<%@ Page Language="C#" MasterPageFile="~/Adm.Master" AutoEventWireup="true" CodeBehind="mEstado.aspx.cs" Inherits="sistemaAGP.mEstado" Title="Administracion de Flujo de Trabajo" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">
    
     <link rel="stylesheet" href="../sitio.css" />
        <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7/jquery.min.js"></script> 
        <script type="text/javascript" src="../jquery-1.7.2.min.js"></script>
	    <script type="text/javascript" src="../jquery.mousewheel-3.0.6.pack.js"></script>
	    <script type="text/javascript" src="../jquery.fancybox.js?v=2.0.6"></script>
        <script type="text/javascript" src="../ScrollableGrid.js"></script>
        <script type="text/javascript" src="../jquery.tablednd.0.8.min.js"></script>
        <script type="text/javascript" src="../jquery.highlightFade.js"></script>
        <link rel="Stylesheet" type="text/css" href="../jquery.fancybox.css?v=2.0.6" media="screen" />  

        <script type="text/javascript">
            function grilla_cabecera() 
            {
                $('#<%=GridView1.ClientID %>').Scrollable();
            }
         </script>

         <style type="text/css">
             .GbiHighlight
             {
                background-color: Gray;
             }
         </style>

         <script type="text/javascript">

             $(document).ready(function () {
                 Sys.WebForms.PageRequestManager.getInstance().add_endRequest(load_lazyload);
                 load_lazyload();
             });

             function load_lazyload() {
                 var gr1 = "#<%=GridView1.ClientID %>";
                 $(gr1).tableDnD({
                     onDragClass: "GbiHighlight",
                     onDrop: function (table, row) {
                         alert($('#<%=GridView1.ClientID %>').tableDnD.serialize());
                         var rows = table.tBodies[0].rows;
                         var debugStr = "Row dropped was " + row.id + ". New order: ";
                         for (var i = 0; i < rows.length; i++) {
                             debugStr += rows[i].id + "";
                         }
                         dragHandle: ".dragHandle"
                         $("#debugArea").html(debugStr);
                     },
                     onDragStart: function (table, row) {
                         $("#debugArea").html("Started dragging row " + row.id);
                     }
                 });

                 $(function () {
                     $("#<%=GridView1.ClientID %> td").hover(function () {
                         $("td", $(this).closest("tr")).addClass("hover_row");
                     }, function () {
                         $("td", $(this).closest("tr")).removeClass("hover_row");
                     });
                 });  
             }          
         </script>

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

 
     <style type="text/css">
         .style2
         {
             width: 8%;
             height: 41px;
         }
         .style3
         {
             width: 1258px;
         }
         .style5
         {
             width: 77px;
         }
         .style6
         {
             width: 221px;
         }
         .style7
         {
             width: 83px;
         }
         .style8
         {
             width: 23px;
         }
         .style10
         {
             width: 87px;
         }
         .style11
         {
             width: 248px;
             height: 41px;
         }
         .style12
         {
             height: 41px;
         }
         
         .hover_row 
         {  
            background-color: Gray; 
         }

         td
	     {
            cursor:pointer;
	     }
	     
     </style>

