using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTOs
{
    public class ModelGenreDTO
    {
        public int GID { get; set; }

        public string GenreName { get; set; }

        public ModelGenreDTO(string genreName)
        {
            this.GenreName = genreName;
        }
        public ModelGenreDTO(int gID, string genreName)
        {
            this.GID = gID;
            this.GenreName = genreName;
        }
    }
}
