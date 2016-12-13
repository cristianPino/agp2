<%@ Page Language="C#" MasterPageFile="~/Adm.Master" AutoEventWireup="true" CodeBehind="mInformecliente.aspx.cs" Inherits="sistemaAGP.mInformecliente" Title="Opciones de Informes para Cliente" %>
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
            height: 15px;
        }
        </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table>
        <tr>
            <td class="style5">
        
                Administracion de Informes</td>
        </tr>
    </table>
    <asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" 
                        CellPadding="4" Font-Names="Verdana" Font-Size="X-Small" ForeColor="#333333" 
                        DataKeyNames = "id_informe"
                        GridLines="None" onselectedindexchanged="gr_dato_SelectedIndexChanged">
                    <RowStyle BackColor="#EFF3FB" />
                    <Columns>
                        <asp:BoundField DataField="id_informe" 
                            HeaderText="id_informe" AccessibleHeaderText="id_informe" 
                            Visible="False" />
                        <asp:BoundField AccessibleHeaderText="nombre" DataField="nombre" 
                                HeaderText="nombre" />
                                
                                <asp:BoundField AccessibleHeaderText="descripcion" 
                            DataField="descripcion" HeaderText="descripcion" />
                             <asp:TemplateField AccessibleHeaderText="chk" >
                <HeaderTemplate>
                    <asp:CheckBox runat="server" ID="checkall" AutoPostBack="True"
                OnCheckedChanged="Check_Clicked" />
                </HeaderTemplate>
                <ItemTemplate >
                    <asp:CheckBox ID="chk" runat="server"   
                     Checked='<%# Bind("check")  %>'/> 
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
    <table class="style1">
    
    <table>
        <tr>
            <td class="style4">
                &nbsp;</td>
            <td class="style4">
                &nbsp;</td>
            <td class="style4">
            </td>
            <td class="style4">
                &nbsp;</td>
        </tr>
    </table>
    
    </tr>
    
        <tr>
            <td class="style2">
    &nbsp;<br />
        </td>
                &nbsp;<asp:Button ID="Button1" runat="server" Font-Names="Arial" Font-Size="X-Small" 
                        Text="Guardar" onclick="Button1_Click" TabIndex="16" 
        Height="21px" />
    <cc1:ConfirmButtonExtender ID="Button1_ConfirmButtonExtender" runat="server" 
                        TargetControlID="Button1"
                        ConfirmText="¿Esta seguro de actualizar el perfil?" >
    </cc1:ConfirmButtonExtender>
                &nbsp;</tr></table>
</asp:Content>
