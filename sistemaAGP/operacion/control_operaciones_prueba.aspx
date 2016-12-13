<%@ Page Title="Control de Operaciones AGP S.A. Prueba" Language="C#" MasterPageFile="~/AGP.Master" AutoEventWireup="true" CodeBehind="control_operaciones_prueba.aspx.cs" Inherits="sistemaAGP.control_operaciones_prueba" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/controles/wucPanelControl.ascx" TagName="PanelControl" TagPrefix="agp" %>
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
	<script type="text/javascript">
		function confirmarEliminar() {
			if (confirm("Desea eliminar la operacion seleccionada?") == true) {
				return true;
			} else {
				return false;
			}
		}
	</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoCentral" runat="server">
    <asp:UpdatePanel ID="up_arriba" runat="server">
		<ContentTemplate>
			<div id="title-nomina" style="display: none;">
				Nómina por Operaciones
			</div>
			<div id="title-cargar" style="display: none;">
				Crear Carpeta Digital
			</div>
			<div id="title-cdigital" style="display: none;">
				Documentos Carpeta Digital
			</div>
			<div id="title-work" style="display: none;">
				Estado Operación
			</div>
			<div id="title-poliza" style="display: none;">
				Pólizas SOAP
			</div>
			<div id="title-solicrc" style="display: none;">
				Solicitudes SRCeI
			</div>
			<div id="title-gastos" style="display: none;">
				Gastos por Operación
			</div>
			<div id="title-pagos" style="display: none;">
				Pagos por Operación
			</div>
			<div style="background-color: #507cd1; font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #ffffff;">
				<table>
					<tr>
						<td style="vertical-align: middle;">
							<strong>Cliente</strong>
						</td>
						<td style="vertical-align: middle;">
							<asp:DropDownList ID="dl_cliente" runat="server" AutoPostBack="true" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #000000; width: 250px;" OnSelectedIndexChanged="dl_cliente_SelectedIndexChanged">
							</asp:DropDownList>
						</td>
						<td style="vertical-align: middle;">
							<strong>Familia AGP</strong>
						</td>
						<td style="vertical-align: middle;">
							<asp:DropDownList ID="dl_familia" runat="server" AutoPostBack="true" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #000000; width: 200px;" OnSelectedIndexChanged="dl_familia_SelectedIndexChanged">
							</asp:DropDownList>
							<asp:RequiredFieldValidator ID="rfv_familia" runat="server" ControlToValidate="dl_familia" ErrorMessage="Familia AGP" Text="*" InitialValue="0" SetFocusOnError="true" ValidationGroup="filtros"></asp:RequiredFieldValidator>
						</td>
						<td style="vertical-align: middle;">
							<strong>Producto</strong>
						</td>
						<td style="vertical-align: middle;">
							<asp:DropDownList ID="dl_producto" runat="server" AutoPostBack="true" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #000000; width: 200px;" OnSelectedIndexChanged="dl_producto_SelectedIndexChanged">
							</asp:DropDownList>
							<asp:RequiredFieldValidator ID="rfv_producto" runat="server" ControlToValidate="dl_producto" ErrorMessage="Producto" Text="*" InitialValue="0" SetFocusOnError="true" ValidationGroup="work"></asp:RequiredFieldValidator>
						</td>
					</tr>
					<tr>
						<td style="vertical-align: middle;">
							<strong>Módulo</strong>
						</td>
						<td style="vertical-align: middle;">
							<asp:DropDownList ID="dl_modulo" runat="server" AutoPostBack="true" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #000000; width: 140px;" OnSelectedIndexChanged="dl_modulo_SelectedIndexChanged">
							</asp:DropDownList>
						</td>
						<td style="vertical-align: middle;">
							<strong>Sucursal</strong>
						</td>
						<td style="vertical-align: middle;">
							<asp:DropDownList ID="dl_sucursal" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #000000; width: 140px;">
							</asp:DropDownList>
						</td>
						<td style="vertical-align: middle;">
							<strong>Nº Operacion</strong>
						</td>
						<td style="vertical-align: middle;">
							<asp:TextBox ID="txt_operacion" runat="server" AutoPostBack="true" CausesValidation="true" ValidationGroup="filtros" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #ffffff; background-color: #3399ff; width: 80px;" OnTextChanged="txt_operacion_TextChanged"></asp:TextBox>
							<asp:CheckBox ID="chk_agrupar" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #ffffff;" Text="Agrupar" />
							<ajaxToolkit:FilteredTextBoxExtender ID="fte_operacion" runat="server" TargetControlID="txt_operacion" FilterType="Custom, Numbers" ValidChars="">
							</ajaxToolkit:FilteredTextBoxExtender>
						</td>
					</tr>
					<tr>
						<td style="vertical-align: middle;">
							<strong>RUT Adquirente</strong>
						</td>
						<td style="vertical-align: middle;">
							<asp:TextBox ID="txt_rut" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 80px;" MaxLength="8" ToolTip="Ingrese el RUT sin puntos ni digito verificador"></asp:TextBox>
							<ajaxToolkit:FilteredTextBoxExtender ID="fte_rut" runat="server" TargetControlID="txt_rut" FilterType="Custom, Numbers" ValidChars="">
							</ajaxToolkit:FilteredTextBoxExtender>
						</td>
						<td style="vertical-align: middle;">
							<strong>Nº Factura</strong>
						</td>
						<td style="vertical-align: middle;">
							<asp:TextBox ID="txt_factura" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 135px;" MaxLength="8"></asp:TextBox>
							<ajaxToolkit:FilteredTextBoxExtender ID="fte_factura" runat="server" TargetControlID="txt_factura" FilterType="Custom, Numbers" ValidChars="">
							</ajaxToolkit:FilteredTextBoxExtender>
						</td>
						<td style="vertical-align: middle;">
							<strong>Nº Cliente</strong>
						</td>
						<td style="vertical-align: middle;">
							<asp:TextBox ID="txt_cliente" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 135px;"></asp:TextBox>
						</td>
					</tr>
					<tr>
						<td style="vertical-align: middle;">
							<strong>Patente</strong>
						</td>
						<td style="vertical-align: middle;">
							<asp:TextBox ID="txt_patente" runat="server" MaxLength="6" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 60px;"></asp:TextBox>
						</td>
						<td style="vertical-align: middle;">
							<strong>Desde</strong>
						</td>
						<td style="vertical-align: middle;">
							<asp:TextBox ID="txt_desde" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 75px;"></asp:TextBox>
							<asp:ImageButton ID="ib_desde" runat="server" ImageUrl="../imagenes/sistema/gif/calendario.gif" />
							<ajaxToolkit:CalendarExtender ID="cal_desde" runat="server" TargetControlID="txt_desde" CssClass="calendario" Format="dd/MM/yyyy" PopupButtonID="ib_desde" TodaysDateFormat="dd/MM/yyyy" OnClientDateSelectionChanged="checkDate" />
						</td>
						<td style="vertical-align: middle;">
							<strong>Hasta</strong>
						</td>
						<td style="vertical-align: middle;">
							<asp:TextBox ID="txt_hasta" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 75px;"></asp:TextBox>
							<asp:ImageButton ID="ib_hasta" runat="server" ImageUrl="../imagenes/sistema/gif/calendario.gif" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" />
							<ajaxToolkit:CalendarExtender ID="cal_hasta" runat="server" TargetControlID="txt_hasta" CssClass="calendario" Format="dd/MM/yyyy" PopupButtonID="ib_hasta" TodaysDateFormat="dd/MM/yyyy" OnClientDateSelectionChanged="checkDate" />
						</td>
					</tr>
					<tr>
						<td style="vertical-align: middle;">
							<strong>Saldo Operación</strong>
						</td>
						<td style="vertical-align: middle;">
							<asp:DropDownList ID="dl_saldo" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #000000; width: 140px;">
							</asp:DropDownList>
						</td>
						<td style="vertical-align: middle;">
							<strong>Chassis</strong>
						</td>
						<td style="vertical-align: middle;">
							<asp:TextBox ID="txt_chassis" runat="server" Style="font-family: Arial, Helvetica, sans-serif;
								font-size: x-small; width: 135px;" MaxLength="30"></asp:TextBox>
						</td>
						<td style="vertical-align: middle;">
							<strong>Motor</strong>
						</td>
						<td style="vertical-align: middle;">
							<asp:TextBox ID="txt_motor" runat="server" Style="font-family: Arial, Helvetica, sans-serif;
								font-size: x-small; width: 135px;" MaxLength="30"></asp:TextBox>
						</td>

					</tr>
					<tr>
					<td style="vertical-align: middle;">
							<strong>RUT Para</strong>
						</td>
						<td style="vertical-align: middle;">
							<asp:TextBox ID="txt_rut_para" runat="server" 
								Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 80px;" 
								MaxLength="8" ToolTip="Ingrese el RUT sin puntos ni digito verificador" 
								ontextchanged="txt_rut_para_TextChanged"></asp:TextBox>
							<ajaxToolkit:FilteredTextBoxExtender ID="fte_rut_para" runat="server" TargetControlID="txt_rut_para" FilterType="Custom, Numbers" ValidChars="">
							</ajaxToolkit:FilteredTextBoxExtender>
						</td>

						<td style="vertical-align: middle;">
							<asp:CheckBox ID="chk_proceso" runat="server" Style="font-family: Arial, Helvetica, sans-serif;
								font-size: x-small; color: #ffffff;" Text="En Proceso" Checked="True" />
						</td>
						<td>
							<asp:Label ID="lbl_count" runat="server" Text="Label" Visible="false" ForeColor="White"
								Font-Size="X-Large"></asp:Label>
						</td>
					</tr>
				</table>
				<asp:ValidationSummary ID="vs_filtros" runat="server" DisplayMode="BulletList" HeaderText="Verifique los siguientes datos para realizar la búsqueda de operaciones:" ShowMessageBox="true" ShowSummary="false" ValidationGroup="filtros" />
			</div>
			<div style="background-color: #cccccc; vertical-align: middle; padding: 2px;">
				<asp:Panel ID="pnl_flujo" runat="server" Style="display: none; vertical-align: middle; font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #ffffff; margin: 0 5px 0 0;">
					<strong>Flujo de Trabajo</strong>
					<asp:DropDownList ID="dpl_estado" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; background-color: #ffffff; width: 250px;">
					</asp:DropDownList>


                    <asp:RadioButton ID="rb_blanco" runat="server" BackColor="White" OnCheckedChanged="rb_blancochangen"
						AutoPostBack="true" />
					<asp:RadioButton ID="rb_rojo" runat="server" BackColor="Red" OnCheckedChanged="rb_rojochangen"
						AutoPostBack="true" />
					<asp:RadioButton ID="rb_amarillo" runat="server" BackColor="Yellow" OnCheckedChanged="rb_amarrillochangen" AutoPostBack="true" />
					<asp:RadioButton ID="rb_verde" runat="server" BackColor="Green" OnCheckedChanged="rb_verdechangen"
						AutoPostBack="true" />

                      

				</asp:Panel>
				<asp:Panel ID="pnl_nomina" runat="server" Style="display: none; vertical-align: middle; font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #ffffff;">
					<strong>Nómina</strong>
					<asp:DropDownList ID="dpl_nomina" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; background-color: #ffffff; width: 180px;">
					</asp:DropDownList>
					<asp:RequiredFieldValidator ID="rfv_id_nomina" runat="server" ControlToValidate="dpl_nomina" ErrorMessage="Tipo Nómina" Text="*" InitialValue="0" SetFocusOnError="true" ValidationGroup="nomina"></asp:RequiredFieldValidator>
					<asp:TextBox ID="txt_nomina" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; background-color: #ffffff; width: 80px;"></asp:TextBox>
					<asp:RequiredFieldValidator ID="rfv_nomina" runat="server" ControlToValidate="txt_nomina" ErrorMessage="Nómina" Text="*" InitialValue="" SetFocusOnError="true" ValidationGroup="nomina"></asp:RequiredFieldValidator>
					<asp:ImageButton ID="btn_nomina_pdf" runat="server" AlternateText="Exportar" ImageAlign="AbsMiddle" ImageUrl="~/imagenes/sistema/static/panel_control/pdf.png" ValidationGroup="nomina" Style="background-color: #ffffff; padding: 2px; border: 1px solid #cccccc;" onclick="btn_nomina_pdf_Click" />
					<asp:ValidationSummary ID="vs_nomina" runat="server" DisplayMode="BulletList" HeaderText="Verifique los siguientes datos para buscar la nómina" ShowMessageBox="true" ShowSummary="false" ValidationGroup="nomina" />
				</asp:Panel>
				<div style="display: inline; vertical-align: middle; font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #ffffff; margin: 0 5px 0 0;">
					<asp:ImageButton ID="ib_buscar" runat="server" CausesValidation="true" AlternateText="Buscar" ImageAlign="AbsMiddle" ImageUrl="~/imagenes/sistema/static/panel_control/lupa.png" Style="background-color: #ffffff; padding: 2px; border: 1px solid #cccccc;" OnClick="ib_buscar_Click" ValidationGroup="filtros" />
					<asp:ImageButton ID="ib_exportar" runat="server" AlternateText="Exportar" 
                        ImageAlign="AbsMiddle" 
                        ImageUrl="~/imagenes/sistema/static/panel_control/excel.png" 
                        Style="background-color: #ffffff; padding: 2px; border: 1px solid #cccccc;" 
                        onclick="ib_exportar_Click" />
				</div>
			</div>
		</ContentTemplate>
	</asp:UpdatePanel>
	<asp:UpdatePanel ID="up_grilla" runat="server">
		<ContentTemplate>
			<%--<agp:PanelControl id="Panelcontrol" runat="server" Titulo="Panel de Control"></agp:PanelControl>--%>
			<asp:Panel ID="pnl_acciones" runat="server" Style="background-color: #507cd1; display: none;">
				<div style="margin: 0 auto; width: 500px;">
					<table style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; background-color: #507cd1; color: #ffffff;">
						<tr>
							<td style="padding: 4px; width: 100px; text-align: center;">
								<asp:ImageButton ID="ib_cargar_gastos" runat="server" ImageUrl="~/imagenes/sistema/static/panel_control/gastos.png" ToolTip="Pagar Operación" Style="background-color: #ffffff; padding: 2px; border: 1px solid #cccccc;" OnClick="ib_cargar_gastos_Click" />
							</td>
							<td style="padding: 4px; width: 100px; text-align: center;">
								<asp:ImageButton ID="ib_pago_operacion" runat="server" ImageUrl="~/imagenes/sistema/static/panel_control/ingresos.png" ToolTip="Pagar Operación" Style="background-color: #ffffff; padding: 2px; border: 1px solid #cccccc;" OnClick="ib_pago_operacion_Click" />
							</td>
							<td style="padding: 0 4px; width: 100px; text-align: center;">
								<asp:ImageButton ID="ib_work" runat="server" CausesValidation="true" ValidationGroup="work" ImageUrl="~/imagenes/sistema/static/panel_control/wflow.png" ToolTip="Cambiar Etapa Workflow" Style="background-color: #ffffff; padding: 2px; border: 1px solid #cccccc;" OnClick="ib_work_Click" />
								<asp:ValidationSummary ID="vs_work" runat="server" DisplayMode="BulletList" HeaderText="Verifique los siguientes datos para generar el cambio de workflow:" ShowMessageBox="true" ShowSummary="false" ValidationGroup="work" />
							</td>
							<td style="padding: 4px; width: 100px; text-align: center;">
								<asp:ImageButton ID="ib_nomina" runat="server" ImageUrl="~/imagenes/sistema/static/panel_control/nominas.png" ToolTip="Generar Nómina" Style="background-color: #ffffff; padding: 2px; border: 1px solid #cccccc;" OnClick="ib_nomina_Click" Visible ="false" />
							</td>
							<td style="padding: 4px; width: 100px; text-align: center;">
								<asp:ImageButton ID="ib_repertorio" runat="server" ImageUrl="~/imagenes/sistema/static/panel_control/repertorio.png" ToolTip="Solicitar Repertorio" Style="background-color: #ffffff; padding: 2px; border: 1px solid #cccccc;" OnClick="ib_repertorio_Click" />
							</td>
                            <td style="padding: 4px; width: 100px; text-align: center;">
								<asp:ImageButton ID="ib_modifica_producto" runat="server" ImageUrl="~/imagenes/sistema/static/carrito.png" ToolTip="Modifica Productos" Style="background-color: #ffffff; padding: 2px; border: 1px solid #cccccc;" OnClick="ib_modifica_producto_Click" />
							</td>
						</tr>
						<tr>
							<td style="text-align: center;">
								<strong>Cargar Gastos</strong>
							</td>
							<td style="text-align: center;">
								<strong>Pagar Operaciones</strong>
							</td>
							<td style="text-align: center;">
								<strong>Cambiar Workflow</strong>
							</td>
							<td style="text-align: center;">
								<strong>......</strong>
							</td>
							<td style="text-align: center;">
								<strong>Solicitar Repertorio</strong>
							</td>
                            <td style="text-align: center;">
								<strong>Modifica Producto</strong>
							</td>
						</tr>
					</table>
					<ajaxToolkit:ConfirmButtonExtender ID="cfe_cargar_gastos" runat="server" ConfirmText="¿Está seguro de cargar automáticamente los gastos a las operaciones seleccionadas?" TargetControlID="ib_cargar_gastos">
					</ajaxToolkit:ConfirmButtonExtender>
					<ajaxToolkit:ConfirmButtonExtender ID="cfe_repertorio" runat="server" TargetControlID="ib_repertorio" ConfirmText="¿Esta seguro de solicitar repertorio para las operaciones marcadas?">
					</ajaxToolkit:ConfirmButtonExtender>
				</div>
			</asp:Panel>
		</ContentTemplate>
	</asp:UpdatePanel>
	<asp:UpdatePanel ID="up_popup" runat="server" UpdateMode="Conditional">
		<ContentTemplate>
			<asp:Button ID="bt_oculto_movimiento" runat="server" Style="display: none;" />
			<asp:Button ID="bt_oculto_work" runat="server" Style="display: none;" />
			<asp:Button ID="bt_oculto_nomina" runat="server" Style="display: none;" />
            <asp:Button ID="bt_oculto_modifica" runat="server" Style="display: none;" />
			<asp:Panel ID="pnl_movimiento" runat="server" Style="padding: 10px; background-color: #507cd1;">
				<asp:UpdatePanel ID="up_movimiento" runat="server">
					<ContentTemplate>
						<table style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; background-color: #507cd1; color: #ffffff;">
							<tr>
								<td style="padding: 2px;">
									<strong>Banco</strong>
								</td>
								<td style="padding: 2px;">
									<asp:DropDownList ID="dl_financiera" runat="server" AutoPostBack="true" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #000000; width: 160px;" OnSelectedIndexChanged="dl_financiera_SelectedIndexChanged">
									</asp:DropDownList>
								</td>
								<td style="padding: 2px;">
									<strong>Nº Cuenta</strong>
								</td>
								<td style="padding: 2px;">
									<asp:DropDownList ID="dl_cuenta" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #000000; width: 140px;">
									</asp:DropDownList>
								</td>
							</tr>
							<tr>
								<td style="padding: 2px;">
									<strong>Tipo Operacion</strong>
								</td>
								<td style="padding: 2px;">
									<asp:DropDownList ID="dl_tipo_operacion" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #000000; width: 160px;">
									</asp:DropDownList>
								</td>
								<td style="padding: 2px;">
									<strong>Fecha Pago</strong>
								</td>
								<td style="padding: 2px;">
									<asp:TextBox ID="txt_fecha_pago" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #000000; width: 75px;"></asp:TextBox>
									<asp:ImageButton ID="ib_fecha_pago" runat="server" ImageUrl="~/imagenes/sistema/gif/calendario.gif" />
									<ajaxToolkit:CalendarExtender ID="cal_fecha_pago" runat="server" TargetControlID="txt_fecha_pago" CssClass="calendario" Format="dd/MM/yyyy" PopupButtonID="ib_fecha_pago" />
								</td>
							</tr>
							<tr>
								<td style="padding: 2px;">
									Documento Especial (G5)
								</td>
								<td style="padding: 2px;">
									<asp:TextBox ID="txt_especial" runat="server" MaxLength="20" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #000000; width: 150px;"></asp:TextBox>
								</td>
								<td style="padding: 2px;">
									<strong>Total a Pagar</strong>
								</td>
								<td style="text-align: right; padding: 2px;">
									<strong>
										<asp:Label ID="lbl_total_gastos" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #ffffff;">0</asp:Label>
									</strong>
								</td>
							</tr>
						</table>
					</ContentTemplate>
					<Triggers>
						<asp:AsyncPostBackTrigger ControlID="dl_financiera" />
					</Triggers>
				</asp:UpdatePanel>
				<div style="text-align: center; width: 300px; margin: 0 auto;">
					<asp:Button ID="bt_graba_movimiento" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; font-weight: bold; width: 100px; margin-right: 4px;" Text="Pagar" onclick="bt_graba_movimiento_Click" />
					<ajaxToolkit:ConfirmButtonExtender ID="cbe_graba_movimiento" runat="server" TargetControlID="bt_graba_movimiento" ConfirmText="¿Esta seguro de pagar por completo las operaciones marcadas?">
					</ajaxToolkit:ConfirmButtonExtender>
					<asp:Button ID="bt_cancela_movimiento" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; font-weight: bold; width: 100px; margin-left: 4px;" Text="Cancelar" />
				</div>
			</asp:Panel>
			<ajaxToolkit:ModalPopupExtender ID="mpe_movimiento" runat="server" BackgroundCssClass="modalBackground" CancelControlID="bt_cancela_movimiento" PopupControlID="pnl_movimiento" TargetControlID="bt_oculto_movimiento">
			</ajaxToolkit:ModalPopupExtender>
			<asp:Panel ID="pnl_work" runat="server" Style="padding: 10px; background-color: #507cd1;">
				<table style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; background-color: #507cd1; color: White;">
					<tr>
						<td>
							Flujo de trabajo
						</td>
						<td>
							<asp:DropDownList ID="dl_estado" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #000000; width: 250px;">
							</asp:DropDownList>
						</td>
					</tr>
					<tr>
						<td>
							Observaciones
						</td>
						<td>
							<asp:TextBox ID="txt_obs" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #000000; width: 350px;"></asp:TextBox>
						</td>
					</tr>
					<tr>
						<td colspan="2" style="text-align: center;">
							<asp:Button ID="bt_guardar_work" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; font-weight: bold; width: 100px; margin-right: 4px;" Text="Guardar" onclick="bt_guardar_work_Click" />
							<ajaxToolkit:ConfirmButtonExtender ID="cbe_guardar_work" runat="server" TargetControlID="bt_guardar_work" ConfirmText="¿Esta seguro de cambiar el estado de Workflow para las operaciones marcadas?">
							</ajaxToolkit:ConfirmButtonExtender>
							<asp:Button ID="bt_cancelar_work" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; font-weight: bold; width: 100px; margin-left: 4px;" Text="Cancelar" />
						</td>
					</tr>
				</table>
			</asp:Panel>
			<ajaxToolkit:ModalPopupExtender ID="mpe_work" runat="server" BackgroundCssClass="modalBackground" CancelControlID="bt_cancelar_work" PopupControlID="pnl_work" TargetControlID="bt_oculto_work">
			</ajaxToolkit:ModalPopupExtender>
			<asp:Panel ID="pnl_nominas" runat="server" Style="padding: 10px; background-color: #507cd1;">
				<table style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; background-color: #507cd1; color: White;">
					<tr>
						<td>
							Nómina
						</td>
						<td>
							<asp:DropDownList ID="dl_nomina" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #000000; width: 250px;">
							</asp:DropDownList>
						</td>
					</tr>
					<tr>
						<td colspan="2" style="text-align: center;">
							<asp:Button ID="bt_guardar_nomina" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; font-weight: bold; width: 100px; margin-right: 4px;" Text="Guardar" onclick="bt_guardar_nomina_Click" />
							<ajaxToolkit:ConfirmButtonExtender ID="cfe_guardar_nomina" runat="server" TargetControlID="bt_guardar_nomina" ConfirmText="¿Esta seguro de generar la nómina para las operaciones marcadas?">
							</ajaxToolkit:ConfirmButtonExtender>
							<asp:Button ID="bt_cancelar_nomina" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; font-weight: bold; width: 100px; margin-left: 4px;" Text="Cancelar" />
						</td>
					</tr>
				</table>
			</asp:Panel>
			<ajaxToolkit:ModalPopupExtender ID="mpe_nominas" runat="server" BackgroundCssClass="modalBackground" CancelControlID="bt_cancelar_nomina" PopupControlID="pnl_nominas" TargetControlID="bt_oculto_nomina">
			</ajaxToolkit:ModalPopupExtender>
		
        
        <asp:Panel ID="pnl_modifica_producto" runat="server" Style="padding: 10px; background-color: #507cd1;">
				<table style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; background-color: #507cd1; color: White;">
					<tr>
						<td>
							Producto
						</td>
						<td>
							<asp:DropDownList ID="dl_producto_cambio" runat="server" 
                                Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #000000; width: 250px;">
							</asp:DropDownList>
						</td>
					</tr>
					<tr>
						<td colspan="2" style="text-align: center;">
							<asp:Button ID="bt_guarda_modifica" runat="server" 
                                Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; font-weight: bold; width: 100px; margin-right: 4px;" 
                                Text="Guardar" onclick="bt_guardar_modifica_Click" />
							<ajaxToolkit:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="bt_guarda_modifica" ConfirmText="¿Esta seguro de generar la nómina para las operaciones marcadas?">
							</ajaxToolkit:ConfirmButtonExtender>
							<asp:Button ID="bt_cancela_modifica" runat="server" 
                                Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; font-weight: bold; width: 100px; margin-left: 4px;" 
                                Text="Cancelar" />
						</td>
					</tr>
				</table>
			</asp:Panel>
        <ajaxToolkit:ModalPopupExtender ID="mpe_modifica" runat="server" BackgroundCssClass="modalBackground" CancelControlID="bt_cancela_modifica" PopupControlID="pnl_modifica_producto" TargetControlID="bt_oculto_modifica">
			</ajaxToolkit:ModalPopupExtender>
        </ContentTemplate>
		<Triggers>
			<asp:AsyncPostBackTrigger ControlID="dl_producto" />
			<asp:AsyncPostBackTrigger ControlID="dl_familia" />
			<asp:AsyncPostBackTrigger ControlID="ib_cargar_gastos" />
			<asp:AsyncPostBackTrigger ControlID="ib_pago_operacion" />
			<asp:AsyncPostBackTrigger ControlID="ib_work" />
			<asp:AsyncPostBackTrigger ControlID="ib_nomina" />
            <asp:AsyncPostBackTrigger ControlID="ib_modifica_producto" />
		</Triggers>
	</asp:UpdatePanel>
</asp:Content>
