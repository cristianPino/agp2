<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucPanelControl.ascx.cs" Inherits="sistemaAGP.wucPanelControl" %>
<asp:UpdatePanel ID="up_persona" runat="server">
	<ContentTemplate>
        <table style="background-color: #669999; width: 100%">
	        <tr>
		        <td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: auto; color: #ffffff;">
			        <strong><asp:Label ID="lbl_operacion" runat="server" Text="n_operacion" /></strong>
		        </td>
                <td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: auto; color: #ffffff;">
			        <strong><asp:Label ID="lbl_cliente" runat="server" Text="" /></strong>
		        </td>
                <td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: auto; color: #ffffff;">
			        <strong><asp:Label ID="lbl_producto" runat="server" Text="" /></strong>
		        </td>
                <td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: auto; color: #ffffff;">
			        <strong><asp:Label ID="lbl_sucursal" runat="server" Text="" /></strong>
		        </td>
                <td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: auto; color: #ffffff;">
			        <strong><asp:Label ID="lbl_nfactura" runat="server" Text="" /></strong>
		        </td>
                <td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: auto; color: #ffffff;">
			        <strong><asp:Label ID="lbl_patente" runat="server" Text="" /></strong>
		        </td>
                <td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: auto; color: #ffffff;">
			        <strong><asp:Label ID="lbl_ncliente" runat="server" Text="" /></strong>
		        </td>
                <td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: auto; color: #ffffff;">
			        <strong><asp:Label ID="lbl_rutadqui" runat="server" Text="" /></strong>
		        </td>
                <td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: auto; color: #ffffff;">
			        <strong><asp:Label ID="lbl_nomadqui" runat="server" Text="" /></strong>
		        </td>
                <td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: auto; color: #ffffff;">
			        <strong><asp:Label ID="lbl_nrepertorio" runat="server" Text="" /></strong>
		        </td>
                <td style="text-align: center; padding: 0 5px 0 5px; width: 32px; height: 32px;">
                    <center>
                        <asp:HyperLink id="lnk_nomina" runat="server" data-title-id="title-nomina" data-fancybox-type="iframe" CssClass="fancybox fancybox.iframe" CausesValidation="true" AlternateText="nomina" ImageAlign="AbsMiddle" ImageUrl="~/imagenes/sistema/static/panel_control/nominas.png" NavigateUrl='<%# Bind("url_nominas") %>' OnClick="ib_nomina_Click" ValidationGroup="filtros" />
                    </center>
                </td>
                <td style="text-align: center; padding: 0 5px 0 5px; width: 32px; height: 32px;">
                    <center>
                        <asp:HyperLink id="lnk_cargar" runat="server" data-title-id="title-cargar" data-fancybox-type="iframe" CssClass="fancybox fancybox.iframe" CausesValidation="true" AlternateText="cargar" ImageAlign="AbsMiddle" ImageUrl="~/imagenes/sistema/static/panel_control/subir.png" NavigateUrl='<%# Bind("url_cargar") %>' OnClick="ib_cargar_Click" ValidationGroup="filtros"  />
                    </center>
                </td>
                <td style="text-align: center; padding: 0 5px 0 5px; width: 32px; height: 32px;">
                    <center>
                        <asp:HyperLink id="lnk_cdigital" runat="server" CausesValidation="true" AlternateText="cdigital" ImageAlign="AbsMiddle" data-title-id="title-cdigital" data-fancybox-type="iframe" CssClass="fancybox fancybox.iframe" ImageUrl="~/imagenes/sistema/static/panel_control/carpeta.png" NavigateUrl='<%# Bind("url_digital") %>' OnClick="ib_cargar_Click" ValidationGroup="filtros" />
                    </center>
                </td>
                <td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: auto; color: #ffffff;">
			        <strong><asp:Label ID="lbl_dias" runat="server" Text="" /></strong>
		        </td>
                <td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: auto; color: #ffffff;">
			        <strong><asp:Label ID="lbl_estadoactual" runat="server" Text="" /></strong>
		        </td>
                <td style="text-align: center; padding: 0 5px 0 5px; width: 32px; height: 32px;">
                    <center>
                        <asp:HyperLink id="lnk_estado" runat="server" CausesValidation="true" AlternateText="estado" ImageAlign="AbsMiddle" data-title-id="title-work" data-fancybox-type="iframe" CssClass="fancybox fancybox.iframe" ImageUrl='<%# Bind("semaforo") %>'  NavigateUrl='<%# Bind("url_estado") %>' OnClick="ib_estado_Click" ValidationGroup="filtros" />
                    </center>
                </td>
                <td style="text-align: center; padding: 0 5px 0 5px; width: 32px; height: 32px;">
                    <center>
                        <asp:HyperLink id="lnk_poliza" runat="server" CausesValidation="true" AlternateText="poliza" ImageAlign="AbsMiddle" data-title-id="title-poliza" data-fancybox-type="iframe" CssClass="fancybox fancybox.iframe" ImageUrl="~/imagenes/sistema/static/panel_control/poliza.png" NavigateUrl='<%# Bind("url_poliza") %>' OnClick="ib_poliza_Click" ValidationGroup="filtros" />
                    </center>
                </td>
                <td style="text-align: center; padding: 0 5px 0 5px; width: 32px; height: 32px;">
                    <center>
                        <asp:HyperLink id="lnk_solicrc" runat="server" CausesValidation="true" AlternateText="solicrc" ImageAlign="AbsMiddle" data-title-id="title-solicrc" data-fancybox-type="iframe" CssClass="fancybox fancybox.iframe" ImageUrl="~/imagenes/sistema/static/panel_control/srci.png" NavigateUrl='<%# Bind("url_solicrc") %>'  OnClick="ib_solicrc_Click" ValidationGroup="filtros" />
                    </center>
                </td>
                <td style="text-align: center; padding: 0 5px 0 5px; width: 32px; height: 32px;">
                    <center>
                        <asp:HyperLink id="lnk_comgasto" runat="server" CausesValidation="true" AlternateText="comgasto" ImageAlign="AbsMiddle" Target="_blank"  CssClass="fancybox fancybox.iframe" ImageUrl="~/imagenes/sistema/static/panel_control/comprobante.png" NavigateUrl='<%# Bind("url_comgastos") %>' OnClick="ib_comgasto_Click" ValidationGroup="filtros" />
                    </center>
                </td>
                <td style="text-align: center; padding: 0 5px 0 5px; width: 32px; height: 32px;">
                    <center>
                        <asp:HyperLink id="lnk_gasto" runat="server" CausesValidation="true" AlternateText="gasto" ImageAlign="AbsMiddle" data-title-id="title-gastos" data-fancybox-type="iframe" CssClass="fancybox fancybox.iframe" ImageUrl="~/imagenes/sistema/static/panel_control/gastos.png" NavigateUrl='<%# Bind("url_gastos") %>' OnClick="ib_gasto_Click" ValidationGroup="filtros" />
                    </center>
                </td>
                <td style="text-align: center; padding: 0 5px 0 5px; width: 32px; height: 32px;">
                    <center>
                        <asp:HyperLink id="lnk_ingreso" runat="server" CausesValidation="true" AlternateText="ingreso" ImageAlign="AbsMiddle" data-title-id="title-pagos" data-fancybox-type="iframe" CssClass="fancybox fancybox.iframe" ImageUrl="~/imagenes/sistema/static/panel_control/ingresos.png" NavigateUrl='<%# Bind("url_ingreso") %>' OnClick="ib_ingreso_Click" ValidationGroup="filtros" />
                    </center>
                </td>
                <td style="text-align: center; padding: 0 5px 0 5px; width: 32px; height: 32px;">
                    <center>
                        <asp:HyperLink id="lnk_contrato" runat="server" CausesValidation="true" AlternateText="contrato" ImageAlign="AbsMiddle" data-title-id="title-contratos" data-fancybox-type="iframe" CssClass="fancybox fancybox.iframe" ImageUrl="~/imagenes/sistema/static/panel_control/poliza.png" NavigateUrl='<%# Bind("url_contratos") %>' OnClick="ib_contrato_Click" ValidationGroup="filtros" />
                    </center>
                </td>
                <td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: auto; color: #ffffff;">
			        <strong><asp:Label ID="lbl_totalgastos" runat="server" Text="" /></strong>
		        </td>
                <td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: auto; color: #ffffff;">
			        <strong><asp:Label ID="lbl_totalpagos" runat="server" Text="" /></strong>
		        </td>
                <td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: auto; color: #ffffff;">
			        <strong><asp:Label ID="lbl_saldo" runat="server" Text="" /></strong>
		        </td>
                <td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: auto; color: #ffffff;">
			        <strong><asp:Label ID="lbl_facturaemitida" runat="server" Text="" /></strong>
		        </td>
                <td style="text-align: center; padding: 0 5px 0 5px; width: 32px; height: 32px;">
                    <center>
                        <asp:ImageButton ID="bt_eliminar" runat="server" CausesValidation="false" 
                            CommandName="Delete" CommandArgument='<%# Bind("id_solicitud") %>' 
                            ImageAlign="AbsMiddle" 
                            ImageUrl="~/imagenes/sistema/static/panel_control/eliminar.png" 
                            onclick="bt_eliminar_Click1" />
                    </center>
                </td>
                <td style="text-align: center; padding: 0 5px 0 5px; width: 32px; height: 32px;">
                    <center>
                        <asp:HyperLink id="lnk_comingreso" runat="server" CausesValidation="true" AlternateText="comingreso" ImageAlign="AbsMiddle" Target="_blank" ImageUrl="~/imagenes/sistema/static/panel_control/wflow.png" NavigateUrl='<%# Bind("url_comingreso") %>' OnClick="ib_comingreso_Click" ValidationGroup="filtros" />
                    </center>
                </td>
	        </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
