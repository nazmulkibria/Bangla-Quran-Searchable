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
            this.SuspendLayout();
            // 
            // txtSearchKey
            // 
            this.txtSearchKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchKey.Location = new System.Drawing.Point(8, 35);
            this.txtSearchKey.Name = "txtSearchKey";
            this.txtSearchKey.Size = new System.Drawing.Size(264, 29);
            this.txtSearchKey.TabIndex = 0;
            // 
            // txtTagID
            // 
            this.txtTagID.Location = new System.Drawing.Point(8, 9);
            this.txtTagID.Name = "txtTagID";
            this.txtTagID.Size = new System.Drawing.Size(264, 20);
            this.txtTagID.TabIndex = 1;
            // 
            // btnSnInsert
            // 
            this.btnSnInsert.Location = new System.Drawing.Point(8, 70);
            this.btnSnInsert.Name = "btnSnInsert";
            this.btnSnInsert.Size = new System.Drawing.Size(264, 42);
            this.btnSnInsert.TabIndex = 2;
            this.btnSnInsert.Text = "Search And Insert";
            this.btnSnInsert.UseVisualStyleBackColor = true;
            this.btnSnInsert.Click += new System.EventHandler(this.btnSnInsert_Click);
            // 
            // frmAutoInsertAyatIndexing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 120);
            this.Controls.Add(this.btnSnInsert);
            this.Controls.Add(this.txtTagID);
            this.Controls.Add(this.txtSearchKey);
            this.Name = "frmAutoInsertAyatIndexing";
            this.Text = "frmAutoInsertAyatIndexing";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearchKey;
        private System.Windows.Forms.TextBox txtTagID;
        private System.Windows.Forms.Button btnSnInsert;
    }
}