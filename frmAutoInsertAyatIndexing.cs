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
    public partial class frmAutoInsertAyatIndexing : Form
    {
        public frmAutoInsertAyatIndexing()
        {
            InitializeComponent();
        }

        private void btnSnInsert_Click(object sender, EventArgs e)
        {
            AutoInsertAyatOfATag a = new AutoInsertAyatOfATag();
            int total = a.StartInsertingAyatIndex(txtSearchKey.Text, Convert.ToInt32(txtTagID.Text));
            MessageBox.Show("Inserted "+total+" ayats");
        }
    }
}
