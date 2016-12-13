<%@ Page Title="" Language="C#" MasterPageFile="~/AGP.Master" AutoEventWireup="true" CodeBehind="EstadoCertificado.aspx.cs" Inherits="sistemaAGP.analisis_vehiculo.EstadoCertificado" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMenu" runat="server">
    <script type="text/javascript" src="../jquery-1.7.2.min.js"></script>
 <script type="text/javascript" src="../jquery.mousewheel-3.0.6.pack.js"></script>
    <script type="text/javascript" src="../jquery.fancybox.js?v=2.0.6"></script>
    <link rel="Stylesheet" type="text/css" href="../jquery.fancybox.css?v=2.0.6" media="screen" />
    <script type="text/javascript" src="../javascript/ScrollableGrid.js"></script>
    <script src="../javascript/highcharts.js"></script>
    <script src="../javascript/exporting.js"></script>
    
    <style type="text/css">
        .caja{
            width: 100%;            
            margin: auto;
            height: 400px;
            transition: height .4s;
            }
            .caja table {
                margin: 0 auto;
                text-align: left;
                }
    </style>

    <script type="text/javascript">
        $(function () {
            var titulo = $('#<%=htitulo.ClientID %>').val();

            var c1 = parseInt($('#<%=Ch1.ClientID %>').val());
            var c2 = parseInt($('#<%=ch2.ClientID %>').val());
            var c3 = parseInt($('#<%=ch3.ClientID %>').val());
            var c4 = parseInt($('#<%=ch4.ClientID %>').val());
            var c5 = parseInt($('#<%=ch5.ClientID %>').val());
            var c6 = parseInt($('#<%=ch6.ClientID %>').val());
            var c7 = parseInt($('#<%=ch7.ClientID %>').val());
            var c8 = parseInt($('#<%=ch8.ClientID %>').val());
            var c9 = parseInt($('#<%=ch9.ClientID %>').val());
            var c10 = parseInt($('#<%=ch10.ClientID %>').val());
            var c11 = parseInt($('#<%=ch11.ClientID %>').val());
            var c12 = parseInt($('#<%=ch12.ClientID %>').val());


            var m1 = parseInt($('#<%=mh1.ClientID %>').val());
            var m2 = parseInt($('#<%=mh2.ClientID %>').val());
            var m3 = parseInt($('#<%=mh3.ClientID %>').val());
            var m4 = parseInt($('#<%=mh4.ClientID %>').val());
            var m5 = parseInt($('#<%=mh5.ClientID %>').val());
            var m6 = parseInt($('#<%=mh6.ClientID %>').val());
            var m7 = parseInt($('#<%=mh7.ClientID %>').val());
            var m8 = parseInt($('#<%=mh8.ClientID %>').val());
            var m9 = parseInt($('#<%=mh9.ClientID %>').val());
            var m10 = parseInt($('#<%=mh10.ClientID %>').val());
            var m11 = parseInt($('#<%=mh11.ClientID %>').val());
            var m12 = parseInt($('#<%=mh12.ClientID %>').val());

            var mes1 = $('#<%=hmes1.ClientID %>').val();
            var mes2 = $('#<%=hmes2.ClientID %>').val();
            var mes3 = $('#<%=hmes3.ClientID %>').val();
            var mes4 = $('#<%=hmes4.ClientID %>').val();
            var mes5 = $('#<%=hmes5.ClientID %>').val();
            var mes6 = $('#<%=hmes6.ClientID %>').val();
            var mes7 = $('#<%=hmes7.ClientID %>').val();
            var mes8 = $('#<%=hmes8.ClientID %>').val();
            var mes9 = $('#<%=hmes9.ClientID %>').val();
            var mes10 = $('#<%=hmes10.ClientID %>').val();
            var mes11 = $('#<%=hmes11.ClientID %>').val();
            var mes12 = $('#<%=hmes12.ClientID %>').val();
            
           
            $('#container').highcharts({
                chart: {
                    type: 'column'
                },
                title: {
                    text: 'Cantidad de Certificados Solicitados ' + titulo
                },
                subtitle: {
                    text: 'Últimos 12 meses'
                },
                xAxis: {
                    categories: [
                        mes1,
                        mes2,
                        mes3,
                        mes4,
                        mes5,
                        mes6,
                        mes7,
                        mes8,
                        mes9,
                        mes10,
                        mes11,
                        mes12
                    ]
                },
                yAxis: {
                    min: 0,
                    title: {
                        text: 'Cantidad (un)'
                    }
                },
                tooltip: {
                    headerFormat: '<span style="font-size:10px">{point.key}</span><table>',
                    pointFormat: '<tr><td style="color:{series.color};padding:0">{series.name}: </td>' +
                        '<td style="padding:0"><b>{point.y:.1f} un</b></td></tr>',
                    footerFormat: '</table>',
                    shared: true,
                    useHTML: true
                },
                plotOptions: {
                    column: {
                        pointPadding: 0.2,
                        borderWidth: 0
                    }
                },
                series: [{
                        name: 'CAV',
                        data: [c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12]

                    }, {
                        name: 'CAV+MULTAS',
                        data: [m1, m2, m3, m4, m5, m6, m7, m8, m9, m10, m11, m12]

                    }]
            });
        });
    </script>
<script type="text/javascript">
    var clic = 1;
    function divLogin() {
        if (clic == 1) {
            document.getElementById("container").style.height = "0px";
            document.getElementById("highcharts-0").style.display = "none";
            clic = clic + 1;
        } else {
            document.getElementById("container").style.height = "400px";
            document.getElementById("highcharts-0").style.display = "block";
           
            clic = 1;
        }
    }
