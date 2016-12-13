<%@ Page Title="" Language="C#" MasterPageFile="~/AGP.Master" AutoEventWireup="true" CodeBehind="Control_Maestro.aspx.cs" Inherits="sistemaAGP.Control_Maestro" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMenu" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoCentral" runat="server">
	<div style="width: 100%; background-color: #507cd1;">
		<asp:UpdatePanel ID="upFiltros" runat="server">
			<ContentTemplate>
				<table style="width: 100%; background-color: #507cd1;">
					<tr>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #ffffff;">
							<strong>Cliente</strong>
						</td>
						<td>
							<asp:DropDownList ID="dl_cliente" runat="server" Font-Names="Arial" Font-Size="X-Small" Width="250px" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #000000;" AutoPostBack="True" OnSelectedIndexChanged="dl_cliente_SelectedIndexChanged">
							</asp:DropDownList>
						</td>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #ffffff;">
							<strong>Familia</strong>
						</td>
						<td>
							<asp:DropDownList ID="dl_familia" runat="server" Font-Names="Arial" Font-Size="X-Small" Width="138px" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #000000;" OnSelectedIndexChanged="dl_familia_SelectedIndexChanged" AutoPostBack="true">
							</asp:DropDownList>
							<asp:RequiredFieldValidator ID="rfv_familia" runat="server" ControlToValidate="dl_familia" ErrorMessage="Debe seleccionar la familia" Text="*" InitialValue="0"></asp:RequiredFieldValidator>
						</td>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #ffffff;">
							<strong>Producto</strong>
						</td>
						<td>
							<asp:DropDownList ID="dl_producto" runat="server" Font-Names="Arial" Font-Size="X-Small" Width="200px" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #000000;">
							</asp:DropDownList>
							<asp:RequiredFieldValidator ID="rfv_producto" runat="server" ControlToValidate="dl_producto" ErrorMessage="Debe seleccionar el producto" Text="*" InitialValue="0"></asp:RequiredFieldValidator>
						</td>
					</tr>
					<tr>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #ffffff;">
							<strong>Sucursal</strong>
						</td>
						<td>
							<asp:DropDownList ID="dl_sucursal" runat="server" Font-Names="Arial" Font-Size="X-Small" Width="138px" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #000000;">
							</asp:DropDownList>
						</td>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #ffffff;">
							<strong>Desde</strong>
						</td>
						<td>
							<asp:TextBox ID="txt_desde" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" Width="73px"></asp:TextBox>
							<asp:ImageButton ID="ib_desde" runat="server" ImageUrl="../imagenes/sistema/gif/calendario.gif" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" />
							<ajaxToolkit:CalendarExtender ID="cal_desde" runat="server" TargetControlID="txt_desde" CssClass="calendario" Format="dd/MM/yyyy" PopupButtonID="ib_desde" TodaysDateFormat="dd/MM/yyyy" OnClientDateSelectionChanged="checkDate" />
						</td>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #ffffff;">
							<strong>Hasta</strong>
						</td>
						<td>
							<asp:TextBox ID="txt_hasta" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" Width="73px"></asp:TextBox>
							<asp:ImageButton ID="ib_hasta" runat="server" ImageUrl="../imagenes/sistema/gif/calendario.gif" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" />
							<ajaxToolkit:CalendarExtender ID="cal_hasta" runat="server" TargetControlID="txt_hasta" CssClass="calendario" Format="dd/MM/yyyy" PopupButtonID="ib_hasta" TodaysDateFormat="dd/MM/yyyy" OnClientDateSelectionChanged="checkDate" />
						</td>
					</tr>
					<tr>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #ffffff;">
							<strong>Nº Operacion</strong>
						</td>
						<td>
							<asp:TextBox ID="txt_operacion" runat="server" Width="80px" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #FFFFFF;" BackColor="#3399ff" ForeColor="White"></asp:TextBox>
							<ajaxToolkit:FilteredTextBoxExtender ID="fte_operacion" runat="server" TargetControlID="txt_operacion" FilterType="Custom, Numbers" ValidChars="">
							</ajaxToolkit:FilteredTextBoxExtender>
						</td>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #ffffff;">
							<strong>Rut Consignatario</strong>
						</td>
						<td>
							<asp:TextBox ID="txt_rut" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" MaxLength="8" Width="60px" ToolTip="Ingrese el RUT sin puntos ni digito verificador"></asp:TextBox>
							<ajaxToolkit:FilteredTextBoxExtender ID="fte_rut" runat="server" TargetControlID="txt_rut" FilterType="Custom, Numbers" ValidChars="">
							</ajaxToolkit:FilteredTextBoxExtender>
						</td>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #ffffff;">
							<strong>Patente</strong>
						</td>
						<td>
							<asp:TextBox ID="txt_patente" runat="server" MaxLength="6" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" Width="60px"></asp:TextBox>
						</td>
					</tr>
				</table>
			</ContentTemplate>
		</asp:UpdatePanel>
		<div style="padding: 3px;">
			<asp:ImageButton ID="bt_exportar" runat="server" AlternateText="Exportar" ImageAlign="AbsMiddle" ImageUrl="~/imagenes/sistema/static/excel_small.png" Style="background-color: #ffffff; padding: 2px; border: 1px solid #cccccc;" OnClick="bt_exportar_Click" />
			<asp:ValidationSummary ID="vs_datos" runat="server" CssClass="errorSummary" DisplayMode="List" HeaderText="Revise los datos faltantes" ShowMessageBox="true" ShowSummary="false" />
		</div>
	</div>
</asp:Content>