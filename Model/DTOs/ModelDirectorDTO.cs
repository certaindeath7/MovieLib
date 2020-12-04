using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTOs
{
    public class ModelDirectorDTO
    {
        public int DID { get; set; }

        public string DirectorName { get; set; }
        
        public ModelDirectorDTO(string directorName)
        {
            this.DirectorName = directorName;
        }
        public ModelDirectorDTO(int directorID, string directorName)
        {
            this.DID = directorID;
            this.DirectorName = directorName;
        }
   
    }
}
