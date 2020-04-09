<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormTesteTemplateField.aspx.cs" Inherits="BibliotecaJogos.Site.WebFormTesteTemplateField" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="gridViewUsers" DataKeyNames="Id_User" AutoGenerateColumns="false" ItemType="BibliotecaJogos.Models.User" runat="server">
                <Columns>
                   <asp:BoundField HeaderText="ID" DataField="Id_User"/>
                   <asp:BoundField HeaderText="Username" DataField="Username"/>
                    <asp:BoundField HeaderText="Role" DataField="Role"/>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:CheckBox ID="checkBoxEliminar" Text="Eliminar" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            <asp:Button ID="buttonAtualizar" Text="Atualizar" runat="server" OnClick="buttonAtualizar_Click"/>
        </div>
    </form>
</body>
</html>
