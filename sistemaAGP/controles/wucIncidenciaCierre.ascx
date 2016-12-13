<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucIncidenciaCierre.ascx.cs" Inherits="sistemaAGP.controles.wucIncidenciaCierre" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>


  <script type="text/javascript" src="../../jquery-1.7.2.min.js"></script>    
    <script type="text/javascript" src="../../jquery.fancybox.js?v=2.0.6"></script>
    <link rel="Stylesheet" type="text/css" href="../../jquery.fancybox.css?v=2.0.6" media="screen" />


 <script type="text/javascript">
         $.ajaxSetup({ cache: false });

         $(document).ready(function () {

             $("a.fancybox").fancybox({
                 autoSize: false,
                 closeBtn: true,
                 maxWidth: 800,
                 maxHeight: 600,
                 minWidth: 800,
                 minHeight: 600,
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
                 },

            afterClose: function () {
                //refresco la grilla de panel de control
                $('#<%=botonReload.ClientID%>').click();

            }

             });         


         });

    </script>
  


<div>   
    <asp:Label ID="lblTipoCierre" runat="server" Text="Label"></asp:Label>
</div>
 <asp:Button ID="botonReload" Style="display: none;" runat="server" Text="" OnClick="botonReload_Click"  />
<asp:Panel ID="pnlCierre" runat="server">
    <span>
        Comenterio
    </span>
    <br />
    <asp:TextBox ID="txtCierreComentario" CssClass="input" Width="400px" MaxLength="200" runat="server"></asp:TextBox>
    <asp:Button ID="btnCierre" runat="server" CssClass="buton" Text="Cerrar" OnClick="btnCierre_Click" />
     <ajaxToolkit:ConfirmButtonExtender ID="cbeCierre" runat="server" 
         TargetControlID="btnCierre" 
         ConfirmText="¿Esta seguro de Cerrar esta incidencia con un comentario? Esta decisión enviará un correo al cliente">
      </ajaxToolkit:ConfirmButtonExtender>

</asp:Panel>



<asp:Panel ID="pnlOperacion" runat="server">
    <span>
        Tipo operación
    </span>
    <br />
    <asp:DropDownList ID="dlTipoOperacion" AutoPostBack="true"  runat="server" OnSelectedIndexChanged="dlTipoOperacion_SelectedIndexChanged"></asp:DropDownList>
    <a runat="server" id="lnk" class="fancybox fancybox.iframe">
        <img alt="Productos" src="../../imagenes/sistema/static/hipotecario/comprador.png" />

    </a>
    <asp:Label ID="lblIdSolicitud" runat="server" Text="Label"></asp:Label>

</asp:Panel>


