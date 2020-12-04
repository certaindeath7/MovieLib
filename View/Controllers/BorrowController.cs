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
    public class BorrowController:Controller
    {
        private iBorrow BorrowMediaManager = new BorrowImpl();
        private iMediaOperation MediaManager = new MediaOperationImpl();
        public ActionResult BorrowMedia()
        {
           
            var Title = Request["MovieTitle"];
            var BorrowDate = Request["Today"];
            var ReturnDate = Request["EstimatedReturnDate"];

            // get the currently logged in user's id
            int UID = int.Parse(Session["UserId"].ToString());
            
            //get the media Id by reading the title text
            int MediaID = MediaManager.CastMediaId(Title);
            //convert string to date-time type
            DateTime TodayBorrow = Convert.ToDateTime(BorrowDate);
            DateTime EstimatedReturnDate = Convert.ToDateTime(ReturnDate);

            // calculate the borrowing duration
            int Duration = DateTime.Compare(TodayBorrow, EstimatedReturnDate);

            // check if user types the title correct
            if (MediaID > 0)
            //the return date has to be greater than the borrowdate which is today
            {
                if (Duration < 0)
                {
                    // check if the media is available
                    //if it is, borrow the media
                    if (BorrowMediaManager.IsMediaAvailable(MediaID))
                    {
                        if (BorrowMediaManager.IsMediaBorrowed(UID, MediaID, TodayBorrow, EstimatedReturnDate))
                        {
                            List<Media> AvailableMedia = new List<Media>();
                            List<MediaDTO> AvailableListFromController = BorrowMediaManager.AvailableMedia();
                            foreach (MediaDTO mediaDTO in AvailableListFromController)
                            {
                                AvailableMedia.Add(new Media(mediaDTO.MediaID, mediaDTO.Title, mediaDTO.Genre, mediaDTO.Director, mediaDTO.Language, mediaDTO.PublishYear, mediaDTO.Budget));
                            }
                            @ViewBag.AvavilableMediaList = AvailableMedia;
                            @ViewBag.BorrowMessage = "You have borrowed successfully";
                            return View("../Home/Borrow");
                        }
                        else
                        {
                            List<Media> AvailableMedia = new List<Media>();
                            List<MediaDTO> AvailableListFromController = BorrowMediaManager.AvailableMedia();
                            foreach (MediaDTO mediaDTO in AvailableListFromController)
                            {
                                AvailableMedia.Add(new Media(mediaDTO.MediaID, mediaDTO.Title, mediaDTO.Genre, mediaDTO.Director, mediaDTO.Language, mediaDTO.PublishYear, mediaDTO.Budget));
                            }
                            @ViewBag.AvavilableMediaList = AvailableMedia;
                            @ViewBag.BorrowMessage = "You have borrowed unsuccessfully";
                            return View("../Home/Borrow");
                        }
                    }
                    else
                    {
                        // check if the movie was already reserved by currently logged in user
                        // if true, the user can borrow it
                        if (BorrowMediaManager.IsMediaReservedByUser(UID, MediaID))
                        {
                            List<Media> AvailableMedia = new List<Media>();
                            List<MediaDTO> AvailableListFromController = BorrowMediaManager.AvailableMedia();
                            foreach (MediaDTO mediaDTO in AvailableListFromController)
                            {
                                AvailableMedia.Add(new Media(mediaDTO.MediaID, mediaDTO.Title, mediaDTO.Genre, mediaDTO.Director, mediaDTO.Language, mediaDTO.PublishYear, mediaDTO.Budget));
                            }
                            @ViewBag.AvavilableMediaList = AvailableMedia;
                            @ViewBag.BorrowMessage = "You have borrowed successfully";
                            return View("../Home/Borrow");
                        }
                        else
                        {
                            List<Media> AvailableMedia = new List<Media>();
                            List<MediaDTO> AvailableListFromController = BorrowMediaManager.AvailableMedia();
                            foreach (MediaDTO mediaDTO in AvailableListFromController)
                            {
                                AvailableMedia.Add(new Media(mediaDTO.MediaID, mediaDTO.Title, mediaDTO.Genre, mediaDTO.Director, mediaDTO.Language, mediaDTO.PublishYear, mediaDTO.Budget));
                            }
                            @ViewBag.AvavilableMediaList = AvailableMedia;
                            @ViewBag.BorrowMessage = "You have borrowed unsuccessfully";
                            return View("../Home/Borrow");
                        }
                    }
                }
                else
                {
                    List<Media> AvailableMedia = new List<Media>();
                    List<MediaDTO> AvailableListFromController = BorrowMediaManager.AvailableMedia();
                    foreach (MediaDTO mediaDTO in AvailableListFromController)
                    {
                        AvailableMedia.Add(new Media(mediaDTO.MediaID, mediaDTO.Title, mediaDTO.Genre, mediaDTO.Director, mediaDTO.Language, mediaDTO.PublishYear, mediaDTO.Budget));
                    }
                    @ViewBag.AvavilableMediaList = AvailableMedia;
                    @ViewBag.BorrowMessage = "Check back your borrow date. The return date has to be greater than today";
                    return View("../Home/Borrow");
                }
            }
            else
            {  
                @ViewBag.BorrowMessage = "Title not correct";
                @ViewBag.AvavilableMediaList = BorrowMediaManager.AvailableMedia();
                return View("../Home/Borrow");
            }
        }
        [HttpPost]
        public string ReturnMedia(int mediaId)
        {
            // get the currently logged in user's id
            int UID = int.Parse(Session["UserId"].ToString());

            DateTime Date = DateTime.Today;
            int Penaltyfee = BorrowMediaManager.ReturnMediaAction(mediaId, UID, Date);

            // check if the media has been returned
            if (Penaltyfee >= 0 )
            {
                @ViewBag.returnMessage = "Return successfully, the Penalty Fee is :$" + Penaltyfee;
                return "Return successfully, the Penalty Fee is :$" + Penaltyfee;
            }
            else
            {
                @ViewBag.returnMessage = "Return Failed";
                return "Return Failed";
            }

        }

        [HttpPost]
        public string ReserveMedia(int mediaId)
        {
            // get the currently logged in user's id
            int UID = int.Parse(Session["UserId"].ToString());

            DateTime Date = DateTime.Today;
            if (BorrowMediaManager.IsMediaAvailable(mediaId))
            {
                @ViewBag.reserveMessage = "Reserve successfully";
                return "Reserve successfully ";
            }
            else
            {
                @ViewBag.reserveMessage = "Reserve unsuccessfully";
                return "Reserve unsuccessfully ";
            }

        }
    }
}