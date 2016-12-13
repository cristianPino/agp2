<%@ Page Language="C#" MasterPageFile="~/AGP.Master" AutoEventWireup="true" CodeBehind="Ingreso_Sii.aspx.cs"
	Inherits="sistemaAGP.Ingreso_Sii" Title="Ingreso de Codigo SII" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMenu" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoCentral" runat="server">
	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
		<ContentTemplate>
			<table class="style1">
				<tr>
					<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; font-weight: 700;
						color: #FFFFFF; background-color: #0066FF">
						Ingreso Codigo SII
					</td>
				</tr>
			</table>
			<table class="style1">
				<tr>
					<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;" class="style21">
						Codigo SII
					</td>
					<td class="style11">
						<asp:Label ID="lbl_codigo" runat="server" ForeColor="#FF3300" Style="font-weight: 700;
							font-size: small"></asp:Label>
					</td>
				</tr>
				<tr>
					<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;" class="style21">
						Tipo Vehiculo
					</td>
					<td class="style5">
						<asp:DropDownList ID="dl_tipo_vehiculo" runat="server" Font-Names="Arial" Font-Size="X-Small"
							Height="16px" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"
							TabIndex="1" Width="167px">
						</asp:DropDownList>
					</td>
				</tr>
				<tr>
					<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;" class="style21">
						Marca
					</td>
					<td class="style5">
						<asp:DropDownList ID="dl_marca_vehiculo" runat="server" Font-Names="Arial" Font-Size="X-Small"
							Height="16px" Width="168px" TabIndex="2" Style="font-family: Arial, Helvetica, sans-serif;
							font-size: x-small">
						</asp:DropDownList>
					</td>
				</tr>
				<tr>
					<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;" class="style21">
						Modelo
					</td>
					<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;" class="style21">
						<asp:TextBox ID="txt_modelo" runat="server" CssClass="style2" Width="376px"></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;" class="style21">
						Año
					</td>
					<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;" class="style21">
						<asp:TextBox ID="txt_ano" runat="server" CssClass="style2" Width="56px" MaxLength="4"></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;" class="style21">
						Cilindrada
					</td>
					<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;" class="style21">
						<asp:TextBox ID="txt_cilindrada" runat="server" CssClass="style2" Width="56px" MaxLength="4"></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;" class="style21">
						Puertas
					</td>
					<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;" class="style21">
						<asp:TextBox ID="txt_puerta" runat="server" CssClass="style2" Width="49px" MaxLength="2"></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;" class="style21">
						Combustible
					</td>
					<td class="style15">
						<asp:DropDownList ID="dl_combustible" runat="server" TabIndex="13" Style="font-family: Arial, Helvetica, sans-serif;
							font-size: x-small; width: 138px; height: 16px;">
						</asp:DropDownList>
					</td>
				</tr>
				<tr>
					<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;" class="style19">
						Transmicion
					</td>
					<td class="style9">
						<asp:DropDownList ID="dl_transmicion" runat="server" Style="font-family: Arial, Helvetica, sans-serif;
							font-size: x-small; width: 138px; height: 16px;" TabIndex="14">
						</asp:DropDownList>
					</td>
				</tr>
				<tr>
					<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;" class="style21">
						Equipo
					</td>
					<td class="style9">
						<asp:DropDownList ID="dl_equipo" runat="server" Style="font-family: Arial, Helvetica, sans-serif;
							font-size: x-small; width: 138px; height: 16px;" TabIndex="15">
						</asp:DropDownList>
					</td>
				</tr>
				<tr>
					<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;" class="style21">
						Tasacion
					</td>
					<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;" class="style21">
						<asp:TextBox ID="txt_tasacion" runat="server" CssClass="style2" Width="88px"></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;" class="style21">
						Permiso
					</td>
					<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;" class="style21">
						<asp:TextBox ID="txt_permiso" runat="server" CssClass="style2" Width="88px" MaxLength="2"></asp:TextBox>
					</td>
				</tr>
			</table>
			<table>
				<tr>
					<td class="style8">
						<asp:Button ID="Button1" runat="server" Style="font-family: Arial, Helvetica, sans-serif;
							font-size: x-small; font-weight: 700;" Text="Guardar" OnClick="Button1_Click" />
					</td>
					<td class="style8">
						<asp:Button ID="Button2" runat="server" Style="font-family: Arial, Helvetica, sans-serif;
							font-size: x-small; font-weight: 700;" Text="Limpiar" OnClick="Button2_Click" />
					</td>
				</tr>
			</table>
		</ContentTemplate>
	</asp:UpdatePanel>
</asp:Content>
