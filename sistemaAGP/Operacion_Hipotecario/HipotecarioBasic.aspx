<%@ Page Title="" Language="C#" MasterPageFile="~/modal2.Master" AutoEventWireup="true"
    CodeBehind="HipotecarioBasic.aspx.cs" Inherits="sistemaAGP.HipotecarioBasic" %>

<%@ Register Src="~/controles/wucPersonaHipotecario.ascx" TagName="DatosPersona" TagPrefix="agp" %>
<%@ Register Src="~/controles/wucGrabar.ascx" TagName="DatosGrabar" TagPrefix="agp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="../jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="../jquery.mousewheel-3.0.6.pack.js"></script>
    <script type="text/javascript" src="../jquery.fancybox.js?v=2.0.6"></script>
    <link rel="Stylesheet" type="text/css" href="../jquery.fancybox.css?v=2.0.6" media="screen" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
     
    <script type="text/javascript">
        $("a.fancybox").fancybox({
            maxWidth: 800,
            maxHeight: 500,
            minWidth: 800,
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
            }


        });
  
        // Solo permite ingresar numeros.
        function soloNumeros(evt) {

            var key = (evt.which) ? evt.which : event.keyCode;
            return (key <= 13 || (key >= 48 && key <= 57) || key == 46);
        }
</script>
    <div class="divTituloModal">
        <img src="../imagenes/sistema/static/panel_control/poliza.png" alt="" />
        <asp:Label ID="lbl_titulo" runat="server" Text=""></asp:Label>
        <asp:Label ID="lbl_operacion" runat="server" Visible="False"></asp:Label>
        <asp:Label ID="lbl_numero" runat="server" Visible="False"></asp:Label>
    </div>
    <asp:UpdatePanel runat="server" ID="Udp" UpdateMode="Conditional">
        <ContentTemplate>
    <div style="clear: both; padding: 5px;">
        <table class="tabla_datos">
            <tr class="tr_fila">
                <td>
                    Cliente
                </td>
                <td>
                    <asp:DropDownList ID="dl_cliente" runat="server" AutoPostBack="True" CssClass="ddl"
                        OnSelectedIndexChanged="dl_cliente_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td>
                    Sucursal Origen
                </td>
                <td>
                    <asp:DropDownList ID="dl_sucursal_origen" runat="server" CssClass="ddl">
                    </asp:DropDownList>
                </td>
                <td>
                    Nº Interno
                </td>
                <td>
                    <asp:TextBox ID="txt_interno" runat="server" CssClass="" MaxLength="15" class="inputs" onkeypress="return soloNumeros(event)"
                        OnTextChanged="txt_interno_TextChanged" AutoPostBack="True"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
    <agp:DatosPersona ID="Datosvendedor" runat="server" Titulo="DATOS DEL PROPIETARIO"
        HabilitarCompraPara="false" />
    <agp:DatosGrabar ID="agpDatosGrabar" OnClick="btnAceptar_Click" OnClick1="cmdLink_Click1"
        runat="server" titulo="GRABAR" habilitarcomprapara="false" Visible="true" />
    <asp:Panel ID="pnlPopUp" runat="server" CssClass="PopUp" Style="display: none;">
        <table>
            <tr>
                <td>
                    <asp:Button ID="bt_salir" runat="server" Font-Names="Arial" Font-Size="X-Small" Text="Cancelar" />
                </td>
            </tr>
        </table>
    </asp:Panel>
      </ContentTemplate>
      
    </asp:UpdatePanel>
</asp:Content>
