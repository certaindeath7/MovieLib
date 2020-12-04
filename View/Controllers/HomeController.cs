using Custom_Controller;
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
    public class HomeController : Controller
    {
        // call the controller reference
        // edit media reference
        private iMediaOperation MediaManager = new MediaOperationImpl();

        // borrow reference
        private iBorrow BorrowMediaManager = new BorrowImpl();

        // edit director reference
        private iEditDirector DirectorManager = new EditDirectorImpl();

        //edit language reference
        private iEditLanguage LanguageManager = new EditLanguageImpl();

        // edit genre reference
        private iEditGenre GenreManager = new EditGenreImpl();

        // edit user reference
        private iEditUser UserManager = new EditUserImpl();


        // load index page
        public ActionResult Index()
        {
            // after a user loggig in, turn Login page into Search page as a home page
            if (Session["UserLevel"] != null)
            {
                List<Media> allMediaList = new List<Media>();
                List<MediaDTO> UserListFromController = MediaManager.ListAllMedia();
                foreach (MediaDTO mediaDTO in UserListFromController)
                {
                    allMediaList.Add(new Media(mediaDTO.MediaID, mediaDTO.Title, mediaDTO.Genre, mediaDTO.Director, mediaDTO.Language, mediaDTO.PublishYear, mediaDTO.Budget));
                }

                ViewBag.allMedia = allMediaList;

                return View("../Home/RegularUserMediaBrowsing");
            }
            else
            {
                return View();
            }
        }
        // load register page
        public ActionResult Register()
        {
            ViewBag.Message = "Please Login";
            return View();
        }
        // load browsing page
        public ActionResult RegularUserMediaBrowsing()
        {
            if (Session["UserLevel"] != null)
            // load media
            {
                ViewBag.allMedia = MediaManager.ListAllMedia();
                ViewBag.Message = "Media Browsing";
                return View("../Home/RegularUserMediaBrowsing");
            }
            else
            {
                ViewBag.Message = "Please Login";
                return View("Index");
            }
        }
        
        public ActionResult SearchMedia()
        {
            iSearchController SearchMedia = new SearchControllerImpl();
            
            var keyword = Request["keyword"];
            var mediaList = Request["criteria"];


            MediaDTO mediaDTOfromController = new MediaDTO();
            if (Session["UserLevel"] != null)
            // load media
            {
                if (keyword != "")
                {
                    switch (mediaList)
                    {
                        case "Title":
                            mediaDTOfromController.Title = keyword;
                            break;
                        case "Genre":
                            mediaDTOfromController.Genre = keyword;
                            break;
                        case "Director":
                            mediaDTOfromController.Director = keyword;
                            break;
                        case "Language":
                            mediaDTOfromController.Language = keyword;
                            break;
                        default:
                            throw new System.Exception("Error while searching");

                    }
                }
                else
                {
                    throw new System.Exception("Error while searching");
                }
                ViewBag.allMedia = SearchMedia.MediaSearcFunction(mediaDTOfromController);

                return View("../Home/RegularUserMediaBrowsing");
            }

            else
            {
                ViewBag.Message = "Please Login";
                return View("../Home/Index");

            }
        }
        //load the borrow page
        public ActionResult Borrow()
        {
            // print the all the available media to borrow first to the _layout
            // and then will retern to the Borrow page in View in which will trigure borrow's logic from Borrow controller
            if (Session["UserLevel"] != null)
            {
                List<Media> AvailableMedia = new List<Media>();
                List<MediaDTO> AvailableListFromController = BorrowMediaManager.AvailableMedia();
                foreach (MediaDTO mediaDTO in AvailableListFromController)
                {
                    AvailableMedia.Add(new Media(mediaDTO.MediaID, mediaDTO.Title, mediaDTO.Genre, mediaDTO.Director, mediaDTO.Language, mediaDTO.PublishYear, mediaDTO.Budget));
                }
                @ViewBag.AvavilableMediaList = BorrowMediaManager.AvailableMedia(); 
                return View("Borrow");
            }
            else
            {
                ViewBag.LoginMessage = "Please Login";
                return View("Index");
            }
        }
        // load return page
        public ActionResult Return()
        {
            // print the all the available media to return first to the _layout
            // and then will retern to the Return page in View in which will trigure return's logic from Borrow controller
            if (Session["UserLevel"] != null)
            {
                int UID = int.Parse(Session["UserId"].ToString());
                List<Media> BorrowingList = new List<Media>();
                List<MediaDTO> AvailableListFromController = BorrowMediaManager.UserBorrowedMedia(UID);
                foreach (MediaDTO mediaDTO in AvailableListFromController)
                {
                    BorrowingList.Add(new Media(mediaDTO.MediaID, mediaDTO.UID, mediaDTO.Title, mediaDTO.PublishYear, mediaDTO.Budget, mediaDTO.Director, mediaDTO.Genre, mediaDTO.Language, mediaDTO.DateBorrow, mediaDTO.DateReturn));
                }
                @ViewBag.BeingBorrowedList = BorrowingList;
                return View("Return");
            }
            else
            {
                ViewBag.LoginMessage = "Please Login";
                return View("Index");
            }
        }
        // load reserve page
        public ActionResult Reserve()
        {

            // print the all the available media to reserve first to the _layout
            // and then will returnn to the Reserve page in View in which will trigure reserve's logic from Borrow controller
            if (Session["UserLevel"] != null)
            {
                int UID = int.Parse(Session["UserId"].ToString());
                List<Media> ReserveList = new List<Media>();

                // get all the available media
                List<MediaDTO> AvailableListFromController = BorrowMediaManager.AvailableMedia();
                foreach (MediaDTO mediaDTO in AvailableListFromController)
                {
                    ReserveList.Add(new Media(mediaDTO.MediaID, mediaDTO.UID, mediaDTO.Title, mediaDTO.PublishYear, mediaDTO.Budget, mediaDTO.Director, mediaDTO.Genre, mediaDTO.Language, mediaDTO.DateBorrow, mediaDTO.DateReturn));
                }
                @ViewBag.AvavilableMediaList = ReserveList;
                return View("Reserve");
            }
            else
            {
                ViewBag.LoginMessage = "Please Login";
                return View("Index");
            }
        }

        //sign out function
        public ActionResult Signout()
        {
            // delete current user's level and ID session to sign out
            Session.Remove("UserLevel");
            Session.Remove("UserId");
            return View("../Home/Index");
        }

        //load editMedia page
        public ActionResult EditMedia()
        {
            // check if there's a usr logged in
            if (Session["UserLevel"] != null)
            {
                //check if the one who just logged in was admin
                if(Session["UserLevel"].Equals("3"))
                {
                    List<Media> mediaList = new List<Media>();
                    List<MediaDTO> MediaListFromController = MediaManager.ListAllMedia();
                    foreach (MediaDTO controllerDTO in MediaListFromController)
                    {
                        mediaList.Add(new Media(controllerDTO.MediaID, controllerDTO.Title, controllerDTO.PublishYear, controllerDTO.Budget, controllerDTO.Director, controllerDTO.Genre, controllerDTO.Language));
                    }

                    ViewBag.allMedia = mediaList;
                    return View("EditMedia");
                }
                else
                {
                    @ViewBag.EditMessage = "You're not authorized";
                    return View("Index");
                }
            }
            else
            {
                ViewBag.LoginMessage = "Please Login";
                return View("Index");
            }
        }

        // load editDirector page
        public ActionResult EditDirector()
        {
            // check if there's a usr logged in
            if (Session["UserLevel"] != null)
            {
                //check if the one who just logged in was admin
                if (Session["UserLevel"].Equals("3"))
                {
                    List<Director> directorList = new List<Director>();
                    List<DirectorDTO> MediaListFromController = DirectorManager.PrintDirectorList();
                    foreach (DirectorDTO controllerDTO in MediaListFromController)
                    {
                        directorList.Add(new Director(int.Parse(controllerDTO.DID.ToString()), controllerDTO.DirectorName));
                    }

                    ViewBag.allMedia = directorList;
                    return View("EditDirector");
                }
                else
                {
                    @ViewBag.EditMessage = "You're not authorized";
                    return View("Index");
                }
            }
            else
            {
                ViewBag.LoginMessage = "Please Login";
                return View("Index");
            }
        }

        // load editLanguage page

        public ActionResult EditLanguage()
        {
            // check if there's a usr logged in
            if (Session["UserLevel"] != null)
            {
                //check if the one who just logged in was admin
                if (Session["UserLevel"].Equals("3"))
                {
                    List<Language> LanguageList = new List<Language>();
                    List<LanguageDTO> MediaListFromController = LanguageManager.PrintLanguageList();
                    foreach (LanguageDTO controllerDTO in MediaListFromController)
                    {
                        LanguageList.Add(new Language(int.Parse(controllerDTO.LID.ToString()), controllerDTO.LanguageName));
                    }

                    ViewBag.allMedia = LanguageList;
                    return View("EditLanguage");
                }
                else
                {
                    @ViewBag.EditMessage = "You're not authorized";
                    return View("Index");
                }
            }
            else
            {
                ViewBag.LoginMessage = "Please Login";
                return View("Index");
            }
        }

        // load editGenre page

        public ActionResult EditGenre()
        {
            // check if there's a usr logged in
            if (Session["UserLevel"] != null)
            {
                //check if the one who just logged in was admin
                if (Session["UserLevel"].Equals("3"))
                {
                    List<Genre> GenreList = new List<Genre>();
                    List<GenreDTO> MediaListFromController = GenreManager.PrintGenreList();
                    foreach (GenreDTO controllerDTO in MediaListFromController)
                    {
                        GenreList.Add(new Genre(int.Parse(controllerDTO.GID.ToString()), controllerDTO.GenreName));
                    }

                    ViewBag.allGenre = GenreList;
                    return View("EditGenre");
                }
                else
                {
                    @ViewBag.EditMessage = "You're not authorized";
                    return View("Index");
                }
            }
            else
            {
                ViewBag.LoginMessage = "Please Login";
                return View("Index");
            }
        }

        // load editUser page

        public ActionResult EditUser()
        {
            // check if there's a usr logged in
            if (Session["UserLevel"] != null)
            {
                //check if the one who just logged in was admin
                if (Session["UserLevel"].Equals("3"))
                {
                    List<User> UserList = new List<User>();
                    List<UserDTO> UserListFromController = UserManager.ListAllUser();
                    foreach (UserDTO controllerDTO in UserListFromController)
                    {
                        UserList.Add(new User(int.Parse(controllerDTO.UID.ToString()), controllerDTO.UserName, controllerDTO.Password, int.Parse(controllerDTO.UserLevel.ToString()), controllerDTO.Email));
                    }

                    ViewBag.allUser = UserList;
                    return View("EditUser");
                }
                else
                {
                    @ViewBag.EditMessage = "You're not authorized";
                    return View("Index");
                }
            }
            else
            {
                ViewBag.LoginMessage = "Please Login";
                return View("Index");
            }
        }

        // load report page
        public ActionResult Report()
        {

            int UID = int.Parse(Session["UserId"].ToString());
            if (Session["UserLevel"] != null)
            {
                //check if the one who just logged in was admin
                if (Session["UserLevel"].Equals("3"))
                {
                    //show available media
                    List<Media> AvailableMedia = new List<Media>();
                    List<MediaDTO> MediaListFromController = BorrowMediaManager.AvailableMedia();
                    foreach (MediaDTO controllerDTO in MediaListFromController)
                    {
                        AvailableMedia.Add(new Media(controllerDTO.MediaID, controllerDTO.Title, controllerDTO.Genre, controllerDTO.Director, controllerDTO.Language, controllerDTO.PublishYear, controllerDTO.Budget));
                    }
                    ViewBag.AvailableList = AvailableMedia;

                    return View();
                }
                else
                {
                    @ViewBag.EditMessage = "You're not authorized";
                    return View("Index");
                }
            }
            else
            {
                ViewBag.LoginMessage = "Please Login";
                return View("Index");
            }
        }
    }
}