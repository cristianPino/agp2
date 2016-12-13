<%@ Page Language="C#" MasterPageFile="~/AGP.Master" AutoEventWireup="true" CodeBehind="mPais.aspx.cs" Inherits="sistemaAGP.mPais" Title="AGP S.A. / Administracion de Pais" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoMenu" runat="server">
	<p style="margin-left: 40px">
		&nbsp;</p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContenidoCentral" runat="server">
	<table border="0" style="width: 493px; height: 347px">
		<tr>
			<td style="border-style: none; border-color: inherit; border-width: 0; text-align: left; width: 968px; height: 277px;" align="left" valign="top">
				<asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="X-Small" Text="Administracion de Paìs"></asp:Label>
				<br />
				<table style="width: 14%; font-family: Arial, Helvetica, sans-serif; font-size: x-small" bgcolor="#E5E5E5">
					<tr>
						<td style="width: 56px; text-align: right;">
							Codigo
							<td style="width: 126px; text-align: left">
								<asp:TextBox ID="txt_codigo" runat="server" Font-Names="Arial" Font-Size="X-Small" MaxLength="4" TabIndex="1"></asp:TextBox>
							</td>
							<td style="width: 15px; text-align: right">
								Nombre
							</td>
							<td style="text-align: left;">
								<asp:TextBox ID="txt_nombre" runat="server" Font-Names="Arial" Font-Size="X-Small" MaxLength="20" Width="190px" TabIndex="3"></asp:TextBox>
							</td>
					</tr>
				</table>
				<asp:Button ID="Button1" runat="server" Font-Names="Arial" Font-Size="X-Small" Text="Guardar" OnClick="Button1_Click" TabIndex="16" />
				<asp:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server" TargetControlID="Button1" ConfirmText="¿Esta seguro de ingresar un País?" />
				<asp:Button ID="Button2" runat="server" Font-Names="Arial" Font-Size="X-Small" OnClick="Button2_Click" Text="Limpiar" />
				<br />
				<asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Names="Verdana" Font-Size="X-Small" ForeColor="#333333" GridLines="None">
					<RowStyle BackColor="#EFF3FB" />
					<Columns>
						<asp:TemplateField AccessibleHeaderText="Codigo" HeaderText="Codigo">
							<EditItemTemplate>
								<asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("codigo") %>'></asp:TextBox>
							</EditItemTemplate>
							<ItemTemplate>
								<asp:Label ID="Label1" runat="server" Text='<%# Bind("codigo") %>'></asp:Label>
							</ItemTemplate>
						</asp:TemplateField>
						<asp:BoundField AccessibleHeaderText="Nombre" DataField="nombre" HeaderText="Nombre" />
					</Columns>
					<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
					<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
					<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
					<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
					<EditRowStyle BackColor="#2461BF" />
					<AlternatingRowStyle BackColor="White" />
				</asp:GridView>
			</td>
		</tr>
	</table>
</asp:Content>