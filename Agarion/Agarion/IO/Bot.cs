using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

using Agarion.IO.DebugTools;
using Agarion.IO.ThreadingTools;
using Agarion.IO.ScreenTools;

namespace Agarion.IO
{
    /// <summary>
    /// The main bot class
    /// Handles everything that has to do with the colorbot.
    /// </summary>
    public static class Bot
    {
        /// <summary>
        /// The main console object that the bot uses to send output
        /// </summary>
        public static AgarionConsole Console { get; private set; }

        /// <summary>
        /// The main web browser object that the bot uses
        /// </summary>
        public static WebBrowser Browser { get; private set; }

        /// <summary>
        /// Initializes the bot.
        /// Starts the bot after 5 seconds.
        /// </summary>
        /// <param name="console">The console object - should be of type ListBox</param>
        public static void Initialize(WebBrowser browser, Control console)
        {
            if (browser == null || console == null)
                return;

            if (console is ListBox == false)
                Debug.WriteLine("[Agarion] Warning: Console is not of type ListBox. This could cause unexpected behavior in the future.");

            Browser = browser;
            Console = new AgarionConsole(console);

            AsyncHelper.ExecuteMethod(Start, 5000);
        }

        /// <summary>
        /// Starts the bot.
        /// NOTE: The bot starts automatically after 5 seconds after calling the initialize method.
        /// </summary>
        public static void Start()
        {
            Console.Log("Starting Agarion...");

            // Start the screenhandler
            ScreenHandler.Initialize(ScreenId.Second);

            Console.Log("Started!");
        }
    }
}
