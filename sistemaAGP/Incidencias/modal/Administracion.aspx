<%@ Page Title="" Language="C#" MasterPageFile="~/modal2.Master" AutoEventWireup="true" CodeBehind="Administracion.aspx.cs" Inherits="sistemaAGP.Incidencias.modal.Administracion" %>

<%@ Register Src="~/controles/wucIncidenciaCierre.ascx" TagName="cierre" TagPrefix="agp" %>
<%@ Register Src="~/controles/wucIncidenciaInicio.ascx" TagName="inicio" TagPrefix="agp" %>
<%@ Register Src="~/controles/wucIncidenciaComentario.ascx" TagName="cometario" TagPrefix="agp" %>
<%@ Register Src="~/controles/wucIncidenciaDocumentos.ascx" TagName="documento" TagPrefix="agp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <div class="divTituloModal">
        <img src="/imagenes/sistema/static/hipotecario/ajustes.png" />
        <asp:Label ID="Label1" runat="server" Text="Administración de incidencia"></asp:Label>
    </div>
    
    <div style="clear: both"></div>

    <br />
    <ajaxToolkit:TabContainer ID="tab_opciones" runat="server" Width="100%" ActiveTabIndex="0">       
        <ajaxToolkit:TabPanel ID="tab_inicio" runat="server" TabIndex="0" HeaderText="Inicio">
            <ContentTemplate>
                <asp:UpdatePanel ID="up_inicio" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                       
                    <agp:inicio ID="wucInicio" runat="server"></agp:inicio>
                    
            </ContentTemplate>
            </asp:UpdatePanel>            
            </ContentTemplate>
        </ajaxToolkit:TabPanel>

         <ajaxToolkit:TabPanel ID="tab_cierre" runat="server" TabIndex="1" HeaderText="Cierre">
            <ContentTemplate>
                <asp:UpdatePanel ID="up_cierre" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <agp:cierre ID="wucCierre" runat="server"></agp:cierre>
                    </ContentTemplate>
                </asp:UpdatePanel>
            
                </ContentTemplate>
                </ajaxToolkit:TabPanel>

 <ajaxToolkit:TabPanel ID="tab_comentario" runat="server" TabIndex="2" HeaderText="Comentarios">
            <ContentTemplate>                
                        <agp:cometario ID="wucComentario" runat="server"></agp:cometario>                              
            </ContentTemplate>
</ajaxToolkit:TabPanel>
 <ajaxToolkit:TabPanel ID="tab_documentos" runat="server" TabIndex="2" HeaderText="Documentos">
            <ContentTemplate>                
                        <agp:documento ID="wucDocumento" runat="server" PuedeModificar="true" ></agp:documento>                              
            </ContentTemplate>
</ajaxToolkit:TabPanel>

    </ajaxToolkit:TabContainer>

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
