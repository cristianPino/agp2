<%@ Page Title="" Language="C#" MasterPageFile="~/modal2.Master" AutoEventWireup="true" 
CodeBehind="IngresoIncidencia.aspx.cs" Inherits="sistemaAGP.Incidencias.Modal.IngresoIncidencia" %>
<%@ Register TagPrefix="cc1" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=3.5.40412.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript" src="/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="/jquery.mousewheel-3.0.6.pack.js"></script>
    <script type="text/javascript" src="/jquery.fancybox.js?v=2.0.6"></script>
    <link rel="Stylesheet" type="text/css" href="/jquery.fancybox.css?v=2.0.6" media="screen" />

    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <asp:UpdatePanel runat="server" UpdateMode="Always" ID="upPrincipal">
        <ContentTemplate>
            <div class="divTituloModal">
                <img alt="" src="/imagenes/sistema/static/hipotecario/up.png" />
                <asp:Label ID="Label1" runat="server" Text="Ingreso Incidencias"></asp:Label>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>



    <div id="divIngreso" runat="server" style="width: 70%;clear:both">   
       <br />   
        
        <table class="tabla-normal">
            <tr>
                <td>
                    <span>Tipo</span>
                </td>
                <td>
                    <asp:DropDownList ID="dlTipoIncidencia" runat="server" CssClass="ddl"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <span>Cliente</span>
                </td>
                <td>
                    <asp:DropDownList ID="dlCliente" runat="server" CssClass="ddl" AutoPostBack="True" OnSelectedIndexChanged="dlCliente_SelectedIndexChanged"></asp:DropDownList>
                </td>
                <td>
                    <span>Sucursal</span>
                </td>
                <td>
                    <asp:DropDownList ID="dlSucursal" runat="server" CssClass="ddl"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <span>Patente</span>
                </td>
                <td>
                    <input type="text" class="inputs" placeholder="Patente" maxlength="6" runat="server" id="txPatente"/>
                </td>
                <td>
                    <span>Chasis</span>
                </td>
                <td>
                    <input type="text" class="inputs" placeholder="Chasis" maxlength="6" runat="server" id="txtChasis"/>
                </td>               
            </tr>
            <tr>
                <td colspan="4">
                    <asp:TextBox ID="txtComentario" runat="server" CssClass="inputs" Height="100%" TextMode="MultiLine" Width="97%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                <br/>
                <center>
                    <asp:FileUpload ID="fileuploadDoc" runat="server" ForeColor="white" Enabled="false"/> <!--Enables FAlse hasta que se programe -->
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnSubeDoc" runat="server" Text="Agregar Incidencia" 
                        CssClass="button" onclick="btnSubeDoc_Click"/>
                     <cc1:ConfirmButtonExtender ID="cbe_inicio" 
                                            runat="server" 
                                            TargetControlID="btnSubeDoc" 
                                            ConfirmText="¿Esta seguro de Crear la incidencia?">
							</cc1:ConfirmButtonExtender>
                </center>    
                </td>
                
            </tr>
        </table> 
    </div>

    

    <div class="divInfo" style="clear: both" id="divInfo" runat="server">
        <center>
            <table>
                <tr>
                    <td>
                        <asp:ImageButton ID="ibSalir" runat="server" ImageUrl="~/imagenes/sistema/static/hipotecario/salir.png"
                            OnClick="ibSalir_Click" />
                    </td>
                </tr>
            </table>
        </center>
    </div>
  

</asp:Content>
