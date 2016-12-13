<%@ Page Language="C#" MasterPageFile="~/AGP.Master" AutoEventWireup="true" CodeBehind="mComuna.aspx.cs" Inherits="sistemaAGP.mComuna" Title="Administrador de Comunas" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMenu" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoCentral" runat="server">
    <table border="0" style="width: 1028px; height: 405px">
        <tr>
            <td style="border-style: none; border-color: inherit; border-width: 0; text-align: left; width: 1057px; height: 277px;" align="left" 
                    valign="top">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Arial" 
                        Font-Size="X-Small" Text="Administracion de Comunas"></asp:Label>
                <br />
                <table style="width: 63%; font-family: Arial, Helvetica, sans-serif; font-size: x-small" 
                                        bgcolor="#E5E5E5">
                    <tr>
                        <td style="width: 56px; text-align: right;">
                            Pais<td style="width: 126px; text-align: left">
                            <asp:DropDownList ID="dl_pais" runat="server" AutoPostBack="True" 
                                    Font-Names="Arial" Font-Size="X-Small" Height="16px" 
                                    onselectedindexchanged="dl_pais_SelectedIndexChanged" Width="138px">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 15px; text-align: right">
                            Region
                        </td>
                        <td style="text-align: left; ">
                            <asp:DropDownList ID="dl_region" runat="server" AutoPostBack="True" 
                                    Font-Names="Arial" Font-Size="X-Small" Height="19px" 
                                    onselectedindexchanged="dl_region_SelectedIndexChanged" Width="213px">
                            </asp:DropDownList>
                        </td>
                         <td style="width: 15px; text-align: right">
                             Ciudad
                        </td>
                        <td style="text-align: left; ">
                            <asp:DropDownList ID="dl_ciudad" runat="server" AutoPostBack="True" 
                                    Font-Names="Arial" Font-Size="X-Small" Height="19px" 
                                     Width="213px" onselectedindexchanged="dl_ciudad_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 15px; text-align: right">
                            Comuna</td>
                        <td style="text-align: left; ">
                            <asp:TextBox ID="txt_nombre" runat="server" Font-Names="Arial" 
                                    Font-Size="X-Small" MaxLength="30" Width="233px" TabIndex="3" 
                                    Height="19px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <asp:Button ID="Button1" runat="server" Font-Names="Arial" Font-Size="X-Small" 
                        Text="Guardar" onclick="Button1_Click" TabIndex="16" />
                <cc1:ConfirmButtonExtender ID="Button1_ConfirmButtonExtender" runat="server" 
                        TargetControlID="Button1"
                        ConfirmText="¿Esta seguro de ingresar una nueva Comuna?" >
                </cc1:ConfirmButtonExtender>
                <asp:Button ID="Button2" runat="server" Font-Names="Arial" 
                        Font-Size="X-Small" onclick="Button2_Click" Text="Limpiar" />
                <br />
                <asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" 
                        CellPadding="4" Font-Names="Arial" Font-Size="X-Small" ForeColor="#333333" 
                        GridLines="None">
                    <RowStyle BackColor="#EFF3FB" />
                    <Columns>
                        <asp:BoundField AccessibleHeaderText="id_comuna" DataField="id_comuna" 
                                HeaderText="id_comuna" />
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
            </td>
        </tr>
    </table>
</asp:Content>
