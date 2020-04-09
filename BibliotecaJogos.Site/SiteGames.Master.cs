using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BibliotecaJogos.Site.Games
{
    public partial class SiteGames : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"].ToString() == "U")
            {
                navLinkEditPublisher.Attributes["style"] = "display:none";
                navLinkEditGenre.Attributes["style"] = "display:none";
                navLinkEditUsers.Attributes["style"] = "display:none";
            }
        }

        protected void buttonLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
            HttpContext.Current.Response.End();
        }
    }
}