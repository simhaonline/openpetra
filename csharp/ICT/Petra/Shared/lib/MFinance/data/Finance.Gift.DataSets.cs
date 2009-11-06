/* Auto generated with nant generateORM
 * Do not modify this file manually!
 */
/*************************************************************************
 *
 * DO NOT REMOVE COPYRIGHT NOTICES OR THIS FILE HEADER.
 *
 * @Authors:
 *       auto generated
 *
 * Copyright 2004-2009 by OM International
 *
 * This file is part of OpenPetra.org.
 *
 * OpenPetra.org is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * OpenPetra.org is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with OpenPetra.org.  If not, see <http://www.gnu.org/licenses/>.
 *
 ************************************************************************/
namespace Ict.Petra.Shared.MFinance.Gift.Data
{
    using Ict.Common;
    using Ict.Common.Data;
    using System;
    using System.Data;
    using System.Data.Odbc;
    using Ict.Petra.Shared.MFinance.Gift.Data;
    using Ict.Petra.Shared.MFinance.Account.Data;
    using Ict.Petra.Shared.MPartner.Partner.Data;

     /// auto generated
    [Serializable()]
    public class GiftBatchTDS : TTypedDataSet
    {

        private ALedgerTable TableALedger;
        private AGiftBatchTable TableAGiftBatch;
        private AGiftTable TableAGift;
        private GiftBatchTDSAGiftDetailTable TableAGiftDetail;
        private AMotivationDetailTable TableAMotivationDetail;
        private AMotivationGroupTable TableAMotivationGroup;

        /// auto generated
        public GiftBatchTDS() :
                base("GiftBatchTDS")
        {
        }

        /// auto generated for serialization
        public GiftBatchTDS(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) :
                base(info, context)
        {
        }

        /// auto generated
        public GiftBatchTDS(string ADatasetName) :
                base(ADatasetName)
        {
        }

        /// auto generated
        public ALedgerTable ALedger
        {
            get
            {
                return this.TableALedger;
            }
        }

        /// auto generated
        public AGiftBatchTable AGiftBatch
        {
            get
            {
                return this.TableAGiftBatch;
            }
        }

        /// auto generated
        public AGiftTable AGift
        {
            get
            {
                return this.TableAGift;
            }
        }

        /// auto generated
        public GiftBatchTDSAGiftDetailTable AGiftDetail
        {
            get
            {
                return this.TableAGiftDetail;
            }
        }

        /// auto generated
        public AMotivationDetailTable AMotivationDetail
        {
            get
            {
                return this.TableAMotivationDetail;
            }
        }

        /// auto generated
        public AMotivationGroupTable AMotivationGroup
        {
            get
            {
                return this.TableAMotivationGroup;
            }
        }

        /// auto generated
        public new virtual GiftBatchTDS GetChangesTyped(bool removeEmptyTables)
        {
            return ((GiftBatchTDS)(base.GetChangesTyped(removeEmptyTables)));
        }

        /// auto generated
        protected override void InitTables()
        {
            this.Tables.Add(new ALedgerTable("ALedger"));
            this.Tables.Add(new AGiftBatchTable("AGiftBatch"));
            this.Tables.Add(new AGiftTable("AGift"));
            this.Tables.Add(new GiftBatchTDSAGiftDetailTable("AGiftDetail"));
            this.Tables.Add(new AMotivationDetailTable("AMotivationDetail"));
            this.Tables.Add(new AMotivationGroupTable("AMotivationGroup"));
        }

        /// auto generated
        protected override void InitTables(System.Data.DataSet ds)
        {
            if ((ds.Tables.IndexOf("ALedger") != -1))
            {
                this.Tables.Add(new ALedgerTable("ALedger"));
            }
            if ((ds.Tables.IndexOf("AGiftBatch") != -1))
            {
                this.Tables.Add(new AGiftBatchTable("AGiftBatch"));
            }
            if ((ds.Tables.IndexOf("AGift") != -1))
            {
                this.Tables.Add(new AGiftTable("AGift"));
            }
            if ((ds.Tables.IndexOf("AGiftDetail") != -1))
            {
                this.Tables.Add(new GiftBatchTDSAGiftDetailTable("AGiftDetail"));
            }
            if ((ds.Tables.IndexOf("AMotivationDetail") != -1))
            {
                this.Tables.Add(new AMotivationDetailTable("AMotivationDetail"));
            }
            if ((ds.Tables.IndexOf("AMotivationGroup") != -1))
            {
                this.Tables.Add(new AMotivationGroupTable("AMotivationGroup"));
            }
        }

        /// auto generated
        protected override void MapTables()
        {
            this.InitVars();
            base.MapTables();
            if ((this.TableALedger != null))
            {
                this.TableALedger.InitVars();
            }
            if ((this.TableAGiftBatch != null))
            {
                this.TableAGiftBatch.InitVars();
            }
            if ((this.TableAGift != null))
            {
                this.TableAGift.InitVars();
            }
            if ((this.TableAGiftDetail != null))
            {
                this.TableAGiftDetail.InitVars();
            }
            if ((this.TableAMotivationDetail != null))
            {
                this.TableAMotivationDetail.InitVars();
            }
            if ((this.TableAMotivationGroup != null))
            {
                this.TableAMotivationGroup.InitVars();
            }
        }

        /// auto generated
        public override void InitVars()
        {
            this.DataSetName = "GiftBatchTDS";
            this.TableALedger = ((ALedgerTable)(this.Tables["ALedger"]));
            this.TableAGiftBatch = ((AGiftBatchTable)(this.Tables["AGiftBatch"]));
            this.TableAGift = ((AGiftTable)(this.Tables["AGift"]));
            this.TableAGiftDetail = ((GiftBatchTDSAGiftDetailTable)(this.Tables["AGiftDetail"]));
            this.TableAMotivationDetail = ((AMotivationDetailTable)(this.Tables["AMotivationDetail"]));
            this.TableAMotivationGroup = ((AMotivationGroupTable)(this.Tables["AMotivationGroup"]));
        }

        /// auto generated
        protected override void InitConstraints()
        {

            if (((this.TableAGiftBatch != null)
                        && (this.TableAGift != null)))
            {
                this.FConstraints.Add(new TTypedConstraint("FKGift1", "AGiftBatch", new string[] {
                                "a_ledger_number_i", "a_batch_number_i"}, "AGift", new string[] {
                                "a_ledger_number_i", "a_batch_number_i"}));
            }
            if (((this.TableALedger != null)
                        && (this.TableAGiftBatch != null)))
            {
                this.FConstraints.Add(new TTypedConstraint("FKGiftBatch1", "ALedger", new string[] {
                                "a_ledger_number_i"}, "AGiftBatch", new string[] {
                                "a_ledger_number_i"}));
            }
            if (((this.TableAGift != null)
                        && (this.TableAGiftDetail != null)))
            {
                this.FConstraints.Add(new TTypedConstraint("FKGiftDetail1", "AGift", new string[] {
                                "a_ledger_number_i", "a_batch_number_i", "a_gift_transaction_number_i"}, "AGiftDetail", new string[] {
                                "a_ledger_number_i", "a_batch_number_i", "a_gift_transaction_number_i"}));
            }
            if (((this.TableAMotivationDetail != null)
                        && (this.TableAGiftDetail != null)))
            {
                this.FConstraints.Add(new TTypedConstraint("FKGiftDetail2", "AMotivationDetail", new string[] {
                                "a_ledger_number_i", "a_motivation_group_code_c", "a_motivation_detail_code_c"}, "AGiftDetail", new string[] {
                                "a_ledger_number_i", "a_motivation_group_code_c", "a_motivation_detail_code_c"}));
            }
            if (((this.TableAMotivationGroup != null)
                        && (this.TableAMotivationDetail != null)))
            {
                this.FConstraints.Add(new TTypedConstraint("FKMotivationDetail1", "AMotivationGroup", new string[] {
                                "a_ledger_number_i", "a_motivation_group_code_c"}, "AMotivationDetail", new string[] {
                                "a_ledger_number_i", "a_motivation_group_code_c"}));
            }
            if (((this.TableALedger != null)
                        && (this.TableAMotivationGroup != null)))
            {
                this.FConstraints.Add(new TTypedConstraint("FKMotivationGroup1", "ALedger", new string[] {
                                "a_ledger_number_i"}, "AMotivationGroup", new string[] {
                                "a_ledger_number_i"}));
            }
        }
    }

    /// The gift recipient information for a gift.  A single gift can be split among more than one recipient.  A gift detail record is created for each recipient.
    [Serializable()]
    public class GiftBatchTDSAGiftDetailTable : AGiftDetailTable
    {
        /// TableId for Ict.Common.Data generic functions
        public new static short TableId = 5600;
        /// used for generic TTypedDataTable functions
        public static short ColumnDonorKeyId = 29;
        /// used for generic TTypedDataTable functions
        public static short ColumnDonorNameId = 30;
        /// used for generic TTypedDataTable functions
        public static short ColumnRecipientDescriptionId = 31;
        /// used for generic TTypedDataTable functions
        public static short ColumnAccountCodeId = 32;

        private static bool FInitInfoValues = InitInfoValues();
        private static bool InitInfoValues()
        {
            TableInfo.Add(TableId, new TTypedTableInfo(TableId, "AGiftDetail", "a_gift_detail",
                new TTypedColumnInfo[] {
                    new TTypedColumnInfo(0, "LedgerNumber", "a_ledger_number_i", "Ledger Number", OdbcType.Int, -1, true),
                    new TTypedColumnInfo(1, "BatchNumber", "a_batch_number_i", "Gift Batch Number", OdbcType.Int, -1, true),
                    new TTypedColumnInfo(2, "GiftTransactionNumber", "a_gift_transaction_number_i", "Gift Transaction Number", OdbcType.Int, -1, true),
                    new TTypedColumnInfo(3, "DetailNumber", "a_detail_number_i", "Gift Number", OdbcType.Int, -1, true),
                    new TTypedColumnInfo(4, "RecipientLedgerNumber", "a_recipient_ledger_number_n", "Recipient Ledger", OdbcType.Decimal, 10, true),
                    new TTypedColumnInfo(5, "GiftAmount", "a_gift_amount_n", "Gift Amount", OdbcType.Decimal, 24, false),
                    new TTypedColumnInfo(6, "MotivationGroupCode", "a_motivation_group_code_c", "Motivation Group", OdbcType.VarChar, 16, true),
                    new TTypedColumnInfo(7, "MotivationDetailCode", "a_motivation_detail_code_c", "Motivation Detail", OdbcType.VarChar, 16, true),
                    new TTypedColumnInfo(8, "CommentOneType", "a_comment_one_type_c", "Comment Type", OdbcType.VarChar, 24, false),
                    new TTypedColumnInfo(9, "GiftCommentOne", "a_gift_comment_one_c", "Comment One", OdbcType.VarChar, 160, false),
                    new TTypedColumnInfo(10, "ConfidentialGiftFlag", "a_confidential_gift_flag_l", "Confidential Gift", OdbcType.Bit, -1, true),
                    new TTypedColumnInfo(11, "TaxDeductable", "a_tax_deductable_l", "Tax Deductable", OdbcType.Bit, -1, false),
                    new TTypedColumnInfo(12, "RecipientKey", "p_recipient_key_n", "Recipient", OdbcType.Decimal, 10, true),
                    new TTypedColumnInfo(13, "ChargeFlag", "a_charge_flag_l", "Charge Fee", OdbcType.Bit, -1, false),
                    new TTypedColumnInfo(14, "CostCentreCode", "a_cost_centre_code_c", "Cost Centre Code", OdbcType.VarChar, 24, false),
                    new TTypedColumnInfo(15, "GiftAmountIntl", "a_gift_amount_intl_n", "International Gift Amount", OdbcType.Decimal, 24, false),
                    new TTypedColumnInfo(16, "ModifiedDetail", "a_modified_detail_l", "Part of a gift detail modification", OdbcType.Bit, -1, false),
                    new TTypedColumnInfo(17, "GiftTransactionAmount", "a_gift_transaction_amount_n", "Transaction Gift Amount", OdbcType.Decimal, 24, true),
                    new TTypedColumnInfo(18, "IchNumber", "a_ich_number_i", "ICH Process Number", OdbcType.Int, -1, true),
                    new TTypedColumnInfo(19, "MailingCode", "p_mailing_code_c", "Mailing Code", OdbcType.VarChar, 50, false),
                    new TTypedColumnInfo(20, "CommentTwoType", "a_comment_two_type_c", "Comment Type", OdbcType.VarChar, 24, false),
                    new TTypedColumnInfo(21, "GiftCommentTwo", "a_gift_comment_two_c", "Comment Two", OdbcType.VarChar, 160, false),
                    new TTypedColumnInfo(22, "CommentThreeType", "a_comment_three_type_c", "Comment Type", OdbcType.VarChar, 24, false),
                    new TTypedColumnInfo(23, "GiftCommentThree", "a_gift_comment_three_c", "Comment Three", OdbcType.VarChar, 160, false),
                    new TTypedColumnInfo(24, "DateCreated", "s_date_created_d", "Created Date", OdbcType.Date, -1, false),
                    new TTypedColumnInfo(25, "CreatedBy", "s_created_by_c", "Created By", OdbcType.VarChar, 20, false),
                    new TTypedColumnInfo(26, "DateModified", "s_date_modified_d", "Modified Date", OdbcType.Date, -1, false),
                    new TTypedColumnInfo(27, "ModifiedBy", "s_modified_by_c", "Modified By", OdbcType.VarChar, 20, false),
                    new TTypedColumnInfo(28, "ModificationId", "s_modification_id_c", "", OdbcType.VarChar, 150, false),
                    new TTypedColumnInfo(29, "DonorKey", "DonorKey", "", OdbcType.Int, -1, false),
                    new TTypedColumnInfo(30, "DonorName", "DonorName", "", OdbcType.Int, -1, false),
                    new TTypedColumnInfo(31, "RecipientDescription", "RecipientDescription", "", OdbcType.Int, -1, false),
                    new TTypedColumnInfo(32, "AccountCode", "AccountCode", "", OdbcType.Int, -1, false)
                },
                new int[] {
                    0, 1, 2, 3
                }));
            return true;
        }

