<%@ Page Title="Analisis estado" Language="C#" MasterPageFile="~/Adm.Master" AutoEventWireup="true" CodeBehind="mOperacion_estado_GyC.aspx.cs" Inherits="sistemaAGP.mOperacion_estado_GyC" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 41px;
        }
        .style2
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: x-small;
            margin-left: 0px;
        }
        .style3
        {
            width: 132px;
        }
        .style4
        {
            width: 131px;
            text-align: right;
        }
        .style5
        {
            text-align: left;
        }
        .style8
    {
        height: 277px;
        width: 469px;
    }
        .style9
        {
            width: 57px;
        }
        .style10
        {
            width: 112px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    
    <table border="0" style="width: 493px; height: 347px">
        <tr>
            <td style="border-style: none; border-color: inherit; border-width: 0; text-align: left; " align="left" 
                    valign="top" class="style8">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Arial" 
                        Font-Size="X-Small" Text="Administracion de WorkFlow"></asp:Label>
                <br />
                <table style="width: 14%; font-family: Arial, Helvetica, sans-serif; font-size: x-small" 
                                        bgcolor="#E5E5E5">
                    </table>
                    
                    
                   
                    <br />
                    
                     <table style="width: 92%; font-family: Arial, Helvetica, sans-serif; font-size: x-small" 
                                        bgcolor="#E5E5E5">
                        
                        <tr>
                        <td class="style1">
                            Tipo Operacion</td>
                        <td class="style2">
                        <asp:Label ID="lbl_tipo" runat="server" Text="Label" Font-Names="Arial" 
                                Font-Size="X-Small"></asp:Label>
                        </td>
                         <td class="style4">
                        <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Names="Arial" 
                        Font-Size="X-Small" Text="Nº solicitud"></asp:Label>   
                        </td>
                        <td>
                        <asp:Label ID="lbl_solicitud" runat="server" Text="Label" Font-Names="Arial" 
                                Font-Size="X-Small" style="font-weight: 700"></asp:Label>
                        </td>
                         
                        </tr>
                        </table>
                    
                    <table style="width: 92%; font-family: Arial, Helvetica, sans-serif; font-size: x-small" 
                                        bgcolor="#E5E5E5">
                        
                        <tr>
                            <td style="width: 56px; " class="style5">
                                Flujo de trabajo  <td style="text-align: left" class="style3">
                                <asp:DropDownList ID="dl_estado" runat="server" 
                                    Font-Names="Arial" Font-Size="X-Small" Height="18px" 
                                    onselectedindexchanged="dl_estado_SelectedIndexChanged" Width="240px" 
                                    AutoPostBack="True">
                                </asp:DropDownList>
                                                </td>
                       </tr>
                       <tr>
                             <td style="width: 15px; text-align: right">
                                Obs. </td>
                            <td style="text-align: left; " class="style3">
                                <asp:TextBox ID="txt_obs" runat="server" Font-Names="Arial" 
                                    Font-Size="X-Small" MaxLength="100" Width="367px" TabIndex="3" 
                                    Height="16px" ontextchanged="txt_obs_TextChanged"></asp:TextBox>
                                        </td>
                       
                       </tr>
                        </table>
                         <asp:Panel id="Panel1" runat="server" Width="428px" Visible="False"
                    >
                <table style="width: 177px; font-family: Arial, Helvetica, sans-serif; font-size: x-small; margin-right: 0px;">
                    <tr>
                        <td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;" 
                            class="style9">
                            Fecha </td>
                    <td>
                        <asp:TextBox ID="txt_fecha" runat="server" 
                                style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; margin-left: 0px;" 
                                Height="19px" Width="73px" TabIndex="2" 
                            ontextchanged="txt_fecha_TextChanged"></asp:TextBox>
                        <cc1:CalendarExtender    runat="server"
                                    TargetControlID="txt_fecha"
                                    CssClass="calendario"
                                    Format="dd/MM/yyyy"
                                    PopupButtonID="ib_calendario" ID="CalendarExtender2" />
                                    </td>
                    <td>
                        <asp:ImageButton ID="ib_calendario" runat="server" 
                                   ImageUrl="../imagenes/sistema/gif/calendario.gif" 
                            onclick="ib_calendario_Click" style="height: 14px" />
                    </td>
                    </tr>
                </TABLE>
                <table>
                    <tr>
                        <td style="width: 56px; text-align: left; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
                            Hora<td style="text-align: left" class="style10">
                                <asp:TextBox ID="txt_hora" runat="server" Font-Names="Arial" 
                                    Font-Size="X-Small" MaxLength="200" Width="71px" TabIndex="47" 
                                Height="16px" 
                                style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" 
                                    ontextchanged="txt_hora_TextChanged" ></asp:TextBox>
                            </td>
                            </tr>
                </table>
            </asp:Panel>
                        
                <asp:Button ID="Button1" runat="server" Font-Names="Arial" Font-Size="X-Small" 
                        Text="Guardar" onclick="Button1_Click" TabIndex="16" />
                <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server" 
                        TargetControlID="Button1" 
                        ConfirmText="¿Esta seguro del estado seleccionado?" />
                    </cc1:ConfirmButtonExtender> 

                            
                        
                &nbsp;<asp:Button ID="Button2" runat="server" Font-Names="Arial" 
                        Font-Size="X-Small" onclick="Button2_Click" Text="cancelar" />
                        <asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" 
                        CellPadding="4" Font-Names="Arial" Font-Size="X-Small" ForeColor="#333333" 
                        GridLines="None" 
            onselectedindexchanged="gr_dato_SelectedIndexChanged" Width="445px">
        <RowStyle BackColor="#EFF3FB" />
        <Columns>
            <asp:BoundField AccessibleHeaderText="Estado" DataField="estado" 
                                HeaderText="Estado" />
            <asp:BoundField AccessibleHeaderText="cuenta usuario" 
                DataField="cuenta_usuario" HeaderText="cuenta usuario" Visible="False" />
            <asp:BoundField AccessibleHeaderText="Usuario" 
                DataField="nombre_usuario" HeaderText="Usuario" />
            <asp:BoundField AccessibleHeaderText="fecha_hora" DataField="fecha" 
                HeaderText="Fecha Hora" />
            <asp:BoundField AccessibleHeaderText="observacion" DataField="observacion" 
                HeaderText="Observacion" />
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
    </table>
    
</asp:Content>
