<%@ Page Language="C#" MasterPageFile="~/AGP.Master" AutoEventWireup="true" CodeBehind="mCheques.aspx.cs" Inherits="sistemaAGP.mcheques" Title="Administracion Perfil Usuario" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMenu" runat="server">
    <style type="text/css">
        .style5
        {
            font-size: x-small;
        }
        .style6
        {
            font-size: small;
            font-family: Arial, Helvetica, sans-serif;
        }
        .style7
        {
            height: 10px;
            width: 302px;
            color: #FFFFFF;
            font-family: Arial, Helvetica, sans-serif;
            background-color: #006666;
        }
        .style8
        {
            width: 14px;
        }
        .style9
        {
            font-size: small;
            font-family: Arial, Helvetica, sans-serif;
            height: 30px;
        }
        .style10
        {
            height: 41px;
        }
        .style11
        {
            font-size: small;
            font-family: Arial, Helvetica, sans-serif;
            height: 29px;
        }
        .style12
        {
            height: 29px;
        }
        .style13
        {
            font-size: small;
            font-family: Arial, Helvetica, sans-serif;
            height: 16px;
        }
        .style14
        {
            height: 16px;
        }
    </style>
     <script type="text/javascript" language="Javascript">
         function isNumberKey(evt) {
             var key = (evt.which) ? evt.which : event.keyCode;
             return (key <= 13 || (key >= 48 && key <= 57) || key == 46);
         }      
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoCentral" runat="server">
	<link rel="stylesheet" href="/Style/reset.css" />
	<link rel="stylesheet" href="/Style/text.css" />
	<link rel="stylesheet" href="/Style/960.css" />
	<link rel="stylesheet" href="/Style/site.css" />
	<script type='text/javascript' src='../jquery-1.7.2.min.js'></script>
	<script type='text/javascript' src='../jquery.mousewheel-3.0.6.pack.js'></script>
	<script type='text/javascript' src='../jquery.fancybox.js?v=2.0.6'></script>
	<link rel="Stylesheet" type="text/css" href="../jquery.fancybox.css?v=2.0.6" media="screen" />
	
	<script type="text/javascript">
	    $(document).ready(function () {
	        $('.fancybox').fancybox({
	            maxWidth: 800,
	            maxHeight: 600,
	            fitToView: true,
	            titleshow: true,
				titleposition:'inside',
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
	                    	'background-color': 'Gray',
							
	                    }
	                }
	            }
	        });
	    });
	</script>
	<asp:UpdatePanel ID="up_operacion" runat="server" UpdateMode="Conditional">
		<ContentTemplate>
	<table>
		<tr>
			<td class="style7">
				<strong>Administracion&nbsp;Banco</strong></td>
		</tr>
	</table>


			<div style="width: 100%;">
				
    <table class="style1">
		
	</table>
				
				<ajaxToolkit:TabContainer ID="tab_datos" runat="server" Width="100%" 
                    ActiveTabIndex="1" ScrollBars="Auto">
					<ajaxToolkit:TabPanel ID="tab_negocio" runat="server" HeaderText="Ingreso de Movimiento" Width="100%">
						<ContentTemplate>
			<table>
			<tr>
				<td class="style6">
				
					Banco<span class="style6"> : </span>
					</td>
                   
                    <td>
                   
                    <asp:DropDownList ID="dl_banco" runat="server" AutoPostBack="True" 
                        Font-Names="Arial" Font-Size="X-Small" Height="16px" 
                        OnSelectedIndexChanged="dl_banco_SelectedIndexChanged" Width="138px" 
                        CssClass="style6">
					</asp:DropDownList>


				</td>
				<td class="style5">
					<span class="style6">Cuenta Corriente : </span>
					
                   
					
                    </td>
                   
                    <td>
                   
                    <asp:DropDownList ID="dl_cta" runat="server" AutoPostBack="True" 
                        Font-Names="Arial" Font-Size="X-Small" Height="16px" 
                        OnSelectedIndexChanged="dl_ctacte_SelectedIndexChanged" Width="138px" 
                        CssClass="style6">
					</asp:DropDownList>
				</td>
				<td class="style5">
					<span class="style6">Tipo de Movimiento : </span>
                   
                    </td>
                   
                    <td>
					<asp:DropDownList ID="dl_tipmov" runat="server" AutoPostBack="True" 
                        Font-Names="Arial" Font-Size="X-Small" Height="16px" 
                        OnSelectedIndexChanged="dl_movimiento_SelectedIndexChanged" Width="138px" 
                        CssClass="style6">
					</asp:DropDownList>
				</td>
			</tr>

			<tr>
			<td class="style11">
			   
			     <span class="style6">Talonario </span>
               
                 </td>
               
                 <td class="style12">
			<asp:TextBox ID="txt_talonario" runat="server" Font-Names="Arial" 
                     Font-Size="X-Small" MaxLength="30" Width="107px" TabIndex="3" Height="16px" 
                     ontextchanged="txt_talonario_TextChanged" CssClass="style6"></asp:TextBox>
								
			</td>
			<td class="style12">
			    
			    <span class="style6">Nº de cheque o Movimiento </span>
				</td>
                
                <td class="style12">
			<asp:TextBox ID="Numcheq1" runat="server" Font-Names="Arial" 
                        Font-Size="X-Small" MaxLength="30" Width="107px" TabIndex="3" Height="16px" 
                        ontextchanged="Numcheq1_TextChanged" CssClass="style6"></asp:TextBox>
			</td>
				<td class="style12">
					<span class="style6">Monto Inicial </span>
                
                    </td>
                
                    <td class="style12">
				
					
				        <asp:TextBox ID="Monto_inicial" runat="server" CssClass="style6" 
                            Font-Names="Arial" Font-Size="X-Small" Height="16px" MaxLength="30" 
                            ontextchanged="Monto_inicial_TextChanged" TabIndex="3" Width="78px"></asp:TextBox>
				</td>
                </tr>
                <tr>
                <td class="style13">Solicitante</td>
                <td class="style14">
                                        <asp:DropDownList runat="server" AutoPostBack="True" CssClass="style6" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="138px" ID="dl_solicitante" OnSelectedIndexChanged="dl_movimiento_SelectedIndexChanged"></asp:DropDownList>

                    
                    </td>
                
                </tr>
                
                
                <tr>



			<td class="style10">
			   
			   <asp:Button ID="Button1" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="21px" OnClick="Button1_Click" TabIndex="16" Text="Guardar" />
                <ajaxToolkit:ConfirmButtonExtender ID="Button1_ConfirmButtonExtender" runat="server" 
                        TargetControlID="Button1"
                        ConfirmText="¿Esta seguro de ingresar un nuevo movimiento?" 
                    Enabled="True" >
                </ajaxToolkit:ConfirmButtonExtender>
    </td>
			</tr>
		</table>
					
						
    
			
						   
						
    
			
						</ContentTemplate>
					</ajaxToolkit:TabPanel>

					<ajaxToolkit:TabPanel ID="tab_RENDICION" runat="server" HeaderText="Informe Rendicion" Width="100%">
						<ContentTemplate>
							<table>
								    <tr>
                                        <td style="vertical-align: middle;" class="style6">
                                            Desde
                                            </td>
                                            <td>
                                            
                                            <asp:TextBox ID="txt_desde" runat="server" 
                                                Style="width: 75px;" CssClass="style6"></asp:TextBox>
                                            <asp:ImageButton ID="ib_desde" runat="server" 
                                                ImageUrl="../imagenes/sistema/gif/calendario.gif" CssClass="style6" />
                                            <ajaxToolkit:CalendarExtender ID="cal_desde" runat="server" 
                                                CssClass="calendario" Enabled="True" Format="dd/MM/yyyy" 
                                                OnClientDateSelectionChanged="checkDate" PopupButtonID="ib_desde" 
                                                TargetControlID="txt_desde" TodaysDateFormat="dd/MM/yyyy">
                                            </ajaxToolkit:CalendarExtender>
                                        </td>
                                        
                                        <td style="vertical-align: middle;" class="style6">
                                            Hasta
                                            </td>
                                            <td>
                                            <asp:TextBox ID="txt_hasta" runat="server" 
                                                Style="width: 75px;" CssClass="style6"></asp:TextBox>
                                            <asp:ImageButton ID="ib_hasta" runat="server" 
                                                ImageUrl="../imagenes/sistema/gif/calendario.gif" CssClass="style6" />
                                            <ajaxToolkit:CalendarExtender ID="cal_hasta" runat="server" 
                                                CssClass="calendario" Enabled="True" Format="dd/MM/yyyy" 
                                                OnClientDateSelectionChanged="checkDate" PopupButtonID="ib_hasta" 
                                                TargetControlID="txt_hasta" TodaysDateFormat="dd/MM/yyyy">
                                            </ajaxToolkit:CalendarExtender>
                                        </td>
                                        <td class="style5">
                                        </td>
                                        <td class="style6">
                                            Tipo de Movimiento :
                                            </td>
                                            <td>
                                            <asp:DropDownList ID="dl_tipo_movimiento" runat="server" Font-Names="Arial" 
                                                Font-Size="X-Small" Height="16px" 
                                                OnSelectedIndexChanged="dl_movimiento2_SelectedIndexChanged" Width="138px" 
                                                    CssClass="style6">
                                            </asp:DropDownList>
                                            <td class="style6">
                                            Rendido :
                                            </td>
                                            <td>
                                            <asp:DropDownList ID="dl_rendido" runat="server" Font-Names="Arial" 
                                                Font-Size="X-Small" Height="16px" Width="138px" CssClass="style6">
                                                <asp:ListItem Text="seleccionar" Value="TODO"></asp:ListItem>
                                                <asp:ListItem Text="Rendido" Value="true"></asp:ListItem>
                                                <asp:ListItem Text="No Rendido" Value="false"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                       
                                         
                                           
                                               
                                                    <td>
                                                        <asp:ImageButton ID="ImageButton1" runat="server" 
                                                            ImageUrl="../imagenes/sistema/static/panel_control/lupa.png" 
                                                            OnClick="ib_opedia_Click" Text="CHEQUES RENDICION" />
                                                    </td>
                                              
                                            
                                   
                                    </tr>
                               
								
							</table>

                            

                            <asp:GridView ID="gr_dato" OnRowDeleting="gr_dato_RowDeleting" runat="server" 
                                                AutoGenerateColumns="False"  
                                                CellPadding="4" Font-Names="Arial" Font-Size="Small" ForeColor="#333333" 
                                                GridLines="None" OnSelectedIndexChanged="gr_dato_SelectedIndexChanged" 
                                                Style="margin-right: 0px; font-size: x-small;" Width="950px" 
                                                DataKeyNames="banco,ctacte,tipo_movimiento,id_inventario" 
                                                EnableModelValidation="True">
												<RowStyle BackColor="#EFF3FB" />
												<Columns>
													<asp:BoundField DataField="id_inventario" Visible="False" HeaderText="id">
														<ItemStyle HorizontalAlign="Right" Width="180px" />
													</asp:BoundField>
													<asp:BoundField DataField="banco" HeaderText="Banco">
														<ItemStyle HorizontalAlign="Right" Width="180px" />
													</asp:BoundField>
													<asp:BoundField DataField="ctacte" HeaderText="Cuenta Corriente">
														<ItemStyle HorizontalAlign="Right" Width="180px" />
													</asp:BoundField>
													<asp:BoundField DataField="tipo_movimiento" HeaderText="Tipo de Movimiento">
														<ItemStyle HorizontalAlign="Right" Width="180px" />
													</asp:BoundField>
													<asp:BoundField DataField="taloncheque" HeaderText="Talonario">
														<ItemStyle HorizontalAlign="Right" Width="180px" />
													</asp:BoundField>
													<asp:BoundField DataField="numero_cheque" HeaderText="Nº de Movimiento">
														<ItemStyle HorizontalAlign="Right" Width="180px" />
													</asp:BoundField>

                                                    <asp:BoundField DataField="solicitante" HeaderText="Solicitante">
														<ItemStyle HorizontalAlign="Right" Width="180px" />
													</asp:BoundField>


													<asp:BoundField DataField="fecha_movimiento" HeaderText="Fecha Entrega">
														<ItemStyle HorizontalAlign="Right" Width="180px" />
													</asp:BoundField>

                                                    <asp:BoundField DataField="montoini" HeaderText="Monto inicial">
														<ItemStyle HorizontalAlign="Right" Width="180px" />
													</asp:BoundField>

                                                    <asp:BoundField DataField="fecha_rendicion" HeaderText="Fecha Rendicion">
														<ItemStyle HorizontalAlign="Right" Width="180px" />
													</asp:BoundField>

                                                    <asp:BoundField DataField="monto_rendido" HeaderText="Monto Rendido">
														<ItemStyle HorizontalAlign="Right" Width="180px" />
													</asp:BoundField>
													
													
                                                    <asp:BoundField DataField="rendido" HeaderText="Rendido">
														<ItemStyle HorizontalAlign="Right" Width="180px" />
													</asp:BoundField>
													<asp:BoundField DataField="Nomina" HeaderText="Nomina">
														<ItemStyle HorizontalAlign="Right" Width="180px" />
													</asp:BoundField>
													<asp:BoundField DataField="Folio" HeaderText="Folio">
														<ItemStyle HorizontalAlign="Right" Width="180px" />
													</asp:BoundField>
													
                                                    <asp:CommandField />
													<asp:TemplateField AccessibleHeaderText="Eliminar" HeaderText="Eliminar">
														<ItemTemplate>
															<asp:ImageButton ID="bt_eliminar" runat="server" CausesValidation="false" CommandName="Delete" CommandArgument='<%# Bind("banco") %>' ImageAlign="AbsMiddle" ImageUrl="~/imagenes/sistema/static/panel_control/eliminar.png" />
														</ItemTemplate>
														<ControlStyle Font-Size="X-Small" />
														<ItemStyle HorizontalAlign="Center" />
													</asp:TemplateField>
													<asp:TemplateField ShowHeader="False" HeaderText="Rendicion">
														<ItemTemplate>
															<asp:HyperLink ID="url_rendir" data-fancybox-type="iframe" CssClass="fancybox fancybox.iframe" runat="server" ImageUrl="../imagenes/sistema/static/dinero-small.png" Text="modulo" NavigateUrl='<%# Bind("url_rendir") %>' />
														</ItemTemplate>
														<ItemStyle HorizontalAlign="Center" />
													</asp:TemplateField>

												</Columns>
												<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
												<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
												<SelectedRowStyle CssClass="table" Font-Bold="True" ForeColor="#333333" />
												<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
												<EditRowStyle BackColor="#2461BF" />
												<AlternatingRowStyle BackColor="White" />
											</asp:GridView>


                            
                                            <table>
                                               
                                                    
                                                        <tr>
                                                            <td class="style8">
                                                    
                                                                <asp:ImageButton ID="ib_opedia" runat="server" 
                                                                    ImageUrl="../imagenes/sistema/static/panel_control/comprobante.png" 
                                                                    OnClick="ib_opedia_Click" Text="CHEQUES RENDICION" Visible="False" />
                                                    
                                                            </td>
                                                            
                                                        </tr>
                                                        
                                                       
                                            </table>

						</ContentTemplate>
					</ajaxToolkit:TabPanel>
					
                    <ajaxToolkit:TabPanel ID="tpCajaChica" runat="server" HeaderText="Caja chica" Width="100%">
						<ContentTemplate>
                        <table>
                            <tr>
                                <td>
                                    Familia
                                </td>
                                <td>
                                    <asp:DropDownList ID="dlFamilia" runat="server" AutoPostBack="True" 
                                        onselectedindexchanged="dlFamilia_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    Tipo de movimiento
                                </td>
                                <td>
                                    <asp:DropDownList ID="dlTipoMovimiento" runat="server">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:ImageButton ID="ImageButton2" runat="server" 
                                        ImageUrl="../imagenes/sistema/static/panel_control/lupa.png" 
                                        OnClick="ib_opedia_Click" Text="CHEQUES RENDICION" />
                                </td>
                            </tr>
                        </table>
                        
                        <table>
                        <tr>
                            <td>
                                Últimos 100 movimientos
                            </td>
                            <td>
                                Saldo Final
                            </td>
                            <td>
                                <span>$</span>
                                <asp:Label ID="lblSaldo" runat="server" Text="0"></asp:Label>
                            </td>
                            </tr>
                        </table>
                        
                         <asp:GridView ID="grMovimientoCajaChica"  
                                                runat="server" 
                                                AutoGenerateColumns="False"  
                                                CellPadding="4" Font-Names="Arial" Font-Size="Small" ForeColor="#333333" 
                                                GridLines="None" 
                                                Style="margin-right: 0px; font-size: x-small;" Width="950px" 
                                                EnableModelValidation="True">
												<RowStyle BackColor="#EFF3FB" />
												<Columns>
													<asp:BoundField DataField="id_movimiento" Visible="False" HeaderText="id">
														<ItemStyle HorizontalAlign="Right" Width="180px" />
													</asp:BoundField>
													<asp:BoundField DataField="fecha" HeaderText="Fecha">
														<ItemStyle HorizontalAlign="Right" Width="180px" />
													</asp:BoundField>
													<asp:BoundField DataField="familia" HeaderText="Familia">
														<ItemStyle HorizontalAlign="Right" Width="180px" />
													</asp:BoundField>
                                                    <asp:BoundField DataField="monto" HeaderText="Monto transacción">
														<ItemStyle HorizontalAlign="Right" Width="180px" />
													</asp:BoundField>
													<asp:BoundField DataField="inicial" HeaderText="Monto Inicial">
														<ItemStyle HorizontalAlign="Right" Width="180px" />
													</asp:BoundField>
                                                    <asp:BoundField DataField="observacion" HeaderText="Observación">
														<ItemStyle HorizontalAlign="Right" Width="180px" />
													</asp:BoundField>
													<asp:BoundField DataField="final" HeaderText="Monto Final">
														<ItemStyle HorizontalAlign="Right" Width="180px" />
													</asp:BoundField>
													<asp:BoundField DataField="tipoMovimiento" HeaderText="Tipo de movimiento">
														<ItemStyle HorizontalAlign="Right" Width="180px" />
													</asp:BoundField>
                                                    <asp:BoundField DataField="usuario" HeaderText="Usuario">
														<ItemStyle HorizontalAlign="Right" Width="180px" />
													</asp:BoundField>
                                                    
												</Columns>
												<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
												<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
												<SelectedRowStyle CssClass="table" Font-Bold="True" ForeColor="#333333" />
												<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
												<EditRowStyle BackColor="#2461BF" />
												<AlternatingRowStyle BackColor="White" />
											</asp:GridView>
                                            
                                            <table>
                                                <tr>
                                                    <td>
                                                        Cargar hacia caja chica
                                                    </td>
                                                    <td>
                                                        <span>$</span>
                                                        <asp:TextBox    ID="txtMontoCajaChica" 
                                                                        runat="server" 
                                                                        onkeypress="return isNumberKey(event)"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="Button2" runat="server" Text="Cargar Monto" 
                                                            onclick="Button2_Click" />
                                                             <ajaxToolkit:ConfirmButtonExtender ID="ConfirmButtonExtender1" 
                                                             runat="server" 
                                                            TargetControlID="Button2"
                                                            ConfirmText="¿Esta seguro de ingresar un nuevo movimiento?" 
                                                            Enabled="True" >
                                                    </ajaxToolkit:ConfirmButtonExtender>
                                                    </td>
                                                </tr>
                                            </table>
                        </ContentTemplate>
					</ajaxToolkit:TabPanel>
					
				</ajaxToolkit:TabContainer>
			</div>
			
		</ContentTemplate>
</asp:UpdatePanel>

 </asp:Content>
