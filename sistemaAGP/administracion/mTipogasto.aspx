<%@ Page Language="C#" MasterPageFile="~/Adm.Master" AutoEventWireup="true" CodeBehind="mTipogasto.aspx.cs" Inherits="sistemaAGP.mTipogasto" Title="Administracion de Gastos por cliente" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
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
								Producto Empresa
							</td>
							<td colspan="3" style="width: 126px; text-align: left">
								<asp:DropDownList ID="dl_producto" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="20px" Width="350px" TabIndex="3" AutoPostBack="True" OnSelectedIndexChanged="dl_producto_SelectedIndexChanged" CssClass="style5">
								</asp:DropDownList>
							</td>
							<td style="height: 19px">
								<asp:CheckBox ID="chk_transferencia" runat="server" Text="transferencia" />
							</td>


						</tr>
						<tr>
							<td style="width: 15px;">
								Nombre Gasto
							</td>
							<td style="text-align: left;">
								<asp:TextBox ID="txt_nombre" MaxLength="50" runat="server" Height="16px" Width="200px" TabIndex="1" OnTextChanged="txt_nombre_TextChanged" CssClass="style5"></asp:TextBox>
							</td>
							<td style="text-align: right" class="style4">
								Valor Gasto
							</td>
							<td style="text-align: left;" class="style3">
								<asp:TextBox ID="txt_valor" runat="server" Height="16px" Width="86px" TabIndex="2" MaxLength="6" CssClass="style5"></asp:TextBox>
								<cc1:filteredtextboxextender ID="txt_valor_FilteredTextBoxExtender" runat="server" TargetControlID="txt_valor" FilterType="Custom, Numbers" ValidChars="">
								</cc1:filteredtextboxextender>
							</td>
							<td>
								<asp:CheckBox ID="chk_gasto" runat="server" Text="Gasto AGP" OnCheckedChanged="chk_gasto_CheckedChanged" />
							</td>
						</tr>
					</table>
				</td>
			</tr>
		</table>
	</div>
	
	<asp:Button ID="Button1" runat="server" Font-Names="Arial" Font-Size="X-Small" Text="Guardar" OnClick="Button1_Click" TabIndex="16" />
	<cc1:confirmbuttonextender ID="Button1_ConfirmButtonExtender" runat="server" TargetControlID="Button1" ConfirmText="¿Esta seguro de ingresar un nuevo tipo de gasto?">
	</cc1:confirmbuttonextender>
	<asp:Button ID="Button2" runat="server" Font-Names="Arial" Font-Size="X-Small" OnClick="Button2_Click" Text="Limpiar" />
	
	<ajaxToolkit:TabContainer ID="tab_datos" runat="server" Width="100%" ActiveTabIndex="1" ScrollBars="Auto">
		<ajaxToolkit:TabPanel ID="tab_negocio" runat="server" HeaderText="TRAMITE" Width="100%">
			<ContentTemplate><table>
					
			<asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Names="Arial" Font-Size="X-Small" ForeColor="#333333" GridLines="None" OnRowEditing="gr_dato_RowEditing" OnSelectedIndexChanged="gr_dato_SelectedIndexChanged">
			<AlternatingRowStyle BackColor="White" />
			<Columns>
			<asp:BoundField AccessibleHeaderText="id_tipogasto" DataField="id_tipogasto" HeaderText="id_tipogasto" />
			<asp:TemplateField HeaderText="Nombre Gasto">
			<ItemTemplate><asp:TextBox ID="txt_nombre_gasto" Height="16px" MaxLength="50" runat="server" Text='<%# Bind("nombre") %>' Width="200px" AutoCompleteType="Disabled" OnTextChanged="txt_nombre_gasto_TextChanged" Font-Size="7pt">
			</asp:TextBox>
			</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField HeaderText="Valor">
			<ItemTemplate>
			<asp:TextBox ID="txt_valor_gasto" MaxLength="6" Height="16px" runat="server" Text='<%# Bind("valor") %>' Width="50px" AutoCompleteType="Disabled" OnTextChanged="txt_valor_gasto_TextChanged" Font-Size="7pt">
			</asp:TextBox>
			<cc1:FilteredTextBoxExtender ID="txt_valor_gasto_FilteredTextBoxExtender" runat="server" TargetControlID="txt_valor_gasto" FilterType="Custom, Numbers" ValidChars="">
			</cc1:FilteredTextBoxExtender>
			</ItemTemplate>
			</asp:TemplateField>
				<asp:TemplateField HeaderText="Cuenta Gasto">
					<ItemTemplate>
						<asp:TextBox ID="cuenta" MaxLength="10" Height="16px" runat="server" Text='<%# Bind("cuenta") %>' Width="50px" AutoCompleteType="Disabled" OnTextChanged="txt_cuenta_TextChanged" Font-Size="7pt">
						</asp:TextBox>
						<cc1:FilteredTextBoxExtender ID="cuenta_FilteredTextBoxExtender" runat="server" TargetControlID="cuenta" FilterType="Custom, Numbers" ValidChars="">
						</cc1:FilteredTextBoxExtender>
					</ItemTemplate>
				</asp:TemplateField>
				<asp:BoundField AccessibleHeaderText="nombrecuenta" DataField="nombrecuenta" HeaderText="nombrecuenta" />
				<asp:TemplateField HeaderText="Cuenta Facturacion">
					<ItemTemplate>
						<asp:TextBox ID="cuentafac" MaxLength="10" Height="16px" runat="server" Text='<%# Bind("cuentafac") %>' Width="50px" AutoCompleteType="Disabled" OnTextChanged="txt_cuenta_TextChanged" Font-Size="7pt">
						</asp:TextBox>
						<cc1:FilteredTextBoxExtender ID="cuentafac_FilteredTextBoxExtender" runat="server" TargetControlID="cuentafac" FilterType="Custom, Numbers" ValidChars="">
						</cc1:FilteredTextBoxExtender>
					</ItemTemplate>
				</asp:TemplateField>

				
			
			
			<asp:BoundField AccessibleHeaderText="producto" DataField="producto" HeaderText="producto" />
			<asp:TemplateField>
			<HeaderTemplate>
			<asp:Label ID="lbl_cargo" Text="Gasto AGP" runat="server">
			</asp:Label>
			</HeaderTemplate>
			<ItemTemplate>
			<asp:CheckBox ID="chk" runat="server" EnableViewState="true" Checked='<%# Bind("cargo_contable") %>' />
			</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField>
			<HeaderTemplate>
			<asp:Label ID="lbl_transf" Text="Transferencia" runat="server">
			</asp:Label>
			</HeaderTemplate>
			<ItemTemplate>
			<asp:CheckBox ID="chk_trans" runat="server" EnableViewState="true" Checked='<%# Bind("transferencia") %>' />
			</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField>
			<HeaderTemplate>
			<asp:Label ID="lbl_habilitado" Text="Habilitado" runat="server">
			</asp:Label>
			</HeaderTemplate>
			<ItemTemplate>
			<asp:CheckBox ID="chk_habilitado" runat="server" EnableViewState="true" Checked='<%# Bind("habilitado") %>' />
			</ItemTemplate>
			</asp:TemplateField>
			</Columns>
			<EditRowStyle BackColor="#2461BF" />
			<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
			<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" /><RowStyle BackColor="#EFF3FB" /><SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" /></asp:GridView><asp:Button ID="bt_editar" runat="server" Text="Editar" Font-Size="X-Small" Visible="False" OnClick="bt_editar_Click" /><cc1:ConfirmButtonExtender ID="bt_editar_ConfirmButtonExtender" runat="server" TargetControlID="bt_editar" ConfirmText="¿Esta seguro de editar los gastos?"></cc1:ConfirmButtonExtender></table></ContentTemplate>
		</ajaxToolkit:TabPanel>
		<ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="GASTOS COMUNES" Width="100%">
			
		<HeaderTemplate>GASTOS COMUNES</HeaderTemplate><ContentTemplate><table><tr><td class="style2"><asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Names="Arial" Font-Size="X-Small" ForeColor="#333333" GridLines="None" OnRowEditing="gr_dato_RowEditing" OnSelectedIndexChanged="gr_dato_SelectedIndexChanged" EnableModelValidation="True"><AlternatingRowStyle BackColor="White" /><Columns><asp:BoundField AccessibleHeaderText="id_tipogasto" DataField="id_tipogasto" HeaderText="id_tipogasto" /><asp:BoundField AccessibleHeaderText="descripcion" DataField="descripcion" HeaderText="Descripcion" /><asp:TemplateField><HeaderTemplate><asp:Label ID="lbl_cargo" Text="Gasto AGP" runat="server"></asp:Label></HeaderTemplate><ItemTemplate><asp:CheckBox ID="check" runat="server" EnableViewState="true" Checked='<%# Bind("check") %>' /></ItemTemplate></asp:TemplateField></Columns><EditRowStyle BackColor="#2461BF" /><FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" /><HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" /><RowStyle BackColor="#EFF3FB" /><SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" /></asp:GridView><br /></td></tr></table><asp:Button ID="Button4" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" Text="Grabar" OnClick="Button2_Click" /></ContentTemplate></ajaxToolkit:TabPanel>

	</ajaxToolkit:TabContainer>
	
	
	<br />

</asp:Content>