        /// constructor
        public GiftBatchTDSAGiftDetailTable() :
                base("AGiftDetail")
        {
        }

        /// constructor
        public GiftBatchTDSAGiftDetailTable(string ATablename) :
                base(ATablename)
        {
        }

        /// constructor for serialization
        public GiftBatchTDSAGiftDetailTable(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) :
                base(info, context)
        {
        }

        ///
        public DataColumn ColumnDonorKey;
        ///
        public DataColumn ColumnDonorName;
        ///
        public DataColumn ColumnRecipientDescription;
        ///
        public DataColumn ColumnAccountCode;

        /// create the columns
        protected override void InitClass()
        {
            this.Columns.Add(new System.Data.DataColumn("a_ledger_number_i", typeof(Int32)));
            this.Columns.Add(new System.Data.DataColumn("a_batch_number_i", typeof(Int32)));
            this.Columns.Add(new System.Data.DataColumn("a_gift_transaction_number_i", typeof(Int32)));
            this.Columns.Add(new System.Data.DataColumn("a_detail_number_i", typeof(Int32)));
            this.Columns.Add(new System.Data.DataColumn("a_recipient_ledger_number_n", typeof(Int64)));
            this.Columns.Add(new System.Data.DataColumn("a_gift_amount_n", typeof(Double)));
            this.Columns.Add(new System.Data.DataColumn("a_motivation_group_code_c", typeof(String)));
            this.Columns.Add(new System.Data.DataColumn("a_motivation_detail_code_c", typeof(String)));
            this.Columns.Add(new System.Data.DataColumn("a_comment_one_type_c", typeof(String)));
            this.Columns.Add(new System.Data.DataColumn("a_gift_comment_one_c", typeof(String)));
            this.Columns.Add(new System.Data.DataColumn("a_confidential_gift_flag_l", typeof(Boolean)));
            this.Columns.Add(new System.Data.DataColumn("a_tax_deductable_l", typeof(Boolean)));
            this.Columns.Add(new System.Data.DataColumn("p_recipient_key_n", typeof(Int64)));
            this.Columns.Add(new System.Data.DataColumn("a_charge_flag_l", typeof(Boolean)));
            this.Columns.Add(new System.Data.DataColumn("a_cost_centre_code_c", typeof(String)));
            this.Columns.Add(new System.Data.DataColumn("a_gift_amount_intl_n", typeof(Double)));
            this.Columns.Add(new System.Data.DataColumn("a_modified_detail_l", typeof(Boolean)));
            this.Columns.Add(new System.Data.DataColumn("a_gift_transaction_amount_n", typeof(Double)));
            this.Columns.Add(new System.Data.DataColumn("a_ich_number_i", typeof(Int32)));
            this.Columns.Add(new System.Data.DataColumn("p_mailing_code_c", typeof(String)));
            this.Columns.Add(new System.Data.DataColumn("a_comment_two_type_c", typeof(String)));
            this.Columns.Add(new System.Data.DataColumn("a_gift_comment_two_c", typeof(String)));
            this.Columns.Add(new System.Data.DataColumn("a_comment_three_type_c", typeof(String)));
            this.Columns.Add(new System.Data.DataColumn("a_gift_comment_three_c", typeof(String)));
            this.Columns.Add(new System.Data.DataColumn("s_date_created_d", typeof(System.DateTime)));
            this.Columns.Add(new System.Data.DataColumn("s_created_by_c", typeof(String)));
            this.Columns.Add(new System.Data.DataColumn("s_date_modified_d", typeof(System.DateTime)));
            this.Columns.Add(new System.Data.DataColumn("s_modified_by_c", typeof(String)));
            this.Columns.Add(new System.Data.DataColumn("s_modification_id_c", typeof(String)));
            this.Columns.Add(new System.Data.DataColumn("DonorKey", typeof(Int64)));
            this.Columns.Add(new System.Data.DataColumn("DonorName", typeof(string)));
            this.Columns.Add(new System.Data.DataColumn("RecipientDescription", typeof(string)));
            this.Columns.Add(new System.Data.DataColumn("AccountCode", typeof(string)));
        }

        /// assign columns to properties, set primary key
        public override void InitVars()
        {
            this.ColumnLedgerNumber = this.Columns["a_ledger_number_i"];
            this.ColumnBatchNumber = this.Columns["a_batch_number_i"];
            this.ColumnGiftTransactionNumber = this.Columns["a_gift_transaction_number_i"];
            this.ColumnDetailNumber = this.Columns["a_detail_number_i"];
            this.ColumnRecipientLedgerNumber = this.Columns["a_recipient_ledger_number_n"];
            this.ColumnGiftAmount = this.Columns["a_gift_amount_n"];
            this.ColumnMotivationGroupCode = this.Columns["a_motivation_group_code_c"];
            this.ColumnMotivationDetailCode = this.Columns["a_motivation_detail_code_c"];
            this.ColumnCommentOneType = this.Columns["a_comment_one_type_c"];
            this.ColumnGiftCommentOne = this.Columns["a_gift_comment_one_c"];
            this.ColumnConfidentialGiftFlag = this.Columns["a_confidential_gift_flag_l"];
            this.ColumnTaxDeductable = this.Columns["a_tax_deductable_l"];
            this.ColumnRecipientKey = this.Columns["p_recipient_key_n"];
            this.ColumnChargeFlag = this.Columns["a_charge_flag_l"];
            this.ColumnCostCentreCode = this.Columns["a_cost_centre_code_c"];
            this.ColumnGiftAmountIntl = this.Columns["a_gift_amount_intl_n"];
            this.ColumnModifiedDetail = this.Columns["a_modified_detail_l"];
            this.ColumnGiftTransactionAmount = this.Columns["a_gift_transaction_amount_n"];
            this.ColumnIchNumber = this.Columns["a_ich_number_i"];
            this.ColumnMailingCode = this.Columns["p_mailing_code_c"];
            this.ColumnCommentTwoType = this.Columns["a_comment_two_type_c"];
            this.ColumnGiftCommentTwo = this.Columns["a_gift_comment_two_c"];
            this.ColumnCommentThreeType = this.Columns["a_comment_three_type_c"];
            this.ColumnGiftCommentThree = this.Columns["a_gift_comment_three_c"];
            this.ColumnDateCreated = this.Columns["s_date_created_d"];
            this.ColumnCreatedBy = this.Columns["s_created_by_c"];
            this.ColumnDateModified = this.Columns["s_date_modified_d"];
            this.ColumnModifiedBy = this.Columns["s_modified_by_c"];
            this.ColumnModificationId = this.Columns["s_modification_id_c"];
            this.ColumnDonorKey = this.Columns["DonorKey"];
            this.ColumnDonorName = this.Columns["DonorName"];
            this.ColumnRecipientDescription = this.Columns["RecipientDescription"];
            this.ColumnAccountCode = this.Columns["AccountCode"];
            this.PrimaryKey = new System.Data.DataColumn[4] {
                    ColumnLedgerNumber,ColumnBatchNumber,ColumnGiftTransactionNumber,ColumnDetailNumber};
        }

        /// Access a typed row by index
        public new GiftBatchTDSAGiftDetailRow this[int i]
        {
            get
            {
                return ((GiftBatchTDSAGiftDetailRow)(this.Rows[i]));
            }
        }

        /// create a new typed row
        public new GiftBatchTDSAGiftDetailRow NewRowTyped(bool AWithDefaultValues)
        {
            GiftBatchTDSAGiftDetailRow ret = ((GiftBatchTDSAGiftDetailRow)(this.NewRow()));
            if ((AWithDefaultValues == true))
            {
                ret.InitValues();
            }
            return ret;
        }

        /// create a new typed row, always with default values
        public new GiftBatchTDSAGiftDetailRow NewRowTyped()
        {
            return this.NewRowTyped(true);
        }

        /// new typed row using DataRowBuilder
        protected override System.Data.DataRow NewRowFromBuilder(System.Data.DataRowBuilder builder)
        {
            return new GiftBatchTDSAGiftDetailRow(builder);
        }

        /// get typed set of changes
        public new GiftBatchTDSAGiftDetailTable GetChangesTyped()
        {
            return ((GiftBatchTDSAGiftDetailTable)(base.GetChangesTypedInternal()));
        }

        /// return the CamelCase name of the table
        public static new string GetTableName()
        {
            return "AGiftDetail";
        }

        /// return the name of the table as it is used in the database
        public static new string GetTableDBName()
        {
            return "a_gift_detail";
        }

        /// get an odbc parameter for the given column
        public override OdbcParameter CreateOdbcParameter(Int32 AColumnNr)
        {
            return CreateOdbcParameter(TableId, AColumnNr);
        }

        /// get the name of the field in the database for this column
        public static string GetDonorKeyDBName()
        {
            return "DonorKey";
        }

        /// get character length for column
        public static short GetDonorKeyLength()
        {
            return -1;
        }

        /// get the name of the field in the database for this column
        public static string GetDonorNameDBName()
        {
            return "DonorName";
        }

        /// get character length for column
        public static short GetDonorNameLength()
        {
            return -1;
        }

        /// get the name of the field in the database for this column
        public static string GetRecipientDescriptionDBName()
        {
            return "RecipientDescription";
        }

        /// get character length for column
        public static short GetRecipientDescriptionLength()
        {
            return -1;
        }

        /// get the name of the field in the database for this column
        public static string GetAccountCodeDBName()
        {
            return "AccountCode";
        }

        /// get character length for column
        public static short GetAccountCodeLength()
        {
            return -1;
        }

    }

    /// The gift recipient information for a gift.  A single gift can be split among more than one recipient.  A gift detail record is created for each recipient.
    [Serializable()]
    public class GiftBatchTDSAGiftDetailRow : AGiftDetailRow
    {
        private GiftBatchTDSAGiftDetailTable myTable;

        /// Constructor
        public GiftBatchTDSAGiftDetailRow(System.Data.DataRowBuilder rb) :
                base(rb)
        {
            this.myTable = ((GiftBatchTDSAGiftDetailTable)(this.Table));
        }

