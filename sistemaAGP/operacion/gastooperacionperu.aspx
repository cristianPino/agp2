<%@ Page Title="" Language="C#" MasterPageFile="~/Adm.Master" AutoEventWireup="true" CodeBehind="gastooperacionperu.aspx.cs" Inherits="sistemaAGP.gastooperacionperu" Culture="es-PE" UICulture="es-PE" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<style type="text/css">
		.style4
		{
			width: 127px;
			background-color: #FFFFFF;
		}
		.style5
		{
			width: 58px;
			text-align: center;
			background-color: #FFFFFF;
		}
		.style6
		{
			font-family: Arial, Helvetica, sans-serif;
			font-size: x-small;
			color: #FF3300;
		}
		.style7
		{
			font-family: Arial, Helvetica, sans-serif;
			font-size: x-small;
			font-weight: bold;
		}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div>
		<table style="width: 81%; font-family: Arial, Helvetica, sans-serif; font-size: x-small" bgcolor="#E5E5E5">
		</table>
		<table style="width: 28%; font-family: Arial, Helvetica, sans-serif; font-size: x-small" bgcolor="#E5E5E5">
			<tr>
				<td class="style4">
					Nº Operacion
				</td>
				<td class="style5">
					<asp:Label ID="lbl_operacion" runat="server" Text="Label" Style="color: #FF3300"></asp:Label>
				</td>
			</tr>
		</table>
	</div>
	&nbsp;<asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Names="Arial" Font-Size="X-Small" ForeColor="#333333" GridLines="None" OnRowEditing="gr_dato_RowEditing" OnSelectedIndexChanged="gr_dato_SelectedIndexChanged" DataKeyNames="bloqueo" OnRowDataBound="gr_dato_RowDataBound">
		<RowStyle BackColor="#EFF3FB" />
		<Columns>
			<asp:TemplateField AccessibleHeaderText="G.C." HeaderText="G.C.">
				<ItemTemplate>
					<asp:CheckBox ID="chkgc" runat="server" EnableViewState="true" Checked='<%# Bind("checkgc") %>' Enabled="false" />
				</ItemTemplate>
			</asp:TemplateField>
			<asp:BoundField AccessibleHeaderText="id_tipogasto" DataField="id_tipogasto" HeaderText="id_tipogasto">
				<ControlStyle Height="0px" Width="0px" />
			</asp:BoundField>
			<asp:BoundField AccessibleHeaderText="descripcion" DataField="descripcion" HeaderText="Descripcion" />
			<asp:TemplateField HeaderText="Valor">
				<ItemTemplate>
					<asp:TextBox ID="txt_valor_gasto" MaxLength="6" Height="16px" runat="server" Text='<%# Bind("valor") %>' Width="60px" AutoCompleteType="Disabled" Font-Size="7pt" OnTextChanged="txt_valor_gasto_Leave" AutoPostBack="true"></asp:TextBox>
					<%--<cc1:FilteredTextBoxExtender ID="txt_valor_gasto_FilteredTextBoxExtender" runat="server" TargetControlID="txt_valor_gasto" FilterType="Custom, Numbers" ValidChars=".">
					</cc1:FilteredTextBoxExtender>--%>
					<cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txt_valor_gasto" Mask="9{5}.99" MaskType="Number" InputDirection="RightToLeft" />
				</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField>
				<HeaderTemplate>
					<asp:CheckBox runat="server" ID="checkall" AutoPostBack="True" OnCheckedChanged="Check_Clicked" />
				</HeaderTemplate>
				<ItemTemplate>
					<asp:CheckBox ID="chk" runat="server" EnableViewState="true" OnCheckedChanged="Check_Grilla_Clicked" AutoPostBack="true" Checked='<%# Bind("check") %>' />
				</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField HeaderText="Cargo Cliente">
				<ItemTemplate>
					<asp:TextBox ID="txt_cargo_cliente" MaxLength="6" Height="16px" runat="server" Text='<%# Bind("cargo_cliente") %>' Width="60px" AutoCompleteType="Disabled" Font-Size="7pt" OnTextChanged="txt_cargo_cliente_Leave" AutoPostBack="true"></asp:TextBox>
					<%--<cc1:FilteredTextBoxExtender ID="txt_cargo_cliente_FilteredTextBoxExtender" runat="server" TargetControlID="txt_cargo_cliente" FilterType="Custom, Numbers" ValidChars=".">
					</cc1:FilteredTextBoxExtender>--%>
					<cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txt_cargo_cliente" Mask="9{5}.99" MaskType="Number" InputDirection="RightToLeft" />
				</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField HeaderText="Cargo Empresa">
				<ItemTemplate>
					<asp:TextBox ID="txt_cargo_empresa" MaxLength="6" Height="16px" runat="server" Text='<%# Bind("cargo_empresa") %>' Width="60px" AutoCompleteType="Disabled" Font-Size="7pt" OnTextChanged="txt_cargo_empresa_Leave" AutoPostBack="true"></asp:TextBox>
					<%--<cc1:FilteredTextBoxExtender ID="txt_cargo_empresa_FilteredTextBoxExtender" runat="server" TargetControlID="txt_cargo_empresa" FilterType="Custom, Numbers" ValidChars=".">
					</cc1:FilteredTextBoxExtender>--%>
					<cc1:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txt_cargo_empresa" Mask="9{5}.99" MaskType="Number" InputDirection="RightToLeft" />
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
	<table>
		<tr>
			<td class="style7">
				CARGO CLIENTE
			</td>
			<td style="text-align: right;">
				<b>
					<asp:Label ID="lbl_cargo_cliente" runat="server" CssClass="style6"></asp:Label>
				</b>
			</td>
		</tr>
		<tr>
			<td class="style7">
				CARGO EMPRESA
			</td>
			<td style="text-align: right;">
				<b>
					<asp:Label ID="lbl_cargo_empresa" runat="server" CssClass="style6"></asp:Label>
				</b>
			</td>
		</tr>
		<tr>
			<td class="style7">
				SUBTOTAL SELECCIONADO
			</td>
			<td style="text-align: right;">
				<b>
					<asp:Label ID="lbl_subtotal" runat="server" CssClass="style6"></asp:Label>
				</b>
			</td>
		</tr>
		<tr>
			<td class="style7">
				IGV (18%)
			</td>
			<td style="text-align: right;">
				<b>
					<asp:Label ID="lbl_igv" runat="server" CssClass="style6"></asp:Label>
				</b>
			</td>
		</tr>
		<tr>
			<td class="style7">
				TOTAL SELECCIONADO
			</td>
			<td style="text-align: right;">
				<b>
					<asp:Label ID="lbl_total" runat="server" CssClass="style6"></asp:Label>
				</b>
			</td>
		</tr>
	</table>
	<table style="width: 175px">
		<tr>
			<td style="text-align: center">
				<asp:Button ID="bt_guardar" runat="server" Text="Guardar" Font-Size="X-Small" Visible="true" OnClick="bt_guardar_Click" />
				<cc1:ConfirmButtonExtender ID="bt_guardar_ConfirmButtonExtender" runat="server" TargetControlID="bt_guardar" ConfirmText="¿Esta seguro de editar los gastos de esta operacion?">
				</cc1:ConfirmButtonExtender>
			</td>
			<td style="text-align: center">
				<asp:Button ID="bt_cerrar" runat="server" Text="Cerrar" Font-Size="X-Small" Visible="true" OnClick="bt_cerrar_Click" Width="70px" />
			</td>
		</tr>
	</table>
</asp:Content>