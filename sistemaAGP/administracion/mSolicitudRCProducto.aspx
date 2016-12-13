<%@ Page Title="" Language="C#" MasterPageFile="~/Adm.Master" AutoEventWireup="true"
	CodeBehind="mSolicitudRCProducto.aspx.cs" Inherits="sistemaAGP.administracion.mSolicitudRCProducto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div style="padding-bottom: 5px;">
		<asp:Label ID="lblTitulo" runat="server" Font-Bold="true" Font-Names="Arial" Font-Size="X-Small"
			Text="Administración Solicitudes Registro Civil" />
	</div>
	<div style="padding-bottom: 5px;">
		<asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" CellPadding="4"
			Font-Names="Arial" Font-Size="X-Small" ForeColor="#333333" GridLines="None" DataKeyNames="ID,Codigo,CodSolicRC">
			<RowStyle BackColor="#eff3fb" />
			<Columns>
				<asp:BoundField AccessibleHeaderText="codigo" DataField="CodSolicRC" HeaderText="Código" />
				<asp:BoundField AccessibleHeaderText="descripcion" DataField="DescSolicRC" HeaderText="Descripción" />
				<asp:TemplateField ItemStyle-HorizontalAlign="Center">
					<HeaderTemplate>
						<asp:CheckBox runat="server" ID="checkall" AutoPostBack="True" OnCheckedChanged="Check_Clicked"
							Text="Activar" TextAlign="Left" />
					</HeaderTemplate>
					<ItemTemplate>
						<asp:CheckBox ID="chk" runat="server" EnableViewState="true" Checked='<%# Bind("Check") %>' />
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
	<div>
		<asp:Button ID="btnGuardar" runat="server" Font-Names="Arial" Font-Size="X-Small"
			Text="Guardar" TabIndex="16" Height="21px" onclick="btnGuardar_Click" />
		<cc1:ConfirmButtonExtender ID="btnGuardar_ConfirmButtonExtender" runat="server" TargetControlID="btnGuardar"
			ConfirmText="¿Esta seguro de actualizar el perfil?" />
	</div>
</asp:Content>