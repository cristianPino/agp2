<%@ Page Title="" Language="C#" MasterPageFile="~/Modal.Master" AutoEventWireup="true" CodeBehind="Ingreso_garantia_scotiabank.aspx.cs" Inherits="sistemaAGP.Ingreso_garantia_scotiabank" Culture="es-CL" UICulture="es-CL" Theme="SkinAdm" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/controles/wucVehiculoNew.ascx" TagName="DatosVehiculo" TagPrefix="agp" %>
<%@ Register Src="~/controles/wucPersonaNew.ascx" TagName="DatosPersona" TagPrefix="agp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
	<asp:UpdatePanel ID="up_operacion" runat="server" UpdateMode="Conditional">
		<ContentTemplate>
			<div style="width: 100%;">
				<table class="tabla-titulo">
					<tr>
						<td>
							INGRESO DE GARANTIA -
							<asp:Label ID="lbl_titulo" runat="server" Text=""></asp:Label>
						</td>
					</tr>
				</table>
				<table class="tabla-normal">
					<tr>
						<td>
							Cliente
						</td>
						<td>
							<asp:DropDownList ID="dl_cliente" runat="server" Enabled="false" Width="200px">
							</asp:DropDownList>
						</td>
						<td>
							Sucursal
						</td>
						<td>
							<asp:DropDownList ID="dl_sucursal" runat="server" Width="200px">
							</asp:DropDownList>
							<asp:RequiredFieldValidator ID="rfv_sucursal" runat="server" CssClass="error" Text="*" ErrorMessage="Sucursal" ControlToValidate="dl_sucursal" InitialValue="0"></asp:RequiredFieldValidator>
						</td>
						<td>
							<asp:Label ID="lbl_operacion" runat="server" ForeColor="#FF3300" Visible="False" Text="Operación Nº: "></asp:Label>
							<asp:Label ID="lbl_numero" runat="server" ForeColor="#FF3300" Visible="False"></asp:Label>
						</td>
					</tr>
				</table>
				<ajaxToolkit:TabContainer ID="tab_datos" runat="server" Width="100%" 
					ActiveTabIndex="0" ScrollBars="Auto">
					<ajaxToolkit:TabPanel ID="tab_negocio" runat="server" HeaderText="Datos Negocio" Width="100%">
						<ContentTemplate>
							<asp:UpdatePanel ID="up_negocio" runat="server" UpdateMode="Conditional">
								<ContentTemplate>
									<asp:Panel ID="pnl_tipo_doc_fundante" runat="server">
										<table class="tabla-normal">
											<tr>
												<td>
													Tipo Documento Fundante
												</td>
												<td>
													<asp:DropDownList ID="dl_tipo_doc_fundante" runat="server" Width="200px" AutoPostBack="True" OnSelectedIndexChanged="dl_tipo_doc_fundante_SelectedIndexChanged">
													</asp:DropDownList>
													<asp:RequiredFieldValidator ID="rfv_tipo_doc_fundante" runat="server" CssClass="error" Text="*" ErrorMessage="Tipo Documento Fundante" ControlToValidate="dl_tipo_doc_fundante" InitialValue="0"></asp:RequiredFieldValidator>
												</td>
											</tr>
										</table>
									</asp:Panel>
									<asp:Panel ID="pnl_emisor" runat="server" Visible="False">
										<agp:DatosPersona ID="agp_emisor" runat="server" Titulo="EMISOR FACTURA" HabilitarCompraPara="false" HabilitarCorreo="false" HabilitarDireccion="false" HabilitarTelefono="false" HabilitarOtrosDatos="false" />
									</asp:Panel>
									<asp:Panel ID="pnl_datos_negocio" runat="server" Visible="False">
										<table class="tabla-titulo">
											<tr>
												<td>
													<asp:Label ID="lbl_datos_negocio" runat="server"></asp:Label>
												</td>
											</tr>
										</table>
										<table class="tabla-normal">
											<tr>
												<% if (this.dl_tipo_doc_fundante.SelectedValue == "FACT" || this.dl_tipo_doc_fundante.SelectedValue == "DECL") { %>
												<td style="width: 100px;">
													<asp:Label ID="lbl_factura" runat="server"></asp:Label>
												</td>
												<td>
													<asp:TextBox ID="txt_factura" runat="server" Width="100px" 
														 MaxLength="10" ></asp:TextBox>
													
													<ajaxToolkit:FilteredTextBoxExtender ID="filter_factura" runat="server" TargetControlID="txt_factura"
														FilterType="Custom, Numbers" ValidChars='<%= System.Globalization.CultureInfo.CreateSpecificCulture("es-CL").NumberFormat.NumberGroupSeparator %>'
														Enabled="True" />
													<asp:RequiredFieldValidator ID="rfv_factura" runat="server" CssClass="error" Text="*"
														ControlToValidate="txt_factura"></asp:RequiredFieldValidator>
												</td>
												<% } %>
												<% if (this.dl_tipo_doc_fundante.SelectedValue == "FACT" || this.dl_tipo_doc_fundante.SelectedValue == "CONT" || this.dl_tipo_doc_fundante.SelectedValue == "DECL") { %>
												<td style="width: 100px;">
													<asp:Label ID="lbl_fecha_factura" runat="server"></asp:Label>
												</td>
												<td>
													<asp:TextBox ID="txt_fecha_factura" runat="server" Width="70px"></asp:TextBox>
													<asp:RequiredFieldValidator ID="rfv_fecha_factura" runat="server" CssClass="error" Text="*" ControlToValidate="txt_fecha_factura"></asp:RequiredFieldValidator>
												</td>
												<td>
													<asp:ImageButton ID="ib_fecha_factura" runat="server" ImageUrl="../imagenes/sistema/gif/calendario.gif" CausesValidation="False"></asp:ImageButton>
													<ajaxToolkit:CalendarExtender ID="cal_fecha_factura" runat="server" CssClass="calendario" Enabled="True" Format="dd/MM/yyyy" PopupButtonID="ib_fecha_factura" TargetControlID="txt_fecha_factura">
													</ajaxToolkit:CalendarExtender>
												</td>
												<% } %>
												<td style="width: 100px;">
													<asp:Label ID="lbl_monto_factura" runat="server"></asp:Label>
												</td>
												<td>
													<asp:TextBox ID="txt_monto_factura" runat="server" Width="100px" MaxLength="11" onkeyup="format(this);" onchange="format(this);"></asp:TextBox>
													<ajaxToolkit:FilteredTextBoxExtender ID="filter_motno_factura" runat="server" TargetControlID="txt_monto_factura" FilterType="Custom, Numbers" ValidChars='<%= System.Globalization.CultureInfo.CreateSpecificCulture("es-CL").NumberFormat.NumberGroupSeparator %>' Enabled="True" />
													<asp:RequiredFieldValidator ID="rfv_monto_factura" runat="server" CssClass="error" Text="*" ControlToValidate="txt_monto_factura"></asp:RequiredFieldValidator>
												</td>
											</tr>
										</table>
										<% if (this.dl_tipo_doc_fundante.SelectedValue == "CONT") { %>
										<table class="tabla-normal">
											<tr>
												<td style="width: 100px;">
													<asp:Label ID="lbl_notaria_factura" runat="server" Text="Notaría"></asp:Label>
												</td>
												<td>
													<asp:TextBox ID="txt_notaria_factura" runat="server" Width="200px" MaxLength="50" onkeyup="upperCase(this);" onchange="upperCase(this);"></asp:TextBox>
													<asp:RequiredFieldValidator ID="rfv_notaria_factura" runat="server" CssClass="error" Text="*" ControlToValidate="txt_notaria_factura"></asp:RequiredFieldValidator>
												</td>
												<td style="width: 100px;">
													<asp:Label ID="lbl_ciudad_notaria_factura" runat="server" Text="Ciudad"></asp:Label>
												</td>
												<td>
													<asp:TextBox ID="txt_ciudad_notaria_factura" runat="server" Width="200px" MaxLength="50" onkeyup="upperCase(this);" onchange="upperCase(this);"></asp:TextBox>
													<asp:RequiredFieldValidator ID="rfv_ciudad_notaria_factura" runat="server" CssClass="error" Text="*" ControlToValidate="txt_ciudad_notaria_factura"></asp:RequiredFieldValidator>
												</td>
											</tr>
										</table>
										<% } %>
										<table class="tabla-normal">
											<tr>
												<td style="width: 100px;">
													<asp:Label ID="lbl_forma_pago_factura" runat="server" Text="Forma de Pago"></asp:Label>
												</td>
												<td>
													<asp:DropDownList ID="dl_forma_pago_factura" runat="server" Width="140px">
													</asp:DropDownList>
													<asp:RequiredFieldValidator ID="rfv_forma_pago_factura" runat="server" CssClass="error" Text="*" ControlToValidate="dl_forma_pago_factura" InitialValue="0"></asp:RequiredFieldValidator>
												</td>
												<td>
													Nro. Crédito
												</td>
												<td>
													<asp:TextBox ID="txt_nro_credito" runat="server" Width="100px" MaxLength="15" onkeyup="format(this);" onchange="format(this);"></asp:TextBox>
													<ajaxToolkit:FilteredTextBoxExtender ID="filter_nro_credito" runat="server" TargetControlID="txt_nro_credito" FilterType="Custom, Numbers" ValidChars='<%= System.Globalization.CultureInfo.CreateSpecificCulture("es-CL").NumberFormat.NumberGroupSeparator %>' Enabled="True" />
													<asp:RequiredFieldValidator ID="rfv_nro_credito" runat="server" CssClass="error" ErrorMessage="Nro. de Crédito" Text="*" ControlToValidate="txt_nro_credito"></asp:RequiredFieldValidator>
													<asp:RequiredFieldValidator ID="rfv_nro_credito2" runat="server" CssClass="error" ErrorMessage="Nro. de Crédito" Text="*" ControlToValidate="txt_nro_credito" InitialValue="0"></asp:RequiredFieldValidator>
												</td>
												<td>
													Fecha Vencimiento
												</td>
												<td>
													<asp:TextBox ID="txt_ultima" runat="server" Width="70px"></asp:TextBox>
													<asp:RequiredFieldValidator ID="rfv_ultima" runat="server" CssClass="error" ErrorMessage="Fecha Vencimiento" Text="*" ControlToValidate="txt_ultima"></asp:RequiredFieldValidator>
												</td>
												<td>
													<asp:ImageButton ID="ib_ultima" runat="server" ImageUrl="~/imagenes/sistema/gif/calendario.gif" CausesValidation="False" />
													<ajaxToolkit:CalendarExtender ID="cal_ultima" runat="server" TargetControlID="txt_ultima" CssClass="calendario" Format="dd/MM/yyyy" PopupButtonID="ib_ultima" />
												</td>
											</tr>
										</table>
										<% if (this.dl_tipo_doc_fundante.SelectedValue == "SIN") { %>
											
										<% } %>
									</asp:Panel>
									<table class="tabla-normal">
										<tr>
											<td>
												Fecha Pagare
											</td>
											<td>
												<asp:TextBox ID="txt_f_pagare" runat="server" Width="70px" OnTextChanged="txt_f_pagare_TextChanged"></asp:TextBox>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="error"
													ErrorMessage="Fecha Pagare" Text="*" ControlToValidate="txt_f_pagare"></asp:RequiredFieldValidator>
											</td>
											<td>
												<asp:ImageButton ID="ib_f_pagare" runat="server" ImageUrl="~/imagenes/sistema/gif/calendario.gif"
													CausesValidation="False" />
												<ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_f_pagare"
													CssClass="calendario" Format="dd/MM/yyyy" PopupButtonID="ib_f_pagare" />
											</td>
											<td>
												Cant.Cuotas
											</td>
											<td>
												<asp:TextBox ID="txt_cant_cuotas" runat="server" Width="100px" MaxLength="15" onkeyup="format(this);"
													onchange="format(this);" OnTextChanged="txt_cant_cuotas_TextChanged" AutoPostBack="true"></asp:TextBox>
												<ajaxToolkit:FilteredTextBoxExtender ID="f_can_cuotas" runat="server" TargetControlID="txt_cant_cuotas"
													FilterType="Custom, Numbers" ValidChars='<%= System.Globalization.CultureInfo.CreateSpecificCulture("es-CL").NumberFormat.NumberGroupSeparator %>'
													Enabled="True" />
												<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="error"
													ErrorMessage="Cant. Cuotas" Text="*" ControlToValidate="txt_cant_cuotas"></asp:RequiredFieldValidator>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" CssClass="error"
													ErrorMessage="Cant. Cuotas" Text="*" ControlToValidate="txt_cant_cuotas" InitialValue="0"></asp:RequiredFieldValidator>
											</td>
											<td>
												Valor Cuotas
											</td>
											<td>
												<asp:TextBox ID="txt_v_cuotas" runat="server" Width="100px" MaxLength="15" onkeyup="format(this);"
													onchange="format(this);" OnTextChanged="txt_v_cuotas_TextChanged"></asp:TextBox>
												<ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
													TargetControlID="txt_v_cuotas" FilterType="Custom, Numbers" ValidChars='<%= System.Globalization.CultureInfo.CreateSpecificCulture("es-CL").NumberFormat.NumberGroupSeparator %>'
													Enabled="True" />
												<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" CssClass="error"
													ErrorMessage="Valor Cuotas" Text="*" ControlToValidate="txt_v_cuotas"></asp:RequiredFieldValidator>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" CssClass="error"
													ErrorMessage="Valor Cuotas" Text="*" ControlToValidate="txt_v_cuotas" InitialValue="0"></asp:RequiredFieldValidator>
											</td>
										</tr>
									</table>
									<table class="tabla-normal">
										<tr>
											<td>
												Fecha Primera
											</td>
											<td>
												<asp:TextBox ID="txt_f_primera" runat="server" Width="70px" OnTextChanged="txt_f_primera_TextChanged"
													AutoPostBack="true"></asp:TextBox>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" CssClass="error"
													ErrorMessage="Fecha Primera" Text="*" ControlToValidate="txt_f_primera"></asp:RequiredFieldValidator>
											</td>
											<td>
												<asp:ImageButton ID="ib_f_primera" runat="server" ImageUrl="~/imagenes/sistema/gif/calendario.gif"
													CausesValidation="False" />
												<ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txt_f_primera"
													CssClass="calendario" Format="dd/MM/yyyy" PopupButtonID="ib_f_primera" />
											</td>
											<td>
												Fecha Ultima
											</td>
											<td>
												<asp:TextBox ID="txt_f_ultima" runat="server" Width="70px" OnTextChanged="txt_f_ultima_TextChanged"></asp:TextBox>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" CssClass="error"
													ErrorMessage="Fecha Ultima" Text="*" ControlToValidate="txt_f_ultima"></asp:RequiredFieldValidator>
											</td>
											<td>
												<asp:ImageButton ID="ib_f_ultima" runat="server" ImageUrl="~/imagenes/sistema/gif/calendario.gif"
													CausesValidation="False" />
												<ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txt_f_ultima"
													CssClass="calendario" Format="dd/MM/yyyy" PopupButtonID="ib_f_ultima" />
											</td>
											<td>
												Capital Pagare
											</td>
											<td>
												<asp:TextBox ID="txt_c_pagare" runat="server" Width="100px" MaxLength="15" onkeyup="format(this);"
													onchange="format(this);" OnTextChanged="txt_c_pagare_TextChanged"></asp:TextBox>
												<ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
													TargetControlID="txt_c_pagare" FilterType="Custom, Numbers" ValidChars='<%= System.Globalization.CultureInfo.CreateSpecificCulture("es-CL").NumberFormat.NumberGroupSeparator %>'
													Enabled="True" />
												<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" CssClass="error"
													ErrorMessage="Capital Pagare" Text="*" ControlToValidate="txt_c_pagare"></asp:RequiredFieldValidator>
												<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" CssClass="error"
													ErrorMessage="Capital Pagare" Text="*" ControlToValidate="txt_c_pagare" InitialValue="0"></asp:RequiredFieldValidator>
											</td>
										</tr>
									</table>
									<table class="tabla-normal">
										<tr>
											<td>
												Tasa
											</td>
											<td>
												<asp:TextBox ID="txt_tasa" runat="server" Width="100px" MaxLength="50" onkeyup="upperCase(this);"
													onchange="upperCase(this);" OnTextChanged="txt_tasa_TextChanged"></asp:TextBox>
											</td>
											<td>
												Dia
											</td>
											<td>
												<asp:TextBox ID="txt_dia" runat="server" Width="100px" MaxLength="50" onkeyup="upperCase(this);"
													onchange="upperCase(this);" OnTextChanged="txt_dia_TextChanged"></asp:TextBox>
											</td>
										</tr>
									</table>

									<asp:Panel ID="pnl_otros_datos" runat="server">
										<table class="tabla-titulo">
											<tr>
												<td>
													OTROS DATOS
												</td>
											</tr>
										</table>
										<table class="tabla-normal">
											<tr>
												<td>
													<asp:CheckBox ID="chk_cav" runat="server" Text="CAV Comprado" Style="font-weight: bold;" />
												</td>
											</tr>
										</table>
									</asp:Panel>
								</ContentTemplate>
							</asp:UpdatePanel>
						</ContentTemplate>
					</ajaxToolkit:TabPanel>
					<ajaxToolkit:TabPanel ID="tab_vehiculo" runat="server" HeaderText="Datos Vehículo" Width="100%">
						<HeaderTemplate>
							Datos Vehículo
						</HeaderTemplate>
						<ContentTemplate>
							<agp:DatosVehiculo ID="agp_vehiculo" runat="server" Titulo="Vehículo" HabilitarCAV="true" />
						</ContentTemplate>
					</ajaxToolkit:TabPanel>
					<ajaxToolkit:TabPanel ID="tab_consignatario" runat="server" HeaderText="Datos Consignatario" Width="100%">
						<ContentTemplate>
							<asp:UpdatePanel ID="up_consignatario" runat="server" UpdateMode="Conditional">
								<ContentTemplate>
									<agp:DatosPersona ID="agp_adquirente" runat="server" Titulo="Consignatario" HabilitarCompraPara="true" HabilitarParticipante="true" HabilitarOtrosDatos="true" OnCambioCompraPara="agp_adquirente_CambioCompraPara" />
									<agp:DatosPersona ID="agp_compra_para" runat="server" Titulo="Compra Para" HabilitarParticipante="true" Visible="False" HabilitarOtrosDatos="true" />
								</ContentTemplate>
								<Triggers>
									<asp:AsyncPostBackTrigger ControlID="agp_adquirente" EventName="CambioCompraPara" />
								</Triggers>
							</asp:UpdatePanel>
						</ContentTemplate>
					</ajaxToolkit:TabPanel>
					<ajaxToolkit:TabPanel ID="tab_garantia" runat="server" HeaderText="Datos Garantía" Width="100%">
						<ContentTemplate>
							<asp:UpdatePanel ID="up_garantia" runat="server" UpdateMode="Conditional">
								<ContentTemplate>
									<table class="tabla-normal">
										<tr>
											<td colspan="4">
												<strong>Datos Protocolización</strong>
											</td>
										</tr>
										<tr>
											<td>
												Notaría
											</td>
											<td>
												<asp:TextBox ID="txt_notaria_protocolizacion" runat="server" Width="200px" MaxLength="50" onkeyup="upperCase(this);" onchange="upperCase(this);"></asp:TextBox><asp:RequiredFieldValidator ID="rfv_notaria_protocolizacion" runat="server" CssClass="error" Text="*" ControlToValidate="txt_notaria_protocolizacion"></asp:RequiredFieldValidator>
											</td>
											<td>
												Ciudad
											</td>
											<td>
												<asp:TextBox ID="txt_ciudad_notaria_protocolizacion" runat="server" Width="200px" MaxLength="50" onkeyup="upperCase(this);" onchange="upperCase(this);">
												</asp:TextBox><asp:RequiredFieldValidator ID="rfv_ciudad_notaria_protocolizacion" runat="server" CssClass="error" Text="*" ControlToValidate="txt_ciudad_notaria_protocolizacion"></asp:RequiredFieldValidator>
											</td>
										</tr>
									</table>
									<table class="tabla-normal">
										<tr>
											<td>
												Nº Repertorio
											</td>
											<td>
												<asp:TextBox ID="txt_repertorio_protocolizacion" runat="server" Width="100px" MaxLength="11" onkeyup="format(this);" onchange="format(this);"></asp:TextBox><ajaxToolkit:FilteredTextBoxExtender ID="filter_repertorio_protocolizacion" runat="server" TargetControlID="txt_repertorio_protocolizacion" FilterType="Custom, Numbers" ValidChars='<%= System.Globalization.CultureInfo.CreateSpecificCulture("es-CL").NumberFormat.NumberGroupSeparator %>' Enabled="True">
												</ajaxToolkit:FilteredTextBoxExtender>
											</td>
											<td>
												Fecha Repertorio
											</td>
											<td>
												<asp:TextBox ID="txt_fecha_repertorio_protocolizacion" runat="server" Width="70px"></asp:TextBox>
											</td>
											<td>
												<asp:ImageButton ID="btn_fecha_repertorio_protocolizacion" runat="server" ImageUrl="~/imagenes/sistema/gif/calendario.gif" CausesValidation="False" /><ajaxToolkit:CalendarExtender ID="cal_fecha_repertorio_protocolizacion" runat="server" TargetControlID="txt_fecha_repertorio_protocolizacion" CssClass="calendario" Format="dd/MM/yyyy" PopupButtonID="btn_fecha_repertorio_protocolizacion" />
											</td>
										</tr>
										<tr>
											<td>
												Nº Protocolizacion
											</td>
											<td>
												<asp:TextBox ID="txt_nro_protocolizacion" runat="server" Width="100px" MaxLength="11" onkeyup="format(this);" onchange="format(this);"></asp:TextBox><ajaxToolkit:FilteredTextBoxExtender ID="filter_nro_protocolizacion" runat="server" TargetControlID="txt_nro_protocolizacion" FilterType="Custom, Numbers" ValidChars='<%= System.Globalization.CultureInfo.CreateSpecificCulture("es-CL").NumberFormat.NumberGroupSeparator %>' Enabled="True">
												</ajaxToolkit:FilteredTextBoxExtender>
											</td>
											<td>
												Fecha Protocolización
											</td>
											<td>
												<asp:TextBox ID="txt_fecha_protocolizacion" runat="server" Width="70px"></asp:TextBox>
											</td>
											<td>
												<asp:ImageButton ID="btn_fecha_protocolizacion" runat="server" ImageUrl="~/imagenes/sistema/gif/calendario.gif" CausesValidation="False" /><ajaxToolkit:CalendarExtender ID="cal_fecha_protocolizacion" runat="server" TargetControlID="txt_fecha_protocolizacion" CssClass="calendario" Format="dd/MM/yyyy" PopupButtonID="btn_fecha_protocolizacion" />
											</td>
										</tr>
									</table>
									<hr />
									<table class="tabla-normal">
										<tr>
											<td colspan="5">
												<strong>Datos Solicitud RNP</strong>
											</td>
										</tr>
										<tr>
											<td>
												Nº Repertorio
											</td>
											<td>
												<asp:TextBox ID="txt_repertorio_rnp" runat="server" Width="100px" MaxLength="11" onkeyup="format(this);" onchange="format(this);"></asp:TextBox><ajaxToolkit:FilteredTextBoxExtender ID="filer_repertorio_rnp" runat="server" TargetControlID="txt_repertorio_rnp" FilterType="Custom, Numbers" ValidChars='<%= System.Globalization.CultureInfo.CreateSpecificCulture("es-CL").NumberFormat.NumberGroupSeparator %>' Enabled="True">
												</ajaxToolkit:FilteredTextBoxExtender>
											</td>
											<td>
												Fecha Repertorio
											</td>
											<td>
												<asp:TextBox ID="txt_fecha_repertorio_rnp" runat="server" Width="70px"></asp:TextBox>
											</td>
											<td>
												<asp:ImageButton ID="btn_fecha_repertorio_rnp" runat="server" ImageUrl="~/imagenes/sistema/gif/calendario.gif" CausesValidation="False" /><ajaxToolkit:CalendarExtender ID="cal_fecha_repertorio_rnp" runat="server" TargetControlID="txt_fecha_repertorio_rnp" CssClass="calendario" Format="dd/MM/yyyy" PopupButtonID="btn_fecha_repertorio_rnp" />
											</td>
											<td>
												Estado
											</td>
											<td>
												<asp:DropDownList ID="dl_estado_rnp" runat="server" Width="200px">
												</asp:DropDownList>
											</td>
										</tr>
									</table>
									<hr />
									<table class="tabla-normal">
										<tr>
											<td colspan="2">
												<strong>Datos Prenda</strong>
											</td>
										</tr>
										<tr>
											<td>
												Estado Prenda
											</td>
											<td>
												<asp:DropDownList ID="dl_estado_prenda" runat="server" Width="200px">
												</asp:DropDownList>
											</td>
										</tr>
									</table>
									<table class="tabla-normal" style="width: 100%;">
										<tr>
											<td colspan="2">
												Observaciones
											</td>
										</tr>
										<tr>
											<td>
												<asp:TextBox ID="txt_observaciones" runat="server" TextMode="MultiLine" Width="100%" Rows="4" MaxLength="1000" onkeyup="upperCase(this);" onchange="upperCase(this);"></asp:TextBox>
											</td>
										</tr>
									</table>
								</ContentTemplate>
							</asp:UpdatePanel>
						</ContentTemplate>
					</ajaxToolkit:TabPanel>


					<ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1">
					</ajaxToolkit:TabPanel>


				</ajaxToolkit:TabContainer>
				<div style="width: 500px; margin: 0 auto 0 auto;">
					<table class="tabla-normal">
						<tr>
							<td style="width: 250px; text-align: center;">
								<asp:Button ID="bt_guardar" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: small; width: 90px;" Text="Guardar" OnClick="bt_guardar_Click" CausesValidation="true" />
								<asp:ValidationSummary ID="vs_garantia" runat="server" DisplayMode="BulletList" ShowMessageBox="true" ShowSummary="false" HeaderText="Debe verificar los siguientes campos antes de continuar" />
								<ajaxToolkit:ConfirmButtonExtender ID="cbe_guardar" runat="server" ConfirmText="¿Está seguro de guardar la operación?" TargetControlID="bt_guardar">
								</ajaxToolkit:ConfirmButtonExtender>
							</td>
							<td style="width: 250px; text-align: center;">
								<asp:Button ID="bt_limpiar" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: small; width: 90px;" Text="Limpiar" OnClick="bt_limpiar_Click" CausesValidation="false" />
								<ajaxToolkit:ConfirmButtonExtender ID="cbe_limpiar" runat="server" ConfirmText="Si limpia el formualrio perderá los cambios realizados. ¿Está seguro de continuar?" TargetControlID="bt_limpiar">
								</ajaxToolkit:ConfirmButtonExtender>
							</td>
						</tr>
					</table>
				</div>
			</div>
		</ContentTemplate>
		<Triggers>
			<asp:AsyncPostBackTrigger ControlID="bt_guardar" EventName="Click" />
			<asp:AsyncPostBackTrigger ControlID="bt_limpiar" EventName="Click" />
		</Triggers>
	</asp:UpdatePanel>
</asp:Content>
