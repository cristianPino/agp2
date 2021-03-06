﻿<%@ Page Language="C#" MasterPageFile="~/Adm.Master" AutoEventWireup="true" CodeBehind="mContratoCliente.aspx.cs"
	Inherits="sistemaAGP.mContratoCliente" Title="Administracion Contratos" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<style type="text/css">

        .style1
        {
            width: 100%;
            height: 3px;
        }
        .style4
        {
            font-size: x-small;
            font-weight: bold;
            font-family: Arial, Helvetica, sans-serif;
        }
        .style5
		{
			height: 28px;
		}
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<table class="style1">
    <table>
        <tr>
            <td class="style4">
        
                Administracion de Operaciones de Clientes</td>
        </tr>
    </table>
    <table>
        <tr>
            <td class="style4">
                Clientes</td>
            <td class="style4">
                &nbsp;</td>
            <td class="style4">
            </td>
            <td class="style4">
                &nbsp;</td>
        </tr>
    </table>
    <table>
		<tr>
			<td class="style4">
				Producto
			</td>
			<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 28px;">
				<b>
					<asp:DropDownList ID="dl_producto" runat="server" Font-Names="Arial" Font-Size="X-Small"
						Height="16px" Width="138px" TabIndex="17" Style="font-family: Arial, Helvetica, sans-serif;
						font-size: x-small; color: #000000;" 
					OnSelectedIndexChanged="dl_producto_SelectedIndexChanged" AutoPostBack="True">
					</asp:DropDownList>
				</b>
			</td>
		</tr>
		
		</table>
		<table>
        <tr>
            <td>
    <asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" 
                        CellPadding="4" Font-Names="Arial" Font-Size="X-Small" ForeColor="#333333" 
                        GridLines="None" 
        onselectedindexchanged="gr_dato_SelectedIndexChanged" 
        style="margin-right: 0px" Width="216px" EnableModelValidation="True">
        <RowStyle BackColor="#EFF3FB" />
        <Columns>
            <asp:BoundField AccessibleHeaderText="id_contrato" DataField="id_contrato" 
                                HeaderText="id_contrato" />
            <asp:BoundField AccessibleHeaderText="nombre" DataField="nombre" 
                                HeaderText="nombre" />
            <asp:TemplateField >
                <HeaderTemplate>
                    <asp:CheckBox runat="server" ID="checkall" AutoPostBack="True"
                OnCheckedChanged="Check_Clicked" />
                </HeaderTemplate>
                <ItemTemplate >
                    <asp:CheckBox ID="chk" runat="server" EnableViewState="true" Checked='<%# Bind("check")  %>'
 

/>
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
    <br />
        </td>
	
                &nbsp;<asp:Button ID="Button1" runat="server" Font-Names="Arial" Font-Size="X-Small" 
                        Text="Guardar" onclick="Button1_Click" TabIndex="16" 
        Height="21px" />
    <cc1:ConfirmButtonExtender ID="Button1_ConfirmButtonExtender" runat="server" 
                        TargetControlID="Button1"
                        ConfirmText="¿Esta seguro de actualizar los contratos del Cliente?" >
    </cc1:ConfirmButtonExtender>
                &nbsp;</tr>
	</table>
	</table>
</asp:Content>
