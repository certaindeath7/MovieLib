using Custom_Controller;
using Custom_Controller.Implementations;
using Custom_Controller.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using View.Models;

namespace View.Controllers
{
    public class EditUserController:Controller
    {
        
        private iEditUser UserManager = new EditUserImpl();

        public ActionResult CreateUser()
        {
            var UID = Request["UserID"];
            var UserName = Request["UserName"];
            var Password = Request["Password"];
            var UserLevel = Request["UserLevel"];
            var Email = Request["Email"];
            var actionOption = Request["criteria"];

            // I created a dropdown menu so admin can choose among update, add in or delete
            // I used swtch case for that
            switch (actionOption)
            {
                case "Create":

                    if (UserManager.CreateUser(UserName, Password, int.Parse(UserLevel.ToString()), Email))
                    {
                        List<User> UserList = new List<User>();
                        List<UserDTO> UserListFromController = UserManager.ListAllUser();
                        foreach (UserDTO controllerDTO in UserListFromController)
                        {
                            UserList.Add(new User(int.Parse(controllerDTO.UID.ToString()), controllerDTO.UserName, controllerDTO.Password, int.Parse(controllerDTO.UserLevel.ToString()), controllerDTO.Email));
                        }

                        ViewBag.allUser = UserList;
                        ViewBag.UserMessage = "Add Inforamtion Successfully";

                    }
                    else
                    {

                        List<User> UserList = new List<User>();
                        List<UserDTO> UserListFromController = UserManager.ListAllUser();
                        foreach (UserDTO controllerDTO in UserListFromController)
                        {
                            UserList.Add(new User(int.Parse(controllerDTO.UID.ToString()), controllerDTO.UserName, controllerDTO.Password, int.Parse(controllerDTO.UserLevel.ToString()), controllerDTO.Email));
                        }

                        ViewBag.allUser = UserList;
                        ViewBag.UserMessage = "Add Inforamtion UnSuccessfully";
                    }

                    break;

                case "Update":
                    if (UserManager.UpdateUser(int.Parse(UID), UserName, Password, int.Parse(UserLevel), Email))
                    {
                        List<User> UserList = new List<User>();
                        List<UserDTO> UserListFromController = UserManager.ListAllUser();
                        foreach (UserDTO controllerDTO in UserListFromController)
                        {
                            UserList.Add(new User(int.Parse(controllerDTO.UID.ToString()), controllerDTO.UserName, controllerDTO.Password, int.Parse(controllerDTO.UserLevel.ToString()), controllerDTO.Email));
                        }

                        ViewBag.allUser = UserList;
                        ViewBag.UserMessage = "Update Inforamtion Successfully";

                    }
                    else
                    {
                        List<User> UserList = new List<User>();
                        List<UserDTO> UserListFromController = UserManager.ListAllUser();
                        foreach (UserDTO controllerDTO in UserListFromController)
                        {
                            UserList.Add(new User(int.Parse(controllerDTO.UID.ToString()), controllerDTO.UserName, controllerDTO.Password, int.Parse(controllerDTO.UserLevel.ToString()), controllerDTO.Email));
                        }

                        ViewBag.allUser = UserList;
                        ViewBag.UserMessage = "Update Inforamtion UnSuccessfully";
                    }
                    break;
                case "Delete":
                    if (UserManager.DeleteUser(int.Parse(UID)))
                    {
                        List<User> UserList = new List<User>();
                        List<UserDTO> UserListFromController = UserManager.ListAllUser();
                        foreach (UserDTO controllerDTO in UserListFromController)
                        {
                            UserList.Add(new User(int.Parse(controllerDTO.UID.ToString()), controllerDTO.UserName, controllerDTO.Password, int.Parse(controllerDTO.UserLevel.ToString()), controllerDTO.Email));
                        }

                        ViewBag.allUser = UserList;
                        ViewBag.GenreMessage = "Delete Inforamtion Successfully";

                    }
                    else
                    {
                        List<User> UserList = new List<User>();
                        List<UserDTO> UserListFromController = UserManager.ListAllUser();
                        foreach (UserDTO controllerDTO in UserListFromController)
                        {
                            UserList.Add(new User(int.Parse(controllerDTO.UID.ToString()), controllerDTO.UserName, controllerDTO.Password, int.Parse(controllerDTO.UserLevel.ToString()), controllerDTO.Email));
                        }

                        ViewBag.allUser = UserList;
                        ViewBag.GenreMessage = "Delete Inforamtion UnSuccessfully";
                    }
                    break;
                default:
                    throw new System.Exception("Error while Editing");

            }
            return View("../Home/EditUser");
        }
    }
}