<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucTelefonos.ascx.cs" Inherits="sistemaAGP.wucTelefonos" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:UpdatePanel ID="up_control" runat="server">
	<ContentTemplate>
		<asp:Panel ID="pnl_grilla" runat="server">
			<asp:GridView ID="gr_datos" runat="server" AutoGenerateColumns="False" DataKeyNames="id_telefono" EnableModelValidation="True" OnRowDataBound="gr_datos_RowDataBound" OnRowCommand="gr_datos_RowCommand">
				<Columns>
					<asp:BoundField HeaderText="Tipo" DataField="tipo">
						<ItemStyle Width="50px" />
					</asp:BoundField>
					<asp:BoundField HeaderText="Teléfono" DataField="numero">
						<ItemStyle Width="100px" />
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
			<asp:LinkButton ID="bt_agregar" runat="server" Text="Agregar Teléfono" CausesValidation="False" OnClick="bt_agregar_Click"></asp:LinkButton>
		</asp:Panel>
		<asp:Panel ID="pnl_nuevo" runat="server">
			<table class="tabla-normal">
				<tr>
					<td>
						Tipo
					</td>
					<td>
						<asp:DropDownList ID="dl_tipo_telefono" runat="server" Width="160px">
						</asp:DropDownList>
						<asp:RequiredFieldValidator ID="rfv_tipo_telefono" runat="server" CssClass="error" Text="*" ErrorMessage="Tipo Teléfono" ControlToValidate="dl_tipo_telefono" InitialValue="0" SetFocusOnError="true" ValidationGroup="nuevo_dato"></asp:RequiredFieldValidator>
					</td>
					<td>
						Teléfono
					</td>
					<td>
						<asp:TextBox ID="txt_numero" runat="server" MaxLength="10" Width="70px"></asp:TextBox>
						<asp:RequiredFieldValidator ID="rfv_numero" runat="server" CssClass="error" Text="*" ErrorMessage="Número Teléfono" ControlToValidate="txt_numero" InitialValue="" SetFocusOnError="true" ValidationGroup="nuevo_dato"></asp:RequiredFieldValidator>
					</td>
					<td>
						<asp:HiddenField ID="hdn_id_telefono" runat="server" />
					</td>
				</tr>
			</table>
			<table class="tabla-normal" style="width: 350px;">
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
			<asp:ValidationSummary ID="vs_datos" runat="server" DisplayMode="BulletList" ShowMessageBox="true" ShowSummary="false" HeaderText="Debe verificar los siguientes campos antes de continuar" />
		</asp:Panel>
	</ContentTemplate>
	<Triggers>
		<asp:AsyncPostBackTrigger ControlID="bt_agregar" EventName="Click" />
		<asp:AsyncPostBackTrigger ControlID="bt_guardar" EventName="Click" />
		<asp:AsyncPostBackTrigger ControlID="bt_cancelar" EventName="Click" />
	</Triggers>
</asp:UpdatePanel>