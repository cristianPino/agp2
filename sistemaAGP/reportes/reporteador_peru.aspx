<%@ Page Title="Control de Operaciones AGP S.A." Language="C#" MasterPageFile="~/AGP.Master" AutoEventWireup="true" CodeBehind="reporteador_peru.aspx.cs" Inherits="sistemaAGP.reporteador_peru" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMenu" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoCentral" runat="server">
	<table align="left" style="width: 55%; height: 440px">
		<tr>
			<td class="style4" style="height: 74px" valign="top">
				<table style="width: 100%; height: 32px;" bgcolor="#507CD1">
					<tr>
						<td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;
							height: 28px; color: #FFFFFF;">
							<b>Familia AGP</b>
						</td>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 28px;
							width: 190px;">
							<b>
								<asp:DropDownList ID="dl_familia" runat="server" Font-Names="Arial" Font-Size="X-Small"
									Height="16px" Width="182px" TabIndex="1" Style="font-family: Arial, Helvetica, sans-serif;
									font-size: x-small; color: #000000;" AutoPostBack="True" OnSelectedIndexChanged="dl_familia_SelectedIndexChanged">
								</asp:DropDownList>
							</b>
						</td>
						
						
						
						<td style="width: 63px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;
							height: 28px; color: #FFFFFF;">
							<b>Producto</b>
						</td>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 28px;">
							<b>
								<asp:DropDownList ID="dl_producto" runat="server" Font-Names="Arial" Font-Size="X-Small"
									Height="16px" Width="138px" TabIndex="17" Style="font-family: Arial, Helvetica, sans-serif;
									font-size: x-small; color: #000000;" OnSelectedIndexChanged="dl_producto_SelectedIndexChanged">
								</asp:DropDownList>
							</b>
						</td>
						
						
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 28px; color: #FFFFFF;">
							<b>Cliente</b>
						</td>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 28px; width: 84px;">
							<b>
								<asp:DropDownList ID="dl_cliente" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="138px" TabIndex="1" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #000000;" AutoPostBack="True" OnSelectedIndexChanged="dl_cliente_SelectedIndexChanged">
								</asp:DropDownList>
							</b>
						</td>
						<td class="style1" style="width: 57px; font-family: Arial, Helvetica, sans-serif; font-size: x-small; font-weight: bold; height: 28px; color: #FFFFFF;">
							Region
						</td>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 28px;">
							<b>
								<asp:DropDownList ID="dl_region" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="138px" TabIndex="17" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #000000;" AutoPostBack="True" OnSelectedIndexChanged="dl_Region_SelectedIndexChanged">
								</asp:DropDownList>
							</b>
						</td>
						<td style="width: 64px; font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 28px; color: #FFFFFF;">
							<b>Ciudad</b>
						</td>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 28px;">
							<b>
								<asp:DropDownList ID="dl_ciudad" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="138px" TabIndex="17" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #000000;" AutoPostBack="True" OnSelectedIndexChanged="dl_ciudad_SelectedIndexChanged">
								</asp:DropDownList>
							</b>
						</td>
						
						
						<td style="width: 64px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;height: 28px; color: #FFFFFF;">
							<asp:CheckBox ID="chk_dua" runat="server" Text="DUA" 
								oncheckedchanged="chk_dua_CheckedChanged" />
							
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
							<asp:TextBox ID="txt_factura" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" MaxLength="8" Width="135px"></asp:TextBox>
							<cc1:FilteredTextBoxExtender ID="txt_facturaFilteredTextBoxExtender1" runat="server" TargetControlID="txt_factura" FilterType="Custom, Numbers" ValidChars="">
							</cc1:FilteredTextBoxExtender>
						</td>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #FFFFFF; font-weight: 700;">
							Nº Cliente
						</td>
						<td style="width: 95px">
							<asp:TextBox ID="txt_cliente" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" Width="133px"></asp:TextBox>
						</td>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #FFFFFF; font-weight: 700; ">
							Patente
						</td>
						<td style="width: 84px">
							<asp:TextBox ID="txt_patente" runat="server" MaxLength="6" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" Width="82px"></asp:TextBox>
						</td>
						<td style="width: 64px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;
							height: 28px; color: #FFFFFF;">
							<b>Sucursal</b>
						</td>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 28px;">
							<b>
								<asp:DropDownList ID="dl_sucursal" runat="server" Font-Names="Arial" Font-Size="X-Small"
									Height="16px" Width="138px" TabIndex="17" Style="font-family: Arial, Helvetica, sans-serif;
									font-size: x-small; color: #000000;">
								</asp:DropDownList>
							</b>
						</td>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #FFFFFF;
							font-weight: 700;">
							Ejecutivo
						</td>
						<td style="width: 84px">
							<asp:TextBox ID="txt_ejec" runat="server" MaxLength="100" Style="font-family: Arial, Helvetica, sans-serif;
								font-size: x-small" Width="82px"></asp:TextBox>
						</td>
					</tr>
					<tr>
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
						
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 95px;" 
							class="style5">
							<asp:Label ID="lbl_flujo" runat="server" Style="color: #FFFFFF; text-align: right;" Text="Flujo de Trabajo" Visible="False"></asp:Label>
						</td>
						<td style="text-align: right; ">
							<asp:DropDownList ID="dpl_estado" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" OnSelectedIndexChanged="dl_estado_SelectedIndexChanged" Width="157px" Visible="False">
							</asp:DropDownList>
						</td>
						<td style="width: 92px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;
							height: 28px; color: #FFFFFF;">
							<b>Nº Operacion</b>
						</td>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 28px;
							width: 95px;">
							<b>
								<asp:TextBox ID="txt_operacion" runat="server" Width="104px" Style="font-family: Arial, Helvetica, sans-serif;
									font-size: x-small; color: #FFFFFF;" BackColor="#3399FF" ForeColor="White" TabIndex="3"></asp:TextBox>
							</b>
						</td>
						
						<td style="width: 64px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;height: 28px; color: #FFFFFF;">
							Marca
						</td>
						<td>
							<asp:DropDownList ID="ddlVehMarca" runat="server" Font-Names="Arial" Font-Size="X-Small"
								Height="16px" Width="150px" Style="font-family: Arial, Helvetica, sans-serif;
								font-size: x-small">
							</asp:DropDownList>
						</td>
					</tr>
				</table>
				<center>
					<table style="width: 100%; height: 264px;">
						<tr>
							<td style="width: 123px;" valign="top">
								<%--<asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Names="Verdana" Font-Size="X-Small" ForeColor="#333333" GridLines="None" DataKeyNames="id_informe,nombre" Style="margin-right: 2px" OnRowCommand="gr_dato_RowCommand">
									<RowStyle BackColor="#EFF3FB" />
									<Columns>
										<asp:BoundField AccessibleHeaderText="id_informe" DataField="id_informe" HeaderText="id_informe" Visible="False" />
										<asp:BoundField AccessibleHeaderText="nombre" DataField="nombre" HeaderText="nombre" Visible="False" />
										<asp:BoundField AccessibleHeaderText="descripcion" DataField="descripcion" HeaderText="Visor de Reportes" />
										<asp:TemplateField>
											<ItemTemplate>
												<asp:Button ID="btnHTML" runat="server" CommandName="html" CommandArgument='<%# Bind("nombre") %>' Text="HTML" Font-Size="X-Small" />
											</ItemTemplate>
										</asp:TemplateField>
										<asp:TemplateField>
											<ItemTemplate>
												<asp:Button ID="btnPDF" runat="server" CommandName="pdf" CommandArgument='<%# Bind("nombre") %>' Text="PDF" Font-Size="X-Small" />
											</ItemTemplate>
										</asp:TemplateField>
										<asp:TemplateField>
											<ItemTemplate>
												<asp:Button ID="btnExcel" runat="server" CommandName="xls" CommandArgument='<%# Bind("nombre") %>' Text="Excel" Font-Size="X-Small" />
											</ItemTemplate>
										</asp:TemplateField>
									</Columns>
									<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
									<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
									<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
									<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
									<EditRowStyle BackColor="#2461BF" />
									<AlternatingRowStyle BackColor="White" />
								</asp:GridView>--%>
								<asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Names="Verdana" Font-Size="X-Small" ForeColor="#333333" GridLines="None" DataKeyNames="id_informe,nombre" OnSelectedIndexChanged="gr_dato_SelectedIndexChanged" Style="margin-right: 2px">
									<RowStyle BackColor="#EFF3FB" />
									<Columns>
										<asp:BoundField AccessibleHeaderText="id_informe" DataField="id_informe" HeaderText="id_informe" Visible="False" />
										<asp:BoundField AccessibleHeaderText="nombre" DataField="nombre" HeaderText="nombre" Visible="False" />
										<asp:BoundField AccessibleHeaderText="descripcion" DataField="descripcion" HeaderText="Visor de Reportes" />
										<asp:CommandField ButtonType="Button" SelectText="Ver" ShowSelectButton="True">
											<ControlStyle Font-Size="X-Small" />
										</asp:CommandField>
									</Columns>
									<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
									<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
									<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
									<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
									<EditRowStyle BackColor="#2461BF" />
									<AlternatingRowStyle BackColor="White" />
								</asp:GridView>
							</td>
						</tr>
					</table>
				</center>
			</td>
		</tr>
	</table>
</asp:Content>