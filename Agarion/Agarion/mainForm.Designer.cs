namespace Agarion
{
    partial class mainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.menustripMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolstripMain = new System.Windows.Forms.ToolStrip();
            this.lbConsole = new System.Windows.Forms.ListBox();
            this.wbBot = new System.Windows.Forms.WebBrowser();
            this.btnHideShowConsole = new System.Windows.Forms.ToolStripButton();
            this.menustripMain.SuspendLayout();
            this.toolstripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // menustripMain
            // 
            this.menustripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menustripMain.Location = new System.Drawing.Point(0, 0);
            this.menustripMain.Name = "menustripMain";
            this.menustripMain.Size = new System.Drawing.Size(1064, 24);
            this.menustripMain.TabIndex = 0;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // toolstripMain
            // 
            this.toolstripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnHideShowConsole});
            this.toolstripMain.Location = new System.Drawing.Point(0, 24);
            this.toolstripMain.Name = "toolstripMain";
            this.toolstripMain.Size = new System.Drawing.Size(1064, 25);
            this.toolstripMain.TabIndex = 1;
            // 
            // lbConsole
            // 
            this.lbConsole.BackColor = System.Drawing.Color.Black;
            this.lbConsole.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbConsole.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbConsole.ForeColor = System.Drawing.Color.White;
            this.lbConsole.FormattingEnabled = true;
            this.lbConsole.Location = new System.Drawing.Point(0, 651);
            this.lbConsole.Name = "lbConsole";
            this.lbConsole.Size = new System.Drawing.Size(1064, 143);
            this.lbConsole.TabIndex = 2;
            // 
            // wbBot
            // 
            this.wbBot.AllowNavigation = false;
            this.wbBot.AllowWebBrowserDrop = false;
            this.wbBot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbBot.IsWebBrowserContextMenuEnabled = false;
            this.wbBot.Location = new System.Drawing.Point(0, 49);
            this.wbBot.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbBot.Name = "wbBot";
            this.wbBot.ScriptErrorsSuppressed = true;
            this.wbBot.ScrollBarsEnabled = false;
            this.wbBot.Size = new System.Drawing.Size(1064, 602);
            this.wbBot.TabIndex = 3;
            this.wbBot.Url = new System.Uri("http://agar.io/", System.UriKind.Absolute);
            // 
            // btnHideShowConsole
            // 
            this.btnHideShowConsole.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnHideShowConsole.Image = ((System.Drawing.Image)(resources.GetObject("btnHideShowConsole.Image")));
            this.btnHideShowConsole.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnHideShowConsole.Name = "btnHideShowConsole";
            this.btnHideShowConsole.Size = new System.Drawing.Size(23, 22);
            this.btnHideShowConsole.Text = "Hide Console";
            this.btnHideShowConsole.Click += new System.EventHandler(this.btnHideShowConsole_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 794);
            this.Controls.Add(this.wbBot);
            this.Controls.Add(this.lbConsole);
            this.Controls.Add(this.toolstripMain);
            this.Controls.Add(this.menustripMain);
            this.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menustripMain;
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agarion";
            this.menustripMain.ResumeLayout(false);
            this.menustripMain.PerformLayout();
            this.toolstripMain.ResumeLayout(false);
            this.toolstripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menustripMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolstripMain;
        private System.Windows.Forms.ListBox lbConsole;
        private System.Windows.Forms.WebBrowser wbBot;
        private System.Windows.Forms.ToolStripButton btnHideShowConsole;
    }
}

