<%@ Page Title="" Language="C#" MasterPageFile="~/AGP.Master" AutoEventWireup="true" CodeBehind="ListAgendaFirmados.aspx.cs" Inherits="sistemaAGP.control_cliente.ListAgendaFirmados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMenu" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoCentral" runat="server">
<table>
    <tr>
        <td>
            <asp:GridView ID="grdnewcredit" runat="server" AutoGenerateColumns="False" Width="850px" AllowSorting="True" EnableModelValidation="True" OnRowDataBound="grdnewcredit_RowDataBound" Visible="false">
					<EmptyDataTemplate>
						<table>
							<tr align="center">
								<td class="ms-input">
									No existen registros.
								</td>
							</tr>
						</table>
					</EmptyDataTemplate>
					<Columns>
						<asp:BoundField DataField="idSolicitud" HeaderText="ID Agenda" />
						<asp:BoundField DataField="ninterno" HeaderText="Numero" />
						<asp:BoundField DataField="id_Ope" HeaderText="Operacion AGP" />
						<asp:TemplateField HeaderText=" Carpeta Digital ">
							<ItemTemplate>
								<asp:ImageButton ID="ib_cargar" runat="server" ImageUrl="~/imagenes/sistema/static/carpeta.gif" Width="20px" />
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="C.Digital">
							<ItemTemplate>
								<asp:ImageButton ID="ib_cdigital" runat="server" ImageUrl="~/imagenes/sistema/static/carpetas.gif" />
							</ItemTemplate>
							<ControlStyle Height="25px" Width="25px" />
						</asp:TemplateField>
              
					</Columns>
					<FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
					<RowStyle BackColor="#F7F6F3" ForeColor="#333333" Font-Names="Verdana" Font-Size="8pt" />
					<EditRowStyle BackColor="#999999" />
					<SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
					<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" Font-Names="Times New Roman" Font-Size="9pt" />
					<HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" Font-Size="8pt" Font-Names="Verdana,sans-serif" />
					<AlternatingRowStyle BackColor="White" ForeColor="#284775" Font-Names="Verdana" Font-Size="8pt" />
				</asp:GridView>
        </td>
    </tr>
</table>
</asp:Content>
