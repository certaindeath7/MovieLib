using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace View.Models
{
    public class Language
    {

        public int LID { get; set; }
        public string LanguageName { get; set; }

        public Language(string languageName)
        {
            this.LanguageName = languageName;
        }

        public Language(int languageID, string languageName)
        {
            this.LID = languageID;
            this.LanguageName = languageName;
        }
    }
}