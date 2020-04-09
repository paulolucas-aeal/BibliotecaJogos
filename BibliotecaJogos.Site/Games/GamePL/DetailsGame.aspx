<%@ Page Title="" Language="C#" MasterPageFile="~/SiteGames.Master" AutoEventWireup="true" CodeBehind="DetailsGame.aspx.cs" Inherits="BibliotecaJogos.Site.Games.GamePL.DetailsGame" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content-page">
        <h2>Detalhes do Jogo</h2>

        <table>
            <tr>
                <td>Título</td>
                <td>
                    <asp:Label ID="labelTitle" runat="server" /></td>
            </tr>
            <tr>
                <td>Capa</td>
                <td>
                    <asp:Image ID="imageCoverImage" Style="width: 150px; height: 200px" runat="server" /></td>
            </tr>
            <tr>
                <td>Valor Pago</td>
                <td>
                    <asp:Label ID="labelAmountPaid" runat="server" /></td>
            </tr>
            <tr>
                <td>Data da Compra</td>
                <td>
                    <asp:Label ID="labelPurchaseDate" runat="server" /></td>
            </tr>
            <tr>
                <td>Editora</td>
                <td>
                    <asp:Label ID="labelPublisher" runat="server" /></td>
            </tr>
            <tr>
                <td>Género</td>
                <td>
                    <asp:Label ID="labelGenre" runat="server" /></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button CssClass="btn btn-primary" ID="buttonVoltarCatalogo" Text="Voltar ao Catálogo" runat="server" OnClick="buttonVoltarCatalogo_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
