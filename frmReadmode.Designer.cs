namespace Bangla_text_mysql
{
    partial class frmReadmode
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
            this.pboxPage = new System.Windows.Forms.PictureBox();
            this.txtPage = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pboxPage)).BeginInit();
            this.SuspendLayout();
            // 
            // pboxPage
            // 
            this.pboxPage.BackgroundImage = global::Bangla_text_mysql.Properties.Resources.style10;
            this.pboxPage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pboxPage.Location = new System.Drawing.Point(13, 13);
            this.pboxPage.Name = "pboxPage";
            this.pboxPage.Size = new System.Drawing.Size(472, 669);
            this.pboxPage.TabIndex = 0;
            this.pboxPage.TabStop = false;
            // 
            // txtPage
            // 
            this.txtPage.BackColor = System.Drawing.SystemColors.Info;
            this.txtPage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPage.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPage.Location = new System.Drawing.Point(76, 75);
            this.txtPage.Name = "txtPage";
            this.txtPage.ReadOnly = true;
            this.txtPage.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txtPage.Size = new System.Drawing.Size(347, 551);
            this.txtPage.TabIndex = 1;
            this.txtPage.Text = "";
            // 
            // frmReadmode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 694);
            this.Controls.Add(this.txtPage);
            this.Controls.Add(this.pboxPage);
            this.Name = "frmReadmode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quran";
            this.Load += new System.EventHandler(this.frmReadmode_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pboxPage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pboxPage;
        private System.Windows.Forms.RichTextBox txtPage;
    }
}