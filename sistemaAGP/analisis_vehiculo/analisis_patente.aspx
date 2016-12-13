<%@ Page Title="Analisis Vehiculo - Datos de C.A.V." Language="C#" MasterPageFile="~/Adm.Master" AutoEventWireup="true" CodeBehind="analisis_patente.aspx.cs" Inherits="sistemaAGP.analisis_patente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 57%;
        }
        .style2
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: x-small;
            margin-left: 0px;
        }
        .style4
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: x-small;
            width: 39px;
        }
        .style5
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: x-small;
            width: 86px;
        }
        .style6
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: x-small;
            width: 74px;
        }
        .style8
        {
            width: 52px;
            height: 25px;
        }
        .style9
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: x-small;
            margin-left: 40px;
            width: 91px;
        }
        .style10
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: x-small;
            width: 74px;
            height: 22px;
        }
        .style11
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: x-small;
            width: 86px;
            height: 22px;
        }
        .style13
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: x-small;
            margin-left: 0px;
            width: 91px;
            height: 22px;
        }
        .style14
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: x-small;
            width: 74px;
            height: 23px;
        }
        .style15
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: x-small;
            width: 86px;
            height: 23px;
        }
        .style17
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: x-small;
            margin-left: 0px;
            width: 91px;
            height: 23px;
        }
        .style18
        {
            height: 25px;
        }
        .style21
		{
			font-family: Arial, Helvetica, sans-serif;
			font-size: x-small;
			margin-left: 0px;
			width: 44px;
		}
		.style22
		{
			font-family: Arial, Helvetica, sans-serif;
			font-size: x-small;
			width: 44px;
			height: 22px;
		}
		.style23
		{
			font-family: Arial, Helvetica, sans-serif;
			font-size: x-small;
			width: 44px;
			height: 23px;
		}
		.style24
		{
			font-family: Arial, Helvetica, sans-serif;
			font-size: x-small;
			width: 44px;
		}
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    
    <table class="style1">
    <tr>
    <td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; font-weight: 700; color: #FFFFFF; background-color: #0066FF" >
        Analisis de Patente</td>
    </tr>
    
    </table>
    <table class="style1">
        <tr>
            <td class="style10">
                Patente</td>
            <td class="style11">
                <asp:Label ID="lbl_patente" runat="server" ForeColor="#FF3300" 
                    style="font-weight: 700; font-size: small"></asp:Label>
            </td>
            <td class="style22">
                Chasis</td>
            <td class="style13">
                <asp:TextBox ID="txt_chasis" runat="server" CssClass="style2" Width="134px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style6">
                Tipo Vehiculo</td>
            <td class="style5">
                <asp:TextBox ID="txt_tipo" runat="server" CssClass="style2" Height="16px" 
                    Width="134px"></asp:TextBox>
            </td>
			<td class="style6">
				Vin
			</td>
			<td class="style5">
				<asp:TextBox ID="txt_vin" runat="server" CssClass="style2" Width="134px"></asp:TextBox>
			</td>
		</tr>
        <tr>
            <td class="style6">
                Marca</td>
            <td class="style5">
                <asp:TextBox ID="txt_marca" runat="server" CssClass="style2" Width="134px"></asp:TextBox>
            </td>
			<td class="style24">
				Serie
			</td>
			<td class="style5">
				<asp:TextBox ID="txt_serie" runat="server" CssClass="style2" Width="134px"></asp:TextBox>
			</td>
        </tr>
        <tr>
         <td class="style4">
                Color</td>
            <td class="style9">
                <asp:TextBox ID="txt_color" runat="server" CssClass="style2" Width="134px"></asp:TextBox>
            </td>
         <td class="style24">
                Modelo</td>
            <td class="style9">
                <asp:TextBox ID="txt_modelo" runat="server" CssClass="style2" Width="134px"></asp:TextBox>
            </td>
        
        </tr>
        <tr>
            <td class="style14">
                Año</td>
            <td class="style15">
                <asp:TextBox ID="txt_ano" runat="server" CssClass="style2" Width="134px"></asp:TextBox>
            </td>
            <td class="style23">
                Motor</td>
            <td class="style17">
                <asp:TextBox ID="txt_motor" runat="server" CssClass="style2" Width="134px"></asp:TextBox>
            </td>
        </tr>
		<tr>
		<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;" class="style14">
			Estado Vehiculo
		</td>
		<td class="style9">
			<asp:DropDownList ID="dl_estado_vehiculo" runat="server" Font-Names="Arial" Font-Size="X-Small"
				Height="16px" Width="138px" TabIndex="6" Style="font-family: Arial, Helvetica, sans-serif;
				font-size: x-small" OnSelectedIndexChanged="dl_estado_vehiculo_SelectedIndexChanged">
			</asp:DropDownList>
		</td>
			
			<td class="style21">
				<asp:DropDownList ID="dl_tipo_vehiculo" runat="server" Font-Names="Arial" Font-Size="X-Small"
					Height="16px" Width="86px" TabIndex="6" Style="font-family: Arial, Helvetica, sans-serif;
					font-size: x-small" OnSelectedIndexChanged="dl_tipo_vehiculo_SelectedIndexChanged" 
					Visible="False">
				</asp:DropDownList>
			</td>
			<td class="style9">
				<asp:DropDownList ID="dl_marca" runat="server" Font-Names="Arial" Font-Size="X-Small"
					Height="16px" Width="108px" TabIndex="6" Style="font-family: Arial, Helvetica, sans-serif;
					font-size: x-small" OnSelectedIndexChanged="dl_marca_SelectedIndexChanged" 
					Visible="False">
				</asp:DropDownList>
			</td>
		</tr>
    </table>
    
    <table>
    <tr>
    <td class="style18">
        <asp:TextBox ID="txt_PDF" runat="server" AutoPostBack="True" Height="36px" 
            ontextchanged="txt_PDF_Leave" TextMode="MultiLine" Width="173px"></asp:TextBox>
    </td>
    
    <td class="style8">
        <asp:Button ID="Button1" runat="server" 
            style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; font-weight: 700" 
            Text="Guardar" onclick="Button1_Click" />
        </td>
  
    
    </tr>
    </table>
    
</asp:Content>
