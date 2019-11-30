using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Bangla_text_mysql.CustomControl;
using Bangla_text_mysql.Core;

namespace Bangla_text_mysql
{
    public partial class frmTest : Form
    {
        public frmTest()
        {
            InitializeComponent();
        }



        public string ConvertUnicodeForRTF(string rtfUnicode)
        {
            // Regular expression to match non-ascii characters
            Regex regNonAscii = new Regex(@"[^\x00-\x7F]");

            MatchCollection mc = regNonAscii.Matches(rtfUnicode);
            Match foundMatch;
            string insert;
            if (mc.Count == 0)
            {
                return rtfUnicode;
            }
            for (int i = mc.Count - 1; i > -1; i--)
            {
                //start with last match
                foundMatch = mc[i];
                char c = foundMatch.Value[0];
                //remove unicode character
                int dec = Convert.ToInt32(c);
                rtfUnicode = rtfUnicode.Remove(foundMatch.Index, 1);
                insert = @"\u" + dec.ToString() + "?";
                rtfUnicode = rtfUnicode.Insert(foundMatch.Index, insert);
            }
            return rtfUnicode;
        }

        private void frmTest_Load(object sender, EventArgs e)
        {
            //string banglaText = "শুরু করছি আল্লাহর নামে যিনি পরম করুণাময়, অতি দয়া." + Environment.NewLine;
            /*string banglaText = "১১০. সুরাহ ন’সর    ১. যখন আসবে আল্লাহর সাহায্য ও বিজয়     ২. এবং আপনি মানুষকে দলে দলে আল্লাহর দ্বীনে প্রবেশ করতে দেখবেন,     ৩. তখন আপনি আপনার পালনকর্তার পবিত্রতা বর্ণনা করুন এবং তাঁর কাছে ক্ষমা প্রার্থনা করুন।";
            string arabicText = "اللغة العربية" + Environment.NewLine;

            MultilingualTextBox mtb = new MultilingualTextBox(this.richTextBox1);
            mtb.AddBanglaText(banglaText);
            mtb.AddArabicText(arabicText);
            mtb.AddBanglaText(banglaText);
            mtb.AddArabicText(arabicText);
            mtb.AddArabicText(arabicText);
            mtb.AddArabicText(arabicText);
            mtb.AddArabicText(arabicText);
            mtb.AddArabicText(arabicText);
            mtb.AddArabicText(arabicText);
             */

            /*richTextBox1.BackColor = Color.White;
            richTextBox1.Clear();
            richTextBox1.BulletIndent = 10;
            richTextBox1.SelectionFont = new Font("Georgia", 16, FontStyle.Bold);
            richTextBox1.SelectedText = "Mindcracker Network \n";
            richTextBox1.SelectionFont = new Font("Verdana", 12);
            richTextBox1.SelectionBullet = true;
            richTextBox1.SelectionColor = Color.DarkBlue;
            richTextBox1.SelectedText = "C# Corner" + "\n";
            richTextBox1.SelectionFont = new Font("Verdana", 12);
            richTextBox1.SelectionColor = Color.Orange;
            richTextBox1.SelectedText = "VB.NET Heaven" + "\n";
            richTextBox1.SelectionFont = new Font("Verdana", 12);
            richTextBox1.SelectionColor = Color.Green;
            richTextBox1.SelectedText = ".Longhorn Corner" + "\n";
            richTextBox1.SelectionColor = Color.Red;
            richTextBox1.SelectedText = ".NET Heaven" + "\n";
            richTextBox1.SelectionBullet = false;
            richTextBox1.SelectionFont = new Font("Tahoma", 10);
            richTextBox1.SelectionColor = Color.Black;
            richTextBox1.SelectedText = "This is a list of Mindcracker Network websites.\n";
            */

            MultilingualTextBox mtb = new MultilingualTextBox(this.richTextBox1);
            frmSearch f = new frmSearch();
            f.surahList = f.LoadSurahList();

            List<OneSurah> surahs = f.SearchAyatByText(string.Empty, 67);

            for (int i = 0; i < surahs[0].AyatList.Count; i++)
            {
                var ayat = surahs[0].AyatList[i];
                mtb.AddArabicText(ayat.Ayat_Arabic + Environment.NewLine);
                mtb.AddArabicText(" (" + Utility.ToConvertArabicNumber(ayat.AyatID) + ") " + Environment.NewLine);
                mtb.AddBanglaText(Utility.ToConvertBanglaNumber(ayat.AyatID) + " ");
                mtb.AddBanglaText(ayat.Ayat + Environment.NewLine);
                
            }
            richTextBox1.Select(0, 0);

            //richTextBox1.SaveFile(@"C:\Users\BrotherJhon\Desktop\SavedRTF.rtf", RichTextBoxStreamType.RichText);
        }

        private void button1_Click(object sender, EventArgs e)
        {


        }
    }
}
