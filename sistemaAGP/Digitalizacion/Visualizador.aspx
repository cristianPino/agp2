<%@ Page Title="" Language="C#" MasterPageFile="~/Adm.Master" AutoEventWireup="true" CodeBehind="Visualizador.aspx.cs" Inherits="sistemaAGP.digitalizacion.Visualizador" %>

<%@ Register Src="~/controles/wucIncidenciaDocumentos.ascx" TagName="documento" TagPrefix="agp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register TagPrefix="cc1" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=3.5.40412.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="subtitulo" style="width: 50%">
        <asp:Image ID="Image1" runat="server"
            ImageUrl="../imagenes/sistema/static/panel_control/carpeta.png"
            Height="34px"
            Width="37px" />
        &nbsp;<asp:Label ID="lbl_titulo" runat="server" Text="Carpeta digital"></asp:Label>
    </div>

    <br />
    <ajaxToolkit:TabContainer ID="tab_opciones" runat="server" Width="100%" ActiveTabIndex="0">
        <ajaxToolkit:TabPanel ID="tab_solicitud" runat="server" TabIndex="0" HeaderText="Documentos Operación">
            <ContentTemplate>
                <asp:UpdatePanel runat="server" ID="updateP" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table class="table">
                            <tr style="vertical-align: top">
                                <td style="vertical-align:top;">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:ImageButton ID="imgSubir" runat="server" OnClick="imgSubir_Click" ToolTip="Subir archivo" />
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="imgEliminar" runat="server" OnClick="imgEliminar_Click" ToolTip="Eliminar archivo" />
                                                <ajaxToolkit:ConfirmButtonExtender ID="Button1_ConfirmButtonExtender" runat="server" TargetControlID="imgEliminar" ConfirmText="¿Está seguro de Eliminar los documentos seleccionados?" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Subir</td>
                                            <td>Borrar</td>
                                        </tr>
                                    </table>

                                    <br />

                                    <asp:GridView ID="gr_documentos" runat="server" AutoGenerateColumns="False"
                                        CssClass="tabla_datos"
                                        DataKeyNames="id_documento_operacion,id_solicitud,id_documento,url,observaciones,fecha,nombre,usuario"
                                        GridLines="None" OnRowCommand="gr_documentos_RowCommand"
                                        EnableModelValidation="True">
                                        <Columns>
                                            <asp:ButtonField AccessibleHeaderText="nombre"
                                                CommandName="View"
                                                DataTextField="nombre"
                                                HeaderText="Documento">
                                                <ItemStyle CssClass="td_derecha_grande" />
                                                <HeaderStyle CssClass="td_cabecera_grande" />
                                            </asp:ButtonField>
                                            <asp:BoundField AccessibleHeaderText="fecha" DataField="fecha" HeaderText="Fecha">
                                                <ItemStyle CssClass="td_derecha" />
                                                <HeaderStyle CssClass="td_cabecera" />
                                            </asp:BoundField>

                                            <asp:BoundField AccessibleHeaderText="Usuario" DataField="usuario" HeaderText="Usuario">
                                                <ItemStyle CssClass="td_derecha_grande" />
                                                <HeaderStyle CssClass="td_cabecera_grande" />
                                            </asp:BoundField>

                                            <asp:TemplateField AccessibleHeaderText="eliminar" HeaderText="Sel">
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
                                    <br />
                                    <br />
                                    <br />
                                    <table>
                                        <tr>
                                            <td>VIENDO:
                                            </td>
                                            <td>
                                                <asp:Label ID="lblDocumentoNombre" runat="server" Text="" style="font-size: xx-large" ></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>SUBIDO POR:
                                            </td>
                                            <td>
                                                <asp:Label ID="lblDocumentoUsuario" runat="server" Text="" style="font-size: large"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>COMENTARIO:
                                            </td>
                                            <td>
                                                <asp:Label ID="lblDocumentoComentario" runat="server" Text="" style="font-size:large"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>

                                </td>
                                <td>

                                    <div class="divIzquierdaDocumentos">
                                        <div class="centrado">
                                            <iframe id="i_documento" frameborder="1" height="600px" width="730px" runat="server" scrolling="auto"></iframe>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                        </table>
                          <asp:Button ID="bt_oculto_subir" runat="server" Style="display: none;" />

                                    <asp:Panel ID="pnl_subir" runat="server" Style="padding: 10px; background-color: #fff;">
                                        <table class="table">
                                            <tr>
                                                <th colspan="2" style="color: #222">
                                                    <center>SUBIR DOCUMENTOS</center>
                                                </th>
                                            </tr>
                                            <tr>
                                                <td>
                                                    TITULO
                                                </td>
                                                <td>
                                                    <center>
                                                        <asp:DropDownList ID="dlTitulo" runat="server" Style="width: 500px; font-size: medium">
                                                        </asp:DropDownList>
                                                    </center>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="dlTitulo"
                                                        ErrorMessage="*" InitialValue="0" Display="Dynamic" ValidationGroup="subir" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    DOCUMENTO
                                                </td>
                                                <td>
                                                    <asp:FileUpload ID="fu_archivo" runat="server" CssClass="button" Style="width: 500px;" Font-Size="small" />
                                                </td>
                                            </tr>

                                            <tr>
                                                <td>
                                                    OBSERVACION
                                                </td>
                                                <td>
                                                    <input type="text" id="txtObservacion" runat="server" style="width: 500px; font-size: medium" placeholder="Comentario" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <center>
                                                        <asp:Button ID="bt_cancelar_subir" Style="font-size: small" runat="server" Text="Cancelar" CssClass="buttonGris" />
                                                    
                                              &nbsp;
                                                    
                                                        <asp:Button ID="btnSubir" runat="server" Text="Subir" Style="font-size: small" CssClass="button" ValidationGroup="subir" ToolTip="Sube el documento seleccionado"
                                                            OnClick="btnSubir_Click" />
                                                        <ajaxToolkit:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="btnSubir" ConfirmText="¿Está seguro de Subir un documento?" />
                                                    </center>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <cc1:ModalPopupExtender ID="mpe_subir" runat="server" BackgroundCssClass="modalBackground" CancelControlID="bt_cancelar_subir" PopupControlID="pnl_subir" TargetControlID="bt_oculto_subir">
                                    </cc1:ModalPopupExtender>


                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnSubir" />
                    </Triggers>
                </asp:UpdatePanel>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>


        <ajaxToolkit:TabPanel runat="server" HeaderText="Incidencia" ID="tab_incidencia">
            <ContentTemplate>
                <agp:documento ID="wucDocumento" runat="server" PuedeModificar="false"></agp:documento>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>


        <ajaxToolkit:TabPanel runat="server" HeaderText="Operacion Origen" ID="tab_origen">
            <ContentTemplate>


                <asp:GridView ID="gr_documentos_origen" runat="server" AutoGenerateColumns="False"
                    CssClass="tabla_datos"
                    DataKeyNames="id_documento_operacion,id_solicitud,id_documento,url"
                    GridLines="None"
                    EnableModelValidation="True">
                    <Columns>
                        <asp:ButtonField AccessibleHeaderText="nombre"
                            CommandName="View"
                            DataTextField="nombre"
                            HeaderText="Documento">
                            <ItemStyle CssClass="td_derecha_grande" />
                            <HeaderStyle CssClass="td_cabecera_grande" />
                        </asp:ButtonField>

                        <asp:BoundField AccessibleHeaderText="extension" DataField="extension" HeaderText="Extensión">
                            <ItemStyle CssClass="td_derecha" />
                            <HeaderStyle CssClass="td_cabecera" />
                        </asp:BoundField>

                        <asp:BoundField AccessibleHeaderText="peso" DataField="peso" HeaderText="Tamaño">
                            <ItemStyle CssClass="td_derecha" />
                            <HeaderStyle CssClass="td_cabecera" />
                        </asp:BoundField>

                        <asp:BoundField AccessibleHeaderText="observaciones" DataField="observaciones" HeaderText="Observaciones">
                            <ItemStyle CssClass="td_derecha_grande" />
                            <HeaderStyle CssClass="td_cabecera_grande" />
                        </asp:BoundField>

                        <asp:BoundField AccessibleHeaderText="Usuario" DataField="usuario" HeaderText="Usuario">
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
                <br />

                <hr />

                <div class="centrado">
                    <iframe id="i_documento_origen" frameborder="1" height="400px" width="95%" runat="server" scrolling="auto"></iframe>
                </div>



            </ContentTemplate>
        </ajaxToolkit:TabPanel>

    </ajaxToolkit:TabContainer>

</asp:Content>
