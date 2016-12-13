<%@ Page Title="Control y Gestion" Language="C#" MasterPageFile="~/Adm.Master" AutoEventWireup="true" CodeBehind="mGestionControl.aspx.cs" Inherits="sistemaAGP.mGestionControl" EnableSessionState="True" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<%@ Register Src="~/controles/wucPersona.ascx" TagName="DatosPersona" TagPrefix="agp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <style type="text/css">
        .style5
        {
            height: 26px;
        }
        .style9
        {
            width: 99px;
            height: 8px;
        }
        .style10
        {
            width: 39px;
            height: 15px;
        }
        .style12
        {
            height: 15px;
        }
        .style14
        {
            width: 73px;
            height: 8px;
        }
        .style17
        {
            height: 10px;
            text-align: left;
        }
        .style18
        {
            height: 15px;
            width: 118px;
        }
        .style19
        {
            height: 10px;
            width: 118px;
        }
        .style25
        {
            height: 25px;
            width: 111px;
        }
        .style26
        {
            width: 61px;
            height: 26px;
        }
        .style27
        {
            width: 33px;
        }
        .style28
        {
            width: 43px;
        }
        .style29
        {
            height: 15px;
            width: 7px;
        }
        .style30
        {
            text-align: left;
        }
        .style31
        {
            width: 1115px;
            height: 16px;
        }
        .style32
        {
            height: 16px;
        }
        </style>
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
       
            <table  bgcolor="#cccccc" style="width: 100%; height: 13px;">
                <tr>
                    <td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 1115px; color: #000000;">
                        <b>INGRESO OPERACION DE SEGUIMIENTO</b></td>
                </tr>
            </table>
            <table  bgcolor="#669999" style="width: 100%; height: 20px;">
                <tr>
                    <td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 1115px; color: #FFFFFF;">
                        <b>DATOS DEUDOR</b></td>
                </tr>
            </table>
            <table style="width: 20%">
                <tr>
                    <td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;" 
                        class="style29">
                            RUT</td>
                    <td class="style12">
                        <asp:TextBox ID="txt_rut_deudor"  runat="server" Font-Names="Arial" 
                                    Font-Size="X-Small" MaxLength="8" TabIndex="1" AutoPostBack="True" 
                                ontextchanged="txt_rut_deudor_Leave" BackColor="#0099FF" ForeColor="White" 
                                style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" 
                                Height="16px" Width="98px" 
                                                     ></asp:TextBox>
                    </td>
                     <td style="width: 15px; text-align: right; font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 25px;">
                            Dv</td>
                    <td style="text-align: left; " class="style25">
                        <asp:TextBox ID="txt_dv" runat="server" Font-Names="Arial" 
                                    Font-Size="X-Small" MaxLength="1" Width="16px" TabIndex="28" 
                                Height="16px" Enabled="False" 
                                style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"></asp:TextBox>
                    </td>
                    
                    
                    </tr>
                    </table>
                     <table style="width: 60%">
                    <tr>
                    <td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;" 
                        class="style10">
                            Nombre </td>
                    <td class="style18">
                        <asp:TextBox ID="txt_nombre_deudor" runat="server" 
                                style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" 
                                Height="19px" Width="140px" TabIndex="2"></asp:TextBox>
                        
                                    </td>
                    <td style="width: 15px; text-align: right; font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 25px;">
                             Apellido Paterno</td>
                    <td style="text-align: left; width: 147px; height: 25px;">
                        <asp:TextBox ID="txt_paterno" runat="server" Font-Names="Arial" 
                                    Font-Size="X-Small" MaxLength="10" Width="140px" TabIndex="3" 
                                Height="18px" 
                                style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"></asp:TextBox>
                    </td>
                    <td style="width: 15px; text-align: right; font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 25px;">
                             Apellido Materno</td>
                    <td style="text-align: left; " class="style25">
                        <asp:TextBox ID="txt_materno" runat="server" Font-Names="Arial" 
                                    Font-Size="X-Small" MaxLength="30" Width="141px" TabIndex="4" 
                                Height="18px" 
                                style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"></asp:TextBox>
                    </td>
                    
                    
                    </tr>
                    </table>
                     <table style="width: 16%">
                    <tr>
                    <td align="center" class="style27">
                        <asp:ImageButton ID="ib_direccion" runat="server" 
                        ImageUrl="../imagenes/sistema/static/direccion.jpg" Height="22px" Width="23px" 
                            onclick="ib_direccion_Click" Enabled="False" />
                    </td>
                    <td align="center" class="style28">
                        <asp:ImageButton ID="ib_telefono" runat="server" 
                        ImageUrl="../imagenes/sistema/static/telefono.jpg" Height="23px" Width="27px" 
                            onclick="ib_telefono_Click" Enabled="False" />
                    </td>
                   <td style="width: 32px" align="center">
                        <asp:ImageButton ID="ib_correo" runat="server" 
                        ImageUrl="../imagenes/sistema/static/mail.jpg" Height="22px" Width="23px" 
                            onclick="ib_correo_Click" Enabled="False" />
                    </td>
						<td>
							<asp:CheckBox ID="chk_vendedor" runat="server" Text="Vendedor" ForeColor="Red" AutoPostBack="True"
								OnCheckedChanged="chk_vendedor_CheckedChanged" />
						</td>
                </tr>
                </table>
				<agp:datospersona id="Datosvendedor" runat="server" 
				titulo="DATOS DEL VENDEDOR" habilitarcomprapara="false" Visible="False" />
                 <table  bgcolor="#669999" style="width: 100%; height: 14px;">
                <tr>
                    <td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #FFFFFF;" 
                        class="style31">
                        <b>DATOS NEGOCIO</b></td>
                </tr>
            </table>
                <table>
                <tr>
                <td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
                                       Sucursal Origen</td>
                    <td>
                        <asp:DropDownList ID="dl_sucursal_origen" runat="server"
                                    Font-Names="Arial" Font-Size="X-Small" Height="16px"
                                    Width="138px" TabIndex="5" 
                                style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" 
                            onselectedindexchanged="dl_sucursal_origen_SelectedIndexChanged" >
                        </asp:DropDownList>
                    </td>
                 <td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;" 
                        class="style14">
                                       Producto Cliente</td>
                                        <td class="style9">
                        <asp:DropDownList ID="dl_producto_Cliente" runat="server"
                                    Font-Names="Arial" Font-Size="X-Small" Height="16px"
                                    Width="138px" TabIndex="6" 
                                style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" 
                            onselectedindexchanged="dl_producto_cliente_SelectedIndexChanged" >
                        </asp:DropDownList>
                    </td>
                    
                    <td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;" 
                        class="style14">
                                       Forma de Pago</td>
                                        <td class="style9">
                        <asp:DropDownList ID="dl_forma_pago" runat="server"
                                    Font-Names="Arial" Font-Size="X-Small" Height="16px"
                                    Width="138px" TabIndex="6" 
                                style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" 
                            onselectedindexchanged="dl_forma_pago_SelectedIndexChanged" >
                        </asp:DropDownList>
                    </td>
                </tr>
                   </table>
                <table>
                  <tr>
                    <td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;" 
                          class="style30">
                            Fecha Otorgamiento</td>
                    <td>
                        <asp:TextBox ID="txt_fecha_gestion" runat="server" 
                                style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" 
                                Height="19px" Width="73px" TabIndex="7"></asp:TextBox>
                        <cc1:CalendarExtender    runat="server"
                                    TargetControlID="txt_fecha_Gestion"
                                    CssClass="calendario"
                                    Format="dd/MM/yyyy"
                                    PopupButtonID="ib_calendario" ID="CalendarExtender2" />
                                    </td>
                    <td>
                        <asp:ImageButton ID="ib_calendario" runat="server" 
                                   ImageUrl="../imagenes/sistema/gif/calendario.gif" 
                            onclick="ib_calendario_Click" />
                    </td>
                    <td style="width: 37px; text-align: right; font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 10px;">
                             Monto Credito</td>
                    <td style="text-align: left; " class="style19">
                        <asp:TextBox ID="txt_total" runat="server" Font-Names="Arial" 
                                    Font-Size="X-Small" MaxLength="10" Width="88px" TabIndex="8" 
                                Height="16px" 
                                style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" 
							AutoPostBack="True" ontextchanged="txt_total_TextChanged" ></asp:TextBox>
                    </td>
                    <td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; " 
                          class="style17">
                            Nº Cuotas</td>
                    <td style="text-align: left; width: 20px; height: 10px;">
                        <asp:TextBox ID="txt_ncuotas" runat="server" Font-Names="Arial" 
                                    Font-Size="X-Small" MaxLength="10" Width="88px" TabIndex="9" 
                                Height="16px" 
                                style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" ></asp:TextBox>
                    </td>
                    <td style="width: 37px; font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 10px;" 
                          class="style30">
                             Nº Operacion </td>
                    <td style="text-align: left; height: 10px;">
                        <asp:TextBox ID="txt_noperacion" runat="server" Font-Names="Arial" 
                                    Font-Size="X-Small" MaxLength="10" Width="88px" TabIndex="10" 
                                Height="16px" 
                                style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" ></asp:TextBox>
                    </td>
					<tr>
						<td style="width: 45px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
							Patente
						</td>
						<td style="width: 76px;">
							<asp:TextBox ID="txt_patente" runat="server" Width="76px" Style="font-family: Arial, Helvetica, sans-serif;
								font-size: x-small; background-color: #0099ff; color: #ffffff;" MaxLength="6"
								TabIndex="1" OnTextChanged="txt_patente_TextChanged" AutoPostBack="true"></asp:TextBox>
						</td>
						<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 10px;
							padding: 0 2px 0 2px; text-align: center;">
							<strong>-</strong>
						</td>
						<td style="width: 20px;">
							<asp:TextBox ID="TextBox1" runat="server" TabIndex="2" MaxLength="1" Enabled="False"
								Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 20px;
								height: 16px;"></asp:TextBox>
						</td>
						<td style="width: 37px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;
							height: 10px;" class="style30">
							Monto final
						</td>
						<td style="text-align: left; height: 10px;">
							<asp:TextBox ID="txt_monto_final" runat="server" Font-Names="Arial" Font-Size="X-Small"
								MaxLength="12" Width="88px" TabIndex="10" Height="16px" Style="font-family: Arial, Helvetica, sans-serif;
								font-size: x-small"></asp:TextBox>
						</td>
					</tr>
                    
                </tr>
              </table>
                  <table>
            <tr>
           <td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;" 
                        class="style26">
                             Observacion</td>
                    <td style="text-align: left; " class="style5">
                        <asp:TextBox ID="txt_observacion" runat="server" Font-Names="Arial" 
                                    Font-Size="X-Small" MaxLength="1000" Width="331px" TabIndex="11" 
                                Height="54px" 
                                style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" 
                            TextMode="MultiLine" ontextchanged="TextBox1_TextChanged1"></asp:TextBox>
                    </td>
            </tr>
            </table>
          
         
            
            <table  bgcolor="#669999" style="width: 100%">
                <tr>
                    <td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #FFFFFF;" 
                        class="style32">
                        <b>&nbsp;REFERENCIA</b></td>
                </tr>
            </table>
           
            <table style="width: 189px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
            
                  <tr>    
                    <td>
               <asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" 
                        CellPadding="0" Font-Names="Arial" Font-Size="X-Small" ForeColor="#333333" 
                        GridLines="None" OnRowEditing="gr_dato_RowEditing" 
                        onrowdatabound="gr_dato_RowDataBound" DataKeyNames="referencia" 
                    onselectedindexchanged="gr_dato_SelectedIndexChanged"
                    onrowdeleting="gr_dato_RowDeleting" Height="100px" ShowHeader="False">
                          <RowStyle BackColor="#EFF3FB" />
                    <Columns>
                       
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:TextBox ID="txt_referencia" runat="server" AutoCompleteType="Disabled" 
                                    AutoPostBack="false" Font-Size="9pt" Height="20px" MaxLength="500" 
                                    OnTextChanged="txt_referencia_Leave" Text='<%# Bind("referencia") %>' 
                                    Width="200px" EnableViewState="true"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>

                        
                        <asp:CommandField DeleteText="X"  ShowDeleteButton="True"  >

                        
                        <ControlStyle Font-Names="Arial" Font-Size="Large" />
                        </asp:CommandField>

                        
                    </Columns>
                </asp:GridView>
                </td>
                            </tr>  
                            <tr>
                               <td style="text-align: center">
                <asp:ImageButton ID="ib_mas" runat="server" 
                        ImageUrl="../imagenes/sistema/static/mas.jpg" Height="22px" Width="23px" 
                            onclick="ib_mas_Click" style="text-align: center" />
                            </td>
                            
                            </tr>
            </table>
        
            <table  bgcolor="cccccc" style="width: 100%" >
                <tr>
                     <td style="text-align: center; width: 38px;">
                        <asp:Button ID="bt_guardar" runat="server" Font-Names="Arial" Font-Size="X-Small" 
                            Text="Guardar" TabIndex="53" onclick="bt_guardar_Click" />
                    </td>
                    <td style="width: 42px">
                        <asp:Button ID="Button2" runat="server" Font-Names="Arial" Font-Size="X-Small" 
                            Text="Nuevo" TabIndex="54" onclick="Button2_Click" />
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

