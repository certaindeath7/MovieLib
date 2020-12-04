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
    public class EditMediaModelImpl : iEditMediaModel
    {
        // declare connection
        static string CONNECTION_STRING = "Data Source=SQL5017.site4now.net;Initial Catalog=DB_9AB8B7_D19ES6911;Persist Security Info=True;User ID=DB_9AB8B7_D19ES6911_admin;Password=fe2y8xZ7";

        public bool CreateMedia(string title, int genre, int director, int language, int publishYear, decimal budget)
        {
            using (SqlConnection dbConnection = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    //create query
                    String AddNewMedia = "INSERT INTO TabMedia ([Title], [Genre], [Director], [Language], [PublishYear], [Budget]) VALUES (@Title,@Genre,@Director,@Language,@PublishYear,@Budget)";

                    //Create new adapter
                    SqlDataAdapter DataAdapter = new SqlDataAdapter();

                    //Create empty dataset
                    Dataset UserDataset = new Dataset();

                    dbConnection.Open();

                    //insert insert command into the adapter
                    DataAdapter.InsertCommand = new SqlCommand(AddNewMedia, dbConnection);

                    DataAdapter.InsertCommand.Parameters.Add("@Title", SqlDbType.VarChar).Value = title;
                    DataAdapter.InsertCommand.Parameters.Add("@Genre", SqlDbType.Int).Value = genre;
                    DataAdapter.InsertCommand.Parameters.Add("@Director", SqlDbType.Int).Value = director;
                    DataAdapter.InsertCommand.Parameters.Add("@Language", SqlDbType.Int).Value =language;
                    DataAdapter.InsertCommand.Parameters.Add("@PublishYear", SqlDbType.Int).Value = publishYear;
                    DataAdapter.InsertCommand.Parameters.Add("@Budget", SqlDbType.Decimal).Value = budget;

                    int RowCount = DataAdapter.InsertCommand.ExecuteNonQuery();
                    // if there's a row successfully inserted, return true  and vice versa
                    return RowCount > 0 ? true : false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error while adding new user: " + ex.Message);
                    return false;
                }
            }
        }

        public bool DeleteMedia(int mediaID)
        {
            using (SqlConnection dbConnection = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    //create query
                    String query = "DELETE FROM TabMedia WHERE (MediaID = @Original_MediaID)";

                    //Create new adapter
                    SqlDataAdapter DataAdapter = new SqlDataAdapter();

                    //Create empty dataset
                    Dataset UserDataset = new Dataset();

                    dbConnection.Open();

                    //insert insert command into the adapter
                    DataAdapter.DeleteCommand = new SqlCommand(query, dbConnection);

                    DataAdapter.DeleteCommand.Parameters.Add("@Original_MediaID", SqlDbType.Int).Value = mediaID;
                

                    int RowCount = DataAdapter.DeleteCommand.ExecuteNonQuery();
                    // if there's a row successfully inserted, return true  and vice versa
                    return RowCount > 0 ? true : false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error while adding new user: " + ex.Message);
                    return false;
                }
            }
        }

        public bool UpdateMedia(int mediaID, string title, int genreID, int directorID, int languageID, int publishYear, decimal budget)
        {
            using (SqlConnection dbConnection = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    //create query
                    String query = "UPDATE TabMedia SET Title = @Title, Genre = @Genre, Director = @Director, Language = @Language, PublishYear = @PublishYear, Budget = @Budget WHERE (MediaID = @Original_MediaID)";

                    //Create new adapter
                    SqlDataAdapter DataAdapter = new SqlDataAdapter();

                    //Create empty dataset
                    Dataset UserDataset = new Dataset();

                    dbConnection.Open();

                    //insert insert command into the adapter
                    DataAdapter.UpdateCommand = new SqlCommand(query, dbConnection);

                    DataAdapter.UpdateCommand.Parameters.Add("@Original_MediaID", SqlDbType.Int).Value = mediaID;
                    DataAdapter.UpdateCommand.Parameters.Add("@Title", SqlDbType.VarChar).Value = title;
                    DataAdapter.UpdateCommand.Parameters.Add("@Genre", SqlDbType.Int).Value = genreID;
                    DataAdapter.UpdateCommand.Parameters.Add("@Director", SqlDbType.Int).Value = directorID;
                    DataAdapter.UpdateCommand.Parameters.Add("@Language", SqlDbType.Int).Value = languageID;
                    DataAdapter.UpdateCommand.Parameters.Add("@PublishYear", SqlDbType.Int).Value = publishYear;
                    DataAdapter.UpdateCommand.Parameters.Add("@Budget", SqlDbType.Decimal).Value = budget;

                    int RowCount = DataAdapter.UpdateCommand.ExecuteNonQuery();
                    // if there's a row successfully inserted, return true  and vice versa
                    return RowCount > 0 ? true : false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error while adding new user: " + ex.Message);
                    return false;
                }
            }
        }
    }
}
