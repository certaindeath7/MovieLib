using Custom_Controller.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Controller.Interfaces
{
    public interface iCreate
    {
        bool CreateMediaController(string title, string genre, string director, string language, int publishYear, decimal budget);
        bool CreateGenreController(string genreName);
        bool CreateDirectorController(string directorName);
        bool CreateLanguageController(string languageName);
    }
}
