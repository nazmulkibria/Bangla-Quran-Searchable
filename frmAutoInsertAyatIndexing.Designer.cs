namespace Bangla_text_mysql
{
    partial class frmAutoInsertAyatIndexing
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
            this.txtSearchKey = new System.Windows.Forms.TextBox();
            this.txtTagID = new System.Windows.Forms.TextBox();
            this.btnSnInsert = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtSearchKey
            // 
            this.txtSearchKey.Font = new System.Drawing.Font("Arabic Typesetting", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchKey.Location = new System.Drawing.Point(113, 90);
            this.txtSearchKey.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.txtSearchKey.Name = "txtSearchKey";
            this.txtSearchKey.Size = new System.Drawing.Size(480, 38);
            this.txtSearchKey.TabIndex = 0;
            // 
            // txtTagID
            // 
            this.txtTagID.Location = new System.Drawing.Point(113, 30);
            this.txtTagID.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.txtTagID.Name = "txtTagID";
            this.txtTagID.Size = new System.Drawing.Size(480, 38);
            this.txtTagID.TabIndex = 1;
            // 
            // btnSnInsert
            // 
            this.btnSnInsert.Location = new System.Drawing.Point(113, 152);
            this.btnSnInsert.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.btnSnInsert.Name = "btnSnInsert";
            this.btnSnInsert.Size = new System.Drawing.Size(484, 60);
            this.btnSnInsert.TabIndex = 2;
            this.btnSnInsert.Text = "Search And Insert";
            this.btnSnInsert.UseVisualStyleBackColor = true;
            this.btnSnInsert.Click += new System.EventHandler(this.btnSnInsert_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 31);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tag ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-1, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 31);
            this.label2.TabIndex = 4;
            this.label2.Text = "Search With";
            // 
            // frmAutoInsertAyatIndexing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 228);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSnInsert);
            this.Controls.Add(this.txtTagID);
            this.Controls.Add(this.txtSearchKey);
            this.Font = new System.Drawing.Font("Arabic Typesetting", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "frmAutoInsertAyatIndexing";
            this.Text = "frmAutoInsertAyatIndexing";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearchKey;
        private System.Windows.Forms.TextBox txtTagID;
        private System.Windows.Forms.Button btnSnInsert;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}