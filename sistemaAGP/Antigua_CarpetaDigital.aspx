<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Antigua_CarpetaDigital.aspx.cs" Inherits="sistemaAGP.Antigua_CarpetaDigital" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Carpeta Digital - AGP S.A.</title>
	antes
	<script type="text/javascript" src="jquery-1.7.2.min.js"></script>
	<script type="text/javascript" src="jquery.mousewheel-3.0.6.pack.js"></script>
	<script type="text/javascript" src="jquery.fancybox.js?v=2.0.6"></script>-
<link rel="Stylesheet" type="text/css" href="jquery.fancybox.css?v=2.0.6" media="screen" />

actual

	<!-- Add jQuery library -->
<%--	<script type="text/javascript" src="http://code.jquery.com/jquery-latest.min.js"></script>
	<!-- Add mousewheel plugin (this is optional) -->
	<script type="text/javascript" src="/fancybox/lib/jquery.mousewheel-3.0.6.pack.js"></script>
	<!-- Add fancyBox -->
	<link rel="stylesheet" href="/fancybox/source/jquery.fancybox.css?v=2.1.5" type="text/css"
		media="screen" />
	<script type="text/javascript" src="/fancybox/source/jquery.fancybox.pack.js?v=2.1.5"></script>--%>



	<style type="text/css">
		html, body {
			width: 100%;
			height: 100%;
			padding: 0;
			margin: 0;
		}

		body {
			background: #ffffff url(<%=ViewState["url_fondo"]%>) no-repeat center bottom fixed;
			-webkit-background-size: cover;
			-moz-background-size: cover;
			-o-background-size: cover;
			background-size: cover;
			font-family: "Lucida Sans Unicode","Lucida Grande",Helvetica,Arial,sans-serif;
		}
		
		.wrap 
		{
			margin: 0 auto;
			width: 90%;
			max-width: 90%;
			border: 0 solid #000000;
			-moz-border-radius: 10px;
			-webkit-border-radius: 10px;
			border-radius: 10px;
			background: #ffffff;
			padding: 10px;
		}
		
		.header 
		{
			margin-bottom: 10px;
			text-align: center;
			font-size: 1.5em;
		}
	</style>
	<script type="text/javascript">
		$(document).ready(function () {
			$('.fancybox').fancybox({
				maxWidth: 800,
				maxHeight: 600,
				fitToView: false,
				width: 800,
				height: 600,
				autoSize: true,
				openEffect: 'elastic',
				openSpeed: 150,
				closeEffect: 'elastic',
				closeSpeed: 150,
				closeClick: false,
				closeBtn: true,
				scrolling: 'no',
				padding: 0,
				helpers: {
					overlay: {
						opacity: 0.5,
						css: {
							'background-color': 'Gray'
						},
						title: {
							type: 'float'
						}
					}
				}
			});
		});
	</script>
</head>
<body>
    <form id="formCarpeta" runat="server">
	<div class="wrap header">
		<asp:Label ID="lbl_titulo" runat="server" Text="Carpeta Digital" />
	</div>
    <div class="wrap">
		<asp:GridView ID="gr_documentos" runat="server" AutoGenerateColumns="False" 
			CellPadding="4" Font-Names="Arial" Font-Size="X-Small" ForeColor="#333333" 
			GridLines="None" Width="100%" EnableModelValidation="True">
			<Columns>
				<asp:TemplateField AccessibleHeaderText="nombre" HeaderText="Archivo" ShowHeader="False">
					<ItemTemplate>
						<a class="fancybox fancybox.iframe" href='<%# Eval("url") %>' title='<%# Eval("nombre") %>'><%# Eval("nombre") %></a>
					</ItemTemplate>
				</asp:TemplateField>
				<asp:BoundField DataField="extension" HeaderText="Extensión">
					<ItemStyle Width="50px" />
				</asp:BoundField>
				<asp:BoundField DataField="peso" HeaderText="Tamaño">
					<ItemStyle Width="50px" />
				</asp:BoundField>
				<asp:BoundField DataField="observaciones" HeaderText="Observaciones">
					<ItemStyle Width="200px" />
				</asp:BoundField>
			</Columns>
			<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
			<RowStyle BackColor="#EEEEEE" />
			<AlternatingRowStyle BackColor="White" />
		</asp:GridView>
    </div>
    </form>
</body>
</html>
