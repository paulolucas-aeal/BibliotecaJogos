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
    public partial class EditGenre : System.Web.UI.Page
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
            List<Genre> listGenres = GenreDAO.getGenres();
            gridViewGenres.DataSource = listGenres;
            gridViewGenres.DataBind();
            labelMensagem.Visible = false;
        }

        protected void gridViewGenres_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridViewGenres.EditIndex = e.NewEditIndex;
            RefreshGridView();
        }

        protected void gridViewGenres_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Genre genre = new Genre()
            {
                Id_Genre = Convert.ToInt32(gridViewGenres.Rows[e.RowIndex].Cells[0].Text),
                Description_Genre = e.NewValues["description_genre"].ToString()
            };

            int returnCode = GenreDAO.UpdateGenre(genre);
            gridViewGenres.EditIndex = -1;
            RefreshGridView();
        }

        protected void gridViewGenres_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridViewGenres.EditIndex = -1;
            RefreshGridView();
        }

        protected void gridViewGenres_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int returnCode = GenreDAO.DeleteGenre(Convert.ToInt32(gridViewGenres.Rows[e.RowIndex].Cells[0].Text));

            switch (returnCode)
            {
                case -1:
                    labelMensagem.Visible = true;
                    labelMensagem.ForeColor = System.Drawing.Color.Red;
                    labelMensagem.Text = "Falha na eliminação.<br />Não foi encontrado qualquer género com o nº de ID indicado!";
                    break;
                case -2:
                    labelMensagem.Visible = true;
                    labelMensagem.ForeColor = System.Drawing.Color.Red;
                    labelMensagem.Text = "Eliminição impossibilitada.<br />Existem jogos registados pertencentes ao género.";
                    break;
                default:
                    labelMensagem.ForeColor = System.Drawing.Color.Green;
                    labelMensagem.Text = "Eliminição efetuada com sucesso.";
                    RefreshGridView();
                    break;
            }
        }

        protected void buttonNovoGenero_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Games/GenrePL/NewGenre.aspx");
        }

        protected void buttonVerCatalogo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Games/GameLibraryPL/GameLibrary.aspx");
        }
    }
}