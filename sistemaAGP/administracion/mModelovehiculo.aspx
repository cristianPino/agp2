<%@ Page Language="C#" MasterPageFile="~/Adm.Master" AutoEventWireup="true" CodeBehind="mModelovehiculo.aspx.cs" Inherits="sistemaAGP.mModelovehiculo" Title="Administracion de Modelos de Vehiculo" %>
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
            font-size: x-small;
            font-weight: bold;
            font-family: Arial, Helvetica, sans-serif;
            width: 10px;
        }
        .style6
        {
            font-size: x-small;
            font-weight: bold;
            font-family: Arial, Helvetica, sans-serif;
            width: 28px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="style1">
    <table>
        <tr>
            <td class="style4">
        
                Administracion de Modelos de Vehiculo</td>
        </tr>
    </table>
    <table>
        <tr>
            <td class="style4">
                Marca</td>
            <td class="style4">
                <asp:Label ID="lbl_marca" runat="server" Font-Names="Arial" 
            Font-Size="X-Small"></asp:Label>
            </td>
            </tr>
            <tr>
            <td class="style5">
                Tipo Vehiculo</td>
            <td class="style6">
                            <asp:DropDownList ID="dl_tipo" runat="server" 
                                    Font-Names="Arial" Font-Size="X-Small" Height="19px" 
                                     Width="173px" 
                                TabIndex="19" AutoPostBack="True" 
                                onselectedindexchanged="dl_tipo_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
        </tr>
        
        <tr>
        <td class="style5">Modelo
        </td>
        <td>
            <asp:TextBox ID="txt_modelo" runat="server" Height="18px" Width="126px"></asp:TextBox>
        </td>
        </tr>
        
        <tr>
        <td>
            <asp:Button ID="Button1" runat="server" Font-Names="Arial" Font-Size="X-Small" 
                        Text="Guardar" onclick="Button1_Click" TabIndex="16" 
        Height="21px" />
    <cc1:ConfirmButtonExtender ID="Button1_ConfirmButtonExtender" runat="server" 
                        TargetControlID="Button1"
                        ConfirmText="¿Esta seguro de guardar un nuevo modelo?" >
    </cc1:ConfirmButtonExtender>

        </td>
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
            <asp:BoundField AccessibleHeaderText="id_modelo" DataField="id_modelo" 
                                HeaderText="id_modelo" />
            <asp:BoundField AccessibleHeaderText="nombre" DataField="nombre" 
                                HeaderText="nombre" />
            
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
                &nbsp;&nbsp;</tr></table>
</asp:Content>
