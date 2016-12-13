<%@ Page Title="" Language="C#" MasterPageFile="~/Adm.Master" AutoEventWireup="true"
    CodeBehind="InfoAutoProcesos.aspx.cs" Inherits="sistemaAGP.preinscripcion.InfoAutoProcesos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="div_titulo">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/imagenes/sistema/static/infoAuto/iconoProcesos.png"
            Height="30px" Width="30px" />
        <asp:Label ID="Label2" runat="server" Text="Estado de los Procesos" Style="font-size: 18pt;
            font-weight: bold;"></asp:Label>
    </div>
    <br/>
    <table class="table">
        <tr>
            <td>
                <asp:ImageButton ID="ib_buscar" runat="server" ImageUrl="../imagenes/sistema/static/infoAuto/lupaazul.png"
                    Height="21px" Width="30px" Style="text-align: center" 
                    onclick="ib_buscar_Click"  />
            </td>
        </tr>
    </table>
    <br/>
    <asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" CssClass="tabla_datos">
        <Columns>
            <asp:TemplateField HeaderText="Paso">
                <ItemTemplate>
                    <strong>
                        <asp:HyperLink ID="lnkid" runat="server" Text='<%# Bind("descripcion") %>' /></strong>
                </ItemTemplate>
                <ItemStyle CssClass="td_derecha_grande" />
                <HeaderStyle CssClass="td_cabecera_grande" />
            </asp:TemplateField>
            <asp:BoundField AccessibleHeaderText="fecha" DataField="fechaInicio" HeaderText="Fecha Inicio">
                <ItemStyle CssClass="td_derecha_grande" />
                <HeaderStyle CssClass="td_cabecera_grande" />
            </asp:BoundField>
            <asp:BoundField AccessibleHeaderText="fechat" DataField="fechaTermino" HeaderText="Fecha Termino">
                <ItemStyle CssClass="td_derecha_grande" />
                <HeaderStyle CssClass="td_cabecera_grande" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Estado">
                <ItemTemplate>
                    <strong>
                        <asp:HyperLink ID="lnkpatente" runat="server" Text='<%# Bind("estado") %>' />
                    </strong>
                </ItemTemplate>
                <ItemStyle CssClass="td_derecha_grande" />
                <HeaderStyle CssClass="td_cabecera_grande" />
            </asp:TemplateField>
        </Columns>
        <HeaderStyle CssClass="tr_cabecera" />
        <RowStyle CssClass="tr_fila" />
        <AlternatingRowStyle CssClass="tr_fila_alt" />
    </asp:GridView>
</asp:Content>