        ///
        public Int64 DonorKey
        {
            get
            {
                object ret;
                ret = this[this.myTable.ColumnDonorKey.Ordinal];
                if ((ret == System.DBNull.Value))
                {
                    throw new System.Data.StrongTypingException("Error: DB null", null);
                }
                else
                {
                    return ((Int64)(ret));
                }
            }
            set
            {
                if ((this.IsNull(this.myTable.ColumnDonorKey)
                            || (((Int64)(this[this.myTable.ColumnDonorKey])) != value)))
                {
                    this[this.myTable.ColumnDonorKey] = value;
                }
            }
        }

        ///
        public string DonorName
        {
            get
            {
                object ret;
                ret = this[this.myTable.ColumnDonorName.Ordinal];
                if ((ret == System.DBNull.Value))
                {
                    return String.Empty;
                }
                else
                {
                    return ((string)(ret));
                }
            }
            set
            {
                if ((this.IsNull(this.myTable.ColumnDonorName)
                            || (((string)(this[this.myTable.ColumnDonorName])) != value)))
                {
                    this[this.myTable.ColumnDonorName] = value;
                }
            }
        }

        ///
        public string RecipientDescription
        {
            get
            {
                object ret;
                ret = this[this.myTable.ColumnRecipientDescription.Ordinal];
                if ((ret == System.DBNull.Value))
                {
                    return String.Empty;
                }
                else
                {
                    return ((string)(ret));
                }
            }
            set
            {
                if ((this.IsNull(this.myTable.ColumnRecipientDescription)
                            || (((string)(this[this.myTable.ColumnRecipientDescription])) != value)))
                {
                    this[this.myTable.ColumnRecipientDescription] = value;
                }
            }
        }

        ///
        public string AccountCode
        {
            get
            {
                object ret;
                ret = this[this.myTable.ColumnAccountCode.Ordinal];
                if ((ret == System.DBNull.Value))
                {
                    return String.Empty;
                }
                else
                {
                    return ((string)(ret));
                }
            }
            set
            {
                if ((this.IsNull(this.myTable.ColumnAccountCode)
                            || (((string)(this[this.myTable.ColumnAccountCode])) != value)))
                {
                    this[this.myTable.ColumnAccountCode] = value;
                }
            }
        }

        /// set default values
        public override void InitValues()
        {
            this[this.myTable.ColumnLedgerNumber.Ordinal] = 0;
            this[this.myTable.ColumnBatchNumber.Ordinal] = 0;
            this[this.myTable.ColumnGiftTransactionNumber.Ordinal] = 0;
            this[this.myTable.ColumnDetailNumber.Ordinal] = 0;
            this[this.myTable.ColumnRecipientLedgerNumber.Ordinal] = 0;
            this[this.myTable.ColumnGiftAmount.Ordinal] = 0;
            this.SetNull(this.myTable.ColumnMotivationGroupCode);
            this.SetNull(this.myTable.ColumnMotivationDetailCode);
            this.SetNull(this.myTable.ColumnCommentOneType);
            this.SetNull(this.myTable.ColumnGiftCommentOne);
            this[this.myTable.ColumnConfidentialGiftFlag.Ordinal] = false;
            this[this.myTable.ColumnTaxDeductable.Ordinal] = true;
            this[this.myTable.ColumnRecipientKey.Ordinal] = 0;
            this[this.myTable.ColumnChargeFlag.Ordinal] = true;
            this.SetNull(this.myTable.ColumnCostCentreCode);
            this[this.myTable.ColumnGiftAmountIntl.Ordinal] = 0;
            this[this.myTable.ColumnModifiedDetail.Ordinal] = false;
            this[this.myTable.ColumnGiftTransactionAmount.Ordinal] = 0;
            this[this.myTable.ColumnIchNumber.Ordinal] = 0;
            this.SetNull(this.myTable.ColumnMailingCode);
            this.SetNull(this.myTable.ColumnCommentTwoType);
            this.SetNull(this.myTable.ColumnGiftCommentTwo);
            this.SetNull(this.myTable.ColumnCommentThreeType);
            this.SetNull(this.myTable.ColumnGiftCommentThree);
            this[this.myTable.ColumnDateCreated.Ordinal] = DateTime.Today;
            this.SetNull(this.myTable.ColumnCreatedBy);
            this.SetNull(this.myTable.ColumnDateModified);
            this.SetNull(this.myTable.ColumnModifiedBy);
            this.SetNull(this.myTable.ColumnModificationId);
            this.SetNull(this.myTable.ColumnDonorKey);
            this.SetNull(this.myTable.ColumnDonorName);
            this.SetNull(this.myTable.ColumnRecipientDescription);
            this.SetNull(this.myTable.ColumnAccountCode);
        }

        /// test for NULL value
        public bool IsDonorKeyNull()
        {
            return this.IsNull(this.myTable.ColumnDonorKey);
        }

        /// assign NULL value
        public void SetDonorKeyNull()
        {
            this.SetNull(this.myTable.ColumnDonorKey);
        }

        /// test for NULL value
        public bool IsDonorNameNull()
        {
            return this.IsNull(this.myTable.ColumnDonorName);
        }

        /// assign NULL value
        public void SetDonorNameNull()
        {
            this.SetNull(this.myTable.ColumnDonorName);
        }

        /// test for NULL value
        public bool IsRecipientDescriptionNull()
        {
            return this.IsNull(this.myTable.ColumnRecipientDescription);
        }

        /// assign NULL value
        public void SetRecipientDescriptionNull()
        {
            this.SetNull(this.myTable.ColumnRecipientDescription);
        }

        /// test for NULL value
        public bool IsAccountCodeNull()
        {
            return this.IsNull(this.myTable.ColumnAccountCode);
        }

        /// assign NULL value
        public void SetAccountCodeNull()
        {
            this.SetNull(this.myTable.ColumnAccountCode);
        }
    }

     /// auto generated
    [Serializable()]
    public class BankImportTDS : TTypedDataSet
    {

        private BankImportTDSAGiftDetailTable TableAGiftDetail;
        private BankImportTDSPBankingDetailsTable TablePBankingDetails;
        private BankImportTDSAEpTransactionTable TableAEpTransaction;
        private AEpMatchTable TableAEpMatch;

        /// auto generated
        public BankImportTDS() :
                base("BankImportTDS")
        {
        }

        /// auto generated for serialization
        public BankImportTDS(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) :
                base(info, context)
        {
        }

        /// auto generated
        public BankImportTDS(string ADatasetName) :
                base(ADatasetName)
        {
        }

        /// auto generated
        public BankImportTDSAGiftDetailTable AGiftDetail
        {
            get
            {
                return this.TableAGiftDetail;
            }
        }

        /// auto generated
        public BankImportTDSPBankingDetailsTable PBankingDetails
        {
            get
            {
                return this.TablePBankingDetails;
            }
        }

        /// auto generated
        public BankImportTDSAEpTransactionTable AEpTransaction
        {
            get
            {
                return this.TableAEpTransaction;
            }
        }

        /// auto generated
        public AEpMatchTable AEpMatch
        {
            get
            {
                return this.TableAEpMatch;
            }
        }

        /// auto generated
        public new virtual BankImportTDS GetChangesTyped(bool removeEmptyTables)
        {
            return ((BankImportTDS)(base.GetChangesTyped(removeEmptyTables)));
        }

        /// auto generated
        protected override void InitTables()
        {
            this.Tables.Add(new BankImportTDSAGiftDetailTable("AGiftDetail"));
            this.Tables.Add(new BankImportTDSPBankingDetailsTable("PBankingDetails"));
            this.Tables.Add(new BankImportTDSAEpTransactionTable("AEpTransaction"));
            this.Tables.Add(new AEpMatchTable("AEpMatch"));
        }

        /// auto generated
        protected override void InitTables(System.Data.DataSet ds)
        {
            if ((ds.Tables.IndexOf("AGiftDetail") != -1))
            {
                this.Tables.Add(new BankImportTDSAGiftDetailTable("AGiftDetail"));
            }
            if ((ds.Tables.IndexOf("PBankingDetails") != -1))
            {
                this.Tables.Add(new BankImportTDSPBankingDetailsTable("PBankingDetails"));
            }
            if ((ds.Tables.IndexOf("AEpTransaction") != -1))
            {
                this.Tables.Add(new BankImportTDSAEpTransactionTable("AEpTransaction"));
            }
            if ((ds.Tables.IndexOf("AEpMatch") != -1))
            {
                this.Tables.Add(new AEpMatchTable("AEpMatch"));
            }
        }

        /// auto generated
        protected override void MapTables()
        {
            this.InitVars();
            base.MapTables();
            if ((this.TableAGiftDetail != null))
            {
                this.TableAGiftDetail.InitVars();
            }
            if ((this.TablePBankingDetails != null))
            {
                this.TablePBankingDetails.InitVars();
            }
            if ((this.TableAEpTransaction != null))
            {
                this.TableAEpTransaction.InitVars();
            }
            if ((this.TableAEpMatch != null))
            {
                this.TableAEpMatch.InitVars();
            }
        }

        /// auto generated
        public override void InitVars()
        {
            this.DataSetName = "BankImportTDS";
            this.TableAGiftDetail = ((BankImportTDSAGiftDetailTable)(this.Tables["AGiftDetail"]));
            this.TablePBankingDetails = ((BankImportTDSPBankingDetailsTable)(this.Tables["PBankingDetails"]));
            this.TableAEpTransaction = ((BankImportTDSAEpTransactionTable)(this.Tables["AEpTransaction"]));
            this.TableAEpMatch = ((AEpMatchTable)(this.Tables["AEpMatch"]));
        }

        /// auto generated
        protected override void InitConstraints()
        {

            if (((this.TablePBankingDetails != null)
                        && (this.TableAEpTransaction != null)))
            {
                this.FConstraints.Add(new TTypedConstraint("FKEpTransaction2", "PBankingDetails", new string[] {
                                "p_banking_details_key_i"}, "AEpTransaction", new string[] {
                                "a_statement_bank_account_key_i"}));
            }
            if (((this.TableAEpMatch != null)
                        && (this.TableAEpTransaction != null)))
            {
                this.FConstraints.Add(new TTypedConstraint("FKEpTransaction3", "AEpMatch", new string[] {
                                "a_ep_match_key_i"}, "AEpTransaction", new string[] {
                                "a_ep_match_key_i"}));
            }
        }
    }

    /// The gift recipient information for a gift.  A single gift can be split among more than one recipient.  A gift detail record is created for each recipient.
    [Serializable()]
    public class BankImportTDSAGiftDetailTable : AGiftDetailTable
    {
        /// TableId for Ict.Common.Data generic functions
        public new static short TableId = 5601;
        /// used for generic TTypedDataTable functions
        public static short ColumnDonorKeyId = 29;
        /// used for generic TTypedDataTable functions
        public static short ColumnDonorShortNameId = 30;
        /// used for generic TTypedDataTable functions
        public static short ColumnRecipientDescriptionId = 31;
        /// used for generic TTypedDataTable functions
        public static short ColumnAlreadyMatchedId = 32;
        /// used for generic TTypedDataTable functions
        public static short ColumnBatchStatusId = 33;

