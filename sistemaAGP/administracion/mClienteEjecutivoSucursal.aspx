<%@ Page Language="C#" MasterPageFile="~/AGP.Master" AutoEventWireup="true" CodeBehind="mClienteEjecutivoSucursal.aspx.cs" Inherits="sistemaAGP.mClienteEjecutivoSucursal" Title="Administracion de Gastos por cliente" %>

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



	<div>
		<table bgcolor="#E5E5E5" style="width: 459px">
			<tr>
				<td>
					<table style="width: 74%; font-family: Arial, Helvetica, sans-serif; font-size: x-small" bgcolor="#E5E5E5">
						</table>
					<table style="width: 99%; font-family: Arial, Helvetica, sans-serif; font-size: x-small" bgcolor="#E5E5E5">
						<tr>
							<td style="width: 56px;">
								Cliente
							</td>
							<td colspan="3" style="width: 126px; text-align: left">
								<asp:DropDownList ID="dl_cliente" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="20px" Width="350px" TabIndex="3" AutoPostBack="True" OnSelectedIndexChanged="dl_cliente_SelectedIndexChanged" CssClass="style5">
								</asp:DropDownList>
							</td>
							
						</tr>
						

					</table>
				</td>
			</tr>
		</table>
	</div>
	
	<asp:Button  Visible="false" ID="Button2" runat="server" Font-Names="Arial" Font-Size="X-Small" OnClick="Button2_Click" Text="Limpiar" />
	<asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Names="Arial" Font-Size="X-Small" ForeColor="#333333" GridLines="None" OnRowEditing="gr_dato_RowEditing" OnSelectedIndexChanged="gr_dato_SelectedIndexChanged">
		<RowStyle BackColor="#EFF3FB" />
		<Columns>
			<asp:BoundField AccessibleHeaderText="id_Sucursal" DataField="id_Sucursal" HeaderText="id_Sucursal" />
			
				
					<asp:BoundField AccessibleHeaderText="descripcion" DataField="descripcion" HeaderText="Descripcion" />
				
				
			
			
			
			<asp:TemplateField ShowHeader="False" HeaderText="EJECUTIVOS">
				<ItemTemplate>
					<asp:HyperLink ID="ib_ejecutivo" data-fancybox-type="iframe" CssClass="fancybox fancybox.iframe" runat="server" ImageUrl="../imagenes/sistema/static/browser.png" Text="modulo" NavigateUrl='<%# Bind("url_ejecutivo") %>' />
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
	<asp:Button ID="Button1" runat="server" Font-Names="Arial" Font-Size="X-Small" Visible="false" Text="Guardar" OnClick="Button1_Click" TabIndex="16" />
	<cc1:ConfirmButtonExtender ID="Button1_ConfirmButtonExtender" runat="server" TargetControlID="Button1" ConfirmText="¿Esta seguro de ingresar un nuevo tipo de gasto?">
	</cc1:ConfirmButtonExtender>
	<asp:Button ID="bt_editar" runat="server" Text="Editar" Font-Size="X-Small" Visible="False" OnClick="bt_editar_Click" />
	<cc1:ConfirmButtonExtender ID="bt_editar_ConfirmButtonExtender" runat="server" TargetControlID="bt_editar" ConfirmText="¿Esta seguro de editar los gastos?">
	</cc1:ConfirmButtonExtender>
	<br />
</asp:Content>