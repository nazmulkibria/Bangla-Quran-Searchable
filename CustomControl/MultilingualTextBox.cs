using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Bangla_text_mysql.CustomControl
{
    public class MultilingualTextBox
    {
        public static string ArabicFontName = "Arabic Typesetting";//"kfgqpc uthman taha naskh";//"Traditional Arabic"
        public static string BanglaFontName = "Vrinda";//"Shonar Bangla";//"Vrinda";//"kalpurush";//

        private Font ArabicNormalFont = new System.Drawing.Font(ArabicFontName, 40.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        private Font ArabicHeaderFont = new System.Drawing.Font(ArabicFontName, 30.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        private Font ArabicSpecialFont = new System.Drawing.Font(ArabicFontName, 25.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

        private Font BanglaNormalFont = new System.Drawing.Font(BanglaFontName, 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        private Font BanglaHeaderFont = new System.Drawing.Font(BanglaFontName, 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        private Font BanglaSpecialFont = new System.Drawing.Font(BanglaFontName, 20.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

        private Color arabicColor = Color.DarkSlateBlue;
        private Color banglaColor = Color.Green;

        public Action<string> SearchWithText = null;

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
            //_thisMTBox.ScrollToCaret();
        }

        public void AddBanglaHeaderText(string banglaText)
        {
            banglaText = banglaText.Replace("।", "৷");
            banglaText = banglaText.Replace("_", "-");

            _thisMTBox.AppendText(banglaText);
            _thisMTBox.SelectionStart = startCaret;
            _thisMTBox.SelectionLength = banglaText.Length;
            _thisMTBox.SelectionAlignment = HorizontalAlignment.Center;
            _thisMTBox.SelectionFont = BanglaHeaderFont;
            _thisMTBox.SelectionColor = Color.Magenta;

            startCaret += _thisMTBox.SelectionLength;

            //_thisMTBox.ScrollToCaret();
        }

        public void AddArabicHeaderText(string arabicText)
        {
            _thisMTBox.AppendText(arabicText);
            _thisMTBox.SelectionStart = startCaret;
            _thisMTBox.SelectionLength = arabicText.Length;
            _thisMTBox.SelectionAlignment = HorizontalAlignment.Center;
            _thisMTBox.SelectionFont = ArabicHeaderFont;
            _thisMTBox.SelectionColor = Color.Magenta;

            startCaret += _thisMTBox.SelectionLength;

            //_thisMTBox.ScrollToCaret();
        }

        public void AddBanglaText(string banglaText)
        {
            banglaText = banglaText.Replace("।", "৷");
            banglaText = banglaText.Replace("_", "-");

            _thisMTBox.AppendText(banglaText);
            _thisMTBox.SelectionStart = startCaret;
            _thisMTBox.SelectionLength = banglaText.Length;
            _thisMTBox.SelectionAlignment = HorizontalAlignment.Left;
            _thisMTBox.SelectionFont = BanglaNormalFont;
            _thisMTBox.SelectionColor = banglaColor;

            startCaret += _thisMTBox.SelectionLength;

            //_thisMTBox.ScrollToCaret();
        }

        public void AddSpecialText(string banglaText, bool isArabic = false)
        {

            _thisMTBox.AppendText(banglaText);
            _thisMTBox.SelectionStart = startCaret;
            _thisMTBox.SelectionLength = banglaText.Length;


            if (isArabic)
            {

                _thisMTBox.SelectionAlignment = HorizontalAlignment.Right;
                //Traditional Arabic
                _thisMTBox.SelectionFont = ArabicSpecialFont;

            }
            else
            {
                _thisMTBox.SelectionAlignment = HorizontalAlignment.Left;
                _thisMTBox.SelectionFont = BanglaSpecialFont;

            }

            _thisMTBox.SelectionColor = Color.DarkBlue;

            startCaret += _thisMTBox.SelectionLength;

            //_thisMTBox.ScrollToCaret();
        }

        public void AddArabicText(string arabicText)
        {
            _thisMTBox.AppendText(arabicText);
            _thisMTBox.SelectionStart = startCaret;
            _thisMTBox.SelectionLength = arabicText.Length;
            _thisMTBox.SelectionAlignment = HorizontalAlignment.Right;
            _thisMTBox.SelectionFont = ArabicNormalFont;
            _thisMTBox.SelectionColor = arabicColor;

            startCaret += _thisMTBox.SelectionLength;

            //_thisMTBox.ScrollToCaret();
        }


        public void ClearText()
        {
            _thisMTBox.Text = string.Empty;
            startCaret = 0;
        }

        public string GetText()
        {
            if (_thisMTBox == null) return string.Empty;

            return _thisMTBox.Text;
        }

        public void AddContextMenu()
        {
            RichTextBox rtb = _thisMTBox;

            if (rtb.ContextMenuStrip == null)
            {
                ContextMenuStrip cms = new ContextMenuStrip()
                {
                    ShowImageMargin = false
                };

                /*ToolStripMenuItem tsmiUndo = new ToolStripMenuItem("Undo");
                tsmiUndo.Click += (sender, e) => rtb.Undo();
                cms.Items.Add(tsmiUndo);

                ToolStripMenuItem tsmiRedo = new ToolStripMenuItem("Redo");
                tsmiRedo.Click += (sender, e) => rtb.Redo();
                cms.Items.Add(tsmiRedo);

                cms.Items.Add(new ToolStripSeparator());

                ToolStripMenuItem tsmiCut = new ToolStripMenuItem("Cut");
                tsmiCut.Click += (sender, e) => rtb.Cut();
                cms.Items.Add(tsmiCut);
                */
                ToolStripMenuItem tsmiCopy = new ToolStripMenuItem("Copy");
                tsmiCopy.Click += (sender, e) => rtb.Copy();
                cms.Items.Add(tsmiCopy);

                //ToolStripMenuItem tsmiPaste = new ToolStripMenuItem("Paste");
                //tsmiPaste.Click += (sender, e) => rtb.Paste();
                //cms.Items.Add(tsmiPaste);

                ToolStripMenuItem tsmiSearch = new ToolStripMenuItem("Search");
                tsmiSearch.Click += (sender, e) => { if (SearchWithText != null) { SearchWithText(rtb.SelectedText); } };
                cms.Items.Add(tsmiSearch);

                
                /*
                ToolStripMenuItem tsmiDelete = new ToolStripMenuItem("Delete");
                tsmiDelete.Click += (sender, e) => rtb.SelectedText = "";
                cms.Items.Add(tsmiDelete);

                cms.Items.Add(new ToolStripSeparator());

                ToolStripMenuItem tsmiSelectAll = new ToolStripMenuItem("Select All");
                tsmiSelectAll.Click += (sender, e) => rtb.SelectAll();
                cms.Items.Add(tsmiSelectAll);
                */

                cms.Opening += (sender, e) =>
                {
                    //tsmiUndo.Enabled = !rtb.ReadOnly && rtb.CanUndo;
                    //tsmiRedo.Enabled = !rtb.ReadOnly && rtb.CanRedo;
                    //tsmiCut.Enabled = !rtb.ReadOnly && rtb.SelectionLength > 0;
                    tsmiSearch.Enabled = rtb.SelectionLength > 0;
                    tsmiCopy.Enabled = rtb.SelectionLength > 0;
                    //tsmiPaste.Enabled = !rtb.ReadOnly && Clipboard.ContainsText();
                    //tsmiDelete.Enabled = !rtb.ReadOnly && rtb.SelectionLength > 0;
                    //tsmiSelectAll.Enabled = rtb.TextLength > 0 && rtb.SelectionLength < rtb.TextLength;
                };

                rtb.ContextMenuStrip = cms;
            }
        }
    }
}
