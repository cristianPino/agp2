<%@ Page Language="C#" MasterPageFile="~/Adm.Master" AutoEventWireup="true" CodeBehind="mRetiroCarpetaCredito.aspx.cs"Inherits="sistemaAGP.mRetiroCarpetaCredito" Title="Retiro Carpetas De Credito" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/controles/wucPersonaTransferencia.ascx" TagName="DatosPersona"
	TagPrefix="agp" %>
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
		.style12
		{
			font-family: Arial, Helvetica, sans-serif;
			font-size: x-small;
		}
		.style8
		{
			font-family: Arial, Helvetica, sans-serif;
			font-size: x-small;
		}
	</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<table style="background-color: #e5e5e5;">
		<tr>
			<td>
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
						<td class="style12">
							Concesionario
						</td>
						<td style="width: 126px; text-align: left">
							
							<asp:DropDownList ID="dl_concesionario" runat="server" AutoPostBack="true" Height="16px" Width="204px" OnSelectedIndexChanged="dl_conseci_SelectedIndexChanged" Style="font-size: x-small">
							</asp:DropDownList>
						</td>
					</tr>
					<tr>
						<td class="style8">
							Sucursal
						</td>
						<td colspan="3" style="width: 126px; text-align: left">
							<asp:DropDownList ID="dl_sucursal" ForeColor="SlateGray" runat="server" Font-Names="Arial"
								Font-Size="X-Small" Height="16px" Width="379px" TabIndex="3" AutoPostBack="True"
								OnSelectedIndexChanged="dl_sucursal_SelectedIndexChanged" CssClass="style5">
							</asp:DropDownList>
						</td>
					</tr>
				</table>
				<agp:datospersona id="DatosAdquiriente" runat="server" titulo="DATOS DEL ADQUIRIENTE"
					habilitarcomprapara="false" />
				<table bgcolor="#669999" style="width: 100%">
					<tr>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 1115px;
							color: #FFFFFF;">
							<b>DATOS CREDITO</b>
						</td>
					</tr>
				</table>
				<table style="width: 718px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;
					height: 38px;">
					<tr>
						<td class="style12">
							Nº Credito
						</td>
						<td>
							<asp:TextBox ID="txt_credito" runat="server" Style="font-family: Arial, Helvetica, sans-serif;"
								Font-Size="X-Small" MaxLength="30" Width="174px" TabIndex="3" Height="21px" OnTextChanged="txt_credito_TextChanged"
								AutoPostBack="true"></asp:TextBox>
						</td>
					</tr>
					<tr>
						<td class="style12">
							Entidad Financiera
						</td>
						<td>
							<asp:DropDownList ID="dl_financiera" runat="server" AutoPostBack="true" Height="16px" Width="204px" OnSelectedIndexChanged="dl_financiera_SelectedIndexChanged" Style="font-size: x-small">
							</asp:DropDownList>
						</td>
					</tr>
					<tr>
						<td class="style6">
							Ejecutivo
						</td>
						<td>
							<asp:TextBox ID="txt_ejecutivo" runat="server" Font-Names="Arial" Font-Size="X-Small"
								MaxLength="30" Width="284px" TabIndex="3" Height="23px"></asp:TextBox>
						</td>
					</tr>
					<tr>
						<td class="style12">
							Prohibicion
						</td>
						<td>
							<asp:DropDownList ID="dl_prohibicion" runat="server" AutoPostBack="true" Height="16px"
								Width="204px" OnSelectedIndexChanged="dl_prohibicion_SelectedIndexChanged" Style="font-size: x-small">
								<asp:ListItem Text="seleccionar" Value="0" />
								<asp:ListItem Text="SI" Value="1" />
								<asp:ListItem Text="NO" Value="2" />
							</asp:DropDownList>
						</td>
						
					</tr>
					<tr>
						<td class="style6">
							O.T.
						</td>
						<td>
							<asp:textbox id="txt_ot" runat="server" font-names="Arial" font-size="X-Small" maxlength="30"
								width="281px" tabindex="3" height="21px" ontextchanged="txt_ot_TextChanged"></asp:textbox>
						</td>
                        
					</tr>
                    <tr>
                        <td style="vertical-align: middle;">
							<strong>Fecha Adjudicacion</strong>
						</td>
						<td style="vertical-align: middle;">
							<asp:TextBox ID="txt_f_adjudicacion" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; " Height="16px" Width="180px"></asp:TextBox>
							<asp:ImageButton ID="ib_f_adjudicacion" runat="server" ImageUrl="../imagenes/sistema/gif/calendario.gif" />
							<cc1:CalendarExtender ID="cal_f_adjudicacion" runat="server" TargetControlID="txt_f_adjudicacion" CssClass="calendario" Format="dd/MM/yyyy" PopupButtonID="ib_f_adjudicacion" TodaysDateFormat="dd/MM/yyyy" OnClientDateSelectionChanged="checkDate" />
						</td>

                    </tr>
				</table>
				<table style="height: 17px; width: 718px">
					<tr>
						<td>
							<asp:Button ID="Button1" runat="server" Font-Names="Arial" Font-Size="X-Small" Visible="true"
								Text="Guardar" OnClick="Button1_Click" TabIndex="16" />
							<cc1:confirmbuttonextender id="Button1_ConfirmButtonExtender" runat="server" targetcontrolid="Button1"
								confirmtext="¿Confirmar datos de ingreso para retiro de Carpeta?">
			</cc1:confirmbuttonextender>
							<table>
								<tr>
									<td style="width: 721px; text-align: right">
										<asp:Label ID="lbl_operacion" runat="server" Font-Names="Arial" Font-Size="Small"
											ForeColor="#FF3300" Visible="False"></asp:Label>
										<asp:Label ID="lbl_numero" runat="server" Font-Names="Arial" Font-Size="Small" ForeColor="#FF3300"
											Visible="False"></asp:Label>
									</td>
								</tr>
							</table>
							<br />
						</td>
					</tr>
				</table>
			</td>
		</tr>
	</table>
</asp:Content>
