<%@ Page Language="C#" MasterPageFile="~/AGP.Master" AutoEventWireup="true" CodeBehind="mControl_cliente.aspx.cs" Inherits="sistemaAGP.mControl_cliente" Title="Ingreso de Operaciones" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoMenu" runat="server">
	<script type="text/javascript" src="../jquery-1.7.2.min.js"></script>
	<script type="text/javascript" src="../jquery.mousewheel-3.0.6.pack.js"></script>
	<script type="text/javascript" src="../jquery.fancybox.js?v=2.0.6"></script>
	<link rel="Stylesheet" type="text/css" href="../jquery.fancybox.css?v=2.0.6" media="screen" />
	<script type="text/javascript">
		$(document).ready(function () {
			$('.ventana_modal').fancybox({
				fitToView: false,
				width: '80%',
				height: '100%',
				autoSize: false,
				openEffect: 'elastic',
				openSpeed: 150,
				closeEffect: 'elastic',
				closeSpeed: 150,
				closeClick: false,
				closeBtn: true,
				scrolling: 'auto',
				padding: 0,
				type: 'iframe',
				beforeClose: function () {
					return window.confirm('¿Desea cerrar la ventana?');
				},
				helpers: {
					overlay: {
						opacity: 0.9,
						css: {
							'background-color': '#cccccc'
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
<asp:Content ID="Content3" ContentPlaceHolderID="ContenidoCentral" runat="server">
	<asp:UpdatePanel ID="up_combos" runat="server">
		<ContentTemplate>
			<div style="text-align: left; font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 100%;">
				<strong>Ingreso de Operaciones</strong>
			</div>
			<div style="text-align: left; font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 100%;">
				<table style="width: 100%;">
					<tr>
						<td style="width: 50px;">
							Empresa
						</td>
						<td>
							<asp:DropDownList ID="dl_cliente" runat="server" AutoPostBack="true" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 400px;" OnSelectedIndexChanged="dl_cliente_SelectedIndexChanged">
							</asp:DropDownList>
						</td>
					</tr>
					<tr>
						<td>
							Familia
						</td>
						<td>
							<asp:DropDownList ID="dl_familia" runat="server" AutoPostBack="true" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 300px;" OnSelectedIndexChanged="dl_familia_SelectedIndexChanged">
							</asp:DropDownList>
						</td>
					</tr>
				</table>
			</div>
		</ContentTemplate>
	</asp:UpdatePanel>
	<asp:UpdatePanel ID="up_grilla" runat="server">
		<ContentTemplate>
			<asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Names="Verdana" Font-Size="X-Small" ForeColor="#333333" GridLines="None" EnableModelValidation="True" Width="350">
				<Columns>
					<asp:TemplateField HeaderText="Operación" InsertVisible="False">
						<ItemTemplate>
							<asp:HyperLink ID="lnk_operacion" runat="server" NavigateUrl='<%# Eval("url") %>' Text='<%# Eval("operacion") %>' CssClass="ventana_modal" Title='<%# Eval("operacion") %>'></asp:HyperLink>
						</ItemTemplate>
					</asp:TemplateField>
				</Columns>
				<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
				<RowStyle BackColor="#EFF3FB" />
				<AlternatingRowStyle BackColor="White" />
			</asp:GridView>
		</ContentTemplate>
		<Triggers>
			<asp:AsyncPostBackTrigger ControlID="dl_cliente" EventName="SelectedIndexChanged" />
			<asp:AsyncPostBackTrigger ControlID="dl_familia" EventName="SelectedIndexChanged" />
		</Triggers>
	</asp:UpdatePanel>
	<%--<table border="0" style="width: 493px; height: 347px">
		<tr>
			<td style="border-style: none; border-color: inherit; border-width: 0; text-align: left; width: 968px; height: 277px;" align="left" valign="top">
				<asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="X-Small" Text="Ingreso de Operaciones"></asp:Label>
				<br />
				<table style="width: 14%; font-family: Arial, Helvetica, sans-serif; font-size: x-small" bgcolor="#E5E5E5">
					<tr>
						<td style="width: 60px; text-align: right;">
							Empresa
						</td>
						<td style="text-align: left">
							<asp:DropDownList ID="dl_cliente" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 300px;" OnSelectedIndexChanged="dl_cliente_SelectedIndexChanged">
							</asp:DropDownList>
						</td>
					</tr>
					<tr>
						<td style="width: 60px; text-align: right;">
							Familia
						</td>
						<td style="text-align: left">
							<asp:DropDownList ID="dl_familia" runat="server" OnSelectedIndexChanged="dl_familia_SelectedIndexChanged" AutoPostBack="true" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 300px;">
							</asp:DropDownList>
						</td>
					</tr>
				</table>
				<asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Names="Verdana" Font-Size="X-Small" ForeColor="#333333" GridLines="None" DataKeyNames="tamano,url_operacion" OnRowDataBound="gr_dato_RowDataBound">
					<RowStyle BackColor="#EFF3FB" />
					<Columns>
						<asp:BoundField DataField="operacion" HeaderText="Operacion" ItemStyle-Width="300px" />
						<asp:TemplateField ShowHeader="False" HeaderText="">
							<ItemTemplate>
								<asp:ImageButton ID="ib_producto" runat="server" ImageUrl='<%# Bind("imagen")  %>' />
							</ItemTemplate>
							<ControlStyle Height="40px" Width="40px" />
						</asp:TemplateField>
						<asp:BoundField DataField="tamano" Visible="False" />
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
	</table>--%>
     <div class="divInfo">
        <center>
        <asp:Image ID="imgInfo" runat="server" ImageUrl="~/imagenes/sistema/static/hipotecario/mensaje.png"/> 
      <asp:Label ID="lblMensajeAnalisis" runat="server" Text=""></asp:Label>
            </center>
    </div>
</asp:Content>