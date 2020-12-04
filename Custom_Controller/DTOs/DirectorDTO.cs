using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Controller.DTOs
{
    public class DirectorDTO
    {
        public int DID { get; set; }

        public string DirectorName { get; set; }
        public DirectorDTO(string directorName)
        {
            this.DirectorName = directorName;
        }
        public DirectorDTO(int directorID, string directorName)
        {
            this.DID = directorID;
            this.DirectorName = directorName;
        }
    }
}
