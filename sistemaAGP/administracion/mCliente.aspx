<%@ Page Language="C#" MasterPageFile="~/AGP.Master" AutoEventWireup="true" CodeBehind="mCliente.aspx.cs" Inherits="sistemaAGP.mCliente" Title="Administracion de Clientes" %>

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


	<table border="0" style="width: 1001px; height: 323px; margin-right: 369px;">
		<tr>
			<td style="border-style: none; border-color: inherit; border-width: 0; text-align: left; width: 1057px; height: 277px;" align="left" valign="top">
				<asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="X-Small" Text="Administracion de Clientes"></asp:Label>
				<table style="width: 73%; font-family: Arial, Helvetica, sans-serif; font-size: x-small" bgcolor="#E5E5E5">
					<tr>
						<td style="width: 23px; text-align: left;">
							Rut
						</td>
						<td style="width: 93px; text-align: left">
							<asp:TextBox ID="txt_rut" runat="server" Font-Names="Arial" Font-Size="X-Small" MaxLength="10" TabIndex="1" AutoPostBack="True" Height="17px" Width="91px" BackColor="#0099FF" ForeColor="White" OnTextChanged="txt_rut_Leave"></asp:TextBox>
						</td>
						<td style="width: 15px; text-align: right">
							Nombre
						</td>
						<td style="text-align: left;">
							<asp:Label ID="lbl_nombre" runat="server" Font-Names="Arial" Font-Size="X-Small" Font-Bold="True" ForeColor="#0099FF"></asp:Label>
						</td>
					</tr>
				</table>
				<asp:Button ID="Button1" runat="server" Font-Names="Arial" Font-Size="X-Small" Text="Guardar" OnClick="Button1_Click" TabIndex="16" />
				<cc1:ConfirmButtonExtender ID="Button1_ConfirmButtonExtender" runat="server" TargetControlID="Button1" ConfirmText="¿Esta seguro de ingresar un nuevo Cliente?">
				</cc1:ConfirmButtonExtender>
				<asp:Button ID="Button2" runat="server" Font-Names="Arial" Font-Size="X-Small" OnClick="Button2_Click" Text="Limpiar" />
				<asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Names="Arial" Font-Size="X-Small" ForeColor="#333333" GridLines="None" Style="text-align: left" OnSelectedIndexChanged="gr_dato_SelectedIndexChanged1" OnRowDataBound="gr_dato_RowDataBound" DataKeyNames="id_cliente" EnableModelValidation="True">
					<RowStyle BackColor="#EFF3FB" />
					<Columns>
						<asp:BoundField AccessibleHeaderText="id_cliente" DataField="id_cliente" HeaderText="id_cliente" />
						<asp:BoundField AccessibleHeaderText="nombre" DataField="nombre" 
                            HeaderText="Nombre" >
						<ItemStyle Width="300px" />
                        </asp:BoundField>
						<asp:TemplateField ShowHeader="False" HeaderText="Modulos">
							<ItemTemplate>
								<asp:HyperLink ID="ib_modulo" data-fancybox-type="iframe" CssClass="fancybox fancybox.iframe" runat="server" ImageUrl="../imagenes/sistema/static/browser.png" Text="modulo" 
                                NavigateUrl='<%# Bind("url_modulo") %>'/>
							</ItemTemplate>
							<ItemStyle HorizontalAlign="Center" />
						</asp:TemplateField>
						<asp:TemplateField ShowHeader="False" HeaderText="Sucursales">
							<ItemTemplate>
								<asp:HyperLink ID="ib_sucursales" runat="server" data-fancybox-type="iframe" CssClass="fancybox fancybox.iframe" ImageUrl="../imagenes/sistema/static/edificio.png" Text="Sucursales" 
                                NavigateUrl='<%# Bind("url_sucursal") %>' />
							</ItemTemplate>
							<ItemStyle HorizontalAlign="Center" />
						</asp:TemplateField>
						<asp:TemplateField ShowHeader="False" HeaderText="Personeros">
							<ItemTemplate>
								<asp:HyperLink ID="ib_personero" runat="server" data-fancybox-type="iframe" CssClass="fancybox fancybox.iframe" ImageUrl="../imagenes/sistema/static/personero.gif" Text="Personeros" 
                                 NavigateUrl='<%# Bind("url_personero") %>'/>
							</ItemTemplate>
							<ItemStyle HorizontalAlign="Center" />
						</asp:TemplateField>
						<asp:TemplateField ShowHeader="False" HeaderText="Operacion">
							<ItemTemplate>
								<asp:HyperLink ID="ib_operacion" runat="server" data-fancybox-type="iframe" CssClass="fancybox fancybox.iframe" ImageUrl="../imagenes/sistema/static/carrito.png"
                                 NavigateUrl='<%# Bind("url_producto") %>' />
							</ItemTemplate>
							<ItemStyle HorizontalAlign="Center" />
						</asp:TemplateField>
						<asp:TemplateField ShowHeader="False" HeaderText="Gastos">
							<ItemTemplate>
								<asp:HyperLink ID="ib_gastos" runat="server" data-fancybox-type="iframe" CssClass="fancybox fancybox.iframe" ImageUrl="../imagenes/sistema/static/dinero_dos.png" Text="Gastos" 
                                 NavigateUrl='<%# Bind("url_gasto") %>'/>
							</ItemTemplate>
							<ItemStyle HorizontalAlign="Center" />
						</asp:TemplateField>
						<asp:TemplateField ShowHeader="False" HeaderText="SOAP">
							<ItemTemplate>
								<asp:HyperLink ID="ib_valor" runat="server" data-fancybox-type="iframe" CssClass="fancybox fancybox.iframe" ImageUrl="../imagenes/sistema/static/alert.png" Text="valor" 
                                 NavigateUrl='<%# Bind("url_soap") %>'/>
							</ItemTemplate>
							<ItemStyle HorizontalAlign="Center" />
						</asp:TemplateField>
						<asp:TemplateField ShowHeader="False" HeaderText="Prod.Cliente">
							<ItemTemplate>
								<asp:HyperLink ID="ib_ProdCliente" runat="server" data-fancybox-type="iframe" CssClass="fancybox fancybox.iframe" ImageUrl="../imagenes/sistema/static/creditos.jpg" Text="valor" 
                                 NavigateUrl='<%# Bind("url_prod") %>'/>
							</ItemTemplate>
							<ItemStyle HorizontalAlign="Center" />
						</asp:TemplateField>
						<asp:TemplateField ShowHeader="False" HeaderText="Forma Pago">
							<ItemTemplate>
								<asp:HyperLink ID="ib_forma_pago" runat="server" data-fancybox-type="iframe" CssClass="fancybox fancybox.iframe" ImageUrl="../imagenes/sistema/static/formas_de_pago.jpg" Text="forma pago" 
                                 NavigateUrl='<%# Bind("url_forma_pago") %>'/>
							</ItemTemplate>
							<ItemStyle HorizontalAlign="Center" />
						</asp:TemplateField>
						<asp:TemplateField ShowHeader="False" HeaderText="Contratos">
							<ItemTemplate>
								<asp:HyperLink ID="ib_contratos" runat="server" data-fancybox-type="iframe" CssClass="fancybox fancybox.iframe" ImageUrl="../imagenes/sistema/static/contrato2.gif" Text="Contratos" 
                                 NavigateUrl='<%# Bind("url_contrato") %>'/>
							</ItemTemplate>
							<ItemStyle HorizontalAlign="Center" />
						</asp:TemplateField>
                        <asp:TemplateField ShowHeader="False" HeaderText="Alertas">
							<ItemTemplate>
								<asp:HyperLink ID="ib_alerta" runat="server" data-fancybox-type="iframe" CssClass="fancybox fancybox.iframe" ImageUrl="../imagenes/sistema/static/warning.png" Text="Contratos" 
                                 NavigateUrl='<%# Bind("url_alerta") %>'/>
							</ItemTemplate>
							<ItemStyle HorizontalAlign="Center" />
						</asp:TemplateField>
						<asp:TemplateField ShowHeader="False" HeaderText="Financiera">
							<ItemTemplate>
								<asp:HyperLink ID="ib_financiera" runat="server" data-fancybox-type="iframe" CssClass="fancybox fancybox.iframe"
									ImageUrl="../imagenes/sistema/static/edificio.png" Text="Financiera" NavigateUrl='<%# Bind("url_financiera") %>' />
							</ItemTemplate>
							<ItemStyle HorizontalAlign="Center" />
						</asp:TemplateField>
						<asp:TemplateField ShowHeader="False" HeaderText="Operacion Gasto">
							<ItemTemplate>
								<asp:HyperLink ID="oper_gasto" runat="server" data-fancybox-type="iframe" CssClass="fancybox fancybox.iframe"
									ImageUrl="../imagenes/sistema/static/dinero.png" Text="Operacion Gasto" NavigateUrl='<%# Bind("url_oper_gasto") %>' />
							</ItemTemplate>
							<ItemStyle HorizontalAlign="Center" />
						</asp:TemplateField>
						<asp:TemplateField ShowHeader="False" HeaderText="Cliente TAG">
							<ItemTemplate>
								<asp:HyperLink ID="cliente_tag" runat="server" data-fancybox-type="iframe" CssClass="fancybox fancybox.iframe" ImageUrl="../imagenes/sistema/static/tag.jpg" Text="Operacion Gasto" NavigateUrl='<%# Bind("url_cliente_tag") %>' />
							</ItemTemplate>
							<ItemStyle HorizontalAlign="Center" />
						</asp:TemplateField>

						<asp:TemplateField HeaderText="FINANCIERA" meta:resourcekey="TemplateFieldResource1">
							<ItemTemplate>
								<asp:DropDownList ID="dl_financiera" MaxLength="120" Height="16px" runat="server" Width="120px" Font-Size="7pt" AutoPostBack="false" OnSelectedIndexChanged="dl_financiera_SelectedIndexChanged">
								</asp:DropDownList>
							</ItemTemplate>
							<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
						</asp:TemplateField>

					</Columns>
					<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
					<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
					<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
					<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
					<EditRowStyle BackColor="#2461BF" />
					<AlternatingRowStyle BackColor="White" />
				</asp:GridView>
				<br />
			</td>
		</tr>
		
	</table>
	<asp:Button ID="Button3" runat="server" Font-Names="Arial" Font-Size="X-Small" Text="Guardar" OnClick="Button21_Click" TabIndex="16" />
</asp:Content>