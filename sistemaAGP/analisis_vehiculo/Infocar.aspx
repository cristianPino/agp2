<%@ Page Title="" Language="C#" MasterPageFile="~/AGP.Master" AutoEventWireup="true" CodeBehind="Infocar.aspx.cs" Inherits="sistemaAGP.analisis_vehiculo.Infocar" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMenu" runat="server">
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
//                 width: Math.ceil(($(document).width()*99)/100),
//                 height: Math.ceil(($(document).height() * 30) / 100),
//                 maxWidth: Math.ceil(($(document).width()*99)/100),
//                 maxHeight: Math.ceil(($(document).height()*30)/100),
//                 minWidth: Math.ceil(($(document).width() * 99) / 100),
//                 minHeight: Math.ceil(($(document).height() * 30) / 100),     
                 maxWidth: 800,
                 maxHeight:600,
                 minWidth: 800,
                 minHeight: 600,       
                 closeClick: false,
                 autoDimensions: true,
                 openEffect: 'elastic',
                 closeEffect: 'elastic',
                 fitToView: false,
                 autoScale:true,
                 nextSpeed: 0, //important
                 prevSpeed: 0, //important  
                 beforeClose: function () {
                     return window.confirm('¿Desea cerrar la ventana?');
                 },
//                 beforeShow: function () {
//                     // added 50px to avoid scrollbars inside fancybox
//                     this.width = ($('.fancybox-iframe').contents().find('html').width());
//                     this.height = ($('.fancybox-iframe').contents().find('html').height());
//                 }

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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoCentral" runat="server">
    <div class="subtitulo" style="width: 70%">
        <asp:Image ID="Image1" runat="server" 
                        ImageUrl="../imagenes/sistema/static/infoAuto/InfoAutoIcono2.png" 
                        Height="34px" 
                        Width="37px" />
        &nbsp;<asp:Label ID="lbl_titulo" runat="server" Text="ESTADO INFOCAR"></asp:Label>
    </div>
    <br/>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional"><ContentTemplate>
       
        <table class="table">
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Oc"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtOc" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Patente"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPatente" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="Desde"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="dlMes" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
        </table>

       
    </ContentTemplate></asp:UpdatePanel>
    <br />
     <div class="div_objetos" style="text-align: center">
        <asp:ImageButton ID="imBuscar" OnClick="imBuscar_Click"  runat="server" ImageUrl="../imagenes/sistema/static/infoAuto/lupaBlanca.png" />
        </div>
    
          <br/>      
   <asp:UpdatePanel ID="upGrillaHipoteca" runat="server" UpdateMode="Conditional" OnLoad="upGrillaHipoteca_Load" >
    <ContentTemplate>
    
<asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" CssClass="tabla_datos" ShowFooter="True" OnRowDataBound="gr_dato_RowDataBound" onrowcommand="gr_dato_RowCommand"
				DataKeyNames="idSolicitud,codigoEstado,estado" >				
				<Columns>
				    <asp:TemplateField HeaderText="Id" >
									<ItemTemplate>
										<asp:HyperLink ID="id_operacion" runat="server"   Text='<%# Bind("idSolicitud") %>' />
                                        
										<asp:Panel ID="pnl_menu_solicitud" runat="server" CssClass="popupmenu">
											<table>
												<tr>	
												<td>
													<asp:HyperLink ID="HyperLink1" runat="server"  class="fancybox fancybox.iframe" ToolTip="Carpeta"
									                ImageUrl="~/imagenes/sistema/static/panel_control/carpeta.png" Text="Carpeta" NavigateUrl='<%# Bind("urlCarpeta") %>' />
												</td>													
												</tr>
												<tr>
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
                    <asp:BoundField DataField="oc" HeaderText="Oc" >
                     <ItemStyle CssClass="td_derecha"  />
					<HeaderStyle CssClass="td_cabecera" />
                    </asp:BoundField>
                    
                    <asp:BoundField DataField="patente" HeaderText="Patente" >
                     <ItemStyle CssClass="td_derecha"  />
					<HeaderStyle CssClass="td_cabecera" />
                    </asp:BoundField>

                    <asp:BoundField DataField="fecha" HeaderText="Fecha" >
                     <ItemStyle CssClass="td_derecha_grande"  />
					<HeaderStyle CssClass="td_cabecera_grande" />
                    </asp:BoundField>

					<asp:BoundField DataField="correo" HeaderText="Correo" >
                     <ItemStyle CssClass="td_derecha_grande"  />
					<HeaderStyle CssClass="td_cabecera_grande" />
                    </asp:BoundField>

					<asp:BoundField DataField="estado" HeaderText="Estado" >
                     <ItemStyle CssClass="td_derecha_grande"  />
					<HeaderStyle CssClass="td_cabecera_grande" />
                    </asp:BoundField>
                    
                     <asp:TemplateField HeaderText="Procesos">
                            <ItemTemplate>
                                <asp:HyperLink ID="lnkPdf" runat="server" data-fancybox-type="iframe" CssClass="fancybox fancybox.iframe"
                                    ImageUrl="../imagenes/sistema/static/infoAuto/iconoProcesosChico.png" NavigateUrl='<%# Bind("urlProcesos") %>' />
                            </ItemTemplate>
                            <ItemStyle CssClass="td_derecha" />
                            <HeaderStyle CssClass="td_cabecera" />
                        </asp:TemplateField>

                    <asp:TemplateField HeaderText="Semaforo">
                                                    <ItemTemplate>
                                                        <asp:HyperLink ID="lnk_sem" runat="server" ImageUrl='<%# Bind("urlSemaforo") %>'  />
                                                    </ItemTemplate>
                    <ItemStyle CssClass="td_derecha"  />
					<HeaderStyle CssClass="td_derecha" /> 
                   </asp:TemplateField>
                   
                   <asp:TemplateField HeaderText="Tareas">
                                                    <ItemTemplate>
                                                        <asp:HyperLink ID="lnk_tareas" runat="server" class="fancybox fancybox.iframe" ToolTip="Tareas" NavigateUrl='<%# Bind("urlTareas") %>' 
                                                        ImageUrl="~/imagenes/sistema/static/infoAuto/InfoAutoIcono2chico.png" />
                                                    </ItemTemplate>
                    <ItemStyle CssClass="td_derecha"  />
					<HeaderStyle CssClass="td_derecha" /> 
                   </asp:TemplateField>
                   
                   <asp:TemplateField HeaderText="Trabajar">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="../imagenes/sistema/static/panel_control/wflow.png"
                                                        CommandName="trabajar"  CommandArgument='<%#((GridViewRow)Container).RowIndex %>'
                                                         />
                                                          <cc1:ConfirmButtonExtender  ID="ConfirmButtonExtender1" 
                                                                                        runat ="server" 
                                                                                        TargetControlID="ImageButton1"
                                                                                        ConfirmText="¿Está seguro que desea tomar esta operación?"/>
                                                    </ItemTemplate>
                    <ItemStyle CssClass="td_derecha"  />
					<HeaderStyle CssClass="td_derecha" /> 
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
                  <FooterStyle CssClass="tr_cabecera" />
				<RowStyle CssClass="tr_fila" />
				<AlternatingRowStyle CssClass="tr_fila_alt" />   
			</asp:GridView>
            <br/>
             <div class="div_objetos" id="divBotones" runat="server" Visible="False" style="z-index: 1">
        <center>
            <asp:ImageButton ID="imAvanzar" runat="server" Style="transform: scaleX(-1);-moz-transform: scaleX(-1);-webkit-transform: scaleX(-1);-o-transform: scaleX(-1);"
                ImageUrl="../imagenes/sistema/static/hipotecario/avanzar.png" 
                onclick="imAvanzar_Click" />
             <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server"
                                            TargetControlID="imAvanzar" ConfirmText="¿Está seguro de reiniciar lo seleccionado?">
                </cc1:ConfirmButtonExtender>
        </center>
       
         
     </div>
     <div class="divInfo">
         <table><tr><td> <asp:Image ID="imgInfo" runat="server"  ImageUrl="../imagenes/sistema/static/infoAuto/exclamacion.png"/> </td>
         <td> <asp:Label ID="lblInfo" runat="server" Text="Bienvenido"></asp:Label></td>
         </tr></table>
      
           
     </div>

            </ContentTemplate>

</asp:UpdatePanel>
</asp:Content>
