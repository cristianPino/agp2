<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ERROR.aspx.cs" Inherits="sistemaAGP.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1
        {
            top: -12px;
            left: 1px;
            position: absolute;
            height: 646px;
            width: 1254px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" 
    style="color: #000000; background-color: #00FF00; position: absolute">
    <asp:Label ID="Label1" runat="server" 
        style="top: 68px; left: 428px; position: absolute; height: 19px; width: 176px" 
        Text="ERRORES AGP"></asp:Label>
    <asp:Label ID="Label2" runat="server" 
        style="top: 133px; left: 16px; position: absolute; height: 68px; width: 309px" Text="La página que intentó acceder no existe en este servidor. 
Esta página no puede existir debido a las siguientes razones: "></asp:Label>
    <asp:Label ID="Label3" runat="server" 
        style="top: 227px; left: 182px; position: absolute; height: 71px; width: 286px" 
        Text="La URL que ha introducido en su navegador es incorrecta. Por favor, vuelva a introducir la dirección URL e inténtelo de nuevo. "></asp:Label>
    <asp:Label ID="Label4" runat="server" 
        style="top: 332px; left: 180px; position: absolute; height: 66px; width: 286px" 
        Text="El link que ha hecho clic no funciona. Póngase en contacto con el propietario de este sitio web para informarles de esta situación."></asp:Label>
    <img alt="" src="../imagenes/agp.jpg" 
        style="width: 489px; height: 244px; top: 105px; left: 499px; position: absolute" /></form>
</body>
</html>
