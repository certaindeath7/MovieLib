using Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Interfaces
{
    public interface iMediaManagement
    {
        List<ModelMediaDTO> BrowseAllMedia();

        int CastMediaId(string title);
    }
}
