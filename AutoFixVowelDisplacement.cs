using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data.SQLite;

namespace Bangla_text_mysql
{
    public class AutoFixVowelDisplacement
    {
        private void Fix(KeyValuePair<int, string> kp)
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

                query = "UPDATE  texts SET  ayat =  '" + Utility.ToLiteral( Utility.FixerVowelDisplacement(kp.Value) ) + "' WHERE  id = " + kp.Key;
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
            }

            //dbCon.Close();
        }

        public int Fix(string searchWith, string fixWith)
        {
            DBUtility.AddEscapeChar(ref searchWith);
            DBUtility.AddEscapeChar(ref fixWith);

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

                //query = "UPDATE texts SET ayat = REPLACE(ayat, '" + searchWith + "', '" + fixWith + "') WHERE INSTR(ayat, '" + searchWith + "') > 0";
                query = "UPDATE texts SET ayat = REPLACE(ayat, '" + searchWith + "', '" + fixWith + "') WHERE ayat LIKE '%" + searchWith + "%'";
                cmd.CommandText = query;
                return cmd.ExecuteNonQuery();
            }

            return 0;
            //dbCon.Close();
        }
        
        private List<KeyValuePair<int, string>> ChooseAyatsNeededToFix()
        {
            List<KeyValuePair<int, string>> ayatsList = new List<KeyValuePair<int, string>>();

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

                query = "SELECT `id`, `ayat` FROM `texts`  WHERE ";

                string [] list = Utility.GetFixerVowels(true);
                
                for(int i = 0; i < list.Length; i++)
                {
                    if(i > 0)
                        query += " or ";

                    query += "ayat like '%"+list[i]+"%'";
                }

                cmd.CommandText = query;
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string ayat = reader.GetString(1);
                    var kp = new KeyValuePair<int, string>(id, ayat);
                    ayatsList.Add(kp);
                }

                reader.Close();
            }

            return ayatsList;
        }

        public void FixAll()
        {
            List<KeyValuePair<int, string>> ayatsList = ChooseAyatsNeededToFix();
            
            foreach (var kp in ayatsList)
                Fix(kp);
        }

    }
}
