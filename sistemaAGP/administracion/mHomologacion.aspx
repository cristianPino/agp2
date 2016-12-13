<%@ Page Language="C#" MasterPageFile="~/Adm.Master" AutoEventWireup="true" CodeBehind="mHomologacion.aspx.cs"
	Inherits="sistemaAGP.mHomologacion" Title="valores seguro" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<style type="text/css">
        .style4 {
            width: 209px;
			background-color: #FFFFFF;
            height: 1px;
        }
        .style5 {
            width: 58px;
            text-align: center;
			background-color: #FFFFFF;
            height: 1px;
        }
        .style8 {
            width: 78px;
        }
        .style10
        {
            width: 209px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div>
		<table style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 26px;" bgcolor="#E5E5E5">
			<tr>
				<td class="style4">
					Distribuidor Poliza
				</td>
				<td class="style5">
					<asp:Label ID="lbl_poliza" runat="server" Style="color: #FF3300" 
						meta:resourcekey="lbl_polizaResource1"></asp:Label>
				</td>
			</tr>
		<asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" CellPadding="4"
			Font-Names="Arial" Font-Size="X-Small" ForeColor="#333333" GridLines="None" OnRowEditing="gr_dato_RowEditing"
			OnSelectedIndexChanged="gr_dato_SelectedIndexChanged" 
			meta:resourcekey="gr_datoResource1">
			<RowStyle BackColor="#EFF3FB" />
			<Columns>
				<asp:BoundField AccessibleHeaderText="codigo" DataField="codigo" 
					HeaderText="codigo" meta:resourcekey="BoundFieldResource1">
					<ControlStyle Height="0px" Width="0px" />
				</asp:BoundField>
				<asp:BoundField AccessibleHeaderText="nombre" DataField="nombre" 
					HeaderText="nombre" meta:resourcekey="BoundFieldResource2" />
				<asp:TemplateField HeaderText="pariedad" meta:resourcekey="TemplateFieldResource1">
					<ItemTemplate>
						<asp:TextBox ID="txt_codigoTipVehDist" MaxLength="6" Height="16px" runat="server" Text='<%# Bind("codigoTipVehDist") %>'
							Width="50px" AutoCompleteType="Disabled" Font-Size="7pt" OnTextChanged="txt_codigoTipVehDist_Leave" 
							meta:resourcekey="txt_codigoTipVehDistResource1"></asp:TextBox>
						<cc1:FilteredTextBoxExtender ID="txt_codigoTipVehDist_FilteredTextBoxExtender" runat="server"
							TargetControlID="txt_codigoTipVehDist" FilterType="Custom, Numbers" Enabled="True">
						</cc1:FilteredTextBoxExtender>
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
		</table>
	</div>
	<div>
		<table style="width: 175px">
			<tr>
				<td class="style8">
					<asp:Button ID="bt_guardar" runat="server" Text="Guardar" Font-Size="X-Small"
						OnClick="bt_guardar_Click" UseSubmitBehavior="False" 
						meta:resourcekey="bt_guardarResource1" />
					<cc1:ConfirmButtonExtender ID="bt_guardar_ConfirmButtonExtender" runat="server" TargetControlID="bt_guardar"
						ConfirmText="¿Esta seguro de editar los gastos de esta operacion?" Enabled="True">
					</cc1:ConfirmButtonExtender>
				</td>
				<td style="text-align: left">
					<asp:Button ID="bt_cerrar" runat="server" Text="Cerrar" Font-Size="X-Small"
						OnClick="bt_cerrar_Click" Width="70px" Style="text-align: left" 
						meta:resourcekey="bt_cerrarResource1" />
				</td>
			</tr>
		</table>
	</div>
</asp:Content>