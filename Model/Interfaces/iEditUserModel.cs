using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Interfaces
{
    public interface iEditUserModel
    {
        bool CreateUser(string userName, string password, int userLevel, string email);
        bool UpdateUser(int userID, string username, string password, int userLevel, string email);
        bool DeleteUser(int userID);

        List<ModelUserDTO> ListAllUser();
    }
}
