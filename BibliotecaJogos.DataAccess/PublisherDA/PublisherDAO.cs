using BibliotecaJogos.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaJogos.DataAccess.PublisherDA
{
    public class PublisherDAO
    {
        public static List<Publisher> getPublishers()
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GameLibraryDBCS"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetPublishers";
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            List<Publisher> listPublishers = new List<Publisher>();
                            while (dataReader.Read())
                            {
                                listPublishers.Add(new Publisher()
                                {
                                    Id_Publisher = Convert.ToInt32(dataReader["id_publisher"]),
                                    Name_Publisher = dataReader["name_publisher"].ToString()
                                });
                            }
                            return listPublishers;
                        }
                        return null;
                    }
                }
            }
        }

        public static int InsertPublisher(Publisher publisher)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GameLibraryDBCS"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_InsertPublisher";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@name_publisher", publisher.Name_Publisher);

                    connection.Open();
                    int returnCode = (int)command.ExecuteScalar();

                    return returnCode;
                }
            }
        }

        public static Publisher GetPublisher(int id_publisher)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GameLibraryDBCS"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetPublisherByID";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@id_publisher", id_publisher);
                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            Publisher publisher = new Publisher()
                            {
                                Id_Publisher = Convert.ToInt32(dataReader["id_publisher"]),
                                Name_Publisher = dataReader["name_publisher"].ToString()
                            };
                            return publisher;
                        }
                        return null;
                    }

                }
            }
        }

        public static int DeletePublisher(int id_publisher)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GameLibraryDBCS"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_DeletePublisherByID";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@id_publisher", id_publisher);

                    connection.Open();
                    int returnCode = (int)command.ExecuteScalar();

                    return returnCode;
                }
            }
        }

        public static int UpdatePublisher(Publisher publisher)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GameLibraryDBCS"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_UpdatePublisherByID";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@id_publisher", publisher.Id_Publisher);
                    command.Parameters.AddWithValue("@name_publisher", publisher.Name_Publisher);

                    connection.Open();
                    int returnCode = (int)command.ExecuteScalar();

                    return returnCode;
                }
            }
        }
    }
}
