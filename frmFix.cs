using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Bangla_text_mysql
{
    public partial class frmFix : Form
    {
        public frmFix()
        {
            InitializeComponent();
        }

        private void btnFix_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchWith.Text) || string.IsNullOrEmpty(txtFixWith.Text))
                return;

            DialogResult dialogResult = MessageBox.Show("Are sure you want to update?", "Update", MessageBoxButtons.YesNoCancel);
            
            if (dialogResult == DialogResult.Yes)
            {
                AutoFixVowelDisplacement f = new AutoFixVowelDisplacement();
                int res = f.Fix(txtSearchWith.Text, txtFixWith.Text);
                MessageBox.Show("Successfully Replaced: "+res+" ayats");
            }
            
        }
    }
}
