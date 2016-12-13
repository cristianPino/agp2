<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucOperacionParticipe.ascx.cs" Inherits="sistemaAGP.controles.wucOperacionParticipe" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<script type="text/javascript">
    $.ajaxSetup({ cache: false });

    $(document).ready(function () {

        $("a.fancybox").fancybox({
            autoDimensions: true,
            width: '90%',
            height: '90%',
            openEffect: 'elastic',
            closeEffect: 'elastic',
            fitToView: false,
            nextSpeed: 0, //important
            prevSpeed: 0, //important  
            beforeShow: function () {
                // added 50px to avoid scrollbars inside fancybox
                this.width = ($('.fancybox-iframe').contents().find('html').width());
                this.height = ($('.fancybox-iframe').contents().find('html').height());
            },

            afterClose: function () {
                //refresco la grilla de panel de control
                
            }

        });
    });
 
     </script>
<asp:UpdatePanel runat="server"
                    UpdateMode="Conditional"
                    ID="update1" >
        <ContentTemplate>
<asp:GridView runat="server"
                ID="grOperacionParticipe"
                CssClass="tabla_datos"
                AutoGenerateColumns="False"
                DataKeyNames="rut,tipo,id_solicitud,busqueda" 
                onrowcommand="grOperacionParticipe_RowCommand" 
                EnableModelValidation="True">
    <Columns>
           
            <asp:BoundField DataField="rut"
                            HeaderText="Rut">
                            <ItemStyle CssClass="td_derecha"  />
						    <HeaderStyle CssClass="td_cabecera" />
            </asp:BoundField>

            <asp:BoundField DataField="nombre"
                            HeaderText="Nombre">
                            <ItemStyle CssClass="td_derecha_grande"  />
						    <HeaderStyle CssClass="td_cabecera_grande" />
            </asp:BoundField>
            <asp:BoundField DataField="tipo_descripcion"
                            HeaderText="Tipo">
                            <ItemStyle CssClass="td_derecha_grande"  />
						    <HeaderStyle CssClass="td_cabecera_grande" />
            </asp:BoundField>
           <asp:TemplateField HeaderText="">
							    <ItemTemplate>
								    <asp:HyperLink ID="hlContacto" 
                                                    ImageUrl="../imagenes/sistema/static/telefono.jpg" 
                                                    Height="32px" Width="32px"
                                                    runat="server"
                                                    class="fancybox fancybox.iframe" 
                                                    NavigateUrl='<%# Bind("url_contactos") %>' />
							    </ItemTemplate>
							    <ItemStyle CssClass="td_derecha_mediana_2" Height="32px" Width="32px" />
								<ControlStyle Height="32px" Width="32px" />
								<HeaderStyle CssClass="td_cabecera_mediana_2" />
		  </asp:TemplateField>
          <asp:TemplateField HeaderText="">
							    <ItemTemplate>
								    <asp:HyperLink ID="hlCorreo" 
                                                    ImageUrl="../imagenes/sistema/static/mail_icono.jpg" 
                                                    Height="32px" Width="32px"  
                                                    runat="server" 
                                                    class="fancybox fancybox.iframe"
                                                    NavigateUrl='<%# Bind("url_correos") %>' />
							    </ItemTemplate>
							    <ItemStyle CssClass="td_derecha_mediana_2" Height="32px" Width="32px" />
								<ControlStyle Height="32px" Width="32px" />
								<HeaderStyle CssClass="td_cabecera_mediana_2" />
		  </asp:TemplateField>
          <asp:TemplateField HeaderText="">
							    <ItemTemplate>
								    <asp:HyperLink ID="hlDireccion" 
                                                    ImageUrl="../imagenes/sistema/static/direccion_icono.jpg"
                                                    Height="32px" Width="32px"
                                                    class="fancybox fancybox.iframe"  
                                                    runat="server" 
                                                    NavigateUrl='<%# Bind("url_direcciones") %>' />
							    </ItemTemplate>
							    <ItemStyle CssClass="td_derecha_mediana_2" Height="32px" Width="32px" />
								<ControlStyle Height="32px" Width="32px" />
								<HeaderStyle CssClass="td_cabecera_mediana_2" />
		  </asp:TemplateField>
          <asp:TemplateField HeaderText="">
							    <ItemTemplate>
								    <asp:HyperLink ID="hlRepresentantes" 
                                                    ImageUrl="../imagenes/sistema/icono001.gif"
                                                    Height="32px" Width="32px"
                                                    class="fancybox fancybox.iframe"   
                                                    runat="server" 
                                                    NavigateUrl='<%# Bind("url_representantes") %>' />
							    </ItemTemplate>
							    <ItemStyle CssClass="td_derecha_mediana_2" Height="32px" Width="32px" />
								<ControlStyle Height="32px" Width="32px" />
								<HeaderStyle CssClass="td_cabecera_mediana_2" />
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
                           
                           ConfirmText="¿Esta seguro de eliminar este participante?"/>
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
