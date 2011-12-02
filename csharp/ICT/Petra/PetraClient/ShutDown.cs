//
// DO NOT REMOVE COPYRIGHT NOTICES OR THIS FILE HEADER.
//
// @Authors:
//       christiank
//
// Copyright 2004-2010 by OM International
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
using System.Diagnostics;
using System.Windows.Forms;
using Ict.Petra.Client.App.Core;
using SplashScreen;

namespace PetraClientShutdown
{
/// <summary>
/// Handles various aspects of the shutdown of the PetraClient.
/// </summary>
public static class Shutdown
{
    private static TSplashScreenManager FSplashScreen;

    /// <summary>
    /// the splash screen
    /// </summary>
    public static TSplashScreenManager SplashScreen
    {
        get
        {
            return FSplashScreen;
        }

        set
        {
            FSplashScreen = value;
        }
    }

    /// <summary>
    /// todoComment
    /// </summary>
    public static void SaveUserDefaultsAndDisconnect()
    {
        String CantDisconnectReason;

        try
        {
            TUserDefaults.SaveChangedUserDefaults();

            if (!Ict.Petra.Client.App.Core.TConnectionManagement.GConnectionManagement.DisconnectFromServer(out CantDisconnectReason))
            {
#if TESTMODE
                TLogging.Log("cannot disconnect: " + CantDisconnectReason);
#endif
#if  TESTMODE
#else
#if DEBUGMODE
                MessageBox.Show(CantDisconnectReason, "Error on Client Disconnection");
#endif
#endif
            }
        }
        catch (Exception Exp)
        {
#if DEBUGMODE
            MessageBox.Show("DEBUGMODE Information: Unhandled exception while disconnecting from Servers: " + "\r\n" + Exp.ToString());
#endif
        }
    }

    /// <summary>
    /// todoComment
    /// </summary>
    public static void SaveUserDefaultsAndDisconnectAndStop()
    {
        SaveUserDefaultsAndDisconnect();
        StopPetraClient();
    }

    /// <summary>
    /// todoComment
    /// </summary>
    public static void StopPetraClient()
    {
        if (TClientSettings.RunAsStandalone == true)
        {
            StopServers();
        }

        // APPLICATION STOPS HERE !!!
        Environment.Exit(0);
    }

    /// <summary>
    /// Stops the Petra Server Console
    /// </summary>
    public static void StopServers()
    {
        System.Diagnostics.Process PetraServerProcess;

        // stop the Petra server (e.g. c:\petra2\bin22\PetraServerAdminConsole.exe C:C:\petra2\ServerAdminStandalone.config Command:Stop
        try
        {
            PetraServerProcess = new System.Diagnostics.Process();
            PetraServerProcess.StartInfo.FileName = TClientSettings.Petra_Path_Bin + "/PetraServerAdminConsole.exe";
            PetraServerProcess.StartInfo.WorkingDirectory = TClientSettings.Petra_Path_Bin;
            PetraServerProcess.StartInfo.Arguments = "-C:\"" + TClientSettings.PetraServerAdmin_Configfile + "\" -Command:Stop";
            PetraServerProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            PetraServerProcess.EnableRaisingEvents = false;

            if (!PetraServerProcess.Start())
            {
#if TESTMODE
                TLogging.Log("failed to start " + PetraServerProcess.StartInfo.FileName);
#endif
                return;
            }
        }
        catch (Exception exp)
        {
#if TESTMODE
            TLogging.Log("Exception while shutting down OpenPetra server process: " + exp.ToString());
#endif
#if  TESTMODE
#else
            MessageBox.Show("Exception while shutting down OpenPetra server process: " + exp.ToString());
#endif
            return;
        }

        PetraServerProcess.WaitForExit(20000);

        StopPostgreSqlServer();
    }

    private static void StopPostgreSqlServer()
    {
#if TODO
        System.Diagnostics.Process PostgreSqlServerProcess;

        if (TClientSettings.RunAsStandalone)
        {
            // stop the PostgreSql server (e.g. c:\Program Files\Postgres\8.3\bin\pg_ctl.exe -D C:\petra2\db23_pg stop
            try
            {
                PostgreSqlServerProcess = new System.Diagnostics.Process();
                PostgreSqlServerProcess.StartInfo.FileName = "\"" + TClientSettings.PostgreSql_BaseDir + "\\bin\\pg_ctl.exe\"";
                PostgreSqlServerProcess.StartInfo.Arguments = "-D " + TClientSettings.PostgreSql_DataDir + " stop";
                PostgreSqlServerProcess.StartInfo.WorkingDirectory = TClientSettings.PostgreSql_DataDir;
                PostgreSqlServerProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                PostgreSqlServerProcess.EnableRaisingEvents = false;
                PostgreSqlServerProcess.StartInfo.UseShellExecute = false;

                System.Security.SecureString MyPassword = new System.Security.SecureString();
                String Pwd = "petra";

                foreach (char c in Pwd)
                {
                    MyPassword.AppendChar(c);
                }

                PostgreSqlServerProcess.StartInfo.Password = MyPassword;
                PostgreSqlServerProcess.StartInfo.UserName = "petrapostgresqluser";

                if (!PostgreSqlServerProcess.Start())
                {
#if TESTMODE
                    TLogging.Log("failed to start " + PostgreSqlServerProcess.StartInfo.FileName);
#endif
                    return;
                }
            }
            catch (Exception exp)
            {
#if TESTMODE
                TLogging.Log("Exception while shutting down PostgreSql server process: " + exp.ToString());
#else
                MessageBox.Show("Exception while shutting down PostgreSql server process: " + exp.ToString());
#endif
                return;
            }
            PostgreSqlServerProcess.WaitForExit(20000);
        }
#endif
    }
}
}