<%@ Page Language="C#" MasterPageFile="~/ADM.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="mGastosComunes.aspx.cs" Inherits="sistemaAGP.mGastosComunes" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<asp:UpdatePanel ID="up_datos" runat="server">
		<ContentTemplate>
			
			<table style="width: 450px; height: 60px">
				<tr>
					<td style="border-style: none; border-color: inherit; border-width: 0; text-align: left;" class="style1">
						<asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="X-Small" Text="Administracion de Flujos de trabajo"></asp:Label>
						<br />
						<tr>
							<td style="width: 226px; text-align: left">
								Nombre Gasto
								<asp:TextBox Height="17px" Width="200px" ID="TextBox1" runat="server"></asp:TextBox>
							</td>
							<td style="width: 226px; text-align: left">
								Cuenta
								<asp:TextBox Height="17px" Width="200px" ID="TextBox2" runat="server"></asp:TextBox>
							</td>
							<td style="width: 226px; text-align: left">
								Proveedor
								<asp:TextBox Height="17px" Width="200px" ID="TextBox4" runat="server"></asp:TextBox>
							</td>
							<td style="width: 226px; text-align: left">
								Cuenta Facturacion
								<asp:TextBox Height="17px" Width="200px" ID="TextBox5" runat="server"></asp:TextBox>
							</td>
						</tr>
			</table>
			<tr>
				
				Valor
				<asp:TextBox Height="17px" Width="35px" ID="TextBox3" runat="server"></asp:TextBox>
				Cargo contable
				<asp:CheckBox ID="chk_aviso" MaxLength="2" Height="16px" runat="server" Checked='<%# Bind("envia_adquiriente") %>' Width="20px" AutoCompleteType="Disabled" Font-Size="7pt"></asp:CheckBox>
				Transferencia
				<asp:CheckBox ID="CheckBox1" MaxLength="2" Height="16px" runat="server" Checked='<%# Bind("envia_adquiriente") %>' Width="20px" AutoCompleteType="Disabled" Font-Size="7pt"></asp:CheckBox>
				
				Bloqueada
				<asp:CheckBox ID="CheckBox3" MaxLength="2" Height="16px" runat="server" Checked='<%# Bind("envia_adquiriente") %>' Width="20px" AutoCompleteType="Disabled" Font-Size="7pt"></asp:CheckBox>
				Factura
				<asp:CheckBox ID="CheckBox2" MaxLength="2" Height="16px" runat="server" Checked='<%# Bind("envia_adquiriente") %>' Width="20px" AutoCompleteType="Disabled" Font-Size="7pt"></asp:CheckBox>
				Opcional
				<asp:CheckBox ID="CheckBox4" MaxLength="2" Height="16px" runat="server" Checked='<%# Bind("envia_adquiriente") %>' Width="20px" AutoCompleteType="Disabled" Font-Size="7pt"></asp:CheckBox>
			</tr>
			<table>
				<tr>
					<td>
						<asp:Button runat="server" Text="Grabar" OnClick="grabar" Visible="true" ID="Button1" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" />
					</td>
				</tr>
			</table>
			</table>		
			
			
				<asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Names="Arial" Font-Size="X-Small" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="gr_dato_SelectedIndexChanged">
					<RowStyle BackColor="#EFF3FB" />
					<Columns>
						<asp:BoundField AccessibleHeaderText="id_gasto" DataField="id_gasto" HeaderText="Id Gasto" Visible="true" />
						<asp:TemplateField HeaderText="Nombre Gasto" meta:resourcekey="TemplateFieldResource1">
							<ItemTemplate>
								<asp:TextBox ID="descripcion" Text='<%# Bind("descripcion") %>' MaxLength="380" Height="16px" runat="server" Width="150px" AutoCompleteType="Disabled" Font-Size="7pt"></asp:TextBox>
							</ItemTemplate>
						</asp:TemplateField>


						<asp:BoundField AccessibleHeaderText="Valor" DataField="Valor" HeaderText="Valor" Visible="true" />
						<asp:TemplateField HeaderText="cargo_contable" meta:resourcekey="TemplateFieldResource3">
							<ItemTemplate>
								<asp:CheckBox ID="cargo_contable" MaxLength="2" Checked='<%# Bind("cargo_contable") %>' Height="16px" runat="server" Width="20px" AutoCompleteType="Disabled" Font-Size="7pt"></asp:CheckBox>
							</ItemTemplate>
							<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
						</asp:TemplateField>
						<asp:TemplateField HeaderText="transferencia" meta:resourcekey="TemplateFieldResource3">
							<ItemTemplate>
								<asp:CheckBox ID="transferencia" MaxLength="2" Checked='<%# Bind("transferencia") %>' Height="16px" runat="server" Width="20px" AutoCompleteType="Disabled" Font-Size="7pt"></asp:CheckBox>
							</ItemTemplate>
							<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
						</asp:TemplateField>
						<asp:TemplateField HeaderText="bloqueada" meta:resourcekey="TemplateFieldResource3">
							<ItemTemplate>
								<asp:CheckBox ID="bloqueada" MaxLength="2" Checked='<%# Bind("bloqueada") %>' Height="16px" runat="server" Width="20px" AutoCompleteType="Disabled" Font-Size="7pt"></asp:CheckBox>
							</ItemTemplate>
							<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Factura" meta:resourcekey="TemplateFieldResource3">
							<ItemTemplate>
								<asp:CheckBox ID="Factura" MaxLength="2" Checked='<%# Bind("Factura") %>' Height="16px" runat="server" Width="20px" AutoCompleteType="Disabled" Font-Size="7pt"></asp:CheckBox>
							</ItemTemplate>
							<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
						</asp:TemplateField>
						


						<asp:TemplateField HeaderText="Plan de Cuenta" meta:resourcekey="TemplateFieldResource1">
							<ItemTemplate>
								<asp:TextBox ID="pdecta" Text='<%# Bind("pdecta") %>' MaxLength="380" Height="16px" runat="server" Width="150px" AutoCompleteType="Disabled" Font-Size="7pt"></asp:TextBox>
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Proveedor" meta:resourcekey="TemplateFieldResource1">
							<ItemTemplate>
								<asp:TextBox ID="proveedor" Text='<%# Bind("proveedor") %>' MaxLength="380" Height="16px" runat="server" Width="150px" AutoCompleteType="Disabled" Font-Size="7pt"></asp:TextBox>
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Cuenta Facturacion" meta:resourcekey="TemplateFieldResource1">
							<ItemTemplate>
								<asp:TextBox ID="ctafac" Text='<%# Bind("ctafac") %>' MaxLength="380" Height="16px" runat="server" Width="150px" AutoCompleteType="Disabled" Font-Size="7pt"></asp:TextBox>
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Gasto Opcional" meta:resourcekey="TemplateFieldResource3">
							<ItemTemplate>
								<asp:CheckBox ID="opcional" MaxLength="2" Checked='<%# Bind("opcional") %>' Height="16px" runat="server" Width="20px" AutoCompleteType="Disabled" Font-Size="7pt"></asp:CheckBox>
							</ItemTemplate>
							<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
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
						<td>
							<asp:Button runat="server" Text="Actualizar" OnClick="presionado" Visible="true" ID="Button2" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" />
						</td>
					</tr>
				</table>
			
		</ContentTemplate>
	</asp:UpdatePanel>
	<%--<table style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; background-color: #e5e5e5;">
		<tr>
			<td>
				Nombre Gasto
			</td>
			<td>
				<asp:TextBox ID="txt_nombre" MaxLength="50" runat="server" Height="16px" Width="200px"></asp:TextBox>
			</td>
			<td>
				Valor Gasto
			</td>
			<td>
				<asp:TextBox ID="txt_valor" runat="server" Height="16px" Width="46px" MaxLength="6"></asp:TextBox>
				<ajaxToolkit:FilteredTextBoxExtender ID="txt_valor_FilteredTextBoxExtender" runat="server" TargetControlID="txt_valor" FilterType="Custom, Numbers" ValidChars="">
				</ajaxToolkit:FilteredTextBoxExtender>
			</td>
			<td>
				<asp:CheckBox ID="chk_gasto" runat="server" Text="Cargo Contable" />
			</td>
			<td>
				<asp:CheckBox ID="chk_transferencia" runat="server" Text="Transferencia" />
			</td>
		</tr>
	</table>
	<asp:Button ID="Button1" runat="server" Font-Names="Arial" Font-Size="X-Small" Text="Guardar" OnClick="Button1_Click" TabIndex="16" />
	<ajaxToolkit:ConfirmButtonExtender ID="Button1_ConfirmButtonExtender" runat="server" TargetControlID="Button1" ConfirmText="¿Esta seguro de ingresar un nuevo tipo de gasto ?">
	</ajaxToolkit:ConfirmButtonExtender>
	&nbsp;<asp:Button ID="Button2" runat="server" Font-Names="Arial" Font-Size="X-Small" OnClick="Button2_Click" Text="Limpiar" />
	<asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Names="Arial" Font-Size="X-Small" ForeColor="#333333" GridLines="None" OnRowEditing="gr_dato_RowEditing" OnSelectedIndexChanged="gr_dato_SelectedIndexChanged">
		<RowStyle BackColor="#EFF3FB" />
		<Columns>
			<asp:BoundField AccessibleHeaderText="id_tipogasto" DataField="id_tipogasto" HeaderText="id_tipogasto" />
			<asp:TemplateField HeaderText="Nombre Gasto">
				<ItemTemplate>
					<asp:TextBox ID="txt_nombre_gasto" Height="16px" MaxLength="50" runat="server" Text='<%# Bind("nombre") %>' Width="200px" AutoCompleteType="Disabled" OnTextChanged="txt_nombre_gasto_TextChanged" Font-Size="7pt"></asp:TextBox>
				</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField HeaderText="Valor">
				<ItemTemplate>
					<asp:TextBox ID="txt_valor_gasto" MaxLength="6" Height="16px" runat="server" Text='<%# Bind("valor") %>' Width="50px" AutoCompleteType="Disabled" OnTextChanged="txt_valor_gasto_TextChanged" Font-Size="7pt"></asp:TextBox>
					<ajaxToolkit:FilteredTextBoxExtender ID="txt_valor_gasto_FilteredTextBoxExtender" runat="server" TargetControlID="txt_valor_gasto" FilterType="Custom, Numbers" ValidChars="">
					</ajaxToolkit:FilteredTextBoxExtender>
				</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField>
				<HeaderTemplate>
					<asp:Label ID="lbl_cargo" Text="cargo_contable" runat="server"></asp:Label>
				</HeaderTemplate>
				<ItemTemplate>
					<asp:CheckBox ID="chk" runat="server" EnableViewState="true" Checked='<%# Bind("cargo_contable") %>' />
				</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField>
				<HeaderTemplate>
					<asp:Label ID="lbl_transf" Text="Transferencia" runat="server"></asp:Label>
				</HeaderTemplate>
				<ItemTemplate>
					<asp:CheckBox ID="chk_trans" runat="server" EnableViewState="true" Checked='<%# Bind("transferencia") %>' />
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
	<asp:Button ID="bt_editar" runat="server" Text="Editar" Font-Size="X-Small" Visible="False" OnClick="bt_editar_Click" />
	<ajaxToolkit:ConfirmButtonExtender ID="bt_editar_ConfirmButtonExtender" runat="server" TargetControlID="bt_editar" ConfirmText="¿Esta seguro de editar los gastos?">
	</ajaxToolkit:ConfirmButtonExtender>--%>
</asp:Content>