using Custom_Controller.DTOs;
using Custom_Controller.Interfaces;
using Model.DTOs;
using Model.Implementations;
using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Controller.Implementations
{
    public class EditLanguageImpl : iEditLanguage
    {
        private iEditLanguageModel DirectorEditManager = new EditLanguageModelImpl();
        public bool CreateLanguage(string languageName)
        {
            return DirectorEditManager.CreateLanguage(languageName);
        }

        public bool DeleteLanguage(int languageID)
        {
            return DirectorEditManager.DeleteLanguage(languageID);
        }

        public List<LanguageDTO> PrintLanguageList()
        {
            List<LanguageDTO> LanguageListController = new List<LanguageDTO>();
            List<ModelLanguageDTO> LanguageList = DirectorEditManager.PrintLanguageList();

            foreach (ModelLanguageDTO directorDTO in LanguageList)
            {
                LanguageListController.Add(new LanguageDTO(directorDTO.LID, directorDTO.LanguageName));
            }
            return LanguageListController;
        }

        public bool UpdateLanguage(int languageID, string languageName)
        {
            return DirectorEditManager.UpdateLanguage(languageID, languageName);
        }
    }
}
