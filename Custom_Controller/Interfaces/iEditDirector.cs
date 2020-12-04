using Custom_Controller.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Controller.Interfaces
{
    public interface iEditDirector
    {
        bool CreateDirector(string directorName);
        bool UpdateDirector(int directorID, string directorName);
        bool DeleteDirect(int directorID);
        List<DirectorDTO> PrintDirectorList();

    }
}
