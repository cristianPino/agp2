<%@ Page Title="" Language="C#" MasterPageFile="~/Modal.Master" AutoEventWireup="true" CodeBehind="TransYFactura.aspx.cs" Inherits="sistemaAGP.preinscripcion.TransYFactura"
	Culture="es-CL" UICulture="es-CL" Theme="SkinAdm" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/controles/wucPersona.ascx" TagName="DatosPersona" TagPrefix="agp" %>
<%@ Register Src="~/controles/wucVehiculoNew.ascx" TagName="DatosVehiculo" TagPrefix="agp" %>
<%@ Register Src="~/controles/wucGrabar.ascx" TagName="DatosGrabar" TagPrefix="agp" %>
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
							<td class="style4">
								Cliente
							</td>
							<td class="style2">
								<asp:DropDownList ID="dl_cliente" runat="server" Enabled="false" Width="200px" 
									onselectedindexchanged="dl_cliente_SelectedIndexChanged">
								</asp:DropDownList>
							</td>
							<td class="style3">
								Sucursal
							</td>
							<td class="style6">
								<asp:DropDownList ID="dl_sucursal" runat="server" Width="200px">
								</asp:DropDownList>
							
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
						<td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
						Fecha Facturacion
					</td>
					<td class="style7">
						<asp:TextBox ID="txt_fecha_factura" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" Height="19px" Width="73px" TabIndex="2"></asp:TextBox>
						
						<cc1:CalendarExtender runat="server" TargetControlID="txt_fecha_factura" CssClass="calendario" Format="dd/MM/yyyy" PopupButtonID="ib_calendario" ID="CalendarExtender1" />
					</td>
					<td>
						<asp:ImageButton ID="ib_calendario" runat="server" ImageUrl="../imagenes/sistema/gif/calendario.gif" />
					</td>
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
						<tr>
							<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;" class="style2">
								Cargo Venta
							</td>
							<td class="style1">
								<asp:DropDownList ID="dl_cargo_venta" runat="server" Font-Names="Arial" Font-Size="X-Small"
									Height="16px" Width="138px" TabIndex="22" Style="font-family: Arial, Helvetica, sans-serif;
									font-size: x-small" onselectedindexchanged="dl_cargo_venta_SelectedIndexChanged">
								</asp:DropDownList>
							</td>

                            <td id="tdnumOper" runat="server" Visible="false" style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;" class="style2">
                                Nº Operacion Cliente
                            </td>

                            <td id="tdTexOper" runat="server" Visible="false">
                                <asp:TextBox ID="txtNumOperacion" runat="server" 
									Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" 
									Height="19px" Width="73px" TabIndex="2" 
									ontextchanged="txtNumOperacion_TextChanged"></asp:TextBox>
                            </td>
                            
                             <td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
					            <asp:Label ID="lblInstruccionPago" runat="server" Text="Instrucción de pago" Visible="False"></asp:Label> 
				            </td>

                            <td style="margin-left: 80px">
					            <asp:DropDownList ID="dlInstruccionPago" Visible="False" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="138px" TabIndex="1" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" AutoPostBack="True" OnSelectedIndexChanged="dl_cliente_SelectedIndexChanged">
					            </asp:DropDownList>
				            </td>

                            <td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
					            <asp:Label ID="lblNormaEuro" runat="server" Text="Norma Euro" Visible="False"></asp:Label>
				            </td>
                            <td>
                                <asp:CheckBox ID="ckNormaEuro" runat="server" Visible="False"/>
                            </td>

						</tr>
                        <tr>
                            <td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
                                <asp:Label ID="lbl_bien" runat="server" Text="Bien Leasing" Visible="False"></asp:Label>
                            </td>

                            <td>
                                <asp:DropDownList ID="dl_bien" runat="server" Visible="False" Font-Names="Arial" Font-Size="X-Small" Height="16px"
                                Width="138px" TabIndex="1" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small">
					            </asp:DropDownList>
                            </td>
                        </tr>
					</table>
					<ajaxToolkit:TabContainer ID="tab_opciones" runat="server" Width="100%" 
						ActiveTabIndex="1">

<ajaxToolkit:TabPanel ID="tab_persona" runat="server" HeaderText="Aquiriente"><ContentTemplate>
<asp:UpdatePanel ID="up_adquiriente" runat="server" UpdateMode="Conditional"><ContentTemplate>
		<agp:DatosPersona ID="agp_adquirente" runat="server" HabilitarCompraPara="true" HabilitarCorreo="true" HabilitarDireccion="true" HabilitarOtrosDatos="true" HabilitarParticipante="true" HabilitarTelefono="true" Titulo="DATOS ADQUIRENTE" />
		<agp:DatosPersona ID="agpCompraPara" runat="server" Titulo="DATOS COMPRA PARA" HabilitarCompraPara="false" Visible="false" />
</ContentTemplate>
</asp:UpdatePanel>


</ContentTemplate>
</ajaxToolkit:TabPanel>
						<ajaxToolkit:TabPanel ID="tab_vehiculos" runat="server" HeaderText="Vehiculo"><ContentTemplate>
<asp:UpdatePanel ID="up_vehiculo" runat="server" UpdateMode="Conditional"><ContentTemplate>
		<agp:DatosVehiculo ID="agp_vehiculo" runat="server" Titulo="DATOS VEHICULO" />
</ContentTemplate>
</asp:UpdatePanel>


</ContentTemplate>
</ajaxToolkit:TabPanel>
					</ajaxToolkit:TabContainer>
				</div>
				<div style="width: 500px; margin: 0 auto 0 auto;">
					<agp:datosGrabar ID="agpDatosGrabar" OnClick="btnAceptar_Click" runat="server" Titulo="GRABAR"
						HabilitarCompraPara="false" Visible="true" />
				</div>
			</div>
             <asp:HiddenField ID="hdIdOrdenTrabajo" runat="server" />
		</ContentTemplate>
		
	</asp:UpdatePanel>
</asp:Content>
