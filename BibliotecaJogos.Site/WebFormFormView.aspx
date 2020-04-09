<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormFormView.aspx.cs" Inherits="BibliotecaJogos.Site.WebFormFormView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:FormView ID="formViewGame" ItemType="BibliotecaJogos.Models.Game" runat="server">
                <ItemTemplate>
                    <table>
                        <tr>
                            <td>Título</td>
                            <td><%#: Item.Title %></td>
                        </tr>
                        <tr>
                            <td>Valor pago</td>
                            <td><%#: String.Format("{0:c}", Item.Amount_Paid) %></td>
                        </tr>
                        <tr>
                            <td>Data da compra</td>
                            <td><%#: String.Format("{0:d}",Item.Purchase_Date) %></td>
                        </tr>
                        <tr>
                            <td>Editora</td>
                            <td><%#: Item.Id_Publisher %></td>
                        </tr>
                        <tr>
                            <td>Género</td>
                            <td><%#: Item.Id_Genre %></td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:FormView>
        </div>
    </form>
</body>
</html>
