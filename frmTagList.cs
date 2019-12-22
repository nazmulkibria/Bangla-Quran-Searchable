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
using Bangla_text_mysql.Core;
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

        private List<Tag> Tags = new List<Tag>();

        public frmTagList()
        {
            InitializeComponent();
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            if (listBoxTags.SelectedIndex >= 0)
            {
                SelectedTagId = Tags[ listBoxTags.SelectedIndex ] .tag_id;
                SelectedTagString = Tags[listBoxTags.SelectedIndex].tag_bangla;
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void LoadTags()
        {
            listBoxTags.Items.Clear();
            Tags.Clear();
            Tags.AddRange(DB_tag_processor.GetTags());

            foreach (var tag in Tags)
                listBoxTags.Items.Add(tag.tag_bangla);

        }

        private void AddBlackBorder()
        {
            Panel panel = new Panel();
            panel.BackColor = this.BackColor;
            panel.Size = new System.Drawing.Size(this.Size.Width - 2, this.Size.Height - 2);
            panel.Location = new Point(1, 1);
            this.Controls.Remove(listBoxTags);
            panel.Controls.Add(listBoxTags);
            this.Controls.Add(panel);
            this.BackColor = Color.Gray;
        }

        private void frmSurahList_Load(object sender, EventArgs e)
        {
            AddBlackBorder();
            LoadTags();

            if (listBoxTags.Items.Count > 0)
                listBoxTags.SelectedIndex = 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
