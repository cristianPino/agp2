<%@ Page Title="" Language="C#" MasterPageFile="~/AGP.Master" AutoEventWireup="true" CodeBehind="IngresoAGP_CBCA.aspx.cs" Inherits="sistemaAGP.control_cliente.IngresoAGP_CBCA" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMenu" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoCentral" runat="server">
	<asp:Table ID="TBL_AGENDA" runat="server" Width="100%" HorizontalAlign="Center">
		<asp:TableRow>
			<asp:TableCell ColumnSpan="3">
				<asp:Calendar ID="cld_FechaFirma" runat="server" OnSelectionChanged="cld_FechaFirma_SelectionChanged" BackColor="White" BorderColor="Black" BorderStyle="Solid" CellSpacing="1" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="308px" NextPrevFormat="ShortMonth" ToolTip="Seleccione un Dia" Width="472px">
					<DayHeaderStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" Height="8pt" />
					<DayStyle BackColor="#CCCCCC" />
					<NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="White" />
					<OtherMonthDayStyle ForeColor="#999999" />
					<SelectedDayStyle BackColor="#333399" ForeColor="White" />
					<TitleStyle BackColor="#333399" BorderStyle="Solid" Font-Bold="True" Font-Size="12pt" ForeColor="White" Height="12pt" />
					<TodayDayStyle BackColor="#999999" ForeColor="White" />
					<WeekendDayStyle BackColor="White" BorderColor="Blue" />
				</asp:Calendar>
				<asp:Label ID="lblfechaseleccionada" runat="server" Text="" Visible="false"></asp:Label>
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow>
			<asp:TableCell ColumnSpan="3">
				<asp:GridView ID="grdResultado" runat="server" AutoGenerateColumns="False" Width="850px" OnRowCreated="grdResultado_RowCreated" AllowSorting="True" EnableModelValidation="True" OnRowCommand="grdResultado_RowCommand" autopostback="true">
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
						<asp:BoundField DataField="Hora_firma" HeaderText="Hora" />
						<asp:BoundField DataField="id_solicitud" HeaderText="Solicitud" />
						<asp:BoundField DataField="Cliente" HeaderText="Cliente" />
						<asp:BoundField DataField="Direccion" HeaderText="Direccion" />
						<asp:BoundField DataField="comuna" HeaderText="Comuna" />
						<asp:BoundField DataField="Telefono" HeaderText="Telefono" />
						<asp:BoundField DataField="Celular" HeaderText="Celular" />
						<asp:BoundField DataField="N_intentos" HeaderText="Intento" />
					</Columns>
					<FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
					<RowStyle BackColor="#F7F6F3" ForeColor="#333333" Font-Names="Verdana" Font-Size="8pt" />
					<EditRowStyle BackColor="#999999" />
					<SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
					<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" Font-Names="Times New Roman" Font-Size="9pt" />
					<HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" Font-Size="8pt" Font-Names="Verdana,sans-serif" />
					<AlternatingRowStyle BackColor="White" ForeColor="#284775" Font-Names="Verdana" Font-Size="8pt" />
				</asp:GridView>
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow>
			<asp:TableCell>
				<asp:Label ID="Label1" runat="server" Text="Id Solicitud"></asp:Label>&nbsp;&nbsp;&nbsp;
				<asp:DropDownList ID="cbo_nsol" runat="server" OnSelectedIndexChanged="cbo_nsol_SelectedIndexChanged" AutoPostBack="true">
				</asp:DropDownList>
			</asp:TableCell>
			<asp:TableCell>
                &nbsp;
			</asp:TableCell>
			<asp:TableCell>
				<asp:Button ID="btn_Crt_Firm" runat="server" Text="Ingresar" OnClick="btn_Crt_Firm_Click" />
			</asp:TableCell>
		</asp:TableRow>
	</asp:Table>
	<asp:Table ID="TBL_ING_CREDITO" runat="server" Width="100%" Visible="false">
		<asp:TableRow>
			<asp:TableCell ColumnSpan="2">
                          &nbsp;
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow>
			<asp:TableCell ColumnSpan="2">
				<asp:GridView ID="grdCreditos" runat="server"  AutoGenerateColumns="False" Width="850px" AllowSorting="True" EnableModelValidation="True">
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
						<asp:BoundField DataField="idInterno" HeaderText="Numero CrediAutos" />
						<asp:TemplateField HeaderText="Firmado">
							<ItemTemplate>
								<asp:CheckBox ID="chkfirma" runat="server" />
							</ItemTemplate>
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
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow>
			<asp:TableCell ColumnSpan="2">
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
			</asp:TableCell>
		</asp:TableRow>
		<asp:TableRow>
			<asp:TableCell>
				<asp:Button ID="bt_GrabaCreditos" runat="server" Text="Grabar" OnClick="bt_GrabaCreditos_Click" />
                &nbsp;
                <asp:Button ID="btn_Enviar" runat="server" Text="Enviar Mail" Visible="false" onclick="btn_Enviar_Click" />
			</asp:TableCell>
		</asp:TableRow>
	</asp:Table>
	<asp:Label ID="lblError" runat="server" Text="" ForeColor="Red"></asp:Label>
	<asp:Label ID="lblid" runat="server" Text="" Visible="false"></asp:Label>
	<asp:Label ID="lblCli" runat="server" Text="" Visible="false"></asp:Label>
</asp:Content>