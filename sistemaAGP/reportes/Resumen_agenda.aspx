<%@ Page Title="Control de Operaciones AGP S.A." Language="C#" MasterPageFile="~/AGP.Master"
	AutoEventWireup="true" CodeBehind="Resumen_agenda.aspx.cs" Inherits="sistemaAGP.Resumen_agenda" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMenu" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoCentral" runat="server">
    <table align="left" style="width: 55%; height: 440px">
        <tr>
            <td class="style4" style="height: 74px" valign="top">
                <table style="width: 100%; height: 32px;" bgcolor="#507CD1">
                    <tr>
                        <td style="width: 38px; font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 28px; color: #FFFFFF;">
                            <b>Tecnico</b></td>
                        <td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 28px;">
                            <b>
                            <asp:DropDownList ID="dl_tecnico" runat="server"
                                    Font-Names="Arial" Font-Size="X-Small" Height="16px"
                                    Width="138px" TabIndex="1" 
                                style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #000000;" 
                                AutoPostBack="True" 
                                onselectedindexchanged="dl_tecnico_SelectedIndexChanged" >
								<asp:ListItem Text="usuario test 1" Value="153944601" />
								<asp:ListItem Text="usuario test 2" Value="179249669" />
                                
                            </asp:DropDownList>
                            </b>
                        </td>
                        <td class="style1" 
                            
                            
                            style="width: 57px; font-family: Arial, Helvetica, sans-serif; font-size: x-small; font-weight: bold; height: 28px; color: #FFFFFF;">
                            Modulo</td>
                        <td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 28px;">
                            <b>
                            <asp:DropDownList ID="dl_hora" runat="server"
                                    Font-Names="Arial" Font-Size="X-Small" Height="16px"
                                    Width="138px" TabIndex="17" 
                                
                                
                                style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #000000;" 
                                onselectedindexchanged="dl_hora_SelectedIndexChanged" >
                                
                            </asp:DropDownList>
                            </b>
                        </td>
                        
                    </tr>
                    
                   <tr>
                   
                   <td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #FFFFFF">
                       <b>Desde
                   </b>
                   </td>
                   <td>
                     <asp:TextBox ID="txt_desde" runat="server" 
                                    style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" 
                                    Height="19px" Width="73px" TabIndex="2" 
						   ontextchanged="txt_desde_TextChanged"></asp:TextBox>
                               
                     <asp:ImageButton ID="ib_desde" runat="server" 
                                       ImageUrl="../imagenes/sistema/gif/calendario.gif" 
                           style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" 
						   onclick="ib_desde_Click" />
                               
                               <cc1:CalendarExtender ID="CalendarExtender1"    runat="server"
                                        TargetControlID="txt_desde"
                                        CssClass="FondoAplicacion"
                                        Format="dd/MM/yyyy"
                                        PopupButtonID="ib_desde" /> 
                   </td>
                   <td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #FFFFFF; font-weight: 700">
                   Hasta
                   </td>
                   <td>
                     <asp:TextBox ID="txt_hasta" runat="server" 
                                    style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" 
                                    Height="19px" Width="73px" TabIndex="2" 
						   ontextchanged="txt_hasta_TextChanged"></asp:TextBox>
                               
                     <asp:ImageButton ID="ib_hasta" runat="server" 
                                       ImageUrl="../imagenes/sistema/gif/calendario.gif" 
                           style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" 
						   onclick="ib_hasta_Click" />
                               
                               <cc1:CalendarExtender ID="CalendarExtender2"    runat="server"
                                        TargetControlID="txt_hasta"
                                        CssClass="FondoAplicacion"
                                        Format="dd/MM/yyyy"
                                        PopupButtonID="ib_hasta" /> 
                   </td>
                   
                   
                    </tr>
					<tr>
						<td style="width: 32px" align="center">
							<asp:ImageButton ID="ib_resumen" runat="server" ImageUrl="../imagenes/sistema/static/correo.png"
								Height="22px" Width="23px" OnClick="ib_resumen_Click" Enabled="TRUE" />
						</td>
					</tr>
                </table>
                

                <center>
                <table style="width: 100%; height: 264px; " >
                <tr>
                <td style="width: 123px;" valign="top">
                    
                            &nbsp;</td>
                </tr>
                </table>
                
   
    
                </center>
                
            </td>
        </tr>
    </table>
</asp:Content>
