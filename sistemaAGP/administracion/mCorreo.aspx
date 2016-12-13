<%@ Page Language="C#" MasterPageFile="~/Adm.Master" AutoEventWireup="true" CodeBehind="mCorreo.aspx.cs" Inherits="sistemaAGP.mCorreo" Title="Administracion de Correos" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 155px;
        }
        .style3
        {
            width: 13px;
        }
        .style4
        {
            width: 124px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
                
                <table style="width: 32%; font-family: Arial, Helvetica, sans-serif; font-size: x-small" 
                                        bgcolor="#E5E5E5">
                    <tr>
                        <td class="style3">
                            persona<td style="text-align: left" class="style4">
                            <asp:Label ID="lbl_nombre" runat="server"></asp:Label>
                        </td>
                        <td style="text-align: right" class="style3">
                            rut</td>
                        <td style="text-align: left; " class="style1">
                            <asp:Label ID="lbl_rut" runat="server"></asp:Label>
                        </td>
                        </tr>
                        <tr>
                        <td class="style3">
                             Correo</td>
                        <td style="text-align: left; " class="style4">
                            <asp:TextBox ID="txt_correo" runat="server" Height="17px" MaxLength="50" 
                                Width="168px"></asp:TextBox>
                        </td>
                    </tr>
                    
                
                    
                    
                </table>
                </div>
<asp:Button ID="Button1" runat="server" Font-Names="Arial" Font-Size="X-Small" 
                        Text="Guardar" onclick="Button1_Click" TabIndex="16" 
                        
                        />
<cc1:ConfirmButtonExtender ID="Button1_ConfirmButtonExtender" 
            runat="server" TargetControlID="Button1"
            ConfirmText="¿Esta seguro de ingresar un nuevo correo?"
            >
</cc1:ConfirmButtonExtender>
                
                            
                        
                <asp:Button ID="Button2" runat="server" Font-Names="Arial" 
                        Font-Size="X-Small" onclick="Button2_Click" Text="Limpiar" />
<asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" 
                        CellPadding="4" Font-Names="Arial" Font-Size="X-Small" ForeColor="#333333" 
                        GridLines="None" 
        onselectedindexchanged="gr_dato_SelectedIndexChanged">
    <RowStyle BackColor="#EFF3FB" />
    <Columns>
        <asp:BoundField AccessibleHeaderText="id_correo" DataField="id_correo" 
            HeaderText="id_correo" />
        <asp:BoundField AccessibleHeaderText="correo" DataField="correo" 
            HeaderText="correo" />
            <asp:TemplateField >
                <ItemTemplate >
                    <asp:CheckBox ID="chk" runat="server" EnableViewState="true" Checked='<%# Bind("check")  %>'/>
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
<asp:Button ID="Button3" runat="server" Font-Names="Arial" Font-Size="X-Small" 
                        Text="actualizar" onclick="Button3_Click" TabIndex="16" 
                        
                        />
<cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" 
            runat="server" TargetControlID="Button3"
            ConfirmText="¿Esta seguro de priorizar tal correo?"
            >
</cc1:ConfirmButtonExtender>
                

</asp:Content>
