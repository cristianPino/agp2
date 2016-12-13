<%@ Page Title="" Language="C#" MasterPageFile="~/AGP.Master" AutoEventWireup="true" CodeBehind="control_operaciones_peru.aspx.cs" Inherits="sistemaAGP.control_operaciones_peru" Culture="es-PE" UICulture="es-PE" %>


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
	<asp:UpdateProgress ID="UpdateProg1" DisplayAfter="1000" runat="server">
		<ProgressTemplate>
			<div class="updateProgressContainer">
				<div class="updateProgress">
					<div style="position: relative; text-align: center;">
						<img src="../imagenes/sistema/gif/loading.gif" style="vertical-align: middle" alt="Procesando" />
						Procesando ...
					</div>
				</div>
			</div>
		</ProgressTemplate>
	</asp:UpdateProgress>
	<table align="left" style="width: 55%; height: 440px">
		<tr>
			<td class="style4" style="height: 74px" valign="top" align="left">
				<asp:UpdatePanel ID="arriba" runat="server">
					<ContentTemplate>
						<table style="width: 300; height: 32px;" bgcolor="#507CD1">
							<tr>
								<td>
									<table style="width: 300; height: 32px;" bgcolor="#507CD1">
										<tr>
											<td style="width: 74px; font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 28px; color: #FFFFFF; text-align: left;">
												<b style="text-align: right">Nº Operacion</b>
											</td>
											<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 28px;">
												<b>
													<asp:TextBox ID="txt_operacion" runat="server" Width="104px" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #FFFFFF;" BackColor="#3399FF" ForeColor="White" TabIndex="3" OnTextChanged="txt_operacion_TextChanged" AutoPostBack="true"></asp:TextBox>
													<cc1:filteredtextboxextender id="txt_operacion_FilteredTextBoxExtender" runat="server" targetcontrolid="txt_operacion" filtertype="Custom, Numbers" validchars="">
										</cc1:filteredtextboxextender>
												</b>
											</td>
											<td style="width: 81px">
												<asp:CheckBox ID="chk_agrupar" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; font-weight: 700; color: #FFFFFF" Text="Agrupar" />
											</td>
											<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #FFFFFF; height: 9px;">
												<b>Desde </b>
											</td>
											<td style="height: 9px">
												<asp:TextBox ID="txt_desde" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" Height="19px" Width="73px" TabIndex="2"></asp:TextBox>
												<asp:ImageButton ID="ib_desde" runat="server" ImageUrl="../imagenes/sistema/gif/calendario.gif" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" />
												<cc1:calendarextender id="CalendarExtender1" runat="server" targetcontrolid="txt_desde" cssclass="calendario" format="dd/MM/yyyy" popupbuttonid="ib_desde" />
											</td>
											<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #FFFFFF; font-weight: 700; height: 9px; width: 33px;">
												Hasta
											</td>
											<td style="height: 9px">
												<asp:TextBox ID="txt_hasta" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" Height="19px" Width="73px" TabIndex="2"></asp:TextBox>
												<asp:ImageButton ID="ib_hasta" runat="server" ImageUrl="../imagenes/sistema/gif/calendario.gif" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" />
												<cc1:calendarextender id="CalendarExtender2" runat="server" targetcontrolid="txt_hasta" cssclass="calendario" format="dd/MM/yyyy" popupbuttonid="ib_hasta" />
											</td>
											<td style="width: 81px">
												<asp:CheckBox ID="chk_proceso" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; font-weight: 700; color: #FFFFFF" Text="En Proceso" Checked="True" />
											</td>
										</tr>
									</table>
									<table style="width: 300; height: 32px;" bgcolor="#507CD1">
										<tr>
											<td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 28px; color: #FFFFFF;">
												<b>Familia AGP</b>
											</td>
											<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 28px; width: 190px;">
												<b>
													<asp:DropDownList ID="dl_familia" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="182px" TabIndex="1" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #000000;" AutoPostBack="True" OnSelectedIndexChanged="dl_cliente_SelectedIndexChanged">
													</asp:DropDownList>
												</b>
											</td>
											<td style="width: 38px; font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 28px; color: #FFFFFF;">
												<b>Cliente</b>
											</td>
											<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 28px; width: 238px;">
												<b>
													<asp:DropDownList ID="dl_cliente" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="238px" TabIndex="1" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #000000;" AutoPostBack="True" OnSelectedIndexChanged="dl_cliente_SelectedIndexChanged">
													</asp:DropDownList>
												</b>
											</td>
											<td style="width: 63px; font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 28px; color: #FFFFFF;">
												<b>Producto</b>
											</td>
											<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 28px;">
												<b>
													<asp:DropDownList ID="dl_producto" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="138px" TabIndex="17" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #000000;" AutoPostBack="True" OnSelectedIndexChanged="dl_producto_SelectedIndexChanged">
													</asp:DropDownList>
												</b>
											</td>
											<td class="style1" style="width: 57px; font-family: Arial, Helvetica, sans-serif; font-size: x-small; font-weight: bold; height: 28px; color: #FFFFFF;">
												Modulo
											</td>
											<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 28px;">
												<b>
													<asp:DropDownList ID="dl_modulo" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="138px" TabIndex="17" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #000000;" OnSelectedIndexChanged="dl_modulo_SelectedIndexChanged">
													</asp:DropDownList>
												</b>
											</td>
											<td style="width: 64px; font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 28px; color: #FFFFFF;">
												<b>Sucursal</b>
											</td>
											<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 28px; width: 29px;">
												<b>
													<asp:DropDownList ID="dl_sucursal" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="138px" TabIndex="17" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #000000;">
													</asp:DropDownList>
												</b>
											</td>
										</tr>
										<tr>
											<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #FFFFFF; font-weight: 700; width: 73px;">
												Adquiriente
											</td>
											<td style="width: 190px">
												<asp:TextBox ID="txt_rut" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" MaxLength="8" Width="136px"></asp:TextBox>
												<cc1:filteredtextboxextender id="txt_rutFilteredTextBoxExtender1" runat="server" targetcontrolid="txt_rut" filtertype="Custom, Numbers" validchars="">
									</cc1:filteredtextboxextender>
											</td>
											<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #FFFFFF">
												<b>Nº Factura</b>
											</td>
											<td style="width: 238px">
												<asp:TextBox ID="txt_factura" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" MaxLength="20" Width="135px"></asp:TextBox>
												<%--<cc1:filteredtextboxextender id="txt_facturaFilteredTextBoxExtender1" runat="server" targetcontrolid="txt_factura" filtertype="Custom, Numbers" validchars=""></cc1:filteredtextboxextender>--%>
											</td>
											<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #FFFFFF; font-weight: 700;">
												Nº Cliente
											</td>
											<td style="width: 51px">
												<asp:TextBox ID="txt_cliente" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" Width="133px"></asp:TextBox>
											</td>
											<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #FFFFFF; font-weight: 700;">
												Patente
											</td>
											<td style="width: 29px">
												<asp:TextBox ID="txt_patente" runat="server" MaxLength="6" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" Width="82px"></asp:TextBox>
											</td>
											<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 28px; color: #ffffff;">
												<strong>Saldo Operación</strong>
											</td>
											<td>
												<asp:DropDownList ID="dl_saldo" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="138px" TabIndex="19" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #000000;">
												</asp:DropDownList>
											</td>
										</tr>
									</table>
									<table bgcolor="Gray">
										<tr>
											<td style="text-align: center; height: 9px;" align="center" valign="middle">
												<asp:ImageButton ID="ib_buscar" runat="server" ImageUrl="../imagenes/sistema/gif/lupa.gif" Height="21px" Width="30px" OnClick="ib_buscar_Click" Style="text-align: center" />
											</td>
											<td style="text-align: left; width: 40px; height: 9px;" align="center" valign="middle">
												<asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="exel" Font-Names="Arial" Font-Size="X-Small" Style="font-size: x-small; color: #FFFFFF; font-family: Arial, Helvetica, sans-serif" />
											</td>
											<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;" class="style5">
												<asp:Label ID="lbl_flujo" runat="server" Style="color: #FFFFFF; text-align: right;" Text="Flujo de Trabajo" Visible="False"></asp:Label>
											</td>
											<td style="text-align: right;">
												<asp:DropDownList ID="dpl_estado" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" OnSelectedIndexChanged="dl_estado_SelectedIndexChanged" Width="157px" Visible="False">
												</asp:DropDownList>
											</td>
											<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;" class="style5">
												<asp:Label ID="lbl_nomina" runat="server" Style="color: #FFFFFF; text-align: right;" Text="Nómina"></asp:Label>
											</td>
											<td>
												<asp:DropDownList ID="dpl_nomina" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="157px">
												</asp:DropDownList>
											</td>
											<td>
												<asp:TextBox ID="txt_nomina" runat="server" Font-Names="Arial" Font-Size="X-Small" Width="87px" OnTextChanged="txt_nomina_TextChanged"></asp:TextBox>
											</td>
											<td>
												<asp:ImageButton ID="btn_nomina_pdf" runat="server" ImageUrl="../imagenes/sistema/static/pdf.jpg" Height="24" Width="24" OnClick="btn_nomina_pdf_Click" />
											</td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
						</td> </tr>
					</ContentTemplate>
				</asp:UpdatePanel>
			</td>
		</tr>
		<tr>
			<td>
				<table style="width: 100%; height: 264px;">
					<tr>
						<td style="width: 123px;" valign="top">
							<asp:UpdatePanel ID="UpdatePanel2" runat="server">
								<ContentTemplate>
									<asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="tipo_operacion,cliente" Font-Names="Arial" Font-Size="X-Small" ForeColor="#333333" GridLines="None" Height="50px" OnSelectedIndexChanged="gr_dato_SelectedIndexChanged" Width="984px" OnRowCommand="gr_dato_RowCommand" OnRowDataBound="gr_dato_RowDataBound">
										<RowStyle BackColor="#EFF3FB" />
										<Columns>
											<asp:HyperLinkField AccessibleHeaderText="id_solicitud" DataNavigateUrlFormatString="id_solicitud" DataTextField="id_solicitud" HeaderText="Operacion" Text="id_solicitud">
												<ItemStyle ForeColor="#00CC00" />
											</asp:HyperLinkField>
											<asp:BoundField AccessibleHeaderText="Cliente" DataField="Cliente" HeaderText="Cliente" Visible="False" />
											<asp:BoundField AccessibleHeaderText="Cliente" DataField="nombre_cliente" HeaderText="Cliente" />
											<asp:BoundField AccessibleHeaderText="tipo_operacion" DataField="tipo_operacion" HeaderText="Tipo_operacion" Visible="False" />
											<asp:BoundField AccessibleHeaderText="Producto" DataField="operacion" HeaderText="Producto" />
											<asp:BoundField AccessibleHeaderText="Nº Factura" DataField="numero_factura" HeaderText="Nº Factura" />
											<asp:BoundField AccessibleHeaderText="Patente" DataField="Patente" HeaderText="Patente" />
											<asp:BoundField AccessibleHeaderText="numero_cliente" DataField="numero_cliente" HeaderText="Numero Cliente" />
											<asp:BoundField AccessibleHeaderText="Adquiriente" DataField="rut_persona" HeaderText="Adquiriente" />
											<asp:BoundField AccessibleHeaderText="Nombre" DataField="nombre_persona" />
											<asp:TemplateField AccessibleHeaderText="Nomina" HeaderText="Nomina">
												<ItemTemplate>
													<asp:ImageButton ID="ib_nomina" runat="server" ImageUrl="../imagenes/sistema/static/reporte.gif" />
												</ItemTemplate>
												<ControlStyle Height="25px" Width="25px" />
											</asp:TemplateField>
											<asp:TemplateField AccessibleHeaderText="Cargar" HeaderText="Cargar">
												<ItemTemplate>
													<asp:ImageButton ID="ib_cargar" runat="server" ImageUrl="../imagenes/sistema/static/carpeta.gif" />
												</ItemTemplate>
												<ControlStyle Height="25px" Width="25px" />
											</asp:TemplateField>
											<asp:TemplateField AccessibleHeaderText="C.Digital" HeaderText="C.Digital">
												<ItemTemplate>
													<asp:ImageButton ID="ib_cdigital" runat="server" ImageUrl="../imagenes/sistema/static/carpetas.gif" />
												</ItemTemplate>
												<ControlStyle Height="25px" Width="25px" />
											</asp:TemplateField>
											<asp:BoundField AccessibleHeaderText="ultimo estado" DataField="ultimo_estado" HeaderText="Estado Actual" />
											<asp:TemplateField HeaderText="Estado" ShowHeader="False">
												<ItemTemplate>
													<asp:ImageButton ID="ib_estado" runat="server" ImageUrl="../imagenes/sistema/static/Herramienta.png" />
												</ItemTemplate>
												<ControlStyle Height="25px" Width="25px" />
											</asp:TemplateField>
											<asp:TemplateField HeaderText="Comprobante gastos" ShowHeader="False">
												<ItemTemplate>
													<asp:ImageButton ID="ib_comGastos" runat="server" ImageUrl="../imagenes/sistema/impresoras/impresora.gif" Text="comprobante gastos" />
												</ItemTemplate>
												<ControlStyle Height="25px" Width="25px" />
											</asp:TemplateField>
											<asp:TemplateField HeaderText="Gastos" ShowHeader="False">
												<ItemTemplate>
													<asp:ImageButton ID="ib_gasto" runat="server" ImageUrl="../imagenes/sistema/static/dinero.png" Text="Gastos" />
												</ItemTemplate>
												<ControlStyle Height="25px" Width="25px" />
											</asp:TemplateField>
											<asp:TemplateField HeaderText="Pagos" ShowHeader="False">
												<ItemTemplate>
													<asp:ImageButton ID="ib_ingreso" runat="server" ImageUrl="../imagenes/sistema/static/cofre.png" Text="Pagos" />
												</ItemTemplate>
												<ControlStyle Height="35px" Width="35px" />
											</asp:TemplateField>
											<asp:TemplateField>
												<HeaderTemplate>
													<asp:CheckBox ID="checkall" runat="server" AutoPostBack="True" OnCheckedChanged="Check_Clicked" />
												</HeaderTemplate>
												<ItemTemplate>
													<asp:CheckBox ID="chk" runat="server" AutoPostBack="true" EnableViewState="true" OnCheckedChanged="Check_Clicked_Grilla" />
												</ItemTemplate>
											</asp:TemplateField>
											<asp:BoundField DataField="total_gasto" HeaderText="Total Gastos" />
											<asp:BoundField DataField="total_ingreso" HeaderText="Total Pagos" />
											<asp:BoundField DataField="saldo" HeaderText="Saldo" />
											<asp:BoundField DataField="factura_emitida" HeaderText="Factura Emitida" />
											<asp:TemplateField AccessibleHeaderText="Eliminar" HeaderText="Eliminar" ShowHeader="False">
												<ItemTemplate>
													<asp:Button ID="bt_eliminar" runat="server" CausesValidation="False" CommandName="eliminar" CommandArgument='<%# Bind("id_solicitud") %>' Text="Eliminar" />
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
									<asp:Button ID="btnHiddenButton" runat="server" Text="Hidden Button" Style="display: none" />
									<asp:Panel ID="pnlEliminar" runat="server" CssClass="popupContainer">
										<div class="popupMsg">
											<div class="popupInfo">
												<div style="position: relative; text-align: center;">
													<table style="width: 200px; vertical-align: middle; text-align: center; background-color: #507cd1;">
														<tr>
															<td colspan="2" style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #ffffff;">
																Para eliminar la operación nro. <strong>
																	<asp:Label ID="lblOpEliminar" runat="server" Text=""></asp:Label></strong> debe proporcionar permisos de administrador
															</td>
														</tr>
														<tr>
															<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #ffffff;">
																Usuario
															</td>
															<td>
																<asp:TextBox ID="txtUsuario" runat="server" Text="" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 18px; width: 130px;"></asp:TextBox>
															</td>
														</tr>
														<tr>
															<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #ffffff;">
																Clave
															</td>
															<td>
																<asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Text="" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 18px; width: 130px;"></asp:TextBox>
															</td>
														</tr>
													</table>
													<table style="width: 200px;">
														<tr>
															<td style="vertical-align: middle; text-align: center;">
																<asp:Button ID="btnAceptarEliminar" runat="server" Text="Aceptar" OnClick="btnAceptarEliminar_Click" />
															</td>
															<td style="vertical-align: middle; text-align: center;">
																<asp:Button ID="btnCancelarEliminar" runat="server" Text="Cancelar" />
															</td>
														</tr>
													</table>
												</div>
											</div>
										</div>
									</asp:Panel>
									<cc1:modalpopupextender id="ModalPopupExtenderEliminar" runat="server" cancelcontrolid="btnCancelarEliminar" popupcontrolid="pnlEliminar" targetcontrolid="btnHiddenButton">
									</cc1:modalpopupextender>
								</ContentTemplate>
							</asp:UpdatePanel>
						</td>
					</tr>
				</table>
				<center>
					<asp:UpdatePanel ID="panel_movimiento" runat="server">
						<ContentTemplate>
							<asp:Panel ID="Panel1" runat="server" Visible="false">
								<table style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 842px; background-color: #507CD1">
									<tr>
										<td class="style9" style="color: #FFFFFF">
											Banco
										</td>
										<td style="text-align: left; width: 170px">
											<asp:DropDownList ID="dl_financiera" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="18px" Width="160px" TabIndex="19" CssClass="style8" AutoPostBack="True" OnSelectedIndexChanged="dl_financiera_SelectedIndexChanged">
											</asp:DropDownList>
										</td>
										<td class="style8" style="color: #FFFFFF">
											Nº Cuenta
										</td>
										<td style="text-align: left; width: 182px">
											<asp:DropDownList ID="dl_cuenta" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="138px" TabIndex="19" CssClass="style8">
											</asp:DropDownList>
										</td>
									</tr>
									<tr>
										<td class="style9">
											<span style="color: #FFFFFF">Tipo Operacion</span>
										</td>
										<td style="text-align: left; width: 170px">
											<asp:DropDownList ID="dl_tipo_operacion" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="161px" TabIndex="19" CssClass="style8">
											</asp:DropDownList>
										</td>
										<td class="style9">
											<span style="color: #FFFFFF">Fecha Pago</span>
										</td>
										<td style="text-align: left; width: 182px">
											<asp:TextBox ID="txt_fecha_pago" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" Height="19px" Width="73px" TabIndex="2"></asp:TextBox>
											<asp:ImageButton ID="ib_fecha_pago" runat="server" ImageUrl="../imagenes/sistema/gif/calendario.gif" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" />
											<cc1:calendarextender id="CalendarExtender3" runat="server" targetcontrolid="txt_fecha_pago" cssclass="calendario" format="dd/MM/yyyy" popupbuttonid="ib_fecha_pago" />
										</td>
										<td class="style9" style="color: #FFFFFF">
											Documento Especial (G5)<td style="text-align: left">
												<asp:TextBox ID="txt_especial" runat="server" Style="font-size: x-small; font-family: Arial, Helvetica, sans-serif" Width="149px" MaxLength="20"></asp:TextBox>
											</td>
									</tr>
									<tr>
										<td>
											&nbsp;
										</td>
									</tr>
									<tr>
										<td style="font-size: small">
											<cc1:confirmbuttonextender id="ConfirmButtonExtender2" runat="server" targetcontrolid="bt_graba_movimiento" confirmtext="¿Esta seguro de cancelar las operaciones marcadas por completo.?">
											</cc1:confirmbuttonextender>
											<span style="color: #FFFFFF"><strong>Total a Pagar</strong></span>
										</td>
										<td style="text-align: left; color: #FFFFFF">
											<strong>
												<asp:Label ID="lbl_total_gastos" runat="server" Style="color: #ffffff; text-align: left; font-size: small;">0</asp:Label>
											</strong>
										</td>
										<td>
											<asp:Button ID="bt_graba_movimiento" runat="server" OnClick="bt_graba_movimiento_Click" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" Text="Pagar" />
										</td>
										<td style="width: 182px">
											&nbsp;
										</td>
									</tr>
								</table>
							</asp:Panel>
						</ContentTemplate>
						<Triggers>
							<asp:AsyncPostBackTrigger ControlID="ib_pago_operacion" />
						</Triggers>
					</asp:UpdatePanel>
				</center>
				<center>
					<asp:UpdatePanel ID="UpdatePanel3" runat="server">
						<ContentTemplate>
							<asp:Panel ID="Panel2" runat="server" Visible="false">
								<table style="width: 54%; font-family: Arial, Helvetica, sans-serif; font-size: x-small; background-color: #507CD1">
									<tr>
										<td style="width: 56px; color: #FFFFFF;" class="style5">
											Flujo de trabajo
											<td style="text-align: left" class="style8">
												<asp:DropDownList ID="dl_estado" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="18px" OnSelectedIndexChanged="dl_estado_SelectedIndexChanged" Width="240px">
												</asp:DropDownList>
											</td>
									</tr>
									<tr>
										<td style="width: 15px; text-align: right; color: #FFFFFF;">
											Obs.
										</td>
										<td style="text-align: left;" class="style8">
											<asp:TextBox ID="txt_obs" runat="server" Font-Names="Arial" Font-Size="X-Small" MaxLength="30" Width="367px" TabIndex="3" Height="16px" OnTextChanged="txt_obs_TextChanged"></asp:TextBox>
										</td>
										<td>
											<asp:Button ID="Button1" runat="server" Font-Names="Arial" Font-Size="X-Small" Text="Guardar" OnClick="Button1_Click" TabIndex="16" />
											<cc1:confirmbuttonextender id="ConfirmButtonExtender1" runat="server" targetcontrolid="Button1" confirmtext="¿Esta seguro de actualizar el flujo de trabajo?">
											</cc1:confirmbuttonextender>
										</td>
									</tr>
								</table>
							</asp:Panel>
						</ContentTemplate>
						<Triggers>
							<asp:AsyncPostBackTrigger ControlID="ib_work" />
						</Triggers>
					</asp:UpdatePanel>
				</center>
				<center>
					<asp:UpdatePanel ID="UpdatePanel4" runat="server">
						<ContentTemplate>
							<asp:Panel ID="Panel3" runat="server" Visible="false">
								<table style="width: 54%; font-family: Arial, Helvetica, sans-serif; font-size: x-small; background-color: #507CD1">
									<tr>
										<td style="width: 56px; color: #FFFFFF;" class="style5">
											Nomina<td style="text-align: left" class="style8">
												<asp:DropDownList ID="dl_nomina" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="18px" OnSelectedIndexChanged="dl_nomina_SelectedIndexChanged" Width="240px">
												</asp:DropDownList>
												&nbsp;<asp:Button ID="Button3" runat="server" Font-Names="Arial" Font-Size="X-Small" OnClick="Button3_Click" TabIndex="16" Text="Guardar" Style="height: 21px" />
											</td>
									</tr>
								</table>
							</asp:Panel>
						</ContentTemplate>
						<Triggers>
							<asp:AsyncPostBackTrigger ControlID="ib_nomina" />
						</Triggers>
					</asp:UpdatePanel>
				</center>
			</td>
		</tr>
		<tr>
			<td>
				<table bgcolor="Gray">
					<tr>
						<td style="width: 170px">
							<asp:ImageButton ID="ib_pago_operacion" runat="server" ImageUrl="../imagenes/sistema/static/dinero1.gif" Height="21px" Width="30px" Style="text-align: center" OnClick="ib_pago_operacion_Click" />
							<span style="font-size: x-small; font-family: Arial, Helvetica, sans-serif; color: #FFFFFF;"><strong>Pagar Operaciones</strong></span>
						</td>
						<td style="width: 170px">
							<asp:ImageButton ID="ib_work" runat="server" ImageUrl="../imagenes/sistema/static/Herramienta.png" Height="21px" Width="30px" Style="text-align: center" OnClick="ib_work_Click" />
							<span style="font-size: x-small; font-family: Arial, Helvetica, sans-serif; color: #FFFFFF;"><strong>Cambiar WorkFlow</strong></span>
						</td>
						<td style="width: 170px">
							<asp:ImageButton ID="ib_nomina" runat="server" ImageUrl="../imagenes/sistema/static/documentos.gif" Height="21px" Width="30px" Style="text-align: center" OnClick="ib_nomina_Click" />
							<span style="font-size: x-small; font-family: Arial, Helvetica, sans-serif; color: #FFFFFF;"><strong>Crear Nomina</strong></span>
						</td>
					</tr>
				</table>
			</td>
		</tr>
	</table>
</asp:Content>
