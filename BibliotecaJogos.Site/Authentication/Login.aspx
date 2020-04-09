<%@ Page Language="C#" MasterPageFile="~/SiteOutOfContentApp.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BibliotecaJogos.Site.Authentication.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <h2>Login</h2>
        <div class="form-group">
            <asp:TextBox CssClass="form-control" ID="textBoxUsername" placeholder="Username" runat="server" />
            <asp:RequiredFieldValidator ForeColor="Red" ErrorMessage="É necessário o username" Text="*" ControlToValidate="textBoxUsername" runat="server" />
        </div>
        <div class="form-group">
            <asp:TextBox CssClass="form-control" ID="textBoxPassword" placeholder="Password" TextMode="Password" runat="server" />
            <asp:RequiredFieldValidator ForeColor="Red" ErrorMessage="É necessário a password" Text="*" ControlToValidate="textBoxPassword" runat="server" />
        </div>
        <div>
            <asp:ValidationSummary HeaderText="Erros de Validação" ForeColor="Red" runat="server" />
        </div>
        <div>
            <asp:Label ID="labelMensagem" ForeColor="Red" runat="server" />
        </div>
        <div>
            <asp:Button CssClass="btn btn-primary" ID="buttonLogin" Text="Login" runat="server" OnClick="buttonLogin_Click" />
            <asp:HyperLink Text="Clique aqui para se registar" NavigateUrl="~/Registration/Register.aspx" runat="server" />
        </div>
        <div>
            <br />
            <asp:HyperLink CssClass="alert-link" ID="hyperLinkEsqueceuPassword" Text="Esqueceu-se da password?" NavigateUrl="~/PwdMgmt/NewPasswordRequest.aspx" runat="server" />
        </div>
</asp:Content>
