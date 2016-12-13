<%@ Page Title="Poliza" Language="C#" MasterPageFile="~/Adm.Master" AutoEventWireup="true" CodeBehind="mPoliza.aspx.cs" Inherits="sistemaAGP.mPoliza" EnableSessionState="True" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<style type="text/css">
        .style10
        {
            width: 39px;
            height: 15px;
        }
        .style17
        {
            height: 10px;
            text-align: left;
        }
        .style18
        {
            height: 15px;
            width: 118px;
        }
        .style25
        {
            height: 25px;
            width: 111px;
        }
        .style30
        {
            text-align: left;
        }
        .style33
        {
            width: 44px;
        }
        .style34
        {
            text-align: left;
            width: 70px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<table bgcolor="#cccccc" style="width: 100%; height: 13px;">
		<tr>
			<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 1115px; color: #000000;">
				<b>INGRESO DE POLIZA</b>
			</td>
		</tr>
	</table>
	<table style="width: 60%">
		<tr>
			<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;" class="style10">
				NºPoliza
			</td>
			<td class="style18">
				<asp:TextBox ID="txt_npoliza" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="19px" Width="140px" TabIndex="1" ontextchanged="txt_npoliza_TextChanged" AutoPostBack="true"></asp:TextBox>
			</td>
			<td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
				Distribuidor Poliza
			</td>
			<td>
				<asp:DropDownList ID="dl_distribuidor_poliza" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="138px" TabIndex="2" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" OnSelectedIndexChanged="dl_distribuidor_poliza_SelectedIndexChanged" AutoPostBack="True">
				</asp:DropDownList>
			</td>
			<td style="width: 15px; text-align: right; font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 25px;">
				NºFolio Distribuidor
			</td>
			<td style="text-align: left;" class="style25">
				<asp:TextBox ID="txt_nfolio" runat="server" Font-Names="Arial" Font-Size="X-Small" MaxLength="30" Width="141px" TabIndex="3" Height="18px" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"></asp:TextBox>
			</td>
		</tr>
	</table>
	<table>
		<tr>
			<td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;" class="style30">
				Vigencia Desde
			</td>
			<td>
				<asp:TextBox ID="txt_fechadesde" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" Height="19px" Width="73px" OnTextChanged="txt_fechadesde_TextChanged" AutoPostBack="true"></asp:TextBox>
				<cc1:CalendarExtender runat="server" TargetControlID="txt_fechadesde" CssClass="calendario" Format="dd/MM/yyyy" PopupButtonID="ib_calendario" ID="CalendarExtender2" />
			</td>
			<td>
				<asp:ImageButton ID="ib_calendario" runat="server" ImageUrl="../imagenes/sistema/gif/calendario.gif" OnClick="ib_calendario_Click" TabIndex="4" />
			</td>
			<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;" class="style34">
				Vigencia Hasta
			</td>
			<td>
				<asp:TextBox ID="txt_fecha_hasta" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" Height="19px" Width="73px" OnTextChanged="txt_fecha_hasta_TextChanged"  Enabled="true"></asp:TextBox>
				<cc1:CalendarExtender runat="server" TargetControlID="txt_fecha_hasta" CssClass="calendario" Format="dd/MM/yyyy" PopupButtonID="ib_calendario2" ID="CalendarExtender1" />
			</td>
			<td>
				<asp:ImageButton ID="ib_calendario2" runat="server" ImageUrl="../imagenes/sistema/gif/calendario.gif" OnClick="ib_calendario_Click" TabIndex="4" />
			</td>
                <%--<cc1:CalendarExtender runat="server" TargetControlID="txt_fecha_hasta" CssClass="calendario" Format="dd/MM/yyyy" PopupButtonID="ib_calendario0" ID="txt_fecha_hasta_CalendarExtender" />--%>
			</td>
			<td>
				<%--<asp:ImageButton ID="ib_calendario0" runat="server" ImageUrl="../imagenes/sistema/gif/calendario.gif" OnClick="ib_calendario0_Click" Style="height: 14px" TabIndex="5" />--%>
			</td>
			<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;" class="style17">
				Prima
			</td>
			<td style="text-align: left; width: 20px; height: 10px;">
				<asp:TextBox ID="txt_prima" runat="server" Font-Names="Arial" 
                    Font-Size="X-Small" MaxLength="10" Width="88px" TabIndex="6" Height="16px" 
                    Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" 
                    OnTextChanged="txt_ncuotas_TextChanged" Enabled="False"></asp:TextBox>
			</td>
		</tr>
	</table>
	<table>
		<tr>
			<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;" class="style17">
				URL Poliza
			</td>
			<td style="text-align: left; width: 20px; height: 10px;">
				<asp:TextBox ID="txt_url" runat="server" Font-Names="Arial" Font-Size="X-Small" MaxLength="1000" Width="381px" TabIndex="7" Height="18px" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" OnTextChanged="txt_url_TextChanged"></asp:TextBox>
			</td>
		</tr>
	</table>
	<table>
		<tr>
			<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;" class="style10">
				Precio Piso
			</td>
			<td class="style18">
				<asp:TextBox ID="txtPpiso" runat="server" 
                    Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" 
                    Height="19px" Width="72px" TabIndex="8" OnTextChanged="txtPpiso_TextChanged" 
                    Enabled="False"></asp:TextBox>
			</td>
			<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;" class="style10">
				Precio AGP
			</td>
			<td class="style18">
				<asp:TextBox ID="txtPagp" runat="server" 
                    Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" 
                    Height="19px" Width="72px" TabIndex="9" OnTextChanged="txtPagp_TextChanged" 
                    Enabled="False"></asp:TextBox>
			</td>
			<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;" class="style10">
				Precio Cliente
			</td>
			<td class="style18">
				<asp:TextBox ID="txtPcliente" runat="server" 
                    Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" 
                    Height="19px" Width="72px" TabIndex="10" 
                    OnTextChanged="txtPcliente_TextChanged" Enabled="False"></asp:TextBox>
			</td>
		</tr>
	</table>
	<table>
		<asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="id_solicitud, id_poliza, poliza_nula, url_poliza" Font-Names="Arial" Font-Size="X-Small" ForeColor="#333333" GridLines="None" OnRowDeleting="gr_dato_RowDeleting" EnableModelValidation="True" OnRowDataBound="gr_dato_RowDataBound">
			<RowStyle BackColor="#EFF3FB" />
			<Columns>
				<asp:BoundField AccessibleHeaderText="Id.Poliza" DataField="id_poliza" FooterText="Id.Poliza" HeaderText="Id.Poliza" />
				<asp:BoundField AccessibleHeaderText="Distribuidor Poliza" DataField="distribuidor_poliza" HeaderText="Distribuidor Poliza" />
				<asp:BoundField AccessibleHeaderText="Nº poliza" DataField="npoliza" HeaderText="Nº poliza" />
				<asp:BoundField AccessibleHeaderText="Nº Folio Distribuidor" DataField="nfolio" HeaderText="Nº Folio Distribuidor" />
				<asp:BoundField AccessibleHeaderText="Vigencia Desde" DataField="vigencia_desde" HeaderText="Vigencia Desde" />
				<asp:BoundField AccessibleHeaderText="Vigencia Hasta" DataField="vigencia_hasta" HeaderText="Vigencia Hasta" />
				<asp:BoundField AccessibleHeaderText="Precio Piso" DataField="ppiso" HeaderText="Precio Piso" />
				<asp:BoundField AccessibleHeaderText="Precio AGP" DataField="pagp" HeaderText="Precio AGP" />
				<asp:BoundField AccessibleHeaderText="Precio Cliente" DataField="pcliente" HeaderText="Precio Cliente" />
				<asp:BoundField AccessibleHeaderText="Total" DataField="total" HeaderText="Total" />
				<asp:TemplateField AccessibleHeaderText="Poliza" HeaderText="Poliza">
					<ItemTemplate>
						<asp:ImageButton ID="ib_poliza" runat="server" ImageUrl="../imagenes/sistema/static/pdf.jpg" />
					</ItemTemplate>
					<ControlStyle Height="25px" Width="25px" />
				</asp:TemplateField>
				<asp:BoundField AccessibleHeaderText="Nula" DataField="poliza_nula" HeaderText="Nula" />
				<asp:TemplateField ShowHeader="False">
					<ItemTemplate>
						<asp:Button ID="btn_eliminar" runat="server" CausesValidation="False" Visible="false" CommandName="Delete" Text="Anular" />
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
	</table>
	<table bgcolor="cccccc" style="width: 17%">
		<tr>
			<td style="text-align: center;" class="style33">
				<asp:Button ID="bt_guardar" runat="server" Font-Names="Arial" Font-Size="X-Small" Text="Guardar" TabIndex="53" OnClick="bt_guardar_Click" />
			</td>
			<td style="width: 42px">
				<asp:Button ID="btn_solicitar" runat="server" Font-Names="Arial" Font-Size="X-Small" Text="Solicitar" TabIndex="54" OnClick="Button2_Click" Enabled="False" />
				<cc1:ConfirmButtonExtender ID="confirm_solicitar_adquirir" runat="server" ConfirmText="¿Desea adquirir una poliza en linea?" TargetControlID="btn_solicitar"></cc1:ConfirmButtonExtender>
			</td>
		</tr>
	</table>
	<%--
             <cc1:ModalPopupExtender ID="mpeSeleccion" runat="server" TargetControlID="bt_guardar"
                PopupControlID="pnlSeleccionarDatos"  CancelControlID="btnCancelar"
                DropShadow="True"
                BackgroundCssClass="FondoAplicacion" />
	--%>
</asp:Content>