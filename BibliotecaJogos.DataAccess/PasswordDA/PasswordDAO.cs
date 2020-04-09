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

namespace BibliotecaJogos.DataAccess.PasswordDA
{
    public class PasswordDAO
    {
        public static string InsertNewPwdRequest(string email)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GameLibraryDBCS"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_InsertPwdRequest";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@email", email);

                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            return dataReader["GUID"].ToString();
                        }
                        return null;
                    }
                }
            }
        }

        public static int ResetPassword(int id_user, string new_password)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GameLibraryDBCS"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_ResetPassword";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@id_user", id_user);
                    command.Parameters.AddWithValue("@new_password", PasswordEncryptSHA256.GenerateSHA256String(new_password));

                    connection.Open();
                    return (int)command.ExecuteScalar();
                }
            }
        }

        public static NewPwdRequest GetNewPwdRequestDataByGUID(string GUID)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GameLibraryDBCS"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetPwdRequestDataByGUID";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@guid", GUID);

                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            NewPwdRequest newPwdRequest = new NewPwdRequest(){
                                Id_PwdRecoveryRequest = Convert.ToInt32(dataReader["id_pwdRecoveryRequest"]),
                                Email = dataReader["email"].ToString(),
                                Guid = dataReader["guid"].ToString(),
                                Date_Recovery_Request = Convert.ToDateTime(dataReader["date_recovery_request"])
                            };
                            return newPwdRequest;
                        }
                        return null;
                    }
                }
            }
        }

        public static int DeletePwdRequestByEmail(string email)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GameLibraryDBCS"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_DeletePwdRequestByEmail";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@email", email);

                    connection.Open();
                    return (int)command.ExecuteScalar();
                }
            }
        }

    }
}
