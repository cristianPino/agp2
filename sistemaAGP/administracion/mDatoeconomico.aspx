<%@ Page Language="C#" MasterPageFile="~/AGP.Master" AutoEventWireup="true" CodeBehind="mDatoeconomico.aspx.cs" Inherits="sistemaAGP.mDatoeconomico" Title="Administracion datos economicos" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMenu" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoCentral" runat="server">
    <table border="0" style="width: 1028px; height: 405px">
        <tr>
            <td style="border-style: none; border-color: inherit; border-width: 0; text-align: left; width: 1057px; height: 277px;" align="left" 
                    valign="top">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Arial" 
                        Font-Size="X-Small" Text="Administracion Datos Economicos"></asp:Label>
                <br />
                <table style="width: 14%; font-family: Arial, Helvetica, sans-serif; font-size: x-small" 
                                        bgcolor="#E5E5E5">
                    <tr>
                        <td style="width: 56px; text-align: right;">
                                Codigo  
                        <td style="width: 126px; text-align: left">
                            <asp:TextBox ID="txt_codigo"  runat="server" Font-Names="Arial" 
                                    Font-Size="X-Small" MaxLength="10" TabIndex="1" 
                                                     ></asp:TextBox>
                        </td>
                        <td style="width: 15px; text-align: right">
                                Valor</td>
                        <td style="text-align: left; ">
                            <asp:TextBox ID="txt_valor" runat="server" Font-Names="Arial" 
                                    Font-Size="X-Small" MaxLength="5" Width="72px" TabIndex="3" 
                                Height="17px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <asp:Button ID="Button1" runat="server" Font-Names="Arial" Font-Size="X-Small" 
                        Text="Guardar" onclick="Button1_Click" TabIndex="16" />
                <cc1:ConfirmButtonExtender ID="Button1_ConfirmButtonExtender" 
                    runat="server" TargetControlID="Button1" ConfirmText="¿Esta seguro de ingresar un nuevo Valor?">
                </cc1:ConfirmButtonExtender>
                    </asp:ConfirmButtonExtender> 

                            
                        
                &nbsp;<asp:Button ID="Button2" runat="server" Font-Names="Arial" 
                        Font-Size="X-Small" onclick="Button2_Click" Text="Limpiar" />
                <asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" 
                        CellPadding="4" Font-Names="Verdana" Font-Size="X-Small" ForeColor="#333333" 
                        GridLines="None" onselectedindexchanged="gr_dato_SelectedIndexChanged">
                    <RowStyle BackColor="#EFF3FB" />
                    <Columns>
                        <asp:CommandField ButtonType="Button" SelectText="Editar" 
                            ShowSelectButton="True">
                            <ControlStyle Font-Size="X-Small" />
                        </asp:CommandField>
                        <asp:BoundField AccessibleHeaderText="Codigo" DataField="Codigo" 
                            HeaderText="Codigo" />
                        <asp:BoundField AccessibleHeaderText="Valor" DataField="Valor" 
                                HeaderText="Valor" />
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
</asp:Content>
