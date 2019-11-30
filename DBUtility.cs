using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data.SQLite;

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
                query = "CREATE VIRTUAL TABLE AyatSearch USING fts4(surah_id,ayat_id, ayat, ayat_arabic)";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

                query = "INSERT INTO AyatSearch SELECT surah_id, ayat_id, ayat, ayat_arabic FROM texts";//(surah_id || '_' || ayat_id)
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

            }
        }

        public static void DropVirtualTable()
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
                query = "Drop table AyatSearch";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
            }
            
        }

        public static void AddEscapeChar(ref string str)
        {
            str = str.Replace("'","''");
        }
    }
}
