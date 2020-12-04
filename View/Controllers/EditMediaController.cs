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
    public class EditMediaController:Controller
    {
        private iEditMedia EditMediaManager = new EditMediaImpl();
        private iMediaOperation MediaManager = new MediaOperationImpl();
        public ActionResult CreateMedia()
        {
            var MediaID = Request["MediaID"];
            var Title = Request["TitleID"];
            var Genre = Request["GenreID"];
            var Director = Request["DirectorID"];
            var Language = Request["LanguageID"];
            var PublishYear = Request["PublishYearID"];
            var Budget = Request["BudgetID"];
            var actionOption = Request["criteria"];

            // I created a dropdown menu so admin can choose among update, add in or delete
            // I used swtch case for that
            switch (actionOption)
            {
                case "Create":
                
                    if (EditMediaManager.CreateMedia(Title, int.Parse(Genre), int.Parse(Director), int.Parse(Language), int.Parse(PublishYear), decimal.Parse(Budget)))
                    {
                        List<Media> mediaList = new List<Media>();
                        List<MediaDTO> MediaListFromController = MediaManager.ListAllMedia();
                        foreach (MediaDTO controllerDTO in MediaListFromController)
                        {
                            mediaList.Add(new Media(controllerDTO.MediaID, controllerDTO.Title, controllerDTO.PublishYear, controllerDTO.Budget, controllerDTO.Director, controllerDTO.Genre, controllerDTO.Language));
                        }

                        ViewBag.allMedia = mediaList;
                        ViewBag.EditMessage = "Add Inforamtion Successfully";
                        
                    }
                    else
                    {
                        List<Media> mediaList = new List<Media>();
                        List<MediaDTO> MediaListFromController = MediaManager.ListAllMedia();
                        foreach (MediaDTO controllerDTO in MediaListFromController)
                        {
                            mediaList.Add(new Media(controllerDTO.MediaID, controllerDTO.Title, controllerDTO.PublishYear, controllerDTO.Budget, controllerDTO.Director, controllerDTO.Genre, controllerDTO.Language));
                        }

                        ViewBag.allMedia = mediaList;
                        ViewBag.EditMessage = "Add Inforamtion UnSuccessfully";
                    }
                   
                    break;

                case "Update":
                    if (EditMediaManager.UpdateMedia(int.Parse(MediaID), Title, int.Parse(Genre), int.Parse(Director), int.Parse(Language), int.Parse(PublishYear), decimal.Parse(Budget)))
                    {
                        List<Media> mediaList = new List<Media>();
                        List<MediaDTO> MediaListFromController = MediaManager.ListAllMedia();
                        foreach (MediaDTO controllerDTO in MediaListFromController)
                        {
                            mediaList.Add(new Media(controllerDTO.MediaID, controllerDTO.Title, controllerDTO.PublishYear, controllerDTO.Budget, controllerDTO.Director, controllerDTO.Genre, controllerDTO.Language));
                        }

                        ViewBag.allMedia = mediaList;
                        ViewBag.EditMessage = "Update Inforamtion Successfully";

                    }
                    else
                    {
                        List<Media> mediaList = new List<Media>();
                        List<MediaDTO> MediaListFromController = MediaManager.ListAllMedia();
                        foreach (MediaDTO controllerDTO in MediaListFromController)
                        {
                            mediaList.Add(new Media(controllerDTO.MediaID, controllerDTO.Title, controllerDTO.PublishYear, controllerDTO.Budget, controllerDTO.Director, controllerDTO.Genre, controllerDTO.Language));
                        }

                        ViewBag.allMedia = mediaList;
                        ViewBag.EditMessage = "Update Inforamtion UnSuccessfully";
                    }
                    break;
                case "Delete":
                    if (EditMediaManager.DeleteMedia(int.Parse(MediaID)))
                    {
                        List<Media> mediaList = new List<Media>();
                        List<MediaDTO> MediaListFromController = MediaManager.ListAllMedia();
                        foreach (MediaDTO controllerDTO in MediaListFromController)
                        {
                            mediaList.Add(new Media(controllerDTO.MediaID, controllerDTO.Title, controllerDTO.PublishYear, controllerDTO.Budget, controllerDTO.Director, controllerDTO.Genre, controllerDTO.Language));
                        }

                        ViewBag.allMedia = mediaList;
                        ViewBag.EditMessage = "Delete Inforamtion Successfully";

                    }
                    else
                    {
                        List<Media> mediaList = new List<Media>();
                        List<MediaDTO> MediaListFromController = MediaManager.ListAllMedia();
                        foreach (MediaDTO controllerDTO in MediaListFromController)
                        {
                            mediaList.Add(new Media(controllerDTO.MediaID, controllerDTO.Title, controllerDTO.PublishYear, controllerDTO.Budget, controllerDTO.Director, controllerDTO.Genre, controllerDTO.Language));
                        }

                        ViewBag.allMedia = mediaList;
                        ViewBag.EditMessage = "Delete Inforamtion UnSuccessfully";
                    }
                    break;
                default:
                    throw new System.Exception("Error while Editing");

            }
            return View("../Home/EditMedia");

        }
    }

    

}