using Custom_Controller.DTOs;
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
    public class EditDirectorController:Controller
    {
        private iEditDirector DirectorManager = new EditDirectorImpl();
        private iMediaOperation MediaManager = new MediaOperationImpl();
       
        public ActionResult CreateDirector()
        {
            var DirectorName = Request["DirectorName"];
            var DirectorID = Request["DirectorID"];
            var actionOption = Request["criteria"];

            // I created a dropdown menu so admin can choose among update, add in or delete
            // I used swtch case for that
            switch (actionOption)
            {
                case "Create":

                    if (DirectorManager.CreateDirector(DirectorName))
                    {
                        List<Director> directorList = new List<Director>();
                        List<DirectorDTO> MediaListFromController = DirectorManager.PrintDirectorList();
                        foreach (DirectorDTO controllerDTO in MediaListFromController)
                        {
                            directorList.Add(new Director(int.Parse(controllerDTO.DID.ToString()), controllerDTO.DirectorName));
                        }

                        ViewBag.allMedia = directorList;
                        ViewBag.DirectorMessage = "Add Inforamtion Successfully";

                    }
                    else
                    {
                        List<Director> directorList = new List<Director>();
                        List<DirectorDTO> MediaListFromController = DirectorManager.PrintDirectorList();
                        foreach (DirectorDTO controllerDTO in MediaListFromController)
                        {
                            directorList.Add(new Director(int.Parse(controllerDTO.DID.ToString()), controllerDTO.DirectorName));
                        }

                        ViewBag.allMedia = directorList;
                        ViewBag.DirectorMessage = "Add Inforamtion unSuccessfully";
                    }

                    break;

                case "Update":
                    if (DirectorManager.UpdateDirector(int.Parse(DirectorID), DirectorName))
                    {
                        List<Director> directorList = new List<Director>();
                        List<DirectorDTO> MediaListFromController = DirectorManager.PrintDirectorList();
                        foreach (DirectorDTO controllerDTO in MediaListFromController)
                        {
                            directorList.Add(new Director(int.Parse(controllerDTO.DID.ToString()), controllerDTO.DirectorName));
                        }

                        ViewBag.allMedia = directorList;
                        ViewBag.DirectorMessage = "Update Inforamtion Successfully";

                    }
                    else
                    {
                        List<Director> directorList = new List<Director>();
                        List<DirectorDTO> MediaListFromController = DirectorManager.PrintDirectorList();
                        foreach (DirectorDTO controllerDTO in MediaListFromController)
                        {
                            directorList.Add(new Director(int.Parse(controllerDTO.DID.ToString()), controllerDTO.DirectorName));
                        }

                        ViewBag.allMedia = directorList;
                        ViewBag.DirectorMessage = "update Inforamtion UnSuccessfully";
                    }
                    break;
                case "Delete":
                    if (DirectorManager.DeleteDirect(int.Parse(DirectorID)))
                    {
                        List<Director> directorList = new List<Director>();
                        List<DirectorDTO> MediaListFromController = DirectorManager.PrintDirectorList();
                        foreach (DirectorDTO controllerDTO in MediaListFromController)
                        {
                            directorList.Add(new Director(int.Parse(controllerDTO.DID.ToString()), controllerDTO.DirectorName));
                        }

                        ViewBag.allMedia = directorList;
                        ViewBag.DirectorMessage = "delete Inforamtion Successfully";

                    }
                    else
                    {
                        List<Director> directorList = new List<Director>();
                        List<DirectorDTO> MediaListFromController = DirectorManager.PrintDirectorList();
                        foreach (DirectorDTO controllerDTO in MediaListFromController)
                        {
                            directorList.Add(new Director(int.Parse(controllerDTO.DID.ToString()), controllerDTO.DirectorName));
                        }

                        ViewBag.allMedia = directorList;
                        ViewBag.DirectorMessage = "Delete Inforamtion UnSuccessfully";
                    }
                    break;
                default:
                    throw new System.Exception("Error while Editing");

            }
            return View("../Home/EditDirector");
        }
    }
}