<%@ Page Title="" Language="C#" MasterPageFile="~/modal2.Master" AutoEventWireup="true"
    CodeBehind="OrdenPedido.aspx.cs" Inherits="sistemaAGP.OrdenTrabajo.modal.OrdenPedido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <script type="text/javascript" src="../../jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="../../jquery.mousewheel-3.0.6.pack.js"></script>
    <script type="text/javascript" src="../../jquery.fancybox.js?v=2.0.6"></script>
    <link rel="Stylesheet" type="text/css" href="../../jquery.fancybox.css?v=2.0.6" media="screen" />
    <script type="text/javascript" src="../../javascript/ScrollableGrid.js"></script>
    <script type="text/javascript">
        $("a.fancybox").fancybox({
            maxWidth: 1000,
            maxHeight: 500,
            minWidth: 1000,
            minHeight: 500,
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
            },

            afterClose: function () {
                //refresco la grilla de panel de control
                $('#<%=botonReload.ClientID%>').click();

            }


        });
    </script>
    <div class="divTituloModal">
        <img src="../../imagenes/sistema/static/panel_control/nominas.png" />
        <asp:Label ID="Label1" runat="server" Text="Orden de Pedido"></asp:Label>
    </div>

    <div style="clear: both" id="DivBloqueo" runat="server" visible="False">
        <asp:Image ID="Image2" runat="server" ImageUrl="~/imagenes/sistema/static/hipotecario/soloLecturaGrande.png"
            ToolTip="Operación sin intentos" />
    </div>
    <div style="clear: both;">
        <table class="tabla_datos" style="font-size: large">
            <tr class="tr_fila">
                <td colspan="6" class="tr_cabecera" align="center">
                    <asp:Label ID="Label2" runat="server" Text="DATOS DE CABECERA"></asp:Label>
                </td>
            </tr>
            <tr class="tr_fila">
                <td class="tr_cabecera">Número Pedido
                </td>
                <td class="td_cabecera_grande">
                    <asp:Label ID="lblNumerOrden" runat="server" Text=""></asp:Label>
                </td>
                <td class="tr_cabecera">Cliente
                </td>
                <td class="td_cabecera_grande">
                    <asp:Label ID="lblCliente" runat="server" Text=""></asp:Label>
                </td>
                <td class="tr_cabecera">Sucursal
                </td>
                <td class="td_cabecera_grande">
                    <asp:Label ID="lblSucursal" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr class="tr_fila">
                <td colspan="6" class="tr_cabecera" align="center">
                    <asp:Label ID="Label3" runat="server" Text="DATOS DE LA FACTURA"></asp:Label>
                </td>
            </tr>
            <tr class="tr_fila">
                <td class="tr_cabecera">Número Factura
                </td>
                <td class="td_cabecera_grande">
                    <asp:Label ID="lblFacturaNumero" runat="server" Text=""></asp:Label>
                </td>
                <td class="tr_cabecera">Fecha Facturación
                </td>
                <td class="td_cabecera_grande">
                    <asp:Label ID="lblFacturaFecha" runat="server" Text=""></asp:Label>
                </td>
                <td class="tr_cabecera">Neto
                </td>
                <td class="td_cabecera_grande">
                    <asp:Label ID="lblFacturaNeto" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr class="tr_fila">
                <td class="tr_cabecera">Compra Para
                </td>
                <td class="td_cabecera_grande">
                    <asp:Label ID="lblCompraPara" runat="server" Text=""></asp:Label>
                </td>
                <td class="tr_cabecera">Term. Especial
                </td>
                <td class="td_cabecera_grande">
                    <asp:Label ID="lblTerminacionEspecial" runat="server" Text=""></asp:Label>
                </td>
                <td class="tr_cabecera">Impuesto Verde
                </td>
                <td class="td_cabecera_grande">
                    <asp:Label ID="lblImpuestoVerde" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="tr_cabecera">Ver Factura
                </td>
                <td class="td_cabecera_grande">
                    <asp:HyperLink runat="server" ID="hlFactura" Target="_blank" NavigateUrl="">Factura</asp:HyperLink>
                </td>
                <td class="tr_cabecera">Abono Cliente
                </td>
                <td class="td_cabecera_grande">
                    <asp:Label ID="lblAbonoCliente" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr class="tr_fila">
                <td class="tr_cabecera">Forma de Pago
                </td>
                <td class="td_cabecera_grande">
                    <asp:Label ID="lblFormaPago" runat="server" Text=""></asp:Label>
                </td>
                <td class="tr_cabecera">Financiera
                </td>
                <td class="td_cabecera_grande">
                    <asp:Label ID="lblFinanciera" runat="server" Text=""></asp:Label>
                </td>
                <td class="tr_cabecera">Quién Paga
                </td>
                <td class="td_cabecera_grande">
                    <asp:Label ID="lblQuienPaga" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr class="tr_fila">
                <td colspan="6" class="tr_cabecera" align="center">
                    <asp:Label ID="Label4" runat="server" Text="DATOS DEL ADQUIRIENTE"></asp:Label>
                </td>
            </tr>
            <tr class="tr_fila">
                <td class="tr_cabecera">Rut
                </td>
                <td class="td_cabecera_grande">
                    <asp:Label ID="lblCompradorRut" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr class="tr_fila">
                <td class="tr_cabecera">Nombre
                </td>
                <td class="td_cabecera_grande">
                    <asp:Label ID="lblCompradorNombre" runat="server" Text=""></asp:Label>
                </td>
                <td class="tr_cabecera">Apellido Paterno
                </td>
                <td class="td_cabecera_grande">
                    <asp:Label ID="lblCompApepat" runat="server" Text=""></asp:Label>
                </td>
                <td class="tr_cabecera">Apellido Materno
                </td>
                <td class="td_cabecera_grande">
                    <asp:Label ID="lblCompApemat" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr class="tr_fila">
                <td colspan="6" class="tr_cabecera" align="center">
                    <asp:Label ID="Label5" runat="server" Text="DATOS DEL VEHICULO"></asp:Label>
                </td>
            </tr>
            <tr class="tr_fila">
                <td class="tr_cabecera">Marca
                </td>
                <td class="td_cabecera_grande">
                    <asp:Label ID="lblVehiculoMarca" runat="server" Text=""></asp:Label>
                </td>
                <td class="tr_cabecera">Modelo
                </td>
                <td class="td_cabecera_grande">
                    <asp:Label ID="lblVehiculoModelo" runat="server" Text=""></asp:Label>
                </td>
                <td class="tr_cabecera">Año
                </td>
                <td class="td_cabecera_grande">
                    <asp:Label ID="lblVehiculoAnio" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr class="tr_fila">
                <td class="tr_cabecera">Cilindrada
                </td>
                <td class="td_cabecera_grande">
                    <asp:Label ID="lblVehiculoCilindrada" runat="server" Text=""></asp:Label>
                </td>
                <td class="tr_cabecera">Puertas
                </td>
                <td class="td_cabecera_grande">
                    <asp:Label ID="lblNumeroPuertas" runat="server" Text=""></asp:Label>
                </td>
                <td class="tr_cabecera">Asientos
                </td>
                <td class="td_cabecera_grande">
                    <asp:Label ID="lblVehiculoNumAsientos" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr class="tr_fila">
                <td class="tr_cabecera">Peso Bruto
                </td>
                <td class="td_cabecera_grande">
                    <asp:Label ID="lblVehiculoPesoBruto" runat="server" Text=""></asp:Label>
                </td>
                <td class="tr_cabecera">Carga
                </td>
                <td class="td_cabecera_grande">
                    <asp:Label ID="lblVehiculoCarga" runat="server" Text=""></asp:Label>
                </td>
                <td class="tr_cabecera">Combustible
                </td>
                <td class="td_cabecera_grande">
                    <asp:Label ID="lblVehiculoCombustible" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr class="tr_fila">
                <td class="tr_cabecera">Color
                </td>
                <td class="td_cabecera_grande">
                    <asp:Label ID="lblVehiculoColor" runat="server" Text=""></asp:Label>
                </td>
                <td class="tr_cabecera">Motor
                </td>
                <td class="td_cabecera_grande">
                    <asp:Label ID="lblVehiculoMotor" runat="server" Text=""></asp:Label>
                </td>
                <td class="tr_cabecera">Chasis
                </td>
                <td class="td_cabecera_grande">
                    <asp:Label ID="lblVehiculoChasis" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr class="tr_fila">
                <td class="tr_cabecera">Vin
                </td>
                <td class="td_cabecera_grande">
                    <asp:Label ID="lblVehiculoVin" runat="server" Text=""></asp:Label>
                </td>
                <td class="tr_cabecera">Cit
                </td>
                <td class="td_cabecera_grande">
                    <asp:Label ID="lblVehiculoCit" runat="server" Text=""></asp:Label>
                </td>
                <td class="tr_cabecera">PATENTE
                </td>
                <td class="td_cabecera_grande">
                    <asp:Label ID="lblPatente" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr class="tr_fila">
                <td class="tr_cabecera">Observación
                </td>
                <td class="td_cabecera_grandexl" colspan="5">
                    <asp:Label ID="lblObservacion" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div>
        <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="upd">
            <ContentTemplate>
                <asp:Button ID="botonReload" Style="display: none;" runat="server" Text="" OnClick="botonReload_Click" />
                <table>
                    <tr>                       
                        <td>
                             <asp:DropDownList ID="dlProductos" AutoPostBack="true" CssClass="ddl" Font-Size="X-Small" Width="300" runat="server" OnSelectedIndexChanged="dlProductos_SelectedIndexChanged" ></asp:DropDownList>
                        </td>
                         <td>
                             <a runat="server" id="lnk" class="fancybox fancybox.iframe">
                             <img alt="Productos" src="../../imagenes/sistema/static/hipotecario/comprador.png"/>
                             </a>
                        </td>
                        <td>
                            <asp:Label ID="lblIdAgp" Font-Size="X-Small" runat="server" Text="Sin operación"></asp:Label>
                            <img alt="ok" id="imgOk" runat="server" src="../../imagenes/sistema/static/109_AllAnnotations_Error_16x16_72.png" />
                        </td>
                    </tr>
                </table>    

            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="botonReload" />
                <asp:PostBackTrigger ControlID="ibSalir" />
            </Triggers>
        </asp:UpdatePanel>
    
    </div>
    <br />
    <div style="clear: both"><br /> </div>
    <asp:HiddenField ID="hdIdCliente" runat="server" />
    <asp:HiddenField ID="hdOrdenTrabajoActividad" runat="server" />
    <asp:HiddenField ID="hdIdOrdenPedido" runat="server" />
    <div class="divInfo" style="clear: both" id="divInfo" runat="server">
        <center>
            <table>
                <tr>
                    <td>
                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="../../imagenes/sistema/static/panel_control/comprobante.png"
                            OnClientClick="window.print();" />
                    </td>
                    <td>
                        <asp:ImageButton ID="ibSalir" runat="server" ImageUrl="~/imagenes/sistema/static/hipotecario/salir.png"
                            OnClick="ibSalir_Click" />
                    </td>
                </tr>
            </table>
        </center>
    </div>
</asp:Content>
