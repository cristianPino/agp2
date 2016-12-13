<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucServiciosAgp.ascx.cs" Inherits="sistemaAGP.controles.wucServiciosAgp" %>
<script type="text/javascript">
    function grilla_cabecera() {
        $('#<%=GrProducto.ClientID %>').Scrollable();
        $('#<%=GrDocumentos.ClientID %>').Scrollable();
    }
   </script>
<asp:UpdatePanel ID="udp" runat="server" OnLoad="upGrillaHipoteca_Load">
    <ContentTemplate>
        <asp:Panel ID="Panel1" runat="server">
      <table><tr><td>
                     <asp:GridView ID="GrProducto" runat="server" AutoGenerateColumns="false" 
                        CssClass="tabla_datos" DataKeyNames="idProd" >
                            <Columns>
                                <asp:BoundField AccessibleHeaderText="idProd" DataField="idProd" HeaderText="ID">
                                    <ItemStyle CssClass="td_derecha" />
                                    <HeaderStyle CssClass="td_cabecera" />
                                </asp:BoundField>

                                <asp:BoundField AccessibleHeaderText="productos" DataField="productos" HeaderText="SERVICIOS">
                                    <ItemStyle CssClass="td_derecha_grandexl" />
                                    <HeaderStyle CssClass="td_cabecera_grandexl" />
                                </asp:BoundField>

                                <asp:TemplateField AccessibleHeaderText="" HeaderText="" >
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CheckProd" runat="server" />
                                </ItemTemplate>
                                    <ItemStyle CssClass="td_derecha_chica" />
                                    <HeaderStyle CssClass="td_cabecera_chica" />
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle CssClass="tr_cabecera" />
                            <RowStyle CssClass="tr_fila" />
                            <AlternatingRowStyle CssClass="tr_fila_alt" />
                     </asp:GridView>
                 </td><td>
                          <asp:GridView ID="GrDocumentos" runat="server" AutoGenerateColumns="false" 
                        CssClass="tabla_datos" DataKeyNames="idProd" >
                            <Columns>
                                <asp:BoundField AccessibleHeaderText="idProd" DataField="idProd" HeaderText="ID">
                                    <ItemStyle CssClass="td_derecha" />
                                    <HeaderStyle CssClass="td_cabecera" />
                                </asp:BoundField>

                                <asp:BoundField AccessibleHeaderText="documentos" DataField="documentos" HeaderText="DOCUMENTOS ">
                                    <ItemStyle CssClass="td_derecha_grandexl" />
                                    <HeaderStyle CssClass="td_cabecera_grandexl" />
                                </asp:BoundField>

                                <asp:TemplateField AccessibleHeaderText="" HeaderText="" >
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CheckDoc" runat="server" />
                                </ItemTemplate>
                                    <ItemStyle CssClass="td_derecha_chica" />
                                    <HeaderStyle CssClass="td_cabecera_chica" />
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle CssClass="tr_cabecera" />
                            <RowStyle CssClass="tr_fila" />
                            <AlternatingRowStyle CssClass="tr_fila_alt" />
                     </asp:GridView>
                      </td></tr></table>
                     
                    
                     

            </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>