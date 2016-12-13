<%@ Page Title="Ingreso de Multas de vehiculos motorizados" Language="C#" MasterPageFile="~/Adm.Master" AutoEventWireup="true" CodeBehind="mInfraccion.aspx.cs" Inherits="sistemaAGP.mInfraccion" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/controles/wucPersona.ascx" TagName="DatosPersona" TagPrefix="agp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<style type="text/css">
        .style4
        {
            width: 89px;
            height: 26px;
        }
        .style5
        {
            height: 26px;
        }
        .style6
        {
            width: 15px;
            height: 26px;
        }
        .style7
        {
            width: 32px;
            height: 26px;
        }
        .style8
        {
            width: 821px;
        }
        .style9
        {
            width: 1112px;
        }
        .style10
        {
            width: 38px;
            height: 29px;
        }
        .style11
        {
            width: 42px;
            height: 29px;
        }
        .style12
        {
            height: 29px;
        }
        .style13
        {
            width: 930px;
            height: 16px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<table bgcolor="#669999" style="width: 100%; height: 14px;">
		<tr>
			<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #FFFFFF;" class="style9">
				<strong>INGRESO DE INFRACCIONES -
					<asp:Label ID="lbl_titulo" runat="server" Text=""></asp:Label></strong>
			</td>
		</tr>
	</table>
	<table style="width: 60%">
		<tr>
			<td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
				Cliente
			</td>
			<td>
				<asp:DropDownList ID="dl_cliente" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="138px" TabIndex="1" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" AutoPostBack="True" OnSelectedIndexChanged="dl_cliente_SelectedIndexChanged">
				</asp:DropDownList>
			</td>
			<td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
				Patente
			</td>
			<td>
				<asp:TextBox ID="txt_patente" runat="server" Width="88px" MaxLength="6" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" AutoPostBack="true" OnTextChanged="txt_patente_Leave" BackColor="#3399FF" ForeColor="White" TabIndex="3"></asp:TextBox>
				<asp:TextBox ID="txt_dv_patente" runat="server" Width="16px" MaxLength="1" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" BackColor="#3399FF" ForeColor="White" TabIndex="3"></asp:TextBox>
			</td>
			<td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
				Sucursal Origen
			</td>
			<td>
				<asp:DropDownList ID="dl_sucursal_origen" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="138px" TabIndex="17" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" OnSelectedIndexChanged="dl_sucursal_origen_SelectedIndexChanged">
				</asp:DropDownList>
			</td>
		</tr>
	</table>
	<agp:DatosPersona ID="agpInfractor" runat="server" Titulo="DATOS INFRACTOR" HabilitarCompraPara="False" />
	<%--  <table  bgcolor="#669999" style="width: 100%; height: 18px;">
                <tr>
                    <td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #FFFFFF;" 
                        class="style8">
                        <b>DATOS DEL INFRACTOR</b></td>
                </tr>
            </table>
            <table style="width: 773px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
                <tr>
                <td style="width: 20px; text-align: right; font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 25px;">
                             Rut</td>
                   
                          
                        <td style="width: 167px; text-align: center; height: 18px;">
                            <asp:TextBox ID="txt_rut"  runat="server" Font-Names="Arial" 
                                    Font-Size="X-Small" MaxLength="8" TabIndex="27" AutoPostBack="True" 
                                ontextchanged="txt_rut_Leave" BackColor="#0099FF" ForeColor="White" 
                                style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" 
                                Height="16px" Width="98px" 
                                                     ></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="txt_rut_FilteredTextBoxExtender" 
                        runat="server" TargetControlID="txt_rut"
                        FilterType="Custom, Numbers"
                        ValidChars="">
                            </cc1:FilteredTextBoxExtender>
                    </td>
                    <td>
                        <asp:Button ID="bt_limpia_persona" runat="server" BackColor="White" 
                                Height="16px" Width="16px" onclick="bt_limpia_persona_Click" />
                    </td>
                    
                    <td style="text-align: left; height: 25px; width: 1px;">
                        <asp:TextBox ID="txt_dv" runat="server" Font-Names="Arial" 
                                    Font-Size="X-Small" MaxLength="1" Width="16px" TabIndex="28" 
                                Height="16px" Enabled="False" 
                                style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"></asp:TextBox>
                    </td>
                    <td style="width: 20px; text-align: right; font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 25px;">
                             Nombre</td>
                    <td style="text-align: left; width: 152px; height: 25px;">
                        <asp:TextBox ID="txt_nombre" runat="server" Font-Names="Arial" 
                                    Font-Size="X-Small" MaxLength="100" Width="169px" TabIndex="29" 
                                Height="16px" 
                                
                                
                            style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; margin-left: 0px;"></asp:TextBox>
                    </td>
                    <td style="width: 15px; text-align: right; font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 25px;">
                             Apellido Paterno</td>
                    <td style="text-align: left; width: 147px; height: 25px;">
                        <asp:TextBox ID="txt_paterno" runat="server" Font-Names="Arial" 
                                    Font-Size="X-Small" MaxLength="100" Width="140px" TabIndex="30" 
                                Height="16px" 
                                style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"></asp:TextBox>
                    </td>
                    <td style="width: 15px; text-align: right; font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 25px;">
                             Apellido Materno</td>
                 <td>
                        <asp:TextBox ID="txt_materno" runat="server" Font-Names="Arial" 
                                    Font-Size="X-Small" MaxLength="30" Width="141px" TabIndex="31" 
                                Height="16px" 
                                style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"></asp:TextBox>
                </td>
                </tr>
            </TABLE>
            <table>
                <tr>
                    <td style="width: 56px; text-align: left; font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 10px;">
                            Direccion</td><td style="width: 113px; text-align: left; height: 10px;">
                        <asp:TextBox ID="txt_direccion" runat="server" Font-Names="Arial" 
                                    Font-Size="X-Small" MaxLength="200" Width="243px" TabIndex="32" 
                                Height="16px" 
                                style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" ></asp:TextBox>
                    </td>
                    <td style="width: 1px; text-align: right; font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 10px;">
                            Numero</td>
                    <td style="text-align: left; width: 20px; height: 10px;">
                        <asp:TextBox ID="txt_numero" runat="server" Font-Names="Arial" 
                                    Font-Size="X-Small" MaxLength="10" Width="88px" TabIndex="33" 
                                Height="16px" 
                                style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" ></asp:TextBox>
                    </td>
                    <td style="width: 37px; text-align: right; font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 10px;">
                             Depto</td>
                    <td style="text-align: left; height: 10px;">
                        <asp:TextBox ID="txt_depto" runat="server" Font-Names="Arial" 
                                    Font-Size="X-Small" MaxLength="10" Width="88px" TabIndex="34" 
                                Height="16px" 
                                style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" ></asp:TextBox>
                    </td>
                    <td style="width: 37px; text-align: right; font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 10px;">
                             Telefono</td>
                    <td style="text-align: left; height: 10px;">
                        <asp:TextBox ID="txt_telefono" runat="server" Font-Names="Arial" 
                                    Font-Size="X-Small" MaxLength="10" Width="88px" TabIndex="34" 
                                Height="16px" 
                                style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" ></asp:TextBox>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td style="width: 89px; height: 23px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
                            Pais </td>
                            <td style="width: 126px; text-align: left; height: 23px;">
                        <asp:DropDownList ID="dl_pais" runat="server" AutoPostBack="True" 
                                    Font-Names="Arial" Font-Size="X-Small" Height="16px" 
                                    onselectedindexchanged="dl_pais_SelectedIndexChanged" Width="138px" 
                                TabIndex="35" style="font-family: Arial, Helvetica, sans-serif; font-size: x-small">
                        </asp:DropDownList>
                    </td>
                    <td style="width: 15px; text-align: right; height: 23px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
                            Region
                        </td>
                    <td style="text-align: left; height: 23px;">
                        <asp:DropDownList ID="dl_region" runat="server" AutoPostBack="True" 
                                    Font-Names="Arial" Font-Size="X-Small" Height="19px" 
                                    onselectedindexchanged="dl_region_SelectedIndexChanged" Width="213px" 
                                TabIndex="36" 
                                style="font-family: Arial, Helvetica, sans-serif; font-size: x-small">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;" 
                        class="style4">
                             Ciudad</td>
                    <td style="text-align: left; " class="style5">
                        <asp:DropDownList ID="dl_ciudad" runat="server" AutoPostBack="True" 
                                    Font-Names="Arial" Font-Size="X-Small" Height="19px" 
                                     Width="173px" onselectedindexchanged="dl_ciudad_SelectedIndexChanged" 
                                TabIndex="37" 
                                style="font-family: Arial, Helvetica, sans-serif; font-size: x-small">
                        </asp:DropDownList>
                    </td>
                    <td style="text-align: right; font-family: Arial, Helvetica, sans-serif; font-size: x-small;" 
                        class="style6">
                            Comuna<br />
                    </td>
                    <td style="text-align: left; " class="style5">
                        <asp:DropDownList ID="dl_comuna" runat="server" 
                                    Font-Names="Arial" Font-Size="X-Small" Height="19px" 
                                     Width="213px" 
                                TabIndex="38" onselectedindexchanged="dl_comuna_SelectedIndexChanged" 
                                style="font-family: Arial, Helvetica, sans-serif; font-size: x-small">
                        </asp:DropDownList>
                    </td>
                    <td align="center" class="style7">
                        <asp:ImageButton ID="ib_comuna" runat="server" 
                        ImageUrl="../imagenes/sistema/static/Herramienta.png" Height="22px" Width="23px" 
                            onclick="ib_comuna_Click" Visible="False" />
                    </td>
                </tr>
            </table>--%>
	<table bgcolor="#669999" style="width: 100%">
		<tr>
			<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #FFFFFF;" class="style13">
				<b>DATOS DE LA INFRACCION</b>
			</td>
		</tr>
	</table>
	<table style="width: 15%; height: 45px;">
		<tr>
			<td>
				<asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" CellPadding="1" Font-Names="Arial" Font-Size="X-Small" ForeColor="#333333" GridLines="None" OnRowEditing="gr_dato_RowEditing" ShowHeader="true" OnRowDataBound="gr_dato_RowDataBound" DataKeyNames="tipoInfraccion" OnSelectedIndexChanged="gr_dato_SelectedIndexChanged2">
					<RowStyle BackColor="#EFF3FB" />
					<Columns>
						<asp:TemplateField HeaderText="Tipo Infracción" ShowHeader="true">
							<ItemTemplate>
								<asp:DropDownList ID="dl_tipo_infraccion" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" OnSelectedIndexChanged="dl_tipo_infraccion_SelectedIndexChanged" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" TabIndex="4" Width="138px">
								</asp:DropDownList>
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Observación">
							<ItemTemplate>
								<asp:TextBox ID="txt_observacion" runat="server" AutoCompleteType="Disabled" AutoPostBack="false" Font-Size="7pt" Height="16px" MaxLength="50" OnTextChanged="txt_observacion_Leave" Text='<%# Bind("observacion") %>' Width="100px"></asp:TextBox>
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Monto">
							<ItemTemplate>
								<asp:TextBox ID="txt_monto" MaxLength="6" Height="16px" runat="server" Text='<%# Bind("monto") %>' Width="50px" AutoCompleteType="Disabled" Font-Size="7pt" OnTextChanged="txt_monto_Leave" AutoPostBack="false"></asp:TextBox>
								<cc1:FilteredTextBoxExtender ID="txt_monto_FilteredTextBoxExtender" runat="server" TargetControlID="txt_monto" FilterType="Custom, Numbers" ValidChars="">
								</cc1:FilteredTextBoxExtender>
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Fecha">
							<ItemTemplate>
								<asp:TextBox ID="txt_fecha" MaxLength="10" Height="16px" runat="server" Text='<%# Bind("fecha") %>' Width="75px" AutoCompleteType="Disabled" Font-Size="7pt" OnTextChanged="txt_fecha_Leave" AutoPostBack="false"></asp:TextBox>
							</ItemTemplate>
						</asp:TemplateField>
					</Columns>
				</asp:GridView>
		</tr>
		<tr>
			<td style="text-align: center">
				<asp:ImageButton ID="ib_mas" runat="server" ImageUrl="../imagenes/sistema/static/mas.jpg" Height="22px" Width="23px" OnClick="ib_mas_Click" Style="text-align: center" />
			</td>
		</tr>
	</table>
	<table bgcolor="white" style="width: 100%">
		<tr>
			<td style="text-align: center;" class="style10">
				<asp:Button ID="bt_guardar" runat="server" Font-Names="Arial" Font-Size="X-Small" Text="Guardar" TabIndex="53" OnClick="bt_guardar_Click" />
			</td>
			<td class="style11">
				<asp:Button ID="Button2" runat="server" Font-Names="Arial" Font-Size="X-Small" Text="Limpiar" TabIndex="54" OnClick="Button2_Click" />
			</td>
			<td class="style11">
				<asp:Button ID="bt_caratula" runat="server" Font-Names="Arial" Font-Size="X-Small" Text="Caratula" TabIndex="54" Visible="False" OnClick="bt_caratula_Click" />
			</td>
			<td style="text-align: right" class="style12">
				<asp:ImageButton ID="ib_gasto" runat="server" ImageUrl="../imagenes/sistema/static/dinero.png" Height="22px" Width="23px" OnClick="ib_gasto_Click" Visible="false" />
				<asp:Label ID="lbl_operacion" runat="server" Font-Names="Arial" Font-Size="Small" ForeColor="#FF3300" Visible="False"></asp:Label>
				<asp:Label ID="lbl_numero" runat="server" Font-Names="Arial" Font-Size="Small" ForeColor="#FF3300" Visible="False"></asp:Label>
			</td>
		</tr>
	</table>
	<br />
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