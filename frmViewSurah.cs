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

namespace Bangla_text_mysql
{
    public partial class frmViewSurah : Form
    {
        public int SurahID = -1;
        public int TageID = -1;

        public frmViewSurah()
        {
            InitializeComponent();
        }
        

        private string LoadFullSurah(int surah_id)
        {
            StringBuilder strb = new StringBuilder();

            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "banglatest";
            if (dbCon.IsConnect())
            {
                string query = "SELECT `ayat_id`, `ayat` FROM `texts` WHERE `surah_id` =" + surah_id;
#if DB_MYSQL
                var cmd = new MySqlCommand(query, dbCon.Connection);
#else
                var cmd = new SQLiteCommand(query, dbCon.Connection);
#endif
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int ayat_id = reader.GetInt32(0);
                    string ayat = reader.GetString(1);
                    strb.Append( ayat_id + ". " + ayat + Environment.NewLine + Environment.NewLine);
                }
                reader.Close();
            }

            //dbCon.Close();

            return strb.ToString();
        }

        private string LoadAyatByTagIndex(int tag_id)
        {
            StringBuilder strb = new StringBuilder();

            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "banglatest";
            if (dbCon.IsConnect())
            {
                string query = "SELECT T.`surah_id` , T.`ayat_id` , T.`ayat` FROM texts T INNER JOIN  `ayah_indexing` I ON I.`tag_id` = "+tag_id+" AND I.`surah_id` = T.`surah_id` AND I.`ayat_id` = T.`ayat_id` ORDER BY  `T`.`surah_id` , T.`ayat_id`";

#if DB_MYSQL
                var cmd = new MySqlCommand(query, dbCon.Connection);
#else
                var cmd = new SQLiteCommand(query, dbCon.Connection);
#endif
                var reader = cmd.ExecuteReader();
                int counter = 1;

                while (reader.Read())
                {
                    int surah_id = reader.GetInt32(0); 
                    int ayat_id = reader.GetInt32(1);
                    string ayat = reader.GetString(2);
                    strb.Append( counter++ +". (" + surah_id + ":" + ayat_id + ") " + ayat + Environment.NewLine + Environment.NewLine);
                }
                reader.Close();
            }

            //dbCon.Close();

            return strb.ToString();
        }

        private void frmViewSurah_Load(object sender, EventArgs e)
        {
            if (SurahID >= 1 && SurahID <= 114)
            {
                txtAyats.Text = string.Empty;
                txtAyats.Text = LoadFullSurah(SurahID);
                txtAyats.Select(0, 0);
                txtAyats.Update();
            }
            else if(TageID>0)
            {
                txtAyats.Text = string.Empty;
                txtAyats.Text = LoadAyatByTagIndex(TageID);
                txtAyats.Select(0, 0);
                txtAyats.Update();
            }
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
