using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#if DB_MYSQL
using MySql.Data.MySqlClient;
#else
using System.Data.SQLite;
#endif
using System.Windows.Forms;
using Bangla_text_mysql.Core;

namespace Bangla_text_mysql
{
    public class DBUtility
    {
        public static Dictionary<int, int> GetSurahMaxAyatList()
        {
            Dictionary<int, int> maxAyats = new Dictionary<int, int>();

            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "banglatest";

            if (dbCon.IsConnect())
            {
                string query = "";

#if DB_MYSQL
                var cmd = new MySqlCommand("", dbCon.Connection);
#else
                var cmd = new SQLiteCommand("", dbCon.Connection);
#endif
                //SetUTF8Mode(cmd);
                query = "SELECT  `surah_id` , MAX(  `ayat_id` ) AS MaxAyat FROM texts GROUP BY  `surah_id`";
                cmd.CommandText = query;
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int surah_id = reader.GetInt32(0);
                    int maxAyat = reader.GetInt32(1);
                    maxAyats.Add(surah_id, maxAyat);
                }

                reader.Close();
            }

            return maxAyats;
        }

        public static OneSurah GetFullSurah(int surah_id, string surahName)
        {
            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "banglatest";

            OneSurah surah = new OneSurah() { SurahName = surahName, SurahID = surah_id };

            if (dbCon.IsConnect())
            {
                string query = "";

#if DB_MYSQL
                var cmd = new MySqlCommand(query, dbCon.Connection);
#else
                var cmd = new SQLiteCommand(query, dbCon.Connection);
#endif
                //SetUTF8Mode(cmd);
                query = "SELECT  `ayat_id`, `ayat`, `ayat_arabic` FROM `texts`  WHERE `surah_id` = " + surah_id;
                cmd.CommandText = query;
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int ayat_id = reader.GetInt32(0);
                    string arabic = reader.GetString(2);
                    string ayat = reader.GetString(1);
                    surah.AyatList.Add(new OneAyat() { Ayat = ayat, Ayat_Arabic = arabic, AyatID = ayat_id });
                }

                reader.Close();
            }

            return surah;
        }

        public static void UpdateNoHarakatField()
        {
            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "banglatest";

            if (dbCon.IsConnect())
            {
                string query = "";
                string queryUpdate = "";

#if DB_MYSQL
                var cmd = new MySqlCommand(query, dbCon.Connection);
                var cmd2 = new MySqlCommand(queryUpdate, dbCon.Connection);
#else
                var cmd = new SQLiteCommand(query, dbCon.Connection);
                var cmd2 = new SQLiteCommand(queryUpdate, dbCon.Connection);
#endif
                //SetUTF8Mode(cmd);
                query = "SELECT  `ayat_id`, `surah_id`, `ayat_arabic` FROM `texts`";
                cmd.CommandText = query;
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int ayat_id = reader.GetInt32(0);
                    int surah_id = reader.GetInt32(1);
                    string arabic = reader.GetString(2);
                    arabic = ArabicNormalizer.normalize(arabic);

                    queryUpdate = "UPDATE `texts` SET ayat_arabic_nh = " + "'" + arabic + "' WHERE ayat_id = " + ayat_id + " AND surah_id = " + surah_id;
                    cmd2.CommandText = queryUpdate;
                    cmd2.ExecuteNonQuery();
                }

                reader.Close();
            }

        }

        public static void CreateVirtualTable()
        {
            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "banglatest";

            if (dbCon.IsConnect())
            {
                string query = "";

#if DB_MYSQL
                var cmd = new MySqlCommand("", dbCon.Connection);
#else
                var cmd = new SQLiteCommand("", dbCon.Connection);
#endif
                //SetUTF8Mode(cmd);
                query = "CREATE VIRTUAL TABLE AyatSearch USING fts4(surah_id,ayat_id, ayat, ayat_arabic, ayat_arabic_nh)";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

                query = "INSERT INTO AyatSearch SELECT surah_id, ayat_id, ayat, ayat_arabic, ayat_arabic_nh FROM texts";//(surah_id || '_' || ayat_id)
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

            }

        }

        

        public static void DropVirtualTable()
        {
            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "banglatest";

            try
            {
                if (dbCon.IsConnect())
                {
                    string query = "";

#if DB_MYSQL
                var cmd = new MySqlCommand("", dbCon.Connection);
#else
                    var cmd = new SQLiteCommand("", dbCon.Connection);
#endif
                    //SetUTF8Mode(cmd);
                    query = "Drop table AyatSearch";
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }

        }

        public static void AddEscapeChar(ref string str)
        {
            str = str.Replace("'", "''");
        }
    }
}
