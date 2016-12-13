<%@ Page Title="" Language="C#" MasterPageFile="~/AGP.Master" AutoEventWireup="true" CodeBehind="ingresoTR.aspx.cs" Inherits="sistemaAGP.ingresoTR" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMenu" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoCentral" runat="server">
       <table  bgcolor="#E5E5E5">
                    <tr>
                    <td style="width: 789px; height: 20px" valign="top"  >
                 
                 <table  bgcolor="#669999" style="width: 100%">
                    <tr>
                    <td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 1115px; color: #FFFFFF;"><b>
                        CARGO OPERACION</b></td>
                    </tr>
                    </table>
                    <table>
                    <tr>
                    <td>
                        <span style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; font-weight: bold">Cliente</span>
                    </td>
                    <td>
                        <asp:DropDownList ID="dl_cliente" runat="server" Height="16px" Width="188px" 
                            AutoPostBack="True" onselectedindexchanged="dl_cliente_SelectedIndexChanged" 
                            style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; font-weight: 700">
                        </asp:DropDownList>
                        </td>
                    </tr>
                    </table>
                 
                 
                     <table  bgcolor="#669999" style="width: 100%">
                    <tr>
                    <td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 1115px; color: #FFFFFF;"><b>
                        DATOS DEL VENDEDOR</b></td>
                    </tr>
                    </table>
                    
                       <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                        
                    <table style="width: 773px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
                              <tr>
                            <td style="width: 30px; text-align: left; font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 25px;">
                                Rut 
                            <td style="width: 167px; text-align: center; height: 18px;">
                                <asp:TextBox ID="txt_rut" ontextchanged="txt_rut_Leave"  runat="server" Font-Names="Arial" 
                                        Font-Size="X-Small" MaxLength="8" TabIndex="27" AutoPostBack="True" 
                                     BackColor="#0099FF" ForeColor="White" 
                                    style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" 
                                    Height="16px" Width="98px" 
                                                         ></asp:TextBox>

       <cc1:FilteredTextBoxExtender ID="txt_rut_FilteredTextBoxExtender" 
                            runat="server" TargetControlID="txt_rut"
                            FilterType="Custom, Numbers"
                            ValidChars="">
                            
                        </cc1:FilteredTextBoxExtender>                                                     
                                                         
                                                         
                                </td>
                                <td>
                                <asp:ImageButton ID="ib_limpia_vende" runat="server" 
                            ImageUrl="../imagenes/sistema/static/limpia.jpg" Height="22px" Width="23px" 
                                        onclick="ib_limpia_vende_Click" />
                                </td>
                                <td>
                                    &nbsp;</td>
                            <td style="width: 15px; text-align: right; font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 25px;">
                                Dv</td>
                            <td style="text-align: left; height: 25px; width: 1px;">
                                <asp:TextBox ID="txt_dv" runat="server" Font-Names="Arial" 
                                        Font-Size="X-Small" MaxLength="1" Width="16px" TabIndex="28" 
                                    Height="16px" Enabled="False" 
                                    style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"></asp:TextBox>
                            </td>
                            
                            
                            
                             <td style="width: 20px; text-align: right; font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 25px;">
                                 Nombre</td>
                            <td style="text-align: left; width: 152px; height: 25px;">
                                <asp:TextBox ID="txt_nombre" runat="server" Font-Names="Arial" 
                                        Font-Size="X-Small" MaxLength="10" Width="169px" TabIndex="29" 
                                    Height="16px" 
                                    
                                    style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; margin-left: 0px;"></asp:TextBox>
                            </td>
                             <td style="width: 15px; text-align: right; font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 25px;">
                                 Apellido Paterno</td>
                            <td style="text-align: left; width: 147px; height: 25px;">
                                <asp:TextBox ID="txt_paterno" runat="server" Font-Names="Arial" 
                                        Font-Size="X-Small" MaxLength="10" Width="140px" TabIndex="30" 
                                    Height="16px" 
                                    style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"></asp:TextBox>
                            </td>
                            
                             <td style="width: 15px; text-align: right; font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 25px;">
                                 Apellido Materno</td>
                            <td style="text-align: left; width: 88px; height: 25px;">
                                <asp:TextBox ID="txt_materno" runat="server" Font-Names="Arial" 
                                        Font-Size="X-Small" MaxLength="10" Width="141px" TabIndex="31" 
                                    Height="16px" 
                                    style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"></asp:TextBox>
                            </td>
                            
                            
                        </tr>
                        </TABLE>
                        <table>
                        <tr>
                            <td style="width: 56px; text-align: left; font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 10px;">
                                Direccion<td style="width: 113px; text-align: left; height: 10px;">
                                <asp:TextBox ID="txt_direccion" runat="server" Font-Names="Arial" 
                                        Font-Size="X-Small" MaxLength="200" Width="243px" TabIndex="32" 
                                    Height="16px" 
                                    style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" ></asp:TextBox>
                            </td>
                            
                            <td style="width: 1px; text-align: right; font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 10px;">
                                Numero</td>
                            <td style="text-align: left; width: 20px; height: 10px;">
                                <asp:TextBox ID="txt_numero" runat="server" Font-Names="Arial" 
                                        Font-Size="X-Small" MaxLength="10" Width="88px" TabIndex="33" 
                                    Height="16px" 
                                    style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" ></asp:TextBox>
                            </td>
                            
                             <td style="width: 37px; text-align: right; font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 10px;">
                                 Depto</td>
                            <td style="text-align: left; height: 10px;">
                                <asp:TextBox ID="txt_depto" runat="server" Font-Names="Arial" 
                                        Font-Size="X-Small" MaxLength="10" Width="88px" TabIndex="34" 
                                    Height="16px" 
                                    style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" ></asp:TextBox>
                            </td>
                             <td style="width: 37px; text-align: right; font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 10px;">
                                 Telefono</td>
                            <td style="text-align: left; height: 10px;">
                                <asp:TextBox ID="txt_telefono" runat="server" Font-Names="Arial" 
                                        Font-Size="X-Small" MaxLength="10" Width="88px" TabIndex="34" 
                                    Height="16px" 
                                    style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" ></asp:TextBox>
                            </td>
                         
                            
                            
                        </tr>
                        </table>
                        <table>
                                            <tr>
                            <td style="width: 89px; height: 23px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
                                Pais<td style="width: 126px; text-align: left; height: 23px;">
                                <asp:DropDownList ID="dl_pais" runat="server" AutoPostBack="True" 
                                        Font-Names="Arial" Font-Size="X-Small" Height="16px" 
                                        onselectedindexchanged="dl_pais_SelectedIndexChanged" Width="138px" 
                                    TabIndex="35" style="font-family: Arial, Helvetica, sans-serif; font-size: x-small">
                                </asp:DropDownList>
                                                    
                            </td>
                            <td style="width: 15px; text-align: right; height: 23px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
                                Region
                            </td>
                            <td style="text-align: left; height: 23px;">
                                <asp:DropDownList ID="dl_region" runat="server" AutoPostBack="True" 
                                        Font-Names="Arial" Font-Size="X-Small" Height="19px" 
                                        onselectedindexchanged="dl_region_SelectedIndexChanged" Width="213px" 
                                    TabIndex="36" 
                                    style="font-family: Arial, Helvetica, sans-serif; font-size: x-small">
                                </asp:DropDownList>
                               
                            </td>
                            </tr>
                            <tr>
                             <td style="width: 89px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
                                 Ciudad</td>
                            <td style="text-align: left; ">
                                <asp:DropDownList ID="dl_ciudad" runat="server" AutoPostBack="True" 
                                        Font-Names="Arial" Font-Size="X-Small" Height="19px" 
                                         Width="173px" onselectedindexchanged="dl_ciudad_SelectedIndexChanged" 
                                    TabIndex="37" 
                                    style="font-family: Arial, Helvetica, sans-serif; font-size: x-small">
                                </asp:DropDownList>
                               
                            </td>
                            <td style="width: 15px; text-align: right; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
                                Comuna<br />
                                </td>
                            <td style="text-align: left; ">
                                <asp:DropDownList ID="dl_comuna" runat="server" 
                                        Font-Names="Arial" Font-Size="X-Small" Height="19px" 
                                         Width="213px" 
                                    TabIndex="38" onselectedindexchanged="dl_comuna_SelectedIndexChanged" 
                                    style="font-family: Arial, Helvetica, sans-serif; font-size: x-small">
                                </asp:DropDownList>
                                
                            </td>
     
                        <td style="width: 32px" align="center">
                            <asp:ImageButton ID="ib_comuna" runat="server" 
                            ImageUrl="../imagenes/sistema/static/HERRAMIENTA.png" Height="22px" Width="23px" 
                                onclick="ib_comuna_Click" Visible="False" />
                        </td>
     
                        
                        <td style="width: 32px" align="center">
                            <asp:ImageButton ID="ib_adquiriente" runat="server" 
                            ImageUrl="../imagenes/sistema/static/persona.png" Height="22px" Width="23px" 
                                onclick="ib_adquiriente_Click" Visible="False" />
                        </td>
                        
                        <td style="width: 32px" align="center">
                            <asp:ImageButton ID="ib_par_vendedor" runat="server" 
                            ImageUrl="../imagenes/sistema/static/personero.gif" Height="22px" Width="23px" 
                                      Visible="False" />
                        </td>
                        
                        
                       </tr>
                        
                    </table>
                    </ContentTemplate>
                        </asp:UpdatePanel>
                    
                    
                     <table  bgcolor="#669999" style="width: 100%">
                    <tr>
                    <td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 1115px; color: #FFFFFF;">
                        <b>
                        DATOS DE VENTA</b></td>
                    </tr>
                    </table>
                    
                     <table>
                    <tr>
                    <td style="font-size: x-small; font-family: Arial, Helvetica, sans-serif">
                        Patente</td>
                    <td>
                        <asp:TextBox ID="txt_patente" runat="server" MaxLength="6" 
                            style="font-size: x-small; font-family: Arial, Helvetica, sans-serif" 
                            Width="60px"></asp:TextBox>
                            <asp:TextBox ID="txt_dv_patente" runat="server" MaxLength="1" 
                            style="font-size: x-small; font-family: Arial, Helvetica, sans-serif" 
                            Width="16px"></asp:TextBox>
                    </td>
                    <td style="font-size: x-small; font-family: Arial, Helvetica, sans-serif">
                        Kilometraje</td>
                    <td>
                        <asp:TextBox ID="txt_kilometraje" runat="server" MaxLength="6" 
                            style="font-size: x-small; font-family: Arial, Helvetica, sans-serif" 
                            Width="65px"></asp:TextBox>
                           
                           <cc1:FilteredTextBoxExtender ID="txt_kilometrajeFilteredTextBoxExtender1" 
                            runat="server" TargetControlID="txt_kilometraje"
                            FilterType="Custom, Numbers"
                            ValidChars="">         </cc1:FilteredTextBoxExtender>     
                                                
                            
                    </td>
                    <td style="font-size: x-small; font-family: Arial, Helvetica, sans-serif">
                        Precio Venta</td>
                        <td>
                            <asp:TextBox ID="txt_precio" runat="server" MaxLength="8" 
                                style="font-size: x-small; font-family: Arial, Helvetica, sans-serif"></asp:TextBox>
                                 
                                 <cc1:FilteredTextBoxExtender ID="txt_precioFilteredTextBoxExtender1" 
                            runat="server" TargetControlID="txt_precio"
                            FilterType="Custom, Numbers"
                            ValidChars="">         </cc1:FilteredTextBoxExtender>  
                                             
                                
                        </td>
                        <td style="font-size: x-small; font-family: Arial, Helvetica, sans-serif">
                            Tasacion</td>
                    
                    <td>
                        <asp:TextBox ID="txt_tasacion" runat="server" 
                            style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"></asp:TextBox>
                            
                            <cc1:FilteredTextBoxExtender ID="txt_tasacionFilteredTextBoxExtender1" 
                            runat="server" TargetControlID="txt_tasacion"
                            FilterType="Custom, Numbers"
                            ValidChars="">
                            
                        </cc1:FilteredTextBoxExtender>     
                            
                    </td>
                    <td>
                        <asp:Label ID="lbl_codigo" runat="server" 
                            
                            style="font-family: Arial, Helvetica, sans-serif; font-size: small; color: #FFFFFF; background-color: #0099FF"></asp:Label>
                    </td>
                    <td>
                                                <asp:ImageButton ID="ib_tasacion" runat="server" 
                            ImageUrl="../imagenes/sistema/static/dinero1.gif" 
    Height="22px" Width="23px" 
                                 />
                        
                    </td>
                    </tr>
                    </table>
                
                    
                
                     <table  bgcolor="#669999" style="width: 100%">
                    <tr>
                    <td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 1115px; color: #FFFFFF;">
                        <b>
                        OPCIONES DE CONTRATO</b></td>
                    </tr>
                    </table>
                    
                    
                    
                     <table style="width: 371px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
                    <tr>
                    <td style="width: 115px; height: 15px;">
                        <asp:RadioButton ID="rb_consignacion" runat="server" AutoPostBack="True" 
                            GroupName="opciones" oncheckedchanged="rb_consignacion_CheckedChanged2" 
                            Text="Consignacion" Checked=true />
                        </td>
                        <td class="style1" style="width: 127px; height: 15px;">
                            <asp:RadioButton ID="rb_automotora" runat="server" GroupName="opciones" 
                                oncheckedchanged="rb_automotora_CheckedChanged" Text="Toma Directa" 
                                AutoPostBack="True" />
                        </td>
                        <td style="height: 15px">
                            <asp:RadioButton ID="rb_tercero" runat="server" AutoPostBack="True" 
                                GroupName="opciones" oncheckedchanged="rb_tercero_CheckedChanged1" 
                                Text="a Tercero" />
                        </td>
                    </tr>
                    </table>

    
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>

                        

                         <asp:Panel id="pnl_comprador" runat="server" Visible="false">

                     <table  bgcolor="#669999" style="width: 100%">
                    <tr>
                    <td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 1115px; color: #FFFFFF;">
                        <b>
                        DATOS DEL COMPRADOR</b></td>
                    </tr>
                    </table>
                    
                    
                    <table style="width: 773px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
                              <tr>
                            <td style="width: 30px; text-align: left; font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 25px;">
                                Rut 
                            <td style="width: 167px; text-align: center; height: 18px;">
                                <asp:TextBox ID="txt_rut_compra"  runat="server" Font-Names="Arial" 
                                        Font-Size="X-Small" MaxLength="8" TabIndex="40" AutoPostBack="True" 
                                    ontextchanged="txt_rut_compra_Leave" BackColor="#0099FF" ForeColor="White" 
                                    style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" 
                                    Height="16px" Width="98px" 
                                                         ></asp:TextBox>

       <cc1:FilteredTextBoxExtender ID="txt_rut_compraFilteredTextBoxExtender1" 
                            runat="server" TargetControlID="txt_rut_compra"
                            FilterType="Custom, Numbers"
                            ValidChars="">
                            
                        </cc1:FilteredTextBoxExtender>                                                     
                                                         
                                                         
                                </td>
                                 <td>
                                <asp:ImageButton ID="ib_limpia_compra" runat="server" 
                            ImageUrl="../imagenes/sistema/static/limpia.jpg" Height="22px" Width="23px" 
                                         onclick="ib_limpia_compra_Click" />
                                </td>
                                <td>
                                    &nbsp;</td>
                            <td style="width: 15px; text-align: right; font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 25px;">
                                Dv</td>
                            <td style="text-align: left; height: 25px; width: 1px;">
                                <asp:TextBox ID="txt_dv_compra" runat="server" Font-Names="Arial" 
                                        Font-Size="X-Small" MaxLength="1" Width="16px" TabIndex="41" 
                                    Height="16px" Enabled="False" 
                                    style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"></asp:TextBox>
                            </td>
                            
                            
                            
                             <td style="width: 20px; text-align: right; font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 25px;">
                                 Nombre</td>
                            <td style="text-align: left; width: 152px; height: 25px;">
                                <asp:TextBox ID="txt_nombre_compra" runat="server" Font-Names="Arial" 
                                        Font-Size="X-Small" MaxLength="10" Width="169px" TabIndex="42" 
                                    Height="16px" 
                                    
                                    
                                    
                                    style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; margin-left: 0px;"></asp:TextBox>
                            </td>
                             <td style="width: 15px; text-align: right; font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 25px;">
                                 Apellido Paterno</td>
                            <td style="text-align: left; width: 147px; height: 25px;">
                                <asp:TextBox ID="txt_apellidop_compra" runat="server" Font-Names="Arial" 
                                        Font-Size="X-Small" MaxLength="10" Width="140px" TabIndex="43" 
                                    Height="16px" 
                                    style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"></asp:TextBox>
                            </td>
                            
                             <td style="width: 15px; text-align: right; font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 25px;">
                                 Apellido Materno</td>
                            <td style="text-align: left; width: 88px; height: 25px;">
                                <asp:TextBox ID="txt_apellidom_compra" runat="server" Font-Names="Arial" 
                                        Font-Size="X-Small" MaxLength="10" Width="141px" TabIndex="44" 
                                    Height="16px" 
                                    style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"></asp:TextBox>
                            </td>
                            
                            
                        </tr>
                        </TABLE>
                        <table>
                        <tr>
                            <td style="width: 56px; text-align: left; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
                                Direccion<td style="width: 113px; text-align: left">
                                <asp:TextBox ID="txt_direccion_compra" runat="server" Font-Names="Arial" 
                                        Font-Size="X-Small" MaxLength="200" Width="243px" TabIndex="47" 
                                    Height="16px" 
                                    style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" ></asp:TextBox>
                            </td>
                            
                            <td style="width: 1px; text-align: right; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
                                Numero</td>
                            <td style="text-align: left; width: 20px;">
                                <asp:TextBox ID="txt_numero_compra" runat="server" Font-Names="Arial" 
                                        Font-Size="X-Small" MaxLength="10" Width="88px" TabIndex="33" 
                                    Height="16px" 
                                    style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" ></asp:TextBox>
                            </td>
                            
                             <td style="width: 37px; text-align: right; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
                                 Depto</td>
                            <td style="text-align: left; ">
                                <asp:TextBox ID="txt_depto_compra" runat="server" Font-Names="Arial" 
                                        Font-Size="X-Small" MaxLength="10" Width="88px" TabIndex="34" 
                                    Height="16px" 
                                    style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" ></asp:TextBox>
                            </td>
                         
                           <td style="width: 37px; text-align: right; font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 10px;">
                                 Telefono</td>
                            <td style="text-align: left; height: 10px;">
                                <asp:TextBox ID="txt_telefono_compra" runat="server" Font-Names="Arial" 
                                        Font-Size="X-Small" MaxLength="10" Width="88px" TabIndex="48" 
                                    Height="16px" 
                                    style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" ></asp:TextBox>
                            </td>
                            
                            
                        </tr>
                        </table>
                        <table>
                                            <tr>
                            <td style="width: 56px; height: 23px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
                                Pais<td style="width: 126px; text-align: left; height: 23px;">
                                <asp:DropDownList ID="dl_pais_compra" runat="server" AutoPostBack="True" 
                                        Font-Names="Arial" Font-Size="X-Small" Height="16px" 
                                        onselectedindexchanged="dl_pais_compra_SelectedIndexChanged" Width="138px" 
                                    TabIndex="49" 
                                        style="font-family: Arial, Helvetica, sans-serif; font-size: x-small">
                                </asp:DropDownList>
                                                    
                            </td>
                            <td style="width: 15px; text-align: right; height: 23px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
                                Region
                            </td>
                            <td style="text-align: left; height: 23px;">
                                <asp:DropDownList ID="dl_region_compra" runat="server" AutoPostBack="True" 
                                        Font-Names="Arial" Font-Size="X-Small" Height="19px" 
                                        onselectedindexchanged="dl_region_compra_SelectedIndexChanged" Width="213px" 
                                    TabIndex="50" 
                                    style="font-family: Arial, Helvetica, sans-serif; font-size: x-small">
                                </asp:DropDownList>
                               
                            </td>
                            </tr>
                            <tr>
                             <td style="width: 15px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
                                 Ciudad</td>
                            <td style="text-align: left; ">
                                <asp:DropDownList ID="dl_ciudad_compra" runat="server" AutoPostBack="True" 
                                        Font-Names="Arial" Font-Size="X-Small" Height="19px" 
                                         Width="173px" onselectedindexchanged="dl_ciudad_compra_SelectedIndexChanged" 
                                    TabIndex="51" 
                                    style="font-family: Arial, Helvetica, sans-serif; font-size: x-small">
                                </asp:DropDownList>
                               
                            </td>
                            <td style="width: 15px; text-align: right; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
                                Comuna<br />
                                </td>
                            <td style="text-align: left; ">
                                <asp:DropDownList ID="dl_comuna_compra" runat="server" 
                                        Font-Names="Arial" Font-Size="X-Small" Height="19px" 
                                         Width="213px" 
                                    TabIndex="52" 
                                    style="font-family: Arial, Helvetica, sans-serif; font-size: x-small">
                                </asp:DropDownList>
                                
                            </td>
                            
                               <td style="width: 32px" align="center">
                            <asp:ImageButton ID="ImageButton1" runat="server" 
                            ImageUrl="../imagenes/sistema/static/herramienta.png" Height="22px" Width="23px" 
                                onclick="ib_comuna_para_Click" Visible="False" />
                        </td>
     
                            
                              <td style="width: 32px" align="center">
                            <asp:ImageButton ID="ib_comprador" runat="server" 
                            ImageUrl="../imagenes/sistema/static/persona.png" Height="22px" Width="23px" 
                                      Visible="False" />
                        </td>
                        
                        
                              <td style="width: 32px" align="center">
                            <asp:ImageButton ID="ib_par_comprador" runat="server" 
                            ImageUrl="../imagenes/sistema/static/personero.gif" Height="22px" Width="23px" 
                                      Visible="False" />
                        </td>
                        
                        <td style="width: 89px" align="center">
                            <asp:CheckBox ID="chk_compra_para" runat="server" AutoPostBack="True" 
                                style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; font-weight: 700; color: #FF0000;" 
                                Text="Compra Para" TabIndex="39" 
                                oncheckedchanged="chk_compra_para_CheckedChanged" />
                        </td>
                            
                        </tr>
                    </table>
               
               </asp:Panel>

