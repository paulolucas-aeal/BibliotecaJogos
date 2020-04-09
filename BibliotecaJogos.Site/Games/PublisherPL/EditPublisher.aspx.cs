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
    public partial class EditPublisher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"].ToString() == "U")
            {
                Response.Redirect("~/Games/GameLibraryPL/GameLibrary.aspx");
            }

            if (!Page.IsPostBack)
            {
                RefreshGridView();
            }
        }

        private void RefreshGridView()
        {
            List<Publisher> listPublishers = PublisherDAO.getPublishers();
            gridViewPublishers.DataSource = listPublishers;
            gridViewPublishers.DataBind();
            labelMensagem.Visible = false;
        }

        protected void gridViewPublishers_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridViewPublishers.EditIndex = e.NewEditIndex;
            RefreshGridView();
        }

        protected void gridViewPublishers_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Publisher publisher = new Publisher()
            {
                Id_Publisher = Convert.ToInt32(gridViewPublishers.Rows[e.RowIndex].Cells[0].Text),
                Name_Publisher = e.NewValues["name_publisher"].ToString()
            };

            int returnCode = PublisherDAO.UpdatePublisher(publisher);
            gridViewPublishers.EditIndex = -1;
            RefreshGridView();
        }

        protected void gridViewPublishers_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridViewPublishers.EditIndex = -1;
            RefreshGridView();
        }

        protected void gridViewPublishers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int returnCode = PublisherDAO.DeletePublisher(Convert.ToInt32(gridViewPublishers.Rows[e.RowIndex].Cells[0].Text));

            switch (returnCode)
            {
                case -1:
                    labelMensagem.Visible = true;
                    labelMensagem.ForeColor = System.Drawing.Color.Red;
                    labelMensagem.Text = "Falha na eliminação.<br />Não foi encontrado qualquer editora com o nº de ID indicado!";
                    break;
                case -2:
                    labelMensagem.Visible = true;
                    labelMensagem.ForeColor = System.Drawing.Color.Red;
                    labelMensagem.Text = "Eliminição impossibilitada.<br />Existem jogos registados pertencentes à editora.";
                    break;
                default:
                    labelMensagem.ForeColor = System.Drawing.Color.Green;
                    RefreshGridView();
                    break;
            }
        }

        protected void buttonNovaEditora_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Games/PublisherPL/NewPublisher.aspx");
        }

        protected void buttonVerCatalogo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Games/GameLibraryPL/GameLibrary.aspx");
        }
    }
}