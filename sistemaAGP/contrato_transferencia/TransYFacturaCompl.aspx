<%@ Page Title="" Language="C#" MasterPageFile="~/Modal.Master" AutoEventWireup="true" CodeBehind="TransYFacturaCompl.aspx.cs" Inherits="sistemaAGP.preinscripcion.TransYFacturaCompl"
	Culture="es-CL" UICulture="es-CL" Theme="SkinAdm" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/controles/wucPersonaNew.ascx" TagName="DatosPersona" TagPrefix="agp" %>
<%@ Register Src="~/controles/wucVehiculoNew.ascx" TagName="DatosVehiculo" TagPrefix="agp" %>
<asp:Content ID="head_content" ContentPlaceHolderID="head" runat="server">
	<style type="text/css">
		.style1
		{
			width: 234px;
		}
		.style2
		{
			width: 233px;
		}
		.style3
		{
			width: 54px;
		}
		.style4
		{
			width: 49px;
		}
		.style5
		{
			width: 69px;
		}
		.style6
		{
			width: 219px;
		}
	</style>
</asp:Content>
<asp:Content ID="body_content" ContentPlaceHolderID="body" runat="server">
	<asp:UpdatePanel ID="up_operacion" runat="server" UpdateMode="Conditional">
		<ContentTemplate>
			<div style="width: 100%;">
				<div style="width: 100%; margin: 15px auto 0 auto;">
					<table class="tabla-titulo">
						<tr>
							<td>
								DATOS NEGOCIO - 
								<asp:Label ID="lbl_titulo" runat="server" Text=""></asp:Label>
							</td>
							
						</tr>
					</table>
					<table class="tabla-normal" style="width: 100%;">
						<tr>
							<td colspan="10" style="text-align: right;">
								<asp:ImageButton ID="ib_poliza" runat="server" ImageUrl="~/imagenes/sistema/static/poliza.jpg"
									Height="22px" Width="23px" Visible="false" OnClick="ib_poliza_Click" />
								<asp:ImageButton ID="ib_gasto" runat="server" ImageUrl="~/imagenes/sistema/static/dinero.png"
									Height="22px" Width="23px" OnClick="ib_gasto_Click" Visible="false" />
								<asp:ImageButton ID="ib_comgasto" runat="server" ImageUrl="~/imagenes/sistema/impresoras/impresora.gif"
									Height="22px" Width="23px" Visible="false" onclick="ib_comgasto_Click" />
								<asp:Label ID="lbl_operacion" runat="server" ForeColor="#FF3300" Visible="False" Text="Operación Nº: "></asp:Label>
								<asp:Label ID="lbl_numero" runat="server" ForeColor="#FF3300" Visible="False"></asp:Label>
							</td>
						</tr>
						<tr>
							<td class="style4">
								Cliente
							</td>
							<td class="style2">
								<asp:DropDownList ID="dl_cliente" runat="server" Enabled="false" Width="200px">
								</asp:DropDownList>
							</td>
							<td class="style3">
								Sucursal
							</td>
							<td class="style6">
								<asp:DropDownList ID="dl_sucursal" runat="server" Width="200px">
								</asp:DropDownList>
								<asp:RequiredFieldValidator ID="rfv_sucursal" runat="server" CssClass="error" Text="*" ErrorMessage="Sucursal" ControlToValidate="dl_sucursal" InitialValue="0"></asp:RequiredFieldValidator>
							</td>
							<td class="style5">
								NºFactura
							</td>
							<td>
								<asp:TextBox ID="txt_factura" runat="server" AutoPostBack="True" 
									ontextchanged="txt_factura_TextChanged"></asp:TextBox>
							</td>
							<td class="style5">
								Neto Factura
							</td>
							<td>
								<asp:TextBox ID="txt_neto" runat="server" AutoPostBack="True" OnTextChanged="txt_neto_TextChanged"></asp:TextBox>
							</td>
						</tr>
						<tr>
							<td style="width: 117px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
								<asp:Label ID="lbl_forma_pago" runat="server" Text="Forma de Pago"></asp:Label>
							</td>
							<td>
								<asp:DropDownList ID="dl_forma_pago" runat="server" Font-Names="Arial" Font-Size="X-Small"
									Height="16px" Width="138px" TabIndex="18" Style="font-family: Arial, Helvetica, sans-serif;
									font-size: x-small" AutoPostBack="true" OnSelectedIndexChanged="dl_forma_pago_SelectedIndexChanged">
								</asp:DropDownList>
							</td>
							<td style="width: 117px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
								<asp:Label ID="lbl_financiera" runat="server" Text="Entidad Financiera"></asp:Label>
							</td>
							<td>
								<asp:DropDownList ID="dl_financiera" runat="server" Font-Names="Arial" Font-Size="X-Small"
									Height="16px" Width="138px" TabIndex="19" Style="font-family: Arial, Helvetica, sans-serif;
									font-size: x-small" OnSelectedIndexChanged="dl_financiera_SelectedIndexChanged">
								</asp:DropDownList>
							</td>
						</tr>
					</table>
					<ajaxToolkit:TabContainer ID="tab_opciones" runat="server" Width="100%" 
						ActiveTabIndex="0">
						<ajaxToolkit:TabPanel ID="tab_persona" runat="server" HeaderText="Aquiriente"><ContentTemplate><asp:UpdatePanel ID="up_adquiriente" runat="server" UpdateMode="Conditional"><ContentTemplate><agp:DatosPersona ID="agp_adquirente" runat="server" HabilitarCompraPara="false" HabilitarCorreo="true" HabilitarDireccion="true" HabilitarOtrosDatos="true" HabilitarParticipante="true" HabilitarTelefono="true" Titulo="DATOS ADQUIRENTE" /></ContentTemplate></asp:UpdatePanel></ContentTemplate></ajaxToolkit:TabPanel>
						<ajaxToolkit:TabPanel ID="tab_vehiculos" runat="server" HeaderText="Vehiculo"><ContentTemplate><asp:UpdatePanel ID="up_vehiculo" runat="server" UpdateMode="Conditional"><ContentTemplate><agp:DatosVehiculo ID="agp_vehiculo" runat="server" Titulo="DATOS VEHICULO" /></ContentTemplate></asp:UpdatePanel></ContentTemplate></ajaxToolkit:TabPanel>
					</ajaxToolkit:TabContainer>
				</div>
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
