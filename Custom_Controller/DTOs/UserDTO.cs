using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Controller
{
    public class UserDTO
    {
        // variable initialization
        public int UserLevel { get; set; }
        public int UID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

       // constructor
       public UserDTO(int userID, string userName, string password, int userLevel, string email)
        {
            this.UID = userID;
            this.UserName = userName;
            this.Password = password;
            this.UserLevel = userLevel;
            this.Email = email;

        }

        public UserDTO( string userName, string password)
        {
            this.UserName = userName;
            this.Password = password;
            
        }

        public UserDTO(int userLevel)
        {
            this.UserLevel = userLevel;
        }

    }
}
