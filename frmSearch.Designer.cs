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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearch));
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
            this.cmbTags = new System.Windows.Forms.ComboBox();
            this.linkAddIndex = new System.Windows.Forms.LinkLabel();
            this.cb_english = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Arabic Typesetting", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.ForeColor = System.Drawing.Color.Crimson;
            this.txtSearch.Location = new System.Drawing.Point(10, 71);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(346, 38);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(362, 71);
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
            this.linkSurah.Location = new System.Drawing.Point(476, 79);
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
            this.linkTags.Location = new System.Drawing.Point(590, 78);
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
            this.labelInfo.Location = new System.Drawing.Point(705, 78);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(0, 31);
            this.labelInfo.TabIndex = 17;
            // 
            // linkFixBangla
            // 
            this.linkFixBangla.AutoSize = true;
            this.linkFixBangla.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkFixBangla.Location = new System.Drawing.Point(476, 51);
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
            this.txtAyats.Location = new System.Drawing.Point(8, 116);
            this.txtAyats.Name = "txtAyats";
            this.txtAyats.ReadOnly = true;
            this.txtAyats.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtAyats.Size = new System.Drawing.Size(1148, 351);
            this.txtAyats.TabIndex = 19;
            this.txtAyats.Text = "";
            this.txtAyats.MouseUp += new System.Windows.Forms.MouseEventHandler(this.txtAyats_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.OrangeRed;
            this.label1.Location = new System.Drawing.Point(8, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(429, 16);
            this.label1.TabIndex = 20;
            this.label1.Text = "Search with Arabic, Bangla, English or [SurahID:StartAyatID-EndAyatID]";
            // 
            // cb_Arabic
            // 
            this.cb_Arabic.AutoSize = true;
            this.cb_Arabic.Checked = true;
            this.cb_Arabic.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_Arabic.Location = new System.Drawing.Point(585, 54);
            this.cb_Arabic.Name = "cb_Arabic";
            this.cb_Arabic.Size = new System.Drawing.Size(56, 17);
            this.cb_Arabic.TabIndex = 21;
            this.cb_Arabic.Text = "Arabic";
            this.cb_Arabic.UseVisualStyleBackColor = true;
            this.cb_Arabic.CheckedChanged += new System.EventHandler(this.cb_Arabic_CheckedChanged);
            // 
            // cb_Bangla
            // 
            this.cb_Bangla.AutoSize = true;
            this.cb_Bangla.Checked = true;
            this.cb_Bangla.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_Bangla.Location = new System.Drawing.Point(643, 55);
            this.cb_Bangla.Name = "cb_Bangla";
            this.cb_Bangla.Size = new System.Drawing.Size(59, 17);
            this.cb_Bangla.TabIndex = 22;
            this.cb_Bangla.Text = "Bangla";
            this.cb_Bangla.UseVisualStyleBackColor = true;
            this.cb_Bangla.CheckedChanged += new System.EventHandler(this.cb_Bangla_CheckedChanged);
            // 
            // linkCopyShare
            // 
            this.linkCopyShare.AutoSize = true;
            this.linkCopyShare.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkCopyShare.Location = new System.Drawing.Point(475, 16);
            this.linkCopyShare.Name = "linkCopyShare";
            this.linkCopyShare.Size = new System.Drawing.Size(43, 18);
            this.linkCopyShare.TabIndex = 23;
            this.linkCopyShare.TabStop = true;
            this.linkCopyShare.Text = "Copy";
            this.linkCopyShare.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkCopyShare_LinkClicked);
            // 
            // cmbTags
            // 
            this.cmbTags.DisplayMember = "tag_bangla";
            this.cmbTags.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTags.Font = new System.Drawing.Font("Arabic Typesetting", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTags.FormattingEnabled = true;
            this.cmbTags.Location = new System.Drawing.Point(591, 10);
            this.cmbTags.MaxDropDownItems = 10;
            this.cmbTags.Name = "cmbTags";
            this.cmbTags.Size = new System.Drawing.Size(275, 31);
            this.cmbTags.TabIndex = 24;
            this.cmbTags.ValueMember = "tag_id";
            this.cmbTags.Visible = false;
            // 
            // linkAddIndex
            // 
            this.linkAddIndex.AutoSize = true;
            this.linkAddIndex.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkAddIndex.Location = new System.Drawing.Point(872, 16);
            this.linkAddIndex.Name = "linkAddIndex";
            this.linkAddIndex.Size = new System.Drawing.Size(130, 18);
            this.linkAddIndex.TabIndex = 25;
            this.linkAddIndex.TabStop = true;
            this.linkAddIndex.Text = "Tag Search Result";
            this.linkAddIndex.Visible = false;
            this.linkAddIndex.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkAddIndex_LinkClicked);
            // 
            // cb_english
            // 
            this.cb_english.AutoSize = true;
            this.cb_english.Checked = true;
            this.cb_english.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_english.Location = new System.Drawing.Point(703, 55);
            this.cb_english.Name = "cb_english";
            this.cb_english.Size = new System.Drawing.Size(60, 17);
            this.cb_english.TabIndex = 26;
            this.cb_english.Text = "English";
            this.cb_english.UseVisualStyleBackColor = true;
            this.cb_english.CheckedChanged += new System.EventHandler(this.cb_english_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.OrangeRed;
            this.label2.Location = new System.Drawing.Point(11, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Ex: 1:1-2 3:1-2 4:6-9";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.OrangeRed;
            this.label3.Location = new System.Drawing.Point(120, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 16);
            this.label3.TabIndex = 28;
            this.label3.Text = "Ex: parents";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Vrinda", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.OrangeRed;
            this.label4.Location = new System.Drawing.Point(200, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 17);
            this.label4.TabIndex = 29;
            this.label4.Text = "Ex: পিতামাতা";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arabic Typesetting", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.OrangeRed;
            this.label5.Location = new System.Drawing.Point(279, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 23);
            this.label5.TabIndex = 30;
            this.label5.Text = "Ex: عَدُوٌّ مُّبِينٌ ";
            // 
            // frmSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1168, 479);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cb_english);
            this.Controls.Add(this.linkAddIndex);
            this.Controls.Add(this.cmbTags);
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1184, 517);
            this.Name = "frmSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quran -- Searchable in Arabic, Bangla & English";
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
        private System.Windows.Forms.ComboBox cmbTags;
        private System.Windows.Forms.LinkLabel linkAddIndex;
        private System.Windows.Forms.CheckBox cb_english;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}