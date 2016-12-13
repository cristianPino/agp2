<%@ Page Title="" Language="C#" MasterPageFile="~/AGP.Master" AutoEventWireup="true" CodeBehind="mConservadores.aspx.cs" Inherits="sistemaAGP.administracion.mConservadores" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMenu" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoCentral" runat="server">
    <script type="text/javascript" src="../jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="../jquery.mousewheel-3.0.6.pack.js"></script>
    <script type="text/javascript" src="../jquery.fancybox.js?v=2.0.6"></script>
    <link rel="Stylesheet" type="text/css" href="../jquery.fancybox.css?v=2.0.6" media="screen" />

	<script type="text/javascript">
	    $(document).ready(function () {
	        $('.fancybox').fancybox({
	            maxWidth: 800,
	            maxHeight: 800,
	            fitToView: true,
	            width: 800,
	            height: 800,
	            autoSize: true,
	            openEffect: 'elastic',
	            openSpeed: 150,
	            closeEffect: 'elastic',
	            closeSpeed: 150,
	            closeClick: false,
	            closeBtn: true,
	            scrolling: 'auto',
	            padding: 5,
	            helpers: {
	                overlay: {
	                    opacity: 0.5,
	                    css: {
	                        'background-color': 'Gray'
	                    }
	                }
	            }
	        });
	    });
	</script>

    <div class="subtitulo" style="width: 80%">
        <asp:Label ID="Label1" runat="server" Text="Administración de Conservadores de Bienes Raíces"></asp:Label>
    </div>

    <table class="table">
        <tr>
            <td>
                <asp:Label ID="lblIdConservador" 
                            runat="server" 
                            Text="0" 
                            Visible="False"/>
                            Descripción
            </td>
            <td>
                <asp:TextBox ID="txtDescripcion" 
                            runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                            runat="server" 
                            ErrorMessage="Nombre es requerido"
                            ControlToValidate="txtDescripcion"
                            ValidationGroup="insert" ></asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="button"  
                    ValidationGroup="insert" onclick="btnAgregar_Click"/>
                     <ajaxToolkit:ConfirmButtonExtender ID="Button1_ConfirmButtonExtender" runat="server" TargetControlID="btnAgregar"
                        ConfirmText="¿Esta seguro de guardar un nuevo Conservador?" >
                    </ajaxToolkit:ConfirmButtonExtender>  
            </td>
        </tr>
    </table>
    <asp:UpdatePanel runat="server" ID="updateGrilla" UpdateMode="Conditional">
    <ContentTemplate>
    <asp:GridView runat="server" 
                ID="grConcervador"
                CssClass="tabla_datos"
                AutoGenerateColumns="False" 
                EnableModelValidation="True"
                DataKeyNames="idConservador" 
                onrowediting="grConcervador_RowEditing" 
                onrowcancelingedit="grConcervador_RowCancelingEdit" 
                onrowupdating="grConcervador_RowUpdating">
                <Columns>
                    <asp:TemplateField HeaderText="Id">
							    <ItemTemplate>
								    <asp:HyperLink ID="id"   AccessibleHeaderText="id" runat="server" Text='<%# Bind("idConservador") %>' />
							    </ItemTemplate>
							           <ItemStyle CssClass="td_derecha_mediana_2" />
									<HeaderStyle CssClass="td_cabecera_mediana_2" />
					</asp:TemplateField>

                    <asp:BoundField DataField="descripcion"
                                    HeaderText="Descripcion"
                                    AccessibleHeaderText="descripcion"
                                     >
                                  <ItemStyle CssClass="td_derecha_grande"  />
								  <HeaderStyle CssClass="td_cabecera_grande" />
                    </asp:BoundField>
                                  
                    <asp:ButtonField ButtonType="Image" 
                                    CommandName="Edit" 
                                    HeaderText="Editar"
                                    AccessibleHeaderText="editar" 
                                    ImageUrl="~/imagenes/sistema/static/edit.png"
                                    ShowHeader="True" >
                                  <ItemStyle CssClass="td_derecha"  />
								  <HeaderStyle CssClass="td_cabecera" />
                    </asp:ButtonField>
                    
                    <asp:ButtonField ButtonType="Image" CommandName="Cancel" HeaderText="Cancelar " 
                        ImageUrl="~/imagenes/sistema/static/109_AllAnnotations_Error_16x16_72.png" 
                        ShowHeader="True" Text="cancelar" />
                    <asp:ButtonField ButtonType="Image" CommandName="Update" 
                        HeaderText="Actualizar" 
                        ImageUrl="~/imagenes/sistema/static/109_AllAnnotations_Default_16x16_72.png" 
                        ShowHeader="True" Text="Actualizar" />
                    
                    <asp:TemplateField HeaderText="Comunas">
							    <ItemTemplate>
								    <asp:HyperLink ID="modulos" runat="server"  data-fancybox-type="iframe" CssClass="fancybox fancybox.iframe" ToolTip="Comunas"	ImageUrl="../imagenes/sistema/static/panel_control/nominas.png" NavigateUrl='<%# Bind("urlComunas") %>' />
							    </ItemTemplate>
							           <ItemStyle CssClass="td_derecha_mediana_2" />
									<HeaderStyle CssClass="td_cabecera_mediana_2" />
					</asp:TemplateField>
                </Columns>  
                        <HeaderStyle CssClass="tr_cabecera" />
						<RowStyle CssClass="tr_fila" />
						<AlternatingRowStyle CssClass="tr_fila_alt" />      
    </asp:GridView>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
