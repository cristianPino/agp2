<%@ Page Language="C#" MasterPageFile="~/Adm.Master" AutoEventWireup="true" CodeBehind="mProductoTipogasto.aspx.cs" Inherits="sistemaAGP.mProductoTipogasto" Title="Administracion de Gastos por cliente" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<style type="text/css">

        .style1
        {
            width: 49px;
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
							

						</tr>
						
					</table>
				</td>
			</tr>
		</table>
	</div>
	
	
	
	
	
		
	
			
		<HeaderTemplate>GASTOS COMUNES</HeaderTemplate><ContentTemplate><table><tr><td class="style2"><asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Names="Arial" Font-Size="X-Small" ForeColor="#333333" GridLines="None" OnRowEditing="gr_dato_RowEditing" OnSelectedIndexChanged="gr_dato_SelectedIndexChanged" EnableModelValidation="True"><AlternatingRowStyle BackColor="White" /><Columns><asp:BoundField AccessibleHeaderText="id_tipogasto" DataField="id_tipogasto" HeaderText="id_tipogasto" /><asp:BoundField AccessibleHeaderText="descripcion" DataField="descripcion" HeaderText="Descripcion" /><asp:TemplateField><HeaderTemplate><asp:Label ID="lbl_cargo" Text="Gasto AGP" runat="server"></asp:Label></HeaderTemplate><ItemTemplate><asp:CheckBox ID="check" runat="server" EnableViewState="true" Checked='<%# Bind("check") %>' /></ItemTemplate></asp:TemplateField></Columns><EditRowStyle BackColor="#2461BF" /><FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" /><HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" /><PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" /><RowStyle BackColor="#EFF3FB" /><SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" /></asp:GridView><br /></td></tr></table><asp:Button ID="Button4" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" Text="Grabar" OnClick="Button2_Click" /></ContentTemplate></ajaxToolkit:TabPanel>

	
	
	
	<br />

</asp:Content>