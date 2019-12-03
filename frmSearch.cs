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

        public List<string> surahList;
        private Dictionary<int, int> surahMaxAyatList;
        private OneSurah Fatiha = null;

        public frmSearch()
        {
            InitializeComponent();
        }

        public List<string> LoadSurahList()
        {
            List<string> surahList = new List<string>();

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
                query = "SELECT `surah_id`, `surah_name` FROM `surah`";
                cmd.CommandText = query;
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int surah_id = reader.GetInt32(0);
                    string surah = Utility.ToConvertBanglaNumber(surah_id) + ". " + reader.GetString(1);
                    surahList.Add(surah);
                }

                reader.Close();
            }

            return surahList;
        }

        
        public bool IsSpecialSearch(string searchKey, ref SpecialSearchParam sp)
        {
            if (searchKey.StartsWith("[") && searchKey.EndsWith("]"))
            {
                string txt = searchKey;
                txt = txt.Replace("[","");
                txt = txt.Replace("]","");

                int index = txt.IndexOf(":");
                
                if (index < 0)
                    return false;

                string surah = txt.Substring(0, index);

                txt = txt.Substring(index + 1);
                index = txt.IndexOf("-");
                
                if (index < 0)
                    return false;

                string ayat_start = txt.Substring(0, index);

                string ayat_end = txt.Substring(index + 1);

                sp.SurahID = -1;

                if (!string.IsNullOrEmpty(surah))
                {
                    int sid = -1;
                    Utility.isInteger(surah, ref sid);
                    sp.SurahID = sid;

                    if (sp.SurahID >= 1 && sp.SurahID <= 114)
                    {
                        int asid = 1;
                        Utility.isInteger(ayat_start, ref asid);
                        sp.StartAyatId = asid;
                    
                        int eid = surahMaxAyatList[sp.SurahID];
                        Utility.isInteger(ayat_end, ref eid);
                        sp.EndAyatId = eid;
                    }
                }

                return true;
            }
            
            return false;
        }

        public List<OneSurah> SearchAyatByText(string search, int loadFullSurah = -1)
        {
            DBUtility.AddEscapeChar( ref search);

            List<OneSurah> surahs = new List<OneSurah>();

            if (loadFullSurah == -1 && string.IsNullOrEmpty(search))
                return surahs;

            SpecialSearchParam sp = new SpecialSearchParam();
            bool isSpecial = IsSpecialSearch(search, ref sp);

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

                if(isSpecial)
                    query = "SELECT `surah_id`, `ayat_id`, `ayat`, `ayat_arabic` FROM `texts`  WHERE `surah_id` = " + sp.SurahID + " AND `ayat_id` >= "+sp.StartAyatId + " AND `ayat_id` <= "+sp.EndAyatId;
                else if (loadFullSurah >= 1)
                    query = "SELECT `surah_id`, `ayat_id`, `ayat`, `ayat_arabic` FROM `texts`  WHERE `surah_id` = " + loadFullSurah;
                else
                {    //query = "SELECT `surah_id`, `ayat_id`, `ayat`, `ayat_arabic` FROM `texts`  WHERE `ayat` LIKE '%" + search + "%' or `ayat_arabic` LIKE '%" + search + "%'";

                    if (Utility.IsSurahAndAyat(search))
                    {
                        var list = Utility.ParseSurahAyatSearch(search);
                        query = "SELECT `surah_id`, `ayat_id`, `ayat`, `ayat_arabic` FROM `AyatSearch`  WHERE ";

                        bool morethanone = false;

                        foreach (var item in list)
                        {
                            if (morethanone)
                                query += " OR";

                            query += " `surah_id` = " + item.SurahID;
                            
                            if (item.AyatStartID >= 0)
                                query += " AND `ayat_id` >= " + item.AyatStartID;

                            if(item.AyatEndID >=0 )
                                query += " AND `ayat_id` <= " + item.AyatEndID;

                            morethanone = true;
                        }
                    }
                    else
                        query = "SELECT `surah_id`, `ayat_id`, `ayat`, `ayat_arabic` FROM `AyatSearch`  WHERE `AyatSearch` MATCH '" + search + "*'";
                }
                cmd.CommandText = query;
                var reader = cmd.ExecuteReader();

                int lastSurah = -1;
                while (reader.Read())
                {
                    int surah_id = reader.GetInt32(0);
                    int ayat_id = reader.GetInt32(1);
                    string arabic = reader.GetString(3);
                    string ayat = reader.GetString(2);

                    if (lastSurah != surah_id)
                    {
                        OneSurah one = new OneSurah() { SurahName = surahList[surah_id - 1], SurahID = surah_id };
                        surahs.Add(one);
                    }

                    surahs[surahs.Count - 1].AyatList.Add(new OneAyat() { Ayat = ayat, Ayat_Arabic = arabic, AyatID = ayat_id});

                    lastSurah = surah_id;
                }

                reader.Close();
            }

            return surahs;
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

                query = "SELECT T.`surah_id` , T.`ayat_id` , T.`ayat`, T.`ayat_arabic` FROM texts T INNER JOIN  `ayah_indexing` I ON I.`tag_id` = " + tagId + " AND I.`surah_id` = T.`surah_id` AND I.`ayat_id` = T.`ayat_id` ORDER BY  `T`.`surah_id` , T.`ayat_id`";

                cmd.CommandText = query;
                var reader = cmd.ExecuteReader();

                int lastSurah = -1;
                while (reader.Read())
                {
                    int surah_id = reader.GetInt32(0);
                    int ayat_id = reader.GetInt32(1);

                    string ayat = reader.GetString(2);
                    string ayat_arabic = reader.GetString(3);

                    if (lastSurah != surah_id)
                    {
                        OneSurah one = new OneSurah() { SurahName = surahList[surah_id - 1], SurahID = surah_id };
                        surahs.Add(one);
                    }

                    surahs[surahs.Count - 1].AyatList.Add(new OneAyat() { Ayat = ayat, Ayat_Arabic = ayat_arabic, AyatID = ayat_id });

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
            if(oneSurah.SurahID != 9 && oneSurah.AyatList.Count > 1 && oneSurah.AyatList[0].AyatID == 1)
                return Fatiha.AyatList[0].Ayat_Arabic + Environment.NewLine;

            return "";
        }

        private void bindAyatsFlowPanel(ref List<OneSurah> surahs)
        {
            mtb.ClearText();

            for (int j = 0; j < surahs.Count; j++)
            {
                mtb.AddBanglaHeaderText(GetSurahHeader(surahs[j], j==0));
                string Bismillah = AddBismillah(surahs[j]);
                
                if(Bismillah != string.Empty)
                    mtb.AddArabicHeaderText(Bismillah);

                for (int i = 0; i < surahs[j].AyatList.Count; i++)
                {
                    var ayat = surahs[j].AyatList[i];
                    //string arabic_ayat = string.Format("{0} {1}", ayat.Ayat_Arabic, Utility.ToConvertArabicNumber(ayat.AyatID));
                    string arabic_ayat = ayat.Ayat_Arabic;
                    //var RLM = ((char)0x200F).ToString();
                    //var LRM = ((char)0x200E).ToString();
                    //var result = arabic_ayat + RLM + Utility.ToConvertArabicNumber(ayat.AyatID);

                    mtb.AddArabicText(arabic_ayat + Environment.NewLine);
                    mtb.AddBanglaText(Utility.ToConvertBanglaNumber(ayat.AyatID) + ") ");
                    mtb.AddBanglaText(ayat.Ayat + Environment.NewLine);

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
            
            string search = txtSearch.Text;
            
            if (string.IsNullOrEmpty(search))
                return;

            labelInfo.Text = "Searching with: " + search + " ......";

            labelInfo.Update();
            
            List<OneSurah> surahs = SearchAyatByText(search);

            bindAyatsFlowPanel(ref surahs);

            Utility.HighlightText(txtAyats, search, Color.Black);

            labelInfo.Text = GetSearchItemCount(ref surahs) +  " Ayats found with: [" + search + "]";
        }

        private void frmSearch_Load(object sender, EventArgs e)
        {
            surahList = LoadSurahList();
            surahMaxAyatList = DBUtility.GetSurahMaxAyatList();
            Fatiha = DBUtility.GetFullSurah(1, surahList[0]);
            mtb = new MultilingualTextBox(this.txtAyats);
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
                    labelInfo.Text = "Loading full surah: " + f.SelectedSurahString + " .....";

                    labelInfo.Update();

                    List<OneSurah> surahs = SearchAyatByText(string.Empty, f.SelectedSurahId);

                    bindAyatsFlowPanel(ref surahs);

                    labelInfo.Text = "Total Ayats: " + GetSearchItemCount(ref surahs);
                }
            }
        }

        private void linkTags_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmTagList f = new frmTagList();
            f.SelectedTagId = 1;
            if (f.ShowDialog() == DialogResult.OK)
            {

                if (f.SelectedTagId >= 1)
                {
                    labelInfo.Text = "Loading with tag: " + f.SelectedTagString + " .....";
                    labelInfo.Update();

                    List<OneSurah> surahs = SearchTagID(f.SelectedTagId);

                    bindAyatsFlowPanel(ref surahs);

                    labelInfo.Text = GetSearchItemCount(ref surahs) + " Ayats found with tag: " + f.SelectedTagString + "";
                }
            }
        }

        private void linkFixBangla_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmFix f = new frmFix();
            f.ShowDialog();
        }

        private void linkJumpTo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
