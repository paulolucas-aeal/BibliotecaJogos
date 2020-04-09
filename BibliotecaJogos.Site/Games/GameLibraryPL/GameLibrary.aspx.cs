using BibliotecaJogos.DataAccess.GameDA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BibliotecaJogos.Site.Games.GameLibraryPL
{
    public partial class GameLibrary : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                repeaterGameLibrary.DataSource = GameDAO.GetGames();
                repeaterGameLibrary.DataBind();
            }

            if (Session["role"].ToString() == "U")
            {
                buttonNovoJogo.Attributes["style"] = "display:none";
                buttonNovoJogo.Attributes["style"] = "display:none";
            }
        }

        protected void buttonNovoJogo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Games/GamePL/NewGame.aspx");
        }
    }
}



