<%@ Page Title="" Language="C#" MasterPageFile="~/AGP.Master" AutoEventWireup="true" CodeBehind="mParametrotipo.aspx.cs" Inherits="sistemaAGP.mParametrotipo" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMenu" runat="server">
    <style type="text/css">
        .style5
        {
            width: 78px;
        }
        .style6
        {
            width: 1046px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoCentral" runat="server">
    <div class="div_subcontenido">
        <table class="table">
            <tr>
                <td class="style6">
                    <asp:Label ID="Label1" runat="server" Text="Administracion de Tipo Parametros"></asp:Label>
                </td>
            </tr>
        </table>
        <table class="table_n">
            <tr>
                <td>
                    <strong>
                        Codigo
                    </strong>
                </td>
                <td>
                    <asp:TextBox ID="txt_codigo"  runat="server" MaxLength="4" TabIndex="1"></asp:TextBox>
                </td>
                <td>
                    <strong>
                        Nombre
                    </strong>
                </td>
                <td>
                    <asp:TextBox ID="txt_nombre" runat="server" MaxLength="20" Width="190px" TabIndex="3"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
    <div class="div_objetos">
        <table class="table_sec">
            <tr>
                <td class="style5">
                    <asp:Button ID="Button1" runat="server" CssClass="button" Font-Names="Arial" Font-Size="X-Small" 
                        Text="Guardar" onclick="Button1_Click" TabIndex="16" />
                <asp:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server" 
                        TargetControlID="Button1" 
                        ConfirmText="¿Esta seguro de ingresar un tipo de parametro?" />
                </asp:ConfirmButtonExtender> 
                </td>
                <td>
                    <asp:Button ID="Button2" CssClass="button" runat="server" Font-Names="Arial" 
                        Font-Size="X-Small" onclick="Button2_Click" Text="Limpiar" Width="72px" />
                </td>
            </tr>
        </table>
    </div>
    <p />
                <asp:GridView ID="gr_dato" runat="server" 
        AutoGenerateColumns="False" CssClass="tabla_datos" 
                        CellPadding="4" Font-Names="Verdana" Font-Size="X-Small" ForeColor="#333333" 
                        onselectedindexchanged="gr_dato_SelectedIndexChanged" 
        Width="314px">
                    <RowStyle BackColor="#EFF3FB" />
                    <Columns>
                        <asp:BoundField DataField="codigotipoparametro" 
                            HeaderText="codigotipoparametro" />
                        <asp:BoundField AccessibleHeaderText="Descripcion" DataField="Descripcion" 
                                HeaderText="Descripcion" />
                    </Columns>
                    <HeaderStyle CssClass="tr_cabecera" />
                    <RowStyle CssClass="tr_fila" />
                    <AlternatingRowStyle CssClass="tr_fila_alt" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
