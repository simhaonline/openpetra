//
// DO NOT REMOVE COPYRIGHT NOTICES OR THIS FILE HEADER.
//
// @Authors:
//       timop
//       Tim Ingham, alanP
//
// Copyright 2004-2014 by OM International
//
// This file is part of OpenPetra.org.
//
// OpenPetra.org is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// OpenPetra.org is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with OpenPetra.org.  If not, see <http://www.gnu.org/licenses/>.
//

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data;
using Ict.Common;
using Ict.Common.Verification;
using Ict.Common.Controls;
using Ict.Petra.Shared.MFinance.AP.Data;
using Ict.Petra.Client.App.Core;
using Ict.Petra.Client.App.Core.RemoteObjects;
using Ict.Petra.Client.MCommon;
using Ict.Petra.Client.MFinance.Gui.GL;
using Ict.Petra.Shared.Interfaces.MFinance;
using System.Threading;


namespace Ict.Petra.Client.MFinance.Gui.AP
{
    public partial class TUC_OutstandingInvoices
    {
        private bool FKeepUpSearchFinishedCheck = false;

        /// <summary>DataTable that holds all Pages of data (also empty ones that are not retrieved yet!)</summary>
        private DataTable FInvoiceTable;
        private TSgrdDataGridPaged grdDetails;
        private int FPrevRowChangedRow = -1;
        private DataRow FPreviouslySelectedDetailRow = null;

        private TFrmAPMain FMainForm = null;


        /// <summary>
        /// Sets the reference to the main form (the host of this user control)
        /// </summary>
        public TFrmAPMain MainForm
        {
            set
            {
                FMainForm = value;
            }
        }

        private void InitializeManualCode()
        {
            // The auto-generated code requires that the grid be named grdDetails (for filter/find), but that doesn't work for another part of the autogenerated code!
            // So we make grdDetails reference grdInvoices here at initialization
            grdDetails = grdInvoices;
            
            grdInvoices.MouseClick += new MouseEventHandler(grdResult_Click);
            grdInvoices.DataPageLoaded += new TDataPageLoadedEventHandler(grdInvoices_DataPageLoaded);
        }

        /// ////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// These methods are stubs that allow the auto-generated code to compile (we don't have a details panel)

        private void SelectRowInGrid(int ARowNumber)
        {
        }

        /// <summary>
        /// Standard method
        /// </summary>
        public void GetDataFromControls()
        {
        }

        /// <summary>
        /// Standard method
        /// </summary>
        public bool ValidateAllData(bool ADummy1, bool ADummy2)
        {
            return true;
        }

        /// /////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void UpdateRecordNumberDisplay()
        {
            int RecordCount;

            if (grdDetails.DataSource != null)
            {
                int totalTableRecords = grdInvoices.TotalRecords;
                int totalGridRecords = ((DevAge.ComponentModel.BoundDataView)grdDetails.DataSource).Count;
                bool hasFilter = FFilterPanelControls.BaseFilter.Length > 0;

                RecordCount = ((DevAge.ComponentModel.BoundDataView)grdDetails.DataSource).Count;
                lblRecordCounter.Text = String.Format(
                    Catalog.GetPluralString(MCommonResourcestrings.StrSingularRecordCount, MCommonResourcestrings.StrPluralRecordCount, RecordCount, true),
                    RecordCount) + String.Format(" ({0})", totalTableRecords);

                SetRecordNumberDisplayProperties();
                UpdateDisplayedBalance();
            }
        }

