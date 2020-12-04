using Custom_Controller.DTOs;
using Custom_Controller.Interfaces;
using Model.DTOs;
using Model.Implementations;
using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Controller.Implementations
{
    public class BorrowImpl : iBorrow
    {
        private iBorrowModel BorrowMediaManager = new BorrowModelImpl();
        public List<MediaDTO> AdminBorrowedMedia()
        {
            List<MediaDTO> AdminBorrowedMediaList = new List<MediaDTO>();

            List<ModelMediaDTO> MediaListFromModel = BorrowMediaManager.AdminBorrowedMedia();


            foreach (ModelMediaDTO modelDTO in MediaListFromModel)
            {
                AdminBorrowedMediaList.Add(new MediaDTO(modelDTO.MediaID, modelDTO.UID, modelDTO.UserName, modelDTO.Title, modelDTO.Genre, modelDTO.Director, modelDTO.DateBorrow, modelDTO.DateReturn, modelDTO.ActualReturn, modelDTO.PenaltyFee));
            }
            return AdminBorrowedMediaList;
        }

        public List<MediaDTO> AdminReservedMedia()
        {
            List<MediaDTO> AdminReserveddMediaList = new List<MediaDTO>();

            List<ModelMediaDTO> MediaListFromModel = BorrowMediaManager.AdminReservedMedia();


            foreach (ModelMediaDTO modelDTO in MediaListFromModel)
            {
                AdminReserveddMediaList.Add(new MediaDTO(modelDTO.MediaID, modelDTO.UID, modelDTO.UserName, modelDTO.Title, modelDTO.Genre, modelDTO.Director, modelDTO.DateBorrow, modelDTO.DateReturn, modelDTO.ActualReturn, modelDTO.PenaltyFee));
            }
            return AdminReserveddMediaList;
        }

        public List<MediaDTO> AvailableMedia()
        {
            List<MediaDTO> AdminReserveddMediaList = new List<MediaDTO>();

            List<ModelMediaDTO> MediaListFromModel = BorrowMediaManager.AvailableMedia();


            foreach (ModelMediaDTO modelDTO in MediaListFromModel)
            {
                AdminReserveddMediaList.Add(new MediaDTO(modelDTO.MediaID, modelDTO.UID, modelDTO.UserName, modelDTO.Title, modelDTO.Genre, modelDTO.Director, modelDTO.DateBorrow, modelDTO.DateReturn, modelDTO.ActualReturn, modelDTO.PenaltyFee));
            }
            return AdminReserveddMediaList;
        }

        public DateTime EstimatedReturnDate(int mediaID, int uid)
        {
            return BorrowMediaManager.EstimatedReturnDate(mediaID, uid);
        }

        public bool IsMediaAvailable(int mediaId)
        {
            return BorrowMediaManager.IsMediaAvailable(mediaId);
        }

        public bool IsMediaBorrowed(int uid, int mediaId, DateTime borrowDate, DateTime returnDate)
        {
            return BorrowMediaManager.IsMediaBorrowed(uid, mediaId, borrowDate, returnDate);

        }

        public bool IsMediaReserved(int uid, int mediaID, DateTime reserveDate)
        {
            return BorrowMediaManager.IsMediaReserved(uid, mediaID, reserveDate);
        }

        public bool IsMediaReturned(int uid, int mediaId, DateTime borrowDate, DateTime returnDate)
        {
            return BorrowMediaManager.IsMediaReturned(uid, mediaId, borrowDate, returnDate);

        }

        public bool RemoveReturnedMedia(int mediaId, int uid)
        {
            return BorrowMediaManager.RemoveReturnedMedia(uid, mediaId);
        }
        public bool IsMediaReservedByUser(int mediaId, int uid)
        {
            return BorrowMediaManager.IsMediaReservedByUser(mediaId, uid);
        }

        public int ReturnMediaAction(int mediaId, int uid, DateTime returnDate)
        {
            DateTime todayDate = DateTime.Today;
            // after a media has been returned, add it to returned media admin's list
            // then delete it from borrow record;
            BorrowMediaManager.IsMediaReturned(uid, mediaId, todayDate, returnDate);
            BorrowMediaManager.RemoveReturnedMedia(mediaId, uid);
                
                return BorrowMediaManager.ReturnMediaAction(mediaId, uid, returnDate);
        }

        public List<MediaDTO> UserBorrowedMedia(int uid)
        {
            List<MediaDTO> AdminReserveddMediaList = new List<MediaDTO>();

            List<ModelMediaDTO> MediaListFromModel = BorrowMediaManager.UserBorrowedMedia(uid);


            foreach (ModelMediaDTO modelDTO in MediaListFromModel)
            {
                AdminReserveddMediaList.Add(new MediaDTO(modelDTO.MediaID, modelDTO.UID, modelDTO.UserName, modelDTO.Title, modelDTO.Genre, modelDTO.Director, modelDTO.DateBorrow, modelDTO.DateReturn, modelDTO.ActualReturn, modelDTO.PenaltyFee));
            }
            return AdminReserveddMediaList;
        }
    }
}
