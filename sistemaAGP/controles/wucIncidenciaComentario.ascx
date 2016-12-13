<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucIncidenciaComentario.ascx.cs" Inherits="sistemaAGP.controles.wucIncidenciaComentario" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<link rel="stylesheet" href="~/estilos/Master2.css" />
<br />
<table>
    <tr>
        <td>
            <span>Nuevo comentario</span>
        </td>
    </tr>
    <tr>
        <td>
            <asp:TextBox ID="txtComentario2" runat="server" TextMode="MultiLine"
                CssClass="inputs" Width="800px" Height="100%"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <center>
                    <asp:Button ID="btnComentario" runat="server" Text="Comentar" CssClass="button" 
                        onclick="btnComentario_Click"/>
                         <ajaxToolkit:ConfirmButtonExtender ID="cbeComentario" runat="server" 
                         TargetControlID="btnComentario" 
                         ConfirmText="¿Esta seguro de añadir un comentario?">
                        </ajaxToolkit:ConfirmButtonExtender>
            </center>
        </td>
    </tr>
</table>

<br />

<asp:GridView ID="grComentario" runat="server" AutoGenerateColumns="False" DataKeyNames=""
    CssClass="tabla_datos">
    <Columns>

        <asp:BoundField DataField="fecha" HeaderText="Fecha">
            <ItemStyle CssClass="td_derecha" />
            <HeaderStyle CssClass="td_derecha" />
        </asp:BoundField>

        <asp:BoundField DataField="estado" HeaderText="Estado">
            <ItemStyle CssClass="td_derecha_grande" />
            <HeaderStyle CssClass="td_derecha_grande" />
        </asp:BoundField>

        <asp:BoundField DataField="comentario" HeaderText="Comentario">
            <ItemStyle CssClass="td_derecha_grandexl" />
            <HeaderStyle CssClass="td_derecha_grandexl" />
        </asp:BoundField>

        <asp:BoundField DataField="usuario" HeaderText="Usuario">
            <ItemStyle CssClass="td_derecha" />
            <HeaderStyle CssClass="td_derecha" />
        </asp:BoundField>

    </Columns>
    <HeaderStyle CssClass="tr_cabecera" />
    <RowStyle CssClass="tr_fila" />
    <AlternatingRowStyle CssClass="tr_fila_alt" />
</asp:GridView>
