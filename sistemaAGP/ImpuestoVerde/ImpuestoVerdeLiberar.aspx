<%@ Page Title="" Language="C#" MasterPageFile="~/AGP.Master" AutoEventWireup="true" CodeBehind="ImpuestoVerdeLiberar.aspx.cs" Inherits="sistemaAGP.ImpuestoVerde.ImpuestoVerdeLiberar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMenu" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoCentral" runat="server">

	<div style="background-color: #507cd1; font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #ffffff;">

		<table>
			<tr>
				<td>
					Nùmero solicitud	
				</td>
				<td>
					<asp:TextBox ID="txt_operacion" runat="server" AutoPostBack="true" 
					ValidationGroup="filtros" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;
					color: #ffffff; background-color: #3399ff; width: 80px;">
					</asp:TextBox>
				</td>
				<td>
					<asp:Button ID="bt_graba_movimiento" runat="server" Style="font-family: Arial, Helvetica, sans-serif;
					font-size: x-small; font-weight: bold; width: 100px; margin-right: 4px;" Text="Liberar" 
						onclick="bt_graba_movimiento_Click"/>
				</td>
			</tr>
		</table>

	</div>


</asp:Content>
