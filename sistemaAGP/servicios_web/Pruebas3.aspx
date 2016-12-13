<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pruebas3.aspx.cs" MasterPageFile="~/Adm.Master"
	Inherits="sistemaAGP.servicios_web.Pruebas3" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:content id="Content1" contentplaceholderid="head" runat="server">
	<script type="text/javascript" src="../jquery-1.7.2.min.js"></script>
	<script type="text/javascript" src="../jquery.mousewheel-3.0.6.pack.js"></script>
	<script type="text/javascript" src="../jquery.fancybox.js?v=2.0.6"></script>
	<link rel="Stylesheet" type="text/css" href="../jquery.fancybox.css?v=2.0.6" media="screen" />
	<script type="text/javascript">
		$(document).ready(function () {
			$('.fancybox').fancybox({
				maxWidth: 800,
				maxHeight: 600,
				fitToView: false,
				width: 800,
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

</asp:content>
<asp:content id="Content2" contentplaceholderid="ContentPlaceHolder1" runat="server">
    <div>
    
    	<asp:Button ID="Button1" runat="server" Text="probar" data-fancybox-type="iframe"
			CssClass="fancybox fancybox.iframe" OnClick="Button1_Click" />

			<asp:Label ID="Label1" runat="server" Text="PRUEBAS 2"></asp:Label>
		
		
    </div>
   </asp:content>
