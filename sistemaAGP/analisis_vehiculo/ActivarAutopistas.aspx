<%@ Page Title="" Language="C#" MasterPageFile="~/modal2.Master" AutoEventWireup="true" CodeBehind="ActivarAutopistas.aspx.cs" Inherits="sistemaAGP.analisis_vehiculo.ActivarAutopistas" %>

<%@ Register TagPrefix="cc1" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=3.5.40412.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="~/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="~/jquery.mousewheel-3.0.6.pack.js"></script>
    <script type="text/javascript" src="~/jquery.fancybox.js?v=2.0.6"></script>
    <link rel="Stylesheet" type="text/css" href="~/jquery.fancybox.css?v=2.0.6" media="screen" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="divTituloModal">
        <img src="../imagenes/sistema/static/hipotecario/up.png" />
        <asp:Label ID="lblTitulo" runat="server" Text="Estado Páginas Autopistas"></asp:Label>
    </div>
    <div style="clear: both">
        <asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" CssClass="tabla_datos" DataKeyNames="id_dicom_vehiculo_pasos,descripcion,estado">
            <Columns>
                <asp:TemplateField HeaderText="Id">
                    <ItemTemplate>
                        <asp:Label ID="lblId" runat="server" Text='<%# Bind("id_dicom_vehiculo_pasos") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle CssClass="td_derecha" />
                    <HeaderStyle CssClass="td_cabecera" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Paso">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("descripcion") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle CssClass="td_derecha" />
                    <HeaderStyle CssClass="td_cabecera" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Estado">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkEstado" runat="server" EnableViewState="true" Checked='<%# Bind("estado")  %>' />
                    </ItemTemplate>
                    <ItemStyle CssClass="td_derecha" />
                    <HeaderStyle CssClass="td_cabecera" />
                </asp:TemplateField>
            </Columns>
            <HeaderStyle CssClass="tr_cabecera" />
            <RowStyle CssClass="tr_fila" />
            <AlternatingRowStyle CssClass="tr_fila_alt" />
        </asp:GridView>

        <asp:Button ID="btnCambiar" runat="server" CssClass="button" Text="Cambiar" OnClick="btnCambiar_Click" />
        <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" ConfirmText="¿Está segur@ de actualizar el estado de las autopistas?"
            TargetControlID="btnCambiar">
        </cc1:ConfirmButtonExtender>
    </div>
</asp:Content>
