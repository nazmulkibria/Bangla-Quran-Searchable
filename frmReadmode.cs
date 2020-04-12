using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Bangla_text_mysql.CustomControl;
using Bangla_text_mysql.Core;
using System.Runtime.InteropServices;

namespace Bangla_text_mysql
{
    public partial class frmReadmode : Form
    {
        MultilingualTextBox mtb = null;

        public frmReadmode()
        {
            InitializeComponent();
        }

        private void frmReadmode_Load(object sender, EventArgs e)
        {
            DBUtility.surahList = DBUtility.LoadSurahList();
            DBUtility.surahMaxAyatList = DBUtility.GetSurahMaxAyatList();
            mtb = new MultilingualTextBox(this.txtPage);
            List<OneSurah> page = DBUtility.SearchAyatByText("2:6-16");
            bindAyatsFlowPanel(ref page);
        }

        private void bindAyatsFlowPanel(ref List<OneSurah> surahs)
        {
            mtb.ClearText();

            for (int j = 0; j < surahs.Count; j++)
            {
                for (int i = 0; i < surahs[j].AyatList.Count; i++)
                {
                    var ayat = surahs[j].AyatList[i];
                    mtb.AddArabicTextForPage(ayat.Ayat_Arabic);
                    mtb.AddArabicTextForAyatNumber("\u06DD" + Utility.ToConvertArabicNumber(ayat.AyatID));
                }
            }
            txtPage.Select(0, 0);

        }
    }
}
