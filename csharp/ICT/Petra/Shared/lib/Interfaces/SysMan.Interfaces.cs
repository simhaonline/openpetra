/* Auto generated with nant generateGlue, based on csharp\ICT\Petra\Definitions\NamespaceHierarchy.xml
 * and the Server c# files (eg. UIConnector implementations)
 * Do not change this file manually.
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Ict.Common;
using Ict.Common.Verification;
using Ict.Petra.Shared.Interfaces.MSysMan.Application;
using Ict.Petra.Shared.Interfaces.MSysMan.Maintenance;
using Ict.Petra.Shared.Interfaces.MSysMan.TableMaintenance;
using Ict.Petra.Shared.Interfaces.MSysMan.ImportExport;
using Ict.Petra.Shared.Interfaces.MSysMan.PrintManagement;
using Ict.Petra.Shared.Interfaces.MSysMan.Security;
using Ict.Petra.Shared.Interfaces.MSysMan.Application.UIConnectors;
using Ict.Petra.Shared.Interfaces.MSysMan.Application.ServerLookups;
using Ict.Petra.Shared.Interfaces.MSysMan.Maintenance.SystemDefaults;
using Ict.Petra.Shared.Interfaces.MSysMan.Maintenance.UIConnectors;
using Ict.Petra.Shared.Interfaces.MSysMan.Maintenance.UserDefaults;
using Ict.Petra.Shared.Interfaces.MSysMan.Maintenance.WebConnectors;
using Ict.Petra.Shared.Interfaces.MSysMan.TableMaintenance.UIConnectors;
using Ict.Petra.Shared.Interfaces.MSysMan.ImportExport.WebConnectors;
using Ict.Petra.Shared.Interfaces.MSysMan.PrintManagement.UIConnectors;
using Ict.Petra.Shared.Interfaces.MSysMan.Security.UIConnectors;
using Ict.Petra.Shared.Interfaces.MSysMan.Security.UserManager;
#region ManualCode
using System.Xml;
using Ict.Petra.Shared.MSysMan.Data;
#endregion
namespace Ict.Petra.Shared.Interfaces.MSysMan
{
    /// <summary>auto generated</summary>
    public interface IMSysManNamespace : IInterface
    {
        /// <summary>access to sub namespace</summary>
        IApplicationNamespace Application
        {
            get;
        }

        /// <summary>access to sub namespace</summary>
        IMaintenanceNamespace Maintenance
        {
            get;
        }

        /// <summary>access to sub namespace</summary>
        ITableMaintenanceNamespace TableMaintenance
        {
            get;
        }

        /// <summary>access to sub namespace</summary>
        IImportExportNamespace ImportExport
        {
            get;
        }

        /// <summary>access to sub namespace</summary>
        IPrintManagementNamespace PrintManagement
        {
            get;
        }

        /// <summary>access to sub namespace</summary>
        ISecurityNamespace Security
        {
            get;
        }

    }

}


namespace Ict.Petra.Shared.Interfaces.MSysMan.Application
{
    /// <summary>auto generated</summary>
    public interface IApplicationNamespace : IInterface
    {
        /// <summary>access to sub namespace</summary>
        IApplicationUIConnectorsNamespace UIConnectors
        {
            get;
        }

        /// <summary>access to sub namespace</summary>
        IApplicationServerLookupsNamespace ServerLookups
        {
            get;
        }

    }

}


namespace Ict.Petra.Shared.Interfaces.MSysMan.Application.UIConnectors
{
    /// <summary>auto generated</summary>
    public interface IApplicationUIConnectorsNamespace : IInterface
    {
    }

}


namespace Ict.Petra.Shared.Interfaces.MSysMan.Application.ServerLookups
{
    /// <summary>auto generated</summary>
    public interface IApplicationServerLookupsNamespace : IInterface
    {
        /// <summary>auto generated from Instantiator (Ict.Petra.Server.MSysMan.Instantiator.Application.ServerLookups.TApplicationServerLookupsNamespace)</summary>
        System.Boolean GetDBVersion(out System.String APetraDBVersion);
        /// <summary>auto generated from Instantiator (Ict.Petra.Server.MSysMan.Instantiator.Application.ServerLookups.TApplicationServerLookupsNamespace)</summary>
        System.Boolean GetInstalledPatches(out Ict.Petra.Shared.MSysMan.Data.SPatchLogTable APatchLogDT);
    }

}


namespace Ict.Petra.Shared.Interfaces.MSysMan.Maintenance
{
    /// <summary>auto generated</summary>
    public interface IMaintenanceNamespace : IInterface
    {
        /// <summary>access to sub namespace</summary>
        IMaintenanceSystemDefaultsNamespace SystemDefaults
        {
            get;
        }

        /// <summary>access to sub namespace</summary>
        IMaintenanceUIConnectorsNamespace UIConnectors
        {
            get;
        }

        /// <summary>access to sub namespace</summary>
        IMaintenanceUserDefaultsNamespace UserDefaults
        {
            get;
        }

        /// <summary>access to sub namespace</summary>
        IMaintenanceWebConnectorsNamespace WebConnectors
        {
            get;
        }

    }

}


namespace Ict.Petra.Shared.Interfaces.MSysMan.Maintenance.SystemDefaults
{
    /// <summary>auto generated</summary>
    public interface IMaintenanceSystemDefaultsNamespace : IInterface
    {
        /// <summary>auto generated from Instantiator (Ict.Petra.Server.MSysMan.Instantiator.Maintenance.SystemDefaults.TMaintenanceSystemDefaultsNamespace)</summary>
        Ict.Petra.Shared.MSysMan.Data.SSystemDefaultsTable GetSystemDefaults();
        /// <summary>auto generated from Instantiator (Ict.Petra.Server.MSysMan.Instantiator.Maintenance.SystemDefaults.TMaintenanceSystemDefaultsNamespace)</summary>
        System.Boolean SaveSystemDefaults(Ict.Petra.Shared.MSysMan.Data.SSystemDefaultsTable ASystemDefaultsDataTable);
        /// <summary>auto generated from Instantiator (Ict.Petra.Server.MSysMan.Instantiator.Maintenance.SystemDefaults.TMaintenanceSystemDefaultsNamespace)</summary>
        void ReloadSystemDefaultsTable();
    }

}


namespace Ict.Petra.Shared.Interfaces.MSysMan.Maintenance.UIConnectors
{
    /// <summary>auto generated</summary>
    public interface IMaintenanceUIConnectorsNamespace : IInterface
    {
    }

}


namespace Ict.Petra.Shared.Interfaces.MSysMan.Maintenance.UserDefaults
{
    /// <summary>auto generated</summary>
    public interface IMaintenanceUserDefaultsNamespace : IInterface
    {
        /// <summary>auto generated from Instantiator (Ict.Petra.Server.MSysMan.Instantiator.Maintenance.UserDefaults.TMaintenanceUserDefaultsNamespace)</summary>
        void GetUserDefaults(System.String AUserName,
                             out Ict.Petra.Shared.MSysMan.Data.SUserDefaultsTable AUserDefaultsDataTable);
        /// <summary>auto generated from Instantiator (Ict.Petra.Server.MSysMan.Instantiator.Maintenance.UserDefaults.TMaintenanceUserDefaultsNamespace)</summary>
        System.Boolean SaveUserDefaults(System.String AUserName,
                                        ref Ict.Petra.Shared.MSysMan.Data.SUserDefaultsTable AUserDefaultsDataTable,
                                        out Ict.Common.Verification.TVerificationResultCollection AVerificationResult);
        /// <summary>auto generated from Instantiator (Ict.Petra.Server.MSysMan.Instantiator.Maintenance.UserDefaults.TMaintenanceUserDefaultsNamespace)</summary>
        void ReloadUserDefaults(System.String AUserName,
                                out Ict.Petra.Shared.MSysMan.Data.SUserDefaultsTable AUserDefaultsDataTable);
    }

}


namespace Ict.Petra.Shared.Interfaces.MSysMan.Maintenance.WebConnectors
{
    /// <summary>auto generated</summary>
    public interface IMaintenanceWebConnectorsNamespace : IInterface
    {
        /// <summary> auto generated from Connector method(Ict.Petra.Server.MSysMan.Maintenance.WebConnectors.TMaintenanceWebConnector)</summary>
        bool SetUserPassword(string AUsername,
                             string APassword);
        /// <summary> auto generated from Connector method(Ict.Petra.Server.MSysMan.Maintenance.WebConnectors.TMaintenanceWebConnector)</summary>
        bool CreateUser(string AUsername,
                        string APassword,
                        string AModulePermissions);
        /// <summary> auto generated from Connector method(Ict.Petra.Server.MSysMan.Maintenance.WebConnectors.TMaintenanceWebConnector)</summary>
        TSubmitChangesResult SaveSUser(ref MaintainUsersTDS ASubmitDS,
                                       out TVerificationResultCollection AVerificationResult);
    }

}


namespace Ict.Petra.Shared.Interfaces.MSysMan.TableMaintenance
{
    /// <summary>auto generated</summary>
    public interface ITableMaintenanceNamespace : IInterface
    {
        /// <summary>access to sub namespace</summary>
        ITableMaintenanceUIConnectorsNamespace UIConnectors
        {
            get;
        }

    }

}


namespace Ict.Petra.Shared.Interfaces.MSysMan.TableMaintenance.UIConnectors
{
    /// <summary>auto generated</summary>
    public interface ITableMaintenanceUIConnectorsNamespace : IInterface
    {
        /// <summary>auto generated from Connector constructor (Ict.Petra.Server.MSysMan.TableMaintenance.UIConnectors.TSysManTableMaintenanceUIConnector)</summary>
        ISysManUIConnectorsTableMaintenance SysManTableMaintenance();
        /// <summary>auto generated from Connector constructor and GetData (Ict.Petra.Server.MSysMan.TableMaintenance.UIConnectors.TSysManTableMaintenanceUIConnector)</summary>
        ISysManUIConnectorsTableMaintenance SysManTableMaintenance(ref DataTable ADataSet,
                                                                   string ATableName);
    }

    /// <summary>auto generated</summary>
    public interface ISysManUIConnectorsTableMaintenance : IInterface
    {
        /// <summary> auto generated from Connector method(Ict.Petra.Server.MSysMan.TableMaintenance.UIConnectors.TSysManTableMaintenanceUIConnector)</summary>
        DataTable GetData(string ATableName);
        /// <summary> auto generated from Connector method(Ict.Petra.Server.MSysMan.TableMaintenance.UIConnectors.TSysManTableMaintenanceUIConnector)</summary>
        TSubmitChangesResult SubmitChanges(ref DataTable AInspectTable,
                                           ref DataTable AResponseTable,
                                           out TVerificationResultCollection AVerificationResult);
    }

}


namespace Ict.Petra.Shared.Interfaces.MSysMan.ImportExport
{
    /// <summary>auto generated</summary>
    public interface IImportExportNamespace : IInterface
    {
        /// <summary>access to sub namespace</summary>
        IImportExportWebConnectorsNamespace WebConnectors
        {
            get;
        }

    }

}


namespace Ict.Petra.Shared.Interfaces.MSysMan.ImportExport.WebConnectors
{
    /// <summary>auto generated</summary>
    public interface IImportExportWebConnectorsNamespace : IInterface
    {
        /// <summary> auto generated from Connector method(Ict.Petra.Server.MSysMan.ImportExport.WebConnectors.TImportExportWebConnector)</summary>
        string ExportAllTables();
        /// <summary> auto generated from Connector method(Ict.Petra.Server.MSysMan.ImportExport.WebConnectors.TImportExportWebConnector)</summary>
        bool ResetDatabase(string ANewDatabaseData);
    }

}


namespace Ict.Petra.Shared.Interfaces.MSysMan.PrintManagement
{
    /// <summary>auto generated</summary>
    public interface IPrintManagementNamespace : IInterface
    {
        /// <summary>access to sub namespace</summary>
        IPrintManagementUIConnectorsNamespace UIConnectors
        {
            get;
        }

    }

}


namespace Ict.Petra.Shared.Interfaces.MSysMan.PrintManagement.UIConnectors
{
    /// <summary>auto generated</summary>
    public interface IPrintManagementUIConnectorsNamespace : IInterface
    {
    }

}


namespace Ict.Petra.Shared.Interfaces.MSysMan.Security
{
    /// <summary>auto generated</summary>
    public interface ISecurityNamespace : IInterface
    {
        /// <summary>access to sub namespace</summary>
        ISecurityUIConnectorsNamespace UIConnectors
        {
            get;
        }

        /// <summary>access to sub namespace</summary>
        ISecurityUserManagerNamespace UserManager
        {
            get;
        }

    }

}


namespace Ict.Petra.Shared.Interfaces.MSysMan.Security.UIConnectors
{
    /// <summary>auto generated</summary>
    public interface ISecurityUIConnectorsNamespace : IInterface
    {
    }

}


namespace Ict.Petra.Shared.Interfaces.MSysMan.Security.UserManager
{
    /// <summary>auto generated</summary>
    public interface ISecurityUserManagerNamespace : IInterface
    {
        /// <summary>auto generated from Instantiator (Ict.Petra.Server.MSysMan.Instantiator.Security.UserManager.TSecurityUserManagerNamespace)</summary>
        Ict.Petra.Shared.Security.TPetraPrincipal ReloadCachedUserInfo();
        /// <summary>auto generated from Instantiator (Ict.Petra.Server.MSysMan.Instantiator.Security.UserManager.TSecurityUserManagerNamespace)</summary>
        void SignalReloadCachedUserInfo(System.String AUserID);
    }

}

