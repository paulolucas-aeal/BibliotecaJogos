using BibliotecaJogos.DataAccess.GameDA;
using BibliotecaJogos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BibliotecaJogos.Site
{
    public partial class WebFormFormView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["id_game"];
            
            if (string.IsNullOrEmpty(id))
            {
                Response.Redirect("~/Games/GameLibraryPL/GameLibrary.aspx");
            }

            List<Game> dsource = new List<Game>
            {
                GameDAO.GetGame(Convert.ToInt32(id))
            };
            formViewGame.DataSource = dsource;
            formViewGame.DataBind();
        }
    }
}