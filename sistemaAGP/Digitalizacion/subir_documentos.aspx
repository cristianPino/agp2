<%@ Page Title="Subir documentos" Language="C#" AutoEventWireup="true" CodeBehind="subir_documentos.aspx.cs" Inherits="sistemaAGP.subir_documentos" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
	<base target="_self" />
	<title>SUBIR DOCUMENTOS</title>
	<meta http-equiv="Cache-Control" content="no-cache" />
	<meta http-equiv="Pragma" content="no-cache" />
	<meta http-equiv="Expires" content="Tue, 01 Jan 1980 1:00:00 GMT" />
	<script type="text/javascript">
		function solonumeros(e) {
			var key;
			if (window.event) // IE
			{
				key = e.keyCode;
			}
			else if (e.which) // Netscape/Firefox/Opera
			{
				key = e.which;
			}

			if (key < 48 || key > 57) {
				return false;
			}
			return true;
		}
	</script>
	<style type="text/css">
		.calendario 
		{
			background-color: #ffffff;
		}
		.modalBackground
		{
			background-color: Gray;
			filter: alpha(opacity=50);
			opacity: 0.50;
		}
		.updateProgress 
		{
			border: none;
			background-color: #ffffff;
			position: absolute;
			width: 180px;
			height: 65px;
			top: 50%;
			left: 50%;
			margin-left: -90px;
			margin-top: -35px;
		}
		.centrado {
			text-align: center;
			margin: 0 auto 0 auto;
		}		
		.mensaje {
			color: #ff0000;
			text-align: center;
			font-size: 20px;
			position: absolute;
			height: 200px;
			width: 400px;
			top: 50%;
			left: 50%;
			margin-top: -100px;
			margin-left: -200px;
		}
	</style>
</head>
<body alink="#0066cc">
	<form id="form1" runat="server">
	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
		<ContentTemplate>
			<asp:UpdateProgress ID="UpdateProg1" DisplayAfter="0" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
				<ProgressTemplate>
					<div style="position: absolute; width: 100%; height: 100%; background-color: #ffffff;">
						<div class="updateProgress">
							<div style="position: relative; text-align: center;">
								<img src="../imagenes/sistema/gif/loading.gif" style="vertical-align: middle" alt="Procesando" />
								Procesando ...
							</div>
						</div>
					</div>
				</ProgressTemplate>
			</asp:UpdateProgress>
			<asp:Panel ID="divGrilla" runat="server">
				<asp:GridView ID="gr_documentos" runat="server" AutoGenerateColumns="false" CellPadding="1" Font-Names="Arial" Font-Size="X-Small" ForeColor="#333333" DataKeyNames="id_solicitud,codigo,id_documento" GridLines="None" Width="100%">
					<RowStyle BackColor="#EFF3FB" />
					<Columns>
						<asp:BoundField AccessibleHeaderText="nombre" DataField="nombre" HeaderText="Tipo Documento" ItemStyle-Width="20%" />
						<asp:TemplateField AccessibleHeaderText="ruta_documento" HeaderText="Ruta Documento" ItemStyle-Width="50%">
							<ItemTemplate>
								<asp:FileUpload ID="fu_archivo" runat="server" />
							</ItemTemplate>

							<ControlStyle Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="100%" />
						</asp:TemplateField>
						<asp:TemplateField AccessibleHeaderText="observaciones" HeaderText="Observaciones" ItemStyle-Width="30%">
							<ItemTemplate>
								<asp:TextBox ID="txt_observaciones" runat="server" MaxLength="250" Text=""></asp:TextBox>
							</ItemTemplate>
							<ControlStyle Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="100%" />
						</asp:TemplateField>
                        <asp:TemplateField AccessibleHeaderText="escanner" HeaderText="Escanner" ItemStyle-Width="50%">
							<ItemTemplate>
                                <asp:HyperLink ID="hlescanner" Text="Obtener Imagen" runat="server" NavigateUrl='<%# Bind("url_escanner") %>' >Obtener Imagen</asp:HyperLink>
							</ItemTemplate>
                            </asp:TemplateField>
					</Columns>
				</asp:GridView>
				<asp:Panel ID="divBoton" runat="server" CssClass="centrado">
					<asp:Button ID="bt_subir" runat="server" Text="Cargar los documentos" 
						OnClick="bt_subir_Click" />
				</asp:Panel>
				<asp:ConfirmButtonExtender ID="cb_subir" ConfirmText="¿Desea subir los archivos seleccionados?" runat="server" TargetControlID="bt_subir" />
			</asp:Panel>
			<asp:Panel ID="divMensaje" runat="server" Visible="false" CssClass="mensaje">
				<img alt="advertencia" src="../imagenes/sistema/static/warning.png" /><br />
				<p>
					No puede adjuntar archivos para este tipo de operación.</p>
				<p>
					Favor comunicarse con Informática.</p>
			</asp:Panel>
			<asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="true" EnableScriptLocalization="true">
			</asp:ToolkitScriptManager>
		</ContentTemplate>
		<Triggers>
			<asp:PostBackTrigger ControlID="bt_subir" />
		</Triggers>
	</asp:UpdatePanel>
	</form>
</body>
</html>