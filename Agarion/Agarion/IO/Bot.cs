﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

using Agarion.IO.DebugTools;
using Agarion.IO.ThreadingTools;

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
        public static AgarionConsole Console { public get; private set; }

        /// <summary>
        /// Initializes the bot.
        /// Starts the bot after 5 seconds.
        /// </summary>
        /// <param name="console">The console object - should be of type ListBox</param>
        public static void Initialize(Control console)
        {
            if (console is ListBox == false)
                Debug.WriteLine("[Agarion] Warning: Console is not of type ListBox. This could cause unexpected behavior in the future.");

            Console = new AgarionConsole(console);

            AsyncHelper.ExecuteMethod(Start, 5000);
        }

        /// <summary>
        /// Starts the bot.
        /// NOTE: The bot starts automatically after 5 seconds after calling the initialize method.
        /// </summary>
        public static void Start()
        {

        }
    }
}
