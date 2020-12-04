using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace View.Models
{
    public class Director
    {
        public int DID { get; set; }

        public string DirectorName { get; set; }
        public Director(string directorName)
        {
            this.DirectorName = directorName;
        }
        public Director(int directorID, string directorName)
        {
            this.DID = directorID;
            this.DirectorName = directorName;
        }
    }
}