<%@ Page Language="C#" MasterPageFile="~/AGP.Master" AutoEventWireup="true" CodeBehind="mUsuariodatos.aspx.cs" Inherits="sistemaAGP.mUsuariodatos" Title="Administrador datos del usuario" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMenu" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoCentral" runat="server">
	<table  class=table border="0" style="width: 1028px;">
		<tr>
			<td style="border-style: none; border-color: inherit; border-width: 0; text-align: left; width: 1057px;" align="left" valign="top">
				<asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="X-Small" Text="Administracion de Usuarios"></asp:Label>
			</td>
		</tr>
		<tr>
			<td>
				<table style="width: 63%; font-family: Arial, Helvetica, sans-serif; font-size: x-small" bgcolor="#E5E5E5">
					<tr>
						<td style="width: 56px; text-align: right;">
							Cuenta
						</td>
						<td style="width: 126px; text-align: left">
							<asp:TextBox ID="txt_cuenta" runat="server" Height="16px" MaxLength="9" Width="93px" TabIndex="1" AutoPostBack="True" BackColor="#0099FF" ForeColor="White" OnTextChanged="txt_cuenta_Leave" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"></asp:TextBox>
						</td>
						<td style="width: 15px; text-align: right">
							Nombre
						</td>
						<td style="text-align: left; width: 128px;">
							<asp:TextBox ID="txt_nombre" runat="server" Height="16px" Width="216px" MaxLength="50" TabIndex="2" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"></asp:TextBox>
						</td>
						<td style="width: 15px; text-align: right">
							Empresa
						</td>
						<td style="text-align: left;">
							<asp:DropDownList ID="dl_cliente" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="138px" TabIndex="7" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small">
							</asp:DropDownList>
						</td>
					</tr>
					<tr>
						<td style="width: 56px; text-align: right; height: 20px;">
							Clave
						</td>
						<td style="width: 126px; text-align: left; height: 20px;">
							<asp:TextBox ID="txt_clave" runat="server" Height="16px" MaxLength="10" Width="93px" TabIndex="3" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"></asp:TextBox>
						</td>
						<td style="width: 15px; text-align: right; height: 20px;">
							Telefono
						</td>
						<td style="text-align: left; width: 128px; height: 20px;">
							<asp:TextBox ID="txt_telefono" runat="server" Height="16px" MaxLength="10" Width="121px" TabIndex="4" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"></asp:TextBox>
						</td>
						<td style="width: 15px; text-align: right; height: 20px;">
							Anexo
						</td>
						<td style="text-align: left; height: 20px;">
							<asp:TextBox ID="txt_anexo" runat="server" Height="16px" Width="63px" MaxLength="4" TabIndex="5" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"></asp:TextBox>
						</td>
					</tr>
					<tr>
						<td style="width: 56px; text-align: right;">
							Correo
						</td>
						<td style="width: 126px; text-align: left">
							<asp:TextBox ID="txt_correo" runat="server" Height="17px" MaxLength="50" Width="125px" TabIndex="6" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"></asp:TextBox>
						</td>
						<td style="width: 15px; text-align: right">
							Nivel Consulta
						</td>
						<td style="text-align: left; width: 128px;">
							<asp:DropDownList ID="dl_nivel" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="138px" TabIndex="7" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small">
							</asp:DropDownList>
						</td>
						<td>
							Intentos
						</td>
						<td style="text-align: left;">
							<asp:TextBox ID="txt_intentos" runat="server" Height="16px" Width="64px" MaxLength="50" TabIndex="8" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"></asp:TextBox>
						</td>
					</tr>
					<tr>
						<td>
							Usuario NAV
						</td>
						<td style="text-align: left;">
							<asp:TextBox ID="usuanav" runat="server" Height="16px" Width="64px" MaxLength="50" TabIndex="8" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"></asp:TextBox>
						</td>
					</tr>
					<tr>
						<td style="text-align: right;">
							Perfil
						</td>
						<td>
							<asp:DropDownList ID="dl_perfil" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="138px" TabIndex="7" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small">
							</asp:DropDownList>
						</td>
						<td colspan="4">
							<asp:CheckBox ID="chk_permite_eliminar" runat="server" Text="Puede eliminar operaciones" Enabled="false" />
						</td>
					</tr>
				</table>
				<asp:Button ID="Button1" runat="server" Font-Names="Arial" Font-Size="X-Small" Text="Guardar" OnClick="Button1_Click" TabIndex="16" Height="21px" />
				<cc1:ConfirmButtonExtender ID="Button1_ConfirmButtonExtender" runat="server" TargetControlID="Button1" ConfirmText="¿Esta seguro de ingresar un nuevo Usuario?">
				</cc1:ConfirmButtonExtender>
			</td>
		</tr>
	</table>
</asp:Content>