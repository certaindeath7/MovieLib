using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Controller
{
    public interface iUserOperation
    {
        int Validate(string userName, string password);
        bool AddUser(string userName, string password, int userLevel, string email);
        int CastUserId(string userName);

    }
}
