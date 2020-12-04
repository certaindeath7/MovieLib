using Custom_Controller.Interfaces;
using Model.Implementations;
using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Controller.Implementations
{
    public class EditMediaImpl : iEditMedia
    {

        private iEditMediaModel CreateMediaManager = new EditMediaModelImpl();
        public bool CreateMedia(string title, int genre, int director, int language, int publishYear, decimal budget)
        {
            return CreateMediaManager.CreateMedia(title, genre, director, language, publishYear, budget);
        }

        public bool DeleteMedia(int mediaID)
        {
            return CreateMediaManager.DeleteMedia(mediaID);

        }

        public bool UpdateMedia(int mediaID, string title, int genreID, int directorID, int languageID, int publishYear, decimal budget)
        {
            return CreateMediaManager.UpdateMedia(mediaID, title, genreID, directorID, languageID, publishYear, budget);
        }
    }
}
