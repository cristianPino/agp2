<%@ Page Language="C#" MasterPageFile="~/Adm.Master" AutoEventWireup="true" CodeBehind="mPersonero.aspx.cs" Inherits="sistemaAGP.mPersonero" Title="Administracion de Personeros" %>
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
        <table style="width: 81%; font-family: Arial, Helvetica, sans-serif; font-size: x-small" 
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
        <table style="width: 81%; font-family: Arial, Helvetica, sans-serif; font-size: x-small" 
                                        bgcolor="#E5E5E5">
            <tr>
                <td style="width: 56px; ">
                    Rut<td style="width: 126px; text-align: left">
                    <asp:TextBox ID="txt_rut" runat="server" Height="16px" Width="145px"></asp:TextBox>
                </td>
                <td style="width: 15px; text-align: right">
                    Nombre
                </td>
                <td style="text-align: left; ">
                    <asp:TextBox ID="txt_nombre" runat="server" Height="16px" Width="285px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 15px; ">
                    Tipo</td>
                <td style="text-align: left; ">
                    <asp:DropDownList ID="dl_tipo" runat="server" 
                                    Font-Names="Arial" Font-Size="X-Small" Height="19px" 
                                     Width="173px" 
                                TabIndex="19">
                    </asp:DropDownList>
                </td>
                <td style="width: 15px; text-align: right">
                    Descripcion</td>
                <td style="text-align: left; ">
                    <asp:TextBox ID="txt_descripcion" runat="server" Height="16px" Width="285px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 15px; ">
                    Modulo</td>
                <td style="text-align: left; ">
                    <asp:DropDownList ID="dl_modulo" runat="server" 
                                    Font-Names="Arial" Font-Size="X-Small" Height="19px" 
                                     Width="173px" 
                                TabIndex="19">
                    </asp:DropDownList>
                </td>
                <td style="width: 15px; text-align: right">
                    Profesion</td>
                <td style="text-align: left; ">
                    <asp:TextBox ID="txt_profesion" runat="server" Height="17px" Width="286px"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
    <asp:Button ID="Button1" runat="server" Font-Names="Arial" Font-Size="X-Small" 
                        Text="Guardar" onclick="Button1_Click" TabIndex="16" 
                        
                        />
    <cc1:ConfirmButtonExtender ID="Button1_ConfirmButtonExtender" 
            runat="server" TargetControlID="Button1"
            ConfirmText="¿Esta seguro de ingresar un nuevo Personero?"
            >
    </cc1:ConfirmButtonExtender>
                
                            
                        
                &nbsp;<asp:Button ID="Button2" runat="server" Font-Names="Arial" 
                        Font-Size="X-Small" onclick="Button2_Click" Text="Limpiar" />
    <asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" 
                        CellPadding="4" Font-Names="Arial" Font-Size="X-Small" ForeColor="#333333" 
                        GridLines="None" onselectedindexchanged="gr_dato_SelectedIndexChanged">
        <RowStyle BackColor="#EFF3FB" />
        <Columns>
           <asp:CommandField ButtonType="Button" SelectText="Editar" 
                            ShowSelectButton="True">
                            <ControlStyle Font-Size="X-Small" />
          </asp:CommandField>
            <asp:BoundField AccessibleHeaderText="id_personero" DataField="id_personero" 
                HeaderText="id_personero" />
            <asp:BoundField AccessibleHeaderText="modulo" DataField="modulo" 
                HeaderText="modulo" />
            <asp:BoundField AccessibleHeaderText="rut" DataField="rut" HeaderText="rut" />
            <asp:BoundField AccessibleHeaderText="nombre" DataField="nombre" 
                HeaderText="nombre" />
            <asp:BoundField AccessibleHeaderText="tipo" DataField="tipo" 
                HeaderText="tipo" />
            <asp:BoundField AccessibleHeaderText="descripcion" DataField="descripcion" 
                HeaderText="descripcion" />
            <asp:BoundField AccessibleHeaderText="profesion" DataField="profesion" 
                HeaderText="profesion" />
            <asp:BoundField AccessibleHeaderText="id_modulo" DataField="id_modulo" 
                HeaderText="id_modulo"></asp:BoundField>
        </Columns>
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#2461BF" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
</asp:Content>
