<%@ Page Title="" Language="C#" MasterPageFile="~/AGP.Master" AutoEventWireup="true" CodeBehind="CotiazadorProduccion.aspx.cs" Inherits="sistemaAGP.preinscripcion.CotiazadorProduccion" %>

<%@ Register TagPrefix="ajaxToolkit" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=3.5.40412.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMenu" runat="server">

    <style type="text/css">
        
        .caja
        {
            width: 995px;
            margin: auto;
            height: 294px;
            background: #2FAACE;
            box-shadow: 10px 10px 3px #D8D8D8;
            transition: height .4s;
            color: #fff;
            font-size: xx-small;
            text-align: center;
            vertical-align:middle;
            border: solid 1px #fff;
            position: relative;
			top: 0px;
			left: 0px;
		}
        .caja table
        {
            margin: 0 auto;
            text-align: left;
        }
        
         .cajaVertical
        {
            width: 40%;
            margin: auto;
            height: 120px;
            background: #2FAACE;
            box-shadow: 10px 10px 3px #D8D8D8;
            transition: background .4s;
            text-align: center;
            color: #fff;
            font-size: xx-small;
            vertical-align:sub;
            border: solid 1px #fff;
           
        }
        .cajaVertical table
        {
            margin: 0 auto;
            text-align: left;
        }
        .style5
        {
            height: 27px;
        }
        .style7
        {
            height: 10px;
        }
        .style8
        {
            font-size: x-small;
        }
    </style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoCentral" runat="server">

<div id="div_titulo">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/imagenes/sistema/static/infoAuto/InfoAutoIcono2.png"
            Height="30px" Width="30px" />
        <asp:Label ID="Label2" runat="server" Text="COTIZADOR " Style="font-size: 18pt; font-weight: bold;"></asp:Label>
    </div>
    <br/>
    <div id="caja" class="caja" align="center">
  <br/>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table>

                 <tr>
                        <td style="vertical-align: middle;">
                        PRODUCTO
                        </td>

						 
                        <td style="vertical-align: middle;">
                           <asp:DropDownList ID="DropDownList1" Visible="true" runat="server" AutoPostBack="True" >
										<asp:ListItem Value="PI">PRIMERA INSCRIPCION VEHICULO COMPLETA</asp:ListItem>
										<asp:ListItem Value="PITAG">PRIMERA INSCRIPCION VEHIC/COMPLETA CON TAG</asp:ListItem>
                                        <asp:ListItem Value="IP">INSCRIPCION Y PATENTE</asp:ListItem>
										
											</asp:DropDownList>
                        </td>
                        </TR>
               
                        <tr>
                        <td style="vertical-align: middle;">
                        CLIENTE
                        </td>

						 
                        <td style="vertical-align: middle; font-size: small; color: #000099;">
                            <asp:DropDownList ID="dl_cliente" runat="server" 
                                OnSelectedIndexChanged="dl_cliente_SelectedIndexChanged" 
                                Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #000000; width: 250px;">
                            </asp:DropDownList>
                            &nbsp;* Campo Obligatorio</td>
                        </TR>
                            <tr>
                                <td>
                                    CODIGO CIT
                                </td>
                                <td style="font-size: large">
                                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    FECHA DE FACTURA
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="calDesde" runat="server" Enabled="True" 
                                        TargetControlID="TextBox1" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    FECHA DE TRAMITACION
                                </td>
                                <td>
                                    <asp:TextBox ID="Tramitacion" runat="server"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" 
                                        Enabled="True" TargetControlID="Tramitacion" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    MONTO NETO FACTURA
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="style5">
                                    VENDEDOR
                                </td>
                                <td class="style5">
                                    <asp:Label ID="id_vendedor" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>

                             <tr>
                                <td>
                                    ADQUIRIENTE
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    CARGAR DATOS A COTIZADOR
                                </td>
                                <td>
                                    <asp:ImageButton ID="ibPedir" runat="server" 
                                        ImageUrl="../imagenes/sistema/static/ok.png" OnClick="ibPedir_Click" 
                                        ToolTip="Crear documento" ValidationGroup="ibCreaBorradorEscritura" />
                                    *(Presionar al modificar datos)
                                </td>
                            </tr>
                            <tr>
                                <td class="style7">
                                    SOLICITAR COTIZACION
                                </td>
                                <td class="style7">
                                    <asp:ImageButton ID="ibPedir0" runat="server" 
                                        ImageUrl="../imagenes/sistema/static/hipotecario/crear_nuevo_doc.png" 
                                        OnClick="ibPedir_Click2" ToolTip="Crear documento" 
                                        ValidationGroup="ibCreaBorradorEscritura" Visible="false" />
                                </td>
                            </tr>

						 
                    </tr>


                </table>
                   </ContentTemplate>
                    </asp:UpdatePanel>
                  </div>   
                <table style="clear:both">
                <tr>
                <td>
                 <asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" 
                        CellPadding="1" Font-Names="Arial" Font-Size="X-Small" ForeColor="#333333" 
                        GridLines="None" class="caja"  Visible="true"
                    onselectedindexchanged="gr_dato_SelectedIndexChanged" 
                        Height="148px">
                    <RowStyle BackColor="#EFF3FB" />
                    <Columns>
                        <asp:BoundField AccessibleHeaderText="id_cotizacion" DataField="id_cotizacion" 
                            HeaderText="COTIZACION" />
                        <asp:BoundField AccessibleHeaderText="nombre" DataField="nombre" 
                            HeaderText="MARCA" />
                        
                        <asp:BoundField AccessibleHeaderText="modelo" DataField="modelo" 
                            HeaderText="MODELO" />
                        
                        <asp:BoundField AccessibleHeaderText="monto" DataField="monto" 
                            HeaderText="MONTO" />
                        
                          <asp:BoundField AccessibleHeaderText="fechafac" DataField="fechafac" 
                            HeaderText="fecha factura" />

                      
                    </Columns>
                  
                    
                </asp:GridView>
                </td>
                </tr>
                </table>
       
    
   
    <br />
    <br />

    


    <div class="caja" style="display:none; height: 110px" >
    <br style="visibility: hidden"/>
       
	   COTIZACION DE VEHICULO 
		<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
	
	<table>
	<tr>
	<td>
	Segun la cotizacion solicitada para el vehiculo Marca 
		<asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>  
	Modelo 
		<asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
		</td>
		</tr>
<tr>
		<td>
		
		
		El permiso de circulacion corresponde a : 
		<asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
		</td>

		</tr>
		<tr>
		<td>
		el Valor del impuesto Verde Corresponde a : 
		<asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
	</td>
	</tr>

	</table>


    </div>

    <br/>



</asp:Content>
