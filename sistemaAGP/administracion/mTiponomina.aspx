<%@ Page Language="C#" MasterPageFile="~/adm.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="mTiponomina.aspx.cs" Inherits="sistemaAGP.mTiponomina" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<style type="text/css">
		.style1 {
			height: 277px;
			width: 1051px;
		}
	</style>
	</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table style="width: 493px; height: 347px">
        <tr>
            <td style="border-style: none; border-color: inherit; border-width: 0; text-align: left; " class="style1" 
                   >
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Arial" 
                        Font-Size="X-Small" Text="Administracion de Nominas"></asp:Label>
                <br />
                <table style="width: 97%; font-family: Arial, Helvetica, sans-serif; font-size: x-small" 
                                      >
                    <tr>
                                <td style="width: 226px; text-align: left">
								Descripcion
									<asp:TextBox Height="17px" Width="100px" ID="TextBox2" runat="server" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
								Emite Factura
									<asp:CheckBox ID="CheckBox1" runat="server" />
								           Folio	
							  	    <asp:TextBox Height="17px" Width="35px" ID="TextBox3" runat="server"></asp:TextBox>
									REPORTE
									<asp:TextBox Height="17px" Width="230px" ID="TextBox4" runat="server"></asp:TextBox>
									GASTO
									<asp:DropDownList ID="gasto_dl" MaxLength="120" Height="16px" runat="server" Width="120px" Font-Size="7pt" AutoPostBack="false" OnSelectedIndexChanged="gastodl_SelectedIndexChanged">
									</asp:DropDownList>	
									ESTADO
									<asp:DropDownList ID="estado_dl" MaxLength="120" Height="16px" runat="server" Width="120px" Font-Size="7pt" AutoPostBack="false" OnSelectedIndexChanged="estadodl_SelectedIndexChanged">
									</asp:DropDownList>
					</tr>
                                        
                    
                </table>
                <asp:Button ID="Button1" runat="server" Font-Names="Arial" Font-Size="X-Small" 
                        Text="Guardar" onclick="Button1_Click" TabIndex="16" />

			                           
                        
                &nbsp;<asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Names="Verdana" Font-Size="X-Small" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="gr_dato_SelectedIndexChanged" OnRowDataBound="gr_dato_RowDataBound" DataKeyNames="dl_estado,dl_gasto">
                    <RowStyle BackColor="#EFF3FB" />
                    <Columns>
                        <asp:BoundField AccessibleHeaderText="id_nomina" DataField="id_nomina" 
                            HeaderText="id_nomina" />
						
						
						<asp:BoundField AccessibleHeaderText="descripcion" DataField="descripcion" 
                            HeaderText="descripcion" />
						<asp:TemplateField HeaderText="Folio" meta:resourcekey="TemplateFieldResource1">
							<ItemTemplate>
								<asp:TextBox ID="Folio" MaxLength="120" Height="16px" runat="server" Width="120px" Font-Size="7pt" AutoPostBack="false" OnSelectedIndexChanged="dl_estado_SelectedIndexChanged" Text='<%# Bind("Folio") %>'>
								</asp:TextBox>
							</ItemTemplate>
							<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
						</asp:TemplateField>


						<asp:TemplateField HeaderText="Emite Factura" meta:resourcekey="TemplateFieldResource1">
							<ItemTemplate>
								<asp:CheckBox  ID="chk" runat="server" EnableViewState="true" Checked='<%# Bind("checked")  %>' />
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField HeaderText="Reporte" meta:resourcekey="TemplateFieldResource1">
							<ItemTemplate>
								<asp:TextBox ID="reporte" MaxLength="120" Height="16px" runat="server" Width="120px" Font-Size="7pt" AutoPostBack="false" OnSelectedIndexChanged="dl_estado_SelectedIndexChanged" Text='<%# Bind("reporte") %>'>
								</asp:TextBox>
							</ItemTemplate>
							<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
						</asp:TemplateField>



						<asp:TemplateField HeaderText="ESTADO" meta:resourcekey="TemplateFieldResource1">
							<ItemTemplate>
								<asp:DropDownList ID="dl_estado" MaxLength="120" Height="16px" runat="server" Width="120px" Font-Size="7pt" AutoPostBack="false" OnSelectedIndexChanged="dl_estado_SelectedIndexChanged">
								</asp:DropDownList>
							</ItemTemplate>
							<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
						</asp:TemplateField>
						
						
					


						<asp:TemplateField HeaderText="GASTO" meta:resourcekey="TemplateFieldResource1">
							<ItemTemplate>
								<asp:DropDownList ID="dl_gasto" MaxLength="120" Height="16px" runat="server" Width="120px" Font-Size="7pt" AutoPostBack="false" OnSelectedIndexChanged="dl_estado_SelectedIndexChanged">
								</asp:DropDownList>
							</ItemTemplate>
							<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
						</asp:TemplateField>
					</Columns>
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#2461BF" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
                <asp:Button ID="Button2" runat="server" Font-Names="Arial" 
                        Font-Size="X-Small" onclick="Button2_Click" Text="Actualizar" />
              
                <br />
            </td>
        </tr>
        <tr>
            <td style="border-style: none; border-color: inherit; border-width: 0; text-align: left; " class="style1"  
                   >
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
