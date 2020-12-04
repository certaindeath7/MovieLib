using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTOs
{
    public class ModelLanguageDTO
    {
        public int LID { get; set; }
        public string LanguageName { get; set; }

        public ModelLanguageDTO(string languageName)
        {
            this.LanguageName = languageName;
        }

        public ModelLanguageDTO(int languageID ,string languageName)
        {
            this.LID = languageID;
            this.LanguageName = languageName;
        }
    }
}
