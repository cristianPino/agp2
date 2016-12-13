<%@ Page Title="" Language="C#" MasterPageFile="~/Adm.Master" AutoEventWireup="true" CodeBehind="mHipotecaCorreoEstado.aspx.cs" Inherits="sistemaAGP.administracion.mHipotecaCorreoEstado" %>
<%@ Register TagPrefix="cc1" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=3.5.40412.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel runat="server" ID="upt1">
        <ContentTemplate>
            <div class="subtitulo" style="width: 50%">
                        <asp:Image ID="Image2" runat="server" 
                        ImageUrl="../imagenes/sistema/static/mensaje_verde.png" 
                        Height="34px" 
                        Width="37px" />
        &nbsp;<asp:Label ID="lbl_titulo" runat="server" Text="ADM CORREO HIPOTECARIO"></asp:Label>
    </div>
    <br/>
            <table class="table">
                <tr>
                    <td>
                        Familia
                    </td>
                    <td>
                        <asp:DropDownList ID="dlFamilia" runat="server" 
                            onselectedindexchanged="dlFamilia_SelectedIndexChanged" AutoPostBack="True">
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
            <br/>
            <asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" 
                        Font-Size="X-Small"  CssClass="tabla_datos" OnRowDataBound="gr_dato_RowDataBound"
                        GridLines="None" EnableModelValidation="True" DataKeyNames="codigoEstado,idFormatoCorreo">
                        
                        <Columns>
                        <asp:BoundField AccessibleHeaderText="codigoEstado" DataField="codigoEstado" HeaderText="Cód.">
                        <ItemStyle CssClass="td_derecha_chica"  />
					    <HeaderStyle CssClass="td_cabecera_chica" />
                        </asp:BoundField>
                        <asp:BoundField AccessibleHeaderText="nombre" DataField="estadoNombre" HeaderText="Estado" >
                        <ItemStyle CssClass="td_derecha_grande"  />
					    <HeaderStyle CssClass="td_cabecera_grande" />
                        </asp:BoundField>
                        
                         <asp:TemplateField HeaderText="Formato de Correo">
							<ItemTemplate>
					        <asp:DropDownList ID="dlFormatoCorreo" runat="server" Width="100%"  AutoPostBack="false" ></asp:DropDownList>
				            </ItemTemplate>
                             <ItemStyle CssClass="td_derecha_grande"  />
					    <HeaderStyle CssClass="td_cabecera_grande" />
						</asp:TemplateField>

                        <asp:TemplateField HeaderText="Ejecutivo Hipotecario" >
                        <ItemTemplate >
                            <asp:CheckBox ID="chkEjecutivo" runat="server" EnableViewState="true"  Checked='<%# Bind("checkEjecutivoH")  %>' />
                        </ItemTemplate>
                        <ItemStyle CssClass="td_derecha"  />
					    <HeaderStyle CssClass="td_cabecera" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Vendedor Hipotecario" >
                        <ItemTemplate >
                            <asp:CheckBox ID="chkVendedor" runat="server" EnableViewState="true"  Checked='<%# Bind("checkVendedorH")  %>' />
                        </ItemTemplate>
                        <ItemStyle CssClass="td_derecha"  />
					    <HeaderStyle CssClass="td_cabecera" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Comprador Hipotecario" >
                        <ItemTemplate >
                            <asp:CheckBox ID="chkComprador" runat="server" EnableViewState="true"  Checked='<%# Bind("checkCompradorH")  %>' />
                        </ItemTemplate>
                        <ItemStyle CssClass="td_derecha"  />
					    <HeaderStyle CssClass="td_cabecera" />
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Usuarios Participantes" >
                        <ItemTemplate >
                            <asp:CheckBox ID="chkUsuarios" runat="server" EnableViewState="true"  Checked='<%# Bind("checkUsuarios")  %>' />
                        </ItemTemplate>
                        <ItemStyle CssClass="td_derecha"  />
					    <HeaderStyle CssClass="td_cabecera" />
                        </asp:TemplateField>
                        
                        
                        <asp:TemplateField HeaderText="Lista de Correo" >
                        <ItemTemplate >
                            <asp:CheckBox ID="chkLista" runat="server" EnableViewState="true"  Checked='<%# Bind("checkLista")  %>' />
                        </ItemTemplate>
                        <ItemStyle CssClass="td_derecha"  />
					    <HeaderStyle CssClass="td_cabecera" />
                        </asp:TemplateField>
                        
                         <asp:TemplateField HeaderText="Lista" >
                        <ItemTemplate >
                            <asp:TextBox ID="txtListaCorreo" runat="server" Text='<%# Bind("lista")  %>' Width="100%" ></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle CssClass="td_derecha_grande"  />
					    <HeaderStyle CssClass="td_cabecera_grande" />
                        </asp:TemplateField>
                        </Columns>
                        <HeaderStyle CssClass="tr_cabecera" />
				        <RowStyle CssClass="tr_fila" />
				        <AlternatingRowStyle CssClass="tr_fila_alt" />
            </asp:GridView>
            <table class="table">
                <tr>
                    <td>
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="button" 
                            onclick="btnGuardar_Click" /></td>
                </tr>
            </table>
            <cc1:ConfirmButtonExtender ID="btnGuardarconfirm" runat="server" TargetControlID="btnGuardar" ConfirmText="¿Está seguro de guardar los cambios?" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
