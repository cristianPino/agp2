<%@ Page Title="" Language="C#" MasterPageFile="~/Adm.Master" AutoEventWireup="true" CodeBehind="Rebajar_Operacion.aspx.cs" Inherits="sistemaAGP.Rebajar_Operacion" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<style type="text/css">


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
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	
	<table>
		<tr>
			<td class="style7">
				NUMERO DE FACTURA</td>
			<td>
				<b>
					<asp:Label ID="lbl_n_factura" runat="server" CssClass="style6"></asp:Label>
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
			<td>
				<asp:Button ID="bt_guardar" runat="server" Text="Guardar" Font-Size="X-Small" Visible="true" OnClick="bt_guardar_Click" Style="height: 21px" />
				<cc1:ConfirmButtonExtender ID="bt_guardar_ConfirmButtonExtender" runat="server" TargetControlID="bt_guardar" ConfirmText="¿Esta seguro ingresar un movimiento de egreso?">
				</cc1:ConfirmButtonExtender>
			</td>
			<%--<td style="text-align: center">
				<asp:Button ID="bt_comprobante" runat="server" Text="Comprobante" Font-Size="X-Small" Visible="true" Width="82px" />
			</td>--%>
			<%--<td style="text-align: right">
				<asp:Button ID="bt_cerrar" runat="server" Text="Cerrar" Font-Size="X-Small" Visible="true" OnClick="bt_cerrar_Click" Width="61px" />
			</td>--%>
		</tr>
	</table>
	</asp:Content>