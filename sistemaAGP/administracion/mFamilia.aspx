<%@ Page Language="C#" MasterPageFile="~/agp.Master" AutoEventWireup="true" CodeBehind="mFamilia.aspx.cs" Inherits="sistemaAGP.mFamilia" Title="Administracion de Familias" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContenidoMenu">
    
        <link rel="stylesheet" href="../sitio.css" />
        <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7/jquery.min.js"></script> 
        <script type="text/javascript" src="../jquery-1.7.2.min.js"></script>
	    <script type="text/javascript" src="../jquery.mousewheel-3.0.6.pack.js"></script>
	    <script type="text/javascript" src="../jquery.fancybox.js?v=2.0.6"></script>
        <script type="text/javascript" src="../ScrollableGrid.js"></script>
        <link rel="Stylesheet" type="text/css" href="../jquery.fancybox.css?v=2.0.6" media="screen" />  

        <script type="text/javascript">
            function grilla_cabecera() {
                $('#<%=gr_dato.ClientID %>').Scrollable();
            }
    </script>

	<script type="text/javascript">
	    $(document).ready(function () {
	        $('.fancybox').fancybox({
	            maxWidth: 1000,
	            maxHeight: 700,
	            fitToView: false,
	            width: 1000,
	            height: 700,
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

	<script type="text/javascript">
	    function confirmarEliminar() {
	        if (confirm("Desea eliminar la operacion seleccionada?") == true) {
	            return true;
	        } else {
	            return false;
	        }
	    }
	</script>

</asp:Content>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContenidoCentral">
    <table class="table">
        <tr>
            <td>
               <strong>
                    Administracion de Familias
               </strong> 
            </td>
        </tr>
    </table>
    <asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="false" 
        CellPadding="4" EnableModelValidation="true" CssClass="tabla_datos" 
        Width="30%">
        <Columns>
            <asp:TemplateField HeaderText="Id Familia">
                <ItemTemplate>
                    <asp:HyperLink ID="id_familia" runat="server"
                        Text='<%# Bind("id_familia") %>'></asp:HyperLink>
                    <asp:Panel ID="pnl_menu_familia" runat="server" CssClass="popupmenu">
                        <table>
                            <tr>
                                <td>
                                    <asp:HyperLink ID="ib_modulo" data-fancybox-type="iframe" CssClass="fancybox fancybox.iframe" runat="server" ImageUrl="../imagenes/sistema/static/amarillo.png" Text="Estado" NavigateUrl='<%# Bind("url_estado") %>' /> 
                                </td>
                                <td>
                                    <asp:HyperLink ID="ib_sucursales" data-fancybox-type="iframe" CssClass="fancybox fancybox.iframe" runat="server" ImageUrl="../imagenes/sistema/static/dinero-small.png" Text="Gasto" NavigateUrl='<%# Bind("url_Gasto") %>' />
                                </td>
                                <td>
                                    <asp:HyperLink ID="ib_personero" runat="server" data-fancybox-type="iframe" CssClass="fancybox fancybox.iframe" ImageUrl="../imagenes/sistema/static/document.png" Text="Nomina" NavigateUrl='<%# Bind("url_nomina") %>' />
                                </td>
                                <td>
                                    <asp:HyperLink ID="ib_operacion" runat="server"  data-fancybox-type="iframe" CssClass="fancybox fancybox.iframe" ImageUrl="../imagenes/sistema/static/carrito.png" NavigateUrl='<%# Bind("url_operacion") %>' />
                                </td>
                                <td>
                                    <asp:HyperLink ID="ib_operaciongastos" runat="server"  data-fancybox-type="iframe" CssClass="fancybox fancybox.iframe" ImageUrl="../imagenes/sistema/static/carrito.png" NavigateUrl='<%# Bind("url_operaciongastos") %>' />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Estados
                                </td>
                                <td>
                                    Gastos
                                </td>
                                <td>
                                    Nóminas
                                </td>
                                <td>
                                    Productos
                                </td>
                                <td>
                                    Prod. Gastos
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <cc1:HoverMenuExtender ID="hme_menu_familia" runat="Server" 
                                    HoverDelay="500" OffsetX="0" OffsetY="0" PopDelay="0" 
                                    PopupControlID="pnl_menu_familia" PopupPosition="Right" 
                                    TargetControlID="id_familia" />
                </ItemTemplate>
                <ItemStyle CssClass="td_derecha" />
                <HeaderStyle CssClass="td_cabecera" />
            </asp:TemplateField>
            <asp:BoundField AccessibleHeaderText="Descripcion" DataField="Descripcion" HeaderText="Descripcion"></asp:BoundField>
        </Columns>
        <HeaderStyle CssClass="tr_cabecera" />
        <RowStyle CssClass="tr_fila" />
        <AlternatingRowStyle CssClass="tr_fila_alt" />               
    </asp:GridView>
    
</asp:Content>