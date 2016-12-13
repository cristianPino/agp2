<%@ Page Title="" Language="C#" MasterPageFile="~/Adm.Master" AutoEventWireup="true" CodeBehind="Flujo.aspx.cs" Inherits="sistemaAGP.OrdenTrabajo.modal.Flujo" %>
<%@ Register TagPrefix="cc1" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=3.5.40412.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript" src="../../jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="../../jquery.mousewheel-3.0.6.pack.js"></script>
    <script type="text/javascript" src="../../jquery.fancybox.js?v=2.0.6"></script>
    <link rel="Stylesheet" type="text/css" href="../../jquery.fancybox.css?v=2.0.6" media="screen" />
    <script type="text/javascript" src="../../javascript/ScrollableGrid.js"></script>
    
    <script type="text/javascript">
         $("a.fancybox").fancybox({
             maxWidth: 800,
             maxHeight: 500,
             minWidth: 800,
             minHeight: 500,
             autoDimensions: true,
             openEffect: 'elastic',
             closeEffect: 'elastic',
             fitToView: false,
             nextSpeed: 0, //important
             prevSpeed: 0, //important  
             beforeShow: function () {
                 // added 50px to avoid scrollbars inside fancybox
                 this.width = ($('.fancybox-iframe').contents().find('html').width());
                 this.height = ($('.fancybox-iframe').contents().find('html').height());
             }


         });
   </script>

     <div class="subtitulo">
        HISTORIAL
    </div>
    <br/>
    <asp:UpdatePanel ID="upd" runat="server" UpdateMode="Conditional"  >
    <ContentTemplate>
<asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" CssClass="tabla_datos"
				DataKeyNames="idActividad,idUsuario,idOtAct,idOt" >				
				<Columns>
				   <asp:TemplateField HeaderText="Actividad">
						<ItemTemplate>
							<asp:HyperLink ID="numCli" runat="server" data-title-id="title-Tasador"
								Text='<%# Bind("actividad") %>'/>
						</ItemTemplate>
						 <ItemStyle CssClass="td_derecha_grande"  />
					<HeaderStyle CssClass="td_cabecera_grande" />                
					</asp:TemplateField>

                    <asp:BoundField DataField="usuario" HeaderText="Usuario" >
                     <ItemStyle CssClass="td_derecha_grande"  />
					<HeaderStyle CssClass="td_cabecera_grande" />
                    </asp:BoundField>

					<asp:BoundField DataField="inicio" HeaderText="Inicio" >
                     <ItemStyle CssClass="td_derecha"  />
					<HeaderStyle CssClass="td_cabecera" />
                    </asp:BoundField>
                    
                    <asp:BoundField DataField="termino" HeaderText="Termino" >
                     <ItemStyle CssClass="td_derecha"  />
					<HeaderStyle CssClass="td_cabecera" />
                    </asp:BoundField>
                    
                    <asp:BoundField DataField="sla" HeaderText="Sla" >
                     <ItemStyle CssClass="td_derecha_mediana_2"  />
					<HeaderStyle CssClass="td_derecha_mediana_2" />
                    </asp:BoundField>
                    
                    <asp:BoundField DataField="horas" HeaderText="Hrs Lab" >
                     <ItemStyle CssClass="td_derecha_mediana_2"  />
					<HeaderStyle CssClass="td_derecha_mediana_2" />
                    </asp:BoundField>

                    <asp:TemplateField HeaderText="Semáforo">
						<ItemTemplate>
							<asp:HyperLink ID="lnk_estado" 
                                        runat="server"
                                        ImageUrl='<%# Bind("semaforo") %>' />
						</ItemTemplate>
						 <ItemStyle CssClass="td_derecha_mediana_2"  />
					    <HeaderStyle CssClass="td_derecha_mediana_2" />                 
					</asp:TemplateField>
                    
                      <asp:TemplateField HeaderText="Flujo">
						<ItemTemplate>
							<asp:HyperLink ID="lnk_Estados" runat="server"
								 ImageUrl='<%# Bind("flujo") %>'  />
						</ItemTemplate>
						 <ItemStyle CssClass="td_derecha_mediana_2"  />
					<HeaderStyle CssClass="td_derecha_mediana_2" />                
					</asp:TemplateField>
				</Columns>
				 <HeaderStyle CssClass="tr_cabecera" />
				<RowStyle CssClass="tr_fila" />
				<AlternatingRowStyle CssClass="tr_fila_alt" />   
			</asp:GridView>
            
            <br/>
            <asp:GridView ID="grOperacion" runat="server" AutoGenerateColumns="False" CssClass="tabla_datos">				
				<Columns>
				   <asp:TemplateField HeaderText="Productos" HeaderImageUrl="../../imagenes/sistema/static/hipotecario/comprador.png">
						<ItemTemplate>
							<asp:HyperLink ID="numCli" runat="server" Text='<%# Bind("Producto") %>'/>
						</ItemTemplate>
						 <ItemStyle CssClass="td_derecha_grandexl"  />
					<HeaderStyle CssClass="td_cabecera_grandexl" />                
					</asp:TemplateField>
                     <asp:TemplateField HeaderText="Operación AGP" >
						<ItemTemplate>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Bind("urlEstadoOperacion") %>'  class="fancybox fancybox.iframe" ToolTip="Estado Operación"  Text='<%# Bind("idSolicitud") %>'/>
				</ItemTemplate>
						 <ItemStyle CssClass="td_derecha_grandexl"  />
					<HeaderStyle CssClass="td_cabecera_grandexl" />                
					</asp:TemplateField>
                </Columns>
				 <HeaderStyle CssClass="tr_cabecera" />
				<RowStyle CssClass="tr_fila" />
				<AlternatingRowStyle CssClass="tr_fila_alt" />   
			</asp:GridView>
        </ContentTemplate>
         
            
</asp:UpdatePanel>
     <div class="divInfo" style="clear: both" id="divInfo" runat="server">
        <center>
            <table>
                <tr>
                    <td>
                        <asp:ImageButton ID="ibSalir" runat="server" ImageUrl="~/imagenes/sistema/static/hipotecario/salir.png"
                            OnClick="ibSalir_Click" />
                    </td>
                </tr>
            </table>
        </center>
    </div>
</asp:Content>