        private static bool FInitInfoValues = InitInfoValues();
        private static bool InitInfoValues()
        {
            TableInfo.Add(TableId, new TTypedTableInfo(TableId, "AGiftDetail", "a_gift_detail",
                new TTypedColumnInfo[] {
                    new TTypedColumnInfo(0, "LedgerNumber", "a_ledger_number_i", "Ledger Number", OdbcType.Int, -1, true),
                    new TTypedColumnInfo(1, "BatchNumber", "a_batch_number_i", "Gift Batch Number", OdbcType.Int, -1, true),
                    new TTypedColumnInfo(2, "GiftTransactionNumber", "a_gift_transaction_number_i", "Gift Transaction Number", OdbcType.Int, -1, true),
                    new TTypedColumnInfo(3, "DetailNumber", "a_detail_number_i", "Gift Number", OdbcType.Int, -1, true),
                    new TTypedColumnInfo(4, "RecipientLedgerNumber", "a_recipient_ledger_number_n", "Recipient Ledger", OdbcType.Decimal, 10, true),
                    new TTypedColumnInfo(5, "GiftAmount", "a_gift_amount_n", "Gift Amount", OdbcType.Decimal, 24, false),
                    new TTypedColumnInfo(6, "MotivationGroupCode", "a_motivation_group_code_c", "Motivation Group", OdbcType.VarChar, 16, true),
                    new TTypedColumnInfo(7, "MotivationDetailCode", "a_motivation_detail_code_c", "Motivation Detail", OdbcType.VarChar, 16, true),
                    new TTypedColumnInfo(8, "CommentOneType", "a_comment_one_type_c", "Comment Type", OdbcType.VarChar, 24, false),
                    new TTypedColumnInfo(9, "GiftCommentOne", "a_gift_comment_one_c", "Comment One", OdbcType.VarChar, 160, false),
                    new TTypedColumnInfo(10, "ConfidentialGiftFlag", "a_confidential_gift_flag_l", "Confidential Gift", OdbcType.Bit, -1, true),
                    new TTypedColumnInfo(11, "TaxDeductable", "a_tax_deductable_l", "Tax Deductable", OdbcType.Bit, -1, false),
                    new TTypedColumnInfo(12, "RecipientKey", "p_recipient_key_n", "Recipient", OdbcType.Decimal, 10, true),
                    new TTypedColumnInfo(13, "ChargeFlag", "a_charge_flag_l", "Charge Fee", OdbcType.Bit, -1, false),
                    new TTypedColumnInfo(14, "CostCentreCode", "a_cost_centre_code_c", "Cost Centre Code", OdbcType.VarChar, 24, false),
                    new TTypedColumnInfo(15, "GiftAmountIntl", "a_gift_amount_intl_n", "International Gift Amount", OdbcType.Decimal, 24, false),
                    new TTypedColumnInfo(16, "ModifiedDetail", "a_modified_detail_l", "Part of a gift detail modification", OdbcType.Bit, -1, false),
                    new TTypedColumnInfo(17, "GiftTransactionAmount", "a_gift_transaction_amount_n", "Transaction Gift Amount", OdbcType.Decimal, 24, true),
                    new TTypedColumnInfo(18, "IchNumber", "a_ich_number_i", "ICH Process Number", OdbcType.Int, -1, true),
                    new TTypedColumnInfo(19, "MailingCode", "p_mailing_code_c", "Mailing Code", OdbcType.VarChar, 50, false),
                    new TTypedColumnInfo(20, "CommentTwoType", "a_comment_two_type_c", "Comment Type", OdbcType.VarChar, 24, false),
                    new TTypedColumnInfo(21, "GiftCommentTwo", "a_gift_comment_two_c", "Comment Two", OdbcType.VarChar, 160, false),
                    new TTypedColumnInfo(22, "CommentThreeType", "a_comment_three_type_c", "Comment Type", OdbcType.VarChar, 24, false),
                    new TTypedColumnInfo(23, "GiftCommentThree", "a_gift_comment_three_c", "Comment Three", OdbcType.VarChar, 160, false),
                    new TTypedColumnInfo(24, "DateCreated", "s_date_created_d", "Created Date", OdbcType.Date, -1, false),
                    new TTypedColumnInfo(25, "CreatedBy", "s_created_by_c", "Created By", OdbcType.VarChar, 20, false),
                    new TTypedColumnInfo(26, "DateModified", "s_date_modified_d", "Modified Date", OdbcType.Date, -1, false),
                    new TTypedColumnInfo(27, "ModifiedBy", "s_modified_by_c", "Modified By", OdbcType.VarChar, 20, false),
                    new TTypedColumnInfo(28, "ModificationId", "s_modification_id_c", "", OdbcType.VarChar, 150, false),
                    new TTypedColumnInfo(29, "DonorKey", "DonorKey", "", OdbcType.Int, -1, false),
                    new TTypedColumnInfo(30, "DonorShortName", "DonorShortName", "", OdbcType.Int, -1, false),
                    new TTypedColumnInfo(31, "RecipientDescription", "RecipientDescription", "", OdbcType.Int, -1, false),
                    new TTypedColumnInfo(32, "AlreadyMatched", "AlreadyMatched", "", OdbcType.Int, -1, false),
                    new TTypedColumnInfo(33, "BatchStatus", "BatchStatus", "", OdbcType.Int, -1, false)
                },
                new int[] {
                    0, 1, 2, 3
                }));
            return true;
        }

        /// constructor
        public BankImportTDSAGiftDetailTable() :
                base("AGiftDetail")
        {
        }

        /// constructor
        public BankImportTDSAGiftDetailTable(string ATablename) :
                base(ATablename)
        {
        }

        /// constructor for serialization
        public BankImportTDSAGiftDetailTable(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) :
                base(info, context)
        {
        }

        ///
        public DataColumn ColumnDonorKey;
        ///
        public DataColumn ColumnDonorShortName;
        ///
        public DataColumn ColumnRecipientDescription;
        ///
        public DataColumn ColumnAlreadyMatched;
        ///
        public DataColumn ColumnBatchStatus;

        /// create the columns
        protected override void InitClass()
        {
            this.Columns.Add(new System.Data.DataColumn("a_ledger_number_i", typeof(Int32)));
            this.Columns.Add(new System.Data.DataColumn("a_batch_number_i", typeof(Int32)));
            this.Columns.Add(new System.Data.DataColumn("a_gift_transaction_number_i", typeof(Int32)));
            this.Columns.Add(new System.Data.DataColumn("a_detail_number_i", typeof(Int32)));
            this.Columns.Add(new System.Data.DataColumn("a_recipient_ledger_number_n", typeof(Int64)));
            this.Columns.Add(new System.Data.DataColumn("a_gift_amount_n", typeof(Double)));
            this.Columns.Add(new System.Data.DataColumn("a_motivation_group_code_c", typeof(String)));
            this.Columns.Add(new System.Data.DataColumn("a_motivation_detail_code_c", typeof(String)));
            this.Columns.Add(new System.Data.DataColumn("a_comment_one_type_c", typeof(String)));
            this.Columns.Add(new System.Data.DataColumn("a_gift_comment_one_c", typeof(String)));
            this.Columns.Add(new System.Data.DataColumn("a_confidential_gift_flag_l", typeof(Boolean)));
            this.Columns.Add(new System.Data.DataColumn("a_tax_deductable_l", typeof(Boolean)));
            this.Columns.Add(new System.Data.DataColumn("p_recipient_key_n", typeof(Int64)));
            this.Columns.Add(new System.Data.DataColumn("a_charge_flag_l", typeof(Boolean)));
            this.Columns.Add(new System.Data.DataColumn("a_cost_centre_code_c", typeof(String)));
            this.Columns.Add(new System.Data.DataColumn("a_gift_amount_intl_n", typeof(Double)));
            this.Columns.Add(new System.Data.DataColumn("a_modified_detail_l", typeof(Boolean)));
            this.Columns.Add(new System.Data.DataColumn("a_gift_transaction_amount_n", typeof(Double)));
            this.Columns.Add(new System.Data.DataColumn("a_ich_number_i", typeof(Int32)));
            this.Columns.Add(new System.Data.DataColumn("p_mailing_code_c", typeof(String)));
            this.Columns.Add(new System.Data.DataColumn("a_comment_two_type_c", typeof(String)));
            this.Columns.Add(new System.Data.DataColumn("a_gift_comment_two_c", typeof(String)));
            this.Columns.Add(new System.Data.DataColumn("a_comment_three_type_c", typeof(String)));
            this.Columns.Add(new System.Data.DataColumn("a_gift_comment_three_c", typeof(String)));
            this.Columns.Add(new System.Data.DataColumn("s_date_created_d", typeof(System.DateTime)));
            this.Columns.Add(new System.Data.DataColumn("s_created_by_c", typeof(String)));
            this.Columns.Add(new System.Data.DataColumn("s_date_modified_d", typeof(System.DateTime)));
            this.Columns.Add(new System.Data.DataColumn("s_modified_by_c", typeof(String)));
            this.Columns.Add(new System.Data.DataColumn("s_modification_id_c", typeof(String)));
            this.Columns.Add(new System.Data.DataColumn("DonorKey", typeof(Int64)));
            this.Columns.Add(new System.Data.DataColumn("DonorShortName", typeof(string)));
            this.Columns.Add(new System.Data.DataColumn("RecipientDescription", typeof(string)));
            this.Columns.Add(new System.Data.DataColumn("AlreadyMatched", typeof(Boolean)));
            this.Columns.Add(new System.Data.DataColumn("BatchStatus", typeof(string)));
        }

        /// assign columns to properties, set primary key
        public override void InitVars()
        {
            this.ColumnLedgerNumber = this.Columns["a_ledger_number_i"];
            this.ColumnBatchNumber = this.Columns["a_batch_number_i"];
            this.ColumnGiftTransactionNumber = this.Columns["a_gift_transaction_number_i"];
            this.ColumnDetailNumber = this.Columns["a_detail_number_i"];
            this.ColumnRecipientLedgerNumber = this.Columns["a_recipient_ledger_number_n"];
            this.ColumnGiftAmount = this.Columns["a_gift_amount_n"];
            this.ColumnMotivationGroupCode = this.Columns["a_motivation_group_code_c"];
            this.ColumnMotivationDetailCode = this.Columns["a_motivation_detail_code_c"];
            this.ColumnCommentOneType = this.Columns["a_comment_one_type_c"];
            this.ColumnGiftCommentOne = this.Columns["a_gift_comment_one_c"];
            this.ColumnConfidentialGiftFlag = this.Columns["a_confidential_gift_flag_l"];
            this.ColumnTaxDeductable = this.Columns["a_tax_deductable_l"];
            this.ColumnRecipientKey = this.Columns["p_recipient_key_n"];
            this.ColumnChargeFlag = this.Columns["a_charge_flag_l"];
            this.ColumnCostCentreCode = this.Columns["a_cost_centre_code_c"];
            this.ColumnGiftAmountIntl = this.Columns["a_gift_amount_intl_n"];
            this.ColumnModifiedDetail = this.Columns["a_modified_detail_l"];
            this.ColumnGiftTransactionAmount = this.Columns["a_gift_transaction_amount_n"];
            this.ColumnIchNumber = this.Columns["a_ich_number_i"];
            this.ColumnMailingCode = this.Columns["p_mailing_code_c"];
            this.ColumnCommentTwoType = this.Columns["a_comment_two_type_c"];
            this.ColumnGiftCommentTwo = this.Columns["a_gift_comment_two_c"];
            this.ColumnCommentThreeType = this.Columns["a_comment_three_type_c"];
            this.ColumnGiftCommentThree = this.Columns["a_gift_comment_three_c"];
            this.ColumnDateCreated = this.Columns["s_date_created_d"];
            this.ColumnCreatedBy = this.Columns["s_created_by_c"];
            this.ColumnDateModified = this.Columns["s_date_modified_d"];
            this.ColumnModifiedBy = this.Columns["s_modified_by_c"];
            this.ColumnModificationId = this.Columns["s_modification_id_c"];
            this.ColumnDonorKey = this.Columns["DonorKey"];
            this.ColumnDonorShortName = this.Columns["DonorShortName"];
            this.ColumnRecipientDescription = this.Columns["RecipientDescription"];
            this.ColumnAlreadyMatched = this.Columns["AlreadyMatched"];
            this.ColumnBatchStatus = this.Columns["BatchStatus"];
            this.PrimaryKey = new System.Data.DataColumn[4] {
                    ColumnLedgerNumber,ColumnBatchNumber,ColumnGiftTransactionNumber,ColumnDetailNumber};
        }

        /// Access a typed row by index
        public new BankImportTDSAGiftDetailRow this[int i]
        {
            get
            {
                return ((BankImportTDSAGiftDetailRow)(this.Rows[i]));
            }
        }

        /// create a new typed row
        public new BankImportTDSAGiftDetailRow NewRowTyped(bool AWithDefaultValues)
        {
            BankImportTDSAGiftDetailRow ret = ((BankImportTDSAGiftDetailRow)(this.NewRow()));
            if ((AWithDefaultValues == true))
            {
                ret.InitValues();
            }
            return ret;
        }

        /// create a new typed row, always with default values
        public new BankImportTDSAGiftDetailRow NewRowTyped()
        {
            return this.NewRowTyped(true);
        }

