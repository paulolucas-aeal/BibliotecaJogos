<%@ Page Language="C#" MasterPageFile="~/SiteOutOfContentApp.Master" AutoEventWireup="true" CodeBehind="NewPasswordRequest.aspx.cs" Inherits="BibliotecaJogos.Site.PwdMgmt.NewPasswordRequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2>Solicitação de Nova Password</h2>

        <div class="form-group">
            <asp:TextBox CssClass="form-control" ID="textBoxEmail" placeholder="Email de registo no sistema" TextMode="Email" runat="server" />
            <asp:RequiredFieldValidator ErrorMessage="É necessário o email" Text="*" ForeColor="Red" ControlToValidate="textBoxEmail" runat="server" />
        </div>
        <div>
            <asp:ValidationSummary HeaderText="Erros na Validação do Campo" ForeColor="Red" runat="server" />
        </div>
        <div>
            <asp:Label ID="labelMensagem" Visible="false" runat="server" />
        </div>
        <div>
            <asp:HyperLink ID="hyperLinkLogin" Text="Clique aqui para Login" NavigateUrl="~/Authentication/Login.aspx" Visible="false" runat="server" />
        </div>
        <div>
            <asp:Button CssClass="btn btn-primary" ID="buttonSubmeterPedido" Text="Submeter pedido" runat="server" OnClick="buttonSubmeterPedido_Click" />
            <asp:Button CssClass="btn btn-secondary" ID="buttonCancelar" Text="Cancelar" CausesValidation="false" runat="server" OnClick="buttonCancelar_Click" />
        </div>
    </div>
</asp:Content>
