<%@ Page Title="" Language="C#" MasterPageFile="~/Adm.Master" AutoEventWireup="true" CodeBehind="mDocumentoEstado.aspx.cs" Inherits="sistemaAGP.administracion.mDocumentoEstado" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
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
		function grilla_cabecera() {
			$('#<%=gr_dato.ClientID %>').Scrollable();
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
			var gr1 = "#<%=gr_dato.ClientID %>";
			$(gr1).tableDnD({
				onDragClass: "GbiHighlight",
				onDrop: function (table, row) {
					alert($('#<%=gr_dato.ClientID %>').tableDnD.serialize());
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
				$("#<%=gr_dato.ClientID %> td").hover(function () {
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
         .style6
         {
             width: 221px;
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
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="div_subcontenido">
	<table class="table">
		<tr>
				<td class="style6">
					Familia :
					<asp:Label ID="lbl_familia" runat="server"></asp:Label>
				</td>
			</tr>
		<tr>
				<td class="style6">
					Estado :
					<asp:Label ID="lbl_estado" runat="server"></asp:Label>
				</td>
			</tr>
		
        </table>
	</div>
		<table>
		<tr>
			<td class="style2">
				<asp:GridView ID="gr_dato" runat="server" CssClass="tabla_datos" AutoGenerateColumns="False"
					CellPadding="4" Font-Names="Arial" Font-Size="X-Small" ForeColor="#333333" GridLines="Horizontal"
					OnSelectedIndexChanged="gr_dato_SelectedIndexChanged" Style="margin-right: 0px"
					Width="360px" DataKeyNames="codigo_documento">
					<RowStyle BackColor="#EFF3FB" />
					<Columns>
						<asp:BoundField AccessibleHeaderText="codigo_documento" DataField="codigo_documento"
							HeaderText="codigo_documento" Visible="false" />
						<asp:BoundField AccessibleHeaderText="descripcion" DataField="descripcion" HeaderText="Documento" />
						
						<asp:TemplateField>
							<HeaderTemplate>
						
							</HeaderTemplate>
							<ItemTemplate>
								<asp:CheckBox ID="chk2" MaxLength="2" Height="16px" runat="server" Width="20px" Checked='<%# Bind("chekalert") %>' AutoCompleteType="Disabled" Font-Size="7pt"></asp:CheckBox>
							</ItemTemplate>
						</asp:TemplateField>
					</Columns>
					<HeaderStyle CssClass="tr_cabecera" />
					<RowStyle CssClass="tr_fila" />
					<AlternatingRowStyle CssClass="tr_fila_alt" />
				</asp:GridView>
				<div >
				<asp:Button ID="Button1" CssClass="button" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" Text="Grabar" OnClick="Button1_Click" Visible="true" />
				</div>
				<br />
			</td>
			</tr>
	</table>
</asp:Content>
