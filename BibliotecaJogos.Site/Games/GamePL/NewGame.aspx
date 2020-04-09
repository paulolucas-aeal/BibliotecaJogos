<%@ Page Title="" Language="C#" MasterPageFile="~/SiteGames.Master" AutoEventWireup="true" CodeBehind="NewGame.aspx.cs" Inherits="BibliotecaJogos.Site.Games.GamePL.NewGame" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content-page">
        <h2>Novo Jogo</h2>
        <table>
            <tr>
                <td>Título</td>
                <td>
                    <asp:TextBox ID="textBoxTitle" runat="server" />
                    <asp:RequiredFieldValidator ErrorMessage="errormessage" Text="*" ForeColor="Red" ControlToValidate="textBoxTitle" runat="server" />
                </td>
            </tr>
            <tr>
                <td>Capa</td>
                <td>
                    <asp:FileUpload ID="fileUploadCoverImage" runat="server" />
                    <asp:RequiredFieldValidator ErrorMessage="errormessage" Text="*" ForeColor="Red" ControlToValidate="fileUploadCoverImage" runat="server" />
                </td>
            </tr>
            <tr>
                <td>Valor pago</td>
                <td>
                    <asp:TextBox ID="textBoxAmountPaid" runat="server" />
                </td>
            </tr>
            <tr>
                <td>Data da compra</td>
                <td>
                    <asp:TextBox ID="textBoxPurchaseDate" TextMode="Date" runat="server" />
                </td>
            </tr>
            <tr>
                <td>Editor</td>
                <td>
                    <asp:DropDownList ID="dropDownListPublishers" runat="server">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ErrorMessage="errormessage" Text="*" ForeColor="Red" ControlToValidate="dropDownListPublishers" runat="server" />
                </td>
            </tr>
            <tr>
                <td>Género</td>
                <td>
                    <asp:DropDownList ID="dropDownListGenres" runat="server">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ErrorMessage="errormessage" Text="*" ForeColor="Red" ControlToValidate="dropDownListGenres" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:ValidationSummary HeaderText="Erros na Validação dos Campos" ForeColor="Red" runat="server" />
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
                    <asp:Button CssClass="btn btn-primary" ID="buttonInserirJogo" Text="Inserir" runat="server" OnClick="buttonInserirJogo_Click" />
                    <asp:Button CssClass="btn btn-info" ID="buttonLimpar" Text="Limpar" CausesValidation="false" runat="server" OnClick="buttonLimpar_Click" />
                    <asp:Button CssClass="btn btn-secondary" ID="buttonCancelar" Text="Cancelar" CausesValidation="false" runat="server" OnClick="buttonCancelar_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
