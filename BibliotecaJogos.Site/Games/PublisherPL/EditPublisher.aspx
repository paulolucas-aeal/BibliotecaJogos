<%@ Page Title="" Language="C#" MasterPageFile="~/SiteGames.Master" AutoEventWireup="true" CodeBehind="EditPublisher.aspx.cs" Inherits="BibliotecaJogos.Site.Games.PublisherPL.EditPublisher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content-page">
        <h2>Editoras</h2>

        <asp:GridView ID="gridViewPublishers" AutoGenerateColumns="False" runat="server" EmptyDataText="Sem registos"
            OnRowEditing="gridViewPublishers_RowEditing"
            OnRowUpdating="gridViewPublishers_RowUpdating"
            OnRowCancelingEdit="gridViewPublishers_RowCancelingEdit"
            OnRowDeleting="gridViewPublishers_RowDeleting" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
            <Columns>
                <asp:BoundField DataField="id_publisher" HeaderText="ID" ReadOnly="true" />
                <asp:BoundField DataField="name_publisher" HeaderText="Nome da Editora" />

                <asp:CommandField ShowEditButton="true" />
                <asp:CommandField ShowDeleteButton="true" />
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

        <asp:Label ID="labelMensagem" Visible="false" runat="server" />

        <br />
        <asp:Button CssClass="btn btn-primary" ID="buttonNovaEditora" Text="Nova Editora" runat="server" OnClick="buttonNovaEditora_Click" />
        <asp:Button CssClass="btn btn-secondary" ID="buttonVerCatalogo" Text="Ver Catálogo dos Jogos" runat="server" OnClick="buttonVerCatalogo_Click" />
    </div>
</asp:Content>
