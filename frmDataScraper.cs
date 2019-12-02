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

using System.Net;
using System.Collections.Specialized;
using System.Threading;


namespace Bangla_text_mysql
{
    

    public partial class frmDataScraper : Form
    {
        public frmDataScraper()
        {
            InitializeComponent();
        }

        public string parseAyat(ref string data)
        {
            
            string initAyatDivSep = "<div class=bangla>";
            string endAyatDivSep = "[<a href=";

            int index = data.IndexOf(initAyatDivSep);
            
            if (index < 0) return string.Empty;

            index += initAyatDivSep.Length;
            data = data.Substring(index);

            index = data.IndexOf(endAyatDivSep);

            if (index < 0) return string.Empty;

            string Ayat = data.Substring(0,index);

            return Ayat;


        }

        public string parseAyatArabic(ref string data)
        {

            string initAyatDivSep = "<div class='span11 arabic'>";
            string endAyatDivSep = "</div></div>";

            int index = data.IndexOf(initAyatDivSep);

            if (index < 0) return string.Empty;

            index += initAyatDivSep.Length;
            data = data.Substring(index);

            index = data.IndexOf(endAyatDivSep);

            if (index < 0) return string.Empty;

            string Ayat = data.Substring(0, index);

            return Ayat;


        }

        public List<string> parseAllAyats(string content, bool isArabic = false)
        {

            List<string> Ayats = new List<string>();

            while (true)
            {

                string Ayat = string.Empty;

                if (isArabic)
                    Ayat = parseAyatArabic(ref content);
                else
                    Ayat = parseAyat(ref content);

                if (Ayat.Equals(string.Empty))
                    break;

                Ayats.Add(Ayat);
            }

            return Ayats;
        }

        public List<string> DownloadFileArabic(string remoteFilename)
        {
            WebClient wc = new WebClient();
            wc.Headers.Add("User-Agent", "Mozilla/5.0 (Windows; U; Windows NT 6.1; en-GB; rv:1.9.2.12) Gecko/20101026 Firefox/3.6.12");
            var rawData = wc.DownloadData(remoteFilename);
            var encoding = WebUtils.GetEncodingFrom(wc.ResponseHeaders, Encoding.UTF8);
            string content = encoding.GetString(rawData);

            return parseAllAyats(content, true);

        }

        public List<string> DownloadFile(string remoteFilename)
        {
            WebClient wc = new WebClient();
            wc.Headers.Add("User-Agent", "Mozilla/5.0 (Windows; U; Windows NT 6.1; en-GB; rv:1.9.2.12) Gecko/20101026 Firefox/3.6.12");
            var rawData = wc.DownloadData(remoteFilename);
            var encoding = WebUtils.GetEncodingFrom(wc.ResponseHeaders, Encoding.UTF8);
            string content = encoding.GetString(rawData);

            return  parseAllAyats(content);

        }


