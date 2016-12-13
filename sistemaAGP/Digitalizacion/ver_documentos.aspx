<%@ Page Title="Ver documentos" Language="C#" MasterPageFile="~/Adm.Master" AutoEventWireup="true" CodeBehind="ver_documentos.aspx.cs" Inherits="sistemaAGP.digitalizacion.ver_documentos" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<style type="text/css">
		.centrado {
			text-align: center;
			margin: 0 auto 0 auto;
		}
		
		.panel {
			margin: 0;
			padding: 0;
		}
		
		.mensaje {
			color: #ff0000;
			text-align: center;
			font-size: 20px;
			position: absolute;
			height: 200px;
			width: 400px;
			top: 50%;
			left: 50%;
			margin-top: -100px;
			margin-left: -200px;
		}
		
		.grilla {
			overflow: auto;
			height: 40%;
			width: 95%;
		}
	</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<asp:updatepanel id="up_datos" runat="server">
		<contenttemplate>
	<asp:Panel ID="divGrilla" runat="server" CssClass="panel">
		<asp:TabContainer ID="tabDocs" runat="server" AutoPostBack="true" 
			Style="margin: 0 auto 0 auto;" Width="100%" 
			OnActiveTabChanged="tabDocs_ActiveTabChanged" ActiveTabIndex="0" 
			ScrollBars="Auto">
			<asp:TabPanel ID="tabOperacion" runat="server" HeaderText="Documentos Operación" Width="100%">
				<ContentTemplate>
					<asp:GridView ID="gr_documentos" runat="server" AutoGenerateColumns="False" 
						CellPadding="4" Font-Names="Arial" Font-Size="X-Small" ForeColor="#333333" 
						DataKeyNames="id_documento_operacion,id_solicitud,id_documento,url" 
						GridLines="None" Width="100%" OnRowCommand="gr_documentos_RowCommand" 
						EnableModelValidation="True" ><Columns>
<asp:ButtonField AccessibleHeaderText="nombre" CommandName="View" DataTextField="nombre" 
													HeaderText="Archivo" />
<asp:BoundField AccessibleHeaderText="extension" DataField="extension" HeaderText="Extensión">
<ItemStyle Width="50px" />
</asp:BoundField>
<asp:BoundField AccessibleHeaderText="peso" DataField="peso" HeaderText="Tamaño">
<ItemStyle Width="50px" />
</asp:BoundField>
<asp:BoundField AccessibleHeaderText="observaciones" DataField="observaciones" HeaderText="Observaciones">
<ItemStyle Width="200px" />
</asp:BoundField>
<asp:TemplateField AccessibleHeaderText="eliminar" HeaderText="Eliminar"><ItemTemplate>
	<%if(origen != "pc"){%> 
	<asp:CheckBox ID="chk_eliminar" runat="server" Checked="false" visible="False" />	
	<%}else{%>
	 <asp:CheckBox ID="chk_eliminar2" runat="server" Checked="false" visible="True" />
	     <%}%> 
</ItemTemplate>

<ItemStyle Width="50px" />
</asp:TemplateField>
</Columns>

<RowStyle BackColor="#EFF3FB" />
</asp:GridView>

					<asp:Panel ID="divBoton" runat="server" CssClass="centrado">
						<asp:Button ID="bt_eliminar" runat="server" 
							Text="Eliminar los documentos seleccionados" OnClick="bt_eliminar_Click" ></asp:Button>



						<asp:ConfirmButtonExtender ID="cb_eliminar" runat="server" 
							ConfirmText="¿Desea eliminar los archivos marcados?" 
							TargetControlID="bt_eliminar" Enabled="True" ></asp:ConfirmButtonExtender>


</asp:Panel>

</ContentTemplate>


</asp:TabPanel>
			<asp:TabPanel ID="tabAsociados" runat="server" HeaderText="Documentos Asociados" Width="100%" Visible="false">
				<ContentTemplate>
					<asp:GridView ID="gr_asociados" runat="server" AutoGenerateColumns="false" CellPadding="4" Font-Names="Arial" 
					Font-Size="X-Small" ForeColor="#333333" DataKeyNames="id_documento_operacion,id_solicitud,id_documento,url" 
					GridLines="None" Width="100%" OnRowCommand="gr_asociados_RowCommand" Visible="false">
						<RowStyle BackColor="#EFF3FB" />
						<Columns>
							<asp:BoundField AccessibleHeaderText="id_solicitud" HeaderText="Id.Solicitud" DataField="id_solicitud" ItemStyle-Width="50px" />
							<asp:ButtonField ButtonType="Link" AccessibleHeaderText="nombre" DataTextField="nombre" HeaderText="Archivo" CommandName="View" />
							<asp:BoundField AccessibleHeaderText="extension" DataField="extension" HeaderText="Extensión" ItemStyle-Width="50px" />
							<asp:BoundField AccessibleHeaderText="peso" DataField="peso" HeaderText="Tamaño" ItemStyle-Width="50px" />
							<asp:BoundField AccessibleHeaderText="observaciones" DataField="observaciones" HeaderText="Observaciones" ItemStyle-Width="200px" />
						</Columns>
					</asp:GridView>
				
</ContentTemplate>
			


</asp:TabPanel>
		</asp:TabContainer>
		<div class="centrado">
			&nbsp;
		</div>
		<div class="centrado">
			<iframe id="i_documento" frameborder="1" height="400px" width="95%" runat="server" scrolling="auto"></iframe>
		</div>
	</asp:Panel>
	
	</contenttemplate>
	</asp:updatepanel>
</asp:Content>