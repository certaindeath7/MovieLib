using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Model
{
    public class UserManagementImpl : iUserManagement
    {
        static string CONNECTION_STRING = "Data Source=SQL5017.site4now.net;Initial Catalog=DB_9AB8B7_D19ES6911;Persist Security Info=True;User ID=DB_9AB8B7_D19ES6911_admin;Password=fe2y8xZ7";
        public bool AddUser(string userName, string password, int userLevel, string email)
        {
           // 1. Create a connection
           using (SqlConnection dbConnection = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    //create query
                    String AddNewUser = "INSERT INTO [dbo].[TabUser] ([UserName], [Password], [UserLevel], [UserEmail]) VALUES (@UserName, @Password, @UserLevel, @UserEmail);";

                    //Create new adapter
                    SqlDataAdapter DataAdapter = new SqlDataAdapter();

                    //Create empty dataset
                    Dataset UserDataset = new Dataset();

                    dbConnection.Open();

                    //insert insert command into the adapter
                    DataAdapter.InsertCommand = new SqlCommand(AddNewUser, dbConnection);

                    DataAdapter.InsertCommand.Parameters.Add("@UserName", SqlDbType.VarChar).Value = userName;
                    DataAdapter.InsertCommand.Parameters.Add("@Password", SqlDbType.VarChar).Value = password;
                    DataAdapter.InsertCommand.Parameters.Add("@UserLevel", SqlDbType.Int).Value = userLevel;
                    DataAdapter.InsertCommand.Parameters.Add("@UserEmail", SqlDbType.VarChar).Value = email;

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

        /*
        public bool ChangePassword(string userName, string oldPassword, string newPassword)
        {
            using (SqlConnection dbConnection = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    //create query
                    String query = "SELECT UserLevel FROM dbo.TabUser WHERE UserName=@UserName AND Password=@PASSWORD";

                    //Create empty dataset
                    DataSet UserDataset = new DataSet();

                    dbConnection.Open();

                    //insert insert command into the adapter
                    SqlDataAdapter UserAdapter = new SqlDataAdapter();
                    UserAdapter.SelectCommand = new SqlCommand(Validate, dbConnection);


                    UserAdapter.SelectCommand.Parameters.Add("@UserName", SqlDbType.VarChar).Value = userName;
                    UserAdapter.SelectCommand.Parameters.Add("@Password", SqlDbType.VarChar).Value = password;

                    int RowCount = UserAdapter.Fill(UserDataset);
                    ModelUserDTO newUser = null;
                    if (RowCount > 0)
                    {
                        foreach (DataRow row in UserDataset.Tables[0].Rows)
                        {
                            newUser = new ModelUserDTO(int.Parse(row[0].ToString()));
                        }
                        return newUser.UserLevel;
                    }
                    else
                    {
                        Console.WriteLine("Error");
                        return -1;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error while validating user: " + ex.Message);
                    return -1;
                }
            }
        }*/

        public int UserLogin(string userName, string password)
        {
            using (SqlConnection dbConnection = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    //create query
                    String Validate = "SELECT UserLevel FROM dbo.TabUser WHERE UserName=@UserName AND Password=@PASSWORD";

                    //Create empty dataset
                    DataSet UserDataset = new DataSet();

                    dbConnection.Open();

                    //insert insert command into the adapter
                    SqlDataAdapter UserAdapter = new SqlDataAdapter();
                    UserAdapter.SelectCommand = new SqlCommand(Validate, dbConnection);


                    UserAdapter.SelectCommand.Parameters.Add("@UserName", SqlDbType.VarChar).Value = userName;
                    UserAdapter.SelectCommand.Parameters.Add("@Password", SqlDbType.VarChar).Value = password;

                    int RowCount = UserAdapter.Fill(UserDataset);
                    ModelUserDTO newUser = null;
                    if (RowCount > 0)
                    {
                        foreach (DataRow row in UserDataset.Tables[0].Rows)
                        {
                            newUser = new ModelUserDTO(int.Parse(row[0].ToString()));
                        }
                        return newUser.UserLevel;
                    }
                    else
                    {
                        Console.WriteLine("Error");
                        return -1;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error while validating user: " + ex.Message);
                    return -1;
                }
            }
        }
        public int CastUserId(string userName)
        {
            using (SqlConnection dbConnection = new SqlConnection(CONNECTION_STRING))
            {
                try
                {

                    //create query
                    String query = "SELECT UID FROM TabUser WHERE UserName=@UserName";

                    //Create new adapter
                    SqlDataAdapter DataAdapter = new SqlDataAdapter();

                    //Create empty dataset
                    Dataset UserDataset = new Dataset();

                    dbConnection.Open();

                    //insert insert command into the adapter
                    DataAdapter.SelectCommand = new SqlCommand(query, dbConnection);

                    DataAdapter.SelectCommand.Parameters.Add("@UserName", SqlDbType.VarChar).Value = userName;

                    int Userid = 0;
                    int RowCount = DataAdapter.Fill(UserDataset, "userIdList");
                    
                    foreach (DataRow row in UserDataset.Tables["userIdList"].Rows)
                    {
                        Userid = int.Parse(row[0].ToString());
                    }
                    return Userid;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error while adding new user: " + ex.Message);
                    return 0;
                }
            }
        }
    }
}
