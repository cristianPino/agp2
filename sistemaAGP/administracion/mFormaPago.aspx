<%@ Page Language="C#" MasterPageFile="~/Adm.Master" AutoEventWireup="true" CodeBehind="mFormaPago.aspx.cs" Inherits="sistemaAGP.mFormaPago" Title="administracion Formas de Pago" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 49px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
                
                <table style="width: 31%; font-family: Arial, Helvetica, sans-serif; font-size: x-small" 
                                        bgcolor="#E5E5E5">
                    <tr>
                    <td class="style1">
                        Cliente:</td>
                        <td>
                            <asp:Label ID="lbl_cliente" runat="server" Font-Names="Arial" 
                                Font-Size="X-Small"></asp:Label>
                        </td>
                    
                    </tr>
                </table>
                
                <table style="width: 31%; font-family: Arial, Helvetica, sans-serif; font-size: x-small" 
                                        bgcolor="#E5E5E5">
                                        
                     <tr>
                        <td style="width: 15px; text-align: right">
                            Nombre</td>
                        <td style="text-align: left; ">
                            <asp:TextBox ID="txt_nombre" runat="server" Height="16px" MaxLength="50" 
                                Width="229px"></asp:TextBox>
                        </td>
                    </tr>
                    
                    
                </table>
                </div>
<asp:Button ID="Button1" runat="server" Font-Names="Arial" Font-Size="X-Small" 
                        Text="Guardar" onclick="Button1_Click" TabIndex="16" 
                        
                        />
<cc1:ConfirmButtonExtender ID="Button1_ConfirmButtonExtender" 
            runat="server" TargetControlID="Button1"
            ConfirmText="¿Esta seguro de ingresar una nueva Forma de Pago?"
            >
</cc1:ConfirmButtonExtender>
                
                            
                        
                &nbsp;<asp:Button ID="Button2" runat="server" Font-Names="Arial" 
                        Font-Size="X-Small" onclick="Button2_Click" Text="Limpiar" />
<asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" 
                        CellPadding="4" Font-Names="Arial" Font-Size="X-Small" ForeColor="#333333" 
                        GridLines="None">
    <RowStyle BackColor="#EFF3FB" />
    <Columns>
        <asp:BoundField AccessibleHeaderText="id_forma_pago" DataField="id_forma_pago" 
            HeaderText="id_forma_pago" />
        <asp:BoundField AccessibleHeaderText="Descripcion" DataField="descripcion" 
            HeaderText="Descripcion" />
    </Columns>
    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <EditRowStyle BackColor="#2461BF" />
    <AlternatingRowStyle BackColor="White" />
</asp:GridView>
</asp:Content>
