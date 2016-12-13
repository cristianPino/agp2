<%@ Page Language="C#" MasterPageFile="~/AGP.Master" AutoEventWireup="true" CodeBehind="mTasacionSII.aspx.cs" Inherits="sistemaAGP.mTasacionSII" Title="Tasacion SII" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMenu" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoCentral" runat="server">
    <table border="0" style="width: 1028px; height: 405px">
        <tr>
            <td style="border-style: none; border-color: inherit; border-width: 0; text-align: left; width: 1057px; height: 277px;" align="left" 
                    valign="top">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Arial" 
                        Font-Size="X-Small" Text="Tasacion Automotriz SII"></asp:Label>
                <table style="width: 21%; font-family: Arial, Helvetica, sans-serif; font-size: x-small" 
                                        bgcolor="#E5E5E5">
                    <tr>
                        <td style="width: 56px; text-align: right; height: 23px;">
                                Codigo  
                        <td style="width: 105px; text-align: left; height: 23px;">
                            <asp:TextBox ID="txt_codigo"  runat="server" Font-Names="Arial" 
                                    Font-Size="X-Small" MaxLength="10" TabIndex="1" 
                                                     ></asp:TextBox>
                        </td>
                        <td style="width: 15px; text-align: right; height: 23px;">
                            Marca</td>
                        <td style="text-align: left; height: 23px;">
                            <asp:TextBox ID="txt_marca" runat="server" Font-Names="Arial" 
                                    Font-Size="X-Small" MaxLength="20" Width="72px" TabIndex="3" 
                                Height="17px"></asp:TextBox>
                                <td style="width: 15px; text-align: right; height: 23px;">
                                    Modelo</td>
                        <td style="text-align: left; height: 23px;">
                            <asp:TextBox ID="txt_modelo" runat="server" Font-Names="Arial" 
                                    Font-Size="X-Small" MaxLength="30" Width="72px" TabIndex="3" 
                                Height="17px"></asp:TextBox>
                                <td style="width: 15px; text-align: right; height: 23px;">
                                    Año</td>
                        <td style="text-align: left; height: 23px;">
                            <asp:TextBox ID="txt_ano" runat="server" Font-Names="Arial" 
                                    Font-Size="X-Small" MaxLength="4" Width="72px" TabIndex="3" 
                                Height="17px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                                <asp:Button ID="bt_buscar" runat="server"  Text="Buscar" 
                                    Width="78px" onclick="bt_buscar_Click" Font-Names="Arial" 
                                    Font-Size="XX-Small"  />
                            <asp:GridView ID="gr_sii" runat="server" CellPadding="3" Font-Names="Arial" 
                        Font-Size="XX-Small" AutoGenerateColumns="False" 
                        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" allowpaging="true"
                        selectedindex="0"
 
                        BorderWidth="1px" Height="269px" 
                    onselectedindexchanged="gr_sii_SelectedIndexChanged" Width="948px">
                        <RowStyle ForeColor="#000066" />
                        <Columns>
                            <asp:CommandField AccessibleHeaderText="Seleccionar" HeaderText="Seleccionar" 
                                SelectText="&lt;&lt;&gt;&gt;" ShowSelectButton="True">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:CommandField>
                            <asp:BoundField DataField="id_vehiculo" HeaderText="Id Tasacion" />
                            <asp:BoundField DataField="codigosii" HeaderText="CodigoSII" />
                            <asp:BoundField DataField="ano" HeaderText="Año" />
                            <asp:BoundField DataField="tipo_vehiculo" HeaderText="Tipo Vehiculo" />
                            <asp:BoundField DataField="marca" HeaderText="Marca" />
                            <asp:BoundField DataField="modelo" HeaderText="Modelo" />
                            <asp:BoundField DataField="puerta" HeaderText="Puertas" />
                            <asp:BoundField DataField="cilindrada" HeaderText="Cilindrada" />
                            <asp:BoundField DataField="combustible" HeaderText="Combustible" />
                            <asp:BoundField DataField="transmision" HeaderText="Transmision" />
                            <asp:BoundField DataField="equipo" HeaderText="Equipamiento" />
                            <asp:BoundField DataField="tasacion" HeaderText="Tasacion Fiscal" />
                            <asp:BoundField DataField="permiso" HeaderText="Permiso Circulacion" />
                        </Columns>
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                    </asp:GridView>
                    </td>
        </tr>
    </table>
</asp:Content>
