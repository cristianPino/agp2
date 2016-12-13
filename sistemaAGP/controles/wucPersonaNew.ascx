<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucPersonaNew.ascx.cs" Inherits="sistemaAGP.wucPersonaNew" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/controles/wucPersonaBase.ascx" TagName="Persona" TagPrefix="agp" %>
<%@ Register Src="~/controles/wucDirecciones.ascx" TagName="Direcciones" TagPrefix="agp" %>
<%@ Register Src="~/controles/wucTelefonos.ascx" TagName="Telefonos" TagPrefix="agp" %>
<%@ Register Src="~/controles/wucCorreos.ascx" TagName="Correos" TagPrefix="agp" %>
<%@ Register Src="~/controles/wucRepresentantes.ascx" TagName="Representantes" TagPrefix="agp" %>
<asp:Panel ID="pnl_datos_persona" runat="server">
	<table class="tabla-titulo">
		<tr>
			<td>
				<asp:Label ID="lbl_titulo" runat="server" Text="" />
			</td>
		</tr>
	</table>
	<agp:Persona ID="agp_persona" runat="server" SoloPersonas="false" OnCambioPersona="agp_persona_CambioPersona" OnLimpiarPersona="agp_persona_LimpiarPersona" />
</asp:Panel>
<asp:UpdatePanel ID="up_opciones" runat="server">
	<ContentTemplate>
		<asp:Panel ID="pnl_opciones" runat="server" CssClass="opciones">
			<table class="tabla-normal" style="width: 520px; text-align: right;">
				<tr>
					<td style="text-align: right;">
						<asp:CheckBox ID="chk_compra_para" runat="server" AutoPostBack="True" ForeColor="#ff0000" Text="Compra Para" OnCheckedChanged="chk_compra_para_CheckedChanged" />
					</td>
				</tr>
			</table>
			<ajaxToolkit:TabContainer ID="tab_opciones" runat="server" Width="100%" ActiveTabIndex="0">
				<ajaxToolkit:TabPanel ID="tab_direcciones" runat="server" HeaderText="Direcciones">
					<ContentTemplate>
						<asp:UpdatePanel ID="up_direcciones" runat="server" UpdateMode="Conditional">
							<ContentTemplate>
								<table class="tabla-normal" style="width: 100%;">
									<tr>
										<td style="font-weight: bold; width: 70px;">
											Tipo Dirección
										</td>
										<td style="font-weight: bold; width: 10px; text-align: center;">
											:
										</td>
										<td>
											<asp:Label ID="lbl_tipo_direccion" runat="server" Text=""></asp:Label>
										</td>
										<td style="font-weight: bold; width: 70px;">
											Dirección
										</td>
										<td style="font-weight: bold; width: 10px; text-align: center;">
											:
										</td>
										<td>
											<asp:Label ID="lbl_direccion" runat="server" Text=""></asp:Label>
										</td>
									</tr>
									<tr>
										<td style="font-weight: bold;">
											Número
										</td>
										<td style="font-weight: bold; text-align: center;">
											:
										</td>
										<td>
											<asp:Label ID="lbl_numero" runat="server" Text=""></asp:Label>
										</td>
										<td style="font-weight: bold;">
											Complemento
										</td>
										<td style="font-weight: bold; text-align: center;">
											:
										</td>
										<td>
											<asp:Label ID="lbl_complemento" runat="server" Text=""></asp:Label>
										</td>
									</tr>
									<tr>
										<td style="font-weight: bold;">
											Ciudad
										</td>
										<td style="font-weight: bold; text-align: center;">
											:
										</td>
										<td>
											<asp:Label ID="lbl_ciudad" runat="server" Text=""></asp:Label>
										</td>
										<td style="font-weight: bold;">
											Comuna
										</td>
										<td style="font-weight: bold; text-align: center;">
											:
										</td>
										<td>
											<asp:Label ID="lbl_comuna" runat="server" Text=""></asp:Label>
										</td>
									</tr>
									<tr>
										<td colspan="6" style="text-align: right;">
											<asp:LinkButton ID="bt_editar_direcciones" runat="server" Text="Editar Direcciones" OnClick="bt_editar_direcciones_Click" CausesValidation="true" ValidationGroup="persona"></asp:LinkButton>
										</td>
									</tr>
								</table>
							</ContentTemplate>
							<Triggers>
								<asp:AsyncPostBackTrigger ControlID="agp_direcciones" EventName="GuardarDireccion" />
								<asp:AsyncPostBackTrigger ControlID="agp_direcciones" EventName="CambioDireccion" />
							</Triggers>
						</asp:UpdatePanel>
					</ContentTemplate>
				</ajaxToolkit:TabPanel>
				<ajaxToolkit:TabPanel ID="tab_telefonos" runat="server" HeaderText="Teléfonos">
					<ContentTemplate>
						<asp:UpdatePanel ID="up_telefonos" runat="server" UpdateMode="Conditional">
							<ContentTemplate>
								<table class="tabla-normal" style="width: 100%;">
									<tr>
										<td style="font-weight: bold; width: 70px;">
											Tipo Teléfono
										</td>
										<td style="font-weight: bold; width: 10px; text-align: center;">
											:
										</td>
										<td>
											<asp:Label ID="lbl_tipo_telefono" runat="server" Text=""></asp:Label>
										</td>
										<td style="font-weight: bold; width: 70px;">
											Teléfono
										</td>
										<td style="font-weight: bold; width: 10px; text-align: center;">
											:
										</td>
										<td>
											<asp:Label ID="lbl_telefono" runat="server" Text=""></asp:Label>
										</td>
									</tr>
									<tr>
										<td colspan="6" style="text-align: right;">
											<asp:LinkButton ID="bt_editar_telefonos" runat="server" Text="Editar Teléfonos" OnClick="bt_editar_telefonos_Click" CausesValidation="true" ValidationGroup="persona"></asp:LinkButton>
										</td>
									</tr>
								</table>
							</ContentTemplate>
							<Triggers>
								<asp:AsyncPostBackTrigger ControlID="agp_telefonos" EventName="GuardarTelefono" />
								<asp:AsyncPostBackTrigger ControlID="agp_telefonos" EventName="CambioTelefono" />
							</Triggers>
						</asp:UpdatePanel>
					</ContentTemplate>
				</ajaxToolkit:TabPanel>
				<ajaxToolkit:TabPanel ID="tab_correos" runat="server" HeaderText="Correos">
					<ContentTemplate>
						<asp:UpdatePanel ID="up_correos" runat="server" UpdateMode="Conditional">
							<ContentTemplate>
								<table class="tabla-normal" style="width: 100%;">
									<tr>
										<td style="width: 100px;">
											Correo electrónico
										</td>
										<td style="font-weight: bold; width: 10px; text-align: center;">
											:
										</td>
										<td>
											<asp:Label ID="lbl_correo" runat="server" Text=""></asp:Label>
										</td>
									</tr>
									<tr>
										<td colspan="3" style="text-align: right;">
											<asp:LinkButton ID="bt_editar_correos" runat="server" Text="Editar Correos" OnClick="bt_editar_correos_Click" CausesValidation="true" ValidationGroup="persona"></asp:LinkButton>
										</td>
									</tr>
								</table>
							</ContentTemplate>
							<Triggers>
								<asp:AsyncPostBackTrigger ControlID="agp_correos" EventName="GuardarCorreo" />
								<asp:AsyncPostBackTrigger ControlID="agp_correos" EventName="CambioCorreo" />
							</Triggers>
						</asp:UpdatePanel>
					</ContentTemplate>
				</ajaxToolkit:TabPanel>
				<ajaxToolkit:TabPanel ID="tab_representantes" runat="server" HeaderText="Representantes">
					<ContentTemplate>
						<asp:UpdatePanel ID="up_representantes" runat="server" UpdateMode="Conditional">
							<ContentTemplate>
								<asp:GridView ID="gr_representantes" runat="server" AutoGenerateColumns="False" EnableModelValidation="True" Width="100%">
									<Columns>
										<asp:BoundField HeaderText="RUN" DataField="rut_dv" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Right" />
										<asp:BoundField HeaderText="Nombre" DataField="nombre" />
										<asp:BoundField HeaderText="Tipo" DataField="tipo" />
										<asp:CheckBoxField HeaderText="Firma" DataField="firma" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center" />
										<asp:BoundField HeaderText="Ciudad" DataField="ciudad" />
										<asp:BoundField HeaderText="Notario" DataField="notario" />
										<asp:BoundField HeaderText="Fecha" DataField="fecha" DataFormatString="{0:d}" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Center" />
									</Columns>
								</asp:GridView>
								<table class="tabla-normal" style="width: 100%;">
									<tr>
										<td style="text-align: right;">
											<asp:LinkButton ID="bt_editar_representantes" runat="server" Text="Editar Representantes" OnClick="bt_editar_representantes_Click" CausesValidation="true" ValidationGroup="persona"></asp:LinkButton>
										</td>
									</tr>
								</table>
							</ContentTemplate>
							<Triggers>
								<asp:AsyncPostBackTrigger ControlID="agp_representantes" EventName="CambioRepresentantes" />
							</Triggers>
						</asp:UpdatePanel>
					</ContentTemplate>
				</ajaxToolkit:TabPanel>
			</ajaxToolkit:TabContainer>
		</asp:Panel>
	</ContentTemplate>
	<Triggers>
		<asp:AsyncPostBackTrigger ControlID="agp_persona" EventName="CambioPersona" />
		<asp:AsyncPostBackTrigger ControlID="agp_persona" EventName="LimpiarPersona" />
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
<%--Inicio representantes--%>
<asp:LinkButton ID="bt_oculto_representantes" runat="server" Style="display: none;"></asp:LinkButton>
<asp:Panel ID="pnl_editar_representantes" runat="server" CssClass="window">
	<asp:Panel ID="pnl_titulo_representantes" runat="server" CssClass="title">
		Representantes
		<asp:ImageButton ID="bt_cerrar_representantes" runat="server" CssClass="close" ImageUrl="~/imagenes/sistema/static/close-window.png" AlternateText="X" CausesValidation="false" />
	</asp:Panel>
	<div class="content">
		<agp:Representantes ID="agp_representantes" runat="server" OnCambioRepresentantes="agp_representantes_CambioRepresentantes" />
	</div>
</asp:Panel>
<ajaxToolkit:ModalPopupExtender ID="mpe_editar_representantes" runat="server" TargetControlID="bt_oculto_representantes" Drag="true" PopupDragHandleControlID="pnl_titulo_representantes" CancelControlID="bt_cerrar_representantes" PopupControlID="pnl_editar_representantes" BackgroundCssClass="modalBackground" Enabled="True" DynamicServicePath="">
</ajaxToolkit:ModalPopupExtender>
<%--Fin representantes--%>
<asp:ValidationSummary ID="vs_persona" runat="server" DisplayMode="BulletList" ShowMessageBox="true" ShowSummary="false" HeaderText="Debe verificar los siguientes campos antes de continuar" ValidationGroup="persona" />