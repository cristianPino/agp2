<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="reestablecer_clave.aspx.cs"
    Inherits="sistemaAGP.reestablecer_clave" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Reestablecer contraseña</title>
    <link rel="stylesheet" href="~/estilos/Master2.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div style="position: absolute; top: 50%; left: 50%; width: 800px; margin-left: -400px;
        height: 600px; margin-top: -300px;">
          
        <div class="divInfoNoAnclado">
          <div style="float: left">
                <img src="imagenes/sistema/static/infoAuto/exclamacion.png" />
            </div>
            <div class="divCabeceraMenuBoton">
                <asp:Label ID="lblMensaje" runat="server" Font-Size="X-Small" Text="lblMensaje"></asp:Label>
            </div>
        </div>
        <br />
        <br />
        <div style="float: left;">
            <table>
                <tr>
                    <td>
                        <span>Contraseña nueva:&nbsp; &nbsp; </span>
                    </td>
                    <td>
                         <asp:TextBox ID="txtContrasena"  runat="server" MaxLength="10" CssClass="inputs" Width="200" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <span>Confirme contraseña:</span>
                    </td>
                    <td>
                           <asp:TextBox ID="txtContrasenaConfirm" runat="server" MaxLength="10" CssClass="inputs" Width="200" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        
                    </td>
                    <td style="text-align: right">
                        <asp:Button ID="btnAceptar" runat="server" CssClass="button" Text="Reestablecer"
                            OnClick="btnAceptar_Click" />
                    </td>
                </tr>
                 </table>
        </div>
        <div  style="float: left;">
            <img src="imagenes/sistema/static/llave.jpg" width="400" />
        </div>
    </div>
    </form>
</body>
</html>
