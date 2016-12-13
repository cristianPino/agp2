<%@ Page Title="Analisis Alzamiento" Language="C#" MasterPageFile="~/Adm.Master"
	AutoEventWireup="true" CodeBehind="Analisis_Alzamiento.aspx.cs" Inherits="sistemaAGP.Analisis_Alzamiento"
	EnableSessionState="True" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>--%>
<%@ Register Src="~/controles/wucPersona.ascx" TagName="DatosPersona" TagPrefix="agp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
	<style type="text/css">
        .style31
        {
            width: 121px;
            height: 16px;
        }
        .style32
		{
			width: 121px;
		}
		.style33
		{
			width: 146px;
		}
		.style34
		{
			width: 52px;
		}
        </style>
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
       
            <table  bgcolor="#cccccc" style="width: 100%; height: 13px;">
                <tr>
                    <td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 1115px; color: #000000;">
                        <b>INGRESO OPERACION DE ALZAMIENTO</b></td>
                </tr>
            </table>
	<table style="width: 100%; height: 14px;">
		<tr>
			<td bgcolor="#669999" style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;
				color: #FFFFFF;" class="style31">
				<b>DATOS OPERACION</b>
			</td>
		</tr>
		<tr>
			<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;" 
				class="style32">
				Entidad Financiera
			</td>
			<td class="style33">
				<asp:DropDownList ID="ddl_financiera" runat="server" Font-Names="Arial" Font-Size="X-Small"
					Height="16px" Width="138px" Style="font-family: Arial, Helvetica, sans-serif;
					font-size: x-small">
				</asp:DropDownList>
			</td>
			<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;" 
				class="style34">
				Monto 
			</td>
			<td>
				<asp:TextBox ID="txt_monto" runat="server" Font-Names="Arial" Font-Size="X-Small"
					Height="16px" Width="80px" MaxLength="50" Style="font-family: Arial, Helvetica, sans-serif;
					font-size: x-small"></asp:TextBox>
			</td>
		</tr>
		<tr>
			<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
				Fecha Carta
			</td>
			<td>
				<asp:TextBox ID="txt_fecha_carta" runat="server" Font-Names="Arial" Font-Size="X-Small"
					Height="16px" Width="65px" MaxLength="50" Style="font-family: Arial, Helvetica, sans-serif;
					font-size: x-small"></asp:TextBox>
				<asp:ImageButton ID="ib_calendario" runat="server" ImageUrl="../imagenes/sistema/gif/calendario.gif" />
				<cc1:CalendarExtender ID="calfechacarta" runat="server" TargetControlID="txt_fecha_carta"
					PopupButtonID="ib_calendario" />
			</td>
			<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
				Fecha Termino
			</td>
			<td >
				<asp:TextBox ID="txt_fecha_termino" runat="server" Font-Names="Arial" Font-Size="X-Small"
					Height="16px" Width="65px" MaxLength="50" Style="font-family: Arial, Helvetica, sans-serif;
					font-size: x-small"></asp:TextBox>
				<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="../imagenes/sistema/gif/calendario.gif" />
				<cc1:CalendarExtender ID="calfechatermino" runat="server" TargetControlID="txt_fecha_termino"
					PopupButtonID="ImageButton1" />
			</td>
		</tr>
		<tr>
			<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
				Fecha Otorgamiento
			</td>
			<td>
				<asp:TextBox ID="txt_fecha_otorgamiento" runat="server" Font-Names="Arial" Font-Size="X-Small"
					Height="16px" Width="65px" MaxLength="50" Style="font-family: Arial, Helvetica, sans-serif;
					font-size: x-small"></asp:TextBox>
				<asp:ImageButton ID="ib_otorgamiento" runat="server" ImageUrl="../imagenes/sistema/gif/calendario.gif" />
				<cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_fecha_otorgamiento"
					PopupButtonID="ib_otorgamiento" />
			</td>
		</tr>
		<tr>
			<td>
				
				<asp:Label ID="lbl_error" ForeColor="Red" runat="server" Text=""></asp:Label>
				
			</td>
		</tr>
	</table>
            <table  bgcolor="cccccc" style="width: 100%" >
                <tr>
                     <td style="text-align: center; width: 38px;">
                        <asp:Button ID="bt_guardar" runat="server" Font-Names="Arial" Font-Size="X-Small" 
                            Text="Guardar" TabIndex="53" onclick="bt_guardar_Click" />
                    </td>
                         
                    <td style="text-align: right">
						&nbsp;</td>
                </tr>
            </table>
                        
                 
            
             </asp:Content>

