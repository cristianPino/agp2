<%@ Page Title="" Language="C#" MasterPageFile="~/AGP.Master" AutoEventWireup="true" CodeBehind="Actualizar_Repertorios.aspx.cs" Inherits="sistemaAGP.garantias.Actualizar_Repertorios" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMenu" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoCentral" runat="server">
	<asp:UpdatePanel ID="up_filtros" runat="server" UpdateMode="Conditional">
		<ContentTemplate>
			<div style="background-color: #507cd1; width: 100%;">
				<table>
					<tr>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #ffff66;">
							Seleccione el archivo
						</td>
						<td>
							<asp:FileUpload ID="fu_archivo" runat="server" Width="400px" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;" />
							<asp:RequiredFieldValidator ID="rfv_archivo" runat="server" ControlToValidate="fu_archivo" ErrorMessage="Archivo" InitialValue="" SetFocusOnError="true" Text="*"></asp:RequiredFieldValidator>
						</td>
						<td>
							<asp:Button ID="bt_procesar" runat="server" Text="Procesar" OnClick="bt_procesar_Click" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;" />
							<asp:ValidationSummary ID="vs_datos" runat="server" ShowMessageBox="true" ShowSummary="false" HeaderText="Verificar los siguientes datos:" DisplayMode="List" />
							<ajaxToolkit:ConfirmButtonExtender ID="cfe_datos" runat="server" ConfirmText="Va a procesara un archivo, ¿desea continuar?" TargetControlID="bt_procesar"></ajaxToolkit:ConfirmButtonExtender>
						</td>
					</tr>
				</table>
				<asp:Label ID="lbl_error" runat="server" Text="" Style="color: Red; font-family: Arial, Helvetica, sans-serif; font-size: x-small;"></asp:Label>
			</div>
			<div>
				<p><strong><asp:Label ID="lbl_titulo" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;"></asp:Label></strong></p>
				<asp:GridView ID="gr_info" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Names="Arial" Font-Size="X-Small" ForeColor="#333333" GridLines="None" EnableModelValidation="True">
					<Columns>
						<asp:BoundField DataField="id_solicitud" HeaderText="Id.Solicitud" />
						<asp:ImageField DataImageUrlField="icon" AlternateText="Icono" ShowHeader="false" />
						<asp:BoundField DataField="observacion" HeaderText="Observaciones" />
					</Columns>
					<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
					<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
					<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
					<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
					<EditRowStyle BackColor="#2461BF" />
					<AlternatingRowStyle BackColor="White" />
				</asp:GridView>
			</div>
		</ContentTemplate>
		<Triggers>
			<asp:PostBackTrigger ControlID="bt_procesar" />
		</Triggers>
	</asp:UpdatePanel>
</asp:Content>