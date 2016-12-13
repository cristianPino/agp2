<%@ Page Title="" Language="C#" MasterPageFile="~/modal2.Master" AutoEventWireup="true"
    CodeBehind="ControlFlujo.aspx.cs" Inherits="sistemaAGP.Flujo.ControlFlujo" %>

<%@ Register TagPrefix="cc1" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=3.5.40412.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .circulo
        {
            width: 100px;
            height: 100px;
            background: #ff9200;
            -moz-border-radius: 50px;
            -webkit-border-radius: 50px;
            border-radius: 70px;
            display: table-cell;
            text-align: center;
            vertical-align: middle;
            color: #fff;
            border-color: #000;
            border-top-style: solid;
        }
        
        .circuloGrande
        {
            width: 160px;
            height: 160px;
            background: #ff9200;
            -moz-border-radius: 80px;
            -webkit-border-radius: 80px;
            border-radius: 80px;
            display: table-cell;
            text-align: center;
            vertical-align: middle;
            color: #fff;
            border-color: #000;
            border-top-style: solid;
        }
        
        .divFlujo
        {
            max-width: 80%;
            background-color: #f1f1f1;
            border: dot-dash 5px #000;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="divTituloModal" style="vert-align: middle">
       <%-- <img src="../imagenes/sistema/static/hipotecario/flujo.png" width="35px" height="35px" />--%>
       <img src="../imagenes/sistema/static/hipotecario/next-gris.png" width="35px" height="35px" />
       <img src="../imagenes/sistema/static/hipotecario/next-naranjo.png" width="35px" height="35px" />
        <asp:Label ID="Label1" runat="server" Text="Control de flujo"></asp:Label>
    </div>
    <div style="clear: both">
    </div>
    <br />
    <div class="divFlujo">
        <center>
        <table>
            <tr>
                <td>
                    <div class="circulo" id="divEstadoOrigen" runat="server" style="background: #515151;">
                        <asp:Label ID="lblOrigen" runat="server" Font-Size="x-small" Text="Label"></asp:Label>
                    </div>
                </td>
                <td>
                    <div style="float: left; padding: 10% 0;">
                        <asp:Image ID="imgFlecha1" runat="server" Height="40px" Width="40px" ImageUrl="../imagenes/sistema/static/hipotecario/next-gris.png" />
                        <asp:Image ID="Image1" runat="server" Height="40px" Width="40px" ImageUrl="../imagenes/sistema/static/hipotecario/next-gris.png" />
                        <asp:Image ID="Image4" runat="server" Height="40px" Width="40px" ImageUrl="../imagenes/sistema/static/hipotecario/next-gris.png" />
                    </div>
                </td>
                <td>
                    <div class="circulo" id="divEstadoActual" runat="server">
                        <asp:Label ID="lblActual" runat="server" Font-Size="x-small" Text="Label"></asp:Label>
                    </div>
                </td>
                <td>
                    <div style="float: left; padding: 10% 0;">
                        <asp:Image ID="imgFlecha2" runat="server" Height="40px" Width="40px" ImageUrl="../imagenes/sistema/static/hipotecario/next-naranjo.png" />
                        <asp:Image ID="Image2" runat="server" Height="40px" Width="40px" ImageUrl="../imagenes/sistema/static/hipotecario/next-naranjo.png" />
                        <asp:Image ID="Image3" runat="server" Height="40px" Width="40px" ImageUrl="../imagenes/sistema/static/hipotecario/next-naranjo.png" />
                    </div>
                </td>
                <td>
                    <div class="circuloGrande" style="background: #0a79b4;">
                        <asp:Image ID="imgCono" runat="server" Height="40px" Width="40px" Visible="False"
                            ToolTip="El siguiente estado no es manual" ImageUrl="../imagenes/sistema/static/hipotecario/cono_blanco.png" />
                        <asp:DropDownList ID="dlEstados" Font-Size="x-small" runat="server" Width="140px">
                        </asp:DropDownList>
                    </div>
                </td>
            </tr>
        </table></center>
        <br />
        <br />
        <asp:RequiredFieldValidator ID="reqValidEstados" runat="server" ControlToValidate="dlEstados" Display="Dynamic" ErrorMessage="Ups! Seleccione un estado." InitialValue="0"
            ValidationGroup="ibTerminar"></asp:RequiredFieldValidator>
        <div class="div_objetos" id="divBotones" runat="server" style="border-top-width: 30px;
            max-width: 90%">
            <center>
                <table>
                    <tr>
                        <td runat="server" id="tdComentario">
                            <input type="text" class="inputs" placeholder="Comentarios" runat="server" id="txtObservacion" />
                        </td>
                        <td>
                            <asp:ImageButton ID="ibTerminar" runat="server" ImageUrl="../imagenes/sistema/static/hipotecario/avanzar.png"
                                OnClick="ibTerminar_Click" />
                        </td>
                    </tr>
                </table>
            </center>
            <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender8" runat="server" TargetControlID="ibTerminar"
                ConfirmText="¿Está seguro de Avanzar?">
            </cc1:ConfirmButtonExtender>
        </div>
        <br />
        <br />
        <center>        <asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" DataKeyNames="id_estado,activo"
            CssClass="tabla_datos" OnRowDataBound="gr_dato_RowDataBound">
            <Columns>
                <asp:HyperLinkField DataTextField="estado" HeaderText="Estado">
                    <ItemStyle CssClass="td_derecha_grande" />
                    <HeaderStyle CssClass="td_derecha_grande" />
                </asp:HyperLinkField>
                <asp:BoundField DataField="cuenta_usuario" HeaderText="cuenta usuario" Visible="False" />
                <asp:BoundField DataField="nombre_usuario" HeaderText="Usuario">
                    <ItemStyle CssClass="td_derecha" />
                    <HeaderStyle CssClass="td_derecha" />
                </asp:BoundField>
                <asp:BoundField DataField="fecha" HeaderText="Fecha Hora">
                    <ItemStyle CssClass="td_derecha" />
                    <HeaderStyle CssClass="td_derecha" />
                </asp:BoundField>
                <asp:BoundField DataField="observacion" HeaderText="Observación">
                    <ItemStyle CssClass="td_derecha_grande" />
                    <HeaderStyle CssClass="td_derecha_grande" />
                </asp:BoundField>
                <asp:BoundField DataField="contador" HeaderText="Contador">
                    <ItemStyle CssClass="td_derecha" />
                    <HeaderStyle CssClass="td_derecha" />
                </asp:BoundField>
                <asp:ImageField AccessibleHeaderText="Semaforo" DataImageUrlField="semaforo" HeaderText="Semaforo">
                    <ItemStyle CssClass="td_derecha" />
                    <HeaderStyle CssClass="td_derecha" />
                </asp:ImageField>
            </Columns>
            <HeaderStyle CssClass="tr_cabecera" />
            <RowStyle CssClass="tr_fila" />
            <AlternatingRowStyle CssClass="tr_fila_alt" />
        </asp:GridView></center>

        <br />
    </div>
    <asp:HiddenField ID="hdIdSolicitud" runat="server" />
    <asp:HiddenField ID="hdEstadoActual" runat="server" />
    <asp:HiddenField ID="hdEstadoOrigen" runat="server" />
</asp:Content>
