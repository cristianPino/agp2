<%@ Page Language="C#" MasterPageFile="~/Adm.Master" AutoEventWireup="true" CodeBehind="Cotizador.aspx.cs"
    Inherits="sistemaAGP.Cotizador" Title="Solicitud InfoAuto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="ajaxToolkit" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=3.5.40412.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        
        .caja
        {
            width: 100%;
            margin: auto;
            height: 163px;
            background: #2FAACE;
            box-shadow: 10px 10px 3px #D8D8D8;
            transition: height .4s;
            color: #fff;
            font-size: xx-small;
            text-align: center;
            vertical-align:middle;
            border: solid 1px #fff;
            position: relative;
			top: 30px;
			left: 0px;
		}
        .caja table
        {
            margin: 0 auto;
            text-align: left;
        }
        
         .cajaVertical
        {
            width: 30%;
            margin: auto;
            height: 280px;
            background: #2FAACE;
            box-shadow: 10px 10px 3px #D8D8D8;
            transition: background .4s;
            text-align: center;
            color: #fff;
            font-size: xx-small;
            vertical-align:middle;
            border: solid 1px #fff;
           
        }
        .cajaVertical table
        {
            margin: 0 auto;
            text-align: left;
        }
    </style>
    <script type="text/javascript">

       
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                        <td>
                            MARCA VEHICULO
                        </td>
                        <td>
                            <asp:DropDownList ID="dlmarca" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dlmarca_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        </tr>
                        <tr>
                        <td>
                            MODELO DE VEHICULO
                        </td>
                        <td>
                            <asp:DropDownList ID="dlSucursal" runat="server">
                            </asp:DropDownList>

                        </td>

						 
                    </tr>

					  <tr>
                        <td>
                           FECHA DE FACTURA
                        </td>
                        <td>
							<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                        </td>

						 
                    </tr>

					 <tr>
                        <td>
                           MONTO DE FACTURA
                        </td>
                        <td>
							<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                        </td>

						 
                    </tr>
				
					<tr>
					<td>

					SOLICITAR COTIZACION

					</td>
					<td>
					  
							                    <asp:ImageButton ID="ibPedir" ValidationGroup="ibCreaBorradorEscritura" runat="server"
                        ImageUrl="../imagenes/sistema/static/hipotecario/crear_nuevo_doc.png" ToolTip="Crear documento"
                        OnClick="ibPedir_Click" />
                    
                 
					 
					 
					 
					</td>
					</tr>
                   
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
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
