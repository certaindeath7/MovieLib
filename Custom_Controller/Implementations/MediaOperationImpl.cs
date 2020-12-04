using Custom_Controller.DTOs;
using Custom_Controller.Interfaces;
using Model;
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
    public class MediaOperationImpl : iMediaOperation
    {
        public int CastMediaId(string title)
        {
            //call the model reference
            iMediaManagement MediaAccess = new MediaManagementImpl();
            //create the Controller UserDTO
            MediaDTO Media = new MediaDTO();

            //Pass the value of ModelUserDTO to the Controller UserDTO
            Media.MediaID = MediaAccess.CastMediaId(title);
            return Media.MediaID;
        }

        public List<MediaDTO> ListAllMedia()
        {
            // call the model reference
            iMediaManagement MediaAccess = new MediaManagementImpl();
            // create a list of media
            // all the variables will be taken from Controller DTOs
            List<MediaDTO> ListOfMedia = new List<MediaDTO>();

            List<ModelMediaDTO> ListOfMediaFromModel = MediaAccess.BrowseAllMedia();

            foreach (ModelMediaDTO modelMedia in ListOfMediaFromModel)

            {
                ListOfMedia.Add(new MediaDTO(modelMedia.MediaID, modelMedia.Title, modelMedia.Genre, modelMedia.Director, modelMedia.Language, modelMedia.PublishYear, modelMedia.Budget));
            }

            return ListOfMedia;

        }
    }
}
