<%@ Page Title="" Language="C#" MasterPageFile="~/modal2.Master" AutoEventWireup="true"
    CodeBehind="EstadosYGastos.aspx.cs" Inherits="sistemaAGP.Operacion_Hipotecario.modal.EstadosYGastos" %>

<%@ Register TagPrefix="cc1" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=3.5.40412.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <script type="text/javascript" src="/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="/jquery.mousewheel-3.0.6.pack.js"></script>
    <script type="text/javascript" src="/jquery.fancybox.js?v=2.0.6"></script>
    <link rel="Stylesheet" type="text/css" href="/jquery.fancybox.css?v=2.0.6" media="screen" />
    <script type="text/javascript" src="/javascript/ScrollableGrid.js"></script>
    <script type="text/javascript">
        function grilla_cabecera() {
           $('#<%=grDato.ClientID %>').Scrollable();
            $('#<%=grCambioEstado.ClientID %>').Scrollable();
        }
    </script>
    <asp:UpdatePanel runat="server" UpdateMode="Always" OnLoad="upGrillaHipoteca_Load"
        ID="upPrincipal">
        <ContentTemplate>
            <div class="divTituloModal">
                <img src="/imagenes/sistema/static/hipotecario/up.png" />
                <asp:Label ID="Label1" runat="server" Text="Cargas masivas"></asp:Label>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div style="clear: both">
        <br />
        <div class="div_objetos" id="div1" runat="server" style="border-top-width: 30px;
            vert-align: middle">
            <center>
                <img class="divTituloTexto" src="/imagenes/sistema/static/hipotecario/first1.png" />
                <asp:Label ID="Label5" CssClass="divTituloTexto" runat="server" Text="PASO 1: Cargar Archivo."></asp:Label>
                <asp:FileUpload ID="fileuploadExcel" runat="server" ForeColor="white" />
            </center>
        </div>
    </div>
    <br />
    <div style="clear: both">
        <div class="div_objetos" id="divPaso2" runat="server" style="border-top-width: 30px">
            <img class="divTituloTexto" src="/imagenes/sistema/static/hipotecario/flag2.png" />
            <asp:Label ID="Label6" CssClass="divTituloTexto" runat="server" Text="PASO 2: Subir y analizar."></asp:Label>
            <center>
                <table>
                    <tr>
                        <td>
                            <asp:ImageButton ID="ImgSubir" runat="server" ImageUrl="~/imagenes/sistema/static/hipotecario/arrow68.png"
                                ToolTip="Subir y analizar" OnClick="ImgSubir_Click" />
                            <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender8" runat="server" TargetControlID="ImgSubir"
                                ConfirmText="Realizar analisis">
                            </cc1:ConfirmButtonExtender>
                        </td>
                    </tr>
                </table>
            </center>
        </div>
    </div>
    <br />
    <div class="div_objetos" id="divPaso3" visible="False" runat="server" style="border-top-width: 30px;">
        <img class="divTituloTexto" src="/imagenes/sistema/static/hipotecario/stage.png" />
        <asp:Label ID="Label7" CssClass="divTituloTexto" runat="server" Text="PASO 3: Aplicar cambios a Filas correctas."></asp:Label>
        <center>
            <table>
                <tr>
                    <td>
                        <asp:Button ID="btnLimpiar" CssClass="buttonGris" runat="server" Text="Borrar todo"
                            OnClick="btnLimpiar_Click" />
                        <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server" TargetControlID="btnLimpiar"
                            ConfirmText="¿Borrar contenido del analisis?">
                        </cc1:ConfirmButtonExtender>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="btnGuardar" runat="server" CssClass="button" Text="Aplicar Cambios"
                            OnClick="btnGuardar_Click" />
                        <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="btnGuardar"
                            ConfirmText="¿Desea aplicar los cambios de las filas correctas?">
                        </cc1:ConfirmButtonExtender>
                    </td>
                </tr>
            </table>
        </center>
    </div>
    <br />
    <br />
    <div runat="server" id="divPaso2Grilla" visible="False">
        <cc1:TabContainer ID="tab_datos" runat="server" Width="100%" TabIndex="0" ActiveTabIndex="2"
            ScrollBars="Auto" OnActiveTabChanged="tab_datos_ActiveTabChanged">
            <cc1:TabPanel ID="tp_datos_de_contacto" runat="server" HeaderText="Cotizaciones"
                Width="100%">
                <HeaderTemplate>
                    Lista Nuevas Operaciones
                </HeaderTemplate>
                <ContentTemplate>
                    
                    <asp:GridView ID="grDato" runat="server" AutoGenerateColumns="False" CssClass="tabla_datos"
                        DataKeyNames="codigo_tipo_operacion,
                                        estado_revision,
                                        numero_banco,
                                        rut,
                                        nombre,
                                        apepat,
                                        apemat,
                                        id_cliente,
                                        tarifa_servicio,
                                        e_titulo,
                                        borrador,
                                        inscripcion_cbr,
                                        notaria,
                                        cbr,
                                        gp,
                                        dominio,
                                        cert_alzam,
                                        varios,
                                        copia_plano,
                                        insc_comercio,
                                        cert_numero,
                                        recep_final,
                                        avaluo_detallado,
                                        cert_no_exprop,
                                        archivo_judicial,
                                        cert_deslinde,
                                        envio,
                                        vivienda_social, 
                                        gestoria,
                                        comentario">
                        <Columns>
                             <asp:BoundField DataField="hoja_excel" HeaderText="Hoja Exel">
                                <ItemStyle CssClass="td_derecha_grande" />
                                <HeaderStyle CssClass="td_cabecera_grande" />
                            </asp:BoundField>
                            <asp:BoundField DataField="fila_excel" HeaderText="Fila Exel">
                                <ItemStyle CssClass="td_derecha" />
                                <HeaderStyle CssClass="td_cabecera" />
                            </asp:BoundField>
                            <asp:BoundField DataField="cliente" HeaderText="Cliente">
                                <ItemStyle CssClass="td_derecha" />
                                <HeaderStyle CssClass="td_cabecera" />
                            </asp:BoundField>
                            <asp:BoundField DataField="tipo_operacion" HeaderText="Tipo Operación">
                                <ItemStyle CssClass="td_derecha" />
                                <HeaderStyle CssClass="td_cabecera" />
                            </asp:BoundField>
                            <asp:BoundField DataField="numero_banco" HeaderText="Número Banco">
                                <ItemStyle CssClass="td_derecha" />
                                <HeaderStyle CssClass="td_cabecera" />
                            </asp:BoundField>
                            <asp:BoundField DataField="rut" HeaderText="Rut">
                                <ItemStyle CssClass="td_derecha" />
                                <HeaderStyle CssClass="td_cabecera" />
                            </asp:BoundField>                            
                            <asp:BoundField DataField="nombre" HeaderText="Nombre">
                                <ItemStyle CssClass="td_derecha" />
                                <HeaderStyle CssClass="td_cabecera" />
                            </asp:BoundField>
                            <asp:BoundField DataField="apepat" HeaderText="Apellido Paterno">
                                <ItemStyle CssClass="td_derecha" />
                                <HeaderStyle CssClass="td_cabecera" />
                            </asp:BoundField>
                            <asp:BoundField DataField="apemat" HeaderText="Apellido Materno">
                                <ItemStyle CssClass="td_derecha" />
                                <HeaderStyle CssClass="td_cabecera" />
                            </asp:BoundField>
                            <asp:BoundField DataField="total_gastos" HeaderText="Total gastos Cargados">
                                <ItemStyle CssClass="td_derecha" />
                                <HeaderStyle CssClass="td_cabecera" />
                            </asp:BoundField>
                             <asp:BoundField DataField="comentario" HeaderText="Comentario del usuario">
                                <ItemStyle CssClass="td_derecha_grandexl" />
                                <HeaderStyle CssClass="td_cabecera_grandexl" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Estado">
                                <ItemTemplate>
                                    <asp:HyperLink ID="lnk_estado" runat="server" data-title-id="title-work" data-fancybox-type="iframe"
                                        CssClass="fancyboxy fancybox.iframe" ImageUrl='<%# Bind("semaforo") %>'></asp:HyperLink></ItemTemplate>
                                <ItemStyle CssClass="td_derecha_chica" />
                                <HeaderStyle CssClass="td_derecha_chica" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="mensaje" HeaderText="Mensaje Resultado análisis">
                                <ItemStyle CssClass="td_derecha_grande" />
                                <HeaderStyle CssClass="td_cabecera_grande" />
                            </asp:BoundField>
                        </Columns>
                        <HeaderStyle CssClass="tr_cabecera" />
                        <RowStyle CssClass="tr_fila" />
                        <AlternatingRowStyle CssClass="tr_fila_alt" />
                    </asp:GridView>
                </ContentTemplate>
            </cc1:TabPanel>
            <cc1:TabPanel ID="TabPanel1" runat="server" HeaderText="Cotizaciones" Width="100%">
                <HeaderTemplate>
                    Lista Cambio de Estado
                </HeaderTemplate>
                <ContentTemplate>
                    
                    <asp:GridView ID="grCambioEstado" runat="server" AutoGenerateColumns="False" CssClass="tabla_datos"
                        DataKeyNames="id_nomina,
                                    id_cliente,
                                    rut,
                                    codigo_tipo_operacion,
                                    id_solicitud,
                                    estado_revision,
                                    e_titulo,
                                    borrador,
                                    inscripcion_cbr,
                                    tarifa_servicio,
                                    notaria,
                                    cbr,
                                    gp,
                                    dominio,
                                    cert_alzam,
                                    varios,
                                    copia_plano,
                                    insc_comercio,
                                    cert_numero,
                                    recep_final,
                                    avaluo_detallado,
                                    cert_no_exprop,
                                    archivo_judicial,
                                    cert_deslinde, 
                                    envio,
                                    vivienda_social, 
                                    gestoria,
                                    comentario">
                        <Columns>
                             <asp:BoundField DataField="hoja_excel" HeaderText="Hoja Exel">
                                <ItemStyle CssClass="td_derecha_grande" />
                                <HeaderStyle CssClass="td_cabecera_grande" />
                            </asp:BoundField>
                            <asp:BoundField DataField="fila_excel" HeaderText="Fila Exel">
                                <ItemStyle CssClass="td_derecha" />
                                <HeaderStyle CssClass="td_cabecera" />
                            </asp:BoundField>
                            <asp:BoundField DataField="cliente" HeaderText="Cliente">
                                <ItemStyle CssClass="td_derecha" />
                                <HeaderStyle CssClass="td_cabecera" />
                            </asp:BoundField>
                            <asp:BoundField DataField="nomina" HeaderText="Nómina">
                                <ItemStyle CssClass="td_derecha" />
                                <HeaderStyle CssClass="td_cabecera" />
                            </asp:BoundField>
                            <asp:BoundField DataField="id_solicitud" HeaderText="Número Agp">
                                <ItemStyle CssClass="td_derecha" />
                                <HeaderStyle CssClass="td_cabecera" />
                            </asp:BoundField>
                            <asp:BoundField DataField="numero_banco" HeaderText="Número Banco">
                                <ItemStyle CssClass="td_derecha" />
                                <HeaderStyle CssClass="td_cabecera" />
                            </asp:BoundField>
                            <asp:BoundField DataField="rut" HeaderText="Rut">
                                <ItemStyle CssClass="td_derecha" />
                                <HeaderStyle CssClass="td_cabecera" />
                            </asp:BoundField>                            
                            <asp:BoundField DataField="total_gastos" HeaderText="Total gastos Cargados">
                                <ItemStyle CssClass="td_derecha" />
                                <HeaderStyle CssClass="td_cabecera" />
                            </asp:BoundField>        
                             <asp:BoundField DataField="comentario" HeaderText="Comentario del usuario">
                                <ItemStyle CssClass="td_derecha_grandexl" />
                                <HeaderStyle CssClass="td_cabecera_grandexl" />
                            </asp:BoundField>                   
                            <asp:TemplateField HeaderText="Estado">
                                <ItemTemplate>
                                    <asp:HyperLink ID="lnk_estado" runat="server" data-title-id="title-work" data-fancybox-type="iframe"
                                        CssClass="fancyboxy fancybox.iframe" ImageUrl='<%# Bind("semaforo") %>'></asp:HyperLink></ItemTemplate>
                                <ItemStyle CssClass="td_derecha" />
                                <HeaderStyle CssClass="td_derecha" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="mensaje" HeaderText="Mensaje Resultado análisis">
                                <ItemStyle CssClass="td_derecha_grande" />
                                <HeaderStyle CssClass="td_cabecera_grande" />
                            </asp:BoundField>
                        </Columns>
                        <HeaderStyle CssClass="tr_cabecera" />
                        <RowStyle CssClass="tr_fila" />
                        <AlternatingRowStyle CssClass="tr_fila_alt" />
                    </asp:GridView>
                </ContentTemplate>
            </cc1:TabPanel>
        </cc1:TabContainer>
    </div>
    <br />
    <br />
    <br />
    <br />
    <asp:HiddenField ID="hdnidTipoNomina" runat="server" Value="0" />
    <div class="divInfo">
        <center>
            <asp:Label ID="lblMessage" runat="server" 
                Text="Esperando carga y validación de Archivo Macro de Excel .xlsm"></asp:Label>
        </center>
    </div>
</asp:Content>
