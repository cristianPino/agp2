<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucIncidenciaInicio.ascx.cs" Inherits="sistemaAGP.controles.wucIncidenciaInicio" %>
<%@ Register TagPrefix="cc1" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=3.5.40412.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>

<asp:UpdatePanel ID="udp_wuc_incidencia_inicio" runat="server" UpdateMode="Conditional">
    <ContentTemplate>

    </ContentTemplate>
</asp:UpdatePanel>

<table>
    <tr>
        <td>
            <span>¿Cargo Cliente?</span>
        </td>
        <td>
            <asp:DropDownList ID="dlCargoCliente" runat="server" CssClass="ddl" Width="300px">
                <asp:ListItem Selected="True" Value="1">Sí</asp:ListItem>
                <asp:ListItem Value="0">No</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
            <span>Tipo de cierre</span>
        </td>
        <td>
            <asp:DropDownList ID="dlTipoCierre" runat="server" CssClass="ddl" Width="300px">
                <asp:ListItem Selected="True" Value="1">Crear nueva operación</asp:ListItem>
                <asp:ListItem Value="2">Cerrar con comentario</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
            <span>Próximo usuario</span>
        </td>
        <td>
            <asp:DropDownList ID="dlAsignarUsuario" runat="server" CssClass="ddl" Width="300px"></asp:DropDownList>
        </td>
    </tr>
     <tr>
        <td>
            <span>Comentario</span>
        </td>
        <td>
            <asp:TextBox ID="txtComentario" CssClass="input" Width="300px" runat="server"></asp:TextBox>
        </td>
    </tr>
</table>

<asp:Panel runat="server" ID="pnel_seleccion_operacion">
    <table>
        <tr>
            <td>
                <span>Esta incidencia puede tener alguna operación de origen. De ser así seleccione la posible operación</span>
            </td>
        </tr>
        <tr>
            <td>
                <hr />
            </td>
        </tr>
        <tr>
            <td>
                 <asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" DataKeyNames="id_solicitud" CssClass="tabla_datos">
            <Columns>  
                <asp:BoundField DataField="id_solicitud" HeaderText="Id Solicitud">
                    <ItemStyle CssClass="td_derecha" />
                    <HeaderStyle CssClass="td_derecha" />
                </asp:BoundField>

                <asp:BoundField DataField="patente" HeaderText="Patente">
                    <ItemStyle CssClass="td_derecha" />
                    <HeaderStyle CssClass="td_derecha" />
                </asp:BoundField>

                 <asp:BoundField DataField="chassis" HeaderText="Chasis">
                    <ItemStyle CssClass="td_derecha_grande" />
                    <HeaderStyle CssClass="td_derecha_grande" />
                </asp:BoundField>

                <asp:BoundField DataField="operacion" HeaderText="Tipo Operacion">
                    <ItemStyle CssClass="td_derecha_grande" />
                    <HeaderStyle CssClass="td_derecha_grande" />
                </asp:BoundField>
                <asp:BoundField DataField="fecha_solicitud" HeaderText="Fecha ingreso">
                    <ItemStyle CssClass="td_derecha_grande" />
                    <HeaderStyle CssClass="td_derecha_grande" />
                </asp:BoundField>
                <asp:BoundField DataField="nom_cliente" HeaderText="Cliente">
                    <ItemStyle CssClass="td_derecha_grande" />
                    <HeaderStyle CssClass="td_derecha_grande" />
                </asp:BoundField>

                <asp:BoundField DataField="nombre" HeaderText="Sucursal">
                    <ItemStyle CssClass="td_derecha"/>
                    <HeaderStyle CssClass="td_derecha" />
                </asp:BoundField>                

                <asp:TemplateField HeaderText="Sel">
				    <ItemTemplate>
                         <input name="rbSeleccion" type="radio" value='<%# Eval("id_solicitud") %>' />                     
				    </ItemTemplate>
				<ItemStyle CssClass="td_derecha"/>
				<HeaderStyle CssClass="td_derecha"/>
				</asp:TemplateField>
            </Columns>
            <HeaderStyle CssClass="tr_cabecera" />
            <RowStyle CssClass="tr_fila" />
            <AlternatingRowStyle CssClass="tr_fila_alt"/>
        </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnAsignar" runat="server" Text="Asignar ID origen" CssClass="button" OnClick="btnAsignar_Click" />
                <cc1:ConfirmButtonExtender ID="cbe_asignar" 
                                            runat="server" 
                                            TargetControlID="btnAsignar" 
                                            ConfirmText="¿Esta seguro de Asignar la incidencia?, se enviará un correo al usuario ingresador">
							</cc1:ConfirmButtonExtender>
                <asp:Button ID="btnNoAsignar" runat="server" Text="Avanzar sin asignar ID" CssClass="button" OnClick="btnNoAsignar_Click" />
                <cc1:ConfirmButtonExtender ID="cbe_no_asignar" 
                                            runat="server" 
                                            TargetControlID="btnNoAsignar" 
                                            ConfirmText="¿Esta seguro de Asignar la incidencia?, se enviará un correo al usuario ingresador">
							</cc1:ConfirmButtonExtender>
            </td>
        </tr>
    </table>



</asp:Panel>
