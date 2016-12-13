<%@ Page Language="C#" MasterPageFile="~/AGP.Master" AutoEventWireup="true" CodeBehind="mPersona.aspx.cs" Inherits="sistemaAGP.mPersona" Title="Administracion de Personas" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMenu" runat="server">
	<script type="text/javascript" src="../jquery-1.7.2.min.js"></script>
	<script type="text/javascript" src="../jquery.mousewheel-3.0.6.pack.js"></script>
	<script type="text/javascript" src="../jquery.fancybox.js?v=2.0.6"></script>
	<link rel="Stylesheet" type="text/css" href="../jquery.fancybox.css?v=2.0.6" media="screen" />
	<script type="text/javascript">
		$(document).ready(function () {
			$('.fancybox').fancybox({
				maxWidth: 640,
				maxHeight: 480,
				minWidth: 640,
				minHeight: 480,
				fitToView: false,
				width: 640,
				height: 480,
				autoSize: true,
				openEffect: 'elastic',
				openSpeed: 150,
				closeEffect: 'elastic',
				closeSpeed: 150,
				closeClick: false,
				closeBtn: true,
				scrolling: 'no',
				padding: 0,
				helpers: {
					overlay: {
						opacity: 0.5,
						css: {
							'background-color': 'Gray'
						},
						title: {
							type: 'float'
						}
					}
				}
			});
		});
	</script>
	<style type="text/css">
		.style6
		{
			width: 84px;
		}
		.style7
		{
			width: 13px;
		}
		.style9
		{
			width: 42px;
		}
		.style10
		{
			width: 18px;
		}
		.style11
		{
			width: 86px;
		}
		.style12
		{
			height: 32px;
			width: 51px;
		}
	</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoCentral" runat="server">

    <table border="0" style="width: 1028px; height: 405px">
        <tr>
            <td style="border-style: none; border-color: inherit; border-width: 0; text-align: left; width: 1057px; height: 277px;" align="left" 
                    valign="top">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Arial" 
                        Font-Size="X-Small" Text="Administracion de Personas"></asp:Label>
                <table style="width: 81%; font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 20px;" 
                                        bgcolor="#E5E5E5">
                    <tr>
                        <td style="text-align: left;" class="style10">
                            Rut 
                        <td style="text-align: left" class="style9">
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
                        <td style="text-align: left; " class="style11">
                            <asp:TextBox ID="txt_dv" runat="server" Font-Names="Arial" 
                                    Font-Size="X-Small" MaxLength="1" Width="16px" TabIndex="100" 
                                Height="16px" Enabled="False"></asp:TextBox>
                        </td>
                        
                        
                    </tr>

					<tr>
						<td style="text-align: right" class="style10">
							Nombre
						</td>
						<td colspan="3" style="text-align: left;">
							<asp:textbox id="txt_nombre" runat="server" font-names="Arial" font-size="X-Small"
								width="267px" tabindex="3" height="16px" ontextchanged="txt_serie_TextChanged"></asp:textbox>
						</td>
						<td style="width: 15px; text-align: right">
							Apellido Paterno
						</td>
						<td style="text-align: left;" class="style7">
							<asp:textbox id="txt_paterno" runat="server" font-names="Arial" font-size="X-Small"
								maxlength="10" width="107px" tabindex="4" height="16px" ontextchanged="txt_serie_TextChanged"></asp:textbox>
						</td>
						<td style="width: 15px; text-align: right">
							Apellido Materno
						</td>
						<td style="text-align: left; width: 88px;">
							<asp:textbox id="txt_materno" runat="server" font-names="Arial" font-size="X-Small"
								maxlength="10" width="88px" tabindex="5" height="16px" ontextchanged="txt_serie_TextChanged">
							</asp:textbox>
						</td>
					</tr>
                    
                         <tr>
                        <td style="text-align: left;" class="style10">
                            Sexo 
                        <td style="text-align: left" class="style9">
                            <asp:DropDownList ID="dl_sexo" runat="server" Font-Names="Arial" 
                                Font-Size="X-Small" TabIndex="6">
                            </asp:DropDownList>
                        </td>
                        
                      
                        
                         <td style="width: 15px; text-align: right">
                             Nacionalidad</td>
                        <td style="text-align: left; " class="style11">
                            <asp:TextBox ID="txt_nacionalidad" runat="server" Font-Names="Arial" 
                                    Font-Size="X-Small" MaxLength="10" Width="88px" TabIndex="8" 
                                Height="16px" ontextchanged="txt_serie_TextChanged"></asp:TextBox>
                        </td>
                         <td style="width: 15px; text-align: right">
                             Profesion</td>
                        <td style="text-align: left; " class="style7">
                            <asp:TextBox ID="txt_profesion" runat="server" Font-Names="Arial" 
                                    Font-Size="X-Small" MaxLength="10" Width="107px" TabIndex="9" 
                                Height="16px" ontextchanged="txt_serie_TextChanged"></asp:TextBox>
                        </td>
                        
                         <td style="width: 15px; text-align: right">
                             Estado Civil </td>
                        <td style="text-align: left; width: 88px;">
                            <asp:DropDownList ID="dl_estado_civil" runat="server" Font-Names="Arial" 
                                Font-Size="X-Small" TabIndex="10">
                            </asp:DropDownList>
                        </td>
                        
                        
                    </tr>
                    
                             
                    <tr>
                      
                         <td style="text-align: right" class="style10">
                             Giro</td>
                        <td colspan="5" style="text-align: left;">
							<asp:textbox id="txt_giro" runat="server" font-names="Arial" font-size="X-Small"
								 width="420px" tabindex="17" height="16px" ontextchanged="txt_giro_TextChanged"></asp:textbox>
                            </td>
                        
                        
                    </tr>
                    
                    
                    
                </table>
                <table style="width: 81%; font-family: Arial, Helvetica, sans-serif; font-size: x-small" 
                                        bgcolor="#E5E5E5">
                  
					<tr>
						<td  style="text-align: center; padding: 0 5px 0 5px; " class="style12">
							<asp:imagebutton id="ib_direccion" runat="server" imageurl="../imagenes/sistema/static/direccion.jpg"
								height="32px" width="32px" onclick="ib_direccion_Click" Visible="False"/>
							
						</td>
						<td style="text-align: right;" class="style6">
							<a id="lnk_popup" runat="server" class="fancybox fancybox.iframe" style="display: none;">
							</a>
							
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
                    TabIndex="24" />
               
            
                
            
            
                <asp:ImageButton ID="ib_ficha" 
                    ImageUrl="../imagenes/sistema/gif/impresora.gif"  runat="server" Height="36px"
                    
                    Width="43px" onclick="ib_ficha_Click"   />
               
            
                
            
            
            </td>
        </tr>
    </table>
    
           
        
       
</asp:Content>
