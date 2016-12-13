<%@ Page Title="Actualizar - Datos de vehiculo" Language="C#" MasterPageFile="~/Adm.Master"
	AutoEventWireup="true" CodeBehind="actualizar_vehiculo.aspx.cs" Inherits="sistemaAGP.actualizar_vehiculo" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/controles/wucPersona.ascx" TagName="DatosPersona" TagPrefix="agp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<style type="text/css">
		.style2
		{
		}
		.style3
		{
			height: 9px;
		}
		.style4
		{
			height: 15px;
		}
		.style5
		{
			height: 16px;
		}
		.style6
		{
			height: 22px;
		}
		.style7
		{
			height: 63px;
		}
		
		.style9
		{
			height: 22px;
			width: 94px;
		}
		
		.style10
		{
			height: 22px;
			width: 87px;
		}
		
		.style13
		{
			height: 15px;
			width: 97px;
		}
		.style14
		{
			height: 9px;
			width: 97px;
		}
		.style15
		{
			height: 22px;
			width: 97px;
		}
	</style>
</asp:Content>
<asp:content id="Content2" contentplaceholderid="ContentPlaceHolder1" runat="server">
	<table style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 167px;
		width: 860px;" bgcolor="#E5E5E5">
		<tr>
			<td colspan="9" style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;
				font-weight: 700; color: #FFFFFF; background-color: #0066FF" class="style5">
				Datos a Actualizar
			</td>
		</tr>
		<tr>
			<td class="style13">
				Patente:
			</td>
			<td class="style4" colspan="8">
				<asp:label id="lbl_patente" runat="server" forecolor="#FF3300" style="font-weight: 700;
					font-size: small"></asp:label>
			</td>
		</tr>
		<tr>
			<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;" class="style14">
				Fecha Contrato
			</td>
			<td class="style3" colspan="8">
				<asp:textbox id="txt_fecha_contrato" runat="server" style="font-family: Arial, Helvetica, sans-serif;
					font-size: x-small" height="21px" width="103px" tabindex="7" ontextchanged="txt_fecha_contrato_TextChanged">
				</asp:textbox>
				<cc1:calendarextender runat="server" targetcontrolid="txt_fecha_contrato" cssclass="calendario"
					format="dd/MM/yyyy" popupbuttonid="ib_calendario" id="CalendarExtender2" />
				<asp:imagebutton id="ib_calendario" runat="server" imageurl="../imagenes/sistema/gif/calendario.gif"
					onclick="ib_calendario_Click" height="16px" />
			</td>
		</tr>
		<tr>
			<td class="style15">
				Precio venta
			</td>
			<td class="style6" colspan="8">
				<asp:textbox id="txt_precio_venta" runat="server" cssclass="style2" width="135px"
					maxlength="12" ontextchanged="txt_precio_venta_TextChanged" height="19px" autopostback="True">
				</asp:textbox>
			</td>
		</tr>
		<tr>
			<td class="style15">
				Kilometraje
			</td>
			<td class="style6" colspan="8">
				<asp:textbox id="txt_kilometraje" runat="server" cssclass="style2" width="55px" maxlength="12"
					ontextchanged="txt_kilometraje_TextChanged" height="19px" autopostback="True">
				</asp:textbox>
			</td>
		</tr>
		<tr>
			<td class="style15">
				Comision
			</td>
			<td class="style6" colspan="8">
				<asp:dropdownlist id="dl_impuesto" runat="server" Visible="false"
					onselectedindexchanged="dl_impuesto_SelectedIndexChanged">
					<asp:listitem text="seleccionar" value="0" />
					<asp:listitem text="3" value="3" />
					<asp:listitem text="5" value="5" />
				</asp:dropdownlist>

			</td>
		</tr>
	</table>
	<asp:updatepanel id="Panel_leasing" runat="server">
		<contenttemplate>
			<asp:Panel ID="Panel2" runat="server" Visible="false">
		<table class="style6" >		
		<tr>
			<td style="width: 30px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
				N°Contrato</td>
			<td class="style10">
				<asp:TextBox ID="txt_contrato" runat="server" CssClass="style2" Width="82px" MaxLength="12"
					OnTextChanged="txt_contrato_TextChanged" Height="19px" AutoPostBack="True"></asp:TextBox>
			</td>
			<td style="width: 30px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
				Valor Cesion
			</td>

			<td class="style10">
				<asp:TextBox ID="txt_valor_cesion" runat="server" CssClass="style2" Width="82px"
					MaxLength="12" OnTextChanged="txt_valor_cesion_TextChanged" Height="19px" AutoPostBack="True"></asp:TextBox></td>
			<td style="width: 30px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
				Valor Opcion
			</td>
			<td class="style9">
				<asp:TextBox ID="txt_valor_opcion" runat="server" CssClass="style2" Width="82px"
					MaxLength="12" OnTextChanged="txt_valor_opcion_TextChanged" Height="19px" AutoPostBack="True"></asp:TextBox></td>
			<td style="width: 30px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
				Cantidad</td>
			<td class="style9">
				<asp:TextBox ID="txt_cantidad" runat="server" CssClass="style2" Width="40px" MaxLength="12"
					OnTextChanged="txt_cantidad_TextChanged" Height="19px" AutoPostBack="True"></asp:TextBox>
			</td>
			<td style="width: 30px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
				Fecha Cesion
			</td>
			<td class="style6">
				<asp:TextBox ID="txt_fecha_cesion" runat="server" Style="font-family: Arial, Helvetica, sans-serif;
					font-size: x-small" Height="21px" Width="103px" TabIndex="7" OnTextChanged="txt_fecha_cesion_TextChanged"></asp:TextBox>
				
				<cc1:CalendarExtender runat="server" TargetControlID="txt_fecha_cesion" CssClass="calendario"
					Format="dd/MM/yyyy" PopupButtonID="ib_fecha_cesion" ID="CalendarExtender1" />
				<asp:ImageButton ID="ib_fecha_cesion" runat="server" ImageUrl="../imagenes/sistema/gif/calendario.gif"
					OnClick="ib_fecha_cesion_Click" Height="16px" /></td>
			</tr>
		</table>
			</asp:Panel>
		</contenttemplate>
	</asp:updatepanel>
	<table>
		<tr>
			<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;" class="style14">
				Forma Pago
			</td>
			<td class="style7" colspan="5">
				<asp:textbox id="txt_forma_pago" runat="server" cssclass="style2" height="57px" width="285px"
					maxlength="500" textmode="MultiLine" ontextchanged="txt_forma_pago_TextChanged">
				</asp:textbox>
			</td>
		</tr>
		<tr>
			<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;" class="style14">
				N°Cheques/Cuotas
			</td>
			<td colspan="5">
				<asp:textbox id="txt_cheques" runat="server" autopostback="true" maxlength="2" ontextchanged="txt_cheques_TextChanged"
					style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; margin-left: 8px;
					width: 33px;">
				</asp:textbox>
				<cc1:filteredtextboxextender id="filter_cheques" runat="server" filtertype="Custom, Numbers"
					targetcontrolid="txt_cheques" validchars="">
				</cc1:filteredtextboxextender>
			</td>
		</tr>
	</table>
	<asp:panel id="pnlInfoCheques" runat="server" visible="false">
		<asp:panel id="Panel1" runat="server" visible="true">
			<table>
				<tr>
					<td style="width: 30px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
						Banco
					</td>
					<td>
						<asp:dropdownlist id="dl_financiera" runat="server" style="font-family: Arial, Helvetica, sans-serif;
							font-size: x-small; width: 138px; height: 16px;" onselectedindexchanged="dl_financiera_SelectedIndexChanged">
						</asp:dropdownlist>
					</td>
				</tr>
			</table>
			<asp:gridview id="gr_cheques" runat="server" autogeneratecolumns="False" showfooter="true"
				cellpadding="4" font-names="Arial" font-size="X-Small" forecolor="#333333" gridlines="None"
				onrowcommand="gr_cheques_RowCommand" onrowdatabound="gr_cheques_RowDataBound"
				onselectedindexchanged="gr_cheques_SelectedIndexChanged">
				<columns>
					<asp:BoundField HeaderText="Nº Cuota" DataField="nro_cuota" ItemStyle-Width="60px"
						ItemStyle-HorizontalAlign="Right" />
					<asp:TemplateField HeaderText="Nº Cheque" ItemStyle-Width="150px">
						<ItemTemplate>
							<asp:TextBox ID="txt_nro_cheque" runat="server" Text='<%# Bind("nro_cheque") %>'
								Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 80px;
								height: 16px;"></asp:TextBox>
							<cc1:FilteredTextBoxExtender ID="filter_nro_cheque" runat="server" TargetControlID="txt_nro_cheque"
								FilterType="Custom, Numbers" ValidChars="">
							</cc1:FilteredTextBoxExtender>
							<asp:ImageButton ID="btn_nro_cheque" runat="server" ImageUrl="~/imagenes/sistema/static/FillDownHS.png"
								CommandName="FillDownNro" />
							<cc1:ConfirmButtonExtender ID="cbe_nro_cheques" runat="server" ConfirmText="¿Los cheques siguientes son correlativos?"
								TargetControlID="btn_nro_cheque">
							</cc1:ConfirmButtonExtender>
						</ItemTemplate>
					</asp:TemplateField>
					<asp:TemplateField HeaderText="Fecha" ItemStyle-Width="150px">
						<ItemTemplate>
							<asp:TextBox ID="txt_fecha_cheque" runat="server" Text='<%# Bind("fecha_cheque") %>'
								Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 16px;
								width: 73px;"></asp:TextBox>
							<asp:ImageButton ID="ibt_fecha_cheque" runat="server" ImageUrl="../imagenes/sistema/gif/calendario.gif" />
							<cc1:CalendarExtender ID="cal_fecha_cheque" runat="server" TargetControlID="txt_fecha_cheque"
								CssClass="calendario" Format="dd/MM/yyyy" PopupButtonID="ibt_fecha_cheque" />
							<asp:ImageButton ID="btn_fecha_cheque" runat="server" ImageUrl="~/imagenes/sistema/static/FillDownHS.png"
								CommandName="FillDownFecha" />
							<cc1:ConfirmButtonExtender ID="cbe_fecha_cheques" runat="server" ConfirmText="¿Los cheques siguientes tienen fechas correlativas?"
								TargetControlID="btn_fecha_cheque">
							</cc1:ConfirmButtonExtender>
						</ItemTemplate>
					</asp:TemplateField>
					<asp:TemplateField HeaderText="Monto" ItemStyle-Width="120px">
						<ItemTemplate>
							<asp:TextBox ID="txt_monto_cheque" runat="server" Text='<%# Bind("monto_cheque") %>'
								AutoPostBack="true" OnTextChanged="txt_monto_cheque_TextChanged" Style="font-family: Arial, Helvetica, sans-serif;
								font-size: x-small; width: 80px; height: 16px;"></asp:TextBox>
							<cc1:FilteredTextBoxExtender ID="filter_monto_cheque" runat="server" TargetControlID="txt_monto_cheque"
								FilterType="Custom, Numbers" ValidChars="">
							</cc1:FilteredTextBoxExtender>
							<asp:ImageButton ID="btn_monto_cheque" runat="server" ImageUrl="~/imagenes/sistema/static/FillDownHS.png"
								CommandName="FillDownMonto" />
							<cc1:ConfirmButtonExtender ID="cbe_monto_cheques" runat="server" ConfirmText="¿Los cheques siguientes tienen el mismo monto?"
								TargetControlID="btn_monto_cheque">
							</cc1:ConfirmButtonExtender>
						</ItemTemplate>
						<FooterTemplate>
							<asp:TextBox ID="txt_total_monto_cheque" runat="server" Text="" Style="font-family: Arial, Helvetica, sans-serif;
								font-size: x-small; width: 80px; height: 16px;"></asp:TextBox>
						</FooterTemplate>
					</asp:TemplateField>
				</columns>
				<rowstyle backcolor="#EFF3FB" verticalalign="Middle" horizontalalign="Center" />
				<footerstyle backcolor="#507CD1" font-bold="True" forecolor="White" />
				<pagerstyle backcolor="#2461BF" forecolor="White" horizontalalign="Center" />
				<selectedrowstyle backcolor="#D1DDF1" font-bold="True" forecolor="#333333" />
				<headerstyle backcolor="#507CD1" font-bold="True" forecolor="White" />
				<editrowstyle backcolor="#2461BF" />
				<alternatingrowstyle backcolor="White" />
			</asp:gridview>
		</asp:panel>
	</asp:panel>
	<table bgcolor="#E5E5E5" style="height: 100px; width: 859px">
		<tr>
			<td>
				<asp:checkbox id="chk_prenda" runat="server" oncheckedchanged="chk_prenda_CheckedChanged"
					text="Prenda" autopostback="True" />
			</td>
		</tr>
		<tr>
			<td colspan="2">
				<agp:datospersona id="Datosprendedor" runat="server" titulo="Datos Acreedor" habilitarcomprapara="false"
					habilitarcorreo="false" habilitardireccion="false" habilitarparticipante="false"
					habilitartelefono="false" visible="false" />
			</td>
		</tr>
		<tr>
			<td>
				<asp:button id="Button1" runat="server" style="font-family: Arial, Helvetica, sans-serif;
					font-size: x-small; font-weight: 700" text="Guardar" onclick="Button1_Click" />
			</td>
		</tr>
	</table>
</asp:content>
