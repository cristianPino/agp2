<%@ Page Language="C#" MasterPageFile="~/AGP.Master" AutoEventWireup="true" CodeBehind="mEjecutivoSucursal.aspx.cs" Inherits="sistemaAGP.mEjecutivoSucursal" Title="Administracion de Ejecutivos por cliente - sucursal" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMenu" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoCentral" runat="server">
	<div>
		<table bgcolor="#E5E5E5" style="width: 459px">
			<tr>
				<td>
					
					<table style="width: 99%; font-family: Arial, Helvetica, sans-serif; font-size: x-small" bgcolor="#E5E5E5">
						<tr>
							<td style="width: 56px;">
								CLIENTE</td>
							<td colspan="3" style="width: 126px; text-align: left">
								<asp:DropDownList ID="dl_cliente" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="20px" Width="350px" TabIndex="3"   AutoPostBack="true" OnSelectedIndexChanged="dl_cliente_SelectedIndexChanged" CssClass="style5">
								</asp:DropDownList>
							</td>
							

						</tr>
						
					</table>
				</td>
			</tr>
		</table>
	</div>
	
	<asp:Button ID="Button1" runat="server" Font-Names="Arial" Visible="false" Font-Size="X-Small" Text="Guardar" OnClick="Button1_Click" TabIndex="16" />
	<cc1:confirmbuttonextender ID="Button1_ConfirmButtonExtender" runat="server" TargetControlID="Button1" ConfirmText="¿Esta seguro de ingresar un nuevo tipo de gasto?">
	</cc1:confirmbuttonextender>
	<asp:Button ID="Button2" runat="server" Font-Names="Arial" Font-Size="X-Small" Visible="false" OnClick="Button2_Click" Text="Limpiar" />
	
	<asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Names="Arial" Font-Size="X-Small" ForeColor="#333333"   GridLines="None" onselectedindexchanged="gr_dato_SelectedIndexChanged1">
		<RowStyle BackColor="#EFF3FB" />
		<Columns>
			<asp:BoundField AccessibleHeaderText="id_cliente" DataField="id_cliente" HeaderText="ID" />
			<asp:BoundField AccessibleHeaderText="nombre" DataField="nombre" HeaderText="NOMBRE" />
			<asp:TemplateField>
				<HeaderTemplate>
					<asp:CheckBox runat="server" ID="checkall" AutoPostBack="True" OnCheckedChanged="Check_Clicked" />
				</HeaderTemplate>
				<ItemTemplate>
					<asp:CheckBox ID="chk" runat="server" EnableViewState="true" Checked='<%# Bind("check")  %>' />
				</ItemTemplate>
			</asp:TemplateField>
			
		</Columns>
		
		<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
		<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
		<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
		<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
		<EditRowStyle BackColor="#2461BF" />
		<AlternatingRowStyle BackColor="White" />
	</asp:GridView>
	<asp:Button ID="Button3" runat="server" Font-Names="Arial" Font-Size="X-Small" Visible="false" Text="Guardar" OnClick="Button1_Click" TabIndex="16" Height="21px" />
	<br />

</asp:Content>