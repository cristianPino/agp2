<%@ Page Title="Control de Operaciones Ventas AGP S.A." Language="C#" MasterPageFile="~/AGP.Master"
	AutoEventWireup="true" CodeBehind="Control_Operacion_Ventas.aspx.cs" Inherits="sistemaAGP.Control_Operacion_Ventas" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMenu" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoCentral" runat="server">
	<table align="left" style="width: 55%; height: 440px">
		<tr>
			<td class="style4" style="height: 74px" valign="top">
				<table style="width: 100%; height: 32px;" bgcolor="#507CD1">
					<tr>
						<td style="width: 38px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;
							height: 28px; color: #FFFFFF;">
							<b>Cliente</b>
						</td>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 28px;">
							<b>
								<asp:DropDownList ID="dl_cliente" runat="server" Font-Names="Arial" Font-Size="X-Small"
									Height="16px" Width="138px" TabIndex="1" Style="font-family: Arial, Helvetica, sans-serif;
									font-size: x-small; color: #000000;" AutoPostBack="True" OnSelectedIndexChanged="dl_cliente_SelectedIndexChanged">
								</asp:DropDownList>
							</b>
						</td>
						<td class="style1" style="width: 57px; font-family: Arial, Helvetica, sans-serif;
							font-size: x-small; font-weight: bold; height: 28px; color: #FFFFFF;">
							Modulo
						</td>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 28px;">
							<b>
								<asp:DropDownList ID="dl_modulo" runat="server" Font-Names="Arial" Font-Size="X-Small"
									Height="16px" Width="138px" TabIndex="17" Style="font-family: Arial, Helvetica, sans-serif;
									font-size: x-small; color: #000000;" OnSelectedIndexChanged="dl_modulo_SelectedIndexChanged">
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
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 28px; width: 137px;">
							<b>
								<asp:DropDownList ID="dl_producto" runat="server" Font-Names="Arial" Font-Size="X-Small"
									Height="16px" Width="138px" TabIndex="17" Style="font-family: Arial, Helvetica, sans-serif;
									font-size: x-small; color: #000000;" OnSelectedIndexChanged="dl_producto_SelectedIndexChanged">
								</asp:DropDownList>
							</b>
						</td>
						
					</tr>
					<tr>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #FFFFFF;
							font-weight: 700;">
							Adquiriente
						</td>
						<td>
							<asp:TextBox ID="txt_rut" runat="server" Style="font-family: Arial, Helvetica, sans-serif;
								font-size: x-small" MaxLength="8" Width="136px"></asp:TextBox>
							<cc1:FilteredTextBoxExtender ID="txt_rutFilteredTextBoxExtender1" runat="server"
								TargetControlID="txt_rut" FilterType="Custom, Numbers" ValidChars="">
							</cc1:FilteredTextBoxExtender>
						</td>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #FFFFFF;
							font-weight: 700;">
							Nº Cliente
						</td>
						<td>
							<asp:TextBox ID="txt_cliente" runat="server" Style="font-family: Arial, Helvetica, sans-serif;
								font-size: x-small" Width="133px"></asp:TextBox>
						</td>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #FFFFFF;
							font-weight: 700;">
							Patente
						</td>
						<td>
							<asp:TextBox ID="txt_patente" runat="server" MaxLength="6" Style="font-family: Arial, Helvetica, sans-serif;
								font-size: x-small" Width="82px"></asp:TextBox>
						</td>
                        <td style="width: 92px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;
							height: 28px; color: #FFFFFF;">
							<b>Nº Operacion</b>
						</td>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 28px; width: 137px;">
							<b>
								<asp:TextBox ID="txt_operacion" runat="server" Width="104px" Style="font-family: Arial, Helvetica, sans-serif;
									font-size: x-small; color: #FFFFFF;" BackColor="#3399FF" ForeColor="White" TabIndex="3"></asp:TextBox>
								<cc1:FilteredTextBoxExtender ID="txt_operacion_FilteredTextBoxExtender" runat="server"
									TargetControlID="txt_operacion" FilterType="Custom, Numbers" ValidChars="">
								</cc1:FilteredTextBoxExtender>
							</b>
						</td>
					</tr>
					<tr>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #FFFFFF">
							<b>Desde </b>
						</td>
						<td>
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
						<td>
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
						</td>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;" class="style5">
							<asp:Label ID="lbl_flujo" runat="server" Style="color: #FFFFFF; text-align: right;"
								Text="Flujo de Trabajo" Visible="False"></asp:Label>
							<td style="text-align: right;">
								<asp:DropDownList ID="dpl_estado" runat="server" Font-Names="Arial" Font-Size="X-Small"
									Height="16px" OnSelectedIndexChanged="dl_estado_SelectedIndexChanged" Width="157px"
									Visible="False">
								</asp:DropDownList>
							</td>
							<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 137px;" 
							class="style5">
								<asp:Label ID="Label1" runat="server" Style="color: #FFFFFF; text-align: right;"
									Text="Tercero a Tercero" Visible="true"></asp:Label>
							
								<asp:ImageButton ID="ib_habilitar" runat="server" ImageUrl="../imagenes/sistema/gif/personas.gif"
									Height="21px" Width="30px"  Style="text-align: center" onclick="ib_habilitar_Click"  />
								
								
					</tr>
				</table>
				<center>
					<table style="width: 100%; height: 264px;">
						<tr>
							<td style="width: 123px;" valign="top">
								<asp:UpdatePanel ID="UpdatePanel2" runat="server">
									<ContentTemplate>
										<asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" CellPadding="4"
											Font-Names="Arial" Font-Size="X-Small" ForeColor="#333333" DataKeyNames="tipo_operacion,cliente,operacion"
											GridLines="None" Width="898px" Height="50px" OnSelectedIndexChanged="gr_dato_SelectedIndexChanged" 
                                            EnableModelValidation="True">
											<RowStyle BackColor="#EFF3FB" />
											<Columns>
												<asp:BoundField AccessibleHeaderText="Operacion" DataField="operacion" 
                                                    HeaderText="Operacion" Visible="true" />
												<asp:BoundField AccessibleHeaderText="tipo_operacion" 
                                                    DataField="tipo_operacion" FooterText="tipo_operacion" 
                                                    HeaderText="tipo_operacion" Visible="False" />
												<asp:BoundField AccessibleHeaderText="Cliente" DataField="Cliente" Visible="False" />
												<asp:BoundField AccessibleHeaderText="Cliente" DataField="Cliente_nombre" HeaderText="Cliente" />
												<asp:BoundField AccessibleHeaderText="Patente" DataField="Patente" HeaderText="Patente" />
												<asp:BoundField AccessibleHeaderText="Precio Venta" DataField="monto" 
                                                    HeaderText="Precio Venta" Visible="False" />
												<asp:BoundField AccessibleHeaderText="RUT Vendedor" DataField="rut_vendedor" 
                                                    HeaderText="RUT Vendedor" />
												<asp:BoundField AccessibleHeaderText="Vendedor" DataField="nombre_vendedor" 
                                                    HeaderText="Vendedor" />
												<asp:BoundField AccessibleHeaderText="ultimo" DataField="ultimo_estado" HeaderText="Estado Actual" />
												<asp:TemplateField HeaderText="C.Digital" AccessibleHeaderText="C.Digital">
													<ControlStyle Height="25px" Width="25px" />
													<ItemTemplate>
														<asp:ImageButton ID="ib_cdigital" runat="server" 
                                                            ImageUrl="../imagenes/sistema/static/carpetas.gif" />
													</ItemTemplate>
													<EditItemTemplate>
                                                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                                                    </EditItemTemplate>
													<ControlStyle Height="25px" Width="25px" />
												</asp:TemplateField>
                                                <asp:TemplateField HeaderText="Toma" ShowHeader="False">
												<ItemTemplate>
													<asp:ImageButton ID="ib_ventas" runat="server" ImageUrl="../imagenes/sistema/static/dinero.png" OnClick="Click_ventas" Text="Ventas" />
												</ItemTemplate>
												<ControlStyle Height="25px" Width="25px" />
											</asp:TemplateField>
												<asp:TemplateField>
													<ItemTemplate>
														<asp:CheckBox ID="chk" runat="server" AutoPostBack="true" EnableViewState="true"
															OnCheckedChanged="Check_Clicked_Grilla" />
													</ItemTemplate>
													<HeaderTemplate>
														<asp:CheckBox ID="checkall" runat="server" AutoPostBack="True" OnCheckedChanged="Check_Clicked" />
													</HeaderTemplate>
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