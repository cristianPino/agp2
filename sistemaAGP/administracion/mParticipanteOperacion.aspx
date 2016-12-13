<%@ Page Title="" Language="C#" MasterPageFile="~/Adm.Master" AutoEventWireup="true" CodeBehind="mParticipanteOperacion.aspx.cs" Inherits="sistemaAGP.administracion.mParticipanteOperacion" %>
<%@ Register Src="~/controles/wucPersonaTransferencia.ascx" TagName="DatosPersona" TagPrefix="agp" %>
<%@ Register Src="~/controles/wucOperacionParticipe.ascx" TagName="ParticipanteOperacion" TagPrefix="agp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
    <asp:UpdatePanel runat="server" ID="updatePanelIngreso">
        <ContentTemplate>
            
            <div class="subtitulo">
                PARTICIPANTES DE LA OPERACION
            </div>
            <br/>
    <table class="table">
        <tr>
            <td>
                Tipo Participante
            </td>
            <td>
                <asp:DropDownList ID="dlTipo" runat="server">
                </asp:DropDownList>
            </td>
            <td>
                <asp:Button ID="btnAgregar" runat="server" CssClass="button" Text="Agregar" 
                    onclick="btnAgregar_Click" />
            </td>
        </tr>
    </table>
    <br/>
    <agp:DatosPersona ID="DatosParticipante" runat="server" Titulo="DATOS DEL PARTICIPANTE" HabilitarCompraPara="false" />
    <br/>
    <agp:ParticipanteOperacion ID="Participante" runat="server" />
    
           </ContentTemplate>
    </asp:UpdatePanel>

   
</asp:Content>
