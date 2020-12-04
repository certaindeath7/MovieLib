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
    public class EditGenreController:Controller
    {
        private iEditGenre GenreManager = new EditGenreImpl();
        private iMediaOperation MediaManager = new MediaOperationImpl();

        public ActionResult CreateGenre()
        {
            var GenreName = Request["GenreName"];
            var GID = Request["GenreID"];
            var actionOption = Request["criteria"];

            // I created a dropdown menu so admin can choose among update, add in or delete
            // I used swtch case for that
            switch (actionOption)
            {
                case "Create":

                    if (GenreManager.CreateGenre(GenreName))
                    {
                        List<Genre> GenreList = new List<Genre>();
                        List<GenreDTO> MediaListFromController = GenreManager.PrintGenreList();
                        foreach (GenreDTO controllerDTO in MediaListFromController)
                        {
                            GenreList.Add(new Genre(int.Parse(controllerDTO.GID.ToString()), controllerDTO.GenreName));
                        }

                        ViewBag.allGenre = GenreList;
                        ViewBag.GenreMessage = "Add Inforamtion Successfully";

                    }
                    else
                    {

                        List<Genre> GenreList = new List<Genre>();
                        List<GenreDTO> MediaListFromController = GenreManager.PrintGenreList();
                        foreach (GenreDTO controllerDTO in MediaListFromController)
                        {
                            GenreList.Add(new Genre(int.Parse(controllerDTO.GID.ToString()), controllerDTO.GenreName));
                        }

                        ViewBag.allGenre = GenreList;
                        ViewBag.GenreMessage = "Add Inforamtion UnSuccessfully";
                    }

                    break;

                case "Update":
                    if (GenreManager.UpdateGenre(int.Parse(GID), GenreName))
                    {
                        List<Genre> GenreList = new List<Genre>();
                        List<GenreDTO> MediaListFromController = GenreManager.PrintGenreList();
                        foreach (GenreDTO controllerDTO in MediaListFromController)
                        {
                            GenreList.Add(new Genre(int.Parse(controllerDTO.GID.ToString()), controllerDTO.GenreName));
                        }

                        ViewBag.allGenre = GenreList;
                        ViewBag.GenreMessage = "Update Inforamtion Successfully";

                    }
                    else
                    {
                        List<Genre> GenreList = new List<Genre>();
                        List<GenreDTO> MediaListFromController = GenreManager.PrintGenreList();
                        foreach (GenreDTO controllerDTO in MediaListFromController)
                        {
                            GenreList.Add(new Genre(int.Parse(controllerDTO.GID.ToString()), controllerDTO.GenreName));
                        }

                        ViewBag.allGenre = GenreList;
                        ViewBag.GenreMessage = "Update Inforamtion UnSuccessfully";
                    }
                    break;
                case "Delete":
                    if (GenreManager.DeleteGenre(int.Parse(GID)))
                    {
                        List<Genre> GenreList = new List<Genre>();
                        List<GenreDTO> MediaListFromController = GenreManager.PrintGenreList();
                        foreach (GenreDTO controllerDTO in MediaListFromController)
                        {
                            GenreList.Add(new Genre(int.Parse(controllerDTO.GID.ToString()), controllerDTO.GenreName));
                        }

                        ViewBag.allGenre = GenreList;
                        ViewBag.GenreMessage = "Delete Inforamtion Successfully";

                    }
                    else
                    {
                        List<Genre> GenreList = new List<Genre>();
                        List<GenreDTO> MediaListFromController = GenreManager.PrintGenreList();
                        foreach (GenreDTO controllerDTO in MediaListFromController)
                        {
                            GenreList.Add(new Genre(int.Parse(controllerDTO.GID.ToString()), controllerDTO.GenreName));
                        }

                        ViewBag.allGenre = GenreList;
                        ViewBag.GenreMessage = "Delete Inforamtion UnSuccessfully";
                    }
                    break;
                default:
                    throw new System.Exception("Error while Editing");

            }
            return View("../Home/EditGenre");
        }
    }
}