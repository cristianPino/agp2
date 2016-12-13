<%@ Page Title="Analisis Vehiculo - Datos de C.A.V." Language="C#" MasterPageFile="~/Adm.Master" AutoEventWireup="true" CodeBehind="analisis_vehiculos.aspx.cs" Inherits="sistemaAGP.analisis_vehiculos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 57%;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    
    <table class="style1">
    <tr>
    <td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; font-weight: 700; color: #FFFFFF; background-color: #0066FF" >
        Analisis de Vehiculo</td>
    </tr>
		<asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" CellPadding="4"
			Font-Names="Verdana" Font-Size="X-Small" ForeColor="#333333" GridLines="None"
			OnSelectedIndexChanged="gr_dato_SelectedIndexChanged1">
			<RowStyle BackColor="#EFF3FB" />
			<Columns>
				<asp:BoundField DataField="id_solicitud" HeaderText="id_solicitud" />
				<asp:BoundField DataField="patente" HeaderText="patente" />
				<asp:BoundField DataField="kilometraje" HeaderText="kilometraje" />
				<asp:BoundField DataField="tasacion" HeaderText="tasacion" />
				<asp:BoundField DataField="precio" HeaderText="precio" />
				<asp:TemplateField AccessibleHeaderText="analisis" HeaderText="analisis">
					<ItemTemplate>
						<asp:ImageButton ID="ib_analisis" runat="server" ImageUrl="../imagenes/sistema/static/registro.jpg"
							OnClick="Click_analisis" Text="analisis patente" />
					</ItemTemplate>
					<ControlStyle Height="35px" Width="35px" />
				</asp:TemplateField>
			</Columns>
			<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
			<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
			<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
			<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
			<EditRowStyle BackColor="#2461BF" />
			<AlternatingRowStyle BackColor="White" />
		</asp:GridView>
    
    </table>
        
</asp:Content>
