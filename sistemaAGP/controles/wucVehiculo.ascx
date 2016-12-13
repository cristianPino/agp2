<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucVehiculo.ascx.cs" Inherits="sistemaAGP.wucVehiculo" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<table style="background-color: #669999; width: 100%">
	<tr>
		<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 1115px; color: #ffffff;">
			<strong>
				<asp:Label ID="lbl_titulo" runat="server" Text="" /></strong>
		</td>
	</tr>
</table>
<table>
	<tr>
		<td style="width: 45px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
			Patente
		</td>
		<td style="width: 76px;">
			<asp:TextBox ID="txt_patente" runat="server" Width="76px" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; background-color: #0099ff; color: #ffffff;" MaxLength="6" ontextchanged="txt_patente_TextChanged" AutoPostBack="true"></asp:TextBox>
		</td>
		<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 10px; padding: 0 2px 0 2px; text-align: center;">
			<strong>-</strong>
		</td>
		<td style="width: 20px;">
			<asp:TextBox ID="txt_dv" runat="server" MaxLength="1" Enabled="False" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 20px; height: 16px;"></asp:TextBox>
		</td>
		<td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small; padding-left: 4px;">
			Tipo Vehiculo
		</td>
		<td>
			<asp:DropDownList ID="dl_tipo_vehiculo" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="138px" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small">
			</asp:DropDownList>
		</td>
		<td style="width: 43px; font-family: Arial, Helvetica, sans-serif; font-size: x-small; padding-left: 4px;">
			Marca
		</td>
		<td>
			<asp:DropDownList ID="dl_marca_vehiculo" runat="server" Font-Names="Arial" AutoPostBack="true" 
				Font-Size="X-Small" Height="16px" Width="168px" 
				Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" 
				onselectedindexchanged="dl_marca_vehiculo_SelectedIndexChanged">
			</asp:DropDownList>
		</td>
		<td style="width: 43px; font-family: Arial, Helvetica, sans-serif; font-size: x-small; padding-left: 4px;">
			Modelo
		</td>
		<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small">
			<%--<asp:DropDownList ID="dl_modelo" runat="server" Font-Names="Arial" Font-Size="X-Small" AutoPostBack="true"
				Height="16px" Width="168px" Style="font-family: Arial, Helvetica, sans-serif;
				font-size: x-small" onselectedindexchanged="dl_modelo_SelectedIndexChanged">
			</asp:DropDownList>--%>
			<asp:TextBox ID="txt_modelo" runat="server" Style="font-family: Arial, Helvetica, sans-serif;
				font-size: x-small; width: 120px; height: 16px;" MaxLength="40" Visible="true"></asp:TextBox>
			<%--<cc1:AutoCompleteExtender ID="ac_modelo_vehiculo" runat="server" Enabled="True" ServicePath="~/servicios_web/wsagp.asmx" MinimumPrefixLength="2" ServiceMethod="getListaModelosVehiculos" EnableCaching="true" TargetControlID="txt_modelo_vehiculo" UseContextKey="True" CompletionSetCount="10" CompletionInterval="200">
			</cc1:AutoCompleteExtender>--%>
		</td>
		<td style="width: 43px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;
			padding-left: 4px;">
			Impuesto
		</td>
		<td>
			<asp:TextBox ID="txt_impuesto" runat="server" Style="font-family: Arial, Helvetica, sans-serif;
				font-size: x-small; width: 120px; height: 16px;" MaxLength="30" Visible="False"></asp:TextBox>
		</td>
	</tr>
</table>
<table>
	<tr>
		<td style="width: 43px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
			Año
		</td>
		<td>
			<asp:TextBox ID="txt_ano_vehiculo" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 16px; width: 56px;" MaxLength="4" ></asp:TextBox>
			<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txt_ano_vehiculo" FilterType="Custom, Numbers" ValidChars="">
			</cc1:FilteredTextBoxExtender>
		</td>
		<td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small; padding-left: 4px;">
			Cilindrada
		</td>
		<td>
			<asp:TextBox ID="txt_cilindrada" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 16px; width: 67px;" MaxLength="10" ></asp:TextBox>
		</td>
		<td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small; padding-left: 4px;">
			Nº Puertas
		</td>
		<td>
			<asp:TextBox ID="txt_puertas" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 16px; width: 43px;" MaxLength="2"></asp:TextBox>
			<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txt_puertas" FilterType="Custom, Numbers" ValidChars="">
			</cc1:FilteredTextBoxExtender>
		</td>
		<td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small; padding-left: 4px;">
			Nº Asientos
		</td>
		<td>
			<asp:TextBox ID="txt_asientos" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 39px; height: 19px;" MaxLength="2"></asp:TextBox>
			<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="txt_asientos" FilterType="Custom, Numbers" ValidChars="">
			</cc1:FilteredTextBoxExtender>
		</td>
		<td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small; padding-left: 4px;">
			Peso Bruto
		</td>
		<td>
			<asp:TextBox ID="txt_peso_bruto" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 56px; height: 16px;" MaxLength="6"></asp:TextBox>
			<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" TargetControlID="txt_peso_bruto" FilterType="Custom, Numbers" ValidChars="">
			</cc1:FilteredTextBoxExtender>
		</td>
		<td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small; padding-left: 4px;">
			Peso Carga
		</td>
		<td>
			<asp:TextBox ID="txt_peso_carga" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 56px; height: 16px;" MaxLength="6"></asp:TextBox>
			<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" TargetControlID="txt_peso_carga" FilterType="Custom, Numbers" ValidChars="">
			</cc1:FilteredTextBoxExtender>
		</td>
	</tr>
