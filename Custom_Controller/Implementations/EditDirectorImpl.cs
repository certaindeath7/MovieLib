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
    public class EditDirectorImpl : iEditDirector
    {
        private iEditDirectorModel DirectorEditManager = new EditDirectorModelImpl();
        public bool CreateDirector(string directorName)
        {
            return DirectorEditManager.CreateDirector(directorName);
        }

        public bool DeleteDirect(int directorID)
        {
            return DirectorEditManager.DeleteDirect(directorID);
        }

        public List<DirectorDTO> PrintDirectorList()
        {
            
            List<DirectorDTO> DirectorListController = new List<DirectorDTO>();
            List<ModelDirectorDTO> DirectorList = DirectorEditManager.PrintDirectorList();

            foreach (ModelDirectorDTO directorDTO in DirectorList)
            {
                DirectorListController.Add(new DirectorDTO(directorDTO.DID, directorDTO.DirectorName));
            }
            return DirectorListController;
        }

        public bool UpdateDirector(int directorID, string directorName)
        {
            return DirectorEditManager.UpdateDirector(directorID, directorName);
        }


    }
}
