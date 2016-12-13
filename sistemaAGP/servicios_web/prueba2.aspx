<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="prueba2.aspx.cs" MasterPageFile="~/Adm.Master"
	Inherits="sistemaAGP.servicios_web.prueba2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:content id="Content1" contentplaceholderid="head" runat="server">
	<script type="text/javascript" src="../jquery-1.7.2.min.js"></script>
	<script type="text/javascript" src="../jquery.mousewheel-3.0.6.pack.js"></script>
	<script type="text/javascript" src="../jquery.fancybox.js?v=2.0.6"></script>
	<link rel="Stylesheet" type="text/css" href="../jquery.fancybox.css?v=2.0.6" media="screen" />
	<script type="text/javascript">
		$(document).ready(function () {
			$('.fancybox').fancybox({
				maxWidth: 400,
				maxHeight: 300,
				fitToView: false,
				width: 400,
				height: 300,
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

</asp:content>
<asp:content id="Content2" contentplaceholderid="ContentPlaceHolder1" runat="server">
    <div>
    
    	<asp:Button ID="Button1" runat="server" Text="probar"   OnClick="Button1_Click" />

<%--        PostBackUrl="~/servicios_web/Pruebas3.aspx"--%>

		<asp:HyperLink ID="lnk_gasto" runat="server" data-title-id="title-gastos" data-fancybox-type="iframe"
			CssClass="fancybox fancybox.iframe" ImageUrl="~/imagenes/sistema/static/panel_control/gastos.png"
			NavigateUrl="~/servicios_web/Pruebas3.aspx" />

			<asp:Label ID="Label1" runat="server" Text="PRUEBAS 2"></asp:Label>
		
		
    </div>
   </asp:content>
