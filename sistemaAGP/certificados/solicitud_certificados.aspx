<%@ Page Title="" Language="C#" MasterPageFile="~/Modal.Master" AutoEventWireup="true" CodeBehind="solicitud_certificados.aspx.cs" Inherits="sistemaAGP.certificados.solicitud_certificados" Culture="es-CL" UICulture="es-CL" Theme="SkinAdm" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="head_content" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="body_content" ContentPlaceHolderID="body" runat="server">
	<asp:UpdatePanel ID="up_operacion" runat="server" UpdateMode="Conditional">
		<ContentTemplate>
			<div style="width: 100%;">
				<table class="tabla-titulo">
					<tr>
						<td>
							SOLICITUD DE CERTIFICADO -
							<asp:Label ID="lbl_titulo" runat="server" Text=""></asp:Label>
						</td>
					</tr>
				</table>
				<div style="width: 600px; margin: 0 auto 0 auto;">
					<table class="tabla-normal">
						<tr>
							<td colspan="4" style="text-align: right;">
								<asp:Label ID="lbl_operacion" runat="server" ForeColor="#FF3300" Visible="False" Text="Operación Nº: "></asp:Label>
								<asp:Label ID="lbl_numero" runat="server" ForeColor="#FF3300" Visible="False"></asp:Label>
							</td>
						</tr>
						<tr>
							<td>
								Cliente
							</td>
							<td>
								<asp:DropDownList ID="dl_cliente" runat="server" Enabled="false" Width="200px">
								</asp:DropDownList>
							</td>
							<td>
								Sucursal
							</td>
							<td>
								<asp:DropDownList ID="dl_sucursal" runat="server" Width="200px">
								</asp:DropDownList>
								<asp:RequiredFieldValidator ID="rfv_sucursal" runat="server" CssClass="error" Text="*" ErrorMessage="Sucursal" ControlToValidate="dl_sucursal" InitialValue="0"></asp:RequiredFieldValidator>
							</td>
						</tr>
						<tr>
							<td>
								Patente
							</td>
							<td style="vertical-align: middle;">
								<asp:TextBox ID="txt_patente" runat="server" Width="70px" AutoPostBack="true" OnTextChanged="txt_patente_TextChanged"></asp:TextBox><strong>-</strong><asp:TextBox ID="txt_dv" runat="server" Width="10px" Enabled="false"></asp:TextBox>
								<asp:RegularExpressionValidator ID="rev_patente" runat="server" CssClass="error" Text="*" ErrorMessage="Formato Patente" ControlToValidate="txt_patente" ValidationExpression="^([a-zA-Z])([a-zA-Z])([a-zA-Z]|\d)([a-zA-Z]|\d)(\d)(\d)$" SetFocusOnError="true"></asp:RegularExpressionValidator>
							</td>
						</tr>
					</table>
				</div>
				<div style="width: 500px; margin: 0 auto 0 auto;">
					<table class="tabla-normal">
						<tr>
							<td style="width: 250px; text-align: center;">
								<asp:Button ID="bt_guardar" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: small; width: 90px;" Text="Guardar" OnClick="bt_guardar_Click" CausesValidation="true" />
								<asp:ValidationSummary ID="vs_garantia" runat="server" DisplayMode="BulletList" ShowMessageBox="true" ShowSummary="false" HeaderText="Debe verificar los siguientes campos antes de continuar" />
								<ajaxToolkit:ConfirmButtonExtender ID="cbe_guardar" runat="server" ConfirmText="¿Está seguro de guardar la operación?" TargetControlID="bt_guardar">
								</ajaxToolkit:ConfirmButtonExtender>
							</td>
							<td style="width: 250px; text-align: center;">
								<asp:Button ID="bt_limpiar" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: small; width: 90px;" Text="Limpiar" OnClick="bt_limpiar_Click" CausesValidation="false" />
								<ajaxToolkit:ConfirmButtonExtender ID="cbe_limpiar" runat="server" ConfirmText="Si limpia el formualrio perderá los cambios realizados. ¿Está seguro de continuar?" TargetControlID="bt_limpiar">
								</ajaxToolkit:ConfirmButtonExtender>
							</td>
						</tr>
					</table>
				</div>
			</div>
		</ContentTemplate>
		<Triggers>
			<asp:AsyncPostBackTrigger ControlID="bt_guardar" EventName="Click" />
			<asp:AsyncPostBackTrigger ControlID="bt_limpiar" EventName="Click" />
		</Triggers>
	</asp:UpdatePanel>
</asp:Content>