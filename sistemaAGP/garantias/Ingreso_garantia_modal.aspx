<%@ Page Title="" Language="C#" MasterPageFile="~/Adm.Master" AutoEventWireup="true" CodeBehind="Ingreso_garantia_modal.aspx.cs" Inherits="sistemaAGP.Ingreso_garantia_modal" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/controles/wucVehiculo.ascx" TagName="DatosVehiculo" TagPrefix="agp" %>
<%@ Register Src="~/controles/wucPersona.ascx" TagName="DatosPersona" TagPrefix="agp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div style="width: 789px;">
		<table style="background-color: #669999; width: 100%">
			<tr>
				<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 1115px; color: #FFFFFF;">
					<strong>INGRESO DE GARANTIA -
						<asp:Label ID="lblTitulo" runat="server" Text=""></asp:Label></strong>
				</td>
			</tr>
		</table>



		<table>
			<tr>
				<td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
					Cliente
				</td>
				<td>
					<asp:DropDownList ID="dl_cliente" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 16px; width: 138px;" AutoPostBack="True" OnSelectedIndexChanged="dl_cliente_SelectedIndexChanged">
					</asp:DropDownList>
				</td>
				<td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
					Sucursal
				</td>
				<td>
					<asp:DropDownList ID="dl_sucursal" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 16px; width: 138px;">
					</asp:DropDownList>
				</td>
			</tr>
		</table>
		<agp:DatosPersona ID="agpEmisor" runat="server" Titulo="DATOS EMISOR" HabilitarCompraPara="false" HabilitarCorreo="false" HabilitarDireccion="false" HabilitarTelefono="false" />
		<table style="background-color: #669999; width: 100%">
			<tr>
				<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #FFFFFF;">
					<strong>DATOS FACTURA</strong>
				</td>
			</tr>
		</table>
		<table>
			<tr>
				<td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
					Nº Factura
				</td>
				<td>
					<asp:TextBox ID="txt_factura" runat="server" MaxLength="8" AutoPostBack="True" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 16px; width: 98px; background-color: #0099ff; color: #ffffff;" OnTextChanged="txt_factura_TextChanged"></asp:TextBox>
					<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender_factura" runat="server" TargetControlID="txt_factura" FilterType="Custom, Numbers" ValidChars="">
					</cc1:FilteredTextBoxExtender>
				</td>
				<td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
					Fecha Facturacion
				</td>
				<td>
					<asp:TextBox ID="txt_fecha_factura" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 16px; width: 73px;" Enabled="False" ForeColor="#333333" Font-Bold="True"></asp:TextBox>
				</td>
				<td>
					<asp:ImageButton ID="ib_calendario" runat="server" ImageUrl="../imagenes/sistema/gif/calendario.gif" />
					<cc1:CalendarExtender runat="server" TargetControlID="txt_fecha_factura" CssClass="calendario" Format="dd/MM/yyyy" PopupButtonID="ib_calendario" ID="cal_fecha_factura" />
				</td>
				<td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
					Neto Factura
				</td>
				<td>
					<asp:TextBox ID="txt_neto" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 104px; height: 16px; background-color: #3399ff; color: #ffffff;" OnTextChanged="txt_neto_TextChanged" AutoPostBack="true"></asp:TextBox>
					<cc1:FilteredTextBoxExtender ID="txt_neto_FilteredTextBoxExtender" runat="server" TargetControlID="txt_neto" FilterType="Custom, Numbers" ValidChars="">
					</cc1:FilteredTextBoxExtender>
				</td>
			</tr>
		</table>
		<agp:DatosVehiculo ID="agpVehiculo" runat="server" Titulo="DATOS VEHICULO" HabilitarCAV="true" />
		<table style="background-color: #669999; width: 100%">
			<tr>
				<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #FFFFFF;">
					<strong>DATOS DEL CREDITO</strong>
				</td>
			</tr>
		</table>
		<table>
			<tr>
				<td style="width: 75px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
					Forma de Pago
				</td>
				<td>
					<asp:DropDownList ID="dl_forma_pago" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 138px; height: 16px;" OnSelectedIndexChanged="dl_forma_pago_SelectedIndexChanged">
					</asp:DropDownList>
				</td>
				<td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
					Total Factura/Valor Vehículo
				</td>
				<td>
					<asp:TextBox ID="txt_total" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 104px; height: 16px; background-color: #3399ff; color: #ffffff;" OnTextChanged="txt_total_TextChanged" AutoPostBack="true"></asp:TextBox>
					<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txt_neto" FilterType="Custom, Numbers" ValidChars="">
					</cc1:FilteredTextBoxExtender>
				</td>
			</tr>
		</table>
		<table>
			<tr>
				<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
					Monto Pie
				</td>
				<td>
					<asp:TextBox ID="txt_pie" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; margin-left: 8px; width: 100px; height: 16px;" MaxLength="10" OnTextChanged="txt_pie_TextChanged" AutoPostBack="true"></asp:TextBox>
					<cc1:FilteredTextBoxExtender ID="filter_pie" runat="server" TargetControlID="txt_pie" FilterType="Custom, Numbers" ValidChars="">
					</cc1:FilteredTextBoxExtender>
				</td>
				<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
					N°Cheques/Cuotas
				</td>
				<td>
					<asp:TextBox ID="txt_cheques" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; margin-left: 8px; width: 33px;" MaxLength="2" OnTextChanged="txt_cheques_TextChanged" AutoPostBack="true"></asp:TextBox>
					<cc1:FilteredTextBoxExtender ID="filter_cheques" runat="server" TargetControlID="txt_cheques" FilterType="Custom, Numbers" ValidChars="">
					</cc1:FilteredTextBoxExtender>
				</td>
				<td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
					Fecha Primera Cuota
				</td>
				<td>
					<asp:TextBox ID="txt_primera" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 16px; width: 73px;" OnTextChanged="txt_primera_TextChanged" AutoPostBack="true" Enabled="true" ForeColor="#333333" Font-Bold="True"></asp:TextBox>
				</td>
				<td>
					<asp:ImageButton ID="ib_primera" runat="server" ImageUrl="../imagenes/sistema/gif/calendario.gif" />
					<cc1:CalendarExtender ID="cal_primera" runat="server" TargetControlID="txt_primera" CssClass="calendario" Format="dd/MM/yyyy" PopupButtonID="ib_primera" />
				</td>
				<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
					Fecha Ultima Cuota
				</td>
				<td>
					<asp:TextBox ID="txt_ultima" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 16px; width: 73px;" Enabled="False" ForeColor="#333333" Font-Bold="True"></asp:TextBox>
				</td>
				<td>
					<asp:ImageButton ID="ib_ultima" runat="server" ImageUrl="../imagenes/sistema/gif/calendario.gif" />
					<cc1:CalendarExtender ID="cal_ultima" runat="server" TargetControlID="txt_ultima" CssClass="calendario" Format="dd/MM/yyyy" PopupButtonID="ib_ultima" />
				</td>
				<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
					<asp:Label ID="lbl_Repertorio" runat="server" Text="Nº Repertorio" Visible="false" />
				</td>
				<td>
					<asp:TextBox ID="txt_Repertorio" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 16px; width: 100px;" Visible="False"></asp:TextBox>
					<cc1:FilteredTextBoxExtender ID="filter_Repertorio" runat="server" TargetControlID="txt_Repertorio" FilterType="Custom, Numbers" ValidChars="">
					</cc1:FilteredTextBoxExtender>
				</td>
			</tr>
		</table>
		<table>
			<tr>
				<td style="width: 100px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
					Nº Factura Intereses
				</td>
				<td>
					<asp:TextBox ID="txtFacturaIntereses" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; margin-left: 8px; width: 100px; height: 16px;" MaxLength="10"></asp:TextBox>
					<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtFacturaIntereses" FilterType="Custom, Numbers" ValidChars="">
					</cc1:FilteredTextBoxExtender>
				</td>
				<td style="width: 100px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
					Fecha Factura Intereses
				</td>
				<td>
					<asp:TextBox ID="txtFechaFacturaIntereses" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 16px; width: 73px;" Enabled="False" ForeColor="#333333" Font-Bold="True"></asp:TextBox>
				</td>
				<td>
					<asp:ImageButton ID="btnFechaFacturaIntereses" runat="server" ImageUrl="../imagenes/sistema/gif/calendario.gif" />
					<cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFechaFacturaIntereses" CssClass="calendario" Format="dd/MM/yyyy" PopupButtonID="btnFechaFacturaIntereses" />
				</td>
				<td style="width: 100px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
					Monto Factura Intereses
				</td>
				<td>
					<asp:TextBox ID="txtMontoFacturaIntereses" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; margin-left: 8px; width: 100px; height: 16px;" MaxLength="10" OnTextChanged="txtMontoFacturaIntereses_TextChanged" AutoPostBack="true"></asp:TextBox>
					<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtMontoFacturaIntereses" FilterType="Custom, Numbers" ValidChars="">
					</cc1:FilteredTextBoxExtender>
				</td>
				<td style="width: 100px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
					Monto a financiar
				</td>
				<td>
					<asp:TextBox ID="txtMontoFinanciar" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; margin-left: 8px; width: 100px; height: 16px;" MaxLength="10"></asp:TextBox>
					<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="txtMontoFinanciar" FilterType="Custom, Numbers" ValidChars="">
					</cc1:FilteredTextBoxExtender>
				</td>
			</tr>
		</table>
		<table>
			<tr>
				<td style="width: 100px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
					Nº Factura Gastos Administrativos
				</td>
				<td>
					<asp:TextBox ID="txtFacturaGastos" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; margin-left: 8px; width: 100px; height: 16px;" MaxLength="10"></asp:TextBox>
					<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" TargetControlID="txtFacturaGastos" FilterType="Custom, Numbers" ValidChars="">
					</cc1:FilteredTextBoxExtender>
				</td>
				<td style="width: 100px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
					Fecha Factura Gastos Administrativos
				</td>
				<td>
					<asp:TextBox ID="txtFechaFacturaGastos" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 16px; width: 73px;" Enabled="False" ForeColor="#333333" Font-Bold="True"></asp:TextBox>
				</td>
				<td>
					<asp:ImageButton ID="btnFechaFacturaGastos" runat="server" ImageUrl="../imagenes/sistema/gif/calendario.gif" />
					<cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtFechaFacturaGastos" CssClass="calendario" Format="dd/MM/yyyy" PopupButtonID="btnFechaFacturaGastos" />
				</td>
				<td style="width: 100px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
					Monto Factura Gastos Administrativos
				</td>
				<td>
					<asp:TextBox ID="txtMontoFacturaGastos" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; margin-left: 8px; width: 100px; height: 16px;" MaxLength="10" OnTextChanged="txtMontoFacturaIntereses_TextChanged" AutoPostBack="true"></asp:TextBox>
					<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" TargetControlID="txtMontoFacturaGastos" FilterType="Custom, Numbers" ValidChars="">
					</cc1:FilteredTextBoxExtender>
				</td>
			</tr>
		</table>
		<asp:Panel ID="pnlInfoCheques" runat="server" Visible="false">
			<table>
				<tr>
					<td style="width: 30px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
						Banco
					</td>
					<td>
						<asp:DropDownList ID="dl_financiera" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 138px; height: 16px;" OnSelectedIndexChanged="dl_financiera_SelectedIndexChanged">
						</asp:DropDownList>
					</td>
					<td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
						N° Cta.Corriente
					</td>
					<td>
						<asp:TextBox ID="txt_cta_corriente" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 100px; height: 16px;"></asp:TextBox>
					</td>
					<td style="width: 71px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
						Nombre Titular
					</td>
					<td>
						<asp:TextBox ID="txt_titular" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 264px; height: 16px;"></asp:TextBox>
					</td>
				</tr>
			</table>
			<asp:GridView ID="gr_cheques" runat="server" AutoGenerateColumns="False" ShowFooter="true" CellPadding="4" Font-Names="Arial" Font-Size="X-Small" ForeColor="#333333" GridLines="None" OnRowCommand="gr_cheques_RowCommand" OnRowDataBound="gr_cheques_RowDataBound">
				<Columns>
					<asp:BoundField HeaderText="Nº Cuota" DataField="nro_cuota" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Right" />
					<asp:TemplateField HeaderText="Nº Cheque" ItemStyle-Width="150px">
						<ItemTemplate>
							<asp:TextBox ID="txt_nro_cheque" runat="server" Text='<%# Bind("nro_cheque") %>' Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 80px; height: 16px;"></asp:TextBox>
							<cc1:FilteredTextBoxExtender ID="filter_nro_cheque" runat="server" TargetControlID="txt_nro_cheque" FilterType="Custom, Numbers" ValidChars="">
							</cc1:FilteredTextBoxExtender>
							<asp:ImageButton ID="btn_nro_cheque" runat="server" ImageUrl="~/imagenes/sistema/static/FillDownHS.png" CommandName="FillDownNro" />
							<cc1:ConfirmButtonExtender ID="cbe_nro_cheques" runat="server" ConfirmText="¿Los cheques siguientes son correlativos?" TargetControlID="btn_nro_cheque">
							</cc1:ConfirmButtonExtender>
						</ItemTemplate>
					</asp:TemplateField>
					<asp:TemplateField HeaderText="Fecha" ItemStyle-Width="150px">
						<ItemTemplate>
							<asp:TextBox ID="txt_fecha_cheque" runat="server" Text='<%# Bind("fecha_cheque") %>' Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 16px; width: 73px;"></asp:TextBox>
							<asp:ImageButton ID="ibt_fecha_cheque" runat="server" ImageUrl="../imagenes/sistema/gif/calendario.gif" />
							<cc1:CalendarExtender ID="cal_fecha_cheque" runat="server" TargetControlID="txt_fecha_cheque" CssClass="calendario" Format="dd/MM/yyyy" PopupButtonID="ibt_fecha_cheque" />
							<asp:ImageButton ID="btn_fecha_cheque" runat="server" ImageUrl="~/imagenes/sistema/static/FillDownHS.png" CommandName="FillDownFecha" />
							<cc1:ConfirmButtonExtender ID="cbe_fecha_cheques" runat="server" ConfirmText="¿Los cheques siguientes tienen fechas correlativas?" TargetControlID="btn_fecha_cheque">
							</cc1:ConfirmButtonExtender>
						</ItemTemplate>
					</asp:TemplateField>
					<asp:TemplateField HeaderText="Monto" ItemStyle-Width="120px">
						<ItemTemplate>
							<asp:TextBox ID="txt_monto_cheque" runat="server" Text='<%# Bind("monto_cheque") %>' AutoPostBack="true" OnTextChanged="txt_monto_cheque_TextChanged" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 80px; height: 16px;"></asp:TextBox>
							<cc1:FilteredTextBoxExtender ID="filter_monto_cheque" runat="server" TargetControlID="txt_monto_cheque" FilterType="Custom, Numbers" ValidChars="">
							</cc1:FilteredTextBoxExtender>
							<asp:ImageButton ID="btn_monto_cheque" runat="server" ImageUrl="~/imagenes/sistema/static/FillDownHS.png" CommandName="FillDownMonto" />
							<cc1:ConfirmButtonExtender ID="cbe_monto_cheques" runat="server" ConfirmText="¿Los cheques siguientes tienen el mismo monto?" TargetControlID="btn_monto_cheque">
							</cc1:ConfirmButtonExtender>
						</ItemTemplate>
						<FooterTemplate>
							<asp:TextBox ID="txt_total_monto_cheque" runat="server" Text="" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 80px; height: 16px;"></asp:TextBox>
						</FooterTemplate>
					</asp:TemplateField>
				</Columns>
				<RowStyle BackColor="#EFF3FB" VerticalAlign="Middle" HorizontalAlign="Center" />
				<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
				<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
				<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
				<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
				<EditRowStyle BackColor="#2461BF" />
				<AlternatingRowStyle BackColor="White" />
			</asp:GridView>
		</asp:Panel>


	

		<asp:Panel ID="pnlGestionPrenda" runat="server" Width="790px">
			<table style="background-color: #669999; width: 100%">
				<tr>
					<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #FFFFFF;">
						<strong>
							<asp:Label ID="lbl_nomEstadoAnt" runat="server" Text="ESTADO ANTERIOR:" Visible="False"></asp:Label>
							<asp:Label ID="lbl_nombreEstado" runat="server" Visible="False" />
						</strong>
					</td>
					<td>
					</td>
					<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #FFFFFF;">
						<strong>
							<asp:Label ID="lbl_fecUltimoEstado" runat="server" Text="FECHA ULTIMO ESTADO :" Visible="False"></asp:Label>
							<asp:Label ID="lbl_fechaUltimoEstado" runat="server" Visible="False"></asp:Label>
						</strong>
					</td>
				</tr>
			</table>
			<table>
				<tr>
					<td style="width: 34px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
						<asp:Label ID="lbl_notario" runat="server" Text="Notario" Visible="False"></asp:Label>
					</td>
					<td style="margin-left: 40px">
						<asp:TextBox ID="txt_notario" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 16px; width: 225px;" Visible="False"></asp:TextBox>
					</td>
					<td style="width: 71px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
						<asp:Label ID="lbl_ciudadNotario" runat="server" Text="Ciudad Notario" Visible="False"></asp:Label>
					</td>
					<td>
						<asp:TextBox ID="txt_Ciudad" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 16px; width: 225px;" Visible="False"></asp:TextBox>
					</td>
				</tr>
			</table>
			<table>
				<tr>
					<td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
						<asp:Label ID="lbl_fecProtocolizacion" runat="server" Text="Fecha Protocolización" Visible="False"></asp:Label>
					</td>
					<td>
						<asp:TextBox ID="txt_fecProtocolizacion" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 16px; width: 73px;" OnTextChanged="txt_protocolizacion_TextChanged" AutoPostBack="true" Enabled="False" ForeColor="#333333" Visible="False" Font-Bold="True"></asp:TextBox>
					</td>
					<td>
						<asp:ImageButton ID="img_calFechaProtocolizacion" runat="server" ImageUrl="../imagenes/sistema/gif/calendario.gif" Visible="False" />
					</td>
					<td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
						<asp:Label ID="lbl_numProtocolizacion" runat="server" Text="Nº Protocolización" Visible="False"></asp:Label>
					</td>
					<td>
						<asp:TextBox ID="txt_numProtocolizacion" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 16px; width: 73px;" OnTextChanged="txt_protocolizacion_TextChanged" AutoPostBack="true" Visible="False"></asp:TextBox>
						<cc1:FilteredTextBoxExtender ID="filter_numProtocolizacion" runat="server" TargetControlID="txt_numProtocolizacion" FilterType="Custom, Numbers" ValidChars="">
						</cc1:FilteredTextBoxExtender>
					</td>
					<td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
						<asp:Label ID="lbl_numRepertorioNotaria" runat="server" Text="Nº Repertorio Notaria" Visible="False"></asp:Label>
					</td>
					<td>
						<asp:TextBox ID="txt_numRepertorioNotaria" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 16px; width: 73px;" OnTextChanged="txt_protocolizacion_TextChanged" AutoPostBack="true" Visible="False"></asp:TextBox>
						<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" TargetControlID="txt_numRepertorioNotaria" FilterType="Custom, Numbers" ValidChars="">
						</cc1:FilteredTextBoxExtender>
					</td>
				</tr>
				<tr>
					<td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
						<asp:Label ID="lbl_numRepertorioRNP" runat="server" Text="Nº Repertorio RNP" Visible="False"></asp:Label>
					</td>
					<td>
						<asp:TextBox ID="txt_numRepertorioRNP" runat="server" Visible="False" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 16px; width: 73px;"></asp:TextBox>
						<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server" TargetControlID="txt_numRepertorioRNP" FilterType="Custom, Numbers" ValidChars="">
						</cc1:FilteredTextBoxExtender>
					</td>
					<td style="width: 50px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
						<asp:Label ID="lbl_fechaContrato" runat="server" Text="Fecha Contrato" Visible="False"></asp:Label>
					</td>
					<td>
						<asp:TextBox ID="txt_fecha_contrato" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 16px; width: 73px;" Enabled="False" Font-Bold="True" ForeColor="#333333" Visible="False"></asp:TextBox>
					</td>
					<td>
						<asp:ImageButton ID="ib_contrato" runat="server" ImageUrl="../imagenes/sistema/gif/calendario.gif" Visible="False" />
						<cc1:CalendarExtender ID="cal_contrato" runat="server" TargetControlID="txt_fecha_contrato" CssClass="calendario" Format="dd/MM/yyyy" PopupButtonID="ib_contrato" />
					</td>
				</tr>
			</table>
		</asp:Panel>
		<asp:Panel ID="pnlAlzammiento4702" runat="server">
			<table>
				<tr>
					<td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
						<asp:Label ID="lbl_fechaRepertorio" runat="server" Text="Fecha Repertorio" Visible="False"></asp:Label>
					</td>
					<td>
						<asp:TextBox ID="txt_fechaRepertorio" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 16px; width: 73px;" Visible="False" Enabled="False" Font-Bold="True" ForeColor="#333333"></asp:TextBox>
					</td>
					<td>
						<asp:ImageButton ID="img_fecRepertorio" runat="server" ImageUrl="../imagenes/sistema/gif/calendario.gif" OnClick="img_fecRepertorio_Click" Visible="False" />
						<cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txt_fechaRepertorio" CssClass="calendario" Format="dd/MM/yyyy" PopupButtonID="img_fecRepertorio" />
					</td>
					<td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
						<asp:Label ID="lbl_ofRegistro" runat="server" Text="Oficina Registro" Visible="False"></asp:Label>
					</td>
					<td>
						<asp:TextBox ID="txt_oficinaRegistro" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 16px;" Visible="False"></asp:TextBox>
					</td>
					<td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
						<asp:Label ID="lbl_ingAlzaPNreg" runat="server" Text="Ingreso Alza PN Registro" Visible="False"></asp:Label>
					</td>
					<td>
						<asp:TextBox ID="txt_ingAlzaPN" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 16px; width: 73px;" Visible="False"></asp:TextBox>
						<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server" TargetControlID="txt_ingAlzaPN" FilterType="Custom, Numbers" ValidChars="">
						</cc1:FilteredTextBoxExtender>
					</td>
				</tr>
				<tr>
					<td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
						<asp:Label ID="lbl_ingAlzaPHreg" runat="server" Text="Ingreso Alza PH Registro" Visible="False"></asp:Label>
					</td>
					<td>
						<asp:TextBox ID="txt_ingAlzaPH" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 16px; width: 73px;" Visible="False"></asp:TextBox>
						<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server" TargetControlID="txt_ingAlzaPH" FilterType="Custom, Numbers" ValidChars="">
						</cc1:FilteredTextBoxExtender>
					</td>
					<td>
					</td>
					<td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
						<asp:Label ID="lbl_numSolPNreg" runat="server" Text="Nº Solicitud PN Registro" Visible="False"></asp:Label>
					</td>
					<td>
						<asp:TextBox ID="txt_solRegistroPN" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;" Visible="False" Height="16px"></asp:TextBox>
						<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" runat="server" TargetControlID="txt_solRegistroPN" FilterType="Custom, Numbers" ValidChars="">
						</cc1:FilteredTextBoxExtender>
					</td>
					<td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
						<asp:Label ID="lbl_numSolPHreg" runat="server" Text="Nº Solicitud PH Registro" Visible="False"></asp:Label>
					</td>
					<td>
						<asp:TextBox ID="txt_solRegistroPH" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 16px; width: 73px;" Visible="False"></asp:TextBox>
						<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender12" runat="server" TargetControlID="txt_solRegistroPH" FilterType="Custom, Numbers" ValidChars="">
						</cc1:FilteredTextBoxExtender>
					</td>
                </tr>
			</table>
           <%-- <asp:Panel ID="Panel1" runat="server"> --%>
            <table>
                <tr>
                    <td colspan="2">
                     Observaciones
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txt_observaciones" runat="server" TextMode="MultiLine" Width="100%" Rows="4"></asp:TextBox>
                    </td>
                </tr>
            </table>

			<agp:DatosPersona ID="agpAdquirente" runat="server" Titulo="DATOS ADQUIRENTE" HabilitarCompraPara="true" HabilitarParticipante="true" />
			<agp:DatosPersona ID="agpCompraPara" runat="server" Titulo="DATOS COMPRA PARA" HabilitarParticipante="true" Visible="false" />
			<table style="background-color: #ffffff; width: 100%">
				<tr>
					<td style="text-align: center; width: 38px;">
						<asp:Button ID="bt_guardar" runat="server" Font-Names="Arial" Font-Size="X-Small" Text="Guardar" OnClick="bt_guardar_Click" />
					</td>
					<td style="width: 42px">
						<asp:Button ID="bt_limpiar" runat="server" Font-Names="Arial" Font-Size="X-Small" Text="Limpiar" OnClick="bt_limpiar_Click" />
					</td>
					<td style="text-align: right">
						<asp:Label ID="lbl_operacion" runat="server" Font-Names="Arial" Font-Size="Small" ForeColor="#FF3300" Visible="False"></asp:Label>
						<asp:Label ID="lbl_numero" runat="server" Font-Names="Arial" Font-Size="Small" ForeColor="#FF3300" Visible="False"></asp:Label>
					</td>
				</tr>
			</table>
		</asp:Panel>
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