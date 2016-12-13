<%@ Page Title="Tasador" Language="C#" MasterPageFile="~/Adm.Master"
	AutoEventWireup="true" CodeBehind="mTasador.aspx.cs" Inherits="sistemaAGP.mTasador" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/controles/wucPersona.ascx" TagName="DatosPersona" TagPrefix="agp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<style type="text/css">

        .style2
		{}
		.style3
		{
			height: 9px;
		}
		.style4
		{
			height: 15px;
		}
		.style5
		{
			height: 16px;
		}
		.style6
		{
			height: 22px;
		}
		
        .style13
		{
			height: 15px;
			width: 97px;
		}
		.style14
		{
			height: 9px;
			width: 97px;
		}
		.style15
		{
			height: 22px;
			width: 97px;
		}

        .style16
		{
			width: 580px;
		}

        .style17
		{
			height: 15px;
			width: 140px;
		}
		.style18
		{
			height: 9px;
			width: 140px;
		}
		.style19
		{
			height: 22px;
			width: 140px;
		}
		.style20
		{
			width: 140px;
		}

        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

	<table style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 167px; width: 671px;" 
		bgcolor="#E5E5E5">
    <tr>
    <td colspan="6" style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; font-weight: 700; color: #FFFFFF; background-color: #0066FF" 
			class="style5" >
        Datos del Tasador</td>
    </tr>
 
    <tr>
            <td class="style13">
                Operacion Nº: </td>
            <td class="style4">
                <asp:Label ID="lbl_operacion" runat="server" ForeColor="#FF3300" 
                    style="font-weight: 700; font-size: small"></asp:Label>
            </td>
		<td class="style13">
			ROL:
		</td>
		<td class="style17">
			<asp:Label ID="lbl_rol" runat="server" ForeColor="#FF3300" Style="font-weight: 700;
				font-size: small"></asp:Label>
		</td>
		<td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;">
			<asp:Label ID="lbl_tasador" runat="server" Font-Size="X-Small" Text="Tasador"></asp:Label>
		</td>
		<td>
			<asp:DropDownList ID="dl_tasador" runat="server" Font-Names="Arial" Font-Size="X-Small"
				Height="16px" Width="138px" TabIndex="17" Style="font-family: Arial, Helvetica, sans-serif;
				font-size: x-small" OnSelectedIndexChanged="dl_tasador_SelectedIndexChanged1">
			</asp:DropDownList>
		</td>
        </tr>
	
		<tr>
			<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;"
				class="style14">
				Valor Comercial(UF)</td>
			<td class="style3">
				<asp:TextBox ID="txt_valor_comercial" runat="server" CssClass="style2" 
					Width="135px" MaxLength="12"
					OnTextChanged="txt_valor_comercial_TextChanged" Height="19px"></asp:TextBox>
				</td>
			<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;" class="style14">
				Metros Edificados
			</td>
			<td class="style18">
				<asp:TextBox ID="txt_metros_edificados" runat="server" CssClass="style2" Width="135px"
					MaxLength="12" OnTextChanged="txt_metros_edificados_TextChanged" Height="19px"></asp:TextBox>
			</td>
			<td style="font-size: x-small; font-family: Arial, Helvetica, sans-serif">
				Permiso Edificacion
			</td>
			<td>
				<asp:TextBox ID="txt_permiso_edificacion" runat="server"></asp:TextBox>
			</td>
		</tr>
		<tr>
			<td class="style15">
				Valor Liquidez(UF)</td>
			<td class="style6">
				<asp:TextBox ID="txt_valor_liquidez" runat="server" CssClass="style2" 
					Width="135px" MaxLength="12"
					OnTextChanged="txt_valor_liquidez_TextChanged" Height="19px"></asp:TextBox>
			</td>
			<td class="style15">
				Metros Terreno
			</td>
			<td class="style19">
				<asp:TextBox ID="txt_metros_terreno" runat="server" CssClass="style2" 
					Width="135px" MaxLength="12"
					OnTextChanged="txt_metros_terreno_TextChanged" Height="19px"></asp:TextBox>
			</td>
			<td style="font-size: x-small; font-family: Arial, Helvetica, sans-serif">
				Estado General Obra
			</td>
			<td>
				<asp:TextBox ID="txt_estado_obra" runat="server"></asp:TextBox>
			</td>
		</tr>
		<tr>
			<td class="style15">
				Valor Seguro
				(UF)</td>
			<td class="style6">
				<asp:TextBox ID="txt_valor_seguro" runat="server" CssClass="style2" 
					Width="135px" MaxLength="12"
					OnTextChanged="txt_valor_seguro_TextChanged" Height="19px"></asp:TextBox>
			</td>
			<td style="font-size: x-small; font-family: Arial, Helvetica, sans-serif">
				Superficie a Valorar
			</td>
			<td class="style20">
				<asp:TextBox ID="txt_superficie_valorar" runat="server"></asp:TextBox>
			</td>
			<td style="font-size: x-small; font-family: Arial, Helvetica, sans-serif">
				Urbanizacion
			</td>
			<td>
				<asp:TextBox ID="txt_urbanizacion" runat="server"></asp:TextBox>
			</td>
			<tr>
				<td style="font-size: x-small; font-family: Arial, Helvetica, sans-serif">
					Leyes Acogidas
				</td>
				<td>
					<asp:TextBox ID="txt_leyes_acogidas" runat="server"></asp:TextBox>
				</td>
			</tr>
		</tr>
		</table>



		<table bgcolor="#E5E5E5" style="height: 37px; width: 673px">
		<tr>
    
    <td class="style16">
        <asp:Button ID="Button1" runat="server" 
            style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; font-weight: 700" 
            Text="Guardar" onclick="Button1_Click" />
        </td>
  
    
    </tr>
    </table>
	
</asp:Content>
