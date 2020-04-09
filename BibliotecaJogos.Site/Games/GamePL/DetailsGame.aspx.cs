using BibliotecaJogos.DataAccess.GameDA;
using BibliotecaJogos.DataAccess.GenreDA;
using BibliotecaJogos.DataAccess.PublisherDA;
using BibliotecaJogos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BibliotecaJogos.Site.Games.GamePL
{
    public partial class DetailsGame : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string rawID = Request.QueryString["id_game"];
            int id_game = -1;

            if (string.IsNullOrEmpty(rawID) || !int.TryParse(rawID, out id_game))
            {
                Response.Redirect("~/Games/GameLibraryPL/GameLibrary.aspx");
            }

            if (!Page.IsPostBack)
            {
                Game game = GameDAO.GetGame(id_game);

                if (game == null)
                {
                    Response.Redirect("~/Games/GameLibraryPL/GameLibrary.aspx");
                }

                Publisher publisher = PublisherDAO.GetPublisher(game.Id_Publisher);
                Genre genre = GenreDAO.GetGenre(game.Id_Genre);

                FillDetais(game, publisher, genre);
            }
        }

        private void FillDetais(Game game, Publisher publisher, Genre genre)
        {
            labelTitle.Text = game.Title;
            imageCoverImage.ImageUrl = "~/Content/CoverImages/" + game.Cover_Image;
            labelAmountPaid.Text = string.Format("{0:C}", game.Amount_Paid);
            labelPurchaseDate.Text = game.Purchase_Date != null ? Convert.ToDateTime(game.Purchase_Date.ToString()).ToString("yyyy-MM-dd") : "";
            labelPublisher.Text = publisher.Name_Publisher;
            labelGenre.Text = genre.Description_Genre;
        }

        protected void buttonVoltarCatalogo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Games/GameLibraryPL/GameLibrary.aspx");
        }
    }
}