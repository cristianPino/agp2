<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="respuesta_usuario.aspx.cs" Inherits="sistemaAGP.respuesta_usuario" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Página sin título</title>
    <style type="text/css">
        .style1
        {
            width: 24%;
            height: 103px;
        }
        .style2
        {
            width: 95px;
        }
        .style3
        {
            width: 98px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table bgcolor="#336699" class="style1">
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:Label ID="Label1" runat="server" Font-Names="Arial" Font-Size="Small" 
                    ForeColor="White" Text="Esta seguro  de Guardar?"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style3" style="text-align: center">
                <asp:Button ID="Button1" runat="server" Text="Si" />
            </td>
            <td class="style2" style="text-align: center">
                <asp:Button ID="Button2" runat="server" Text="No" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
