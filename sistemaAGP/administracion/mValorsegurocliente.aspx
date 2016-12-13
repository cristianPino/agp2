<%@ Page Language="C#" MasterPageFile="~/Adm.Master" AutoEventWireup="true" CodeBehind="mValorsegurocliente.aspx.cs"
	Inherits="sistemaAGP.mValorsegurocliente" Title="valores seguro" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<style type="text/css">
        .style4 {
            width: 2px;
			background-color: #FFFFFF;
            height: 1px;
        }
        .style5 {
            width: 58px;
            text-align: center;
			background-color: #FFFFFF;
            height: 1px;
        }
        .style8 {
            width: 78px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div>
		<table style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 26px;" bgcolor="#E5E5E5">
			<tr>
				<td class="style4">
					Cliente
				</td>
				<td class="style5">
					<asp:Label ID="lbl_cliente" runat="server" Style="color: #FF3300"></asp:Label>
				</td>
			</tr>
			<tr>
				<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;" class="style9">
					Fecha Inicial
				</td>
				<td>
					<asp:TextBox ID="txt_fecha_inicio" runat="server" Style="font-family: Arial, Helvetica, sans-serif;
						font-size: x-small" Height="18px" Width="128px" TabIndex="7" OnTextChanged="txt_fecha_inicio_TextChanged"></asp:TextBox>
					<cc1:CalendarExtender runat="server" TargetControlID="txt_fecha_inicio" CssClass="calendario"
						Format="dd/MM/yyyy" PopupButtonID="ib_calendario" ID="CalendarExtender2" />
				</td>
				<td>
					<asp:ImageButton ID="ib_calendario" runat="server" ImageUrl="../imagenes/sistema/gif/calendario.gif"
						OnClick="ib_calendario_Click" />
				</td>
				<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;" class="style10">
					Fecha Final
				</td>
				<td>
					<asp:TextBox ID="txt_fecha_final" runat="server" Style="font-family: Arial, Helvetica, sans-serif;
						font-size: x-small" Height="17px" Width="92px" TabIndex="7" OnTextChanged="txt_fecha_final_TextChanged"></asp:TextBox>
					<cc1:CalendarExtender runat="server" TargetControlID="txt_fecha_final" CssClass="calendario"
						Format="dd/MM/yyyy" PopupButtonID="ImageButton1" ID="CalendarExtender1" />
				</td>
				<td>
					<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="../imagenes/sistema/gif/calendario.gif"
						OnClick="ImageButton1_Click" Style="height: 14px" />
				</td>
			</tr>
			<tr>
				<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;" class="style9">
					Periodo
				</td>
				<td>
					<asp:DropDownList ID="dl_periodo" runat="server" Font-Names="Arial" Font-Size="X-Small"
						Height="16px" Width="138px" TabIndex="17" Style="font-family: Arial, Helvetica, sans-serif;
						font-size: x-small" OnSelectedIndexChanged="dl_periodo_SelectedIndexChanged">
						<asp:ListItem Text="seleccionar" Value="0" />
						<asp:ListItem Text="1" Value="1" />
						<asp:ListItem Text="2" Value="2" />
						<asp:ListItem Text="3" Value="3" />
						<asp:ListItem Text="4" Value="4" />
					</asp:DropDownList>
				</td>
			</tr>
		</table>
		
	</div>
	<div>
		<asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" CellPadding="4"
			Font-Names="Arial" Font-Size="X-Small" ForeColor="#333333" GridLines="None" OnRowEditing="gr_dato_RowEditing"
			OnSelectedIndexChanged="gr_dato_SelectedIndexChanged">
			<RowStyle BackColor="#EFF3FB" />
			<Columns>
				<asp:BoundField AccessibleHeaderText="codigo" DataField="codigo" HeaderText="codigo">
					<ControlStyle Height="0px" Width="0px" />
				</asp:BoundField>
				<asp:BoundField AccessibleHeaderText="nombre" DataField="nombre" HeaderText="nombre" />
				<asp:TemplateField HeaderText="valor cliente">
					<ItemTemplate>
						<asp:TextBox ID="txt_valor" MaxLength="6" Height="16px" runat="server" Text='<%# Bind("valor") %>'
							Width="50px" AutoCompleteType="Disabled" Font-Size="7pt" AutoPostBack="false"></asp:TextBox>
						<cc1:FilteredTextBoxExtender ID="txt_valor_FilteredTextBoxExtender" runat="server"
							TargetControlID="txt_valor" FilterType="Custom, Numbers" ValidChars="">
						</cc1:FilteredTextBoxExtender>
					</ItemTemplate>
				</asp:TemplateField>
				<asp:TemplateField HeaderText="valor AGP">
					<ItemTemplate>
						<asp:TextBox ID="txt_valorAGP" MaxLength="6" Height="16px" runat="server" Text='<%# Bind("valorAGP") %>'
							Width="50px" AutoCompleteType="Disabled" Font-Size="7pt" AutoPostBack="false"></asp:TextBox>
						<cc1:FilteredTextBoxExtender ID="txt_valorAGP_FilteredTextBoxExtender" runat="server"
							TargetControlID="txt_valor" FilterType="Custom, Numbers" ValidChars="">
						</cc1:FilteredTextBoxExtender>
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
	
	</div>
	<div>
		<table style="width: 93px">
			<tr>
				<td class="style8">
					<asp:Button ID="bt_editar" runat="server" Text="Guardar" Font-Size="X-Small" OnClick="bt_editar_Click"
						UseSubmitBehavior="False" meta:resourcekey="bt_editarResource1" Style="height: 21px" />
					<cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="bt_editar"
						ConfirmText="¿Esta seguro de crear un nuevo Periodo?" Enabled="True">
					</cc1:ConfirmButtonExtender>
				</td>
			</tr>
		</table>
	</div>
	<div>
		<table>
			<tr>
				<td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
					Periodo
				</td>
				<td>
					<asp:DropDownList ID="dl_periodo2" runat="server" Font-Names="Arial" Font-Size="X-Small"
						Height="16px" Width="138px" TabIndex="17" Style="font-family: Arial, Helvetica, sans-serif;
						font-size: x-small" OnSelectedIndexChanged="dl_periodo2_SelectedIndexChanged">
						<asp:ListItem Text="seleccionar" Value="0" />
						<asp:ListItem Text="1" Value="1" />
						<asp:ListItem Text="2" Value="2" />
						<asp:ListItem Text="3" Value="3" />
						<asp:ListItem Text="4" Value="4" />
					</asp:DropDownList>
				</td>
				<td style="width: 50px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
					Año
				</td>
				<td>
					<asp:DropDownList ID="dl_ano" runat="server" Font-Names="Arial" Font-Size="X-Small"
						Height="16px" Width="138px" TabIndex="17" Style="font-family: Arial, Helvetica, sans-serif;
						font-size: x-small" OnSelectedIndexChanged="dl_ano_SelectedIndexChanged">
						<asp:ListItem Text="seleccionar" Value="0" />
						<asp:ListItem Text="2011" Value="2011" />
						<asp:ListItem Text="2012" Value="2012" />
						<asp:ListItem Text="2013" Value="2013" />
						<asp:ListItem Text="2014" Value="2014" />
						<asp:ListItem Text="2015" Value="2015" />
						<asp:ListItem Text="2016" Value="2016" />
						<asp:ListItem Text="2017" Value="2017" />
						<asp:ListItem Text="2018" Value="2018" />
					</asp:DropDownList>
				</td>
			</tr>
			<tr>
				<td class="style8">
					<asp:Button ID="id_buscar" runat="server" Text="Buscar" Font-Size="X-Small" OnClick="bt_buscar_Click"
						UseSubmitBehavior="False" meta:resourcekey="bt_buscarResource1" />
				</td>
				<td class="style8">
					<asp:Button ID="bt_guardar" runat="server" Text="Editar" Font-Size="X-Small" OnClick="bt_guardar_Click"
						UseSubmitBehavior="False" meta:resourcekey="bt_guardarResource1" Height="21px"
						Width="58px" Visible="false" />
					<cc1:ConfirmButtonExtender ID="bt_guardar_ConfirmButtonExtender" runat="server" TargetControlID="bt_guardar"
						ConfirmText="¿Esta seguro de editar los vaoles de este Cliente?" Enabled="True">
					</cc1:ConfirmButtonExtender>
				</td>
			</tr>
		</table>
		<table style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 26px;"
			bgcolor="#E5E5E5">
			<asp:GridView ID="gr_dato2" runat="server" AutoGenerateColumns="False" CellPadding="4"
				Font-Names="Arial" Font-Size="X-Small" ForeColor="#333333" GridLines="None" OnRowEditing="gr_dato2_RowEditing"
				OnSelectedIndexChanged="gr_dato2_SelectedIndexChanged" meta:resourcekey="gr_dato2Resource1"
				Visible="False">
				<RowStyle BackColor="#EFF3FB" />
				<Columns>
					<asp:BoundField AccessibleHeaderText="id_seguro" DataField="id_seguro" HeaderText="id_seguro"
						meta:resourcekey="BoundFieldResource6">
						<ControlStyle Height="0px" Width="0px" />
					</asp:BoundField>
					<asp:BoundField AccessibleHeaderText="codigo" DataField="codigo" HeaderText="codigo"
						meta:resourcekey="BoundFieldResource1">
						<ControlStyle Height="0px" Width="0px" />
					</asp:BoundField>
					<asp:BoundField AccessibleHeaderText="nombre" DataField="nombre" HeaderText="nombre"
						meta:resourcekey="BoundFieldResource2" />
					<asp:TemplateField HeaderText="valor cliente">
						<ItemTemplate>
							<asp:TextBox ID="txt_valor" MaxLength="6" Height="16px" runat="server" Text='<%# Bind("valor") %>'
								Width="50px" AutoCompleteType="Disabled" Font-Size="7pt" AutoPostBack="false"></asp:TextBox>
							<cc1:FilteredTextBoxExtender ID="txt_valor_FilteredTextBoxExtender" runat="server"
								TargetControlID="txt_valor" FilterType="Custom, Numbers" ValidChars="">
							</cc1:FilteredTextBoxExtender>
						</ItemTemplate>
					</asp:TemplateField>
					<asp:TemplateField HeaderText="valor AGP">
						<ItemTemplate>
							<asp:TextBox ID="txt_valorAGP" MaxLength="6" Height="16px" runat="server" Text='<%# Bind("valorAGP") %>'
								Width="50px" AutoCompleteType="Disabled" Font-Size="7pt" AutoPostBack="false"></asp:TextBox>
							<cc1:FilteredTextBoxExtender ID="txt_valorAGP_FilteredTextBoxExtender" runat="server"
								TargetControlID="txt_valor" FilterType="Custom, Numbers" ValidChars="">
							</cc1:FilteredTextBoxExtender>
						</ItemTemplate>
					</asp:TemplateField>
					<asp:BoundField AccessibleHeaderText="fecha_inicio" DataField="fecha_inicio" HeaderText="fecha inicio"
						meta:resourcekey="BoundFieldResource3">
						<ControlStyle Height="0px" Width="0px" />
					</asp:BoundField>
					<asp:BoundField AccessibleHeaderText="fecha_final" DataField="fecha_final" HeaderText="fecha final"
						meta:resourcekey="BoundFieldResource4">
						<ControlStyle Height="0px" Width="0px" />
					</asp:BoundField>
					<asp:BoundField AccessibleHeaderText="Periodo" DataField="periodo" HeaderText="Periodo"
						meta:resourcekey="BoundFieldResource5">
						<ControlStyle Height="0px" Width="0px" />
					</asp:BoundField>
				</Columns>
				<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
				<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
				<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
				<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
				<EditRowStyle BackColor="#2461BF" />
				<AlternatingRowStyle BackColor="White" />
			</asp:GridView>
		</table>
	</div>
	<br />
	<br />
</asp:Content>