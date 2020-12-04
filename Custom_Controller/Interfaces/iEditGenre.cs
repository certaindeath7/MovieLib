using Custom_Controller.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Controller.Interfaces
{
    public interface iEditGenre
    {
        bool CreateGenre(string genreName);
        bool UpdateGenre(int genreID, string genreName);
        bool DeleteGenre(int genreID);

        List<GenreDTO> PrintGenreList();
    }
}
