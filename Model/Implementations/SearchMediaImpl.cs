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
    public class SearchMediaImpl : iSearchModel
    {
        static string CONNECTION_STRING = "Data Source=SQL5017.site4now.net;Initial Catalog=DB_9AB8B7_D19ES6911;Persist Security Info=True;User ID=DB_9AB8B7_D19ES6911_admin;Password=fe2y8xZ7";

        public List<ModelMediaDTO> MediaSearch(ModelMediaDTO modelMedia)
        {
            // 1. Create a connection
            SqlConnection dbConnection = new SqlConnection(CONNECTION_STRING);
            try
            {
                List<ModelMediaDTO> MediaSearchList = new List<ModelMediaDTO>();

                //create query
                String query = "SELECT * " +
                                    "FROM TabMedia " +
                                    "INNER JOIN TabDirector ON TabMedia.Director = TabDirector.DID " +
                                    "INNER JOIN TabGenre ON TabMedia.Genre = TabGenre.GID " +
                                    "INNER JOIN TabLanguage ON TabMedia.Language = TabLanguage.LID " +
                                    "WHERE (TabMedia.Title LIKE '%' + @title + '%' OR @title = '') " +
                                    "AND(TabGenre.GenreName LIKE '%' + @genre + '%' OR @genre = '') " +
                                    "AND(TabDirector.DirectorName LIKE '%' + @dName + '%' OR @dName = '') " +
                                    "AND(TabMedia.PublishYear = @year OR @year = 0) " +
                                    "AND(TabLanguage.LanguageName LIKE '%' + @lang + '%' OR @lang = '')";
                //Create new adapter
                SqlDataAdapter DataAdapter = new SqlDataAdapter();

                //Create empty dataset
                Dataset UserDataset = new Dataset();

                dbConnection.Open();

                //insert insert command into the adapter
                DataAdapter.SelectCommand = new SqlCommand(query, dbConnection);

                DataAdapter.SelectCommand.Parameters.Add("@title", SqlDbType.VarChar).Value = modelMedia.Title;
                DataAdapter.SelectCommand.Parameters.Add("@genre", SqlDbType.VarChar).Value = modelMedia.Genre;
                DataAdapter.SelectCommand.Parameters.Add("@dName", SqlDbType.VarChar).Value = modelMedia.Director;
                DataAdapter.SelectCommand.Parameters.Add("@year", SqlDbType.Int).Value = modelMedia.PublishYear;
                DataAdapter.SelectCommand.Parameters.Add("@lang", SqlDbType.VarChar).Value = modelMedia.Language;

                int RowCount = DataAdapter.Fill(UserDataset, "mediaSearch");
                // if there's a row successfully inserted, return true  and vice versa
                if (RowCount > 0)
                {
                    foreach (DataRow row in UserDataset.Tables["mediaSearch"].Rows)
                    {
                        MediaSearchList.Add(new ModelMediaDTO(int.Parse(row[0].ToString()), row[1].ToString(), row[10].ToString(), row[8].ToString(), row[12].ToString(), int.Parse(row[5].ToString()), decimal.Parse(row[6].ToString())));
                    }
                    return MediaSearchList;
                }
                else
                {
                    List<ModelMediaDTO> ListOfMedia = new List<ModelMediaDTO>();

                    Console.WriteLine("Errr while validation user: ");
                    return ListOfMedia;
                }


            }
            catch (Exception ex)
            {
                List<ModelMediaDTO> browseMedia = new List<ModelMediaDTO>();

                Console.WriteLine("Errr while validation user: " + ex.Message);
                return browseMedia;
            }
        }

   
    }
}
