﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Sigesoft.Node.WinClient.UI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmLogin());
            bool instanceCountOne = false;
            bool OnlyStartOnce = bool.Parse(Common.Utils.GetApplicationConfigValue("OnlyStartOnce"));

            if (OnlyStartOnce)
            {
                using (Mutex mtex = new Mutex(true, "MyRunningApp", out instanceCountOne))
                {
                    if (instanceCountOne)
                    {
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        Application.Run(new frmLogin());
                        //Application.Run(new frmControlAsistencia());
                        mtex.ReleaseMutex();
                    }
                    else
                    {
                        MessageBox.Show("La aplicación ya se está ejecutando");
                    }
                }
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmLogin());
                //Application.Run(new frmControlAsistencia());
            }
        }
    }
}