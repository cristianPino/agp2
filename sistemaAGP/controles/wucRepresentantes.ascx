<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucRepresentantes.ascx.cs" Inherits="sistemaAGP.wucRepresentantes" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/controles/wucPersonaBase.ascx" TagName="Persona" TagPrefix="agp" %>
<%@ Register Src="~/controles/wucDirecciones.ascx" TagName="Direcciones" TagPrefix="agp" %>
<%@ Register Src="~/controles/wucTelefonos.ascx" TagName="Telefonos" TagPrefix="agp" %>
<%@ Register Src="~/controles/wucCorreos.ascx" TagName="Correos" TagPrefix="agp" %>
<asp:UpdatePanel ID="up_control" runat="server">
	<ContentTemplate>
		<asp:Panel ID="pnl_grilla" runat="server">
			<asp:GridView ID="gr_datos" runat="server" AutoGenerateColumns="False" DataKeyNames="rut" EnableModelValidation="True" OnRowDataBound="gr_datos_RowDataBound" OnRowCommand="gr_datos_RowCommand">
				<Columns>
					<asp:BoundField HeaderText="RUN" DataField="rut_dv" />
					<asp:BoundField HeaderText="Nombre" DataField="nombre" />
					<asp:BoundField HeaderText="Tipo" DataField="tipo" />
					<asp:CheckBoxField HeaderText="Firma" DataField="firma" ItemStyle-HorizontalAlign="Center" />
					<asp:BoundField HeaderText="Ciudad" DataField="ciudad" />
					<asp:BoundField HeaderText="Notario" DataField="notario" />
					<asp:BoundField HeaderText="Fecha" DataField="fecha" DataFormatString="{0:d}" />
					<asp:ButtonField ButtonType="Image" HeaderText="Editar" ImageUrl="~/imagenes/sistema/static/EditInformationHS.png" ShowHeader="True" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="45px" />
				</Columns>
			</asp:GridView>
			<asp:LinkButton ID="bt_agregar" runat="server" Text="Agregar Representante" CausesValidation="False" OnClick="bt_agregar_Click"></asp:LinkButton>
		</asp:Panel>
		<asp:Panel ID="pnl_nuevo" runat="server">
			<agp:Persona ID="agp_persona" runat="server" HabilitaLimpiar="false" HabilitarOtrosDatos="true" SoloPersonas="false" OnCambioPersona="agp_persona_CambioPersona" OnLimpiarPersona="agp_persona_LimpiarPersona" />
			<table class="tabla-normal">
				<tr>
					<td style="width: 110px;">
						Tipo Participante
					</td>
					<td>
						<asp:DropDownList ID="dl_tipo" runat="server" Width="120px">
						</asp:DropDownList>
						<asp:RequiredFieldValidator ID="rfv_tipo" runat="server" CssClass="error" Text="*" ErrorMessage="Tipo Participante" ControlToValidate="dl_tipo" InitialValue="0" SetFocusOnError="true" ValidationGroup="persona"></asp:RequiredFieldValidator>
					</td>
					<td style="width: 110px;">
						Fecha Personeria
					</td>
					<td>
						<asp:TextBox ID="txt_fecha" runat="server" Width="70px" Enabled="false"></asp:TextBox>
						<asp:RequiredFieldValidator ID="rfv_fecha" runat="server" CssClass="error" Text="*" ErrorMessage="Fecha Personeria" ControlToValidate="txt_fecha" InitialValue="" SetFocusOnError="true" ValidationGroup="persona"></asp:RequiredFieldValidator>
					</td>
					<td>
						<asp:ImageButton ID="ib_fecha" runat="server" ImageUrl="../imagenes/sistema/gif/calendario.gif" CausesValidation="False"></asp:ImageButton>
						<ajaxToolkit:CalendarExtender ID="cal_fecha" runat="server" CssClass="calendario" Enabled="True" Format="dd/MM/yyyy" PopupButtonID="ib_fecha" TargetControlID="txt_fecha">
						</ajaxToolkit:CalendarExtender>
					</td>
				</tr>
				<tr>
					<td style="width: 110px;">
						Ciudad Notario
					</td>
					<td colspan="4">
						<asp:TextBox ID="txt_ciudad" runat="server" MaxLength="30" Width="230px"></asp:TextBox>
						<asp:RequiredFieldValidator ID="rfv_ciudad" runat="server" CssClass="error" Text="*" ErrorMessage="Ciudad Notario" ControlToValidate="txt_ciudad" InitialValue="" SetFocusOnError="true" ValidationGroup="persona"></asp:RequiredFieldValidator>
					</td>
				</tr>
				<tr>
					<td style="width: 110px;">
						Notario Público
					</td>
					<td colspan="4">
						<asp:TextBox ID="txt_notario" runat="server" MaxLength="30" Width="300px"></asp:TextBox>
						<asp:RequiredFieldValidator ID="rfv_notario" runat="server" CssClass="error" Text="*" ErrorMessage="Notario Público" ControlToValidate="txt_notario" InitialValue="" SetFocusOnError="true" ValidationGroup="persona"></asp:RequiredFieldValidator>
					</td>
				</tr>
				<tr>
					<td colspan="5" style="text-align: right;">
						<asp:CheckBox ID="chk_firma" runat="server" Text="Firma Contrato" />
					</td>
				</tr>
			</table>
			<asp:UpdatePanel ID="up_opciones" runat="server">
				<ContentTemplate>
					<asp:Panel ID="pnl_opciones" runat="server" CssClass="opciones">
						<ajaxToolkit:TabContainer ID="tab_opciones" runat="server" Width="100%" ActiveTabIndex="0">
							<ajaxToolkit:TabPanel ID="tab_direcciones" runat="server" HeaderText="Direcciones"><ContentTemplate><asp:UpdatePanel ID="up_direcciones" runat="server" UpdateMode="Conditional"><ContentTemplate><table class="tabla-normal" style="width: 100%;"><tr><td style="font-weight: bold; width: 70px;">Tipo Dirección </td><td style="font-weight: bold; width: 10px; text-align: center;">: </td><td><asp:Label ID="lbl_tipo_direccion" runat="server" Text=""></asp:Label></td><td style="font-weight: bold; width: 70px;">Dirección </td><td style="font-weight: bold; width: 10px; text-align: center;">: </td><td><asp:Label ID="lbl_direccion" runat="server" Text=""></asp:Label></td></tr><tr><td style="font-weight: bold;">Número </td><td style="font-weight: bold; text-align: center;">: </td><td><asp:Label ID="lbl_numero" runat="server" Text=""></asp:Label></td><td style="font-weight: bold;">Complemento </td><td style="font-weight: bold; text-align: center;">: </td><td><asp:Label ID="lbl_complemento" runat="server" Text=""></asp:Label></td></tr><tr><td style="font-weight: bold;">Ciudad </td><td style="font-weight: bold; text-align: center;">: </td><td><asp:Label ID="lbl_ciudad" runat="server" Text=""></asp:Label></td><td style="font-weight: bold;">Comuna </td><td style="font-weight: bold; text-align: center;">: </td><td><asp:Label ID="lbl_comuna" runat="server" Text=""></asp:Label></td></tr><tr><td colspan="6" style="text-align: right;"><asp:LinkButton ID="bt_editar_direcciones" runat="server" Text="Editar Direcciones" OnClick="bt_editar_direcciones_Click" CausesValidation="true" ValidationGroup="persona"></asp:LinkButton></td></tr></table></ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="agp_direcciones" EventName="GuardarDireccion" /><asp:AsyncPostBackTrigger ControlID="agp_direcciones" EventName="CambioDireccion" /></Triggers></asp:UpdatePanel></ContentTemplate></ajaxToolkit:TabPanel>
							<ajaxToolkit:TabPanel ID="tab_telefonos" runat="server" HeaderText="Teléfonos"><ContentTemplate><asp:UpdatePanel ID="up_telefonos" runat="server" UpdateMode="Conditional"><ContentTemplate><table class="tabla-normal" style="width: 100%;"><tr><td style="font-weight: bold; width: 70px;">Tipo Teléfono </td><td style="font-weight: bold; width: 10px; text-align: center;">: </td><td><asp:Label ID="lbl_tipo_telefono" runat="server" Text=""></asp:Label></td><td style="font-weight: bold; width: 70px;">Teléfono </td><td style="font-weight: bold; width: 10px; text-align: center;">: </td><td><asp:Label ID="lbl_telefono" runat="server" Text=""></asp:Label></td></tr><tr><td colspan="6" style="text-align: right;"><asp:LinkButton ID="bt_editar_telefonos" runat="server" Text="Editar Teléfonos" OnClick="bt_editar_telefonos_Click" CausesValidation="true" ValidationGroup="persona"></asp:LinkButton></td></tr></table></ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="agp_telefonos" EventName="GuardarTelefono" /><asp:AsyncPostBackTrigger ControlID="agp_telefonos" EventName="CambioTelefono" /></Triggers></asp:UpdatePanel></ContentTemplate></ajaxToolkit:TabPanel>
							<ajaxToolkit:TabPanel ID="tab_correos" runat="server" HeaderText="Correos"><ContentTemplate><asp:UpdatePanel ID="up_correos" runat="server" UpdateMode="Conditional"><ContentTemplate><table class="tabla-normal" style="width: 100%;"><tr><td style="width: 100px;">Correo electrónico </td><td style="font-weight: bold; width: 10px; text-align: center;">: </td><td><asp:Label ID="lbl_correo" runat="server" Text=""></asp:Label></td></tr><tr><td colspan="3" style="text-align: right;"><asp:LinkButton ID="bt_editar_correos" runat="server" Text="Editar Correos" OnClick="bt_editar_correos_Click" CausesValidation="true" ValidationGroup="persona"></asp:LinkButton></td></tr></table></ContentTemplate><Triggers><asp:AsyncPostBackTrigger ControlID="agp_correos" EventName="GuardarCorreo" /><asp:AsyncPostBackTrigger ControlID="agp_correos" EventName="CambioCorreo" /></Triggers></asp:UpdatePanel></ContentTemplate></ajaxToolkit:TabPanel>
						</ajaxToolkit:TabContainer>
					</asp:Panel>
				</ContentTemplate>
				<Triggers>
					<asp:AsyncPostBackTrigger ControlID="agp_persona" EventName="CambioPersona" />
					<asp:AsyncPostBackTrigger ControlID="agp_persona" EventName="LimpiarPersona" />
				</Triggers>
			</asp:UpdatePanel>
			<asp:ValidationSummary ID="vs_persona" runat="server" DisplayMode="BulletList" ShowMessageBox="true" ShowSummary="false" HeaderText="Debe verificar los siguientes campos antes de continuar" ValidationGroup="persona" />
			<table class="tabla-normal" style="width: 600px;">
				<tr>
					<td style="text-align: center; width: 50%;">
						<asp:Button ID="bt_guardar" runat="server" CausesValidation="true" Text="Guardar" OnClick="bt_guardar_Click" ValidationGroup="persona"></asp:Button>
						<ajaxToolkit:ConfirmButtonExtender ID="cb_guardar" runat="server" ConfirmText="¿Está seguro de guardar los datos?" TargetControlID="bt_guardar">
						</ajaxToolkit:ConfirmButtonExtender>
					</td>
					<td style="text-align: center; width: 50%;">
						<asp:Button ID="bt_cancelar" runat="server" CausesValidation="false" Text="Cancelar" OnClick="bt_cancelar_Click"></asp:Button>
						<ajaxToolkit:ConfirmButtonExtender ID="cb_cancelar" runat="server" ConfirmText="Si acepta perderá los datos ingresados. ¿Desea continuar?" TargetControlID="bt_cancelar">
						</ajaxToolkit:ConfirmButtonExtender>
					</td>
				</tr>
			</table>
			<%--<asp:ValidationSummary ID="vs_datos" runat="server" DisplayMode="BulletList" ShowMessageBox="true" ShowSummary="false" HeaderText="Debe verificar los siguientes campos antes de continuar" ValidationGroup="nuevo_dato" />--%>
		</asp:Panel>
	</ContentTemplate>
	<Triggers>
		<asp:AsyncPostBackTrigger ControlID="bt_agregar" EventName="Click" />
		<asp:AsyncPostBackTrigger ControlID="bt_guardar" EventName="Click" />
		<asp:AsyncPostBackTrigger ControlID="bt_cancelar" EventName="Click" />
	</Triggers>
