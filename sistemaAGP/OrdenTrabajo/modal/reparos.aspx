<%@ Page Title="" Language="C#" MasterPageFile="~/Adm.Master" AutoEventWireup="true" CodeBehind="reparos.aspx.cs" Inherits="sistemaAGP.OrdenTrabajo.modal.reparos" %>
<%@ Register TagPrefix="cc1" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=3.5.40412.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>
<%@ Register Src="~/controles/mensajeOt.ascx" TagName="mensajes" TagPrefix="mens" %>
<%@ Register Src="~/controles/wucOtPropiedades.ascx" TagName="propiedades" TagPrefix="prop" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="../../jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="../../jquery.mousewheel-3.0.6.pack.js"></script>
    <script type="text/javascript" src="../../jquery.fancybox.js?v=2.0.6"></script>
    <link rel="Stylesheet" type="text/css" href="../../jquery.fancybox.css?v=2.0.6" media="screen" />
    <script type="text/javascript" src="../../javascript/ScrollableGrid.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="subtitulo">
        REPAROS
    </div>
    <br/>
    <asp:UpdatePanel ID="upd" runat="server" UpdateMode="Conditional" >
    <ContentTemplate>
  

        <table class="tabla_datos">
            <tr class="tr_fila">
                <td>
                    Clasificación del Reparo
                </td>
                <td style="font-weight: bold">
                    <asp:Label ID="lblTipoReparo" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                    Ente Responsable
                </td>
                <td  style="font-weight: bold">
                    <asp:Label ID="lblParametroTipoResponsable" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                    Tiempo Transcurrido (lab)
                </td>
                <td style="font-weight: bold">
                    <asp:Label ID="lblTiempo" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                    Semaforo
                </td>
                <td>
                    <asp:Image ID="imgSemaforo" runat="server" />
                </td>
            </tr>
             <tr class="tr_fila">
                <td>
                    Fecha de ingreso Reparo
                </td>
                <td  style="font-weight: bold">
                    <asp:Label ID="lblFechaIngreso" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                    Sla para Subsanar (lab)
                </td>
                <td  style="font-weight: bold">
                    <asp:Label ID="lblSla" runat="server" Text="Label"></asp:Label>
                </td>
           
                <td>
                    Usuario Ingresador Reparo
                </td>
                <td  style="font-weight: bold">
                    <asp:Label ID="lblUsuarioIngresoReparo" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                    Usuario Responsable Subsano
                </td>
                <td  style="font-weight: bold">
                    <asp:Label ID="lblUsuarioResponsable" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr class="tr_fila">
                 <td>
                    Estado
                </td>
                <td  style="font-weight: bold">
                    <asp:Label ID="lblEstadoReparo" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
             <tr class="tr_fila">
                <td colspan="8" style="font-weight: bold">
                <center>   Observación al momento de ingresar el reparo </center> 
                </td>
            </tr>
             <tr class="tr_fila">
                <td colspan="8" style="color: cornflowerblue; font-style: italic; font-weight: bold" >
                <center>    <asp:Label ID="lblObservacion" runat="server" Text="Label"></asp:Label> </center>
                </td>
            </tr>
            <tr class="tr_fila">
                <td colspan="8"  style="font-weight: bold">
                  <center>  <asp:Button ID="btnSubsano" runat="server" CssClass="button" Text="Subsanar" 
                        onclick="btnSubsano_Click" /></center> 
                </td>
            </tr>
        </table>
        <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" ConfirmText="Esta acción marcará como subsanado el reparo y avanzará el pre-ticket. ¿Desea Continuar?"
                                    TargetControlID="btnSubsano">
                                </cc1:ConfirmButtonExtender>
                                
     
     <cc1:TabContainer ID="tab_opciones" runat="server" Width="100%" ActiveTabIndex="7"
                ScrollBars="Auto">
         <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="Mensajes">
                    <HeaderTemplate>
                        Propiedades
                    </HeaderTemplate>

                    <ContentTemplate>
                                  <prop:propiedades ID="PropiedadesOt" runat="server"></prop:propiedades>   
                    </ContentTemplate>  
                
                    </cc1:TabPanel>
                <cc1:TabPanel ID="tab_cliente" runat="server" HeaderText="Mensajes">
                    <HeaderTemplate>
                        Mensajes
                    </HeaderTemplate>

                    <ContentTemplate>
                                <mens:mensajes ID="mensajes1" runat="server"></mens:mensajes>   
                    </ContentTemplate>  
                
                    </cc1:TabPanel>
                     <cc1:TabPanel ID="TabPanel1" runat="server" HeaderText="Mensajes">
                    <HeaderTemplate>
                        Historial de Reparos
                    </HeaderTemplate>

                    <ContentTemplate>
                                  <asp:GridView ID="grHistorial" runat="server" AutoGenerateColumns="False" CssClass="tabla_datos"
				DataKeyNames="id_reparo" >				
				<Columns>
				   <asp:TemplateField HeaderText="Tipo Reparo">
						<ItemTemplate>
							<asp:HyperLink ID="hltipoReparo" runat="server" data-title-id="title-Tasador"
								Text='<%# Bind("tipo_reparo") %>'/>
						</ItemTemplate>
						 <ItemStyle CssClass="td_derecha_grandexl"  />
					<HeaderStyle CssClass="td_cabecera_grandexl" />                
					</asp:TemplateField>

                    <asp:BoundField DataField="usuarioIngreso" HeaderText="Usuario ingreso" >
                     <ItemStyle CssClass="td_derecha_grande"  />
					<HeaderStyle CssClass="td_cabecera_grande" />
                    </asp:BoundField>

					<asp:BoundField DataField="inicio" HeaderText="Inicio" >
                     <ItemStyle CssClass="td_derecha_grande"  />
					<HeaderStyle CssClass="td_cabecera_grande" />
                    </asp:BoundField>
                    
                    <asp:BoundField DataField="termino" HeaderText="Termino" >
                     <ItemStyle CssClass="td_derecha_grande"  />
					<HeaderStyle CssClass="td_cabecera_grande" />
                    </asp:BoundField>
                    
                    <asp:BoundField DataField="sla" HeaderText="Sla" >
                     <ItemStyle CssClass="td_derecha_mediana_2"  />
					<HeaderStyle CssClass="td_derecha_mediana_2" />
                    </asp:BoundField>
                    
                    <asp:BoundField DataField="horas" HeaderText="Hrs Lab" >
                     <ItemStyle CssClass="td_derecha_mediana_2"  />
					<HeaderStyle CssClass="td_derecha_mediana_2" />
                    </asp:BoundField>

                    <asp:TemplateField HeaderText="Smfro">
						<ItemTemplate>
							<asp:HyperLink ID="lnk_estado" 
                                        runat="server"
                                        ImageUrl='<%# Bind("semaforo") %>' />
						</ItemTemplate>
						 <ItemStyle CssClass="td_derecha_mediana_2"  />
					    <HeaderStyle CssClass="td_derecha_mediana_2" />                 
					</asp:TemplateField>
				</Columns>
				 <HeaderStyle CssClass="tr_cabecera" />
				<RowStyle CssClass="tr_fila" />
				<AlternatingRowStyle CssClass="tr_fila_alt" />   
			</asp:GridView>
                    </ContentTemplate>  
                
                    </cc1:TabPanel>
   </cc1:TabContainer>
           
    
       
     
         
     </ContentTemplate>
    </asp:UpdatePanel>
    <asp:HiddenField ID="hdIdOrdenTrabajo" runat="server" />
    <asp:HiddenField ID="hdIdReparo" runat="server" />
    <asp:HiddenField ID="hdIdOrdenTrabajoActividad" runat="server" />
</asp:Content>

