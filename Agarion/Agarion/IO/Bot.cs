using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Drawing;

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
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int GetWindowThreadProcessId(IntPtr handle, out int processId);

        /// <summary>
        /// The main console object that the bot uses to send output
        /// </summary>
        public static AgarionConsole Console { get; private set; }

        /// <summary>
        /// The main web browser object that the bot uses
        /// </summary>
        public static WebBrowser Browser { get; set; }

        /// <summary>
        /// The bot's current process
        /// </summary>
        public static Process CurrentProcess { get; private set; }

        /// <summary>
        /// Gets whether the bot is running or not
        /// </summary>
        public static bool Running { get; private set; }

        /// <summary>
        /// Gets the UI API.
        /// </summary>
        public static UIHandler UI { get; private set; }

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

            // Set the current process
            CurrentProcess = Process.GetCurrentProcess();

            UI = new UIHandler();

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

            Running = true;

            // Start the screenhandler
            ScreenHandler.Initialize(ScreenHandler.GetMiddleScreen());

            // Start the update method.
            AsyncHelper.ExecuteUpdatingMethod(Update, IsBotActiveAndRunning, true, 10);

            Console.Log("Started!");
        }

        /// <summary>
        /// Stops the bot.
        /// </summary>
        public static void Stop()
        {
            Running = false;
        }

        /// <summary>
        /// The update method.
        /// Updates every 10 msec.
        /// </summary>
        /// <param name="uptime">The current uptime.</param>
        private static void Update(int uptime)
        {
            
        }

        /// <summary>
        /// Gets whether the bot window is active.
        /// </summary>
        /// <returns>Whether the bot window is active or not.</returns>
        public static bool IsBotActive()
        {
            // Get the top-most window.
            var handle = GetForegroundWindow();

            if (handle == IntPtr.Zero)
                // Handle is zero. Window is not active.
                return false;

            // Get the current process id
            var pId = CurrentProcess.Id;
            int activeWindowId;

            // Set the active window id
            GetWindowThreadProcessId(handle, out activeWindowId);

            return pId == activeWindowId;
        }

        /// <summary>
        /// Gets whether the bot is active and also running.
        /// </summary>
        /// <returns>Returns the bot's active & running state.</returns>
        public static bool IsBotActiveAndRunning()
        {
            return IsBotActive() && Running;
        }
    }
}
