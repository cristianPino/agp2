<%@ Page Title="" Language="C#" MasterPageFile="~/Modal.Master" AutoEventWireup="true" CodeBehind="Alzamiento_20190_Especial.aspx.cs" Inherits="sistemaAGP.Alzamiento_20190_Especial" Culture="es-CL" UICulture="es-CL" Theme="SkinAdm" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/controles/wucVehiculoNew.ascx" TagName="DatosVehiculo" TagPrefix="agp" %>
<%@ Register Src="~/controles/wucPersonaNew.ascx" TagName="DatosPersona" TagPrefix="agp" %>
<asp:Content ID="head_content" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="body_content" ContentPlaceHolderID="body" runat="server">
	<asp:UpdatePanel ID="up_operacion" runat="server" UpdateMode="Conditional">
		<ContentTemplate>
			<div style="width: 100%;">
				<table class="tabla-titulo">
					<tr>
						<td>
							INGRESO DE ALZAMIENTO -
							<asp:Label ID="lbl_titulo" runat="server" Text=""></asp:Label>
						</td>
					</tr>
				</table>
				<table class="tabla-normal">
					<tr>
						<td colspan="6" style="text-align: right;">
							<asp:Label ID="lbl_operacion" runat="server" ForeColor="#FF3300" Visible="False" Text="Operación Nº: "></asp:Label>
							<asp:Label ID="lbl_numero" runat="server" ForeColor="#FF3300" Visible="False"></asp:Label>
						</td>
					</tr>
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
							Solicitante
						</td>
						<td>
							<asp:TextBox ID="txt_solicitante" runat="server" Width="200px"></asp:TextBox>
							<ajaxToolkit:AutoCompleteExtender ID="ace_solicitante" runat="server" TargetControlID="txt_solicitante" ServiceMethod="getListaSolicitantes" ServicePath="~/servicios_web/wsagp.asmx" ContextKey="" UseContextKey="true" MinimumPrefixLength="2" CompletionInterval="1000" EnableCaching="true">
							</ajaxToolkit:AutoCompleteExtender>
							<asp:RequiredFieldValidator ID="rfv_solicitante" runat="server" CssClass="error" Text="*" ErrorMessage="Solicitante" ControlToValidate="txt_solicitante" InitialValue=""></asp:RequiredFieldValidator>
						</td>
					</tr>
				</table>
				<ajaxToolkit:TabContainer ID="tab_datos" runat="server" Width="100%" ActiveTabIndex="0" ScrollBars="Auto">
					<ajaxToolkit:TabPanel ID="tab_negocio" runat="server" HeaderText="Datos Negocio" Width="100%">
						<ContentTemplate>
							<table class="tabla-normal">
								<tr>
									<td colspan="5">
										<strong>Datos Solicitud Notaría</strong>
									</td>
								</tr>
								<tr>
									<td>
										Nº Repertorio
									</td>
									<td>
										<asp:TextBox ID="txt_repertorio_notaria" runat="server" Width="100px" MaxLength="11" onkeyup="format(this);" onchange="format(this);"></asp:TextBox>
										<ajaxToolkit:FilteredTextBoxExtender ID="filter_repertorio_notaria" runat="server" TargetControlID="txt_repertorio_notaria" FilterType="Custom, Numbers" ValidChars='<%= System.Globalization.CultureInfo.CreateSpecificCulture("es-CL").NumberFormat.NumberGroupSeparator %>' Enabled="True">
										</ajaxToolkit:FilteredTextBoxExtender>
										<asp:RequiredFieldValidator ID="rfv_repertorio_notaria" runat="server" CssClass="error" Text="*" ErrorMessage="Nº Repertorio Notaria" ControlToValidate="txt_repertorio_notaria" InitialValue=""></asp:RequiredFieldValidator>
									</td>
									<td>
										Fecha Repertorio
									</td>
									<td>
										<asp:TextBox ID="txt_fecha_repertorio_notaria" runat="server" Width="70px"></asp:TextBox>
										<asp:RequiredFieldValidator ID="rfv_fecha_repertorio_notaria" runat="server" CssClass="error" Text="*" ErrorMessage="Fecha Repertorio Notaria" ControlToValidate="txt_fecha_repertorio_notaria" InitialValue=""></asp:RequiredFieldValidator>
									</td>
									<td>
										<asp:ImageButton ID="btn_fecha_repertorio_notaria" runat="server" ImageUrl="~/imagenes/sistema/gif/calendario.gif" CausesValidation="False" />
										<ajaxToolkit:CalendarExtender ID="cal_fecha_repertorio_notaria" runat="server" TargetControlID="txt_fecha_repertorio_notaria" CssClass="calendario" Format="dd/MM/yyyy" PopupButtonID="btn_fecha_repertorio_notaria" />
									</td>
								</tr>
							</table>
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
										<asp:TextBox ID="txt_repertorio_rnp" runat="server" Width="100px" MaxLength="11" onkeyup="format(this);" onchange="format(this);"></asp:TextBox>
										<ajaxToolkit:FilteredTextBoxExtender ID="filer_repertorio_rnp" runat="server" TargetControlID="txt_repertorio_rnp" FilterType="Custom, Numbers" ValidChars='<%= System.Globalization.CultureInfo.CreateSpecificCulture("es-CL").NumberFormat.NumberGroupSeparator %>' Enabled="True">
										</ajaxToolkit:FilteredTextBoxExtender>
										<asp:RequiredFieldValidator ID="rfv_repertorio_rnp" runat="server" CssClass="error" Text="*" ErrorMessage="Nº Repertorio RNP" ControlToValidate="txt_repertorio_rnp" InitialValue=""></asp:RequiredFieldValidator>
									</td>
									<td>
										Fecha Repertorio
									</td>
									<td>
										<asp:TextBox ID="txt_fecha_repertorio_rnp" runat="server" Width="70px"></asp:TextBox>
										<asp:RequiredFieldValidator ID="rfv_fecha_repertorio_rnp" runat="server" CssClass="error" Text="*" ErrorMessage="Fecha Repertorio RNP" ControlToValidate="txt_fecha_repertorio_rnp" InitialValue=""></asp:RequiredFieldValidator>
									</td>
									<td>
										<asp:ImageButton ID="btn_fecha_repertorio_rnp" runat="server" ImageUrl="~/imagenes/sistema/gif/calendario.gif" CausesValidation="False" />
										<ajaxToolkit:CalendarExtender ID="cal_fecha_repertorio_rnp" runat="server" TargetControlID="txt_fecha_repertorio_rnp" CssClass="calendario" Format="dd/MM/yyyy" PopupButtonID="btn_fecha_repertorio_rnp" />
									</td>
								</tr>
							</table>
							<table class="tabla-normal">
								<tr>
									<td colspan="3">
										<strong>Datos Solicitud RNVM</strong>
									</td>
								</tr>
								<tr>
									<td>
										Fecha Inscripción
									</td>
									<td>
										<asp:TextBox ID="txt_fecha_inscripcion_ph" runat="server" Width="70px"></asp:TextBox>
										<asp:RequiredFieldValidator ID="rfv_fecha_inscripcion_ph" runat="server" CssClass="error" Text="*" ErrorMessage="Fecha Inscripción RNVM" ControlToValidate="txt_fecha_inscripcion_ph" InitialValue=""></asp:RequiredFieldValidator>
									</td>
									<td>
										<asp:ImageButton ID="btn_fecha_inscripcion_ph" runat="server" ImageUrl="~/imagenes/sistema/gif/calendario.gif" CausesValidation="False" />
										<ajaxToolkit:CalendarExtender ID="cal_fecha_inscripcion_ph" runat="server" TargetControlID="txt_fecha_inscripcion_ph" CssClass="calendario" Format="dd/MM/yyyy" PopupButtonID="btn_fecha_inscripcion_ph" />
									</td>
								</tr>
							</table>
						</ContentTemplate>
					</ajaxToolkit:TabPanel>
					<ajaxToolkit:TabPanel ID="tab_vehiculo" runat="server" HeaderText="Datos Vehículo" Width="100%">
						<ContentTemplate>
							<agp:DatosVehiculo ID="agp_vehiculo" runat="server" Titulo="Vehículo" HabilitarCAV="true" />
						</ContentTemplate>
					</ajaxToolkit:TabPanel>
					<ajaxToolkit:TabPanel ID="tab_consignatario" runat="server" HeaderText="Datos Consignatario" Width="100%">
						<ContentTemplate>
							<asp:UpdatePanel ID="up_consignatario" runat="server" UpdateMode="Conditional">
								<ContentTemplate>
									<agp:DatosPersona ID="agp_consignatario" runat="server" Titulo="Consignatario" HabilitarCompraPara="false" HabilitarCorreo="false" HabilitarDireccion="false" HabilitarTelefono="false" HabilitarParticipante="false" HabilitarOtrosDatos="false" />
								</ContentTemplate>
								<Triggers>
									<asp:AsyncPostBackTrigger ControlID="agp_consignatario" />
								</Triggers>
							</asp:UpdatePanel>
						</ContentTemplate>
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