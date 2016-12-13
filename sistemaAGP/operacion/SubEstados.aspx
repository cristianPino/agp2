<%@ Page Title="Administracion de Participantes" Language="C#" MasterPageFile="~/Adm.Master"
    AutoEventWireup="true" CodeBehind="SubEstados.aspx.cs" Inherits="sistemaAGP.SubEstados" %>

<%@ Register Src="~/controles/wucPersonaTransferencia.ascx" TagName="DatosPersona"
    TagPrefix="agp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="../jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="../jquery.mousewheel-3.0.6.pack.js"></script>
    <script type="text/javascript" src="../jquery.fancybox.js?v=2.0.6"></script>
    <link rel="Stylesheet" type="text/css" href="../jquery.fancybox.css?v=2.0.6" media="screen" />
    <script type="text/javascript">
        $(document).ready(function () {
            $('.fancybox').fancybox({
                maxWidth: 400,
                maxHeight: 400,
                minWidth: 400,
                minHeight: 400,
                fitToView: false,
                width: 400,
                height: 400,
                autoSize: true,
                openEffect: 'elastic',
                openSpeed: 150,
                closeEffect: 'elastic',
                closeSpeed: 150,
                closeClick: false,
                closeBtn: true,
                scrolling: 'no',
                padding: 0,
                helpers: {
                    overlay: {
                        opacity: 0.5,
                        css: {
                            'background-color': 'Gray'
                        },
                        title: {
                            type: 'float'
                        }
                    }
                }
            });
        });
    </script>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="subtitulo" style="width: 50%">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/imagenes/sistema/static/panel_control/poliza.png"
            Height="34px" Width="37px" />
        &nbsp;<asp:Label ID="lbl_titulo" runat="server" Text="HITOS DEL ESTADO"></asp:Label>
    </div>
    <br />
     <div class="subtitulo" style="width: 50%">
        <asp:Image ID="Image5" runat="server" ImageUrl="~/imagenes/sistema/static/history-folder.png"
            Height="34px" Width="37px" />
        &nbsp;<asp:Label ID="Label1" runat="server" Text="Historal"></asp:Label>
    </div>
    <br/>
     <asp:GridView ID="gr_dato" runat="server" CssClass="tabla_datos" AutoGenerateColumns="False">
        
            <Columns>
                <asp:BoundField AccessibleHeaderText="Hito" DataField="hito" HeaderText="Hito">
                     <ItemStyle CssClass="td_derecha_grande"  />
					<HeaderStyle CssClass="td_cabecera_grande" />
                    </asp:BoundField>
                <asp:BoundField AccessibleHeaderText="Fecha_hito" DataField="fecha" HeaderText="Fecha Hito" >
                     <ItemStyle CssClass="td_derecha_grande"  />
					<HeaderStyle CssClass="td_cabecera_grande" />
                    </asp:BoundField>
                <asp:ImageField AccessibleHeaderText="Tipo" DataImageUrlField="tipo" HeaderText="Tipo">
                     <ItemStyle CssClass="td_derecha"  />
					<HeaderStyle CssClass="td_cabecera" />
                    </asp:ImageField>
            </Columns>
                        <HeaderStyle CssClass="tr_cabecera" />
						<RowStyle CssClass="tr_fila" />
						<AlternatingRowStyle CssClass="tr_fila_alt" /> 
        </asp:GridView>
 <hr/>
 
  <div class="subtitulo" style="width: 50%">
        <asp:Image ID="Image6" runat="server" ImageUrl="../imagenes/sistema/static/mensaje_gris.png"
            Height="34px" Width="37px" />
        &nbsp;<asp:Label ID="Label2" runat="server" Text="Nuevo hito"></asp:Label>
    </div>
    <br/>
    <table class="table">
        <tr>
            <td>
                <asp:Label ID="lbl_estado" runat="server" Text="Label" Font-Names="Arial" Font-Size="X-Small"></asp:Label>
            </td>
            <td colspan="2">
                <asp:Label ID="lbl_id_estado" runat="server" Text="Label" Font-Names="Arial" Font-Size="X-Small"></asp:Label>
            </td>
             <td>
                 <asp:Image ID="Image4" ImageUrl="../imagenes/sistema/static/mensaje_verde.png"
                    runat="server" />
                <asp:RadioButton ID="rb_verde" runat="server" 
                     Checked="True" GroupName="hito"  />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbl_observacion" runat="server" Text="Hito" Font-Names="Arial" Font-Size="X-Small"></asp:Label>
            </td>
            <td colspan="2">
                <asp:TextBox ID="txt_observacion" runat="server" Height="57px" TextMode="MultiLine"
                    Width="355px" OnTextChanged="txt_observacion_TextChanged" 
                    CausesValidation="True" ValidationGroup="texto"></asp:TextBox>
            </td>
             <td >
                <asp:Image ID="Image3" ImageUrl="../imagenes/sistema/static/mensaje_amarillo.png"
                    runat="server" />
                <asp:RadioButton ID="rb_amarillo" runat="server"  
                    GroupName="hito" />
            </td>
             
        </tr>
        <tr>
             <td colspan="3">
                <asp:Button ID="Button1" runat="server" CssClass="button" Text="Guardar" 
                    OnClick="Button1_Click" ValidationGroup="texto" />
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                     ErrorMessage="(*)Observación es requerida" Font-Size="x-small" 
                     ValidationGroup="texto" 
                     ControlToValidate="txt_observacion"></asp:RequiredFieldValidator>
     
            </td>
           
            <td>
                <asp:Image ID="Image2" ImageUrl="../imagenes/sistema/static/mensaje_rojo.png" runat="server" />
                <asp:RadioButton ID="rb_rojo" runat="server"  
                    GroupName="hito" />
            </td>
           
        </tr>
    </table>

    
   
</asp:Content>
