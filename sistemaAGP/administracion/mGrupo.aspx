<%@ Page Title="Grupos Estado" Language="C#" MasterPageFile="~/AGP.Master" AutoEventWireup="true"
	CodeBehind="mGrupo.aspx.cs" Inherits="sistemaAGP.mGrupo" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMenu" runat="server">
	<link rel="stylesheet" href="../sitio.css" />
        <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7/jquery.min.js"></script> 
        <script type="text/javascript" src="../jquery-1.7.2.min.js"></script>
	    <script type="text/javascript" src="../jquery.mousewheel-3.0.6.pack.js"></script>
	    <script type="text/javascript" src="../jquery.fancybox.js?v=2.0.6"></script>
        <script type="text/javascript" src="../ScrollableGrid.js"></script>
        <script type="text/javascript" src="../jquery.tablednd.0.8.min.js"></script>
        <link rel="Stylesheet" type="text/css" href="../jquery.fancybox.css?v=2.0.6" media="screen" />  

        <script type="text/javascript">
            function grilla_cabecera() {
            	$('#<%=gr_dato.ClientID %>').Scrollable();
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
        .style5
        {
            width: 48px;
        }
        .style6
        {
            height: 29px;
            width: 71px;
        }
    </style>
</asp:Content>
<asp:content id="Content4" contentplaceholderId="ContenidoCentral" runat="server">   
    <div class="div_subcontenido">
        <table class="table">
            <tr>
                <td>
                    <asp:label id="Label1" runat="server" Text="Administracion de Grupos Estado"></asp:label>    
                </td>
            </tr>
        </table>
        <table class="table">
            <tr>
                <td class="style5">
                    <strong>
                        Grupo
                    </strong>
                </td>
                <td>
                    <asp:textbox id="txt_grupo" runat="server" ontextchanged="txt_grupo_TextChanged">
				    </asp:textbox>
                </td>
            </tr>
        </table>
    </div>
    <div class="div_objetos">
        <table class="table_sec">
            <tr>
                <td class="style6">
                    <asp:button id="Button1" runat="server" CssClass="button"
					text="Guardar" onclick="Button1_Click" tabindex="16" height="21px" />
				<cc1:confirmbuttonextender id="Button1_ConfirmButtonExtender" runat="server" targetcontrolid="Button1"
					confirmtext="¿Esta seguro de actualizar los Grupos?">
                </cc1:confirmbuttonextender>
                </td>
                <td>
                    <asp:button id="bt_editar" runat="server" text="Editar" CssClass="button"
					visible="False" onclick="bt_editar_Click" Height="21px" Width="63px" /><cc1:confirmbuttonextender id="bt_editar_ConfirmButtonExtender"
					runat="server" targetcontrolid="bt_editar" confirmtext="¿Esta seguro de editar los gastos?"></cc1:confirmbuttonextender>
                </td>
            </tr>
        </table>
    </div>
    <p />
    
    <asp:gridview id="gr_dato" runat="server" autogeneratecolumns="False" 
            cellpadding="4" CssClass="tabla_datos" 
            onselectedindexchanged="gr_dato_SelectedIndexChanged" 
            enablemodelvalidation="True" Width="386px">
        <Columns>
            <asp:BoundField AccessibleHeaderText="id_grupo" DataField="id_grupo" 
									HeaderText="Id_grupo" />
				
		    <asp:TemplateField HeaderText="Nombre">
			    <ItemTemplate>
			        <asp:TextBox ID="nombre" Height="16px" MaxLength="50" runat="server" Text='<%# Bind("nombre") %>' Width="200px" AutoCompleteType="Disabled" OnTextChanged="txt_nombre_TextChanged" Font-Size="7pt">
				    </asp:TextBox>
				</ItemTemplate>
			</asp:TemplateField>
        </Columns>
        <HeaderStyle CssClass="tr_cabecera" />
        <RowStyle CssClass="tr_fila" />
        <AlternatingRowStyle CssClass="tr_fila_alt" />
    </asp:gridview>
</asp:content>
