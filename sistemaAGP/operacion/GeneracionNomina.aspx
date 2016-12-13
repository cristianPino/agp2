<%@ Page Title="" Language="C#" MasterPageFile="~/AGP.Master" AutoEventWireup="true" CodeBehind="GeneracionNomina.aspx.cs" Inherits="sistemaAGP.GeneracionNomina" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="CC1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMenu" runat="server">
    <style type="text/css">
        .style5
        {
            font-family: Arial, Helvetica, sans-serif;
        }
        .style6
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: small;
            color: #FFFFFF;
        }
        .style7
        {
            height: 4px;
            margin-left: 40px;
        }
        .style8
        {
            height: 23px;
            margin-left: 40px;
        }
        .style9
        {
            width: 93px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoCentral" runat="server">
	<asp:UpdatePanel ID="up_filtros" runat="server">
		<ContentTemplate>
			<asp:Panel ID="pnl_filtros" runat="server" Style="width: 100%; background-color: #507cd1;">
	
    <table bgcolor="Gray" style="width: 100%">
				<tr>
					<td colspan="2" style="text-align:left; background-color: #006666;" 
                        class="style6">
						
					    <strong>GENERACION DE NOMINAS</strong></td>
				</tr>
				</table>
    			<table style="background-color: #507cd1; font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #ffffff;">
					<tr>
						<td>
							Familia AGP
						</td>
						<td colspan="3">
							<asp:DropDownList ID="dl_familia" runat="server" AutoPostBack="true" Width="200px" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;" OnSelectedIndexChanged="dl_familia_SelectedIndexChanged">
							</asp:DropDownList>
						</td>
						<td>
							Tipo Nómina
						</td>
						<td>
							<asp:DropDownList ID="dl_tiponomina" runat="server" Width="200px" 
								Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;" 
								onselectedindexchanged="dl_tiponomina_SelectedIndexChanged" AutoPostBack="true">
							</asp:DropDownList>
						</td>
						<td>
							<asp:Label ID="lbl_cliente" runat="server" Text="Cliente" Visible="true"></asp:Label>
							
						</td>
						<td>
							<asp:DropDownList ID="dl_cliente" runat="server" Width="200px" Style="font-family: Arial, Helvetica, sans-serif;
								font-size: x-small;" OnSelectedIndexChanged="dl_cliente_SelectedIndexChanged"
								AutoPostBack="true" Visible="true">
							</asp:DropDownList>
						</td>
					</tr>
					
					
                    <tr>
                    <td>
                        Nº Solicitud</td>
                    <td>
                        <asp:TextBox ID="txt_operacion" runat="server" Height="16px" Width="92px" 
                            AutoPostBack="true"  OnTextChanged="txt_operacion_TextChanged" 
							Enabled="false"></asp:TextBox>
                        </td>
						<td>
							<asp:Label ID="lbl_credito" runat="server" Text="NºCredito" Visible="false"></asp:Label>
							
						</td>
						<td>
							<asp:TextBox ID="txt_credito" runat="server" Height="16px" Width="80px" AutoPostBack="true"
								OnTextChanged="txt_credito_TextChanged" Visible="false" ></asp:TextBox>
						</td>
						<td>
						Folio</td>
						<td>
							<asp:TextBox ID="txt_folio" runat="server" Height="16px" Width="92px" AutoPostBack="false"
								 Enabled="false" ontextchanged="txt_folio_TextChanged1"></asp:TextBox>
						</td>
						
					    <td>
                            <asp:ImageButton ID="ImageButton2" runat="server" 
                                ImageUrl="../imagenes/sistema/static/panel_control/lupa.png" 
                                OnClick="ib_opedia_Click" Text="CHEQUES RENDICION" />

                        </td>
                        <td>
                        
                            <asp:ImageButton ID="ib_exportar" runat="server" AlternateText="Exportar" 
                                ImageAlign="AbsMiddle" 
                                ImageUrl="~/imagenes/sistema/static/panel_control/excel.png" 
                                onclick="ib_exportar_Click" 
                                Style="background-color: #ffffff; padding: 2px; border: 1px solid #cccccc;" />

                                  <ajaxToolkit:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" 
                        TargetControlID="ib_exportar"
                        ConfirmText="¿Desea ver la nomina en exel?" 
                    Enabled="True" >
                </ajaxToolkit:ConfirmButtonExtender>

                        <asp:ImageButton ID="btn_nomina_pdf" runat="server" AlternateText="Exportar" ImageAlign="AbsMiddle" 
						ImageUrl="~/imagenes/sistema/static/panel_control/pdf.png" ValidationGroup="nomina" Style="background-color: #ffffff; 
                        	padding: 2px; border: 1px solid #cccccc;" onclick="btn_nomina_pdf_Click" />

							<asp:ImageButton ID="btn_nomina_txt" runat="server" AlternateText="Exportar" ImageAlign="AbsMiddle"
								ImageUrl="~/imagenes/sistema/static/txt_1.jpg" ValidationGroup="nomina"
								Style="background-color: #ffffff; padding: 2px; border: 1px solid #cccccc;" OnClick="btn_nomina_txt_Click" />

                        	
							<asp:HyperLink ID="LinkButton1" runat="server" Visible="false" Target="_blank">DescargarUTF8</asp:HyperLink>

							<asp:HyperLink ID="LinkButton2" runat="server" Visible="false" Target="_blank">DescargarANCI</asp:HyperLink>
                        </td>

                    </tr>
                    <tr>
					
                    <td
                        style="vertical-align: middle;" class="style47">
							<strong>Desde</strong> 
                            </td>
                            <td class="style36">
							<asp:TextBox ID="txt_desde" runat="server" 
                                Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 75px; margin-bottom: 0px;"></asp:TextBox>
							<asp:ImageButton ID="ib_desde" runat="server" ImageUrl="../imagenes/sistema/gif/calendario.gif" />
							<ajaxToolkit:CalendarExtender ID="cal_desde" runat="server" TargetControlID="txt_desde" CssClass="calendario" Format="dd/MM/yyyy" PopupButtonID="ib_desde" TodaysDateFormat="dd/MM/yyyy" OnClientDateSelectionChanged="checkDate" />
						</td>
						<td style="vertical-align: middle;" class="style47">
							<strong>Hasta</strong>
                        </td>
                        <td class="style33">
							<asp:TextBox ID="txt_hasta" runat="server" 
                                Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 75px; margin-left: 0px;"></asp:TextBox>
							<asp:ImageButton ID="ib_hasta" runat="server" 
                                ImageUrl="../imagenes/sistema/gif/calendario.gif" 
                                Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 14px;" />
							<ajaxToolkit:CalendarExtender ID="cal_hasta" runat="server" TargetControlID="txt_hasta" CssClass="calendario" Format="dd/MM/yyyy" PopupButtonID="ib_hasta" TodaysDateFormat="dd/MM/yyyy" OnClientDateSelectionChanged="checkDate" />
						</td>
							<td class="style7">
						<asp:label id="lbl_cantidad1" runat="server" style="font-family: Arial; color: #FFFFFF">
						</asp:label>
					</td>
                    </tr>
					
				</table>
				
			</asp:Panel>
			
		</ContentTemplate>
		
	</asp:UpdatePanel>
	<center>
           <table bgcolor="Gray" style="width: 70%">
		   <tr>
			   <td>
				   <asp:Label ID="Label1" runat="server" Text="Seleccione Archivo Excel" Font-Bold="True"></asp:Label>
			   </td>
			   <td colspan="2">
				   <asp:FileUpload ID="fileuploadExcel" runat="server" />
			   </td>
			   <td>
				   <asp:Button ID="btnImport" runat="server" Text="Cargar Planilla" OnClick="btnImport_Click"
					   Width="99px" />
			   </td>
		   </tr>
				</table>
	</center>

	<asp:UpdatePanel ID="up_datos" runat="server">
		<ContentTemplate>
			<asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" 
				CellPadding="4" DataKeyNames="id_solicitud,id_cliente,tipo_operacion,disponible,monto_gasto" 
				Font-Names="Arial" Font-Size="X-Small" GridLines="None" 
				EnableModelValidation="True" Width="100%" 
				onselectedindexchanged="gr_dato_SelectedIndexChanged">
				<RowStyle />
				<Columns>
					<asp:HyperLinkField HeaderText="Operación" DataNavigateUrlFormatString="id_solicitud" DataTextField="id_solicitud">
						<ItemStyle ForeColor="#00cc00" Width="60px" />
					</asp:HyperLinkField>
					<asp:BoundField HeaderText="Cliente" DataField="nombre_cliente" />
					<asp:BoundField HeaderText="Producto" DataField="operacion" />
					<asp:BoundField HeaderText="Nº Factura" DataField="numero_factura" />
					<asp:BoundField HeaderText="Patente" DataField="patente" />
					<asp:BoundField HeaderText="Adquirente" DataField="rut_persona" />
					<asp:BoundField DataField="nombre_persona" />
					<asp:ImageField AccessibleHeaderText="Semaforo" DataImageUrlField="semaforo" HeaderText="Nivel Proceso">
						<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
					</asp:ImageField>
					<asp:BoundField HeaderText="Estado Actual" DataField="ultimo_estado" />
					<asp:BoundField HeaderText="Disponible" DataField="disponible" Visible="false" />
                    
                    <asp:BoundField HeaderText="Valor Gasto" DataField="monto_gasto" Visible="true" />
					
                    <asp:ImageField AccessibleHeaderText="img_disponible" DataImageUrlField="img_disponible" HeaderText="Disponible">
						<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
					</asp:ImageField>
					<asp:CommandField SelectText="Quitar" ShowSelectButton="True" />
				</Columns>
				<FooterStyle  Font-Bold="True" ForeColor="#ffffff" />
				<PagerStyle BackColor="#2461bf" ForeColor="#ffffff" HorizontalAlign="Center" />
				<SelectedRowStyle BackColor="#d1ddf1" Font-Bold="True" ForeColor="#333333" />
				<HeaderStyle BackColor="#507cd1" Font-Bold="True" ForeColor="#ffffff7" />
				<EditRowStyle BackColor="#2461bf" />
				<AlternatingRowStyle BackColor="#ffffff" />
			</asp:GridView>

		</ContentTemplate>
		
	</asp:UpdatePanel>
	<center>
		<asp:UpdatePanel ID="up_gastos" runat="server" Visible="true">
			<ContentTemplate>
				<asp:Panel ID="Panel1" runat="server" Visible="false">
					
                    
                        <table bgcolor="Gray" style="width: 100%">
				<tr>
					<td class="style7">
						
					    <asp:Label ID="lbl_cantidad" runat="server" 
                            style="font-family: Arial; color: #FFFFFF"></asp:Label>
						
					</td>
				</tr>
    </table>

                    
                    <table style="width: 26%; font-family: Arial, Helvetica, sans-serif; font-size: x-small;
						background-color: #507CD1; margin-right: 30px;">
						<tr>
							<td style="width: 81px; color: #FFFFFF;" class="style5">
								Gasto</td>
								<td style="text-align: left; width: 110px;">
									<asp:TextBox ID="txt_gasto" runat="server" Font-Names="Arial" Font-Size="X-Small"
										Height="16px" MaxLength="30" Enabled="false" TabIndex="3"
										Width="163px" ontextchanged="txt_gasto_TextChanged"></asp:TextBox>
								</td>
						
							<td style="width: 81px; color: #FFFFFF;" class="style5">
								Valor Gasto</td>
								<td style="text-align: left; width: 110px;">
									<asp:TextBox ID="txt_monto" runat="server" Font-Names="Arial" Font-Size="X-Small"
										Height="16px" MaxLength="30" OnTextChanged="txt_monto_TextChanged" Enabled="false" TabIndex="3"
										Width="86px"></asp:TextBox>
								</td>
                                <td style="width: 81px; color: #FFFFFF;" class="style5">
								Total Gasto</td>
								<td style="text-align: left; width: 110px;">
									<asp:TextBox ID="txt_total" runat="server" Font-Names="Arial" Font-Size="X-Small"
										Height="16px" MaxLength="30" OnTextChanged="txt_total_TextChanged" Enabled="false" TabIndex="3"
										Width="109px"></asp:TextBox>
										</td>
                                <td style="width: 81px; color: #FFFFFF;" class="style5">
								Cheque
								</td>
                                <td>
                                    <asp:DropDownList ID="DropDowncheque" runat="server" Height="27px" 
                                        Width="236px">
                                    </asp:DropDownList>
                                </td>
							</tr>
					
					</table>
				</asp:Panel>
			</ContentTemplate>
		</asp:UpdatePanel>
	</center>

    <asp:Panel ID="pnl_guardar" runat="server" Style="width: 100%;">
			<table bgcolor="Gray" style="width: 100%">
				<tr>
					<td colspan="2" style="text-align:left; ">
						
                        <asp:ImageButton ID="bt_generar" runat="server" ImageUrl="~/imagenes/sistema/gif/grabar-small.png"
							Enabled="true" Style="background-color: #ffffff;" OnClick="bt_generar_Click" />
                            
                          <ajaxToolkit:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server" 
                        TargetControlID="bt_generar"
                        ConfirmText="¿Desea Generar Nomina?" 
                    Enabled="True" >
                </ajaxToolkit:ConfirmButtonExtender>
					</td>
				</tr>
				</table>
			</asp:Panel>

</asp:Content>