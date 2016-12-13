<%@ Page Title="" Language="C#" MasterPageFile="~/AGP.Master" AutoEventWireup="true" CodeBehind="autorizar_alz_garantias.aspx.cs" Inherits="sistemaAGP.autorizar_alz_garantias" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMenu" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoCentral" runat="server">
	<asp:UpdatePanel ID="upFiltros" runat="server">
		<ContentTemplate>
			<table style="width: 100%; background-color: #507cd1;">
				<tr>
					<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #ffffff;">
						<strong>Cliente</strong>
					</td>
					<td>
						<asp:DropDownList ID="dl_cliente" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="250px" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #000000;" AutoPostBack="True" OnSelectedIndexChanged="dl_cliente_SelectedIndexChanged">
						</asp:DropDownList>
					</td>
					<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #ffffff;">
						<strong>Modulo</strong>
					</td>
					<td>
						<asp:DropDownList ID="dl_modulo" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="138px" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #000000;">
						</asp:DropDownList>
					</td>
					<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #ffffff;">
						<strong>Sucursal</strong>
					</td>
					<td>
						<asp:DropDownList ID="dl_sucursal" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="138px" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #000000;">
						</asp:DropDownList>
					</td>
				</tr>
				<tr>
					<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #ffffff;">
						<strong>Desde</strong>
					</td>
					<td>
						<asp:TextBox ID="txt_desde" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" Height="16px" Width="73px"></asp:TextBox>
						<asp:ImageButton ID="ib_desde" runat="server" ImageUrl="../imagenes/sistema/gif/calendario.gif" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" />
						<ajaxToolkit:CalendarExtender ID="cal_desde" runat="server" TargetControlID="txt_desde" CssClass="calendario" Format="dd/MM/yyyy" PopupButtonID="ib_desde" TodaysDateFormat="dd/MM/yyyy" OnClientDateSelectionChanged="checkDate" />
					</td>
					<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #ffffff;">
						<strong>Hasta</strong>
					</td>
					<td>
						<asp:TextBox ID="txt_hasta" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" Height="16px" Width="73px"></asp:TextBox>
						<asp:ImageButton ID="ib_hasta" runat="server" ImageUrl="../imagenes/sistema/gif/calendario.gif" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" />
						<ajaxToolkit:CalendarExtender ID="cal_hasta" runat="server" TargetControlID="txt_hasta" CssClass="calendario" Format="dd/MM/yyyy" PopupButtonID="ib_hasta" TodaysDateFormat="dd/MM/yyyy" OnClientDateSelectionChanged="checkDate" />
					</td>
					<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #ffffff;">
						<strong>Nº Operacion</strong>
					</td>
					<td>
						<asp:TextBox ID="txt_operacion" runat="server" Width="80px" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #FFFFFF;" BackColor="#3399ff" ForeColor="White"></asp:TextBox>
						<ajaxToolkit:FilteredTextBoxExtender ID="fte_operacion" runat="server" TargetControlID="txt_operacion" FilterType="Custom, Numbers" ValidChars="">
						</ajaxToolkit:FilteredTextBoxExtender>
					</td>
				</tr>
				<tr>
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
					<td colspan="2">
						<table style="width: 100%;">
							<tr>
								<td style="text-align: center;">
									<asp:ImageButton ID="ib_buscar" runat="server" ImageUrl="../imagenes/sistema/gif/lupa.gif" Height="30px" Width="30px" OnClick="ib_buscar_Click" Style="text-align: center" />
								</td>
								<td style="text-align: center;">
									<asp:ImageButton ID="ib_autorizar" runat="server" ImageUrl="../imagenes/sistema/static/ok.png" Height="30px" Width="30px" Style="text-align: center" OnClick="ib_autorizar_Click" />
								</td>
							</tr>
						</table>	
					</td>
				</tr>
			</table>
			<ajaxToolkit:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" ConfirmText="¿Está seguro de autorizar estos alzamientos?" TargetControlID="ib_autorizar">
			</ajaxToolkit:ConfirmButtonExtender>
		</ContentTemplate>
	</asp:UpdatePanel>
	<asp:UpdatePanel ID="upDatos" runat="server">
		<ContentTemplate>
			<asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" DataKeyNames="id_solicitud,id_cliente,tipo_producto" CellPadding="4" Font-Names="Arial" Font-Size="X-Small" ForeColor="#333333" GridLines="Both" Width="100%" EnableModelValidation="True">
				<Columns>
					<asp:TemplateField AccessibleHeaderText="id_solicitud" HeaderText="Operacion">
						<ItemTemplate>
							<asp:HyperLink ID="hlk_solicitud" runat="server" NavigateUrl='<%# Eval("url") %>' Text='<%# Eval("id_solicitud", "{0:N0}") %>' CssClass="hyperlink"></asp:HyperLink>
						</ItemTemplate>
						<HeaderStyle HorizontalAlign="Center" />
						<ItemStyle HorizontalAlign="Center" />
					</asp:TemplateField>
					<asp:BoundField AccessibleHeaderText="Cliente" DataField="nombre_cliente" HeaderText="Cliente"  />
					<asp:BoundField AccessibleHeaderText="Patente" DataField="Patente" HeaderText="Patente" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="60px" >
					<ItemStyle HorizontalAlign="Center" Width="60px" />
					</asp:BoundField>
					<asp:BoundField DataField="rut" HeaderText="Rut Consignatario" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="80px" >
					<ItemStyle HorizontalAlign="Right" Width="80px" />
					</asp:BoundField>
					<asp:BoundField DataField="nombre" HeaderText="Nombre Consignatario"/>
					<asp:BoundField DataField="fecha_ultimo" HeaderText="Fec.Últ. Cheque" ItemStyle-Width="60px" DataFormatString="{0:dd/MM/yyyy}" >
					<ItemStyle Width="60px" />
					</asp:BoundField>
					<asp:TemplateField >
						<HeaderTemplate>
							<asp:CheckBox ID="checkall" runat="server" AutoPostBack="True" OnCheckedChanged="Check_Clicked" Text="Autorizar" TextAlign="Left" />
						</HeaderTemplate>
						<ItemTemplate>
							<asp:CheckBox ID="chk" runat="server" EnableViewState="true" />
						</ItemTemplate>
						<HeaderStyle HorizontalAlign="Center" />
						<ItemStyle HorizontalAlign="Center" Width="60px" />
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