        /// new typed row using DataRowBuilder
        protected override System.Data.DataRow NewRowFromBuilder(System.Data.DataRowBuilder builder)
        {
            return new BankImportTDSAGiftDetailRow(builder);
        }

        /// get typed set of changes
        public new BankImportTDSAGiftDetailTable GetChangesTyped()
        {
            return ((BankImportTDSAGiftDetailTable)(base.GetChangesTypedInternal()));
        }

        /// return the CamelCase name of the table
        public static new string GetTableName()
        {
            return "AGiftDetail";
        }

        /// return the name of the table as it is used in the database
        public static new string GetTableDBName()
        {
            return "a_gift_detail";
        }

        /// get an odbc parameter for the given column
        public override OdbcParameter CreateOdbcParameter(Int32 AColumnNr)
        {
            return CreateOdbcParameter(TableId, AColumnNr);
        }

        /// get the name of the field in the database for this column
        public static string GetDonorKeyDBName()
        {
            return "DonorKey";
        }

        /// get character length for column
        public static short GetDonorKeyLength()
        {
            return -1;
        }

        /// get the name of the field in the database for this column
        public static string GetDonorShortNameDBName()
        {
            return "DonorShortName";
        }

        /// get character length for column
        public static short GetDonorShortNameLength()
        {
            return -1;
        }

        /// get the name of the field in the database for this column
        public static string GetRecipientDescriptionDBName()
        {
            return "RecipientDescription";
        }

        /// get character length for column
        public static short GetRecipientDescriptionLength()
        {
            return -1;
        }

        /// get the name of the field in the database for this column
        public static string GetAlreadyMatchedDBName()
        {
            return "AlreadyMatched";
        }

        /// get character length for column
        public static short GetAlreadyMatchedLength()
        {
            return -1;
        }

        /// get the name of the field in the database for this column
        public static string GetBatchStatusDBName()
        {
            return "BatchStatus";
        }

        /// get character length for column
        public static short GetBatchStatusLength()
        {
            return -1;
        }

    }

    /// The gift recipient information for a gift.  A single gift can be split among more than one recipient.  A gift detail record is created for each recipient.
    [Serializable()]
    public class BankImportTDSAGiftDetailRow : AGiftDetailRow
    {
        private BankImportTDSAGiftDetailTable myTable;

        /// Constructor
        public BankImportTDSAGiftDetailRow(System.Data.DataRowBuilder rb) :
                base(rb)
        {
            this.myTable = ((BankImportTDSAGiftDetailTable)(this.Table));
        }

        ///
        public Int64 DonorKey
        {
            get
            {
                object ret;
                ret = this[this.myTable.ColumnDonorKey.Ordinal];
                if ((ret == System.DBNull.Value))
                {
                    throw new System.Data.StrongTypingException("Error: DB null", null);
                }
                else
                {
                    return ((Int64)(ret));
                }
            }
            set
            {
                if ((this.IsNull(this.myTable.ColumnDonorKey)
                            || (((Int64)(this[this.myTable.ColumnDonorKey])) != value)))
                {
                    this[this.myTable.ColumnDonorKey] = value;
                }
            }
        }

        ///
        public string DonorShortName
        {
            get
            {
                object ret;
                ret = this[this.myTable.ColumnDonorShortName.Ordinal];
                if ((ret == System.DBNull.Value))
                {
                    return String.Empty;
                }
                else
                {
                    return ((string)(ret));
                }
            }
            set
            {
                if ((this.IsNull(this.myTable.ColumnDonorShortName)
                            || (((string)(this[this.myTable.ColumnDonorShortName])) != value)))
                {
                    this[this.myTable.ColumnDonorShortName] = value;
                }
            }
        }

        ///
        public string RecipientDescription
        {
            get
            {
                object ret;
                ret = this[this.myTable.ColumnRecipientDescription.Ordinal];
                if ((ret == System.DBNull.Value))
                {
                    return String.Empty;
                }
                else
                {
                    return ((string)(ret));
                }
            }
            set
            {
                if ((this.IsNull(this.myTable.ColumnRecipientDescription)
                            || (((string)(this[this.myTable.ColumnRecipientDescription])) != value)))
                {
                    this[this.myTable.ColumnRecipientDescription] = value;
                }
            }
        }

        ///
        public Boolean AlreadyMatched
        {
            get
            {
                object ret;
                ret = this[this.myTable.ColumnAlreadyMatched.Ordinal];
                if ((ret == System.DBNull.Value))
                {
                    throw new System.Data.StrongTypingException("Error: DB null", null);
                }
                else
                {
                    return ((Boolean)(ret));
                }
            }
            set
            {
                if ((this.IsNull(this.myTable.ColumnAlreadyMatched)
                            || (((Boolean)(this[this.myTable.ColumnAlreadyMatched])) != value)))
                {
                    this[this.myTable.ColumnAlreadyMatched] = value;
                }
            }
        }

        ///
        public string BatchStatus
        {
            get
            {
                object ret;
                ret = this[this.myTable.ColumnBatchStatus.Ordinal];
                if ((ret == System.DBNull.Value))
                {
                    return String.Empty;
                }
                else
                {
                    return ((string)(ret));
                }
            }
            set
            {
                if ((this.IsNull(this.myTable.ColumnBatchStatus)
                            || (((string)(this[this.myTable.ColumnBatchStatus])) != value)))
                {
                    this[this.myTable.ColumnBatchStatus] = value;
                }
            }
        }

        /// set default values
        public override void InitValues()
        {
            this[this.myTable.ColumnLedgerNumber.Ordinal] = 0;
            this[this.myTable.ColumnBatchNumber.Ordinal] = 0;
            this[this.myTable.ColumnGiftTransactionNumber.Ordinal] = 0;
            this[this.myTable.ColumnDetailNumber.Ordinal] = 0;
            this[this.myTable.ColumnRecipientLedgerNumber.Ordinal] = 0;
            this[this.myTable.ColumnGiftAmount.Ordinal] = 0;
            this.SetNull(this.myTable.ColumnMotivationGroupCode);
            this.SetNull(this.myTable.ColumnMotivationDetailCode);
            this.SetNull(this.myTable.ColumnCommentOneType);
            this.SetNull(this.myTable.ColumnGiftCommentOne);
            this[this.myTable.ColumnConfidentialGiftFlag.Ordinal] = false;
            this[this.myTable.ColumnTaxDeductable.Ordinal] = true;
            this[this.myTable.ColumnRecipientKey.Ordinal] = 0;
            this[this.myTable.ColumnChargeFlag.Ordinal] = true;
            this.SetNull(this.myTable.ColumnCostCentreCode);
            this[this.myTable.ColumnGiftAmountIntl.Ordinal] = 0;
            this[this.myTable.ColumnModifiedDetail.Ordinal] = false;
            this[this.myTable.ColumnGiftTransactionAmount.Ordinal] = 0;
            this[this.myTable.ColumnIchNumber.Ordinal] = 0;
            this.SetNull(this.myTable.ColumnMailingCode);
            this.SetNull(this.myTable.ColumnCommentTwoType);
            this.SetNull(this.myTable.ColumnGiftCommentTwo);
            this.SetNull(this.myTable.ColumnCommentThreeType);
            this.SetNull(this.myTable.ColumnGiftCommentThree);
            this[this.myTable.ColumnDateCreated.Ordinal] = DateTime.Today;
            this.SetNull(this.myTable.ColumnCreatedBy);
            this.SetNull(this.myTable.ColumnDateModified);
            this.SetNull(this.myTable.ColumnModifiedBy);
            this.SetNull(this.myTable.ColumnModificationId);
            this.SetNull(this.myTable.ColumnDonorKey);
            this.SetNull(this.myTable.ColumnDonorShortName);
            this.SetNull(this.myTable.ColumnRecipientDescription);
            this.SetNull(this.myTable.ColumnAlreadyMatched);
            this.SetNull(this.myTable.ColumnBatchStatus);
        }

        /// test for NULL value
        public bool IsDonorKeyNull()
        {
            return this.IsNull(this.myTable.ColumnDonorKey);
        }

        /// assign NULL value
        public void SetDonorKeyNull()
        {
            this.SetNull(this.myTable.ColumnDonorKey);
        }

        /// test for NULL value
        public bool IsDonorShortNameNull()
        {
            return this.IsNull(this.myTable.ColumnDonorShortName);
        }

        /// assign NULL value
        public void SetDonorShortNameNull()
        {
            this.SetNull(this.myTable.ColumnDonorShortName);
        }

        /// test for NULL value
        public bool IsRecipientDescriptionNull()
        {
            return this.IsNull(this.myTable.ColumnRecipientDescription);
        }

        /// assign NULL value
        public void SetRecipientDescriptionNull()
        {
            this.SetNull(this.myTable.ColumnRecipientDescription);
        }

        /// test for NULL value
        public bool IsAlreadyMatchedNull()
        {
            return this.IsNull(this.myTable.ColumnAlreadyMatched);
        }

        /// assign NULL value
        public void SetAlreadyMatchedNull()
        {
            this.SetNull(this.myTable.ColumnAlreadyMatched);
        }

        /// test for NULL value
        public bool IsBatchStatusNull()
        {
            return this.IsNull(this.myTable.ColumnBatchStatus);
        }

        /// assign NULL value
        public void SetBatchStatusNull()
        {
            this.SetNull(this.myTable.ColumnBatchStatus);
        }
    }

    /// Any bank details for a partner can be store in this table
    [Serializable()]
    public class BankImportTDSPBankingDetailsTable : PBankingDetailsTable
    {
        /// TableId for Ict.Common.Data generic functions
        public new static short TableId = 5602;
        /// used for generic TTypedDataTable functions
        public static short ColumnPartnerKeyId = 19;

        private static bool FInitInfoValues = InitInfoValues();
        private static bool InitInfoValues()
        {
            TableInfo.Add(TableId, new TTypedTableInfo(TableId, "PBankingDetails", "p_banking_details",
                new TTypedColumnInfo[] {
                    new TTypedColumnInfo(0, "BankingDetailsKey", "p_banking_details_key_i", "p_banking_details_key_i", OdbcType.Int, -1, true),
                    new TTypedColumnInfo(1, "BankingType", "p_banking_type_i", "p_banking_type_i", OdbcType.Int, -1, true),
                    new TTypedColumnInfo(2, "AccountName", "p_account_name_c", "Account Name", OdbcType.VarChar, 160, false),
                    new TTypedColumnInfo(3, "Title", "p_title_c", "Title", OdbcType.VarChar, 64, false),
                    new TTypedColumnInfo(4, "FirstName", "p_first_name_c", "First Name", OdbcType.VarChar, 64, false),
                    new TTypedColumnInfo(5, "MiddleName", "p_middle_name_c", "Middle Name", OdbcType.VarChar, 64, false),
                    new TTypedColumnInfo(6, "LastName", "p_last_name_c", "Last Name", OdbcType.VarChar, 64, false),
                    new TTypedColumnInfo(7, "BankKey", "p_bank_key_n", "p_bank_key_n", OdbcType.Decimal, 10, true),
                    new TTypedColumnInfo(8, "BankAccountNumber", "p_bank_account_number_c", "Account Number", OdbcType.VarChar, 40, false),
                    new TTypedColumnInfo(9, "Iban", "p_iban_c", "IBAN", OdbcType.VarChar, 128, false),
                    new TTypedColumnInfo(10, "SecurityCode", "p_security_code_c", "Security Code", OdbcType.VarChar, 24, false),
                    new TTypedColumnInfo(11, "ValidFromDate", "p_valid_from_date_d", "p_valid_from_date_d", OdbcType.Date, -1, false),
                    new TTypedColumnInfo(12, "ExpiryDate", "p_expiry_date_d", "p_expiry_date_d", OdbcType.Date, -1, false),
                    new TTypedColumnInfo(13, "Comment", "p_comment_c", "p_comment_c", OdbcType.VarChar, 510, false),
                    new TTypedColumnInfo(14, "DateCreated", "s_date_created_d", "Created Date", OdbcType.Date, -1, false),
                    new TTypedColumnInfo(15, "CreatedBy", "s_created_by_c", "Created By", OdbcType.VarChar, 20, false),
                    new TTypedColumnInfo(16, "DateModified", "s_date_modified_d", "Modified Date", OdbcType.Date, -1, false),
                    new TTypedColumnInfo(17, "ModifiedBy", "s_modified_by_c", "Modified By", OdbcType.VarChar, 20, false),
                    new TTypedColumnInfo(18, "ModificationId", "s_modification_id_c", "", OdbcType.VarChar, 150, false),
                    new TTypedColumnInfo(19, "PartnerKey", "PartnerKey", "", OdbcType.Int, -1, false)
                },
                new int[] {
                    0
                }));
            return true;
        }