</asp:UpdatePanel>
<%--Inicio direcciones--%>
<asp:LinkButton ID="bt_oculto_direcciones" runat="server" Style="display: none;"></asp:LinkButton>
<asp:Panel ID="pnl_editar_direcciones" runat="server" CssClass="window">
	<asp:Panel ID="pnl_titulo_direcciones" runat="server" CssClass="title">
		Direcciones
		<asp:ImageButton ID="bt_cerrar_direcciones" runat="server" CssClass="close" ImageUrl="~/imagenes/sistema/static/close-window.png" AlternateText="X" CausesValidation="false" />
	</asp:Panel>
	<div class="content">
		<agp:Direcciones ID="agp_direcciones" runat="server" OnGuardarDireccion="agp_direcciones_GuardarDireccion" OnCambioDireccion="agp_direcciones_CambioDireccion" />
	</div>
</asp:Panel>
<ajaxToolkit:ModalPopupExtender ID="mpe_editar_direcciones" runat="server" TargetControlID="bt_oculto_direcciones" Drag="true" PopupDragHandleControlID="pnl_titulo_direcciones" CancelControlID="bt_cerrar_direcciones" PopupControlID="pnl_editar_direcciones" BackgroundCssClass="modalBackground" Enabled="True" DynamicServicePath="">
</ajaxToolkit:ModalPopupExtender>
<%--Fin direcciones--%>
<%--Inicio teléfonos--%>
<asp:LinkButton ID="bt_oculto_telefonos" runat="server" Style="display: none;"></asp:LinkButton>
<asp:Panel ID="pnl_editar_telefonos" runat="server" CssClass="window">
	<asp:Panel ID="pnl_titulo_telefonos" runat="server" CssClass="title">
		Teléfonos
		<asp:ImageButton ID="bt_cerrar_telefonos" runat="server" CssClass="close" ImageUrl="~/imagenes/sistema/static/close-window.png" AlternateText="X" CausesValidation="false" />
	</asp:Panel>
	<div class="content">
		<agp:Telefonos ID="agp_telefonos" runat="server" OnCambioTelefono="agp_telefonos_CambioTelefono" OnGuardarTelefono="agp_telefonos_GuardarTelefono" />
	</div>
