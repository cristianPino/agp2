<%@ Page Language="C#" MasterPageFile="~/Adm.Master" AutoEventWireup="true" CodeBehind="mSucursal.aspx.cs" Inherits="sistemaAGP.mSucursal" Title="Administracion de Sucursales" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<style type="text/css">
        .style1
        {
            width: 49px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div>
		<table style="width: 81%; font-family: Arial, Helvetica, sans-serif; font-size: x-small" bgcolor="#E5E5E5">
			<tr>
				<td class="style1">
					Cliente:
				</td>
				<td>
					<asp:Label ID="lbl_cliente" runat="server" Font-Names="Arial" Font-Size="X-Small"></asp:Label>
				</td>
			</tr>
		</table>
		<table style="width: 81%; font-family: Arial, Helvetica, sans-serif; font-size: x-small" bgcolor="#E5E5E5">
			<tr>
				<td style="width: 56px;">
					Pais
				</td>
				<td style="width: 126px; text-align: left">
					<asp:DropDownList ID="dl_pais" runat="server" AutoPostBack="True" Font-Names="Arial" Font-Size="X-Small" Height="16px" OnSelectedIndexChanged="dl_pais_SelectedIndexChanged" Width="138px" TabIndex="17">
					</asp:DropDownList>
				</td>
				<td style="width: 15px; text-align: right">
					Region
				</td>
				<td style="text-align: left;">
					<asp:DropDownList ID="dl_region" runat="server" AutoPostBack="True" Font-Names="Arial" Font-Size="X-Small" Height="19px" OnSelectedIndexChanged="dl_region_SelectedIndexChanged" Width="213px" TabIndex="18">
					</asp:DropDownList>
				</td>
			</tr>
			<tr>
				<td style="width: 15px;">
					Ciudad
				</td>
				<td style="text-align: left;">
					<asp:DropDownList ID="dl_ciudad" runat="server" AutoPostBack="True" Font-Names="Arial" Font-Size="X-Small" Height="19px" Width="173px" OnSelectedIndexChanged="dl_ciudad_SelectedIndexChanged" TabIndex="19">
					</asp:DropDownList>
				</td>
				<td style="width: 15px; text-align: right">
					Comuna
				</td>
				<td style="text-align: left;">
					<asp:DropDownList ID="dl_comuna" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="19px" Width="213px" TabIndex="20">
					</asp:DropDownList>
				</td>
			</tr>
			<tr>
				<td style="width: 15px;">
					Modulo
				</td>
				<td style="text-align: left;">
					<asp:DropDownList ID="dl_modulo" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="19px" Width="173px" TabIndex="19">
					</asp:DropDownList>
				</td>
				<td style="width: 15px; text-align: right">
					Nombre
				</td>
				<td style="text-align: left;">
					<asp:TextBox ID="txt_nombre" runat="server" Height="16px" MaxLength="30" Width="327px"></asp:TextBox>
				</td>
			</tr>
		</table>
	</div>
	<asp:Button ID="Button1" runat="server" Font-Names="Arial" Font-Size="X-Small" Text="Guardar" OnClick="Button1_Click" TabIndex="16" />
	<cc1:ConfirmButtonExtender ID="Button1_ConfirmButtonExtender" runat="server" TargetControlID="Button1" ConfirmText="¿Esta seguro de ingresar una nueva Sucursal?">
	</cc1:ConfirmButtonExtender>
	&nbsp;<asp:Button ID="Button2" runat="server" Font-Names="Arial" Font-Size="X-Small" OnClick="Button2_Click" Text="Limpiar" />
	<asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Names="Arial" Font-Size="X-Small" ForeColor="#333333" GridLines="None">
		<RowStyle BackColor="#EFF3FB" />
		<Columns>
			<asp:BoundField AccessibleHeaderText="Id_Sucursal" DataField="id_sucursal" HeaderText="id_sucursal" />
			<asp:BoundField AccessibleHeaderText="nombre" DataField="nombre" HeaderText="Nombre" />
			<asp:BoundField AccessibleHeaderText="modulo" DataField="Modulo" HeaderText="Modulo" />
			<asp:BoundField AccessibleHeaderText="comuna" DataField="Comuna" HeaderText="Comuna" />
			<asp:ButtonField ButtonType="Button" Text="Editar">
				<ControlStyle Font-Names="Arial" Font-Size="X-Small" />
			</asp:ButtonField>
		</Columns>
		<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
		<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
		<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
		<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
		<EditRowStyle BackColor="#2461BF" />
		<AlternatingRowStyle BackColor="White" />
	</asp:GridView>
</asp:Content>