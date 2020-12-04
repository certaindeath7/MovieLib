using Custom_Controller.Interfaces;
using Model;
using Model.Implementations;
using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Controller.Implementations
{
    public class EditUserImpl : iEditUser
    {
        private iEditUserModel UserManager = new EditUserModelImpl();
        public bool CreateUser(string userName, string password, int userLevel, string email)
        {
            return UserManager.CreateUser(userName, password, userLevel, email);
        }

        public bool DeleteUser(int userID)
        {
            return UserManager.DeleteUser(userID);
        }

        public List<UserDTO> ListAllUser()
        {
            List<UserDTO> UserListController = new List<UserDTO>();
            List<ModelUserDTO> GenreList = UserManager.ListAllUser();

            foreach (ModelUserDTO userDTO in GenreList)
            {
                UserListController.Add(new UserDTO(userDTO.UID, userDTO.UserName, userDTO.Password, userDTO.UserLevel, userDTO.Email));
            }
            return UserListController;
        }

        public bool UpdateUser(int userID, string username, string password, int userLevel, string email)
        {
            throw new NotImplementedException();
        }
    }
}