        /// constructor
        public BankImportTDSPBankingDetailsTable() :
                base("PBankingDetails")
        {
        }

        /// constructor
        public BankImportTDSPBankingDetailsTable(string ATablename) :
                base(ATablename)
        {
        }

        /// constructor for serialization
        public BankImportTDSPBankingDetailsTable(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) :
                base(info, context)
        {
        }

        ///
        public DataColumn ColumnPartnerKey;

        /// create the columns
        protected override void InitClass()
        {
            this.Columns.Add(new System.Data.DataColumn("p_banking_details_key_i", typeof(Int32)));
            this.Columns.Add(new System.Data.DataColumn("p_banking_type_i", typeof(Int32)));
            this.Columns.Add(new System.Data.DataColumn("p_account_name_c", typeof(String)));
            this.Columns.Add(new System.Data.DataColumn("p_title_c", typeof(String)));
            this.Columns.Add(new System.Data.DataColumn("p_first_name_c", typeof(String)));
            this.Columns.Add(new System.Data.DataColumn("p_middle_name_c", typeof(String)));
            this.Columns.Add(new System.Data.DataColumn("p_last_name_c", typeof(String)));
            this.Columns.Add(new System.Data.DataColumn("p_bank_key_n", typeof(Int64)));
            this.Columns.Add(new System.Data.DataColumn("p_bank_account_number_c", typeof(String)));
            this.Columns.Add(new System.Data.DataColumn("p_iban_c", typeof(String)));
            this.Columns.Add(new System.Data.DataColumn("p_security_code_c", typeof(String)));
            this.Columns.Add(new System.Data.DataColumn("p_valid_from_date_d", typeof(System.DateTime)));
            this.Columns.Add(new System.Data.DataColumn("p_expiry_date_d", typeof(System.DateTime)));
            this.Columns.Add(new System.Data.DataColumn("p_comment_c", typeof(String)));
            this.Columns.Add(new System.Data.DataColumn("s_date_created_d", typeof(System.DateTime)));
            this.Columns.Add(new System.Data.DataColumn("s_created_by_c", typeof(String)));
            this.Columns.Add(new System.Data.DataColumn("s_date_modified_d", typeof(System.DateTime)));
            this.Columns.Add(new System.Data.DataColumn("s_modified_by_c", typeof(String)));
            this.Columns.Add(new System.Data.DataColumn("s_modification_id_c", typeof(String)));
            this.Columns.Add(new System.Data.DataColumn("PartnerKey", typeof(Int64)));
        }

        /// assign columns to properties, set primary key
        public override void InitVars()
        {
            this.ColumnBankingDetailsKey = this.Columns["p_banking_details_key_i"];
            this.ColumnBankingType = this.Columns["p_banking_type_i"];
            this.ColumnAccountName = this.Columns["p_account_name_c"];
            this.ColumnTitle = this.Columns["p_title_c"];
            this.ColumnFirstName = this.Columns["p_first_name_c"];
            this.ColumnMiddleName = this.Columns["p_middle_name_c"];
            this.ColumnLastName = this.Columns["p_last_name_c"];
            this.ColumnBankKey = this.Columns["p_bank_key_n"];
            this.ColumnBankAccountNumber = this.Columns["p_bank_account_number_c"];
            this.ColumnIban = this.Columns["p_iban_c"];
            this.ColumnSecurityCode = this.Columns["p_security_code_c"];
            this.ColumnValidFromDate = this.Columns["p_valid_from_date_d"];
            this.ColumnExpiryDate = this.Columns["p_expiry_date_d"];
            this.ColumnComment = this.Columns["p_comment_c"];
            this.ColumnDateCreated = this.Columns["s_date_created_d"];
            this.ColumnCreatedBy = this.Columns["s_created_by_c"];
            this.ColumnDateModified = this.Columns["s_date_modified_d"];
            this.ColumnModifiedBy = this.Columns["s_modified_by_c"];
            this.ColumnModificationId = this.Columns["s_modification_id_c"];
            this.ColumnPartnerKey = this.Columns["PartnerKey"];
            this.PrimaryKey = new System.Data.DataColumn[1] {
                    ColumnBankingDetailsKey};
        }

        /// Access a typed row by index
        public new BankImportTDSPBankingDetailsRow this[int i]
        {
            get
            {
                return ((BankImportTDSPBankingDetailsRow)(this.Rows[i]));
            }
        }

        /// create a new typed row
        public new BankImportTDSPBankingDetailsRow NewRowTyped(bool AWithDefaultValues)
        {
            BankImportTDSPBankingDetailsRow ret = ((BankImportTDSPBankingDetailsRow)(this.NewRow()));
            if ((AWithDefaultValues == true))
            {
                ret.InitValues();
            }
            return ret;
        }

        /// create a new typed row, always with default values
        public new BankImportTDSPBankingDetailsRow NewRowTyped()
        {
            return this.NewRowTyped(true);
        }

        /// new typed row using DataRowBuilder
        protected override System.Data.DataRow NewRowFromBuilder(System.Data.DataRowBuilder builder)
        {
            return new BankImportTDSPBankingDetailsRow(builder);
        }

        /// get typed set of changes
        public new BankImportTDSPBankingDetailsTable GetChangesTyped()
        {
            return ((BankImportTDSPBankingDetailsTable)(base.GetChangesTypedInternal()));
        }

        /// return the CamelCase name of the table
        public static new string GetTableName()
        {
            return "PBankingDetails";
        }

        /// return the name of the table as it is used in the database
        public static new string GetTableDBName()
        {
            return "p_banking_details";
        }

        /// get an odbc parameter for the given column
        public override OdbcParameter CreateOdbcParameter(Int32 AColumnNr)
        {
            return CreateOdbcParameter(TableId, AColumnNr);
        }

        /// get the name of the field in the database for this column
        public static string GetPartnerKeyDBName()
        {
            return "PartnerKey";
        }

        /// get character length for column
        public static short GetPartnerKeyLength()
        {
            return -1;
        }

    }

    /// Any bank details for a partner can be store in this table
    [Serializable()]
    public class BankImportTDSPBankingDetailsRow : PBankingDetailsRow
    {
        private BankImportTDSPBankingDetailsTable myTable;

        /// Constructor
        public BankImportTDSPBankingDetailsRow(System.Data.DataRowBuilder rb) :
                base(rb)
        {
            this.myTable = ((BankImportTDSPBankingDetailsTable)(this.Table));
        }

        ///
        public Int64 PartnerKey
        {
            get
            {
                object ret;
                ret = this[this.myTable.ColumnPartnerKey.Ordinal];
                if ((ret == System.DBNull.Value))
                {
                    throw new System.Data.StrongTypingException("Error: DB null", null);
                }
                else
                {
                    return ((Int64)(ret));
                }
            }
            set
            {
                if ((this.IsNull(this.myTable.ColumnPartnerKey)
                            || (((Int64)(this[this.myTable.ColumnPartnerKey])) != value)))
                {
                    this[this.myTable.ColumnPartnerKey] = value;
                }
            }
        }

        /// set default values
        public override void InitValues()
        {
            this.SetNull(this.myTable.ColumnBankingDetailsKey);
            this.SetNull(this.myTable.ColumnBankingType);
            this.SetNull(this.myTable.ColumnAccountName);
            this.SetNull(this.myTable.ColumnTitle);
            this.SetNull(this.myTable.ColumnFirstName);
            this.SetNull(this.myTable.ColumnMiddleName);
            this.SetNull(this.myTable.ColumnLastName);
            this.SetNull(this.myTable.ColumnBankKey);
            this.SetNull(this.myTable.ColumnBankAccountNumber);
            this.SetNull(this.myTable.ColumnIban);
            this.SetNull(this.myTable.ColumnSecurityCode);
            this.SetNull(this.myTable.ColumnValidFromDate);
            this.SetNull(this.myTable.ColumnExpiryDate);
            this.SetNull(this.myTable.ColumnComment);
            this[this.myTable.ColumnDateCreated.Ordinal] = DateTime.Today;
            this.SetNull(this.myTable.ColumnCreatedBy);
            this.SetNull(this.myTable.ColumnDateModified);
            this.SetNull(this.myTable.ColumnModifiedBy);
            this.SetNull(this.myTable.ColumnModificationId);
            this.SetNull(this.myTable.ColumnPartnerKey);
        }

        /// test for NULL value
        public bool IsPartnerKeyNull()
        {
            return this.IsNull(this.myTable.ColumnPartnerKey);
        }

        /// assign NULL value
        public void SetPartnerKeyNull()
        {
            this.SetNull(this.myTable.ColumnPartnerKey);
        }
    }

    /// the transactions from the recently imported bank statements; they should help to identify the other party of the transaction (donor, etc) and the purpose of the transaction
    [Serializable()]
    public class BankImportTDSAEpTransactionTable : AEpTransactionTable
    {
        /// TableId for Ict.Common.Data generic functions
        public new static short TableId = 5603;
        /// used for generic TTypedDataTable functions
        public static short ColumnDetailKeyId = 23;
        /// used for generic TTypedDataTable functions
        public static short ColumnOriginalAmountOnStatementId = 24;
        /// used for generic TTypedDataTable functions
        public static short ColumnGiftLedgerNumberId = 25;
        /// used for generic TTypedDataTable functions
        public static short ColumnGiftBatchNumberId = 26;
        /// used for generic TTypedDataTable functions
        public static short ColumnGiftTransactionNumberId = 27;
        /// used for generic TTypedDataTable functions
        public static short ColumnGiftDetailNumberId = 28;
        /// used for generic TTypedDataTable functions
        public static short ColumnDonorKeyId = 29;
        /// used for generic TTypedDataTable functions
        public static short ColumnDonorShortNameId = 30;
        /// used for generic TTypedDataTable functions
        public static short ColumnRecipientDescriptionId = 31;

