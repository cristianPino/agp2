<%@ Page Title="" Language="C#" MasterPageFile="~/modal2.Master" AutoEventWireup="true" CodeBehind="Carga_factura.aspx.cs" Inherits="sistemaAGP.OrdenTrabajo.modal.Carga_factura" %>

<%@ Register TagPrefix="AjaxControlToolkit" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=3.5.40412.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link rel="Stylesheet" type="text/css" href="../../estilos/Master2.css" media="screen" />


<%--    <link href="../../Content/bootstrap.css" rel="stylesheet" />--%>

    <script type="text/javascript">
    
        // Tomado de http://www.quirksmode.org/blog/archives/2005/10/_and_the_winner_1.html
        addEvent = function(obj, type, fn) {
            if (obj.addEventListener)
                obj.addEventListener(type, fn, false);
            else if (obj.attachEvent) {
                obj["e" + type + fn] = fn;
                obj[type + fn] = function() { obj["e" + type + fn](window.event); };
                obj.attachEvent("on" + type, obj[type + fn]);
            }
        };
        bc_newElement = function(tag) {
            return document.createElement(tag);
        };
        bc_getElement = function(id) {
            return document.getElementById(id);
        };

        var field_count = 1;

        bc_init = function(fileId, displayId) {
            try {
                field = bc_getElement(fileId);
                field.display = bc_getElement(displayId);

                if (!field || !field.type || field.type != 'file' || !field.display) return;

                addEvent(field, 'change', bc_addField);
            } catch(ex) { bc_handleError(ex); }
        };

        bc_load = function(fileId, displayId) {
            addEvent(window, 'load', new Function("bc_init('" + fileId + "', '" + displayId + "');));
        };
        // Basado en http://the-stickman.com/web-development/javascript/updated-upload-multiple-files-with-a-single-file-element/
        bc_addField = function() {
            try {
                new_field = bc_newElement('INPUT');
                new_field.type = 'file';
                new_field.id = new_field.name = this.id.replace( /-@bc-.*$/g , "") + '-@bc-' + field_count++;
                new_field.display = this.display;
                addEvent(new_field, 'change', bc_addField);

                this.parentNode.insertBefore(new_field, this);

                li = bc_newElement('LI');

                a = bc_newElement('A');
                a.href = "#";
                a.appendChild(document.createTextNode('Quitar'));
                a.field_id = this.id;
                addEvent(a, 'click', bc_removeField);

                li.appendChild(a);
                li.appendChild(document.createTextNode(this.value.substring(this.value.search('/[^\/\]+$/'))));
                this.display.appendChild(li);

                this.style.position = 'absolute';
                this.style.left = '-1000px';
            } catch(ex) { bc_handleError(ex); }
        };
        bc_removeField = function(event) {
            try {
                (del = bc_getElement(this.field_id)).parentNode.removeChild(del);

                this.parentNode.parentNode.removeChild(this.parentNode);
                if (event && event.preventDefault)
                    event.preventDefault();
                return false;
            } catch(ex) { bc_handleError(ex); }
            return false;
        };
        bc_handleError = function(ex) { alert(ex); };
    
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <div class="divTituloModal">
        <img src="../../imagenes/sistema/static/panel_control/nominas.png" />
        <asp:Label ID="Label1" runat="server" Text="Carga de facturas"></asp:Label>
    </div>

    <asp:UpdatePanel ID="udp" runat="server" UpdateMode="Conditional">
        <ContentTemplate>

            <div style="clear:both">

            </div>
            <br />
            <asp:Panel ID="Panel_subir"
                Width="100%"
                runat="server">
                <table>
                    <tr>    
                        <td>
                             <asp:DropDownList ID="dlCliente" CssClass="ddl" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dlCliente_SelectedIndexChanged"></asp:DropDownList>
                        </td>                 
                        <td>
                             <asp:DropDownList ID="dlSucursal" CssClass="ddl" runat="server"></asp:DropDownList>
                           
                        </td>
                        </tr>                   
                    <tr>      
                        <td>
                             <asp:DropDownList ID="dlTipoPago" CssClass="ddl" runat="server"></asp:DropDownList>
                        </td>                                        
                        <td>
                             <asp:DropDownList ID="dlGrupo" CssClass="ddl" runat="server"></asp:DropDownList>
                        </td>
                        
                    </tr>
                     <tr>
                        <td>
                            <input id="inputField" type="file" runat="server" class="button" maxlength="10485760" multiple="100" max="10485760" />
                            <ul id="list_files" runat="server"></ul>
                        </td>  
                        </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btn_subir"
                                runat="server"
                                CssClass="button"
                                Text="Subir" OnClick="btn_subir_Click"/>

                            <AjaxControlToolkit:ConfirmButtonExtender ID="ConfirmButtonExtender8" runat="server" TargetControlID="btn_subir"
                                ConfirmText="¿Está seguro de Subir este archivo?" />
                        </td>
                    </tr>
                </table>


            </asp:Panel>

              <asp:Panel ID="panel_grid"
                Width="100%"
                runat="server">
                  <asp:GridView ID="gr_filas" 
                                runat="server" 
                                CssClass="tabla_mensaje" 
                                AutoGenerateColumns="False"  
                                CellPadding="4" Font-Size="X-Small"                                 
                                GridLines="None"                                 
                                EnableModelValidation="True">						
						        <Columns>
							            <asp:BoundField AccessibleHeaderText="nuevo" 
                                                    DataField="id" 
                                                    HeaderText="Nuevo Id">
							                 <ItemStyle CssClass="td_derecha"  />
								             <HeaderStyle CssClass="td_cabecera" />
						                </asp:BoundField> 
                                    
                                        <asp:BoundField AccessibleHeaderText="nombre" 
                                                    DataField="nombre" 
                                                    HeaderText="Nombre Documento">
							                 <ItemStyle CssClass="td_derecha"  />
								             <HeaderStyle CssClass="td_cabecera" />
						                </asp:BoundField> 

                                         <asp:BoundField AccessibleHeaderText="Estado" 
                                                    DataField="estado" 
                                                    HeaderText="estado">
							                 <ItemStyle CssClass="td_derecha"  />
								             <HeaderStyle CssClass="td_cabecera" />
						                </asp:BoundField> 

							            <asp:BoundField AccessibleHeaderText="observaciones" 
                                                    DataField="observaciones" 
                                                    HeaderText="Observaciones">
							                 <ItemStyle CssClass="td_derecha_mediana"  />
								             <HeaderStyle CssClass="td_cabecera_mediana" />
						                </asp:BoundField>  	
							           
						        </Columns>
                                <HeaderStyle CssClass="tr_cabecera" />
						        <RowStyle CssClass="tr_fila" />
						        <AlternatingRowStyle CssClass="tr_fila_alt" />	
					        </asp:GridView>



                  </asp:Panel>


        </ContentTemplate>
          <Triggers>
                <asp:PostBackTrigger ControlID="btn_subir" />
            </Triggers>
    </asp:UpdatePanel>

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
