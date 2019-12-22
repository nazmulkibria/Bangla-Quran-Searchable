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
    public partial class frmTagList : Form
    {
        public int SelectedTagId = -1;

        private string SelTagStr = string.Empty;

        public string SelectedTagString
        {
            private set { SelTagStr = value; }
            get { return SelTagStr; }
        }

        private List<string> Tags = new List<string>();

        public frmTagList()
        {
            InitializeComponent();
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            if (listBoxSurah.SelectedIndex >= 0)
            {
                SelectedTagId = listBoxSurah.SelectedIndex + 1;
                SelectedTagString = "#"+Tags[listBoxSurah.SelectedIndex];
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void LoadTags()
        {
            listBoxSurah.Items.Clear();
            Tags.Clear();

            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "banglatest";
            if (dbCon.IsConnect())
            {
                string query = "SELECT * FROM tags";
#if DB_MYSQL
                var cmd = new MySqlCommand(query, dbCon.Connection);
#else
                var cmd = new SQLiteCommand(query, dbCon.Connection);
#endif
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int surah_id = reader.GetInt32(0);
                    string surah_name = reader.GetString(1);
                    listBoxSurah.Items.Add(Utility.ToConvertBanglaNumber( surah_id ) + ". #" + surah_name);
                    Tags.Add(surah_name);
                }
                reader.Close();
            }

            //dbCon.Close();
        }

        private void AddBlackBorder()
        {
            Panel panel = new Panel();
            panel.BackColor = this.BackColor;
            panel.Size = new System.Drawing.Size(this.Size.Width - 2, this.Size.Height - 2);
            panel.Location = new Point(1, 1);
            this.Controls.Remove(listBoxSurah);
            panel.Controls.Add(listBoxSurah);
            this.Controls.Add(panel);
            this.BackColor = Color.Gray;
        }

        private void frmSurahList_Load(object sender, EventArgs e)
        {
            AddBlackBorder();

            LoadTags();

            if (SelectedTagId >= 1 && SelectedTagId <= 114)
                listBoxSurah.SelectedIndex = SelectedTagId - 1;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
