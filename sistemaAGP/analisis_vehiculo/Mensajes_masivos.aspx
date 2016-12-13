<%@ Page Title="" Language="C#" MasterPageFile="~/modal2.Master" AutoEventWireup="true" CodeBehind="Mensajes_masivos.aspx.cs" Inherits="sistemaAGP.analisis_vehiculo.Mensajes_masivos" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="~/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="~/jquery.mousewheel-3.0.6.pack.js"></script>
    <script type="text/javascript" src="~/jquery.fancybox.js?v=2.0.6"></script>
    <link rel="Stylesheet" type="text/css" href="~/jquery.fancybox.css?v=2.0.6" media="screen" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
      <div class="divTituloModal">
                <img src="../imagenes/sistema/static/hipotecario/up.png" />
                <asp:Label ID="Label1" runat="server" Text="Mensajes Masivos"></asp:Label>
            </div>
    <div style="clear:both">
        <asp:TextBox ID="txtMensaje" Width="595px" Height="100px" TextMode="MultiLine" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnMensaje" runat="server" CssClass="button" Text="Enviar Mensaje" OnClick="btnMensaje_Click" />
        <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender4" runat="server" TargetControlID="btnMensaje"
																ConfirmText="¿Agregar el mensaje?" />
    </div>
    <br />
    <br />
    <div>
          <asp:GridView ID="grMensajes" runat="server" AutoGenerateColumns="False" CssClass="tabla_datos" DataKeyNames="idMensaje" OnRowCommand="grMensajes_RowCommand" OnSelectedIndexChanged="grMensajes_SelectedIndexChanged" OnRowDataBound="grMensajes_RowDataBound">
                        <Columns>
                            <asp:BoundField DataField="idMensaje" HeaderText="Id">
                                <ItemStyle CssClass="td_derecha" />
                                <HeaderStyle CssClass="td_cabecera" />
                            </asp:BoundField>
                            <asp:BoundField DataField="mensaje" HeaderText="Mensaje">
                                <ItemStyle CssClass="td_derecha_grande" />
                                <HeaderStyle CssClass="td_cabecera_grande" />
                            </asp:BoundField>
                            <asp:BoundField DataField="fecha" HeaderText="Fecha">
                                <ItemStyle CssClass="td_derecha" />
                                <HeaderStyle CssClass="td_cabecera" />
                            </asp:BoundField>
                            <asp:BoundField DataField="usuario" HeaderText="Usuario">
                                <ItemStyle CssClass="td_derecha" />
                                <HeaderStyle CssClass="td_cabecera" />
                            </asp:BoundField>  
                              <asp:BoundField DataField="estado" HeaderText="Estado">
                                <ItemStyle CssClass="td_derecha" />
                                <HeaderStyle CssClass="td_cabecera" />
                            </asp:BoundField>   
                            <asp:TemplateField HeaderText="Sel">
                            <ItemTemplate>
                                	<asp:ImageButton ID="iBaManual" runat="server" Visible="false" 
                                                        CommandName="desactivar" 
                                                        CommandArgument='<%#((GridViewRow)Container).RowIndex %>'
														AlternateText="Desactivar" />
															<cc1:ConfirmButtonExtender ID="ConfirmButtonExtender3" runat="server" TargetControlID="iBaManual"
																ConfirmText="¿Desactivar el mensaje?" />
                            </ItemTemplate>
                            <ItemStyle CssClass="td_derecha" />
                            <HeaderStyle CssClass="td_derecha" />
                        </asp:TemplateField>                         
                           
                        </Columns>
                        <HeaderStyle CssClass="tr_cabecera" />
                        <RowStyle CssClass="tr_fila" />
                        <AlternatingRowStyle CssClass="tr_fila_alt" />
                    </asp:GridView>
           
    </div>
</asp:Content>
