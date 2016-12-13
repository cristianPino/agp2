<%@ Page Title="" Language="C#" MasterPageFile="~/AGP.Master" AutoEventWireup="true" CodeBehind="mBancofinanciera.aspx.cs" Inherits="sistemaAGP.mBancofinanciera" EnableEventValidation="false" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMenu" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoCentral" runat="server">
    <table border="0" style="width: 630px; height: 323px">
        <tr>
            <td style="border-style: none; border-color: inherit; border-width: 0; text-align: left; width: 960px; height: 277px;" align="left" 
                    valign="top">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Arial" 
                        Font-Size="X-Small" Text="Administracion Bancos y Financieras"></asp:Label>
                <table style="width: 72%; font-family: Arial, Helvetica, sans-serif; font-size: x-small" 
                                        bgcolor="#E5E5E5">
                    <tr>
                        <td style="width: 23px; text-align: left;">
                            Codigo 
                        <td style="width: 93px; text-align: left">
                            <asp:TextBox ID="txt_codigo"  runat="server" Font-Names="Arial" 
                                    Font-Size="X-Small" MaxLength="10" TabIndex="1" 
                                Height="17px" Width="91px" BackColor="#0099FF" ForeColor="White" 
                                                     ></asp:TextBox>
                        </td>
                        <td style="width: 15px; text-align: right">
                                Nombre 
                        </td>
                        <td style="text-align: left; ">
                            <asp:TextBox ID="txt_nombre" runat="server" Height="16px" Width="226px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <asp:Button ID="Button1" runat="server" Font-Names="Arial" Font-Size="X-Small" 
                        Text="Guardar" onclick="Button1_Click" TabIndex="16" />
                <cc1:ConfirmButtonExtender ID="Button1_ConfirmButtonExtender" runat="server" 
                        TargetControlID="Button1"
                        ConfirmText="¿Esta seguro de ingresar un nuevo Cliente?" >
                </cc1:ConfirmButtonExtender>

                            
                        
                &nbsp;<asp:Button ID="Button2" runat="server" Font-Names="Arial" 
                        Font-Size="X-Small" onclick="Button2_Click" Text="Limpiar" />
                <asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" 
                        CellPadding="4" Font-Names="Arial" Font-Size="X-Small" ForeColor="#333333" 
                        GridLines="None" 
                    onselectedindexchanged="gr_dato_SelectedIndexChanged">
                    <RowStyle BackColor="#EFF3FB" />
                    <Columns>
                        <asp:BoundField AccessibleHeaderText="codigo" DataField="codigo" 
                            HeaderText="codigo" />
                        <asp:BoundField AccessibleHeaderText="nombre" DataField="nombre" 
                            HeaderText="Nombre" />
                        
                        <asp:TemplateField ShowHeader="False" HeaderText="Cta.Cte.">
                            <ItemTemplate>
                                <asp:ImageButton ID="ib_cuenta" runat="server" 
                             ImageUrl="../imagenes/sistema/static/cheque.png" Text="Cta.Cte." />
                            </ItemTemplate>
                            <ControlStyle Height="30px" Width="45px" />
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
        </tr>
        <tr>
            <td style="border-style: none; border-color: inherit; border-width: 0; text-align: left; width: 960px; height: 277px;" align="left" 
                    valign="top">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
