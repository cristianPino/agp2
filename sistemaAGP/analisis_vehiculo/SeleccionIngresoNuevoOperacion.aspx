<%@ Page Title="" Language="C#" MasterPageFile="~/modal2.Master" AutoEventWireup="true" CodeBehind="SeleccionIngresoNuevoOperacion.aspx.cs" Inherits="sistemaAGP.analisis_vehiculo.SeleccionIngresoNuevoOperacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="divTituloModal">
        <img src="../../imagenes/sistema/static/panel_control/nominas.png" />
        <asp:Label ID="Label1" runat="server" Text="Ingreso Operación"></asp:Label>
    </div>
    <div style="clear:both"></div>
<br />
    <asp:Label ID="lblMensaje" runat="server" Text="Label"></asp:Label>
        
        <br />
        <asp:dropdownlist id="dlTipoOperacion" runat="server"></asp:dropdownlist>
        <br />
    <br />
    <br />
        <asp:imagebutton id="ibIr" ImageUrl="~/imagenes/sistema/static/hipotecario/avanzar.png"  runat="server" OnClick="ibIr_Click"></asp:imagebutton>
   
    <br />
    <asp:Panel ID="pnelAlto" runat="server">
        <asp:Image ID="imgAlto" runat="server" ImageUrl="../imagenes/sistema/static/hipotecario/monigote_alto.jpg" />
    </asp:Panel>

</asp:Content>
