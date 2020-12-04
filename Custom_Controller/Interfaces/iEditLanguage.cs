using Custom_Controller.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Controller.Interfaces
{
    public interface iEditLanguage
    {
        bool CreateLanguage(string languageName);
        bool UpdateLanguage(int languageID, string languageName);
        bool DeleteLanguage(int languageID);

        List<LanguageDTO> PrintLanguageList();
    }
}
