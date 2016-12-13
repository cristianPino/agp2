<%@ Page Title="Control de Operaciones AGP S.A." Language="C#" MasterPageFile="~/AGP.Master" AutoEventWireup="true" CodeBehind="estado_operacion_hipoteca.aspx.cs" Inherits="sistemaAGP.estado_operacion_hipoteca" %>

<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>--%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMenu" runat="server">
	 <script type="text/javascript" src="../jquery-1.7.2.min.js"></script>
	<script type="text/javascript" src="../jquery.mousewheel-3.0.6.pack.js"></script>
	<script type="text/javascript" src="../jquery.fancybox.js?v=2.0.6"></script>
   <link rel="Stylesheet" type="text/css" href="../jquery.fancybox.css?v=2.0.6" media="screen" />
	
    <script type="text/javascript">
        $(document).ready(function () {
            $('.fancybox').fancybox({
                maxWidth: 800,
                maxHeight: 800,
                minWidth: 800,
                minHeight: 800,
                fitToView: true,
                width: 800,
                height: 800,
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
	<script type="text/javascript">
	    function confirmarEliminar() {
	        if (confirm("Desea eliminar la operacion seleccionada?") == true) {
	            return true;
	        } else {
	            return false;
	        }
	    }
	</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoCentral" runat="server">
   
      <div class="subtitulo" style="width: 50%">
        <asp:Image ID="Image1" runat="server" 
            ImageUrl="../imagenes/sistema/static/hipotecario/Logo.png" Height="34px" 
            Width="37px" />
        &nbsp;<asp:Label ID="lbl_titulo" runat="server" Text="OPERACIONES HIPOTECARIAS"></asp:Label>
    </div>
    <br />
	<asp:UpdatePanel ID="up_arriba" runat="server">
		<ContentTemplate>
			<div id="title-cdigital" style="display: none;">
				Documentos Carpeta Digital
			</div>
			<div id="title-work" style="display: none;">
				Estado Operación
			</div>
			<div id="title-contratos" style="display: none;">
				Contratos
			</div>
            <p />
			 <div id="div1" class="div_subcontenido"  runat="server">
				<table class="table">
					<tr>
						<td>
							<strong>Familia</strong>
						</td>
						<td>
							<asp:DropDownList ID="dl_familia" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dl_familia_SelectedIndexChanged" >
							</asp:DropDownList>
                          
						</td>
						<td >
						    
							<strong>Cliente</strong>
						</td>
						<td>
							<asp:DropDownList ID="dl_cliente" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dl_cliente_SelectedIndexChanged">
							</asp:DropDownList>
						</td>
						<td>
							<strong>Producto</strong>
						</td>
						<td>
							<asp:DropDownList ID="dl_producto" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dl_producto_SelectedIndexChanged">
							</asp:DropDownList>
							<asp:RequiredFieldValidator ID="rfv_producto" runat="server" ControlToValidate="dl_producto" ErrorMessage="Producto" Text="*" InitialValue="0" SetFocusOnError="true" ValidationGroup="work"></asp:RequiredFieldValidator>
						</td>
						<td>
							<strong>Nº Cliente</strong>
						</td>
						<td >
							<asp:TextBox ID="txt_cliente" runat="server"></asp:TextBox>
						</td>
					</tr>
					<tr>
						<td>
							<strong>Módulo</strong>
						</td>
						<td>
							<asp:DropDownList ID="dl_modulo" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dl_modulo_SelectedIndexChanged">							
							</asp:DropDownList>
						</td>
						<td>
							<strong>Sucursal</strong>
						</td>
						<td>
							<asp:DropDownList ID="dl_sucursal" runat="server">
							</asp:DropDownList>
						</td>
						<td>
							<strong>Nº Operacion</strong>
                            
						</td>
						<td>
							<asp:TextBox ID="txt_operacion" runat="server" AutoPostBack="true" CausesValidation="true" ValidationGroup="filtros" OnTextChanged="txt_operacion_TextChanged"></asp:TextBox>
						
							<ajaxtoolkit:filteredtextboxextender id="fte_operacion" runat="server" targetcontrolid="txt_operacion" filtertype="Custom, Numbers" validchars="">
							</ajaxtoolkit:filteredtextboxextender>
						</td>
						<td style="vertical-align: middle;">
							<strong>RUT Deudor</strong>
						</td>
						<td >
							<asp:TextBox ID="txt_rut" runat="server" MaxLength="8" ToolTip="Ingrese el RUT sin puntos ni digito verificador"></asp:TextBox>
							<ajaxToolkit:FilteredTextBoxExtender ID="fte_rut" runat="server" TargetControlID="txt_rut"
								FilterType="Custom, Numbers" ValidChars="">
							</ajaxToolkit:FilteredTextBoxExtender>
						</td>
					</tr>
					<tr>
						
						<td>
							<strong>Desde</strong>
						</td>
						<td>
							<asp:TextBox ID="txt_desde" runat="server"></asp:TextBox>
							<asp:ImageButton ID="ib_desde" runat="server" ImageUrl="../imagenes/sistema/gif/calendario.gif" />
							<ajaxToolkit:CalendarExtender ID="cal_desde" runat="server" TargetControlID="txt_desde"
								CssClass="calendario" Format="dd/MM/yyyy" PopupButtonID="ib_desde" TodaysDateFormat="dd/MM/yyyy"
								OnClientDateSelectionChanged="checkDate" />
						</td>
						<td>
							<strong>Hasta</strong>
						</td>
						<td >
							<asp:TextBox ID="txt_hasta" runat="server"></asp:TextBox>
							<asp:ImageButton ID="ib_hasta" runat="server" ImageUrl="../imagenes/sistema/gif/calendario.gif" />
							<ajaxToolkit:CalendarExtender ID="cal_hasta" runat="server" TargetControlID="txt_hasta"
								CssClass="calendario" Format="dd/MM/yyyy" PopupButtonID="ib_hasta" TodaysDateFormat="dd/MM/yyyy"
								OnClientDateSelectionChanged="checkDate" />
						</td>
                        <td>
                            	<asp:CheckBox ID="chk_agrupar" runat="server" Text="Agrupar" />
                        </td>
					</tr>
					
				</table>
				<asp:ValidationSummary ID="vs_filtros" runat="server" DisplayMode="BulletList" HeaderText="Verifique los siguientes datos para realizar la búsqueda de operaciones:" ShowMessageBox="true" ShowSummary="false" ValidationGroup="filtros" />
			</div>

			<div  class="div_objetos" style="z-index: 1">
				<asp:Panel ID="pnl_flujo" runat="server" CssClass="paneles" >
					
					<strong>Flujo de Trabajo</strong>

					<asp:DropDownList ID="dpl_estado" runat="server">
					</asp:DropDownList>

					<asp:RadioButton ID="rb_blanco" 
                                runat="server" 
                                BackColor="White" 
                                OnCheckedChanged="rb_blancochangen"
						        AutoPostBack="true" />
					<asp:RadioButton ID="rb_rojo" 
                                runat="server" 
                                BackColor="Red"
                                OnCheckedChanged="rb_rojochangen"
						        AutoPostBack="true" />
					<asp:RadioButton ID="rb_amarillo" 
                                runat="server" 
                                BackColor="Yellow" 
                                OnCheckedChanged="rb_amarrillochangen" 
                                AutoPostBack="true" />
					<asp:RadioButton ID="rb_verde" 
                                runat="server"                                 
                                BackColor="green"
                                OnCheckedChanged="rb_verdechangen"
						        AutoPostBack="true" />				

				</asp:Panel>

				
					<asp:ImageButton ID="ib_buscar" 
                                runat="server" 
                                CausesValidation="true" 
                                AlternateText="Buscar" 
                                ImageAlign="AbsMiddle" 
                                ImageUrl="~/imagenes/sistema/static/panel_control/lupa.png" 
                                OnClick="ib_buscar_Click" 
                                ValidationGroup="filtros" />
				
			</div>
		</ContentTemplate>
	</asp:UpdatePanel>

	<asp:UpdatePanel ID="up_grilla" runat="server">
		<ContentTemplate>
         <p />


			<asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" CellPadding="4" CssClass="tabla_datos"
				DataKeyNames="tipo_operacion,cliente,id_solicitud,saldo,total_gasto,id_estado" 
                 GridLines="None" Width="100%" OnSelectedIndexChanged="gr_dato_SelectedIndexChanged"
				OnRowDataBound="gr_dato_RowDataBound" EnableModelValidation="True">				
				<Columns>
					<asp:HyperLinkField DataTextField="id_solicitud" HeaderText="Operacion">
						 <ItemStyle CssClass="td_derecha"  />
					<HeaderStyle CssClass="td_cabecera" />          
					</asp:HyperLinkField>
					<asp:BoundField DataField="Cliente" HeaderText="Acreedor" Visible="False" >
                     <ItemStyle CssClass="td_derecha"  />
					<HeaderStyle CssClass="td_cabecera" />
                    </asp:BoundField>
					<asp:BoundField DataField="nombre_cliente" HeaderText="Cliente" >
                     <ItemStyle CssClass="td_derecha"  />
					<HeaderStyle CssClass="td_cabecera" />
                    </asp:BoundField>
					<asp:BoundField DataField="tipo_operacion" HeaderText="Tipo_operacion" Visible="False" >
                     <ItemStyle CssClass="td_derecha"  />
					<HeaderStyle CssClass="td_cabecera" />
                    </asp:BoundField>
					<asp:BoundField DataField="operacion" HeaderText="Producto" >
                    <ItemStyle CssClass="td_derecha"  />
					<HeaderStyle CssClass="td_cabecera" />
                    </asp:BoundField>
					<asp:BoundField DataField="sucursal" HeaderText="Sucursal" >
                     <ItemStyle CssClass="td_derecha"  />
					<HeaderStyle CssClass="td_cabecera" />
                    </asp:BoundField>
					<asp:BoundField DataField="numero_cliente" HeaderText="Numero Cliente" >
                     <ItemStyle CssClass="td_derecha"  />
					<HeaderStyle CssClass="td_cabecera" />
                    </asp:BoundField>
					<asp:BoundField DataField="rut_persona" HeaderText="RUT Deudor" >
                     <ItemStyle CssClass="td_derecha"  />
					<HeaderStyle CssClass="td_cabecera" />
                    </asp:BoundField>
					<asp:BoundField DataField="nombre_persona" HeaderText="Nombre Deudor" >
                     <ItemStyle CssClass="td_derecha"  />
					<HeaderStyle CssClass="td_cabecera" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Cargar">
						<ItemTemplate>
							<asp:HyperLink ID="lnk_cargar" runat="server" data-title-id="title-cargar" data-fancybox-type="iframe" CssClass="fancybox fancybox.iframe" ImageUrl="~/imagenes/sistema/static/panel_control/subir.png" NavigateUrl='<%# Bind("url_cargar") %>' />
						</ItemTemplate>
						 <ItemStyle CssClass="td_derecha"  />
					<HeaderStyle CssClass="td_cabecera" />                
					</asp:TemplateField>
					<asp:TemplateField HeaderText="C.Digital">
						<ItemTemplate>
							<asp:HyperLink ID="lnk_cdigital" runat="server" data-title-id="title-cdigital" data-fancybox-type="iframe" CssClass="fancybox fancybox.iframe" ImageUrl="~/imagenes/sistema/static/panel_control/carpeta.png" NavigateUrl='<%# Bind("url_digital") %>' />
						</ItemTemplate>
						 <ItemStyle CssClass="td_derecha"  />
					<HeaderStyle CssClass="td_cabecera" />
                  
					</asp:TemplateField>
					<asp:TemplateField HeaderText="Tasador">
						<ItemTemplate>
							<asp:HyperLink ID="lnk_tasador" runat="server" data-title-id="title-Tasador" data-fancybox-type="iframe"
								CssClass="fancybox fancybox.iframe" ImageUrl="~/imagenes/sistema/static/tasador2.jpg"
								NavigateUrl='<%# Bind("url_tasador") %>' />
						</ItemTemplate>
						 <ItemStyle CssClass="td_derecha"  />
					<HeaderStyle CssClass="td_cabecera" />                
					</asp:TemplateField>

					<asp:BoundField DataField="id_estado" HeaderText="Id_estado" Visible="False" >
                     <ItemStyle CssClass="td_derecha"  />
					<HeaderStyle CssClass="td_cabecera" />
                    </asp:BoundField>
                    

                    <asp:TemplateField HeaderText="Estado Actual">
						<ItemTemplate>
							<asp:HyperLink ID="lnk_Estados" runat="server" data-title-id="title-Tasador" data-fancybox-type="iframe"
								CssClass="fancybox fancybox.iframe" Text='<%# Bind("ultimo_estado") %>'
								NavigateUrl='<%# Bind("urlEstados") %>' />
						</ItemTemplate>
						 <ItemStyle CssClass="td_derecha"  />
					<HeaderStyle CssClass="td_cabecera" />                
					</asp:TemplateField>
                    


					<asp:BoundField DataField="contador" HeaderText="Dias" >
                     <ItemStyle CssClass="td_derecha"  />
					<HeaderStyle CssClass="td_cabecera" />
                    </asp:BoundField>

					<asp:ImageField AccessibleHeaderText="Semaforo" DataImageUrlField="semaforo" 
						HeaderText="Semaforo">
                         <ItemStyle CssClass="td_derecha"  />
					<HeaderStyle CssClass="td_cabecera" />
                    
					</asp:ImageField>

					<asp:TemplateField HeaderText="Estado" ShowHeader="False">
						<ItemTemplate>
							<asp:HyperLink ID="lnk_estado" runat="server" data-title-id="title-work" data-fancybox-type="iframe" CssClass="fancybox fancybox.iframe" ImageUrl="~/imagenes/sistema/static/panel_control/wflow.png" NavigateUrl='<%# Bind("url_estado") %>' />
						</ItemTemplate>
						 <ItemStyle CssClass="td_derecha"  />
					<HeaderStyle CssClass="td_cabecera" />                 
					</asp:TemplateField>

				<%--	<asp:TemplateField HeaderText="Comprobante gastos" ShowHeader="False">
						<ItemTemplate>
							<asp:HyperLink ID="lnk_comGastos" runat="server" Target="_blank" ImageUrl="~/imagenes/sistema/static/panel_control/comprobante.png" NavigateUrl='<%# Bind("url_comgastos") %>' />
						</ItemTemplate>
						 <ItemStyle CssClass="td_derecha"  />
					<HeaderStyle CssClass="td_cabecera" />                   
					</asp:TemplateField>--%>


					<%--<asp:BoundField DataField="total_gasto" HeaderText="Total Gastos" 
						ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Right" >
					 <ItemStyle CssClass="td_derecha"  />
					<HeaderStyle CssClass="td_cabecera" />
                    </asp:BoundField>--%>
					<%--<asp:BoundField DataField="saldo" HeaderText="Saldo" ItemStyle-Width="80px" 
						ItemStyle-HorizontalAlign="Right" >					
					 <ItemStyle CssClass="td_derecha"  />
					<HeaderStyle CssClass="td_cabecera" />
                    </asp:BoundField>--%>

					<asp:TemplateField HeaderText="111" Visible="false">
						<ItemTemplate>
							<asp:HyperLink ID="lnk_contrato" runat="server" data-title-id="title-contratos" Target="_blank"
								 ImageUrl="~/imagenes/sistema/static/panel_control/poliza.png"
								NavigateUrl='<%# Bind("url_contratos") %>' />
						</ItemTemplate>
						 <ItemStyle CssClass="td_derecha"  />
					<HeaderStyle CssClass="td_cabecera" />           
					</asp:TemplateField>

					<asp:TemplateField HeaderText="Documentos">
						<ItemTemplate>
							<asp:HyperLink ID="lnk_escritura" runat="server" data-title-id="title-escritura"
								Target="_blank" ImageUrl="~/imagenes/sistema/static/word-small.jpg" NavigateUrl='<%# Bind("url_escritura") %>' />
						</ItemTemplate>
						 <ItemStyle CssClass="td_derecha"  />
					<HeaderStyle CssClass="td_cabecera" />
                
					</asp:TemplateField>
					
				</Columns>
				 <HeaderStyle CssClass="tr_cabecera" />
						<RowStyle CssClass="tr_fila" />
						<AlternatingRowStyle CssClass="tr_fila_alt" />   
			</asp:GridView>
		</ContentTemplate>
	</asp:UpdatePanel>
	<%--<table align="left" style="width: 55%; height: 440px">
		<tr>
			<td class="style4" style="height: 74px" valign="top">
				<table style="width: 100%; height: 32px;" bgcolor="#507CD1">
					<tr>
						<td style="width: 38px; font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 28px; color: #FFFFFF;">
							<b>Cliente</b>
						</td>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 28px;">
							<b>
								<asp:DropDownList ID="dl_cliente" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="138px" TabIndex="1" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #000000;" AutoPostBack="True" OnSelectedIndexChanged="dl_cliente_SelectedIndexChanged">
								</asp:DropDownList>
							</b>
						</td>
						<td class="style1" style="width: 57px; font-family: Arial, Helvetica, sans-serif; font-size: x-small; font-weight: bold; height: 28px; color: #FFFFFF;">
							Modulo
						</td>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 28px;">
							<b>
								<asp:DropDownList ID="dl_modulo" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="138px" TabIndex="17" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #000000;" OnSelectedIndexChanged="dl_modulo_SelectedIndexChanged">
								</asp:DropDownList>
							</b>
						</td>
						<td style="width: 64px; font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 28px; color: #FFFFFF;">
							<b>Sucursal</b>
						</td>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 28px;">
							<b>
								<asp:DropDownList ID="dl_sucursal" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="138px" TabIndex="17" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #000000;">
								</asp:DropDownList>
							</b>
						</td>
						<td style="width: 63px; font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 28px; color: #FFFFFF;">
							<b>Producto</b>
						</td>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 28px;">
							<b>
								<asp:DropDownList ID="dl_producto" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="138px" TabIndex="17" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #000000;" OnSelectedIndexChanged="dl_producto_SelectedIndexChanged">
								</asp:DropDownList>
							</b>
						</td>
						<td style="width: 92px; font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 28px; color: #FFFFFF;">
							<b>Nº Operacion</b>
						</td>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 28px;">
							<b>
								<asp:TextBox ID="txt_operacion" runat="server" Width="104px" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #FFFFFF;" BackColor="#3399FF" ForeColor="White" TabIndex="3"></asp:TextBox>
								<cc1:FilteredTextBoxExtender ID="txt_operacion_FilteredTextBoxExtender" runat="server" TargetControlID="txt_operacion" FilterType="Custom, Numbers" ValidChars="">
								</cc1:FilteredTextBoxExtender>
							</b>
						</td>
					</tr>
					<tr>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #FFFFFF; font-weight: 700;">
							Adquiriente
						</td>
						<td>
							<asp:TextBox ID="txt_rut" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" MaxLength="8" Width="136px"></asp:TextBox>
							<cc1:FilteredTextBoxExtender ID="txt_rutFilteredTextBoxExtender1" runat="server" TargetControlID="txt_rut" FilterType="Custom, Numbers" ValidChars="">
							</cc1:FilteredTextBoxExtender>
						</td>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #FFFFFF">
							<b>Nº Factura</b>
						</td>
						<td>
							<asp:TextBox ID="txt_factura" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" MaxLength="8" Width="135px"></asp:TextBox>
							<cc1:FilteredTextBoxExtender ID="txt_facturaFilteredTextBoxExtender1" runat="server" TargetControlID="txt_factura" FilterType="Custom, Numbers" ValidChars="">
							</cc1:FilteredTextBoxExtender>
						</td>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #FFFFFF; font-weight: 700;">
							Nº Cliente
						</td>
						<td>
							<asp:TextBox ID="txt_cliente" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" Width="133px"></asp:TextBox>
						</td>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #FFFFFF; font-weight: 700;">
							Patente
						</td>
						<td>
							<asp:TextBox ID="txt_patente" runat="server" MaxLength="6" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" Width="82px"></asp:TextBox>
						</td>
					</tr>
					<tr>
						<td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 28px; color: #FFFFFF;">
							<b>Familia AGP</b>
						</td>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 28px; width: 190px;">
							<b>
								<asp:DropDownList ID="dl_familia" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="182px" TabIndex="1" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #000000;" AutoPostBack="True" OnSelectedIndexChanged="dl_familia_SelectedIndexChanged">
								</asp:DropDownList>
							</b>
						</td>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #FFFFFF">
							<b>Desde </b>
						</td>
						<td>
							<asp:TextBox ID="txt_desde" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" Height="19px" Width="73px" TabIndex="2"></asp:TextBox>
							<asp:ImageButton ID="ib_desde" runat="server" ImageUrl="../imagenes/sistema/gif/calendario.gif" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" />
							<cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_desde" CssClass="FondoAplicacion" Format="dd/MM/yyyy" PopupButtonID="ib_desde" />
						</td>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #FFFFFF; font-weight: 700">
							Hasta
						</td>
						<td>
							<asp:TextBox ID="txt_hasta" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" Height="19px" Width="73px" TabIndex="2"></asp:TextBox>
							<asp:ImageButton ID="ib_hasta" runat="server" ImageUrl="../imagenes/sistema/gif/calendario.gif" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" />
							<cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txt_hasta" CssClass="FondoAplicacion" Format="dd/MM/yyyy" PopupButtonID="ib_hasta" />
						</td>
						<td style="text-align: center" align="center" valign="middle">
							<asp:ImageButton ID="ib_buscar" runat="server" ImageUrl="../imagenes/sistema/gif/lupa.gif" Height="21px" Width="30px" OnClick="ib_buscar_Click" Style="text-align: center" />
						</td>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;" class="style5">
							<asp:Label ID="lbl_flujo" runat="server" Style="color: #FFFFFF; text-align: right;" Text="Flujo de Trabajo" Visible="False"></asp:Label>
							<td style="text-align: right;">
								<asp:DropDownList ID="dpl_estado" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="16px" Width="157px" Visible="False">
								</asp:DropDownList>
							</td>
					</tr>
				</table>
				<center>
					<table style="width: 100%; height: 264px;">
						<tr>
							<td style="width: 123px;" valign="top">
								<asp:UpdatePanel ID="UpdatePanel2" runat="server">
									<ContentTemplate>
										<asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Names="Arial" Font-Size="X-Small" ForeColor="#333333" DataKeyNames="cod_tip_operacion" GridLines="None" Width="898px" Height="50px" EnableModelValidation="True">
											<RowStyle BackColor="#EFF3FB" />
											<Columns>
												<asp:HyperLinkField AccessibleHeaderText="id_solicitud" DataNavigateUrlFormatString="id_solicitud" DataTextField="id_solicitud" HeaderText="Operacion" Text="id_solicitud">
													<ItemStyle ForeColor="#00CC00" />
												</asp:HyperLinkField>
												<asp:BoundField AccessibleHeaderText="Cliente" DataField="Cliente" Visible="False" />
												<asp:BoundField AccessibleHeaderText="Cliente" DataField="Cliente_nombre" HeaderText="Cliente" />
												<asp:BoundField AccessibleHeaderText="tipo_operacion" DataField="tipo_operacion" HeaderText="Tipo operacion" />
												<asp:BoundField AccessibleHeaderText="cod_tip_operacion" DataField="cod_tip_operacion" FooterText="cod_tip_operacion" HeaderText="cod_tip_operacion" Visible="False" />
												<asp:BoundField AccessibleHeaderText="Nº Factura" DataField="numero_factura" HeaderText="Nº Factura" />
												<asp:BoundField AccessibleHeaderText="Patente" DataField="Patente" HeaderText="Patente" />
												<asp:BoundField AccessibleHeaderText="numero_cliente" DataField="numero_cliente" HeaderText="Numero Cliente" />
												<asp:BoundField AccessibleHeaderText="Adquiriente" DataField="rut_persona" HeaderText="Adquiriente" />
												<asp:BoundField AccessibleHeaderText="Nombre" DataField="nombre_persona" />
												<asp:BoundField AccessibleHeaderText="Gastos" FooterText="Gastos" HeaderText="Gastos" DataField="total_gasto" />
												<asp:BoundField AccessibleHeaderText="Saldo" DataField="saldo" FooterText="Saldo" HeaderText="Saldo" />
												<asp:BoundField AccessibleHeaderText="ultimo" DataField="ultimo_estado" HeaderText="Estado Actual" />
												<asp:TemplateField HeaderText="Comp. gastos" ShowHeader="False">
													<ItemTemplate>
														<asp:ImageButton ID="ib_comGastos" runat="server" ImageUrl="../imagenes/sistema/impresoras/impresora.gif" Text="comprobante gastos" />
													</ItemTemplate>
													<ControlStyle Height="25px" Width="25px" />
												</asp:TemplateField>
												<asp:TemplateField AccessibleHeaderText="Workflow" HeaderText="Workflow" ShowHeader="False">
													<ItemTemplate>
														<asp:ImageButton ID="ib_workflow" runat="server" ImageUrl="../imagenes/sistema/static/Herramienta.png" />
													</ItemTemplate>
													<EditItemTemplate>
														<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
													</EditItemTemplate>
													<ControlStyle Height="25px" Width="25px" />
												</asp:TemplateField>
												<asp:TemplateField AccessibleHeaderText="C.Digital" HeaderText="C.Digital">
													<EditItemTemplate>
														<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
													</EditItemTemplate>
													<ItemTemplate>
														<asp:ImageButton ID="ib_cdigital" runat="server" ImageUrl="../imagenes/sistema/static/carpetas.gif" />
													</ItemTemplate>
													<ControlStyle Height="25px" Width="25px" />
												</asp:TemplateField>
												<asp:TemplateField AccessibleHeaderText="Contratos" HeaderText="Contratos">
													<EditItemTemplate>
														<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
													</EditItemTemplate>
													<ItemTemplate>
														<asp:ImageButton ID="ib_vehiculo" runat="server" ImageUrl="../imagenes/sistema/static/contrato2.gif" />
													</ItemTemplate>
													<ControlStyle Height="25px" Width="25px" />
												</asp:TemplateField>
											</Columns>
											<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
											<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
											<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
											<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
											<EditRowStyle BackColor="#2461BF" />
											<AlternatingRowStyle BackColor="White" />
										</asp:GridView>
									</ContentTemplate>
								</asp:UpdatePanel>
							</td>
						</tr>
					</table>
				</center>
			</td>
		</tr>
	</table>--%>
</asp:Content>