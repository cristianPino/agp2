<%@ Page Language="C#" MasterPageFile="~/Adm.Master" AutoEventWireup="true" CodeBehind="mUsuariocliente.aspx.cs" Inherits="sistemaAGP.mUsuariocliente" Title="Administracion Perfil Usuario" %>
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
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="style1">
    
    <table>
        <tr>
            <td class="style4">
                Usuario</td>
            <td class="style4">
                <asp:Label ID="lbl_Usuario" runat="server" Font-Names="Arial" 
            Font-Size="X-Small"></asp:Label>
            </td>
            <td class="style4">
                <img alt="" src="../imagenes/sistema/static/edi72_ejecutivo.gif" 
                    style="width: 43px; height: 37px" /></td>
            <td class="style4">
                &nbsp;</td>
        </tr>
    </table>
    
    <table>
        <tr>
            <td class="style4">
        
                Acceso a Clientes Usuario<asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" 
                        CellPadding="4" Font-Names="Arial" Font-Size="X-Small" ForeColor="#333333" 
                        GridLines="None" 
        onselectedindexchanged="gr_dato_SelectedIndexChanged" style="margin-right: 0px">
        <RowStyle BackColor="#EFF3FB" />
        <Columns>
            <asp:BoundField AccessibleHeaderText="id_cliente" DataField="id_cliente" 
                                HeaderText="id_cliente" />
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
            </td>
        </tr>
    </table>
    
    
    </tr>
    
        <tr>
            <td class="style2">
    <br />
        </td>
                &nbsp;<asp:Button ID="Button1" runat="server" Font-Names="Arial" Font-Size="X-Small" 
                        Text="Guardar" onclick="Button1_Click" TabIndex="16" 
        Height="21px" />
    <cc1:ConfirmButtonExtender ID="Button1_ConfirmButtonExtender" runat="server" 
                        TargetControlID="Button1"
                        ConfirmText="¿Esta seguro de actualizar el acceso a clientes?" >
    </cc1:ConfirmButtonExtender>
                &nbsp;</tr></table>
</asp:Content>
