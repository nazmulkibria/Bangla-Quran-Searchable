using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Bangla_text_mysql
{
    public class ArabicNormalizer
    {

        /**
         * ArabicNormalizer constructor
         * @param input String
         */
        private ArabicNormalizer()
        {

        }

        private static string SpecialNormalize(string script)
        {
            script = script.Replace("ٱ", "ا");
            script = script.Replace("أ", "ا");
            script = script.Replace("إ", "ا");
            script = script.Replace("آ", "ا");
            script = script.Replace("\uFE80", "");//isolated hamza 0xFE80
            script = script.Replace("\u0621", "");//isolated hamza 0x0621
            script = script.Replace("\u06C3", "\u0629");//0x06C3 0x0629 ta marbuta fixing ...indo to uthmani
            
            //script = script.Replace("ي", "ى");
            //script = script.Replace("ی", "ى");

            script = script.Replace("ى", "ي");
            script = script.Replace("\u06CC", "ي");

            script = script.Replace("ہ", "ه");
            script = script.Replace(" ٭ۙ", "");
            script = script.Replace("ک", "ك");
            //script = script.Replace("ا", "");
            
            return script;
        }

        public static List<int> AllIndexesOf(string str, char c)
        {
            var foundIndexes = new List<int>();
            for (int i = str.IndexOf(c); i > -1; i = str.IndexOf(c, i + 1))
            {
                foundIndexes.Add(i);
            }

            return foundIndexes;
        }

        /**
         * normalize Method
         * @return String
         */
        public static string normalize(string input)
        {

            input = input.Replace("\uFC5E", "");//ARABIC LIGATURE SHADDA WITH DAMMATAN ISOLATED FORM	ﱞ
            input = input.Replace("\uFC5F", "");//ARABIC LIGATURE SHADDA WITH KASRATAN ISOLATED FORM	ﱟ
            input = input.Replace("\uFC60", "");//ARABIC LIGATURE SHADDA WITH FATHA ISOLATED FORM	ﱠ
            input = input.Replace("\uFC61", "");//ARABIC LIGATURE SHADDA WITH DAMMA ISOLATED FORM	ﱡ
            input = input.Replace("\uFC62", "");//ARABIC LIGATURE SHADDA WITH KASRA ISOLATED FORM	ﱢ
            input = input.Replace("\uFC63", "");//ARABIC LIGATURE SHADDA WITH SUPERSCRIPT ALEF ISOLATED FORM

            //Remove honorific sign
            input = input.Replace("\u0610", "");//ARABIC SIGN SALLALLAHOU ALAYHE WA SALLAM
            input = input.Replace("\u0611", "");//ARABIC SIGN ALAYHE ASSALLAM
            input = input.Replace("\u0612", "");//ARABIC SIGN RAHMATULLAH ALAYHE
            input = input.Replace("\u0613", "");//ARABIC SIGN RADI ALLAHOU ANHU
            input = input.Replace("\u0614", "");//ARABIC SIGN TAKHALLUS

            //Remove koranic anotation
            input = input.Replace("\u0615", "");//ARABIC SMALL HIGH TAH
            input = input.Replace("\u0616", "");//ARABIC SMALL HIGH LIGATURE ALEF WITH LAM WITH YEH
            input = input.Replace("\u0617", "");//ARABIC SMALL HIGH ZAIN
            input = input.Replace("\u0618", "");//ARABIC SMALL FATHA
            input = input.Replace("\u0619", "");//ARABIC SMALL DAMMA
            input = input.Replace("\u061A", "");//ARABIC SMALL KASRA
            input = input.Replace("\u06D6", "");//ARABIC SMALL HIGH LIGATURE SAD WITH LAM WITH ALEF MAKSURA
            input = input.Replace("\u06D7", "");//ARABIC SMALL HIGH LIGATURE QAF WITH LAM WITH ALEF MAKSURA
            input = input.Replace("\u06D8", "");//ARABIC SMALL HIGH MEEM INITIAL FORM
            input = input.Replace("\u06D9", "");//ARABIC SMALL HIGH LAM ALEF
            input = input.Replace("\u06DA", "");//ARABIC SMALL HIGH JEEM
            input = input.Replace("\u06DB", "");//ARABIC SMALL HIGH THREE DOTS
            input = input.Replace("\u06DC", "");//ARABIC SMALL HIGH SEEN
            input = input.Replace("\u06DD", "");//ARABIC END OF AYAH
            input = input.Replace("\u06DE", "");//ARABIC START OF RUB EL HIZB
            input = input.Replace("\u06DF", "");//ARABIC SMALL HIGH ROUNDED ZERO
            input = input.Replace("\u06E0", "");//ARABIC SMALL HIGH UPRIGHT RECTANGULAR ZERO
            input = input.Replace("\u06E1", "");//ARABIC SMALL HIGH DOTLESS HEAD OF KHAH
            input = input.Replace("\u06E2", "");//ARABIC SMALL HIGH MEEM ISOLATED FORM
            input = input.Replace("\u06E3", "");//ARABIC SMALL LOW SEEN
            input = input.Replace("\u06E4", "");//ARABIC SMALL HIGH MADDA
            input = input.Replace("\u06E5", "");//ARABIC SMALL WAW
            input = input.Replace("\u06E6", "");//ARABIC SMALL YEH
            input = input.Replace("\u06E7", "");//ARABIC SMALL HIGH YEH
            input = input.Replace("\u06E8", "");//ARABIC SMALL HIGH NOON
            input = input.Replace("\u06E9", "");//ARABIC PLACE OF SAJDAH
            input = input.Replace("\u06EA", "");//ARABIC EMPTY CENTRE LOW STOP
            input = input.Replace("\u06EB", "");//ARABIC EMPTY CENTRE HIGH STOP
            input = input.Replace("\u06EC", "");//ARABIC ROUNDED HIGH STOP WITH FILLED CENTRE
            input = input.Replace("\u06ED", "");//ARABIC SMALL LOW MEEM

            //Remove tatweel
            input = input.Replace("\u0640", "");

            //Remove tashkeel
            input = input.Replace("\u064B", "");//ARABIC FATHATAN
            input = input.Replace("\u064C", "");//ARABIC DAMMATAN
            input = input.Replace("\u064D", "");//ARABIC KASRATAN
            input = input.Replace("\u064E", "");//ARABIC FATHA
            input = input.Replace("\u064F", "");//ARABIC DAMMA
            input = input.Replace("\u0650", "");//ARABIC KASRA
            input = input.Replace("\u0651", "");//ARABIC SHADDA
            input = input.Replace("\u0652", "");//ARABIC SUKUN
            input = input.Replace("\u0653", "");//ARABIC MADDAH ABOVE
            input = input.Replace("\u0654", "");//ARABIC HAMZA ABOVE
            input = input.Replace("\u0655", "");//ARABIC HAMZA BELOW
            input = input.Replace("\u0656", "");//ARABIC SUBSCRIPT ALEF
            input = input.Replace("\u0657", "");//ARABIC INVERTED DAMMA
            input = input.Replace("\u0658", "");//ARABIC MARK NOON GHUNNA
            input = input.Replace("\u0659", "");//ARABIC ZWARAKAY
            input = input.Replace("\u065A", "");//ARABIC VOWEL SIGN SMALL V ABOVE
            input = input.Replace("\u065B", "");//ARABIC VOWEL SIGN INVERTED SMALL V ABOVE
            input = input.Replace("\u065C", "");//ARABIC VOWEL SIGN DOT BELOW
            input = input.Replace("\u065D", "");//ARABIC REVERSED DAMMA
            input = input.Replace("\u065E", "");//ARABIC FATHA WITH TWO DOTS
            input = input.Replace("\u065F", "");//ARABIC WAVY HAMZA BELOW



            //input = input.Replace("\u0670", "");//ARABIC LETTER SUPERSCRIPT ALEF
            //input = input.Replace("\u0670", "ا");

            
            input = SpecialNormalize(input);

            List<int> indexes = AllIndexesOf(input, '\u0670');

            if (indexes.Count > 0)
            {
                StringBuilder sb = new StringBuilder(input);
                for (int i = 0; i < indexes.Count; i++)
                {
                    int idx = indexes[i];
                    if (idx + 1 < input.Length)
                    {
                        if (idx >= 2 && input.ElementAt(idx + 1) == '\u0647' && input.ElementAt(idx - 1) == '\u0644' && input.ElementAt(idx - 2) == '\u0644')/*Allah word*/ 
                        {
                        }
                        else if (
                            input.ElementAt(idx + 1) != 'ى' 
                           )
                        {
                            sb[idx] = 'ا';
                        }
                    }
                }
                input = sb.ToString();

            }

            input = input.Replace("\u0670", "");//ARABIC LETTER SUPERSCRIPT ALEF

            input = input.Replace("و ", "و");
            input = input.Replace("اا", "ا");
            input = input.Replace("٭","");
            input = input.Replace("  ", " ");

            return input;
        }

        /**
         * @return the output
         */
        public static void Test()
        {
            String test = "كَلَّا لَا تُطِعْهُ وَاسْجُدْ وَاقْتَرِبْ ۩";
            MessageBox.Show("Before: " + test);
            test = normalize(test);
            MessageBox.Show("After: " + test);
        }
    }

}
