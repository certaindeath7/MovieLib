using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace View.Models
{
    public class User
    {
        // variable initialization
        public int UserLevel { get; set; }
        public int UID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        // constructor
        public User(int userID, string userName, string password, int userLevel, string email)
        {
            this.UID = userID;
            this.UserName = userName;
            this.Password = password;
            this.UserLevel = userLevel;
            this.Email = email;
        }

        public User(string userName, string password)
        {
            this.UserName = userName;
            this.Password = password;
            
        }
    }
}