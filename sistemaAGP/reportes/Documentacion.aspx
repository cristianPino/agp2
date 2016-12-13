<%@ Page Language="C#" MasterPageFile="~/AGP.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Documentacion.aspx.cs" Inherits="sistemaAGP.Documentacion" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMenu" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoCentral" runat="server">
	<div style="display: block;">
		<table style="border: none;">
			<tr>
				<td style="border-style: none; border-color: inherit; border-width: 0; text-align: left;"
					align="left" valign="top" colspan="4">
					<asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="X-Small"
						Text="Administracion de Documentos"></asp:Label>
				</td>
			</tr>
			<tr>
				<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 35px">
					<asp:Label ID="lbl_nombre" runat="server" Font-Names="Arial" Font-Size="X-Small"
						Text="Nombre" />
				</td>
				<td style="width: 240px;">
					<asp:TextBox ID="txt_nombre" runat="server" Font-Names="Arial" Font-Size="X-Small"
						MaxLength="100" OnTextChanged="txt_nombre_TextChanged" Width="240px"></asp:TextBox>
				</td>
				<td style="width: 60px">
					<asp:Button ID="Button1" runat="server" Font-Names="Arial" Font-Size="X-Small" Text="Guardar"
						OnClick="Button1_Click" />
					<asp:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server" TargetControlID="Button1"
						ConfirmText="¿Esta seguro de ingresar una informe?" />
				</td>
				<td style="width: 60px">
					<asp:Button ID="Button2" runat="server" Font-Names="Arial" Font-Size="X-Small" OnClick="Button2_Click"
						Text="Limpiar" />
				</td>
			</tr>
		</table>
	</div>
	<div style="display: block;">
		<asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" CellPadding="4"
			Font-Names="Verdana" Font-Size="X-Small" ForeColor="#333333" GridLines="None"
			OnSelectedIndexChanged="gr_dato_SelectedIndexChanged" DataKeyNames="publico">
			<RowStyle BackColor="#eff3fb" />
			<Columns>
				<asp:BoundField AccessibleHeaderText="id_documento" DataField="id_documento" HeaderText="Id.Documento" />
				<asp:BoundField AccessibleHeaderText="nombre" DataField="nombre" HeaderText="Nombre" />
				<asp:TemplateField ItemStyle-HorizontalAlign="Center">
					<HeaderTemplate>
						<asp:CheckBox ID="checkall" runat="server" Text="P&uacute;blico" TextAlign="Left" OnCheckedChanged="Check_Clicked"
							ToolTip="Marca todos los elementos como públicos para usuarios externos" AutoPostBack="true" />
					</HeaderTemplate>
					<ItemTemplate>
						<asp:CheckBox ID="chk" runat="server" ToolTip="Marca el elemento como público para usuarios externos"
							Checked='<%# Bind("publico") %>' EnableViewState="true" />
					</ItemTemplate>
				</asp:TemplateField>
			</Columns>
			<FooterStyle BackColor="#507cd1" Font-Bold="True" ForeColor="White" />
			<PagerStyle BackColor="#2461bf" ForeColor="White" HorizontalAlign="Center" />
			<SelectedRowStyle BackColor="#d1ddf1" Font-Bold="True" ForeColor="#333333" />
			<HeaderStyle BackColor="#507cd1" Font-Bold="True" ForeColor="White" />
			<EditRowStyle BackColor="#2461bf" />
			<AlternatingRowStyle BackColor="White" />
		</asp:GridView>
	</div>
	<div style="display: block; width: 125px;">
		<asp:Button ID="btnGuardar" runat="server" Font-Names="Arial" Font-Size="X-Small"
			Text="Guardar cambios" OnClick="btnGuardar_Click" />
		<asp:ConfirmButtonExtender ID="ConfirmBtnGuardar" runat="server" TargetControlID="btnGuardar"
			ConfirmText="¿Esta seguro de guardar los cambios?" />
	</div>
</asp:Content>