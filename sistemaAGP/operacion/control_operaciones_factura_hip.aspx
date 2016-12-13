<%@ Page Title="Control Factura de Operaciones AGP S.A." Language="C#" MasterPageFile="~/AGP.Master"
	AutoEventWireup="true" CodeBehind="control_operaciones_factura_hip.aspx.cs" Inherits="sistemaAGP.control_operaciones_factura_hip" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/controles/wucPersonaTransferencia.ascx" TagName="DatosPersona"
	TagPrefix="agp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMenu" runat="server">
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
		.style5
		{
			width: 169px;
		}
		.style6
		{
			width: 136px;
		}
		.style7
		{
			width: 74px;
		}
	</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoCentral" runat="server">
	<table style="width: 55%; height: 100%">
		<tr>
			<td class="style4" style="height: 74px" valign="top" align="left">
				<%--<asp:UpdatePanel ID="arriba" UpdateMode="Conditional" runat="server">
					<ContentTemplate>--%>
						<table style="width: 300; height: 32px;" >
							<tr>
								<td>
									<table style="width: 300; height: 32px;" bgcolor="#507CD1">
										<tr>
											<td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;
												height: 28px; color: #FFFFFF;">
												<b>Familia AGP</b>
											</td>
											<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 28px;
												width: 190px;">
												<b>
													<asp:DropDownList ID="dl_familia" runat="server" Font-Names="Arial" Font-Size="X-Small"
														Height="16px" Width="182px" TabIndex="1" Style="font-family: Arial, Helvetica, sans-serif;
														font-size: x-small; color: #000000;" AutoPostBack="True" OnSelectedIndexChanged="dl_familia_SelectedIndexChanged">
													</asp:DropDownList>
												</b>
											</td>
											<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 43px;">
												Cliente
											</td>
											<td>
												<asp:DropDownList ID="ddlCliente" runat="server" Font-Names="Arial" Font-Size="X-Small"
													Height="16px" Width="138px" Style="font-family: Arial, Helvetica, sans-serif;
													font-size: x-small" AutoPostBack="True" OnSelectedIndexChanged="ddlCliente_SelectedIndexChanged">
												</asp:DropDownList>
											</td>
										</tr>
										<tr>
											<td style="width: 74px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;
												height: 28px; color: #FFFFFF; text-align: left;">
												<b style="text-align: right">Nº Operacion</b>
											</td>
											<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 28px;">
												<asp:TextBox ID="txt_operacion" runat="server" Font-Names="Arial" Font-Size="X-Small"
													OnTextChanged="txt_operacion_TextChanged" Width="87px" AutoPostBack="True"></asp:TextBox>
											</td>
											<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;" class="style5">
												<asp:Label ID="lbl_nomina" runat="server" Style="color: #FFFFFF; text-align: right;"
													Text="Nómina"></asp:Label>
											</td>
											<td>
												<asp:DropDownList ID="dpl_nomina" runat="server" Font-Names="Arial" Font-Size="X-Small"
													Height="16px" Width="157px" OnSelectedIndexChanged="dpl_nomina_SelectedIndexChanged">
												</asp:DropDownList>
											</td>
											<td style="width: 74px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;
												height: 28px; color: #FFFFFF; text-align: left;">
												<b style="text-align: right">Nº Nomina</b>
											</td>
											<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 28px;">
												<asp:TextBox ID="txt_nomina" runat="server" Font-Names="Arial" Font-Size="X-Small"
													OnTextChanged="txt_nomina_TextChanged" Width="87px"></asp:TextBox>
											</td>
											<td style="text-align: center; height: 9px;" align="center" valign="middle">
												<asp:ImageButton ID="ib_buscar" runat="server" ImageUrl="../imagenes/sistema/gif/lupa.gif"
													Height="21px" Width="30px" OnClick="ib_buscar_Click" Style="text-align: center" />
											</td>
											<td style="width: 27px">
												<asp:ImageButton ID="btn_nomina_pdf0" runat="server" Height="24" ImageUrl="../imagenes/sistema/static/pdf.jpg"
													OnClick="btn_nomina_pdf_Click" Width="24" />
											</td>
										</tr>
									</table>
					<%--</ContentTemplate>
				</asp:UpdatePanel>--%>
			</td>
		</tr>
		<tr>
			<td>
				<table bgcolor="Gray">
					<tr>
						<td>
							<asp:Label ID="Label2" runat="server" Text="Seleccione Archivo Excel" Font-Bold="True"
								Width="149px"></asp:Label>
						</td>
						<td colspan="2">
							<asp:FileUpload ID="fileuploadExcel" runat="server" />
						</td>
						<td>
							<asp:Button ID="btnImport" runat="server" Text="Cargar Planilla" OnClick="btnImport_Click"
								Width="87px" Height="32px" />
						</td>
						<td colspan="2" style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;
							color: #FFFFFF; text-align: left;" class="style7">
							<asp:RadioButton ID="rdb_nomina" runat="server" AutoPostBack="true" CausesValidation="True"
								GroupName="total" Text="Nomina" OnCheckedChanged="rdb_nomina_CheckedChanged" />
							<asp:RadioButton ID="rdb_operacion" runat="server" AutoPostBack="true" GroupName="total" 
								Text="Operacion" oncheckedchanged="rdb_operacion_CheckedChanged" />
							<asp:Label ID="lbl_cantidad" runat="server" Text="" Font-Bold="True" ForeColor="Red"
								Width="149px"></asp:Label>
						</td>
						<td style="width: 81px; text-align: right; color: #FFFFFF;">
							<asp:Label ID="lbl_f_fac_oper" runat="server" Text="Fecha Factura" Visible="false"></asp:Label>
						</td>
						<td style="text-align: left; width: 110px;">
							<asp:TextBox ID="txt_fecha_fac_oper" runat="server" Height="16px" Visible="false"
								Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" TabIndex="2"
								Width="87px"></asp:TextBox>
							<asp:ImageButton ID="imgb_fecha_fac_oper" runat="server" Visible="false" ImageUrl="../imagenes/sistema/gif/calendario.gif"
								Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" Height="16px" />
							<ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_fecha_fac_oper"
								CssClass="calendario" Format="dd/MM/yyyy" PopupButtonID="imgb_fecha_fac_oper" />
						</td>
					</tr>
				</table>
			</td>
		</tr>
		<tr>
			<td>
				<table style="width: 100%; height: 264px;">
					<tr>
						<td style="width: 123px;" valign="top">
							<%--<asp:UpdatePanel ID="UpdatePanel2" UpdateMode="Conditional" runat="server">
								<ContentTemplate>--%>
									<asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" CellPadding="4"
										DataKeyNames="tipo_operacion" Font-Names="Arial" Font-Size="X-Small" ForeColor="#333333"
										GridLines="None" Height="50px" OnSelectedIndexChanged="gr_dato_SelectedIndexChanged"
										Width="634px" EnableModelValidation="True">
										<RowStyle BackColor="#EFF3FB" />
										<Columns>
											<asp:BoundField AccessibleHeaderText="id_solicitud" DataField="id_solicitud" HeaderText="id_solicitud" />
											<asp:BoundField AccessibleHeaderText="Nº Factura" DataField="numero_factura" HeaderText="Nº Factura" />
											<asp:BoundField AccessibleHeaderText="Operacion" DataField="tipo_operacion" HeaderText="Operacion" />
											<asp:BoundField AccessibleHeaderText="Cantidad Operaciones" DataField="cantidad_operaciones"
												HeaderText="Cant. Operaciones" />
											<asp:BoundField DataField="total_gasto" HeaderText="Total Gastos" />
										</Columns>
										<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
										<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
										<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
										<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
										<EditRowStyle BackColor="#2461BF" />
										<AlternatingRowStyle BackColor="White" />
									</asp:GridView>
								<%--</ContentTemplate>
							</asp:UpdatePanel>--%>
						</td>
					</tr>
				</table>
			</td>
		</tr>
	
	<tr>
	<td>
			<center>
				<asp:Panel ID="Panel1" runat="server" Visible="false">
					<table style="width: 26%; font-family: Arial, Helvetica, sans-serif; font-size: x-small;
						background-color: #507CD1; margin-right: 30px;">
						<tr>
							<td style="width: 81px; color: #FFFFFF;" class="style5">
								Tipo Facturacion
							</td>
							<td style="text-align: left; width: 110px;">
								<asp:DropDownList ID="DropDownList1" Visible="false" runat="server" AutoPostBack="True"
									OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
									<asp:ListItem>Electronica</asp:ListItem>
									<asp:ListItem>Manual</asp:ListItem>
								</asp:DropDownList>
							</td>		
						</tr>
					    <tr>
							<td style="width: 81px; color: #FFFFFF;" class="style5">
								N°Factura AGP
							</td>
							<td style="text-align: left; width: 110px;">
								<asp:TextBox ID="txt_fac_facturacion" runat="server" Font-Names="Arial" Font-Size="X-Small"
									Height="16px" MaxLength="30" OnTextChanged="txt_fac_TextChanged" TabIndex="3"
									Width="163px"></asp:TextBox>
							</td>
						</tr>
						<tr>
							<td style="width: 81px; color: #FFFFFF;" class="style5">
								Giro Tercera Persona
							</td>
							<td style="text-align: left; width: 110px;">
								<asp:TextBox ID="txt_orden_compra" runat="server" Font-Names="Arial" Font-Size="X-Small"
									Height="16px" MaxLength="30" OnTextChanged="txt_orden_compra_TextChanged" TabIndex="3"
									Width="214px"></asp:TextBox>
							</td>
						</tr>
						<tr>
							<td style="width: 81px; text-align: right; color: #FFFFFF;">
								Fecha Factura
							</td>
							<td style="text-align: left; width: 110px;">
								<asp:TextBox ID="txt_fecha_factura" runat="server" Height="16px" Style="font-family: Arial, Helvetica, sans-serif;
									font-size: x-small" TabIndex="2" Width="87px"></asp:TextBox>
								<asp:ImageButton ID="ib_fecha_factura" runat="server" ImageUrl="../imagenes/sistema/gif/calendario.gif"
									Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" Height="16px" />
								<ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txt_fecha_factura"
									CssClass="calendario" Format="dd/MM/yyyy" PopupButtonID="ib_fecha_factura" />
							</td>
						</tr>
						<tr>
							<td style="width: 81px; color: #FFFFFF;" class="style5">
								Observacion
							</td>
							<td style="text-align: left; width: 110px;">
								<asp:TextBox ID="txt_observacion" runat="server" Font-Names="Arial" Font-Size="X-Small"
									Height="16px" MaxLength="100" OnTextChanged="txt_observacion_TextChanged" TabIndex="3"
									Width="212px"></asp:TextBox>
							</td>
						</tr>
						<tr>
							<td style="width: 81px; color: #FFFFFF;" class="style5">
								Valor Neto
							</td>
							<td style="text-align: left; width: 110px;">
								<asp:TextBox ID="txt_neto" runat="server" Font-Names="Arial" Font-Size="X-Small"
									Height="16px" MaxLength="100" OnTextChanged="txt_valor_neto_TextChanged" TabIndex="3"
									Width="95px"></asp:TextBox>
							</td>
							<td>
								<asp:Button ID="Button4" runat="server" Font-Names="Arial" Font-Size="X-Small" Text="Aceptar"
									OnClick="Button4_Click" TabIndex="16" Style="margin-left: 0px" Width="53px" />
								<ajaxToolkit:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server" TargetControlID="Button4"
									ConfirmText="¿Esta seguro de Emitir Factura?">
								</ajaxToolkit:ConfirmButtonExtender>
							</td>
						</tr>
				</table>
			<agp:DatosPersona ID="DatosTercero" runat="server" Titulo="Factura a Tercero" HabilitarCompraPara="false" />
		</asp:Panel>
		</center> 
	</td> 
	</tr>
	<tr>
		<td>
			<table bgcolor="Gray">
				<tr>
					<td style="width: 170px">
						<asp:ImageButton ID="ib_nomina" runat="server" ImageUrl="../imagenes/sistema/static/documentos.gif"
							Height="21px" Width="30px" Style="text-align: center" OnClick="ib_nomina_Click" />
						<span style="font-size: x-small; font-family: Arial, Helvetica, sans-serif; color: #FFFFFF;">
							<strong>Emitir Factura</strong></span>
					</td>
					<td style="width: 170px">
						<asp:ImageButton ID="ib_nomina_eliminar" runat="server" ImageUrl="../imagenes/sistema/static/documentos.gif"
							Height="21px" Width="30px" Style="text-align: center" OnClick="ib_nomina_eliminar_Click"
							Visible="False" />
						<asp:Label ID="lbl_eliminar_agp" runat="server" Style="color: #FFFFFF; text-align: right;"
							Text="Eliminar Factura" Visible="false"></asp:Label>
					</td>
					<td class="style6">
						<asp:ImageButton ID="Imagebutton1" runat="server" ImageUrl="../imagenes/sistema/static/documentos.gif"
							Height="21px" Width="30px" Style="text-align: center" OnClick="ib_Cambia_folio"
							Visible="False" />
						<asp:Label ID="Label1" runat="server" Style="color: #FFFFFF; text-align: right;"
							Text="Folio Act." Visible="false"></asp:Label>
					</td>
					<td>
						<asp:TextBox ID="id_folio" runat="server" Font-Names="Arial" Font-Size="X-Small"
							OnTextChanged="txt_factura_agp_TextChanged" Width="87px" Height="19px" Visible="false"> </asp:TextBox>
					</td>
					<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;" class="style5">
						<asp:Label ID="lbl_factura_agp" runat="server" Style="color: #FFFFFF; text-align: right;"
							Text="N°Factura AGP"></asp:Label>
					</td>
					<td style="text-align: right;">
						<asp:TextBox ID="txt_factura_agp" runat="server" Font-Names="Arial" Font-Size="X-Small"
							OnTextChanged="txt_factura_agp_TextChanged" Width="87px" Height="19px"></asp:TextBox>
					</td>
					<%--<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;" class="style5" >
									Ver Factura</td>--%>
					<td>
						<asp:ImageButton ID="btn_factura_rpt" runat="server" ImageUrl="../imagenes/sistema/static/poliza.jpg"
							Height="24" Width="24" OnClick="btn_factura_rpt_Click" Visible="true" />
					</td>
				</tr>
			</table>
		</td>
	</tr>
	</table>
</asp:Content>
