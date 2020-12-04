using Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Interfaces
{
    public interface iEditDirectorModel
    {
        bool CreateDirector( string directorName);
        bool UpdateDirector(int directorID, string directorName);
        bool DeleteDirect(int directorID);

        List<ModelDirectorDTO> PrintDirectorList();
    }
}
