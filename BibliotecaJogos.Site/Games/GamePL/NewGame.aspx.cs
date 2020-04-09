using BibliotecaJogos.DataAccess.GameDA;
using BibliotecaJogos.DataAccess.GenreDA;
using BibliotecaJogos.DataAccess.PublisherDA;
using BibliotecaJogos.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BibliotecaJogos.Site.Games.GamePL
{
    public partial class NewGame : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"].ToString() == "U")
            {
                Response.Redirect("~/Games/GameLibraryPL/GameLibrary.aspx");
            }

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
            }
        }

        protected void buttonInserirJogo_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Game game = new Game()
                {
                    Title = textBoxTitle.Text,
                    Cover_Image = Path.GetFileName(fileUploadCoverImage.PostedFile.FileName),
                    Amount_Paid = string.IsNullOrWhiteSpace(textBoxAmountPaid.Text) ? (double?)null : Convert.ToDouble(textBoxAmountPaid.Text),
                    Purchase_Date = string.IsNullOrWhiteSpace(textBoxPurchaseDate.Text) ? (DateTime?)null : Convert.ToDateTime(textBoxPurchaseDate.Text),
                    Id_Publisher = Convert.ToInt32(dropDownListPublishers.SelectedValue),
                    Id_Genre = Convert.ToInt32(dropDownListGenres.SelectedValue)
                };

                int returnCode = GameDAO.InsertGame(game);

                if (returnCode == -1)
                {
                    labelMensagem.ForeColor = System.Drawing.Color.Red;
                    labelMensagem.Text = "Registo do jogo falhado!<br />Contacte o administrador ou tente novamente...";
                }
                else
                {
                    fileUploadCoverImage.PostedFile.SaveAs(Server.MapPath("~/Content/CoverImages/") + Path.GetFileName(fileUploadCoverImage.PostedFile.FileName));

                    labelMensagem.ForeColor = System.Drawing.Color.Green;
                    labelMensagem.Text = "Registo efetuado com sucesso!";

                    textBoxTitle.Enabled = false;
                    fileUploadCoverImage.Enabled = false;
                    textBoxAmountPaid.Enabled = false;
                    textBoxPurchaseDate.Enabled = false;
                    dropDownListPublishers.Enabled = false;
                    dropDownListGenres.Enabled = false;

                    buttonInserirJogo.Visible = false;
                    buttonLimpar.Visible = false;
                    buttonCancelar.Visible = false;

                    hyperlinkLibrary.Visible = true;
                }

            }
        }

        protected void buttonLimpar_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void buttonCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Games/GameLibraryPL/GameLibrary.aspx");
        }
    }
}