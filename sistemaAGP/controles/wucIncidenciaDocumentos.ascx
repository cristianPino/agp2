<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucIncidenciaDocumentos.ascx.cs" Inherits="sistemaAGP.controles.wucIncidenciaDocumentos" %>

<asp:UpdatePanel runat="server" ID="upd_Incidencia" UpdateMode="Conditional">
    <ContentTemplate>
        
        <asp:Panel ID="pnelAcciones" runat="server">
        <table>
            
            <tr>
                <td>
                    <span>Título o descripción</span>
                </td>

                <td>
                    <span>Comentario</span>
                </td>


            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtTítulo" CssClass="input" runat="server" Width="200" MaxLength="100"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="txtComentario" CssClass="input" runat="server" Width="500" MaxLength="200"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:FileUpload ID="fu_archivo" runat="server" CssClass="button" />

                    <asp:Button ID="btnSubirIncidencia" runat="server" Text="Subir" CssClass="button" ValidationGroup="subir" ToolTip="Sube el documento seleccionado"
                        OnClick="btnSubirIncidencia_Click" />
                </td>
            </tr>
        </table>
        </asp:Panel>

        <asp:GridView ID="gr_documentos" runat="server" AutoGenerateColumns="False"
            CssClass="tabla_datos"
            DataKeyNames="id_incidencia,id_incidencia_documento,url"
            GridLines="None" EnableModelValidation="True"
            OnRowCommand="gr_documentos_RowCommand">
            <Columns>
                <asp:ButtonField AccessibleHeaderText="titulo"
                    CommandName="View"
                    DataTextField="titulo"
                    HeaderText="Documento">
                    <ItemStyle CssClass="td_derecha_grande" />
                    <HeaderStyle CssClass="td_cabecera_grande" />
                </asp:ButtonField>

                <asp:BoundField DataField="fecha" HeaderText="Fecha">
                    <ItemStyle CssClass="td_derecha" />
                    <HeaderStyle CssClass="td_cabecera" />
                </asp:BoundField>

                <asp:BoundField AccessibleHeaderText="observaciones" DataField="comentario" HeaderText="Observaciones">
                    <ItemStyle CssClass="td_derecha_grande" />
                    <HeaderStyle CssClass="td_cabecera_grande" />
                </asp:BoundField>

                <asp:BoundField AccessibleHeaderText="Usuario" DataField="nombre_usuario" HeaderText="Usuario">
                    <ItemStyle CssClass="td_derecha_grande" />
                    <HeaderStyle CssClass="td_cabecera_grande" />
                </asp:BoundField>

                <asp:TemplateField AccessibleHeaderText="eliminar" HeaderText="Eliminar">
                    <ItemTemplate>
                        <asp:CheckBox ID="chk_eliminar" runat="server" Checked="false" />
                    </ItemTemplate>
                    <ItemStyle CssClass="td_derecha" />
                    <HeaderStyle CssClass="td_cabecera" />
                </asp:TemplateField>
            </Columns>

            <HeaderStyle CssClass="tr_cabecera" />
            <RowStyle CssClass="tr_fila" />
            <AlternatingRowStyle CssClass="tr_fila_alt" />
        </asp:GridView>

        <div class="centrado">
            <iframe id="i_documento" frameborder="1" height="400px" width="95%" runat="server" scrolling="auto"></iframe>
        </div>
                
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="btnSubirIncidencia" />
    </Triggers>


</asp:UpdatePanel>
