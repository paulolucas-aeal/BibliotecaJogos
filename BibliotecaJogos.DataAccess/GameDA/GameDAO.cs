using BibliotecaJogos.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaJogos.DataAccess.GameDA
{
    public class GameDAO
    {
        public static int InsertGame(Game game)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GameLibraryDBCS"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_InsertGame";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@title", game.Title);
                    command.Parameters.AddWithValue("@cover_image", game.Cover_Image);
                    command.Parameters.AddWithValue("@amount_paid", (object)game.Amount_Paid ?? SqlMoney.Null);
                    command.Parameters.AddWithValue("@purchase_date", (object)game.Purchase_Date ?? SqlDateTime.Null);
                    command.Parameters.AddWithValue("@id_publisher", Convert.ToInt32(game.Id_Publisher));
                    command.Parameters.AddWithValue("@id_genre", Convert.ToInt32(game.Id_Genre));

                    connection.Open();
                    int returnCode = (int)command.ExecuteScalar();

                    return returnCode;
                }
            }
        }

        public static Game GetGame(int id_game)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GameLibraryDBCS"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetGameByID";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@id_game", id_game);

                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            Game game = new Game()
                            {
                                Id_Game = Convert.ToInt32(dataReader["id_game"]),
                                Title = dataReader["title"].ToString(),
                                Cover_Image = dataReader["cover_image"].ToString(),
                                Amount_Paid = dataReader["amount_paid"] == DBNull.Value ? (double?)null : Convert.ToDouble(dataReader["amount_paid"]),
                                Purchase_Date = dataReader["purchase_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dataReader["purchase_date"]),
                                Id_Publisher = Convert.ToInt32(dataReader["id_publisher"]),
                                Id_Genre = Convert.ToInt32(dataReader["id_genre"])
                            };
                            return game;
                        }
                        return null;
                    }
                }
            }
        }

        public static int UpdateGame(Game game)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GameLibraryDBCS"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_UpdateGameByID";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@id_game", game.Id_Game);
                    command.Parameters.AddWithValue("@title", game.Title);
                    command.Parameters.AddWithValue("@cover_image", game.Cover_Image);
                    command.Parameters.AddWithValue("@amount_paid", (object)game.Amount_Paid ?? SqlMoney.Null);
                    command.Parameters.AddWithValue("@purchase_date", (object)game.Purchase_Date ?? SqlDateTime.Null);
                    command.Parameters.AddWithValue("@id_publisher", Convert.ToInt32(game.Id_Publisher));
                    command.Parameters.AddWithValue("@id_genre", Convert.ToInt32(game.Id_Genre));

                    connection.Open();
                    int returnCode = (int)command.ExecuteScalar();
                    return returnCode;
                }   
            }
        }

        public static List<Game> GetGames()
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["GameLibraryDBCS"].ConnectionString;
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "sp_GetGames";
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            List<Game> listGames = new List<Game>();
                            while (dataReader.Read())
                            {
                                listGames.Add(new Game() { 
                                    Id_Game = Convert.ToInt32(dataReader["id_game"]),
                                    Title = dataReader["title"].ToString(),
                                    Cover_Image = dataReader["cover_image"].ToString(),
                                    Amount_Paid = dataReader["amount_paid"] == DBNull.Value ? (double?)null : Convert.ToDouble(dataReader["amount_paid"]),
                                    Purchase_Date = dataReader["purchase_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dataReader["purchase_date"]),
                                    Id_Publisher = Convert.ToInt32(dataReader["id_publisher"]),
                                    Id_Genre = Convert.ToInt32(dataReader["id_genre"])
                                });
                            }
                            return listGames;
                        }
                        return null;
                    }
                }
            }
        }
    }
}
