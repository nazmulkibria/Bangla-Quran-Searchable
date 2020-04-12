using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

#if DB_MYSQL
using MySql.Data.MySqlClient;
#else
using System.Data.SQLite;
#endif

using System.Runtime.InteropServices;
using Bangla_text_mysql.Core;
using Bangla_text_mysql.CustomControl;
using System.IO;

namespace Bangla_text_mysql
{
    public partial class frmSearch : Form
    {
        private const int EM_GETLINECOUNT = 0xba;
        [DllImport("user32", EntryPoint = "SendMessageA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern int SendMessage(int hwnd, int wMsg, int wParam, int lParam);

        MultilingualTextBox mtb = null;

        private List<OneSurah> cache_surahs = null;

        
        private OneSurah Fatiha = null;

        public frmSearch()
        {
            InitializeComponent();
        }

        

        public List<OneSurah> SearchTagID(int tagId)
        {
            List<OneSurah> surahs = new List<OneSurah>();

            if (tagId == -1)
                return surahs;

            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "banglatest";

            if (dbCon.IsConnect())
            {
                string query = "";

#if DB_MYSQL
                var cmd = new MySqlCommand(query, dbCon.Connection);
#else
                var cmd = new SQLiteCommand(query, dbCon.Connection);
#endif
                //SetUTF8Mode(cmd);

                query = "SELECT T.`surah_id` , T.`ayat_id` , T.`ayat`, T.`ayat_arabic`, T.`ayat_sahih_en` FROM texts T INNER JOIN  `ayah_indexing` I ON I.`tag_id` = " + tagId + " AND I.`surah_id` = T.`surah_id` AND I.`ayat_id` = T.`ayat_id` ORDER BY  `T`.`surah_id` , T.`ayat_id`";

                cmd.CommandText = query;
                var reader = cmd.ExecuteReader();

                int lastSurah = -1;
                while (reader.Read())
                {
                    int surah_id = reader.GetInt32(0);
                    int ayat_id = reader.GetInt32(1);

                    string ayat = reader.GetString(2);
                    string ayat_arabic = reader.GetString(3);
                    string ayat_en = reader.GetString(4);

                    if (lastSurah != surah_id)
                    {
                        OneSurah one = new OneSurah() { SurahName = DBUtility.surahList[surah_id - 1], SurahID = surah_id };
                        surahs.Add(one);
                    }

                    surahs[surahs.Count - 1].AyatList.Add(new OneAyat() { Ayat = ayat, Ayat_Arabic = ayat_arabic, AyatID = ayat_id, Ayat_En = ayat_en });

                    lastSurah = surah_id;
                }

                reader.Close();
            }

            return surahs;
        }

        private string GetSurahHeader(OneSurah oneSurah, bool isFirst)
        {
            string tt = string.Empty;

            if (!isFirst)
                tt += Environment.NewLine;

            tt += oneSurah.SurahName + Environment.NewLine;

            return tt;
        }

        private string AddBismillah(OneSurah oneSurah)
        {
            if (oneSurah.SurahID != 9 && oneSurah.AyatList.Count > 1 && oneSurah.AyatList[0].AyatID == 1)
                return Fatiha.AyatList[0].Ayat_Arabic + Environment.NewLine;

            return "";
        }

        private void bindAyatsFlowPanel(ref List<OneSurah> surahs)
        {
            mtb.ClearText();

            for (int j = 0; j < surahs.Count; j++)
            {
                mtb.AddBanglaHeaderText(GetSurahHeader(surahs[j], j == 0));
                string Bismillah = AddBismillah(surahs[j]);

                if (Bismillah != string.Empty)
                    mtb.AddArabicHeaderText(Bismillah);

                for (int i = 0; i < surahs[j].AyatList.Count; i++)
                {
                    var ayat = surahs[j].AyatList[i];

                    if (cb_Arabic.Checked)
                    {
                        //mtb.AddSpecialText(Utility.ToConvertArabicNumber(surahs[j].SurahID) + ":" + Utility.ToConvertArabicNumber(ayat.AyatID) + Environment.NewLine, true);
                        string ayatArabic = ayat.Ayat_Arabic + " \u06DD" + Utility.ToConvertArabicNumber(ayat.AyatID);
                        //mtb.AddArabicText(ayatArabic);
                        //if (cb_Bangla.Checked)
                        mtb.AddArabicText(ayatArabic + Environment.NewLine);
                        //else
                        //  mtb.AddArabicText(ayatArabic);
                    }

                    //if (cb_Arabic.Checked && cb_Bangla.Checked)
                    //  mtb.AddSpecialText(Environment.NewLine);

                    if (cb_Bangla.Checked)
                    {
                        //mtb.AddSpecialText(Utility.ToConvertBanglaNumber(surahs[j].SurahID) + ":" + Utility.ToConvertBanglaNumber(ayat.AyatID) + Environment.NewLine);
                        string ayatBangla = Utility.ToConvertBanglaNumber(ayat.AyatID) + ") " + ayat.Ayat;
                        mtb.AddBanglaText(ayatBangla + Environment.NewLine);
                    }

                    if (cb_english.Checked)
                    {
                        string ayatEnglish = ayat.AyatID + ") " + ayat.Ayat_En;
                        mtb.AddBanglaText(ayatEnglish + Environment.NewLine);
                    }
                    //mtb.AddSpecialText("______________________________________________________________________________________________" + Environment.NewLine);

                }
            }
            txtAyats.Select(0, 0);

        }

        private int GetSearchItemCount(ref List<OneSurah> surahs)
        {
            int count = 0;

            for (int i = 0; i < surahs.Count; i++)
            {
                count += surahs[i].AyatList.Count;
            }

            return count;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search(txtSearch.Text);
        }

        private void SearchByText(string searchKey)
        {
            txtSearch.Text = searchKey;
            txtSearch.Update();
            btnSearch.PerformClick();
        }

        private void Search(string search)
        {

            if (string.IsNullOrEmpty(search))
                return;

            labelInfo.Text = "Searching with: " + search + " ......";

            labelInfo.Update();

            List<OneSurah> surahs = DBUtility.SearchAyatByText(search);

            cache_surahs = surahs;

            bindAyatsFlowPanel(ref surahs);

            Utility.HighlightText(txtAyats, search, Color.Black);

            int ayat_count = GetSearchItemCount(ref surahs);
            labelInfo.Text = ayat_count + " Ayats found with: [" + search + "]";

            if (ayat_count > 0)
            {
                ShowTagsForIndexing();
            }
            else
            {
                cmbTags.Visible = linkAddIndex.Visible = false;
            }
        }

        private void ShowTagsForIndexing()
        {
            var binding = new BindingSource();
            binding.DataSource = DB_tag_processor.GetTags();
            cmbTags.DataSource = binding.DataSource;
            cmbTags.Visible = linkAddIndex.Visible = true;
        }

        private void frmSearch_Load(object sender, EventArgs e)
        {
            DBUtility.surahList = DBUtility.LoadSurahList();
            DBUtility.surahMaxAyatList = DBUtility.GetSurahMaxAyatList();
            Fatiha = DBUtility.GetFullSurah(1, DBUtility.surahList[0]);
            mtb = new MultilingualTextBox(this.txtAyats);
            mtb.SearchWithText = SearchByText;
        }



        private const int WM_NCLBUTTONDBLCLK = 0x00A3; //double click on a title bar a.k.a. non-client area of the form

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_NCLBUTTONDBLCLK)
            {
                m.Result = IntPtr.Zero;
                return;
            }
            base.WndProc(ref m);
        }

