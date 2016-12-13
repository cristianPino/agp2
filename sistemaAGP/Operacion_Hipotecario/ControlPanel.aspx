<%@ Page Title="" Language="C#" MasterPageFile="~/Master2.Master" AutoEventWireup="true"
    CodeBehind="ControlPanel.aspx.cs" Inherits="sistemaAGP.Operacion_Hipotecario.ControlPanelCertificados" %>

<%@ Register TagPrefix="cc1" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=3.5.40412.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>
<%@ MasterType VirtualPath="~/Master2.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript" src="../jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="../jquery.mousewheel-3.0.6.pack.js"></script>
    <script type="text/javascript" src="../jquery.fancybox.js?v=2.0.6"></script>
    <link rel="Stylesheet" type="text/css" href="../jquery.fancybox.css?v=2.0.6" media="screen" />
    <script type="text/javascript" src="../javascript/ScrollableGrid.js"></script>
    <script type="text/javascript" src="../javascript/exporting.js"></script>

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
                maxWidth: 1200,
                maxHeight: 700,
                minWidth: 1200,
                minHeight: 700,
                closeClick: false,
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

            });



            $("a.fancyboxy").fancybox({
                autoSize: false,
                fitToView: false,
                closeBtn: true,
                maxWidth: 600,
                maxHeight: 800,
                minWidth: 800,
                minHeight: 600,
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
    <asp:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional">
        <ContentTemplate>
            <table class="tabla_datos" width="100%">
                <tr>
                    <td colspan="6">Dashboard
                    </td>
                </tr>
                <tr>
                    <td class="td_derecha">Total Operaciones
                        <br />
                        <asp:Label ID="lblTotalOp" runat="server" Font-Size="x-large" Text="345"></asp:Label>
                    </td>
                    <td class="td_derecha">Fuera de sla
                        <br />
                        <asp:Label ID="lblRojas" runat="server" Font-Size="x-large" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblrojasprom" runat="server" Font-Size="x-small" Text=""></asp:Label>
                    </td>
                    <td class="td_derecha">Verdes<br />
                        <asp:Label ID="lblVerdes" runat="server" Font-Size="x-large" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblVerdesprom" runat="server" Font-Size="x-small" Text=""></asp:Label>
                    </td>
                    <td class="td_derecha">Amarillas<br />
                        <asp:Label ID="lblAmarillas" runat="server" Font-Size="x-large" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="lblAmarillasprom" runat="server" Font-Size="x-small" Text=""></asp:Label>
                    </td>
                    <td class="td_derecha">Mas tiempo<br />
                        <asp:Label ID="lblDiaMayor" runat="server" Font-Size="x-large" Text=""></asp:Label>
                        <br />
                        días
                    </td>
                    <td class="td_derecha">Promedio total<br />
                        <asp:Label ID="lblPromedioDias" runat="server" Font-Size="x-large" Text=""></asp:Label>
                        <br />
                        días
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        <a class="fancybox fancybox.iframe" href="modal/Grafico.aspx">
                            <img src="../imagenes/sistema/static/infoAuto/chart.png" />
                        </a>
                        <asp:ImageButton ID="ibExcel" runat="server" ToolTip="Reporte en excel" ImageUrl="../imagenes/sistema/static/hipotecario/XLS_File_24.png"
                            OnClick="ibExcel_Click" />
                        <asp:HyperLink ID="hlCargaMasiva" NavigateUrl="modal/EstadosYGastos.aspx" class="fancybox fancybox.iframe"
                            ImageUrl="../imagenes/sistema/static/hipotecario/up.png" runat="server"></asp:HyperLink>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel runat="server" ID="udp" UpdateMode="Conditional" OnLoad="upGrillaHipoteca_Load">
        <ContentTemplate>
            <table>
                <tr>
                    <td>
                        <asp:DropDownList ID="dlCliente" runat="server" CssClass="ddl" AutoPostBack="True"
                            OnSelectedIndexChanged="dlCliente_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <input type="text" class="inputs" placeholder="Nº Banco" runat="server" id="txtNumeroBco" />
                    </td>
                    <td>
                        <input type="text" class="inputs" placeholder="Rut Comprador" runat="server" id="txtRutComprador" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="dlProductos" runat="server" CssClass="ddl">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="dlEstados" runat="server" CssClass="ddl">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="dlTipoBusquedaMasiva" runat="server" CssClass="ddl">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <input type="text" class="inputs" placeholder="Nº AGP" runat="server" id="txtAgp" />
                    </td>
                    <td>
                        <input type="text" class="inputs" placeholder="Factura" runat="server" id="txtFactura" />
                    </td>
                    <td>
                        <asp:TextBox ID="txtBcoMultiple" runat="server" CssClass="inputs" Height="100%" TextMode="MultiLine"
                            Width="100%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" align="center">
                        <asp:ImageButton ID="ImageButton2" runat="server" Width="20px" ImageUrl="~/imagenes/sistema/static/verde.png"
                            ToolTip="Buscar Dentro de Sla" OnClick="ImageButton2_Click" />
                        <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="../imagenes/sistema/static/warning.png"
                            ToolTip="Buscar Sla próximo a vencer" Width="20px" OnClick="ImageButton3_Click" />
                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="../imagenes/sistema/static/no.jpg"
                            ToolTip="Buscar Fuera de Sla" Width="20px" OnClick="ImageButton1_Click" />
                        <asp:ImageButton ID="ib_buscar" runat="server" ImageUrl="../imagenes/sistema/static/buscar_chico.png" ToolTip="Buscar Todo" OnClick="ib_buscar_Click" />
                        <asp:Image ID="imgCantidadOperaciones" runat="server" ToolTip="Operaciones encontradas"
                            ImageUrl="../imagenes/sistema/static/hipotecario/Visibility_button_32.png" Height="20px"
                            Width="20px" />
                        <asp:Label ID="lblConteoOperaciones" runat="server" Font-Size="x-small" Text="0"></asp:Label>
                    </td>
                </tr>
            </table>

            <div id="divGrid" style="clear: both">
                <asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" CssClass="tabla_datos"
                    ShowFooter="true" DataKeyNames="idSolicitud,rutComprador,codigoEstado,total_gastos,total_ingresos,saldo,idCliente"
                    OnRowDataBound="gr_dato_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="Id">
                            <ItemTemplate>
                                <asp:HyperLink ID="id_operacion" Font-Size="small" runat="server" Text='<%# Bind("idSolicitud") %>' />
                                <asp:Panel ID="pnl_menu_solicitud" runat="server" CssClass="popupmenu">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:HyperLink ID="lnk_gasto" runat="server" data-title-id="title-gastos" data-fancybox-type="iframe"
                                                    CssClass="fancybox fancybox.iframe" ImageUrl="~/imagenes/sistema/static/panel_control/gastos.png"
                                                    NavigateUrl='<%# Bind("url_gastos") %>' />
                                            </td>
                                            <td>
                                                <asp:HyperLink ID="HyperLink2" runat="server" data-title-id="title-gastos" data-fancybox-type="iframe"
                                                    CssClass="fancybox fancybox.iframe" ImageUrl="~/imagenes/sistema/static/panel_control/nominas.png"
                                                    NavigateUrl='<%# Bind("url_nominas") %>' />
                                            </td>
                                            <td>
                                                <asp:HyperLink ID="lnkFirmas" runat="server" CssClass="fancybox fancybox.iframe"
                                                    data-title-id="title-Firmas" ImageUrl="~/imagenes/sistema/static/panel_control/poliza.png"
                                                    NavigateUrl='<%# Bind("url_hito") %>' />
                                            </td>
                                            <td>
                                                <asp:HyperLink ID="HyperLink1" runat="server" CssClass="fancybox fancybox.iframe"
                                                    data-title-id="title-Firmas" ImageUrl="../imagenes/sistema/static/panel_control/carpeta.png"
                                                    NavigateUrl='<%# Bind("urlCarpeta") %>' />
                                            </td>
                                            <td>
                                                <asp:HyperLink ID="HyperLink3" Font-Size="large" ForeColor="white" runat="server"
                                                    Text='<%# Bind("total_gastos") %>' />
                                            </td>
                                            <td>
                                                <asp:HyperLink ID="HyperLink4" Font-Size="large" ForeColor="white" runat="server"
                                                    Text='<%# Bind("total_ingresos") %>' />
                                            </td>
                                            <td>
                                                <asp:HyperLink ID="HyperLink5" Font-Size="large" ForeColor="white" runat="server"
                                                    Text='<%# Bind("saldo") %>' />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Gastos
                                            </td>
                                            <td>Nóminas
                                            </td>
                                            <td>Hitos
                                            </td>
                                            <td>Carpeta
                                            </td>
                                            <td>Total Gastos
                                            </td>
                                            <td>Total Ingresos
                                            </td>
                                            <td>Saldo
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                <cc1:HoverMenuExtender ID="hme_menu_solicitud" runat="Server" TargetControlID="Id_operacion"
                                    PopupControlID="pnl_menu_solicitud" PopupPosition="Right" OffsetX="0" OffsetY="0"
                                    HoverDelay="500" PopDelay="0" />
                            </ItemTemplate>
                            <ItemStyle CssClass="td_derecha" />
                            <HeaderStyle CssClass="td_cabecera" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tipo Operación">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("tipoOperacion") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lbltotalGastosTitulo" runat="server" Text="Total Gastos"></asp:Label>
                            </FooterTemplate>
                            <ItemStyle CssClass="td_derecha_grande" />
                            <HeaderStyle CssClass="td_cabecera_grande" />
                            <FooterStyle CssClass="td_cabecera_grande" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Cliente">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("cliente") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lbltotalGastos" runat="server" Text="0"></asp:Label>
                            </FooterTemplate>
                            <ItemStyle CssClass="td_derecha" />
                            <HeaderStyle CssClass="td_cabecera" />
                            <FooterStyle CssClass="td_cabecera" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sucursal">
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("sucursal") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lbltotalIngresosTitulo" runat="server" Text="Total Ingresos"></asp:Label>
                            </FooterTemplate>
                            <ItemStyle CssClass="td_derecha" />
                            <HeaderStyle CssClass="td_cabecera" />
                            <FooterStyle CssClass="td_cabecera" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Número bco.">
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("numeroBanco") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lbltotalIngresos" runat="server" Text="0"></asp:Label>
                            </FooterTemplate>
                            <ItemStyle CssClass="td_derecha" />
                            <HeaderStyle CssClass="td_cabecera" />
                            <FooterStyle CssClass="td_cabecera" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Número Factura">
                            <ItemTemplate>
                                <asp:Label ID="Label5" runat="server" Text='<%# Bind("factura") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lbltotalSaldoTitulo" runat="server" Text="Saldo"></asp:Label>
                            </FooterTemplate>
                            <ItemStyle CssClass="td_derecha" />
                            <HeaderStyle CssClass="td_cabecera" />
                            <FooterStyle CssClass="td_cabecera" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Comprador">
                            <ItemTemplate>
                                <asp:Label ID="Label6" runat="server" Text='<%# Bind("comprador") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lbltotalSaldo" runat="server" Text="0"></asp:Label>
                            </FooterTemplate>
                            <ItemStyle CssClass="td_derecha_grande" />
                            <HeaderStyle CssClass="td_cabecera_grande" />
                            <FooterStyle CssClass="td_cabecera_grande" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="rutComprador" HeaderText="Rut">
                            <ItemStyle CssClass="td_derecha" />
                            <HeaderStyle CssClass="td_cabecera" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Actividad">
                            <ItemTemplate>
                                <asp:HyperLink ID="lnk_Estados" runat="server" data-title-id="title-Tasador" CssClass="fancybox fancybox.iframe"
                                    Text='<%# Bind("nombreActividad") %>' NavigateUrl='<%# Bind("urlTareas") %>' />
                            </ItemTemplate>
                            <ItemStyle CssClass="td_derecha" />
                            <HeaderStyle CssClass="td_cabecera" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="fechaInicio" HeaderText="Inicio">
                            <ItemStyle CssClass="td_derecha" />
                            <HeaderStyle CssClass="td_cabecera" />
                        </asp:BoundField>
                        <asp:BoundField DataField="horasActividad" HeaderText="H/S">
                            <ItemStyle CssClass="td_derecha_chica" />
                            <HeaderStyle CssClass="td_cabecera_chica" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Estado">
                            <ItemTemplate>
                                <asp:HyperLink ID="lnk_estado" runat="server" data-title-id="title-work" data-fancybox-type="iframe"
                                    Width="40" Height="40" CssClass="fancyboxy fancybox.iframe" ImageUrl='<%# Bind("semaforo") %>'
                                    NavigateUrl='<%# Bind("url_estado") %>' />
                            </ItemTemplate>
                            <ItemStyle CssClass="td_derecha_mediana_2" />
                            <HeaderStyle CssClass="td_derecha_mediana_2" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sel">
                            <ItemTemplate>
                                <asp:CheckBox ID="chk" Visible="True" runat="server" onclick="javascript:check(this);" />
                            </ItemTemplate>
                            <ItemStyle CssClass="td_derecha_chica" />
                            <HeaderStyle CssClass="td_derecha_chica" />
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle CssClass="tr_cabecera" />
                    <RowStyle CssClass="tr_fila" />
                    <AlternatingRowStyle CssClass="tr_fila_alt" />
                </asp:GridView>
            </div>

             </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ib_buscar" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
        <asp:Button ID="bt_oculto_baja" runat="server" Style="display: none;" />
        <asp:Button ID="bt_oculto_producto" runat="server" Style="display: none;" />
        <asp:Button ID="bt_oculto_cambio_estado" runat="server" Style="display: none;" />
      
            <asp:Panel ID="pnl_baja" runat="server" Style="padding: 10px; background-color: #507cd1;">
                <table style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; background-color: #507cd1; color: White;">
                    <tr>
                        <td>¿Dar de baja las Operaciones Seleccionadas?
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;<input type="text" class="inputs" placeholder="Comentario" runat="server" maxlength="200" id="txtComentarioAccion" /></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: center;">
                            <asp:Button ID="bt_dar_baja" runat="server" Text="Dar de baja" CssClass="button" OnClick="bt_dar_baja_Click" />

                            <cc1:ConfirmButtonExtender ID="cbe_dar_baja" runat="server" TargetControlID="bt_dar_baja" ConfirmText="¿Esta seguro de dar de baja los ticket seleccionados?, se enviará un correo al usuario ingresador">
                            </cc1:ConfirmButtonExtender>
                            <asp:Button ID="bt_cancelar_baja" runat="server" CssClass="buttonGris" Text="Cancelar" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <cc1:ModalPopupExtender ID="mpe_baja" runat="server" BackgroundCssClass="modalBackground" CancelControlID="bt_cancelar_baja" PopupControlID="pnl_baja" TargetControlID="bt_oculto_baja">
            </cc1:ModalPopupExtender>

            <asp:Panel ID="pnl_cambio_estado" runat="server" Style="padding: 10px; background-color: #507cd1;">
                <table style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; background-color: #507cd1; color: White;">
                    <tr>
                        <td colspan="2">¿Cambiar de estado las operaciones seleccionados?
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <span>Estados</span>
                        </td>
                        <td>
                            <asp:DropDownList ID="dlCambioEstado" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: center;">
                            <asp:Button ID="btnCambioEstado" runat="server" Text="Cambiar Estado" CssClass="button" OnClick="btnCambioEstado_Click" />
                            <cc1:ConfirmButtonExtender ID="cbeCambioEstado" runat="server" TargetControlID="btnCambioEstado" ConfirmText="¿Esta seguro de cambiar estado?">
                            </cc1:ConfirmButtonExtender>
                            <asp:Button ID="btnCancelarCambioEstado" runat="server" CssClass="buttonGris" Text="Cancelar" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <cc1:ModalPopupExtender ID="mpeCambioEstado" runat="server" BackgroundCssClass="modalBackground" CancelControlID="btnCancelarCambioEstado" PopupControlID="pnl_cambio_estado" TargetControlID="bt_oculto_cambio_estado">
            </cc1:ModalPopupExtender>

            <asp:Panel ID="pnlCambioProducto" runat="server" Style="padding: 10px; background-color: #507cd1;">
                <table style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; background-color: #507cd1; color: White;">
                    <tr>
                        <td colspan="2">¿Cambia producto a las operaciones seleccionadas?
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <span>Productos</span>
                        </td>
                        <td>
                            <asp:DropDownList ID="dl_producto_cambio" runat="server"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: center;">
                            <asp:Button ID="btnCambiarProd" runat="server" Text="Cambiar Producto" CssClass="button" OnClick="btnCambiarProd_Click" />

                            <cc1:ConfirmButtonExtender ID="cbeCambioProducto" runat="server" TargetControlID="btnCambiarProd" ConfirmText="¿Esta seguro de cambiar de producto las Op. seleccionadas?">
                            </cc1:ConfirmButtonExtender>
                            <asp:Button ID="btnCancelarCambioProducto" runat="server" CssClass="buttonGris" Text="Cancelar" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <cc1:ModalPopupExtender ID="mpeCambioProducto" runat="server" BackgroundCssClass="modalBackground" CancelControlID="btnCancelarCambioProducto" PopupControlID="pnlCambioProducto" TargetControlID="bt_oculto_producto">
            </cc1:ModalPopupExtender>

            <br />

             <div class="div_objetos" id="divBotones" runat="server" style="border-top-width: 30px">
                <center>
                    <table style="font-size:xx-small">
                        <tr>                           
                            <td>
                              <center>
                                  <asp:ImageButton ID="ibBaja" runat="server"  ImageUrl="~/imagenes/sistema/static/hipotecario/delete.png" OnClick="ibBaja_Click"/>
                              </center>
                            </td>
                            <td>
                               <center>
                                   <asp:ImageButton ID="ibCambiarProducto" runat="server" ImageUrl="~/imagenes/sistema/static/hipotecario/asignar.png" OnClick="ibCambiarProducto_Click"/>
                               </center>
                            </td>
                            <td>
                              <center>
                                  <asp:ImageButton ID="ibCambiarEstado" runat="server" ImageUrl="~/imagenes/sistema/static/hipotecario/workflow.png" OnClick="ibCambiarEstado_Click"/>
                              </center>
                            </td>
                        </tr>
                        <tr>                           
                            <td>
                               <center><span>Dar de baja</span></center>
                            </td>
                            <td>
                                <center><span>Cambiar Producto</span></center>
                            </td>
                            <td>
                               <center><span>Cambiar Estado</span></center>
                            </td>
                        </tr>
                    </table>                   
                </center>
          </div>



       
    <br />
    <asp:HiddenField ID="hdnBusqueda" runat="server" Value="0" />
</asp:Content>
