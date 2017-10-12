using PassCount.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PassCount
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AppConf appConf = AppConf.Get();
            FormMain formMain = new FormMain(appConf);
            formMain.WindowState = appConf.window.fullsreen ? FormWindowState.Maximized : FormWindowState.Normal;
            Application.Run(formMain);
        }
    }
}
