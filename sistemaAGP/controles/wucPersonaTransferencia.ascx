<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucPersonaTransferencia.ascx.cs" Inherits="sistemaAGP.wucPersonaTransferencia" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<table style="background-color: #669999; width: 100%">
	<tr>
		<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: auto; color: #ffffff;">
			<strong><asp:Label ID="lbl_titulo" runat="server" Text="" /></strong>
		</td>
	</tr>
</table>
<table style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
	<tr>
		<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 50px; padding: 0 2px 0 2px;">
			Rut
		</td>
		<td style="width: 115px;">
			<asp:TextBox ID="txt_rut" runat="server" MaxLength="8" AutoPostBack="True" OnTextChanged="txt_rut_Leave" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; background-color: #0099ff; color: #ffffff; width: 115px; height: 16px;"></asp:TextBox>
			<cc1:FilteredTextBoxExtender ID="txt_rut_FilteredTextBoxExtender" runat="server" TargetControlID="txt_rut" FilterType="Custom, Numbers" ValidChars="">
			</cc1:FilteredTextBoxExtender>
		</td>
		<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 10px; padding: 0 2px 0 2px; text-align: center;">
			<strong>-</strong>
		</td>
		<td style="width: 20px;">
			<asp:TextBox ID="txt_dv" runat="server" MaxLength="1" Enabled="False" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 20px; height: 16px;"></asp:TextBox>
		</td>
		<td style="width: 16px;">
			<asp:Button ID="bt_limpia_persona" runat="server" BackColor="White" Height="16px" Width="16px" OnClick="bt_limpia_persona_Click" />
		</td>
		<td>
			&nbsp;
		</td>
	</tr>
</table>
<table style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
	<tr>
		<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 50px; padding: 0 2px 0 2px;">
			Nombre
		</td>
		<td>
			<asp:TextBox ID="txt_nombre" runat="server" MaxLength="100" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 200px; height: 16px;"></asp:TextBox>
		</td>
		<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 90px; padding: 0 2px 0 2px;">
			Apellido Paterno
		</td>
		<td>
			<asp:TextBox ID="txt_paterno" runat="server" MaxLength="30" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 170px; height: 16px;"></asp:TextBox>
		</td>
		<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 90px; padding: 0 2px 0 2px;">
			Apellido Materno
		</td>
		<td>
			<asp:TextBox ID="txt_materno" runat="server" MaxLength="30" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 170px; height: 16px;"></asp:TextBox>
		</td>
	</tr>
</table>
<asp:Panel ID="pnlOtrosDatos" runat="server">
	<table>
		<tr>
			<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 90px; padding: 0 2px 0 2px;">
				Sexo
			</td>
			<td>
				<asp:DropDownList ID="dl_sexo" runat="server" Font-Names="Arial" Font-Size="X-Small" TabIndex="6">
				</asp:DropDownList>
			</td>
			<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 90px; padding: 0 2px 0 2px;">
				Nacionalidad
			</td>
			<td>
				<asp:TextBox ID="txt_nacionalidad" runat="server" MaxLength="30" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 170px; height: 16px;"></asp:TextBox>
			</td>
			<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 90px; padding: 0 2px 0 2px;">
				Profesión
			</td>
			<td>
				<asp:TextBox ID="txt_profesion" runat="server" MaxLength="250" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 170px; height: 16px;"></asp:TextBox>
			</td>
			<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 90px; padding: 0 2px 0 2px;">
				Estado Civil
			</td>
			<td>
				<asp:DropDownList ID="dl_estado_civil" runat="server" Font-Names="Arial" Font-Size="X-Small" TabIndex="10">
				</asp:DropDownList>
			</td>
		</tr>
	</table>
</asp:Panel>
<asp:Panel ID="pnl_opciones" runat="server">
	<table>
		<tr>
			<td style="text-align: center; padding: 0 5px 0 5px; width: 32px; height: 32px;">
				<asp:ImageButton ID="ib_direccion" runat="server" ImageUrl="../imagenes/sistema/static/direccion.jpg" Height="32px" Width="32px" OnClick="ib_direccion_Click" />
			</td>
			<td style="text-align: center; padding: 0 5px 0 5px; width: 32px; height: 32px;">
				<asp:ImageButton ID="ib_telefono" runat="server" ImageUrl="../imagenes/sistema/static/telefono.jpg" Height="32px" Width="32px" OnClick="ib_telefono_Click" />
			</td>
			<td style="text-align: center; padding: 0 5px 0 5px; width: 32px; height: 32px;">
				<asp:ImageButton ID="ib_correo" runat="server" ImageUrl="../imagenes/sistema/static/mail.jpg" Height="32px" Width="32px" OnClick="ib_correo_Click" />
			</td>
            <td style="text-align: center; padding: 0 5px 0 5px; width: 32px; height: 32px;">
				<asp:ImageButton ID="ib_participante" runat="server" ImageUrl="../imagenes/sistema/icono001.gif" Height="32px" Width="32px" OnClick="ib_participante_Click" />
			</td>
			<td style="width: 663px; text-align: right;">
				<a id="lnk_popup" runat="server" class="fancybox fancybox.iframe" style="display: none;"></a>
				<asp:CheckBox ID="chk_compra_para" runat="server" AutoPostBack="True" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; font-weight: 700; color: #ff0000;" Text="Compra Para" OnCheckedChanged="chk_compra_para_CheckedChanged" />
			</td>
		</tr>
	</table>
</asp:Panel>
