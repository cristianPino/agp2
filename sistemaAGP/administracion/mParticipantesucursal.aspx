<%@ Page Language="C#" MasterPageFile="~/Adm.Master" AutoEventWireup="true" CodeBehind="mParticipantesucursal.aspx.cs"
	Inherits="sistemaAGP.mParticipantesucursal" Title="Administracion de Sucursales / Participantes" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">

        .style1
        {
            width: 100%;
        }
        .style4
        {
            font-size: x-small;
            font-weight: bold;
            font-family: Arial, Helvetica, sans-serif;
        }
        .style5
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: x-small;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="style1">
   
    <table>
        <tr>
             <td class="style4">
                <img alt="" src="../imagenes/sistema/static/edificio1.jpg" 
                    style="width: 43px; height: 37px" /></td>
        </tr>
        
        <tr>
        
        <td class="style5">
            <b>Cliente</b>
        </td>
        
        <td>
        
        <asp:DropDownList ID="dl_cliente" runat="server" CssClass="style5" 
            Height="16px" onselectedindexchanged="dl_cliente_SelectedIndexChanged" 
            Width="146px" AutoPostBack="True">
        </asp:DropDownList>
        
        </td>
        
        </tr>
        
        <tr>
        <td class="style4">Modulo</td>
        <td>
                            <asp:DropDownList ID="dl_modulo" runat="server" 
                                    Font-Names="Arial" Font-Size="X-Small" Height="19px" 
                                     Width="173px" 
                                TabIndex="19" AutoPostBack="True" 
                                onselectedindexchanged="dl_modulo_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
        </tr>
        
    </table>
    
     <table>
    <tr>
    <td class="style4">
        
        Administracion de Sucursales / Usuario</td>
    </tr>
    </table>
    
    
    </tr>
    
        <tr>
            <td class="style2">
    <asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" 
                        CellPadding="4" Font-Names="Arial" Font-Size="X-Small" ForeColor="#333333" 
                        GridLines="None" 
        onselectedindexchanged="gr_dato_SelectedIndexChanged" style="margin-right: 0px">
        <RowStyle BackColor="#EFF3FB" />
        <Columns>
            <asp:BoundField AccessibleHeaderText="id_sucursal" DataField="id_sucursal" 
                                HeaderText="id_sucursal" />
            <asp:BoundField AccessibleHeaderText="nombre" DataField="nombre" 
                                HeaderText="nombre" />
            <asp:TemplateField >
                <HeaderTemplate>
                    <asp:CheckBox runat="server" ID="checkall" AutoPostBack="True"
                OnCheckedChanged="Check_Clicked" />
                </HeaderTemplate>
                <ItemTemplate >
                    <asp:CheckBox ID="chk" runat="server" EnableViewState="true" Checked='<%# Bind("check")  %>' />
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
                        ConfirmText="¿Esta seguro de actualizar las sucursales del usuario?" >
    </cc1:ConfirmButtonExtender>
                &nbsp;</tr></table>
</asp:Content>
