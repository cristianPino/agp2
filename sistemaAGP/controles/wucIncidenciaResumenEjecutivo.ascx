<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucIncidenciaResumenEjecutivo.ascx.cs" Inherits="sistemaAGP.controles.wucIncidenciaResumenEjecutivo" %>
<table class="tabla_datos" width="100%">
                <tr>
                    <td colspan="6">
                        Mis Incidencias Activas
                    </td>
                </tr>
                <tr>                                      
                    <td class="td_derecha">
                        Fuera de sla
                        <br />
                      <asp:HyperLink ID="hpRojo" CssClass="fancybox fancybox.iframe" Font-Size="x-large" ForeColor="Red" runat="server">0</asp:HyperLink>
                        <br />
                        <asp:Label ID="lblrojasprom" runat="server" Font-Size="x-small" Text=""></asp:Label>
                    </td>
                    <td class="td_derecha">
                        Verdes<br />
                        <asp:HyperLink ID="hpVerdes" CssClass="fancybox fancybox.iframe" Font-Size="x-large" ForeColor="Green" runat="server">0</asp:HyperLink>                       
                        <br />
                        <asp:Label ID="lblVerdesprom" runat="server" Font-Size="x-small" Text=""></asp:Label>
                    </td>
                    <td class="td_derecha">
                        Amarillas<br />
                       <asp:HyperLink ID="hpAmarillo" CssClass="fancybox fancybox.iframe" Font-Size="x-large" ForeColor="#CC9900" runat="server">0</asp:HyperLink>
                        <br />
                        <asp:Label ID="lblAmarillasprom" runat="server" Font-Size="x-small" Text=""></asp:Label>
                    </td>  
                      <td class="td_derecha">
                        Total Operaciones
                        <br />
                         <asp:HyperLink ID="hpTotal" CssClass="fancybox fancybox.iframe" Font-Size="x-large" runat="server">0</asp:HyperLink>
                    </td>
                </tr>
    </table>
