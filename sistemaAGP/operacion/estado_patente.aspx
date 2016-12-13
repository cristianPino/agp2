<%@ Page Title="Control de Operaciones AGP S.A." Language="C#" MasterPageFile="~/AGP.Master"
	AutoEventWireup="true" CodeBehind="estado_patente.aspx.cs" Inherits="sistemaAGP.estado_patente" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMenu" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoCentral" runat="server">
	<table align="left" style="width: 55%; height: 440px">
		<tr>
			<td class="style4" style="height: 74px" valign="top">
				<table style="width: 100%; height: 32px;" bgcolor="#507CD1">
					<tr>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #FFFFFF;
							font-weight: 700; width: 63px;">
							Patente
						</td>
						<td style="width: 98px">
							<asp:TextBox ID="txt_patente" runat="server" MaxLength="6" Style="font-family: Arial, Helvetica, sans-serif;
								font-size: x-small" Width="82px"></asp:TextBox>
						</td>
						<td style="text-align: center" align="left" valign="middle">
							<asp:ImageButton ID="ib_buscar" runat="server" ImageUrl="../imagenes/sistema/gif/lupa.gif"
								Height="21px" Width="30px" OnClick="ib_buscar_Click" ImageAlign="Left" />
						</td>
					</tr>
					</table>
				<center>
					<table style="width: 100%; height: 264px;">
						<tr>
							<td style="width: 123px;" valign="top">
								<asp:UpdatePanel ID="UpdatePanel2" runat="server">
									<ContentTemplate>
										<asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" CellPadding="4"
											Font-Names="Arial" Font-Size="X-Small" ForeColor="#333333" DataKeyNames="cod_tip_operacion"
											GridLines="None" Width="898px" Height="50px" OnSelectedIndexChanged="gr_dato_SelectedIndexChanged"
											EnableModelValidation="True">
											<RowStyle BackColor="#EFF3FB" />
											<Columns>
												<asp:HyperLinkField AccessibleHeaderText="id_solicitud" DataNavigateUrlFormatString="id_solicitud"
													DataTextField="id_solicitud" HeaderText="Operacion" Text="id_solicitud">
													<ItemStyle ForeColor="#00CC00" />
												</asp:HyperLinkField>
												<asp:BoundField AccessibleHeaderText="Cliente" DataField="Cliente" Visible="False" />
												<asp:BoundField AccessibleHeaderText="Cliente" DataField="Cliente_nombre" HeaderText="Cliente" />
												<asp:BoundField AccessibleHeaderText="tipo_operacion" DataField="tipo_operacion"
													HeaderText="Tipo operacion" />
												<asp:BoundField AccessibleHeaderText="cod_tip_operacion" 
													DataField="cod_tip_operacion" FooterText="cod_tip_operacion" 
													HeaderText="cod_tip_operacion" Visible="False" />
												<asp:BoundField AccessibleHeaderText="Nº Factura" DataField="numero_factura" HeaderText="Nº Factura" />
												<asp:BoundField AccessibleHeaderText="Patente" DataField="Patente" HeaderText="Patente" />
												<asp:BoundField AccessibleHeaderText="numero_cliente" DataField="numero_cliente"
													HeaderText="Numero Cliente" />
												<asp:BoundField AccessibleHeaderText="Adquiriente" DataField="rut_persona" HeaderText="Adquiriente" />
												<asp:BoundField AccessibleHeaderText="Nombre" DataField="nombre_persona" />
												<asp:BoundField AccessibleHeaderText="Gastos" FooterText="Gastos" HeaderText="Gastos"
													DataField="total_gasto" />
												<asp:BoundField AccessibleHeaderText="Saldo" DataField="saldo" 
                                                    FooterText="Saldo" HeaderText="Saldo" />
												<asp:BoundField AccessibleHeaderText="ultimo" DataField="ultimo_estado" HeaderText="Estado Actual" />
												<asp:TemplateField HeaderText="Comp. gastos" ShowHeader="False">
													<ItemTemplate>
														<asp:ImageButton ID="ib_comGastos" runat="server" ImageUrl="../imagenes/sistema/impresoras/impresora.gif"
															Text="comprobante gastos" />
													</ItemTemplate>
													<ControlStyle Height="25px" Width="25px" />
												</asp:TemplateField>
												<asp:TemplateField AccessibleHeaderText="Workflow" HeaderText="Workflow" ShowHeader="False">
													<ItemTemplate>
														<itemtemplate>
                                            <asp:ImageButton ID="ib_workflow" runat="server" ImageUrl="../imagenes/sistema/static/Herramienta.png"  />
                            
                                        </itemtemplate>
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
	</table>
</asp:Content>