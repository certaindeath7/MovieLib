using Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Interfaces
{
    public interface iEditGenreModel
    {
        bool CreateGenre(string genreName);
        bool UpdateGenre(int genreID, string genreName);
        bool DeleteGenre(int genreID);

        List<ModelGenreDTO> PrintGenreList();
    }
}
