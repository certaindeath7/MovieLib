using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Controller.DTOs
{
    public class LanguageDTO
    {
        public int LID { get; set; }
        public string LanguageName { get; set; }

        public LanguageDTO(string languageName)
        {
            this.LanguageName = languageName;
        }

        public LanguageDTO(int languageID, string languageName)
        {
            this.LID = languageID;
            this.LanguageName = languageName;
        }
    }
}
