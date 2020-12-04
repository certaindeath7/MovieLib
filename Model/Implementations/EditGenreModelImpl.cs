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
    public class EditGenreModelImpl : iEditGenreModel
    {
       static string CONNECTION_STRING = "Data Source=SQL5017.site4now.net;Initial Catalog=DB_9AB8B7_D19ES6911;Persist Security Info=True;User ID=DB_9AB8B7_D19ES6911_admin;Password=fe2y8xZ7";

        public bool CreateGenre(string genreName)
        {
            using (SqlConnection dbConnection = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    //create query
                    String query = "INSERT INTO [dbo].[TabGenre] ([GenreName]) VALUES (@GenreName)";

                    //Create new adapter
                    SqlDataAdapter DataAdapter = new SqlDataAdapter();

                    //Create empty dataset
                    Dataset UserDataset = new Dataset();

                    dbConnection.Open();

                    //insert insert command into the adapter
                    DataAdapter.InsertCommand = new SqlCommand(query, dbConnection);

                    DataAdapter.InsertCommand.Parameters.Add("@GenreName", SqlDbType.VarChar).Value = genreName;


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

        public bool DeleteGenre(int genreID)
        {
            using (SqlConnection dbConnection = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    //create query
                    String query = "DELETE FROM TabGenre WHERE (GID = @Original_GID)";

                    //Create new adapter
                    SqlDataAdapter DataAdapter = new SqlDataAdapter();

                    //Create empty dataset
                    Dataset UserDataset = new Dataset();

                    dbConnection.Open();

                    //insert insert command into the adapter
                    DataAdapter.DeleteCommand = new SqlCommand(query, dbConnection);

                    DataAdapter.DeleteCommand.Parameters.Add("@Original_GID", SqlDbType.Int).Value = genreID;


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

        public List<ModelGenreDTO> PrintGenreList()
        {
            using (SqlConnection dbConnection = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    List<ModelGenreDTO> GenreList = new List<ModelGenreDTO>();
                    //create query
                    String query = "SELECT GID, GenreName FROM dbo.TabGenre";

                    //Create new adapter
                    SqlDataAdapter DataAdapter = new SqlDataAdapter();

                    //Create empty dataset
                    Dataset UserDataset = new Dataset();

                    dbConnection.Open();

                    //insert insert command into the adapter
                    DataAdapter.SelectCommand = new SqlCommand(query, dbConnection);


                    int RowCount = DataAdapter.Fill(UserDataset, "genreList");
                    foreach (DataRow row in UserDataset.Tables["genreList"].Rows)
                    {
                        GenreList.Add(new ModelGenreDTO(int.Parse(row[0].ToString()), row[1].ToString()));
                    }
                    // if there's a row successfully inserted, return true  and vice versa
                    return GenreList;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error while adding new user: " + ex.Message);
                    return null;
                }
            }
        }

        public bool UpdateGenre(int genreID, string genreName)
        {
            using (SqlConnection dbConnection = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    //create query
                    String query = "UPDATE TabGenre SET GenreName = @GenreName WHERE (GID = @Original_GID)";

                    //Create new adapter
                    SqlDataAdapter DataAdapter = new SqlDataAdapter();

                    //Create empty dataset
                    Dataset UserDataset = new Dataset();

                    dbConnection.Open();

                    //insert insert command into the adapter
                    DataAdapter.UpdateCommand = new SqlCommand(query, dbConnection);
                    DataAdapter.UpdateCommand.Parameters.Add("@Original_GID", SqlDbType.Int).Value = genreID;
                    DataAdapter.UpdateCommand.Parameters.Add("@GenreName", SqlDbType.VarChar).Value = genreName;

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
