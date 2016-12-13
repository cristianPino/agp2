<%@ Page Language="C#" MasterPageFile="~/AGP.Master" AutoEventWireup="true" CodeBehind="InfoAutoDet.aspx.cs"
    Inherits="sistemaAGP.InfoAutoDet" Title="Administracion Info Auto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="ajaxToolkit" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=3.5.40412.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMenu" runat="server">
    <script type="text/javascript" src="../jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="../jquery.mousewheel-3.0.6.pack.js"></script>
    <script type="text/javascript" src="../jquery.fancybox.js?v=2.0.6"></script>
    <link rel="Stylesheet" type="text/css" href="../jquery.fancybox.css?v=2.0.6" media="screen" />
    <script type="text/javascript" src="../javascript/ScrollableGrid.js"></script>
     <script type="text/javascript">
         function grilla_cabecera() {
             $('#<%=gr_dato.ClientID %>').Scrollable(); 
             $('#<%=grCav.ClientID %>').Scrollable(); 
         }
    </script>
    
    <script type="text/javascript">
        $(document).ready(function () {
            $('.fancybox').fancybox({
                maxWidth: 900,
                maxHeight: 600,
                fitToView: false,
                width: 900,
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
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoCentral" runat="server">

    <div id="div_titulo">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/imagenes/sistema/static/infoAuto/InfoAutoIcono2.png"
            Height="30px" Width="30px" />
        <asp:Label ID="Label2" runat="server" Text="InfoCar" Style="font-size: 18pt; font-weight: bold;"></asp:Label>
    </div>
    <br />

    <table class="table">
        <tr>
            <td>
                NºAGP
            </td>
            <td>
                <asp:TextBox ID="txt_operacion" runat="server" Font-Names="Arial" Font-Size="X-Small"
                    MaxLength="30" Width="110px" TabIndex="3" Height="19px"></asp:TextBox>
            </td>
            <td>
                Patente
            </td>
            <td>
                <asp:TextBox ID="txt_patente" runat="server" Font-Names="Arial" Font-Size="X-Small"
                    MaxLength="30" Width="93px" TabIndex="3" Height="19px"></asp:TextBox>
            </td>
            <td>
                Desde
            </td>
            <td>
                <asp:TextBox ID="txtDesde" runat="server"  Font-Size="X-Small" TabIndex="4" Height="19px"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtDesde" Format="dd/MM/yyyy" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Fecha incorrecta" ValidationGroup="buscar" ControlToValidate="txtDesde" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"></asp:RegularExpressionValidator>
            </td>
            <td>
                Hasta
            </td>
            <td>
                <asp:TextBox ID="txtHasta" runat="server"  Font-Size="X-Small" TabIndex="4" Height="19px"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtHasta" Format="dd/MM/yyyy" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Fecha incorrecta" ValidationGroup="buscar" ControlToValidate="txtHasta" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"></asp:RegularExpressionValidator>


            </td>
            <td>
                Estado InfoCar
            </td>
            <td>
                <asp:DropDownList ID="dlEstado" runat="server" />
            </td>
            
            <td>
                Nueva
            </td>
            <td>
                <a href="../preinscripcion/SoliInfoAuto.aspx" class="fancybox fancybox.iframe">
                    <img height="32px" width="32px" src="../imagenes/sistema/static/infoAuto/InfoAutoIcono2.png" />
                </a>
            </td>
            <td>
                <asp:ImageButton ID="ib_buscar" runat="server" ImageUrl="../imagenes/sistema/static/infoAuto/lupaazul.png"
                ValidationGroup="buscar" Height="21px" Width="30px" Style="text-align: center" OnClick="btn_buscar_click" />
            </td>
        </tr>
    </table>
   
    <div>
    <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
    </div>
    
    <br />
    <div style="z-index: 0">
    <cc1:TabContainer ID="tab_datos" runat="server" Width="100%" TabIndex="0" ActiveTabIndex="0" 
        ScrollBars="Auto" onload="tab_datos_Load">
        <cc1:TabPanel ID="tpInfoCar" runat="server" HeaderText="Mis InfoCar"
            Width="100%">
            <ContentTemplate>
                
                <asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" 
                    CssClass="tabla_datos" Font-Size="XX-Small"
                    OnSelectedIndexChanged="gr_dato_SelectedIndexChanged" 
                    EnableModelValidation="True">
                    <Columns>
                        <asp:TemplateField HeaderText="NºAGP">
                            <ItemTemplate>
                                <strong>
                                    <asp:HyperLink ID="lnkid" runat="server" Text='<%# Bind("id_solicitud") %>' /></strong>
                            </ItemTemplate>
                            <ItemStyle CssClass="td_derecha" />
                            <HeaderStyle CssClass="td_cabecera" />
                        </asp:TemplateField>
                        <asp:BoundField AccessibleHeaderText="fecha" DataField="fecha" HeaderText="Fecha">
                            <ItemStyle CssClass="td_derecha" />
                            <HeaderStyle CssClass="td_cabecera" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Patente">
                            <ItemTemplate>
                                <strong>
                                    <asp:HyperLink ID="lnkpatente" runat="server" Text='<%# Bind("patente") %>' />
                                </strong>
                            </ItemTemplate>
                            <ItemStyle CssClass="td_derecha" />
                            <HeaderStyle CssClass="td_cabecera" />
                        </asp:TemplateField>
                        <asp:BoundField AccessibleHeaderText="marca" DataField="marca" HeaderText="Marca">
                            <ItemStyle CssClass="td_derecha" />
                            <HeaderStyle CssClass="td_cabecera" />
                        </asp:BoundField>
                        <asp:BoundField AccessibleHeaderText="motor" DataField="motor" HeaderText="Motor">
                            <ItemStyle CssClass=" td_derecha_grande" />
                            <HeaderStyle CssClass="td_cabecera_grande" />
                        </asp:BoundField>
                        <asp:BoundField AccessibleHeaderText="propietario" DataField="propietario" HeaderText="Propietario">
                            <ItemStyle CssClass="td_derecha_grande" />
                            <HeaderStyle CssClass="td_cabecera_grande" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Encargo por Robo">
                            <ItemTemplate>
                                <strong>
                                    <asp:HyperLink ID="lnkencargo" runat="server" Text='<%# Bind("encargo") %>' />
                                </strong>
                            </ItemTemplate>
                            <ItemStyle CssClass="td_derecha" />
                            <HeaderStyle CssClass="td_cabecera" />
                        </asp:TemplateField>
                        <asp:BoundField AccessibleHeaderText="limitacionDominio" DataField="limitacionDominio"
                            HeaderText="Limitación al Dominio">
                            <ItemStyle CssClass="td_derecha_grande" />
                            <HeaderStyle CssClass="td_cabecera_grande" />
                        </asp:BoundField>
                        <asp:BoundField AccessibleHeaderText="revtec" DataField="revisionTecnica" HeaderText="Revisión Técnica">
                            <ItemStyle CssClass="td_derecha" />
                            <HeaderStyle CssClass="td_cabecera" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Estado Multas">
                            <ItemTemplate>
                                <asp:HyperLink ID="lnkPdf" runat="server" Target="_blank" ImageUrl='<%# Bind("estado") %>'
                                    ToolTip='<%# Bind("toolTipEstado") %>' />
                            </ItemTemplate>
                            <ItemStyle CssClass="td_derecha" />
                            <HeaderStyle CssClass="td_cabecera" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Monto estimado Multas">
                            <ItemTemplate>
                                <strong>
                                    <asp:HyperLink ID="lnkmontoMulta" runat="server" Text='<%# Bind("montoMulta") %>' /></strong>
                            </ItemTemplate>
                            <ItemStyle CssClass="td_derecha" />
                            <HeaderStyle CssClass="td_cabecera" />
                        </asp:TemplateField>
                        <asp:BoundField AccessibleHeaderText="estadoFamilia" DataField="estadoFamilia" HeaderText="Estado">
                            <ItemStyle CssClass="td_derecha_grande" />
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
                        <asp:TemplateField HeaderText="Informe">
                            <ItemTemplate>
                                <asp:HyperLink ID="lnkPdf" runat="server" Text='<%# Bind("estadoInforme") %>' data-fancybox-type="iframe"
                                    CssClass="fancybox fancybox.iframe" ImageUrl='<%# Bind("imagenInforme") %>' NavigateUrl='<%# Bind("urlInforme") %>' />
                            </ItemTemplate>
                            <ItemStyle CssClass="td_derecha" />
                            <HeaderStyle CssClass="td_cabecera" />
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle CssClass="tr_cabecera" />
                    <RowStyle CssClass="tr_fila" />
                    <AlternatingRowStyle CssClass="tr_fila_alt" />
                </asp:GridView>
            </ContentTemplate>
        </cc1:TabPanel>
        <cc1:TabPanel ID="tpCav" runat="server" HeaderText="Mis Cav" TabIndex="1"
            Width="100%">
            <ContentTemplate>
                
                 <asp:GridView ID="grCav" runat="server" AutoGenerateColumns="False" CssClass="tabla_datos" Font-Size="xx-small"
                    EnableModelValidation="True">
                    <Columns>
                        <asp:TemplateField HeaderText="NºAGP">
                            <ItemTemplate>
                                <strong>
                                    <asp:HyperLink ID="lnkid" runat="server" Text='<%# Bind("id_solicitud") %>' /></strong>
                            </ItemTemplate>
                            <ItemStyle CssClass="td_derecha" />
                            <HeaderStyle CssClass="td_cabecera" />
                        </asp:TemplateField>
                        <asp:BoundField AccessibleHeaderText="fecha" DataField="fecha" HeaderText="Fecha">
                            <ItemStyle CssClass="td_derecha" />
                            <HeaderStyle CssClass="td_cabecera" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Patente">
                            <ItemTemplate>
                                <strong>
                                    <asp:HyperLink ID="lnkpatente" runat="server" Text='<%# Bind("patente") %>' />
                                </strong>
                            </ItemTemplate>
                            <ItemStyle CssClass="td_derecha" />
                            <HeaderStyle CssClass="td_cabecera" />
                        </asp:TemplateField>
                        <asp:BoundField AccessibleHeaderText="marca" DataField="marca" HeaderText="Marca">
                            <ItemStyle CssClass="td_derecha" />
                            <HeaderStyle CssClass="td_cabecera" />
                        </asp:BoundField>
                        <asp:BoundField AccessibleHeaderText="motor" DataField="motor" HeaderText="Motor">
                            <ItemStyle CssClass=" td_derecha_grande" />
                            <HeaderStyle CssClass="td_cabecera_grande" />
                        </asp:BoundField>
                        <asp:BoundField AccessibleHeaderText="propietario" DataField="propietario" HeaderText="Propietario">
                            <ItemStyle CssClass="td_derecha_grande" />
                            <HeaderStyle CssClass="td_cabecera_grande" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Encargo por Robo">
                            <ItemTemplate>
                                <strong>
                                    <asp:HyperLink ID="lnkencargo" runat="server" Text='<%# Bind("encargo") %>' />
                                </strong>
                            </ItemTemplate>
                            <ItemStyle CssClass="td_derecha" />
                            <HeaderStyle CssClass="td_cabecera" />
                        </asp:TemplateField>
                        <asp:BoundField AccessibleHeaderText="limitacionDominio" DataField="limitacionDominio"
                            HeaderText="Limitación al Dominio">
                            <ItemStyle CssClass="td_derecha_grande" />
                            <HeaderStyle CssClass="td_cabecera_grande" />
                        </asp:BoundField>
                        <asp:BoundField AccessibleHeaderText="estadoFamilia" DataField="estadoFamilia" HeaderText="Estado">
                            <ItemStyle CssClass="td_derecha_grande" />
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
                        <asp:TemplateField HeaderText="Informe">
                            <ItemTemplate>
                                <asp:HyperLink ID="lnkPdf" runat="server" Text='<%# Bind("estadoInforme") %>' data-fancybox-type="iframe"
                                    CssClass="fancybox fancybox.iframe" ImageUrl='<%# Bind("imagenInforme") %>' NavigateUrl='<%# Bind("urlInforme") %>' />
                            </ItemTemplate>
                            <ItemStyle CssClass="td_derecha" />
                            <HeaderStyle CssClass="td_cabecera" />
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle CssClass="tr_cabecera" />
                    <RowStyle CssClass="tr_fila" />
                    <AlternatingRowStyle CssClass="tr_fila_alt" />
                </asp:GridView>                

            </ContentTemplate>
        </cc1:TabPanel>
         <cc1:TabPanel ID="TabPanel1" runat="server" HeaderText="Mis Cav + Multas" TabIndex="2"
            Width="100%">
            <ContentTemplate>
                
                 <asp:GridView ID="grMultas" runat="server" AutoGenerateColumns="False" CssClass="tabla_datos" Font-Size="xx-small"
                    EnableModelValidation="True">
                    <Columns>
                        <asp:TemplateField HeaderText="NºAGP">
                            <ItemTemplate>
                                <strong>
                                    <asp:HyperLink ID="lnkid" runat="server" Text='<%# Bind("id_solicitud") %>' /></strong>
                            </ItemTemplate>
                            <ItemStyle CssClass="td_derecha" />
                            <HeaderStyle CssClass="td_cabecera" />
                        </asp:TemplateField>
                        <asp:BoundField AccessibleHeaderText="fecha" DataField="fecha" HeaderText="Fecha">
                            <ItemStyle CssClass="td_derecha" />
                            <HeaderStyle CssClass="td_cabecera" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Patente">
                            <ItemTemplate>
                                <strong>
                                    <asp:HyperLink ID="lnkpatente" runat="server" Text='<%# Bind("patente") %>' />
                                </strong>
                            </ItemTemplate>
                            <ItemStyle CssClass="td_derecha" />
                            <HeaderStyle CssClass="td_cabecera" />
                        </asp:TemplateField>
                        <asp:BoundField AccessibleHeaderText="marca" DataField="marca" HeaderText="Marca">
                            <ItemStyle CssClass="td_derecha" />
                            <HeaderStyle CssClass="td_cabecera" />
                        </asp:BoundField>
                        <asp:BoundField AccessibleHeaderText="motor" DataField="motor" HeaderText="Motor">
                            <ItemStyle CssClass=" td_derecha_grande" />
                            <HeaderStyle CssClass="td_cabecera_grande" />
                        </asp:BoundField>
                        <asp:BoundField AccessibleHeaderText="propietario" DataField="propietario" HeaderText="Propietario">
                            <ItemStyle CssClass="td_derecha_grande" />
                            <HeaderStyle CssClass="td_cabecera_grande" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Encargo por Robo">
                            <ItemTemplate>
                                <strong>
                                    <asp:HyperLink ID="lnkencargo" runat="server" Text='<%# Bind("encargo") %>' />
                                </strong>
                            </ItemTemplate>
                            <ItemStyle CssClass="td_derecha" />
                            <HeaderStyle CssClass="td_cabecera" />
                        </asp:TemplateField>
                        <asp:BoundField AccessibleHeaderText="limitacionDominio" DataField="limitacionDominio"
                            HeaderText="Limitación al Dominio">
                            <ItemStyle CssClass="td_derecha_grande" />
                            <HeaderStyle CssClass="td_cabecera_grande" />
                        </asp:BoundField>
                         <asp:TemplateField HeaderText="Estado Multas">
                            <ItemTemplate>
                                <asp:HyperLink ID="lnkPdf" runat="server" Target="_blank" ImageUrl='<%# Bind("estado") %>'
                                    ToolTip='<%# Bind("toolTipEstado") %>' />
                            </ItemTemplate>
                            <ItemStyle CssClass="td_derecha" />
                            <HeaderStyle CssClass="td_cabecera" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Monto estimado Multas">
                            <ItemTemplate>
                                <strong>
                                    <asp:HyperLink ID="lnkmontoMulta" runat="server" Text='<%# Bind("montoMulta") %>' /></strong>
                            </ItemTemplate>
                            <ItemStyle CssClass="td_derecha" />
                            <HeaderStyle CssClass="td_cabecera" />
                        </asp:TemplateField>
                        <asp:BoundField AccessibleHeaderText="estadoFamilia" DataField="estadoFamilia" HeaderText="Estado">
                            <ItemStyle CssClass="td_derecha_grande" />
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
                        <asp:TemplateField HeaderText="Informe">
                            <ItemTemplate>
                                <asp:HyperLink ID="lnkPdf" runat="server" Text='<%# Bind("estadoInforme") %>' data-fancybox-type="iframe"
                                    CssClass="fancybox fancybox.iframe" ImageUrl='<%# Bind("imagenInforme") %>' NavigateUrl='<%# Bind("urlInforme") %>' />
                            </ItemTemplate>
                            <ItemStyle CssClass="td_derecha" />
                            <HeaderStyle CssClass="td_cabecera" />
                        </asp:TemplateField>
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
    <div class="divInfo">
        <center>
        <asp:Image ID="imgInfo" runat="server" ImageUrl="~/imagenes/sistema/static/hipotecario/mensaje.png" /> 
      <asp:Label ID="lblMensajeAnalisis" runat="server" Text=""></asp:Label>
            </center>
    </div>
   
</asp:Content>
