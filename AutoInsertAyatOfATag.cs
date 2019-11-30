using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data.SQLite;

namespace Bangla_text_mysql
{
    public class AutoInsertAyatOfATag
    {
        private void InsertAyatIndex(List<KeyValuePair<int, int>> ids, int tag_id)//<surah_id, ayat_id>
        {
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

                for (int i = 0; i < ids.Count; i++)
                {
                    query = "INSERT INTO ayah_indexing (surah_id, ayat_id, tag_id) VALUES (@surah_id, @ayat_id, @tag_id)";
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@surah_id", ids[i].Key);
                    cmd.Parameters.AddWithValue("@ayat_id", ids[i].Value);
                    cmd.Parameters.AddWithValue("@tag_id", tag_id);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
            }

            //dbCon.Close();
        }

#if DB_MYSQL
        private void SetUTF8Mode(MySqlCommand cmd)
        {
            string mysql_query2 = "SET CHARACTER SET utf8; SET SESSION collation_connection =`utf8_general_ci`;";
            cmd.CommandText = mysql_query2;
            cmd.ExecuteNonQuery();
        }
#endif
        public int StartInsertingAyatIndex(string search, int tag_id)
        {

            List<KeyValuePair<int, int>> ids = new List<KeyValuePair<int, int>>();
            List<KeyValuePair<int, int>> ids2 = new List<KeyValuePair<int, int>>();

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
                query = "SELECT T.`surah_id`, T.`ayat_id`  FROM `texts` T WHERE (`ayat`) LIKE '%" + search + "%' AND (T.`surah_id`, T.`ayat_id`) NOT IN (SELECT B.`surah_id`, B.`ayat_id` FROM `ayah_indexing` B WHERE tag_id=" + tag_id + ")";
                cmd.CommandText = query;
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int surah_id = reader.GetInt32(0);
                    int ayat_id = reader.GetInt32(1);
                    ids.Add(new KeyValuePair<int, int>(surah_id, ayat_id));
                }

                reader.Close();
            }

            if (ids.Count > 0)
            {
                InsertAyatIndex(ids, tag_id);
                return ids.Count;
            }

            return 0;
        }
    }
}