        private static bool FInitInfoValues = InitInfoValues();
        private static bool InitInfoValues()
        {
            TableInfo.Add(TableId, new TTypedTableInfo(TableId, "AEpTransaction", "a_ep_transaction",
                new TTypedColumnInfo[] {
                    new TTypedColumnInfo(0, "StatementKey", "a_statement_key_i", "Bank statement", OdbcType.Int, -1, true),
                    new TTypedColumnInfo(1, "Order", "a_order_i", "order", OdbcType.Int, -1, true),
                    new TTypedColumnInfo(2, "StatementBankAccountKey", "a_statement_bank_account_key_i", "banking details", OdbcType.Int, -1, true),
                    new TTypedColumnInfo(3, "AccountName", "a_account_name_c", "Account Name", OdbcType.VarChar, 160, false),
                    new TTypedColumnInfo(4, "Title", "a_title_c", "Title", OdbcType.VarChar, 64, false),
                    new TTypedColumnInfo(5, "FirstName", "a_first_name_c", "First Name", OdbcType.VarChar, 64, false),
                    new TTypedColumnInfo(6, "MiddleName", "a_middle_name_c", "Middle Name", OdbcType.VarChar, 64, false),
                    new TTypedColumnInfo(7, "LastName", "a_last_name_c", "Last Name", OdbcType.VarChar, 64, false),
                    new TTypedColumnInfo(8, "BranchCode", "p_branch_code_c", "Bank/Branch Code", OdbcType.VarChar, 20, false),
                    new TTypedColumnInfo(9, "Bic", "p_bic_c", "BIC/SWIFT Code", OdbcType.VarChar, 22, false),
                    new TTypedColumnInfo(10, "BankAccountNumber", "a_bank_account_number_c", "Account Number", OdbcType.VarChar, 40, false),
                    new TTypedColumnInfo(11, "Iban", "a_iban_c", "IBAN", OdbcType.VarChar, 128, false),
                    new TTypedColumnInfo(12, "TransactionTypeCode", "a_transaction_type_code_c", "transaction type", OdbcType.VarChar, 40, false),
                    new TTypedColumnInfo(13, "TransactionAmount", "a_transaction_amount_n", "Transaction Amount", OdbcType.Decimal, 24, true),
                    new TTypedColumnInfo(14, "Description", "a_description_c", "description", OdbcType.VarChar, 512, false),
                    new TTypedColumnInfo(15, "DateEffective", "a_date_effective_d", "Date", OdbcType.Date, -1, true),
                    new TTypedColumnInfo(16, "EpMatchKey", "a_ep_match_key_i", "a_ep_match_key_i", OdbcType.Int, -1, false),
                    new TTypedColumnInfo(17, "MatchingStatus", "a_matching_status_c", "a_matching_status_c", OdbcType.VarChar, 40, false),
                    new TTypedColumnInfo(18, "DateCreated", "s_date_created_d", "Created Date", OdbcType.Date, -1, false),
                    new TTypedColumnInfo(19, "CreatedBy", "s_created_by_c", "Created By", OdbcType.VarChar, 20, false),
                    new TTypedColumnInfo(20, "DateModified", "s_date_modified_d", "Modified Date", OdbcType.Date, -1, false),
                    new TTypedColumnInfo(21, "ModifiedBy", "s_modified_by_c", "Modified By", OdbcType.VarChar, 20, false),
                    new TTypedColumnInfo(22, "ModificationId", "s_modification_id_c", "", OdbcType.VarChar, 150, false),
                    new TTypedColumnInfo(23, "DetailKey", "DetailKey", "", OdbcType.Int, -1, false),
                    new TTypedColumnInfo(24, "OriginalAmountOnStatement", "OriginalAmountOnStatement", "", OdbcType.Int, -1, false),
                    new TTypedColumnInfo(25, "GiftLedgerNumber", "GiftLedgerNumber", "", OdbcType.Int, -1, false),
                    new TTypedColumnInfo(26, "GiftBatchNumber", "GiftBatchNumber", "", OdbcType.Int, -1, false),
                    new TTypedColumnInfo(27, "GiftTransactionNumber", "GiftTransactionNumber", "", OdbcType.Int, -1, false),
                    new TTypedColumnInfo(28, "GiftDetailNumber", "GiftDetailNumber", "", OdbcType.Int, -1, false),
                    new TTypedColumnInfo(29, "DonorKey", "DonorKey", "", OdbcType.Int, -1, false),
                    new TTypedColumnInfo(30, "DonorShortName", "DonorShortName", "", OdbcType.Int, -1, false),
                    new TTypedColumnInfo(31, "RecipientDescription", "RecipientDescription", "", OdbcType.Int, -1, false)
                },
                new int[] {
                    0, 1, 23
                }));
            return true;
        }

        /// constructor
        public BankImportTDSAEpTransactionTable() :
                base("AEpTransaction")
        {
        }

        /// constructor
        public BankImportTDSAEpTransactionTable(string ATablename) :
                base(ATablename)
        {
        }

        /// constructor for serialization
        public BankImportTDSAEpTransactionTable(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) :
                base(info, context)
        {
        }

        ///
        public DataColumn ColumnDetailKey;
        ///
        public DataColumn ColumnOriginalAmountOnStatement;
        ///
        public DataColumn ColumnGiftLedgerNumber;
        ///
        public DataColumn ColumnGiftBatchNumber;
        ///
        public DataColumn ColumnGiftTransactionNumber;
        ///
        public DataColumn ColumnGiftDetailNumber;
        ///
        public DataColumn ColumnDonorKey;
        ///
        public DataColumn ColumnDonorShortName;
        ///
        public DataColumn ColumnRecipientDescription;

        /// create the columns
        protected override void InitClass()
        {
            this.Columns.Add(new System.Data.DataColumn("a_statement_key_i", typeof(Int32)));
            this.Columns.Add(new System.Data.DataColumn("a_order_i", typeof(Int32)));
            this.Columns.Add(new System.Data.DataColumn("a_statement_bank_account_key_i", typeof(Int32)));
            this.Columns.Add(new System.Data.DataColumn("a_account_name_c", typeof(String)));
            this.Columns.Add(new System.Data.DataColumn("a_title_c", typeof(String)));
            this.Columns.Add(new System.Data.DataColumn("a_first_name_c", typeof(String)));
            this.Columns.Add(new System.Data.DataColumn("a_middle_name_c", typeof(String)));
            this.Columns.Add(new System.Data.DataColumn("a_last_name_c", typeof(String)));
            this.Columns.Add(new System.Data.DataColumn("p_branch_code_c", typeof(String)));
            this.Columns.Add(new System.Data.DataColumn("p_bic_c", typeof(String)));
            this.Columns.Add(new System.Data.DataColumn("a_bank_account_number_c", typeof(String)));
            this.Columns.Add(new System.Data.DataColumn("a_iban_c", typeof(String)));
            this.Columns.Add(new System.Data.DataColumn("a_transaction_type_code_c", typeof(String)));
            this.Columns.Add(new System.Data.DataColumn("a_transaction_amount_n", typeof(Double)));
            this.Columns.Add(new System.Data.DataColumn("a_description_c", typeof(String)));
            this.Columns.Add(new System.Data.DataColumn("a_date_effective_d", typeof(System.DateTime)));
            this.Columns.Add(new System.Data.DataColumn("a_ep_match_key_i", typeof(Int32)));
            this.Columns.Add(new System.Data.DataColumn("a_matching_status_c", typeof(String)));
            this.Columns.Add(new System.Data.DataColumn("s_date_created_d", typeof(System.DateTime)));
            this.Columns.Add(new System.Data.DataColumn("s_created_by_c", typeof(String)));
            this.Columns.Add(new System.Data.DataColumn("s_date_modified_d", typeof(System.DateTime)));
            this.Columns.Add(new System.Data.DataColumn("s_modified_by_c", typeof(String)));
            this.Columns.Add(new System.Data.DataColumn("s_modification_id_c", typeof(String)));
            this.Columns.Add(new System.Data.DataColumn("DetailKey", typeof(Int32)));
            this.Columns.Add(new System.Data.DataColumn("OriginalAmountOnStatement", typeof(Double)));
            this.Columns.Add(new System.Data.DataColumn("GiftLedgerNumber", typeof(Int32)));
            this.Columns.Add(new System.Data.DataColumn("GiftBatchNumber", typeof(Int32)));
            this.Columns.Add(new System.Data.DataColumn("GiftTransactionNumber", typeof(Int32)));
            this.Columns.Add(new System.Data.DataColumn("GiftDetailNumber", typeof(Int32)));
            this.Columns.Add(new System.Data.DataColumn("DonorKey", typeof(Int64)));
            this.Columns.Add(new System.Data.DataColumn("DonorShortName", typeof(string)));
            this.Columns.Add(new System.Data.DataColumn("RecipientDescription", typeof(string)));
        }

        /// assign columns to properties, set primary key
        public override void InitVars()
        {
            this.ColumnStatementKey = this.Columns["a_statement_key_i"];
            this.ColumnOrder = this.Columns["a_order_i"];
            this.ColumnStatementBankAccountKey = this.Columns["a_statement_bank_account_key_i"];
            this.ColumnAccountName = this.Columns["a_account_name_c"];
            this.ColumnTitle = this.Columns["a_title_c"];
            this.ColumnFirstName = this.Columns["a_first_name_c"];
            this.ColumnMiddleName = this.Columns["a_middle_name_c"];
            this.ColumnLastName = this.Columns["a_last_name_c"];
            this.ColumnBranchCode = this.Columns["p_branch_code_c"];
            this.ColumnBic = this.Columns["p_bic_c"];
            this.ColumnBankAccountNumber = this.Columns["a_bank_account_number_c"];
            this.ColumnIban = this.Columns["a_iban_c"];
            this.ColumnTransactionTypeCode = this.Columns["a_transaction_type_code_c"];
            this.ColumnTransactionAmount = this.Columns["a_transaction_amount_n"];
            this.ColumnDescription = this.Columns["a_description_c"];
            this.ColumnDateEffective = this.Columns["a_date_effective_d"];
            this.ColumnEpMatchKey = this.Columns["a_ep_match_key_i"];
            this.ColumnMatchingStatus = this.Columns["a_matching_status_c"];
            this.ColumnDateCreated = this.Columns["s_date_created_d"];
            this.ColumnCreatedBy = this.Columns["s_created_by_c"];
            this.ColumnDateModified = this.Columns["s_date_modified_d"];
            this.ColumnModifiedBy = this.Columns["s_modified_by_c"];
            this.ColumnModificationId = this.Columns["s_modification_id_c"];
            this.ColumnDetailKey = this.Columns["DetailKey"];
            this.ColumnOriginalAmountOnStatement = this.Columns["OriginalAmountOnStatement"];
            this.ColumnGiftLedgerNumber = this.Columns["GiftLedgerNumber"];
            this.ColumnGiftBatchNumber = this.Columns["GiftBatchNumber"];
            this.ColumnGiftTransactionNumber = this.Columns["GiftTransactionNumber"];
            this.ColumnGiftDetailNumber = this.Columns["GiftDetailNumber"];
            this.ColumnDonorKey = this.Columns["DonorKey"];
            this.ColumnDonorShortName = this.Columns["DonorShortName"];
            this.ColumnRecipientDescription = this.Columns["RecipientDescription"];
            this.PrimaryKey = new System.Data.DataColumn[3] {
                    ColumnStatementKey,ColumnOrder,ColumnDetailKey};
        }

        /// Access a typed row by index
        public new BankImportTDSAEpTransactionRow this[int i]
        {
            get
            {
                return ((BankImportTDSAEpTransactionRow)(this.Rows[i]));
            }
        }

        /// create a new typed row
        public new BankImportTDSAEpTransactionRow NewRowTyped(bool AWithDefaultValues)
        {
            BankImportTDSAEpTransactionRow ret = ((BankImportTDSAEpTransactionRow)(this.NewRow()));
            if ((AWithDefaultValues == true))
            {
                ret.InitValues();
            }
            return ret;
        }

        /// create a new typed row, always with default values
        public new BankImportTDSAEpTransactionRow NewRowTyped()
        {
            return this.NewRowTyped(true);
        }

        /// new typed row using DataRowBuilder
        protected override System.Data.DataRow NewRowFromBuilder(System.Data.DataRowBuilder builder)
        {
            return new BankImportTDSAEpTransactionRow(builder);
        }

        /// get typed set of changes
        public new BankImportTDSAEpTransactionTable GetChangesTyped()
        {
            return ((BankImportTDSAEpTransactionTable)(base.GetChangesTypedInternal()));
        }

        /// return the CamelCase name of the table
        public static new string GetTableName()
        {
            return "AEpTransaction";
        }

        /// return the name of the table as it is used in the database
        public static new string GetTableDBName()
        {
            return "a_ep_transaction";
        }

        /// get an odbc parameter for the given column
        public override OdbcParameter CreateOdbcParameter(Int32 AColumnNr)
        {
            return CreateOdbcParameter(TableId, AColumnNr);
        }

        /// get the name of the field in the database for this column
        public static string GetDetailKeyDBName()
        {
            return "DetailKey";
        }

        /// get character length for column
        public static short GetDetailKeyLength()
        {
            return -1;
        }

        /// get the name of the field in the database for this column
        public static string GetOriginalAmountOnStatementDBName()
        {
            return "OriginalAmountOnStatement";
        }

        /// get character length for column
        public static short GetOriginalAmountOnStatementLength()
        {
            return -1;
        }

        /// get the name of the field in the database for this column
        public static string GetGiftLedgerNumberDBName()
        {
            return "GiftLedgerNumber";
        }

        /// get character length for column
        public static short GetGiftLedgerNumberLength()
        {
            return -1;
        }

        /// get the name of the field in the database for this column
        public static string GetGiftBatchNumberDBName()
        {
            return "GiftBatchNumber";
        }

        /// get character length for column
        public static short GetGiftBatchNumberLength()
        {
            return -1;
        }

