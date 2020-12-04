using Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Interfaces
{
    public interface iSearchModel
    {
        List<ModelMediaDTO> MediaSearch(ModelMediaDTO modelMedia);
      

    }
}
