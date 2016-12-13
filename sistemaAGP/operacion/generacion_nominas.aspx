<%@ Page Title="" Language="C#" MasterPageFile="~/AGP.Master" AutoEventWireup="true" CodeBehind="generacion_nominas.aspx.cs" Inherits="sistemaAGP.generacion_nominas" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMenu" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoCentral" runat="server">
	<asp:UpdatePanel ID="up_filtros" runat="server" UpdateMode="Conditional">
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
							<asp:DropDownList ID="dl_tiponomina" runat="server" Width="200px" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
							</asp:DropDownList>
						</td>
					</tr>
					<tr>
						<td>
							Cliente
						</td>
						<td>
							<asp:DropDownList ID="dl_cliente" runat="server" Width="200px" AutoPostBack="true" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;" OnSelectedIndexChanged="dl_cliente_SelectedIndexChanged">
							</asp:DropDownList>
						</td>
						<td>
							Sucursal
						</td>
						<td>
							<asp:DropDownList ID="dl_sucursal" runat="server" Width="150px" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
							</asp:DropDownList>
						</td>
					</tr>
					<tr>
						<td>
							Fecha Desde
						</td>
						<td>
							<asp:TextBox ID="txt_desde" runat="server" Width="70px" Enabled="false" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;"></asp:TextBox>
							<asp:ImageButton ID="bt_desde" runat="server" ImageUrl="~/imagenes/sistema/gif/calendario.gif" />
							<ajaxToolkit:CalendarExtender ID="cal_desde" runat="server" TargetControlID="txt_desde" CssClass="calendario" Format="dd/MM/yyyy" PopupButtonID="bt_desde" />
						</td>
						<td>
							Fecha Hasta
						</td>
						<td>
							<asp:TextBox ID="txt_hasta" runat="server" Width="70px" Enabled="false" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;"></asp:TextBox>
							<asp:ImageButton ID="bt_hasta" runat="server" ImageUrl="~/imagenes/sistema/gif/calendario.gif" />
							<ajaxToolkit:CalendarExtender ID="cal_hasta" runat="server" TargetControlID="txt_hasta" CssClass="calendario" Format="dd/MM/yyyy" PopupButtonID="bt_hasta" />
						</td>
					</tr>
                    <tr>
                    <td>
                        Nº Solicitud</td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server" Height="20px" Width="70px"></asp:TextBox>
                        </td>
                    </tr>
					<tr>
						<td>
							Observación
						</td>
						<td colspan="3">
							<asp:TextBox ID="txt_observaciones" runat="server" Width="450px" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;"></asp:TextBox>
						</td>
					</tr>
					<tr>
						<td colspan="2" style="text-align: center;">
							<asp:ImageButton ID="bt_buscar" runat="server" ImageUrl="~/imagenes/sistema/gif/lupa-small.png" CausesValidation="true" Style="background-color: #ffffff;" OnClick="bt_buscar_Click" />
						</td>
						<td colspan="2" style="text-align: center;">
							<asp:ImageButton ID="bt_generar" runat="server" ImageUrl="~/imagenes/sistema/gif/grabar-small.png" Enabled="false" Style="background-color: #ffffff;" OnClick="bt_generar_Click" />
						</td>
					</tr>
				</table>
			</asp:Panel>
		</ContentTemplate>
		<Triggers>
			<asp:AsyncPostBackTrigger ControlID="bt_buscar" />
			<asp:AsyncPostBackTrigger ControlID="bt_generar" />
		</Triggers>
	</asp:UpdatePanel>
	<asp:UpdatePanel ID="up_datos" runat="server" UpdateMode="Conditional">
		<ContentTemplate>
			<asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="id_solicitud,id_cliente,tipo_operacion" Font-Names="Arial" Font-Size="X-Small" ForeColor="#333333" GridLines="None" EnableModelValidation="True" Width="100%">
				<RowStyle BackColor="#eff3fb" />
				<Columns>
					<asp:HyperLinkField HeaderText="Operación" DataNavigateUrlFormatString="id_solicitud" DataTextField="id_solicitud">
						<ItemStyle ForeColor="#00cc00" Width="60px" />
					</asp:HyperLinkField>
					<asp:BoundField HeaderText="Cliente" DataField="nombre_cliente" />
					<asp:BoundField HeaderText="Producto" DataField="operacion" />
					<asp:BoundField HeaderText="Nº Factura" DataField="numero_factura" />
					<asp:BoundField HeaderText="Patente" DataField="patente" />
					<asp:BoundField HeaderText="Adquirente" DataField="rut_persona" />
					<asp:BoundField DataField="nombre_persona" />
					<asp:BoundField HeaderText="Estado Actual" DataField="ultimo_estado" />
					<asp:TemplateField HeaderText="Seleccionar">
						<ItemTemplate>
							<asp:CheckBox ID="chk" runat="server" />
						</ItemTemplate>
						<ItemStyle HorizontalAlign="Center" />
						<HeaderTemplate>
							<asp:Label ID="lbl_seleccionar" runat="server" Text="Seleccionar"></asp:Label><br />
							<asp:CheckBox ID="checkall" runat="server" Text="" AutoPostBack="true" OnCheckedChanged="chk_checkall_CheckedChanged" />
						</HeaderTemplate>
					</asp:TemplateField>
				</Columns>
				<FooterStyle BackColor="#507cd1" Font-Bold="True" ForeColor="#ffffff" />
				<PagerStyle BackColor="#2461bf" ForeColor="#ffffff" HorizontalAlign="Center" />
				<SelectedRowStyle BackColor="#d1ddf1" Font-Bold="True" ForeColor="#333333" />
				<HeaderStyle BackColor="#507cd1" Font-Bold="True" ForeColor="#ffffff" />
				<EditRowStyle BackColor="#2461bf" />
				<AlternatingRowStyle BackColor="#ffffff" />
			</asp:GridView>
		</ContentTemplate>
		<Triggers>
			<asp:AsyncPostBackTrigger ControlID="bt_buscar" />
			<asp:AsyncPostBackTrigger ControlID="bt_generar" />
		</Triggers>
	</asp:UpdatePanel>
</asp:Content>