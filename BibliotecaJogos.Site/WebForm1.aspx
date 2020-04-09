<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="BibliotecaJogos.Site.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />

</head>
<body>

    <%-- NAVBAR --%>
    <nav class="navbar navbar-expand-md bg-dark navbar-dark ">
        <%--NAVBAR-BRAND--%>
        <a class="navbar-brand" href="#">Brand</a>
        <%--NAVBAR-TOGGLER--%>
        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarText">
            <span class="navbar-toggler-icon"></span>
        </button>
        <%--NAVBAR-COLLAPSE--%>
        <div class="collapse navbar-collapse" id="navbarText">
            <%--NAVBAR-NAV--%>
            <ul class="navbar-nav">
                <%--NAV-ITEM--%>
                <li class="nav-item">
                    <%--NAV-LINK--%>
                    <a class="nav-link" href="#">content1</a>
                </li>
                <%--NAV-ITEM--%>
                <li class="nav-item">
                    <%--NAV-LINK--%>
                    <a class="nav-link" href="#">content2</a>
                </li>
                <%--NAV-ITEM--%>
                <li class="nav-item">
                    <%--NAV-LINK--%>
                    <a class="nav-link" href="#">content3</a>
                </li>
            </ul>
        </div>
    </nav>

    <%--    <div class="container">
        <div class="row">
            <asp:Repeater ID="repeaterTeste" ItemType="BibliotecaJogos.Models.Game" runat="server">
                <ItemTemplate>
                    <div class="col-sm-4">
                        <a href="/Games/GamePL/DetailsGame.aspx?id_game=<%#Item.Id_Game%>"><img src="/Content/CoverImages/<%#Item.Cover_Image%>" height="200" width="150"/></a>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>--%>

    <%--<div class="container">
        <div class="row">
            <asp:Repeater ID="repeaterTeste" runat="server">
                <ItemTemplate>
                    <div class="col-sm-4">
                        <a href="/Games/GamePL/DetailsGame.aspx?id_game=<%#Eval("Id_Game")%>"><img src="/Content/CoverImages/<%#Eval("Cover_Image")%>" height="200" width="150"/></a>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>--%>

    <%--<div class="container">
        <div class="row">
            <asp:Repeater ID="repeaterTeste" runat="server">
                <ItemTemplate>
                    <div class="col-sm-3">
                        <a href="/Games/GamePL/DetailsGame.aspx?id_game=<%#DataBinder.Eval(Container.DataItem, "Id_Game")%>"><img src="/Content/CoverImages/<%#DataBinder.Eval(Container.DataItem, "Cover_Image")%>" height="200" width="150"/></a>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>--%>

    <div class="container">
        <asp:ListView ID="listVewTeste" GroupItemCount="3" ItemType="BibliotecaJogos.Models.Game" runat="server">
            <GroupTemplate>
                <div class="row" id="itemPlaceholderContainer" runat="server">
                    <span id="itemPlaceholder" runat="server"></span>
                </div>
            </GroupTemplate>

            <ItemTemplate>
                <div style="padding:5px">
                    <a href="/Games/GamePL/DetailsGame.aspx?id_game=<%#DataBinder.Eval(Container.DataItem, "Id_Game")%>">
                        <img class="img-thumbnail" src="/Content/CoverImages/<%#DataBinder.Eval(Container.DataItem, "Cover_Image")%>" height="200" width="150" /></a>
                </div>
            </ItemTemplate>
        </asp:ListView>
    </div>


    <%--<form id="form1" runat="server">
        <asp:ListView ID="listViewPublishers" GroupItemCount="3" ItemType="BibliotecaJogos.Models.Publisher" runat="server">
            <EmptyDataTemplate>
                <span>No data was returned.</span>
            </EmptyDataTemplate>
            <GroupTemplate>
                <span id="itemPlaceholderContainer" runat="server">
                    <span id="itemPlaceholder" runat="server"></span>
                </span>
            </GroupTemplate>
            <ItemTemplate>
                <a href="#"><%# Item.Name_Publisher %></a>
            </ItemTemplate>
            <ItemSeparatorTemplate><b>&</b> </ItemSeparatorTemplate>
        </asp:ListView>
    </form>--%>

    <script src="Scripts/jquery-3.4.1.min.js"></script>
    <script src="Scripts/popper.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>


</body>
</html>