</table>
<table>
	<tr>
		<td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
			Combustible
		</td>
		<td>
			<asp:DropDownList ID="dl_combustible" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 138px; height: 16px;">
			</asp:DropDownList>
		</td>
		<td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small; padding-left: 4px;">
			Color
		</td>
		<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small">
			<asp:TextBox ID="txt_color" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 134px; height: 16px;" MaxLength="50" ></asp:TextBox>
			<cc1:AutoCompleteExtender ID="ac_color" runat="server" Enabled="True" ServicePath="~/servicios_web/wsagp.asmx" MinimumPrefixLength="2" ServiceMethod="getListaColoresVehiculos" EnableCaching="true" TargetControlID="txt_color" UseContextKey="True" CompletionSetCount="10" CompletionInterval="200">
			</cc1:AutoCompleteExtender>
		</td>
		<td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small; padding-left: 4px;">
			Motor
		</td>
		<td>
			<asp:TextBox ID="txt_motor" runat="server" 
				Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 125px; height: 16px;" 
				MaxLength="30" ontextchanged="txt_motor_TextChanged" ></asp:TextBox>
		</td>
		<td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small; padding-left: 4px;">
			Chasis
		</td>
		<td>
			<asp:TextBox ID="txt_chasis" runat="server" 
				Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 125px; height: 16px;" 
				MaxLength="30"  ></asp:TextBox>
		</td>
	</tr>
</table>
<table>
	<tr>
		<td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
			VIN
		</td>
		<td>
			<asp:TextBox ID="txt_vin" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 120px; height: 16px;" MaxLength="30" ></asp:TextBox>
		</td>
		<td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small; padding-left: 4px;">
			Serie
		</td>
		<td>
			<asp:TextBox ID="txt_serie" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 120px; height: 16px;" MaxLength="30" ></asp:TextBox>
		</td>
		<td>
			<asp:textbox id="txt_marca" runat="server" style="font-family: Arial, Helvetica, sans-serif;
				font-size: x-small; width: 120px; height: 16px;" maxlength="30" Visible="False"></asp:textbox>
		</td>
		<td>
			<asp:textbox id="txt_tipo" runat="server" style="font-family: Arial, Helvetica, sans-serif;
				font-size: x-small; width: 120px; height: 16px;" maxlength="30" Visible="False"></asp:textbox>
		</td>
		
	</tr>
	<tr>
		<td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
		<asp:Label ID="cav" runat="server" Visible="false" Text="CAV"></asp:Label>
		</td>
	<td>
		<asp:TextBox ID="txt_PDF" runat="server" AutoPostBack="True" Height="36px" OnTextChanged="txt_PDF_Leave"
			TextMode="MultiLine" Width="173px" Visible="False"></asp:TextBox>
	</td>
		<td style="width: 43px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;
			padding-left: 4px;">
			Transmision
		</td>
		<td>
			<asp:dropdownlist id="dl_Transmision_vehiculo" runat="server" font-names="Arial" font-size="X-Small"
				height="16px" width="168px" style="font-family: Arial, Helvetica, sans-serif;
				font-size: x-small">
			</asp:dropdownlist>
		</td>
		<td style="width: 43px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;
			padding-left: 4px;">
			Equipamiento
		</td>
		<td>
			<asp:dropdownlist id="dl_Equipamiento_vehiculo" runat="server" font-names="Arial"
				font-size="X-Small" height="16px" width="168px" style="font-family: Arial, Helvetica, sans-serif;
				font-size: x-small">
			</asp:dropdownlist>
		</td>
	</tr>
</table>