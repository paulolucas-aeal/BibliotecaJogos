using BibliotecaJogos.DataAccess.PublisherDA;
using BibliotecaJogos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BibliotecaJogos.Site.Games.PublisherPL
{
    public partial class NewPublisher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"].ToString() == "U")
            {
                Response.Redirect("~/Games/GameLibraryPL/GameLibrary.aspx");
            }
        }

        protected void buttonInserirEditora_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Publisher publisher = new Publisher()
                {
                    Name_Publisher = textBoxNamePublisher.Text
                };

                int returnCode = PublisherDAO.InsertPublisher(publisher);
                if (returnCode == -1)
                {
                    labelMensagem.ForeColor = System.Drawing.Color.Red;
                    labelMensagem.Text = "Registo da editora falhado!<br />Contacte o administrador ou tente novamente...";
                }
                else
                {
                    labelMensagem.Text = "Registo efetuado com sucesso!";
                    textBoxNamePublisher.Enabled = false;

                    buttonInserirEditora.Enabled = false;
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
            Response.Redirect("~/Games/PublisherPL/EditPublisher.aspx");
        }
    }
}