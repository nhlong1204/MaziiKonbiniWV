
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
            ((System.ComponentModel.ISupportInitialize)(this.wvMain)).BeginInit();
            this.SuspendLayout();
            // 
            // wvMain
            // 
            this.wvMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.wvMain.CreationProperties = null;
            this.wvMain.DefaultBackgroundColor = System.Drawing.Color.White;
            this.wvMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wvMain.Location = new System.Drawing.Point(0, 0);
            this.wvMain.Name = "wvMain";
            this.wvMain.Size = new System.Drawing.Size(377, 489);
            this.wvMain.Source = new System.Uri("https://mazii.net/", System.UriKind.Absolute);
            this.wvMain.TabIndex = 0;
            this.wvMain.ZoomFactor = 1D;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 489);
            this.Controls.Add(this.wvMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "Mazii Konbini";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.wvMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 wvMain;
    }
}

