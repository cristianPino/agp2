<%@ Page Title="" Language="C#" MasterPageFile="~/AGP.Master" AutoEventWireup="true" CodeBehind="control_operaciones_peru_adv.aspx.cs" Inherits="sistemaAGP.control_operaciones_peru_adv" Culture="es-PE" UICulture="es-PE" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMenu" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoCentral" runat="server">
	<table align="left" style="width: 55%; height: 440px">
		<tr>
			<td class="style4" style="height: 74px" valign="top">
				<table style="width: 100%; height: 32px;" bgcolor="#507CD1">
					<tr>
						<td style="width: 38px; font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 28px; color: #FFFFFF;">
							<b>Cliente</b>
						</td>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 28px;">
							<b>
								<asp:DropDownList ID="dl_cliente" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="138px" TabIndex="1" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #000000;" AutoPostBack="True" OnSelectedIndexChanged="dl_cliente_SelectedIndexChanged">
								</asp:DropDownList>
							</b>
						</td>
						<td style="width: 64px; font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 28px; color: #FFFFFF;">
							<b>Sucursal</b>
						</td>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 28px;">
							<b>
								<asp:DropDownList ID="dl_sucursal" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="138px" TabIndex="17" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #000000;">
								</asp:DropDownList>
							</b>
						</td>
						<td style="width: 92px; font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 28px; color: #FFFFFF;">
							<b>Nº Operacion</b>
						</td>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 28px;">
							<b>
								<asp:TextBox ID="txt_operacion" runat="server" Width="104px" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #FFFFFF;" BackColor="#3399FF" ForeColor="White" TabIndex="3"></asp:TextBox>
								<cc1:FilteredTextBoxExtender ID="txt_operacion_FilteredTextBoxExtender" runat="server" TargetControlID="txt_operacion" FilterType="Custom, Numbers" ValidChars="">
								</cc1:FilteredTextBoxExtender>
							</b>
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
							<b>Nº Factura</b>
						</td>
						<td>
							<asp:TextBox ID="txt_factura" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" MaxLength="20" Width="135px"></asp:TextBox>
							<%--<cc1:FilteredTextBoxExtender ID="txt_facturaFilteredTextBoxExtender1" runat="server" TargetControlID="txt_factura" FilterType="Custom, Numbers" ValidChars="">
							</cc1:FilteredTextBoxExtender>--%>
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
						<td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 28px; color: #FFFFFF;">
							<b>Familia AGP</b>
						</td>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 28px; width: 190px;">
							<b>
								<asp:DropDownList ID="dl_familia" runat="server" Font-Names="Arial" 
								Font-Size="X-Small" Height="16px" Width="147px" TabIndex="1" 
								Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #000000;" 
								AutoPostBack="True" OnSelectedIndexChanged="dl_cliente_SelectedIndexChanged">
								</asp:DropDownList>
							</b>
						</td>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #FFFFFF">
							<b>Desde </b>
						</td>
						<td>
							<asp:TextBox ID="txt_desde" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" Height="19px" Width="73px" TabIndex="2"></asp:TextBox>
							<asp:ImageButton ID="ib_desde" runat="server" ImageUrl="../imagenes/sistema/gif/calendario.gif" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" />
							<cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_desde" CssClass="FondoAplicacion" Format="dd/MM/yyyy" PopupButtonID="ib_desde" />
						</td>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #FFFFFF; font-weight: 700">
							Hasta
						</td>
						<td>
							<asp:TextBox ID="txt_hasta" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" Height="19px" Width="73px" TabIndex="2"></asp:TextBox>
							<asp:ImageButton ID="ib_hasta" runat="server" ImageUrl="../imagenes/sistema/gif/calendario.gif" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" />
							<cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txt_hasta" CssClass="FondoAplicacion" Format="dd/MM/yyyy" PopupButtonID="ib_hasta" />
						</td>
						<td style="text-align: center" align="center" valign="middle">
							<asp:ImageButton ID="ib_buscar" runat="server" ImageUrl="../imagenes/sistema/gif/lupa.gif" Height="21px" Width="30px" OnClick="ib_buscar_Click" Style="text-align: center" />
						</td>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;" class="style5">
							<asp:Label ID="lbl_flujo" runat="server" Style="color: #FFFFFF; text-align: right;" Text="Flujo de Trabajo" Visible="False"></asp:Label>
							<td style="text-align: right;">
								<asp:DropDownList ID="dpl_estado" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="157px" Visible="False">
								</asp:DropDownList>
							</td>
					</tr>
				</table>
				<center>
					<table style="width: 100%; height: 264px;">
						<tr>
							<td style="width: 123px;" valign="top">
								<asp:UpdatePanel ID="UpdatePanel2" runat="server">
									<ContentTemplate>
										<asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Names="Arial" Font-Size="X-Small" ForeColor="#333333" DataKeyNames="tipo_operacion,cliente" GridLines="None" Width="898px" Height="50px" EnableModelValidation="True" OnRowDataBound="gr_dato_RowDataBound">
											<RowStyle BackColor="#EFF3FB" />
											<Columns>
												<asp:HyperLinkField AccessibleHeaderText="id_solicitud" DataNavigateUrlFormatString="id_solicitud" DataTextField="id_solicitud" HeaderText="Operacion" Text="id_solicitud">
													<ItemStyle ForeColor="#00CC00" />
												</asp:HyperLinkField>
												<asp:BoundField AccessibleHeaderText="Cliente" DataField="Cliente" Visible="False" />
												<asp:BoundField AccessibleHeaderText="Cliente" DataField="nombre_cliente" HeaderText="Cliente" />
												<asp:BoundField AccessibleHeaderText="tipo_operacion" DataField="operacion" HeaderText="Tipo operacion" />
												<asp:BoundField AccessibleHeaderText="Nº Factura" DataField="numero_factura" HeaderText="Nº Factura" />
												<asp:BoundField AccessibleHeaderText="Patente" DataField="Patente" HeaderText="Patente" />
												<asp:BoundField AccessibleHeaderText="numero_cliente" DataField="numero_cliente" HeaderText="Numero Cliente" />
												<asp:BoundField AccessibleHeaderText="Adquiriente" DataField="rut_persona" HeaderText="Adquiriente" />
												<asp:BoundField AccessibleHeaderText="Nombre" DataField="nombre_persona" />
												<asp:BoundField AccessibleHeaderText="Gastos" FooterText="Gastos" HeaderText="Gastos" DataField="total_gasto" />
												<asp:BoundField AccessibleHeaderText="Saldo" DataField="saldo" FooterText="Saldo" HeaderText="Saldo" />
												<asp:BoundField AccessibleHeaderText="ultimo" DataField="ultimo_estado" HeaderText="Estado Actual" />
												<asp:TemplateField HeaderText="Comp. gastos" ShowHeader="False">
													<ItemTemplate>
														<asp:ImageButton ID="ib_comGastos" runat="server" ImageUrl="../imagenes/sistema/impresoras/impresora.gif" Text="comprobante gastos" />
													</ItemTemplate>
													<ControlStyle Height="25px" Width="25px" />
												</asp:TemplateField>
												<asp:TemplateField AccessibleHeaderText="Workflow" HeaderText="Workflow" ShowHeader="False">
													<ItemTemplate>
														<asp:ImageButton ID="ib_workflow" runat="server" ImageUrl="../imagenes/sistema/static/Herramienta.png" />
													</ItemTemplate>
													<ControlStyle Height="25px" Width="25px" />
												</asp:TemplateField>
												<asp:TemplateField AccessibleHeaderText="C.Digital" HeaderText="C.Digital">
													<ItemTemplate>
														<asp:ImageButton ID="ib_cdigital" runat="server" ImageUrl="../imagenes/sistema/static/carpetas.gif" />
													</ItemTemplate>
													<ControlStyle Height="25px" Width="25px" />
												</asp:TemplateField>
											</Columns>
											<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
											<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
											<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
											<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
											<EditRowStyle BackColor="#2461BF" />
											<AlternatingRowStyle BackColor="White" />
										</asp:GridView>
									</ContentTemplate>
								</asp:UpdatePanel>
							</td>
						</tr>
					</table>
				</center>
			</td>
		</tr>
	</table>
</asp:Content>