</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
	<table class="table_sec">
        <tr>
            <td class="style3">
                <asp:Label ID="Label1" runat="server" Text="Administracion de Flujos de trabajo Familia: "></asp:Label>
                <asp:Label ID="lbl_familia" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <table class="table_n">
        <tr>
            <td class="style2">
                <strong>
                    Grupo Familia
                </strong>
            </td>
            <td class="style11">
                <asp:DropDownList ID="dpl_grupo" runat="server" 
                    onselectedindexchanged="dpl_grupo_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
            </td>
            <td class="style12">
                <asp:LinkButton ID="lnkNuevo" runat="server" CssClass="button" Text="Nuevo" 
                    ForeColor="White" onclick="lnkNuevo_Click"></asp:LinkButton>
            </td>
        </tr>
    </table>

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        OnRowDataBound="gr_dato_RowDataBound" CellPadding="4" CssClass="tabla_datos"
                OnSelectedIndexChanged="gr_dato_SelectedIndexChanged" 
        DataKeyNames="contador_estado,id_grupo" 
        HeaderStyle-CssClass="nodrag nodrop" Width="1231px" >
        <Columns>
            <asp:BoundField AccessibleHeaderText="codigo_estado" DataField="codigo_estado" HeaderText="Código" Visible="true" />
			<asp:TemplateField HeaderText="Descripcion" meta:resourcekey="TemplateFieldResource1">
				<ItemTemplate>
					<asp:TextBox ID="descripcion" Text='<%# Bind("descripcion") %>' MaxLength="380" Height="16px" runat="server" Width="150px" AutoCompleteType="Disabled" Font-Size="7pt"></asp:TextBox>
				</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField HeaderText="Correo cliente" meta:resourcekey="TemplateFieldResource1">
				<ItemTemplate>
					<asp:CheckBox ID="chk_cliente" Checked='<%# Bind("correo_cliente") %>'  Height="16px" runat="server" Width="20px" AutoCompleteType="Disabled" Font-Size="7pt"></asp:CheckBox>
				</ItemTemplate>
				<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
			</asp:TemplateField>
			
			<asp:TemplateField HeaderText="Correo Empresa" meta:resourcekey="TemplateFieldResource2">
				<ItemTemplate>
					<asp:CheckBox ID="chk_empresa" MaxLength="2" Checked='<%# Bind("correo_empresa") %>' Height="16px" runat="server" Width="20px" AutoCompleteType="Disabled" Font-Size="7pt"></asp:CheckBox>
				</ItemTemplate>
				<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
			</asp:TemplateField>
			<asp:TemplateField HeaderText="Estado Empresa" Visible="false" meta:resourcekey="TemplateFieldResource3">
				<ItemTemplate>
					<asp:CheckBox ID="chk_estadoempresa" MaxLength="2" Checked='<%# Bind("cliente_estado") %>' Height="16px" runat="server" Width="20px" AutoCompleteType="Disabled" Font-Size="7pt"></asp:CheckBox>
				</ItemTemplate>
				<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
			</asp:TemplateField>
			<asp:TemplateField HeaderText="chk_llamada" meta:resourcekey="TemplateFieldResource3">
				<ItemTemplate>
					<asp:CheckBox ID="chk_llamada" MaxLength="2" Checked='<%# Bind("llamada") %>' Height="16px" runat="server" Width="20px" AutoCompleteType="Disabled" Font-Size="7pt"></asp:CheckBox>
				</ItemTemplate>
				<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
			</asp:TemplateField>
			<asp:TemplateField HeaderText="Correos" meta:resourcekey="TemplateFieldResource1">
				<ItemTemplate>
					<asp:TextBox ID="lista_correo" Text='<%# Bind("lista_correo") %>' MaxLength="380" Height="16px" runat="server" Width="150px" AutoCompleteType="Disabled" Font-Size="7pt"></asp:TextBox>
				</ItemTemplate>
			</asp:TemplateField>
			<asp:TemplateField HeaderText="Envia a cliente" meta:resourcekey="TemplateFieldResource1">
				<ItemTemplate>
					<asp:CheckBox ID="chk_adquiriente" MaxLength="2" Height="16px" runat="server" Checked='<%# Bind("envia_adquirientes") %>' Width="20px" AutoCompleteType="Disabled" Font-Size="7pt"></asp:CheckBox>
				</ItemTemplate>
				<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
			</asp:TemplateField>
			<asp:TemplateField HeaderText="Dias Aviso" meta:resourcekey="TemplateFieldResource1" HeaderImageUrl="~/imagenes/sistema/static/amarillo.png">
				<ItemTemplate>
					<asp:TextBox ID="dias_primer_a" Text='<%# Bind("dias_primer_a") %>' MaxLength="2" Height="16px" runat="server" Width="20px" AutoCompleteType="Disabled" Font-Size="7pt"> </asp:TextBox>
				</ItemTemplate>
				<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
			</asp:TemplateField>
			<asp:TemplateField HeaderText="Dias Termino" meta:resourcekey="TemplateFieldResource1" HeaderImageUrl="~/imagenes/sistema/static/rojo.png">
				<ItemTemplate>
					<asp:TextBox ID="dias_ultimo_a" Text='<%# Bind("dias_ultimo_a") %>' MaxLength="2" Height="16px" runat="server" Width="20px" AutoCompleteType="Disabled" Font-Size="7pt"></asp:TextBox>
				</ItemTemplate>
				<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
			</asp:TemplateField>
			<asp:TemplateField HeaderText="Horas Caducidad" meta:resourcekey="TemplateFieldResource1">
				<ItemTemplate>
					<asp:TextBox ID="caducidad_estado" Text='<%# Bind("caducidad_estado") %>' MaxLength="2" Height="16px" runat="server" Width="20px" AutoCompleteType="Disabled" Font-Size="7pt"></asp:TextBox>
				</ItemTemplate>
				<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
			</asp:TemplateField>
			<asp:TemplateField HeaderText="Contador" Visible="false" meta:resourcekey="TemplateFieldResource1">
				<ItemTemplate>
					<asp:DropDownList ID="contador_estado" CssClass="select" MaxLength="120" Height="16px" runat="server" Width="120px" Font-Size="7pt" AutoPostBack="false" OnSelectedIndexChanged="dl_estado_SelectedIndexChanged">
					</asp:DropDownList>
				</ItemTemplate>
				<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
			</asp:TemplateField>
            <asp:TemplateField HeaderText="Grupo Familia" meta:resourcekey="TemplateFieldResource1">
				<ItemTemplate>
					<asp:DropDownList ID="id_grupo" CssClass="select" MaxLength="120" Height="16px" runat="server" Width="120px" Font-Size="7pt" AutoPostBack="false" OnSelectedIndexChanged="dl_estado_SelectedIndexChanged">
					</asp:DropDownList>
				</ItemTemplate>
				<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
			</asp:TemplateField>
            <asp:TemplateField HeaderText="Documento" meta:resourcekey="TemplateFieldResource1">
				<ItemTemplate>
					<asp:HyperLink  CssClass="fancybox fancybox.iframe" ID="url_documento" runat="server" data-fancybox-type="iframe"  ImageUrl="../imagenes/sistema/static/document.png" Text="Sucursales" NavigateUrl='<%# Bind("url_documento") %>' />
				</ItemTemplate>
				<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
			</asp:TemplateField>
			<asp:TemplateField HeaderText="Comportamiento" meta:resourcekey="TemplateFieldResource1">
				<ItemTemplate>
					<asp:HyperLink CssClass="fancybox fancybox.iframe" ID="url_comportamiento" runat="server"
						data-fancybox-type="iframe" ImageUrl="../imagenes/sistema/static/document.png"
						Text="Sucursales" NavigateUrl='<%# Bind("url_comportamiento") %>' />
				</ItemTemplate>
				<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
			</asp:TemplateField>
			<asp:TemplateField HeaderText="Regla" meta:resourcekey="TemplateFieldResource1">
				<ItemTemplate>
					<asp:HyperLink  CssClass="fancybox fancybox.iframe" ID="url_modulo" runat="server" data-fancybox-type="iframe"  ImageUrl="../imagenes/sistema/static/edificio.png" Text="Sucursales" NavigateUrl='<%# Bind("url_modulo") %>' />
				</ItemTemplate>
				<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
			</asp:TemplateField>
            <asp:TemplateField HeaderText="Estado Manual" meta:resourcekey="TemplateFieldResource1">
				<ItemTemplate>
					<asp:CheckBox ID="chk_emanual" MaxLength="2" Height="16px" runat="server" Checked='<%# Bind("estado_manual") %>' Width="20px" AutoCompleteType="Disabled" Font-Size="7pt"></asp:CheckBox>
				</ItemTemplate>
				<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
			</asp:TemplateField>
        </Columns>
        <HeaderStyle CssClass="tr_cabecera" />
        <RowStyle CssClass="tr_fila" />
        <AlternatingRowStyle BackColor="#F3F3F3" />
    </asp:GridView>
    <asp:Panel ID="pnl_actualizar" Visible="true" runat="server" Width="1227px">
    <div class="div_objetos">
        <table class="table_sec">
            <tr>
                <td>
                    <asp:Button runat="server" CssClass="button" Text="Actualizar" OnClick="presionado" Visible="true"
                    ID="Button2" Width="77px" />
                </td>
            </tr>
        </table>
    </div>
    </asp:Panel>

    <asp:Panel ID="pnl_Nuevo" runat="server" CssClass="estado" Height="125px" 
        Width="584px">
        <div class="div_fondo">
            <table class="table_n">
                <tr>
                    <td>
                        <strong>
                            Grupo Familia 
                        </strong>
                    </td>
                    <td>
                        <asp:Label ID="lbl_gfamilia" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style5">
                        <strong>
                            Descripcion 
                        </strong>    
                    </td>
                    <td class="style6">
                        <asp:TextBox CssClass="tabla-normal" ID="TextBox1" runat="server" Width="210px"></asp:TextBox>
                    </td>
                    <td class="style7">
                        <strong>
                            Correo Cliente
                        </strong>
                    </td>
                    <td class="style8">
                        <asp:CheckBox CssClass="tabla-normal" ID="chk_aviso" MaxLength="2" Height="16px" runat="server" Checked='<%# Bind("correo_cliente") %>' Width="20px" AutoCompleteType="Disabled" Font-Size="7pt"></asp:CheckBox>
                    </td>
                    <td class="style10">
                        <strong>
                            Correo Empresa
                        </strong>
                    </td>
                    <td>
                        <asp:CheckBox CssClass="tabla-normal" ID="CheckBox1" MaxLength="2" Height="16px" runat="server" Checked='<%# Bind("Correo_empresa") %>' Width="20px" AutoCompleteType="Disabled" Font-Size="7pt"></asp:CheckBox>
                    </td>
                </tr>
                <tr>
                    <td class="style5">
                        <strong>
                            Orden
                        </strong>
                    </td>
                    <td class="style6">
						<asp:TextBox CssClass="tabla-normal" Height="17px" Width="35px" ID="TextBox3" runat="server"></asp:TextBox>
                    </td>
                    <td class="style7">
                        <strong>
                            Estado Manual
                        </strong>
                    </td>
                    <td class="style8">
						<asp:CheckBox CssClass="tabla-normal" ID="CheckBox3" MaxLength="2" Visible="true" Height="16px" runat="server" Checked='<%# Bind("estado_manual") %>' Width="20px" AutoCompleteType="Disabled" Font-Size="7pt"></asp:CheckBox>                        
                    </td>
                    <td class="style10">
                        <strong>
                            Llamada
                        </strong>
                    </td>
                    <td>
						<asp:CheckBox CssClass="tabla-normal" ID="CheckBox4" MaxLength="2" Height="16px" runat="server" Checked='<%# Bind("llamada") %>' Width="20px" AutoCompleteType="Disabled" Font-Size="7pt"></asp:CheckBox>                        
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button runat="server" Text="Grabar" OnClick="grabar"
                            ID="Button1" CssClass="button" Width="63px"/>
                    </td>
                    <td>
                        <asp:Button runat="server" Text="Cerrar" ID="Button4" CssClass="button" 
                            Width="64px" onclick="Button4_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
    <cc1:modalpopupextender ID="mpeCerrar" runat="server" CancelControlID="Button4" PopupControlID="pnl_Nuevo" TargetControlID="lnkNuevo" BackgroundCssClass="cerrar">
	</cc1:modalpopupextender>
	<cc1:confirmbuttonextender ID="cbeCerrar" runat="server"  DisplayModalPopupID="mpeCerrar" TargetControlID="lnkNuevo">
	</cc1:confirmbuttonextender>
</asp:Content>