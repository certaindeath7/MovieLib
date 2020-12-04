using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface iUserManagement
    {
        int UserLogin(string userName, string password);
        bool AddUser(string userName, string password, int userLevel, string email);

        int CastUserId(string userName);

       


    }
}
