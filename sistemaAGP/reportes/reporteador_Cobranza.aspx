<%@ Page Title="Reportes Cobranza." Language="C#" MasterPageFile="~/AGP.Master" AutoEventWireup="true" CodeBehind="reporteador_Cobranza.aspx.cs" Inherits="sistemaAGP.reporteador_Cobranza" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMenu" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoCentral" runat="server">
	<table align="left" style="width: 55%; height: 440px">
		<tr>
			<td class="style4" style="height: 74px" valign="top">
				<table style="width: 100%; height: 32px;" bgcolor="#507CD1">
					
					<tr>
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
					</tr>
				</table>
				<center>
					<table style="width: 100%; height: 264px;">
						<tr>
							<td style="width: 123px;" valign="top">
							
								<asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" CellPadding="4"
									Font-Names="Verdana" Font-Size="X-Small" ForeColor="#333333" GridLines="None"
									DataKeyNames="id_informe_excel,sp_informe" OnSelectedIndexChanged="gr_dato_SelectedIndexChanged"
									OnRowCommand="ContactsGridView_RowCommand" Style="margin-right: 2px" EnableModelValidation="True">
									<RowStyle BackColor="#EFF3FB" />
									<Columns>
										<asp:BoundField AccessibleHeaderText="id_informe_excel" DataField="id_informe_excel"
											HeaderText="id_informe_excel" Visible="False" />
										<asp:BoundField AccessibleHeaderText="nombre" DataField="sp_informe" HeaderText="nombre"
											Visible="False" />
										<asp:BoundField AccessibleHeaderText="descripcion" DataField="descripcion" HeaderText="Visor de Reportes" />
									
									<asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="Excel" runat="server" CommandName="Excel"  CommandArgument='<%#((GridViewRow)Container).RowIndex %>'
                                  ImageUrl='~/imagenes/sistema/static/panel_control/excel.png' /> 
                          
                          </ItemTemplate>
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
				</center>
			</td>
		</tr>
	</table>
	
</asp:Content>