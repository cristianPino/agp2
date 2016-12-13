<%@ Page Title="Control de Operaciones AGP S.A." Language="C#" MasterPageFile="~/AGP.Master"
	AutoEventWireup="true" CodeBehind="control_operaciones_ejec.aspx.cs" Inherits="sistemaAGP.control_operaciones_ejec" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMenu" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoCentral" runat="server">

    <script type="text/javascript">
        function confirmarEliminar() {
            if (confirm("Desea eliminar la operacion seleccionada?") == true) {
                return true;
            } else {
                return false;
            }
        }
    </script>
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
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 28px;
							width: 51px;">
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
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 28px;">
							<b>
								<asp:DropDownList ID="dl_producto" runat="server" Font-Names="Arial" Font-Size="X-Small"
									Height="16px" Width="138px" TabIndex="17" Style="font-family: Arial, Helvetica, sans-serif;
									font-size: x-small; color: #000000;" AutoPostBack="True" OnSelectedIndexChanged="dl_producto_SelectedIndexChanged1">
								</asp:DropDownList>
							</b>
						</td>
						<td style="width: 92px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;
							height: 28px; color: #FFFFFF; text-align: right;">
							<b style="text-align: right">Nº Operacion</b>
						</td>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 28px;">
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
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #FFFFFF">
							<b>Nº Factura</b>
						</td>
						<td>
							<asp:TextBox ID="txt_factura" runat="server" Style="font-family: Arial, Helvetica, sans-serif;
								font-size: x-small" MaxLength="8" Width="135px"></asp:TextBox>
							<cc1:FilteredTextBoxExtender ID="txt_facturaFilteredTextBoxExtender1" runat="server"
								TargetControlID="txt_factura" FilterType="Custom, Numbers" ValidChars="">
							</cc1:FilteredTextBoxExtender>
						</td>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #FFFFFF;
							font-weight: 700;">
							Nº Cliente
						</td>
						<td style="width: 51px">
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
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #FFFFFF;
							height: 9px;">
							<b>Desde </b>
						</td>
						<td style="height: 9px">
							<asp:TextBox ID="txt_desde" runat="server" Style="font-family: Arial, Helvetica, sans-serif;
								font-size: x-small" Height="19px" Width="73px" TabIndex="2"></asp:TextBox>
							<asp:ImageButton ID="ib_desde" runat="server" ImageUrl="../imagenes/sistema/gif/calendario.gif"
								Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" />
							<cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_desde"
								CssClass="calendario" Format="dd/MM/yyyy" PopupButtonID="ib_desde" />
						</td>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #FFFFFF;
							font-weight: 700; height: 9px;">
							Hasta
						</td>
						<td style="height: 9px">
							<asp:TextBox ID="txt_hasta" runat="server" Style="font-family: Arial, Helvetica, sans-serif;
								font-size: x-small" Height="19px" Width="73px" TabIndex="2"></asp:TextBox>
							<asp:ImageButton ID="ib_hasta" runat="server" ImageUrl="../imagenes/sistema/gif/calendario.gif"
								Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" />
							<cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txt_hasta"
								CssClass="calendario" Format="dd/MM/yyyy" PopupButtonID="ib_hasta" />
						</td>
					</tr>
				</table>
				<table bgcolor="Gray">
					<tr>
						<td style="text-align: center; height: 9px;" align="center" valign="middle">
							<asp:ImageButton ID="ib_buscar" runat="server" ImageUrl="../imagenes/sistema/gif/lupa.gif"
								Height="21px" Width="30px" OnClick="ib_buscar_Click" Style="text-align: center" />
						</td>
						<td style="" valign="middle">
							<asp:CheckBox ID="chk_workflow" runat="server" Text=" Workflow" CssClass="style10"
								AutoPostBack="True" OnCheckedChanged="CheckBox1_CheckedChanged" Style="font-size: x-small;
								color: #FFFFFF; font-family: Arial, Helvetica, sans-serif" Visible="False" />
							<asp:CheckBox ID="chk_nomina" runat="server" Text=" Nomina" CssClass="style10" AutoPostBack="True"
								OnCheckedChanged="chk_nomina_CheckedChanged" Style="font-size: x-small; color: #FFFFFF;
								font-family: Arial, Helvetica, sans-serif" Visible="False" />
						</td>
						<td style="text-align: left; width: 51px; height: 9px;" align="center" valign="middle">
							<asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="exel" Font-Names="Arial"
								Font-Size="X-Small" Style="font-size: x-small; color: #FFFFFF; font-family: Arial, Helvetica, sans-serif" />
						</td>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;" class="style5">
							<asp:Label ID="lbl_flujo" runat="server" Style="color: #FFFFFF; text-align: right;"
								Text="Flujo de Trabajo" Visible="False"></asp:Label>
						</td>
						<td style="text-align: right;">
							<asp:DropDownList ID="dpl_estado" runat="server" Font-Names="Arial" Font-Size="X-Small"
								Height="16px" OnSelectedIndexChanged="dl_estado_SelectedIndexChanged" Width="157px"
								Visible="False">
							</asp:DropDownList>
						</td>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;" class="style5">
							<asp:Label ID="lbl_nomina" runat="server" Style="color: #FFFFFF; text-align: right;"
								Text="Nómina"></asp:Label>
						</td>
						<td>
							<asp:DropDownList ID="dpl_nomina" runat="server" Font-Names="Arial" Font-Size="X-Small"
								Height="16px" Width="157px">
							</asp:DropDownList>
						</td>
						<td>
							<asp:TextBox ID="txt_nomina" runat="server" Font-Names="Arial" Font-Size="X-Small"
								Width="87px" ontextchanged="txt_nomina_TextChanged"></asp:TextBox>
						</td>
						<td>
							<asp:ImageButton ID="btn_nomina_pdf" runat="server" ImageUrl="../imagenes/sistema/static/pdf.jpg"
								Height="24" Width="24" OnClick="btn_nomina_pdf_Click" />
						</td>
					</tr>
				</table>
			</td>
		</tr>
		<tr>
			<td>
				<center>
					<table style="width: 100%; height: 264px;">
						<tr>
							<td style="width: 123px;" valign="top">
								<asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" 
                                                    CellPadding="4" DataKeyNames="tipo_operacion,cliente" Font-Names="Arial" 
                                                    Font-Size="X-Small" ForeColor="#333333" GridLines="None" Height="50px" 
                                                    OnSelectedIndexChanged="gr_dato_SelectedIndexChanged" 
                                            Width="984px" onrowcommand="gr_dato_RowCommand">
                                            <RowStyle BackColor="#EFF3FB" />
                                            <Columns>
                                                <asp:HyperLinkField AccessibleHeaderText="id_solicitud" 
                                                            DataNavigateUrlFormatString="id_solicitud" DataTextField="id_solicitud" 
                                                            HeaderText="Operacion" Text="id_solicitud">
                                                <ItemStyle ForeColor="#00CC00" />
                                                </asp:HyperLinkField>
                                                <asp:BoundField AccessibleHeaderText="Cliente" DataField="Cliente" 
                                                            HeaderText="Cliente" Visible="False" />
                                                <asp:BoundField AccessibleHeaderText="Cliente" DataField="nombre_cliente" 
                                                            HeaderText="Cliente" />
                                                <asp:BoundField AccessibleHeaderText="tipo_operacion" 
                                                            DataField="tipo_operacion" HeaderText="Tipo_operacion" 
                                                    Visible="False" />
                                                <asp:BoundField AccessibleHeaderText="Producto" DataField="operacion" 
                                                            HeaderText="Producto" />
                                                <asp:BoundField AccessibleHeaderText="Nº Factura" DataField="numero_factura" 
                                                            HeaderText="Nº Factura" />
                                                <asp:BoundField AccessibleHeaderText="Patente" DataField="Patente" 
                                                            HeaderText="Patente" />
                                                <asp:BoundField AccessibleHeaderText="numero_cliente" 
                                                            DataField="numero_cliente" HeaderText="Numero Cliente" />
                                                <asp:BoundField AccessibleHeaderText="Adquiriente" DataField="rut_persona" 
                                                            HeaderText="Adquiriente" />
                                                <asp:BoundField AccessibleHeaderText="Nombre" DataField="nombre_persona" />
                                                <asp:TemplateField AccessibleHeaderText="Nomina" HeaderText="Nomina">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="ib_nomina" runat="server" 
                                                                    ImageUrl="../imagenes/sistema/static/reporte.gif" />
                                                    </ItemTemplate>
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
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="ib_cdigital" runat="server" 
                                                                    ImageUrl="../imagenes/sistema/static/carpetas.gif" />
                                                    </ItemTemplate>
                                                    <ControlStyle Height="25px" Width="25px" />
                                                </asp:TemplateField>
                                                <asp:BoundField AccessibleHeaderText="ultimo estado" DataField="ultimo_estado" 
                                                            HeaderText="Estado Actual" />
                                                <asp:TemplateField HeaderText="Estado" ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="ib_estado" runat="server" 
                                                                    ImageUrl="../imagenes/sistema/static/Herramienta.png" />
                                                    </ItemTemplate>
                                                    <ControlStyle Height="25px" Width="25px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Comprobante gastos" ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="ib_comGastos" runat="server" 
                                                                    ImageUrl="../imagenes/sistema/impresoras/impresora.gif" 
                                                                    Text="comprobante gastos" />
                                                    </ItemTemplate>
                                                    <ControlStyle Height="25px" Width="25px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Gastos" ShowHeader="False">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="ib_gasto" runat="server" 
                                                                    ImageUrl="../imagenes/sistema/static/dinero.png" OnClick="Click_Gasto" 
                                                                    Text="Gastos" />
                                                    </ItemTemplate>
                                                    <ControlStyle Height="25px" Width="25px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <HeaderTemplate>
                                                        <asp:CheckBox ID="checkall" runat="server" AutoPostBack="True" 
                                                                    OnCheckedChanged="Check_Clicked" />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chk" runat="server" AutoPostBack="true" 
                                                                    EnableViewState="true" OnCheckedChanged="Check_Clicked_Grilla" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="total_gasto" HeaderText="Total Gastos" />
                                                <asp:BoundField DataField="total_egreso" HeaderText="Total Egreso" />
                                                <asp:BoundField DataField="total_ingreso" HeaderText="Total Ingreso" />
                                                <asp:BoundField DataField="total_devolucion" HeaderText="Total Devolución" />
                                                <asp:BoundField DataField="saldo" HeaderText="Saldo" />
                                                <asp:TemplateField HeaderText="Eliminar" ShowHeader="False" 
                                                    AccessibleHeaderText="Eliminar">
                                                    <ItemTemplate>
                                                        <asp:Button ID="bt_eliminar" runat="server" CausesValidation="False" 
                                                                    CommandName="eliminar" 
                                                            CommandArgument='<%# Bind("id_solicitud") %>' Text="Eliminar" />
                                                    </ItemTemplate>
                                                    <ControlStyle Font-Size="X-Small" />
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
					<asp:Panel ID="Panel2" runat="server" Visible="false">
						<asp:UpdatePanel ID="UpdatePanel3" runat="server">
							<ContentTemplate>
								<table style="width: 54%; font-family: Arial, Helvetica, sans-serif; font-size: x-small;
									background-color: #507CD1">
									<tr>
										<td style="width: 56px; color: #FFFFFF;" class="style5">
											Flujo de trabajo
											<td style="text-align: left" class="style8">
												<asp:DropDownList ID="dl_estado" runat="server" Font-Names="Arial" Font-Size="X-Small"
													Height="18px" OnSelectedIndexChanged="dl_estado_SelectedIndexChanged" Width="240px">
												</asp:DropDownList>
											</td>
									</tr>
									<tr>
										<td style="width: 15px; text-align: right; color: #FFFFFF;">
											Obs.
										</td>
										<td style="text-align: left;" class="style8">
											<asp:TextBox ID="txt_obs" runat="server" Font-Names="Arial" Font-Size="X-Small" MaxLength="30"
												Width="367px" TabIndex="3" Height="16px" OnTextChanged="txt_obs_TextChanged"></asp:TextBox>
										</td>
										<td>
											<asp:Button ID="Button1" runat="server" Font-Names="Arial" Font-Size="X-Small" Text="Guardar"
												OnClick="Button1_Click" TabIndex="16" />
											<cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="Button1"
												ConfirmText="¿Esta seguro de actualizar el flujo de trabajo?">
											</cc1:ConfirmButtonExtender>
										</td>
									</tr>
								</table>
							</ContentTemplate>
						</asp:UpdatePanel>
					</asp:Panel>
					<asp:Panel ID="Panel3" runat="server" Visible="false">
						<asp:UpdatePanel ID="UpdatePanel4" runat="server">
							<ContentTemplate>
								<table style="width: 54%; font-family: Arial, Helvetica, sans-serif; font-size: x-small;
									background-color: #507CD1">
									<tr>
										<td style="width: 56px; color: #FFFFFF;" class="style5">
											Nomina<td style="text-align: left" class="style8">
												<asp:DropDownList ID="dl_nomina" runat="server" Font-Names="Arial" Font-Size="X-Small"
													Height="18px" OnSelectedIndexChanged="dl_nomina_SelectedIndexChanged" Width="240px">
												</asp:DropDownList>
												&nbsp;<asp:Button ID="Button3" runat="server" Font-Names="Arial" Font-Size="X-Small"
													OnClick="Button3_Click" TabIndex="16" Text="Guardar" Style="height: 21px" />
											</td>
									</tr>
								</table>
							</ContentTemplate>
						</asp:UpdatePanel>
					</asp:Panel>
					
				</center>
			</td>
		</tr>
	</table>
</asp:Content>