namespace Bangla_text_mysql
{
    partial class frmFix
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearchWith = new System.Windows.Forms.TextBox();
            this.txtFixWith = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnFix = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search with: ";
            // 
            // txtSearchWith
            // 
            this.txtSearchWith.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchWith.Location = new System.Drawing.Point(80, 6);
            this.txtSearchWith.Name = "txtSearchWith";
            this.txtSearchWith.Size = new System.Drawing.Size(182, 29);
            this.txtSearchWith.TabIndex = 1;
            // 
            // txtFixWith
            // 
            this.txtFixWith.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFixWith.Location = new System.Drawing.Point(80, 51);
            this.txtFixWith.Name = "txtFixWith";
            this.txtFixWith.Size = new System.Drawing.Size(182, 29);
            this.txtFixWith.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fix with: ";
            // 
            // btnFix
            // 
            this.btnFix.Location = new System.Drawing.Point(80, 86);
            this.btnFix.Name = "btnFix";
            this.btnFix.Size = new System.Drawing.Size(182, 42);
            this.btnFix.TabIndex = 4;
            this.btnFix.Text = "Fix";
            this.btnFix.UseVisualStyleBackColor = true;
            this.btnFix.Click += new System.EventHandler(this.btnFix_Click);
            // 
            // frmFix
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 135);
            this.Controls.Add(this.btnFix);
            this.Controls.Add(this.txtFixWith);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSearchWith);
            this.Controls.Add(this.label1);
            this.Name = "frmFix";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fix Bangla Issue";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearchWith;
        private System.Windows.Forms.TextBox txtFixWith;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnFix;
    }
}