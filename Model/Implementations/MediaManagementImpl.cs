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
    public class MediaManagementImpl : iMediaManagement
    {
        static string CONNECTION_STRING = "Data Source=SQL5017.site4now.net;Initial Catalog=DB_9AB8B7_D19ES6911;Persist Security Info=True;User ID=DB_9AB8B7_D19ES6911_admin;Password=fe2y8xZ7";
        public List<ModelMediaDTO> BrowseAllMedia()
        {
            // 1. Create a connection
            SqlConnection dbConnection = new SqlConnection(CONNECTION_STRING);
            
               
                try
                {
                    List<ModelMediaDTO> browseMedia = new List<ModelMediaDTO>();

                    //create query
                    String query = "SELECT MediaID, Title, GenreName, DirectorName, LanguageName, PublishYear, Budget, Genre, Director, Language FROM dbo.ViewMedia ";

                    //Create new adapter
                    SqlDataAdapter DataAdapter = new SqlDataAdapter();

                    //Create empty dataset
                    Dataset UserDataset = new Dataset();

                    dbConnection.Open();

                    //insert insert command into the adapter
                    DataAdapter.SelectCommand = new SqlCommand(query, dbConnection);

                    int RowCount = DataAdapter.Fill(UserDataset, "mediaBrowse");
                // if there's a row successfully inserted, return true  and vice versa
                if (RowCount > 0)
                {
                    foreach (DataRow row in UserDataset.Tables["mediaBrowse"].Rows)
                    {
                        browseMedia.Add(new ModelMediaDTO(int.Parse(row[0].ToString()), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), int.Parse(row[5].ToString()), decimal.Parse(row[6].ToString())));
                    }
                    return browseMedia;
                }
                else
                {
                    List<ModelMediaDTO> listMedia = new List<ModelMediaDTO>();

                    Console.WriteLine("Errr while validation user: " );
                    return listMedia;
                }


                }
                catch (Exception ex)
                {
                    List<ModelMediaDTO> browseMedia = new List<ModelMediaDTO>();

                    Console.WriteLine("Errr while validation user: " + ex.Message);
                    return browseMedia;
                }
                

            
        }

        public int CastMediaId(string title)
        {
            using (SqlConnection dbConnection = new SqlConnection(CONNECTION_STRING))
            {
                try
                {
                    List<ModelUserDTO> UserIdList = new List<ModelUserDTO>();
                    //create query
                    String query = "SELECT TabMedia.MediaID FROM TabMedia WHERE (TabMedia.Title=@title)";

                    //Create new adapter
                    SqlDataAdapter DataAdapter = new SqlDataAdapter();

                    //Create empty dataset
                    Dataset UserDataset = new Dataset();

                    dbConnection.Open();

                    //insert insert command into the adapter
                    DataAdapter.SelectCommand = new SqlCommand(query, dbConnection);

                    DataAdapter.SelectCommand.Parameters.Add("@title", SqlDbType.VarChar).Value = title;

                    int Mediaid = 0;
                    int RowCount = DataAdapter.Fill(UserDataset, "userIdList");
                   
                    foreach (DataRow row in UserDataset.Tables["userIdList"].Rows)
                    {
                        Mediaid = int.Parse(row[0].ToString());
                    }
                    return Mediaid;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error while adding new user: " + ex.Message);
                    return -1;
                }
            }
        }
    }
}
