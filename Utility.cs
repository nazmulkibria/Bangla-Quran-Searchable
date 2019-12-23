using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.CodeDom.Compiler;
using System.CodeDom;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using Bangla_text_mysql.Core;

namespace Bangla_text_mysql
{
    public class Utility
    {
        private static char[] banglaNumbers = { '০', '১', '২', '৩', '৪', '৫', '৬', '৭', '৮', '৯' };
        private static char[] engNumbers = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        //private static string arabicNumbers = "٠‎ ١‎ ٢‎ ٣‎ ٤‎ ٥‎ ٦‎ ٧‎ ٨‎ ٩‎";
        private static char[] arabicNumbers = { '٠', '١', '٢', '٣', '٤', '٥', '٦', '٧', '٨', '٩' };

        private static string vowels = "া ি ী ু ূ ৃ ে ৈ ো ৌ";

        public static bool IsSurahAndAyat(string search)
        {
            var arr = search.ToCharArray();

            char[] chars = { ':', '-', ' ' };

            if (!arr.Contains(chars[0]) || !arr.Contains(chars[1]))
                return false;

            bool containNumbers = false;

            foreach (char c in arr)
            {
                bool isNumbers = banglaNumbers.Contains(c) || engNumbers.Contains(c) || arabicNumbers.Contains(c);
 
                if (isNumbers)
                    containNumbers = true;

                bool found = isNumbers || chars.Contains(c);

                if (!found)
                    return false;
            }

            if (!containNumbers) return false;
            return true;
        }

        public static List<SearchSurahAyat> ParseSurahAyatSearch(string search)
        {
            var arr = search.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            List<SearchSurahAyat> slist = new List<SearchSurahAyat>();

            foreach (var s in arr)
            {
                SearchSurahAyat ss = new SearchSurahAyat() { SurahID = -1, AyatStartID = -1, AyatEndID = -1 };

                var surahId = s.Split(new[] { ":" }, StringSplitOptions.RemoveEmptyEntries);
                var ayatId = surahId.Length == 1 ? null : surahId[1].Split(new[] { "-" }, StringSplitOptions.RemoveEmptyEntries);

                int a = -1;
                if (surahId.Length > 0)
                {
                    if (Int32.TryParse(surahId[0], out a))
                        ss.SurahID = a;

                }

                a = -1;
                if (ayatId != null && ayatId.Length > 0)
                {
                    if (Int32.TryParse(ayatId[0], out a))
                        ss.AyatStartID = a;
                }

                a = -1;
                if (ayatId != null && ayatId.Length > 1)
                {
                    if (Int32.TryParse(ayatId[1], out a))
                        ss.AyatEndID = a;
                }

                if (ss.SurahID >= 1 && ss.SurahID <= 114 &&  ss.AyatStartID >= 1 && ss.AyatStartID <= DBUtility.surahMaxAyatList[ss.SurahID] && ss.AyatEndID >= ss.AyatStartID)
                    slist.Add(ss);
            }

            return slist;
        }

        public static string ToConvertEnglishNumber(string number)
        {
            string outEnglish = string.Empty;

            foreach (char c in number.ToCharArray())
            {
                if (banglaNumbers.Contains(c))
                {
                    int index = banglaNumbers.ToList().FindIndex(cc => cc == c);
                    outEnglish += engNumbers[index];
                }
                else if (arabicNumbers.Contains(c))
                {
                    int index = arabicNumbers.ToList().FindIndex(cc => cc == c);
                    outEnglish += engNumbers[index];
                }
                else
                    outEnglish += c;
            }

            return outEnglish;
        }

        public static string ToConvertBanglaNumber(int number)
        {
            string outBangla = string.Empty;
            string english = Convert.ToString(number);

            foreach (char c in english.ToCharArray())
            {
                int n = Convert.ToInt32(c) - 48;
                outBangla += banglaNumbers[n];
            }

            return outBangla;
        }

        public static string ToConvertArabicNumber(int number)
        {
            //var ar = arabicNumbers.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            string outArabic = string.Empty;
            string english = Convert.ToString(number);

            foreach (char c in english.ToCharArray())
            {
                int n = Convert.ToInt32(c) - 48;
                outArabic += arabicNumbers[n];
            }

            return outArabic;
        }


        public static string[] GetFixerVowels(bool withSpaceAdded)
        {
            string[] vowelsSplit = vowels.Split(new[] { " " }, StringSplitOptions.None);

            if (!withSpaceAdded)
                return vowelsSplit;

            for (int i = 0; i < vowelsSplit.Length; i++)
                vowelsSplit[i] = " " + vowelsSplit[i];

            return vowelsSplit;
        }

        public static string FixerVowelDisplacement(string txt)
        {
            string[] vowelsSearchWith = GetFixerVowels(true);
            string[] vowelsRepWith = GetFixerVowels(false);

            for (int i = 0; i < vowelsSearchWith.Length; i++)
            {
                txt = txt.Replace(vowelsSearchWith[i], vowelsRepWith[i]);
            }

            return txt;
        }

        public static string ToLiteral(string input)
        {
            return input.Replace("\'", "\\'");
        }

        public static void HighlightText(RichTextBox myRtb, string word, Color color)
        {

            if (word == string.Empty)
                return;

            //word = ArabicNormalizer.normalize(word);

            Color backup = myRtb.SelectionColor;

            int s_start = myRtb.SelectionStart, startIndex = 0, index;

            //string rtbTxt = ArabicNormalizer.normalize(myRtb.Text);
            string rtbTxt = myRtb.Text.ToLower();

            while ((index = rtbTxt.IndexOf(word.ToLower(), startIndex)) != -1)
            {
                myRtb.Select(index, word.Length);
                myRtb.SelectionColor = color;
                myRtb.SelectionBackColor = Color.Yellow;
                startIndex = index + word.Length;
            }

            myRtb.SelectionStart = s_start;
            myRtb.SelectionLength = 0;
            myRtb.SelectionColor = backup;
        }


        public static bool isInteger(string numberStr, ref int number)
        {
            int n;
            bool isNumeric = int.TryParse(numberStr, out n);
            number = isNumeric ? n : number;
            return isNumeric;

        }
    }
}
