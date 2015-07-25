using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Agarion.IO;
using Agarion.IO.ThreadingTools;

namespace Agarion
{
    /// <summary>
    /// The main form - handles the UI, web browser, et cetera.
    /// </summary>
    public partial class mainForm : Form
    {
        /// <summary>
        /// Initializes the main form
        /// </summary>
        public mainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The click event of hide/show console button.
        /// Hides or shows the console.
        /// </summary>
        /// <param name="sender">The object that sent the event</param>
        /// <param name="e">The event arguments</param>
        private void btnHideShowConsole_Click(object sender, EventArgs e)
        {
            this.lbConsole.Visible = !this.lbConsole.Visible;
            this.btnHideShowConsole.Text = (this.lbConsole.Visible) ? "Hide Console" : "Show Console";
        }

        /// <summary>
        /// An event that fires after the form has loaded
        /// </summary>
        /// <param name="sender">The sending object - which would be the form</param>
        /// <param name="e">The event arguments</param>
        private void mainForm_Load(object sender, EventArgs e)
        {
            Bot.Initialize(this.wbBot, this.lbConsole);

            AsyncHelper.ExecuteUpdatingMethod(this.Update, Bot.IsBotActiveAndRunning, true, 10);
        }

        public void Update(int uptime)
        {
            Bot.CurrentWindowPosition = this.DesktopLocation;
            Bot.CurrentWindowSize = this.Size;
            Bot.Browser = this.wbBot;

            Invoke(new MethodInvoker(() =>
            {
                Bot.TitlebarHeight = RectangleToScreen(this.ClientRectangle).Top - this.Top;
                Bot.BorderWidth = RectangleToScreen(this.ClientRectangle).Left - this.Left;
            }));
        }
    }
}
