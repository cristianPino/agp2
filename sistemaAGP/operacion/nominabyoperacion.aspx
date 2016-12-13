<%@ Page Title="Analisis estado" Language="C#" MasterPageFile="~/Modal.Master" AutoEventWireup="true" CodeBehind="nominabyoperacion.aspx.cs" Inherits="sistemaAGP.nominabyoperacion" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
	<table class="tabla-titulo">
		<tr>
			<td>
				NOMINAS ASOCIADAS A LA OPERACIÓN
			</td>
		</tr>
	</table>
    <asp:UpdatePanel ID="up_grilla" runat="server">
        <ContentTemplate>
            <asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" CellPadding="4"
				DataKeyNames="id_nomina" Font-Names="Arial" Font-Size="X-Small" ForeColor="#333333"
				GridLines="None" Width="100%" OnSelectedIndexChanged="gr_dato_SelectedIndexChanged"
				OnRowDeleting="gr_dato_RowDeleting">
		<RowStyle BackColor="#EFF3FB" />
		<Columns>
			<asp:BoundField DataField="id_nomina" HeaderText="id_nomina" Visible="False" />
			<asp:BoundField AccessibleHeaderText="descripcion" DataField="descripcion" HeaderText="Nómina" />
			<%--<asp:BoundField AccessibleHeaderText="folio" DataField="folio" HeaderText="Folio" />--%>
			<asp:HyperLinkField HeaderText="Folio" DataNavigateUrlFields="reporte_url" DataTextField="folio" DataTextFormatString="{0:N0}" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="75px" Target="_blank" />
		    <asp:TemplateField AccessibleHeaderText="del" HeaderText="Eliminar">
			    <ItemTemplate>
				    <asp:ImageButton ID="bt_eliminar" runat="server" CausesValidation="false" CommandName="Delete"  ImageAlign="AbsMiddle" ImageUrl="~/imagenes/sistema/static/panel_control/eliminar.png" />
					    <cc1:ConfirmButtonExtender ID="cfe_eliminar" runat="server" ConfirmText="¿Está seguro de eliminar la Operacion de la Nomina?" TargetControlID="bt_eliminar"></cc1:ConfirmButtonExtender>
				</ItemTemplate>
				<ControlStyle Font-Size="X-Small" />
                <ItemStyle HorizontalAlign="Center" />			
            </asp:TemplateField>
        </Columns>
		<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
		<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
		<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
		<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
		<EditRowStyle BackColor="#2461BF" />
		<AlternatingRowStyle BackColor="White" />
	</asp:GridView>    
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>