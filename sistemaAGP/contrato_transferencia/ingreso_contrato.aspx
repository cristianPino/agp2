<%@ Page Title="Ingreso Solicitud de Transferencia" Language="C#" MasterPageFile="~/Adm.Master" AutoEventWireup="true" CodeBehind="ingreso_contrato.aspx.cs" Inherits="sistemaAGP.contrato_transferencia.ingreso_contrato" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/controles/wucPersonaTransferencia.ascx" TagName="DatosPersona" TagPrefix="agp" %>
<%--<%@ Register Src="~/controles/wucVehiculo.ascx" TagName="DatosVehiculo" TagPrefix="agp" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<script type="text/javascript" src="../jquery-1.7.2.min.js"></script>
	<script type="text/javascript" src="../jquery.mousewheel-3.0.6.pack.js"></script>
	<script type="text/javascript" src="../jquery.fancybox.js?v=2.0.6"></script>

		<style type="text/css">

        
        
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

        
        
    </style>



	<link rel="Stylesheet" type="text/css" href="../jquery.fancybox.css?v=2.0.6" media="screen" />
	<script type="text/javascript">
		$(document).ready(function () {
			$('.fancybox').fancybox({
				maxWidth: 640,
				maxHeight: 480,
				minWidth: 640,
				minHeight: 480,
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
	<table style="background-color: #e5e5e5;">
		<tr>
			<td style="width: 789px; height: 20px" valign="top">
				<table bgcolor="#669999" style="width: 100%">
					<tr>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 1115px; color: #FFFFFF;">
							<b>CARGO OPERACION --<asp:Label ID="lbl_titulo" runat="server" Text=""></asp:Label></b>
						</td>
					</tr>
				</table>
				<table>
					<tr>
						<td>
							<span style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; font-weight: bold">Cliente</span>
						</td>
						<td>
							<asp:DropDownList ID="dl_cliente" runat="server" Height="16px" Width="188px" AutoPostBack="True" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; font-weight: 700" onselectedindexchanged="dl_cliente_SelectedIndexChanged">
							</asp:DropDownList>
						</td>
						<td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
							Sucursal Origen
						</td>
						<td>
							<asp:DropDownList ID="dl_sucursal_origen" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="138px" TabIndex="17" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small">
							</asp:DropDownList>
						</td>

                        <td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">Nº Operacion Cliente
                        </td>
                        <td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
                            <asp:TextBox ID="txt_numero_emisor" runat="server" Width="72px" ontextchanged="txt_numero_emisor_TextChanged"></asp:TextBox>  
                        
                        </td>
                        <td  id="tdFactura" runat="server"  style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
                                N° Factura
                        </td>

                        <td id="tdTxtFactura" runat="server" style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;" >
                            <asp:TextBox ID="txtNumFactura" runat="server" Width="72px"></asp:TextBox>
                        </td>


						<td>
							<asp:HyperLink ID="lnk_manual" runat="server" ImageUrl="~/imagenes/iconpdf.jpg" NavigateUrl="~/imagenes/Manual_Transferencia.pdf" Width="29px" Height="29px" Target="_blank" Style="border: none; text-decoration: none;"></asp:HyperLink>
						</td>
					</tr>
                     <tr>
                            <td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
                                <asp:Label ID="lbl_bien" runat="server" Text="Bien Leasing" Visible="False"></asp:Label>
                            </td>

                            <td>
                                <asp:DropDownList ID="dl_bien" runat="server" Visible="False" Font-Names="Arial" Font-Size="X-Small" Height="16px"
                                Width="138px" TabIndex="1" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small">
					            </asp:DropDownList>
                            </td>
                        </tr>
				</table>
				<agp:DatosPersona ID="Datosvendedor" runat="server" Titulo="DATOS DEL VENDEDOR" HabilitarCompraPara="false" />
				<table bgcolor="#669999" style="width: 100%">
					<tr>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 1115px; color: #FFFFFF;">
							<b>DATOS DE VENTA</b>
						</td>
					</tr>
				</table>
				<asp:Panel ID="id_datounico" runat="server">
					<table>
						<tr>
							<td style="font-size: x-small; font-family: Arial, Helvetica, sans-serif">
								Patente
							</td>
							<td>
								<asp:TextBox ID="txt_patente" runat="server" MaxLength="6" Style="font-size: x-small; font-family: Arial, Helvetica, sans-serif" Width="60px" AutoPostBack="True" OnTextChanged="txt_patente_TextChanged"></asp:TextBox>
								<asp:TextBox ID="txt_dv_patente" runat="server" MaxLength="1" Style="font-size: x-small; font-family: Arial, Helvetica, sans-serif" Width="16px"></asp:TextBox>
							</td>
							<td style="font-size: x-small; font-family: Arial, Helvetica, sans-serif">
								Kilometraje
							</td>
							<td>
								<asp:TextBox ID="txt_kilometraje" runat="server" MaxLength="10" Style="font-size: x-small; font-family: Arial, Helvetica, sans-serif" Width="65px" AutoPostBack="True" OnTextChanged="txt_kilometraje_TextChanged"></asp:TextBox>
								<%--<ajaxToolkit:FilteredTextBoxExtender ID="txt_kilometrajeFilteredTextBoxExtender1" runat="server"
								TargetControlID="txt_kilometraje" FilterType="Custom, Numbers" ValidChars="">
							</ajaxToolkit:FilteredTextBoxExtender>--%>
							</td>
							<td style="font-size: x-small; font-family: Arial, Helvetica, sans-serif">
								Precio Venta
							</td>
							<td>
								<asp:TextBox ID="txt_precio" runat="server" MaxLength="9" Style="font-size: x-small; font-family: Arial, Helvetica, sans-serif" AutoPostBack="True" OnTextChanged="txt_precio_TextChanged"></asp:TextBox>
								<%--<ajaxToolkit:FilteredTextBoxExtender ID="txt_precioFilteredTextBoxExtender1" runat="server"
								TargetControlID="txt_precio" FilterType="Custom, Numbers" ValidChars=".">
							</ajaxToolkit:FilteredTextBoxExtender>--%>
							</td>
							<td style="font-size: x-small; font-family: Arial, Helvetica, sans-serif">
								Tasacion
							</td>
							<td>
								<asp:TextBox ID="txt_tasacion" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" AutoPostBack="True" OnTextChanged="txt_tasacion_TextChanged"></asp:TextBox>
								<%--<ajaxToolkit:FilteredTextBoxExtender ID="txt_tasacionFilteredTextBoxExtender1" runat="server"
								TargetControlID="txt_tasacion" FilterType="Custom, Numbers" ValidChars="">
							</ajaxToolkit:FilteredTextBoxExtender>--%>
							</td>
							<td>
								<asp:Label ID="lbl_codigo" runat="server"></asp:Label>
							</td>
							<td>
								<asp:ImageButton ID="ib_tasacion" runat="server" ImageUrl="../imagenes/sistema/static/dinero1.gif" Height="22px" Width="23px" />
							</td>
							
						</tr>
						<tr>
							
							<td style="width: 117px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
								<asp:Label ID="lbl_forma_pago" runat="server" Text="Forma de Pago"></asp:Label>
							</td>
							<td>
								<asp:DropDownList ID="dl_forma_pago" runat="server" Font-Names="Arial" Font-Size="X-Small"
									Height="16px" Width="138px" TabIndex="18" Style="font-family: Arial, Helvetica, sans-serif;
									font-size: x-small" AutoPostBack="true" OnSelectedIndexChanged="dl_forma_pago_SelectedIndexChanged">
									<asp:listitem text="seleccionar" value="0" />
									<asp:listitem text="CONTADO" value="1" />
									<asp:listitem text="CREDITO" value="2" />
									<asp:listitem text="CHEQUE" value="3" />
								</asp:DropDownList>
							</td>
							<td style="width: 117px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
								<asp:Label ID="lbl_financiera" runat="server" Text="Entidad Financiera"></asp:Label>
							</td>
							<td>
								<asp:DropDownList ID="dl_financiera" runat="server" Font-Names="Arial" Font-Size="X-Small"
									Height="16px" Width="138px" TabIndex="19" Style="font-family: Arial, Helvetica, sans-serif;
									font-size: x-small" onselectedindexchanged="dl_financiera_SelectedIndexChanged">
								</asp:DropDownList>
							</td>
							<td style="width: 31px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
								<asp:Label ID="lbl_tag" runat="server" Text="TAG"></asp:Label>
							</td>
							<td>
								<asp:DropDownList ID="dl_tag" runat="server" Font-Names="Arial" Font-Size="X-Small"
									Height="16px" Width="138px" TabIndex="26" Style="font-family: Arial, Helvetica, sans-serif;
									font-size: x-small">
								</asp:DropDownList>
							</td>
							<td>
								<asp:CheckBox ID="chk_leasing" runat="server" Text="Leasing" ForeColor="Red" AutoPostBack="True"
									OnCheckedChanged="chk_leasing_CheckedChanged" Visible="false" />
							</td>
							<td style="font-size: x-small; font-family: Arial, Helvetica, sans-serif">
								<asp:Label ID="lbl_amicar" runat="server" Text="Financiamiento AMICAR" Visible="false"></asp:Label>
							</td>
							<td>
								<asp:DropDownList ID="dl_financiamiento" runat="server" Font-Names="Arial" Font-Size="X-Small"
									Height="16px" Width="90px" TabIndex="17" Style="font-family: Arial, Helvetica, sans-serif;
									font-size: x-small" Visible="false" OnSelectedIndexChanged="dl_financiamiento_SelectedIndexChanged">
									<asp:ListItem Text="seleccionar" Value="0" />
									<asp:ListItem Text="SI" Value="TRUE" />
									<asp:ListItem Text="NO" Value="FALSE" />
								</asp:DropDownList>
							</td>
							
						</tr>
                        <tr>
                            <td style="font-size: x-small; font-family: Arial, Helvetica, sans-serif">
								<asp:Label ID="lbl_t_transferencia" runat="server" Text="Tipo Transferencia" Visible="True"></asp:Label>
							</td>
                            <td>
                                <asp:DropDownList ID="dl_t_transferencia" runat="server" Font-Names="Arial" Font-Size="X-Small"
									Height="16px" Width="138px" TabIndex="26" Style="font-family: Arial, Helvetica, sans-serif;
									font-size: x-small" OnSelectedIndexChanged="dl_t_transferencia_SelectedIndexChanged">
								</asp:DropDownList>

                            </td>

                        </tr>

					</table>
				</asp:Panel>
				<asp:Panel ID="id_leasing" runat="server">
					<table>
						<tr>
							<td style="font-size: x-small; font-family: Arial, Helvetica, sans-serif">
								Nº Contrato
							</td>
							<td>
								<asp:TextBox ID="txt_n_contrato" runat="server" MaxLength="6" Style="font-size: x-small; font-family: Arial, Helvetica, sans-serif" Width="65px"></asp:TextBox>
								<ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txt_n_contrato" FilterType="Custom, Numbers" ValidChars="">
								</ajaxToolkit:FilteredTextBoxExtender>
							</td>
							<td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;" class="style30">
								Fecha Cesion
							</td>
							<td>
								<asp:TextBox ID="txt_fecha_contrato" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" Height="19px" Width="73px" TabIndex="7"></asp:TextBox>
								<ajaxToolkit:CalendarExtender runat="server" TargetControlID="txt_fecha_contrato" CssClass="calendario" Format="dd/MM/yyyy" PopupButtonID="ib_calendario" ID="CalendarExtender2" />
							</td>
							<td>
								<asp:ImageButton ID="ib_calendario" runat="server" ImageUrl="../imagenes/sistema/gif/calendario.gif" />
							</td>
							<td style="font-size: x-small; font-family: Arial, Helvetica, sans-serif">
								valor opcion
							</td>
							<td>
								<asp:TextBox ID="txt_valor_opcion" runat="server" MaxLength="10" Style="font-size: x-small; font-family: Arial, Helvetica, sans-serif" Width="65px" AutoPostBack="True" OnTextChanged="txt_valor_opcion_TextChanged"></asp:TextBox>
								<%--<ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txt_valor_opcion"
									FilterType="Custom, Numbers" ValidChars="">
								</ajaxToolkit:FilteredTextBoxExtender>--%>
							</td>
							<td style="font-size: x-small; font-family: Arial, Helvetica, sans-serif">
								valor cesion
							</td>
							<td>
								<asp:TextBox ID="txt_valor_cesion" runat="server" MaxLength="9" Style="font-size: x-small; font-family: Arial, Helvetica, sans-serif" AutoPostBack="True" OnTextChanged="txt_valor_cesion_TextChanged"></asp:TextBox>
								<%--<ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txt_valor_cesion"
									FilterType="Custom, Numbers" ValidChars="">
								</ajaxToolkit:FilteredTextBoxExtender>--%>
							</td>
							<td style="font-size: x-small; font-family: Arial, Helvetica, sans-serif">
								Nº Vehiculos
							</td>
							<td>
								<asp:TextBox ID="txt_n_vehiculos" runat="server" MaxLength="9" Style="font-size: x-small; font-family: Arial, Helvetica, sans-serif" AutoPostBack="True"></asp:TextBox>
								<%--<ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txt_valor_cesion"
									FilterType="Custom, Numbers" ValidChars="">
								</ajaxToolkit:FilteredTextBoxExtender>--%>
							</td>
							
							
						</tr>
					</table>
					<%--<agp:DatosVehiculo ID="agpVehiculo" runat="server" Titulo="DATOS VEHICULO" />--%>
					<table style="width: 189px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
						<tr>
							<td>
								&nbsp;</td>
						</tr>
					</table>
				</asp:Panel>
				<agp:DatosPersona ID="Datoscomprador" runat="server" Titulo="DATOS DEL COMPRADOR" HabilitarCompraPara="true" HabilitarParticipante="true" />
				<agp:DatosPersona ID="agpCompraPara" runat="server" Titulo="DATOS COMPRA PARA" HabilitarCompraPara="false" Visible="false" HabilitarParticipante="true" />
			
		
			
			
			
			
				<table>
					<tr>
						<td>
							<asp:Button ID="bt_guardar" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" Text="Guardar" OnClick="bt_guardar_Click" />
                            <asp:Button ID="bt_oculto_asignar" runat="server" Style="display: none;" />
							<%--<ajaxToolkit:ConfirmButtonExtender ID="bt_guardar_ConfirmButtonExtender" runat="server" TargetControlID="bt_prueba" ConfirmOnFormSubmit="True" ConfirmText="¿Esta seguro de ingresar un nuevo contrato de transferencia?">
							</ajaxToolkit:ConfirmButtonExtender>--%>
						</td>
						<td>
							<asp:Button ID="Button1" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" Text="Limpiar" Height="21px" Width="58px" OnClick="Button1_Click1" />
						</td>
					
						<td style="width: 721px; text-align: right">
							<asp:Label ID="lbl_operacion" runat="server" Font-Names="Arial" Font-Size="Small" ForeColor="#FF3300" Visible="False"></asp:Label>
							<asp:Label ID="lbl_numero" runat="server" Font-Names="Arial" Font-Size="Small" ForeColor="#FF3300" Visible="False"></asp:Label>
						</td>
                        <td>
                        <asp:ImageButton ID="ib_contrato" runat="server" ImageUrl="~/imagenes/sistema/static/poliza.jpg"
						Height="22px" Width="23px" Visible="false" OnClick="ib_contrato_Click" />
                        </td>
					</tr>
				</table>
			</td>
		</tr>
	</table>
	<asp:Panel ID="pnlPopUp" runat="server" CssClass="PopUp" Style="display: none;">
		<table>
			<tr>
				<td>
					<span style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; font-weight: bold">Codigo SII</span>
				</td>
				<td>
					<asp:TextBox ID="txt_sii" runat="server" MaxLength="10" Style="font-size: x-small; font-family: Arial, Helvetica, sans-serif"></asp:TextBox>
				</td>
				<td>
					<asp:ImageButton ID="ib_busca_sii" runat="server" ImageUrl="../imagenes/sistema/gif/lupa.gif" Height="22px" Width="23px" OnClick="ib_busca_sii_Click" />
				</td>
			</tr>
		</table>
		<table>
			<tr>
				<td>
					<asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Names="Arial" Font-Size="X-Small" ForeColor="#333333" GridLines="None" Width="456px" OnSelectedIndexChanged="gr_dato_SelectedIndexChanged" Visible="true">
						<RowStyle BackColor="#EFF3FB" />
						<Columns>
							<asp:CommandField SelectText="&lt;&lt;&gt;&gt;" ShowSelectButton="True" />
							<asp:BoundField AccessibleHeaderText="Marca" DataField="Marca" HeaderText="Marca" />
							<asp:BoundField AccessibleHeaderText="Modelo" DataField="modelo" HeaderText="Modelo" />
							<asp:BoundField AccessibleHeaderText="Puertas" DataField="puerta" HeaderText="Puertas" />
							<asp:BoundField AccessibleHeaderText="Cilindrada" DataField="Cilindrada" HeaderText="Cilindrada" />
							<asp:BoundField AccessibleHeaderText="Combustible" DataField="Combustible" HeaderText="Combustible" />
							<asp:BoundField AccessibleHeaderText="Transmision" DataField="Transmision" HeaderText="Transmision" />
							<asp:BoundField AccessibleHeaderText="Equipo" DataField="Equipo" HeaderText="Equipo" />
							<asp:BoundField AccessibleHeaderText="Tasacion" DataField="tasacion" HeaderText="Tasacion" />
							<asp:BoundField AccessibleHeaderText="Permiso" DataField="Permiso" HeaderText="Permiso" />
							<asp:BoundField AccessibleHeaderText="Año" DataField="Ano" HeaderText="Año" />
						</Columns>
						<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
						<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
						<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
						<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
						<EditRowStyle BackColor="#2461BF" />
						<AlternatingRowStyle BackColor="White" />
					</asp:GridView>
				</td>
			</tr>
		</table>
		<table>
			<tr>
				<td>
					<asp:Button ID="bt_salir" runat="server" Font-Names="Arial" Font-Size="X-Small" Text="Cancelar" />
				</td>
			</tr>
		</table>
	</asp:Panel>
	<ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender" runat="server" BackgroundCssClass="modalBackground2" DropShadow="false" PopupDragHandleControlID="pnlPopUp" PopupControlID="pnlPopUp" TargetControlID="ib_tasacion" CancelControlID="bt_salir" />
    <asp:Panel ID="pnlSeleccionarDatos" runat="server" Style="border-width: 1px; border-style: solid; background-color: #FFFFFF; position: inherit; width: 300px; height: 80px" Height="64px" Width="296px">
		<center style="background-color: #0066CC">
			<asp:Label ID="Label4" ForeColor="Blue" Font-Names="Arial, Helvetica, sans-serif" runat="server" Text="¿Esta seguro de ingresar esta operación?" Font-Size="Small" Style="color: #FFFFFF; font-weight: 700" />
		</center>
		<table style="width: 292px; height: 60px">
			<tr>
				<td align="center" style="background-color: #FFFFFF">
					<asp:button id="btnAceptar" runat="server" font-names="Arial" font-size="X-Small" OnClientClick="desactivarBoton()"
						text="Aceptar"/>
                
				</td>
				<td align="center" style="background-color: #FFFFFF">
					<asp:Button ID="btnCancelar" runat="server" Font-Names="Arial" Font-Size="X-Small" Text="Cancelar"  />
				</td>
			</tr>
		</table>
	</asp:Panel>
		<ajaxToolkit:modalpopupextender ID="mpeSeleccion" runat="server" 
		TargetControlID="bt_oculto_asignar" PopupControlID="pnlSeleccionarDatos" 
		CancelControlID="btnCancelar" 
		BackgroundCssClass="FondoAplicacion" />

</asp:Content>