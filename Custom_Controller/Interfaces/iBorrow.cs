using Custom_Controller.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Controller.Interfaces
{
    public interface iBorrow
    {
        List<MediaDTO> UserBorrowedMedia(int uid);
        List<MediaDTO> AvailableMedia();
        List<MediaDTO> AdminBorrowedMedia();
        List<MediaDTO> AdminReservedMedia();

        bool IsMediaReturned(int uid, int mediaId, DateTime borrowDate, DateTime returnDate);
        bool IsMediaReserved(int uid, int mediaID, DateTime reserveDate);
        bool IsMediaBorrowed(int uid, int mediaId, DateTime borrowDate, DateTime returnDate);
        bool IsMediaAvailable(int mediaId);
        bool RemoveReturnedMedia(int mediaId, int uid);
        bool IsMediaReservedByUser(int mediaId, int uid);
        int ReturnMediaAction(int mediaId, int uid, DateTime returnDate);

        DateTime EstimatedReturnDate(int mediaID, int uid);
    }
}
