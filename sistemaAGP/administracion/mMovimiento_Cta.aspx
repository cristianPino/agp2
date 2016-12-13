<%@ Page Language="C#" MasterPageFile="~/Adm.Master" AutoEventWireup="true" CodeBehind="mMovimiento_Cta.aspx.cs" Inherits="sistemaAGP.mMovimiento_Cta" Title="Movimientos Cuenta Corriente" %>
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
								Cuenta
							</td>
							<td style="text-align: left; width: 128px;">
								<asp:DropDownList ID="dl_cuenta" runat="server" Font-Names="Arial" Font-Size="X-Small"
									Height="16px" Width="138px" TabIndex="7" Style="font-family: Arial, Helvetica, sans-serif;
									font-size: x-small" onselectedindexchanged="dl_tipo_SelectedIndexChanged">
								</asp:DropDownList>
							</td>
						</tr>
                        <tr>
                        <td class="style3">
                             Monto</td>
                        <td style="text-align: left; " class="style4">
                            <asp:TextBox ID="txt_monto" runat="server" Height="17px" MaxLength="50" 
                                Width="137px" AutoPostBack="True" ontextchanged="txt_monto_TextChanged"></asp:TextBox>
                        </td>
                    </tr>
					<tr>
						<td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;"
							class="style30">
							Fecha Movimiento</td>
						<td>
							<asp:TextBox ID="txt_fecha_movimiento" runat="server" Style="font-family: Arial, Helvetica, sans-serif;
								font-size: x-small" Height="17px" Width="135px" TabIndex="7" 
								OnTextChanged="txt_fecha_movimiento_TextChanged"></asp:TextBox>
							<cc1:CalendarExtender runat="server" TargetControlID="txt_fecha_movimiento" CssClass="calendario"
								Format="dd/MM/yyyy" PopupButtonID="ib_calendario" ID="CalendarExtender2" />
						</td>
						<td>
							<asp:ImageButton ID="ib_calendario" runat="server" ImageUrl="../imagenes/sistema/gif/calendario.gif"
								OnClick="ib_calendario_Click" style="height: 14px" />
						</td>
					</tr>
					<tr>
						<td style="width: 15px; text-align: right">
							tipo
						</td>
						<td style="text-align: left; width: 128px;">
							<asp:DropDownList ID="dl_tipo" runat="server" Font-Names="Arial" Font-Size="X-Small"
								Height="16px" Width="138px" TabIndex="7" Style="font-family: Arial, Helvetica, sans-serif;
								font-size: x-small" OnSelectedIndexChanged="dl_tipo_SelectedIndexChanged">
							</asp:DropDownList>
						</td>
					</tr>
                    
                
                    
                    
                </table>
                </div>
<asp:Button ID="Button1" runat="server" Font-Names="Arial" Font-Size="X-Small" 
                        Text="Guardar" onclick="Button1_Click" TabIndex="16" 
                        
                        />
<cc1:ConfirmButtonExtender ID="Button1_ConfirmButtonExtender" 
            runat="server" TargetControlID="Button1"
            ConfirmText="¿Esta seguro de ingresar un nuevo Movimiento?"
            >
</cc1:ConfirmButtonExtender>
                
                            
                        
                &nbsp;<asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" 
                        CellPadding="4" Font-Names="Arial" Font-Size="X-Small" ForeColor="#333333" 
                        GridLines="None" 
        onselectedindexchanged="gr_dato_SelectedIndexChanged" 
		EnableModelValidation="True">
    <RowStyle BackColor="#EFF3FB" />
    <Columns>
        <asp:BoundField AccessibleHeaderText="fecha" DataField="fecha_hora" 
            HeaderText="fecha" FooterText="fecha" />
        <asp:BoundField AccessibleHeaderText="abono" DataField="abono" 
            HeaderText="abono" FooterText="abono" />
            <asp:BoundField AccessibleHeaderText="cargo" DataField="cargo" 
			FooterText="cargo" HeaderText="cargo" />
		<asp:BoundField AccessibleHeaderText="saldo" DataField="saldo" 
			FooterText="saldo" HeaderText="saldo" />
		<asp:TemplateField HeaderText="Carga contable" ShowHeader="False">
			<ItemTemplate>
				<asp:ImageButton ID="ib_carga" runat="server" ImageUrl="../imagenes/sistema/impresoras/impresora.gif"
					Text="carga contable" />
			</ItemTemplate>
			<ControlStyle Height="25px" Width="25px" />
		</asp:TemplateField>
		<asp:TemplateField HeaderText="Oper.del dia" ShowHeader="False">
			<ItemTemplate>
				<asp:ImageButton ID="ib_opedia" runat="server" ImageUrl="../imagenes/sistema/impresoras/impresora.gif"
					Text="operaciones del dia" />
			</ItemTemplate>
			<ControlStyle Height="25px" Width="25px" />
		</asp:TemplateField>

    </Columns>
    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <EditRowStyle BackColor="#2461BF" />
    <AlternatingRowStyle BackColor="White" />
</asp:GridView>
                

</asp:Content>
