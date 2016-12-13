<%@ Page Language="C#" MasterPageFile="~/Adm.Master" AutoEventWireup="true" CodeBehind="mClienteTipooperciongasto.aspx.cs" Inherits="sistemaAGP.mClienteTipooperciongasto" Title="Administracion de Gastos por cliente" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<style type="text/css">

        .style1
        {
            width: 49px;
        }
        .style3
        {
            width: 94px;
        }
        .style4
        {
            width: 58px;
        }
        .style5
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: x-small;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div>
		<table bgcolor="#E5E5E5" style="width: 459px">
			<tr>
				<td>
					<table style="width: 74%; font-family: Arial, Helvetica, sans-serif; font-size: x-small" bgcolor="#E5E5E5">
						<tr>
							<td class="style1">
								Cliente:
							</td>
							<td>
								<asp:Label ID="lbl_cliente" runat="server" Font-Names="Arial" Font-Size="X-Small"></asp:Label>
							</td>
						</tr>
					</table>
					<table style="width: 99%; font-family: Arial, Helvetica, sans-serif; font-size: x-small" bgcolor="#E5E5E5">
						<tr>
							<td style="width: 56px;">
								Familia
							</td>
							<td colspan="3" style="width: 126px; text-align: left">
								<asp:DropDownList ID="dl_familia" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="20px" Width="350px" TabIndex="3" AutoPostBack="True" OnSelectedIndexChanged="dl_familia_SelectedIndexChanged" CssClass="style5">
								</asp:DropDownList>
							</td>
							
						</tr>
						<tr>
							<td style="width: 56px;">
								Producto Empresa
							</td>
							<td colspan="3" style="width: 126px; text-align: left">
								<asp:DropDownList ID="dl_producto" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="20px" Width="350px" TabIndex="3" AutoPostBack="True" OnSelectedIndexChanged="dl_producto_SelectedIndexChanged" CssClass="style5">
								</asp:DropDownList>
							</td>
							
						</tr>


					</table>
				</td>
			</tr>
		</table>
	</div>
	
	<asp:Button  Visible="false" ID="Button2" runat="server" Font-Names="Arial" Font-Size="X-Small" OnClick="Button2_Click" Text="Limpiar" />
	<asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Names="Arial" Font-Size="X-Small" ForeColor="#333333" GridLines="None" OnRowEditing="gr_dato_RowEditing" OnSelectedIndexChanged="gr_dato_SelectedIndexChanged">
		<RowStyle BackColor="#EFF3FB" />
		<Columns>
			<asp:BoundField AccessibleHeaderText="id_tipogasto" DataField="id_tipogasto" HeaderText="id_tipogasto" />
			
				
					<asp:BoundField AccessibleHeaderText="descripcion" DataField="descripcion" HeaderText="Descripcion" />
				
				
			
			
			
			<asp:TemplateField>
				<HeaderTemplate>
					<asp:Label ID="lbl_cargo" Text="Gasto AGP" runat="server"></asp:Label>
				</HeaderTemplate>
				<ItemTemplate>
					<asp:CheckBox ID="check" runat="server" EnableViewState="true" Checked='<%# Bind("check") %>' />
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
	<asp:Button ID="Button1" runat="server" Font-Names="Arial" Font-Size="X-Small" Text="Guardar" OnClick="Button1_Click" TabIndex="16" />
	<cc1:ConfirmButtonExtender ID="Button1_ConfirmButtonExtender" runat="server" TargetControlID="Button1" ConfirmText="¿Esta seguro de ingresar un nuevo tipo de gasto?">
	</cc1:ConfirmButtonExtender>
	<asp:Button ID="bt_editar" runat="server" Text="Editar" Font-Size="X-Small" Visible="False" OnClick="bt_editar_Click" />
	<cc1:ConfirmButtonExtender ID="bt_editar_ConfirmButtonExtender" runat="server" TargetControlID="bt_editar" ConfirmText="¿Esta seguro de editar los gastos?">
	</cc1:ConfirmButtonExtender>
	<br />
</asp:Content>