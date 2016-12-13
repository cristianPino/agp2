<%@ Page Title="" Language="C#" MasterPageFile="~/Adm.Master" AutoEventWireup="true" CodeBehind="IngresoAutopistas.aspx.cs" Inherits="sistemaAGP.analisis_vehiculo.IngresoAutopistas" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #TextArea1 {
            width: 636px;
        }

        .div_objetos {
            position: relative;
            background: -webkit-linear-gradient(left, #222, #5f5992); /* For Safari 5.1 to 6.0 */
            background: -o-linear-gradient(right, #222, #5f5992); /* For Opera 11.1 to 12.0 */
            background: -moz-linear-gradient(right, #222, #5f5992); /* For Firefox 3.6 to 15 */
            background: linear-gradient(to right, #222, #5f5992); /* Standard syntax (must be last) */
            color: #fff;
            padding: 2px;
            border-radius: 5px;
            -ms-border-radius: 5px;
            -moz-border-radius: 5px;
            -webkit-border-radius: 5px;
            -khtml-border-radius: 5px;
            -moz-box-shadow: 10px 10px 5px #888;
            -webkit-box-shadow: 10px 10px 5px #888;
            box-shadow: 10px 10px 5px #888;
            clear: both;
        }

        .titulo {
            position: relative;
            width: 70%;
            max-width: 70%;
            height: auto;
            vert-align: middle;
            background-color: #5f5992;
            color: #f1f1f1;
            font-size: large;
            font-weight: bold;
            overflow: hidden;
            float: left;
            border-bottom-right-radius: 15px;
            border-bottom-left-radius: 15px;
            border: solid 5px;
        }

        body {
            font-family: Arial, Helvetica, sans-serif;
            font-size: x-small;
        }

        .droplist {
            font-family: Arial, Helvetica, sans-serif;
            font-size: x-small;
            height: 16px;
            width: 138px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script language="Javascript">
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        } </script>

    <table class="titulo">
        <tr>
            <td>
                <asp:Image ID="Image1" runat="server" ImageUrl="~/imagenes/sistema/static/infoAuto/InfoAutoIcono2.png" />
            </td>
            <td>
                <asp:Label ID="Label2" runat="server" Text="INFOCAR ANALISIS MANUAL PPU: "></asp:Label>
                <asp:Label ID="lblPatente" runat="server" Text=""></asp:Label>
            </td>
        </tr>
    </table>
     <table>
        <tr>
            <td>
                Rut del Propietario:
            </td>
            <td>               
                <asp:Label ID="lblRutPropietario" runat="server" Text="s/i"></asp:Label>
            </td>
            <td>
                Nombre del Propietario:
            </td>
            <td>               
                <asp:Label ID="lblNombrePropietario" runat="server" Text="s/i"></asp:Label>
            </td>
        </tr>
    </table>
    
    
    <br />
    <table class="table" style="clear: both">
        <tr>
            <td>
                <asp:Label ID="Label1"
                    runat="server"
                    Text="Fuente:"></asp:Label>
                <asp:DropDownList ID="dlFuenteInformacion" runat="server" CssClass="droplist"
                    OnSelectedIndexChanged="dlFuenteInformacion_SelectedIndexChanged"
                    AutoPostBack="True">
                </asp:DropDownList>
            </td>
            <td>
                <asp:Button ID="btnIniciar" runat="server" Text="Iniciar"
                    CssClass="button_verde" OnClick="btnIniciar_Click" />
            </td>
            <td>
                <asp:Button ID="btnExito" runat="server" Text="Terminar con éxito"
                    CssClass="button" OnClick="btnExito_Click" />
            </td>
            <td>
                <asp:Button ID="btnFracaso" runat="server"
                    Text="No se pudo obtener información" CssClass="button_rojo"
                    OnClick="btnFracaso_Click" />
            </td>
            <td>
                <asp:ImageButton ID="ib_buscar"
                    runat="server"
                    ImageUrl="~/imagenes/sistema/static/infoAuto/lupaazul.png"
                    Height="21px"
                    Width="30px"
                    Style="text-align: center"
                    OnClick="ib_buscar_Click" ToolTip="Buscar" />
            </td>
            <td>
                <asp:ImageButton ID="ib_insertar"
                    runat="server"
                    ImageUrl="~/imagenes/sistema/static/hipotecario/crear_nuevo_doc.png"
                    Height="21px"
                    Width="30px"
                    Style="text-align: center"
                    OnClick="ib_insertar_Click"
                    ToolTip="Insertar Multas" />
            </td>
        </tr>
    </table>


    <br />

    <div class="div_objetos">
        <asp:HyperLink ID="hlinkPaginas"
                    Target="_blank"
                    runat="server">
                    <asp:Label ID="lblLink"
                        runat="server"
                        Text=""></asp:Label>
                </asp:HyperLink>
    </div>

   <br />

    <table class="table">
        <tr runat="server" id="trComplemento" visible="False">
            <td>
                <asp:Label ID="lblComplemento" runat="server" Text="Complemento"></asp:Label>
                <asp:Label ID="lblIdComplemento" runat="server" Text="0" Visible="False"></asp:Label>
                <asp:TextBox ID="txtComplemento" runat="server" Style="Width: 400px"></asp:TextBox>
            </td>
        </tr>          
        <tr runat="server" id="trDatoVehiculoTitulo" visible="False">
            <td>
                <asp:Label ID="lbldatoVehiculo" runat="server" Text=""></asp:Label>
            </td>
        </tr> 
        <tr runat="server" id="trDatoVehiculo" visible="False">
            <td>
                <textarea id="txtDatosVehiculo"
                    runat="server"
                    rows="20" cols="7"
                    style="width: 600px; height: 200px"></textarea>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblInfoFuente" runat="server" Text=""></asp:Label>
            </td>
        </tr>       
        <tr>
            <td>
                <textarea id="TextArea1"
                    runat="server"
                    rows="20" cols="7"
                    style="width: 600px; height: 200px"></textarea>


                <asp:GridView ID="gr_dato"
                    runat="server"
                    AutoGenerateColumns="False"
                    CssClass="tabla_datos"
                    OnRowCommand="gr_dato_OnRowCommand"
                    OnRowDataBound="gr_dato_OnRowDataBound"
                    DataKeyNames="id_dicom_vehiculo_detalle">

                    <Columns>
                        <asp:BoundField DataField="id_solicitud"
                            HeaderText="Nº AGP">
                            <ItemStyle CssClass="td_derecha" />
                            <HeaderStyle CssClass="td_cabecera" />
                        </asp:BoundField>

                        <asp:BoundField DataField="patente"
                            HeaderText="Patente">
                            <ItemStyle CssClass="td_derecha" />
                            <HeaderStyle CssClass="td_cabecera" />
                        </asp:BoundField>

                        <asp:TemplateField AccessibleHeaderText="fecha">
                            <HeaderTemplate>
                                <asp:Label ID="lblFechaHechoAlias"
                                    runat="server"
                                    Text="Fecha Hecho"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:TextBox ID="txtfechaHecho"
                                    Width="100%"
                                    runat="server"
                                    Text='<%# Bind("fechaHecho") %>'></asp:TextBox>
                                <cc1:CalendarExtender ID="calendar1"
                                    runat="server"
                                    TargetControlID="txtfechaHecho" />
                            </ItemTemplate>
                            <ItemStyle CssClass="td_derecha_grande" />
                            <HeaderStyle CssClass="td_cabecera_grande" />
                        </asp:TemplateField>

                        <asp:TemplateField AccessibleHeaderText="descripcion">
                            <HeaderTemplate>
                                <asp:Label ID="lblDescripcionAlias" runat="server" Text="Descripción"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:TextBox ID="txtdescripcion"
                                    Width="100%"
                                    runat="server"
                                    Text='<%# Bind("descripcion") %>'></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle CssClass="td_derecha_grande" />
                            <HeaderStyle CssClass="td_cabecera_grande" />
                        </asp:TemplateField>

                        <asp:TemplateField AccessibleHeaderText="lugar">
                            <HeaderTemplate>
                                <asp:Label ID="lblLugarAlias" runat="server" Text="Lugar"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:TextBox ID="txtlugar"
                                    Width="100%"
                                    runat="server"
                                    Text='<%# Bind("lugar") %>'></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle CssClass="td_derecha_grande" />
                            <HeaderStyle CssClass="td_cabecera_grande" />
                        </asp:TemplateField>

                        <asp:TemplateField AccessibleHeaderText="fechaInformacion">
                            <HeaderTemplate>
                                <asp:Label ID="lblFechaInformacionAlias" runat="server" Text="Fecha Infrormación"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:TextBox ID="txtfechaInformacion"
                                    runat="server"
                                    Width="100%"
                                    Text='<%# Bind("fechaInformacion") %>'></asp:TextBox>
                                <cc1:CalendarExtender ID="calendar2"
                                    runat="server"
                                    TargetControlID="txtfechaInformacion" />
                            </ItemTemplate>
                            <ItemStyle CssClass="td_derecha_grande" />
                            <HeaderStyle CssClass="td_cabecera_grande" />
                        </asp:TemplateField>

                        <asp:TemplateField AccessibleHeaderText="monto">
                            <HeaderTemplate>
                                <asp:Label ID="lblMontoAlias" runat="server" Text="Monto"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:TextBox ID="txtmonto"
                                    Width="100%"
                                    runat="server"
                                    Text='<%# Bind("monto") %>'></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle CssClass="td_derecha_grande" />
                            <HeaderStyle CssClass="td_cabecera_grande" />
                        </asp:TemplateField>

                        <asp:TemplateField AccessibleHeaderText="observacion">
                            <HeaderTemplate>
                                <asp:Label ID="lblObservacionAlias" runat="server" Text="Observación"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:TextBox ID="txtobservacion"
                                    Width="100%"
                                    runat="server"
                                    Text='<%# Bind("observacion") %>'></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle CssClass="td_derecha_grande" />
                            <HeaderStyle CssClass="td_cabecera_grande" />
                        </asp:TemplateField>

                        <asp:TemplateField AccessibleHeaderText="nombre">
                            <HeaderTemplate>
                                <asp:Label ID="lblNombreAlias" runat="server" Text="Nombre"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:TextBox ID="txtnombre"
                                    Width="100%"
                                    runat="server"
                                    Text='<%# Bind("nombre") %>'></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle CssClass="td_derecha_grande" />
                            <HeaderStyle CssClass="td_cabecera_grande" />
                        </asp:TemplateField>

                        <asp:TemplateField AccessibleHeaderText="rut">
                            <HeaderTemplate>
                                <asp:Label ID="lblRutAlias" runat="server" Text="Rut"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:TextBox ID="txtrut"
                                    Width="100%"
                                    runat="server"
                                    Text='<%# Bind("rut") %>'></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle CssClass="td_derecha_grande" />
                            <HeaderStyle CssClass="td_cabecera_grande" />
                        </asp:TemplateField>

                        <asp:TemplateField AccessibleHeaderText="arancel">
                            <HeaderTemplate>
                                <asp:Label ID="lblArancelAlias" runat="server" Text="Arancel"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:TextBox ID="txtarancel"
                                    Width="100%"
                                    runat="server"
                                    Text='<%# Bind("arancel") %>'></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle CssClass="td_derecha_grande" />
                            <HeaderStyle CssClass="td_cabecera_grande" />
                        </asp:TemplateField>

                        <asp:TemplateField AccessibleHeaderText="tipoMoneda">
                            <HeaderTemplate>
                                <asp:Label ID="lblTipoMonedaAlias" runat="server" Text="Tipo Moneda"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:TextBox ID="txttipoMoneda"
                                    Width="100%"
                                    runat="server"
                                    Text='<%# Bind("tipoMoneda") %>'></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle CssClass="td_derecha_grande" />
                            <HeaderStyle CssClass="td_cabecera_grande" />
                        </asp:TemplateField>

                        <asp:TemplateField AccessibleHeaderText="idMulta">
                            <HeaderTemplate>
                                <asp:Label ID="lblIdMultaAlias" runat="server" Text="Id Multa"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:TextBox ID="txtidMulta"
                                    Width="100%"
                                    runat="server"
                                    Text='<%# Bind("idMulta") %>'></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle CssClass="td_derecha_grande" />
                            <HeaderStyle CssClass="td_cabecera_grande" />
                        </asp:TemplateField>

                        <asp:TemplateField AccessibleHeaderText="fechaIngresoRMNP">
                            <HeaderTemplate>
                                <asp:Label ID="lblfechaIngresoRMNPAlias" runat="server" Text="Fecha Ingreso Rmnp"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:TextBox ID="txtfechaIngresoRMNP"
                                    Width="100%"
                                    runat="server"
                                    Text='<%# Bind("fechaIngresoRMNP") %>'></asp:TextBox>
                                <cc1:CalendarExtender ID="calendar3"
                                    runat="server"
                                    TargetControlID="txtfechaIngresoRMNP" />
                            </ItemTemplate>
                            <ItemStyle CssClass="td_derecha_grande" />
                            <HeaderStyle CssClass="td_cabecera_grande" />
                        </asp:TemplateField>

                        <asp:TemplateField AccessibleHeaderText="Eliminar"
                            HeaderText="Eliminar">
                            <ItemTemplate>
                                <asp:ImageButton ID="eliminar"
                                    runat="server"
                                    CommandName="Eliminar"
                                    CommandArgument='<%#((GridViewRow)Container).RowIndex %>'
                                    ImageUrl="~/imagenes/sistema/static/cancel.png" />
                                <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender2"
                                    runat="server"
                                    TargetControlID="eliminar"
                                    ConfirmText="¿Está seguro de Eliminar esta fila?" />
                            </ItemTemplate>
                            <ItemStyle CssClass="td_derecha" />
                            <HeaderStyle CssClass="td_cabecera" />
                        </asp:TemplateField>

                    </Columns>
                    <HeaderStyle CssClass="tr_cabecera" />
                    <FooterStyle CssClass="tr_cabecera" />
                    <RowStyle CssClass="tr_fila" />
                    <AlternatingRowStyle CssClass="tr_fila_alt" />
                </asp:GridView>

                <asp:GridView ID="gr2"
                    runat="server"
                    AutoGenerateColumns="False"
                    CssClass="tabla_datos"
                    OnRowCommand="gr_dato_OnRowCommand"
                    OnRowDataBound="gr2_OnRowDataBound"
                    DataKeyNames="id_dicom_vehiculo_detalle">

                    <Columns>
                        <asp:BoundField DataField="id_solicitud"
                            HeaderText="Nº AGP">
                            <ItemStyle CssClass="td_derecha" />
                            <HeaderStyle CssClass="td_cabecera" />
                        </asp:BoundField>

                        <asp:BoundField DataField="patente"
                            HeaderText="Patente">
                            <ItemStyle CssClass="td_derecha" />
                            <HeaderStyle CssClass="td_cabecera" />
                        </asp:BoundField>

                        <asp:TemplateField AccessibleHeaderText="fecha">
                            <HeaderTemplate>
                                <asp:Label ID="lblFechaHechoAlias"
                                    runat="server"
                                    Text="Fecha Hecho"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:TextBox ID="txtfechaHecho"
                                    Width="100%"
                                    runat="server"
                                    Text='<%# Bind("fechaHecho") %>'></asp:TextBox>
                                <cc1:CalendarExtender ID="calendar1"
                                    runat="server"
                                    TargetControlID="txtfechaHecho" />
                            </ItemTemplate>
                            <ItemStyle CssClass="td_derecha_grande" />
                            <HeaderStyle CssClass="td_cabecera_grande" />
                        </asp:TemplateField>

                        <asp:TemplateField AccessibleHeaderText="descripcion">
                            <HeaderTemplate>
                                <asp:Label ID="lblDescripcionAlias" runat="server" Text="Descripción"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:TextBox ID="txtdescripcion"
                                    Width="100%"
                                    runat="server"
                                    Text='<%# Bind("descripcion") %>'></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle CssClass="td_derecha_grande" />
                            <HeaderStyle CssClass="td_cabecera_grande" />
                        </asp:TemplateField>

                        <asp:TemplateField AccessibleHeaderText="lugar">
                            <HeaderTemplate>
                                <asp:Label ID="lblLugarAlias" runat="server" Text="Lugar"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:TextBox ID="txtlugar"
                                    Width="100%"
                                    runat="server"
                                    Text='<%# Bind("lugar") %>'></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle CssClass="td_derecha_grande" />
                            <HeaderStyle CssClass="td_cabecera_grande" />
                        </asp:TemplateField>

                        <asp:TemplateField AccessibleHeaderText="fechaInformacion">
                            <HeaderTemplate>
                                <asp:Label ID="lblFechaInformacionAlias" runat="server" Text="Fecha Infrormación"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:TextBox ID="txtfechaInformacion"
                                    runat="server"
                                    Width="100%"
                                    Text='<%# Bind("fechaInformacion") %>'></asp:TextBox>
                                <cc1:CalendarExtender ID="calendar2"
                                    runat="server"
                                    TargetControlID="txtfechaInformacion" />
                            </ItemTemplate>
                            <ItemStyle CssClass="td_derecha_grande" />
                            <HeaderStyle CssClass="td_cabecera_grande" />
                        </asp:TemplateField>

                        <asp:TemplateField AccessibleHeaderText="monto">
                            <HeaderTemplate>
                                <asp:Label ID="lblMontoAlias" runat="server" Text="Monto"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:TextBox ID="txtmonto"
                                    Width="100%"
                                    runat="server"
                                    Text='<%# Bind("monto") %>'></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle CssClass="td_derecha_grande" />
                            <HeaderStyle CssClass="td_cabecera_grande" />
                        </asp:TemplateField>

                        <asp:TemplateField AccessibleHeaderText="observacion">
                            <HeaderTemplate>
                                <asp:Label ID="lblObservacionAlias" runat="server" Text="Observación"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:TextBox ID="txtobservacion"
                                    Width="100%"
                                    runat="server"
                                    Text='<%# Bind("observacion") %>'></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle CssClass="td_derecha_grande" />
                            <HeaderStyle CssClass="td_cabecera_grande" />
                        </asp:TemplateField>

                        <asp:TemplateField AccessibleHeaderText="nombre">
                            <HeaderTemplate>
                                <asp:Label ID="lblNombreAlias" runat="server" Text="Nombre"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:TextBox ID="txtnombre"
                                    Width="100%"
                                    runat="server"
                                    Text='<%# Bind("nombre") %>'></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle CssClass="td_derecha_grande" />
                            <HeaderStyle CssClass="td_cabecera_grande" />
                        </asp:TemplateField>

                        <asp:TemplateField AccessibleHeaderText="rut">
                            <HeaderTemplate>
                                <asp:Label ID="lblRutAlias" runat="server" Text="Rut"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:TextBox ID="txtrut"
                                    Width="100%"
                                    runat="server"
                                    Text='<%# Bind("rut") %>'></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle CssClass="td_derecha_grande" />
                            <HeaderStyle CssClass="td_cabecera_grande" />
                        </asp:TemplateField>

                        <asp:TemplateField AccessibleHeaderText="arancel">
                            <HeaderTemplate>
                                <asp:Label ID="lblArancelAlias" runat="server" Text="Arancel"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:TextBox ID="txtarancel"
                                    Width="100%"
                                    runat="server"
                                    Text='<%# Bind("arancel") %>'></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle CssClass="td_derecha_grande" />
                            <HeaderStyle CssClass="td_cabecera_grande" />
                        </asp:TemplateField>

                        <asp:TemplateField AccessibleHeaderText="tipoMoneda">
                            <HeaderTemplate>
                                <asp:Label ID="lblTipoMonedaAlias" runat="server" Text="Tipo Moneda"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:TextBox ID="txttipoMoneda"
                                    Width="100%"
                                    runat="server"
                                    Text='<%# Bind("tipoMoneda") %>'></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle CssClass="td_derecha_grande" />
                            <HeaderStyle CssClass="td_cabecera_grande" />
                        </asp:TemplateField>

                        <asp:TemplateField AccessibleHeaderText="idMulta">
                            <HeaderTemplate>
                                <asp:Label ID="lblIdMultaAlias" runat="server" Text="Id Multa"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:TextBox ID="txtidMulta"
                                    Width="100%"
                                    runat="server"
                                    Text='<%# Bind("idMulta") %>'></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle CssClass="td_derecha_grande" />
                            <HeaderStyle CssClass="td_cabecera_grande" />
                        </asp:TemplateField>

                        <asp:TemplateField AccessibleHeaderText="fechaIngresoRMNP">
                            <HeaderTemplate>
                                <asp:Label ID="lblfechaIngresoRMNPAlias" runat="server" Text="Fecha Ingreso Rmnp"></asp:Label>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:TextBox ID="txtfechaIngresoRMNP"
                                    Width="100%"
                                    runat="server"
                                    Text='<%# Bind("fechaIngresoRMNP") %>'></asp:TextBox>
                                <cc1:CalendarExtender ID="calendar3"
                                    runat="server"
                                    TargetControlID="txtfechaIngresoRMNP" />
                            </ItemTemplate>
                            <ItemStyle CssClass="td_derecha_grande" />
                            <HeaderStyle CssClass="td_cabecera_grande" />
                        </asp:TemplateField>

                        <asp:TemplateField AccessibleHeaderText="Eliminar"
                            HeaderText="Eliminar">
                            <ItemTemplate>
                                <asp:ImageButton ID="eliminar"
                                    runat="server"
                                    CommandName="Eliminar"
                                    CommandArgument='<%#((GridViewRow)Container).RowIndex %>'
                                    ImageUrl="~/imagenes/sistema/static/cancel.png" />
                                <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender2"
                                    runat="server"
                                    TargetControlID="eliminar"
                                    ConfirmText="¿Está seguro de Eliminar esta fila?" />
                            </ItemTemplate>
                            <ItemStyle CssClass="td_derecha" />
                            <HeaderStyle CssClass="td_cabecera" />
                        </asp:TemplateField>

                    </Columns>
                    <HeaderStyle CssClass="tr_cabecera" />
                    <FooterStyle CssClass="tr_cabecera" />
                    <RowStyle CssClass="tr_fila" />
                    <AlternatingRowStyle CssClass="tr_fila_alt" />
                </asp:GridView>
                <asp:Label ID="lblMensaje"
                    runat="server"
                    Text=""></asp:Label>

            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnCrear"
                    Font-Size="X-Small"
                    runat="server"
                    CssClass="button"
                    Text="Agregar informacion" OnClick="btnCrear_Click" />
                <asp:Button ID="btnGuardarGrid"
                    runat="server"
                    CssClass="button"
                    Font-Size="X-Small"
                    OnClick="btnGuardarGrid_Click"
                    Text="Guardar cambios"
                    Visible="False" />
            </td>
        </tr>
    </table>

    <hr />
    <div class="div_objetos" id="divBotones" runat="server" style="z-index: 1">
        <center>
            <asp:ImageButton ID="ibTerminar" runat="server"
                ImageUrl="../imagenes/sistema/static/hipotecario/avanzar.png" OnClick="ibTerminar_Click" />
            <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender8" runat="server" TargetControlID="ibTerminar"
                ConfirmText="¿Está seguro de Terminar? Esta acción cambiará de estado la solicitud">
            </cc1:ConfirmButtonExtender>
        </center>


    </div>



    <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender4" runat="server" TargetControlID="btnGuardarGrid" ConfirmText="¿Está seguro de Guardar los cambios?" />
    <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="btnCrear" ConfirmText="¿Está seguro de crear?" />
    <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender5" runat="server" TargetControlID="btnIniciar" ConfirmText="¿Está seguro Iniciar la busqueda?" />
    <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender6" runat="server" TargetControlID="btnExito" ConfirmText="¿Está seguro de Finalizar con éxito?" />
    <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender7" runat="server" TargetControlID="btnFracaso" ConfirmText="Esta acción dejará la busqueda de la selección como Pendiente. ¿Desea Continuar?" />

</asp:Content>
