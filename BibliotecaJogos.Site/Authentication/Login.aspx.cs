using BibliotecaJogos.DataAccess.UserDA;
using BibliotecaJogos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BibliotecaJogos.Site.Authentication
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void buttonLogin_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string username = textBoxUsername.Text;
                string password = textBoxPassword.Text;

                User user = UserDAO.GetUser(username, password);
                if (user == null)
                {
                    labelMensagem.Text = "O username não se encontra registado";
                }
                else if (user.Is_Locked == false && user.Nr_Attempts == 0 && user.Locked_Date_Time == null)
                {
                    FormsAuthentication.RedirectFromLoginPage(textBoxUsername.Text, false);
                    Session["username"] = user.Username;
                    Session["role"] = user.Role;
                }
                else if (user.Is_Locked == true)
                {
                    labelMensagem.Text = "Esgotou as 3 tentativas. O seu acesso encontra-se bloqueado por um período de 24 horas, desde " + user.Locked_Date_Time;
                }
                else
                {
                    labelMensagem.Text = "Acesso falhado. Tem mais " + (4 - user.Nr_Attempts) + " tentativa(s)";                       
                }
                
            }
        }


    }
}