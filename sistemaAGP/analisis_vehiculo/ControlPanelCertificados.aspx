<%@ Page Title="" Language="C#" MasterPageFile="~/Master2.Master" AutoEventWireup="true"
    CodeBehind="ControlPanelCertificados.aspx.cs" Inherits="sistemaAGP.analisis_vehiculo.ControlPanelCertificados" %>

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
                    <td class="td_derecha">Total Operaciones de este mes
                        <br />
                        <asp:Label ID="lblTotalMes" runat="server" Font-Size="x-large" Text="0"></asp:Label>
                        <br />
                        de un total de
                        <asp:Label ID="lblTotalOp" runat="server" Font-Size="x-small" Text="0"></asp:Label>
                    </td>
                    <td class="td_derecha">Operaciones CAVs de este mes
                        <br />
                        <asp:Label ID="lblRojas" runat="server" Font-Size="x-large" Text=""></asp:Label>
                        <br />
                        de un total de 
                        <asp:Label ID="lblrojasprom" runat="server" Font-Size="x-small" Text=""></asp:Label>
                    </td>
                    <td class="td_derecha">Operaciones CAVs y multas de este mes<br />
                        <asp:Label ID="lblVerdes" runat="server" Font-Size="x-large" Text=""></asp:Label>
                        <br />
                        de un total de 
                        <asp:Label ID="lblVerdesprom" runat="server" Font-Size="x-small" Text=""></asp:Label>
                    </td>
                    <td class="td_derecha">Operaciones INFOCAR de este mes<br />
                        <asp:Label ID="lblAmarillas" runat="server" Font-Size="x-large" Text=""></asp:Label>
                        <br />
                        de un total de
                        <asp:Label ID="lblAmarillasprom" runat="server" Font-Size="x-small" Text=""></asp:Label>
                    </td>
                    <td class="td_derecha">Documentos comprados este mes<br />
                        <asp:Label ID="lblPromedioDias" runat="server" Font-Size="x-large" Text=""></asp:Label>
                        <br />
                        CAVS y Multas
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        <asp:ImageButton ID="ibExcel" runat="server" ToolTip="Reporte en excel" ImageUrl="../imagenes/sistema/static/hipotecario/XLS_File_24.png"
                            OnClick="ibExcel_Click" />
                        <a href="../preinscripcion/SoliInfoAuto.aspx" class="fancybox fancybox.iframe">
                            <img height="30px" width="30px" src="../imagenes/sistema/static/infoAuto/InfoAutoIcono2.png" />
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
                        <asp:DropDownList ID="dlSucursal" runat="server" CssClass="ddl" AutoPostBack="True" OnSelectedIndexChanged="dlSucursal_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="dlUsuario" runat="server" CssClass="ddl">
                        </asp:DropDownList>
                    </td>
                    <td rowspan="3">
                        <asp:TextBox ID="txtBcoMultiple" runat="server" CssClass="inputs" Height="100%" TextMode="MultiLine" Text="Patentes"
                            onFocus="if (this.value=='Patentes') this.value='';" onBlur="if (this.value.trim()=='')this.value='Patentes';"></asp:TextBox>
                    </td>

                </tr>

                <tr>
                    <td>
                        <asp:DropDownList ID="dlEstado" runat="server" CssClass="ddl">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="dlProducto" runat="server" CssClass="ddl">
                        </asp:DropDownList>
                    </td>
                    <td></td>
                </tr>
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

            <div id="divGrid" style="clear: both">
                <asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" CssClass="tabla_datos" DataKeyNames="id_solicitud,tipo_operacion,terminado">
                    <Columns>
                        <asp:TemplateField HeaderText="ID">
                            <ItemTemplate>
                                <asp:HyperLink ID="lnk_id" Font-Size="Small" runat="server" Text='<%# Bind("id_solicitud") %>' />
                                <asp:Panel ID="pnl_menu_solicitud" runat="server" CssClass="popupmenu">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:HyperLink ID="lnk_comGastos" runat="server" class="fancybox fancybox.iframe"
                                                    ToolTip="Comprobante gastos" ImageUrl="~/imagenes/sistema/static/infoAuto/iconoProcesosChico.png"
                                                    NavigateUrl='<%# Bind("url_procesos") %>' />
                                            </td>
                                            <td>
                                                <asp:HyperLink ID="lnk_contratos" runat="server" data-title-id="title-work" data-fancybox-type="iframe"
                                                    Width="40" Height="40" CssClass="fancyboxy fancybox.iframe" ImageUrl='<%# Bind("img_contrato") %>'
                                                    NavigateUrl='<%# Bind("url_contrato") %>' />
                                            </td>
                                            <td>
                                                <asp:HyperLink ID="HyperLink1" runat="server" data-title-id="title-work" data-fancybox-type="iframe"
                                                    Width="40" Height="40" CssClass="fancybox fancybox.iframe" ImageUrl='<%# Bind("img_ingreso") %>'
                                                    NavigateUrl='<%# Bind("url_ingreso") %>' />
                                            </td>

                                        </tr>
                                        <tr>
                                            <td>
                                                Procesos
                                            </td>
                                            <td>
                                                Contratos
                                            </td>
                                            <td>
                                                Nueva Operación
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
                        <asp:TemplateField HeaderText="Patente">
                            <ItemTemplate>
                                <asp:Label ID="lblPatente" ForeColor="#5f5992" Font-Size="Small" Font-Bold="true" runat="server" Text='<%# Bind("patente") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="td_derecha" />
                            <HeaderStyle CssClass="td_cabecera" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fecha">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("fecha") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="td_derecha" />
                            <HeaderStyle CssClass="td_cabecera" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Producto">
                            <ItemTemplate>
                                <asp:Label ID="Label6" runat="server" Text='<%# Bind("producto") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="td_derecha" />
                            <HeaderStyle CssClass="td_cabecera" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sucursal">
                            <ItemTemplate>
                        <center>  <asp:Label ID="Label3" runat="server" Text='<%# Bind("sucursal") %>'></asp:Label></center>
                            </ItemTemplate>
                            <ItemStyle CssClass="td_derecha_grande" />
                            <HeaderStyle CssClass="td_cabecera_grande" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Usuario">
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("usuario") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="td_derecha_grande" />
                            <HeaderStyle CssClass="td_cabecera_grande" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ID Asociado">
                            <ItemTemplate>
                                 <asp:HyperLink ID="lnk_e_asociado" runat="server" data-title-id="title-work" data-fancybox-type="iframe"
                                    Width="40" Height="40" CssClass="fancyboxy fancybox.iframe" Text='<%# Bind("id_asociado") %>'
                                    NavigateUrl='<%# Bind("url_e_operacion_asociada") %>' />
                            </ItemTemplate>
                            <ItemStyle CssClass="td_derecha" />
                            <HeaderStyle CssClass="td_cabecera" />
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="Limitaciones">
                            <ItemTemplate>
                                <asp:Label ID="lblLim" runat="server" Text='<%# Bind("limitacion_dominio") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle CssClass="td_derecha" />
                            <HeaderStyle CssClass="td_cabecera" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="estado" HeaderText="Estado">
                            <ItemStyle CssClass="td_derecha_grande" />
                            <HeaderStyle CssClass="td_cabecera_grande" />
                        </asp:BoundField>
                      
                        <asp:TemplateField HeaderText="Docs.">
                            <ItemTemplate>
                                <asp:HyperLink ID="lnk_doc" runat="server" data-title-id="title-work" data-fancybox-type="iframe"
                                    Width="40" Height="40" CssClass="fancyboxy fancybox.iframe" ImageUrl='<%# Bind("img_documentos") %>'
                                    NavigateUrl='<%# Bind("url_documentos") %>' />
                            </ItemTemplate>
                            <ItemStyle CssClass="td_derecha_mediana_2" />
                            <HeaderStyle CssClass="td_derecha_mediana_2" />
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Sel">
                        <ItemTemplate>
                            <asp:CheckBox ID="chk" Visible="true" runat="server"/>
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
            
            
            <asp:Button ID="bt_oculto_habilitar" runat="server" Style="display: none;" />
             <asp:Panel ID="pnl_habilitar" runat="server" Style="padding: 10px; background-color: #507cd1;">
                <table style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; background-color: #507cd1; color: White;">
                    <tr>
                        <td>¿Habilitar los contratos seleccionados?
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <input type="text" maxlength="200" class="inputs" placeholder="Comentario" max="150" runat="server" id="txtHabilitarComentario" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: center;">
                            <asp:Button ID="bt_habilitar" runat="server" Text="Habilitar" CssClass="button" OnClick="bt_habilitar_Click" />

                            <cc1:ConfirmButtonExtender ID="cbe_habilitar" runat="server" TargetControlID="bt_habilitar" ConfirmText="¿Está seguro de habilitar los contratos seleccionados?">
                            </cc1:ConfirmButtonExtender>
                            <asp:Button ID="bt_cancelar_habilitar" runat="server" CssClass="buttonGris" Text="Cancelar" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <cc1:ModalPopupExtender ID="mpe_habilitar" runat="server" BackgroundCssClass="modalBackground" CancelControlID="bt_cancelar_habilitar" PopupControlID="pnl_habilitar" TargetControlID="bt_oculto_habilitar">
            </cc1:ModalPopupExtender>

            <div class="div_objetos" id="divBotones" runat="server" style="border-top-width: 30px">
                <center>
                    <table style="font-size: xx-small">
                        <tr>
                            <td>
                                <center>
                                    <asp:ImageButton ID="ibHabilitar" runat="server" ImageUrl="~/imagenes/sistema/static/hipotecario/key.png" OnClick="ibHabilitar_Click"   />
                                </center>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <center><span>Habilitar</span></center>
                            </td>
                        </tr>
                    </table>

                </center>
            </div>


        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="ib_buscar" />
             <asp:PostBackTrigger ControlID="ibHabilitar" />
             <asp:PostBackTrigger ControlID="bt_habilitar" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
