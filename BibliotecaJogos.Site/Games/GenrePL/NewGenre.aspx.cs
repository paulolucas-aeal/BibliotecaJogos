using BibliotecaJogos.DataAccess.GenreDA;
using BibliotecaJogos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BibliotecaJogos.Site.Games.GenrePL
{
    public partial class NewGenre : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"].ToString() == "U")
            {
                Response.Redirect("~/Games/GameLibraryPL/GameLibrary.aspx");
            }
        }

        protected void buttonInserirGenero_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Genre genre = new Genre()
                {
                    Description_Genre = textBoxDescriptionGenre.Text
                };

                int returnCode = GenreDAO.InsertGenre(genre);
                if (returnCode == -1)
                {
                    labelMensagem.ForeColor = System.Drawing.Color.Red;
                    labelMensagem.Text = "Registo do género falhado!<br />Contacte o administrador ou tente novamente...";
                }
                else
                {
                    labelMensagem.Text = "Registo efetuado com sucesso!";
                    textBoxDescriptionGenre.Enabled = false;

                    buttonInserirGenero.Enabled = false;
                    buttonCancelar.Enabled = false;
                    hyperlinkLibrary.Visible = true;
                }
            }
            else
            {
                labelMensagem.Text = "Falha na validação do formulário.<br />Contacte o administrador ou tente novamente...";
            }
        }

        protected void buttonCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Games/GenrePL/EditGenre.aspx");
        }
    }
}