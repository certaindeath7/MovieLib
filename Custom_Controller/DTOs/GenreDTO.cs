using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Controller.DTOs
{
    public class GenreDTO
    {
        public int GID { get; set; }

        public string GenreName { get; set; }

        public GenreDTO(string genreName)
        {
            this.GenreName = genreName;
        }
        public GenreDTO(int gID, string genreName)
        {
            this.GID = gID;
            this.GenreName = genreName;
        }
    }
}