</asp:Panel>
<ajaxToolkit:ModalPopupExtender ID="mpe_editar_telefonos" runat="server" TargetControlID="bt_oculto_telefonos" Drag="true" PopupDragHandleControlID="pnl_titulo_telefonos" CancelControlID="bt_cerrar_telefonos" PopupControlID="pnl_editar_telefonos" BackgroundCssClass="modalBackground" Enabled="True" DynamicServicePath="">
</ajaxToolkit:ModalPopupExtender>
<%--Fin teléfonos--%>
<%--Inicio correos--%>
<asp:LinkButton ID="bt_oculto_correos" runat="server" Style="display: none;"></asp:LinkButton>
<asp:Panel ID="pnl_editar_correos" runat="server" CssClass="window">
	<asp:Panel ID="pnl_titulo_correos" runat="server" CssClass="title">
		Correos
		<asp:ImageButton ID="bt_cerrar_correos" runat="server" CssClass="close" ImageUrl="~/imagenes/sistema/static/close-window.png" AlternateText="X" CausesValidation="false" />
	</asp:Panel>
	<div class="content">
		<agp:Correos ID="agp_correos" runat="server" OnCambioCorreo="agp_correos_CambioCorreo" OnGuardarCorreo="agp_correos_GuardarCorreo" />
	</div>
</asp:Panel>
<ajaxToolkit:ModalPopupExtender ID="mpe_editar_correos" runat="server" TargetControlID="bt_oculto_correos" Drag="true" PopupDragHandleControlID="pnl_titulo_correos" CancelControlID="bt_cerrar_correos" PopupControlID="pnl_editar_correos" BackgroundCssClass="modalBackground" Enabled="True" DynamicServicePath="">
</ajaxToolkit:ModalPopupExtender>
<%--Fin correos--%>