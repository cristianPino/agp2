<%@ Page Title="" Language="C#" MasterPageFile="~/Adm.Master" AutoEventWireup="true" CodeBehind="ProductosVarios.aspx.cs" Inherits="sistemaAGP.ProductosVarios" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/controles/wucPersonaTransferencia.ascx" TagName="DatosPersona" TagPrefix="agp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<script type="text/javascript" src="../jquery-1.7.2.min.js"></script>
	<script type="text/javascript" src="../jquery.mousewheel-3.0.6.pack.js"></script>
	<script type="text/javascript" src="../jquery.fancybox.js?v=2.0.6"></script>
	<link rel="Stylesheet" type="text/css" href="../jquery.fancybox.css?v=2.0.6" media="screen" />
	<script type="text/javascript">
		$(document).ready(function () {
			$('.fancybox').fancybox({
				maxWidth: 640,
				maxHeight: 480,
				minWidth: 640,
				minHeight: 480,
				fitToView: false,
				width: 640,
				height: 480,
				autoSize: true,
				openEffect: 'elastic',
				openSpeed: 150,
				closeEffect: 'elastic',
				closeSpeed: 150,
				closeClick: false,
				closeBtn: true,
				scrolling: 'no',
				padding: 0,
				helpers: {
					overlay: {
						opacity: 0.5,
						css: {
							'background-color': 'Gray'
						},
						title: {
							type: 'float'
						}
					}
				}
			});
		});
	</script>

	<style type="text/css">
		.style2
		{}
	</style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

	<table style="background-color: #e5e5e5;">
		<tr>
			<td style="width: 789px; height: 20px" valign="top">
				<table bgcolor="#669999" style="width: 100%">
					<tr>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 1115px;
							color: #FFFFFF;">
							<b>CARGO OPERACION --<asp:Label ID="lbl_titulo" runat="server" Text=""></asp:Label></b>
						</td>
					</tr>
				</table>
				<table>
					<tr>
						<td>
							<span style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; font-weight: bold">
								Cliente</span>
						</td>
						<td>
							<asp:DropDownList ID="dl_cliente" runat="server" Height="16px" Width="188px" AutoPostBack="True"
								Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; font-weight: 700"
								OnSelectedIndexChanged="dl_cliente_SelectedIndexChanged">
							</asp:DropDownList>
						</td>
						<td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
							Sucursal Origen
						</td>
						<td>
							<asp:DropDownList ID="dl_sucursal_origen" runat="server" Font-Names="Arial" Font-Size="X-Small"
								Height="16px" Width="138px" TabIndex="17" Style="font-family: Arial, Helvetica, sans-serif;
								font-size: x-small">
							</asp:DropDownList>
						</td>
						<td style="font-size: x-small; font-family: Arial, Helvetica, sans-serif">
							<asp:Label ID="Label1" runat="server" Text="Nº Interno"></asp:Label>
						</td>
						<td>
							<asp:TextBox ID="txt_interno" runat="server" MaxLength="15" Style="font-size: x-small;
								font-family: Arial, Helvetica, sans-serif" Width="65px" AutoPostBack="false" 
								OnTextChanged="txt_interno_TextChanged" Visible="true"></asp:TextBox>

							<asp:DropDownList ID="dl_Codigo_TAG" runat="server" Visible="false">
							</asp:DropDownList>
						</td>
					</tr>
                    <tr>
                       	<td style="font-size: x-small; font-family: Arial, Helvetica, sans-serif">
							<asp:Label ID="Label2" runat="server" Text="Nº Factura"></asp:Label>
						</td>

                        <td>
                            <asp:TextBox ID="txt_factura" runat="server" Width="72px"></asp:TextBox>
                        </td>


                    </tr>
				</table>
				<agp:DatosPersona ID="Datosvendedor" runat="server" Titulo="DATOS DEL PROPIETARIO" HabilitarCompraPara="false" />
				<table bgcolor="#669999" style="width: 100%">
					<tr>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 1115px;
							color: #FFFFFF;">
							<b>DATOS VEHICULO</b></td>
					</tr>
				</table>
				<asp:Panel ID="id_datounico" runat="server">
					<table>
						<tr>
							<td style="font-size: x-small; font-family: Arial, Helvetica, sans-serif">
								Patente
							</td>
							<td>
								<asp:TextBox ID="txt_patente" runat="server" MaxLength="6" Style="font-size: x-small;
									font-family: Arial, Helvetica, sans-serif" Width="60px" AutoPostBack="True" OnTextChanged="txt_patente_TextChanged"></asp:TextBox>
								<asp:TextBox ID="txt_dv_patente" runat="server" MaxLength="1" Style="font-size: x-small;
									font-family: Arial, Helvetica, sans-serif" Width="16px"></asp:TextBox>
							</td>
							<td style="font-size: x-small; font-family: Arial, Helvetica, sans-serif">
								Kilometraje
							</td>
							<td>
								<asp:TextBox ID="txt_kilometraje" runat="server" MaxLength="10" Style="font-size: x-small;
									font-family: Arial, Helvetica, sans-serif" Width="65px" AutoPostBack="True" OnTextChanged="txt_kilometraje_TextChanged"></asp:TextBox>
							</td>
							<td style="font-size: x-small; font-family: Arial, Helvetica, sans-serif">
								Tipo Vehiculo
							</td>
							<td class="style21">
								<asp:DropDownList ID="dl_tipo_vehiculo" runat="server" Font-Names="Arial" Font-Size="X-Small"
									Height="16px" Width="119px" TabIndex="6" Style="font-family: Arial, Helvetica, sans-serif;
									font-size: x-small" OnSelectedIndexChanged="dl_tipo_vehiculo_SelectedIndexChanged"
									Visible="true">
								</asp:DropDownList>
							</td>
							<td style="font-size: x-small; font-family: Arial, Helvetica, sans-serif">
								Marca
							</td>
							<td class="style9">
								<asp:DropDownList ID="dl_marca" runat="server" Font-Names="Arial" Font-Size="X-Small"
									Height="16px" Width="108px" TabIndex="6" Style="font-family: Arial, Helvetica, sans-serif;
									font-size: x-small" OnSelectedIndexChanged="dl_marca_SelectedIndexChanged" Visible="true">
								</asp:DropDownList>
							</td>
							<td class="control">
								Año
							</td>
							<td class="style15">
								<asp:TextBox ID="txt_ano" runat="server" CssClass="control" Width="44px" 
									ontextchanged="txt_ano_TextChanged"></asp:TextBox>
							</td>
							<td class="control">
								Motor
							</td>
							<td class="style17">
								<asp:TextBox ID="txt_motor" runat="server" CssClass="style2" Width="100px" 
									ontextchanged="txt_motor_TextChanged"></asp:TextBox>
							</td>
						</tr>
						<tr>
							<td class="control">
								Observacion
							</td>
							<td class="style17" colspan="4">
								<asp:TextBox ID="txt_observacion" runat="server" CssClass="style2" 
									Width="237px" OnTextChanged="txt_motor_TextChanged" Height="65px" TextMode="MultiLine"></asp:TextBox>
							</td>
						</tr>
					</table>
				</asp:Panel>
				<table>
					<tr>
						<td>
							<asp:Button ID="bt_guardar" runat="server" Style="font-family: Arial, Helvetica, sans-serif;
								font-size: x-small" Text="Guardar" OnClick="bt_guardar_Click" />
							<ajaxToolkit:ConfirmButtonExtender ID="bt_guardar_ConfirmButtonExtender" runat="server"
								TargetControlID="bt_guardar" ConfirmText="¿Esta seguro de ingresar un nuevo contrato de transferencia?">
							</ajaxToolkit:ConfirmButtonExtender>
						</td>
						<td>
							&nbsp;</td>
						<td>
							&nbsp;
						</td>
						<td style="width: 721px; text-align: right">
							<asp:Label ID="lbl_operacion" runat="server" Font-Names="Arial" Font-Size="Small"
								ForeColor="#FF3300" Visible="False"></asp:Label>
							<asp:Label ID="lbl_numero" runat="server" Font-Names="Arial" Font-Size="Small" ForeColor="#FF3300"
								Visible="False"></asp:Label>
						</td>
					</tr>
				</table>
			</td>
		</tr>
	</table>
	<asp:Panel ID="pnlPopUp" runat="server" CssClass="PopUp" Style="display: none;">
		<table>
			<tr>
				<td>
					<asp:Button ID="bt_salir" runat="server" Font-Names="Arial" Font-Size="X-Small" Text="Cancelar" />
				</td>
			</tr>
		</table>
	</asp:Panel>
	
</asp:Content>
