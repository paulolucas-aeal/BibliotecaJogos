using BibliotecaJogos.DataAccess.GameDA;
using BibliotecaJogos.DataAccess.PublisherDA;
using BibliotecaJogos.DataAccess.UserDA;
using BibliotecaJogos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BibliotecaJogos.Site
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            listVewTeste.DataSource = GameDAO.GetGames();
            listVewTeste.DataBind();

            //List<Publisher> listPublishers = PublisherDAO.getPublishers();
            //listViewPublishers.DataSource = listPublishers;
            //listViewPublishers.DataBind();
        }
    }
}