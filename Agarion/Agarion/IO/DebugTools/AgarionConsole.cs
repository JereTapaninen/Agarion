using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;

namespace Agarion.IO.DebugTools
{
    /// <summary>
    /// The AgarionConsole
    /// Is really just a debug tool.
    /// Remember to specify the main console control right
    /// </summary>
    public class AgarionConsole
    {
        /// <summary>
        /// The console object (should be lbConsole)
        /// </summary>
        private Control console;

        /// <summary>
        /// Initializes the AgarionConsole
        /// </summary>
        /// <param name="console">The console, should be a ListBox</param>
        public AgarionConsole(Control console)
        {
            this.console = console;
        }

        /// <summary>
        /// Logs a message
        /// </summary>
        /// <param name="message">The message</param>
        public void Log(string message)
        {
            message = "[Agarion] " + message;

            Debug.WriteLine(message);
            Console.WriteLine(message);

            if (this.console is ListBox)
                (this.console as ListBox).Items.Add(message);
        }
    }
}
