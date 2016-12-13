<%@ Page Title="" Language="C#" MasterPageFile="~/modal2.Master" AutoEventWireup="true" CodeBehind="IngresoGarantias.aspx.cs" Inherits="sistemaAGP.OrdenTrabajo.modal.IngresoGarantias" %>

<%@ Register TagPrefix="AjaxControlToolkit" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=3.5.40412.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>



<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">


    <div class="divTituloModal">
        <img src="../../imagenes/sistema/static/panel_control/nominas.png" />
        <asp:Label ID="Label1" runat="server" Text="Ingreso Garantías"></asp:Label>
    </div>
    <div style="clear: both"></div>
    
    <table class="tabla">
        <tr>
            <td>
                <span>Seleccione un Cliente:</span>
            </td>
            <td>
                <asp:DropDownList ID="dlCliente" CssClass="ddl"  runat="server" AutoPostBack="True" OnSelectedIndexChanged="dlCliente_SelectedIndexChanged"></asp:DropDownList>
            </td>
        </tr>
    </table>
    <br/>
    <AjaxControlToolkit:TabContainer ID="tab_datos" runat="server" Width="100%" TabIndex="0" ActiveTabIndex="2"
        ScrollBars="Auto">
        <AjaxControlToolkit:TabPanel ID="tp_datos_de_contacto" runat="server" HeaderText="Cotizaciones"
            Width="100%">
            <HeaderTemplate>
                Carga Masiva
            </HeaderTemplate>
            <ContentTemplate>
                <br />
                <asp:FileUpload ID="fileuploadExcel" runat="server" />
                <asp:Button ID="btnAnalisisMasivo" runat="server" CssClass="button" Text="Subir y analizar" ValidationGroup="val" OnClick="btnAnalisisMasivo_Click" />
                <asp:Button ID="btnUpload" runat="server" CssClass="button" Text="Aplicar" ValidationGroup="val" OnClick="btnUpload_Click" Visible="false" />
                <asp:Button ID="btnCancel" runat="server" CssClass="button_rojo" Text="Borrar" ValidationGroup="val" OnClick="btnCancel_Click" Visible="false" />
                 <br />
                 <br />
                <asp:GridView ID="grDato" runat="server" AutoGenerateColumns="False" CssClass="tabla_datos"
                    DataKeyNames="fila_excel,
                                        id_sucursal,
                                        nombre_sucursal,
                                        codigo_sucursal,
                                        correo,
                                        rut,
                                        rut_formateado,
                                        patente,
                                        estado_revision,
                                        semaforo,
                                        mensaje,
                                        n_operacion">
                    <Columns>
                        <asp:BoundField DataField="fila_excel" HeaderText="Fila Exel">
                            <ItemStyle CssClass="td_derecha" />
                            <HeaderStyle CssClass="td_cabecera" />
                        </asp:BoundField>
                         <asp:BoundField DataField="n_operacion" HeaderText="N operación">
                            <ItemStyle CssClass="td_derecha" />
                            <HeaderStyle CssClass="td_cabecera" />
                        </asp:BoundField>
                        <asp:BoundField DataField="patente" HeaderText="Patente">
                            <ItemStyle CssClass="td_derecha" />
                            <HeaderStyle CssClass="td_cabecera" />
                        </asp:BoundField>
                        <asp:BoundField DataField="codigo_sucursal" HeaderText="Codigo sucursal">
                            <ItemStyle CssClass="td_derecha" />
                            <HeaderStyle CssClass="td_cabecera" />
                        </asp:BoundField>
                        <asp:BoundField DataField="nombre_sucursal" HeaderText="Sucursal">
                            <ItemStyle CssClass="td_derecha_grande" />
                            <HeaderStyle CssClass="td_cabecera_grande" />
                        </asp:BoundField>
                        <asp:BoundField DataField="rut" HeaderText="Rut">
                            <ItemStyle CssClass="td_derecha" />
                            <HeaderStyle CssClass="td_cabecera" />
                        </asp:BoundField>
                        <asp:BoundField DataField="correo" HeaderText="Correo">
                            <ItemStyle CssClass="td_derecha_grande" />
                            <HeaderStyle CssClass="td_cabecera_grande" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Estado">
                            <ItemTemplate>
                                <asp:HyperLink ID="lnk_estado" runat="server" ImageUrl='<%# Bind("semaforo") %>'></asp:HyperLink>
                            </ItemTemplate>
                            <ItemStyle CssClass="td_derecha" />
                            <HeaderStyle CssClass="td_derecha" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="mensaje" HeaderText="RESULTADO">
                            <ItemStyle CssClass="td_derecha_grande" />
                            <HeaderStyle CssClass="td_cabecera_grande" />
                        </asp:BoundField>
                    </Columns>
                    <HeaderStyle CssClass="tr_cabecera" />
                    <RowStyle CssClass="tr_fila" />
                    <AlternatingRowStyle CssClass="tr_fila_alt" />
                </asp:GridView>

            </ContentTemplate>
        </AjaxControlToolkit:TabPanel>
        <AjaxControlToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="Cotizaciones" Width="100%">
            <HeaderTemplate>
                Nueva Orden
            </HeaderTemplate>
            <ContentTemplate>
                <asp:UpdatePanel ID="upd" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                          <asp:HiddenField ID="hdnIdSucursal" Value="0" runat="server" />
                        <table style="color: #999999">
                            <tr>
                                <td>Patente</td>
                                <td>
                                    <asp:TextBox ID="txtPatente" CssClass="inputs" MaxLength="6" Width="100px" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Rut</td>
                                <td>
                                    <asp:TextBox ID="txtRut" CssClass="inputs" MaxLength="9" runat="server" AutoPostBack="true" Width="100px" OnTextChanged="txtRut_TextChanged"></asp:TextBox>
                                    <span>-</span>
                                    <asp:TextBox ID="txtDv" Width="10px" CssClass="inputs" Enabled="false" AutoPostBack="true" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Correo
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCorreo" CssClass="inputs" runat="server"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="revCorreo" runat="server" ValidationGroup="val" ControlToValidate="txtCorreo" ErrorMessage="No valido" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" SetFocusOnError="True"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                             <tr runat="server" id="trNumeroOperacion" Visible="False">
                                <td>N Operación
                                </td>
                                <td>
                                    <asp:TextBox ID="txtOperacion" CssClass="inputs" MaxLength="8" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Cod. Sucursal
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSucursal" CssClass="inputs" MaxLength="5" Width="50px" AutoPostBack="true" runat="server" OnTextChanged="txtSucursal_TextChanged"></asp:TextBox>

                                    <asp:Label ID="lblNombreSucursal" Font-Size="Small" runat="server" Text="Sucursal no seleccionada"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <br />
                                </td>
                            </tr>
                            <caption>
                                |
                    <tr>
                        <td colspan="2">
                            <asp:FileUpload ID="fu_archivo" runat="server" CssClass="button" />
                            <asp:Button ID="btnIngreso" runat="server" CssClass="button" OnClick="btnIngreso_Click" Text="Ingresar" ValidationGroup="val" />
                            <AjaxControlToolkit:ConfirmButtonExtender ID="ConfirmButtonExtender8" runat="server" ConfirmText="¿Está seguro de crear una solicitud?" TargetControlID="btnIngreso" />
                        </td>
                    </tr>
                            </caption>


                        </table>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnIngreso" />
                    </Triggers>
                </asp:UpdatePanel>

            </ContentTemplate>
        </AjaxControlToolkit:TabPanel>
    </AjaxControlToolkit:TabContainer>

    <div class="divInfo" style="clear: both" id="divInfo" runat="server">
        <center>
            <table>
                <tr>
                    <td>
                        <asp:ImageButton ID="ibSalir" runat="server" ImageUrl="~/imagenes/sistema/static/hipotecario/salir.png"
                            OnClick="ibSalir_Click" />
                    </td>
                </tr>
            </table>
        </center>
    </div>

  
</asp:Content>