        private void InsertSurahName()
        {
            string[] list = {
                                 "ফাতিহা"
                                ,"বাকারা"
                                ,"ইমরান"
                                ,"নিসা"
                                ,"মায়েদা"
                                ,"আন’য়াম"
                                ,"আরাফ"
                                ,"আনফাল"
                                ,"তাওবা"
                                ,"ইউনুস"
                                ,"হুদ"
                                ,"ইউসুফ"
                                ,"রা’দ"
                                ,"ইবরাহীম"
                                ,"হিজর"
                                ,"নাহল"
                                ,"বনী-ইসরাঈল"
                                ,"কা’হফ"
                                ,"মারঈয়াম"
                                ,"ত্বা-হা"
                                ,"আম্বিয়া"
                                ,"হাজ্জ্ব"
                                ,"মু’মিনুন"
                                ,"নুর"
                                ,"ফুরকান"
                                ,"শু’য়ারা"
                                ,"নাম’ল"
                                ,"কাসাস"
                                ,"আনকাবুত"
                                ,"রূম"
                                ,"লুকমান"
                                ,"সাজদা"
                                ,"আহযাব"
                                ,"সা’বা"
                                ,"ফাতির"
                                ,"ইয়া-সীন"
                                ,"সাফফাত"
                                ,"সা’দ"
                                ,"যুমার"
                                ,"মু’মিন"
                                ,"হা-মীম"
                                ,"শূরা"
                                ,"যূখরুফ"
                                ,"দুখান"
                                ,"যাসিয়া"
                                ,"আহক্বাফ"
                                ,"মুহাম্মাদ"
                                ,"ফাতাহ"
                                ,"হুজুরাত"
                                ,"ক্বাফ"
                                ,"যারিয়া’ত"
                                ,"তুর"
                                ,"নাজম"
                                ,"ক্বামার"
                                ,"আর-রহমান"
                                ,"ওয়াক্বিয়া"
                                ,"হাদীদ"
                                ,"মুজাদালাহ"
                                ,"হাশর"
                                ,"মুমতাহিনা"
                                ,"সফ"
                                ,"জুম’য়া"
                                ,"মুনাফিক্বুন"
                                ,"তাগাবুন"
                                ,"তালাক"
                                ,"তাহরীম"
                                ,"মুলক"
                                ,"কালাম"
                                ,"হাক্বকাহ"
                                ,"মা’য়ারিজ"
                                ,"নূহ"
                                ,"জ্বীন"
                                ,"মুযযাম্মিল"
                                ,"মুদ্দাসসির"
                                ,"কিয়ামা’ত"
                                ,"দা’হর"
                                ,"মুরসালাত"
                                ,"নাবা"
                                ,"নাজিয়াত"
                                ,"আ’বাসা"
                                ,"তাকভীর"
                                ,"ইনফিতার"
                                ,"মুতাফফিফীন"
                                ,"ইনশিকাক"
                                ,"বুরূজ"
                                ,"তারিক"
                                ,"আ’লা"
                                ,"গাশিয়াহ"
                                ,"ফা’জর"
                                ,"বা’লাদ"
                                ,"শামস"
                                ,"লাইল"
                                ,"দুহা"
                                ,"আলাম-নাশরাহ"
                                ,"তীন"
                                ,"আলাক"
                                ,"ক্বদর"
                                ,"বাইয়্যেনাহ"
                                ,"যিলযাল"
                                ,"আদিয়্যাত"
                                ,"ক্বারিয়া"
                                ,"তাকাসুর"
                                ,"আসর"
                                ,"হুমাযা"
                                ,"ফীল"
                                ,"কুরাইশ"
                                ,"মাউন"
                                ,"কাউসার"
                                ,"কাফিরূন"
                                ,"ন’সর"
                                ,"লাহাব"
                                ,"ইখলাস"
                                ,"ফালাক"
                                ,"নাস"
                             };


            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "banglatest";
            if (dbCon.IsConnect())
            {

                string query = "";
#if DB_MYSQL
                var cmd = new MySqlCommand(query, dbCon.Connection);
                SetUTF8Mode(cmd);
#else
                var cmd = new SQLiteCommand(query, dbCon.Connection);
#endif
                

                for (int i = 0; i < list.Length; i++)
                {
                    byte[] surah_name = System.Text.Encoding.UTF8.GetBytes(  "সুরাহ "+ list[i]);
                    query = "INSERT INTO surah (surah_name) VALUES (@surah_name)";
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@surah_name", surah_name);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
            }

            //dbCon.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //InsertSurahName();
            //ScrapeAndInsertSurah();
            //ScarapeArabicAndInsertSurah();
        }

        private void ScarapeArabicAndInsertSurah()
        {
            for (int i = 1; i < 115; i++)
            {
                DownloadArabicSurah(i);
                label1.Text = i + "";
                Application.DoEvents();
                Thread.Sleep(200);
                label1.Text = (i + 1) + " ~ processing";
            }
        }

       
        private void DownloadArabicSurah(int surah_id)
        {
            string url = "https://habibur.com/quran/arabic/" + Convert.ToString(surah_id) + "/";
            List<string> Ayats = DownloadFileArabic(url);

            //MessageBox.Show(Ayats[0]);

            int ay = 1;
            foreach (string s in Ayats)
                InsertAyatsArabic(s, surah_id, ay++);

        }

        private void ScrapeAndInsertSurah()
        {
            for (int i = 1; i < 115; i++)
            {
                DownloadSurah(i);
                label1.Text = i + "";
                Application.DoEvents();
                Thread.Sleep(60000);
                label1.Text = (i + 1) + " ~ processing";
            }
        }

        private void DownloadSurah(int surah_id)
        {
            string url = "https://habibur.com/quran/" + Convert.ToString(surah_id) + "/";
            List<string> Ayats = DownloadFile(url);

            int ay = 1;
            foreach (string s in Ayats)
                InsertAyats(s, surah_id, ay++);

        }

#if DB_MYSQL
        private void SetUTF8Mode(MySqlCommand cmd)
        {
            string mysql_query2 = "SET NAMES 'utf8'";
            cmd.CommandText = mysql_query2;
            cmd.ExecuteNonQuery();
        }
#endif
        private void InsertAyats(string theContent, int surah_id, int ayat_id)
        {
            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "banglatest";
            if (dbCon.IsConnect())
            {

                string query = "";
#if DB_MYSQL
                var cmd = new MySqlCommand(query, dbCon.Connection);
                SetUTF8Mode(cmd);
#else
                var cmd = new SQLiteCommand(query, dbCon.Connection);
#endif

                byte[] ayatText = System.Text.Encoding.UTF8.GetBytes(theContent);
                query = "INSERT INTO texts (surah_id, ayat_id, ayat) VALUES (@surah_id, @ayat_id, @ayat)";
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@surah_id", surah_id);
                cmd.Parameters.AddWithValue("@ayat_id", ayat_id);
                cmd.Parameters.AddWithValue("@ayat", ayatText);
                cmd.ExecuteNonQuery();
                //MessageBox.Show("Successfully inserted");
            }

            //dbCon.Close();
        }

        private void InsertAyatsArabic(string theContent, int surah_id, int ayat_id)
        {
            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "banglatest";
            if (dbCon.IsConnect())
            {

                string query = "";
#if DB_MYSQL
                var cmd = new MySqlCommand(query, dbCon.Connection);
                SetUTF8Mode(cmd);
#else
                var cmd = new SQLiteCommand(query, dbCon.Connection);
#endif

                byte[] ayatText = System.Text.Encoding.UTF8.GetBytes(theContent);
                query = "UPDATE texts SET ayat_arabic = @ayat WHERE surah_id = @surah_id AND ayat_id = @ayat_id";
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@surah_id", surah_id);
                cmd.Parameters.AddWithValue("@ayat_id", ayat_id);
                cmd.Parameters.AddWithValue("@ayat", ayatText);
                cmd.ExecuteNonQuery();
                //MessageBox.Show("Successfully inserted");
            }

            //dbCon.Close();
        }

        private void ReadTest()
        {
            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "banglatest";
            if (dbCon.IsConnect())
            {
                //suppose col0 and col1 are defined as VARCHAR in the DB
                string query = "SELECT * FROM texts";
#if DB_MYSQL
                var cmd = new MySqlCommand(query, dbCon.Connection);
#else
                var cmd = new SQLiteCommand(query, dbCon.Connection);
#endif

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string someStringFromColumnZero = reader.GetInt32(0).ToString();
                    string someStringFromColumnOne = reader.GetString(1);
                    string line = someStringFromColumnZero + "," + someStringFromColumnOne;
                    MessageBox.Show(line);
                }
                reader.Close();
            }

            dbCon.Close();
        }

        private void frmDataScraper_Load(object sender, EventArgs e)
        {

        }
    }


    public static class WebUtils
    {
        public static Encoding GetEncodingFrom(
            NameValueCollection responseHeaders,
            Encoding defaultEncoding = null)
        {
            if (responseHeaders == null)
                throw new ArgumentNullException("responseHeaders");

            //Note that key lookup is case-insensitive
            var contentType = responseHeaders["Content-Type"];
            if (contentType == null)
                return defaultEncoding;

            var contentTypeParts = contentType.Split(';');
            if (contentTypeParts.Length <= 1)
                return defaultEncoding;

            var charsetPart =
                contentTypeParts.Skip(1).FirstOrDefault(
                    p => p.TrimStart().StartsWith("charset", StringComparison.InvariantCultureIgnoreCase));
            if (charsetPart == null)
                return defaultEncoding;

            var charsetPartParts = charsetPart.Split('=');
            if (charsetPartParts.Length != 2)
                return defaultEncoding;

            var charsetName = charsetPartParts[1].Trim();
            if (charsetName == "")
                return defaultEncoding;

            try
            {
                return Encoding.GetEncoding(charsetName);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
                throw new ArgumentNullException(ex.Message);
            }
        }
    }
}
