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
    public partial class frmDataEntry : Form
    {
        public frmDataEntry()
        {
            InitializeComponent();
        }

        private List<KeyValuePair<int, string>> tagList = new List<KeyValuePair<int, string>>();
        private List<KeyValuePair<int, string>> surahList = new List<KeyValuePair<int, string>>();
        private List<int> CurrentTagIDList = new List<int>();

        private void LoadTags()
        {
            tagList.Clear();
            listTags.Items.Clear();

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
                    int tag_id = reader.GetInt32(0);
                    string tag_bangla = reader.GetString(1);
                    tagList.Add(new KeyValuePair<int, string>(tag_id, tag_bangla));
                }
                reader.Close();
            }

            //dbCon.Close();
        }

        private void LoadSurahs()
        {
            surahList.Clear();

            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "banglatest";
            if (dbCon.IsConnect())
            {
                string query = "SELECT * FROM surah";
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
                    surahList.Add(new KeyValuePair<int, string>(surah_id, surah_name));
                }
                reader.Close();
            }

            //dbCon.Close();
        }

        private void BindTags()
        {
            for (int i = 0; i < tagList.Count; i++)
                listTags.Items.Add(tagList[i].Value);
        }

        private void LoadAyat(int surah_id, int ayat_id)
        {

            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "banglatest";
            if (dbCon.IsConnect())
            {
                string query = "SELECT ayat FROM texts WHERE surah_id = " + surah_id + " AND ayat_id = " + ayat_id;
#if DB_MYSQL
                var cmd = new MySqlCommand(query, dbCon.Connection);
#else
                var cmd = new SQLiteCommand(query, dbCon.Connection);
#endif
                var reader = cmd.ExecuteReader();
                bool isFound = false;
                while (reader.Read())
                {
                    string tag_bangla = reader.GetString(0);
                    txtAyat.Text = ayat_id + ". " + tag_bangla;
                    isFound = true;
                }
                if (!isFound)
                    txtAyat.Text = "Not Found!!!";
                reader.Close();
            }

            //dbCon.Close();
        }

        private void txtAyaatID_TextChanged(object sender, EventArgs e)
        {
            LoadSpecificAyat();
        }

        private void LoadSpecificAyat()
        {
            if (string.IsNullOrEmpty(txtSurahID.Text))
            {
                //txtSurahID.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtAyaatID.Text))
            {
                //txtAyaatID.Focus();
                return;
            }

            LoadAyat(Convert.ToInt32(txtSurahID.Text), Convert.ToInt32(txtAyaatID.Text));
            LoadAyatTag_ifExit(Convert.ToInt32(txtSurahID.Text), Convert.ToInt32(txtAyaatID.Text));
        }

        private void DetectTagIdActions(ref List<int> addList, ref List<int> deleteList, ref List<KeyValuePair<int, int>> updateList)
        {

            //prepare delete list
            for (int i = 0; i < CurrentTagIDList.Count; i++)
            {
                bool found = false;

                for (int j = 0; j < listTags.SelectedIndices.Count; j++)
                {
                    int tagId = Convert.ToInt32(listTags.SelectedIndices[j]) + 1;

                    if (CurrentTagIDList[i] == tagId)
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                    deleteList.Add(CurrentTagIDList[i]);
            }

            CurrentTagIDList = CurrentTagIDList.Except(deleteList).ToList();

            //prepare add list
            for (int j = 0; j < listTags.SelectedIndices.Count; j++)
            {
                int tagId = Convert.ToInt32(listTags.SelectedIndices[j]) + 1;

                bool found = false;

                for (int i = 0; i < CurrentTagIDList.Count; i++)
                {
                    if (CurrentTagIDList[i] == tagId)
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    if (deleteList.Count > 0)
                    {
                        updateList.Add(new KeyValuePair<int, int>(deleteList[deleteList.Count - 1], tagId));
                        deleteList.RemoveAt(deleteList.Count - 1);
                    }
                    else
                        addList.Add(tagId);
                }
            }

        }

        private void UpdateAyatIndex(int surah_id, int ayat_id)
        {
            if (listTags.SelectedIndices == null || listTags.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Select Tag Name");
                return;
            }

            List<int> deleteList = new List<int>();
            List<int> addList = new List<int>();
            List<KeyValuePair<int, int>> updateList = new List<KeyValuePair<int, int>>(); //<int, int> ==> <oldId,newID>

            DetectTagIdActions(ref addList, ref deleteList, ref updateList);

            InsertAyatIndex(surah_id, ayat_id, addList);
            DeleteAyatIndex(surah_id, ayat_id, deleteList);
            UpdateAyatIndex(surah_id, ayat_id, updateList);
        }

        private void InsertAyatIndex(int surah_id, int ayat_id, List<int> addList)
        {
            if(addList.Count==0) return;

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

                for (int i = 0; i < addList.Count; i++)
                {
                    int tag_id = addList[i];
                    query = "INSERT INTO ayah_indexing (surah_id, ayat_id, tag_id) VALUES (@surah_id, @ayat_id, @tag_id)";
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@surah_id", surah_id);
                    cmd.Parameters.AddWithValue("@ayat_id", ayat_id);
                    cmd.Parameters.AddWithValue("@tag_id", tag_id);
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                }
            }

            //dbCon.Close();
        }

        private void DeleteAyatIndex(int surah_id, int ayat_id, List<int> deleteList)
        {
            if (deleteList.Count == 0) return;

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

                for (int i = 0; i < deleteList.Count; i++)
                {
                    int tag_id = deleteList[i];
                    query = "DELETE FROM ayah_indexing WHERE surah_id = "+surah_id+" AND ayat_id = "+ayat_id+" AND tag_id = " + tag_id;
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                }
            }

            //dbCon.Close();
        }

        private void UpdateAyatIndex(int surah_id, int ayat_id, List<KeyValuePair<int, int>> updateList)
        { 
            if (updateList.Count == 0) return;

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

                for (int i = 0; i < updateList.Count; i++)
                {
                    int new_tag_id = updateList[i].Value;
                    int old_tag_id = updateList[i].Key;

                    query = "UPDATE  ayah_indexing SET  tag_id =  "+ new_tag_id +" WHERE  surah_id = " + surah_id + " AND ayat_id = " + ayat_id + " AND tag_id = " + old_tag_id;
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                }
            }

            //dbCon.Close();
        }

        private void LoadAyatTag_ifExit(int surah_id, int ayat_id)
        {
            listTags.ClearSelected();
            CurrentTagIDList.Clear();

            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "banglatest";
            if (dbCon.IsConnect())
            {
                string query = "SELECT tag_id FROM ayah_indexing WHERE surah_id = " + surah_id + " AND ayat_id = " + ayat_id;
#if DB_MYSQL
                var cmd = new MySqlCommand(query, dbCon.Connection);
#else
                var cmd = new SQLiteCommand(query, dbCon.Connection);
#endif
                var reader = cmd.ExecuteReader();
                bool isFound = false;
                while (reader.Read())
                {
                    int tag_id = reader.GetInt32(0);

                    CurrentTagIDList.Add(tag_id);
                    listTags.SelectedIndices.Add((tag_id - 1));

                    isFound = true;
                }

                reader.Close();
            }

            //dbCon.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtSurahID.Text))
            {
                txtSurahID.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtAyaatID.Text))
            {
                txtAyaatID.Focus();
                return;
            }

            if (listTags.SelectedIndices == null || listTags.SelectedIndices.Count == 0)
            {
                //MessageBox.Show("Please choose a tag");
                DeleteAyatIndex(Convert.ToInt32(txtSurahID.Text), Convert.ToInt32(txtAyaatID.Text), CurrentTagIDList);
                return;
            }

            UpdateAyatIndex(Convert.ToInt32(txtSurahID.Text), Convert.ToInt32(txtAyaatID.Text));
        }

        private void frmDataEntry_Load(object sender, EventArgs e)
        {
            ReloadTags();
            LoadSurahs();
        }

        private void ReloadTags()
        {
            LoadTags();
            BindTags();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            ReloadTags();
        }

        private void txtSurahID_TextChanged(object sender, EventArgs e)
        {
            int surah_id = -1;
            bool isParsed = Int32.TryParse(txtSurahID.Text, out surah_id);

            if (isParsed && surah_id >= 1 && surah_id <= 114)
            {
                lbl_surah.Text = surahList[surah_id - 1].Value;
                LoadSpecificAyat();
            }
            else
            {
                lbl_surah.Text = "Not a surah";
            }
        }

        private void listTags_SelectedIndexChanged(object sender, EventArgs e)
        {
            //txtTags.Text = string.Empty;
            fpTags.Controls.Clear();

            for (int i = 0; i < listTags.SelectedIndices.Count; i++)
            {
                //txtTags.Text += "#" + tagList[listTags.SelectedIndices[i]].Value + " ";
                var link = new LinkLabel();
                link.Font = new Font(txtSurahID.Font.FontFamily, 16);
                link.Text = "#" + tagList[listTags.SelectedIndices[i]].Value;
                link.Tag = tagList[listTags.SelectedIndices[i]].Key;
                link.AutoSize = true; 
                link.Click +=new EventHandler(link_Click);

                fpTags.Controls.Add( link );
            }
        }

        void link_Click(object sender, EventArgs e)
        {
            LinkLabel link = sender as LinkLabel;
            int tagId = (int)link.Tag;
            
            frmViewSurah f = new frmViewSurah();
            f.TageID = tagId;
            f.ShowDialog();
        }

        private void btnAddNewTag_Click(object sender, EventArgs e)
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

                byte[] tag_bangla = System.Text.Encoding.UTF8.GetBytes(txtNewTag.Text);
                query = "INSERT INTO tags (tag_bangla) VALUES (@tag_bangla)";
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@tag_bangla", tag_bangla);
                cmd.ExecuteNonQuery();
                btnReload.PerformClick();
                txtNewTag.Text = string.Empty;
            }

            //dbCon.Close();
        }

        private void linkSurah_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmSurahList f = new frmSurahList();
            
            int sid = -1;
            bool conv = Int32.TryParse(txtSurahID.Text,out sid);
            if (conv && sid>=1 && sid <=114) 
                f.SelectedSurahId = sid;
            
            f.ShowDialog();
            txtSurahID.Text = Convert.ToString(f.SelectedSurahId);

        }

        private void linkFullSurah_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmViewSurah f = new frmViewSurah();
            
            int sid = -1;
            bool conv = Int32.TryParse(txtSurahID.Text,out sid);
            if (conv && sid >= 1 && sid <= 114)
            {
                f.SurahID = sid;
                f.ShowDialog();
            }

        }
    }
}
