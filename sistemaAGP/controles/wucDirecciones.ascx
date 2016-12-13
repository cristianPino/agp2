<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucDirecciones.ascx.cs" Inherits="sistemaAGP.wucDirecciones" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:UpdatePanel ID="up_control" runat="server">
	<ContentTemplate>
		<asp:Panel ID="pnl_grilla" runat="server">
			<asp:GridView ID="gr_datos" runat="server" AutoGenerateColumns="False" Width="600px" DataKeyNames="id_direccion" EnableModelValidation="True" OnRowDataBound="gr_datos_RowDataBound" OnRowCommand="gr_datos_RowCommand">
				<Columns>
					<asp:BoundField HeaderText="Tipo" DataField="tipo">
						<ItemStyle Width="50px" />
					</asp:BoundField>
					<asp:BoundField HeaderText="Dirección" DataField="direccion" />
					<asp:BoundField HeaderText="Comuna" DataField="comuna">
						<ItemStyle Width="150px" />
					</asp:BoundField>
					<asp:BoundField HeaderText="Ciudad" DataField="ciudad">
						<ItemStyle Width="150px" />
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
			<asp:LinkButton ID="bt_agregar" runat="server" Text="Agregar dirección" CausesValidation="False" OnClick="bt_agregar_Click"></asp:LinkButton>
		</asp:Panel>
		<asp:Panel ID="pnl_nuevo" runat="server">
			<table class="tabla-normal" style="width: 600px;">
				<tr>
					<td style="width: 60px;">
						Tipo
					</td>
					<td>
						<asp:DropDownList ID="dl_tipo_direccion" runat="server" Width="160px">
						</asp:DropDownList>
						<asp:RequiredFieldValidator ID="rfv_tipo_direccion" runat="server" CssClass="error" Text="*" ErrorMessage="Tipo Dirección" ControlToValidate="dl_tipo_direccion" InitialValue="0" SetFocusOnError="true" ValidationGroup="nuevo_dato"></asp:RequiredFieldValidator>
					</td>
					<td>
						<asp:HiddenField ID="hdn_id_direccion" runat="server" />
					</td>
				</tr>
			</table>
			<table class="tabla-normal" style="width: 600px;">
				<tr>
					<td style="width: 60px;">
						Calle
					</td>
					<td>
						<asp:TextBox ID="txt_direccion" runat="server" MaxLength="50" Width="400px"></asp:TextBox>
						<asp:RequiredFieldValidator ID="rfv_direccion" runat="server" CssClass="error" Text="*" ErrorMessage="Dirección" ControlToValidate="txt_direccion" InitialValue="" SetFocusOnError="true" ValidationGroup="nuevo_dato"></asp:RequiredFieldValidator>
					</td>
				</tr>
			</table>
			<table class="tabla-normal" style="width: 600px;">
				<tr>
					<td style="width: 60px;">
						Número
					</td>
					<td>
						<asp:TextBox ID="txt_numero" runat="server" MaxLength="10" Width="80px"></asp:TextBox>
						<asp:RequiredFieldValidator ID="rfv_numero" runat="server" CssClass="error" Text="*" ErrorMessage="Número" ControlToValidate="txt_numero" InitialValue="" SetFocusOnError="true" ValidationGroup="nuevo_dato"></asp:RequiredFieldValidator>
					</td>
					<td style="width: 90px;">
						Complemento
					</td>
					<td>
						<asp:TextBox ID="txt_complemento" runat="server" MaxLength="50" Width="230px"></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td style="width: 60px;">
						Ciudad
					</td>
					<td>
						<asp:DropDownList ID="dl_ciudad" runat="server" Width="180px" OnSelectedIndexChanged="dl_ciudad_SelectedIndexChanged" AutoPostBack="True">
						</asp:DropDownList>
					</td>
					<td style="width: 90px;">
						Comuna
					</td>
					<td>
						<asp:DropDownList ID="dl_comuna" runat="server" Width="180px">
						</asp:DropDownList>
						<asp:RequiredFieldValidator ID="rfv_comuna" runat="server" CssClass="error" Text="*" ErrorMessage="Comuna" ControlToValidate="dl_comuna" InitialValue="0" SetFocusOnError="true" ValidationGroup="nuevo_dato"></asp:RequiredFieldValidator>
					</td>
				</tr>
			</table>
			<table class="tabla-normal" style="width: 600px;">
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