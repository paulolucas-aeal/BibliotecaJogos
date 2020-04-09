using BibliotecaJogos.DataAccess.PasswordDA;
using BibliotecaJogos.DataAccess.UserDA;
using BibliotecaJogos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BibliotecaJogos.Site.PwdMgmt
{
    public partial class SetNewPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string GUID = Request.QueryString["guid"];

            if (string.IsNullOrEmpty(GUID))
            {
                Response.Redirect("~/Authentication/Login.aspx");
            }

            NewPwdRequest newPwdRequest = PasswordDAO.GetNewPwdRequestDataByGUID(GUID);

            if (newPwdRequest == null)
            {
                labelMensagem.Text = "Link de redefinição de password INVÁLIDO!";
                labelMensagem.ForeColor = System.Drawing.Color.Red;

                textBoxPassword.Enabled = false;
                textBoxConfirmPassword.Enabled = false;

                buttonSubmeterNovaPassword.Visible = false;
                buttonCancelar.Visible = false;
                hyperlinkLogin.Visible = true;
            }
            else
            {
                hiddenEmail.Value = newPwdRequest.Email;
            }
        }

        protected void buttonCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Authentication/Login.aspx");
        }

        protected void buttonSubmeterNovaPassword_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                User user = UserDAO.GetUser(hiddenEmail.Value);

                int returnCode = PasswordDAO.ResetPassword(user.Id_User, textBoxPassword.Text);
                if (returnCode == -1)
                {
                    labelMensagem.Text = "Redefinição da password falhou!<br />Tente novamente ou contacte o administrador do sistema...";
                    labelMensagem.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    returnCode = PasswordDAO.DeletePwdRequestByEmail(hiddenEmail.Value);

                    if (returnCode == -1)
                    {
                        labelMensagem.Text = "Ocorreu um erro inesperado!<br />Tente novamente ou contacte o administrador do sistema...";
                        labelMensagem.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        labelMensagem.Text = "Password redefinida com sucesso";
                        labelMensagem.ForeColor = System.Drawing.Color.Green;
                        buttonSubmeterNovaPassword.Visible = false;
                        buttonCancelar.Visible = false;
                    }
                    
                }
                hyperlinkLogin.Visible = true;
            }
        }
    }
}