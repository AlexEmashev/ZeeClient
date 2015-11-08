using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZeeClient
{
    /// <summary>
    /// Implements simple logging feature.
    /// </summary>
    class SimpleLog
    {
        /// <summary>
        /// Writes <paramref name="message"/> to log file.
        /// </summary>
        /// <param name="message">Message to write to log.</param>
        /// <param name="overwrite">Overwrite existing log file.</param>
        public static void Write(string message, bool overwrite)
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter("app.log", !overwrite);
            file.WriteLine(message);
            file.Close();
        }

    }
}
