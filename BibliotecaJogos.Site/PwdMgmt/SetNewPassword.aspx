<%@ Page Language="C#" MasterPageFile="~/SiteOutOfContentApp.Master" AutoEventWireup="true" CodeBehind="SetNewPassword.aspx.cs" Inherits="BibliotecaJogos.Site.PwdMgmt.SetNewPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Nova Password</h2>
    <input type="hidden" id="hiddenEmail" runat="server" />
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
        <asp:Button CssClass="btn btn-primary" ID="buttonSubmeterNovaPassword" Text="Redefinir Password" runat="server" OnClick="buttonSubmeterNovaPassword_Click" />
        <asp:Button CssClass="btn btn-secondary" ID="buttonCancelar" Text="Cancelar" CausesValidation="false" runat="server" OnClick="buttonCancelar_Click" />
    </div>
</asp:Content>
