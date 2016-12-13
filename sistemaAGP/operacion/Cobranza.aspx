<%@ Page Title="Control de Cobranza AGP S.A." Language="C#" MasterPageFile="~/AGP.Master" AutoEventWireup="true" CodeBehind="Cobranza.aspx.cs" Inherits="sistemaAGP.Cobranza" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMenu" runat="server">
	<style type="text/css">
		.style5
		{
			height: 61px;
		}
	</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoCentral" runat="server">
    
	<asp:UpdateProgress ID="UpdateProg1" DisplayAfter="1000" runat="server">
		<ProgressTemplate>
			<div class="updateProgressContainer">
				<div class="updateProgress">
					<div style="position: relative; text-align: center;">
						<img src="../imagenes/sistema/gif/loading.gif" style="vertical-align: middle" alt="Procesando" />
						Procesando ...
					</div>
				</div>
			</div>
		</ProgressTemplate>
	</asp:UpdateProgress>
	<table align="left" style="width: 55%; height: 440px">
		<tr>
			<td class="style5" valign="top" align="left">
				<asp:UpdatePanel ID="arriba" runat="server">
					<ContentTemplate>
						
                        <table style="width: 636px; height: 32px;" bgcolor="#507CD1">
                        <tr>
                        <td>
                        
                        <table style="width: 627px; height: 32px;" bgcolor="#507CD1">
                                                 
                            <tr>
								<td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;
									height: 28px; color: #FFFFFF;">
									<b>Familia AGP</b>
								</td>
								<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 28px;
									width: 190px;">
									<b>
										<asp:DropDownList ID="dl_familia" runat="server" Font-Names="Arial" Font-Size="X-Small"
											Height="16px" Width="182px" TabIndex="1" Style="font-family: Arial, Helvetica, sans-serif;
											font-size: x-small; color: #000000;" AutoPostBack="True" OnSelectedIndexChanged="dl_familia_SelectedIndexChanged">
										</asp:DropDownList>
									</b>
								</td>
								<td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;
									height: 28px; color: #FFFFFF;">
									<b>Cliente</b>
								</td>
									<td>
										<asp:DropDownList ID="ddlCliente" runat="server" Font-Names="Arial" Font-Size="X-Small"
											Height="16px" Width="268px" Style="font-family: Arial, Helvetica, sans-serif;
											font-size: x-small" AutoPostBack="True" onselectedindexchanged="ddlCliente_SelectedIndexChanged">
										</asp:DropDownList>
									</td>
								
							
                            </tr>
                            </table>
                          
						<table bgcolor="Gray">
							<tr>
								
								<td>
									NºFactura
								</td>
								
								<td style="text-align: right;">
									<asp:TextBox ID="txt_factura_agp" runat="server" Font-Names="Arial" Font-Size="X-Small"
										OnTextChanged="txt_factura_agp_TextChanged" Width="87px" Height="19px"></asp:TextBox>
								</td>
								<td style="text-align: center; height: 9px;" align="center" valign="middle">
									<asp:ImageButton ID="ib_buscar" runat="server" ImageUrl="../imagenes/sistema/gif/lupa.gif"
										Height="21px" Width="30px" OnClick="ib_buscar_Click" Style="text-align: center" />
								</td>
                            
							</tr>
						
						</table>
                        </td>
                        </tr>
                        </table>
						</td> </tr>
					</ContentTemplate>
				</asp:UpdatePanel>
			</td>
		</tr>
		<tr>
			<td>
				<table style="width: 100%; height: 264px;">
					<tr>
						<td style="width: 123px;" valign="top">
							<asp:UpdatePanel ID="UpdatePanel2" runat="server">
								<ContentTemplate>
									<asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" CellPadding="4"
										Font-Names="Arial" Font-Size="X-Small" ForeColor="#333333" GridLines="None" Height="50px"
										OnSelectedIndexChanged="gr_dato_SelectedIndexChanged" OnRowDataBound="gr_dato_RowDataBound"
										Width="634px" EnableModelValidation="True">
										<RowStyle BackColor="#EFF3FB" />
										<Columns>

											<asp:BoundField AccessibleHeaderText="Familia" DataField="familia" HeaderText="Familia" />
											<asp:BoundField AccessibleHeaderText="Nº Factura" DataField="n_factura" HeaderText="Nº Factura" />
											<asp:BoundField AccessibleHeaderText="Cliente" DataField="cliente" HeaderText="Cliente" />
											<asp:BoundField AccessibleHeaderText="Fecha Factura" DataField="fecha_factura" HeaderText="Fecha Factura" />
											<asp:BoundField AccessibleHeaderText="Total General" DataField="total_general" HeaderText="Total General" />
											<asp:BoundField AccessibleHeaderText="Total Factura" DataField="Total_factura" HeaderText="Total Factura" />
											<asp:BoundField AccessibleHeaderText="Saldo Pendiente" DataField="saldo_pendiente" HeaderText="Saldo Pendiente" />
											<asp:TemplateField HeaderText="Rebajar">
												<ItemTemplate>
													<asp:HyperLink ID="lnk_rebajar" runat="server" data-title-id="title-Rebajar" data-fancybox-type="iframe"
														CssClass="fancybox fancybox.iframe" ImageUrl="~/imagenes/sistema/static/panel_control/gastos.png"
														NavigateUrl='<%# Bind("url_rebajar") %>' />
												</ItemTemplate>
												<ItemStyle HorizontalAlign="Center" />
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
              
               
			</td>
		</tr>
	</table>
</asp:Content>