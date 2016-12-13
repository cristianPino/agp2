<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucVehiculoNew.ascx.cs" Inherits="sistemaAGP.wucVehiculoNew" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:UpdatePanel ID="up_vehiculo" runat="server" UpdateMode="Conditional">
	<ContentTemplate>
		<table class="tabla-titulo">
			<tr>
				<td>
					<asp:Label ID="lbl_titulo" runat="server" Text="" />
				</td>
			</tr>
		</table>
		<table class="tabla-normal">
			<tr>
				<td>
					Patente
				</td>
				<td>
					<asp:TextBox ID="txt_patente" runat="server" Width="50px" MaxLength="6" OnTextChanged="txt_patente_TextChanged" AutoPostBack="true" BackColor="#0099ff" ForeColor="#ffffff"></asp:TextBox><strong>-</strong><asp:TextBox ID="txt_dv" runat="server" MaxLength="1" Enabled="False" Width="15px" CssClass="dv"></asp:TextBox>
					<asp:RegularExpressionValidator ID="rev_patente" runat="server" CssClass="error" Text="*" ErrorMessage="Formato Patente" ControlToValidate="txt_patente" ValidationExpression="^([a-zA-Z])([a-zA-Z])([a-zA-Z]|\d)([a-zA-Z]|\d)(\d)(\d)$" SetFocusOnError="true"></asp:RegularExpressionValidator>
					<asp:Button ID="bt_limpia_vehiculo" runat="server" Text="Limpiar" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;" OnClick="bt_limpia_vehiculo_Click" CausesValidation="false" />
				</td>
				<td>
					Tipo Vehiculo
				</td>
				<td>
					<asp:DropDownList ID="dl_tipo_vehiculo" runat="server" Width="180px">
					</asp:DropDownList>
					<asp:RequiredFieldValidator ID="rfv_tipo_vehiculo" runat="server" CssClass="error" Text="*" ErrorMessage="Tipo Vehículo" ControlToValidate="dl_tipo_vehiculo" InitialValue="0" SetFocusOnError="true"></asp:RequiredFieldValidator>
				</td>
				<td>
					Marca
				</td>
				<td>
					<asp:DropDownList ID="dl_marca_vehiculo" runat="server" Width="180px">
					</asp:DropDownList>
					<asp:RequiredFieldValidator ID="rfv_marca_vehiculo" runat="server" CssClass="error" Text="*" ErrorMessage="Marca Vehículo" ControlToValidate="dl_marca_vehiculo" InitialValue="0" SetFocusOnError="true"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
				<td>
					Modelo
				</td>
				<td>
					<asp:TextBox ID="txt_modelo_vehiculo" runat="server" Width="180px" MaxLength="100"></asp:TextBox>
					<cc1:AutoCompleteExtender ID="ac_modelo_vehiculo" runat="server" Enabled="True" ServicePath="~/servicios_web/wsagp.asmx" MinimumPrefixLength="2" ServiceMethod="getListaModelosVehiculos" EnableCaching="true" TargetControlID="txt_modelo_vehiculo" UseContextKey="True" CompletionSetCount="10" CompletionInterval="200">
					</cc1:AutoCompleteExtender>
					<asp:RequiredFieldValidator ID="rfv_modelo_vehiculo" runat="server" CssClass="error" Text="*" ErrorMessage="Modelo Vehículo" ControlToValidate="txt_modelo_vehiculo" InitialValue="" SetFocusOnError="true"></asp:RequiredFieldValidator>
				</td>
				<td>
					Año
				</td>
				<td>
					<asp:TextBox ID="txt_ano_vehiculo" runat="server" Width="60px" MaxLength="4"></asp:TextBox>
					<cc1:FilteredTextBoxExtender ID="filter_ano_vehiculo" runat="server" TargetControlID="txt_ano_vehiculo" FilterType="Custom, Numbers">
					</cc1:FilteredTextBoxExtender>
					<asp:RequiredFieldValidator ID="rfv_ano_vehiculo" runat="server" CssClass="error" Text="*" ErrorMessage="Año Vehículo" ControlToValidate="txt_ano_vehiculo" InitialValue="" SetFocusOnError="true"></asp:RequiredFieldValidator>
				</td>
				<td>
					Cilindrada
				</td>
				<td>
					<asp:TextBox ID="txt_cilindrada" runat="server" Width="70px" MaxLength="10"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td>
					Nº Puertas
				</td>
				<td>
					<asp:TextBox ID="txt_puertas" runat="server" Width="45px" MaxLength="2"></asp:TextBox>
					<cc1:FilteredTextBoxExtender ID="filter_puertas" runat="server" TargetControlID="txt_puertas" FilterType="Custom, Numbers">
					</cc1:FilteredTextBoxExtender>
				</td>
				<td>
					Nº Asientos
				</td>
				<td>
					<asp:TextBox ID="txt_asientos" runat="server" Width="40px" MaxLength="2"></asp:TextBox>
					<cc1:FilteredTextBoxExtender ID="filer_asientos" runat="server" TargetControlID="txt_asientos" FilterType="Custom, Numbers">
					</cc1:FilteredTextBoxExtender>
				</td>
				<td>
					Peso Bruto
				</td>
				<td>
					<asp:TextBox ID="txt_peso_bruto" runat="server" Width="60px" MaxLength="6"></asp:TextBox>
					<cc1:FilteredTextBoxExtender ID="filter_perso_bruto" runat="server" TargetControlID="txt_peso_bruto" FilterType="Custom, Numbers">
					</cc1:FilteredTextBoxExtender>
				</td>
			</tr>
			<tr>
				<td>
					Peso Carga
				</td>
				<td>
					<asp:TextBox ID="txt_peso_carga" runat="server" Width="56px" MaxLength="6"></asp:TextBox>
					<cc1:FilteredTextBoxExtender ID="filter_peso_carga" runat="server" TargetControlID="txt_peso_carga" FilterType="Custom, Numbers">
					</cc1:FilteredTextBoxExtender>
				</td>
				<td>
					Combustible
				</td>
				<td>
					<asp:DropDownList ID="dl_combustible" runat="server" Width="138px">
					</asp:DropDownList>
				</td>
				<td>
					Color
				</td>
				<td>
					<asp:TextBox ID="txt_color" runat="server" Width="134px" MaxLength="50"></asp:TextBox>
					<cc1:AutoCompleteExtender ID="ac_color" runat="server" Enabled="True" ServicePath="~/servicios_web/wsagp.asmx" MinimumPrefixLength="2" ServiceMethod="getListaColoresVehiculos" EnableCaching="true" TargetControlID="txt_color" UseContextKey="True" CompletionSetCount="10" CompletionInterval="200">
					</cc1:AutoCompleteExtender>
					<asp:RequiredFieldValidator ID="rfv_color" runat="server" CssClass="error" Text="*" ErrorMessage="Color Vehículo" ControlToValidate="txt_color" InitialValue="" SetFocusOnError="true"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
				<td>
					Motor
				</td>
				<td>
					<asp:TextBox ID="txt_motor" runat="server" Width="125px" MaxLength="30"></asp:TextBox>
					<asp:RequiredFieldValidator ID="rfv_motor" runat="server" CssClass="error" Text="*" ErrorMessage="Nro. Motor Vehículo" ControlToValidate="txt_motor" InitialValue="" SetFocusOnError="true"></asp:RequiredFieldValidator>
				</td>
				<td>
					Chasis/VIN
				</td>
				<td>
					<asp:TextBox ID="txt_chasis" runat="server" Width="125px" MaxLength="30"></asp:TextBox>
					<asp:RequiredFieldValidator ID="rfv_chasis" runat="server" CssClass="error" Text="*" ErrorMessage="Nro. Chasis/VIN Vehículo" ControlToValidate="txt_chasis" InitialValue="" SetFocusOnError="true"></asp:RequiredFieldValidator>
				</td>
				<td>
					Serie
				</td>
				<td>
					<asp:TextBox ID="txt_serie" runat="server" Width="120px" MaxLength="30"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td>
					Transmision
				</td>
				<td>
					<asp:DropDownList ID="dl_transmision" runat="server" Width="138px">
					</asp:DropDownList>
				</td>
				<td>
					Equipamiento
				</td>
				<td>
					<asp:DropDownList ID="dl_equipamiento" runat="server" Width="138px">
					</asp:DropDownList>
				</td>
			</tr>
			<tr>
				<td>
					<asp:Label ID="cav" runat="server" Visible="false" Text="CAV"></asp:Label>
				</td>
				<td colspan="2">
					<asp:TextBox ID="txt_PDF" runat="server" AutoPostBack="True" Height="36px" OnTextChanged="txt_PDF_Leave" TextMode="MultiLine" Width="173px" Visible="False"></asp:TextBox>
				</td>
				<td colspan="2">
					<asp:TextBox ID="txt_tipo" runat="server" Width="134px" Visible="False"></asp:TextBox>
				</td>
				<td colspan="2">
					<asp:TextBox ID="txt_marca" runat="server" Width="134px" Visible="False"></asp:TextBox>
				</td>
			</tr>
		</table>
	</ContentTemplate>
	<Triggers>
		<asp:AsyncPostBackTrigger ControlID="bt_limpia_vehiculo" />
		<asp:AsyncPostBackTrigger ControlID="txt_PDF" />
	</Triggers>
</asp:UpdatePanel>