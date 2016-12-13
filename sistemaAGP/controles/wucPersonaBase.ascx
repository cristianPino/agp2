<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucPersonaBase.ascx.cs" Inherits="sistemaAGP.wucPersonaBase" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:UpdatePanel ID="up_persona" runat="server">
	<ContentTemplate>
		<table class="tabla-normal">
			<tr>
				<td style="width: 110px;">
					<asp:Label ID="lbl_rut" runat="server" Text="R.U.N."></asp:Label>
				</td>
				<td style="width: 160px;">
					<asp:TextBox ID="txt_rut" runat="server" MaxLength="8" AutoPostBack="True" 
						Width="70px" BackColor="#0099ff" ForeColor="#ffffff" 
						OnTextChanged="txt_rut_TextChanged"></asp:TextBox><strong>-</strong><asp:TextBox ID="txt_dv" runat="server" MaxLength="1" Enabled="False" Width="15px" CssClass="dv"></asp:TextBox>
					<ajaxToolkit:FilteredTextBoxExtender ID="filter_rut" runat="server" TargetControlID="txt_rut" FilterType="Custom, Numbers" ValidChars='<%= System.Globalization.CultureInfo.CreateSpecificCulture("es-CL").NumberFormat.NumberGroupSeparator %>'>
					</ajaxToolkit:FilteredTextBoxExtender>
					<asp:RequiredFieldValidator ID="rfv_rut" runat="server" CssClass="error" Text="*" ErrorMessage="Rut" ControlToValidate="txt_rut" InitialValue="" SetFocusOnError="true"></asp:RequiredFieldValidator>
					<asp:RequiredFieldValidator ID="rfv_rut2" runat="server" CssClass="error" Text="*" ErrorMessage="Rut" ControlToValidate="txt_rut" InitialValue="" SetFocusOnError="true" ValidationGroup="persona"></asp:RequiredFieldValidator>
					<asp:RangeValidator ID="rv_rut" runat="server" CssClass="error" Text="*" ErrorMessage="RUN no puede ser superior a 50.000.000" ControlToValidate="txt_rut" MinimumValue="0" MaximumValue="49999999" SetFocusOnError="true" Enabled="false"></asp:RangeValidator>
				</td>
				<td>
					<asp:Button ID="bt_limpia_persona" runat="server" Text="Limpiar" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;" OnClick="bt_limpia_persona_Click" CausesValidation="false" />
				</td>
			</tr>
		</table>
		<table class="tabla-normal">
			<tr>
				<td style="width: 110px;">
					<asp:Label ID="lbl_nombre" runat="server" Text="Nombre"></asp:Label>
				</td>
				<td colspan="3">
					<asp:TextBox ID="txt_nombre" runat="server" MaxLength="100" Width="400px"></asp:TextBox>
					<asp:RequiredFieldValidator ID="rfv_nombre" runat="server" CssClass="error" Text="*" ErrorMessage="Nombre" ControlToValidate="txt_nombre" InitialValue="" SetFocusOnError="true"></asp:RequiredFieldValidator>
					<asp:RequiredFieldValidator ID="rfv_nombre2" runat="server" CssClass="error" Text="*" ErrorMessage="Nombre" ControlToValidate="txt_nombre" InitialValue="" SetFocusOnError="true" ValidationGroup="persona"></asp:RequiredFieldValidator>
				</td>
			</tr>
		</table>
		<asp:Panel ID="pnl_apellidos" runat="server">
			<table class="tabla-normal">
				<tr>
					<td style="width: 110px;">
						Apellido Paterno
					</td>
					<td>
						<asp:TextBox ID="txt_paterno" runat="server" MaxLength="30" Width="400px"></asp:TextBox>
						<asp:RequiredFieldValidator ID="rfv_paterno" runat="server" CssClass="error" Text="*" ErrorMessage="Apellido Paterno" ControlToValidate="txt_paterno" InitialValue="" SetFocusOnError="true"></asp:RequiredFieldValidator>
						<asp:RequiredFieldValidator ID="rfv_paterno2" runat="server" CssClass="error" Text="*" ErrorMessage="Apellido Paterno" ControlToValidate="txt_paterno" InitialValue="" SetFocusOnError="true" ValidationGroup="persona"></asp:RequiredFieldValidator>
					</td>
				</tr>
				<tr>
					<td style="width: 110px;">
						Apellido Materno
					</td>
					<td>
						<asp:TextBox ID="txt_materno" runat="server" MaxLength="30" Width="400px"></asp:TextBox>
						<asp:RequiredFieldValidator ID="rfv_materno" runat="server" CssClass="error" Text="*" ErrorMessage="Apellido Materno" ControlToValidate="txt_materno" InitialValue="" SetFocusOnError="true"></asp:RequiredFieldValidator>
						<asp:RequiredFieldValidator ID="rfv_materno2" runat="server" CssClass="error" Text="*" ErrorMessage="Apellido Materno" ControlToValidate="txt_materno" InitialValue="" SetFocusOnError="true" ValidationGroup="persona"></asp:RequiredFieldValidator>
					</td>
				</tr>
			</table>
		</asp:Panel>
		<asp:Panel ID="pnl_otros_datos" runat="server">
			<table class="tabla-normal">
				<tr>
					<td style="width: 110px;">
						Sexo
					</td>
					<td>
						<asp:DropDownList ID="dl_sexo" runat="server" Width="120px">
						</asp:DropDownList>
			
					</td>
					<td style="width: 110px;">
						Estado Civil
					</td>
					<td>
						<asp:DropDownList ID="dl_estado_civil" runat="server" Width="150px">
						</asp:DropDownList>

					</td>
				</tr>
				<tr>
					<td>
						Nacionalidad
					</td>
					<td colspan="3">
						<asp:TextBox ID="txt_nacionalidad" runat="server" MaxLength="30" Width="230px"></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td>
						Profesión
					</td>
					<td colspan="3">
						<asp:TextBox ID="txt_profesion" runat="server" MaxLength="250" Width="230px"></asp:TextBox>
					</td>
				</tr>
			</table>
		</asp:Panel>
	</ContentTemplate>
	<Triggers>
		<asp:AsyncPostBackTrigger ControlID="txt_rut" EventName="TextChanged" />
		<asp:AsyncPostBackTrigger ControlID="bt_limpia_persona" EventName="Click" />
	</Triggers>
</asp:UpdatePanel>