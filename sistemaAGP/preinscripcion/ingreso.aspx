<%@ Page Title="Ingreso de Pre-inscripcion de vehiculos motorizados" Language="C#" MasterPageFile="~/AGP.Master" AutoEventWireup="true" CodeBehind="ingreso.aspx.cs" Inherits="sistemaAGP.ingreso" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMenu" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoCentral" runat="server">
        <table style="width: 78%; height: 348px">
            <tr>
                <td style="height: 342px" valign="top">
                    
                    <table  bgcolor="#E5E5E5">
                    <td style="width: 789px; height: 20px;">
                    
                    
                     <table  bgcolor="#669999" style="width: 100%">
                    <tr>
                    <td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 1115px; color: #FFFFFF;"><b>
                        INGRESO DE VEHICULOS MOTORIZADOS</b></td>
                    </tr>
                    </table>
                    
                    
                    <table style="width: 97%">
                        <tr>
                                       <td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
                                Cliente</td>
                            <td>
                                <asp:DropDownList ID="dl_cliente" runat="server"
                                        Font-Names="Arial" Font-Size="X-Small" Height="16px"
                                        Width="138px" TabIndex="1" 
                                    style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" 
                                    AutoPostBack="True" 
                                    onselectedindexchanged="dl_cliente_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                
                            <td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
                                Nº Factura</td>
                            <td>
                                <asp:TextBox ID="txt_factura"  runat="server" Font-Names="Arial" 
                                        Font-Size="X-Small" MaxLength="8" TabIndex="27" AutoPostBack="True" 
                                    ontextchanged="txt_factura_Leave" BackColor="#0099FF" ForeColor="White" 
                                    style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" 
                                    Height="16px" Width="98px" 
                                                         ></asp:TextBox>

       <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender_factura" 
                            runat="server" TargetControlID="txt_factura"
                            FilterType="Custom, Numbers"
                            ValidChars="">
                            
                        </cc1:FilteredTextBoxExtender>                           
                            </td>
                                        <td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
                                Fecha Facturacion</td>
                            <td>
                               
                               
                                <asp:TextBox ID="txt_fecha_factura" runat="server" 
                                    style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" 
                                    Height="19px" Width="73px" TabIndex="2"></asp:TextBox>
                               
                               
                               <td>
                               
                               <asp:ImageButton ID="ib_calendario" runat="server" 
                                       ImageUrl="../imagenes/sistema/gif/calendario.gif" />
                               
                               <cc1:CalendarExtender    runat="server"
                                        TargetControlID="txt_fecha_factura"
                                        CssClass="FondoAplicacion"
                                        Format="dd/MM/yyyy"
                                        PopupButtonID="ib_calendario" /> 
                                        
                                   
                                        
                               </td>         
                               
                              <td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
                                Neto</td>
                            <td>
                               
                                <asp:TextBox ID="txt_neto" runat="server" Width="104px" 
                                    style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" 
                                    BackColor="#3399FF" ForeColor="White" TabIndex="3"></asp:TextBox>
                                   
                            <cc1:FilteredTextBoxExtender ID="txt_neto_FilteredTextBoxExtender" 
                            runat="server" TargetControlID="txt_neto"
                            FilterType="Custom, Numbers"
                            ValidChars="">
                            
                        </cc1:FilteredTextBoxExtender>      
                               
                            </td>
                
                  <td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
                                Patente</td>
                            <td>
                               
                                <asp:TextBox ID="txt_patente" runat="server" Width="89px" MaxLength="6"
                                    style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" 
                                    BackColor="#3399FF" ForeColor="White" TabIndex="3"></asp:TextBox>
                        
                        <asp:TextBox ID="txt_dv_patente" runat="server" Width="16px" MaxLength="1"
                                    style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" 
                                    BackColor="#3399FF" ForeColor="White" TabIndex="3"></asp:TextBox>
                               
                            </td>
                
                        </tr>
                    </table>
                    
                     <table  bgcolor="#669999" style="width: 100%">
                    <tr>
                    <td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 1115px; color: #FFFFFF;"><b>
                        DATOS DEL VEHICULO</b></td>
                    </tr>
                    </table>
                    
                    
                    <table style="width: 32%">
                        <tr>
                                       <td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
                                           Tipo Vehiculo</td>
                            <td>
                                <asp:DropDownList ID="dl_tipo_vehiculo" runat="server"
                                        Font-Names="Arial" Font-Size="X-Small" Height="16px"
                                        Width="138px" TabIndex="4" 
                                    style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" 
                                    onselectedindexchanged="dl_tipo_vehiculo_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                
                            <td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
                                Marca</td>
                            <td>
                                <asp:DropDownList ID="dl_marca_vehiculo" runat="server"
                                        Font-Names="Arial" Font-Size="X-Small" Height="16px"
                                        Width="138px" TabIndex="5" 
                                    style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" 
                                    AutoPostBack="True" 
                                    onselectedindexchanged="dl_marca_vehiculo_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                                        <td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
                                            Modelo</td>
                            <td>
                                <asp:DropDownList ID="dl_modelo_vehiculo" runat="server"
                                        Font-Names="Arial" Font-Size="X-Small" Height="16px"
                                        Width="138px" TabIndex="6" 
                                    style="font-family: Arial, Helvetica, sans-serif; font-size: x-small">
                                </asp:DropDownList>
                            </td>
                                                                <td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
                                                                    Año</td>
                            <td>
                                <asp:TextBox ID="txt_ano_vehiculo" runat="server" Width="56px" 
                                    style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" 
                                    MaxLength="4" TabIndex="7"></asp:TextBox>
                                    
                             <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" 
                            runat="server" TargetControlID="txt_ano_vehiculo"
                            FilterType="Custom, Numbers"
                            ValidChars="">
                            </cc1:FilteredTextBoxExtender>  
                                    
                            </td>

                
                        </tr>
                    </table>
                    <table style="width: 32%">
                        <tr>
                                       <td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
                                           Cilindrada</td>
                            <td>
                                <asp:TextBox ID="txt_cilindrada" runat="server" 
                                    style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" 
                                    MaxLength="10" Width="67px" TabIndex="8"></asp:TextBox>
                            </td>
                
                            <td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
                                Nº Puertas</td>
                            <td>
                                <asp:TextBox ID="txt_puertas" runat="server" 
                                    style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" 
                                    Height="19px" Width="43px" TabIndex="9" MaxLength="2"></asp:TextBox>
                            
                              <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" 
                            runat="server" TargetControlID="txt_puertas"
                            FilterType="Custom, Numbers"
                            ValidChars="">
                            </cc1:FilteredTextBoxExtender>  
                            
                            </td>
                                        <td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
                                            Nº Asientos</td>
                            <td>
                                <asp:TextBox ID="txt_asientos" runat="server" 
                                    style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" 
                                    Width="39px" Height="19px" TabIndex="10" MaxLength="2"></asp:TextBox>
                                    
                             <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" 
                            runat="server" TargetControlID="txt_asientos"
                            FilterType="Custom, Numbers"
                            ValidChars="">
                            </cc1:FilteredTextBoxExtender>  
                                    
                            </td>
                                                                <td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
                                                                    Peso Bruto </td>
                            <td>
                                <asp:TextBox ID="txt_peso_bruto" runat="server" Width="56px" 
                                    style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" 
                                    TabIndex="11" MaxLength="4"></asp:TextBox>
                              <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" 
                            runat="server" TargetControlID="txt_peso_bruto"
                            FilterType="Custom, Numbers"
                            ValidChars="">
                            </cc1:FilteredTextBoxExtender>  
                            
                            
                            </td>
                             <td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
                                                                    Peso Carga </td>
                            <td>
                                <asp:TextBox ID="txt_peso_carga" runat="server" Width="56px" 
                                    style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" 
                                    TabIndex="12" MaxLength="4"></asp:TextBox>
                            
                              <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" 
                            runat="server" TargetControlID="txt_peso_carga"
                            FilterType="Custom, Numbers"
                            ValidChars="">
                            </cc1:FilteredTextBoxExtender>  
                            
                            </td>
                                        <td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
                                                                    Combustible </td>
                            <td>
                                <asp:DropDownList ID="dl_combustible" runat="server"
                                        Font-Names="Arial" Font-Size="X-Small" Height="16px"
                                        Width="138px" TabIndex="13" 
                                    style="font-family: Arial, Helvetica, sans-serif; font-size: x-small">
                                </asp:DropDownList>
                            </td>

                
                        </tr>
                    </table>
                    
                    
                    
                    
                        <table style="width: 32%">
                        <tr>
                                       <td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
                                           Color</td>
                            <td>
                                <asp:TextBox ID="txt_color" runat="server" 
                                    style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" 
                                    MaxLength="50" Width="164px" TabIndex="14" Height="16px"></asp:TextBox>
                            </td>
                
                            <td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
                                Motor</td>
                            <td>
                                <asp:TextBox ID="txt_motor" runat="server" 
                                    style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" 
                                    MaxLength="30" Width="160px" TabIndex="15"></asp:TextBox>
                            </td>
                                        <td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
                                            Chasis</td>
                            <td>
                                <asp:TextBox ID="txt_chasis" runat="server" 
                                    style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" 
                                    MaxLength="30" Width="160px" TabIndex="16"></asp:TextBox>
                            </td>
                                                      

                
                        </tr>
                    
                    </table>
                    
                     <table  bgcolor="#669999" style="width: 100%">
                    <tr>
                    <td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 1115px; color: #FFFFFF;"><b>
                        DATOS DEL NEGOCIO</b></td>
                    </tr>
                    </table>
                    
                    
                        <table style="width: 98%">
                        <tr>
                                       <td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
                                           Sucursal Origen</td>
                            <td>
                                <asp:DropDownList ID="dl_sucursal_origen" runat="server"
                                        Font-Names="Arial" Font-Size="X-Small" Height="16px"
                                        Width="138px" TabIndex="17" 
                                    style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" >
                                    
                                </asp:DropDownList>
                            </td>
                
                            <td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
                                Sucursal Destino</td>
                            <td>
                                <asp:DropDownList ID="dl_sucursal_destino" runat="server"
                                        Font-Names="Arial" Font-Size="X-Small" Height="16px"
                                        Width="138px" TabIndex="18" 
                                    style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" >
                                    
                                </asp:DropDownList>
                            </td>
                                        <td style="width: 117px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
                                            Forma de Pago</td>
                            <td>
                                <asp:DropDownList ID="dl_forma_pago" runat="server"
                                        Font-Names="Arial" Font-Size="X-Small" Height="16px"
                                        Width="138px" TabIndex="18" 
                                    style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" >
                                    
                                </asp:DropDownList>
                            </td>
                                                      
    <td style="width: 117px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
                                            Entidad Financiera</td>
                            <td>
                                <asp:DropDownList ID="dl_financiera" runat="server"
                                        Font-Names="Arial" Font-Size="X-Small" Height="16px"
                                        Width="138px" TabIndex="19" 
                                    style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" >
                                    
                                </asp:DropDownList>
                            </td>
                                               
                
                        </tr>
                    
                    </table>
                   
                        <table style="width: 98%">
                        <tr>
                                       <td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
                                           Nº Poliza</td>
                            <td>
                                <asp:TextBox ID="txt_poliza" runat="server" Width="56px" 
                                    style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" 
                                    TabIndex="20" MaxLength="8"></asp:TextBox>
                            
                            
                            
                            </td>
                
                            <td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
                                Distribuidor Poliza</td>
                            <td>
                                <asp:DropDownList ID="dl_distribuidor_poliza" runat="server"
                                        Font-Names="Arial" Font-Size="X-Small" Height="16px"
                                        Width="138px" TabIndex="21" 
                                    style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" >
                                    
                                </asp:DropDownList>
                            </td>
                                        <td style="width: 117px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
                                            Cargo Venta</td>
                            <td>
                                <asp:DropDownList ID="dl_cargo_venta" runat="server"
                                        Font-Names="Arial" Font-Size="X-Small" Height="16px"
                                        Width="138px" TabIndex="22" 
                                    style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" >
                                    
                                </asp:DropDownList>
                            </td>
                                                      
    <td style="width: 117px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
                                            Tipo Tramite</td>
                            <td>
                                <asp:DropDownList ID="dl_tipo_tramite" runat="server"
                                        Font-Names="Arial" Font-Size="X-Small" Height="16px"
                                        Width="138px" TabIndex="23" 
                                    style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" >
                                    
                                </asp:DropDownList>
                            </td>
                                               
                
                        </tr>
                    
                    </table>
                   
                        <table style="width: 98%">
                        <tr>
                                       <td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
                                           Notaria</td>
                            <td class="style1" style="width: 140px">
                                <asp:DropDownList ID="dl_notaria" runat="server"
                                        Font-Names="Arial" Font-Size="X-Small" Height="16px"
                                        Width="138px" TabIndex="24" 
                                    style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" >
                                   
                                </asp:DropDownList>
                                       </td>
                
                            <td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
                                Terminacion Especial</td>
                            <td style="width: 85px">
                                <asp:TextBox ID="txt_terminacion" runat="server" 
                                    style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" 
                                    MaxLength="10" Width="84px" TabIndex="25"></asp:TextBox>
                            </td>
                                        <td style="width: 31px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
                                            TAG</td>
                            <td style="width: 460px">
                                <asp:DropDownList ID="dl_tag" runat="server"
                                        Font-Names="Arial" Font-Size="X-Small" Height="16px"
                                        Width="138px" TabIndex="26" 
                                    style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" >
                                    
                                </asp:DropDownList>
                            </td>
                                                      

                                               
                
                        </tr>
                    
                    </table>
                    
                    <asp:UpdatePanel ID="up_adquiere" runat="server">
                        <ContentTemplate>
                    
                     <table  bgcolor="#669999" style="width: 100%">
                    <tr>
                    <td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 1115px; color: #FFFFFF;"><b>
                        DATOS DEL ADQUIRIENTE
                        </b></td>
                    </tr>
                    </table>
                    
                    
                    <table style="width: 773px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
                              <tr>
                            <td style="width: 30px; text-align: left; font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 25px;">
                                Rut 
                            <td style="width: 167px; text-align: center; height: 18px;">
                                <asp:TextBox ID="txt_rut"  runat="server" Font-Names="Arial" 
                                        Font-Size="X-Small" MaxLength="8" TabIndex="27" AutoPostBack="True" 
                                    ontextchanged="txt_rut_Leave" BackColor="#0099FF" ForeColor="White" 
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
                                <asp:Button ID="bt_limpia_persona" runat="server" BackColor="White" 
                                    Height="16px" Width="16px" onclick="bt_limpia_persona_Click" />
                                                         
                                                         
                            </td>
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
                                onclick="ib_adquiriente_Click" />
                        </td>
                        
                        <td style="width: 89px" align="center">
                            <asp:CheckBox ID="chk_compra_para" runat="server" AutoPostBack="True" 
                                style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; font-weight: 700; color: #FF0000;" 
                                Text="Compra Para" TabIndex="39" 
                                oncheckedchanged="chk_compra_para_CheckedChanged" />
                        </td>
                        
                       </tr>
                        
                    </table>
                    </ContentTemplate>
                    </asp:UpdatePanel>
                    
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                    
                     <asp:Panel id="Panel1" runat="server" Visible=false
                        >

                     
                     
                     
                     <table  bgcolor="#669999" style="width: 100%">
                    <tr>
                    <td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 1115px; color: #FFFFFF;">
                        <b>
                        ADQUIRIENTE COMPRA PARA</b>
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
                                <asp:Button ID="bt_limpia_para" runat="server" BackColor="White" 
                                    Height="16px" Width="16px" onclick="bt_limpia_para_Click" />
                                                         
                                                         
                            </td>
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
                            ImageUrl="../imagenes/sistema/static/persona.png" Height="22px" Width="23px" />
                        </td>
                            
                        </tr>
                    </table>
               
               </asp:Panel>
               
               </ContentTemplate>
                        </asp:UpdatePanel>

                    
                     <table  bgcolor="white" style="width: 100%" >
                    <tr>
                    <td style="text-align: center; width: 38px;">
                        <asp:Button ID="bt_guardar" runat="server" Font-Names="Arial" Font-Size="X-Small" 
                            Text="Guardar" TabIndex="53" onclick="bt_guardar_Click" />
                    </td>
                    <td style="width: 42px">
                        <asp:Button ID="Button2" runat="server" Font-Names="Arial" Font-Size="X-Small" 
                            Text="Limpiar" TabIndex="54" onclick="Button2_Click" />
                        </td>
                    <td style="width: 42px">
                        <asp:Button ID="bt_caratula" runat="server" Font-Names="Arial" Font-Size="X-Small" 
                            Text="Caratula" TabIndex="54"  Visible="False" 
                            onclick="bt_caratula_Click" />
                        </td>
                         
                    <td style="text-align: right">
                        <asp:Label ID="lbl_operacion" runat="server" Font-Names="Arial" 
                            Font-Size="Small" ForeColor="#FF3300" Visible="False"></asp:Label>
                        <asp:Label ID="lbl_numero" runat="server" Font-Names="Arial" 
                            Font-Size="Small" ForeColor="#FF3300" Visible="False"></asp:Label>
                    </td>
                    
                    </tr>
                    </table>
                    
                        <br/>
     </td>
                    </tr>
                    </table>

                </td>
            </tr>
        </table>
        
       
       
        <asp:Panel ID="pnlSeleccionarDatos"  runat="server" 
            style="border-width:1px; border-style:solid; 
                    background-color:#FFFFFF; position:inherit ; width: 300px; Height:80px" 
            Height="64px" Width="296px">
                    <center style="background-color: #0066CC">
                    <asp:Label ID="Label4" ForeColor="Blue" Font-Names="Arial, Helvetica, sans-serif" 
                            runat="server" Text="¿Esta seguro de ingresar esta operación?" 
                            Font-Size="Small" style="color: #FFFFFF; font-weight: 700" />                
                    </center>
                    <table style=" width:292px; height:60px"  >
                    <tr>
                    
                    <td align="center" style="background-color: #FFFFFF">
                    <asp:Button ID="btnAceptar" runat="server" Font-Names="Arial" 
                            Font-Size="X-Small"  Text="Aceptar" onclick="btnAceptar_Click" />
                    </td>
                    <td align="center" style="background-color: #FFFFFF">
                    <asp:Button ID="btnCancelar" runat="server" Font-Names="Arial" 
                            Font-Size="X-Small" Text="Cancelar" onclick="btnCancelar_Click" />
                     </td>
                     </tr>       
                    </table>                        
                            
                
            </asp:Panel>
            
             <cc1:ModalPopupExtender ID="mpeSeleccion" runat="server" TargetControlID="bt_guardar"
                PopupControlID="pnlSeleccionarDatos"  CancelControlID="btnCancelar"
                DropShadow="True"
                BackgroundCssClass="FondoAplicacion" />
                             
            
             </asp:Content>
