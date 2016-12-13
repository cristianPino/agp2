<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucEjecutivoHipotecario.ascx.cs" Inherits="sistemaAGP.controles.wucEjecutivoHipotecario" %>
<%@ Register TagPrefix="cc1" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=3.5.40412.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>
<asp:UpdatePanel runat="server"
                    UpdateMode="Conditional"
                    ID="update1" >
        <ContentTemplate>
<asp:GridView runat="server"
                ID="grEjecutivoHipotecario"
                CssClass="tabla_datos"
                AutoGenerateColumns="False"
                DataKeyNames="id,idSolicitud" 
                onrowcommand="grEjecutivoHipotecario_RowCommand" 
                EnableModelValidation="True">
    <Columns>
           
            <asp:BoundField DataField="id"
                            HeaderText="Id">
                            <ItemStyle CssClass="td_derecha"  />
						    <HeaderStyle CssClass="td_cabecera" />
            </asp:BoundField>

            <asp:BoundField DataField="nombre"
                            HeaderText="Nombre">
                            <ItemStyle CssClass="td_derecha_grande"  />
						    <HeaderStyle CssClass="td_cabecera_grande" />
            </asp:BoundField>
            <asp:BoundField DataField="cliente"
                            HeaderText="cliente">
                            <ItemStyle CssClass="td_derecha_grande"  />
						    <HeaderStyle CssClass="td_cabecera_grande" />
            </asp:BoundField>
            <asp:BoundField DataField="sucursal"
                            HeaderText="Sucursal">
                            <ItemStyle CssClass="td_derecha_grande"  />
						    <HeaderStyle CssClass="td_cabecera_grande" />
            </asp:BoundField>
           
             <asp:TemplateField HeaderText="Correo">
							    <ItemTemplate>
                                    <asp:HyperLink ID="hpCorreo" runat="server" Text='<%# Bind("correo") %>' NavigateUrl='<%# Bind("correod") %>'></asp:HyperLink>
							    </ItemTemplate>
							    <ItemStyle CssClass="td_derecha_grande" />
								<HeaderStyle CssClass="td_derecha_grande" />
		  </asp:TemplateField>
           <asp:TemplateField HeaderText="Eliminar">
							    <ItemTemplate>
                                    <asp:ImageButton ID="ibEliminar" 
                                                        runat="server"
                                                        Height="32px" Width="32px"
                                                        ImageUrl="../imagenes/sistema/static/Rechazar.jpg" 
                                                        CommandName="Eliminar"  CommandArgument='<%#((GridViewRow)Container).RowIndex %>'
                                                        />
                                     <cc1:ConfirmButtonExtender  ID="ConfirmButtonExtender1" 
                           runat ="server" 
                           TargetControlID="ibEliminar"
                           
                           ConfirmText="¿Está seguro de eliminar este Ejecutivo de la operación?"/>
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

