using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Bangla_text_mysql
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //DBUtility.UpdateWithUthmaniScript();//need once in lifetime
            //DBUtility.UpdateNoHarakatField();//need once in lifetime

            //DBUtility.UpdateWithSahihInteEn();

            //DBUtility.DropVirtualTable(); 
            //DBUtility.CreateVirtualTable();

            //ArabicNormalizer.Test();
            //Application.Run(new frmDataScraper());
            //Application.Run(new frmDataEntry());
            //Application.Run(new frmSurahList());
            //Application.Run(new frmAutoInsertAyatIndexing());
            
            Application.Run(new frmSearch());
            //Application.Run(new frmCompareScripts());
            
            //Application.Run(new frmTest());

            
        }
    }
}
