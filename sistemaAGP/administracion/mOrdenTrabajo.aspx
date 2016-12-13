<%@ Page Title="" Language="C#" MasterPageFile="~/Master2.Master" AutoEventWireup="true" CodeBehind="mOrdenTrabajo.aspx.cs" Inherits="sistemaAGP.administracion.mOrdenTrabajo" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ MasterType VirtualPath="~/Master2.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table class="tabla" width="100%">
        <tr>
            <td>
                <span><u>Datos Usuario</u></span>
            </td>
        </tr>
        <tr>
            <td>
                <span>Cuenta:</span>
            </td>
            <td>
                <input type="text" class="inputs" maxlength="15" placeholder="Cuenta de usuario" runat="server" id="txtCuentaUsuario" />
            </td>
            <td>
                <asp:ImageButton ID="ibBuscar" runat="server" ImageUrl="~/imagenes/sistema/static/buscar_chico.png" OnClick="ibBuscar_Click" />
                <asp:ImageButton ID="ibLimpiar" runat="server" ImageUrl="~/imagenes/sistema/static/new.png" />
            </td>
        </tr>
        <tr>
            <td>
                <span>Nombre:</span>
            </td>
            <td>
                <asp:Label ID="lblUsuarioNombre" runat="server" Text=""></asp:Label>
            </td>
        </tr>
    </table>
    <br />
    <asp:Panel ID="pnelConfiguracion" Visible="false" runat="server">

        <table class="tabla" width="100%">
            <tr>
                <td>
                    <span><u>Características</u></span>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:RadioButton ID="rbCopiaPerfil" GroupName="car" AutoPostBack="true" Checked="true" runat="server" Text="Copiar desde un perfil" OnCheckedChanged="rbCopiaPerfil_CheckedChanged"></asp:RadioButton>
                </td>
                <td>
                    <asp:DropDownList ID="dlCopiaPerfil" Class="ddl" runat="server"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:RadioButton ID="rbCopiarUsuario" GroupName="car" AutoPostBack="true" runat="server" Text="Copiar desde un Usuario" OnCheckedChanged="rbCopiarUsuario_CheckedChanged"></asp:RadioButton>
                </td>
                <td>
                    <asp:DropDownList ID="dlCopiaUsuario" Class="ddl" runat="server" Enabled="false"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:RadioButton ID="rbCopiarPersonalizar" GroupName="car" AutoPostBack="true" runat="server" Text="Personalizar" OnCheckedChanged="rbCopiarPersonalizar_CheckedChanged"></asp:RadioButton>
                </td>
            </tr>
        </table>

        <br />

        <ajaxToolkit:TabContainer ID="tab_opciones" runat="server" Width="100%"  ActiveTabIndex="3" Enabled="false">
            <ajaxToolkit:TabPanel ID="tabPermisos" runat="server" TabIndex="0" HeaderText="Busqueda y permisos">
                <ContentTemplate>
                    <br />
                    <table class="tabla" >                       
                        <tr>
                            <td>
                                <span>Tipo de busqueda</span>
                            </td>
                            <td>
                                <asp:DropDownList ID="dlTipoBusqueda" Class="ddl" runat="server"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td><span><u>Permisos Especiales</u></span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:CheckBox ID="ckPermisoAsignar" runat="server" Text="Asignar" />
                            </td>
                            <td>
                                <asp:CheckBox ID="ckPermisoGarantia" runat="server" Text="Garantía" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:CheckBox ID="ckPermisoEliminar" runat="server" Text="Eliminar" />
                            </td>
                            <td>
                                <asp:CheckBox ID="ckPermisoPrimera" runat="server" Text="Primera" />
                            </td>
                        </tr>
                         <tr>
                            <td>
                                <asp:CheckBox ID="ckbAgregarMenu" runat="server" Text="Ver Menú"></asp:CheckBox>
                            </td>
                        </tr>
                    </table>

                    <br />

                </ContentTemplate>
            </ajaxToolkit:TabPanel>
            <ajaxToolkit:TabPanel ID="tabActividades" runat="server" TabIndex="0" HeaderText="Actividades">
                <ContentTemplate>

                    <br />

                    <asp:GridView ID="grActividades" runat="server" AutoGenerateColumns="False" CssClass="tabla_datos" DataKeyNames="id_actividad_orden_trabajo">
                        <Columns>

                            <asp:TemplateField HeaderText="Actividad">
                                <ItemTemplate>
                                    <asp:Label ID="lblFactura" ForeColor="#660066" runat="server" Text='<%# Bind("descripcion") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle CssClass="td_derecha_grandexl" />
                                <HeaderStyle CssClass="td_cabecera_grandexl" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Ver">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkActividadVer" runat="server" EnableViewState="true" Checked='<%# Bind("existe")  %>' />

                                </ItemTemplate>
                                <ItemStyle CssClass="td_derecha" />
                                <HeaderStyle CssClass="td_cabecera" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Solo Lectura">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkActividadLectura" runat="server" EnableViewState="true" Checked='<%# Bind("solo_lectura")  %>' />
                                </ItemTemplate>
                                <ItemStyle CssClass="td_derecha" />
                                <HeaderStyle CssClass="td_cabecera" />
                            </asp:TemplateField>
                        </Columns>
                        <HeaderStyle CssClass="tr_cabecera" />
                        <RowStyle CssClass="tr_fila" />
                        <AlternatingRowStyle CssClass="tr_fila_alt" />
                    </asp:GridView>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
            <ajaxToolkit:TabPanel ID="tabGrupos" runat="server" TabIndex="0" HeaderText="Grupos">
                <ContentTemplate>
                    <br />
                    <asp:GridView ID="grGrupo" runat="server" AutoGenerateColumns="False" CssClass="tabla_datos" DataKeyNames="codigo_grupo">
                        <Columns>
                            <asp:TemplateField HeaderText="Grupo">
                                <ItemTemplate>
                                    <asp:Label ID="lblFactura" ForeColor="#660066" runat="server" Text='<%# Bind("grupo") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle CssClass="td_derecha_grandexl" />
                                <HeaderStyle CssClass="td_cabecera_grandexl" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Jefe">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkJefe" runat="server" EnableViewState="true" Checked='<%# Bind("jefe")  %>' />
                                </ItemTemplate>
                                <ItemStyle CssClass="td_derecha" />
                                <HeaderStyle CssClass="td_cabecera" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Observador">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkObservador" runat="server" EnableViewState="true" Checked='<%# Bind("observador")  %>' />
                                </ItemTemplate>
                                <ItemStyle CssClass="td_derecha" />
                                <HeaderStyle CssClass="td_cabecera" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Activo">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkActivo" runat="server" EnableViewState="true" Checked='<%# Bind("activo")  %>' />
                                </ItemTemplate>
                                <ItemStyle CssClass="td_derecha" />
                                <HeaderStyle CssClass="td_cabecera" />
                            </asp:TemplateField>
                        </Columns>
                        <HeaderStyle CssClass="tr_cabecera" />
                        <RowStyle CssClass="tr_fila" />
                        <AlternatingRowStyle CssClass="tr_fila_alt" />
                    </asp:GridView>
                </ContentTemplate>
            </ajaxToolkit:TabPanel>
        </ajaxToolkit:TabContainer>
        <br />
        <div class="div_objetos" id="divBotones" runat="server" style="border-top-width: 30px">
            <center>
                <table style="font-size: xx-small">
                    <tr>

                        <td>
                            <center>
                                <asp:ImageButton ID="ibGuardar" runat="server" ImageUrl="~/imagenes/sistema/static/hipotecario/save.png" OnClick="ibGuardar_Click" />
                            </center>
                        </td>

                    </tr>
                    <tr>
                        <td>
                            <center><span>Guardar</span></center>
                        </td>

                    </tr>
                </table>

            </center>
        </div>

    </asp:Panel>

</asp:Content>
