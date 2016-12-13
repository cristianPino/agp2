<%@ Page Title="Administrador de Personas" Language="C#" MasterPageFile="~/Adm.Master" AutoEventWireup="true" CodeBehind="mPersonaModal.aspx.cs" Inherits="sistemaAGP.mPersonaModal"  %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 395px;
        }
        .style2
        {
            width: 271px;
        }
        .style3
        {
            height: 23px;
            width: 317px;
        }
        .style4
        {
            width: 317px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" style="width: 821px; height: 316px">
        <tr>
            <td style="border-style: none; border-color: inherit; border-width: 0; text-align: left; width: 1057px; height: 277px;" align="left" 
                    valign="top">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Arial" 
                        Font-Size="X-Small" Text="Administracion de Personas"></asp:Label>
                
                <table>
                <tr>
                <td style="background-color:#E5E5E5">
                
                <table style="width: 35%; font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 20px;" 
                                        bgcolor="#E5E5E5">
                    <tr>
                        <td style="width: 56px; text-align: left;">
                            Rut 
                        <td style="width: 97px; text-align: left">
                            <asp:TextBox ID="txt_rut"  runat="server" Font-Names="Arial" 
                                    Font-Size="X-Small" MaxLength="8" TabIndex="1" AutoPostBack="True" 
                                ontextchanged="txt_rut_Leave" BackColor="#0099FF" ForeColor="White" 
                                                     ></asp:TextBox>
                            <cc1:FilteredTextBoxExtender ID="txt_rut_FilteredTextBoxExtender" 
                        runat="server" TargetControlID="txt_rut"
                        FilterType="Custom, Numbers"
                        ValidChars="">
                            </cc1:FilteredTextBoxExtender>
                        </td>
                        <td style="width: 15px; text-align: right">
                            Dv</td>
                        <td style="text-align: left; ">
                            <asp:TextBox ID="txt_dv" runat="server" Font-Names="Arial" 
                                    Font-Size="X-Small" MaxLength="1" Width="16px" TabIndex="100" 
                                Height="16px" Enabled="False"></asp:TextBox>
                        </td>
                        <td style="width: 15px; text-align: right">
                            Nº Serie</td>
                        <td style="text-align: left; " class="style1">
                            <asp:TextBox ID="txt_serie" runat="server" Font-Names="Arial" 
                                    Font-Size="X-Small" MaxLength="10" Width="88px" TabIndex="2" 
                                Height="16px" ontextchanged="txt_serie_TextChanged"></asp:TextBox>
                        </td>
                        
                        </tr>
                        </table>
                        
                        <table style="width: 81%; font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 20px;" 
                                        bgcolor="#E5E5E5">
                        <tr>    
                        
                        <td style="width: 15px; text-align: right">
                             Nombre</td>
                        <td style="text-align: left; " class="style2">
                            <asp:TextBox ID="txt_nombre" runat="server" Font-Names="Arial" 
                                    Font-Size="X-Small" MaxLength="200" Width="253px" TabIndex="3" 
                                Height="16px" ontextchanged="txt_serie_TextChanged"></asp:TextBox>
                        </td>
                        <td style="width: 15px; text-align: right">
                             Apellido Paterno</td>
                        <td style="text-align: left; ">
                            <asp:TextBox ID="txt_paterno" runat="server" Font-Names="Arial" 
                                    Font-Size="X-Small" MaxLength="200" Width="164px" TabIndex="4" 
                                Height="16px" ontextchanged="txt_serie_TextChanged"></asp:TextBox>
                        </td>
                        <td style="width: 15px; text-align: right">
                             Apellido Materno</td>
                        <td style="text-align: left; width: 88px;">
                            <asp:TextBox ID="txt_materno" runat="server" Font-Names="Arial" 
                                    Font-Size="X-Small" MaxLength="100" Width="164px" TabIndex="5" 
                                Height="17px" ontextchanged="txt_serie_TextChanged"></asp:TextBox>
                        </td>
                    </tr>
                    </table>
                    <table style="width: 81%; font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 20px;" 
                                        bgcolor="#E5E5E5">
                    <tr>
                        <td style="width: 56px; text-align: left;">
                            Sexo 
                        <td style="width: 97px; text-align: left">
                            <asp:DropDownList ID="dl_sexo" runat="server" Font-Names="Arial" 
                                Font-Size="X-Small" TabIndex="6">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 15px; text-align: right">
                            &nbsp;</td>
                        <td style="text-align: left; ">
                            &nbsp;</td>
                        <td style="width: 15px; text-align: right">
                            Tipo Persona</td>
                        <td style="text-align: left; ">
                            <asp:DropDownList ID="dl_tipo_persona" runat="server" Font-Names="Arial" 
                                Font-Size="X-Small" TabIndex="7">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 15px; text-align: right">
                             Nacionalidad</td>
                        <td style="text-align: left; ">
                            <asp:TextBox ID="txt_nacionalidad" runat="server" Font-Names="Arial" 
                                    Font-Size="X-Small" MaxLength="30" Width="88px" TabIndex="8" 
                                Height="16px" ontextchanged="txt_serie_TextChanged"></asp:TextBox>
                        </td>
                        <td style="width: 15px; text-align: right">
                             Profesion</td>
                        <td style="text-align: left; ">
                            <asp:TextBox ID="txt_profesion" runat="server" Font-Names="Arial" 
                                    Font-Size="X-Small" MaxLength="50" Width="133px" TabIndex="9" 
                                Height="16px" ontextchanged="txt_serie_TextChanged"></asp:TextBox>
                        </td>
                        <td style="width: 15px; text-align: right">
                             Estado Civil 
                        </td>
                        <td style="text-align: left; width: 88px;">
                            <asp:DropDownList ID="dl_estado_civil" runat="server" Font-Names="Arial" 
                                Font-Size="X-Small" TabIndex="10">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 56px; text-align: left;">
                            Tipo Empleador<td style="width: 97px; text-align: left">
                            <asp:DropDownList ID="dl_tipo_empleador" runat="server" Font-Names="Arial" 
                                         Font-Size="X-Small" TabIndex="11">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 15px; text-align: right">
                            &nbsp;</td>
                        <td style="text-align: left; ">
                            &nbsp;</td>
                        <td style="width: 15px; text-align: right">
                            Telefono</td>
                        <td style="text-align: left; ">
                            <asp:TextBox ID="txt_telefono" runat="server" Font-Names="Arial" 
                                    Font-Size="X-Small" MaxLength="10" Width="88px" TabIndex="12" 
                                Height="16px" ontextchanged="txt_serie_TextChanged"></asp:TextBox>
                        </td>
                        <td style="width: 15px; text-align: right">
                             Celular</td>
                        <td style="text-align: left; ">
                            <asp:TextBox ID="txt_celular" runat="server" Font-Names="Arial" 
                                    Font-Size="X-Small" MaxLength="10" Width="88px" TabIndex="13" 
                                Height="16px" ontextchanged="txt_serie_TextChanged"></asp:TextBox>
                        </td>
                        <td style="width: 15px; text-align: right">
                             Correo</td>
                        <td style="text-align: left; ">
                            <asp:TextBox ID="txt_correo" runat="server" Font-Names="Arial" 
                                    Font-Size="X-Small" MaxLength="50" Width="138px" TabIndex="14" 
                                Height="20px" ontextchanged="txt_serie_TextChanged"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 56px; text-align: left;">
                            Direccion<td style="width: 97px; text-align: left">
                            <asp:TextBox ID="txt_direccion" runat="server" Font-Names="Arial" 
                                    Font-Size="X-Small" MaxLength="100" Width="102px" TabIndex="15" 
                                Height="16px" ontextchanged="txt_serie_TextChanged"></asp:TextBox>
                        </td>
                        <td style="width: 15px; text-align: right">
                            &nbsp;</td>
                        <td style="text-align: left; ">
                            &nbsp;</td>
                        <td style="width: 15px; text-align: right">
                            Numero</td>
                        <td style="text-align: left; ">
                            <asp:TextBox ID="txt_numero" runat="server" Font-Names="Arial" 
                                    Font-Size="X-Small" MaxLength="10" Width="88px" TabIndex="16" 
                                Height="16px" ontextchanged="txt_serie_TextChanged"></asp:TextBox>
                        </td>
                        <td style="width: 15px; text-align: right">
                             Depto</td>
                        <td style="text-align: left; ">
                            <asp:TextBox ID="txt_depto" runat="server" Font-Names="Arial" 
                                    Font-Size="X-Small" MaxLength="10" Width="88px" TabIndex="17" 
                                Height="16px" ontextchanged="txt_serie_TextChanged"></asp:TextBox>
                        </td>
                        <td style="width: 15px; text-align: right">
                            &nbsp;</td>
                        <td style="text-align: left; ">
                            &nbsp;</td>
                        <td style="width: 15px; text-align: right">
                            &nbsp;</td>
                        <td style="text-align: left; width: 88px;">
                            &nbsp;</td>
                    </tr>
                </table>
                <table style="width: 61%; font-family: Arial, Helvetica, sans-serif; font-size: x-small" 
                                        bgcolor="#E5E5E5">
                    <tr>
                        <td style="width: 56px; height: 23px;">
                            Pais<td style="width: 126px; text-align: left; height: 23px;">
                            <asp:DropDownList ID="dl_pais" runat="server" AutoPostBack="True" 
                                    Font-Names="Arial" Font-Size="X-Small" Height="16px" 
                                    onselectedindexchanged="dl_pais_SelectedIndexChanged" Width="138px" 
                                TabIndex="18">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 15px; text-align: right; height: 23px;">
                            Region
                        </td>
                        <td style="text-align: left; " class="style3">
                            <asp:DropDownList ID="dl_region" runat="server" AutoPostBack="True" 
                                    Font-Names="Arial" Font-Size="X-Small" Height="19px" 
                                    onselectedindexchanged="dl_region_SelectedIndexChanged" Width="213px" 
                                TabIndex="19">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 15px; ">
                             Ciudad</td>
                        <td style="text-align: left; ">
                            <asp:DropDownList ID="dl_ciudad" runat="server" AutoPostBack="True" 
                                    Font-Names="Arial" Font-Size="X-Small" Height="19px" 
                                     Width="173px" onselectedindexchanged="dl_ciudad_SelectedIndexChanged" 
                                TabIndex="20">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 15px; text-align: right">
                            Comuna</td>
                        <td style="text-align: left; " class="style4">
                            <asp:DropDownList ID="dl_comuna" runat="server" 
                                    Font-Names="Arial" Font-Size="X-Small" Height="19px" 
                                     Width="213px" 
                                TabIndex="21">
                            </asp:DropDownList>
                        </td>
                        
                         <td style="width: 32px" align="center">
                        <asp:ImageButton ID="ib_comuna" runat="server" 
                        ImageUrl="../imagenes/sistema/static/HERRAMIENTA.png" Height="22px" Width="23px" 
                           onclick="ib_comuna_Click"  Visible="False" />
                    </td>
                        
                    </tr>
                </table>
                </td>
                </tr>
                </table>
                
                <br />
                <asp:Button ID="Button1" runat="server" Font-Names="Arial" Font-Size="X-Small" 
                        Text="Guardar" onclick="Button1_Click" TabIndex="22" />
              
                             <cc1:ConfirmButtonExtender ID="Button1_ConfirmButtonExtender" 
                    runat="server" TargetControlID="Button1" ConfirmText="¿Esta seguro de ingresar a una nueva persona?">
                </cc1:ConfirmButtonExtender>
                    </asp:ConfirmButtonExtender> 
                        
                &nbsp;<asp:Button ID="Button2" runat="server" Font-Names="Arial" 
                        Font-Size="X-Small" onclick="Button2_Click" Text="Limpiar" 
                    TabIndex="23" />
                <br />
                <br />
                <asp:ImageButton ID="ib_personeria" runat="server" 
                    ImageUrl="../imagenes/icono001.gif" 
                    TabIndex="24" onclick="ib_personeria_Click" />
                    
                    
                     <asp:Panel ID="pnlSeleccionarDatos" runat="server" CssClass="CajaDialogo" Style="display: none;">
            <div style="padding: 3px; background-color:#0099FF; color: #FFFFFF;">
                <asp:Label ID="Label4" Font-Names="Arial, Helvetica, sans-serif" runat="server" Text="REPRESENTANTES" Font-Size="X-Small" />
            </div>
            <div>
               <table  style="width: 81%; font-family: Arial, Helvetica, sans-serif; font-size: x-small" 
                                        bgcolor="#E5E5E5">
                    <tr>
                        <td>
                            <asp:Label ID="Label5" runat="server" Text="Rut:" />
                        </td>
                        <td style="text-align: left; ">
                            <asp:TextBox ID="txt_rut_rep1" runat="server" Font-Names="Arial" 
                                    Font-Size="X-Small" MaxLength="10" Width="88px" TabIndex="16" 
                                Height="16px" ></asp:TextBox>
                         <cc1:FilteredTextBoxExtender ID="txt_rut_rep1_FilteredTextBoxExtender" 
                        runat="server" TargetControlID="txt_rut_rep1"
                        FilterType="Custom, Numbers"
                        ValidChars="">
                        
                    </cc1:FilteredTextBoxExtender>
                                
                        </td>
                    
                        <td style="text-align: left; ">
                            <asp:TextBox ID="txt_dv_rep1" runat="server" Font-Names="Arial" 
                                    Font-Size="X-Small" MaxLength="1" Width="10px" TabIndex="16" 
                                Height="16px" ></asp:TextBox>
                        </td>
                        
                                                <td>
                            <asp:Label ID="Label2" runat="server" Text="Nombre:" />
                        </td>
                        <td style="text-align: left; ">
                            <asp:TextBox ID="txt_nombre_rep1" runat="server" Font-Names="Arial" 
                                    Font-Size="X-Small" MaxLength="70" Width="150px" TabIndex="16" 
                                Height="16px" ></asp:TextBox>
                        </td>

                        
                    </tr>
                    
                     <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text="Rut:" />
                        </td>
                        <td style="text-align: left; ">
                            <asp:TextBox ID="txt_rut_rep2" runat="server" Font-Names="Arial" 
                                    Font-Size="X-Small" MaxLength="10" Width="88px" TabIndex="16" 
                                Height="16px" ></asp:TextBox>
                                
                                <cc1:FilteredTextBoxExtender ID="txt_rut_rep2_FilteredTextBoxExtender1" 
                        runat="server" TargetControlID="txt_rut_rep2"
                        FilterType="Custom, Numbers"
                        ValidChars="">
                        
                    </cc1:FilteredTextBoxExtender>
                                
                        </td>
                    
                        <td style="text-align: left; ">
                            <asp:TextBox ID="txt_dv_rep2" runat="server" Font-Names="Arial" 
                                    Font-Size="X-Small" MaxLength="1" Width="10px" TabIndex="16" 
                                Height="16px" ></asp:TextBox>
                        </td>
                        
                                                <td>
                            <asp:Label ID="Label6" runat="server" Text="Nombre:" />
                        </td>
                        <td style="text-align: left; ">
                            <asp:TextBox ID="txt_nombre_rep2" runat="server" Font-Names="Arial" 
                                    Font-Size="X-Small" MaxLength="70" Width="150px" TabIndex="16" 
                                Height="16px" ></asp:TextBox>
                        </td>

                        
                    </tr>
                    
                    <tr>
                        <td>
                            <asp:Label ID="Label7" runat="server" Text="F.Personeria:" />
                        </td>
                        <td style="text-align: left; ">
                            <asp:TextBox ID="txt_fecha" runat="server" Font-Names="Arial" 
                                    Font-Size="X-Small" MaxLength="10" Width="88px" TabIndex="16" 
                                Height="16px" ></asp:TextBox>
                        </td>
                      <td>
                            <asp:Label ID="Label9" runat="server" Text="Notaria:" />
                        </td>
                    
                        <td style="text-align: left; ">
                            <asp:TextBox ID="txt_notaria" runat="server" Font-Names="Arial" 
                                    Font-Size="X-Small" MaxLength="100" Width="88px" TabIndex="16" 
                                Height="16px" ></asp:TextBox>
                        </td>
                        
                                                <td>
                            <asp:Label ID="Label8" runat="server" Text="Ciudad:" />
                        </td>
                        <td style="text-align: left; ">
                            <asp:TextBox ID="txt_ciudad" runat="server" Font-Names="Arial" 
                                    Font-Size="X-Small" MaxLength="100" Width="88px" TabIndex="16" 
                                Height="16px" ></asp:TextBox>
                        </td>

                        
                    </tr>
                        
                </table>
            </div>
            <div>
                <asp:Button ID="btnAceptar" runat="server" Font-Names="Arial" 
                        Font-Size="X-Small" onclick="btnAceptar_Click" Text="Guardar" />
                
                <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender2" 
                    runat="server" TargetControlID="btnAceptar" ConfirmText="¿Esta seguro de ingresar representantes?">
                </cc1:ConfirmButtonExtender>
                    </asp:ConfirmButtonExtender> 

                
                &nbsp;&nbsp;
                <asp:Button ID="btnCancelar" runat="server" Font-Names="Arial" 
                        Font-Size="X-Small" Text="Cancelar" />
            </div>
        </asp:Panel>
                    
                    
                    
                <cc1:ModalPopupExtender ID="mpeSeleccion" runat="server" TargetControlID="ib_personeria"
            PopupControlID="pnlSeleccionarDatos"  CancelControlID="btnCancelar"
            DropShadow="True"
            BackgroundCssClass="FondoAplicacion" />
                <asp:ImageButton ID="ib_ficha" 
                    ImageUrl="../imagenes/sistema/gif/impresora.gif"  runat="server" Height="36px"
                    
                    Width="43px"   />
            </td>
        </tr>
    </table>
</asp:Content>
