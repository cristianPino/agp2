<%@ Page Title="" Language="C#" MasterPageFile="~/Master2.Master" AutoEventWireup="true" CodeBehind="ControlPanel.aspx.cs" Inherits="sistemaAGP.Incidencias.ControlPanel" %>

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
        function check(check) { }
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


    <table class="tabla_datos" width="100%">
        <tr>
            <td colspan="6">Dashboard
            </td>
        </tr>
        <tr>
            <td class="td_derecha">Total Incidencias
                        <br />
                <asp:Label ID="lblTotalOp" runat="server" Font-Size="x-large" Text="345"></asp:Label>
            </td>
            <td class="td_derecha">Abiertas
                        <br />
                <asp:Label ID="lblRojas" runat="server" Font-Size="x-large" Text=""></asp:Label>
                <br />
                <asp:Label ID="lblrojasprom" runat="server" Font-Size="x-small" Text=""></asp:Label>
            </td>
            <td class="td_derecha">Cerradas<br />
                <asp:Label ID="lblVerdes" runat="server" Font-Size="x-large" Text=""></asp:Label>
                <br />
                <asp:Label ID="lblVerdesprom" runat="server" Font-Size="x-small" Text=""></asp:Label>
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
                <asp:HyperLink ID="hlCargaMasiva" NavigateUrl="modal/IngresoIncidencia.aspx" class="fancybox fancybox.iframe" ImageUrl="../imagenes/sistema/static/hipotecario/up.png" runat="server"></asp:HyperLink>
            </td>
        </tr>
    </table>
    <asp:UpdatePanel runat="server" ID="udpForm" UpdateMode="Conditional" OnLoad="upGrillaHipoteca_Load">
        <ContentTemplate>
            <table>
                <tr>
                    <td>
                        <input type="text" class="inputs" placeholder="Patente" maxlength="6" runat="server" id="txtPatente" />
                    </td>
                    <td>
                        <input type="text" class="inputs" placeholder="Nº ticket" maxlength="6" runat="server" id="txtTicket" />
                    </td>
                    <td rowspan="2">
                        <asp:TextBox ID="txtBcoMultiple" runat="server" CssClass="inputs" Height="100%" TextMode="MultiLine" Width="350px"></asp:TextBox>


                    </td>
                </tr>
                <tr>
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
                    <td colspan="3" align="center">
                        <asp:ImageButton ID="ib_buscar" runat="server" ImageUrl="../imagenes/sistema/static/buscar_chico.png" ToolTip="Buscar Todo" OnClick="ib_buscar_Click" />
                        <asp:Image ID="imgCantidadOperaciones" runat="server" ToolTip="Operaciones encontradas"
                            ImageUrl="../imagenes/sistema/static/hipotecario/Visibility_button_32.png" Height="20px"
                            Width="20px" />
                        <asp:Label ID="lblConteoOperaciones" runat="server" Font-Size="x-small" Text="0"></asp:Label>
                    </td>
                </tr>
            </table>


            <asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" CssClass="tabla_datos"
                DataKeyNames="id_incidencia,id_solicitud,id_solicitud_nueva,id_estado,cuenta_usuario_responsable,id_incidencia_estado">
                <Columns>
                    <asp:TemplateField HeaderText="Nº Ticket">
                        <ItemTemplate>
                            <asp:HyperLink ID="lnkIdIncidencia" Font-Size="small" runat="server" Text='<%# Bind("id_incidencia") %>' />

                            <asp:Panel ID="pnl_menu_solicitud" runat="server" CssClass="popupmenu">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:HyperLink ID="lnk_comGastos" runat="server" class="fancybox fancybox.iframe"
                                                ToolTip="Administración de la incidencia" ImageUrl="~/imagenes/sistema/static/hipotecario/ajustes.png"
                                                NavigateUrl='<%# Bind("url_administracion") %>' />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Administración de la incidencia
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <cc1:HoverMenuExtender ID="hme_menu_solicitud" runat="Server" TargetControlID="lnkIdIncidencia"
                                PopupControlID="pnl_menu_solicitud" PopupPosition="Right" OffsetX="0" OffsetY="0"
                                HoverDelay="500" PopDelay="0" />
                        </ItemTemplate>
                        <ItemStyle CssClass="td_derecha" />
                        <HeaderStyle CssClass="td_cabecera" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Cliente">
                        <ItemTemplate>
                            <asp:Label ID="lblCliente" runat="server" Text='<%# Bind("cliente") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle CssClass="td_derecha" />
                        <HeaderStyle CssClass="td_cabecera" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Sucursal">
                        <ItemTemplate>
                            <asp:Label ID="lblSucursal" runat="server" Text='<%# Bind("sucursal") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle CssClass="td_derecha" />
                        <HeaderStyle CssClass="td_cabecera" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Ingreso">
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("fecha_ingreso") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle CssClass="td_derecha" />
                        <HeaderStyle CssClass="td_cabecera" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Ingresador">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("usuario_ingreso") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle CssClass="td_derecha" />
                        <HeaderStyle CssClass="td_cabecera" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Tipo">
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("tipo_incidencia") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle CssClass="td_derecha" />
                        <HeaderStyle CssClass="td_cabecera" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Patente / Chasis">
                        <ItemTemplate>
                            <asp:Label ID="lblPatente" runat="server" Text='<%# Bind("patente") %>'></asp:Label>
                            / 
                                <asp:Label ID="lblChasis" runat="server" Text='<%# Bind("chasis") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle CssClass="td_derecha" />
                        <HeaderStyle CssClass="td_cabecera" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="AGP Antiguo / Nuevo">
                        <ItemTemplate>
                            <asp:Label ID="lblidOrigen" runat="server" Text='<%# Bind("id_solicitud") %>'></asp:Label>
                            / 
                                <asp:Label ID="lblIdNuevo" runat="server" Text='<%# Bind("id_solicitud_nueva") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle CssClass="td_derecha" />
                        <HeaderStyle CssClass="td_cabecera" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Estado">
                        <ItemTemplate>
                            <asp:Label ID="lblEstado" runat="server" Text='<%# Bind("estado") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle CssClass="td_derecha" />
                        <HeaderStyle CssClass="td_cabecera" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Usuario actual">
                        <ItemTemplate>
                            <asp:Label ID="lblUsuarioResponsable" runat="server" Text='<%# Bind("usuario_responsable") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle CssClass="td_derecha" />
                        <HeaderStyle CssClass="td_cabecera" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Ultimo comentario">
                        <ItemTemplate>
                            <asp:Label ID="lblUltimoComentario" runat="server" Text='<%# Bind("comentario") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle CssClass="td_derecha_grande" />
                        <HeaderStyle CssClass="td_cabecera_grande" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Fecha Ultimo comentario">
                        <ItemTemplate>
                            <asp:Label ID="lblFechaCom" runat="server" Text='<%# Bind("fecha_comentario") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle CssClass="td_derecha" />
                        <HeaderStyle CssClass="td_cabecera" />

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
            <br />
            <asp:Button ID="bt_oculto_baja" runat="server" Style="display: none;" />
            <asp:Button ID="bt_oculto_asignar" runat="server" Style="display: none;" />
            <asp:Button ID="bt_oculto_cambio_estado" runat="server" Style="display: none;" />
            <asp:Button ID="bt_oculto_comentario" runat="server" Style="display: none;" />

            <asp:Panel ID="pnel_comentario" runat="server" Style="padding: 10px; background-color: #507cd1;">
                <table style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; background-color: #507cd1; color: White;">
                    <tr>
                        <td>¿Agregar comentarios?
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <input type="text" maxlength="200" class="inputs" placeholder="Comentario" runat="server" id="txtComentarioNuevo" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: center;">
                            <asp:Button ID="bt_comentario" runat="server" Text="Comentar" CssClass="button" OnClick="bt_comentario_Click" />

                            <cc1:ConfirmButtonExtender ID="cbe_comentario" runat="server" TargetControlID="bt_comentario" ConfirmText="¿Esta seguro de agregar comentario a los ticket seleccionados?, se enviará un correo al usuario ingresador">
                            </cc1:ConfirmButtonExtender>
                            <asp:Button ID="bt_cancelar_comentario" runat="server" CssClass="buttonGris" Text="Cancelar" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <cc1:ModalPopupExtender ID="mpe_comentario" runat="server" BackgroundCssClass="modalBackground" CancelControlID="bt_cancelar_comentario" PopupControlID="pnel_comentario" TargetControlID="bt_oculto_comentario">
            </cc1:ModalPopupExtender>

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

                            <cc1:ConfirmButtonExtender ID="cbe_dar_baja" runat="server" TargetControlID="bt_dar_baja" ConfirmText="¿Esta seguro de dar de baja los ticket seleccionados?, se enviará un correo al usuario ingresador">
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
                            <asp:DropDownList ID="dlAsignarUsuario" runat="server"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <span>Estados</span>
                        </td>
                        <td>
                            <asp:DropDownList ID="dlAsignarEstados" runat="server"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: center;">
                            <input type="text" class="inputs" placeholder="Comentario" runat="server" maxlength="200" id="txtAsignarComentario" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: center;">
                            <asp:Button ID="bt_asignar" runat="server" Text="Asignar" CssClass="button" OnClick="bt_asignar_Click" />
                            <cc1:ConfirmButtonExtender ID="cbe_asignar" runat="server" TargetControlID="bt_asignar" ConfirmText="¿Esta seguro de asignar los ticket seleccionados?, se enviará un correo al usuario ingresador">
                            </cc1:ConfirmButtonExtender>
                            <asp:Button ID="bt_cancelar_asignar" runat="server" CssClass="buttonGris" Text="Cancelar" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <cc1:ModalPopupExtender ID="mpe_asignar" runat="server" BackgroundCssClass="modalBackground" CancelControlID="bt_cancelar_asignar" PopupControlID="pnl_asignar" TargetControlID="bt_oculto_asignar">
            </cc1:ModalPopupExtender>


            <asp:Panel ID="pnl_cambio_estado" runat="server" Style="padding: 10px; background-color: #507cd1;">
                <table style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; background-color: #507cd1; color: White;">
                    <tr>
                        <td colspan="2">¿Cambiar de estado los tickets seleccionados?
                        </td>

                    </tr>
                    <tr>
                        <td>
                            <span>Estados</span>
                        </td>
                        <td>
                            <asp:DropDownList ID="dlEstadoCambios" runat="server"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <input type="text" class="inputs" placeholder="Comentario" runat="server" maxlength="200" id="txtComentarioEstado" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: center;">
                            <asp:Button ID="bt_cambio_estado" runat="server" Text="Cambiar Estado" CssClass="button" OnClick="bt_cambio_estado_Click" />
                            <cc1:ConfirmButtonExtender ID="cbe_cambio_estado" runat="server" TargetControlID="bt_cambio_estado" ConfirmText="¿Esta seguro de cambiar estado?, se enviará un correo al usuario ingresador">
                            </cc1:ConfirmButtonExtender>
                            <asp:Button ID="bt_cancelar_cambio_estado" runat="server" CssClass="buttonGris" Text="Cancelar" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <cc1:ModalPopupExtender ID="mpe_cambio_estado" runat="server" BackgroundCssClass="modalBackground" CancelControlID="bt_cancelar_cambio_estado" PopupControlID="pnl_cambio_estado" TargetControlID="bt_oculto_cambio_estado">
            </cc1:ModalPopupExtender>





            <div class="div_objetos" id="divBotones" runat="server" style="border-top-width: 30px">
                <center>
                    <table style="font-size: xx-small">
                        <tr>
                            <td>
                                <center>
                                    <asp:ImageButton ID="ibComentario" runat="server" ImageUrl="~/imagenes/sistema/static/hipotecario/note.png" OnClick="ibComentario_Click" />
                                </center>
                            </td>
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
                            <td>
                                <center>
                                    <asp:ImageButton ID="ibCambiarEstado" runat="server" ImageUrl="~/imagenes/sistema/static/hipotecario/workflow.png" OnClick="ibCambiarEstado_Click" />
                                </center>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <center><span>Comentario</span></center>
                            </td>
                            <td>
                                <center><span>Dar de baja</span></center>
                            </td>
                            <td>
                                <center><span>Asignar</span></center>
                            </td>
                            <td>
                                <center><span>Cambiar Estado</span></center>
                            </td>
                        </tr>
                    </table>

                </center>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="ib_buscar" />
            <asp:PostBackTrigger ControlID="ibBaja" />
            <asp:PostBackTrigger ControlID="ibAsignar" />
            <asp:PostBackTrigger ControlID="ibCambiarEstado" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
