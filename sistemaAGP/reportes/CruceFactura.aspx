<%@ Page Title="Reportes Cobranza." Language="C#" MasterPageFile="~/AGP.Master" AutoEventWireup="true"
	CodeBehind="CruceFactura.aspx.cs" Inherits="sistemaAGP.CruceFactura" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMenu" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoCentral" runat="server">
	<table align="left" style="width: 55%; height: 440px">
		<tr>
			<td class="style4" style="height: 74px" valign="top">
				<center>
					<table bgcolor="Gray" style="width: 70%">
						<tr>
							<td>
								<asp:Label ID="Label1" runat="server" Text="Seleccione Archivo Excel" Font-Bold="True"></asp:Label>
							</td>
							<td colspan="2">
								<asp:FileUpload ID="fileuploadExcel" runat="server" />
							</td>
							<td>
								<asp:Button ID="btnImport" runat="server" Text="Cargar Planilla" OnClick="btnImport_Click"
									Width="87px" />
							</td>
							<td>
								<asp:Label ID="lbl_cantidad" runat="server" Text="" Font-Bold="True"></asp:Label>
							</td>
						</tr>
					</table>
				</center>
				<center>
					<table style="width: 100%; height: 264px;">
						<tr>
							<td style="width: 123px;" valign="top">
							
								<asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" CellPadding="4"
									DataKeyNames="id_solicitud,id_cliente,tipo_operacion,disponible,monto_gasto"
									Font-Names="Arial" Font-Size="X-Small" GridLines="None" EnableModelValidation="True"
									Width="100%" OnSelectedIndexChanged="gr_dato_SelectedIndexChanged">
									<RowStyle />
									<Columns>
										<asp:HyperLinkField HeaderText="Operación" DataNavigateUrlFormatString="id_solicitud"
											DataTextField="id_solicitud">
											<ItemStyle ForeColor="#00cc00" Width="60px" />
										</asp:HyperLinkField>
										<asp:BoundField HeaderText="Nº Factura" DataField="numero_factura" />
										<asp:BoundField HeaderText="Ingresada" DataField="ingresada" />
										<asp:BoundField HeaderText="Cliente" DataField="nombre_cliente" />
										<asp:BoundField HeaderText="Producto" DataField="operacion" />
										<asp:BoundField HeaderText="Patente" DataField="patente" />
										<asp:BoundField HeaderText="Rut Adquiriente" DataField="rut_persona" />
										<asp:BoundField HeaderText="Adquirente" DataField="nombre_persona" />
										<asp:BoundField HeaderText="Estado Actual" DataField="ultimo_estado" />
										<asp:BoundField HeaderText="Gasto total" DataField="monto_gasto" Visible="true" />
										
									</Columns>
									<FooterStyle Font-Bold="True" ForeColor="#ffffff" />
									<PagerStyle BackColor="#2461bf" ForeColor="#ffffff" HorizontalAlign="Center" />
									<SelectedRowStyle BackColor="#d1ddf1" Font-Bold="True" ForeColor="#333333" />
									<HeaderStyle BackColor="#507cd1" Font-Bold="True" ForeColor="#ffffff7" />
									<EditRowStyle BackColor="#2461bf" />
									<AlternatingRowStyle BackColor="#ffffff" />
								</asp:GridView>
							</td>
						</tr>
					</table>
				</center>
			</td>
		</tr>
	</table>
	
</asp:Content>