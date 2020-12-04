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

    public class EditGenreImpl : iEditGenre
    {
        private iEditGenreModel GenreEditManager = new EditGenreModelImpl();

        public bool CreateGenre(string genreName)
        {
            return GenreEditManager.CreateGenre(genreName);
        }

        public bool DeleteGenre(int genreID)
        {
            return GenreEditManager.DeleteGenre(genreID);
        }

        public List<GenreDTO> PrintGenreList()
        {
            List<GenreDTO> GenreListController = new List<GenreDTO>();
            List<ModelGenreDTO> GenreList = GenreEditManager.PrintGenreList();

            foreach (ModelGenreDTO directorDTO in GenreList)
            {
                GenreListController.Add(new GenreDTO(directorDTO.GID, directorDTO.GenreName));
            }
            return GenreListController;
        }

        public bool UpdateGenre(int genreID, string genreName)
        {
            return GenreEditManager.UpdateGenre(genreID, genreName);
        }
    }
}
