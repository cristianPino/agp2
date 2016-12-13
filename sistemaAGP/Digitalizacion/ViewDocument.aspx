<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewDocument.aspx.cs" Inherits="sistemaAGP.ViewDocument" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Visor de Documento</title>
	<style type="text/css">
		html, body { width: 100%; height: 100%; }
	</style>
	<script type="text/javascript">
		function resize() {
			if (window.innerHeight)
				document.getElementById('if_doc').height = window.innerHeight - 20;
			else if (document.body.clientHeight)
				document.getElementById('if_doc').height = document.body.clientHeight - 20;
			else
				document.getElementById('if_doc').height = 620;

			if (window.innerWidth)
				document.getElementById('if_doc').width = window.innerWidth - 20;
			else if (document.body.clientHeight)
				document.getElementById('if_doc').width = document.body.clientWidth - 20;
			else
				document.getElementById('if_doc').width = 780;
		}
	</script>
</head>
<body onload="resize()">
    <form id="form1" runat="server">
    <div>
		<iframe id="if_doc" runat="server" width="100%" scrolling="auto"></iframe>
    </div>
    </form>
</body>
</html>
