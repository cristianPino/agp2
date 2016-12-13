<%@ Page Title="" Language="C#" MasterPageFile="~/Adm.Master" AutoEventWireup="true" CodeBehind="MailGeneral.aspx.cs" Inherits="sistemaAGP.operacion.MailGeneral" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 255px;
        }
        .style2
        {
            font-size: x-small;
            font-family: Arial;
        }
        .style3
        {
            font-size: x-small;
            font-family: Arial;
            height: 75px;
        }
        .style4
        {
            width: 255px;
            height: 75px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<table>
<tr>

<td class="style2">
Destinarario
</td>
<td class="style1">

    <asp:TextBox ID="txt_para" runat="server" Width="324px"></asp:TextBox>

</td>
</tr>
<tr>

<td class="style2">
CC
</td>
<td class="style1">

    <asp:TextBox ID="txt_cc" runat="server" Width="324px"></asp:TextBox>

</td>
</tr>
<tr>
<td class="style2">
Asunto
</td>
<td class="style1">

    <asp:TextBox ID="txt_asunto" runat="server" Width="323px"></asp:TextBox>

</td>
</tr>
<tr>
<td class="style3">
Mensaje
</td>
<td class="style4">

    <asp:TextBox ID="txt_mensaje" runat="server" Font-Overline="False" 
        Width="318px"></asp:TextBox>

</td>
</tr>
<tr>
<td class="style2">
Adjuntar Archivo
</td>
<td class="style1">

    <asp:FileUpload ID="FileUpload1" runat="server" Width="325px" />

</td>




</tr>

</table>

</asp:Content>


