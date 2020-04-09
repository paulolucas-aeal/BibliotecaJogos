<%@ Page Title="" Language="C#" MasterPageFile="~/SiteGames.Master" AutoEventWireup="true" CodeBehind="NewGenre.aspx.cs" Inherits="BibliotecaJogos.Site.Games.GenrePL.NewGenre" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content-page">
        <h2>Novo Género</h2>
        <table>
            <tr>
                <td>Género</td>
                <td>
                    <asp:TextBox ID="textBoxDescriptionGenre" runat="server" />
                    <asp:RequiredFieldValidator ErrorMessage="É necessário o género" Text="*" ForeColor="Red" ControlToValidate="textBoxDescriptionGenre" runat="server" />
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
                    <asp:Button CssClass="btn btn-primary" ID="buttonInserirGenero" Text="Inserir" runat="server" OnClick="buttonInserirGenero_Click" />
                    <asp:Button CssClass="btn btn-secondary" ID="buttonCancelar" Text="Cancelar" CausesValidation="false" runat="server" OnClick="buttonCancelar_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
