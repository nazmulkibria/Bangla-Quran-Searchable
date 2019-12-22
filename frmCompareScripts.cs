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
    public partial class frmCompareScripts : Form
    {
        public frmCompareScripts()
        {
            InitializeComponent();

            textBox1.Text = "قُلْ أَرَأَيْتُمْ إِنْ أَصْبَحَ مَاؤُكُمْ غَوْرًا فَمَن يَأْتِيكُم بِمَاءٍ مَّعِينٍ";
            textBox4.Text = "قُلْ أَرَءَيْتُمْ إِنْ أَصْبَحَ مَآؤُكُمْ غَوْرًا فَمَن يَأْتِيكُم بِمَآءٍ مَّعِينٍۭ";
        }



        private void btnCompare_Click(object sender, EventArgs e)
        {
            string uthmani = ArabicNormalizer.normalize(textBox1.Text);
            string indopak = ArabicNormalizer.normalize(textBox4.Text);

            //textBox2.Text = ArabicNormalizer.normalize(uthmani).Trim();
            //textBox3.Text = ArabicNormalizer.normalize(indopak).Trim();
            textBox2.Text = uthmani.Trim();
            textBox3.Text = indopak.Trim();


            string msg = string.Empty;

            foreach (char c in textBox2.Text.ToArray())
                msg += " " + c + " " + Convert.ToString(Convert.ToInt16(c));

            msg += Environment.NewLine + Environment.NewLine;

            foreach (char c in textBox3.Text.ToArray())
                msg += " " + c + " " + Convert.ToString(Convert.ToInt16(c));



            if (textBox2.Text.Equals(textBox3.Text))
                MessageBox.Show("Scripts are equal!!");
            else
                MessageBox.Show(msg);
        }
    }
}
