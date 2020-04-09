<%@ Page Title="" Language="C#" MasterPageFile="~/SiteGames.Master" AutoEventWireup="true" CodeBehind="EditUsers.aspx.cs" Inherits="BibliotecaJogos.Site.Users.UsersPL.EditUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="content-page">
        <h2>Utilizadores</h2>

        <asp:GridView ID="gridViewUsers" DataKeyNames="Id_User" AutoGenerateColumns="False" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" OnRowDataBound="gridViewUsers_RowDataBound" >
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="Id_User"/>
                <asp:BoundField HeaderText="Nome do Utilizador" DataField="Username"/>
                <asp:TemplateField HeaderText="Privilégios de Administrador">
                    <ItemTemplate>
                        <asp:CheckBox ID="checkBoxAdministrador" Text="Administrador" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField  HeaderText="Eliminar Utilizador">
                    <ItemTemplate>
                        <asp:CheckBox ID="checkBoxEliminarUtilizador" Text="Eliminar" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#242121" />
        </asp:GridView>

        <br />
        <asp:Button CssClass="btn btn-primary" ID="buttonSalvarAlteracoes" Text="Salvar as alterações" runat="server" OnClick="buttonSalvarAlteracoes_Click" />
    </div>

</asp:Content>
