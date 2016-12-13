<%@ Page Title="" Language="C#" MasterPageFile="~/Adm.Master" AutoEventWireup="true" CodeBehind="gastomovimientocuentaperu.aspx.cs" Inherits="sistemaAGP.gastomovimientocuentaperu" Culture="es-PE" UICulture="es-PE" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<style type="text/css">
        .style4
        {
            width: 63px;
			background-color: #FFFFFF;
		}
        .style5
        {
            width: 58px;
            text-align: center;
			background-color: #FFFFFF;
		}
        .style7
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: x-small;
            font-weight: bold;
        }
        .style6
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: x-small;
            color: #FF3300;
        }
        .style8
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: x-small;
        }
        .style9
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: x-small;
            width: 59px;
        }
        .style10
        {
            width: 65px;
            text-align: center;
            background-color: #FFFFFF;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div>
		<asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Names="Arial" Font-Size="X-Small" ForeColor="#333333" GridLines="None">
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
						<asp:TextBox ID="txt_valor_gasto" MaxLength="6" Height="16px" runat="server" Text='<%# Bind("valor") %>' Width="50px" AutoCompleteType="Disabled" Font-Size="7pt" OnTextChanged="txt_valor_gasto_Leave" AutoPostBack="true" style="text-align: right;"></asp:TextBox>
						<cc1:FilteredTextBoxExtender ID="txt_valor_gasto_FilteredTextBoxExtender" runat="server" TargetControlID="txt_valor_gasto" FilterType="Custom, Numbers" ValidChars=",.">
						</cc1:FilteredTextBoxExtender>
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
			</Columns>
			<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
			<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
			<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
			<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
			<EditRowStyle BackColor="#2461BF" />
			<AlternatingRowStyle BackColor="White" />
		</asp:GridView>
		<table style="width: 81%; font-family: Arial, Helvetica, sans-serif; font-size: x-small" bgcolor="#E5E5E5">
		</table>
		<table style="width: 42%; font-family: Arial, Helvetica, sans-serif; font-size: x-small" bgcolor="#E5E5E5">
			<tr>
				<td class="style4">
					Nº Operacion
				</td>
				<td class="style10">
					<asp:Label ID="lbl_operacion" runat="server" Text="Label" Style="color: #FF3300"></asp:Label>
				</td>
				<td class="style4">
					Tipo Movimiento
				</td>
				<td class="style5">
					<asp:Label ID="lbl_tipo" runat="server" Text="Label" Style="color: #FF3300"></asp:Label>
				</td>
			</tr>
		</table>
	</div>
	<table>
		<tr>
			<td class="style7">
				SUBTOTAL
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
				TOTAL
			</td>
			<td style="text-align: right;">
				<b>
					<asp:Label ID="lbl_total" runat="server" CssClass="style6"></asp:Label>
				</b>
			</td>
		</tr>
	</table>
	<table>
		<tr>
			<td class="style9">
				Banco
			</td>
			<td>
				<asp:DropDownList ID="dl_financiera" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="138px" TabIndex="19" CssClass="style8" AutoPostBack="True" OnSelectedIndexChanged="dl_financiera_SelectedIndexChanged">
				</asp:DropDownList>
			</td>
			<td class="style8">
				Nº Cuenta
			</td>
			<td>
				<asp:DropDownList ID="dl_cuenta" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="138px" TabIndex="19" CssClass="style8">
				</asp:DropDownList>
			</td>
		</tr>
		<tr>
			<td class="style9">
				Tipo Operacion
			</td>
			<td>
				<asp:DropDownList ID="dl_tipo_operacion" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="138px" TabIndex="19" CssClass="style8">
				</asp:DropDownList>
			</td>
			<td class="style9">
				Numero Documento
			</td>
			<td>
				<asp:TextBox ID="txt_numero_documento" runat="server" Style="font-size: x-small; font-family: Arial, Helvetica, sans-serif" Width="121px" MaxLength="10"></asp:TextBox>
			</td>
			<td class="style9">
				Documento Especial
			</td>
			<td>
				<asp:TextBox ID="txt_especial" runat="server" Style="font-size: x-small; font-family: Arial, Helvetica, sans-serif" Width="121px" MaxLength="20"></asp:TextBox>
			</td>
		</tr>
	</table>
	<table style="width: 359px">
		<tr>
			<td style="text-align: center">
				<asp:Button ID="bt_guardar" runat="server" Text="Guardar" Font-Size="X-Small" Visible="true" OnClick="bt_guardar_Click" Style="height: 21px" />
				<cc1:ConfirmButtonExtender ID="bt_guardar_ConfirmButtonExtender" runat="server" TargetControlID="bt_guardar" ConfirmText="¿Esta seguro ingresar un movimiento de egreso?">
				</cc1:ConfirmButtonExtender>
			</td>
			<td style="text-align: center">
				<asp:Button ID="bt_comprobante" runat="server" Text="Comprobante" Font-Size="X-Small" Visible="true" Width="82px" />
			</td>
		</tr>
	</table>
	<table>
		<tr>
			<td class="style7">
				Movimientos generador en la Operacion
			</td>
		</tr>
	</table>
	<asp:GridView ID="gr_movimiento" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Names="Arial" Font-Size="X-Small" ForeColor="#333333" GridLines="None">
		<RowStyle BackColor="#EFF3FB" />
		<Columns>
			<asp:TemplateField AccessibleHeaderText="G.C." HeaderText="G.C.">
				<ItemTemplate>
					<asp:CheckBox ID="chkgc" runat="server" EnableViewState="true" Checked='<%# Bind("chkgc") %>' Enabled="false" />
				</ItemTemplate>
			</asp:TemplateField>
			<asp:BoundField AccessibleHeaderText="id" DataField="id_movimiento_cuenta" HeaderText="id">
				<ControlStyle Height="0px" Width="0px" />
			</asp:BoundField>
			<asp:BoundField AccessibleHeaderText="descripcion" DataField="descripcion" HeaderText="Descripcion" />
			<asp:BoundField AccessibleHeaderText="Banco" DataField="Banco" HeaderText="Banco" />
			<asp:BoundField AccessibleHeaderText="numero_cuenta" DataField="cuenta" HeaderText="Numero Cuenta" />
			<asp:BoundField AccessibleHeaderText="numero documento" DataField="numero_documento" HeaderText="Numero Documento" />
			<asp:BoundField AccessibleHeaderText="Monto" DataField="Monto" HeaderText="Monto" />
			<asp:BoundField AccessibleHeaderText="tipo_operacion" DataField="tipo_operacion" HeaderText="Tipo Operacion" />
			<asp:BoundField AccessibleHeaderText="fecha_movimiento" DataField="fecha_movimiento" HeaderText="Fecha Movimiento" />
			<asp:BoundField AccessibleHeaderText="Documento Especial" DataField="documento_especial" HeaderText="Documento Especial" />
			<asp:BoundField AccessibleHeaderText="usuario" DataField="usuario" HeaderText="Usuario" />
			<asp:TemplateField>
				<HeaderTemplate>
					<asp:CheckBox ID="checkall" runat="server" AutoPostBack="True" OnCheckedChanged="CheckMov_Clicked" />
				</HeaderTemplate>
				<ItemTemplate>
					<asp:CheckBox ID="chk" runat="server" AutoPostBack="true" Checked='<%# Bind("check") %>' EnableViewState="true" OnCheckedChanged="Check_Grilla_Clicked" />
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
	<table style="width: 68px">
		<tr>
			<td>
				<asp:Button ID="bt_Eliminar" runat="server" Text="Eliminar" Font-Size="X-Small" Visible="False" OnClick="bt_eliminar_Click" />
				<cc1:ConfirmButtonExtender ID="bt_Eliminar_ConfirmButtonExtender" runat="server" TargetControlID="bt_Eliminar" ConfirmText="¿Esta seguro de eliminar los movimientos de la operacion?">
				</cc1:ConfirmButtonExtender>
			</td>
		</tr>
	</table>
</asp:Content>