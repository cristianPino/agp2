<%@ Page Title="Contratos de Vehiculo - Datos de Contrato" Language="C#" MasterPageFile="~/Adm.Master" AutoEventWireup="true" CodeBehind="Contra_vehiculos.aspx.cs" Inherits="sistemaAGP.Contra_vehiculos" %>
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
        Contratos de Vehiculo</td>
    </tr>
		<asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" CellPadding="4"
			Font-Names="Verdana" Font-Size="X-Small" ForeColor="#333333" GridLines="None"
			OnSelectedIndexChanged="gr_dato_SelectedIndexChanged1">
			<RowStyle BackColor="#EFF3FB" />
			<Columns>
				<asp:BoundField DataField="id_dato_vehiculo" HeaderText="id_dato_vehiculo" />
				<asp:BoundField DataField="id_solicitud" HeaderText="id_solicitud" />
				<asp:BoundField DataField="patente" HeaderText="patente" />
				<asp:BoundField DataField="kilometraje" HeaderText="kilometraje" />
				<asp:BoundField DataField="tasacion" HeaderText="tasacion" />
				<asp:BoundField DataField="precio" HeaderText="precio" />
				<asp:BoundField DataField="estado" HeaderText="estado" />
				<asp:TemplateField AccessibleHeaderText="Datos Actualizar" HeaderText="Actualizar">
					<ItemTemplate>
						<asp:ImageButton ID="ib_actualizar" runat="server" ImageUrl="../imagenes/sistema/static/documentos2.gif"
							OnClick="Click_actualizar" Text="Actualizar" />
					</ItemTemplate>
					<ControlStyle Height="35px" Width="35px" />
				</asp:TemplateField>
				<asp:TemplateField AccessibleHeaderText="Contratos" HeaderText="Contratos">
					<ItemTemplate>
						<asp:ImageButton ID="ib_contratos" runat="server" ImageUrl="../imagenes/sistema/static/contrato2.gif"
							OnClick="Click_contratos" Text="Contratos" />
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
