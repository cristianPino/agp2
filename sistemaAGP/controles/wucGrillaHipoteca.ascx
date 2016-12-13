<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucGrillaHipoteca.ascx.cs" Inherits="sistemaAGP.controles.wucGrillaHipoteca" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<script type="text/javascript" src="../jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="../jquery.mousewheel-3.0.6.pack.js"></script>
    <script type="text/javascript" src="../jquery.fancybox.js?v=2.0.6"></script>
    <link rel="Stylesheet" type="text/css" href="../jquery.fancybox.css?v=2.0.6" media="screen" />
    <script type="text/javascript" src="../javascript/ScrollableGrid.js"></script>
     <script type="text/javascript">
         function grilla_cabecera() {
             $('#<%=gr_dato.ClientID %>').Scrollable();
         }
    </script>
    
     <script type="text/javascript">
         $.ajaxSetup({ cache: false });

         $(document).ready(function () {

             $("a.fancybox").fancybox({
                 autoSize: false,
                 closeBtn: true,
                 maxWidth: 800,
                 maxHeight: 600,
                 minWidth: 800,
                 minHeight: 600,           
                 closeClick: false,
                 autoDimensions: true,
                 openEffect: 'elastic',
                 closeEffect: 'elastic',
                 fitToView: false,
                 nextSpeed: 0, //important
                 prevSpeed: 0, //important  
                 beforeClose: function () {
                     return window.confirm('¿Desea cerrar la ventana?');
                 },
                 beforeShow: function () {
                     // added 50px to avoid scrollbars inside fancybox
                     this.width = ($('.fancybox-iframe').contents().find('html').width());
                     this.height = ($('.fancybox-iframe').contents().find('html').height());
                 }

             });

             $("a.fancyboxy").fancybox({
                 autoSize: false,
                 fitToView: false,
                 closeBtn: true,
                 maxWidth: 900,
                 maxHeight: 800,
                 minWidth: 900,
                 minHeight: 800,               
                 closeClick: false,
                 autoDimensions: false,
                 openEffect: 'elastic',
                 closeEffect: 'elastic',
                 nextSpeed: 0, //important
                 prevSpeed: 0, //important 
                 beforeClose: function () {
                     return window.confirm('¿Desea cerrar la ventana?');
                 },
                 beforeShow: function () {
                     // added 50px to avoid scrollbars inside fancybox
                     this.width = ($('.fancybox-iframe').contents().find('html').width()) + 50;
                     this.height = ($('.fancybox-iframe').contents().find('html').height()) + 50;
                 }

             });


             $("a.fancybox_grande").fancybox({
                 autoSize: false,
                 closeBtn: true,
                 maxWidth: 900,
                 maxHeight: 800,
                 minWidth: 900,
                 minHeight: 800,                
                 closeClick: false,
                 autoDimensions: false,
                 openEffect: 'elastic',
                 closeEffect: 'elastic',
                 fitToView: false,
                 nextSpeed: 0, //important
                 prevSpeed: 0, //important 
                 beforeClose: function () {
                     return window.confirm('¿Desea cerrar la ventana?');
                 },
                 beforeShow: function () {
                     // added 50px to avoid scrollbars inside fancybox
                     this.width = ($('.fancybox-iframe').contents().find('html').width()) + 150;
                     this.height = ($('.fancybox-iframe').contents().find('html').height()) + 150;
                 }

             });


         });
 
 	</script>

<asp:UpdatePanel ID="upGrillaHipoteca" runat="server" UpdateMode="Conditional" OnLoad="upGrillaHipoteca_Load">
    <ContentTemplate>
    
<asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" CssClass="tabla_datos" 
				DataKeyNames="idSolicitud,ordenEstado,tipoOperacion" >				
				<Columns>
				    <asp:TemplateField HeaderText="Id" >
									<ItemTemplate>
									    <asp:Image ID="imgSoloLectura" runat="server" ImageUrl='<%# Bind("soloLectura") %>' ToolTip='<%# Bind("ttsoloLectura") %>' />
										<asp:HyperLink ID="id_operacion" runat="server"   Text='<%# Bind("idSolicitud") %>' />
                                        
										<asp:Panel ID="pnl_menu_solicitud" runat="server" CssClass="popupmenu">
											<table>
												<tr>												
												<td>
													<asp:HyperLink ID="HyperLink2" runat="server"  class="fancybox fancybox.iframe" ToolTip="Hitos"
									                ImageUrl="~/imagenes/sistema/static/panel_control/poliza.png" Text="Hitos" NavigateUrl='<%# Bind("urlHitos") %>' />
												</td>
                                                
												<td>
													<asp:HyperLink ID="HyperLink1" runat="server"  class="fancybox fancybox.iframe" ToolTip="Carpeta"
									                ImageUrl="~/imagenes/sistema/static/panel_control/carpeta.png" Text="Carpeta" NavigateUrl='<%# Bind("urlCarpeta") %>' />
												</td>													
												</tr>
												<tr>
												<td>
													Hitos
												</td>
												<td>
													Carpeta digital
												</td>
                                               											
												</tr>
											</table>
										</asp:Panel>
										<cc1:HoverMenuExtender ID="hme_menu_solicitud" runat="Server" TargetControlID="Id_operacion" PopupControlID="pnl_menu_solicitud" PopupPosition="Right" OffsetX="0" OffsetY="0" HoverDelay="500" PopDelay="0" />
									</ItemTemplate>

									<ItemStyle CssClass="td_derecha"  />
									<HeaderStyle CssClass="td_cabecera" />
								</asp:TemplateField>
                    
                    
                    <asp:TemplateField HeaderText="Número Cliente">
						<ItemTemplate>
							<asp:HyperLink ID="numCli" runat="server" data-title-id="title-Tasador"
								CssClass="fancybox fancybox.iframe" Text='<%# Bind("numeroCliente") %>'/>
						</ItemTemplate>
						 <ItemStyle CssClass="td_derecha"  />
					<HeaderStyle CssClass="td_cabecera" />                
					</asp:TemplateField>

					<asp:BoundField DataField="clienteNombre" HeaderText="Cliente" >
                     <ItemStyle CssClass="td_derecha"  />
					<HeaderStyle CssClass="td_cabecera" />
                    </asp:BoundField>

					<asp:BoundField DataField="descripcionTipoOperacion" HeaderText="Producto" >
                    <ItemStyle CssClass="td_derecha"  />
					<HeaderStyle CssClass="td_cabecera" />
                    </asp:BoundField>

					<asp:BoundField DataField="sucursal" HeaderText="Sucursal" >
                     <ItemStyle CssClass="td_derecha"  />
					<HeaderStyle CssClass="td_cabecera" />
                    </asp:BoundField>

                    <asp:BoundField DataField="tipoCredito" HeaderText="Tipo Crédito">
                     <ItemStyle CssClass="td_derecha"  />
					<HeaderStyle CssClass="td_cabecera" />
                    </asp:BoundField>
                    
                    <asp:BoundField DataField="ejecutivoIngreso" HeaderText="Ejecutivo Ingreso" >
                     <ItemStyle CssClass="td_derecha"  />
					<HeaderStyle CssClass="td_cabecera" />
                    </asp:BoundField>

                    <asp:BoundField DataField="fechaIngreso" HeaderText="Fecha de Ingreso" >
                     <ItemStyle CssClass="td_derecha"  />
					<HeaderStyle CssClass="td_cabecera" />
                    </asp:BoundField>

					<asp:BoundField DataField="rutDeudor" HeaderText="Rut Deudor" >
                     <ItemStyle CssClass="td_derecha"  />
					<HeaderStyle CssClass="td_cabecera" />
                    </asp:BoundField>

					<asp:BoundField DataField="nombreDeudor" HeaderText="Nombre Deudor" >
                     <ItemStyle CssClass="td_derecha"  />
					<HeaderStyle CssClass="td_cabecera" />
                    </asp:BoundField>

                    <asp:TemplateField HeaderText="Estado">
						<ItemTemplate>
							<asp:HyperLink ID="lnk_Estados" runat="server" data-title-id="title-Tasador"
								CssClass="fancybox fancybox.iframe" Text='<%# Bind("nombreEstado") %>'
								NavigateUrl='<%# Bind("urlcambioEstado") %>' />
						</ItemTemplate>
						 <ItemStyle CssClass="td_derecha_grande"  />
					<HeaderStyle CssClass="td_cabecera_grande" />                
					</asp:TemplateField>

					<asp:BoundField DataField="contadorEstado" HeaderText="Días Eº">
                     <ItemStyle CssClass="td_derecha_chica"  />
					<HeaderStyle CssClass="td_cabecera_chica" />
                    </asp:BoundField>
                    
                    <asp:TemplateField HeaderText="Semáforo Estado">
						<ItemTemplate>
							<asp:HyperLink ID="lnk_estado" 
                                        runat="server" 
                                        data-title-id="title-work" 
                                        data-fancybox-type="iframe" 
                                        CssClass="fancybox fancybox.iframe" 
                                        ImageUrl='<%# Bind("semaforoEstado") %>' 
                                        NavigateUrl='<%# Bind("urlEstado") %>' />
						</ItemTemplate>
						 <ItemStyle CssClass="td_derecha_mediana_2"  />
					    <HeaderStyle CssClass="td_derecha_mediana_2" />                 
					</asp:TemplateField>
                    

                    <asp:BoundField DataField="contadorOperacion" HeaderText="Días Op.">
                     <ItemStyle CssClass="td_derecha_chica"  />
					<HeaderStyle CssClass="td_cabecera_chica" />
                    </asp:BoundField>
                 
					<asp:TemplateField HeaderText="Semáforo Op.">
						<ItemTemplate>
							<asp:HyperLink ID="lnk_estadoOp" runat="server" data-title-id="title-work" data-fancybox-type="iframe" CssClass="fancybox fancybox.iframe" ImageUrl='<%# Bind("semaforoOperacion") %>' NavigateUrl='<%# Bind("urlEstado") %>' />
						</ItemTemplate>
						 <ItemStyle CssClass="td_derecha_mediana_2"  />
					<HeaderStyle CssClass="td_derecha_mediana_2" />                 
					</asp:TemplateField>

                    <asp:TemplateField HeaderText="Tareas">
						<ItemTemplate>
							<asp:HyperLink ID="lnkTareas" runat="server" data-title-id="title-work" data-fancybox-type="iframe" CssClass="fancybox fancybox.iframe" ImageUrl="../imagenes/sistema/static/panel_control/nominas.png" NavigateUrl='<%# Bind("urlTareas") %>' />
						</ItemTemplate>
						 <ItemStyle CssClass="td_derecha_mediana_2"  />
					<HeaderStyle CssClass="td_derecha_mediana_2" />                 
					</asp:TemplateField>

                     <asp:TemplateField HeaderText="Sel">
						<ItemTemplate>
                            <asp:CheckBox ID="chk" runat="server" />
						</ItemTemplate>
						 <ItemStyle CssClass="td_derecha_chica"  />
					<HeaderStyle CssClass="td_derecha_chica" />                 
					</asp:TemplateField>

					
				</Columns>
				 <HeaderStyle CssClass="tr_cabecera" />
				<RowStyle CssClass="tr_fila" />
				<AlternatingRowStyle CssClass="tr_fila_alt" />   
			</asp:GridView>
            
            </ContentTemplate>

</asp:UpdatePanel>