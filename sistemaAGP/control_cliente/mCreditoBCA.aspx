<%@ Page Title="" Language="C#" MasterPageFile="~/Adm.Master" AutoEventWireup="true" CodeBehind="mCreditoBCA.aspx.cs" Inherits="sistemaAGP.control_cliente.mCreditoBCA" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table width="100%">
    <tr>
        <td></td>
        <td></td>
        <td></td>
    </tr>
    <tr>
        <td colspan="3">&nbsp;</td>
    </tr>
    <tr>
        <td colspan="3">&nbsp;</td>
    </tr>
    <tr>
        <td colspan="3" align="center">
         <asp:gridview id="grdResultado" runat="server" allowpaging="false" autogeneratecolumns="False"
					onrowdatabound="grdResultado_RowDataBound" onrowcreated="grdResultado_RowCreated"
					onrowcommand="grdResultado_RowCommand" width="850px" allowsorting="True" enablemodelvalidation="True"
					autopostback="true">
                <EmptyDataTemplate>
                    <table>
                        <tr align="center">
                            <td class="ms-input">
                                No existen registros.
                            </td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <Columns>      
                    <asp:BoundField DataField="id_solicitud" HeaderText="Nro Credito Interno" ItemStyle-Width="20%" />
                    <asp:BoundField DataField="Estado" HeaderText="Estado"  ItemStyle-Width="25%"/>
                    <asp:BoundField DataField="Cliente" HeaderText="Cliente"  ItemStyle-Width="50%"/>
                    <asp:TemplateField HeaderText="Pagado"  ItemStyle-Width="5%">
                        <ItemTemplate>
                            <asp:CheckBox ID="ChkPago" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="IdSolicitud" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lbl_IdSolicitud" runat="server" Text='<%# Bind("id_solicitud") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="RutCliente" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lbl_RutCliente" runat="server" Text='<%# Bind("rutCliente") %>'></asp:Label>
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
        <td colspan="3">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td colspan="3">
            <asp:Button ID="bt_Pagar" runat="server" Text="Pagar" 
                onclick="bt_Pagar_Click" />
        </td>
    </tr>
        <tr>
        <td colspan="3">
            <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red"></asp:Label>
        </td>
    </tr>
</table>
</asp:Content>
