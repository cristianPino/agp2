<%@ Page Title="Control_TAG AGP S.A." Language="C#" MasterPageFile="~/AGP.Master"
	AutoEventWireup="true" CodeBehind="Control_TAG.aspx.cs" Inherits="sistemaAGP.Control_TAG" %>

<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>--%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMenu" runat="server">
	<style type="text/css">
		.style5
		{
			width: 58px;
		}
	</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoCentral" runat="server">
	<script type="text/javascript" src="../jquery-1.7.2.min.js"></script>
	<script type="text/javascript" src="../jquery.mousewheel-3.0.6.pack.js"></script>
	<script type="text/javascript" src="../jquery.fancybox.js?v=2.0.6"></script>
	<link rel="Stylesheet" type="text/css" href="../jquery.fancybox.css?v=2.0.6" media="screen" />
	<script type="text/javascript">
		$(document).ready(function () {
			$('.fancybox').fancybox({
				maxWidth: 800,
				maxHeight: 600,
				fitToView: false,
				width: 800,
				height: 600,
				autoSize: false,
				openEffect: 'elastic',
				openSpeed: 150,
				closeEffect: 'elastic',
				closeSpeed: 150,
				closeClick: false,
				closeBtn: true,
				onClosed: function() {   
						parent.location.reload(true); },
				scrolling: 'auto',
				padding: 5,
				beforeShow: function () {
					var el, id = $(this.element).data('title-id');
					if (id) {
						el = $('#' + id);
						if (el.length)
							this.title = el.html();
					}
				},
				helpers: {
					overlay: {
						opacity: 0.5,
						css: {
							'background-color': 'Gray'
						}
					}
				}
			});
		});
	</script>
	<script type="text/javascript">
		function confirmarEliminar() {
			if (confirm("Desea eliminar la operacion seleccionada?") == true) {
				return true;
			} else {
				return false;
			}
		}
	</script>
	<asp:UpdatePanel ID="up_arriba" runat="server">
		<ContentTemplate>
		
			<div style="background-color: #507cd1; font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #ffffff;">
				<table>
					<tr>
						<td style="vertical-align: middle;">
							<strong>Cliente</strong>
						</td>
						<td style="vertical-align: middle;">
							<asp:DropDownList ID="dl_cliente" runat="server" Style="font-family: Arial, Helvetica, sans-serif;
								font-size: x-small; color: #000000; width: 140px;" 
								onselectedindexchanged="dl_cliente_SelectedIndexChanged" AutoPostBack="true">
							</asp:DropDownList>
						</td>
						<td style="vertical-align: middle;">
							<strong>Sucursal</strong>
						</td>
						<td style="vertical-align: middle;">
							<asp:DropDownList ID="dl_sucursal" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #000000; width: 140px;">
							</asp:DropDownList>
						</td>
						<td style="vertical-align: middle;">
							<strong>RUT Adquirente</strong>
						</td>
						<td style="vertical-align: middle;">
							<asp:TextBox ID="txt_rut" runat="server" Style="font-family: Arial, Helvetica, sans-serif;
								font-size: x-small; width: 80px;" MaxLength="8" ToolTip="Ingrese el RUT sin puntos ni digito verificador"></asp:TextBox>
							<ajaxtoolkit:filteredtextboxextender id="fte_rut" runat="server" targetcontrolid="txt_rut"
								filtertype="Custom, Numbers" validchars="">
							</ajaxtoolkit:filteredtextboxextender>
						</td>
						<td style="vertical-align: middle;">
							<strong>Nº Serie TAG(Codigo TAG)</strong>
						</td>
						<td style="vertical-align: middle;">
							<asp:DropDownList ID="dl_Codigo_TAG" runat="server" Visible="true" 
								onselectedindexchanged="dl_Codigo_TAG_SelectedIndexChanged">
							</asp:DropDownList>
						</td>
						
					
					</tr>
					
					<tr>
						<td style="vertical-align: middle;">
							<strong>Nº Operacion</strong>
						</td>
						<td style="vertical-align: middle;">
							<asp:TextBox ID="txt_operacion" runat="server" AutoPostBack="true" CausesValidation="true"
								ValidationGroup="filtros" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;
								color: #ffffff; background-color: #3399ff; width: 80px;" OnTextChanged="txt_operacion_TextChanged"></asp:TextBox>
							<asp:CheckBox ID="chk_agrupar" runat="server" Style="font-family: Arial, Helvetica, sans-serif;
								font-size: x-small; color: #ffffff;" Text="Agrupar" />
							<ajaxToolkit:FilteredTextBoxExtender ID="fte_operacion" runat="server" TargetControlID="txt_operacion"
								FilterType="Custom, Numbers" ValidChars="">
							</ajaxToolkit:FilteredTextBoxExtender>
						</td>
						<td style="vertical-align: middle;">
							<strong>Desde</strong>
						</td>
						<td style="vertical-align: middle;">
							<asp:TextBox ID="txt_desde" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 75px;"></asp:TextBox>
							<asp:ImageButton ID="ib_desde" runat="server" ImageUrl="../imagenes/sistema/gif/calendario.gif" />
							<ajaxtoolkit:calendarextender id="cal_desde" runat="server" targetcontrolid="txt_desde" cssclass="calendario" format="dd/MM/yyyy" popupbuttonid="ib_desde" todaysdateformat="dd/MM/yyyy" onclientdateselectionchanged="checkDate" />
						</td>
						<td style="vertical-align: middle;">
							<strong>Hasta</strong>
						</td>
						<td style="vertical-align: middle;">
							<asp:TextBox ID="txt_hasta" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 75px;"></asp:TextBox>
							<asp:ImageButton ID="ib_hasta" runat="server" ImageUrl="../imagenes/sistema/gif/calendario.gif" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" />
							<ajaxtoolkit:calendarextender id="cal_hasta" runat="server" targetcontrolid="txt_hasta" cssclass="calendario" format="dd/MM/yyyy" popupbuttonid="ib_hasta" todaysdateformat="dd/MM/yyyy" onclientdateselectionchanged="checkDate" />
						</td>
					</tr>
				</table>
				<asp:ValidationSummary ID="vs_filtros" runat="server" DisplayMode="BulletList" HeaderText="Verifique los siguientes datos para realizar la búsqueda de operaciones:" ShowMessageBox="true" ShowSummary="false" ValidationGroup="filtros" />
			</div>
			<div style="background-color: #cccccc; vertical-align: middle; padding: 2px;">
			
				<div style="display: inline; vertical-align: middle; font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #ffffff; ">
					<asp:ImageButton ID="ib_buscar" runat="server" CausesValidation="true" AlternateText="Buscar" ImageAlign="AbsMiddle" ImageUrl="~/imagenes/sistema/static/panel_control/lupa.png" Style="background-color: #ffffff; padding: 2px; border: 1px solid #cccccc;" OnClick="ib_buscar_Click" ValidationGroup="filtros" />
				</div>
			</div>
			<center>
			<div style="background-color: #507cd1; font-family: Arial, Helvetica, sans-serif;
				font-size: x-small; color: #ffffff; display: table-cell; vertical-align:middle; text-align:center;">
				<center>
				<table>
				<tr>
					<td style="vertical-align: middle;">
						<strong>Codigo TAG Disponibles</strong>
					</td>
					<td style="vertical-align: middle;">
						<asp:DropDownList ID="dl_tag_disponibles" runat="server" Visible="true">
						</asp:DropDownList>
					</td>
					<td class="style5">
						<asp:Label ID="lbl_stock_tag" runat="server" Text="Label" 
							style="font-weight: 700; font-size: small"></asp:Label>
					</td>
				</tr>
				</table>
				<table>
					<tr>
						<td>
							<asp:Label ID="lbl_solicitud" runat="server" Text="Nº Op.AGP"></asp:Label>
						</td>
						<td>
							<asp:TextBox ID="txt_solicitud" runat="server"></asp:TextBox>
						</td>
						<td>
							<asp:Label ID="lbl_patente" runat="server" Text="Patente"></asp:Label>
						</td>
						<td>
							<asp:TextBox ID="txt_patente" runat="server"></asp:TextBox>
						</td>
					</tr>
					
				</table>
				<table>
						<tr>
							<td>
								<asp:Button ID="btn_carga_tag" runat="server" Text="Alta de TAG" 
									onclick="btn_carga_tag_Click" />
							</td>
							<td>
								<asp:Button ID="btn_baja_tag" runat="server" Text="Baja de TAG" 
									onclick="btn_baja_tag_Click" />
							</td>
						</tr>
				</table>
				</center>
			</div>
			</center>
		</ContentTemplate>
	</asp:UpdatePanel>
	<asp:UpdatePanel ID="up_grilla" runat="server">
		<ContentTemplate>
			<asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" CellPadding="4"
				DataKeyNames="tipo_operacion,cliente,patente,id_solicitud" Font-Names="Arial" Font-Size="X-Small"
				ForeColor="#333333" GridLines="None" Width="100%" OnSelectedIndexChanged="gr_dato_SelectedIndexChanged1"
				OnRowDataBound="gr_dato_RowDataBound">
				<RowStyle BackColor="#EFF3FB" />
				<Columns>
					<asp:HyperLinkField DataTextField="id_solicitud" HeaderText="Operacion">
						<ItemStyle ForeColor="#00CC00" />
					</asp:HyperLinkField>
					<asp:BoundField DataField="Cliente" HeaderText="Cliente" Visible="False" />
					<asp:BoundField DataField="nombre_cliente" HeaderText="Cliente" />
					<asp:BoundField DataField="Nº_AGP_Origen" HeaderText="Nº_AGP_Origen" />
					<asp:BoundField DataField="usuario_solicitud" HeaderText="Usuario Solicitud" />
					<asp:BoundField DataField="fecha_solicitud" HeaderText="Fecha Solicitud" />
					<asp:BoundField DataField="tipo_operacion" HeaderText="Tipo_operacion" Visible="False" />
					<asp:BoundField DataField="operacion" HeaderText="Producto" />
					<asp:BoundField DataField="sucursal" HeaderText="Sucursal" />
					<asp:BoundField DataField="patente" HeaderText="Patente" />
					<asp:BoundField DataField="Serie_TAG" HeaderText="Serie TAG" />
					<asp:BoundField DataField="rut_persona" HeaderText="RUT Adquirente" />
					<asp:BoundField DataField="nombre_persona" HeaderText="Nombre Adquirente" />
					<asp:BoundField DataField="estado" HeaderText="Ultimo Estado" />
					<asp:TemplateField HeaderText="Estado">
						<ItemTemplate>
							<asp:HyperLink ID="lnk_estado" runat="server" data-title-id="title-work" data-fancybox-type="iframe"
								CssClass="fancybox fancybox.iframe" ImageUrl="~/imagenes/iconos/estados.png"
								NavigateUrl='<%# Bind("url_estado") %>'>
							</asp:HyperLink>
						</ItemTemplate>
						<ItemStyle HorizontalAlign="Center" />
					</asp:TemplateField>
					<asp:TemplateField HeaderText="Comprobante gastos">
						<ItemTemplate>
							<%--<% If (gr_dato.) Then%>--%>
							<asp:HyperLink ID="lnk_comGastos" runat="server" Target="_blank" ImageUrl="~/imagenes/iconos/certificado.png"
								NavigateUrl='<%# Bind("url_comgastos") %>' />
							<%--<% End If%>--%>
						</ItemTemplate>
						<ItemStyle HorizontalAlign="Center" />
					</asp:TemplateField>
					<asp:TemplateField HeaderText="Cargar">
						<ItemTemplate>
							<asp:HyperLink ID="lnk_cargar" runat="server" data-title-id="title-cargar" data-fancybox-type="iframe"
								CssClass="fancybox fancybox.iframe" ImageUrl="~/imagenes/iconos/cargar.png"
								NavigateUrl='<%# Bind("url_cargar") %>' />
						</ItemTemplate>
						<ItemStyle HorizontalAlign="Center" />
					</asp:TemplateField>
					<asp:TemplateField HeaderText="C.Digital">
						<ItemTemplate>
							<asp:HyperLink ID="lnk_cdigital" runat="server" data-title-id="title-cdigital" data-fancybox-type="iframe" CssClass="fancybox fancybox.iframe" ImageUrl="~/imagenes/iconos/carpeta.png" NavigateUrl='<%# Bind("url_digital") %>' />
						</ItemTemplate>
						<ItemStyle HorizontalAlign="Center" />
					</asp:TemplateField>
					
				
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
	
</asp:Content>