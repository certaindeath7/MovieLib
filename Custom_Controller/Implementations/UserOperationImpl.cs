using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Controller
{
    public class UserOperationImpl : iUserOperation
    {


        public bool AddUser(string userName, string password, int userLevel, string email)
        {
            // call the model reference
            iUserManagement UserAuthentication = new UserManagementImpl();

            //Add user
            return UserAuthentication.AddUser(userName, password, userLevel, email);
        }

        public int Validate(string userName, string password)
        {
            //call the model reference
            iUserManagement UserAuthentication = new UserManagementImpl();
            
            //create the Controller UserDTO
            UserDTO User = new UserDTO(0);

            //Pass the value of ModelUserDTO to the Controller UserDTO
            User.UserLevel = UserAuthentication.UserLogin(userName, password);
            return User.UserLevel;
        }
        public int CastUserId(string userName)
        {
            //call the model reference
            iUserManagement UserAuthentication = new UserManagementImpl();

            //create the Controller UserDTO
            UserDTO User = new UserDTO(0);

            //Pass the value of ModelUserDTO to the Controller UserDTO
            User.UID = UserAuthentication.CastUserId(userName);
            return User.UID;
        }
    }
}
