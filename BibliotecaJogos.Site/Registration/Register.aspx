<%@ Page Language="C#" MasterPageFile="~/SiteOutOfContentApp.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="BibliotecaJogos.Site.Registration.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Registo</h2>
    <div class="form-group">
        <asp:TextBox CssClass="form-control" ID="textBoxUsername" placeholder="Username" runat="server" />
        <asp:RequiredFieldValidator ForeColor="Red" ErrorMessage="É necessário o username" Text="*" ControlToValidate="textBoxUsername" runat="server" />
    </div>
    <div class="form-group">
        <asp:TextBox CssClass="form-control" ID="textBoxEmail" placeholder="Email" TextMode="Email" runat="server" />
        <asp:RequiredFieldValidator ForeColor="Red" ErrorMessage="É necessário o email" Text="*" ControlToValidate="textBoxEmail" runat="server" />
    </div>
    <div class="form-group">
        <asp:TextBox CssClass="form-control" ID="textBoxPassword" placeholder="Password" TextMode="Password" runat="server" />
        <asp:RequiredFieldValidator ForeColor="Red" ErrorMessage="É necessário a password" Text="*" ControlToValidate="textBoxPassword" runat="server" />
    </div>
    <div class="form-group">
        <asp:TextBox CssClass="form-control" ID="textBoxConfirmPassword" placeholder="Confirme a password" TextMode="Password" runat="server" />
        <asp:RequiredFieldValidator Display="Dynamic" ForeColor="Red" ErrorMessage="É necessário a confirmação da password" Text="*" ControlToValidate="textBoxConfirmPassword" runat="server" />
        <asp:CompareValidator Display="Dynamic" ForeColor="Red" ErrorMessage="As passwords não coincidem" Text="*" ControlToValidate="textBoxConfirmPassword" ControlToCompare="textBoxPassword" runat="server" />
    </div>
    <div>
        <asp:ValidationSummary HeaderText="Erros de Validação" ForeColor="Red" runat="server" />
    </div>
    <div>
        <asp:Label ID="labelMensagem" runat="server" />
        <asp:HyperLink ID="hyperlinkLogin" Text="Clique aqui para Login" NavigateUrl="~/Authentication/Login.aspx" Visible="false" runat="server" />
    </div>
    <div>
        <asp:Button CssClass="btn btn-primary" ID="buttonRegistar" Text="Registar" runat="server" OnClick="buttonRegistar_Click" />
        <asp:Button CssClass="btn btn-secondary" ID="buttonCancelar" Text="Cancelar" CausesValidation="false" runat="server" OnClick="buttonCancelar_Click" />
    </div>
</asp:Content>
