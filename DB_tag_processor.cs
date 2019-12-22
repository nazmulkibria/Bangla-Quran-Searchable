using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using Bangla_text_mysql.Core;

namespace Bangla_text_mysql
{
    public class DB_tag_processor
    {
        public static List<Tag> GetTags()
        {
            List<Tag> tags = new List<Tag>();

            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "banglatest";
            if (dbCon.IsConnect())
            {
                string query = "SELECT * FROM tags ORDER BY tag_bangla";
#if DB_MYSQL
                var cmd = new MySqlCommand(query, dbCon.Connection);
#else
                var cmd = new SQLiteCommand(query, dbCon.Connection);
#endif
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int tag_id = reader.GetInt32(0);
                    string tag_bangla = reader.GetString(1);
                    tags.Add( new Tag() { tag_id = tag_id, tag_bangla = tag_bangla } );
                }
                reader.Close();
            }

            return tags;
        }

        public static void InsertAyatIndex(List<OneSurah> ayats, Tag tag)
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

                for (int i = 0; i < ayats.Count; i++)
                {
                    for (int j = 0; j < ayats[i].AyatList.Count; j++)
                    {
                        //query = "INSERT INTO ayah_indexing (surah_id, ayat_id, tag_id) VALUES (@surah_id, @ayat_id, @tag_id)";
                        query = "INSERT OR IGNORE INTO ayah_indexing (surah_id, ayat_id, tag_id) VALUES (@surah_id, @ayat_id, @tag_id)";
                        cmd.CommandText = query;
                        cmd.Parameters.AddWithValue("@surah_id", ayats[i].SurahID);
                        cmd.Parameters.AddWithValue("@ayat_id", ayats[i].AyatList[j].AyatID);
                        cmd.Parameters.AddWithValue("@tag_id", tag.tag_id);
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }
                }
            }

            //dbCon.Close();
        }
    }
}
