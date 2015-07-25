using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.IO;

using Agarion.IO.ThreadingTools;

namespace Agarion.IO.ScreenTools
{
    public enum ScreenId : byte
    {
        First = 1,
        Second = 2,
        Third = 3,
        Fourth = 4,
        Fifth = 5,
    }

    public static class ScreenHandler
    {
        /// <summary>
        /// Gets the most current screenshot of the window.
        /// </summary>
        public static Bitmap CurrentWindowSnap { get; private set; }

        /// <summary>
        /// Gets whether the handler is running or not
        /// </summary>
        public static bool Running { get; private set; }

        /// <summary>
        /// Gets or sets the current screen
        /// Useful if user has multiple screens
        /// </summary>
        private static Screen CurrentScreen { get; set; }

        /// <summary>
        /// The screenshot bitmap. Used for temporary stuff only.
        /// </summary>
        private static Bitmap ScreenBitmap { get; set; }

        /// <summary>
        /// Gets the most current screenshot
        /// </summary>
        private static Bitmap CurrentScreenshot { get; set; }

        /// <summary>
        /// Initializes the handler
        /// Starts the handler afterwards
        /// </summary>
        public static void Initialize(ScreenId screenId)
        {
            // Set the temp id
            var id = ((byte)screenId) - 1;

            // If there are not enough screens for that id, just return.
            if (id >= Screen.AllScreens.Length)
                return;

            // Set the current screen
            CurrentScreen = Screen.AllScreens[id];

            // Set the screen bitmap to the screen bounds
            ScreenBitmap = new Bitmap(CurrentScreen.Bounds.Width, CurrentScreen.Bounds.Height, PixelFormat.Format32bppArgb);

            // Start the handler
            AsyncHelper.ExecuteMethod(Start);
        }

        /// <summary>
        /// Starts the capturing of the screenshots
        /// </summary>
        public static void Start()
        {
            Running = true;

            AsyncHelper.ExecuteUpdatingMethod(CaptureScreen, Bot.IsBotActiveAndRunning, true, 150);
        }

        /// <summary>
        /// Stops the handler
        /// </summary>
        public static void Stop()
        {
            Running = false;

            // Set null values to everything
            CurrentScreen = null;
            CurrentScreenshot = null;
        }

        /// <summary>
        /// Saves the specified screenshot
        /// </summary>
        /// <param name="path">The path. Default is /currentdir/cap.png</param>
        public static void SaveScreenshot(Bitmap bmp, string path = "cap.png")
        {
            if (File.Exists(path))
                File.Delete(path);

            bmp.Save(path, ImageFormat.Png);
        }

        /// <summary>
        /// Gets the center-most screen
        /// </summary>
        /// <returns>The center-most screen</returns>
        public static ScreenId GetMiddleScreen()
        {
            return (Screen.AllScreens.Length == 1) ? ScreenId.First : (Screen.AllScreens.Length == 5) ? ScreenId.Third : ScreenId.Second;
        }

        /// <summary>
        /// Captures the screen until the application is stopped
        /// </summary>
        private static void CaptureScreen(int uptime)
        {
            // If handler is not running, stop immediately.
            if (!Running)
                return;

            // Set the graphics object and dispose it automatically
            using (var screenshot = Graphics.FromImage(ScreenBitmap))
            {
                // Get the screen, copy it to the graphics object
                screenshot.CopyFromScreen(CurrentScreen.Bounds.X, CurrentScreen.Bounds.Y, 0, 0, CurrentScreen.Bounds.Size, CopyPixelOperation.SourceCopy);

                // Set the current screenshot
                CurrentScreenshot = ScreenBitmap;

                CurrentWindowSnap = ParseWindowFromScreenshot(CurrentScreenshot);
            }
        }

        /// <summary>
        /// Parses the bot window from the original screenshot and 
        /// </summary>
        /// <param name="screenshot"></param>
        /// <returns></returns>
        private static Bitmap ParseWindowFromScreenshot(Bitmap screenshot)
        {
            if (!Bot.IsBotActiveAndRunning())
                return screenshot.Clone(new Rectangle(0, 0, screenshot.Width, screenshot.Height), PixelFormat.Format32bppArgb);

            var point = new Point(Bot.UI.Window.Position.X + Bot.Browser.Location.X + Bot.UI.Offsets.Width, Bot.UI.Window.Position.Y + Bot.Browser.Location.Y + Bot.UI.Offsets.Height);

            return screenshot.Clone(new Rectangle(point, Bot.Browser.Size), screenshot.PixelFormat);
        }
    }
}
