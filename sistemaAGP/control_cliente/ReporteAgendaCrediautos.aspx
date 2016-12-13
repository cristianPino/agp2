﻿<%@ Page Title="" Language="C#" MasterPageFile="~/AGP.Master" AutoEventWireup="true" CodeBehind="ReporteAgendaCrediautos.aspx.cs" Inherits="sistemaAGP.control_cliente.ReporteAgendaCrediautos" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMenu" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoCentral" runat="server">
<table width="100%">
    <tr>
        <td>
            <asp:Label ID="Label1" runat="server" Text="Nro de Operacion"></asp:Label>
            &nbsp;&nbsp;
            <asp:TextBox ID="txt_nroOpe" runat="server" style="font-size:9px; font-family:Tahoma;" onKeyPress="return solonumeros(event)"></asp:TextBox>
        </td>
        <td>
            <asp:Label ID="Label2" runat="server" Text="Ejecutivo Comercial"></asp:Label>
            &nbsp;&nbsp;
            <asp:DropDownList ID="cbo_EjeCom" runat="server" ToolTip="Ejecutivo Comercial Asociado al Credito" style="font-size:9px; font-family:Tahoma;">
            </asp:DropDownList>
        </td>
        <td>
            <asp:Label ID="Label3" runat="server" Text="Ejecutivo Operaciones"></asp:Label>
            &nbsp;&nbsp;
            <asp:DropDownList ID="cbo_EjeOpe" runat="server" ToolTip="Ejecutivo Comercial Asociado al Credito" style="font-size:9px; font-family:Tahoma;">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label4" runat="server" Text="Rut Cliente"></asp:Label>
            &nbsp;&nbsp;
            <asp:TextBox ID="txt_rutCli" runat="server" style="font-size:9px; font-family:Tahoma;" onKeyPress="return solonumeros(event)"></asp:TextBox>
        </td>
        <td>
            <asp:Label ID="Label5" runat="server" Text="Desde"></asp:Label>
            &nbsp;&nbsp;
            <asp:TextBox ID="txt_desde" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" Height="19px" Width="73px" TabIndex="2"></asp:TextBox>
									<asp:ImageButton ID="ib_desde" runat="server" ImageUrl="../imagenes/sistema/gif/calendario.gif" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" />
									<cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_desde" CssClass="calendario" Format="dd/MM/yyyy" PopupButtonID="ib_desde" />
        </td>
        <td>
            <asp:Label ID="Label6" runat="server" Text="Hasta"></asp:Label>
            &nbsp;&nbsp;
            <asp:TextBox ID="txt_hasta" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" Height="19px" Width="73px" TabIndex="2"></asp:TextBox>
			<asp:ImageButton ID="ib_hasta" runat="server" ImageUrl="../imagenes/sistema/gif/calendario.gif" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" />
			<cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txt_hasta" CssClass="calendario" Format="dd/MM/yyyy" PopupButtonID="ib_hasta" />
        </td>
    </tr>
    <tr>
        <td colspan="3" align="center">
            <asp:ImageButton ID="img_buscar" runat="server" 
                ImageUrl="../imagenes/sistema/gif/lupa.gif" Height="21px" Width="30px" 
                onclick="img_buscar_Click" />
        </td>
    </tr>
</table>
</asp:Content>
