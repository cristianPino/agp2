<%@ Page Language="C#" MasterPageFile="~/AGP.Master" AutoEventWireup="true" CodeBehind="mExportaEjecutivoSucursal.aspx.cs" Inherits="sistemaAGP.mExportaEjecutivoSucursal" Title="Exporta Ejecutivos por cliente - sucursal" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMenu" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoCentral" runat="server">
	<div>
		<table bgcolor="#E5E5E5" style="width: 459px; height: 41px;">
			<tr>
				<td>
					
					&nbsp;</td>
			</tr>
		</table>
		<table style="width: 50%; font-family: Arial, Helvetica, sans-serif; font-size: x-small" bgcolor="#E5E5E5">
			<tr>
				<td style="vertical-align: middle;">
					<strong>Desde</strong>
				</td>
				<td style="vertical-align: middle;">
					<asp:TextBox ID="txt_desde" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 75px;"></asp:TextBox>
					<asp:ImageButton ID="ib_desde" runat="server" ImageUrl="../imagenes/sistema/gif/calendario.gif" />
					<ajaxToolkit:CalendarExtender ID="cal_desde" runat="server" TargetControlID="txt_desde" CssClass="calendario" Format="dd/MM/yyyy" PopupButtonID="ib_desde" TodaysDateFormat="dd/MM/yyyy" OnClientDateSelectionChanged="checkDate" />
				</td>
				<td style="vertical-align: middle;">
					<strong>Hasta</strong>
				</td>
				<td style="vertical-align: middle;">
					<asp:TextBox ID="txt_hasta" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 75px;"></asp:TextBox>
					<asp:ImageButton ID="ib_hasta" runat="server" ImageUrl="../imagenes/sistema/gif/calendario.gif" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" />
					<ajaxToolkit:CalendarExtender ID="cal_hasta" runat="server" TargetControlID="txt_hasta" CssClass="calendario" Format="dd/MM/yyyy" PopupButtonID="ib_hasta" TodaysDateFormat="dd/MM/yyyy" OnClientDateSelectionChanged="checkDate" />
				</td>
				<td style="vertical-align: middle;">
				<asp:Button ID="Button1" runat="server" Font-Names="Arial" Visible="True" Font-Size="X-Small" Text="Exportar" OnClick="Button1_Click" TabIndex="16" />
					
					<asp:HyperLink ID="HyperLink1" runat="server" Visible="false" Target="_blank">Descargar</asp:HyperLink>
					
				</td>
			</tr>
		</table>
	</div>
	
	
	
	
	
	
	
	
	
	<br />

</asp:Content>