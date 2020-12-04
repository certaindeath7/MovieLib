using Custom_Controller.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Controller.Interfaces
{
    public interface iSearchController
    {
        List<MediaDTO> MediaSearcFunction(MediaDTO modelMedia);
    }
}
