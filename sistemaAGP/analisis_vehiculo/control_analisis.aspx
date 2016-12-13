<%@ Page Title="Control de Operaciones AGP S.A." Language="C#" MasterPageFile="~/AGP.Master"
	AutoEventWireup="true" CodeBehind="control_analisis.aspx.cs" Inherits="sistemaAGP.control_analisis" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMenu" runat="server">
	<script type="text/javascript" src="../jquery-1.7.2.min.js"></script>
	<script type="text/javascript" src="../jquery.mousewheel-3.0.6.pack.js"></script>
	<script type="text/javascript" src="../jquery.fancybox.js?v=2.0.6"></script>
	<link rel="Stylesheet" type="text/css" href="../jquery.fancybox.css?v=2.0.6" media="screen" />
	<script type="text/javascript" src="../javascript/ScrollableGrid.js"></script>
	<script type="text/javascript" src="../javascript/exporting.js"></script>
	<script type="text/JavaScript">

		function timedRefresh(timeoutPeriod) {
			setTimeout("location.reload(true);", timeoutPeriod);
		}

	</script>
	<script type="text/javascript">
		$(document).ready(function () {

			$("a.fancybox").fancybox({
				maxWidth: 800,
				maxHeight: 600,
				minWidth: 800,
				minHeight: 600,
				autoDimensions: true,
				openEffect: 'elastic',
				closeEffect: 'elastic',
				fitToView: false,
				nextSpeed: 0, //important
				prevSpeed: 0, //important  
				beforeShow: function () {
					// added 50px to avoid scrollbars inside fancybox
					this.width = ($('.fancybox-iframe').contents().find('html').width());
					this.height = ($('.fancybox-iframe').contents().find('html').height());
				}

				//	            afterClose: function () {
				//	                //refresco la grilla de panel de control
				//	                $('#<%=ib_buscar.ClientID%>').click();
				//	            }

			});


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
	<%--<script type="text/javascript">

		$(document).ready(function () {

			setInterval(getMensajeAlerta, 1000);

			function getMensajeAlerta() {

				var id_usuario_session = $('#<%=Session.LCID%>').val();
				var animStyle = 'slide';
				$.ajax({
					type: "POST",
					url: "../NotificacionWS.asmx/getMensajeAlerta",
					data: "{'id_cuenta':" + id_usuario_session + "}",
					contentType: "application/json; charset=utf-8",
					dataType: "json",
					success: function (response) {
						var mensaje = response.d;
						if (mensaje.Id_mensaje > 0) {

							alerta = alert(mensaje.Mensaje_hito);


							$.ajax({ type: "POST",
								url: "../NotificacionWS.asmx/upt_alerta",
								data: "{'id_mensaje':" + mensaje.Id_mensaje + "}",
								contentType: "application/json; charset=utf-8",
								dataType: "json"

							});
						}
					},

					failure: function (msg) {
						alert(msg);
					}

				});
			} 
		})

	</script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoCentral" runat="server">
	<div id="title-estado" style="display: none;">
		Estado Operacion
	</div>
	<table align="left" style="width: 55%; height: 440px">
		<tr>
			<td class="style4" style="height: 74px" valign="top">
				<table style="width: 100%; height: 32px;" bgcolor="#507CD1">
					<tr>
						<td style="width: 38px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;
							height: 28px; color: #FFFFFF;">
							<b>Cliente</b>
						</td>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 28px;">
							<b>
								<asp:DropDownList ID="dl_cliente" runat="server" Font-Names="Arial" Font-Size="X-Small"
									Height="16px" Width="138px" TabIndex="1" Style="font-family: Arial, Helvetica, sans-serif;
									font-size: x-small; color: #000000;" AutoPostBack="True" OnSelectedIndexChanged="dl_cliente_SelectedIndexChanged">
								</asp:DropDownList>
							</b>
						</td>
						<td class="style1" style="width: 57px; font-family: Arial, Helvetica, sans-serif;
							font-size: x-small; font-weight: bold; height: 28px; color: #FFFFFF;">
							Modulo
						</td>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 28px;">
							<b>
								<asp:DropDownList ID="dl_modulo" runat="server" Font-Names="Arial" Font-Size="X-Small"
									Height="16px" Width="138px" TabIndex="17" Style="font-family: Arial, Helvetica, sans-serif;
									font-size: x-small; color: #000000;" OnSelectedIndexChanged="dl_modulo_SelectedIndexChanged">
								</asp:DropDownList>
							</b>
						</td>
						<td style="width: 64px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;
							height: 28px; color: #FFFFFF;">
							<b>Sucursal</b>
						</td>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 28px;">
							<b>
								<asp:DropDownList ID="dl_sucursal" runat="server" Font-Names="Arial" Font-Size="X-Small"
									Height="16px" Width="138px" TabIndex="17" Style="font-family: Arial, Helvetica, sans-serif;
									font-size: x-small; color: #000000;">
								</asp:DropDownList>
							</b>
						</td>
						<td style="width: 63px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;
							height: 28px; color: #FFFFFF;">
							<b>Producto</b>
						</td>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 28px;">
							<b>
								<asp:DropDownList ID="dl_producto" runat="server" Font-Names="Arial" Font-Size="X-Small"
									Height="16px" Width="138px" TabIndex="17" Style="font-family: Arial, Helvetica, sans-serif;
									font-size: x-small; color: #000000;" OnSelectedIndexChanged="dl_producto_SelectedIndexChanged">
								</asp:DropDownList>
							</b>
						</td>
						<td style="width: 92px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;
							height: 28px; color: #FFFFFF;">
							<b>Nº Operacion</b>
						</td>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 28px;">
							<b>
								<asp:TextBox ID="txt_operacion" runat="server" Width="104px" Style="font-family: Arial, Helvetica, sans-serif;
									font-size: x-small; color: #FFFFFF;" BackColor="#3399FF" ForeColor="White" TabIndex="3"></asp:TextBox>
								<cc1:FilteredTextBoxExtender ID="txt_operacion_FilteredTextBoxExtender" runat="server"
									TargetControlID="txt_operacion" FilterType="Custom, Numbers" ValidChars="">
								</cc1:FilteredTextBoxExtender>
							</b>
						</td>
					</tr>
					<tr>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #FFFFFF;
							font-weight: 700;">
							Patente
						</td>
						<td>
							<asp:TextBox ID="txt_patente" runat="server" MaxLength="6" Style="font-family: Arial, Helvetica, sans-serif;
								font-size: x-small" Width="82px"></asp:TextBox>
						</td>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #FFFFFF">
							<b>Desde </b>
						</td>
						<td>
							<asp:TextBox ID="txt_desde" runat="server" Style="font-family: Arial, Helvetica, sans-serif;
								font-size: x-small" Height="19px" Width="73px" TabIndex="2"></asp:TextBox>
							<asp:ImageButton ID="ib_desde" runat="server" ImageUrl="../imagenes/sistema/gif/calendario.gif"
								Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" />
							<cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_desde"
								CssClass="FondoAplicacion" Format="dd/MM/yyyy" PopupButtonID="ib_desde" />
						</td>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #FFFFFF;
							font-weight: 700">
							Hasta
						</td>
						<td>
							<asp:TextBox ID="txt_hasta" runat="server" Style="font-family: Arial, Helvetica, sans-serif;
								font-size: x-small" Height="19px" Width="73px" TabIndex="2"></asp:TextBox>
							<asp:ImageButton ID="ib_hasta" runat="server" ImageUrl="../imagenes/sistema/gif/calendario.gif"
								Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" />
							<cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txt_hasta"
								CssClass="FondoAplicacion" Format="dd/MM/yyyy" PopupButtonID="ib_hasta" />
						</td>
						<td style="text-align: center" align="center" valign="middle">
							<asp:ImageButton ID="ib_buscar" runat="server" ImageUrl="../imagenes/sistema/gif/lupa.gif"
								Height="21px" Width="30px" OnClick="ib_buscar_Click" Style="text-align: center" />
						</td>
                        <td>
                            <a href="Mensajes_masivos.aspx" title="Mensajes masivos" class="fancybox fancybox.iframe"><asp:Image ID="Image1" ImageUrl="~/imagenes/sistema/static/hipotecario/mensaje.png" runat="server" /></a>
                        </td>
                        <td>
                            <a href="ActivarAutopistas.aspx" title="Estado páginas autopistas" class="fancybox fancybox.iframe"><asp:Image ID="Image2" ImageUrl="~/imagenes/sistema/static/hipotecario/key.png" runat="server" /></a>
                        </td>
					</tr>
				</table>
				<center>
					<table style="width: 100%; height: 235px;">
						<tr>
							<td style="width: 123px; height: 262px;" valign="top">
								<div id="divOnload" runat="server">
									<asp:UpdatePanel ID="UpdatePanel2" runat="server">
										<ContentTemplate>
											<%--<asp:Timer ID="Timer1" runat="server" Interval="18000" ontick="Timer1_Tick" ></asp:Timer>--%>
											<asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" CellPadding="4"
												Font-Names="Arial" Font-Size="X-Small" ForeColor="#333333" DataKeyNames="tipo_operacion,check,cuenta_usuario,id_cliente,id_solicitud,estado_operacion,codigo_estado"
												GridLines="None" OnSelectedIndexChanged="gr_dato_SelectedIndexChanged"
												OnRowDataBound="gr_dato_RowDataBound" EnableModelValidation="True" OnRowDeleting="gr_dato_onRowDeleting"
												OnRowCommand="gr_dato_RowCommand" ItemInserted="gr_dato_ItemInserted">
												<RowStyle BackColor="#EFF3FB" />
												<Columns>
													<asp:TemplateField HeaderText="Operación">
														<ItemTemplate>
															<asp:HyperLink ID="lnk_id" runat="server" data-fancybox-type="iframe" CssClass="fancybox fancybox.iframe"
																NavigateUrl='<%# Bind("url_op") %>' Text='<%# Bind("id_solicitud") %>'>                                                   
															</asp:HyperLink>
															<asp:Panel ID="pnl_menu_solicitud" runat="server" CssClass="popupmenu">
																<table>
																	<tr>
																		<td>
																			<asp:HyperLink ID="lnk_cav" runat="server" data-fancybox-type="iframe" CssClass="fancybox fancybox.iframe"
																				ToolTip="CAV" ImageUrl="~/imagenes/iconos/certificado.png" NavigateUrl='<%# Bind("url_cav") %>' />
																		</td>
																		<td>
																			<asp:HyperLink ID="lnk_contrato" runat="server" Target="_blank" ImageUrl="~/imagenes/iconos/contrato.png"
																				ToolTip="CONTRATOS" NavigateUrl='<%# Bind("url_contrato") %>' />
																		</td>
																		<td>
																			<asp:HyperLink ID="lnk_gastos" runat="server" data-fancybox-type="iframe" CssClass="fancybox fancybox.iframe"
																			 ToolTip="GASTOS"	ImageUrl="~/imagenes/iconos/gastos.png" NavigateUrl='<%# Bind("url_gasto") %>' />
																		</td>

																		<td>
																			<asp:HyperLink ID="lnk_cargar" runat="server" data-fancybox-type="iframe" CssClass="fancybox fancybox.iframe"
																			 ToolTip="CARPETA"	ImageUrl="~/imagenes/iconos/carpeta.png" NavigateUrl='<%# Bind("url_cargar") %>' />
																		</td>
																		<td>
																			<asp:HyperLink ID="lnk_estado" runat="server" data-title-id="title-estado" data-fancybox-type="iframe"
																				ToolTip="ESTADO" CssClass="fancybox fancybox.iframe" ImageUrl="~/imagenes/iconos/estados.png"
																				NavigateUrl='<%# Bind("url_estado") %>' />
																		</td>
																		<td>
																			<asp:HyperLink ID="lnk_autopista" runat="server" class="fancybox fancybox.iframe"
																			 ToolTip="InfoCar"	ImageUrl="~/imagenes/iconos/buscar.png" NavigateUrl='<%# Bind("url_autopista") %>' />
																		</td>
																		<td>
																			<asp:HyperLink ID="lnkPdf" runat="server" data-fancybox-type="iframe" CssClass="fancybox fancybox.iframe"
																			 ToolTip="Procesos InfoCar"	ImageUrl="../imagenes/iconos/procesos.png" NavigateUrl='<%# Bind("urlProcesos") %>' />
																		</td>
														
																	</tr>
																	<tr>
																		<td>
																			CAV
																		</td>
																		<td>
																			Contratos
																		</td>
																		<td>
																			Gastos
																		</td>
										
																		<td>
																			Carpeta
																		</td>
																		<td>
																			Estado
																		</td>
																		<td>
																			InfoCar			
																		</td>
																		<td>
																			Procesos InfoCar
																		</td>
																	
																	</tr>
																</table>
															</asp:Panel>
															<cc1:HoverMenuExtender ID="hme_menu_solicitud" runat="Server" TargetControlID="lnk_id"
																PopupControlID="pnl_menu_solicitud" PopupPosition="Right" OffsetX="0" OffsetY="0"
																HoverDelay="500" PopDelay="0" />
														</ItemTemplate>
													
														<ItemStyle CssClass="td_derecha" />
														<HeaderStyle CssClass="td_cabecera" />
													</asp:TemplateField>
													<asp:BoundField AccessibleHeaderText="Cliente" DataField="Cliente" HeaderText="Cliente" />
													<asp:BoundField AccessibleHeaderText="Sucursal" DataField="sucursal" HeaderText="Sucursal" />
													<asp:BoundField AccessibleHeaderText="Ejecutivo" DataField="ejecutivo" HeaderText="Ejecutivo" />
													<asp:BoundField AccessibleHeaderText="tipo_operacion" DataField="tipo_operacion" HeaderText="" InsertVisible="False" Visible="False" />
													<asp:BoundField AccessibleHeaderText="Producto" DataField="operacion" HeaderText="Producto" />
													<asp:BoundField AccessibleHeaderText="Patente" DataField="Patente" HeaderText="Patente" />
													<asp:BoundField HeaderText="Total Gastos" DataField="total_gasto" />
												
												
													<asp:TemplateField HeaderText="Alzamiento">
														<ItemTemplate>
															<asp:HyperLink ID="lnk_Alzamiento" runat="server" data-fancybox-type="iframe" CssClass="fancybox fancybox.iframe"
																ImageUrl='<%# Bind("color_alzamiento") %>' NavigateUrl='<%# Bind("url_alzamiento") %>' />
														</ItemTemplate>
														<ItemStyle HorizontalAlign="Center" />
													</asp:TemplateField>
													<asp:BoundField AccessibleHeaderText="Estado Operación" DataField="estado_operacion"
														FooterText="estado_operacion" HeaderText="Estado Operación" />
													<asp:BoundField AccessibleHeaderText="analisis" DataField="nombre" FooterText="analisis"
														HeaderText="Analisis" />
													<asp:BoundField AccessibleHeaderText="cuenta_usuario" DataField="cuenta_usuario"
														FooterText="cuenta_usuario" HeaderText="Usuario" Visible="False" />
													<asp:BoundField AccessibleHeaderText="id_cliente" DataField="id_cliente" FooterText="id_cliente"
														HeaderText="id_cliente" Visible="False" />
													<asp:TemplateField Visible="false">
														<HeaderTemplate>
															<asp:CheckBox ID="checkall" runat="server" AutoPostBack="True" OnCheckedChanged="Check_Clicked"
																Enabled="false" />
														</HeaderTemplate>
														<ItemTemplate>
															<asp:CheckBox ID="chk" runat="server" AutoPostBack="true" EnableViewState="true"
																OnCheckedChanged="Check_Clicked_Grilla" Checked='<%# Bind("check")  %>' Enabled="false" />
														</ItemTemplate>
													</asp:TemplateField>
													<asp:CommandField ButtonType="Button" ShowSelectButton="True" />
													<asp:TemplateField HeaderText="Reiniciar">
														<ItemTemplate>
															<asp:ImageButton ID="reiniciar" runat="server" CommandName="Reiniciar" CommandArgument='<%#((GridViewRow)Container).RowIndex %>'
																AlternateText="  Reiniciar  " Visible="false" />
														
														<%--	<cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="reiniciar"
																ConfirmText="¿Esta seguro de reiniciar la operación?" />--%>
														</ItemTemplate>
														<ItemStyle CssClass="td_derecha_mediana_2" />
														<HeaderStyle CssClass="td_cabecera_mediana_2" />
													</asp:TemplateField>													
                                                    <asp:TemplateField HeaderText="A.Manual">
														<ItemTemplate>
															<asp:ImageButton ID="iBaManual" runat="server" Visible="false" CommandName="aManual" CommandArgument='<%#((GridViewRow)Container).RowIndex %>'
																AlternateText="  A.Manual  " />
														<%--	<cc1:ConfirmButtonExtender ID="ConfirmButtonExtender3" runat="server" TargetControlID="iBaManual"
																ConfirmText="¿Dejar en análisis manual?" />--%>
														</ItemTemplate>
														<ItemStyle CssClass="td_derecha_mediana_2" />
														<HeaderStyle CssClass="td_cabecera_mediana_2" />
													</asp:TemplateField>
													<asp:CommandField ButtonType="Image" HeaderText="Eliminar" ShowDeleteButton="True"
														DeleteImageUrl="../imagenes/iconos/eliminar.png" ControlStyle-Height="25px" ControlStyle-Width="25px">
														<ControlStyle Height="25px" Width="25px" />
													</asp:CommandField>
												</Columns>
												<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
												<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
												<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
												<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
												<EditRowStyle BackColor="#2461BF" />
												<AlternatingRowStyle BackColor="White" />
											</asp:GridView>
										
										</ContentTemplate>
									</asp:UpdatePanel>
								</div>
							</td>
						</tr>
					</table>
				</center>
			</td>
		</tr>
	</table>
</asp:Content>
