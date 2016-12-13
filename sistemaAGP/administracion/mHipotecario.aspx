<%@ Page Title="Ingreso Solicitud de Hipotecario" Language="C#" MasterPageFile="~/Adm.Master"
	AutoEventWireup="true" CodeBehind="mHipotecario.aspx.cs" Inherits="sistemaAGP.mHipotecario" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register Src="~/controles/wucPersona.ascx" TagName="DatosPersona" TagPrefix="agp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    &nbsp;<style type="text/css">
        .modalBackground
        {
            background-color: Gray;
            filter: alpha(opacity=70);
            opacity: 0.7;
        }
        .PopUp
        {
            background-color: #C0C4CC;
            border-width: 1px;
            border-color: #606060;
            border-style: solid;
            padding: 20px;
        }
    		  .style4
			  {
				  width: 95px;
			  }
    		  .style6
			  {
				  width: 27px;
			  }
			  .style7
			  {
				  width: 61px;
			  }
    		  .style8
			  {
				  font-size: x-small;
				  font-family: Arial, Helvetica, sans-serif;
			  }
    </style><table bgcolor="#E5E5E5">
		<tr>
			<td style="width: 789px; height: 20px" valign="top">
				<table bgcolor="#669999" style="width: 100%">
					<tr>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 1115px;
							color: #FFFFFF;">
							<b>CARGO OPERACION --<asp:Label ID="lbl_titulo" runat="server" Text=""></asp:Label></b>
						</td>
					</tr>
				</table>
				<table>
					<tr>
						<td>
							&nbsp;</td>
						<td>
							&nbsp;</td>
						<td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
							Sucursal Origen
						</td>
						<td>
							<asp:DropDownList ID="dl_sucursal_origen" runat="server" Font-Names="Arial" Font-Size="X-Small"
								Height="16px" Width="138px" TabIndex="17" Style="font-family: Arial, Helvetica, sans-serif;
								font-size: x-small" OnSelectedIndexChanged="dl_sucursal_origen_SelectedIndexChanged">
							</asp:DropDownList>
						</td>
					</tr>
				</table>
				<agp:DatosPersona ID="Datosvendedor" runat="server" Titulo="DATOS DEL VENDEDOR" HabilitarCompraPara="false" />
			
				<agp:DatosPersona ID="Datoscomprador" runat="server" Titulo="DATOS DEL COMPRADOR"
					HabilitarCompraPara="true" HabilitarParticipante="true" />
				<agp:DatosPersona ID="agpCompraPara" runat="server" Titulo="DATOS COMPRA PARA" HabilitarCompraPara="false"
					Visible="false" HabilitarParticipante="true" />
				<table bgcolor="#669999" style="width: 100%">
					<tr>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 1115px;
							color: #FFFFFF;">
							<b>DATOS PROPIEDAD</b>
						</td>
					</tr>
				</table>
				<asp:Panel ID="id_datounico" runat="server">
					<table>
						<tr>
							<td style="width: 56px;">
								<span class="style8">Pais</span>
							</td>
							<td style="width: 126px; text-align: left">
								<asp:DropDownList ID="dl_pais" runat="server" AutoPostBack="True" Font-Names="Arial"
									Font-Size="X-Small" Height="16px" OnSelectedIndexChanged="dl_pais_SelectedIndexChanged"
									Width="138px" TabIndex="1">
								</asp:DropDownList>
							</td>
							<td style="width: 15px; text-align: right">
								<span class="style8">Region</span>
							</td>
							<td style="text-align: left;">
								<asp:DropDownList ID="dl_region" runat="server" AutoPostBack="True" Font-Names="Arial"
									Font-Size="X-Small" Height="19px" OnSelectedIndexChanged="dl_region_SelectedIndexChanged"
									Width="213px" TabIndex="2">
								</asp:DropDownList>
							</td>
						</tr>
						<tr>
							<td style="width: 15px;">
								<span class="style8">Ciudad</span>
							</td>
							<td style="text-align: left;">
								<asp:DropDownList ID="dl_ciudad" runat="server" AutoPostBack="True" Font-Names="Arial"
									Font-Size="X-Small" Height="19px" Width="173px" OnSelectedIndexChanged="dl_ciudad_SelectedIndexChanged"
									TabIndex="3">
								</asp:DropDownList>
							</td>
							<td style="width: 15px; text-align: right">
								<span class="style8">Comuna</span>
							</td>
							<td style="text-align: left;">
								<asp:DropDownList ID="dl_comuna" runat="server" Font-Names="Arial" Font-Size="X-Small"
									Height="19px" Width="213px" TabIndex="4">
								</asp:DropDownList>
							</td>
						</tr>
					</table>
						<table>
						<tr>
							<td style="font-size: x-small; font-family: Arial, Helvetica, sans-serif">
								Direccion
							</td>
							<td>
								<asp:TextBox ID="txt_direccion" runat="server" MaxLength="50" Style="font-size: x-small;
									font-family: Arial, Helvetica, sans-serif" Width="116px" OnTextChanged="txt_direccion_TextChanged" 
									TabIndex="5"></asp:TextBox>
							</td>
							
							<td style="width: 15px; text-align: right">
								<span class="style8">Banco Alzante</span>
							</td>
							<td style="text-align: left;">
								<asp:DropDownList ID="dl_banco" runat="server" Font-Names="Arial" Font-Size="X-Small"
									Height="19px" Width="213px" TabIndex="6" onselectedindexchanged="dl_banco_SelectedIndexChanged">
								</asp:DropDownList>
							</td>
							<td style="font-size: x-small; font-family: Arial, Helvetica, sans-serif">
								ROL</td>
							<td>
								<asp:TextBox ID="txt_rol" runat="server" MaxLength="50" Style="font-size: x-small;
									font-family: Arial, Helvetica, sans-serif" OnTextChanged="txt_rol_TextChanged" TabIndex="7"></asp:TextBox>
								<%--<cc1:FilteredTextBoxExtender ID="txt_precioFilteredTextBoxExtender1" runat="server"
								TargetControlID="txt_precio" FilterType="Custom, Numbers" ValidChars=".">
							</cc1:FilteredTextBoxExtender>--%>
							</td>
							
						</tr>
					</table>
						<table>
				
							
				
						<tr>
							<td style="font-size: x-small; font-family: Arial, Helvetica, sans-serif">
								Tasacion($)
							</td>
							<td>
								<asp:TextBox ID="txt_tasacion" runat="server" Style="font-family: Arial, Helvetica, sans-serif;
									font-size: x-small" OnTextChanged="txt_tasacion_TextChanged" Width="109px" AutoPostBack="True" 
									TabIndex="8"></asp:TextBox>
								<%--<cc1:FilteredTextBoxExtender ID="txt_tasacionFilteredTextBoxExtender1" runat="server"
								TargetControlID="txt_tasacion" FilterType="Custom, Numbers" ValidChars="">
							</cc1:FilteredTextBoxExtender>--%>
							</td>
							<td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;"
								class="style30">
								Fecha Subsidio
							</td>
							<td>
								<asp:TextBox ID="txt_fecha_subsidio" runat="server" Style="font-family: Arial, Helvetica, sans-serif;
									font-size: x-small" Height="19px" Width="73px" TabIndex="9" 
									OnTextChanged="txt_fecha_subsidio_TextChanged"></asp:TextBox>
								<cc1:CalendarExtender runat="server" TargetControlID="txt_fecha_subsidio" CssClass="calendario"
									Format="dd/MM/yyyy" PopupButtonID="ib_calendario" ID="CalendarExtender2" />
							</td>
							<td class="style6">
								<asp:ImageButton ID="ib_calendario" runat="server" ImageUrl="../imagenes/sistema/gif/calendario.gif"
									OnClick="ib_calendario_Click" />
							</td>
							<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;" 
								class="style7">
								estado inmueble
							</td>
							<td>
								<asp:DropDownList ID="dl_estado_inmueble" runat="server" Font-Names="Arial" Font-Size="X-Small"
									Height="16px" Width="138px" TabIndex="10" Style="font-family: Arial, Helvetica, sans-serif;
									font-size: x-small" OnSelectedIndexChanged="dl_estado_inmueble_SelectedIndexChanged">
								</asp:DropDownList>
							</td>
							<td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
								Tipo inmueble
							</td>
							<td>
								<asp:DropDownList ID="dl_tipo_inmueble" runat="server" Font-Names="Arial" Font-Size="X-Small"
									Height="16px" Width="138px" TabIndex="11" Style="font-family: Arial, Helvetica, sans-serif;
									font-size: x-small" OnSelectedIndexChanged="dl_tipo_inmueble_SelectedIndexChanged">
								</asp:DropDownList>
							</td>
						</tr>
					</table>
					<table bgcolor="#669999" style="width: 100%">
						<tr>
							<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 1115px;
								color: #FFFFFF;">
								<b>DATOS CREDITO</b>
							</td>
						</tr>
					</table>
					<table >
						<tr>
							<td style="font-size: x-small; font-family: Arial, Helvetica, sans-serif" 
								class="style4">
								Monto Credito(UF)</td>
							<td>
								<asp:TextBox ID="txt_monto" runat="server" MaxLength="15" Style="font-size: x-small;
									font-family: Arial, Helvetica, sans-serif" Width="65px" OnTextChanged="txt_monto_TextChanged" 
									AutoPostBack="True" TabIndex="12"></asp:TextBox>
								<%--<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txt_monto"
									FilterType="Custom, Numbers" ValidChars="">
								</cc1:FilteredTextBoxExtender>--%>
							</td>
							
							<td style="font-size: x-small; font-family: Arial, Helvetica, sans-serif">
								Tasa
							</td>
							<td>
								<asp:TextBox ID="txt_tasa" runat="server" MaxLength="20" Style="font-size: x-small;
									font-family: Arial, Helvetica, sans-serif" Width="65px" OnTextChanged="txt_tasa_TextChanged" 
									TabIndex="13"></asp:TextBox>
								<%--<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txt_valor_opcion"
									FilterType="Custom, Numbers" ValidChars="">
								</cc1:FilteredTextBoxExtender>--%>
							</td>
							<td style="font-size: x-small; font-family: Arial, Helvetica, sans-serif">
								Plazo(Meses)
							</td>
							<td>
								<asp:TextBox ID="txt_plazo" runat="server" MaxLength="9" Style="font-size: x-small;
									font-family: Arial, Helvetica, sans-serif" OnTextChanged="txt_plazo_TextChanged" TabIndex="14"></asp:TextBox>
								<%--<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txt_valor_cesion"
									FilterType="Custom, Numbers" ValidChars="">
								</cc1:FilteredTextBoxExtender>--%>
							</td>
							<td style="font-size: x-small; font-family: Arial, Helvetica, sans-serif">
								NºOperacion
							</td>
							<td>
								<asp:TextBox ID="txt_n_operacion" runat="server" MaxLength="10" Style="font-size: x-small;
									font-family: Arial, Helvetica, sans-serif" Width="86px" OnTextChanged="txt_n_operacion_TextChanged"
									TabIndex="15"></asp:TextBox>
							</td>
						</tr>
					</table>
				</asp:Panel>
				<table>
					<tr>
						<td>
							<asp:Button ID="bt_guardar" runat="server" Style="font-family: Arial, Helvetica, sans-serif;
								font-size: x-small" Text="Guardar" OnClick="bt_guardar_Click" />
							<cc1:ConfirmButtonExtender ID="bt_guardar_ConfirmButtonExtender" runat="server" TargetControlID="bt_guardar"
								ConfirmText="¿Esta seguro de ingresar un nueva Operacion de Hipotecaria?">
							</cc1:ConfirmButtonExtender>
						</td>
						<td>
							<asp:Button ID="Button1" runat="server" Style="font-family: Arial, Helvetica, sans-serif;
								font-size: x-small" Text="Limpiar" Height="21px" Width="58px" />
						</td>
						<td>
							<asp:Button ID="Button2" runat="server" Style="font-family: Arial, Helvetica, sans-serif;
								font-size: x-small" Text="Cerrar" Height="21px" Width="58px" OnClick="Button2_Click" />
						</td>
						<td style="width: 721px; text-align: right">
							<asp:Label ID="lbl_operacion" runat="server" Font-Names="Arial" Font-Size="Small"
								ForeColor="#FF3300" Visible="False"></asp:Label>
							<asp:Label ID="lbl_numero" runat="server" Font-Names="Arial" Font-Size="Small" ForeColor="#FF3300"
								Visible="False"></asp:Label>
						</td>
					</tr>
				</table>
			</td>
		</tr>
	</table>
	
	</asp:Content>

