<%@ Page Title="" Language="C#" MasterPageFile="~/Master2.Master" AutoEventWireup="true"
    CodeBehind="NuevaOrden.aspx.cs" Inherits="sistemaAGP.OrdenTrabajo.NuevaOrden" %>

<%@ Register TagPrefix="cc1" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=3.5.40412.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>
<%@ Register Src="~/controles/wucServiciosAgp.ascx" TagName="Servicios" TagPrefix="uc2" %>
<%@ MasterType VirtualPath="~/Master2.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    &nbsp;<script type="text/javascript" src="../jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="../jquery.mousewheel-3.0.6.pack.js"></script>
    <script type="text/javascript" src="../jquery.fancybox.js?v=2.0.6"></script>
    <link rel="Stylesheet" type="text/css" href="../jquery.fancybox.css?v=2.0.6" media="screen" />
    <script type="text/javascript" src="../javascript/ScrollableGrid.js"></script>
    <script type="text/javascript" language="Javascript">
        function isNumberKey(evt) {
            var key = (evt.which) ? evt.which : event.keyCode;
            return (key <= 13 || (key >= 48 && key <= 57) || key == 46);
        }      
    </script><script type="text/javascript">
        function grilla_cabecera() {
            $('#<%=gr_dato.ClientID %>').Scrollable();
            $('#<%=grDoc.ClientID %>').Scrollable();
        }
    </script>
    
  <script type="text/javascript">
      function ValidaCit() {

          var txtCit = $('#<%=txtCit.ClientID %>');



          var cit = txtCit.val();

          if (cit.trim() == "") return;

          $.ajax({
              type: "POST",
              url: "../OrdenTrabajo/servicio.asmx/ValidaCit",
              data: "{'cit':'" + cit + "'}",
              contentType: "application/json; charset=utf-8",
              dataType: "json",
              success: function (response) {
                  var modeloVehiculo = response.d;
                  if (modeloVehiculo.Nombre == null) {
                      alert("No Existe un modelo para este CIT en la base de datos");
                      return;
                  }

                  var modelo = modeloVehiculo.Nombre;
                  var marca = modeloVehiculo.Marcavehiculo.Nombre;
                  var mensaje = "El CIT Ingresado corresponde a un vehículo marca " + marca + " modelo " + modelo;

                  alert(mensaje);

              },

              failure: function (msg) {
                  alert(msg);
              }

          });


                }
    </script> 
    
    
    <asp:UpdatePanel runat="server" ID="udp" UpdateMode="Conditional" OnLoad="upGrillaHipoteca_Load">
        <ContentTemplate>
            <table>
                <tr>
                    <td>
                        <asp:DropDownList ID="dlCliente" runat="server" CssClass="ddl" AutoPostBack="True"
                            OnSelectedIndexChanged="dlCliente_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="dlSucursal" runat="server" CssClass="ddl">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="dlFormaPago" runat="server" CssClass="ddl" 
                            AutoPostBack="True" onselectedindexchanged="dlFormaPago_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="dlFinanciera" runat="server" Visible="False" CssClass="ddl">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="dlQuienPaga" runat="server" CssClass="ddl">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="dlImpuestoVerde" runat="server" CssClass="ddl">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="inputs">
                        Terminación Especial
                        <asp:CheckBox ID="ck0" runat="server" Text="0" />
                        <asp:CheckBox ID="ck1" runat="server" Text="1" />
                        <asp:CheckBox ID="ck2" runat="server" Text="2" />
                        <asp:CheckBox ID="ck3" runat="server" Text="3" />
                        <asp:CheckBox ID="ck4" runat="server" Text="4" />
                        <asp:CheckBox ID="ck5" runat="server" Text="5" />
                        <asp:CheckBox ID="ck6" runat="server" Text="6" />
                        <asp:CheckBox ID="ck7" runat="server" Text="7" />
                        <asp:CheckBox ID="ck8" runat="server" Text="8" />
                        <asp:CheckBox ID="ck9" runat="server" Text="9" />
                    </td>
                    <td>
                        <input type="text" class="inputs" placeholder="Compra Para" runat="server" id="txtCompraPara" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <input type="text" class="inputs" placeholder="Cit" runat="server" id="txtCit" onblur="ValidaCit();" />
                    </td>
                    <td>
                        <input type="text" class="inputs" placeholder="Abono cliente" style="text-align: right;"
                            runat="server" id="txtAbono" onkeypress="return isNumberKey(event)" />
                    </td>
                    <td>
                        <input type="text" class="inputs" placeholder="Observación" runat="server" id="txtObservación" />
                    </td>
                </tr>
            </table>
            <br />
            <div style="float: left">
                <asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" CssClass="tabla_datos" DataKeyNames="codigo,producto"  >
                    <Columns>
                        <asp:TemplateField HeaderText="Cód">
                            <ItemTemplate>
                                <asp:HyperLink ID="codigoPro" runat="server" Text='<%# Bind("codigo") %>' />
                            </ItemTemplate>
                            <ItemStyle CssClass="td_derecha" />
                            <HeaderStyle CssClass="td_cabecera" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="producto" HeaderText="Producto">
                            <ItemStyle CssClass="td_derecha_grandexl" />
                            <HeaderStyle CssClass="td_cabecera_grandexl"/>
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Sel">
                            <ItemTemplate>
                                <asp:CheckBox ID="chk" runat="server" OnCheckedChanged="add_leido" AutoPostBack="True" />
                                <asp:HiddenField ID="hdCod" Value='<%# Bind("codigo") %>' runat="server" />
                                <asp:HiddenField ID="hdNompro" Value='<%# Bind("producto") %>' runat="server" />
                            </ItemTemplate>
                            <ItemStyle CssClass="td_derecha_chica" />
                            <HeaderStyle CssClass="td_derecha_chica" />
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle CssClass="tr_cabecera" />
                    <RowStyle CssClass="tr_fila" />
                    <AlternatingRowStyle CssClass="tr_fila_alt" />
                </asp:GridView>
            </div>
            <div style="float: left">
                <asp:GridView ID="grDoc" runat="server" AutoGenerateColumns="False" CssClass="tabla_datos"
                    DataKeyNames="idDocumento, codProducto">
                    <Columns>
                        <asp:BoundField DataField="ducumento" HeaderText="Documento">
                            <ItemStyle CssClass="td_derecha_grandexl" />
                            <HeaderStyle CssClass="td_cabecera_grandexl" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Sel">
                            <ItemTemplate>
                                <asp:CheckBox ID="chk" runat="server" />
                            </ItemTemplate>
                            <ItemStyle CssClass="td_derecha_chica" />
                            <HeaderStyle CssClass="td_derecha_chica" />
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle CssClass="tr_cabecera" />
                    <RowStyle CssClass="tr_fila" />
                    <AlternatingRowStyle CssClass="tr_fila_alt" />
                </asp:GridView>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <div class="div_objetos" id="divBotones" runat="server" style="border-top-width: 30px">
                <center>
                    <asp:ImageButton ID="ibTerminar" runat="server" ImageUrl="/imagenes/sistema/static/hipotecario/save.png"
                        OnClick="ibTerminar_Click" />
                    <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender8" runat="server" TargetControlID="ibTerminar"
                        ConfirmText="¿Está seguro de Crear?">
                    </cc1:ConfirmButtonExtender>
                </center>
            </div>
            <asp:Panel ID="pnl_aprobado_riesgo" runat="server" CssClass="modal_div">
                <div class="modal_div-texto">
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="Label8" runat="server" Font-Size="Small" ForeColor="#f1f1f1" Text="Esta solicitud requiere un número de pedido"></asp:Label>
                                <asp:Button ID="btnHiddenPhone2" runat="Server" Style="display: none;" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <input type="text" class="inputs" placeholder="Número de pedido" maxlength="9" style="text-align: right" onkeypress="return isNumberKey(event)"
                                    runat="server" id="txtNumeroPedido" />
                            </td>
                        </tr>
                        <tr runat="server" visible="true">
                            <td>
                                <input type="text" class="inputs" placeholder="Vin" style="text-align: right" runat="server"
                                    maxlength="6" id="txtVin" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnCancel" runat="server" Text="Cancelar" OnClick="btnCancel_Click"
                                    CssClass="button_rojo" />
                                <asp:Button ID="btnAdd" runat="server" Text="Aceptar" OnClick="btnAdd_Click" CssClass="buttonGris" />
                                <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" ConfirmText="¿Esta seguro de avanzar la operación a la siguinte actividad?"
                                    TargetControlID="btnAdd">
                                </cc1:ConfirmButtonExtender>
                            </td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>
            <cc1:ModalPopupExtender ID="ModalPopupExtender2" runat="server" PopupControlID="pnl_aprobado_riesgo"
                TargetControlID="btnHiddenPhone2" BackgroundCssClass="background_modal">
            </cc1:ModalPopupExtender>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnAdd" />
            <asp:PostBackTrigger ControlID="ibTerminar" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
