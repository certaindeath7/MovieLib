using Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Interfaces
{
    public interface iEditLanguageModel
    {
        bool CreateLanguage(string languageName);
        bool UpdateLanguage(int languageID, string languageName);
        bool DeleteLanguage(int languageID);

        List<ModelLanguageDTO> PrintLanguageList();
    }
}
