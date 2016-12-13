<%@ Page Title="" Language="C#" MasterPageFile="~/AGP.Master" AutoEventWireup="true" CodeBehind="mHipotecaCorreoCliente.aspx.cs" Inherits="sistemaAGP.administracion.mHipotecaCorreoCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMenu" runat="server">
     <script type="text/javascript" src="../jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="../jquery.mousewheel-3.0.6.pack.js"></script>
    <script type="text/javascript" src="../jquery.fancybox.js?v=2.0.6"></script>
    <link rel="Stylesheet" type="text/css" href="../jquery.fancybox.css?v=2.0.6" media="screen" />
    <script type="text/javascript" src="../javascript/ScrollableGrid.js"></script>
    <script type="text/javascript">
    $.ajaxSetup({ cache: false });

    $(document).ready(function () {
        $(".various").fancybox({
          
            fitToView: false,
            width: '90%',
            height: '90%',
            autoSize: false,
            closeClick: false,
            openEffect: 'none',
            closeEffect: 'none',
          
        });
    });

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoCentral" runat="server">
    
    <div class="subtitulo" style="width: 50%">
                        <asp:Image ID="Image2" runat="server" 
                        ImageUrl="../imagenes/sistema/static/mensaje_verde.png" 
                        Height="34px" 
                        Width="37px" />
        &nbsp;<asp:Label ID="lbl_titulo" runat="server" Text="CORREO HIPOTECARIO"></asp:Label>
    </div>
    <br/>
    <asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" 
                        Font-Size="X-Small"  CssClass="tabla_datos" 
                        GridLines="None" EnableModelValidation="True" 
		DataKeyNames="idCliente" onselectedindexchanged="gr_dato_SelectedIndexChanged">
                        
                        <Columns>
                        <asp:BoundField AccessibleHeaderText="Cliente" DataField="clienteNombre" HeaderText="Cliente">
                        <ItemStyle CssClass="td_derecha_grande"  />
					    <HeaderStyle CssClass="td_cabecera_grande" />
                        </asp:BoundField>
                        
                        <asp:TemplateField HeaderText="Correos" >
                        <ItemTemplate >
                            <asp:HyperLink ID="hlCorreo" runat="server" data-fancybox-type="iframe" CssClass="various" NavigateUrl='<%# Bind("url_correoCliente") %>' ImageUrl="../imagenes/sistema/static/panel_control/nominas.png"/>
                        </ItemTemplate>
                        <ItemStyle CssClass="td_derecha"  />
					    <HeaderStyle CssClass="td_cabecera" />
                        </asp:TemplateField>
                        
                       
                        </Columns>
                        <HeaderStyle CssClass="tr_cabecera" />
				        <RowStyle CssClass="tr_fila" />
				        <AlternatingRowStyle CssClass="tr_fila_alt" />
            </asp:GridView>
</asp:Content>
