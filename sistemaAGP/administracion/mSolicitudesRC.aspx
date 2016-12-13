<%@ Page Title="" Language="C#" MasterPageFile="~/AGP.Master" AutoEventWireup="true" CodeBehind="mSolicitudesRC.aspx.cs" Inherits="sistemaAGP.administracion.mEstadosRC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMenu" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoCentral" runat="server">
	<div>
		<asp:Label ID="lblTitulo" runat="server" Font-Bold="true" Font-Names="Arial" Font-Size="X-Small"
			Text="Administración Solicitudes Registro Civil" />
	</div>
	<div>
		<table>
			<tr>
				<td style="border-style: none; border-color: inherit; border-width: 0; text-align: left;">
					<asp:Label ID="lblSolic" runat="server" Font-Bold="true" Font-Names="Arial" Font-Size="X-Small"
						Text="Solicitud" />
				</td>
				<td>
					<asp:Label ID="lblCodigo" runat="server" Visible="false" />
					<asp:TextBox ID="txtDescripcion" runat="server" Width="282px" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" MaxLength="100" />
				</td>
			</tr>
			<tr>
				<td style="border-style: none; border-color: inherit; border-width: 0; text-align: left;">
					<asp:Label ID="lblCorreos" runat="server" Font-Bold="true" Font-Names="Arial" Font-Size="X-Small" Text="Lista de Correos" />
				</td>
				<td>
					<asp:TextBox ID="txtCorreos" runat="server" Width="500px" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" MaxLength="1000" />
				</td>
			</tr>
			<tr>
				<td>
					<asp:Button ID="btnGuardar" runat="server" Text="Guardar" Font-Size="X-Small" Height="21px" onclick="btnGuardar_Click" />
				</td>
				<td>
					<asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" Font-Size="X-Small" Height="21px" onclick="btnLimpiar_Click" />
				</td>
			</tr>
		</table>
	</div>
	<div>
		<asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" CellPadding="4"
			Font-Names="Arial" Font-Size="X-Small" ForeColor="#333333" GridLines="None" 
			DataKeyNames="codigo,descripcion" OnRowCommand="gr_dato_RowCommand">
			<RowStyle BackColor="#EFF3FB" />
			<Columns>
				<asp:BoundField AccessibleHeaderText="codigo" DataField="codigo" HeaderText="Código" />
				<asp:BoundField AccessibleHeaderText="descripcion" DataField="descripcion" HeaderText="Descripción" />
				<asp:BoundField AccessibleHeaderText="correos" DataField="correos" HeaderText="Lista de Correos" ItemStyle-Width="200px" />
				<asp:ButtonField AccessibleHeaderText="editar" ButtonType="Image" 
					HeaderText="Editar" ImageUrl="~/imagenes/sistema/static/EditInformationHS.png" CommandName="Select" />
			</Columns>
			<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
			<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
			<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
			<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
			<EditRowStyle BackColor="#2461BF" />
			<AlternatingRowStyle BackColor="White" />
		</asp:GridView>
	</div>
</asp:Content>