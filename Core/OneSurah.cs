using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bangla_text_mysql.Core
{
    public enum SurahTypes { MAKKI, MADANI};

    public class OneSurah
    {
        private List<OneAyat> _TheAyatList;

        public string SurahName { get; set; }
        public SurahTypes SurahType { get; set; } 
        public int TotalAyat { get; set; }
        public int SurahID { get; set; }
        public List<OneAyat> AyatList { get; private set; }

        public OneSurah()
        {
            _TheAyatList = new List<OneAyat>();
            AyatList = _TheAyatList;
        }
    }
}
