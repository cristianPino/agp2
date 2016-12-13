<%@ Page Title="Control de Operaciones AGP S.A." Language="C#" MasterPageFile="~/AGP.Master"
	AutoEventWireup="true" CodeBehind="estado_gestion_control.aspx.cs" Inherits="sistemaAGP.estado_gestion_control" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMenu" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoCentral" runat="server">
	<table align="left" style="width: 100%; height: 443px">
		<tr>
			<td class="style4" style="height: 74px; width: 1026px;" valign="top">
				<table style="width: 750px; height: 32px;" bgcolor="#507CD1">
					<tr>
						<td style="width: 38px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;
							height: 28px; color: #FFFFFF;">
							<b>Cliente</b>
						</td>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 28px; width: 132px;">
							<b>
								<asp:DropDownList ID="dl_cliente" runat="server" Font-Names="Arial" Font-Size="X-Small"
									Height="16px" Width="138px" TabIndex="1" Style="font-family: Arial, Helvetica, sans-serif;
									font-size: x-small; color: #000000;" AutoPostBack="True" OnSelectedIndexChanged="dl_cliente_SelectedIndexChanged">
								</asp:DropDownList>
							</b>
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
						<td style="width: 63px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;
							height: 28px; color: #FFFFFF;">
							<b>Producto</b>
						</td>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 28px; width: 88px;">
							<b>
								<asp:DropDownList ID="dl_producto" runat="server" Font-Names="Arial" Font-Size="X-Small"
									Height="16px" Width="138px" TabIndex="17" Style="font-family: Arial, Helvetica, sans-serif;
									font-size: x-small; color: #000000;" OnSelectedIndexChanged="dl_producto_SelectedIndexChanged" 
                                AutoPostBack="True">
								</asp:DropDownList>
							</b>
						</td>
						
					</tr>
					<tr>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #FFFFFF;
							font-weight: 700;">
							Rut deudor
						</td>
						<td style="width: 132px">
							<asp:TextBox ID="txt_rut" runat="server" Style="font-family: Arial, Helvetica, sans-serif;
								font-size: x-small" MaxLength="8" Width="136px"></asp:TextBox>
							<cc1:FilteredTextBoxExtender ID="txt_rutFilteredTextBoxExtender1" runat="server"
								TargetControlID="txt_rut" FilterType="Custom, Numbers" ValidChars="">
							</cc1:FilteredTextBoxExtender>
						</td>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #FFFFFF;
							font-weight: 700;">
							Nº Operacion</td>
						<td>
							<asp:TextBox ID="txt_cliente" runat="server" Style="font-family: Arial, Helvetica, sans-serif;
								font-size: x-small" Width="133px"></asp:TextBox>
						</td>
						<td style="width: 92px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;
							height: 28px; color: #FFFFFF;">
							<b>Nº AGP</b>
						</td>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 28px; width: 88px;">
							<b>
								<asp:TextBox ID="txt_operacion" runat="server" Width="104px" Style="font-family: Arial, Helvetica, sans-serif;
									font-size: x-small; color: #FFFFFF;" BackColor="#3399FF" ForeColor="White" TabIndex="3"></asp:TextBox>
								<cc1:FilteredTextBoxExtender ID="txt_operacion_FilteredTextBoxExtender" runat="server"
									TargetControlID="txt_operacion" FilterType="Custom, Numbers" ValidChars="">
								</cc1:FilteredTextBoxExtender>
							</b>
						</td>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #FFFFFF">
							<asp:CheckBox ID="chk_llamada" runat="server" Text="Llamadas Programadas" 
								oncheckedchanged="chk_llamada_CheckedChanged" />
						</td>
					</tr>
				
					<tr>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #FFFFFF">
							<b>Desde </b>
						</td>
						<td style="width: 132px">
							<asp:TextBox ID="txt_desde" runat="server" Style="font-family: Arial, Helvetica, sans-serif;
								font-size: x-small" Height="19px" Width="73px" TabIndex="2"></asp:TextBox>
							<asp:ImageButton ID="ib_desde" runat="server" ImageUrl="../imagenes/sistema/gif/calendario.gif"
								Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" />
							<cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_desde"
								CssClass="FondoAplicacion" Format="dd/MM/yyyy" PopupButtonID="ib_desde" />
						</td>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #FFFFFF;
							font-weight: 700">
							Hasta
						</td>
						<td style="width: 101px">
							<asp:TextBox ID="txt_hasta" runat="server" Style="font-family: Arial, Helvetica, sans-serif;
								font-size: x-small" Height="19px" Width="73px" TabIndex="2"></asp:TextBox>
							<asp:ImageButton ID="ib_hasta" runat="server" ImageUrl="../imagenes/sistema/gif/calendario.gif"
								Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" />
							<cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txt_hasta"
								CssClass="FondoAplicacion" Format="dd/MM/yyyy" PopupButtonID="ib_hasta" />
						</td>
						<td style="text-align: center" align="center" valign="middle">
							<asp:ImageButton ID="ib_buscar" runat="server" ImageUrl="../imagenes/sistema/gif/lupa.gif"
								Height="21px" Width="30px" OnClick="ib_buscar_Click" Style="text-align: center" />
							<asp:ImageButton ID="ib_report" runat="server" ImageUrl="~/imagenes/sistema/impresoras/impresora.gif"
								Height="22px" Width="23px" Visible="false" onclick="ib_report_Click" />
						</td>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 88px;" 
                            class="style5">
							<asp:Label ID="lbl_flujo" runat="server" Style="color: #FFFFFF; text-align: right;"
								Text="Flujo de Trabajo" Visible="False"></asp:Label>
							<td style="text-align: left;">
								<asp:DropDownList ID="dpl_estado" runat="server" Font-Names="Arial" Font-Size="X-Small"
									Height="16px" OnSelectedIndexChanged="dl_estado_SelectedIndexChanged" Width="157px"
									Visible="False">
								</asp:DropDownList>
							</td>
					</tr>
				</table>
				<center>
					<table style="width: 800px; height: 264px;" align="left">
						<tr>
							<td style="width: 123px;" valign="top">
								<asp:UpdatePanel ID="UpdatePanel2" runat="server">
									<ContentTemplate>
										<asp:Timer ID="Timer1" runat="server" Enabled="False" ontick="Timer1_Tick">
                                        </asp:Timer>
										<asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" CellPadding="4"
											Font-Names="Arial" Font-Size="X-Small" ForeColor="#333333" DataKeyNames="tipo_operacion,Cliente"
											GridLines="None" Width="898px" Height="50px" OnSelectedIndexChanged="gr_dato_SelectedIndexChanged" 
											EnableModelValidation="True">
											<RowStyle BackColor="#EFF3FB" />
											<Columns>
												<asp:HyperLinkField AccessibleHeaderText="id_solicitud" DataNavigateUrlFormatString="id_solicitud"
													DataTextField="id_solicitud" HeaderText="NºAGP" Text="id_solicitud">
													<ItemStyle ForeColor="#00CC00" />
												</asp:HyperLinkField>
												<asp:BoundField AccessibleHeaderText="Cliente" DataField="Cliente" Visible="False" />
												<asp:BoundField AccessibleHeaderText="Cliente" DataField="Cliente_nombre" HeaderText="Cliente" />
												<asp:BoundField AccessibleHeaderText="operacion" DataField="operacion"
													HeaderText="Operacion" />
												<asp:BoundField AccessibleHeaderText="tipo_operacion" 
                                                    DataField="tipo_operacion" HeaderText="Tipo operacion" 
                                                    InsertVisible="False" Visible="False" />
                                                <asp:BoundField AccessibleHeaderText="NºOperacion" DataField="numero_operacion" 
                                                    HeaderText="NºOperacion" />
												<asp:BoundField AccessibleHeaderText="rut_dedudor" DataField="rut_deudor"
													HeaderText="Rut Deudor" />
												<asp:BoundField AccessibleHeaderText="deudor" DataField="nombre_deudor" 
                                                    HeaderText="Nombre Deudor" />
												<asp:BoundField AccessibleHeaderText="Producto Cliente" DataField="id_producto_cliente" 
                                                    HeaderText="Producto Cliente" />
												<asp:BoundField AccessibleHeaderText="Forma Pago" DataField="descripcion" 
                                                    FooterText="Forma Pago" HeaderText="Forma Pago" />
												<asp:BoundField AccessibleHeaderText="Fecha Otorgamiento" DataField="fecha" 
                                                    FooterText="Fecha Otorgamiento" HeaderText="Fecha Otorgamiento"  />
												<asp:BoundField AccessibleHeaderText="cuenta_regresiva" 
													DataField="cuenta_regresiva" FooterText="Cuenta regresiva" 
													HeaderText="Cuenta regresiva" />
												<asp:BoundField AccessibleHeaderText="Total_gestion" FooterText="Total_gestion" HeaderText="Total Otorgado"
													DataField="total_gestion" />
												<asp:BoundField AccessibleHeaderText="Nº Cuotas" 
                                                    DataField="numero_cuotas" HeaderText="Nº Cuotas" />
												<asp:BoundField AccessibleHeaderText="monto_final" DataField="monto_final" FooterText="monto_final" HeaderText="monto_final" />
												<asp:BoundField AccessibleHeaderText="patente" DataField="patente" HeaderText="patente" />
												<asp:BoundField AccessibleHeaderText="ultimo" DataField="ultimo_estado" HeaderText="Estado Actual" />
												<asp:BoundField AccessibleHeaderText="llamada programada" 
                                                    DataField="llamada_programada" HeaderText="llamada programada" />
												<asp:TemplateField AccessibleHeaderText="Workflow" HeaderText="Workflow" ShowHeader="False">
													<ItemTemplate>
														<itemtemplate>
                                            <asp:ImageButton ID="ib_workflow" runat="server" ImageUrl="../imagenes/sistema/static/Herramienta.png"  />
                            
                                        </itemtemplate>
													</ItemTemplate>
													<EditItemTemplate>
														<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
													</EditItemTemplate>
													<ControlStyle Height="25px" Width="25px" />
												</asp:TemplateField>
												  <asp:TemplateField AccessibleHeaderText="Cargar" HeaderText="Cargar">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="ib_cargar" runat="server" 
                                                                    ImageUrl="../imagenes/sistema/static/carpeta.gif" />
                                                    </ItemTemplate>
                                                    <ControlStyle Height="25px" Width="25px" />
                                                </asp:TemplateField>
												<asp:TemplateField AccessibleHeaderText="C.Digital" HeaderText="C.Digital">
													<EditItemTemplate>
														<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
													</EditItemTemplate>
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