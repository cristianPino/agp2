<%@ Page Title="" Language="C#" MasterPageFile="~/AGP.Master" AutoEventWireup="true" CodeBehind="mDocumentoCambioEstado.aspx.cs" Inherits="sistemaAGP.administracion.mDocumentoCambioEstado" %>
<%@ Register TagPrefix="cc1" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=3.5.40412.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMenu" runat="server">
     <script type="text/javascript" src="../javascript/ScrollableGrid.js"></script>
    <script type="text/javascript">
        function grilla_cabecera() {
            $('#<%=gr_documentos.ClientID %>').Scrollable();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoCentral" runat="server">
    <div class="subtitulo" style="width: 50%">
        <asp:Image ID="Image1" runat="server" 
                        ImageUrl="../imagenes/sistema/static/panel_control/poliza.png" 
                        Height="34px" 
                        Width="37px" />
        &nbsp;<asp:Label ID="lbl_titulo" runat="server" Text="DOCUMENTO & CAMBIO ESTADO"></asp:Label>
    </div>
    <br/>
    <asp:UpdatePanel runat="server" ID="updateP" UpdateMode="Conditional" OnLoad="updateP_Load">
        <ContentTemplate>
            <table class="table">
                <tr>
                    <td> Clientes</td>
                    <td>
                        <asp:DropDownList ID="dlClientes" runat="server" AutoPostBack="True"
                            onselectedindexchanged="dlClientes_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td>Familia</td>
                    <td>
                        <asp:DropDownList ID="dlFamilia" runat="server" AutoPostBack="True"
                            onselectedindexchanged="dlFamilia_SelectedIndexChanged">
                        </asp:DropDownList>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="dlFamilia" 
                            ErrorMessage="Seleccione una familia" InitialValue="0" Display="Dynamic" ValidationGroup="add"/>
                    </td>
                </tr>
            </table>
            <br/>

            <asp:GridView ID="gr_documentos" runat="server" AutoGenerateColumns="False" 
						CssClass="tabla_datos" 
						DataKeyNames="idDocumento,idCliente,idFamilia,codigoSiguienteEstado" 
						GridLines="None" 
                        OnRowDataBound="gr_dato_RowDataBound"
						EnableModelValidation="True">
                <Columns>
                <asp:ButtonField AccessibleHeaderText="nombre" 
                                                CommandName="View" 
                                                DataTextField="nombre" 
												HeaderText="Documento">
                                                <ItemStyle CssClass="td_derecha_grande"  />
					                            <HeaderStyle CssClass="td_cabecera_grande" /> 
                </asp:ButtonField>

                <asp:TemplateField AccessibleHeaderText="eliminar" HeaderText="Siguiente estado">
                <ItemTemplate>
                    <asp:DropDownList ID="dlEstados" runat="server" Width="100%">
                    </asp:DropDownList>
	            </ItemTemplate>
                            <ItemStyle CssClass="td_derecha_grande"  />
				            <HeaderStyle CssClass="td_cabecera_grande" />
                </asp:TemplateField>
                </Columns>

                <HeaderStyle CssClass="tr_cabecera" />
				<RowStyle CssClass="tr_fila" />
				<AlternatingRowStyle CssClass="tr_fila_alt" />
            </asp:GridView>
             </ContentTemplate>
    </asp:UpdatePanel>
    <br/>
    <table class="table">
        <tr>
            <td>
                <asp:Button ID="btnAgregar" runat="server" Text="Guardar cambios" ValidationGroup="add" 
                    CssClass="button" onclick="btnAgregar_Click" />
                     <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="btnAgregar" ConfirmText="¿Está seguro de guardar los cambios?" />
            </td>
        </tr>
    </table>
</asp:Content>