</ContentTemplate>
                        </asp:UpdatePanel>
                    
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                    
                     <asp:Panel id="pnl_compra_para" runat="server" Visible="false">

                     <table  bgcolor="#669999" style="width: 100%">
                    <tr>
                    <td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 1115px; color: #FFFFFF;">
                        <b>
                        DATOS COMPRA PARA</b>
                        </td>
                    </tr>
                    </table>
                    
                    
                    <table style="width: 773px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
                              <tr>
                            <td style="width: 30px; text-align: left; font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 25px;">
                                Rut 
                            <td style="width: 167px; text-align: center; height: 18px;">
                                <asp:TextBox ID="txt_rut_para"  runat="server" Font-Names="Arial" 
                                        Font-Size="X-Small" MaxLength="8" TabIndex="40" AutoPostBack="True" 
                                    ontextchanged="txt_rut_para_Leave" BackColor="#0099FF" ForeColor="White" 
                                    style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" 
                                    Height="16px" Width="98px" 
                                                         ></asp:TextBox>

       <cc1:FilteredTextBoxExtender ID="txt_rut_para_FilteredTextBoxExtender" 
                            runat="server" TargetControlID="txt_rut_para"
                            FilterType="Custom, Numbers"
                            ValidChars="">
                            
                        </cc1:FilteredTextBoxExtender>                                                     
                                                         
                                                         
                                </td>
                                <td>
                                <asp:ImageButton ID="ib_limpia_para" runat="server" 
                            ImageUrl="../imagenes/sistema/static/limpia.jpg" Height="22px" Width="23px" 
                                        onclick="ib_limpia_para_Click" />
                                </td>
                                <td>
                                    &nbsp;</td>
                            <td style="width: 15px; text-align: right; font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 25px;">
                                Dv</td>
                            <td style="text-align: left; height: 25px; width: 1px;">
                                <asp:TextBox ID="txt_dv_para" runat="server" Font-Names="Arial" 
                                        Font-Size="X-Small" MaxLength="1" Width="16px" TabIndex="41" 
                                    Height="16px" Enabled="False" 
                                    style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"></asp:TextBox>
                            </td>
                            
                            
                            
                             <td style="width: 20px; text-align: right; font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 25px;">
                                 Nombre</td>
                            <td style="text-align: left; width: 152px; height: 25px;">
                                <asp:TextBox ID="txt_nombre_para" runat="server" Font-Names="Arial" 
                                        Font-Size="X-Small" MaxLength="10" Width="169px" TabIndex="42" 
                                    Height="16px" 
                                    
                                    
                                    style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; margin-left: 0px;"></asp:TextBox>
                            </td>
                             <td style="width: 15px; text-align: right; font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 25px;">
                                 Apellido Paterno</td>
                            <td style="text-align: left; width: 147px; height: 25px;">
                                <asp:TextBox ID="txt_paterno_para" runat="server" Font-Names="Arial" 
                                        Font-Size="X-Small" MaxLength="10" Width="140px" TabIndex="43" 
                                    Height="16px" 
                                    style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"></asp:TextBox>
                            </td>
                            
                             <td style="width: 15px; text-align: right; font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 25px;">
                                 Apellido Materno</td>
                            <td style="text-align: left; width: 88px; height: 25px;">
                                <asp:TextBox ID="txt_materno_para" runat="server" Font-Names="Arial" 
                                        Font-Size="X-Small" MaxLength="10" Width="141px" TabIndex="44" 
                                    Height="16px" 
                                    style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"></asp:TextBox>
                            </td>
                            
                            
                        </tr>
                        </TABLE>
                        <table>
                        <tr>
                            <td style="width: 56px; text-align: left; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
                                Direccion<td style="width: 113px; text-align: left">
                                <asp:TextBox ID="txt_direccion_para" runat="server" Font-Names="Arial" 
                                        Font-Size="X-Small" MaxLength="200" Width="243px" TabIndex="47" 
                                    Height="16px" 
                                    style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" ></asp:TextBox>
                            </td>
                            
                            <td style="width: 1px; text-align: right; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
                                Numero</td>
                            <td style="text-align: left; width: 20px;">
                                <asp:TextBox ID="txt_numero_para" runat="server" Font-Names="Arial" 
                                        Font-Size="X-Small" MaxLength="10" Width="88px" TabIndex="33" 
                                    Height="16px" 
                                    style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" ></asp:TextBox>
                            </td>
                            
                             <td style="width: 37px; text-align: right; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
                                 Depto</td>
                            <td style="text-align: left; ">
                                <asp:TextBox ID="txt_depto_para" runat="server" Font-Names="Arial" 
                                        Font-Size="X-Small" MaxLength="10" Width="88px" TabIndex="34" 
                                    Height="16px" 
                                    style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" ></asp:TextBox>
                            </td>
                         
                           <td style="width: 37px; text-align: right; font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 10px;">
                                 Telefono</td>
                            <td style="text-align: left; height: 10px;">
                                <asp:TextBox ID="txt_telefono_para" runat="server" Font-Names="Arial" 
                                        Font-Size="X-Small" MaxLength="10" Width="88px" TabIndex="48" 
                                    Height="16px" 
                                    style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" ></asp:TextBox>
                            </td>
                            
                            
                        </tr>
                        </table>
                        <table>
                                            <tr>
                            <td style="width: 56px; height: 23px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
                                Pais<td style="width: 126px; text-align: left; height: 23px;">
                                <asp:DropDownList ID="dl_pais_para" runat="server" AutoPostBack="True" 
                                        Font-Names="Arial" Font-Size="X-Small" Height="16px" 
                                        onselectedindexchanged="dl_pais_para_SelectedIndexChanged" Width="138px" 
                                    TabIndex="49" 
                                        style="font-family: Arial, Helvetica, sans-serif; font-size: x-small">
                                </asp:DropDownList>
                                                    
                            </td>
                            <td style="width: 15px; text-align: right; height: 23px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
                                Region
                            </td>
                            <td style="text-align: left; height: 23px;">
                                <asp:DropDownList ID="dl_region_para" runat="server" AutoPostBack="True" 
                                        Font-Names="Arial" Font-Size="X-Small" Height="19px" 
                                        onselectedindexchanged="dl_region_para_SelectedIndexChanged" Width="213px" 
                                    TabIndex="50" 
                                    style="font-family: Arial, Helvetica, sans-serif; font-size: x-small">
                                </asp:DropDownList>
                               
                            </td>
                            </tr>
                            <tr>
                             <td style="width: 15px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
                                 Ciudad</td>
                            <td style="text-align: left; ">
                                <asp:DropDownList ID="dl_ciudad_para" runat="server" AutoPostBack="True" 
                                        Font-Names="Arial" Font-Size="X-Small" Height="19px" 
                                         Width="173px" onselectedindexchanged="dl_ciudad_para_SelectedIndexChanged" 
                                    TabIndex="51" 
                                    style="font-family: Arial, Helvetica, sans-serif; font-size: x-small">
                                </asp:DropDownList>
                               
                            </td>
                            <td style="width: 15px; text-align: right; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
                                Comuna<br />
                                </td>
                            <td style="text-align: left; ">
                                <asp:DropDownList ID="dl_comuna_para" runat="server" 
                                        Font-Names="Arial" Font-Size="X-Small" Height="19px" 
                                         Width="213px" 
                                    TabIndex="52" 
                                    style="font-family: Arial, Helvetica, sans-serif; font-size: x-small">
                                </asp:DropDownList>
                                
                            </td>
                            
                               <td style="width: 32px" align="center">
                            <asp:ImageButton ID="ib_comuna_para" runat="server" 
                            ImageUrl="../imagenes/sistema/static/herramienta.png" Height="22px" Width="23px" 
                                onclick="ib_comuna_para_Click" Visible="False" />
                        </td>
     
                            
                              <td style="width: 32px" align="center">
                            <asp:ImageButton ID="ib_compra_para" runat="server" 
                            ImageUrl="../imagenes/sistema/static/persona.png" Height="22px" Width="23px" 
                                      Visible="False" />
                        </td>
                            <td style="width: 32px" align="center">
                            <asp:ImageButton ID="ib_par_compra_para" runat="server" 
                            ImageUrl="../imagenes/sistema/static/personero.gif" Height="22px" Width="23px" 
                                      Visible="False" />
                        </td>
                            
                        </tr>
                    </table>
               
               </asp:Panel>
               
               </ContentTemplate>
                        </asp:UpdatePanel>

                
                
                <table>
                <tr>
                <td>
                
                    <asp:Button ID="bt_guardar" runat="server" 
                        style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" 
                        Text="Guardar" onclick="bt_guardar_Click" />
                         <cc1:ConfirmButtonExtender ID="bt_guardar_ConfirmButtonExtender" runat="server" 
                        TargetControlID="bt_guardar"
                        ConfirmText="¿Esta seguro de ingresar un nuevo contrato de transferencia?" >
                </cc1:ConfirmButtonExtender>
                
                </td>
                <td>
                    <asp:Button ID="Button1" runat="server" 
                        style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" 
                        Text="Limpiar" />
                    </td>
                <td style="width: 721px; text-align: right">
                        
                        <asp:Label ID="lbl_operacion" runat="server" Font-Names="Arial" 
                            Font-Size="Small" ForeColor="#FF3300" Visible="False"></asp:Label>
                        <asp:Label ID="lbl_numero" runat="server" Font-Names="Arial" 
                            Font-Size="Small" ForeColor="#FF3300" Visible="False"></asp:Label>
                    </td>
                </tr>
                </table>
                
                    </td>
