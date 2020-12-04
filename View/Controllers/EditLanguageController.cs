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
    public class EditLanguageController:Controller
    {
        private iEditLanguage LanguageManager = new EditLanguageImpl();
        private iMediaOperation MediaManager = new MediaOperationImpl();

        public ActionResult CreateLanguage()
        {
            var LanguageName = Request["LanguageName"];
            var LID = Request["LID"];
            var actionOption = Request["criteria"];

            // I created a dropdown menu so admin can choose among update, add in or delete
            // I used swtch case for that

            switch (actionOption)
            {
                case "Create":

                    if (LanguageManager.CreateLanguage(LanguageName))
                    {
                        List<Language> LanguageList = new List<Language>();
                        List<LanguageDTO> MediaListFromController = LanguageManager.PrintLanguageList();
                        foreach (LanguageDTO controllerDTO in MediaListFromController)
                        {
                            LanguageList.Add(new Language(int.Parse(controllerDTO.LID.ToString()), controllerDTO.LanguageName));
                        }

                        ViewBag.allMedia = LanguageList;
                        ViewBag.LanguageMessage = "Add Inforamtion Successfully";

                    }
                    else
                    {
                        List<Language> LanguageList = new List<Language>();
                        List<LanguageDTO> MediaListFromController = LanguageManager.PrintLanguageList();
                        foreach (LanguageDTO controllerDTO in MediaListFromController)
                        {
                            LanguageList.Add(new Language(int.Parse(controllerDTO.LID.ToString()), controllerDTO.LanguageName));
                        }

                        ViewBag.allMedia = LanguageList;
                        ViewBag.LanguageMessage = "Add Inforamtion UnSuccessfully";
                    }

                    break;

                case "Update":
                    if (LanguageManager.UpdateLanguage(int.Parse(LID), LanguageName))
                    {
                        List<Language> LanguageList = new List<Language>();
                        List<LanguageDTO> MediaListFromController = LanguageManager.PrintLanguageList();
                        foreach (LanguageDTO controllerDTO in MediaListFromController)
                        {
                            LanguageList.Add(new Language(int.Parse(controllerDTO.LID.ToString()), controllerDTO.LanguageName));
                        }

                        ViewBag.allMedia = LanguageList;
                        ViewBag.LanguageMessage = "Update Inforamtion Successfully";

                    }
                    else
                    {
                        List<Language> LanguageList = new List<Language>();
                        List<LanguageDTO> MediaListFromController = LanguageManager.PrintLanguageList();
                        foreach (LanguageDTO controllerDTO in MediaListFromController)
                        {
                            LanguageList.Add(new Language(int.Parse(controllerDTO.LID.ToString()), controllerDTO.LanguageName));
                        }

                        ViewBag.allMedia = LanguageList;
                        ViewBag.LanguageMessage = "Update Inforamtion UnSuccessfully";
                    }
                    break;
                case "Delete":
                    if (LanguageManager.DeleteLanguage(int.Parse(LID)))
                    {
                        List<Language> LanguageList = new List<Language>();
                        List<LanguageDTO> MediaListFromController = LanguageManager.PrintLanguageList();
                        foreach (LanguageDTO controllerDTO in MediaListFromController)
                        {
                            LanguageList.Add(new Language(int.Parse(controllerDTO.LID.ToString()), controllerDTO.LanguageName));
                        }

                        ViewBag.allMedia = LanguageList;
                        ViewBag.LanguageMessage = "Delete Inforamtion Successfully";

                    }
                    else
                    {
                        List<Language> LanguageList = new List<Language>();
                        List<LanguageDTO> MediaListFromController = LanguageManager.PrintLanguageList();
                        foreach (LanguageDTO controllerDTO in MediaListFromController)
                        {
                            LanguageList.Add(new Language(int.Parse(controllerDTO.LID.ToString()), controllerDTO.LanguageName));
                        }

                        ViewBag.allMedia = LanguageList;
                        ViewBag.LanguageMessage = "Delete Inforamtion UnSuccessfully";
                    }
                    break;
                default:
                    throw new System.Exception("Error while Editing");

            }
            return View("../Home/EditLanguage");
        }
    }
}