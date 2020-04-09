using BibliotecaJogos.DataAccess.CryptoHelpers;
using BibliotecaJogos.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaJogos.DataAccess.UserDA
{
    public class UserDAO
    {
        public static int RegisterUser(User user)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GameLibraryDBCS"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_InsertUser";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@username", user.Username);
                    command.Parameters.AddWithValue("@password", PasswordEncryptSHA256.GenerateSHA256String(user.Password));
                    command.Parameters.AddWithValue("@email", user.Email);

                    connection.Open();
                    int returnCode = (int)command.ExecuteScalar();

                    return returnCode;
                }
            }
        }

        public static User GetUser(int id_user)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GameLibraryDBCS"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetUserByID";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@id_user", id_user);

                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            User user = new User()
                            {
                                Id_User = Convert.ToInt32(dataReader["id_user"]),
                                Username = dataReader["username"].ToString(),
                                Password = dataReader["password"].ToString(),
                                Email = dataReader["email"].ToString(),
                                Role = dataReader["role"].ToString()[0],
                                Is_Locked = dataReader["is_locked"] == DBNull.Value ? (bool?)null : Convert.ToBoolean(dataReader["is_locked"]),
                                Nr_Attempts = dataReader["nr_attempts"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["nr_attempts"]),
                                Locked_Date_Time = dataReader["locked_date_time"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dataReader["locked_date_time"])
                            };
                            return user;
                        }
                    }
                    return null;
                }
            }
        }

        public static User GetUser(string email)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GameLibraryDBCS"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetUserByEmail";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@email", email);

                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            User user = new User()
                            {
                                Id_User = Convert.ToInt32(dataReader["id_user"]),
                                Username = dataReader["username"].ToString(),
                                Password = dataReader["password"].ToString(),
                                Email = dataReader["email"].ToString(),
                                Role = dataReader["role"].ToString()[0],
                                Is_Locked = dataReader["is_locked"] == DBNull.Value ? (bool?)null : Convert.ToBoolean(dataReader["is_locked"]),
                                Nr_Attempts = dataReader["nr_attempts"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["nr_attempts"]),
                                Locked_Date_Time = dataReader["locked_date_time"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dataReader["locked_date_time"])
                            };
                            return user;
                        }
                    }
                    return null;
                }
            }
        }

        public static User GetUser(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GameLibraryDBCS"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_AuthenticateUser";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", PasswordEncryptSHA256.GenerateSHA256String(password));

                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            User user = new User()
                            {
                                Id_User = Convert.ToInt32(dataReader["id_user"]),
                                Username = dataReader["username"].ToString(),
                                Password = dataReader["password"].ToString(),
                                Email = dataReader["email"].ToString(),
                                Role = dataReader["role"].ToString()[0],
                                Is_Locked = dataReader["is_locked"] == DBNull.Value ? (bool?)null : Convert.ToBoolean(dataReader["is_locked"]),
                                Nr_Attempts = dataReader["nr_attempts"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["nr_attempts"]),
                                Locked_Date_Time = dataReader["locked_date_time"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dataReader["locked_date_time"])
                            };
                            return user;
                        }
                        return null;

                        //if (dataReader.Read())
                        //{
                        //    if (Convert.ToInt32(dataReader["ReturnCode"]) == -1)
                        //    {
                        //        return null;
                        //    }

                        //    //if (dataReader.NextResult())
                        //    //{
                        //    //    dataReader.Read();
                        //    //    User user = new User()
                        //    //    {
                        //    //        Id_User = Convert.ToInt32(dataReader["id_user"]),
                        //    //        Username = dataReader["username"].ToString(),
                        //    //        Password = dataReader["password"].ToString(),
                        //    //        Role = dataReader["role"].ToString()[0],
                        //    //        Is_Locked = dataReader["is_locked"] == DBNull.Value ? (char?)null : dataReader["is_locked"].ToString()[0],
                        //    //        Nr_Attempts = dataReader["nr_attempts"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["nr_attempts"]),
                        //    //        Locked_Date_Time = dataReader["locked_date_time"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dataReader["locked_date_time"])
                        //    //    };
                        //    //    return user;
                        //    //}
                        //}
                        //return null;
                    }

                }
            }
        }

        public static List<User> GetUsers()
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GameLibraryDBCS"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetUsers";
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            List<User> listUsers = new List<User>();
                            while (dataReader.Read())
                            {
                                listUsers.Add(new User()
                                {
                                    Id_User = Convert.ToInt32(dataReader["id_user"]),
                                    Username = dataReader["username"].ToString(),
                                    Password = dataReader["password"].ToString(),
                                    Email = dataReader["email"].ToString(),
                                    Role = dataReader["role"].ToString()[0],
                                    Is_Locked = dataReader["is_locked"] == DBNull.Value ? (bool?)null : Convert.ToBoolean(dataReader["is_locked"]),
                                    Nr_Attempts = dataReader["nr_attempts"] == DBNull.Value ? (int?)null : Convert.ToInt32(dataReader["nr_attempts"]),
                                    Locked_Date_Time = dataReader["locked_date_time"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dataReader["locked_date_time"])
                                });
                            }
                            return listUsers;
                        }
                        return null;
                    }
                }
            }
        }

        public static int RemoveUser(int id_user)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GameLibraryDBCS"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_DeleteUserByID";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@id_user", id_user);

                    connection.Open();
                    int returnCode = (int)command.ExecuteScalar();

                    return returnCode;
                }
            }
        }

        public static int UpdateUser(User user)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GameLibraryDBCS"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_UpdateUserByID";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@id_user", user.Id_User);
                    command.Parameters.AddWithValue("@username", user.Username);
                    command.Parameters.AddWithValue("@password", user.Password);
                    command.Parameters.AddWithValue("@email", user.Email);
                    command.Parameters.AddWithValue("@role", user.Role);

                    connection.Open();
                    int returnCode = (int)command.ExecuteScalar();

                    return returnCode;
                }
            }
        }

    }

}
