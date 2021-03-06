﻿<%@ Page Language="C#" MasterPageFile="~/Adm.Master" AutoEventWireup="true" CodeBehind="mEjecutivo.aspx.cs" Inherits="sistemaAGP.mEjecutivo" Title="Administracion de Modulos" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">

        .style2
        {
			width: 150px;
		}
        .style7
        {
            width: 114px;
        }
        .style6
        {
            width: 81px;
        }
        .style3
        {
            width: 488px;
        }
        .style8
		{
			width: 61px;
		}
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <table class="style1" bgcolor="#E5E5E5" style="height: 11px">
            <tr>
                <td class="style8">
                    <asp:Label ID="Label1" runat="server" Text="Cliente" Font-Names="Arial" 
                        Font-Size="X-Small"></asp:Label>
                </td>
                <td class="style7">
                    <asp:Label ID="lbl_cliente" runat="server" Font-Names="Arial" 
                        Font-Size="X-Small" Font-Bold="True" ForeColor="Black"></asp:Label>
                    <asp:Label ID="lbl_id" runat="server" Visible="False"></asp:Label>
                </td>
                <td class="style6">
                    <asp:Label ID="Label2" runat="server" Text="CORREO" Font-Names="Arial" 
                        Font-Size="X-Small"></asp:Label>
                </td>
                <td class="style3">
                    <asp:TextBox ID="txt_CORREO" runat="server" Width="291px" Height="19px" 
                        style="margin-left: 0px" ontextchanged="txt_nombre_TextChanged"></asp:TextBox>
                </td>
            </tr>
			<tr>
			<td class="style8"></td>	
			<td></td>
			
				<td class="style2">
					<asp:Label ID="Label6" runat="server" Text="NOMBRE EJECUTIVO" Font-Names="Arial" Font-Size="X-Small"></asp:Label>
				</td>
				<td class="style3">
					<asp:TextBox ID="txt_nombre" runat="server" Width="291px" Height="19px" Style="margin-left: 0px" OnTextChanged="txt_nombre_TextChanged"></asp:TextBox>
				</td>
			</tr>

        </table>
    </div>
    <p>
        <asp:Button ID="Button1" runat="server" Font-Names="Arial" Font-Size="X-Small" 
                        Text="Guardar" onclick="Button1_Click" TabIndex="16" 
                        
                        />
                
                            
                        
                <cc1:ConfirmButtonExtender ID="Button1_ConfirmButtonExtender" 
            runat="server" TargetControlID="Button1"
            ConfirmText="¿Esta seguro de ingresar un nuevo Modulo?"
            >
        </cc1:ConfirmButtonExtender>
                
                            
                        
                &nbsp;<asp:Button ID="Button2" runat="server" Font-Names="Arial" 
                        Font-Size="X-Small" onclick="Button2_Click" Text="Limpiar" />
    <asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" 
                        CellPadding="4" Font-Names="Arial" Font-Size="X-Small" ForeColor="#333333" 
                        GridLines="None" EnableModelValidation="True" OnRowDeleting="CustomersGridView_RowDeleting">
						
        <RowStyle BackColor="#EFF3FB" />
        <Columns>
            <asp:BoundField AccessibleHeaderText="id_sucursal_cliente" DataField="id_sucursal_cliente" HeaderText="id_sucursal_cliente" />
           <%-- <asp:BoundField AccessibleHeaderText="cliente" DataField="cliente" HeaderText="cliente" />--%>
			<asp:BoundField AccessibleHeaderText="id_sucursal" DataField="id_sucursal" HeaderText="id_sucursal" />
			<asp:BoundField AccessibleHeaderText="nombre" DataField="nombre" HeaderText="nombre" />
			<asp:BoundField AccessibleHeaderText="correo" DataField="correo" HeaderText="correo" />
			
        	<asp:CommandField ShowDeleteButton="True" />
			
        </Columns>
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#2461BF" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
    </p>
    <p style="height: 0px">
        &nbsp;</p>
</asp:Content>
