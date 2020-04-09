using BibliotecaJogos.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaJogos.DataAccess.GenreDA
{
    public class GenreDAO
    {
        public static List<Genre> getGenres()
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GameLibraryDBCS"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetGenres";
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            List<Genre> listGenres = new List<Genre>();
                            while (dataReader.Read())
                            {
                                listGenres.Add(new Genre() { 
                                    Id_Genre = Convert.ToInt32(dataReader["id_genre"]),
                                    Description_Genre = dataReader["description_genre"].ToString()
                                });
                            }
                            return listGenres;
                        }
                        return null;
                    }
                }
            }
        }

        public static Genre GetGenre(int id_genre)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GameLibraryDBCS"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetGenreByID";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@id_genre", id_genre);
                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            Genre genre = new Genre()
                            {
                                Id_Genre = Convert.ToInt32(dataReader["id_genre"]),
                                Description_Genre = dataReader["description_genre"].ToString()
                            };
                            return genre;
                        }
                        return null;
                    }

                }
            }
        }

        public static int InsertGenre(Genre genre)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GameLibraryDBCS"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_InsertGenre";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@description_genre", genre.Description_Genre);

                    connection.Open();
                    int returnCode = (int)command.ExecuteScalar();

                    return returnCode;
                }
            }
        }

        public static int DeleteGenre(int id_genre)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GameLibraryDBCS"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_DeleteGenreByID";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@id_genre", id_genre);

                    connection.Open();
                    int returnCode = (int)command.ExecuteScalar();

                    return returnCode;
                }
            }
        }

        public static int UpdateGenre(Genre genre)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GameLibraryDBCS"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_UpdateGenreByID";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@id_genre", genre.Id_Genre);
                    command.Parameters.AddWithValue("@description_genre", genre.Description_Genre);

                    connection.Open();
                    int returnCode = (int)command.ExecuteScalar();

                    return returnCode;
                }
            }
        }
    }
}
