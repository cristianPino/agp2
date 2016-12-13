<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="mensajeOt.ascx.cs" Inherits="sistemaAGP.controles.mensajeOt" %>
<%@ Register TagPrefix="cc2" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=3.5.40412.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>
 <asp:UpdatePanel ID="updmensaje" runat="server" UpdateMode="Conditional"  >
    <ContentTemplate>
<table>
    <tr>
        <td rowspan="2">
            <asp:TextBox ID="txtMensaje" runat="server" TextMode="MultiLine" MaxLength="1000"
                Height="311px" Width="605px"></asp:TextBox>
        </td>
      
    </tr>
    <tr>
        <td>
             <asp:GridView ID="grContactos" runat="server" AutoGenerateColumns="False" CssClass="tabla_datos" DataKeyNames="id_usuario">
                <Columns>
                    <asp:BoundField DataField="usuario" HeaderText="Mis Contactos">
                        <ItemStyle CssClass="td_derecha_grande" />
                        <HeaderStyle CssClass="td_cabecera_grande" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Fav">
                        <ItemTemplate>
                            <asp:Image ID="imgFav" ImageUrl='<%# Bind("imagen_fav") %>' runat="server" />
                        </ItemTemplate>
                        <ItemStyle CssClass="td_derecha_chica" />
                        <HeaderStyle CssClass="td_cabecera_chica" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="sel">
                        <ItemTemplate>
                            <asp:CheckBox ID="chk" runat="server" />
                        </ItemTemplate>
                        <ItemStyle CssClass="td_derecha_chica" />
                        <HeaderStyle CssClass="td_cabecera_chica" />
                    </asp:TemplateField>
                </Columns>
                <HeaderStyle CssClass="tr_cabecera" />
                <RowStyle CssClass="tr_fila" />
                <AlternatingRowStyle CssClass="tr_fila_alt" />
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:Button ID="btnEnviar" runat="server" CssClass="button" Text="Enviar" OnClick="btnEnviar_Click" />
        </td>
         <cc2:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" ConfirmText="¿Desea enviar el mensaje?"
                                    TargetControlID="btnEnviar">
                                </cc2:ConfirmButtonExtender>
    </tr>
    <tr>
        <td colspan="2">
            Mensajes anteriores</td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:GridView ID="grMensajes" runat="server" AutoGenerateColumns="False" CssClass="tabla_datos" DataKeyNames="id_mensaje">
                <Columns>
                    <asp:BoundField DataField="usuarioIngreso" HeaderText="Escrito por">
                        <ItemStyle CssClass="td_derecha_grande" />
                        <HeaderStyle CssClass="td_cabecera_grande" />
                    </asp:BoundField>
                    <asp:BoundField DataField="inicio" HeaderText="Fecha">
                        <ItemStyle CssClass="td_derecha_grande" />
                        <HeaderStyle CssClass="td_cabecera_grande" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Mensaje">
                        <ItemTemplate>
                            <asp:HyperLink ID="hlMensaje" runat="server" Text='<%# Bind("mensaje") %>' />
                        </ItemTemplate>
                        <ItemStyle CssClass="td_derecha_grande" />
                        <HeaderStyle CssClass="td_cabecera_grande" />
                    </asp:TemplateField>
                </Columns>
                <HeaderStyle CssClass="tr_cabecera" />
                <RowStyle CssClass="tr_fila" />
                <AlternatingRowStyle CssClass="tr_fila_alt" />
            </asp:GridView>
        </td>
    </tr>
</table>
<asp:HiddenField ID="hdnIdOrdenTrabajo" runat="server" />
 </ContentTemplate>
    </asp:UpdatePanel>