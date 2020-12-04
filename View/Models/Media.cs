using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace View.Models
{
    public class Media
    {
        public int MediaID { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public string Language { get; set; }
        public int PublishYear { get; set; }
        public decimal Budget { get; set; }

        public string UserName { get; set; }
        public int UID { get; set; }

        public DateTime DateBorrow { get; set; }
        public DateTime DateReturn { get; set; }
        public DateTime ActualReturn { get; set; }
        public DateTime ReserveDate { get; set; }
        public decimal PenaltyFee { get; set; }


        //Constructor
        public Media(int mediaID, string title, string genre, string director, string language, int publishYear, decimal budget)
        {
            this.MediaID = mediaID;
            this.Title = title;
            this.Genre = genre;
            this.Director = director;
            this.Language = language;
            this.PublishYear = publishYear;
            this.Budget = budget;
        }

        public Media(int mediaID, string title, int publishYear, decimal budget, string directorName, string genreName, string languageName)
        {
            this.MediaID = mediaID;
            this.Title = title;
            this.PublishYear = publishYear;
            this.Budget = budget;
            this.Director = directorName;
            this.Genre = genreName;
            this.Language = languageName;
        }

        public Media(string title, string genre, string director, string language)
        {
            this.Title = title;
            this.Genre = genre;
            this.Director = director;
            this.Language = language;
        }
        public Media()
        {
            this.MediaID = 0;
            this.Title = "";
            this.Genre = "";
            this.Director = "";
            this.Language = "";
            this.PublishYear = 0;
            this.Budget = 0;
        }
        public Media(int mediaId, int uid, string userName, string title, string genre, string director, DateTime dateBorrow, DateTime dateReturn, DateTime actualReturn, decimal penaltyFee)
        {
            this.MediaID = mediaId;
            this.UID = uid;
            this.UserName = userName;
            this.Title = title;
            this.Genre = genre;
            this.Director = director;
            this.DateBorrow = dateBorrow;
            this.DateReturn = dateReturn;
            this.ActualReturn = actualReturn;
            this.PenaltyFee = penaltyFee;

        }
        public Media(int mediaId)
        {
            this.MediaID = mediaId;
        }
        public Media(int mediaId, int uid, string title, int publishYear, decimal budget, string director, string genre, string language, DateTime dateBorrow, DateTime dateReturn)
        {
            this.MediaID = mediaId;
            this.UID = uid;
            this.Title = title;
            this.PublishYear = publishYear;
            this.Budget = budget;
            this.Director = director;
            this.Genre = genre;
            this.Language = language;
            this.DateBorrow = dateBorrow;
            this.DateReturn = dateReturn;
        }
    }
}