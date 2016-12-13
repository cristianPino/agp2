<%@ Page Title="" Language="C#" MasterPageFile="~/Modal.Master" AutoEventWireup="true" CodeBehind="UploadEscritura.aspx.cs" Inherits="sistemaAGP.UploadEscritura" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<script type="text/javascript">
		function UploadStarted() {
			alert('Se inició la carga del archivo');
		}

		function UploadError(errorMessage) {
			alert('Se produjo un error al subir el archivo:\n' + errorMesage);
		}

		function UploadedComplete() {
			alert('Se completo la carga del archivo');
			window.close();
		}
	</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
	<asp:UpdatePanel ID="up_file" runat="server">
		<ContentTemplate>
			<table class="tabla-titulo">
				<tr>
					<td>
						Modificación Escritura
					</td>
				</tr>
			</table>
			<table class="tabla-normal">
				<tr>
					<td>
						<strong>Nro. Operación</strong>
					</td>
					<td>
						<asp:Label ID="lbl_id_solicitud" runat="server"></asp:Label>
					</td>
					<td>
						&nbsp;
					</td>
					<td>
						&nbsp;
					</td>
				</tr>
				<tr>
					<td>
						<strong>Deudor</strong>
					</td>
					<td>
						<asp:Label ID="lbl_dedudor" runat="server"></asp:Label>
					</td>
					<td>
						<strong><asp:Label ID="lbl_rut_dedudor_titulo" runat="server"></asp:Label></strong>
					</td>
					<td>
						<asp:Label ID="lbl_rut_dedudor" runat="server"></asp:Label>
					</td>
				</tr>
				<tr>
					<td>
						<strong>Constituyente</strong>
					</td>
					<td>
						<asp:Label ID="lbl_constituyente" runat="server"></asp:Label>
					</td>
					<td>
						<strong>
							<asp:Label ID="lbl_rut_constituyente_titulo" runat="server"></asp:Label></strong>
					</td>
					<td>
						<asp:Label ID="lbl_rut_constituyente" runat="server"></asp:Label>
					</td>
				</tr>
				<tr>
					<td>
						<strong>Archivo</strong>
					</td>
					<td colspan="2">
						<asp:FileUpload ID="fu_archivo" runat="server" Width="100%" />
					</td>
					<td style="text-align: center;">
						<asp:Button ID="btn_subir" runat="server" Text="Subir" onclick="btn_subir_Click" />
					</td>
				</tr>
			</table>
			<%--<ajaxToolkit:AsyncFileUpload ID="afu_documento" runat="server" OnClientUploadComplete="UploadedComplete" OnClientUploadError="UploadError" OnClientUploadStarted="UploadStarted" OnUploadedComplete="afu_documento_UploadedComplete" Enabled="true" Width="500px" />--%>
			</ContentTemplate>
		<Triggers>
			<%--<asp:AsyncPostBackTrigger ControlID="afu_documento" />--%>
		</Triggers>
	</asp:UpdatePanel>
</asp:Content>