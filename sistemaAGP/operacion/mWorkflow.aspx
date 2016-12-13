<%@ Page Title="Analisis estado" Language="C#" MasterPageFile="~/Adm.Master" AutoEventWireup="true" CodeBehind="mWorkflow.aspx.cs" Inherits="sistemaAGP.mWorkflow" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div style="font-family: Arial; font-size: x-small; font-weight: bold">
		Administracion de WorkFlow
	</div>
	<div>
		<asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" 
			CellPadding="4" Font-Names="Arial" Font-Size="X-Small" ForeColor="#333333" 
			GridLines="None" Width="445px" 
			onselectedindexchanged="gr_dato_SelectedIndexChanged">
			<RowStyle BackColor="#EFF3FB" />
			<Columns>
				<asp:BoundField DataField="estado" HeaderText="Estado" />
				<asp:BoundField DataField="cuenta_usuario" HeaderText="cuenta usuario" Visible="False" />
				<asp:BoundField DataField="nombre_usuario" HeaderText="Usuario" />
				<asp:BoundField DataField="fecha" HeaderText="Fecha Hora" />
				<asp:BoundField DataField="observacion" HeaderText="Observación" />
				<asp:BoundField DataField="contador" HeaderText="Contador" />
				<asp:ImageField AccessibleHeaderText="Semaforo" DataImageUrlField="semaforo" HeaderText="Semaforo">
				</asp:ImageField>
			</Columns>
			<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
			<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
			<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
			<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
			<EditRowStyle BackColor="#2461BF" />
			<AlternatingRowStyle BackColor="White" />
		</asp:GridView>
	</div>
	<%--<table border="0" style="width: 493px; height: 347px">
		<tr>
			<td style="border-style: none; border-color: inherit; border-width: 0; text-align: left; width: 968px; height: 277px;" align="left" valign="top">
				<asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="X-Small" Text="Administracion de WorkFlow"></asp:Label>
				<br />
				<table style="width: 14%; font-family: Arial, Helvetica, sans-serif; font-size: x-small" bgcolor="#E5E5E5">
				</table>
				<br />
				<asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Names="Arial" Font-Size="X-Small" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="gr_dato_SelectedIndexChanged" Width="445px">
					<RowStyle BackColor="#EFF3FB" />
					<Columns>
						<asp:BoundField AccessibleHeaderText="Estado" DataField="estado" HeaderText="Estado" />
						<asp:BoundField AccessibleHeaderText="cuenta usuario" DataField="cuenta_usuario" HeaderText="cuenta usuario" Visible="False" />
						<asp:BoundField AccessibleHeaderText="Usuario" DataField="nombre_usuario" HeaderText="Usuario" />
						<asp:BoundField AccessibleHeaderText="fecha_hora" DataField="fecha" HeaderText="Fecha Hora" />
						<asp:BoundField AccessibleHeaderText="observacion" DataField="observacion" HeaderText="Observacion" />
					</Columns>
					<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
					<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
					<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
					<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
					<EditRowStyle BackColor="#2461BF" />
					<AlternatingRowStyle BackColor="White" />
				</asp:GridView>
				<br />
			</td>
		</tr>
	</table>--%>
</asp:Content>