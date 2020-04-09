<%@ Page Title="" Language="C#" MasterPageFile="~/SiteGames.Master" AutoEventWireup="true" CodeBehind="EditGame.aspx.cs" Inherits="BibliotecaJogos.Site.Games.GamePL.EditGame" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="content-page">
        <input type="hidden" id="hiddenID_Game" runat="server" />

        <h2>Edição do Jogo</h2>
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
                    <asp:Image ID="imageCoverImage" Width="150px" Height="200px" runat="server" />
                </td>
            </tr>
            <tr>
                <td>Nova Capa</td>
                <td>
                    <asp:FileUpload ID="fileUploadNewCoverImage" runat="server" />
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
                    <asp:Button CssClass="btn btn-primary" ID="buttonSalvarJogo" Text="Salvar" runat="server" OnClick="buttonSalvarJogo_Click" />
                    <asp:Button CssClass="btn btn-secondary" ID="buttonCancelar" Text="Cancelar" CausesValidation="false" runat="server" OnClick="buttonCancelar_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
