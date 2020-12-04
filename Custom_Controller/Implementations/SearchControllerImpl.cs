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
    public class SearchControllerImpl : iSearchController
    {
        public List<MediaDTO> MediaSearcFunction(MediaDTO media)
        {
            // call the model reference
            iSearchModel SearchEngine = new SearchMediaImpl();
            // create a list of media
            // all the variables will be taken from Controller DTOs
            List<MediaDTO> ListOfSearch = new List<MediaDTO>();

            ModelMediaDTO mediaDTOfromModel = new ModelMediaDTO(media.MediaID, media.Title, media.Genre, media.Director, media.Language, media.PublishYear, media.Budget);
            List<ModelMediaDTO> ListOfMediaFromModel = SearchEngine.MediaSearch(mediaDTOfromModel);

            foreach (ModelMediaDTO modelMedia in ListOfMediaFromModel)

            {
                ListOfSearch.Add(new MediaDTO(modelMedia.MediaID, modelMedia.Title, modelMedia.Genre, modelMedia.Director, modelMedia.Language, modelMedia.PublishYear, modelMedia.Budget));
            }

            return ListOfSearch;
        }

        
    }
}
