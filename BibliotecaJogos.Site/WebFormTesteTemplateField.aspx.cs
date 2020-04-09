using BibliotecaJogos.DataAccess.UserDA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BibliotecaJogos.Site
{
    public partial class WebFormTesteTemplateField : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                gridViewUsers.DataSource = UserDAO.GetUsers();
                gridViewUsers.DataBind();
            }
        }

        protected void buttonAtualizar_Click(object sender, EventArgs e)
        {
            for(int i=0; i<gridViewUsers.Rows.Count; i++)
            {
                if (((CheckBox)gridViewUsers.Rows[i].FindControl("checkBoxEliminar")).Checked)
                {
                    UserDAO.RemoveUser(Convert.ToInt32(gridViewUsers.DataKeys[i].Value));
                }
            }

            gridViewUsers.DataSource = UserDAO.GetUsers();
            gridViewUsers.DataBind();
        }
    }
}