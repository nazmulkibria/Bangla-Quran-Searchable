using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Bangla_text_mysql.CustomControl
{
    public class MultilingualTextBox
    {
        private RichTextBox _thisMTBox;
        private int startCaret;

        public MultilingualTextBox(RichTextBox rtb)
        {
            _thisMTBox = rtb;
            _thisMTBox.Text = string.Empty;
            startCaret = 0;
        }

        private int colorIndex = 0;

        public void SetBullet()
        {
            _thisMTBox.BulletIndent = 10;
            _thisMTBox.SelectionBullet = true;
        }

        public void UnsetBullet()
        {
            _thisMTBox.SelectionBullet = false;
        }

        public void AddHyperLink()
        {
            LinkLabel link = new LinkLabel();
            link.Text = "something";
            //link.LinkClicked += new LinkLabelLinkClickedEventHandler(this.link_LinkClicked);
            LinkLabel.Link data = new LinkLabel.Link();
            data.LinkData = "http://www.google.com";
            link.Links.Add(data);
            link.AutoSize = true;
            link.Location = _thisMTBox.GetPositionFromCharIndex(_thisMTBox.TextLength);
            _thisMTBox.Controls.Add(link);
            _thisMTBox.AppendText(link.Text + "   ");
            _thisMTBox.SelectionStart = _thisMTBox.TextLength;
        }

        public void AddBanglaHeaderText(string banglaText)
        {
            banglaText = banglaText.Replace("।", "৷");

            _thisMTBox.AppendText(banglaText);
            _thisMTBox.SelectionStart = startCaret;
            _thisMTBox.SelectionLength = banglaText.Length;
            _thisMTBox.SelectionAlignment = HorizontalAlignment.Center;
            _thisMTBox.SelectionFont = new System.Drawing.Font("Vrinda", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            _thisMTBox.SelectionColor = Color.Magenta;

            startCaret += _thisMTBox.SelectionLength;
        }

        public void AddBanglaText(string banglaText)
        {
            banglaText = banglaText.Replace("।", "৷");

            _thisMTBox.AppendText( banglaText );
            _thisMTBox.SelectionStart = startCaret;
            _thisMTBox.SelectionLength = banglaText.Length;
            _thisMTBox.SelectionAlignment = HorizontalAlignment.Left;
            _thisMTBox.SelectionFont = new System.Drawing.Font("Vrinda", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            _thisMTBox.SelectionColor = Color.Green;

            startCaret += _thisMTBox.SelectionLength;
        }

        public void AddArabicText(string arabicText)
        {
            _thisMTBox.AppendText( arabicText );
            _thisMTBox.SelectionStart = startCaret;
            _thisMTBox.SelectionLength = arabicText.Length;
            _thisMTBox.SelectionAlignment = HorizontalAlignment.Right;
            //_thisMTBox.SelectionFont = new System.Drawing.Font("Simplified Arabic Fixed Regular", 30.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //_thisMTBox.SelectionFont = new System.Drawing.Font("Sakkal Majalla", 30.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            _thisMTBox.SelectionFont = new System.Drawing.Font("Traditional Arabic", 40.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            _thisMTBox.SelectionColor = Color.Red;

            startCaret += _thisMTBox.SelectionLength;
        }

        public void ClearText()
        {
            _thisMTBox.Text = string.Empty;
            startCaret = 0;
        }
    }
}
