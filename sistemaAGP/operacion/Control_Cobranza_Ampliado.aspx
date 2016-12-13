<%@ Page Title="Modulo_Cierre AGP S.A." Language="C#" MasterPageFile="~/AGP.Master"
	AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Control_Cobranza_Ampliado.aspx.cs" Inherits="sistemaAGP.Control_Cobranza_Ampliado" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register TagPrefix="agp" TagName="multicliente" Src="~/controles/MultiSelectCombo.ascx" %>
<%@ Register TagPrefix="agp" TagName="multiciudad" Src="~/controles/MultiSelectCombo.ascx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMenu" runat="server">


	<link rel="Stylesheet" href="../sitio.css" />
	<script type="text/javascript" src="../jquery-1.7.2.min.js"></script>
	<script src="../javascript/jquery-1.5.2.min.js" type="text/javascript"></script>
	<script type="text/javascript" src="../jquery.mousewheel-3.0.6.pack.js"></script>
	<script type="text/javascript" src="../jquery.fancybox.js?v=2.0.6"></script>
	<link rel="Stylesheet" type="text/css" href="../jquery.fancybox.css?v=2.0.6" media="screen" />
	<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
	<script type="text/javascript">
		$(function () {
			$("[id*=GridView1] td").hover(function () {
				$("td", $(this).closest("tr")).addClass("hover_row");
			}, function () {
				$("td", $(this).closest("tr")).removeClass("hover_row");
			});
		});
	</script>
	<script type="text/javascript">
		$(document).ready(function () {
			$('.fancybox').fancybox({
				maxWidth: 1200,
				maxHeight: 400,
				fitToView: false,
				width: 1200,
				height: 400,
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
        body
        {
            font-family: Arial;
            font-size: 10pt;
        }
        td
        {
            cursor: pointer;
        }
        .hover_row
        {
            background-color: #FFFFBF;
        }
         .selected_row td
        {
            background-color: #A1DCF2;
        }
        .verticaltext th
		{
		     writing-mode: tb-rl;    
		     filter: flipv fliph;    
		}
    </style>
	
    
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContenidoCentral">
		<div>
	<div>
        <table  class="table">
		<tr>
			<td class="style5">
				<%--		<asp:UpdatePanel ID="up_cliente" runat="server">
					<ContentTemplate>--%>
				<table style="width: 63%; font-family: Arial, Helvetica, sans-serif; font-size: x-small" bgcolor="#E5E5E5">
					<tr>
                        <td>
                            <strong>
                                Cliente
                            </strong>
                        </td>
                        <td>
							<agp:multicliente ID="dl_cliente" runat="server" />
                        </td>
					</tr>
					<%--	</table>--%>	<%--				</ContentTemplate>
				</asp:UpdatePanel>--%><%--					<table style="width: 63%; font-family: Arial, Helvetica, sans-serif; font-size: x-small"
						bgcolor="#E5E5E5">--%>
						<tr>
						
						<td style="vertical-align: middle;" class="style10">
							<strong>Desde</strong>
						</td>
						<td style="vertical-align: middle;">
							<asp:TextBox ID="txt_desde" runat="server" Style="font-family: Arial, Helvetica, sans-serif;
								font-size: x-small; width: 75px;"></asp:TextBox>
							<asp:ImageButton ID="ib_desde" runat="server" ImageUrl="../imagenes/sistema/gif/calendario.gif" />
							<ajaxToolkit:CalendarExtender ID="cal_desde" runat="server" TargetControlID="txt_desde"
								CssClass="calendario" Format="dd/MM/yyyy" PopupButtonID="ib_desde" TodaysDateFormat="dd/MM/yyyy"
								OnClientDateSelectionChanged="checkDate" />
						</td>
							<td style="vertical-align: middle;">
								<strong>Hasta</strong>
							</td>
							<td style="vertical-align: middle;">
								<asp:TextBox ID="txt_hasta" runat="server" Style="font-family: Arial, Helvetica, sans-serif;
									font-size: x-small; width: 75px;"></asp:TextBox>
								<asp:ImageButton ID="ib_hasta" runat="server" ImageUrl="../imagenes/sistema/gif/calendario.gif"
									Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" />
								<ajaxToolkit:CalendarExtender ID="cal_hasta" runat="server" TargetControlID="txt_hasta"
									CssClass="calendario" Format="dd/MM/yyyy" PopupButtonID="ib_hasta" TodaysDateFormat="dd/MM/yyyy"
									OnClientDateSelectionChanged="checkDate" />
							</td>
                    </tr>
					<%--		</table>--%>	<%--			<asp:UpdatePanel ID="UpdatePanel1" runat="server">
					<ContentTemplate>--%>					<%--	<table style="width: 63%; font-family: Arial, Helvetica, sans-serif; font-size: x-small"
							bgcolor="#E5E5E5">--%>
                    <tr>
                        <td class="style9">
                            <strong>
                                Region
                            </strong>
                        </td>
                        <td class="style11">
                            <asp:DropDownList ID="ddl_region" runat="server" CssClass="select" 
								onselectedindexchanged="ddl_region_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                        </td>
                        <td>
                            <strong>
                                Ciudad
                            </strong>
                        </td>
                     <td>
							<agp:multiciudad ID="dl_ciudad" runat="server" />
					 </td>
                    </tr>

                </table>
				<%--					</ContentTemplate>
				</asp:UpdatePanel>--%>
            </td>
        </tr>
        </table>
		<asp:UpdatePanel ID="up_arriba" runat="server">
			<ContentTemplate>
		<div class="div_objetos">
			<table class="table_sec">
				<tr>
					<td>
						<asp:ImageButton ID="ib_buscar" runat="server" CausesValidation="true" AlternateText="Buscar"
							ImageAlign="AbsMiddle" ImageUrl="~/imagenes/sistema/static/panel_control/lupa.png"
							Style="background-color: #ffffff; padding: 2px; border: 1px solid #cccccc;" OnClick="ib_buscar_Click"
							ValidationGroup="filtros" />


					</td>
					<td>
					
						<asp:HyperLink ID="ib_gestion" runat="server" ToolTip="Gestion" class="fancybox fancybox.iframe"
							Visible="false" ImageUrl="../imagenes/sistema/static/document.png" > 
						</asp:HyperLink>
					</td>
					
				</tr>
			</table>
		</div>
	
    </div>
	<p />
			

				&nbsp;<ajaxToolkit:TabContainer ID="tab_datos" runat="server" Width="100%" ActiveTabIndex="0"
		
			ScrollBars="Auto" Font-Size="XX-Small">
	<ajaxToolkit:TabPanel ID="tab_Cant_oper_familia" runat="server" HeaderText="N° de Operaciones"
		Width="100%">
		<ContentTemplate>
			<table>
			<tr>
				<td>
					<asp:ImageButton ID="ib_exportar" runat="server" AlternateText="Exportar" ImageAlign="AbsMiddle"
						ImageUrl="~/imagenes/sistema/static/panel_control/excel.png" Style="background-color: #ffffff;
						padding: 2px; border: 1px solid #cccccc;" Visible="False" OnClick="ib_exportar_Click" />
				</td>
			</tr>
				<tr>
				
					<td>
				
						<asp:GridView ID="gvOrders" runat="server" CellPadding="2" BorderWidth="1px" GridLines="Vertical"
							AutoGenerateColumns="False" DataKeyNames="id_familia" Width="100%"
							CssClass="tabla_datos" OnRowDataBound="gvProducts_RowDataBound" OnPageIndexChanging="gvOrders_PageIndexChanging"
							OnSelectedIndexChanged="gvOrders_SelectedIndexChanged" EnableModelValidation="True"
							OnRowCreated="ProductsGridView_RowCreated">
							<HeaderStyle CssClass="tr_cabecera" />
							<RowStyle CssClass="tr_fila" />
							<AlternatingRowStyle CssClass="tr_fila_alt" />
	</asp:GridView>
				

						<asp:LinkButton ID="lnkDummy" runat="server"></asp:LinkButton>

						<asp:GridView ID="gvDetails" runat="server" AutoGenerateColumns="False" CssClass="tabla_datos"
							BorderStyle="Solid" BorderWidth="1px" CellPadding="2" GridLines="Vertical" DataKeyNames="codigo"
							Width="100%"  Visible="False" OnSelectedIndexChanged="gvDetail_SelectedIndexChanged"
							OnRowDataBound="gvDetail_RowDataBound" EnableModelValidation="True">
							<HeaderStyle CssClass="tr_cabecera" />
							<RowStyle CssClass="tr_fila" />
							<AlternatingRowStyle CssClass="tr_fila_alt" />
						</asp:GridView>

			</td>
			
			</tr> 
		
			</table>

					</ContentTemplate>
				</ajaxToolkit:TabPanel>




				<ajaxToolkit:TabPanel ID="Tab_pesos_oper_familia" runat="server" HeaderText="Montos a Cobrar ($)"
					Width="100%">
					<ContentTemplate>
						<table>
							<tr>
								<td>
									<asp:ImageButton ID="ib_exportar_monto" runat="server" AlternateText="Exportar" ImageAlign="AbsMiddle"
										ImageUrl="~/imagenes/sistema/static/panel_control/excel.png" Style="background-color: #ffffff;
										padding: 2px; border: 1px solid #cccccc;" Visible="false" OnClick="ib_exportar_monto_Click" />
								</td>
							</tr>
							<tr>
								
								<td>


						<asp:GridView ID="gr_dato_pesos_familia" runat="server" CellPadding="2" GridLines="Vertical"
							CssClass="tabla_datos" AutoGenerateColumns="False" DataKeyNames="id_familia"
							Width="100%" OnRowDataBound="gr_dato_pesos_familia_RowDataBound" OnPageIndexChanging="gr_dato_pesos_familia_PageIndexChanging"
							OnSelectedIndexChanged="gr_dato_pesos_familia_SelectedIndexChanged" EnableModelValidation="True"
							OnRowCreated="gr_dato_pesos_familia_RowCreated">
							<Columns>
								
							</Columns>
							<HeaderStyle CssClass="tr_cabecera" />
							<RowStyle CssClass="tr_fila" />
							<AlternatingRowStyle CssClass="tr_fila_alt" />
						</asp:GridView>
									<asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
						
						
										<asp:GridView ID="gvDetailsPesos_familia" runat="server" AutoGenerateColumns="true"
											CssClass="tabla_datos" BorderStyle="Solid" BorderWidth="1px" CellPadding="2"
											GridLines="Vertical" DataKeyNames="codigo" Width="100%" ShowHeader="true" Visible="true"
											OnSelectedIndexChanged="gvDetailPesos_SelectedIndexChanged" OnRowDataBound="gvDetailPesosfamilia_RowDataBound">
											<Columns>
											</Columns>
											<HeaderStyle CssClass="tr_cabecera" />
											<RowStyle CssClass="tr_fila" />
											<AlternatingRowStyle CssClass="tr_fila_alt" />
										</asp:GridView>
								
							</td>
							</tr>

						</table>


					</ContentTemplate>
				</ajaxToolkit:TabPanel>
			

				<ajaxToolkit:TabPanel ID="TAb_saldo_operaciones" runat="server" HeaderText="Montos a Reembolsar ($)"
					Width="100%">
					<ContentTemplate>
						<table>
							<tr>
								<td>
									<asp:ImageButton ID="ib_exportar_devolucion" runat="server" AlternateText="Exportar"
										ImageAlign="AbsMiddle" ImageUrl="~/imagenes/sistema/static/panel_control/excel.png"
										Style="background-color: #ffffff; padding: 2px; border: 1px solid #cccccc;" Visible="false"
										OnClick="ib_exportar_devolucion_Click" />
								</td>
							</tr>
							<tr>
								
								<td>
									<asp:GridView ID="gr_dt_saldo" runat="server" CellPadding="2" GridLines="Vertical"
										Width="100%" CssClass="tabla_datos" AutoGenerateColumns="False" DataKeyNames="id_familia"
										OnRowDataBound="gr_dt_saldo_RowDataBound" OnPageIndexChanging="gr_dt_saldo_PageIndexChanging"
										OnSelectedIndexChanged="gr_dt_saldo_SelectedIndexChanged" EnableModelValidation="True"
										OnRowCreated="gr_dt_saldo_RowCreated">
							<Columns>
								
							</Columns>
										<HeaderStyle CssClass="tr_cabecera" />
										<RowStyle CssClass="tr_fila" />
										<AlternatingRowStyle CssClass="tr_fila_alt" />
						</asp:GridView>
									<asp:LinkButton ID="LinkButton2" runat="server"></asp:LinkButton>

								<asp:GridView ID="gvDetailsSaldo" runat="server" AutoGenerateColumns="true" CssClass="tabla_datos"
									BorderStyle="Solid" BorderWidth="1px" CellPadding="2" GridLines="Vertical" DataKeyNames="codigo"
									Width="100%" ShowHeader="true" Visible="true" OnSelectedIndexChanged="gvDetailSaldo_SelectedIndexChanged"
									OnRowDataBound="gvDetailSaldoe_RowDataBound">
									<Columns>
									</Columns>
									<HeaderStyle CssClass="tr_cabecera" />
									<RowStyle CssClass="tr_fila" />
									<AlternatingRowStyle CssClass="tr_fila_alt" />
								</asp:GridView>
							</td>
							</tr>
						</table>

					</ContentTemplate>
				</ajaxToolkit:TabPanel>

			
			<ajaxToolkit:TabPanel ID="Tab_tramite" runat="server" HeaderText="Montos a Facturar ($)"
				Width="100%">
				<ContentTemplate>
					<table>
						<tr>
							<td>
								<asp:ImageButton ID="ib_exportar_tramite" runat="server" AlternateText="Exportar"
									ImageAlign="AbsMiddle" ImageUrl="~/imagenes/sistema/static/panel_control/excel.png"
									Style="background-color: #ffffff; padding: 2px; border: 1px solid #cccccc;" Visible="false"
									OnClick="ib_exportar_tramite_Click" />
							</td>
						</tr>
						<tr>
							
							<td>
								<asp:GridView ID="gr_tramite" runat="server" CellPadding="2" GridLines="Vertical"
									Width="100%" CssClass="tabla_datos" AutoGenerateColumns="False" DataKeyNames="id_familia"
									OnRowDataBound="gr_dt_tramite_RowDataBound" OnPageIndexChanging="gr_dt_tramite_PageIndexChanging"
									OnSelectedIndexChanged="gr_dt_tramite_SelectedIndexChanged" EnableModelValidation="True"
									OnRowCreated="gr_dt_tramite_RowCreated">
									<Columns>
										
									</Columns>
									<HeaderStyle CssClass="tr_cabecera" />
									<RowStyle CssClass="tr_fila" />
									<AlternatingRowStyle CssClass="tr_fila_alt" />
								</asp:GridView>

								<asp:LinkButton ID="LinkButton3" runat="server"></asp:LinkButton>

							<asp:GridView ID="gvDetailsTramite" runat="server" AutoGenerateColumns="true" CssClass="tabla_datos"
								BorderStyle="Solid" BorderWidth="1px" CellPadding="2" GridLines="Vertical" DataKeyNames="codigo"
								Width="100%" ShowHeader="true" Visible="true" OnSelectedIndexChanged="gvDetailTramite_SelectedIndexChanged"
								OnRowDataBound="gvDetailTramite_RowDataBound">
								<Columns>
								</Columns>
								<HeaderStyle CssClass="tr_cabecera" />
								<RowStyle CssClass="tr_fila" />
								<AlternatingRowStyle CssClass="tr_fila_alt" />
							</asp:GridView>
						</td>
						</tr>
					</table>
				</ContentTemplate>
			</ajaxToolkit:TabPanel>



			</ajaxToolkit:TabContainer>
				</ContentTemplate>
				<Triggers>
			<asp:PostBackTrigger ControlID="ib_buscar" /> 
				</Triggers>
		</asp:UpdatePanel>
		</div>

</asp:Content>


