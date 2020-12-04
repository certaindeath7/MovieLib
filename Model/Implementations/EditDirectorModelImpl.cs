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
    public class EditDirectorModelImpl : iEditDirectorModel
    {
        static string CONNECTION_STRING = "Data Source=SQL5017.site4now.net;Initial Catalog=DB_9AB8B7_D19ES6911;Persist Security Info=True;User ID=DB_9AB8B7_D19ES6911_admin;Password=fe2y8xZ7";

        public bool CreateDirector(string directorName)
        {
            using (SqlConnection dbConnection = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    //create query
                    String query = "INSERT INTO [dbo].[TabDirector] ([DirectorName]) VALUES (@DirectorName)";

                    //Create new adapter
                    SqlDataAdapter DataAdapter = new SqlDataAdapter();

                    //Create empty dataset
                    Dataset UserDataset = new Dataset();

                    dbConnection.Open();

                    //insert insert command into the adapter
                    DataAdapter.InsertCommand = new SqlCommand(query, dbConnection);

                    DataAdapter.InsertCommand.Parameters.Add("@DirectorName", SqlDbType.VarChar).Value = directorName;
                   

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

        public bool DeleteDirect(int directorID)
        {
            using (SqlConnection dbConnection = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    //create query
                    String query = "DELETE FROM [dbo].[TabDirector] WHERE ([DID] = @Original_DID)";

                    //Create new adapter
                    SqlDataAdapter DataAdapter = new SqlDataAdapter();

                    //Create empty dataset
                    Dataset UserDataset = new Dataset();

                    dbConnection.Open();

                    //insert insert command into the adapter
                    DataAdapter.DeleteCommand = new SqlCommand(query, dbConnection);

                    DataAdapter.DeleteCommand.Parameters.Add("@Original_DID", SqlDbType.Int).Value = directorID;


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

        public bool UpdateDirector(int directorID, string directorName)
        {
            using (SqlConnection dbConnection = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    //create query
                    String query = "UPDATE [dbo].[TabDirector] SET [DirectorName] = @DirectorName WHERE ([DID] = @Original_DID)";

                    //Create new adapter
                    SqlDataAdapter DataAdapter = new SqlDataAdapter();

                    //Create empty dataset
                    Dataset UserDataset = new Dataset();

                    dbConnection.Open();

                    //insert insert command into the adapter
                    DataAdapter.UpdateCommand = new SqlCommand(query, dbConnection);
                    DataAdapter.UpdateCommand.Parameters.Add("@Original_DID", SqlDbType.Int).Value = directorID;
                    DataAdapter.UpdateCommand.Parameters.Add("@DirectorName", SqlDbType.VarChar).Value = directorName;

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

        public List<ModelDirectorDTO> PrintDirectorList()
        {
            using (SqlConnection dbConnection = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    List<ModelDirectorDTO> DirectorList = new List<ModelDirectorDTO>();
                    //create query
                    String query = "SELECT DID, DirectorName FROM dbo.TabDirector";

                    //Create new adapter
                    SqlDataAdapter DataAdapter = new SqlDataAdapter();

                    //Create empty dataset
                    Dataset UserDataset = new Dataset();

                    dbConnection.Open();

                    //insert insert command into the adapter
                    DataAdapter.SelectCommand = new SqlCommand(query, dbConnection);


                    int RowCount = DataAdapter.Fill(UserDataset, "directorList");
                    foreach (DataRow row in UserDataset.Tables["directorList"].Rows)
                    {
                        DirectorList.Add(new ModelDirectorDTO(int.Parse(row[0].ToString()), row[1].ToString()));
                    }
                    // if there's a row successfully inserted, return true  and vice versa
                    return DirectorList;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error while adding new user: " + ex.Message);
                    return null;
                }
            }
        }
    }
}
