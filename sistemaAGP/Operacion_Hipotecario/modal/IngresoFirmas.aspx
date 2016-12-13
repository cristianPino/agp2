<%@ Page Title="" Language="C#" MasterPageFile="~/modal2.Master" AutoEventWireup="true" CodeBehind="IngresoFirmas.aspx.cs" Inherits="sistemaAGP.Operacion_Hipotecario.modal.IngresoFirmas" %>
<%@ Register TagPrefix="cc1" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=3.5.40412.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <script type="text/javascript" src="~/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="~/jquery.mousewheel-3.0.6.pack.js"></script>
    <script type="text/javascript" src="~/jquery.fancybox.js?v=2.0.6"></script>
    <link rel="Stylesheet" type="text/css" href="~/jquery.fancybox.css?v=2.0.6" media="screen" />
    <script type="text/javascript" src="~/javascript/ScrollableGrid.js"></script>
    <script type="text/javascript">
        $("a.fancybox").fancybox({
            maxWidth: 1000,
            maxHeight: 500,
            minWidth: 1000,
            minHeight: 500,
            autoDimensions: true,
            openEffect: 'elastic',
            closeEffect: 'elastic',
            fitToView: false,
            nextSpeed: 0, //important
            prevSpeed: 0, //important  
            beforeShow: function () {
                // added 50px to avoid scrollbars inside fancybox
                this.width = ($('.fancybox-iframe').contents().find('html').width());
                this.height = ($('.fancybox-iframe').contents().find('html').height());
            }
        });
   </script>

    <div class="divTituloModal">
        <img src="/imagenes/sistema/static/panel_control/poliza.png" /> 
        <asp:Label ID="Label1" runat="server" Text="Firmas"></asp:Label>
    </div>
    
    <asp:UpdatePanel runat="server" ID="upd" UpdateMode="Conditional">
        <ContentTemplate>

   <div style="clear: both;">
        <asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" 
            CssClass="tabla_datos" DataKeyNames="idHipotecarioFirma, idFirma, firma" 
            onrowdatabound="gr_dato_RowDataBound" >				
				<Columns>
				    <asp:TemplateField HeaderText="Firmas" >
						<ItemTemplate>
							<asp:HyperLink ID="firma" runat="server"  Text='<%# Bind("firma") %>'/>
						</ItemTemplate>
						 <ItemStyle CssClass="td_derecha_grande"  />
					<HeaderStyle CssClass="td_cabecera_grande" />                
					</asp:TemplateField>
                     <asp:BoundField DataField="fecha" HeaderText="Fecha firma">
                            <ItemStyle CssClass="td_derecha" />
                            <HeaderStyle CssClass="td_cabecera" />
                     </asp:BoundField>
                     <asp:BoundField DataField="usuario" HeaderText="Usuario">
                            <ItemStyle CssClass="td_derecha" />
                            <HeaderStyle CssClass="td_cabecera" />
                     </asp:BoundField>
                       <asp:TemplateField HeaderText="Comentario">
						<ItemTemplate>
                            <asp:TextBox ID="txtComentario" Text='<%# Bind("comentario") %>' Width="100%" runat="server"></asp:TextBox>
						</ItemTemplate>
						 <ItemStyle CssClass="td_derecha_grandexl"  />
					<HeaderStyle CssClass="td_cabecera_grandexl" />                
					</asp:TemplateField>
				   <asp:TemplateField HeaderText="Sel">
						<ItemTemplate>
                            <asp:CheckBox ID="chk" runat="server" Checked='<%# Bind("check") %>'  />
						</ItemTemplate>
						 <ItemStyle CssClass="td_derecha_chica"  />
					<HeaderStyle CssClass="td_cabecera_chica" />                
					</asp:TemplateField>
				</Columns>
				 <HeaderStyle CssClass="tr_cabecera" />
				<RowStyle CssClass="tr_fila" />
				<AlternatingRowStyle CssClass="tr_fila_alt" />   
			</asp:GridView>
      
    </div>
    <br/>
    <div style="clear: both">
        <asp:Button ID="btnAceptar" runat="server" CssClass="button" Text="Firmar" 
            onclick="btnAceptar_Click" />
         <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender8" runat="server" TargetControlID="btnAceptar"
                        ConfirmText="¿Está seguro de continuar?">
                    </cc1:ConfirmButtonExtender>
    </div>
            <asp:HiddenField ID="hdIdSolicitud" runat="server" />
            <asp:HiddenField ID="hdIdEstado" runat="server" />
     </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
