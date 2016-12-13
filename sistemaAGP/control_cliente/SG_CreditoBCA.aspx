<%@ Page Title="" Language="C#" MasterPageFile="~/AGP.Master" AutoEventWireup="true" CodeBehind="SG_CreditoBCA.aspx.cs" Inherits="sistemaAGP.control_cliente.SG_CreditoBCA" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMenu" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoCentral" runat="server">
<table>
    <tr>
        <td>
            <asp:Label ID="Label1" runat="server" Text="Creditos Crediautos"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;
        </td>
    </tr> 
    <tr>
        <td>
            <asp:gridview id="grdResultado" runat="server" allowpaging="True" autogeneratecolumns="False"
					 width="850px" allowsorting="True" enablemodelvalidation="True"	autopostback="true" onrowdatabound="grdResultado_RowDataBound">
                <EmptyDataTemplate>
                    <table>
                        <tr align="center">
                            <td class="ms-input">
                                No existen registros de creditos Ortorgados no Pagados.
                            </td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <Columns>      
                    <asp:BoundField DataField="id_solicitud" HeaderText="Nro AGP" />
                    <asp:BoundField DataField="N_interno" HeaderText="Nro Credito" />
                    <asp:BoundField DataField="Cliente" HeaderText="Cliente" />
                    <asp:BoundField DataField="Estado" HeaderText="Estado" />
                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                    <asp:BoundField DataField="OBS" HeaderText="Observación" />
                    <asp:TemplateField HeaderText="Pagado">
                        <ItemTemplate>
                            <asp:RadioButton ID="rdb_Pagado" runat="server" GroupName="Credito" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Anulado">
                        <ItemTemplate>
                            <asp:RadioButton ID="rdb_Anulado" runat="server" GroupName="Credito" />
                        </ItemTemplate>
                    </asp:TemplateField>

                       <asp:TemplateField HeaderText="Carpeta Digital">
                       <ItemTemplate>
                        <asp:ImageButton ID="ib_cdigital" runat="server" ImageUrl="../imagenes/sistema/static/carpetas.gif" Width="20px" Height="20px" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Font-Names="Verdana" Font-Size="8pt" />
                <EditRowStyle BackColor="#999999" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" Font-Names="Times New Roman"
                    Font-Size="9pt" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" Font-Size="8pt"
                    Font-Names="Verdana,sans-serif" />
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" Font-Names="Verdana" Font-Size="8pt" />
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;
        </td>
    </tr> 
    <tr>
        <td>
            <asp:Label ID="Label2" runat="server" Text="Observacion:"></asp:Label>&nbsp;
            <asp:TextBox ID="txt_obs" runat="server" TextMode="MultiLine" Height="70px" 
                Width="500px"></asp:TextBox>
        </td>
    </tr> 

    <tr>
        <td>
            <asp:Button ID="btn_Aceptar" runat="server" Text="Aceptar"  Enabled="false"
                onclick="btn_Aceptar_Click" />
        </td>
    </tr>

</table>
</asp:Content>
