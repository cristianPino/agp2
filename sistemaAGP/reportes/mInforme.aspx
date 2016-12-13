<%@ Page Language="C#" MasterPageFile="~/AGP.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="mInforme.aspx.cs" Inherits="sistemaAGP.mInforme" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMenu" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoCentral" runat="server">
    <table border="0" style="width: 493px; height: 347px">
        <tr>
            <td style="border-style: none; border-color: inherit; border-width: 0; text-align: left; width: 968px; height: 277px;" align="left" 
                    valign="top">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Arial" 
                        Font-Size="X-Small" Text="Administracion de Operaciones"></asp:Label>
                <br />
                <table style="width: 14%; font-family: Arial, Helvetica, sans-serif; font-size: x-small" 
                                        bgcolor="#E5E5E5">
                    <tr>
                        <td style="width: 56px; text-align: right;">
                                Nombre  
                        <td style="width: 126px; text-align: left">
                            <asp:TextBox ID="txt_nombre"  runat="server" Font-Names="Arial" 
                                    Font-Size="X-Small" MaxLength="100" TabIndex="1" 
                                                     ></asp:TextBox>
                        </td>
                        <td style="width: 15px; text-align: right">
                                Descripcion 
                        </td>
                        <td style="text-align: left; ">
                            <asp:TextBox ID="txt_descripcion" runat="server" Font-Names="Arial" 
                                    Font-Size="X-Small" MaxLength="100" Width="190px" TabIndex="3" 
                                ontextchanged="txt_descripcion_TextChanged"></asp:TextBox>
                        </td>
                    </tr>
                                        
                    
                </table>
                <asp:Button ID="Button1" runat="server" Font-Names="Arial" Font-Size="X-Small" 
                        Text="Guardar" onclick="Button1_Click" TabIndex="16" />
                <asp:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server" 
                        TargetControlID="Button1" 
                        ConfirmText="¿Esta seguro de ingresar una informe?" />
                    </asp:ConfirmButtonExtender> 

                            
                        
                &nbsp;<asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" 
                        CellPadding="4" Font-Names="Verdana" Font-Size="X-Small" ForeColor="#333333" 
                        GridLines="None" onselectedindexchanged="gr_dato_SelectedIndexChanged">
                    <RowStyle BackColor="#EFF3FB" />
                    <Columns>
                        <asp:BoundField DataField="id_informe" 
                            HeaderText="id_informe" AccessibleHeaderText="id_informe" />
                        <asp:BoundField AccessibleHeaderText="nombre" DataField="nombre" 
                                HeaderText="nombre" />
                                
                                <asp:BoundField AccessibleHeaderText="descripcion" 
                            DataField="descripcion" HeaderText="descripcion" />
                                          
                    </Columns>
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
                <asp:Button ID="Button2" runat="server" Font-Names="Arial" 
                        Font-Size="X-Small" onclick="Button2_Click" Text="Limpiar" />
                <asp:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" 
                        TargetControlID="Button1" 
                        ConfirmText="¿Esta seguro de ingresar una informe?" />
                    </asp:ConfirmButtonExtender> 
                <br />
            </td>
        </tr>
        <tr>
            <td style="border-style: none; border-color: inherit; border-width: 0; text-align: left; width: 968px; height: 277px;" align="left" 
                    valign="top">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
