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
    public class EditLanguageModelImpl : iEditLanguageModel
    {
        static string CONNECTION_STRING = "Data Source=SQL5017.site4now.net;Initial Catalog=DB_9AB8B7_D19ES6911;Persist Security Info=True;User ID=DB_9AB8B7_D19ES6911_admin;Password=fe2y8xZ7";

        public bool CreateLanguage(string languageName)
        {
            using (SqlConnection dbConnection = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    //create query
                    String query = "INSERT INTO [dbo].[TabLanguage] ([LanguageName]) VALUES (@LanguageName)";

                    //Create new adapter
                    SqlDataAdapter DataAdapter = new SqlDataAdapter();

                    //Create empty dataset
                    Dataset UserDataset = new Dataset();

                    dbConnection.Open();

                    //insert insert command into the adapter
                    DataAdapter.InsertCommand = new SqlCommand(query, dbConnection);

                    DataAdapter.InsertCommand.Parameters.Add("@LanguageName", SqlDbType.VarChar).Value = languageName;


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

        public bool DeleteLanguage(int languageID)
        {
            using (SqlConnection dbConnection = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    //create query
                    String query = "DELETE FROM [dbo].[TabLanguage] WHERE ([LID] = @Original_LID)";

                    //Create new adapter
                    SqlDataAdapter DataAdapter = new SqlDataAdapter();

                    //Create empty dataset
                    Dataset UserDataset = new Dataset();

                    dbConnection.Open();

                    //insert insert command into the adapter
                    DataAdapter.DeleteCommand = new SqlCommand(query, dbConnection);

                    DataAdapter.DeleteCommand.Parameters.Add("@Original_LID", SqlDbType.Int).Value = languageID;


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

        public List<ModelLanguageDTO> PrintLanguageList()
        {
            using (SqlConnection dbConnection = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    List<ModelLanguageDTO> LanguageList = new List<ModelLanguageDTO>();
                    //create query
                    String query = "SELECT LID, LanguageName FROM dbo.TabLanguage";

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
                        LanguageList.Add(new ModelLanguageDTO(int.Parse(row[0].ToString()), row[1].ToString()));
                    }
                    // if there's a row successfully inserted, return true  and vice versa
                    return LanguageList;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error while adding new user: " + ex.Message);
                    return null;
                }
            }
        }

        public bool UpdateLanguage(int languageID, string languageName)
        {
            using (SqlConnection dbConnection = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    //create query
                    String query = "UPDATE TabLanguage SET LanguageName = @LanguageName WHERE (LID = @Original_LID)";

                    //Create new adapter
                    SqlDataAdapter DataAdapter = new SqlDataAdapter();

                    //Create empty dataset
                    Dataset UserDataset = new Dataset();

                    dbConnection.Open();

                    //insert insert command into the adapter
                    DataAdapter.UpdateCommand = new SqlCommand(query, dbConnection);
                    DataAdapter.UpdateCommand.Parameters.Add("@Original_LID", SqlDbType.Int).Value = languageID;
                    DataAdapter.UpdateCommand.Parameters.Add("@LanguageName", SqlDbType.VarChar).Value = languageName;

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