        private void linkSurah_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            frmSurahList f = new frmSurahList();
            f.SelectedSurahId = 1;

            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                if (f.SelectedSurahId >= 1 && f.SelectedSurahId <= 114)
                {
                    LoadSpecificSurah(f.SelectedSurahString, f.SelectedSurahId);
                }
            }
        }

        private void LoadSpecificSurah(string SurahName, int SurahId)
        {
            txtSearch.Clear();

            labelInfo.Text = "Loading full surah: " + SurahName + " .....";

            labelInfo.Update();

            List<OneSurah> surahs = DBUtility.SearchAyatByText(string.Empty, SurahId);
            cache_surahs = surahs;

            bindAyatsFlowPanel(ref surahs);

            labelInfo.Text = "Total Ayats: " + GetSearchItemCount(ref surahs);
        }

        private void linkTags_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmTagList f = new frmTagList();
            if (f.ShowDialog() == DialogResult.OK)
            {

                if (f.SelectedTagId >= 1)
                {

                    LoadATag(f.SelectedTagString, f.SelectedTagId);
                }
            }
        }

        private void LoadATag(string TagName, int TagId)
        {
            txtSearch.Clear();

            labelInfo.Text = "Loading with tag: " + TagName + " .....";
            labelInfo.Update();

            List<OneSurah> surahs = SearchTagID(TagId);
            cache_surahs = surahs;

            bindAyatsFlowPanel(ref surahs);

            labelInfo.Text = GetSearchItemCount(ref surahs) + " Ayats found with tag: " + TagName + "";
        }

        private void linkFixBangla_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmFix f = new frmFix();
            f.ShowDialog();
        }

        private void linkJumpTo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void cb_Arabic_CheckedChanged(object sender, EventArgs e)
        {
            if (cache_surahs != null)
            {
                bindAyatsFlowPanel(ref cache_surahs);
                Utility.HighlightText(txtAyats, txtSearch.Text, Color.Black);
            }
        }

        private void cb_Bangla_CheckedChanged(object sender, EventArgs e)
        {
            if (cache_surahs != null)
            {
                bindAyatsFlowPanel(ref cache_surahs);
                Utility.HighlightText(txtAyats, txtSearch.Text, Color.Black);
            }
        }

        private void cb_english_CheckedChanged(object sender, EventArgs e)
        {
            if (cache_surahs != null)
            {
                bindAyatsFlowPanel(ref cache_surahs);
                Utility.HighlightText(txtAyats, txtSearch.Text, Color.Black);
            }
        }

        private void txtAyats_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                mtb.AddContextMenu();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text == string.Empty)
            {
                if (cache_surahs != null)
                    cache_surahs.Clear();

                labelInfo.Text = string.Empty;
                mtb.ClearText();
                cmbTags.Visible = linkAddIndex.Visible = false;

            }
        }

        private void linkCopyShare_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string str = mtb.GetText().Trim();

            if (!str.Equals(string.Empty))
                Clipboard.SetText(str);
        }

        private void linkAddIndex_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (cmbTags.SelectedItem == null) return;

            var tag = (cmbTags.SelectedItem as Tag);

            if (cache_surahs != null && cache_surahs.Count > 0)
            {
                if (MessageBox.Show("Do you want all the Ayat Al Kareemas of search result to tag under this tag: " + tag.tag_bangla + " ?", "Please confirm...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    DB_tag_processor.InsertAyatIndex(cache_surahs, tag);
                    MessageBox.Show("Added/Updated Ayat-Al-Kareemas under this tag:" + tag.tag_bangla, "Successful...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnSearch.PerformClick();
            }
        }

       



    }
}