</script>
   
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
                        ImageUrl="../imagenes/sistema/static/panel_control/pdf.png" 
                        Height="34px" 
                        Width="37px" />
        &nbsp;<asp:Label ID="lbl_titulo" runat="server" Text="ESTADO DE CERTIFICADOS"></asp:Label>
    </div>
    <br/>
    <div id="container" class="caja" style="min-width: 310px; height: 400px; margin: 0 auto"></div>
    <asp:UpdatePanel runat="server" UpdateMode="Conditional"><ContentTemplate>
       
        <table class="table">
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Cliente"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="dlCliente" runat="server" >
                    </asp:DropDownList>
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
                    <asp:TextBox ID="txtDesde" runat="server"></asp:TextBox>
                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDesde" CssClass="FondoAplicacion" Format="dd/MM/yyyy"/>
                </td>
                <td>
                    <asp:TextBox ID="txtHasta" runat="server"></asp:TextBox>
                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtHasta" CssClass="FondoAplicacion" Format="dd/MM/yyyy"/>
                </td>
                <td>
                     <a onclick="divLogin()"><img src="../imagenes/sistema/static/infoAuto/chart.png" /> </a>
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
    
<asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" CssClass="tabla_datos" ShowFooter="True" OnRowDataBound="gr_dato_RowDataBound" 
				DataKeyNames="idSolicitud,tipoOperacion,codigoEstado" >				
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
                    <asp:BoundField DataField="tipoOperacion" HeaderText="Producto" >
                     <ItemStyle CssClass="td_derecha"  />
					<HeaderStyle CssClass="td_cabecera" />
                    </asp:BoundField>
                    
                    <asp:BoundField DataField="usuario" HeaderText="Usuario" >
                     <ItemStyle CssClass="td_derecha_grande"  />
					<HeaderStyle CssClass="td_cabecera_grande" />
                    </asp:BoundField>

                    <asp:BoundField DataField="fecha" HeaderText="Fecha" >
                     <ItemStyle CssClass="td_derecha_grande"  />
					<HeaderStyle CssClass="td_cabecera_grande" />
                    </asp:BoundField>

					<asp:BoundField DataField="patente" HeaderText="Patente" >
                     <ItemStyle CssClass="td_derecha"  />
					<HeaderStyle CssClass="td_cabecera" />
                    </asp:BoundField>

					<asp:BoundField DataField="estado" HeaderText="Estado" >
                     <ItemStyle CssClass="td_derecha_grande"  />
					<HeaderStyle CssClass="td_cabecera_grande" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Semaforo">
                                                    <ItemTemplate>
                                                        <asp:HyperLink ID="lnk_Alzamiento" runat="server" ImageUrl='<%# Bind("urlSemaforo") %>'  />
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
     <br/>
     <br/>
     <br/>
     <br/>
     
          
     <div class="divInfo">
         <table><tr><td> <asp:Image ID="imgInfo" runat="server"  ImageUrl="../imagenes/sistema/static/infoAuto/exclamacion.png"/> </td>
         <td> <asp:Label ID="lblInfo" runat="server" Text="Bienvenido"></asp:Label></td>
         </tr></table>
      
           
     </div>

            </ContentTemplate>

</asp:UpdatePanel>

    <asp:HiddenField ID="Ch1" runat="server" Value="" />
    <asp:HiddenField ID="ch2" runat="server" Value="" />
    <asp:HiddenField ID="ch3" runat="server" Value="" />
    <asp:HiddenField ID="ch4" runat="server" Value="" />
    <asp:HiddenField ID="ch5" runat="server" Value="" />
    <asp:HiddenField ID="ch6" runat="server" Value="" />
    <asp:HiddenField ID="ch7" runat="server" Value="" />
    <asp:HiddenField ID="ch8" runat="server" Value="" />
    <asp:HiddenField ID="ch9" runat="server" Value="" />
    <asp:HiddenField ID="ch10" runat="server" Value="" />
    <asp:HiddenField ID="ch11" runat="server" Value="" />
    <asp:HiddenField ID="ch12" runat="server" Value="" />
    
    <asp:HiddenField ID="mh1" runat="server" Value="" />
    <asp:HiddenField ID="mh2" runat="server" Value="" />
    <asp:HiddenField ID="mh3" runat="server" Value="" />
    <asp:HiddenField ID="mh4" runat="server" Value="" />
    <asp:HiddenField ID="mh5" runat="server" Value="" />
    <asp:HiddenField ID="mh6" runat="server" Value="" />
    <asp:HiddenField ID="mh7" runat="server" Value="" />
    <asp:HiddenField ID="mh8" runat="server" Value="" />
    <asp:HiddenField ID="mh9" runat="server" Value="" />
    <asp:HiddenField ID="mh10" runat="server" Value="" />
    <asp:HiddenField ID="mh11" runat="server" Value="" />
    <asp:HiddenField ID="mh12" runat="server" Value="" />
    
    <asp:HiddenField ID="hmes1" runat="server" Value="" />
    <asp:HiddenField ID="hmes2" runat="server" Value="" />
    <asp:HiddenField ID="hmes3" runat="server" Value="" />
    <asp:HiddenField ID="hmes4" runat="server" Value="" />
    <asp:HiddenField ID="hmes5" runat="server" Value="" />
    <asp:HiddenField ID="hmes6" runat="server" Value="" />
    <asp:HiddenField ID="hmes7" runat="server" Value="" />
    <asp:HiddenField ID="hmes8" runat="server" Value="" />
    <asp:HiddenField ID="hmes9" runat="server" Value="" />
    <asp:HiddenField ID="hmes10" runat="server" Value="" />
    <asp:HiddenField ID="hmes11" runat="server" Value="" />
    <asp:HiddenField ID="hmes12" runat="server" Value="" />
    
     <asp:HiddenField ID="htitulo" runat="server" Value="" />

</asp:Content>
