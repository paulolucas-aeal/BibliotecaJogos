<%@ Page Title="" Language="C#" MasterPageFile="~/SiteGames.Master" AutoEventWireup="true" CodeBehind="NewPublisher.aspx.cs" Inherits="BibliotecaJogos.Site.Games.PublisherPL.NewPublisher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content-page">
        <h2>Nova Editora</h2>
        <table>
            <tr>
                <td>Editora</td>
                <td>
                    <asp:TextBox ID="textBoxNamePublisher" runat="server" />
                    <asp:RequiredFieldValidator ErrorMessage="É necessário o nome da editora" Text="*" ForeColor="Red" ControlToValidate="textBoxNamePublisher" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:ValidationSummary HeaderText="Erros na Validação do Campo" ForeColor="Red" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="labelMensagem" runat="server" />
                    <asp:HyperLink ID="hyperlinkLibrary" Text="Clique aqui para aceder ao catálogo" NavigateUrl="~/Games/GameLibraryPL/GameLibrary.aspx" Visible="false" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button CssClass="btn btn-primary" ID="buttonInserirEditora" Text="Inserir" runat="server" OnClick="buttonInserirEditora_Click" />
                    <asp:Button CssClass="btn btn-secondary" ID="buttonCancelar" Text="Cancelar" CausesValidation="false" runat="server" OnClick="buttonCancelar_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
