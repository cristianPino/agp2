<%@ Page Title="Documentos Garantia AGP S.A." Language="C#" MasterPageFile="~/AGP.Master" AutoEventWireup="true" CodeBehind="Doc_Garantia.aspx.cs" Inherits="sistemaAGP.Doc_Garantia" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMenu" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoCentral" runat="server">
	<asp:UpdatePanel ID="up_filtros" runat="server" UpdateMode="Conditional">
		<ContentTemplate>
			<div>
				<table style="width: 100%; height: 32px; background-color: #507CD1">
					<tr>
						<td style="width: 38px; font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 28px; color: #FFFF66;">
							*<span style="color: #FFFFFF"><b>Cliente</b></span>
						</td>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 28px;">
							<b>
								<asp:DropDownList ID="dl_cliente" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="138px" TabIndex="1" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #000000;" AutoPostBack="True" OnSelectedIndexChanged="dl_cliente_SelectedIndexChanged">
								</asp:DropDownList>
							</b>
						</td>
						<td class="style1" style="width: 57px; font-family: Arial, Helvetica, sans-serif; font-size: x-small; font-weight: bold; height: 28px; color: #FFFFFF;">
							Modulo
						</td>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 28px;">
							<b>
								<asp:DropDownList ID="dl_modulo" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="138px" TabIndex="17" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #000000;">
								</asp:DropDownList>
							</b>
						</td>
						<td style="width: 64px; font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 28px; color: #FFFFFF;">
							<b>Sucursal</b>
						</td>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 28px; width: 132px;">
							<b>
								<asp:DropDownList ID="dl_sucursal" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="138px" TabIndex="17" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #000000;">
								</asp:DropDownList>
							</b>
						</td>
						<td style="width: 63px; font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 28px; color: #FFFFFF;">
							<b><span style="color: #FFFF66">* </span>Producto</b>
						</td>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 28px;">
							<b>
								<asp:DropDownList ID="dl_producto" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="138px" TabIndex="17" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #000000;" OnSelectedIndexChanged="dl_producto_SelectedIndexChanged" AutoPostBack="True">
								</asp:DropDownList>
							</b>
						</td>
					</tr>
					<tr>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #FFFFFF; font-weight: 700;">
							Adquiriente
						</td>
						<td>
							<asp:TextBox ID="txt_rut" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" MaxLength="8" Width="136px"></asp:TextBox>
							<ajaxToolkit:FilteredTextBoxExtender ID="txt_rutFilteredTextBoxExtender1" runat="server" TargetControlID="txt_rut" FilterType="Custom, Numbers" ValidChars="">
							</ajaxToolkit:FilteredTextBoxExtender>
						</td>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #FFFFFF">
							<b>Nº Factura</b>
						</td>
						<td>
							<asp:TextBox ID="txt_factura" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" MaxLength="8" Width="135px"></asp:TextBox>
							<ajaxToolkit:FilteredTextBoxExtender ID="txt_facturaFilteredTextBoxExtender1" runat="server" TargetControlID="txt_factura" FilterType="Custom, Numbers" ValidChars="">
							</ajaxToolkit:FilteredTextBoxExtender>
						</td>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #FFFFFF; font-weight: 700;">
							Nº Cliente
						</td>
						<td style="width: 132px">
							<asp:TextBox ID="txt_cliente" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" Width="133px"></asp:TextBox>
						</td>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #FFFFFF; font-weight: 700;">
							Patente
						</td>
						<td>
							<asp:TextBox ID="txt_patente" runat="server" MaxLength="6" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" Width="82px"></asp:TextBox>
						</td>
					</tr>
					<tr>
						<td style="width: 92px; font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 28px; color: #FFFFFF;">
							<b>Nº Operacion</b>
						</td>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 28px;">
							<b>
								<asp:TextBox ID="txt_operacion" runat="server" Width="104px" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #FFFFFF;" BackColor="#3399FF" ForeColor="White" TabIndex="3"></asp:TextBox>
								<ajaxToolkit:FilteredTextBoxExtender ID="txt_operacion_FilteredTextBoxExtender" runat="server" TargetControlID="txt_operacion" FilterType="Custom, Numbers" ValidChars="">
								</ajaxToolkit:FilteredTextBoxExtender>
							</b>
						</td>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 132px;" class="style5">
							<asp:Label ID="lbl_flujo" runat="server" Style="color: #FFFFFF; text-align: right;" Text="Flujo de Trabajo" Visible="False"></asp:Label>
						</td>
						<td style="text-align: left;">
							<asp:DropDownList ID="dpl_estado" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="157px" Visible="False" Style="text-align: left">
							</asp:DropDownList>
						</td>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #FFFFFF">
							<b>Desde </b>
						</td>
						<td>
							<asp:TextBox ID="txt_desde" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" Height="19px" Width="73px" TabIndex="2"></asp:TextBox>
							<asp:ImageButton ID="ib_desde" runat="server" ImageUrl="../imagenes/sistema/gif/calendario.gif" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" />
							<ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_desde" CssClass="FondoAplicacion" Format="dd/MM/yyyy" PopupButtonID="ib_desde" />
						</td>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #FFFFFF; font-weight: 700">
							Hasta
						</td>
						<td>
							<asp:TextBox ID="txt_hasta" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" Height="19px" Width="73px" TabIndex="2"></asp:TextBox>
							<asp:ImageButton ID="ib_hasta" runat="server" ImageUrl="../imagenes/sistema/gif/calendario.gif" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" />
							<ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txt_hasta" CssClass="FondoAplicacion" Format="dd/MM/yyyy" PopupButtonID="ib_hasta" />
						</td>
					</tr>
					<tr>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 132px; color: #FFFFFF;" class="style5">
							<span style="color: #FFFF00">* </span>Notaria
						</td>
						<td style="text-align: left;">
							<asp:DropDownList ID="dl_notaria" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" OnSelectedIndexChanged="dl_notaria_SelectedIndexChanged" Width="157px" Style="text-align: left" AutoPostBack="True">
							</asp:DropDownList>
						</td>
						<td style="text-align: center" >
							<asp:ImageButton ID="ib_buscar" runat="server" ImageUrl="~/imagenes/sistema/gif/lupa-small.png" OnClick="ib_buscar_Click" Style="text-align: center; background-color: #ffffff;" />
						</td>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 132px; color: #FFFFFF;" class="style5">
							<span style="color: #FFFF00">* </span>Documento
						</td>
						<td style="text-align: left;">
							<asp:DropDownList ID="dl_doc" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="157px" Style="text-align: left">
							</asp:DropDownList>
						</td>
						<td style="text-align: center" >
							<asp:ImageButton ID="ib_word" runat="server" ImageUrl="~/imagenes/sistema/static/word-small.jpg" OnClick="ib_word_Click" Style="text-align: center; background-color: #ffffff;" />
						</td>
						
						
					</tr>
				</table>
			</div>
			<div>
				<asp:UpdatePanel ID="up_grilla" runat="server" UpdateMode="Conditional">
					<ContentTemplate>
						<asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" 
							CellPadding="4" Font-Names="Arial" Font-Size="X-Small" ForeColor="#333333" 
							DataKeyNames="cod_tip_operacion,doc,cliente,id_solicitud" GridLines="None" 
							Width="100%" Height="50px" EnableModelValidation="True" 
							OnRowDataBound="gr_dato_RowDataBound" 
							onselectedindexchanged="gr_dato_SelectedIndexChanged">
							<RowStyle BackColor="#EFF3FB" />
							<Columns>
								<asp:HyperLinkField AccessibleHeaderText="id_solicitud" DataNavigateUrlFormatString="id_solicitud" DataTextField="id_solicitud" HeaderText="Operacion" Text="id_solicitud">
									<ItemStyle ForeColor="#00CC00" />
								</asp:HyperLinkField>
								<asp:BoundField AccessibleHeaderText="Cliente" DataField="Cliente" Visible="False" />
								<asp:BoundField AccessibleHeaderText="Cliente" DataField="Cliente_nombre" HeaderText="Cliente" />
								<asp:BoundField AccessibleHeaderText="tipo_operacion" DataField="tipo_operacion" HeaderText="Tipo operacion" />
								<asp:BoundField AccessibleHeaderText="cod_tip_operacion" DataField="cod_tip_operacion" FooterText="cod_tip_operacion" HeaderText="cod_tip_operacion" Visible="False" />
								<asp:BoundField AccessibleHeaderText="Nº Factura" DataField="numero_factura" HeaderText="Nº Factura" />
								<asp:BoundField AccessibleHeaderText="Patente" DataField="Patente" HeaderText="Patente" />
								<asp:BoundField AccessibleHeaderText="numero_cliente" DataField="numero_cliente" HeaderText="Numero Cliente" />
								<asp:BoundField AccessibleHeaderText="Adquiriente" DataField="rut_persona" HeaderText="Adquiriente" />
								<asp:BoundField AccessibleHeaderText="Nombre" DataField="nombre_persona" />
								<asp:BoundField AccessibleHeaderText="ultimo" DataField="ultimo_estado" HeaderText="Estado Actual" />
								<asp:TemplateField AccessibleHeaderText="Workflow" HeaderText="Workflow" ShowHeader="False" ItemStyle-HorizontalAlign="Center">
									<ItemTemplate>
										<asp:ImageButton ID="ib_workflow" runat="server" ImageUrl="~/imagenes/sistema/static/Herramienta.png" />
									</ItemTemplate>
									<EditItemTemplate>
										<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
									</EditItemTemplate>
									<ControlStyle Height="32px" Width="32px" />
								</asp:TemplateField>
								<asp:TemplateField AccessibleHeaderText="C.Digital" HeaderText="C.Digital" ItemStyle-HorizontalAlign="Center">
									<ItemTemplate>
										<asp:ImageButton ID="ib_cdigital" runat="server" ImageUrl="../imagenes/sistema/static/carpetas.gif" />
									</ItemTemplate>
									<ControlStyle Height="32px" Width="32px" />
								</asp:TemplateField>
								<asp:TemplateField>
									<HeaderTemplate>
										<asp:CheckBox ID="checkall" runat="server" AutoPostBack="True" OnCheckedChanged="Check_Clicked" />
									</HeaderTemplate>
									<ItemTemplate>
										<asp:CheckBox ID="chk" runat="server" EnableViewState="true" />
									</ItemTemplate>
								</asp:TemplateField>
								<asp:TemplateField AccessibleHeaderText="Documentos" HeaderText="Documentos">
									<ItemTemplate>
										<asp:HyperLink ID="lnk_word" runat="server"></asp:HyperLink>
									</ItemTemplate>
								</asp:TemplateField>
								<asp:TemplateField AccessibleHeaderText="Reemplazar" HeaderText="Reemplazar" ItemStyle-HorizontalAlign="Center">
									<ItemTemplate>
										<asp:ImageButton ID="ib_reemplazar" runat="server" ImageUrl="~/imagenes/sistema/static/carpeta-small.jpg" />
									</ItemTemplate>
								</asp:TemplateField>
								<asp:BoundField AccessibleHeaderText="TienDOC" DataField="doc" FooterText="TienDOC" HeaderText="TienDOC" Visible="False" />
							</Columns>
							<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
							<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
							<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
							<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
							<EditRowStyle BackColor="#2461BF" />
							<AlternatingRowStyle BackColor="White" />
						</asp:GridView>
					</ContentTemplate>
				</asp:UpdatePanel>
			</div>
		</ContentTemplate>
	</asp:UpdatePanel>
</asp:Content>