using BibliotecaJogos.DataAccess.UserDA;
using BibliotecaJogos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BibliotecaJogos.Site.Registration
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void buttonRegistar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                User user = new User()
                {
                    Username = textBoxUsername.Text,
                    Password = textBoxPassword.Text,
                    Email = textBoxEmail.Text,
                    Role = 'U'
                };
                
                int returnCode = UserDAO.RegisterUser(user);
                if (returnCode == -1)
                {
                    labelMensagem.ForeColor = System.Drawing.Color.Red;
                    labelMensagem.Text = "Registo falhado!<br />Contacte o administrador ou tente novamente...";
                }
                else
                {
                    labelMensagem.ForeColor = System.Drawing.Color.Green;
                    labelMensagem.Text = "Registo efetuado com sucesso!";
                    
                    textBoxUsername.Enabled = false;
                    textBoxPassword.Enabled = false;
                 
                    buttonRegistar.Visible = false;
                    buttonCancelar.Visible = false;

                    hyperlinkLogin.Visible = true;
                }
            }
            
        }

        protected void buttonCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Authentication/Login.aspx");
        }

    }
}