        /// <summary>
        /// Call this method to load invoices into the user control
        /// </summary>
        public void LoadInvoices()
        {
            if (FKeepUpSearchFinishedCheck)
            {
                // don't run several searches at the same time
                return;
            }

            if (FInvoiceTable != null)
            {
                // we have loaded the results already - has anything changed?
                if (!FMainForm.IsInvoiceDataChanged)
                {
                    return;
                }
            }

            this.Cursor = Cursors.WaitCursor;

            DataTable CriteriaTable = new DataTable();
            CriteriaTable.Columns.Add("LedgerNumber", typeof(Int32));
            CriteriaTable.Columns.Add("SupplierId", typeof(string));
            CriteriaTable.Columns.Add("DaysPlus", typeof(decimal));

            // From 2014 we load all the data so the only criteria of interest is the ledger number
            DataRow row = CriteriaTable.NewRow();
            row["DaysPlus"] = -1;
            row["SupplierId"] = String.Empty;
            row["LedgerNumber"] = FMainForm.LedgerNumber;
            CriteriaTable.Rows.Add(row);

            // Start the asynchronous search operation on the PetraServer
            grdInvoices.DataSource = null;
            FInvoiceTable = null;
            FMainForm.InvoiceFindObject.FindInvoices(CriteriaTable);

            // Start thread that checks for the end of the search operation on the PetraServer
            FKeepUpSearchFinishedCheck = true;
            Thread FinishedCheckThread = new Thread(new ThreadStart(SearchFinishedCheckThread));
            FinishedCheckThread.Start();
        }

        private void grdInvoices_DataPageLoaded(object Sender, TDataPageLoadEventArgs e)
        {
            this.Cursor = Cursors.Default;
            if (e.DataPage == 0)
            {
                FMainForm.IsInvoiceDataChanged = false;
            }
        }

        private delegate void SimpleDelegate();

        /// <summary>
        /// Thread for the search operation. Monitor's the Server System.Object's
        /// AsyncExecProgress.ProgressState and invokes UI updates from that.
        ///
        /// </summary>
        /// <returns>void</returns>
        private void SearchFinishedCheckThread()
        {
            // Check whether this thread should still execute
            while (FKeepUpSearchFinishedCheck)
            {
                TAsyncExecProgressState ThreadStatus = FMainForm.InvoiceFindObject.AsyncExecProgress.ProgressState;

                /* The next line of code calls a function on the PetraServer
                 * > causes a bit of data traffic everytime! */
                switch (ThreadStatus)
                {
                    case TAsyncExecProgressState.Aeps_Finished:
                        FKeepUpSearchFinishedCheck = false;

                        // see also http://stackoverflow.com/questions/6184/how-do-i-make-event-callbacks-into-my-win-forms-thread-safe
                        if (InvokeRequired)
                        {
                            Invoke(new SimpleDelegate(FinishThread));
                        }
                        else
                        {
                            FinishThread();
                        }

                        break;

                    case TAsyncExecProgressState.Aeps_Stopped:
                        FKeepUpSearchFinishedCheck = false;
                        return;
                }

                // Sleep a bit, then loop...
                Thread.Sleep(200);
            }
        }

