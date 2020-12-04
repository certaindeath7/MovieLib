using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace View.Models
{
    public class Genre
    {
        public int GID { get; set; }

        public string GenreName { get; set; }

        public Genre(string genreName)
        {
            this.GenreName = genreName;
        }
        public Genre(int gID, string genreName)
        {
            this.GID = gID;
            this.GenreName = genreName;
        }
    }
}