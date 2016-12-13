<%@ Page Title="" Language="C#" MasterPageFile="~/Adm.Master" AutoEventWireup="true" CodeBehind="ingreso_inmatriculacion.aspx.cs" Inherits="sistemaAGP.inmatriculacion.ingreso_inmatriculacion" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div style="width: 789px;">
		<table style="background-color: #669999; width: 100%">
			<tr>
				<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 1115px; color: #FFFFFF;">
					<strong>INGRESO DE VEHICULOS MOTORIZADOS -
						<asp:Label ID="lbl_titulo" runat="server" Text=""></asp:Label></strong>
				</td>
			</tr>
		</table>
		<table>
			<tr>
				<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 70px;">
					Cliente
				</td>
				<td>
					<asp:DropDownList ID="ddlCliente" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="138px" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" AutoPostBack="True">
					</asp:DropDownList>
				</td>
			</tr>
		</table>
		<table style="background-color: #669999; width: 100%">
			<tr>
				<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 1115px; color: #FFFFFF;">
					<strong>DATOS DEL NEGOCIO</strong>
				</td>
			</tr>
		</table>
		<table>
			<tr>
				<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
					Sucursal
				</td>
				<td>
					<asp:DropDownList ID="ddlSucursal" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="138px" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small">
					</asp:DropDownList>
				</td>
				<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
					Nro. Nota Pedido
				</td>
				<td>
					<asp:TextBox ID="txtNotaPedido" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="100px" MaxLength="50" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" ontextchanged="txtNotaPedido_TextChanged" AutoPostBack="true"></asp:TextBox>
				</td>
				
				<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
					<asp:Label ID="lbl_vendedor" runat="server" Text="Vendedor" Visible="false"></asp:Label>
				</td>
				<td>
					<asp:TextBox ID="txt_vendedor" runat="server" Font-Names="Arial" Font-Size="X-Small"
						Height="16px" Width="151px" MaxLength="50" Style="font-family: Arial, Helvetica, sans-serif;
						font-size: x-small" OnTextChanged="txtvendedor_TextChanged" AutoPostBack="false" 
						Visible="false"></asp:TextBox>
				</td>
				<td colspan="2">
					&nbsp;
				</td>
			</tr>
			<tr>
				<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
					Nro. Documento Venta
				</td>
				<td>
					<asp:TextBox ID="txtNroDocVenta" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="65px" MaxLength="50" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"></asp:TextBox>
				</td>
				<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
					Fecha Documento Venta
				</td>
				<td>
					<asp:TextBox ID="txtFechaDocVenta" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="65px" MaxLength="50" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"></asp:TextBox>
					<asp:ImageButton ID="ib_calendario" runat="server" ImageUrl="../imagenes/sistema/gif/calendario.gif" />
					<cc1:CalendarExtender ID="calFechaNotaPedido" runat="server" TargetControlID="txtFechaDocVenta" PopupButtonID="ib_calendario" />
				</td>
				<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
					Monto Total Vehículo
				</td>
				<td>
					<asp:TextBox ID="txtMontoTotalVeh" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="80px" MaxLength="50" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
					Moneda
				</td>
				<td>
					<asp:DropDownList ID="ddlMoneda" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="138px" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small">
					</asp:DropDownList>
				</td>
				<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
					Forma de Pago
				</td>
				<td>
					<asp:DropDownList ID="ddlFormaPago" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="138px" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small">
					</asp:DropDownList>
				</td>
				<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
					Entidad Financiera
				</td>
				<td>
					<asp:DropDownList ID="ddlFinanciera" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="138px" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small">
					</asp:DropDownList>
				</td>
			</tr>
			<tr>
				<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;" class="style2">
					Cargo Venta
				</td>
				<td>
					<asp:DropDownList ID="ddlCargoVenta" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="138px" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small">
					</asp:DropDownList>
				</td>
				<td>
					
					<asp:CheckBox ID="chk_dua" runat="server" Text="Tiene DUA" Font-Names="Arial" 
						Font-Size="X-Small" oncheckedchanged="chk_dua_CheckedChanged" Visible="false" />
				</td>
			</tr>
		</table>
		<table style="background-color: #669999; width: 100%">
			<tr>
				<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 1115px; color: #FFFFFF;">
					<strong>DATOS DEL ADQUIRENTE</strong>
				</td>
			</tr>
		</table>
		<table>
			<tr>
				<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
					Tipo de Persona
				</td>
				<td>
					<asp:RadioButtonList ID="lstTipoPersona" runat="server" AutoPostBack="true" RepeatColumns="2" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="138px" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" OnSelectedIndexChanged="lstTipoPersona_SelectedIndexChanged">
						<asp:ListItem Value="1" Selected="True">Natural</asp:ListItem>
						<asp:ListItem Value="2">Jurídica</asp:ListItem>
					</asp:RadioButtonList>
				</td>
			</tr>
		</table>
		<asp:Panel ID="pnlPersonaNatural" runat="server" Visible="true">
			<table>
				<tr>
					<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 70px;">
						Documento de Identidad
					</td>
					<td>
						<asp:DropDownList ID="ddlTipoDocNat" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="138px" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" AutoPostBack="True" onselectedindexchanged="ddlTipoDocNat_SelectedIndexChanged">
						</asp:DropDownList>
					</td>
					<td colspan="2">
						<asp:TextBox ID="txtNroDocNat" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="150px" MaxLength="20" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" OnTextChanged="txtNroDocNat_TextChanged" AutoPostBack="true"></asp:TextBox>
					</td>
					<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 70px;">
						Estado Civil
						
					</td>
					<td>
						<asp:DropDownList ID="ddlEstadoCivilNat" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="138px" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" AutoPostBack="True" OnSelectedIndexChanged="ddlEstadoCivil_SelectedIndexChanged">
						</asp:DropDownList>
					</td>
					<td>
						
						<asp:CheckBox ID="chk_bienes" runat="server" Text="Separacion de bienes" 
							Font-Names="Arial" Font-Size="X-Small" AutoPostBack="True" 
							oncheckedchanged="chk_bienes_CheckedChanged" Visible="False" />
							</td>
				</tr>
				<tr>
					<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 70px;">
						Nombre(s)
					</td>
					<td>
						<asp:TextBox ID="txtNombreNat" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="150px" MaxLength="50" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"></asp:TextBox>
					</td>
					<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 70px;">
						Apellido Paterno
					</td>
					<td>
						<asp:TextBox ID="txtPaternoNat" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="150px" MaxLength="50" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"></asp:TextBox>
					</td>
					<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 70px;">
						Apellido Materno
					</td>
					<td>
						<asp:TextBox ID="txtMaternoNat" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="150px" MaxLength="50" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"></asp:TextBox>
					</td>
				</tr>
			</table>
		</asp:Panel>
		<asp:Panel ID="pnlDatosBienes" runat="server" Visible="false">
			<table>
				<tr>
					<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 70px;">
						Partida Electronica
					</td>
					<td>
						<asp:TextBox ID="txtPartElectBienes" runat="server" Font-Names="Arial" Font-Size="X-Small"
							Height="16px" Width="50px" MaxLength="10" Style="font-family: Arial, Helvetica, sans-serif;
							font-size: x-small" ontextchanged="txtPartElectBienes_TextChanged"></asp:TextBox>
					</td>
					<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 70px;">
						Oficina Registral
					</td>
					<td>
						<asp:TextBox ID="txtOficiRegBienes" runat="server" Font-Names="Arial" Font-Size="X-Small"
							Height="16px" Width="296px" MaxLength="200" Style="font-family: Arial, Helvetica, sans-serif;
							font-size: x-small" ontextchanged="txtOficiRegBienes_TextChanged"></asp:TextBox>
					</td>
				</tr>
			</table>
		</asp:Panel>
		<asp:Panel ID="pnlPersonaJuridica" runat="server" Visible="false">
			<table>
				<tr>
					<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 70px;">
						Documento de Identidad
					</td>
					<td>
						<asp:DropDownList ID="ddlTipoDocJur" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="138px" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" AutoPostBack="True" OnSelectedIndexChanged="ddlTipoDocJur_SelectedIndexChanged">
						</asp:DropDownList>
					</td>
					<td colspan="5">
						<asp:TextBox ID="txtNroDocJur" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="150px" MaxLength="20" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" OnTextChanged="txtNroDocJur_TextChanged" AutoPostBack="true"></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 70px;">
						Denominación Social
					</td>
					<td colspan="6">
						<asp:TextBox ID="txtNombreJur" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="450px" MaxLength="255" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td rowspan="2" style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
						Inscrita en
					</td>
					<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; ">
						Partida Electrónica
					</td>
					<td>
						<asp:TextBox ID="txtPartidaElectronica" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="50px" MaxLength="10" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"></asp:TextBox>
					</td>
					<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
						Ficha Nº
					</td>
					<td>
						<asp:TextBox ID="txtFicha" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="50px" MaxLength="10" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"></asp:TextBox>
					</td>
					<td colspan="2">&nbsp;</td>
				</tr>
				<tr>
					<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; ">
						Tomo
					</td>
					<td>
						<asp:TextBox ID="txtTomo" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="50px" MaxLength="10" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"></asp:TextBox>
					</td>
					<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
						Foja(s)
					</td>
					<td>
						<asp:TextBox ID="txtFojas" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="50px" MaxLength="100" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"></asp:TextBox>
					</td>
					<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
						Oficina Registral de
					</td>
					<td>
						<asp:TextBox ID="txtOficinaRegistral" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="150px" MaxLength="100" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"></asp:TextBox>
					</td>
				</tr>
			</table>
		</asp:Panel>
		<table>
			<tr>
				<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 70px;">
					Domicilio
				</td>
				<td colspan="5">
					<asp:TextBox ID="txtDomicilioCom" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="600px" MaxLength="255" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 70px;">
					Departamento
				</td>
				<td>
					<asp:DropDownList ID="ddlRegion" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="138px" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" AutoPostBack="True" onselectedindexchanged="ddlRegion_SelectedIndexChanged">
					</asp:DropDownList>
				</td>
				<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 70px;">
					Provincia
				</td>
				<td>
					<asp:DropDownList ID="ddlCiudad" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="138px" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" AutoPostBack="True" onselectedindexchanged="ddlCiudad_SelectedIndexChanged">
					</asp:DropDownList>
				</td>
				<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 70px;">
					Distrito
				</td>
				<td>
					<asp:DropDownList ID="ddlComuna" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="138px" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" AutoPostBack="True">
					</asp:DropDownList>
				</td>
			</tr>
		</table>
		<asp:Panel ID="pnlRepresentante" runat="server" Visible="false">
			<table style="background-color: #669999; width: 100%">
				<tr>
					<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 1115px; color: #FFFFFF;">
						<strong>DATOS DEL <asp:Label id="lblPanel" runat="server"></asp:Label></strong>
					</td>
				</tr>
			</table>
			<table>
				<tr>
					<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 70px;">
						Documento de Identidad
					</td>
					<td>
						<asp:DropDownList ID="ddlTipoDocRep" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="138px" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" AutoPostBack="True" OnSelectedIndexChanged="ddlTipoDocRep_SelectedIndexChanged">
						</asp:DropDownList>
					</td>
					<td colspan="4">
						<asp:TextBox ID="txtNroDocRep" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="150px" MaxLength="20" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" OnTextChanged="txtNroDocRep_TextChanged" AutoPostBack="true"></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 70px;">
						Nombre(s)
					</td>
					<td>
						<asp:TextBox ID="txtNombreRep" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="150px" MaxLength="50" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"></asp:TextBox>
					</td>
					<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 70px;">
						Apellido Paterno
					</td>
					<td>
						<asp:TextBox ID="txtPaternoRep" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="150px" MaxLength="50" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"></asp:TextBox>
					</td>
					<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 70px;">k
						Apellido Materno
					</td>
					<td>
						<asp:TextBox ID="txtMaternoRep" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="150px" MaxLength="50" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"></asp:TextBox>
					</td>
				</tr>
			</table>
		</asp:Panel>
		<table style="background-color: #669999; width: 100%">
			<tr>
				<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 1115px; color: #FFFFFF;">
					<strong>DATOS DEL VEHÍCULO</strong>
				</td>
			</tr>
		</table>
		<table>
			<tr>
				<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 70px;">
					Nro. Placa
				</td>
				<td>
					<asp:TextBox ID="txtVehPlaca" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="150px" MaxLength="50" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"></asp:TextBox>
				</td>
				<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 70px;">
					Nro VIN
				</td>
				<td>
					<asp:TextBox ID="txtVehVin" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="150px" MaxLength="50" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"></asp:TextBox>
				</td>
				<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 70px;">
					Nro. de Serie
				</td>
				<td>
					<asp:TextBox ID="txtVehSerie" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="150px" MaxLength="50" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 70px;">
					Marca
				</td>
				<td>
					<asp:DropDownList ID="ddlVehMarca" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="150px" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"></asp:DropDownList>
				</td>
				<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 70px;">
					Modelo
				</td>
				<td>
					<asp:TextBox ID="txtVehModelo" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="150px" MaxLength="50" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"></asp:TextBox>
				</td>
				<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 70px;">
					Año Fabricación
				</td>
				<td>
					<asp:TextBox ID="txtVehAnioF" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="150px" MaxLength="50" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 70px;">
					Versión
				</td>
				<td>
					<asp:TextBox ID="txtVehVersion" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="150px" MaxLength="50" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"></asp:TextBox>
				</td>
				<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 70px;">
					Año Modelo
				</td>
				<td>
					<asp:TextBox ID="txtVehAnioM" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="150px" MaxLength="50" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"></asp:TextBox>
				</td>
				<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 70px;">
					Categoría-Clase
				</td>
				<td>
					<%--<asp:TextBox ID="txtVehCat" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="150px" MaxLength="50" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"></asp:TextBox>--%>
					<asp:DropDownList ID="ddlVehCat" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="150px" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"></asp:DropDownList>
				</td>
			</tr>
			<tr>
				<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 70px;">
					Carroceria
				</td>
				<td>
					<%--<asp:TextBox ID="txtVehCarroceria" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="150px" MaxLength="50" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"></asp:TextBox>--%>
					<asp:DropDownList ID="ddlVehCarroceria" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="150px" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"></asp:DropDownList>
				</td>
				<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 70px;">
					Color
				</td>
				<td>
					<asp:TextBox ID="txtVehColor" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="150px" MaxLength="50" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"></asp:TextBox>
				</td>
				<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 70px;">
					Nro. Motor
				</td>
				<td>
					<asp:TextBox ID="txtVehNroMotor" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="150px" MaxLength="50" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 70px;">
					Potencia de Motor
				</td>
				<td>
					<asp:TextBox ID="txtVehPotMotor" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="150px" MaxLength="50" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"></asp:TextBox>
				</td>
				<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 70px;">
					Combustible
				</td>
				<td>
					<asp:DropDownList ID="ddlVehCombus" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="150px" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"></asp:DropDownList>
				</td>
				<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 70px;">
					Cilindros
				</td>
				<td>
					<asp:TextBox ID="txtVehCilindros" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="150px" MaxLength="50" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 70px;">
					Cilindrada
				</td>
				<td>
					<asp:TextBox ID="txtVehCilindrada" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="150px" MaxLength="50" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"></asp:TextBox>
				</td>
				<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 70px;">
					Longitud
				</td>
				<td>
					<asp:TextBox ID="txtVehLong" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="150px" MaxLength="50" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"></asp:TextBox>
				</td>
				<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 70px;">
					Ejes
				</td>
				<td>
					<asp:TextBox ID="txtVehEjes" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="150px" MaxLength="50" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 70px;">
					Pasajeros
				</td>
				<td>
					<asp:TextBox ID="txtVehPasajeros" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="150px" MaxLength="50" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"></asp:TextBox>
				</td>
				<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 70px;">
					Ancho
				</td>
				<td>
					<asp:TextBox ID="txtVehAncho" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="150px" MaxLength="50" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"></asp:TextBox>
				</td>
				<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 70px;">
					Peso Neto
				</td>
				<td>
					<asp:TextBox ID="txtVehPesoNeto" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="150px" MaxLength="50" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 70px;">
					Puertas
				</td>
				<td>
					<asp:TextBox ID="txtVehPuertas" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="150px" MaxLength="50" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"></asp:TextBox>
				</td>
				<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 70px;">
					Carga Útil
				</td>
				<td>
					<asp:TextBox ID="txtVehCargaUtil" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="150px" MaxLength="50" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"></asp:TextBox>
				</td>
				<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 70px;">
					Alto
				</td>
				<td>
					<asp:TextBox ID="txtVehAlto" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="150px" MaxLength="50" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 70px;">
					Peso Bruto
				</td>
				<td>
					<asp:TextBox ID="txtVehPesoBruto" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="150px" MaxLength="50" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"></asp:TextBox>
				</td>
				<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 70px;">
					Ruedas
				</td>
				<td>
					<asp:TextBox ID="txtVehRuedas" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="150px" MaxLength="50" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"></asp:TextBox>
				</td>
				<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 70px;">
					Asientos
				</td>
				<td>
					<asp:TextBox ID="txtVehAsientos" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="150px" MaxLength="50" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 70px;">
					Fórmula Rodante
				</td>
				<td>
					<asp:TextBox ID="txtVehFormula" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="150px" MaxLength="50" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"></asp:TextBox>
				</td>
				<td colspan="4">&nbsp;</td>
			</tr>
		</table>
		<table style="background-color: #669999; width: 100%">
			<tr>
				<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 1115px; color: #FFFFFF;">
					<strong>DETALLE DE FORMA DE PAGO</strong>
				</td>
			</tr>
		</table>
		<asp:GridView ID="grdFormaPago" runat="server" AutoGenerateColumns="False" DataKeyNames="id_solicitud,banco,medio_pago,moneda" CellPadding="4" Font-Names="Arial" Font-Size="X-Small" ForeColor="#333333" GridLines="None" Height="50px" onrowdatabound="grdFormaPago_RowDataBound">
			<Columns>
				<%--<asp:BoundField HeaderText="Nº Cuenta" DataField="numero_cuenta_corriente" />
				<asp:BoundField HeaderText="Banco" DataField="banco" />
				<asp:BoundField HeaderText="Medio Pago" DataField="medio_pago" />
				<asp:BoundField HeaderText="Monto" DataField="monto_abono" />
				<asp:BoundField HeaderText="Moneda" DataField="moneda" />
				<asp:BoundField HeaderText="Fecha" DataField="fecha_abono" />--%>
				<asp:TemplateField HeaderText="Nº Cuenta">
					<ItemTemplate>
						<asp:TextBox ID="txtNCuenta" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="160px" MaxLength="50" Text='<%# Bind("nro_cuenta") %>'></asp:TextBox>
					</ItemTemplate>
					<%--<EditItemTemplate>
						<asp:TextBox ID="txtNCuenta" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="160px" MaxLength="50" Text='<%# Bind("nro_cuenta") %>'></asp:TextBox>
					</EditItemTemplate>--%>
				</asp:TemplateField>
				<asp:TemplateField HeaderText="Banco">
					<ItemTemplate>
						<asp:DropDownList ID="ddlBanco" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="150px"></asp:DropDownList>
					</ItemTemplate>
					<%--<EditItemTemplate>
						<asp:DropDownList ID="ddlBanco" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="150px"></asp:DropDownList>
					</EditItemTemplate>--%>
				</asp:TemplateField>
				<asp:TemplateField HeaderText="Medio Pago">
					<ItemTemplate>
						<asp:DropDownList ID="ddlMedioPago" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="80px">
						</asp:DropDownList>
					</ItemTemplate>
					<%--<EditItemTemplate>
						<asp:DropDownList ID="ddlMedioPago" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="80px">
						</asp:DropDownList>
					</EditItemTemplate>--%>
				</asp:TemplateField>
				<asp:TemplateField HeaderText="Monto">
					<ItemTemplate>
						<asp:TextBox ID="txtMonto" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="60px" MaxLength="50" Text='<%# Bind("monto") %>'></asp:TextBox>
					</ItemTemplate>
					<%--<EditItemTemplate>
						<asp:TextBox ID="txtMonto" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="60px" MaxLength="50" Text='<%# Bind("monto") %>'></asp:TextBox>
					</EditItemTemplate>--%>
				</asp:TemplateField>
				<asp:TemplateField HeaderText="Moneda">
					<ItemTemplate>
						<asp:DropDownList ID="ddlMoneda" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="80px">
						</asp:DropDownList>
					</ItemTemplate>
				</asp:TemplateField>
				<asp:TemplateField HeaderText="Fecha">
					<ItemTemplate>
						<asp:TextBox ID="txtFecha" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="60px" MaxLength="50" Text='<%# Bind("fecha") %>'></asp:TextBox>
						<%--<asp:ImageButton ID="ibFecha" runat="server" ImageUrl="../imagenes/sistema/gif/calendario.gif" />
						<cc1:CalendarExtender ID="calFecha" runat="server" TargetControlID="txtFecha" PopupButtonID="ibFecha" />--%>
						<cc1:CalendarExtender ID="calFecha" runat="server" TargetControlID="txtFecha" />
					</ItemTemplate>
				</asp:TemplateField>
				<asp:TemplateField HeaderText="Observaciones">
					<ItemTemplate>
						<asp:TextBox ID="txtObservaciones" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="250px" MaxLength="250" Text='<%# Bind("observaciones") %>'></asp:TextBox>
					</ItemTemplate>
				</asp:TemplateField>
			</Columns>
			<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
			<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
			<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
			<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
			<EditRowStyle BackColor="#2461BF" />
			<AlternatingRowStyle BackColor="White" />
		</asp:GridView>
		<table>
			<tr>
				<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
					Observaciones Forma de Pago:
				</td>
				<td>
					<asp:TextBox ID="txtObsFP" runat="server" Font-Names="Arial" Font-Size="X-Small" Width="500px" MaxLength="250" TextMode="MultiLine" Rows="4"></asp:TextBox>
				</td>
			</tr>
		</table>
		<table style="background-color: #669999; width: 100%">
			<tr>
				<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 1115px; color: #FFFFFF;">
					<strong>OTROS DATOS OPERACIÓN</strong>
				</td>
			</tr>
		</table>
		<table>
			<tr>
				<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
					Nro. Título:
				</td>
				<td>
					<asp:TextBox ID="txtNumeroTitulo" runat="server" Font-Names="Arial" Font-Size="X-Small" Width="100px" MaxLength="10"></asp:TextBox>
					<cc1:FilteredTextBoxExtender ID="txtNumeroTituloTextBoxExtender1" runat="server" TargetControlID="txtNumeroTitulo" FilterType="Custom, Numbers" ValidChars="">
					</cc1:FilteredTextBoxExtender>
				</td>
			</tr>
			<tr>
				<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
					Observaciones:
				</td>
				<td>
					<asp:TextBox ID="txtObsOp" runat="server" Font-Names="Arial" Font-Size="X-Small" Width="500px" MaxLength="250" TextMode="MultiLine" Rows="4"></asp:TextBox>
				</td>
			</tr>
		</table>
		<table style="background-color: #ffffff; width: 100%">
			<tr>
				<td style="text-align: center; width: 38px;">
					<asp:Button ID="bt_guardar" runat="server" Font-Names="Arial" Font-Size="X-Small" Text="Guardar" OnClick="bt_guardar_Click" />
				</td>
				<td style="width: 42px">
					<asp:Button ID="bt_limpiar" runat="server" Font-Names="Arial" Font-Size="X-Small" Text="Limpiar" OnClick="bt_limpiar_Click" />
				</td>
				<td style="width: 42px">
					<asp:Button ID="bt_caratula" runat="server" Font-Names="Arial" Font-Size="X-Small" Text="Caratula" Visible="False" OnClick="bt_caratula_Click" />
				</td>
				<td style="text-align: right">
					<%--<asp:BoundField HeaderText="Nº Cuenta" DataField="numero_cuenta_corriente" />
				<asp:BoundField HeaderText="Banco" DataField="banco" />
				<asp:BoundField HeaderText="Medio Pago" DataField="medio_pago" />
				<asp:BoundField HeaderText="Monto" DataField="monto_abono" />
				<asp:BoundField HeaderText="Moneda" DataField="moneda" />
				<asp:BoundField HeaderText="Fecha" DataField="fecha_abono" />--%>					<%--<EditItemTemplate>
						<asp:TextBox ID="txtNCuenta" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="160px" MaxLength="50" Text='<%# Bind("nro_cuenta") %>'></asp:TextBox>
					</EditItemTemplate>--%>
					<asp:HyperLink ID="ibtnSUNARP" runat="server" Target="_blank" ImageUrl="~/imagenes/sistema/static/document.png" Style="margin: 2px;" Visible="false" ToolTip="Formato de Inmatriculación"></asp:HyperLink>
					<asp:HyperLink ID="ibtAnexo1" runat="server" Target="_blank" ImageUrl="~/imagenes/sistema/static/document.png" Style="margin: 2px;" Visible="false" ToolTip="Anexo I"></asp:HyperLink>
					<asp:HyperLink ID="ibtAnexo2" runat="server" Target="_blank" ImageUrl="~/imagenes/sistema/static/document.png" Style="margin: 2px;" Visible="false" ToolTip="Anexo II"></asp:HyperLink>
					<asp:HyperLink ID="ibtAnexo" runat="server" Target="_blank" ImageUrl="~/imagenes/sistema/static/document.png" Style="margin: 2px;" Visible="false" ToolTip=""></asp:HyperLink>
					<asp:HyperLink ID="ibtnFormaPago" runat="server" Target="_blank" ImageUrl="~/imagenes/sistema/static/document.png" Style="margin: 2px;" Visible="false" ToolTip="Declaración Forma de Pago"></asp:HyperLink>
					<asp:HyperLink ID="ibtnAAP" runat="server" Target="_blank" ImageUrl="~/imagenes/sistema/static/document.png" Style="margin: 2px;" Visible="false" ToolTip="Poder AAP"></asp:HyperLink>
					<asp:HyperLink ID="ibtSAT" runat="server" Target="_blank" ImageUrl="~/imagenes/sistema/static/document.png" Style="margin: 2px;" Visible="false" ToolTip="Poder SAT"></asp:HyperLink>
					<asp:HyperLink ID="ibtCheck" runat="server" Target="_blank" ImageUrl="~/imagenes/sistema/static/document.png" Style="margin: 2px;" Visible="false" ToolTip="Check List"></asp:HyperLink>
					<asp:Label ID="lbl_operacion" runat="server" Font-Names="Arial" Font-Size="Small" ForeColor="#FF3300" Visible="False"></asp:Label>
					<asp:Label ID="lbl_numero" runat="server" Font-Names="Arial" Font-Size="Small" ForeColor="#FF3300" Visible="False"></asp:Label>
				</td>
			</tr>
		</table>
	</div>
	<asp:Panel ID="pnlSeleccionarDatos" runat="server" Style="border-width: 1px; border-style: solid; background-color: #FFFFFF; position: inherit; width: 300px; height: 80px" Height="64px" Width="296px">
		<center style="background-color: #0066CC">
			<asp:Label ID="Label4" ForeColor="Blue" Font-Names="Arial, Helvetica, sans-serif" runat="server" Text="¿Esta seguro de ingresar esta operación?" Font-Size="Small" Style="color: #FFFFFF; font-weight: 700" />
		</center>
		<table style="width: 292px; height: 60px">
			<tr>
				<td align="center" style="background-color: #FFFFFF">
					<asp:Button ID="btnAceptar" runat="server" Font-Names="Arial" Font-Size="X-Small" Text="Aceptar" OnClick="btnAceptar_Click" />
				</td>
				<td align="center" style="background-color: #FFFFFF">
					<asp:Button ID="btnCancelar" runat="server" Font-Names="Arial" Font-Size="X-Small" Text="Cancelar" OnClick="btnCancelar_Click" />
				</td>
			</tr>
		</table>
	</asp:Panel>
	<cc1:ModalPopupExtender ID="mpeSeleccion" runat="server" TargetControlID="bt_guardar" PopupControlID="pnlSeleccionarDatos" CancelControlID="btnCancelar" DropShadow="True" BackgroundCssClass="FondoAplicacion" />
</asp:Content>
