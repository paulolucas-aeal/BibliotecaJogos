using BibliotecaJogos.DataAccess.GameDA;
using BibliotecaJogos.DataAccess.GenreDA;
using BibliotecaJogos.DataAccess.PublisherDA;
using BibliotecaJogos.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BibliotecaJogos.Site.Games.GamePL
{
    public partial class EditGame : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"].ToString() == "U")
            {
                Response.Redirect("~/Games/GameLibraryPL/GameLibrary.aspx");
            }

            string rawID = Request.QueryString["id_game"];
            int id_game = -1;

            if (string.IsNullOrEmpty(rawID) || !int.TryParse(rawID, out id_game))
            {
                Response.Redirect("~/Games/GameLibraryPL/GameLibrary.aspx");
            }

            hiddenID_Game.Value = id_game.ToString();

            if (!Page.IsPostBack)
            {
                dropDownListPublishers.DataSource = PublisherDAO.getPublishers();
                dropDownListPublishers.DataValueField = "Id_Publisher";
                dropDownListPublishers.DataTextField = "Name_Publisher";
                dropDownListPublishers.DataBind();

                dropDownListGenres.DataSource = GenreDAO.getGenres();
                dropDownListGenres.DataValueField = "Id_Genre";
                dropDownListGenres.DataTextField = "Description_Genre";
                dropDownListGenres.DataBind();

                Game game = GameDAO.GetGame(id_game);

                if (game == null)
                {
                    Response.Redirect("~/Games/GameLibraryPL/GameLibrary.aspx");
                }

                textBoxTitle.Text = game.Title;
                imageCoverImage.ImageUrl = "~/Content/CoverImages/" + game.Cover_Image;
                textBoxAmountPaid.Text = string.Format("{0:C}", game.Amount_Paid);
                textBoxPurchaseDate.Text = game.Purchase_Date == null ? null : Convert.ToDateTime(game.Purchase_Date.ToString()).ToString("yyyy-MM-dd");
                dropDownListPublishers.SelectedValue = game.Id_Publisher.ToString();
                dropDownListGenres.SelectedValue = game.Id_Genre.ToString();

                if (Session["role"].ToString() == "U")
                {
                    textBoxTitle.ReadOnly = true;
                    textBoxAmountPaid.ReadOnly = true;
                    textBoxPurchaseDate.ReadOnly = true;
                    dropDownListPublishers.Enabled = false;
                    dropDownListGenres.Enabled = false;
                    fileUploadNewCoverImage.Enabled = false;
                }
            }
        }

        protected void buttonSalvarJogo_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Game game = new Game()
                {
                    Id_Game = Convert.ToInt32(hiddenID_Game.Value),
                    Title = textBoxTitle.Text,
                    Amount_Paid = string.IsNullOrWhiteSpace(textBoxAmountPaid.Text) ? (double?)null : Convert.ToDouble(textBoxAmountPaid.Text),
                    Purchase_Date = string.IsNullOrWhiteSpace(textBoxPurchaseDate.Text) ? (DateTime?)null : Convert.ToDateTime(textBoxPurchaseDate.Text),
                    Id_Publisher = Convert.ToInt32(dropDownListPublishers.SelectedValue),
                    Id_Genre = Convert.ToInt32(dropDownListGenres.SelectedValue)
                };

                if (fileUploadNewCoverImage.HasFile)
                {
                    game.Cover_Image = Path.GetFileName(fileUploadNewCoverImage.PostedFile.FileName);
                }
                else
                {
                    game.Cover_Image = Path.GetFileName(imageCoverImage.ImageUrl);
                }

                int returnCode = GameDAO.UpdateGame(game);

                if (returnCode == -1)
                {
                    labelMensagem.ForeColor = System.Drawing.Color.Red;
                    labelMensagem.Text = "Salvaguarda falhada das alterações !<br />Contacte o administrador ou tente novamente...";
                }
                else
                {
                    if (fileUploadNewCoverImage.HasFile)
                    {
                        fileUploadNewCoverImage.PostedFile.SaveAs(Server.MapPath("~/Content/CoverImages/") + Path.GetFileName(fileUploadNewCoverImage.PostedFile.FileName));
                    }

                    labelMensagem.ForeColor = System.Drawing.Color.Green;
                    labelMensagem.Text = "Alterações gravadas com sucesso!";

                    textBoxTitle.Enabled = false;
                    fileUploadNewCoverImage.Enabled = false;
                    textBoxAmountPaid.Enabled = false;
                    textBoxPurchaseDate.Enabled = false;
                    dropDownListPublishers.Enabled = false;
                    dropDownListGenres.Enabled = false;

                    buttonSalvarJogo.Visible = false;
                    buttonCancelar.Visible = false;

                    hyperlinkLibrary.Visible = true;
                }
            }
        }

        protected void buttonCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Games/GameLibraryPL/GameLibrary.aspx");
        }
    }
}