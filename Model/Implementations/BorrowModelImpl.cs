using Model.DTOs;
using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Implementations
{
    public class BorrowModelImpl : iBorrowModel
    {
        static string CONNECTION_STRING = "Data Source=SQL5017.site4now.net;Initial Catalog=DB_9AB8B7_D19ES6911;Persist Security Info=True;User ID=DB_9AB8B7_D19ES6911_admin;Password=fe2y8xZ7";

     
        // all the media is being borrowed
        public List<ModelMediaDTO> UserBorrowedMedia(int uid)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    List<ModelMediaDTO> BorrowedMediaList = new List<ModelMediaDTO>();

                    //declare sql
                    String query = "SELECT TabMedia.MediaID, TabBorrow.UID, TabMedia.Title, TabMedia.PublishYear, TabMedia.Budget, TabDirector.DirectorName, TabGenre.GenreName, TabLanguage.LanguageName, TabBorrow.BorrowDate, TabBorrow.ReturnDate FROM TabMedia INNER JOIN TabDirector ON TabMedia.Director = TabDirector.DID INNER JOIN TabGenre ON TabMedia.Genre = TabGenre.GID INNER JOIN TabLanguage ON TabMedia.Language = TabLanguage.LID FULL OUTER JOIN TabBorrow ON TabMedia.MediaID = TabBorrow.MediaID FULL OUTER JOIN TabReserved ON TabMedia.MediaID = TabReserved.MediaID WHERE (TabBorrow.BorrowDate IS NOT NULL) AND (TabBorrow.ActualReturnDate < TabBorrow.BorrowDate) AND (TabBorrow.UID = @UID)";
                    SqlDataAdapter DataAdapter = new SqlDataAdapter();
                    DataSet UserDataSet = new DataSet();


                    connection.Open();
                    DataAdapter.SelectCommand = new SqlCommand(query, connection);
                    DataAdapter.SelectCommand.Parameters.Add("@UID", SqlDbType.Int).Value = uid;

                    int RowCount = DataAdapter.Fill(UserDataSet, "borrowedMedia");
                    foreach (DataRow row in UserDataSet.Tables["borrowedMedia"].Rows)
                    {
                        BorrowedMediaList.Add(new ModelMediaDTO(int.Parse(row[0].ToString()), int.Parse(row[1].ToString()), row[2].ToString(), int.Parse(row[3].ToString()), decimal.Parse(row[4].ToString()), row[5].ToString(), row[6].ToString(), row[7].ToString(), Convert.ToDateTime(row[8].ToString()), Convert.ToDateTime(row[9].ToString())));

                    }
                    return BorrowedMediaList;

                }
                catch (Exception exception)
                {

                    Console.WriteLine("Error : " + exception.Message);
                    return null;
                }

            }
        }


        //get all the media that hasnt been reserved or borrowed
        public List<ModelMediaDTO> AvailableMedia()
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    List<ModelMediaDTO> AvailableMedia = new List<ModelMediaDTO>();

                    //declare sql
                    String query = "SELECT distinct TabMedia.MediaID, TabMedia.Title, TabMedia.PublishYear, TabMedia.Budget, TabDirector.DirectorName, TabGenre.GenreName, TabLanguage.LanguageName, TabBorrow.ActualReturnDate, TabBorrow.BorrowDate FROM TabMedia INNER JOIN TabDirector ON TabMedia.Director = TabDirector.DID INNER JOIN TabGenre ON TabMedia.Genre = TabGenre.GID INNER JOIN TabLanguage ON TabMedia.Language = TabLanguage.LID LEFT OUTER JOIN TabBorrow ON TabMedia.MediaID = TabBorrow.MediaID FULL OUTER JOIN TabReserved ON TabMedia.MediaID = TabReserved.MediaID WHERE (TabReserved.ReservedDate IS NULL) AND (TabBorrow.BorrowDate <= TabBorrow.ActualReturnDate) OR (TabReserved.ReservedDate IS NULL) AND (TabBorrow.BorrowDate IS NULL)";
                    SqlDataAdapter DataAdapter = new SqlDataAdapter();
                    DataSet UserDataSet = new DataSet();


                    connection.Open();
                    DataAdapter.SelectCommand = new SqlCommand(query, connection);

                    int RowCount = DataAdapter.Fill(UserDataSet, "availableMedia");
                    foreach (DataRow row in UserDataSet.Tables["availableMedia"].Rows)
                    {
                        AvailableMedia.Add(new ModelMediaDTO(int.Parse(row[0].ToString()), row[1].ToString(), int.Parse(row[2].ToString()), decimal.Parse(row[3].ToString()), row[4].ToString(), row[5].ToString(), row[6].ToString()));
                    }
                    return AvailableMedia;

                }
                catch (Exception exception)
                {

                    Console.WriteLine("Error : " + exception.Message);
                    return null;
                }

            }
        }

        // show on reporting page that all the borrowed media
        public List<ModelMediaDTO> AdminBorrowedMedia()
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    List<ModelMediaDTO> ReservedMediaList = new List<ModelMediaDTO>();
                    // Define the query

                    String query = "SELECT TabMedia.MediaID, TabReturned.UID, TabMedia.Title, TabMedia.PublishYear, TabMedia.Budget, TabDirector.DirectorName, TabGenre.GenreName, TabLanguage.LanguageName, TabReturned.BorrowDate, TabReturned.ReturnDate, TabReturned.ActualReturnDate, TabReturned.LateFee FROM TabMedia INNER JOIN TabDirector ON TabMedia.Director = TabDirector.DID INNER JOIN TabGenre ON TabMedia.Genre = TabGenre.GID INNER JOIN TabLanguage ON TabMedia.Language = TabLanguage.LID FULL OUTER JOIN TabReturned ON TabMedia.MediaID = TabReturned.MediaID WHERE (TabReturned.BorrowDate IS NOT NULL)";
                    //declaration
                    SqlDataAdapter DataAdapter = new SqlDataAdapter();
                    DataSet UserDataSet = new DataSet();


                    connection.Open();
                    DataAdapter.SelectCommand = new SqlCommand(query, connection);



                    int RowCount = DataAdapter.Fill(UserDataSet, "reservedTable");
                    foreach (DataRow row in UserDataSet.Tables["reservedTable"].Rows)
                    {
                        ReservedMediaList.Add(new ModelMediaDTO(int.Parse(row[0].ToString()), int.Parse(row[1].ToString()), row[2].ToString(), int.Parse(row[3].ToString()), decimal.Parse(row[4].ToString()), row[5].ToString(), row[6].ToString(), row[7].ToString(), Convert.ToDateTime(row[8].ToString()), Convert.ToDateTime(row[9].ToString())));
                    }


                    return ReservedMediaList;

                }
                catch (Exception exception)
                {

                    Console.WriteLine("Error : " + exception.Message);
                    return null;
                }
            }
        }

        public List<ModelMediaDTO> AdminReservedMedia()
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    List<ModelMediaDTO> ReservedMediaList = new List<ModelMediaDTO>();
                    // Define the query

                    String query = "SELECT TabMedia.MediaID, TabMedia.Title, TabMedia.PublishYear, TabMedia.Budget, TabDirector.DirectorName, TabGenre.GenreName, TabLanguage.LanguageName, TabReserved.ReservedDate FROM TabMedia INNER JOIN TabDirector ON TabMedia.Director = TabDirector.DID INNER JOIN TabGenre ON TabMedia.Genre = TabGenre.GID INNER JOIN TabLanguage ON TabMedia.Language = TabLanguage.LID FULL OUTER JOIN TabReserved ON TabMedia.MediaID = TabReserved.MediaID WHERE (TabReserved.ReservedDate IS NOT NULL)";
                    //declaration
                    SqlDataAdapter DataAdapter = new SqlDataAdapter();
                    DataSet UserDataSet = new DataSet();


                    connection.Open();
                    DataAdapter.SelectCommand = new SqlCommand(query, connection);



                    int RowCount = DataAdapter.Fill(UserDataSet, "reservedTable");
                    foreach (DataRow row in UserDataSet.Tables["reservedTable"].Rows)
                    {
                        ReservedMediaList.Add(new ModelMediaDTO(int.Parse(row[0].ToString()), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), int.Parse(row[5].ToString()), decimal.Parse(row[6].ToString())));
                    }


                    return ReservedMediaList;

                }
                catch (Exception exception)
                {

                    Console.WriteLine("Error : " + exception.Message);
                    return null;
                }
            }
        }

      // iit will insert into returned media record
        public bool IsMediaReturned(int uid, int mediaId, DateTime borrowDate, DateTime returnDate)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    // Define the SQL
                    String query = "INSERT INTO [dbo].[TabReturned] ( [UID], [MediaID], [BorrowDate], [ReturnDate], [ActualReturnDate], [LateFee]) VALUES ( @UID, @MediaID, @BorrowDate, @ReturnDate, @ActualReturnDate, @LateFee); SELECT Id, UID, MediaID, BorrowDate, ReturnDate, ActualReturnDate, LateFee FROM TabReturned ";
                    SqlDataAdapter DataAdapter = new SqlDataAdapter();
                    DataSet UserDataSet = new DataSet();
                    
                    //call the estisatemedReturndata function
                    DateTime DateMightReturn  = EstimatedReturnDate(mediaId, uid);

                    // for each day late, user would have to pay $2
                    int PenaltyFee = 2 * (DateTime.Today - DateMightReturn.Date).Days;
                    if (DateTime.Today == DateMightReturn.Date)
                    {
                        PenaltyFee = 0;
                    }

                    connection.Open();
                    DataAdapter.InsertCommand = new SqlCommand(query, connection);


                    DataAdapter.InsertCommand.Parameters.Add("@UID", SqlDbType.Int).Value = uid;
                    DataAdapter.InsertCommand.Parameters.Add("@MediaID", SqlDbType.Int).Value = mediaId;
                    DataAdapter.InsertCommand.Parameters.Add("@BorrowDate", SqlDbType.DateTime).Value = borrowDate;
                    DataAdapter.InsertCommand.Parameters.Add("@ReturnDate", SqlDbType.DateTime).Value = returnDate;
                    DataAdapter.InsertCommand.Parameters.Add("@ActualReturnDate", SqlDbType.DateTime).Value = DateTime.Today;
                    DataAdapter.InsertCommand.Parameters.Add("@LateFee", SqlDbType.Int).Value = PenaltyFee;

                    int RowCount = DataAdapter.InsertCommand.ExecuteNonQuery();

                    return RowCount > 0 ? true : false;

                }
                catch (Exception exception)
                {
                    Console.WriteLine("Error: " + exception.Message);
                    return false;
                }
            }
        }

        public bool IsMediaReserved(int uid, int mediaID, DateTime reserveDate)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    // Define the SQL
                    String query = "INSERT INTO [dbo].[TabReserved] ([UID], [MediaID], [ReservedDate]) VALUES (@UID, @MediaID, @ReservedDate)";
                    SqlDataAdapter DataAdapter = new SqlDataAdapter();
                    DataSet UserDataSet = new DataSet();

                    connection.Open();
                    DataAdapter.InsertCommand = new SqlCommand(query, connection);

                    DataAdapter.InsertCommand.Parameters.Add("@UID", SqlDbType.Int).Value = uid;
                    DataAdapter.InsertCommand.Parameters.Add("@MediaID", SqlDbType.Int).Value = mediaID;
                    DataAdapter.InsertCommand.Parameters.Add("@ReservedDate", SqlDbType.DateTime).Value = reserveDate;

                    int RowCount = DataAdapter.InsertCommand.ExecuteNonQuery();
                    return RowCount > 0 ? true : false;

                }
                catch (Exception exception)
                {

                    Console.WriteLine("Error : " + exception.Message);
                    return false;
                }
            }
        }

        public bool IsMediaBorrowed(int uid, int mediaId, DateTime borrowDate, DateTime returnDate)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                try
                {

                    //declare sql
                    String query = "INSERT INTO TabBorrow (UID, MediaID, BorrowDate, ReturnDate, ActualReturnDate, LateFee) VALUES (@UID,@MediaID,@BorrowDate,@ReturnDate,@ActualReturnDate,@LateFee)";
                    SqlDataAdapter DataAdapter = new SqlDataAdapter();
                    DataSet UserDataSet = new DataSet();

                    connection.Open();
                    DateTime dateTime = new DateTime(2000, 1, 1);
                    DataAdapter.InsertCommand = new SqlCommand(query, connection);

                    DataAdapter.InsertCommand.Parameters.Add("@UID", SqlDbType.Int).Value = uid;
                    DataAdapter.InsertCommand.Parameters.Add("@MediaID", SqlDbType.Int).Value = mediaId;
                    DataAdapter.InsertCommand.Parameters.Add("@BorrowDate", SqlDbType.DateTime).Value = borrowDate;
                    DataAdapter.InsertCommand.Parameters.Add("@ReturnDate", SqlDbType.DateTime).Value = returnDate;
                    DataAdapter.InsertCommand.Parameters.Add("@ActualReturnDate", SqlDbType.DateTime).Value = dateTime;
                    DataAdapter.InsertCommand.Parameters.Add("@LateFee", SqlDbType.Int).Value = 0;
             
                    int RowCount = DataAdapter.InsertCommand.ExecuteNonQuery();
                    return RowCount > 0 ? true : false;


                }
                catch (Exception exception)
                {

                    Console.WriteLine("Error : " + exception.Message);
                    return false;
                }

            }
        }

        //if the media was returned, it would delete from borrowed media list
        public bool RemoveReturnedMedia(int mediaId, int uid)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    // Define the SQL
                    String query = "DELETE FROM TabBorrow WHERE (UID = @Original_UID) AND (MediaID = @Original_MediaID) ";
                    SqlDataAdapter DataAdapter = new SqlDataAdapter();
                    DataSet UserDataSet = new DataSet();
                    connection.Open();
                    DataAdapter.DeleteCommand = new SqlCommand(query, connection);

                    DataAdapter.DeleteCommand.Parameters.Add("@Original_UID", SqlDbType.Int).Value = uid;
                    DataAdapter.DeleteCommand.Parameters.Add("@Original_MediaID", SqlDbType.Int).Value = mediaId;

                    // Fill the DB
                    int RowCount = DataAdapter.DeleteCommand.ExecuteNonQuery();

                    return RowCount > 0 ? true : false;

                }
                catch (Exception exception)
                {
                    Console.WriteLine("Error : " + exception.Message);
                    return false;
                }
            }
        }

        // check if the Media has been reserved or borrowed.
        public bool IsMediaAvailable(int mediaId)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                   
                    // Define the SQL
                    String query = "SELECT TabMedia.MediaID, TabMedia.Title, TabMedia.PublishYear, TabMedia.Budget, TabDirector.DirectorName, TabGenre.GenreName, TabLanguage.LanguageName FROM TabMedia INNER JOIN TabDirector ON TabMedia.Director = TabDirector.DID INNER JOIN TabGenre ON TabMedia.Genre = TabGenre.GID INNER JOIN TabLanguage ON TabMedia.Language = TabLanguage.LID FULL OUTER JOIN TabBorrow ON TabMedia.MediaID = TabBorrow.MediaID FULL OUTER JOIN TabReserved ON TabMedia.MediaID = TabReserved.MediaID WHERE (TabReserved.ReservedDate IS NULL) AND (TabBorrow.BorrowDate <= TabBorrow.ActualReturnDate) AND (TabMedia.MediaID = @mediaID) OR (TabReserved.ReservedDate IS NULL) AND (TabBorrow.BorrowDate IS NULL) AND (TabMedia.MediaID = @mediaID)";
                    SqlDataAdapter DataAdapter = new SqlDataAdapter();
                    DataSet UserDataSet = new DataSet();
                    connection.Open();
                    DataAdapter.SelectCommand = new SqlCommand(query, connection);

                    DataAdapter.SelectCommand.Parameters.Add("@mediaID", SqlDbType.Int).Value = mediaId;
                    // Fill the DB
                    int RowCount = DataAdapter.Fill(UserDataSet, "mediaBrowse");

                    return RowCount > 0 ? true : false;
                }
                catch (Exception exception)
                {
                    Console.WriteLine("Error : " + exception.Message);
                    return false;
                }
            }
        }
        public bool IsMediaReservedByUser(int mediaId, int uid)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                try
                {

                    // Define the SQL
                    String query = "SELECT RID, UID, MediaID, ReservedDate FROM TabReserved where UID=@UID and MediaID=@MediaID";
                    SqlDataAdapter DataAdapter = new SqlDataAdapter();
                    DataSet UserDataSet = new DataSet();
                    connection.Open();
                    DataAdapter.SelectCommand = new SqlCommand(query, connection);

                    DataAdapter.SelectCommand.Parameters.Add("@MediaID", SqlDbType.Int).Value = mediaId;
                    DataAdapter.SelectCommand.Parameters.Add("@UID", SqlDbType.Int).Value = uid;

                    // Fill the DB
                    int RowCount = DataAdapter.Fill(UserDataSet, "mediaBrowse");

                    return RowCount > 0 ? true : false;

                }
                catch (Exception exception)
                {
                    Console.WriteLine("Error : " + exception.Message);
                    return false;
                }
            }
        }

        public int ReturnMediaAction(int mediaId, int uid, DateTime returnDate)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    // Define the SQL
                    String query = "SELECT UID, MediaID, BorrowDate, ReturnDate FROM TabBorrow WHERE (UID = @userID) AND (MediaID = @mediaID)";
                    SqlDataAdapter DataAdapter = new SqlDataAdapter();
                    DataSet UserDataSet = new DataSet();

                    //call the estisatemedReturndata function
                    DateTime DateMightReturn = EstimatedReturnDate(mediaId, uid);

                    // for each day late, user would have to pay $2
                    int PenaltyFee = 2 * (DateTime.Today - DateMightReturn.Date).Days;
                    if (DateTime.Today == DateMightReturn.Date)
                    {
                        PenaltyFee = 0;
                    }

                    connection.Open();
                    DataAdapter.SelectCommand = new SqlCommand(query, connection);

                    DataAdapter.SelectCommand.Parameters.Add("@MediaID", SqlDbType.Int).Value = mediaId;
                    DataAdapter.SelectCommand.Parameters.Add("@UID", SqlDbType.Int).Value = uid;


                    int RowCount = DataAdapter.Fill(UserDataSet, "returnList");
                    foreach(DataRow row in UserDataSet.Tables["returnList"].Rows)
                    {
                        ModelMediaDTO newMedia = new ModelMediaDTO(int.Parse(row[0].ToString()), int.Parse(row[1].ToString()), Convert.ToDateTime(row[2].ToString()), Convert.ToDateTime(row[3].ToString()));
                    }

                    // after a media has been returned, add it to returned media admin's list
                    // then delete it from borrow record;
                    return PenaltyFee;

                }
                catch (Exception exception)
                {
                    Console.WriteLine("Error: " + exception.Message);
                    return 0;
                }
            }
        }

        public DateTime EstimatedReturnDate(int mediaID, int uid)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    // Define the SQL
                    String query = "SELECT ReturnDate FROM TabBorrow WHERE (UID = @userID) AND (MediaID = @mediaID)";
                    SqlDataAdapter DataAdapter = new SqlDataAdapter();
                    DataSet UserDataSet = new DataSet();

                    connection.Open();
                    DataAdapter.InsertCommand = new SqlCommand(query, connection);

                    DataAdapter.InsertCommand.Parameters.Add("@UID", SqlDbType.Int).Value = uid;
                    DataAdapter.InsertCommand.Parameters.Add("@MediaID", SqlDbType.Int).Value = mediaID;

                    DateTime returnDate = new DateTime(2000, 1, 1);


                    int RowCount = DataAdapter.Fill(UserDataSet, "returnMedia");
                    foreach (DataRow row in UserDataSet.Tables["returnMedia"].Rows)
                    {
                        returnDate = Convert.ToDateTime(row[0].ToString());
                    }
                    return returnDate;

                }
                catch (Exception exception)
                {

                    Console.WriteLine("Error : " + exception.Message);
                    return new DateTime(2000, 1, 1);
                }
            }
        }

        
    }
}
