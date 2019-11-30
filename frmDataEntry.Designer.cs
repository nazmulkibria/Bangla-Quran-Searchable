namespace Bangla_text_mysql
{
    partial class frmDataEntry
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
            this.txtSurahID = new System.Windows.Forms.TextBox();
            this.txtAyaatID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listTags = new System.Windows.Forms.ListBox();
            this.txtAyat = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnReload = new System.Windows.Forms.Button();
            this.lbl_surah = new System.Windows.Forms.Label();
            this.btnAddNewTag = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNewTag = new System.Windows.Forms.TextBox();
            this.linkSurah = new System.Windows.Forms.LinkLabel();
            this.linkFullSurah = new System.Windows.Forms.LinkLabel();
            this.fpTags = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // txtSurahID
            // 
            this.txtSurahID.Location = new System.Drawing.Point(73, 39);
            this.txtSurahID.Name = "txtSurahID";
            this.txtSurahID.Size = new System.Drawing.Size(163, 20);
            this.txtSurahID.TabIndex = 0;
            this.txtSurahID.TextChanged += new System.EventHandler(this.txtSurahID_TextChanged);
            // 
            // txtAyaatID
            // 
            this.txtAyaatID.Location = new System.Drawing.Point(339, 39);
            this.txtAyaatID.Name = "txtAyaatID";
            this.txtAyaatID.Size = new System.Drawing.Size(163, 20);
            this.txtAyaatID.TabIndex = 1;
            this.txtAyaatID.TextChanged += new System.EventHandler(this.txtAyaatID_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(303, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ayat";
            // 
            // listTags
            // 
            this.listTags.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listTags.FormattingEnabled = true;
            this.listTags.ItemHeight = 20;
            this.listTags.Location = new System.Drawing.Point(673, 26);
            this.listTags.Name = "listTags";
            this.listTags.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listTags.Size = new System.Drawing.Size(288, 444);
            this.listTags.TabIndex = 4;
            this.listTags.SelectedIndexChanged += new System.EventHandler(this.listTags_SelectedIndexChanged);
            // 
            // txtAyat
            // 
            this.txtAyat.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAyat.Location = new System.Drawing.Point(73, 107);
            this.txtAyat.Multiline = true;
            this.txtAyat.Name = "txtAyat";
            this.txtAyat.ReadOnly = true;
            this.txtAyat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAyat.Size = new System.Drawing.Size(546, 329);
            this.txtAyat.TabIndex = 5;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(436, 516);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(183, 44);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnReload
            // 
            this.btnReload.Location = new System.Drawing.Point(673, 516);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(288, 44);
            this.btnReload.TabIndex = 7;
            this.btnReload.Text = "Reload";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // lbl_surah
            // 
            this.lbl_surah.AutoSize = true;
            this.lbl_surah.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_surah.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbl_surah.Location = new System.Drawing.Point(77, 71);
            this.lbl_surah.Name = "lbl_surah";
            this.lbl_surah.Size = new System.Drawing.Size(0, 24);
            this.lbl_surah.TabIndex = 8;
            // 
            // btnAddNewTag
            // 
            this.btnAddNewTag.Location = new System.Drawing.Point(860, 476);
            this.btnAddNewTag.Name = "btnAddNewTag";
            this.btnAddNewTag.Size = new System.Drawing.Size(101, 34);
            this.btnAddNewTag.TabIndex = 10;
            this.btnAddNewTag.Text = "New Tag";
            this.btnAddNewTag.UseVisualStyleBackColor = true;
            this.btnAddNewTag.Click += new System.EventHandler(this.btnAddNewTag_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(673, 486);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "New Tag";
            // 
            // txtNewTag
            // 
            this.txtNewTag.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewTag.Location = new System.Drawing.Point(728, 479);
            this.txtNewTag.Name = "txtNewTag";
            this.txtNewTag.Size = new System.Drawing.Size(126, 29);
            this.txtNewTag.TabIndex = 11;
            // 
            // linkSurah
            // 
            this.linkSurah.AutoSize = true;
            this.linkSurah.Location = new System.Drawing.Point(32, 42);
            this.linkSurah.Name = "linkSurah";
            this.linkSurah.Size = new System.Drawing.Size(35, 13);
            this.linkSurah.TabIndex = 13;
            this.linkSurah.TabStop = true;
            this.linkSurah.Text = "Surah";
            this.linkSurah.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkSurah_LinkClicked);
            // 
            // linkFullSurah
            // 
            this.linkFullSurah.AutoSize = true;
            this.linkFullSurah.Location = new System.Drawing.Point(536, 88);
            this.linkFullSurah.Name = "linkFullSurah";
            this.linkFullSurah.Size = new System.Drawing.Size(80, 13);
            this.linkFullSurah.TabIndex = 14;
            this.linkFullSurah.TabStop = true;
            this.linkFullSurah.Text = "View Full Surah";
            this.linkFullSurah.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkFullSurah_LinkClicked);
            // 
            // fpTags
            // 
            this.fpTags.Location = new System.Drawing.Point(73, 443);
            this.fpTags.Name = "fpTags";
            this.fpTags.Size = new System.Drawing.Size(546, 67);
            this.fpTags.TabIndex = 15;
            // 
            // frmDataEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 569);
            this.Controls.Add(this.fpTags);
            this.Controls.Add(this.linkFullSurah);
            this.Controls.Add(this.linkSurah);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNewTag);
            this.Controls.Add(this.btnAddNewTag);
            this.Controls.Add(this.lbl_surah);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtAyat);
            this.Controls.Add(this.listTags);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAyaatID);
            this.Controls.Add(this.txtSurahID);
            this.Name = "frmDataEntry";
            this.Text = "frmDataEntry";
            this.Load += new System.EventHandler(this.frmDataEntry_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSurahID;
        private System.Windows.Forms.TextBox txtAyaatID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listTags;
        private System.Windows.Forms.TextBox txtAyat;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Label lbl_surah;
        private System.Windows.Forms.Button btnAddNewTag;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNewTag;
        private System.Windows.Forms.LinkLabel linkSurah;
        private System.Windows.Forms.LinkLabel linkFullSurah;
        private System.Windows.Forms.FlowLayoutPanel fpTags;
    }
}