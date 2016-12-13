<%@ Page Title="" Language="C#" MasterPageFile="~/Adm.Master" AutoEventWireup="true" CodeBehind="mUsuarioEstado.aspx.cs" Inherits="sistemaAGP.administracion.mUsuarioEstado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="subtitulo" style="width: 50%">
        <asp:Image ID="Image1" runat="server" 
                        ImageUrl="../imagenes/sistema/static/hipotecario/Logo.png" 
                        Height="34px" 
                        Width="37px" />
        &nbsp;<asp:Label ID="lbl_titulo" runat="server" Text="ESTADOS POR USUARIO"></asp:Label>
    </div>
    <br/>
    <asp:UpdatePanel runat="server" ID="Upt" UpdateMode="Conditional">
        <ContentTemplate>
    <table class="table">
        <tr>
            <td>
                Familia
            </td>
            <td>
                <asp:DropDownList ID="dlFamilia" runat="server" AutoPostBack="True"
                    onselectedindexchanged="dlFamilia_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
    </table>
    
    <asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" 
                        Font-Size="X-Small"  CssClass="tabla_datos" 
                        GridLines="None" EnableModelValidation="True" DataKeyNames="codigoEstado">
                        <Columns>
                        <asp:BoundField AccessibleHeaderText="codigoEstado" DataField="codigoEstado" HeaderText="Cód.">
                        <ItemStyle CssClass="td_derecha_chica"  />
					    <HeaderStyle CssClass="td_cabecera_chica" />
                        </asp:BoundField>
                        <asp:BoundField AccessibleHeaderText="nombre" DataField="estadoNombre" HeaderText="Estado" >
                        <ItemStyle CssClass="td_derecha_grande"  />
					    <HeaderStyle CssClass="td_cabecera_grande" />
                        </asp:BoundField>
                        
                        <asp:TemplateField HeaderText="SoloLectura" >
                        <ItemTemplate >
                            <asp:CheckBox ID="chkSoloLectura" runat="server" EnableViewState="true"  Checked='<%# Bind("checkSoloLectura")  %>' />
                        </ItemTemplate>
                        <ItemStyle CssClass="td_derecha"  />
					    <HeaderStyle CssClass="td_cabecera" />
                        </asp:TemplateField>
                       
                        <asp:TemplateField HeaderText="Guardar" >
                        <ItemTemplate >
                            <asp:CheckBox ID="chkExiste" runat="server" EnableViewState="true"  Checked='<%# Bind("checkExiste")  %>' />
                        </ItemTemplate>
                        <ItemStyle CssClass="td_derecha"  />
					    <HeaderStyle CssClass="td_cabecera" />
                        </asp:TemplateField>
                        </Columns>
                        <HeaderStyle CssClass="tr_cabecera" />
				        <RowStyle CssClass="tr_fila" />
				        <AlternatingRowStyle CssClass="tr_fila_alt" />
            </asp:GridView>
            <table class="table">
                <tr>
                    <td>
                        <asp:Button ID="btnAdd" runat="server" Text="Guardar Cambios" CssClass="button" 
                            onclick="btnAdd_Click" />
                    </td>
                </tr>
            </table>
            </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