</tr>
    </table>
    
   
    
    <asp:Panel ID="pnlPopUp" runat="server" CssClass="CajaDialogo" Style="display: none;">
     
     <table>
                    <tr>
                    <td>
                        <span style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; font-weight: bold">Codigo SII</span>
                    </td>
                    <td>
                    <asp:TextBox ID="txt_sii" runat="server" MaxLength="10" 
                                style="font-size: x-small; font-family: Arial, Helvetica, sans-serif"></asp:TextBox>
                    </td>
                    <td>
                    
                            <asp:ImageButton ID="ib_busca_sii" runat="server" 
                            ImageUrl="../imagenes/sistema/gif/lupa.gif" Height="22px" 
                            Width="23px" onclick="ib_busca_sii_Click" />
                    
                    </td>
                    </tr>
                    
                    </table>
                    
                    <table>
                    <tr>
                    <td>
                       
                <asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False"  
                        CellPadding="4" Font-Names="Arial" Font-Size="X-Small" ForeColor="#333333" 
                        GridLines="None" Width="456px" 
                            onselectedindexchanged="gr_dato_SelectedIndexChanged" Visible="true" >
                    <RowStyle BackColor="#EFF3FB" />
                    <Columns>
                        <asp:CommandField SelectText="&lt;&lt;&gt;&gt;" ShowSelectButton="True" />
                        <asp:BoundField AccessibleHeaderText="Marca" DataField="Marca" 
                            HeaderText="Marca" />
                        <asp:BoundField AccessibleHeaderText="Modelo" DataField="modelo" 
                            HeaderText="Modelo" />
                        <asp:BoundField AccessibleHeaderText="Puertas" DataField="puerta" 
                            HeaderText="Puertas" />
                        <asp:BoundField AccessibleHeaderText="Cilindrada" DataField="Cilindrada" 
                            HeaderText="Cilindrada" />
                        <asp:BoundField AccessibleHeaderText="Combustible" DataField="Combustible" 
                            HeaderText="Combustible" />
                        <asp:BoundField AccessibleHeaderText="Transmision" DataField="Transmision" 
                            HeaderText="Transmision" />
                        <asp:BoundField AccessibleHeaderText="Equipo" DataField="Equipo" 
                            HeaderText="Equipo" />
                        <asp:BoundField AccessibleHeaderText="Tasacion" DataField="tasacion" 
                            HeaderText="Tasacion" />
                        <asp:BoundField AccessibleHeaderText="Permiso" DataField="Permiso" 
                            HeaderText="Permiso" />
                        <asp:BoundField AccessibleHeaderText="Año" DataField="Ano" HeaderText="Año" />
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
                    <table>
                    <tr>
                    <td>
                     <asp:Button ID="bt_salir" runat="server" Font-Names="Arial" 
                            Font-Size="X-Small" Text="Cancelar" OnClick="bt_salir_OnClick" />
                    </td>
                    </tr>
                    </table>
    

  </asp:Panel>
                
                <cc1:ModalPopupExtender ID="ModalPopupExtender" runat="server" BackgroundCssClass="FondoAplicacion"
                    DropShadow="false" PopupDragHandleControlID="pnlPopUp" PopupControlID="pnlPopUp"

 TargetControlID="ib_tasacion" CancelControlID="bt_salir" />
                    


</asp:Content>
