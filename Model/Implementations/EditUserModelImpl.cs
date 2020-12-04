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
    public class EditUserModelImpl : iEditUserModel
    {
        static string CONNECTION_STRING = "Data Source=SQL5017.site4now.net;Initial Catalog=DB_9AB8B7_D19ES6911;Persist Security Info=True;User ID=DB_9AB8B7_D19ES6911_admin;Password=fe2y8xZ7";

        public bool CreateUser(string userName, string password, int userLevel, string email)
        {
            using (SqlConnection dbConnection = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    List<ModelUserDTO> UserIdList = new List<ModelUserDTO>();
                    //create query
                    String query = "INSERT INTO [dbo].[TabUser] ([UserName], [Password], [UserLevel], [UserEmail]) VALUES (@UserName, @Password, @UserLevel, @UserEmail)";

                    //Create new adapter
                    SqlDataAdapter DataAdapter = new SqlDataAdapter();

                    //Create empty dataset
                    Dataset UserDataset = new Dataset();

                    dbConnection.Open();

                    //insert insert command into the adapter
                    DataAdapter.InsertCommand = new SqlCommand(query, dbConnection);


                    DataAdapter.InsertCommand.Parameters.Add("@UserName", SqlDbType.VarChar).Value = userName;
                    DataAdapter.InsertCommand.Parameters.Add("@Password", SqlDbType.VarChar).Value = password;
                    DataAdapter.InsertCommand.Parameters.Add("@UserLevel", SqlDbType.Int).Value = userLevel;
                    DataAdapter.InsertCommand.Parameters.Add("@UserEmail", SqlDbType.VarChar).Value = email;
                    int RowCount = DataAdapter.InsertCommand.ExecuteNonQuery();
                    return RowCount > 0 ? true : false;
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    return false;
                }
            }
        }

        public bool DeleteUser(int userID)
        {
            using (SqlConnection dbConnection = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    List<ModelUserDTO> UserIdList = new List<ModelUserDTO>();
                    //create query
                    String query = "DELETE FROM TabUser WHERE (UID = @Original_UID)";

                    //Create new adapter
                    SqlDataAdapter DataAdapter = new SqlDataAdapter();

                    //Create empty dataset
                    Dataset UserDataset = new Dataset();

                    dbConnection.Open();

                    //insert insert command into the adapter
                    DataAdapter.DeleteCommand = new SqlCommand(query, dbConnection);


                    DataAdapter.DeleteCommand.Parameters.Add("@Original_UID", SqlDbType.Int).Value = userID;
                    
                    int RowCount = DataAdapter.DeleteCommand.ExecuteNonQuery();
                    return RowCount > 0 ? true : false;

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    return false;
                }
            }
        }

        public List<ModelUserDTO> ListAllUser()
        {
            using (SqlConnection dbConnection = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    List<ModelUserDTO> UserList = new List<ModelUserDTO>();
                    //create query
                    String query = "SELECT UID, UserName, Password, UserLevel, UserEmail FROM dbo.TabUser";

                    //Create new adapter
                    SqlDataAdapter DataAdapter = new SqlDataAdapter();

                    //Create empty dataset
                    Dataset UserDataset = new Dataset();

                    dbConnection.Open();

                    //insert insert command into the adapter
                    DataAdapter.SelectCommand = new SqlCommand(query, dbConnection);


                    int RowCount = DataAdapter.Fill(UserDataset, "userList");
                    foreach (DataRow row in UserDataset.Tables["userList"].Rows)
                    {
                        UserList.Add(new ModelUserDTO(int.Parse(row[0].ToString()), row[1].ToString(), row[2].ToString(), int.Parse(row[3].ToString()), row[4].ToString()));
                    }
                    // if there's a row successfully inserted, return true  and vice versa
                    return UserList;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error while adding new user: " + ex.Message);
                    return null;
                }
            }
        }

        public bool UpdateUser(int userID, string username, string password, int userLevel, string email)
        {
            using (SqlConnection dbConnection = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    //create query
                    String query = "UPDATE TabUser SET UserName = @UserName, Password = @Password, UserLevel = @UserLevel, UserEmail = @UserEmail WHERE (UID = @Original_UID)";

                    //Create new adapter
                    SqlDataAdapter DataAdapter = new SqlDataAdapter();

                    //Create empty dataset
                    Dataset UserDataset = new Dataset();

                    dbConnection.Open();

                    //insert insert command into the adapter
                    DataAdapter.UpdateCommand = new SqlCommand(query, dbConnection);
                    DataAdapter.UpdateCommand.Parameters.Add("@Original_UID", SqlDbType.Int).Value = userID;
                    DataAdapter.UpdateCommand.Parameters.Add("@UserName", SqlDbType.VarChar).Value = username;
                    DataAdapter.UpdateCommand.Parameters.Add("@Password", SqlDbType.VarChar).Value = password;
                    DataAdapter.UpdateCommand.Parameters.Add("@UserLevel", SqlDbType.Int).Value = userLevel;
                    DataAdapter.UpdateCommand.Parameters.Add("@email", SqlDbType.VarChar).Value = email;

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
