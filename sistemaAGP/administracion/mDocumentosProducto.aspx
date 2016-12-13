<%@ Page Language="C#" MasterPageFile="~/Adm.Master" AutoEventWireup="true" CodeBehind="mDocumentosProducto.aspx.cs" Inherits="sistemaAGP.mDocumentosProducto" Title="Opciones de Documento por Producto" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<style type="text/css">
		.style1 {
            width: 100%;
            height: 3px;
        }
        .style4 {
            font-size: x-small;
            font-weight: bold;
            font-family: Arial, Helvetica, sans-serif;
        }
	</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<table class="style1">
		<tr>
			<td class="style4" colspan="2">
				Administración de Perfiles
			</td>
		</tr>
		<tr>
			<td class="style4" style="width: 25px;">
				Perfil
			</td>
			<td class="style4" style="width: auto;">
				<asp:Label ID="lbl_perfil" runat="server" Font-Names="Arial" Font-Size="X-Small" />
			</td>
		</tr>
		<tr>
			<td colspan="2">
				<asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" CellPadding="4"
					Font-Names="Arial" Font-Size="X-Small" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="gr_dato_SelectedIndexChanged"
					Style="margin-right: 0px">
					<RowStyle BackColor="#eff3fb" />
					<Columns>
						<asp:BoundField AccessibleHeaderText="id_documento" DataField="id_documento" HeaderText="Id.Documento" />
						<asp:BoundField AccessibleHeaderText="nombre" DataField="nombre" HeaderText="Nombre" />
						<asp:TemplateField ItemStyle-HorizontalAlign="Center">
							<HeaderTemplate>
								<asp:CheckBox runat="server" ID="checkall" AutoPostBack="True" OnCheckedChanged="Check_Clicked" Text="Activar" TextAlign="Left" />
							</HeaderTemplate>
							<ItemTemplate>
								<asp:CheckBox ID="chk" runat="server" EnableViewState="true" Checked='<%# Bind("check") %>' />
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
			</td>
		</tr>
		<tr>
			<td colspan="2">
				<asp:Button ID="Button1" runat="server" Font-Names="Arial" Font-Size="X-Small" Text="Guardar"
					OnClick="Button1_Click" TabIndex="16" Height="21px" />
				<cc1:ConfirmButtonExtender ID="Button1_ConfirmButtonExtender" runat="server" TargetControlID="Button1"
					ConfirmText="¿Esta seguro de actualizar el perfil?">
				</cc1:ConfirmButtonExtender>
			</td>
		</tr>
	</table>
</asp:Content>
