<%@ Page Title="" Language="C#" MasterPageFile="~/Adm.Master" AutoEventWireup="true" CodeBehind="mClienteTag.aspx.cs" Inherits="sistemaAGP.mClienteTag" EnableEventValidation="false" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<style type="text/css">
        .style3 {
			width: 97px;
		}
		.style6 {
			width: 960px;
			}
    	.style8 {
			width: 131px;
		}
    	</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div>

		<table style="width: 34%; font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 112px; margin-right: 0px;" bgcolor="#E5E5E5">
        <tr>
            <td style="border-style: none; border-color: inherit; border-width: 0; text-align: left; " align="left" 
                    valign="top" class="style6">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="Small" Text="Precio De TAG por cliente" CssClass="calendario"></asp:Label>
				<table>
					<tr>
						<td>
							<asp:DropDownList ID="dl_familia" runat="server" AutoPostBack="true" Height="16px" Width="204px" OnSelectedIndexChanged="dl_familia_SelectedIndexChanged" Style="font-size: x-small">
							</asp:DropDownList>
						</td>
					</tr>
				</table>
				<table style="width: 100%; font-family: Arial, Helvetica, sans-serif; font-size: small ">
					<tr>
						<td class="style3">
							Cliente:
						</td>
					
						<td>
							<asp:Label ID="lbl_cliente" runat="server" Font-Names="Arial" Font-Size="X-Small"  Width="246px"></asp:Label>
						</td>
					</tr>
					</table>

					


					<table>
					
					<tr>
						
						<td class="style8" font-size="X-Small">
							&nbsp;TAG Cliente</td>
							
                        <td style="text-align: left; ">
                            <asp:TextBox ID="txt_tagcliente" runat="server" Height="16px" Width="72px" ontextchanged="txt_nombre_TextChanged" style="margin-left: 2px"></asp:TextBox>
                        </td>
						</tr>
						<%--</table>
						<table style="width: 39%; font-family: Arial, Helvetica, sans-serif; font-size: x-small; height: 29px;" bgcolor="#E5E5E5">--%>
					<tr>
						<td class="style8" font-size="X-Small">
							TAG AGP</td>
							
						<td style="text-align: left;">
							<asp:TextBox ID="txtTag_agp" runat="server" Height="16px" Width="72px" ontextchanged="txttag_agp_TextChanged"></asp:TextBox>
						</td>
						</tr>
						</table>
						<%--</tr>
							<tr>
								<td class="style9" font-size="X-Small">
									&nbsp; TAG AGP
								</td>
								<td style="text-align: left;">
									<asp:TextBox ID="TextBox1" runat="server" Height="16px" Width="72px" OnTextChanged="txttag_agp_TextChanged"></asp:TextBox>
								</td>
							</tr>--%>
					</table>

					
						

						<table>
						<tr>
						<td>
                <asp:Button ID="Button1" runat="server" Font-Names="Arial" Font-Size="X-Small" 
                        Text="Guardar" onclick="Button1_Click" TabIndex="16" />
						</td>
						</tr>
						</table>
                        
            </table>
            
      
	</div>
</asp:Content>
