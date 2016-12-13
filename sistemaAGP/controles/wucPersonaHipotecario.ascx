<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucPersonaHipotecario.ascx.cs" Inherits="sistemaAGP.wucPersonaHipotecario" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<table class="tabla_datos">
	<tr class="tr_fila">
		<td>
			<strong><asp:Label ID="lbl_titulo" runat="server" Text="" /></strong>
		</td>
	</tr>
</table>
<table class="tabla_datos">
    
	<tr class="tr_fila">
		<td>
			Rut
		</td>
		<td>
			<asp:TextBox ID="txt_rut" runat="server" MaxLength="8" AutoPostBack="True" OnTextChanged="txt_rut_Leave" CssClass="inputs"></asp:TextBox>
			<cc1:FilteredTextBoxExtender ID="txt_rut_FilteredTextBoxExtender" runat="server" TargetControlID="txt_rut" FilterType="Custom, Numbers" ValidChars="">
			</cc1:FilteredTextBoxExtender>
		</td>
		<td>
			<strong>-</strong>
			<asp:TextBox ID="txt_dv" runat="server" MaxLength="1" Enabled="False" Width="10px" CssClass="inputs"></asp:TextBox>
            <asp:Button ID="bt_limpia_persona" runat="server" BackColor="White" Height="16px" Width="16px" OnClick="bt_limpia_persona_Click" />
		</td>
		<td>
			&nbsp;</td>
		<td>
			
		</td>
		<td>
			&nbsp;
		</td>
	</tr>
	<tr class="tr_fila">
		<td>
			Nombre
		</td>
		<td>
			<asp:TextBox ID="txt_nombre" runat="server" MaxLength="100" CssClass="inputs"></asp:TextBox>
		</td>
		<td>
			Apellido Paterno
		</td>
		<td>
			<asp:TextBox ID="txt_paterno" runat="server" MaxLength="30" CssClass="inputs"></asp:TextBox>
		</td>
		<td>
			Apellido Materno
		</td>
		<td>
			<asp:TextBox ID="txt_materno" runat="server" MaxLength="30" CssClass="inputs"></asp:TextBox>
		</td>
	</tr>
		<tr runat="server" id="OtrosDatos" class="tr_fila">
			<td>
				Sexo
			</td>
			<td>
				<asp:DropDownList ID="dl_sexo" runat="server" CssClass="ddl">
				</asp:DropDownList>
			</td>
			<td>
				Nacionalidad
			</td>
			<td>
				<asp:TextBox ID="txt_nacionalidad" runat="server" MaxLength="30" CssClass="inputs"></asp:TextBox>
			</td>
			<td>
				Profesión
			</td>
			<td>
				<asp:TextBox ID="txt_profesion" runat="server" MaxLength="250" CssClass="inputs"></asp:TextBox>
			</td>
            </tr>
            <tr runat="server" id="OtrosDatos2" class="tr_fila" >
			<td>
				Estado Civil
			</td>
			<td>
				<asp:DropDownList ID="dl_estado_civil" runat="server" CssClass="ddl">
				</asp:DropDownList>
			</td>
		</tr>
	</table>

<asp:Panel ID="pnl_opciones" runat="server">
	<table class="tabla_datos">
		<tr>
			<td>
				<asp:ImageButton ID="ib_direccion" runat="server" ImageUrl="../imagenes/sistema/static/direccion.jpg" Height="32px" Width="32px" OnClick="ib_direccion_Click" />
			</td>
			<td>
				<asp:ImageButton ID="ib_telefono" runat="server" ImageUrl="../imagenes/sistema/static/telefono.jpg" Height="32px" Width="32px" OnClick="ib_telefono_Click" />
			</td>
			<td>
				<asp:ImageButton ID="ib_correo" runat="server" ImageUrl="../imagenes/sistema/static/mail.jpg" Height="32px" Width="32px" OnClick="ib_correo_Click" />
			</td>
            <td>
				<asp:ImageButton ID="ib_participante" runat="server" ImageUrl="../imagenes/sistema/icono001.gif" Height="32px" Width="32px" OnClick="ib_participante_Click" />
			</td>
			<td>
				<a id="lnk_popup" runat="server" class="fancybox fancybox.iframe" style="display: none;"></a>
				<asp:CheckBox ID="chk_compra_para" runat="server" AutoPostBack="True" Text="Compra Para" OnCheckedChanged="chk_compra_para_CheckedChanged" />
			</td>
		</tr>
	</table>
</asp:Panel>
