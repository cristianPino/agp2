<%@ Page Title="" Language="C#" MasterPageFile="~/Master2.Master" AutoEventWireup="true"
    CodeBehind="Inicio.aspx.cs" Inherits="sistemaAGP.OrdenTrabajo.Inicio" %>

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
                closeBtn: false,
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
                helpers: {
                    overlay: { closeClick: false }
                },
                keys: {
                    close: null
                },
                beforeShow: function () {
                    // added 50px to avoid scrollbars inside fancybox
                    this.width = ($('.fancybox-iframe').contents().find('html').width());
                    this.height = ($('.fancybox-iframe').contents().find('html').height());
                }, afterClose: function () {
                    //refresco la grilla de panel de control
                    UpdFila();
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


    <script type="text/javascript">

        function UpdFila() {

            var idOtrabajo = $('#<%=hdId.ClientID %>').val();
            var usuario = $('#<%=usuarioSesion.ClientID %>').val();

            $.ajax({
                type: "POST",
                url: "../OrdenTrabajo/servicio.asmx/GetUltimoOt",
                data: "{'idOt':'" + idOtrabajo + "' , 'idUsuarioSession':'" + usuario + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    var log = response.d;

                    //                     var objGrid = $('#<%=gr_dato.ClientID %>');
                    var tabla = document.getElementById("ctl00_ContentPlaceHolder1_gr_dato");



                    for (var i = 0; i < tabla.rows.length; i++) {




                     
                        if (tabla.rows[i].cells[0].innerText.trim() == idOtrabajo) {


                            if (log.PuedeVerOt == "no") {

                                tabla.deleteRow(i);


                                return;
                            }                                               



                            if (log.EstadoRevision == 1) {

                                tabla.rows[i].cells[0].getElementsByTagName("img")[0].src = "../imagenes/sistema/static/hipotecario/soloLecturaGrande.png";

                            }
                            else {

                                tabla.rows[i].cells[0].getElementsByTagName("img")[0].src = "";

                            }



                            tabla.rows[i].cells[8].innerHTML = "<a onclick=\"javascript:seleccion('" + idOtrabajo + "');\" class=\"fancybox fancybox.iframe\" href=\"" + log.ActividadDeOrdenTrabajo.Url.trim() + "?idOrdenTrabajoActividad=" + log.IdOtLogEncriptado + "\">" + log.ActividadDeOrdenTrabajo.Descripcion + "</a>";
                            tabla.rows[i].cells[9].innerText = log.Usuario.Nombre.toUpperCase();                         


                            tabla.rows[i].cells[10].innerText = parseInt(log.OrdenTrabajo.IdSolicitud);

                            var horas = parseInt(log.HorasActividad);
                            var sla = parseInt(log.ActividadDeOrdenTrabajo.Sla);
                            var rutaSemaforo = "";
                           
                            if (log.ActividadDeOrdenTrabajo.IdActividad == 4) {
                                rutaSemaforo = "../imagenes/sistema/static/hipotecario/finish.jpg";
                            }
                            else
                            {
                                if (horas < (sla / 2)) {
                                    rutaSemaforo = "../imagenes/sistema/static/verde.png";
                                }
                                else if (horas >= (sla / 2) && horas < sla) {
                                    rutaSemaforo = "../imagenes/sistema/static/amarillo.png";
                                }
                                else if (horas >= sla) {
                                    rutaSemaforo = "../imagenes/sistema/static/rojo.png";
                                }
                            }

                            tabla.rows[i].cells[11].innerHTML = "<a class=\"fancybox fancybox.iframe\" href=\"modal/Flujo.aspx?idOrdenTrabajoActividad=" + log.IdOtLogEncriptado + "\"> <img src=\"" + rutaSemaforo + "\" style=\"border-width:0px;\"\></a>";


                        }


                    }

                },

                failure: function (msg) {
                    alert(msg);
                }

            });
        }

    </script>
    <script type="text/javascript">

        function seleccion(fila) {
            $('#<%=hdId.ClientID %>').val(fila);
        }
    </script>


    <script type="text/javascript">
        function deleteRow(imageElement) {
            var img = $(imageElement);
            imageElement.setAttribute("id", "selectedRow");
            //            alert($("selectedRow").siblings(":image"));
            var row = $(imageElement).closest('tr');
            $(row).slideToggle("fast");
        }
    </script>


    <table class="tabla_datos" width="100%">
        <tr>
            <td colspan="6">Dashboard
            </td>
        </tr>
        <tr>
            <td class="td_derecha">Total Operaciones
                <br />
                <asp:Label ID="lblTotalOp" runat="server" Font-Size="x-large" Text="0"></asp:Label>
            </td>
            <td class="td_derecha">Espera de Factura
                <br />
                <asp:Label ID="lblEsperaFactura" runat="server" Font-Size="x-large" Text="0"></asp:Label>
                <br />
                <asp:Label ID="lblEsperaFacturaprom" runat="server" Font-Size="x-small" Text="0%"></asp:Label>
            </td>
            <td class="td_derecha">En asignación<br />
                <asp:Label ID="lblAsignacion" runat="server" Font-Size="x-large" Text="0"></asp:Label>
                <br />
                <asp:Label ID="lblAsignacionprom" runat="server" Font-Size="x-small" Text="0%"></asp:Label>
            </td>
            <td class="td_derecha">Esperando Ingreso AGP<br />
                <asp:Label ID="lblIngreso" runat="server" Font-Size="x-large" Text="0"></asp:Label>
                <br />
                <asp:Label ID="lblIngresoprom" runat="server" Font-Size="x-small" Text="0%"></asp:Label>
            </td>
            <td class="td_derecha">En AGP<br />
                <asp:Label ID="lblIngresadas" runat="server" Font-Size="x-large" Text="0"></asp:Label>
                <br />
                <asp:Label ID="lblIngresadasprom" runat="server" Font-Size="x-small" Text="0%"></asp:Label>
            </td>
            <td class="td_derecha">Con reparo<br />
                <asp:Label ID="lblReparo" runat="server" Font-Size="x-large" Text="0"></asp:Label>
                <br />
                <asp:Label ID="lblReparoProm" runat="server" Font-Size="x-small" Text="0%"></asp:Label>
            </td>
            <td class="td_derecha">De baja<br />
                <asp:Label ID="lblBaja" runat="server" Font-Size="x-large" Text="0"></asp:Label>
                <br />
                <asp:Label ID="lblBajaprom" runat="server" Font-Size="x-small" Text="0%"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="6">
                <a class="fancybox fancybox.iframe" href="modal/Grafico.aspx">
                    <img src="../imagenes/sistema/static/infoAuto/chart.png" />
                </a>
                <asp:ImageButton ID="ibExcel" runat="server" ToolTip="Reporte en excel" ImageUrl="../imagenes/sistema/static/hipotecario/XLS_File_24.png"
                    OnClick="ibExcel_Click" />
                <a id="link_garantia" runat="server" class="fancybox fancybox.iframe" href="">
                    <asp:Image ID="imgGarantia" runat="server" />
                </a>
                <a id="link_factura" runat="server" class="fancybox fancybox.iframe" href="">
                    <asp:Image ID="imgFactura" runat="server" />
                </a>
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
                <span style="font-size: xx-small">Desde</span>
                <asp:TextBox ID="txtDesde" runat="server" Font-Size="X-Small" CssClass="inputs" TabIndex="4" Width="80%"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtDesde" Format="dd/MM/yyyy" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Fecha incorrecta" ValidationGroup="buscar" ControlToValidate="txtDesde" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"></asp:RegularExpressionValidator>
            </td>
            <td>
                <span style="font-size: xx-small">Hasta</span>
                <asp:TextBox ID="txtHasta" runat="server" Font-Size="X-Small" CssClass="inputs" TabIndex="4" Width="80%"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtHasta" Format="dd/MM/yyyy" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Fecha incorrecta" ValidationGroup="buscar" ControlToValidate="txtHasta" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"></asp:RegularExpressionValidator>
            </td>           
            <td>
                <span style="font-size: xx-small">Factura</span>
                <input type="text" class="inputs" placeholder="Buscar" runat="server" id="txtBuscar" style="font-Size:X-Small; width:80%;"/>
            </td>

        </tr>
        <tr>    
             <td>
                <asp:DropDownList ID="dlActividad" runat="server" CssClass="ddl" AutoPostBack="False">
                </asp:DropDownList>
            </td>       
            <td>
                <asp:DropDownList ID="dlGrupo" runat="server" CssClass="ddl" AutoPostBack="true" OnSelectedIndexChanged="dlGrupo_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td>
                 <asp:DropDownList ID="dlUsuario" runat="server" CssClass="ddl" AutoPostBack="False">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:DropDownList ID="dlCliente" runat="server" CssClass="ddl" AutoPostBack="False">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <center>
                    <asp:ImageButton ID="ib_buscar" runat="server" ImageUrl="../imagenes/sistema/static/buscar_chico.png"
                        OnClick="ib_buscar_Click" />
                </center>
            </td>
        </tr>
    </table>
    <br />
    <asp:UpdatePanel ID="upd" runat="server" UpdateMode="Conditional" OnLoad="upGrillaHipoteca_Load">
        <ContentTemplate>
            <asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" CssClass="tabla_datos"
                OnRowDataBound="gr_dato_RowDataBound" DataKeyNames="idFlujo,idActividad,idOrden,cuenta_usuario_ingreso">
                <Columns>
                    <asp:TemplateField HeaderText="Id">
                        <ItemTemplate>

                            <asp:HyperLink ID="id_operacion" runat="server" Text='<%# Bind("idOrden") %>' />
                            <asp:Panel ID="pnl_menu_solicitud" runat="server" CssClass="popupmenu">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:HyperLink ID="HyperLink1" runat="server" class="fancybox fancybox.iframe" ToolTip="Carpeta"
                                                ImageUrl="~/imagenes/sistema/static/panel_control/carpeta.png" Text="Carpeta"
                                                NavigateUrl='<%# Bind("urlCarpeta") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Carpeta digital
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
                    <asp:TemplateField HeaderText="Factura">
                        <ItemTemplate>
                            <asp:Label ID="lblFactura" ForeColor="#660066" runat="server" Text='<%# Bind("numeroFactura") %>'></asp:Label>                                                     
                        </ItemTemplate>
                        <ItemStyle CssClass="td_derecha" />
                        <HeaderStyle CssClass="td_cabecera" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="patente" HeaderText="Patente">
                        <ItemStyle CssClass="td_derecha" />
                        <HeaderStyle CssClass="td_cabecera" />
                    </asp:BoundField>
                    <asp:BoundField DataField="cliente" HeaderText="Cliente">
                        <ItemStyle CssClass="td_derecha" />
                        <HeaderStyle CssClass="td_cabecera" />
                    </asp:BoundField>                      
                    <asp:BoundField DataField="forma_pago" HeaderText="Forma de Pago">
                        <ItemStyle CssClass="td_derecha" />
                        <HeaderStyle CssClass="td_cabecera" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ejecutivoIngreso" HeaderText="Ejecutivo Ingreso">
                        <ItemStyle CssClass="td_derecha" />
                        <HeaderStyle CssClass="td_cabecera" />
                    </asp:BoundField>
                    <asp:BoundField DataField="fechaIngreso" HeaderText="fechaIngreso">
                        <ItemStyle CssClass="td_derecha" />
                        <HeaderStyle CssClass="td_cabecera" />
                    </asp:BoundField>               
                    <asp:BoundField DataField="usuario_ejecutivo" HeaderText="Ejecutivo Encargado">
                        <ItemStyle CssClass="td_derecha" />
                        <HeaderStyle CssClass="td_cabecera" />
                    </asp:BoundField>      
                    <asp:TemplateField HeaderText="Actividad">
                        <ItemTemplate>
                            <asp:HyperLink ID="lnk_Estados" runat="server" data-title-id="title-Tasador" onclick='<%# "javascript:seleccion(" + "&#39;" + Eval("idOrden") + "&#39;);" %> '
                                CssClass="fancybox fancybox.iframe" Text='<%# Bind("nombreActividad") %>' NavigateUrl='<%# Bind("urlTareas") %>' />
                        </ItemTemplate>
                        <ItemStyle CssClass="td_derecha_grande" />
                        <HeaderStyle CssClass="td_cabecera_grande" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="usuarioActual" HeaderText="Usuario Actual">
                        <ItemStyle CssClass="td_derecha" />
                        <HeaderStyle CssClass="td_cabecera" />
                    </asp:BoundField> 
                    <asp:BoundField DataField="id_solicitud" HeaderText="Número AGP">
                        <ItemStyle CssClass="td_derecha" />
                        <HeaderStyle CssClass="td_cabecera" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Estado">
                        <ItemTemplate>
                            <asp:HyperLink ID="lnk_estado" runat="server" data-title-id="title-work" data-fancybox-type="iframe"
                                CssClass="fancybox fancybox.iframe" ImageUrl='<%# Bind("semaforo") %>' NavigateUrl='<%# Bind("urlSemaforo") %>' />
                        </ItemTemplate>
                        <ItemStyle CssClass="td_derecha_mediana_2" />
                        <HeaderStyle CssClass="td_derecha_mediana_2" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Sel">
                        <ItemTemplate>
                            <asp:CheckBox ID="chk" Visible="true" runat="server" onclick="javascript:check(this);" />
                        </ItemTemplate>
                        <ItemStyle CssClass="td_derecha_chica" />
                        <HeaderStyle CssClass="td_derecha_chica" />
                    </asp:TemplateField>
                </Columns>
                <HeaderStyle CssClass="tr_cabecera" />
                <RowStyle CssClass="tr_fila" />
                <AlternatingRowStyle CssClass="tr_fila_alt" />
            </asp:GridView>
            <asp:HiddenField ID="hdId" runat="server" />
            <asp:HiddenField ID="usuarioSesion" runat="server" />


            <asp:Button ID="bt_oculto_baja" runat="server" Style="display: none;" />
            <asp:Button ID="bt_oculto_asignar" runat="server" Style="display: none;" />

            <asp:Panel ID="pnl_baja" runat="server" Style="padding: 10px; background-color: #507cd1;">
                <table style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; background-color: #507cd1; color: White;">
                    <tr>
                        <td>¿Dar de baja los ticket seleccionados?
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <input type="text" maxlength="200" class="inputs" placeholder="Comentario" runat="server" id="txtBajaComentario" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: center;">
                            <asp:Button ID="bt_dar_baja" runat="server" Text="Dar de baja" CssClass="button" OnClick="bt_dar_baja_Click" />

                            <cc1:ConfirmButtonExtender ID="cbe_dar_baja" runat="server" TargetControlID="bt_dar_baja" ConfirmText="¿Esta seguro de dar de baja los ticket seleccionados?">
                            </cc1:ConfirmButtonExtender>
                            <asp:Button ID="bt_cancelar_baja" runat="server" CssClass="buttonGris" Text="Cancelar" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <cc1:ModalPopupExtender ID="mpe_baja" runat="server" BackgroundCssClass="modalBackground" CancelControlID="bt_cancelar_baja" PopupControlID="pnl_baja" TargetControlID="bt_oculto_baja">
            </cc1:ModalPopupExtender>


            <asp:Panel ID="pnl_asignar" runat="server" Style="padding: 10px; background-color: #507cd1;">
                <table style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; background-color: #507cd1; color: White;">
                    <tr>
                        <td colspan="2">¿Asignar los ticket seleccionados?
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <span>Usuario</span>
                        </td>
                        <td>
                            <asp:DropDownList ID="dlUsuarios" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <span>Comentario</span>
                        </td>
                        <td>
                            <input type="text" class="inputs" placeholder="Deja un comentario" runat="server" id="txtComentarioAccion" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: center;">
                            <asp:Button ID="bt_asignar" runat="server" Text="Asignar" CssClass="button" OnClick="bt_asignar_Click" />
                            <cc1:ConfirmButtonExtender ID="cbe_asignar" runat="server" TargetControlID="bt_asignar" ConfirmText="¿Esta seguro de asignar los ticket seleccionados?">
                            </cc1:ConfirmButtonExtender>
                            <asp:Button ID="bt_cancelar_asignar" runat="server" CssClass="buttonGris" Text="Cancelar" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <cc1:ModalPopupExtender ID="mpe_asignar" runat="server" BackgroundCssClass="modalBackground" CancelControlID="bt_cancelar_asignar" PopupControlID="pnl_asignar" TargetControlID="bt_oculto_asignar">
            </cc1:ModalPopupExtender>

            <div class="div_objetos" id="divBotones" runat="server" style="border-top-width: 30px">
                <center>
                    <table style="font-size: xx-small">
                        <tr>
                            <td>
                                <center>
                                    <asp:ImageButton ID="ibBaja" runat="server" ImageUrl="~/imagenes/sistema/static/hipotecario/delete.png" OnClick="ibBaja_Click" />
                                </center>
                            </td>
                            <td>
                                <center>
                                    <asp:ImageButton ID="ibAsignar" runat="server" ImageUrl="~/imagenes/sistema/static/hipotecario/asignar.png" OnClick="ibAsignar_Click" />
                                </center>
                            </td>

                        </tr>
                        <tr>
                            <td>
                                <center><span>Dar de baja</span></center>
                            </td>
                            <td>
                                <center><span>Asignar</span></center>
                            </td>

                        </tr>
                    </table>

                </center>
            </div>


        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="ibBaja" />
            <asp:PostBackTrigger ControlID="ibAsignar" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
