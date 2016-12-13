<%@ Page Title="Control de Operaciones AGP S.A." Language="C#" MasterPageFile="~/AGP.Master" AutoEventWireup="true" CodeBehind="carpeta_digital.aspx.cs" Inherits="sistemaAGP.carpeta_digital" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMenu" runat="server">
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
				fitToView: true,
				width: 800,
				height: 600,
				autoSize: false,
				openEffect: 'elastic',
				openSpeed: 150,
				closeEffect: 'elastic',
				closeSpeed: 150,
				closeClick: false,
				closeBtn: true,
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



	<table align="left" style="width: 55%; height: 440px">
		<tr>
			<td class="style4" style="height: 74px" valign="top">
				<table style="width: 100%; height: 32px;" bgcolor="#507CD1">
					<tr>
						<td style="width: 92px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;
							height: 28px; color: #FFFFFF;">
							<b>Nº Operacion</b>
						</td>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 28px; width: 114px;">
							<b>
								<asp:TextBox ID="txt_operacion" runat="server" Width="104px" Style="font-family: Arial, Helvetica, sans-serif;
									font-size: x-small; color: #FFFFFF;" BackColor="#3399FF" ForeColor="White" TabIndex="3" 
								AutoPostBack="True" ontextchanged="txt_operacion_TextChanged"></asp:TextBox>
								<cc1:FilteredTextBoxExtender ID="txt_operacion_FilteredTextBoxExtender" runat="server"
									TargetControlID="txt_operacion" FilterType="Custom, Numbers" ValidChars="">
								</cc1:FilteredTextBoxExtender>
							</b>
						</td>
						<td style="width: 84px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;
							color: #FFFFFF;">
						
							
							&nbsp;</td>
						<td>
						</td>
					</tr>
					</table>
				<center>
					<table style="width: 100%; height: 264px;">
						<tr>
							<td style="width: 123px;" valign="top">
								<asp:UpdatePanel ID="UpdatePanel2" runat="server">
									<ContentTemplate>
										<asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" CellPadding="4"
											Font-Names="Arial" Font-Size="X-Small" ForeColor="#333333" DataKeyNames="cod_tip_operacion,id_solicitud,cliente"
											GridLines="None" Width="898px" Height="50px" OnSelectedIndexChanged="gr_dato_SelectedIndexChanged"
											OnRowDeleting="gr_dato_RowDeleting" OnRowEditing="gr_dato_RowEditing" EnableModelValidation="True">
											<RowStyle BackColor="#EFF3FB" />
											<Columns>
												<asp:HyperLinkField AccessibleHeaderText="id_solicitud" DataNavigateUrlFormatString="id_solicitud"
													DataTextField="id_solicitud" HeaderText="Operacion" Text="id_solicitud">
													<ItemStyle ForeColor="#00CC00" />
												</asp:HyperLinkField>
												<asp:BoundField AccessibleHeaderText="Cliente" DataField="Cliente" Visible="False" />
												<asp:BoundField AccessibleHeaderText="Cliente" DataField="Cliente_nombre" HeaderText="Cliente" />
												<asp:BoundField AccessibleHeaderText="tipo_operacion" DataField="tipo_operacion"
													HeaderText="Tipo operacion" />
												<asp:BoundField AccessibleHeaderText="cod_tip_operacion" 
													DataField="cod_tip_operacion" FooterText="cod_tip_operacion" 
													HeaderText="cod_tip_operacion" Visible="False" />
												<asp:BoundField AccessibleHeaderText="Nº Factura" DataField="numero_factura" HeaderText="Nº Factura" />
												<asp:BoundField AccessibleHeaderText="Patente" DataField="Patente" HeaderText="Patente" />
												<asp:BoundField AccessibleHeaderText="numero_cliente" DataField="numero_cliente"
													HeaderText="Numero Cliente" />
												<asp:BoundField AccessibleHeaderText="Adquiriente" DataField="rut_persona" HeaderText="Adquiriente" />
												<asp:BoundField AccessibleHeaderText="Nombre" DataField="nombre_persona" />
												<asp:BoundField AccessibleHeaderText="Gastos" FooterText="Gastos" HeaderText="Gastos"
													DataField="total_gasto" />
												<asp:BoundField AccessibleHeaderText="Saldo" DataField="saldo" 
                                                    FooterText="Saldo" HeaderText="Saldo" />
												<asp:BoundField AccessibleHeaderText="ultimo" DataField="ultimo_estado" HeaderText="Estado Actual" />
												
											
											
												
												<asp:TemplateField HeaderText="Cargar">
						<ItemTemplate>
							<asp:HyperLink ID="lnk_cargar" runat="server" data-fancybox-type="iframe" CssClass="fancybox fancybox.iframe"  data-title-id="title-cargar" ImageUrl="~/imagenes/sistema/static/panel_control/subir.png" NavigateUrl='<%# Bind("url_cargar") %>' />
						</ItemTemplate>
						<ItemStyle HorizontalAlign="Center" />
					</asp:TemplateField>
												
											<asp:TemplateField AccessibleHeaderText="C.Digital" HeaderText="C.Digital">
													<EditItemTemplate>
														<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
													</EditItemTemplate>
													<ItemTemplate>
														<asp:ImageButton ID="ib_cdigital"   runat="server" ImageUrl="../imagenes/sistema/static/panel_control/carpeta.png" />
													</ItemTemplate>
													<ControlStyle Height="25px" Width="25px" />
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
							</td>
						</tr>
			
				</center>
		</table>
			
	
		
				
			

</asp:Content>