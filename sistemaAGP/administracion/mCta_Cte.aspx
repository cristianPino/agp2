<%@ Page Language="C#" MasterPageFile="~/Adm.Master" AutoEventWireup="true" CodeBehind="mCta_Cte.aspx.cs" Inherits="sistemaAGP.mCta_Cte" Title="Administracion de Cuentas Corrientes" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 155px;
        }
        .style3
        {
            width: 13px;
        }
        .style4
        {
            width: 124px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
                
                <table style="width: 32%; font-family: Arial, Helvetica, sans-serif; font-size: x-small" 
                                        bgcolor="#E5E5E5">
                    <tr>
                        <td class="style3">
                            persona<td style="text-align: left" class="style4">
                            <asp:Label ID="lbl_nombre" runat="server"></asp:Label>
                        </td>
                        <td style="text-align: right" class="style3">
                            rut</td>
                        <td style="text-align: left; " class="style1">
                            <asp:Label ID="lbl_rut" runat="server"></asp:Label>
                        </td>
                        </tr>
						<tr>
							<td style="width: 15px; text-align: right">
								Tipo Cuenta
							</td>
							<td style="text-align: left; width: 128px;">
								<asp:DropDownList ID="dl_tipo" runat="server" Font-Names="Arial" Font-Size="X-Small"
									Height="16px" Width="138px" TabIndex="7" Style="font-family: Arial, Helvetica, sans-serif;
									font-size: x-small" onselectedindexchanged="dl_tipo_SelectedIndexChanged">
								</asp:DropDownList>
							</td>
						</tr>
                        <tr>
                        <td class="style3">
                             NºCuenta</td>
                        <td style="text-align: left; " class="style4">
                            <asp:TextBox ID="txt_n_cuenta" runat="server" Height="17px" MaxLength="50" 
                                Width="168px"></asp:TextBox>
                        </td>
                    </tr>
					<tr>
						<td class="style3">
							Banco
						</td>
						<td style="text-align: left;" class="style4">
							<asp:TextBox ID="txt_banco" runat="server" Height="17px" MaxLength="50" Width="168px"></asp:TextBox>
						</td>
					</tr>
                    
                
                    
                    
                </table>
                </div>
<asp:Button ID="Button1" runat="server" Font-Names="Arial" Font-Size="X-Small" 
                        Text="Guardar" onclick="Button1_Click" TabIndex="16" 
                        
                        />
<cc1:ConfirmButtonExtender ID="Button1_ConfirmButtonExtender" 
            runat="server" TargetControlID="Button1"
            ConfirmText="¿Esta seguro de ingresar una nueva cuenta corriente?"
            >
</cc1:ConfirmButtonExtender>
                
                            
                        
                &nbsp;<asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" 
                        CellPadding="4" Font-Names="Arial" Font-Size="X-Small" ForeColor="#333333" 
                        GridLines="None" 
        onselectedindexchanged="gr_dato_SelectedIndexChanged" 
		EnableModelValidation="True">
    <RowStyle BackColor="#EFF3FB" />
    <Columns>
        <asp:BoundField AccessibleHeaderText="id_cta_cte" DataField="id_cta_cte" 
            HeaderText="id_cta_cte" FooterText="id_cta_cte" />
        <asp:BoundField AccessibleHeaderText="tipo_cuenta" DataField="tipo_cuenta" 
            HeaderText="tipo_cuenta" FooterText="tipo_cuenta" />
            <asp:BoundField AccessibleHeaderText="Nºcuenta" DataField="numero" 
			FooterText="Nºcuenta" HeaderText="Nºcuenta" />
		<asp:BoundField AccessibleHeaderText="Banco" DataField="banco" 
			FooterText="Banco" HeaderText="Banco" />
    </Columns>
    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <EditRowStyle BackColor="#2461BF" />
    <AlternatingRowStyle BackColor="White" />
</asp:GridView>
                

</asp:Content>
