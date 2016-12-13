<%@ Page Title="" Language="C#" MasterPageFile="~/Adm.Master" AutoEventWireup="true" CodeBehind="escritura.aspx.cs" Inherits="sistemaAGP.Operacion_Hipotecario.escritura" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <style type="text/css">
        .style1
        {
            font-family: Arial, Helvetica, sans-serif;
        }
        .style2
        {
            width: 298px;
        }
        .style3
        {
            font-family: Arial, Helvetica, sans-serif;
            width: 141px;
        }
    </style>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server">
        <table >
            <tr>
                <td class="style3">
                    Escritura</td>
                <td class="style2">
                    <asp:DropDownList ID="dl_escritura" runat="server" CssClass="style1" 
                        Height="19px" Width="275px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    Notario</td>
                <td class="style2">
                    <asp:DropDownList ID="dl_notario" runat="server" CssClass="style1" 
                        Height="18px" Width="274px">
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
        <table>
        <tr>
        <td>
            <asp:Button ID="bt_generar" runat="server" Text="Generar" />
            </td>
        </tr>
        </table>
    </asp:Panel>
</asp:Content>
