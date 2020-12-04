using Custom_Controller.Implementations;
using Custom_Controller.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace View.Controllers
{
    public class UserLoginController: Controller
    {
        private iMediaOperation MediaManager = new MediaOperationImpl();
        public ActionResult LoginValidation()
        {


            var UserName = Request["username"];
            var Password = Request["password"];
            

            // Call the MVC controller then perform the validation

            Custom_Controller.iUserOperation userOperation = new Custom_Controller.UserOperationImpl();

            // (ValidUser in this context is UserLevel)
            int ValidUser = userOperation.Validate(UserName, Password);
            
            //call the CastUserId so we would know what's the id of username just logged in 
            int UserId = userOperation.CastUserId(UserName);

            //store the if of user just logged in a session so later on, we would know who's logging in with exact id
            Session["UserId"] = UserId.ToString();
            Session["UserLevel"] = ValidUser.ToString();


            ///If the user level equals to 1, he would be regular user
            ///if the user level equals to 2, he would be the admin
            if (ValidUser == 1)
            {
                ViewBag.allMedia = MediaManager.ListAllMedia();
                return View("../Home/RegularUserMediaBrowsing");
            }

            else if (ValidUser == 3)
            {
                ViewBag.allMedia = MediaManager.ListAllMedia();
                return View("../Home/EditMedia");
            }
            else
            {
                ViewBag.Message = "Invalid User";
                return View("../Home/Index");
            }
        }

        public ActionResult Register()
        {

            var UserName = Request["RegisterUsername"];
            var Password = Request["RegisterPassword"];
            var confirm = Request["RegisterConfirmPassword"];
            var email = Request["RegisterEmail"];
            /// regular user is level 1
            /// regular can choose to create another account
            int UserLevel = 1;
            //     Call the MVC controller & perfrom the validation.

            Custom_Controller.iUserOperation userOperations = new Custom_Controller.UserOperationImpl();
            
            if (Password == confirm)
            {
                bool isUserCreated = userOperations.AddUser(UserName, Password, UserLevel, email);

                if (isUserCreated)
                {
                    return View("../Home/RegularUserMediaBrowsing");
                }

                else
                {
                    return View("../Home/Register");
                }
            }
            else
            {
                ViewBag.RegisterMessage = "The password and the confirm password are different";
                return View("../Home/Register");

            }
        }
    }
}