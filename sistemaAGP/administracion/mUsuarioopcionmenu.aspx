<%@ Page Language="C#" MasterPageFile="~/Adm.Master" AutoEventWireup="true" CodeBehind="mUsuarioopcionmenu.aspx.cs" Inherits="sistemaAGP.mUsuarioopcionmenu" Title="Administracion Perfil Usuario" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1 {
            width: 100%;
            height: 3px;
        }

        .style4 {
            font-size: x-small;
            font-weight: bold;
            font-family: Arial, Helvetica, sans-serif;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="style1">
        <table>
            <tr>
                <td class="style4">Administracion de Perfiles</td>
            </tr>
        </table>
        <table>
            <tr>
                <td class="style4">Usuario</td>
                <td class="style4">
                    <asp:Label ID="lbl_Usuario" runat="server" Font-Names="Arial"
                        Font-Size="X-Small"></asp:Label>
                </td>
                <td class="style4"></td>
                <td class="style4">&nbsp;</td>
            </tr>
        </table>

        </tr>
    
        <tr>
            <td class="style2">
                <asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False"
                    CellPadding="4" Font-Names="Arial" Font-Size="X-Small" ForeColor="#333333"
                    GridLines="None"
                    OnSelectedIndexChanged="gr_dato_SelectedIndexChanged" Style="margin-right: 0px">
                    <RowStyle BackColor="#EFF3FB" />
                    <Columns>
                        <asp:BoundField AccessibleHeaderText="codigoopcionmenu" DataField="codigoopcionmenu"
                            HeaderText="codigoopcionmenu" />
                        <asp:BoundField AccessibleHeaderText="nombre" DataField="Descripcion"
                            HeaderText="nombre" />
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:CheckBox runat="server" ID="checkall" AutoPostBack="True"
                                    OnCheckedChanged="Check_Clicked" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="chk" runat="server" EnableViewState="true" Checked='<%# Bind("check")  %>' />
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
                <br />
            </td>
            &nbsp;<asp:Button ID="Button1" runat="server" Font-Names="Arial" Font-Size="X-Small"
                Text="Guardar" OnClick="Button1_Click" TabIndex="16"
                Height="21px" />
            <cc1:ConfirmButtonExtender ID="Button1_ConfirmButtonExtender" runat="server"
                TargetControlID="Button1"
                ConfirmText="¿Esta seguro de actualizar las opciones del menu?">
            </cc1:ConfirmButtonExtender>
            &nbsp;
        </tr>
    </table>
</asp:Content>
