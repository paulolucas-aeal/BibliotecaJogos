<%@ Page Title="" Language="C#" MasterPageFile="~/SiteGames.Master" AutoEventWireup="true"
    CodeBehind="GameLibrary.aspx.cs" Inherits="BibliotecaJogos.Site.Games.GameLibraryPL.GameLibrary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="content-page">
        <h4>Catálogo dos Jogos</h4>

        <div id="divButtonNovoJogo">
            <asp:Button ID="buttonNovoJogo" CssClass="btn btn-primary" Text="Novo Jogo" runat="server" OnClick="buttonNovoJogo_Click"/>
            <hr />
        </div>

        <asp:Repeater ID="repeaterGameLibrary" runat="server">
            <ItemTemplate>
                <div class="jogo-area" onclick="go(<%# DataBinder.Eval(Container.DataItem, "Id_Game")%>, '<%= Session["role"].ToString()%>')">
                    <div>
                        <img style="width: 150px; height: 200px" src="../../Content/CoverImages/<%# DataBinder.Eval(Container.DataItem, "Cover_Image")%>"
                            alt="<%# DataBinder.Eval(Container.DataItem, "Cover_Image")%>" />
                    </div>
                    <div>
                        <%# DataBinder.Eval(Container.DataItem, "Title")%>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    
    <script>
        function go(id_jogo, role) {
            if (role == "A") {
                top.location.href = "../../Games/GamePL/EditGame.aspx?id_game=" + id_jogo;
            } else if (role == "U") {
                top.location.href = "../../Games/GamePL/DetailsGame.aspx?id_game=" + id_jogo;
            } else {
                top.location.href = "../../Games/GamePL/DetailsGame.aspx?id_game=" + id_jogo;
            }
        }
    </script>

</asp:Content>

