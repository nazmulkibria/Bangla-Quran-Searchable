using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data.SQLite;


namespace Bangla_text_mysql
{

    public class DBConnection
    {
        private DBConnection()
        {
        }

        private string databaseName = string.Empty;
        public string DatabaseName
        {
            get { return databaseName; }
            set { databaseName = value; }
        }

        public string Password { get; set; }

        private static DBConnection _instance = null;
        public static DBConnection Instance()
        {
            if (_instance == null)
                _instance = new DBConnection();
            return _instance;
        }

#if DB_MYSQL
        private MySqlConnection connection = null;
        
        public MySqlConnection Connection
        {
            get { return connection; }
        }


        public bool IsConnect()
        {
            bool result = true;
            if (Connection == null)
            {
                if (String.IsNullOrEmpty(databaseName))
                    result = false;
                string connstring = string.Format("Server=127.0.0.1; Charset=utf8; database={0}; UID=root; password=", databaseName);
                connection = new MySqlConnection(connstring);
                connection.Open();
                result = true;
            }

            return result;
        }
#else//sqlite

        private SQLiteConnection connection = null;

        public SQLiteConnection Connection
        {
            get { return connection; }
        }


        public bool IsConnect()
        {
            bool result = true;
            if (Connection == null)
            {
                if (String.IsNullOrEmpty(databaseName))
                    result = false;
                //string connstring = string.Format("Server=127.0.0.1; Charset=utf8; database={0}; UID=root; password=", databaseName);
                connection = new SQLiteConnection(@"Data Source=E:\Work House\Bangla_Quran_sqlite\sqlitedb\MyDatabase.sqlite;Version=3;");
                //connection = new SQLiteConnection(connstring);
                connection.Open();
                result = true;
            }

            return result;
        }

#endif

        public void Close()
        {
            connection.Close();
        }

        
    }
}
