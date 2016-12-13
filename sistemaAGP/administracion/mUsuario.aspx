<%@ Page Language="C#" MasterPageFile="~/AGP.Master" AutoEventWireup="true" CodeBehind="mUsuario.aspx.cs" Inherits="sistemaAGP.mUsuario" Title="Administrador de Usuarios" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMenu" runat="server">
	<script type="text/javascript" src="../jquery-1.7.2.min.js"></script>
	<script type="text/javascript" src="../jquery.mousewheel-3.0.6.pack.js"></script>
	<script type="text/javascript" src="../jquery.fancybox.js?v=2.0.6"></script>
	<link rel="Stylesheet" type="text/css" href="../jquery.fancybox.css?v=2.0.6" media="screen" />
	<script type="text/javascript">
		$(document).ready(function () {
			$('.fancybox').fancybox({
				maxWidth: 800,
				maxHeight: 600,
				fitToView: false,
				width: 800,
				height: 600,
				autoSize: false,
				openEffect: 'elastic',
				openSpeed: 150,
				closeEffect: 'elastic',
				closeSpeed: 150,
				closeClick: false,
				closeBtn: true,
				scrolling: 'auto',
				padding: 5,
				beforeShow: function () {
					var el, id = $(this.element).data('title-id');
					if (id) {
						el = $('#' + id);
						if (el.length)
							this.title = el.html();
					}
				},
				helpers: {
					overlay: {
						opacity: 0.5,
						css: {
							'background-color': 'Gray'
						}
					}
				}
			});
		});
	</script>
	

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoCentral" runat="server">
	<table  class=table border="0" style="width: 1028px; height: 405px">
		<tr>
			<td style="border-style: none; border-color: inherit; border-width: 0; text-align: left; width: 1057px;" align="left" valign="top">
				<asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="X-Small" Text="Administracion de Usuarios"></asp:Label>
			</td>
		</tr>
		<tr>
			<td>
				<table style="width: 63%; font-family: Arial, Helvetica, sans-serif; font-size: x-small" bgcolor="#E5E5E5">
					<tr>
						<td style="width: 56px; text-align: right;">
							Cuenta
						</td>
						<td style="width: 126px; text-align: left">
							<asp:TextBox ID="txt_cuenta" runat="server" Height="16px" MaxLength="9" Width="93px" TabIndex="1" AutoPostBack="True" BackColor="#0099FF" ForeColor="White" OnTextChanged="txt_cuenta_Leave" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"></asp:TextBox>
						</td>
						<td style="width: 15px; text-align: right">
							Nombre
						</td>
						<td style="text-align: left; width: 128px;">
							<asp:TextBox ID="txt_nombre" runat="server" Height="16px" Width="216px" MaxLength="50" TabIndex="2" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"></asp:TextBox>
						</td>
						<td style="width: 15px; text-align: right">
							Empresa
						</td>
						<td style="text-align: left;">
							<asp:DropDownList ID="dl_cliente" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="138px" TabIndex="7" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" OnSelectedIndexChanged="dl_cliente_SelectedIndexChanged">
							</asp:DropDownList>
						</td>
					</tr>
					<tr>
						<td style="width: 56px; text-align: right; height: 20px;">
							Clave
						</td>
						<td style="width: 126px; text-align: left; height: 20px;">
							<asp:TextBox ID="txt_clave" runat="server" Height="16px" MaxLength="10" Width="93px" TabIndex="3" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"></asp:TextBox>
						</td>
						<td style="width: 15px; text-align: right; height: 20px;">
							Telefono
						</td>
						<td style="text-align: left; width: 128px; height: 20px;">
							<asp:TextBox ID="txt_telefono" runat="server" Height="16px" MaxLength="10" Width="121px" TabIndex="4" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"></asp:TextBox>
						</td>
						<td style="width: 15px; text-align: right; height: 20px;">
							Anexo
						</td>
						<td style="text-align: left; height: 20px;">
							<asp:TextBox ID="txt_anexo" runat="server" Height="16px" Width="63px" MaxLength="4" TabIndex="5" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"></asp:TextBox>
						</td>
					</tr>
					<tr>
						<td style="width: 56px; text-align: right;">
							Correo
						</td>
						<td style="width: 126px; text-align: left">
							<asp:TextBox ID="txt_correo" runat="server" Height="17px" MaxLength="50" Width="125px" TabIndex="6" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"></asp:TextBox>
						</td>
						<td style="width: 15px; text-align: right">
							Nivel Consulta
						</td>
						<td style="text-align: left; width: 128px;">
							<asp:DropDownList ID="dl_nivel" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="138px" TabIndex="7" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small">
							</asp:DropDownList>
						</td>
						<td>
							Intentos
						</td>
						<td style="text-align: left;">
							<asp:TextBox ID="txt_intentos" runat="server" Height="16px" Width="64px" MaxLength="50" TabIndex="8" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"></asp:TextBox>
						</td>
					</tr>
					<tr>
						<td>
							Usuario NAV
						</td>
						<td style="text-align: left;">
							<asp:TextBox ID="usuanav" runat="server" Height="16px" Width="64px" MaxLength="50" TabIndex="8" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"></asp:TextBox>
						</td>
					</tr>
					<tr>
						<td style="text-align: right;">
							Perfil
						</td>
						<td>
							<asp:DropDownList ID="dl_perfil" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="138px" TabIndex="7" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small">
							</asp:DropDownList>
						</td>
						<td colspan="2">
							<asp:CheckBox ID="chk_permite_eliminar" runat="server" 
								Text="Puede eliminar operaciones" 
								oncheckedchanged="chk_permite_eliminar_CheckedChanged" />
						</td>
						<td colspan="4">
							<asp:checkbox id="chk_permite_pagar" runat="server" 
								text="Puede Pagar operaciones" 
								oncheckedchanged="chk_permite_pagar_CheckedChanged" />
						</td>
					</tr>
				</table>
				<asp:Button CssClass="button" ID="Button1" runat="server"  Text="Guardar" OnClick="Button1_Click" TabIndex="16" />
				<%--<div id="MensajeAlerta" class=mensaje name="mensaje de alerta" text="mensaje de alerta">
					<!--boton para ocultar/cerrar el mensaje-->
					<input type="button" value="&#x2716;" class="boton_cerrar" onclick="document.getElementById('MensajeAlerta').style.display='none';">
				</div>--%>
				<%--<cc1:ConfirmButtonExtender  ID="Button1_ConfirmButtonExtender" runat="server" TargetControlID="Button1" ConfirmText="¿Esta seguro de ingresar un nuevo Usuario?">
				</cc1:ConfirmButtonExtender>--%>
				<asp:Button CssClass="button" ID="Button2" runat="server"  OnClick="Button2_Click" Text="Limpiar" />
			</td>
		</tr>
		<tr>
			<td>
				<table style="width: 12%">
					<tr>
						<td style="width: 33px" title="Clientes">
								<asp:hyperlink id="ib_clientes" runat="server" tooltip="Clientes por Usuario" class="fancybox fancybox.iframe"
									 visible="false" imageurl="../imagenes/sistema/static/edi72_ejecutivo.gif"> 
								</asp:hyperlink>
							</td>
						
						<td style="width: 37px">
							<asp:hyperlink id="ib_operacion" runat="server" tooltip="Tipo Operacion" class="fancybox fancybox.iframe"
								visible="false" imageurl="../imagenes/sistema/static/carro2.jpg">
							</asp:hyperlink>
						</td>
						<td style="width: 37px">
							<asp:imagebutton id="ib_modulo" runat="server" imageurl="../imagenes/sistema/static/images.jpg"
								height="36px" width="49px" visible="False" data-fancybox-type="iframe" cssclass="fancybox fancybox.iframe"
								onclick="ib_modulo_Click" tooltip="Modulos" />
						</td>
						<td style="width: 21px">
							<asp:hyperlink id="ib_sucursal" runat="server" tooltip="Sucursales" class="fancybox fancybox.iframe"
								visible="false" imageurl="../imagenes/sistema/static/edificio1.jpg">
							</asp:hyperlink>
						</td>
                        <td style="width: 33px" title="Clientes">
								<asp:hyperlink id="hl_usuarioEstado" runat="server" tooltip="Estados por Usuario" class="fancybox fancybox.iframe"
									 visible="false" imageurl="../imagenes/sistema/static/amarillo.png"> 
								</asp:hyperlink>
							</td>
						<td style="width: 33px">
							<asp:imagebutton id="ib_perfil" runat="server" imageurl="../imagenes/sistema/static/llave1.gif"
								height="36px" width="42px" visible="False" 
								tooltip="Acceso Perfil" onclick="ib_perfil_Click" />
						</td>
						<td style="width: 33px">
							<asp:imagebutton id="ib_cuenta_cte" runat="server" imageurl="../imagenes/sistema/static/cta_cte.jpg"
								height="36px" width="42px" visible="False" tooltip="Acceso Cuenta Corriente"
								data-fancybox-type="iframe" cssclass="fancybox fancybox.iframe" onclick="ib_cuenta_cte_Click" />
						</td>
						<td style="width: 33px">
							<asp:imagebutton id="ib_movimiento" runat="server" imageurl="../imagenes/sistema/static/movimiento.jpg"
								height="36px" width="42px" visible="False" tooltip="Acceso a Movimientos" data-fancybox-type="iframe"
								cssclass="fancybox fancybox.iframe" onclick="ib_movimiento_Click" />
						</td>
						
						<td style="width: 33px">
							<asp:imagebutton id="id_usuariofamiliacliente" runat="server" imageurl="../imagenes/sistema/static/movimiento.jpg"
								height="36px" width="42px" visible="False" data-fancybox-type="iframe" cssclass="fancybox fancybox.iframe"
								tooltip="Acceso a Movimientos" onclick="ib_movimiento_Click" />
						</td>
						<td style="width: 33px">
							<asp:ImageButton ID="ib_financieraus" runat="server" data-fancybox-type="iframe" CssClass="fancybox fancybox.iframe" 
							ImageUrl="../imagenes/sistema/static/financiera.png" Height="36px" Width="42px" Visible="False" ToolTip="Acceso a Movimientos"
							 OnClick="ib_financieraus_Click" />
						</td>
					</tr>
				</table>
			</td>
		</tr>
		<tr>
			<td>
				<table>
					<tr>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small">
							Empresa
						</td>
						<td>
							<asp:DropDownList ID="dl_Fcliente" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="138px" TabIndex="7" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
							</asp:DropDownList>
						</td>
					</tr>
				</table>
			</td>
		</tr>
		<tr>
			<td>
				<asp:GridView    ID="gr_dato" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Names="Arial" Font-Size="X-Small" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="gr_dato_SelectedIndexChanged">
					<RowStyle BackColor="#EFF3FB" />
					<Columns>
						<asp:BoundField AccessibleHeaderText="cuenta" DataField="cuenta" HeaderText="cuenta">
							<ControlStyle Height="0px" Width="0px" />
						</asp:BoundField>
						<asp:BoundField AccessibleHeaderText="nombre" DataField="nombre" HeaderText="nombre" />
						<asp:BoundField AccessibleHeaderText="nivel" DataField="nivel" HeaderText="nivel" />
						<asp:BoundField AccessibleHeaderText="perfil" DataField="perfil" HeaderText="perfil" />
						<asp:CommandField   FooterStyle-CssClass=button SelectText="editar" ShowSelectButton="True" ButtonType="Button">
							<ControlStyle Font-Names="Arial" Font-Size="X-Small" />
						</asp:CommandField>
					</Columns>
					<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
					<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
					<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
					<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
					<EditRowStyle BackColor="#2461BF" />
					<AlternatingRowStyle BackColor="White" />
				</asp:GridView>
			</td>
		</tr>
	</table>
</asp:Content>
