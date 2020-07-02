using BibliotecaJogos.DataAccess.PasswordDA;
using BibliotecaJogos.DataAccess.UserDA;
using BibliotecaJogos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BibliotecaJogos.Site.PwdMgmt
{
    public partial class NewPasswordRequest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void buttonSubmeterPedido_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                User user = UserDAO.GetUser(textBoxEmail.Text);

                if (user == null)
                {
                    labelMensagem.Text = "O email indicado não se encontra registado no sistema.";
                    labelMensagem.ForeColor = System.Drawing.Color.Red;
                    labelMensagem.Visible = true;
                }
                else
                {
                    string GUID = PasswordDAO.InsertNewPwdRequest(textBoxEmail.Text);
                    if (string.IsNullOrEmpty(GUID))
                    {
                        labelMensagem.Text = "Solicitação falhada. <br />Tente novamente ou contacte o administrador...";
                        labelMensagem.ForeColor = System.Drawing.Color.Red;
                        labelMensagem.Visible = true;
                    }
                    else
                    {
                        Send_Mail(textBoxEmail.Text, GUID);

                        labelMensagem.Text = "Foi enviado para o email indicado um link para a definição de uma nova senha.";
                        labelMensagem.ForeColor = System.Drawing.Color.Green;
                        labelMensagem.Visible = true;

                        textBoxEmail.Enabled = false;
                        buttonSubmeterPedido.Visible = false;
                        buttonCancelar.Visible = false;
                    }
                    hyperLinkLogin.Visible = true;
                }
            }
        }

        private void Send_Mail(string email, string GUID)
        {
            MailMessage mailMessage = new MailMessage();
            
            mailMessage.From = new MailAddress("alexlucax@gmail.com");
            mailMessage.To.Add(new MailAddress(email));
            mailMessage.Subject = "Biblioteca de Jogos - Solicitação de Nova Password";

            mailMessage.Body = "Para efetivar o pedido de nova password clique aqui: https://localhost:44318/PwdMgmt/SetNewPassword.aspx?guid=" + GUID;
            mailMessage.IsBodyHtml = true;

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new System.Net.NetworkCredential("alexlucax@gmail.com", "xxxxxxxxxxxxx");
            smtpClient.Send(mailMessage);
        }

        protected void buttonCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Authentication/Login.aspx");
        }
    }
}
