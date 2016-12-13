<%@ Page Title="" Language="C#" MasterPageFile="~/AGP.Master" AutoEventWireup="true" CodeBehind="control_garantias_pendientes.aspx.cs" Inherits="sistemaAGP.control_garantias_pendientes" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMenu" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoCentral" runat="server">
	<asp:UpdatePanel ID="upFiltros" runat="server">
		<ContentTemplate>
			<table style="width: 100%; height: 32px;" bgcolor="#507CD1">
				<tr>
					<td style="width: 38px; font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 28px; color: #FFFFFF;">
						<strong>Cliente</strong>
					</td>
					<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 28px;">
						<strong>
							<asp:DropDownList ID="dl_cliente" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="138px" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #000000;" AutoPostBack="True" OnSelectedIndexChanged="dl_cliente_SelectedIndexChanged">
							</asp:DropDownList>
						</strong>
					</td>
					<td style="width: 57px; font-family: Arial, Helvetica, sans-serif; font-size: x-small; font-weight: bold; height: 28px; color: #FFFFFF;">
						Modulo
					</td>
					<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 28px;">
						<strong>
							<asp:DropDownList ID="dl_modulo" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="138px" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #000000;">
							</asp:DropDownList>
						</strong>
					</td>
					<td style="width: 64px; font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 28px; color: #FFFFFF;">
						<strong>Sucursal</strong>
					</td>
					<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 28px;">
						<strong>
							<asp:DropDownList ID="dl_sucursal" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="138px" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #000000;">
							</asp:DropDownList>
						</strong>
					</td>
					<td style="width: 92px; font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 28px; color: #FFFFFF;">
						<strong>Nº Operacion</strong>
					</td>
					<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 28px;">
						<strong>
							<asp:TextBox ID="txt_operacion" runat="server" Width="104px" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #FFFFFF;" BackColor="#3399FF" ForeColor="White"></asp:TextBox>
							<cc1:FilteredTextBoxExtender ID="txt_operacion_FilteredTextBoxExtender" runat="server" TargetControlID="txt_operacion" FilterType="Custom, Numbers" ValidChars="">
							</cc1:FilteredTextBoxExtender>
						</strong>
					</td>
				</tr>
				<tr>
					<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #FFFFFF; font-weight: 700;">
						Adquiriente
					</td>
					<td>
						<asp:TextBox ID="txt_rut" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" MaxLength="8" Width="136px"></asp:TextBox>
						<cc1:FilteredTextBoxExtender ID="txt_rutFilteredTextBoxExtender1" runat="server" TargetControlID="txt_rut" FilterType="Custom, Numbers" ValidChars="">
						</cc1:FilteredTextBoxExtender>
					</td>
					<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #FFFFFF">
						<strong>Nº Factura</strong>
					</td>
					<td>
						<asp:TextBox ID="txt_factura" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" MaxLength="8" Width="135px"></asp:TextBox>
						<cc1:FilteredTextBoxExtender ID="txt_facturaFilteredTextBoxExtender1" runat="server" TargetControlID="txt_factura" FilterType="Custom, Numbers" ValidChars="">
						</cc1:FilteredTextBoxExtender>
					</td>
					<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #FFFFFF; font-weight: 700;">
						Nº Cliente
					</td>
					<td>
						<asp:TextBox ID="txt_cliente" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" Width="133px"></asp:TextBox>
					</td>
					<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #FFFFFF; font-weight: 700;">
						Patente
					</td>
					<td>
						<asp:TextBox ID="txt_patente" runat="server" MaxLength="6" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" Width="82px"></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td style="text-align: center;" align="center" valign="middle">
						<asp:ImageButton ID="ib_buscar" runat="server" ImageUrl="../imagenes/sistema/gif/lupa.gif" Height="30px" Width="30px" OnClick="ib_buscar_Click" Style="text-align: center" />
					</td>
					<td colspan="7">
						&nbsp;
					</td>
				</tr>
			</table>
		</ContentTemplate>
	</asp:UpdatePanel>
	<asp:UpdatePanel ID="upDatos" runat="server">
		<ContentTemplate>
			<asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" DataKeyNames="id_solicitud,cliente,tipo_operacion,p_completado" CellPadding="4" Font-Names="Arial" Font-Size="X-Small" ForeColor="#333333" GridLines="None" Height="50px" Width="100%" OnRowDataBound="gr_dato_RowDataBound">
				<Columns>
					<asp:HyperLinkField AccessibleHeaderText="id_solicitud" DataNavigateUrlFormatString="id_solicitud" DataTextField="id_solicitud" HeaderText="Operacion" Text="id_solicitud">
						<HeaderStyle HorizontalAlign="Center" />
						<ItemStyle ForeColor="#00CC00" HorizontalAlign="Center" />
					</asp:HyperLinkField>
					<asp:BoundField AccessibleHeaderText="Cliente" DataField="nombre_cliente" HeaderText="Cliente" />
					<asp:BoundField AccessibleHeaderText="Producto" DataField="operacion" HeaderText="Producto" />
					<asp:BoundField AccessibleHeaderText="Nº Factura" DataField="numero_factura" HeaderText="Nº Factura" ItemStyle-HorizontalAlign="Center" />
					<asp:BoundField AccessibleHeaderText="Patente" DataField="Patente" HeaderText="Patente" ItemStyle-HorizontalAlign="Center" />
					<asp:BoundField AccessibleHeaderText="Adquiriente" DataField="rut_persona" HeaderText="Adquiriente" ItemStyle-HorizontalAlign="Right" />
					<asp:BoundField AccessibleHeaderText="Nombre" DataField="nombre_persona" />
					<asp:TemplateField AccessibleHeaderText="Cargar" HeaderText="Cargar">
						<ItemTemplate>
							<asp:ImageButton ID="ib_cargar" runat="server" ImageUrl="../imagenes/sistema/static/carpeta.gif" />
						</ItemTemplate>
						<ControlStyle Height="25px" Width="25px" />
						<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="30px" />
					</asp:TemplateField>
					<asp:TemplateField AccessibleHeaderText="C.Digital" HeaderText="C.Digital">
						<ItemTemplate>
							<asp:ImageButton ID="ib_cdigital" runat="server" ImageUrl="../imagenes/sistema/static/carpetas.gif" />
						</ItemTemplate>
						<ControlStyle Height="25px" Width="25px" />
						<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="30px" />
					</asp:TemplateField>
					<asp:TemplateField AccessibleHeaderText="% Completado" HeaderText="% Completado" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Center">
						<ItemTemplate>
							<asp:Image ID="imgProgreso" runat="server" />
						</ItemTemplate>
					</asp:TemplateField>
				</Columns>
				<RowStyle BackColor="#EFF3FB" />
				<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
				<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
				<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
				<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
				<EditRowStyle BackColor="#2461BF" />
				<AlternatingRowStyle BackColor="White" />
			</asp:GridView>
		</ContentTemplate>
		<Triggers>
			<asp:AsyncPostBackTrigger ControlID="ib_buscar" EventName="Click" />
		</Triggers>
	</asp:UpdatePanel>
</asp:Content>