<%@ Page Title="Ingreso de Pre-inscripcion de vehiculos motorizados" Language="C#" MasterPageFile="~/Adm.Master" AutoEventWireup="true" CodeBehind="ingreso_modal.aspx.cs" Inherits="sistemaAGP.ingreso_modal" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/controles/wucVehiculo.ascx" TagName="DatosVehiculo" TagPrefix="agp" %>
<%@ Register Src="~/controles/wucPersona.ascx" TagName="DatosPersona" TagPrefix="agp" %>
<%@ Register Src="~/controles/wucGrabar.ascx" TagName="DatosGrabar" TagPrefix="agp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="../jquery-1.7.2.min.js"></script>
	<script type="text/javascript" src="../jquery.mousewheel-3.0.6.pack.js"></script>
	<script type="text/javascript" src="../jquery.fancybox.js?v=2.0.6"></script>
	<script language="javascript" type="text/javascript">
function HideModalPopup()
{
var modal = $find('ModalPopupExtender');
modal.hide();
}
	</script>
	<link rel="Stylesheet" type="text/css" href="../jquery.fancybox.css?v=2.0.6" media="screen" />
	<style type="text/css">
        .style1
        {
			width: 162px;
		}
        .style2
        {
            width: 70px;
        }
        .style3
        {
            font-size: x-small;
            color: #FF0000;
            font-family: Arial, Helvetica, sans-serif;
        }
          .style6
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: x-small;
            color: #FF3300;
        }
          .style7
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: x-small;
            font-weight: bold;
              color:Red;
			width: 51px;
		}
        
              .modal_div2 {
                border-radius: 20px;
                -ms-border-radius: 10px;
                -moz-border-radius: 10px;
                -webkit-border-radius: 10px;
                -khtml-border-radius: 10px;
                 background-color:Aqua;
                border: 1px solid  #343536;
                
                                  position: absolute;
                height: 233px;
                width: 215px;
                top: 9%;
                left: 19%;
                

              

}
.modal_div2-texto {
                height:210px;
                width: 510px;
                   position:absolute;
    top:500px;
    left:60px
                margin-top: -50px;
                margin-left: -140px;
                color:  #fff;
}
.modal_div2-texto table {
                height: 100%;
                width: 100%;
}
.modal_div2-texto td {
                padding: 3px 6px 3px 6px;
                margin: 5px;
                vertical-align: middle;
                text-align: center;
}

        
        
        .modal_div {
                border-radius: 20px;
                -ms-border-radius: 10px;
                -moz-border-radius: 10px;
                -webkit-border-radius: 10px;
                -khtml-border-radius: 10px;
                 background-color: #669999;
                border: 1px solid  #343536;
                
				opacity:0.9;
                
                                  position: absolute;
                height: 445px;
                width: 350px;
                top: 10%;
                left: 31%;
                

              

}
.modal_div-texto {
                height:44px;
                width: 330px;
                   position:absolute;
    top:390px;
    left:150px;
                margin-left: -140px;
                color:  #fff;
}
.modal_div-texto table {
                height: 100%;
                width: 100%;
}
.modal_div-texto td {
                padding: 3px 6px 3px 6px;
                margin: 5px;
                vertical-align: middle;
                text-align: center;
}

        
    	.style8 {
			width: 110px;
		}

        
    	.style9 {
			font-family: Arial, Helvetica, sans-serif;
			font-size: x-small;
			font-weight: bold;
			color: Red;
			width: 115px;
		}

        
    	.style10
		{
			width: 125px;
		}

        
    </style>
	<script type="text/javascript">
		$(document).ready(function () {
			$('.fancybox').fancybox({
				maxWidth: 640,
				maxHeight: 480,
				fitToView: false,
				width: 640,
				height: 480,
				autoSize: true,
				openEffect: 'elastic',
				openSpeed: 150,
				closeEffect: 'elastic',
				closeSpeed: 150,
				closeClick: false,
				closeBtn: true,
				scrolling: 'no',
				padding: 0,
				helpers: {
					overlay: {
						opacity: 0.5,
						css: {
							'background-color': 'Gray'
						},
						title: {
							type: 'float'
						}
					}
				}
			});
		});
	</script>
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
		<table width="100%">
			<tr>
				<td align="left">
					
			
				
					<asp:Button ID="btnHiddenPhone" runat="Server" Style="display: none;" />
					<asp:Button ID="btnHiddenPhone2" runat="Server" Style="display: none;" />
					<asp:Button ID="btnHiddenPhone3" runat="Server" Style="display: none;" />
				</td>
			</tr>
			
			<tr>
				<td align="left">
					&nbsp;</td>
			</tr>
		</table>


		<table>
			<tr>
				<td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
					Cliente
				</td>
				<td style="margin-left: 80px">
					<asp:DropDownList ID="dl_cliente" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="138px" TabIndex="1" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" AutoPostBack="True" OnSelectedIndexChanged="dl_cliente_SelectedIndexChanged">
					</asp:DropDownList>
				</td>
                 <td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">Nº Operacion Cliente
                        </td>
                        <td>
                            <asp:TextBox ID="txt_numero_emisor" runat="server" Width="72px"   OnTextChanged="txt_numero_emisor_OnTextChanged"></asp:TextBox>
                            <span id="spNumOperacion" runat="server" class="style3" Visible="false">Para continuar debe ingresar N° Op. cliente</span>
                        </td>
                
                         <td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
					        <asp:Label ID="lblInstruccionPago" runat="server" Text="Instrucción de pago" Visible="False"></asp:Label> 
				        </td>
                        <td style="margin-left: 80px">
					        <asp:DropDownList ID="dlInstruccionPago" Visible="False" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="138px" TabIndex="1" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" AutoPostBack="True" OnSelectedIndexChanged="dl_cliente_SelectedIndexChanged">
					        </asp:DropDownList>
				        </td>
                        <td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
					        <asp:Label ID="lblNormaEuro" runat="server" Text="Norma Euro" Visible="False"></asp:Label>
				        </td>
                        <td>
                            <asp:CheckBox ID="ckNormaEuro" runat="server" Visible="False"/>
                        </td>
                
                        <td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
                      
                       <asp:Label ID="lbl_bien" runat="server" Text="Bien Leasing" Visible="False"></asp:Label>
                      </td>

                      <td>
                             <asp:DropDownList ID="dl_bien" runat="server" Visible="False" Font-Names="Arial" Font-Size="X-Small" Height="16px"
                                  Width="138px" TabIndex="1" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" >
					         </asp:DropDownList>
                      </td>
                

			</tr>
		</table>
		<agp:DatosPersona ID="agpVendedor" runat="server" Titulo="DATOS VENDEDOR" HabilitarCompraPara="false" HabilitarCorreo="false" HabilitarDireccion="false" HabilitarParticipante="false" HabilitarTelefono="false" />
        <%--<table style="background-color: #669999; width: 100%">
			<tr>
				<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 1115px; color: #FFFFFF;"><b>DATOS DEL VEHICULO</b></td>
			</tr>
		</table>
		<table style="width: 100%">
			<tr>
				<td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">Tipo Vehiculo</td>
				<td>
					<asp:DropDownList ID="dl_tipo_vehiculo" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="138px" TabIndex="4" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"></asp:DropDownList>
				</td>
				<td style="width: 43px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">Marca</td>
				<td>
					<asp:DropDownList ID="dl_marca_vehiculo" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="168px" TabIndex="5" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"></asp:DropDownList>
				</td>
				<td style="width: 43px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">Modelo</td>
				<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small">
					<asp:TextBox ID="txt_modelo_vehiculo" runat="server" Width="178px" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" MaxLength="100" TabIndex="6"></asp:TextBox>
					<cc1:AutoCompleteExtender ID="ac_modelo_vehiculo" runat="server" Enabled="True" ServicePath="~/servicios_web/wsagp.asmx" MinimumPrefixLength="2" ServiceMethod="getListaModelosVehiculos" EnableCaching="true" TargetControlID="txt_modelo_vehiculo" UseContextKey="True" CompletionSetCount="10" CompletionInterval="200"></cc1:AutoCompleteExtender>
				</td>
				<td style="width: 43px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">Año</td>
				<td>
					<asp:TextBox ID="txt_ano_vehiculo" runat="server" Width="56px" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" MaxLength="4" TabIndex="7"></asp:TextBox>
					<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txt_ano_vehiculo" FilterType="Custom, Numbers" ValidChars=""></cc1:FilteredTextBoxExtender>
				</td>
			</tr>
		</table>
		<table style="width: 100%">
			<tr>
				<td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">Cilindrada</td>
				<td>
					<asp:TextBox ID="txt_cilindrada" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" MaxLength="10" Width="67px" TabIndex="8"></asp:TextBox>
				</td>
				<td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">Nº Puertas</td>
				<td>
					<asp:TextBox ID="txt_puertas" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" Height="19px" Width="43px" TabIndex="9" MaxLength="2"></asp:TextBox>
					<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txt_puertas" FilterType="Custom, Numbers" ValidChars=""></cc1:FilteredTextBoxExtender>
				</td>
				<td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">Nº Asientos</td>
				<td>
					<asp:TextBox ID="txt_asientos" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" Width="39px" Height="19px" TabIndex="10" MaxLength="2"></asp:TextBox>
					<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="txt_asientos" FilterType="Custom, Numbers" ValidChars=""></cc1:FilteredTextBoxExtender>
				</td>
				<td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">Peso Bruto </td>
				<td>
					<asp:TextBox ID="txt_peso_bruto" runat="server" Width="56px" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" TabIndex="11" MaxLength="4"></asp:TextBox>
					<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" TargetControlID="txt_peso_bruto" FilterType="Custom, Numbers" ValidChars=""></cc1:FilteredTextBoxExtender>
				</td>
				<td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">Peso Carga </td>
				<td>
					<asp:TextBox ID="txt_peso_carga" runat="server" Width="56px" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" TabIndex="12" MaxLength="4"></asp:TextBox>
					<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" TargetControlID="txt_peso_carga" FilterType="Custom, Numbers" ValidChars=""></cc1:FilteredTextBoxExtender>
				</td>
				<td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">Combustible</td>
				<td>
					<asp:DropDownList ID="dl_combustible" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="138px" TabIndex="13" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"></asp:DropDownList>
				</td>
			</tr>
		</table>
		<table style="width: 100%">
			<tr>
				<td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">Color</td>
				<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small">
					<asp:TextBox ID="txt_color" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" MaxLength="50" Width="134px" TabIndex="14" Height="16px"></asp:TextBox>
					<cc1:AutoCompleteExtender ID="ac_color" runat="server" Enabled="True" ServicePath="~/servicios_web/wsagp.asmx" MinimumPrefixLength="2" ServiceMethod="getListaColoresVehiculos" EnableCaching="true" TargetControlID="txt_color" UseContextKey="True" CompletionSetCount="10" CompletionInterval="200"></cc1:AutoCompleteExtender>
				</td>
				<td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">Motor</td>
				<td>
					<asp:TextBox ID="txt_motor" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" MaxLength="30" Width="125px" TabIndex="15"></asp:TextBox>
				</td>
				<td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">Chasis</td>
				<td>
					<asp:TextBox ID="txt_chasis" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" MaxLength="30" Width="125px" TabIndex="16"></asp:TextBox>
				</td>
				<td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">VIN</td>
				<td>
					<asp:TextBox ID="txt_vin" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" MaxLength="30" Width="120px" TabIndex="17"></asp:TextBox>
				</td>
				<td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">Serie</td>
				<td>
					<asp:TextBox ID="txt_serie" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" MaxLength="30" Width="120px" TabIndex="17"></asp:TextBox>
				</td>
			</tr>
		</table>--%>
		

		<table style="background-color: #669999; width: 100%">
			<tr>
				<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 1115px; color: #FFFFFF;">
					<b>DATOS DEL NEGOCIO</b>
				</td>
			</tr>
		</table>
		<asp:Panel ID="pnl_datos_factura" runat="server">
			<table>
				<tr>
					<td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
						Nº Factura
					</td>
					<td>
						<asp:TextBox ID="txt_factura" runat="server" Font-Names="Arial" Font-Size="X-Small" MaxLength="8" TabIndex="27" AutoPostBack="True" OnTextChanged="txt_factura_Leave" BackColor="#0099FF" ForeColor="White" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" Height="16px" Width="98px"></asp:TextBox>
						<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender_factura" runat="server" TargetControlID="txt_factura" FilterType="Custom, Numbers" ValidChars="">
						</cc1:FilteredTextBoxExtender>
					</td>
					<td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
						Fecha Facturacion
					</td>
					<td>
						<asp:TextBox ID="txt_fecha_factura" runat="server" 
							Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" 
							Height="19px" Width="73px" TabIndex="2" 
							ontextchanged="txt_fecha_factura_TextChanged" AutoPostBack="true"></asp:TextBox>
						<cc1:CalendarExtender runat="server" TargetControlID="txt_fecha_factura" CssClass="calendario" Format="dd/MM/yyyy" PopupButtonID="ib_calendario" ID="CalendarExtender1" />
					</td>
					<td>
						<asp:ImageButton ID="ib_calendario" runat="server" ImageUrl="../imagenes/sistema/gif/calendario.gif" />
					</td>
					<td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
						Neto
					</td>
					<td>
						<asp:TextBox ID="txt_neto" runat="server" Width="104px" 
							Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" 
							BackColor="#3399FF" ForeColor="White" TabIndex="3" AutoPostBack="true" 
							ontextchanged="txt_neto_TextChanged"></asp:TextBox>
						<cc1:FilteredTextBoxExtender ID="txt_neto_FilteredTextBoxExtender" runat="server" TargetControlID="txt_neto" FilterType="Custom, Numbers" ValidChars="">
						</cc1:FilteredTextBoxExtender>
					</td>
				</tr>
			</table>
		</asp:Panel>
		<table>
			<tr>
				<td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
					Sucursal Origen
				</td>
				<td>
					<asp:DropDownList ID="dl_sucursal_origen" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="138px" TabIndex="17" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small">
					</asp:DropDownList>
				</td>
				<td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
					Sucursal Destino
				</td>
				<td>
					<asp:DropDownList ID="dl_sucursal_destino" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="138px" TabIndex="18" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small">
					</asp:DropDownList>
				</td>
				<td style="width: 117px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
					<asp:Label ID="lbl_forma_pago" runat="server" Text="Forma de Pago"></asp:Label>
				</td>
				<td>
					<asp:DropDownList ID="dl_forma_pago" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="138px" TabIndex="18" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" AutoPostBack="true" OnSelectedIndexChanged="dl_forma_pago_SelectedIndexChanged">
					</asp:DropDownList>
				</td>
				<td style="width: 117px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
					<asp:Label ID="lbl_financiera" runat="server" Text="Entidad Financiera"></asp:Label>
				</td>
				<td>
					<asp:DropDownList ID="dl_financiera" runat="server" Font-Names="Arial" 
						Font-Size="X-Small" Height="16px" Width="138px" TabIndex="19" 
						Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" 
						onselectedindexchanged="dl_financiera_SelectedIndexChanged">
					</asp:DropDownList>
				</td>
			</tr>
		</table>
		<table >
			<tr>
				<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;" class="style2">
					Cargo Venta
				</td>
				<td class="style1">
					<asp:DropDownList ID="dl_cargo_venta" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="138px" TabIndex="22" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small">
					</asp:DropDownList>
				</td>
				<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;" 
					class="style10">
					<asp:Label ID="lbl_terminacion" runat="server" Text="Terminación Especial"></asp:Label>
				</td>
				<td>
					<asp:TextBox ID="txt_terminacion" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" MaxLength="50" Width="84px" TabIndex="25"></asp:TextBox>
				</td>
                <td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;" 
					class="style10">
                    Con o sin impuesto verde
                </td>
                <td>
                    <asp:DropDownList ID="dlImpuestoVerde" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="138px" TabIndex="22" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small">
					</asp:DropDownList>
                </td>
				<%--<td style="width: 31px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
					<asp:Label ID="lbl_tag" runat="server" Text="TAG"></asp:Label>
				</td>
				<td>
					<asp:DropDownList ID="dl_tag" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="138px" TabIndex="26" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small">
					</asp:DropDownList>
				</td>--%>
				<%--<td style="width: 31px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
					<asp:Label ID="lbl_tipo_tramite" runat="server" Text="Tipo Tramite"></asp:Label>
				</td>
				<td>
					<asp:DropDownList ID="dl_tipo_tramite" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="138px" TabIndex="27" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" OnSelectedIndexChanged="dl_tipo_tramite_SelectedIndexChanged">
					</asp:DropDownList>
				</td>--%>
			</tr>
			<tr>
				<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;" class="style2">
					<asp:Label ID="lbl_nota_venta" runat="server" Text="Nota de Venta"></asp:Label>
				</td>
				<td class="style1">
					<asp:TextBox ID="txt_nota_venta" runat="server" Font-Names="Arial" Font-Size="X-Small" MaxLength="8" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" Width="100px"></asp:TextBox>
					<cc1:filteredtextboxextender ID="FilteredTextBoxExtender1" runat="server" 
						TargetControlID="txt_nota_venta" FilterType="Custom, Numbers" ValidChars="">
					</cc1:filteredtextboxextender>
				</td>
				<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;" class="style2">
					<asp:Label ID="Label1" runat="server" Text="CIT"></asp:Label>
				</td>
				<td class="style1">
					<asp:TextBox ID="txt_cit" runat="server" Font-Names="Arial" Font-Size="X-Small"
						MaxLength="20" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"
						Width="100px"></asp:TextBox>
				
				</td>
				
			</tr>
		</table>
		<agp:DatosVehiculo ID="agpVehiculo" runat="server" Titulo="DATOS VEHICULO" />
		<agp:DatosPersona ID="agpAdquirente" runat="server" Titulo="DATOS ADQUIRENTE" HabilitarCompraPara="true" />
		<agp:DatosPersona ID="agpCompraPara" runat="server" Titulo="DATOS COMPRA PARA" HabilitarCompraPara="false" Visible="false" />
		<agp:datosgrabar id="agpDatosGrabar" onclick="btnAceptar_Click" onclick1="cmdLink_Click1"
			runat="server" titulo="GRABAR" habilitarcomprapara="false" visible="true" />
        <asp:HiddenField ID="hdIdOrdenTrabajo" runat="server" />


    
</asp:Content>