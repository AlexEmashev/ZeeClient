using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace ZeeClient
{
    static class Program
    {
        /// <summary>
        /// Application GUID
        /// </summary>
        public static string guid = "{EF323CFA-57F0-4051-B7CF-163195A558C1}";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            SingleInstance singleInstance = new SingleInstance(guid);

            if(!singleInstance.InstanceExists())
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FormClient());
            }
        }
    }
}
