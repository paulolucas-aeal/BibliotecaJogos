using BibliotecaJogos.DataAccess.UserDA;
using BibliotecaJogos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace BibliotecaJogos.Site.Users.UsersPL
{
    public partial class EditUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"].ToString() == "U")
            {
                Response.Redirect("~/Games/GameLibraryPL/GameLibrary.aspx");
            }

            if (!Page.IsPostBack)
            {
                gridViewUsers.DataSource = UserDAO.GetUsers();
                gridViewUsers.DataBind();
            }
        }

        protected void buttonSalvarAlteracoes_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gridViewUsers.Rows.Count; i++)
            {
                User user = UserDAO.GetUser(Convert.ToInt32(gridViewUsers.DataKeys[i].Value));
                int id_user = user.Id_User;
                
                if (((CheckBox)gridViewUsers.Rows[i].FindControl("checkBoxEliminarUtilizador")).Checked)
                {
                    UserDAO.RemoveUser(id_user);
                    continue;
                }

                if (((CheckBox)gridViewUsers.Rows[i].FindControl("checkBoxAdministrador")).Checked)
                {
                    user.Role = 'A';
                }
                else
                {
                    user.Role = 'U';
                    if (Session["username"].ToString() == user.Username)
                    {
                        Session["role"] = 'U';
                    }
                }
                UserDAO.UpdateUser(user);
            }

            Response.Redirect("~/Games/GameLibraryPL/GameLibrary.aspx");
        }

        protected void gridViewUsers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                User user = UserDAO.GetUser(Convert.ToInt32(e.Row.Cells[0].Text));
                if (user.Role == 'A')
                {
                    ((CheckBox)e.Row.FindControl("checkBoxAdministrador")).Checked = true;
                }
            }
        }
    }
}