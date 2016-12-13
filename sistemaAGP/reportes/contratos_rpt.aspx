<%@ Page Title="Analisis Vehiculo - Datos de C.A.V." Language="C#" MasterPageFile="~/Adm.Master" AutoEventWireup="true" CodeBehind="contratos_rpt.aspx.cs" Inherits="sistemaAGP.contratos_rpt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 32%;
			height: 50px;
		}
		.grilla {
			overflow: auto;
			height: 40%;
			width: 95%;
		}
			.panel {
			margin: 0;
			padding: 0;
		}
        #i_documento
		{
		    position:absolute;
		}
		.tabla
		{
		    height: 100%;
		    width: 100%;
		}
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
	<asp:Panel ID="divGrilla" runat="server" CssClass="panel">
		<div style="overflow: auto; width: 20%; height: 20%; float: left; text-align: center;">
			<asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" CellPadding="4"
				Font-Names="Arial" Font-Size="X-Small" ForeColor="#333333" DataKeyNames="id_contrato,nombre"
				GridLines="None" OnRowCommand="gr_dato_RowCommand"
				EnableModelValidation="True" OnSelectedIndexChanged="gr_dato_SelectedIndexChanged1" 
				CssClass="tabla">
				<RowStyle BackColor="#EFF3FB" />
				<Columns>
					<asp:BoundField AccessibleHeaderText="id_contrato" DataField="id_contrato" 
						FooterText="id_contrato" HeaderText="id_contrato" Visible="False" />
					<asp:BoundField AccessibleHeaderText="nombre" DataField="nombre" 
						FooterText="nombre" HeaderText="nombre" Visible="False" />
					<asp:ButtonField ButtonType="Link" AccessibleHeaderText="descripcion" DataTextField="descripcion"
						HeaderText="Contratos" CommandName="View" />
				</Columns>
			</asp:GridView>
		</div>
		
		<div style="height: 850px; width: 80%; float: right;">
			<iframe id="i_documento" frameborder="1" height="100%" width="100%" runat="server"
				scrolling="auto"></iframe>
		</div>
	</asp:Panel>
</asp:Content>
