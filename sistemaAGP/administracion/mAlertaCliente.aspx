<%@ Page Title="" Language="C#" MasterPageFile="~/Adm.Master" AutoEventWireup="true" CodeBehind="mAlertaCliente.aspx.cs" Inherits="sistemaAGP.administracion.mAlertaCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<style type="text/css">
        .style1
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: small;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<script type="text/javascript" src="../jquery-1.7.2.min.js"></script>
	<script type="text/javascript" src="../jquery.mousewheel-3.0.6.pack.js"></script>
	<script type="text/javascript" src="../jquery.fancybox.js?v=2.0.6"></script>
	<link rel="Stylesheet" type="text/css" href="../jquery.fancybox.css?v=2.0.6" media="screen" />
	<script type="text/javascript">
		$(document).ready(function () {
			$('.fancybox').fancybox({
				maxWidth: 300,
				maxHeight: 500,
				fitToView: false,
				width: 300,
				height: 500,
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
	<table>
    <tr>
    <td>
        <span class="style1">Familia de Productos</span>
    </td>
    <td>
    
        <asp:DropDownList ID="dl_familia" runat="server" Height="16px" Width="204px" AutoPostBack="true"
            onselectedindexchanged="dl_familia_SelectedIndexChanged" 
            style="font-size: x-small">
        </asp:DropDownList>
    
    </td>
    
    </tr>
    
    </table>
    <table>
    <tr>
    <td>
    
    
    <asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" OnRowDataBound="gr_dato_RowDataBound" CellPadding="4" Font-Names="Arial" Font-Size="X-Small" ForeColor="#333333" GridLines="None" EnableModelValidation="True" Width="850px" OnSelectedIndexChanged="gr_dato_SelectedIndexChanged" DataKeyNames="id_alerta,codigo_estado,contador_estado,id_documento">
        <RowStyle BackColor="#EFF3FB" />
        <Columns>
			<asp:BoundField AccessibleHeaderText="id_alerta" DataField="id_alerta" HeaderText="Código" visible ="false"/>
			<asp:BoundField AccessibleHeaderText="codigo_estado" DataField="codigo_estado" HeaderText="Descripción" Visible ="false" />



              <asp:TemplateField HeaderText="Habilitado" 
                                       meta:resourcekey="TemplateFieldResource1" 
                                       >
						<ItemTemplate>
							<asp:CheckBox ID="check_habilitado" MaxLength="2" Height="16px" runat="server" Checked='<%# Bind("chk_habilitado") %>' Width="20px" AutoCompleteType="Disabled" Font-Size="7pt"></asp:CheckBox>
						
						</ItemTemplate>
					            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
					</asp:TemplateField>

            
            <asp:BoundField AccessibleHeaderText="estado" DataField="descripcion" 
                                HeaderText="estado" />
                                <asp:TemplateField HeaderText="Correos" meta:resourcekey="TemplateFieldResource1">
						<ItemTemplate>
							<asp:TextBox ID="txt_correo" Text='<%# Bind("lista_correo") %>' MaxLength="380" Height="16px" runat="server" Width="150px" AutoCompleteType="Disabled" Font-Size="7pt"></asp:TextBox>
						
						</ItemTemplate>



					</asp:TemplateField>
                            <asp:TemplateField HeaderText="Envia a cliente" 
                                       meta:resourcekey="TemplateFieldResource1" 
                                       >
						<ItemTemplate>
							<asp:CheckBox ID="chk_aviso" MaxLength="2" Height="16px" runat="server" Checked='<%# Bind("envia_adquiriente") %>' Width="20px" AutoCompleteType="Disabled" Font-Size="7pt"></asp:CheckBox>
						
						</ItemTemplate>
					            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
					</asp:TemplateField>


			<asp:TemplateField HeaderText="Dias Aviso" meta:resourcekey="TemplateFieldResource1" HeaderImageUrl="~/imagenes/sistema/static/amarillo.png">
				<ItemTemplate>
					<asp:TextBox ID="txt_aviso" Text='<%# Bind("dias_primer_aviso") %>' MaxLength="2" Height="16px" runat="server" Width="20px" AutoCompleteType="Disabled" Font-Size="7pt"> </asp:TextBox>
				</ItemTemplate>
				<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
			</asp:TemplateField>
			
					
					
					
				   <asp:TemplateField HeaderText="Dias Termino" meta:resourcekey="TemplateFieldResource1" HeaderImageUrl="~/imagenes/sistema/static/rojo.png">
                            
						<ItemTemplate>
							<asp:TextBox ID="txt_termino" text = '<%# Bind("dias_ultimo_aviso") %>' MaxLength="2" Height="16px" runat="server" Width="20px" AutoCompleteType="Disabled" Font-Size="7pt"></asp:TextBox>
						
						</ItemTemplate>
					            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
					</asp:TemplateField>
		
		
			<asp:TemplateField HeaderText="Dias Caducidad" meta:resourcekey="TemplateFieldResource1">
				<ItemTemplate>
					<asp:TextBox ID="txt_caducidad" text = '<%# Bind("caducidad_estado") %>' MaxLength="2" Height="16px" runat="server" Width="20px" AutoCompleteType="Disabled" Font-Size="7pt"></asp:TextBox>
				</ItemTemplate>
				<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
			</asp:TemplateField>
		
		
		
			<asp:TemplateField HeaderText="Contador" meta:resourcekey="TemplateFieldResource1">
				<ItemTemplate>
					<asp:DropDownList ID="dl_estado" MaxLength="120" Height="16px" runat="server" Width="120px"  Font-Size="7pt" AutoPostBack="false" OnSelectedIndexChanged="dl_estado_SelectedIndexChanged"></asp:DropDownList>
				</ItemTemplate>
				<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
			</asp:TemplateField>
			
			
			
			<asp:TemplateField HeaderText="Documento" meta:resourcekey="TemplateFieldResource1">
				<ItemTemplate>
					<asp:DropDownList ID="dl_documento" MaxLength="120" Height="16px" runat="server" Width="120px" Font-Size="7pt" AutoPostBack="false" OnSelectedIndexChanged="dl_estado_SelectedIndexChanged">
					</asp:DropDownList>
				</ItemTemplate>
				<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
			</asp:TemplateField>
			<asp:TemplateField HeaderText="Orden" meta:resourcekey="TemplateFieldResource1">
				<ItemTemplate>
					<asp:HyperLink ID="url_modulo" runat="server" data-fancybox-type="iframe" CssClass="fancybox fancybox.iframe" ImageUrl="../imagenes/sistema/static/edificio.png" Text="Sucursales" NavigateUrl='<%# Bind("url_modulo") %>' />
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
		
		

    </td>
    
    </tr>
    
    </table>
	<table>
		<tr>
			<td>
				<asp:Button runat="server" Text="Grabar" OnClick="presionado" Visible="false" ID="Button2" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" />
			</td>

			</tr>

			</table>
</asp:Content>
