using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    }
}
