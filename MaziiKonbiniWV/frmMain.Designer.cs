
namespace MaziiKonbiniWV
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.wvMain = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.stMain = new System.Windows.Forms.StatusStrip();
            this.tsDropDownButtonOption = new System.Windows.Forms.ToolStripDropDownButton();
            this.startWithWindowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pbMain = new System.Windows.Forms.PictureBox();
            this.temporarilyDisableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.wvMain)).BeginInit();
            this.stMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMain)).BeginInit();
            this.SuspendLayout();
            // 
            // wvMain
            // 
            this.wvMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wvMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.wvMain.CreationProperties = null;
            this.wvMain.DefaultBackgroundColor = System.Drawing.Color.White;
            this.wvMain.Location = new System.Drawing.Point(0, 0);
            this.wvMain.Name = "wvMain";
            this.wvMain.Size = new System.Drawing.Size(377, 463);
            this.wvMain.Source = new System.Uri("https://mazii.net/", System.UriKind.Absolute);
            this.wvMain.TabIndex = 0;
            this.wvMain.ZoomFactor = 1D;
            this.wvMain.NavigationCompleted += new System.EventHandler<Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs>(this.wvMain_NavigationCompleted);
            // 
            // stMain
            // 
            this.stMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.stMain.AutoSize = false;
            this.stMain.Dock = System.Windows.Forms.DockStyle.None;
            this.stMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsDropDownButtonOption});
            this.stMain.Location = new System.Drawing.Point(0, 467);
            this.stMain.Name = "stMain";
            this.stMain.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.stMain.Size = new System.Drawing.Size(377, 22);
            this.stMain.SizingGrip = false;
            this.stMain.TabIndex = 1;
            this.stMain.Text = "statusStrip1";
            // 
            // tsDropDownButtonOption
            // 
            this.tsDropDownButtonOption.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsDropDownButtonOption.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startWithWindowsToolStripMenuItem,
            this.temporarilyDisableToolStripMenuItem});
            this.tsDropDownButtonOption.Image = ((System.Drawing.Image)(resources.GetObject("tsDropDownButtonOption.Image")));
            this.tsDropDownButtonOption.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsDropDownButtonOption.Name = "tsDropDownButtonOption";
            this.tsDropDownButtonOption.Size = new System.Drawing.Size(62, 20);
            this.tsDropDownButtonOption.Text = "Options";
            // 
            // startWithWindowsToolStripMenuItem
            // 
            this.startWithWindowsToolStripMenuItem.CheckOnClick = true;
            this.startWithWindowsToolStripMenuItem.Name = "startWithWindowsToolStripMenuItem";
            this.startWithWindowsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.startWithWindowsToolStripMenuItem.Text = "Start with Windows";
            this.startWithWindowsToolStripMenuItem.Click += new System.EventHandler(this.startWithWindowsToolStripMenuItem_Click);
            // 
            // pbMain
            // 
            this.pbMain.Image = global::MaziiKonbiniWV.Properties.Resources.ajax_loader_drop;
            this.pbMain.Location = new System.Drawing.Point(174, 216);
            this.pbMain.Name = "pbMain";
            this.pbMain.Size = new System.Drawing.Size(42, 42);
            this.pbMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbMain.TabIndex = 2;
            this.pbMain.TabStop = false;
            this.pbMain.Visible = false;
            // 
            // temporarilyDisableToolStripMenuItem
            // 
            this.temporarilyDisableToolStripMenuItem.CheckOnClick = true;
            this.temporarilyDisableToolStripMenuItem.Name = "temporarilyDisableToolStripMenuItem";
            this.temporarilyDisableToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.temporarilyDisableToolStripMenuItem.Text = "Temporarily disable";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 489);
            this.Controls.Add(this.pbMain);
            this.Controls.Add(this.stMain);
            this.Controls.Add(this.wvMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "Mazii Konbini";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.wvMain)).EndInit();
            this.stMain.ResumeLayout(false);
            this.stMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 wvMain;
        private System.Windows.Forms.StatusStrip stMain;
        private System.Windows.Forms.ToolStripDropDownButton tsDropDownButtonOption;
        private System.Windows.Forms.ToolStripMenuItem startWithWindowsToolStripMenuItem;
        private System.Windows.Forms.PictureBox pbMain;
        private System.Windows.Forms.ToolStripMenuItem temporarilyDisableToolStripMenuItem;
    }
}

