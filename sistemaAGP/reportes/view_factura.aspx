<%@ Page Title="Visor de Reportes" Language="C#" AutoEventWireup="true" CodeBehind="view_factura.aspx.cs"
	Inherits="sistemaAGP.reportes.view_factura" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Administrador de Informes</title>
	<meta http-equiv="Cache-Control" content="no-cache" />
	<meta http-equiv="Pragma" content="no-cache" />
	<meta http-equiv="Expires" content="Tue, 01 Jan 1980 1:00:00 GMT" />
	<%--<link href="rpt_style.css" rel="Stylesheet" />--%>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 19px">
    
        <%--<CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" CssFilename="rpt_style.css" />--%>
		<CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" ToolPanelView="None" />
    </div>
    </form>
</body>
</html>