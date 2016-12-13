<%@ Page Title="Administrador de Comunas" Language="C#" MasterPageFile="~/Adm.Master" AutoEventWireup="true" CodeBehind="mComunamodal.aspx.cs" Inherits="sistemaAGP.mComunamodal" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" style="width: 493px; height: 347px">
        <tr>
            <td style="border-style: none; border-color: inherit; border-width: 0; text-align: left; width: 968px; height: 277px;" align="left" 
                    valign="top">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Arial" 
                        Font-Size="X-Small" Text="Administracion de Comunas"></asp:Label>
                <br />
                <table style="width: 14%; font-family: Arial, Helvetica, sans-serif; font-size: x-small" 
                                        bgcolor="#E5E5E5">
                    <tr>
                        <td style="width: 15px; text-align: right">
                                Nombre 
                        </td>
                        <td style="text-align: left; ">
                            <asp:TextBox ID="txt_comuna" runat="server" Font-Names="Arial" 
                                    Font-Size="X-Small" MaxLength="20" Width="190px" TabIndex="3"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <asp:Button ID="Button1" runat="server" Font-Names="Arial" Font-Size="X-Small" 
                        Text="Guardar" onclick="Button1_Click" TabIndex="16" />
                <asp:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server" 
                        TargetControlID="Button1" 
                        ConfirmText="¿Esta seguro de ingresar una comuna?" />
                    </asp:ConfirmButtonExtender> 

                            
                        
                &nbsp;<asp:Button ID="Button2" runat="server" Font-Names="Arial" 
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
