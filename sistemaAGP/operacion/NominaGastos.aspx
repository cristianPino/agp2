<%@ Page Title="" Language="C#" MasterPageFile="~/AGP.Master" AutoEventWireup="true" CodeBehind="NominaGastos.aspx.cs" Inherits="sistemaAGP.NominaGastos" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMenu" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoCentral" runat="server">
	<asp:UpdatePanel ID="up_filtros" runat="server">
		<ContentTemplate>
			<asp:Panel ID="pnl_filtros" runat="server" Style="width: 100%; background-color: #507cd1;">
				<table style="background-color: #507cd1; font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #ffffff;">
					<tr>
						<td>
							Familia AGP
						</td>
						<td>
							<asp:DropDownList ID="dl_familia" runat="server" AutoPostBack="true" Width="200px" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;" OnSelectedIndexChanged="dl_familia_SelectedIndexChanged">
							</asp:DropDownList>
						</td>
						<td>
							Tipo Nómina
						</td>
						<td>
							<asp:DropDownList ID="dl_tiponomina" runat="server" Width="200px" 
								Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;" 
								onselectedindexchanged="dl_tiponomina_SelectedIndexChanged" AutoPostBack="true">
							</asp:DropDownList>
						</td>
						<td>
							Folio
						</td>
						<td>
							<asp:TextBox ID="txt_folio" runat="server" Height="16px" Width="92px" AutoPostBack="true"
								OnTextChanged="txt_folio_TextChanged" Enabled="false"></asp:TextBox>
						</td>
					</tr>
				
				</table>
				
			</asp:Panel>
		
		</ContentTemplate>
		
	</asp:UpdatePanel>
	<asp:UpdatePanel ID="up_datos" runat="server">
		<ContentTemplate>
			<asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" 
				CellPadding="4" DataKeyNames="id_solicitud,folio,familia,tipo_operacion,id_cliente,disponible" 
				Font-Names="Arial" Font-Size="X-Small" GridLines="None" 
				EnableModelValidation="True" Width="100%" 
				onselectedindexchanged="gr_dato_SelectedIndexChanged">
				<RowStyle />
				<Columns>
					<asp:HyperLinkField HeaderText="Operación" DataNavigateUrlFormatString="id_solicitud" DataTextField="id_solicitud">
						<ItemStyle ForeColor="#00cc00" Width="60px" />
					</asp:HyperLinkField>
					<asp:BoundField HeaderText="Cliente" DataField="nombre_cliente" />
					<asp:BoundField HeaderText="folio" DataField="folio" Visible="false"/>
					<asp:BoundField HeaderText="familia" DataField="familia" Visible="false"/>
					<asp:BoundField HeaderText="Producto" DataField="operacion" />
					<asp:BoundField HeaderText="Nº Factura" DataField="numero_factura" />
					<asp:BoundField HeaderText="Patente" DataField="patente" />
					<asp:BoundField HeaderText="Adquirente" DataField="rut_persona" />
					<asp:BoundField DataField="nombre_persona" />
					<asp:ImageField AccessibleHeaderText="Semaforo" DataImageUrlField="semaforo" HeaderText="Nivel Proceso">
						<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
					</asp:ImageField>
					<asp:BoundField HeaderText="Estado Actual" DataField="ultimo_estado" />
				
					<asp:CommandField SelectText="Quitar" ShowSelectButton="True" />
				</Columns>
				<FooterStyle  Font-Bold="True" ForeColor="#ffffff" />
				<PagerStyle BackColor="#2461bf" ForeColor="#ffffff" HorizontalAlign="Center" />
				<SelectedRowStyle BackColor="#d1ddf1" Font-Bold="True" ForeColor="#333333" />
				<HeaderStyle BackColor="#507cd1" Font-Bold="True" ForeColor="#ffffff7" />
				<EditRowStyle BackColor="#2461bf" />
				<AlternatingRowStyle BackColor="#ffffff" />
			</asp:GridView>

		</ContentTemplate>
		
	</asp:UpdatePanel>
	<center>
		<asp:Panel ID="pnl_guardar" runat="server" Style="width: 100%;">
			<table bgcolor="Gray" style="width: 100%">
				<tr>
					<td align="center" colspan="2" style="text-align: left;">
						<asp:ImageButton ID="bt_generar" runat="server" ImageUrl="~/imagenes/sistema/gif/grabar-small.png"
							Enabled="true" Style="background-color: #ffffff;" OnClick="bt_generar_Click" />
					</td>
				</tr>
			</table>
		</asp:Panel>
	</center>
</asp:Content>