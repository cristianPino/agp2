<%@ Page Title="" Language="C#" MasterPageFile="~/Adm.Master" AutoEventWireup="true" CodeBehind="InG_Meratenencia.aspx.cs" Inherits="sistemaAGP.InG_Meratenencia" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/controles/wucPersonaTransferencia.ascx" TagName="DatosPersona" TagPrefix="agp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
							Nº Interno - (Número OP Bco Estado)
						</td>
						<td>
							<asp:TextBox ID="txt_interno" runat="server" MaxLength="15" Style="font-size: x-small;
								font-family: Arial, Helvetica, sans-serif" Width="65px" AutoPostBack="false" OnTextChanged="txt_interno_TextChanged"></asp:TextBox>
						</td>
					
						<td>
							<asp:TextBox ID="txt_bien" runat="server" MaxLength="15" Style="font-size: x-small;
								font-family: Arial, Helvetica, sans-serif" Width="65px" AutoPostBack="false" Visible="False"
								OnTextChanged="txt_bien_TextChanged"></asp:TextBox>
						</td>

                        

					</tr>

                        <tr>
                            <td style="font-size: x-small; font-family: Arial, Helvetica, sans-serif">
                            N° Factura
                        </td>

                        <td>
                            <asp:TextBox ID="txtNumFactura" runat="server" MaxLength="15" Style="font-size: x-small;
								font-family: Arial, Helvetica, sans-serif" Width="65px" AutoPostBack="false"
								OnTextChanged="txt_bien_TextChanged"></asp:TextBox>
                        </td>
                        <td id="tdMensaje" runat="server" Visible="false">
                            <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
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
				<agp:DatosPersona ID="Datosvendedor" runat="server" Titulo="DATOS DEL ADQUIRIENTE" HabilitarCompraPara="false" />
				<table bgcolor="#669999" style="width: 100%">
					<tr>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 1115px;
							color: #FFFFFF;">
							<b>DATOS DE VENTA</b>
						</td>
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
							
							<td>
								<asp:TextBox ID="txt_kilometraje" runat="server" MaxLength="10" Style="font-size: x-small;
									font-family: Arial, Helvetica, sans-serif" Width="65px" AutoPostBack="True" Visible="false" OnTextChanged="txt_kilometraje_TextChanged"></asp:TextBox>
							</td>
							<td style="font-size: x-small; font-family: Arial, Helvetica, sans-serif">
								<asp:Label ID="lbl_tipo" runat="server" Text="Tipo Vehiculo" Visible="True"></asp:Label>
							</td>
							<td class="style21">
								<asp:DropDownList ID="dl_tipo_vehiculo" runat="server" Font-Names="Arial" Font-Size="X-Small"
									Height="16px" Width="119px" TabIndex="6" Style="font-family: Arial, Helvetica, sans-serif;
									font-size: x-small" OnSelectedIndexChanged="dl_tipo_vehiculo_SelectedIndexChanged"
									Visible="True">
								</asp:DropDownList>
							</td>
							<td style="font-size: x-small; font-family: Arial, Helvetica, sans-serif">
								<asp:Label ID="lbl_marca" runat="server" Text="Marca" Visible="True"></asp:Label>
							</td>
							<td class="style9">
								<asp:DropDownList ID="dl_marca" runat="server" Font-Names="Arial" Font-Size="X-Small"
									Height="16px" Width="108px" TabIndex="6" Style="font-family: Arial, Helvetica, sans-serif;
									font-size: x-small" OnSelectedIndexChanged="dl_marca_SelectedIndexChanged" Visible="True">
								</asp:DropDownList>
							</td>
							<td style="font-size: x-small; font-family: Arial, Helvetica, sans-serif">
								<asp:Label ID="Label1" runat="server" Text="Modelo" Visible="True"></asp:Label>
							</td>
							<td class="style15">
								<asp:TextBox ID="txt_modelo" runat="server" CssClass="style2" Width="177px" Visible="True" 
									ontextchanged="txt_modelo_TextChanged"></asp:TextBox>
							</td>
						
						
						</tr>

					</table>
					<table>
						<tr>
							<td style="font-size: x-small; font-family: Arial, Helvetica, sans-serif">
								<asp:Label ID="lb_titulo_mera" runat="server" Text="Titulo Meratenencia" Visible="true"></asp:Label>
							</td>
							<td class="style21">
								<asp:DropDownList ID="dl_titulo_mera" runat="server" Font-Names="Arial" Font-Size="X-Small"
									Height="16px" Width="119px" TabIndex="6" Style="font-family: Arial, Helvetica, sans-serif;
									font-size: x-small" OnSelectedIndexChanged="dl_titulo_mera_SelectedIndexChanged"
									Visible="true">
								</asp:DropDownList>
							</td>
							<td style="font-size: x-small; font-family: Arial, Helvetica, sans-serif">
								<asp:Label ID="lb_calidad_mero" runat="server" Text="Calidad Merotenedor" Visible="true"></asp:Label>
							</td>
							<td class="style21">
								<asp:DropDownList ID="dl_calidad_mero" runat="server" Font-Names="Arial" Font-Size="X-Small"
									Height="16px" Width="119px" TabIndex="6" Style="font-family: Arial, Helvetica, sans-serif;
									font-size: x-small" OnSelectedIndexChanged="dl_calidad_mero_SelectedIndexChanged"
									Visible="true">
								</asp:DropDownList>
							</td>
							<td style="font-size: x-small; font-family: Arial, Helvetica, sans-serif">
								<asp:Label ID="lbltipo_doc" runat="server" Text="Tipo Documento" Visible="true"></asp:Label>
							</td>
							<td class="style21">
								<asp:DropDownList ID="dl_tipo_doc" runat="server" Font-Names="Arial" Font-Size="X-Small"
									Height="16px" Width="119px" TabIndex="6" Style="font-family: Arial, Helvetica, sans-serif;
									font-size: x-small" OnSelectedIndexChanged="dl_tipo_doc_SelectedIndexChanged"
									Visible="true">
								</asp:DropDownList>
							</td>
							<td style="font-size: x-small; font-family: Arial, Helvetica, sans-serif">
								<asp:Label ID="lb_naturaleza_doc" runat="server" Text="Naturaleza Documento" Visible="true"></asp:Label>
							</td>
							<td class="style21">
								<asp:DropDownList ID="dl_naturaleza_doc" runat="server" Font-Names="Arial" Font-Size="X-Small"
									Height="16px" Width="119px" TabIndex="6" Style="font-family: Arial, Helvetica, sans-serif;
									font-size: x-small" OnSelectedIndexChanged="dl_naturaleza_doc_SelectedIndexChanged"
									Visible="true">
								</asp:DropDownList>
							</td>
						</tr>
						<tr>
							<td style="font-size: x-small; font-family: Arial, Helvetica, sans-serif">
								NºDocumento
							</td>
							<td class="style17">
								<asp:TextBox ID="txt_n_doc" runat="server" CssClass="style2" Width="100px" OnTextChanged="txt_n_doc_TextChanged"></asp:TextBox>
							</td>
							<td style="font-size: x-small; font-family: Arial, Helvetica, sans-serif">
								Lugar Documento
							</td>
							<td class="style17">
								<asp:TextBox ID="txt_lugar_doc" runat="server" CssClass="style2" Width="100px" OnTextChanged="txt_lugar_doc_TextChanged"></asp:TextBox>
							</td>
							<td style="font-size: x-small; font-family: Arial, Helvetica, sans-serif">
								Autorizacion Documento
							</td>
							<td class="style17">
								<asp:TextBox ID="txt_autorizacion_doc" runat="server" CssClass="style2" Width="100px" OnTextChanged="txt_autorizacion_doc_TextChanged"></asp:TextBox>
							</td>
							<td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
								Fecha Documento
							</td>
							<td>
								<asp:TextBox ID="txt_fecha_documento" runat="server" Style="font-family: Arial, Helvetica, sans-serif;
									font-size: x-small" Height="19px" Width="73px" TabIndex="2" Enabled="False" 
									ontextchanged="txt_fecha_documento_TextChanged"></asp:TextBox>
								<cc1:calendarextender runat="server" targetcontrolid="txt_fecha_documento" cssclass="calendario"
									format="dd/MM/yyyy" popupbuttonid="ib_calendario" id="CalendarExtender1" />
							</td>
							<td>
								<asp:ImageButton ID="ib_calendario" runat="server" ImageUrl="../imagenes/sistema/gif/calendario.gif" />
							</td>
						</tr>
						<tr>
							<td style="font-size: x-small; font-family: Arial, Helvetica, sans-serif">
								Tribunal
							</td>
							<td class="style17">
								<asp:TextBox ID="txt_tribunal" runat="server" CssClass="style2" Width="100px" OnTextChanged="txt_tribunal_TextChanged"></asp:TextBox>
							</td>
							<td style="font-size: x-small; font-family: Arial, Helvetica, sans-serif">
								Año Causa
							</td>
							<td class="style17">
								<asp:TextBox ID="txt_anno_causa" runat="server" CssClass="style2" Width="100px" OnTextChanged="txt_anno_causa_TextChanged"></asp:TextBox>
							</td>
						</tr>

					</table>
				</asp:Panel>
				<agp:DatosPersona ID="Datoscomprador" runat="server" Titulo="DATOS DEL MEROTENEDOR"
					HabilitarCompraPara="false" HabilitarParticipante="true" />
				<table>
					<tr>
						<td style="margin-left: 40px">
							<asp:Button ID="bt_guardar" runat="server" Style="font-family: Arial, Helvetica, sans-serif;
								font-size: x-small" Text="Guardar" OnClick="bt_guardar_Click" />
							<ajaxToolkit:ConfirmButtonExtender ID="bt_guardar_ConfirmButtonExtender" runat="server"
								TargetControlID="bt_guardar" ConfirmText="¿Esta seguro de ingresar un nuevo contrato de transferencia?">
							</ajaxToolkit:ConfirmButtonExtender>
						</td>
						<td style="margin-left: 40px">
							<asp:Button ID="btn_limpiar" runat="server" Style="font-family: Arial, Helvetica, sans-serif;
								font-size: x-small" Text="Limpiar" OnClick="bt_limpiar_Click" />
							
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