        /// get the name of the field in the database for this column
        public static string GetGiftTransactionNumberDBName()
        {
            return "GiftTransactionNumber";
        }

        /// get character length for column
        public static short GetGiftTransactionNumberLength()
        {
            return -1;
        }

        /// get the name of the field in the database for this column
        public static string GetGiftDetailNumberDBName()
        {
            return "GiftDetailNumber";
        }

        /// get character length for column
        public static short GetGiftDetailNumberLength()
        {
            return -1;
        }

        /// get the name of the field in the database for this column
        public static string GetDonorKeyDBName()
        {
            return "DonorKey";
        }

        /// get character length for column
        public static short GetDonorKeyLength()
        {
            return -1;
        }

        /// get the name of the field in the database for this column
        public static string GetDonorShortNameDBName()
        {
            return "DonorShortName";
        }

        /// get character length for column
        public static short GetDonorShortNameLength()
        {
            return -1;
        }

        /// get the name of the field in the database for this column
        public static string GetRecipientDescriptionDBName()
        {
            return "RecipientDescription";
        }

        /// get character length for column
        public static short GetRecipientDescriptionLength()
        {
            return -1;
        }

    }

    /// the transactions from the recently imported bank statements; they should help to identify the other party of the transaction (donor, etc) and the purpose of the transaction
    [Serializable()]
    public class BankImportTDSAEpTransactionRow : AEpTransactionRow
    {
        private BankImportTDSAEpTransactionTable myTable;

        /// Constructor
        public BankImportTDSAEpTransactionRow(System.Data.DataRowBuilder rb) :
                base(rb)
        {
            this.myTable = ((BankImportTDSAEpTransactionTable)(this.Table));
        }

        ///
        public Int32 DetailKey
        {
            get
            {
                object ret;
                ret = this[this.myTable.ColumnDetailKey.Ordinal];
                if ((ret == System.DBNull.Value))
                {
                    throw new System.Data.StrongTypingException("Error: DB null", null);
                }
                else
                {
                    return ((Int32)(ret));
                }
            }
            set
            {
                if ((this.IsNull(this.myTable.ColumnDetailKey)
                            || (((Int32)(this[this.myTable.ColumnDetailKey])) != value)))
                {
                    this[this.myTable.ColumnDetailKey] = value;
                }
            }
        }

        ///
        public Double OriginalAmountOnStatement
        {
            get
            {
                object ret;
                ret = this[this.myTable.ColumnOriginalAmountOnStatement.Ordinal];
                if ((ret == System.DBNull.Value))
                {
                    throw new System.Data.StrongTypingException("Error: DB null", null);
                }
                else
                {
                    return ((Double)(ret));
                }
            }
            set
            {
                if ((this.IsNull(this.myTable.ColumnOriginalAmountOnStatement)
                            || (((Double)(this[this.myTable.ColumnOriginalAmountOnStatement])) != value)))
                {
                    this[this.myTable.ColumnOriginalAmountOnStatement] = value;
                }
            }
        }

        ///
        public Int32 GiftLedgerNumber
        {
            get
            {
                object ret;
                ret = this[this.myTable.ColumnGiftLedgerNumber.Ordinal];
                if ((ret == System.DBNull.Value))
                {
                    throw new System.Data.StrongTypingException("Error: DB null", null);
                }
                else
                {
                    return ((Int32)(ret));
                }
            }
            set
            {
                if ((this.IsNull(this.myTable.ColumnGiftLedgerNumber)
                            || (((Int32)(this[this.myTable.ColumnGiftLedgerNumber])) != value)))
                {
                    this[this.myTable.ColumnGiftLedgerNumber] = value;
                }
            }
        }

        ///
        public Int32 GiftBatchNumber
        {
            get
            {
                object ret;
                ret = this[this.myTable.ColumnGiftBatchNumber.Ordinal];
                if ((ret == System.DBNull.Value))
                {
                    throw new System.Data.StrongTypingException("Error: DB null", null);
                }
                else
                {
                    return ((Int32)(ret));
                }
            }
            set
            {
                if ((this.IsNull(this.myTable.ColumnGiftBatchNumber)
                            || (((Int32)(this[this.myTable.ColumnGiftBatchNumber])) != value)))
                {
                    this[this.myTable.ColumnGiftBatchNumber] = value;
                }
            }
        }

        ///
        public Int32 GiftTransactionNumber
        {
            get
            {
                object ret;
                ret = this[this.myTable.ColumnGiftTransactionNumber.Ordinal];
                if ((ret == System.DBNull.Value))
                {
                    throw new System.Data.StrongTypingException("Error: DB null", null);
                }
                else
                {
                    return ((Int32)(ret));
                }
            }
            set
            {
                if ((this.IsNull(this.myTable.ColumnGiftTransactionNumber)
                            || (((Int32)(this[this.myTable.ColumnGiftTransactionNumber])) != value)))
                {
                    this[this.myTable.ColumnGiftTransactionNumber] = value;
                }
            }
        }

        ///
        public Int32 GiftDetailNumber
        {
            get
            {
                object ret;
                ret = this[this.myTable.ColumnGiftDetailNumber.Ordinal];
                if ((ret == System.DBNull.Value))
                {
                    throw new System.Data.StrongTypingException("Error: DB null", null);
                }
                else
                {
                    return ((Int32)(ret));
                }
            }
            set
            {
                if ((this.IsNull(this.myTable.ColumnGiftDetailNumber)
                            || (((Int32)(this[this.myTable.ColumnGiftDetailNumber])) != value)))
                {
                    this[this.myTable.ColumnGiftDetailNumber] = value;
                }
            }
        }

        ///
        public Int64 DonorKey
        {
            get
            {
                object ret;
                ret = this[this.myTable.ColumnDonorKey.Ordinal];
                if ((ret == System.DBNull.Value))
                {
                    throw new System.Data.StrongTypingException("Error: DB null", null);
                }
                else
                {
                    return ((Int64)(ret));
                }
            }
            set
            {
                if ((this.IsNull(this.myTable.ColumnDonorKey)
                            || (((Int64)(this[this.myTable.ColumnDonorKey])) != value)))
                {
                    this[this.myTable.ColumnDonorKey] = value;
                }
            }
        }

        ///
        public string DonorShortName
        {
            get
            {
                object ret;
                ret = this[this.myTable.ColumnDonorShortName.Ordinal];
                if ((ret == System.DBNull.Value))
                {
                    return String.Empty;
                }
                else
                {
                    return ((string)(ret));
                }
            }
            set
            {
                if ((this.IsNull(this.myTable.ColumnDonorShortName)
                            || (((string)(this[this.myTable.ColumnDonorShortName])) != value)))
                {
                    this[this.myTable.ColumnDonorShortName] = value;
                }
            }
        }

        ///
        public string RecipientDescription
        {
            get
            {
                object ret;
                ret = this[this.myTable.ColumnRecipientDescription.Ordinal];
                if ((ret == System.DBNull.Value))
                {
                    return String.Empty;
                }
                else
                {
                    return ((string)(ret));
                }
            }
            set
            {
                if ((this.IsNull(this.myTable.ColumnRecipientDescription)
                            || (((string)(this[this.myTable.ColumnRecipientDescription])) != value)))
                {
                    this[this.myTable.ColumnRecipientDescription] = value;
                }
            }
        }

        /// set default values
        public override void InitValues()
        {
            this.SetNull(this.myTable.ColumnStatementKey);
            this.SetNull(this.myTable.ColumnOrder);
            this.SetNull(this.myTable.ColumnStatementBankAccountKey);
            this.SetNull(this.myTable.ColumnAccountName);
            this.SetNull(this.myTable.ColumnTitle);
            this.SetNull(this.myTable.ColumnFirstName);
            this.SetNull(this.myTable.ColumnMiddleName);
            this.SetNull(this.myTable.ColumnLastName);
            this.SetNull(this.myTable.ColumnBranchCode);
            this.SetNull(this.myTable.ColumnBic);
            this.SetNull(this.myTable.ColumnBankAccountNumber);
            this.SetNull(this.myTable.ColumnIban);
            this.SetNull(this.myTable.ColumnTransactionTypeCode);
            this[this.myTable.ColumnTransactionAmount.Ordinal] = 0;
            this.SetNull(this.myTable.ColumnDescription);
            this[this.myTable.ColumnDateEffective.Ordinal] = DateTime.Today;
            this.SetNull(this.myTable.ColumnEpMatchKey);
            this.SetNull(this.myTable.ColumnMatchingStatus);
            this[this.myTable.ColumnDateCreated.Ordinal] = DateTime.Today;
            this.SetNull(this.myTable.ColumnCreatedBy);
            this.SetNull(this.myTable.ColumnDateModified);
            this.SetNull(this.myTable.ColumnModifiedBy);
            this.SetNull(this.myTable.ColumnModificationId);
            this.SetNull(this.myTable.ColumnDetailKey);
            this.SetNull(this.myTable.ColumnOriginalAmountOnStatement);
            this.SetNull(this.myTable.ColumnGiftLedgerNumber);
            this.SetNull(this.myTable.ColumnGiftBatchNumber);
            this.SetNull(this.myTable.ColumnGiftTransactionNumber);
            this.SetNull(this.myTable.ColumnGiftDetailNumber);
            this.SetNull(this.myTable.ColumnDonorKey);
            this.SetNull(this.myTable.ColumnDonorShortName);
            this.SetNull(this.myTable.ColumnRecipientDescription);
        }

        /// test for NULL value
        public bool IsDetailKeyNull()
        {
            return this.IsNull(this.myTable.ColumnDetailKey);
        }

        /// assign NULL value
        public void SetDetailKeyNull()
        {
            this.SetNull(this.myTable.ColumnDetailKey);
        }

        /// test for NULL value
        public bool IsOriginalAmountOnStatementNull()
        {
            return this.IsNull(this.myTable.ColumnOriginalAmountOnStatement);
        }

        /// assign NULL value
        public void SetOriginalAmountOnStatementNull()
        {
            this.SetNull(this.myTable.ColumnOriginalAmountOnStatement);
        }

        /// test for NULL value
        public bool IsGiftLedgerNumberNull()
        {
            return this.IsNull(this.myTable.ColumnGiftLedgerNumber);
        }

        /// assign NULL value
        public void SetGiftLedgerNumberNull()
        {
            this.SetNull(this.myTable.ColumnGiftLedgerNumber);
        }

        /// test for NULL value
        public bool IsGiftBatchNumberNull()
        {
            return this.IsNull(this.myTable.ColumnGiftBatchNumber);
        }

        /// assign NULL value
        public void SetGiftBatchNumberNull()
        {
            this.SetNull(this.myTable.ColumnGiftBatchNumber);
        }

        /// test for NULL value
        public bool IsGiftTransactionNumberNull()
        {
            return this.IsNull(this.myTable.ColumnGiftTransactionNumber);
        }

        /// assign NULL value
        public void SetGiftTransactionNumberNull()
        {
            this.SetNull(this.myTable.ColumnGiftTransactionNumber);
        }

        /// test for NULL value
        public bool IsGiftDetailNumberNull()
        {
            return this.IsNull(this.myTable.ColumnGiftDetailNumber);
        }

        /// assign NULL value
        public void SetGiftDetailNumberNull()
        {
            this.SetNull(this.myTable.ColumnGiftDetailNumber);
        }

        /// test for NULL value
        public bool IsDonorKeyNull()
        {
            return this.IsNull(this.myTable.ColumnDonorKey);
        }

        /// assign NULL value
        public void SetDonorKeyNull()
        {
            this.SetNull(this.myTable.ColumnDonorKey);
        }

        /// test for NULL value
        public bool IsDonorShortNameNull()
        {
            return this.IsNull(this.myTable.ColumnDonorShortName);
        }

        /// assign NULL value
        public void SetDonorShortNameNull()
        {
            this.SetNull(this.myTable.ColumnDonorShortName);
        }

        /// test for NULL value
        public bool IsRecipientDescriptionNull()
        {
            return this.IsNull(this.myTable.ColumnRecipientDescription);
        }

        /// assign NULL value
        public void SetRecipientDescriptionNull()
        {
            this.SetNull(this.myTable.ColumnRecipientDescription);
        }
    }
}