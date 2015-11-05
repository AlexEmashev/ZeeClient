using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace ZeeClient
{
    /// <summary>
    /// Class for implementing single instance functionallity.
    /// </summary>
    class SingleInstance
    {
        /// <summary>
        /// Mutex to organize single instance feature.
        /// </summary>
        static Mutex mutex;

        const int HWND_BROADCAST = 0xffff;
        /// <summary>
        /// Message asking app to show main window.
        /// </summary>
        public static readonly int WM_SHOW_MAIN_WND = RegisterWindowMessage("WM_SHOW_MAIN_WND");
        [DllImport("user32")]
        public static extern bool PostMessage(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam);
        [DllImport("user32")]
        public static extern int RegisterWindowMessage(string message);

        /// <summary>
        /// Create single instance class
        /// And register mutex of app.
        /// </summary>
        /// <param name="guid">GUID of application (generate your own GUID).</param>
        public SingleInstance(string guid)
        {
            mutex = new Mutex(true, guid);
        }

        /// <summary>
        /// Checks if instance of app is already exists.
        /// If app is running, message to show main window will be sent to it.
        /// <remarks>The message must be handeled by app in WndProc method.</remarks>
        /// </summary>
        /// <returns>True if app is already running.</returns>
        public bool InstanceExists()
        {
            if (mutex.WaitOne(TimeSpan.Zero, true))
            {
                return false;
            }
            else
            {
                // Send message to running up, asking to show it's window.
                PostMessage((IntPtr)HWND_BROADCAST, WM_SHOW_MAIN_WND, IntPtr.Zero, IntPtr.Zero);
                return true;
            }
        }
    }
}
