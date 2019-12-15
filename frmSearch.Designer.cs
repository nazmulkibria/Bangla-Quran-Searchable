namespace Bangla_text_mysql
{
    partial class frmSearch
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
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.linkSurah = new System.Windows.Forms.LinkLabel();
            this.linkTags = new System.Windows.Forms.LinkLabel();
            this.labelInfo = new System.Windows.Forms.Label();
            this.linkFixBangla = new System.Windows.Forms.LinkLabel();
            this.txtAyats = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_Arabic = new System.Windows.Forms.CheckBox();
            this.cb_Bangla = new System.Windows.Forms.CheckBox();
            this.linkCopyShare = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Arabic Typesetting", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.ForeColor = System.Drawing.Color.Crimson;
            this.txtSearch.Location = new System.Drawing.Point(12, 29);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(346, 38);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(364, 29);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(107, 38);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // linkSurah
            // 
            this.linkSurah.AutoSize = true;
            this.linkSurah.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkSurah.Location = new System.Drawing.Point(478, 37);
            this.linkSurah.Name = "linkSurah";
            this.linkSurah.Size = new System.Drawing.Size(107, 24);
            this.linkSurah.TabIndex = 14;
            this.linkSurah.TabStop = true;
            this.linkSurah.Text = "Load Surah";
            this.linkSurah.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkSurah_LinkClicked);
            // 
            // linkTags
            // 
            this.linkTags.AutoSize = true;
            this.linkTags.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkTags.Location = new System.Drawing.Point(592, 36);
            this.linkTags.Name = "linkTags";
            this.linkTags.Size = new System.Drawing.Size(99, 24);
            this.linkTags.TabIndex = 16;
            this.linkTags.TabStop = true;
            this.linkTags.Text = "Load Tags";
            this.linkTags.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkTags_LinkClicked);
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Font = new System.Drawing.Font("Arabic Typesetting", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInfo.ForeColor = System.Drawing.Color.Goldenrod;
            this.labelInfo.Location = new System.Drawing.Point(819, 36);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(0, 31);
            this.labelInfo.TabIndex = 17;
            // 
            // linkFixBangla
            // 
            this.linkFixBangla.AutoSize = true;
            this.linkFixBangla.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkFixBangla.Location = new System.Drawing.Point(478, 9);
            this.linkFixBangla.Name = "linkFixBangla";
            this.linkFixBangla.Size = new System.Drawing.Size(92, 20);
            this.linkFixBangla.TabIndex = 18;
            this.linkFixBangla.TabStop = true;
            this.linkFixBangla.Text = "Fix Bangla?";
            this.linkFixBangla.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkFixBangla_LinkClicked);
            // 
            // txtAyats
            // 
            this.txtAyats.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAyats.BackColor = System.Drawing.Color.White;
            this.txtAyats.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAyats.Location = new System.Drawing.Point(8, 73);
            this.txtAyats.Name = "txtAyats";
            this.txtAyats.ReadOnly = true;
            this.txtAyats.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtAyats.Size = new System.Drawing.Size(1148, 394);
            this.txtAyats.TabIndex = 19;
            this.txtAyats.Text = "";
            this.txtAyats.MouseUp += new System.Windows.Forms.MouseEventHandler(this.txtAyats_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.OrangeRed;
            this.label1.Location = new System.Drawing.Point(13, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(379, 16);
            this.label1.TabIndex = 20;
            this.label1.Text = "Search with Bangla, Arabic or [SurahID:StartAyatID-EndAyatID]";
            // 
            // cb_Arabic
            // 
            this.cb_Arabic.AutoSize = true;
            this.cb_Arabic.Checked = true;
            this.cb_Arabic.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_Arabic.Location = new System.Drawing.Point(587, 12);
            this.cb_Arabic.Name = "cb_Arabic";
            this.cb_Arabic.Size = new System.Drawing.Size(110, 17);
            this.cb_Arabic.TabIndex = 21;
            this.cb_Arabic.Text = "Show Only Arabic";
            this.cb_Arabic.UseVisualStyleBackColor = true;
            this.cb_Arabic.CheckedChanged += new System.EventHandler(this.cb_Arabic_CheckedChanged);
            // 
            // cb_Bangla
            // 
            this.cb_Bangla.AutoSize = true;
            this.cb_Bangla.Checked = true;
            this.cb_Bangla.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_Bangla.Location = new System.Drawing.Point(700, 13);
            this.cb_Bangla.Name = "cb_Bangla";
            this.cb_Bangla.Size = new System.Drawing.Size(113, 17);
            this.cb_Bangla.TabIndex = 22;
            this.cb_Bangla.Text = "Show Only Bangla";
            this.cb_Bangla.UseVisualStyleBackColor = true;
            this.cb_Bangla.CheckedChanged += new System.EventHandler(this.cb_Bangla_CheckedChanged);
            // 
            // linkCopyShare
            // 
            this.linkCopyShare.AutoSize = true;
            this.linkCopyShare.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkCopyShare.Location = new System.Drawing.Point(823, 11);
            this.linkCopyShare.Name = "linkCopyShare";
            this.linkCopyShare.Size = new System.Drawing.Size(108, 18);
            this.linkCopyShare.TabIndex = 23;
            this.linkCopyShare.TabStop = true;
            this.linkCopyShare.Text = "Copy To Share";
            this.linkCopyShare.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkCopyShare_LinkClicked);
            // 
            // frmSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1168, 479);
            this.Controls.Add(this.linkCopyShare);
            this.Controls.Add(this.cb_Bangla);
            this.Controls.Add(this.cb_Arabic);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtAyats);
            this.Controls.Add(this.linkFixBangla);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.linkTags);
            this.Controls.Add(this.linkSurah);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "frmSearch";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSearch";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmSearch_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.LinkLabel linkSurah;
        private System.Windows.Forms.LinkLabel linkTags;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.LinkLabel linkFixBangla;
        private System.Windows.Forms.RichTextBox txtAyats;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cb_Arabic;
        private System.Windows.Forms.CheckBox cb_Bangla;
        private System.Windows.Forms.LinkLabel linkCopyShare;
    }
}