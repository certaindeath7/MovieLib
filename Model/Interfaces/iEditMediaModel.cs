using Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Interfaces
{
    public interface iEditMediaModel
    {
        bool CreateMedia(string title, int genre, int director, int language, int publishYear, decimal budget);
        bool UpdateMedia(int mediaID ,string title, int genreID, int directorID, int languageID, int publishYear, decimal budget);
        bool DeleteMedia(int mediaID);
        
    }
}
