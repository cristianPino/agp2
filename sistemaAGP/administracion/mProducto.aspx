<%@ Page Language="C#" MasterPageFile="~/Adm.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="mProducto.aspx.cs" Inherits="sistemaAGP.mProducto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

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
				width: 400,
				height: 300,
				autoSize: true,
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

	<table style="width: 347px; height: 54px">
		<tr>
			<td style="border-style: none; border-color: inherit; border-width: 0; text-align: left;
				width: 836px;" >
				<asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="X-Small"
					Text="Administracion de Operaciones"></asp:Label>
				<br />
				<table style="width: 96%; font-family: Arial, Helvetica, sans-serif; font-size: x-small;
					height: 31px;">
					<tr>
						<td style="width: 56px; text-align: right; height: 27px;">
							Codigo
							<td style="width: 126px; text-align: left; height: 27px;">
								<asp:TextBox ID="txt_codigo" runat="server" Font-Names="Arial" Font-Size="X-Small"
									MaxLength="4" TabIndex="1"></asp:TextBox>
							</td>
							<td style="width: 8px; text-align: right; height: 27px;">
								Operacion
							</td>
							<td style="text-align: left; height: 27px;">
								<asp:TextBox ID="txt_operacion" runat="server" Font-Names="Arial" Font-Size="X-Small"
									MaxLength="100" Width="193px" TabIndex="3"></asp:TextBox>
							</td>
						</td>
					</tr>
					<tr>
						<td style="width: 56px; text-align: right; height: 5px;">
							url operacion
						</td>
						<td style="text-align: left; height: 5px;">
							<asp:TextBox ID="txt_url_operacion"  runat="server" Font-Names="Arial" Font-Size="X-Small" MaxLength="100" Width="214px" TabIndex="3" Height="20px"></asp:TextBox>
						</td>
						<td style="height: 5px">
							imagen<td style="width: 836px; text-align: right; height: 5px;">
								<asp:TextBox ID="txt_imagen" runat="server" Font-Names="Arial" Font-Size="X-Small"
									MaxLength="100" TabIndex="1" Width="195px" Style="margin-left: 0px"></asp:TextBox>
							</td>
					</tr>
					<tr>
					<td style="width: 56px">
					
							tamaño<td style="width: 836px; text-align: right; height: 5px;">
								<asp:TextBox ID="txt_tamano" runat="server" Font-Names="Arial" Font-Size="X-Small"
									MaxLength="100" TabIndex="1" Width="215px" Style="margin-left: 0px"></asp:TextBox>
							
					</td>
					</tr>
				</table>
				<table>
					<tr>
						<td>
							<asp:Button ID="Button1" runat="server" Font-Names="Arial" Font-Size="X-Small" Text="Guardar"
								OnClick="Button1_Click" TabIndex="16" />
							
						</td>
						<td>
							&nbsp;<asp:Button ID="Button2" runat="server" Font-Names="Arial" Font-Size="X-Small"
								OnClick="Button2_Click" Text="Limpiar" />
						</td>
					</tr>
				</table>
				
				<asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" CellPadding="4"
					Font-Names="Verdana" Font-Size="X-Small" ForeColor="#333333" GridLines="None"
					OnSelectedIndexChanged="gr_dato_SelectedIndexChanged" Height="16px" Width="30px">
					<RowStyle BackColor="#EFF3FB" />
					<Columns>
						<asp:BoundField DataField="codigo" HeaderText="Codigo" AccessibleHeaderText="codigo" />
						<asp:TemplateField HeaderText="Operacion">
							<ItemTemplate>
								<asp:TextBox ID="txt_operacion" Height="16px" MaxLength="500" runat="server" Text='<%# Bind("operacion") %>' Width="200px" AutoCompleteType="Disabled"  Font-Size="7pt"></asp:TextBox>
							</ItemTemplate>
						</asp:TemplateField>
						  <asp:TemplateField HeaderText="Tamaño Ventana"  >
                    <ItemTemplate >
                        <asp:TextBox ID="txt_tamanoVen" Height="16px" MaxLength="500"  runat="server" Text='<%# Bind("tamanoVen") %>' Width="200px" AutoCompleteType="Disabled" OnTextChanged="txt_tamanoVen_TextChanged" Font-Size="7pt" ></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>

						
						<asp:TemplateField ShowHeader="False" HeaderText="Documentos" ItemStyle-VerticalAlign="Middle"
							ItemStyle-HorizontalAlign="Center">
							<ItemTemplate>
								<asp:HyperLink ID="url_documento" data-fancybox-type="iframe" CssClass="fancybox fancybox.iframe" runat="server" ImageUrl="../imagenes/sistema/static/documentos.gif" Text="Estado" NavigateUrl='<%# Bind("url_documento") %>' />
							</ItemTemplate>
							<ControlStyle Height="35px" Width="25px" />
						</asp:TemplateField>
						<asp:TemplateField ShowHeader="False" HeaderText="Solicicitudes RC" ItemStyle-VerticalAlign="Middle"
							ItemStyle-HorizontalAlign="Center">
							<ItemTemplate>
								<asp:HyperLink ID="url_solicitud" data-fancybox-type="iframe" CssClass="fancybox fancybox.iframe" runat="server" ImageUrl="../imagenes/sistema/static/rc.jpg" Text="Estado" NavigateUrl='<%# Bind("url_solicitud") %>' />
							</ItemTemplate>
							<ControlStyle Height="35px" Width="25px" />
						</asp:TemplateField>
					</Columns>
					<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
					<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
					<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
					<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
					<EditRowStyle BackColor="#2461BF" />
					<AlternatingRowStyle BackColor="White" />
				</asp:GridView>
				<table>
					<tr>
						<td style="width: 47px">
							<asp:Button ID="editar" runat="server" Font-Names="Arial" Font-Size="X-Small" Text="editar"
								OnClick="editar_Click" TabIndex="16" />
							<asp:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server" TargetControlID="editar"
								ConfirmText="¿Esta seguro de actualizar Operacion?" />
							</asp:ConfirmButtonExtender>
						</td>
						
					</tr>
				</table>
				<asp:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="Button1"
								ConfirmText="¿Esta seguro de ingresar una Operacion?" />
							</asp:ConfirmButtonExtender>
</asp:Content>