        private void FinishThread()
        {
            // Fetch the first page of data
            try
            {
                grdInvoices.MinimumPageSize = 200;
                grdInvoices.LoadFirstDataPage(@GetDataPagedResult);
            }
            catch (Exception E)
            {
                MessageBox.Show(E.ToString());
                return;
            }
            
            InitialiseGrid();

            DataView myDataView = grdInvoices.PagedDataTable.DefaultView;
            myDataView.AllowNew = false;
            grdInvoices.DataSource = new DevAge.ComponentModel.BoundDataView(myDataView);

            string initialFilter = String.Empty;
            ApplyFilterManual(ref initialFilter);

            if (grdInvoices.TotalPages > 0)
            {
                if (grdInvoices.TotalPages > 1)
                {
                    // Now we can load the remaining pages ...
                    grdInvoices.LoadAllDataPages();
                }

                // Highlight first Row
                grdInvoices.Selection.SelectRow(1, true);
            }

            // Size it
            AutoSizeGrid();
            this.Width = this.Width - 1;
            this.Width = this.Width + 1;

            UpdateRecordNumberDisplay();
            UpdateInvoiceBalance();
            UpdateDisplayedBalance();
            RefreshSumTagged(null, null);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="ANeededPage"></param>
        /// <param name="APageSize"></param>
        /// <param name="ATotalRecords"></param>
        /// <param name="ATotalPages"></param>
        /// <returns></returns>
        private DataTable GetDataPagedResult(Int16 ANeededPage, Int16 APageSize, out Int32 ATotalRecords, out Int16 ATotalPages)
        {
            ATotalRecords = 0;
            ATotalPages = 0;

            IAPUIConnectorsFind findObject = FMainForm.InvoiceFindObject;
            if (findObject != null)
            {
                DataTable NewPage = findObject.GetDataPagedResult(ANeededPage, APageSize, out ATotalRecords, out ATotalPages);

                if (FInvoiceTable == null)
                {
                    FInvoiceTable = NewPage;
                }

                return NewPage;
            }

            return null;
        }

        private void InitialiseGrid()
        {
            grdInvoices.Columns.Clear();
            grdInvoices.AddCheckBoxColumn("", FInvoiceTable.Columns["Selected"], 17, false);
            grdInvoices.AddTextColumn("AP#", FInvoiceTable.Columns["ApNumber"], 55);
            grdInvoices.AddTextColumn("Inv#", FInvoiceTable.Columns["DocumentCode"], 90);
            grdInvoices.AddTextColumn("Supplier", FInvoiceTable.Columns["PartnerShortName"], 150);
            grdInvoices.AddCurrencyColumn("Amount", FInvoiceTable.Columns["TotalAmount"], 2);
            grdInvoices.AddCurrencyColumn("Outstanding", FInvoiceTable.Columns["OutstandingAmount"], 2);
            grdInvoices.AddTextColumn("Currency", FInvoiceTable.Columns["CurrencyCode"], 70);
            grdInvoices.AddDateColumn("Due Date", FInvoiceTable.Columns["DateDue"]);
            grdInvoices.AddTextColumn("Status", FInvoiceTable.Columns["DocumentStatus"], 100);
            grdInvoices.AddDateColumn("Issued", FInvoiceTable.Columns["DateIssued"]);
        }

        private void SetInvoiceFilters(object sender, EventArgs e)
        {
            if (FInvoiceTable != null)
            {
                string filter = String.Empty;
                string filterJoint = " AND ";
                DateTime dtToday = DateTime.Today;

                TextBox txtSupplierName = (TextBox)FFilterPanelControls.FindControlByName("txtSupplierName");
                if (txtSupplierName.Text.Trim().Length > 0)
                {
                    filter += String.Format("(PartnerShortName LIKE '%{0}%')", txtSupplierName.Text.Trim());
                }

                RadioButton rbtOverdue = (RadioButton)FFilterPanelControls.FindControlByName("rbtOverdue");
                if (rbtOverdue.Checked)
                {
                    if (filter.Length > 0)
                    {
                        filter += filterJoint;
                    }

                    filter += String.Format("(DateDue < #{0}#)", dtToday.ToString("d", System.Globalization.CultureInfo.InvariantCulture));
                }

                RadioButton rbtDueToday = (RadioButton)FFilterPanelControls.FindControlByName("rbtDueToday");
                if (rbtDueToday.Checked)
                {
                    if (filter.Length > 0)
                    {
                        filter += filterJoint;
                    }

                    filter += String.Format("(DateDue = #{0}#)", dtToday.ToString("d", System.Globalization.CultureInfo.InvariantCulture));
                }

                RadioButton rbtDueThisWeek = (RadioButton)FFilterPanelControls.FindControlByName("rbtDueThisWeek");
                if (rbtDueThisWeek.Checked)
                {
                    if (filter.Length > 0)
                    {
                        filter += filterJoint;
                    }

                    filter += String.Format("(DateDue >= #{0}#) AND (DateDue <= #{0}#)",
                        dtToday.ToString("d", System.Globalization.CultureInfo.InvariantCulture),
                        dtToday.AddDays(7).ToString("d", System.Globalization.CultureInfo.InvariantCulture));
                }

                RadioButton rbtDueThisMonth = (RadioButton)FFilterPanelControls.FindControlByName("rbtDueThisMonth");
                if (rbtDueThisMonth.Checked)
                {
                    if (filter.Length > 0)
                    {
                        filter += filterJoint;
                    }

                    filter += String.Format("(DateDue >= #{0}#) AND (DateDue <= #{0}#)",
                        dtToday.ToString("d", System.Globalization.CultureInfo.InvariantCulture),
                        dtToday.AddDays(30).ToString("d", System.Globalization.CultureInfo.InvariantCulture));
                }

                RadioButton rbtForApproval = (RadioButton)FFilterPanelControls.FindControlByName("rbtForApproval");
                if (rbtForApproval.Checked)
                {
                    if (filter.Length > 0)
                    {
                        filter += filterJoint;
                    }

                    filter += ("(DocumentStatus='' OR DocumentStatus='OPEN')");
                }

                RadioButton rbtForPosting = (RadioButton)FFilterPanelControls.FindControlByName("rbtForPosting");
                if (rbtForPosting.Checked)
                {
                    if (filter.Length > 0)
                    {
                        filter += filterJoint;
                    }

                    filter += ("(DocumentStatus='' OR DocumentStatus='OPEN' OR DocumentStatus='APPROVED')");
                }

                RadioButton rbtForPaying = (RadioButton)FFilterPanelControls.FindControlByName("rbtForPaying");
                if (rbtForPaying.Checked)
                {
                    if (filter.Length > 0)
                    {
                        filter += filterJoint;
                    }

                    filter += ("(DocumentStatus='POSTED' OR DocumentStatus='PARTPAID')");
                }

                FFilterPanelControls.SetBaseFilter(filter, filter.Length == 0);
            }
        }

        private void UpdateDisplayedBalance()
        {
            DevAge.ComponentModel.BoundDataView dv = (DevAge.ComponentModel.BoundDataView)grdInvoices.DataSource;
            txtFilteredBalance.Text = UpdateBalance(dv.DataView).ToString("n2") + " " + FMainForm.LedgerCurrency;
        }

        private void UpdateInvoiceBalance()
        {
            DataView dv = new DataView(FInvoiceTable);
            txtInvoiceBalance.Text = UpdateBalance(dv).ToString("n2") + " " + FMainForm.LedgerCurrency;
        }

        private Decimal UpdateBalance(DataView ADataView)
        {
            Decimal balance = 0.0m;

            if (FInvoiceTable != null)
            {
                foreach (DataRowView rv in ADataView)
                {
                    DataRow Row = rv.Row;

                    if ((Row["CurrencyCode"].ToString() == FMainForm.LedgerCurrency) && (Row["OutstandingAmount"].GetType() == typeof(Decimal)))
                    {
                        if (Row["CreditNoteFlag"].Equals(true))  // Payments also carry this "Credit note" label
                        {
                            balance -= (Decimal)Row["OutstandingAmount"];
                        }
                        else
                        {
                            balance += (Decimal)Row["OutstandingAmount"];
                        }
                    }
                }
            }

            return balance;
        }

        // Called from a timer, below, so that the default processing of
        // the grid control completes before I get called.
        private void RefreshSumTagged(Object Sender, EventArgs e)
        {
            // If I was called from a timer, kill that now:
            if (Sender != null)
            {
                ((System.Windows.Forms.Timer)Sender).Stop();
            }

            if (FInvoiceTable == null) // I may be called before the first search.
            {
                return;
            }

            // Add up all the selected Items  ** I can only sum items that are in my currency! **
            String MyCurrency = FMainForm.LedgerCurrency;

            Decimal TotalSelected = 0;
            int TaggedItemCount = 0;

            foreach (DataRowView rv in FInvoiceTable.DefaultView)
            {
                DataRow Row = rv.Row;

                if (Row["Selected"].Equals(true))
                {
                    TaggedItemCount++;

                    if (Row["CurrencyCode"].Equals(MyCurrency))
                    {
                        if (Row["CreditNoteFlag"].Equals(true))
                        {
                            TotalSelected -= (Decimal)(Row["TotalAmount"]);
                        }
                        else
                        {
                            TotalSelected += (Decimal)(Row["TotalAmount"]);
                        }
                    }
                }
            }

            txtTaggedBalance.Text = TotalSelected.ToString("n2") + " " + FMainForm.LedgerCurrency;
            txtTaggedCount.Text = TaggedItemCount.ToString();
        }

        private void grdResult_Click(object sender, EventArgs e)
        {
            // I want to update the total tagged field,
            // but it needs to be performed AFTER the default processing so I'm using a timer.
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

            timer.Tick += new EventHandler(RefreshSumTagged);
            timer.Interval = 100;
            timer.Start();
        }

        private Int32 GetCurrentlySelectedDocumentId()
        {
            DataRowView[] SelectedGridRow = grdInvoices.SelectedDataRowsAsDataRowView;
            Int32 ApDocumentId = -1;

            if (SelectedGridRow.Length >= 1)
            {
                Object Cell = SelectedGridRow[0]["ApDocumentId"];

                if (Cell.GetType() == typeof(Int32))
                {
                    ApDocumentId = Convert.ToInt32(Cell);
                }
            }

            return ApDocumentId;
        }

        /// <summary>
        /// Open the selected invoice
        /// </summary>
        public void ShowInvoice(object sender, EventArgs e)
        {
            Int32 SelectedInvoice = GetCurrentlySelectedDocumentId();

            if (SelectedInvoice > 0)
            {
                TFrmAPEditDocument frm = new TFrmAPEditDocument(FMainForm);

                if (frm.LoadAApDocument(FMainForm.LedgerNumber, SelectedInvoice))
                {
                    frm.Show();
                }
            }
        }

        ///// <summary>
        ///// Tag all postable rows
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //public void TagAllPostable(object sender, EventArgs e)
        //{
        //    foreach (DataRow Row in grdInvoices.PagedDataTable.Rows)
        //    {
        //        if ("|POSTED|PARTPAID|PAID|".IndexOf("|" + Row["DocumentStatus"].ToString()) < 0)
        //        {
        //            Row["Selected"] = true;
        //        }
        //    }

        //    RefreshSumTagged(null, null);
        //}

        ///// <summary>
        ///// Tag all payable rows
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //public void TagAllPayable(object sender, EventArgs e)
        //{
        //    foreach (DataRow Row in grdInvoices.PagedDataTable.Rows)
        //    {
        //        if ("|POSTED|PARTPAID|".IndexOf("|" + Row["DocumentStatus"].ToString()) >= 0)
        //        {
        //            Row["Selected"] = true;
        //        }
        //    }

        //    RefreshSumTagged(null, null);
        //}

        /// <summary>
        /// Untag all rows
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void UntagAll(object sender, EventArgs e)
        {
            // We do this for all tags in the complete data table
            foreach (DataRow Row in grdInvoices.PagedDataTable.Rows)
            {
                Row["Selected"] = false;
            }

            if (sender != null)
            {
                RefreshSumTagged(null, null);
            }
        }

        /// <summary>
        /// Tag all rows
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void TagAll(object sender, EventArgs e)
        {
            // Untag everything
            UntagAll(null, null);

            // Now tag all the rows in the current view
            foreach (DataRowView rv in grdInvoices.PagedDataTable.DefaultView)
            {
                rv.Row["Selected"] = true;
            }

            RefreshSumTagged(null, null);
        }

        /// <summary>
        /// Open all tagged documents
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OpenAllTagged(object sender, EventArgs e)
        {
            foreach (DataRow Row in grdInvoices.PagedDataTable.Rows)
            {
                if (Row["Selected"].Equals(true))
                {
                    TFrmAPEditDocument frm = new TFrmAPEditDocument(FMainForm);

                    if (frm.LoadAApDocument(FMainForm.LedgerNumber, (int)Row["ApDocumentId"]))
                    {
                        frm.Show();
                    }
                }
            }
        }

        /// <summary>
        /// Approve all tagged rows
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ApproveAllTagged(object sender, EventArgs e)
        {
            throw new NotImplementedException("Sorry! Not yet implemented");
        }

        /// <summary>
        /// Delete all tagged rows
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void DeleteAllTagged(object sender, EventArgs e)
        {
            // I can only delete invoices that are not posted already.
            // This method is only enabled when the grid shows items for Posting
            List<int> DeleteTheseDocs = new List<int>();

            foreach (DataRowView rv in grdInvoices.PagedDataTable.DefaultView)
            {
                if (rv.Row["Selected"].Equals(true))
                {
                    if ("|POSTED|PARTPAID|PAID|".IndexOf("|" + rv.Row["DocumentStatus"].ToString()) < 0)
                    {
                        DeleteTheseDocs.Add((int)rv.Row["ApDocumentId"]);
                    }
                    else
                    {
                        MessageBox.Show(Catalog.GetString("Cannot delete posted documents. Please reverse the document first."),
                            Catalog.GetString("Document Deletion"));
                    }
                }
            }

            if (DeleteTheseDocs.Count > 0)
            {
                string msg = String.Format(Catalog.GetString("Are you sure that you want to delete the {0} tagged document(s)?"), DeleteTheseDocs.Count);

                if (MessageBox.Show(msg, Catalog.GetString("Document Deletion"),
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    return;
                }

                TRemote.MFinance.AP.WebConnectors.DeleteAPDocuments(FMainForm.LedgerNumber, DeleteTheseDocs);
                FMainForm.IsInvoiceDataChanged = true;

                LoadInvoices();
                MessageBox.Show(Catalog.GetString("Document(s) deleted successfully!"), Catalog.GetString("Document Deletion"));
            }
            else
            {
                MessageBox.Show(Catalog.GetString("There we no tagged invoices to be deleted."), Catalog.GetString("Document Deletion"));
            }
        }

        /// <summary>
        /// Post all tagged documents
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void PostAllTagged(object sender, EventArgs e)
        {
            AccountsPayableTDS TempDS = LoadTaggedDocuments();

            List<int> PostTheseDocs = new List<int>();
            TempDS.AApDocument.DefaultView.Sort = AApDocumentDetailTable.GetApDocumentIdDBName();

            foreach (DataRowView rv in grdInvoices.PagedDataTable.DefaultView)
            {
                if ((rv.Row["Selected"].Equals(true) && ("|POSTED|PARTPAID|PAID|".IndexOf(rv.Row["DocumentStatus"].ToString()) < 0)))
                {
                    int DocId = (int)rv.Row["ApDocumentId"];

                    int RowIdx = TempDS.AApDocument.DefaultView.Find(DocId);

                    if (RowIdx >= 0)
                    {
                        AApDocumentRow DocumentRow = (AApDocumentRow)TempDS.AApDocument.DefaultView[RowIdx].Row;

                        if (TFrmAPEditDocument.ApDocumentCanPost(TempDS, DocumentRow)) // This will produce an message box if there's a problem.
                        {
                            PostTheseDocs.Add(DocId);
                        }
                    }
                }
            }

            if (PostTheseDocs.Count > 0)
            {
                string msg = String.Format(Catalog.GetString("Are you sure that you want to post the {0} tagged document(s)?"), PostTheseDocs.Count);

                if (MessageBox.Show(msg, Catalog.GetString("Document Posting"),
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    return;
                }

                if (TFrmAPEditDocument.PostApDocumentList(TempDS, FMainForm.LedgerNumber, PostTheseDocs))
                {
                    // TODO: print reports on successfully posted batch
                    MessageBox.Show(Catalog.GetString("The tagged documents have been posted successfully!"), Catalog.GetString("Document Posting"));
                    FMainForm.IsInvoiceDataChanged = true;

                    LoadInvoices();

                    // TODO: show posting register of GL Batch?
                }
            }
            else
            {
                MessageBox.Show(Catalog.GetString("There we no tagged documents to be posted."), Catalog.GetString("Document Posting"));
            }
        }

        /// <summary>
        /// Reverse all tagged rows
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ReverseAllTagged(object sender, EventArgs e)
        {
            // I can only reverse invoices that are POSTED.
            // This method is only enabled when the grid shows rows for paying
            // This will include rows that are PARTPAID - we need to test for those
            List<int> ReverseTheseDocs = new List<int>();
            int taggedCount = 0;

            foreach (DataRowView rv in grdInvoices.PagedDataTable.DefaultView)
            {
                if (rv.Row["Selected"].Equals(true))
                {
                    taggedCount++;

                    if ("POSTED" == rv.Row["DocumentStatus"].ToString())
                    {
                        ReverseTheseDocs.Add((int)rv.Row["ApDocumentId"]);
                    }
                }
            }

            if (ReverseTheseDocs.Count < taggedCount)
            {
                string msg = Catalog.GetString("Only posted documents can be reversed.  A document cannot be reversed if it has been part-paid.");

                if (ReverseTheseDocs.Count==0)
                {
                    MessageBox.Show(msg, Catalog.GetString("Document Reversal"));
                }
                else
                {
                    msg += Environment.NewLine + Environment.NewLine;
                    msg += Catalog.GetString("Do you want to continue and reverse the 'Posted' documents?");

                    if (MessageBox.Show(msg, Catalog.GetString("Document Reversal"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                }
            }

            if (ReverseTheseDocs.Count > 0)
            {
                TVerificationResultCollection Verifications;
                TDlgGLEnterDateEffective dateEffectiveDialog = new TDlgGLEnterDateEffective(
                    FMainForm.LedgerNumber,
                    Catalog.GetString("Select reversal date"),
                    Catalog.GetString("The date effective for this reversal") + ":");

                if (dateEffectiveDialog.ShowDialog(FMainForm) != DialogResult.OK)
                {
                    MessageBox.Show(Catalog.GetString("Reversal was cancelled."), Catalog.GetString(
                            "Document Reversal"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DateTime PostingDate = dateEffectiveDialog.SelectedDate;

                if (TRemote.MFinance.AP.WebConnectors.PostAPDocuments(
                        FMainForm.LedgerNumber,
                        ReverseTheseDocs,
                        PostingDate,
                        true,
                        out Verifications))
                {
                    System.Windows.Forms.MessageBox.Show(Catalog.GetString("Invoice(s) reversed to Approved status."), Catalog.GetString("Document Reversal"));
                    FMainForm.IsInvoiceDataChanged = true;

                    LoadInvoices();
                    return;
                }
                else
                {
                    string ErrorMessages = Verifications.BuildVerificationResultString();
                    MessageBox.Show(ErrorMessages, Catalog.GetString("Document Reversal"));
                }
            }
            else
            {
                MessageBox.Show(Catalog.GetString("There we no tagged invoices to be reversed."), Catalog.GetString("Document Reversal"));
            }
        }

        /// <summary>
        /// Pay all tagged documents
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void PayAllTagged(object sender, EventArgs e)
        {
            AccountsPayableTDS TempDS = LoadTaggedDocuments();
            TFrmAPPayment PaymentScreen = new TFrmAPPayment(FMainForm);

            List<int> PayTheseDocs = new List<int>();

            foreach (DataRowView rv in grdInvoices.PagedDataTable.DefaultView)
            {
                if ((rv.Row["Selected"].Equals(true)
                     && ("|POSTED|PARTPAID|".IndexOf("|" + rv.Row["DocumentStatus"].ToString() + "|") >= 0)))
                {
                    PayTheseDocs.Add((int)rv.Row["ApDocumentId"]);
                }
            }

            if (PayTheseDocs.Count > 0)
            {
                if (PaymentScreen.AddDocumentsToPayment(TempDS, FMainForm.LedgerNumber, PayTheseDocs))
                {
                    PaymentScreen.Show();
                }
            }
            else
            {
                MessageBox.Show(Catalog.GetString("There we no tagged documents to be paid."), Catalog.GetString("Document Payment"));
            }
        }

        /// <summary>
        /// Load all tagged documents into a typed data set.  (Used for posting and paying)
        /// </summary>
        /// <returns></returns>
        private AccountsPayableTDS LoadTaggedDocuments()
        {
            AccountsPayableTDS LoadDs = new AccountsPayableTDS();

            foreach (DataRow Row in grdInvoices.PagedDataTable.Rows)
            {
                if (Row["Selected"].Equals(true))
                {
                    LoadDs.Merge(TRemote.MFinance.AP.WebConnectors.LoadAApDocument(FMainForm.LedgerNumber, (int)Row["ApDocumentId"]));
                }
            }

            return LoadDs;
        }

        private void ApplyFilterManual(ref string AFilter)
        {
            if (FInvoiceTable != null)
            {
                FInvoiceTable.DefaultView.RowFilter = AFilter;

                bool gotRows = (grdDetails.Rows.Count > 1);
                bool canApprove = ((RadioButton)FFilterPanelControls.FindControlByName("rbtForApproval")).Checked && gotRows;
                bool canPost = ((RadioButton)FFilterPanelControls.FindControlByName("rbtForPosting")).Checked && gotRows;
                bool canPay = ((RadioButton)FFilterPanelControls.FindControlByName("rbtForPaying")).Checked && gotRows;

                bool canTag = canApprove || canPost || canPay;

                ActionEnabledEvent(null, new ActionEventArgs("actTagAll", canTag));
                ActionEnabledEvent(null, new ActionEventArgs("actUntagAll", canTag));
                ActionEnabledEvent(null, new ActionEventArgs("actApproveTagged", canApprove));
                ActionEnabledEvent(null, new ActionEventArgs("actPostTagged", canPost));
                ActionEnabledEvent(null, new ActionEventArgs("actPayTagged", canPay));
                ActionEnabledEvent(null, new ActionEventArgs("actReverseTagged", canPay));

                FMainForm.ActionEnabledEvent(null, new ActionEventArgs("actOpenTagged", gotRows));
                FMainForm.ActionEnabledEvent(null, new ActionEventArgs("actApproveTagged", canApprove));
                FMainForm.ActionEnabledEvent(null, new ActionEventArgs("actPostTagged", canPost));
                FMainForm.ActionEnabledEvent(null, new ActionEventArgs("actDeleteTagged", canPost));
                FMainForm.ActionEnabledEvent(null, new ActionEventArgs("actPayTagged", canPay));
                FMainForm.ActionEnabledEvent(null, new ActionEventArgs("actReverseTagged", canPay));
            }
        }

        private void FilterToggledManual(bool AFilterIsOff)
        {
            AutoSizeGrid();
        }

        private void AutoSizeGrid()
        {
            if (grdDetails.Columns.Count == 0)
            {
                // Not created yet
                return;
            }

            foreach (SourceGrid.DataGridColumn column in grdDetails.Columns)
            {
                column.Width = 100;
                column.AutoSizeMode = SourceGrid.AutoSizeMode.EnableStretch;
            }

            grdDetails.Columns[0].Width = 20;
            grdDetails.Columns[1].Width = 75;
            grdDetails.Columns[2].AutoSizeMode = SourceGrid.AutoSizeMode.Default;
            grdDetails.Columns[3].AutoSizeMode = SourceGrid.AutoSizeMode.Default;
            grdDetails.Columns[6].Width = 75;

            grdDetails.AutoStretchColumnsToFitWidth = true;
            grdDetails.Rows.AutoSizeMode = SourceGrid.AutoSizeMode.None;
            grdInvoices.SuspendLayout();
            grdDetails.AutoSizeCells();
            grdInvoices.ResumeLayout();
        }
    }
}