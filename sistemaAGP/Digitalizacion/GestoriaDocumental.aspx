<%@ Page Title="" Language="C#" MasterPageFile="~/modal2.Master" AutoEventWireup="true"
    CodeBehind="GestoriaDocumental.aspx.cs" Inherits="sistemaAGP.digitalizacion.GestoriaDocumental" %>

<%@ Register TagPrefix="cc1" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=3.5.40412.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <script type="text/javascript" src="~/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="~/jquery.mousewheel-3.0.6.pack.js"></script>
    <script type="text/javascript" src="~/jquery.fancybox.js?v=2.0.6"></script>
    <link rel="Stylesheet" type="text/css" href="~/jquery.fancybox.css?v=2.0.6" media="screen" />
    <script type="text/javascript" src="~/javascript/ScrollableGrid.js"></script>

    <div class="divTituloModal">
        <img src="../imagenes/sistema/static/panel_control/carpeta.png" />
        <asp:Label ID="Label1" runat="server" Text="Gestoría Documental"></asp:Label>
    </div>
      <asp:UpdatePanel runat="server" ID="upd" UpdateMode="Conditional">
        <ContentTemplate>
    <br />
      <br />
    <div style="clear: both;">
        <asp:GridView ID="gr_documentos" runat="server" AutoGenerateColumns="False" CssClass="tabla_datos"
            DataKeyNames="id_solicitud,id_documento_operacion,id_documento,url" GridLines="None" OnRowCommand="gr_documentos_RowCommand"
            EnableModelValidation="True" onrowdatabound="gr_documentos_RowDataBound">
            <Columns>
                <asp:ButtonField AccessibleHeaderText="nombre" CommandName="View" DataTextField="nombre"
                    HeaderText="Documento">
                    <ItemStyle CssClass="td_derecha_grande" />
                    <HeaderStyle CssClass="td_cabecera_grande" />
                </asp:ButtonField>
                <asp:BoundField AccessibleHeaderText="extension" DataField="extension" HeaderText="Tipo">
                    <ItemStyle CssClass="td_derecha_chica" />
                    <HeaderStyle CssClass="td_cabecera_chica" />
                </asp:BoundField>
                <asp:BoundField AccessibleHeaderText="peso" DataField="peso" HeaderText="Peso">
                    <ItemStyle CssClass="td_derecha_chica" />
                    <HeaderStyle CssClass="td_cabecera_chica" />
                </asp:BoundField>
                 <asp:TemplateField AccessibleHeaderText="observacion" HeaderText="Observación">
                    <ItemTemplate>
                          <asp:TextBox ID="txt_observaciones" runat="server" Width="100%" MaxLength="250" Text='<%# Bind("observaciones") %>'/>
                    </ItemTemplate>
                    <ItemStyle CssClass="td_derecha_grandem" />
                    <HeaderStyle CssClass="td_cabecera_grandem" />
                </asp:TemplateField>
                <asp:BoundField AccessibleHeaderText="Usuario" DataField="usuario" HeaderText="Usuario">
                    <ItemStyle CssClass="td_derecha_grande" />
                    <HeaderStyle CssClass="td_cabecera_grande" />
                </asp:BoundField>
                <asp:TemplateField AccessibleHeaderText="subir" HeaderText="Subir">
                    <ItemTemplate>
                        <asp:FileUpload ID="fu_archivo" CssClass="button" runat="server" />
                    </ItemTemplate>
                    <ItemStyle CssClass="td_derecha_grandem" />
                    <HeaderStyle CssClass="td_cabecera_grandem" />
                </asp:TemplateField>
                <asp:TemplateField AccessibleHeaderText="eliminar" HeaderText="Del">
                    <ItemTemplate>
                        <asp:CheckBox ID="chk_eliminar" runat="server" Checked="false" />
                    </ItemTemplate>
                    <ItemStyle CssClass="td_derecha_chica" />
                    <HeaderStyle CssClass="td_cabecera_chica" />
                </asp:TemplateField>
            </Columns>
            <HeaderStyle CssClass="tr_cabecera" />
            <RowStyle CssClass="tr_fila" />
            <AlternatingRowStyle CssClass="tr_fila_alt" />
        </asp:GridView>
    </div>
    <table>
        <tr>
            <td>
                <asp:Button ID="btnSubir" runat="server" Text="Subir" CssClass="button" 
                    onclick="btnSubir_Click" />
                     <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender8" runat="server" TargetControlID="btnSubir"
                        ConfirmText="¿Está seguro de subir archivos?">
                    </cc1:ConfirmButtonExtender>
            </td>
        </tr>
    </table>
    <br />
    <asp:HiddenField ID="hdIdSolicitud" runat="server" Value="0" />
    <div class="centrado">
        <iframe id="i_documento" frameborder="1" height="400px" width="95%" runat="server"
            scrolling="auto"></iframe>
    </div>
      </ContentTemplate>
      <Triggers>
         <asp:PostBackTrigger ControlID="btnSubir" />
      </Triggers>
    </asp:UpdatePanel>
</asp:Content>
