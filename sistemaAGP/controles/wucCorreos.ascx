<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucCorreos.ascx.cs" Inherits="sistemaAGP.wucCorreos" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:UpdatePanel ID="up_control" runat="server">
	<ContentTemplate>
		<asp:Panel ID="pnl_grilla" runat="server">
			<asp:GridView ID="gr_datos" runat="server" AutoGenerateColumns="False" DataKeyNames="id_correo" EnableModelValidation="True" OnRowDataBound="gr_datos_RowDataBound" OnRowCommand="gr_datos_RowCommand">
				<Columns>
					<asp:BoundField HeaderText="Correo electrónico" DataField="correo">
						<ItemStyle Width="250px" />
					</asp:BoundField>
					<asp:TemplateField HeaderText="Prioridad">
						<ItemTemplate>
							<asp:CheckBox ID="chk_prioridad" runat="server" Checked='<%# Bind("prioridad") %>' OnCheckedChanged="chk_prioridad_CheckedChanged" AutoPostBack="true" />
						</ItemTemplate>
						<ItemStyle HorizontalAlign="Center" Width="65px" />
					</asp:TemplateField>
					<asp:ButtonField ButtonType="Image" HeaderText="Editar" ImageUrl="~/imagenes/sistema/static/EditInformationHS.png" ShowHeader="True" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="45px" />
				</Columns>
			</asp:GridView>
			<asp:LinkButton ID="bt_agregar" runat="server" Text="Agregar e-mail" CausesValidation="False" OnClick="bt_agregar_Click"></asp:LinkButton>
		</asp:Panel>
		<asp:Panel ID="pnl_nuevo" runat="server">
			<table class="tabla-normal">
				<tr>
					<td>
						Correo electrónico
					</td>
					<td>
						<asp:TextBox ID="txt_correo" runat="server" MaxLength="50" Width="170px"></asp:TextBox>
						<asp:RequiredFieldValidator ID="rfv_correo" runat="server" CssClass="error" Text="*" ErrorMessage="Correo Electrónico" ControlToValidate="txt_correo" InitialValue="" SetFocusOnError="true" ValidationGroup="nuevo_dato"></asp:RequiredFieldValidator>
						<asp:RegularExpressionValidator ID="rev_correo" runat="server" CssClass="error" Text="*" ErrorMessage="Formato Correo" ControlToValidate="txt_correo" ValidationExpression="^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,3})$" SetFocusOnError="true" ValidationGroup="nuevo_dato"></asp:RegularExpressionValidator>
					</td>
					<td>
						<asp:HiddenField ID="hdn_id_correo" runat="server" />
					</td>
				</tr>
			</table>
			<table class="tabla-normal" style="width: 300px;">
				<tr>
					<td style="text-align: center; width: 50%;">
						<asp:Button ID="bt_guardar" runat="server" CausesValidation="true" Text="Guardar" OnClick="bt_guardar_Click" ValidationGroup="nuevo_dato"></asp:Button>
						<ajaxToolkit:ConfirmButtonExtender ID="cb_guardar" runat="server" ConfirmText="¿Está seguro de guardar los datos?" TargetControlID="bt_guardar">
						</ajaxToolkit:ConfirmButtonExtender>
					</td>
					<td style="text-align: center; width: 50%;">
						<asp:Button ID="bt_cancelar" runat="server" CausesValidation="false" Text="Cancelar" OnClick="bt_cancelar_Click"></asp:Button>
						<ajaxToolkit:ConfirmButtonExtender ID="cb_cancelar" runat="server" ConfirmText="Si acepta perderá los datos ingresados. ¿Desea continuar?" TargetControlID="bt_cancelar">
						</ajaxToolkit:ConfirmButtonExtender>
					</td>
				</tr>
			</table>
			<asp:ValidationSummary ID="vs_datos" runat="server" DisplayMode="BulletList" ShowMessageBox="true" ShowSummary="false" HeaderText="Debe verificar los siguientes campos antes de continuar" ValidationGroup="nuevo_dato" />
		</asp:Panel>
	</ContentTemplate>
	<Triggers>
		<asp:AsyncPostBackTrigger ControlID="bt_agregar" EventName="Click" />
		<asp:AsyncPostBackTrigger ControlID="bt_guardar" EventName="Click" />
		<asp:AsyncPostBackTrigger ControlID="bt_cancelar" EventName="Click" />
	</Triggers>
</asp:UpdatePanel>