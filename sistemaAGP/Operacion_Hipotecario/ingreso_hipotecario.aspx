<%@ Page Title="Ingreso de Operacion Hipotecaria" Language="C#" MasterPageFile="~/Adm.Master" AutoEventWireup="true" CodeBehind="ingreso_hipotecario.aspx.cs" Inherits="sistemaAGP.Operacion_Hipotecario.ingreso_hipotecario" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/controles/wucFojas.ascx" TagName="Fojas" TagPrefix="agp" %>
<%@ Register Src="~/controles/wucOperacionParticipe.ascx" TagName="Compradores" TagPrefix="agp" %>
<%@ Register Src="~/controles/wucEjecutivoHipotecario.ascx" TagName="Ejecutivos" TagPrefix="agp" %>
<%@ Register TagPrefix="cc1" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=3.5.40412.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="../jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="../jquery.mousewheel-3.0.6.pack.js"></script>
    <script type="text/javascript" src="../jquery.fancybox.js?v=2.0.6"></script>
    <link rel="Stylesheet" type="text/css" href="../jquery.fancybox.css?v=2.0.6" media="screen" />
  <style type="text/css">
        .caja{
            width: 100%;            
            margin: auto;
            height: 0px;
            background: #2FAACE;
            box-shadow: 10px 10px 3px #D8D8D8;
            transition: height .4s;
            color: #fff;
            font-size: xx-small;
            text-align: center;
            border: solid 1px #fff;
            }
            .caja table {
                margin: 0 auto;
                text-align: left;
                }
    </style>
    <script type="text/javascript">
        // Solo permite ingresar numeros.

        function soloNumeros(e) {
           
            var key = window.Event ? e.which : e.keyCode;
            return ((key >= 48 && key <= 57) || (key == 46));
        }
</script>
    <script type="text/javascript">
        $.ajaxSetup({ cache: false });
        $(document).ready(function () {
            $('.fancybox').fancybox({
                width: Math.ceil(($(document).width() * 99) / 100),
                height: Math.ceil(($(document).height() * 99) / 100),
                maxWidth: Math.ceil(($(document).width() * 99) / 100),
                maxHeight: Math.ceil(($(document).height() * 99) / 100),
                minWidth: Math.ceil(($(document).width() * 99) / 100),
                minHeight: Math.ceil(($(document).height() * 99) / 100),  
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
        });

     

        var clic = 1;
        function divLogin() {
            if (clic == 1) {
                document.getElementById("caja").style.height = "100px";
                document.getElementById("tblDocs").style.display = "block";
                document.getElementById("doctitulo").style.display = "block";
                document.getElementById("docCerrar").style.display = "block";
                clic = clic + 1;
            } else {
                document.getElementById("caja").style.height = "0px";
                document.getElementById("tblDocs").style.display = "none";
                document.getElementById("doctitulo").style.display = "none";
                document.getElementById("docCerrar").style.display = "none";
                clic = 1;
            }
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="caja" class="caja" align="center">
       <br/> 
       <span id="doctitulo" style="display: none" >Seleccione el documento que desea crear</span>
      <center>  <table id="tblDocs" style="display: none">
            <tr>
                <td>
                    <asp:DropDownList ID="dlTipoDoc" runat="server">
                    </asp:DropDownList>
                </td>
                <td>  <asp:ImageButton ID="ibCreaBorradorEscritura" 
                                ValidationGroup="ibCreaBorradorEscritura"
                                runat="server" 
                                ImageUrl="../imagenes/sistema/static/hipotecario/crear_nuevo_doc.png" 
                                ToolTip="Crear documento" 
                                OnClick="ibCreaBorradorEscritura_Click" />
                    <ajaxToolkit:ConfirmButtonExtender ID="ConfirmButtonExtender1" 
                                                       runat="server"
                                                       TargetControlID="ibCreaBorradorEscritura" 
                                                       ConfirmText="¿Está seguro de crear el documento?"/>
                               
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" 
                                                        runat="server" 
                                                        ControlToValidate="dlTipoDoc" 
                                                        Display="Dynamic" 
                                                        ErrorMessage="Seleccione opción." 
                                                        InitialValue="0" 
                                                        ValidationGroup="ibCreaBorradorEscritura"/>
                             
                                </td>
            </tr>
        </table>
        </center>
      <a id="docCerrar" style="display: none" onclick="divLogin()">Cerrar</a>
       
    </div>
<%--    <div class="divMenuSuperior" style="display: none">
        <div class="divBotonesMenuSuperiorBotones">
            <asp:Image ID="Image1" runat="server" ImageUrl="../imagenes/sistema/static/hipotecario/Logo.png"
            Height="34px" Width="37px" />
        </div>
        
        <div class="divBotonesMenuSuperior">
            <asp:Label ID="lbl_titulo" Font-Size="xx-small" runat="server" Text=""></asp:Label>
        </div>
         <div class="divBotonesMenuSuperiorBotones">
            <asp:Label ID="Label1" Font-Size="xx-small" runat="server" Text="Datos ingreso"></asp:Label>
        </div>
         <div class="divBotonesMenuSuperiorBotones">
            <asp:Label ID="Label2" Font-Size="xx-small" runat="server" Text="Inmueble"></asp:Label>
        </div>
         <div class="divBotonesMenuSuperiorBotones">
            <asp:Label ID="Label3" Font-Size="xx-small" runat="server" Text="Ejecutivo"></asp:Label>
        </div>
    </div>--%>
    
    <table class="subtitulo">
        <tr>
            <td>
                <asp:Image ID="Image1" runat="server" ImageUrl="../imagenes/sistema/static/hipotecario/Logo.png" Height="34px" Width="37px" />
         &nbsp;<asp:Label ID="lbl_titulo" Font-Size="xx-small" runat="server" Text=""></asp:Label>
            </td>

        </tr>
         
        
    </table>
   

    <br />
   
    <table class="table" runat="server" id="tbl_solo_lectura" visible="False">
        <tr>
            <td>
                <asp:Image ID="Image2" runat="server" ImageUrl="../imagenes/sistema/static/hipotecario/soloLecturaGrande.png" />
            </td>
            <td>
                <asp:Label ID="lbltituloLectura" runat="server" Text="Sólo lectura"></asp:Label>
            </td>
        </tr>
    </table>
    <br />
    <asp:Panel ID="panel_cabecera" runat="server" >
        <table class="table">
            <tr>
                <td>
                    Empresa
                </td>
                <td>
                    <asp:DropDownList ID="dl_cliente" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dl_cliente_SelectedIndexChanged"
                        Enabled="False">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="lbl_operacion" runat="server" Visible="False">
                                
                    </asp:Label>
                </td>
                <td>
                    <strong>
                        <asp:Label ID="lbl_numero" runat="server" Visible="False">
                        </asp:Label></strong>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <br />
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="updateP">
        <ContentTemplate>
            <ajaxToolkit:TabContainer ID="tab_opciones" runat="server" Width="100%" ActiveTabIndex="7"
                ScrollBars="Auto">
                <ajaxToolkit:TabPanel ID="tab_cliente" runat="server" HeaderText="DATOS INGRESO *">
                    <HeaderTemplate>
                        DATOS INGRESO (*)
                    
</HeaderTemplate>

<ContentTemplate>
                        <table class="table">
                            <tr>
                                <td>
                                    <strong>DATOS OPERACION</strong>
                                </td>
                            </tr>
                        </table>
                        <asp:Panel ID="panel_operacion" runat="server">
                            <table class="table">
                                <tr>
                                    <td>
                                        Ejecutivo (*)
                                    </td>
                                    <td>
                                        <asp:Label ID="lblEjecutivo" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        Sucursal Origen (*)
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="dl_sucursal_origen" runat="server" OnSelectedIndexChanged="dl_sucursal_origen_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Nº Interno (*)
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_numero_interno" runat="server" MaxLength="10"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl_tasador" runat="server" Text="Tasador" Visible="False"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="dl_tasador" runat="server" OnSelectedIndexChanged="dl_tasador_SelectedIndexChanged1"
                                            Visible="False">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <table class="table" id="tbl_participantes" runat="server">
                                <tr runat="server">
                                     <td id="Td3" runat="server" visible="False">
                                        <asp:HyperLink ID="hpParticipantes" runat="server" ToolTip="Agregar Participantes"
                                            class="fancybox fancybox.iframe" ImageUrl="../imagenes/sistema/static/hipotecario/comprador_adicional.png"></asp:HyperLink>
                                    </td>
                                    <td runat="server">
                                        <asp:HyperLink ID="hpCompradorAdicional" runat="server" ToolTip="Agregar Compradores"
                                            class="fancybox fancybox.iframe" ImageUrl="../imagenes/sistema/static/hipotecario/comprador_adicional.png"></asp:HyperLink>
                                    </td>
                                    <td runat="server">
                                        <asp:HyperLink ID="hpVendedorAdicional" runat="server" ToolTip="Agregar Vendedores"
                                            class="fancybox fancybox.iframe" ImageUrl="../imagenes/sistema/static/hipotecario/vendedor_adicional.png"></asp:HyperLink>
                                    </td>
                                    <td runat="server">
                                        <asp:HyperLink ID="hpOtrosParticipantes" runat="server" ToolTip="Agregar Fiador-Codeudor solidario"
                                            class="fancybox fancybox.iframe" ImageUrl="../imagenes/sistema/static/hipotecario/add participantes.png"></asp:HyperLink>
                                    </td>
                                    <td runat="server">
                                        <asp:ImageButton ID="ibActualiza" runat="server" ToolTip="Actualizar Participantes"
                                            OnClick="ibActualiza_Click" ImageUrl="../imagenes/sistema/static/panel_control/lupa.png" />
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <agp:Compradores ID="compradores1" runat="server" />
                        </asp:Panel>
                    
</ContentTemplate>
                























































</ajaxToolkit:TabPanel>
                <ajaxToolkit:TabPanel ID="tab_inmueble" runat="server" HeaderText="INMUEBLE (*)">
                    <ContentTemplate>
                        <asp:UpdatePanel runat="server" ID="updatePropiedad" UpdateMode="Conditional"><ContentTemplate>
                                <asp:Panel ID="panel_datos_propiedad" runat="server">
                                    <asp:Panel ID="id_datounico" runat="server" Width="874px">
                                        <table class="table">
                                            <tr>
                                                <td>
                                                    <strong>DATOS DE LA PROPIEDAD</strong>
                                                </td>
                                            </tr>
                                        </table>
                                        <table class="table">
                                            <tr>
                                                <td>
                                                    Tipo Propiedad (*)
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="dl_tipo_propiedad" runat="server" >
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    DFL2
                                                </td>
                                                <td>
                                                    <asp:CheckBox ID="ckDfl2" runat="server" AutoPostBack="True" 
                                                        oncheckedchanged="ckDfl2_CheckedChanged" />
                                                    <asp:CheckBox ID="ckViviendaSocial" runat="server" Text="Vivienda Social" Visible="False" />
                                                </td>
                                            </tr>

                                            <tr>
                                                
                                                <td>
                                                    Tipo ubicación
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="dlUbicacion" runat="server">
                                                    </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                    Tipo transferencia
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="dlTipoTransferencia" runat="server">
                                                    </asp:DropDownList>
                                                    </td>
                                            </tr>
                                        
                                            <tr>
                                                <td>
                                                    <span class="control">Region </span>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="dl_region" runat="server" AutoPostBack="True" 
                                                        OnSelectedIndexChanged="dl_region_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <span class="control">Prov. </span>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="dl_ciudad" runat="server" AutoPostBack="True" 
                                                        OnSelectedIndexChanged="dl_ciudad_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <span>Comuna*</span>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="dl_comuna" runat="server" AutoPostBack="True" 
                                                        OnSelectedIndexChanged="dl_comuna_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <span class="control">Direccion </span>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txt_direccion" runat="server" MaxLength="100"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <span class="control">Numero </span>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txt_numero_direccion" runat="server" MaxLength="10">
                                        
                                                    </asp:TextBox>
                                                </td>
                                                <td>
                                                    <span class="control">Complemento </span>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txt_complemento" runat="server" MaxLength="100"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Conservador
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblConservador" runat="server" Text=""></asp:Label>
                                                </td>
                                                 <td>
                                                Número de rol de la propiedad
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtNRol" runat="server"></asp:TextBox>
                                           
                                                <asp:ImageButton ID="ib_add_rol" runat="server" ImageUrl="../imagenes/sistema/static/109_AllAnnotations_Default_16x16_72.png"
                                                    OnClick="ib_add_rol_Click" Style="height: 16px" />
                                            </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <br />
                                   
                                    <table class="table">
                                        <tr>
                                        <td>
                                            ROLES
                                        </td>
                                        </tr>
                                    </table>       
                                       
                                    <asp:GridView ID="grRoles" runat="server" AutoGenerateColumns="False" CssClass="tabla_datos"
                                        EnableModelValidation="True" DataKeyNames="idRol" OnSelectedIndexChanged="gr_roles_SelectedIndexChanged">
                                        <Columns>
                                            <asp:BoundField DataField="fila" HeaderText="Fila">
                                                <ItemStyle CssClass="td_derecha" />
                                                <HeaderStyle CssClass="td_cabecera" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="numeroRol" HeaderText="Número Rol ">
                                                <ItemStyle CssClass="td_derecha" />
                                                <HeaderStyle CssClass="td_cabecera" />
                                            </asp:BoundField>
                                            <asp:CommandField SelectText="Quitar" ShowSelectButton="True" />
                                        </Columns>
                                        <HeaderStyle CssClass="tr_cabecera" />
                                        <RowStyle CssClass="tr_fila" />
                                        <AlternatingRowStyle CssClass="tr_fila_alt" />
                                    </asp:GridView>
                                    <br />
                                    <table class="table">
                                        <tr>
                                            <td>
                                                <strong>FOJAS</strong>
                                            </td>
                                        </tr>
                                    </table>
                                    <table class="table" id="tblFojas" runat="server">
                                        <tr>
                                            <td>
                                                Inscripcion Fojas
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txt_i_fojas" runat="server" MaxLength="10" Width="85px">0</asp:TextBox>
                                                 <asp:RegularExpressionValidator ID="RegularExpressionValidator3" 
                                                    runat="server" ControlToValidate="txt_i_fojas" ErrorMessage="Solo números" 
                                                    ValidationExpression="\d+" ValidationGroup="iFoja"></asp:RegularExpressionValidator>
                                            </td>
                                            <td>
                                                Letra
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txt_i_fojas_letras" runat="server"  MaxLength="10" Width="85px"></asp:TextBox>
                                               
                                            </td>
                                            </tr>
                                            <tr>
                                            <td>
                                                Inscripcion Numero
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txt_i_numero" runat="server" Width="85px">0</asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                                                    ControlToValidate="txt_i_numero" ErrorMessage="Sólo Número" 
                                                    ValidationExpression="\d+" ValidationGroup="iFoja"></asp:RegularExpressionValidator>
                                            </td>
                                             
                                 
                                     
                                            <td>
                                                Inscripcion Año
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txt_i_ano" runat="server" MaxLength="10" Width="85px" AutoPostBack="True"
                                                    ValidationGroup="iFoja" OnTextChanged="txt_i_ano_TextChanged" onKeyPress="return soloNumeros(event)">0</asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_i_ano"
                                                    ErrorMessage="Sólo Número" ValidationExpression="\d+"></asp:RegularExpressionValidator>
                                            </td>
                                            </tr>
                                            <tr>
                                            <td>
                                                Observación
                                            </td>
                                            <td colspan="2">
                                                <asp:TextBox ID="txt_i_observacion" runat="server" MaxLength="500" 
                                                    onBlur="if (this.value.trim()=='')this.value='Escribe una observación...';" 
                                                    onFocus="if (this.value=='Escribe una observación...') this.value='';" 
                                                    Width="100%">Escribe una observación...</asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ibAgregarFojas" runat="server" 
                                                    ImageUrl="../imagenes/sistema/static/109_AllAnnotations_Default_16x16_72.png" 
                                                    onclick="ibAgregarFojas_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                    <br />
                                    <agp:Fojas ID="Fojas1" runat="server" />
                                    <br />
                                    <table class="table">
                                        <tr>
                                            <td>
                                                Descripción de Deslindes
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txt_comentarios_deslinde" runat="server" TextMode="MultiLine" Width="600"
                                                    Height="200px"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                               
       

    
                            
</ContentTemplate>
</asp:UpdatePanel>
























































                    
</ContentTemplate>
                























































</ajaxToolkit:TabPanel>
                <ajaxToolkit:TabPanel ID="tpEjecutivos" runat="server" HeaderText="EJECUTIVOS BANCO">
                    <ContentTemplate>
                        <table class="table">
                            <tr>
                                <td>
                                    <strong>INGRESO EJECUTIVOS DE LA OPERACION</strong>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <asp:Panel ID="panel_ejecutivo" runat="server">
                            <table class="table">
                                <tr>
                                    <td>
                                        Ejecutivos
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="dlEjecutivosHipotecario" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnAgregarEjecutivo" runat="server" Text="+ Agregar" CssClass="button_verde"
                                            OnClick="btnAgregarEjecutivo_Click" />
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <agp:Ejecutivos ID="EjecutivosHipotecario" runat="server"></agp:Ejecutivos>
                        </asp:Panel>
                    
</ContentTemplate>
                























































</ajaxToolkit:TabPanel>
                <ajaxToolkit:TabPanel ID="tab_hi_gra_pro" runat="server" HeaderText="H-G-P">
                    <ContentTemplate>
                        <table class="table">
                            <tr>
                                <td>
                                    <strong>HIPOTECAS GRAVAMENES Y PROHIBICIONES</strong>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <asp:Panel ID="panel_hgp" runat="server">
                            <table class="table">
                                <tr>
                                    <td>
                                        Tipo
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="dl_tipo_prohibicion" runat="server" CssClass="control" Font-Names="Arial"
                                            Font-Size="X-Small" Height="16px" TabIndex="4" Width="152px">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        Fojas
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_p_fojas" runat="server" MaxLength="6" Style="font-size: x-small;
                                            font-family: Arial, Helvetica, sans-serif" Width="65px" onKeyPress="return soloNumeros(event)"></asp:TextBox>
                                    </td>
                                     <td>
                                        Letra
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_p_letra" runat="server" Height="19px" Style="font-family: Arial, Helvetica, sans-serif;
                                            font-size: x-small" TabIndex="7" Width="73px" ></asp:TextBox>
                                    </td>
                                    <td>
                                        Numero
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_p_numero" runat="server" Height="19px" Style="font-family: Arial, Helvetica, sans-serif;
                                            font-size: x-small" TabIndex="7" Width="73px" onKeyPress="return soloNumeros(event)"></asp:TextBox>
                                    </td>
                                    <td>
                                        Año
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_p_ano" runat="server" MaxLength="10" Style="font-size: x-small; 
                                            font-family: Arial, Helvetica, sans-serif" Width="65px" OnTextChanged="txt_p_ano_TextChanged" onKeyPress="return soloNumeros(event)"></asp:TextBox>
                                    </td>
                                    <td>
                                        A favor de
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_p_a_favor_de" runat="server" Style="font-size: x-small; font-family: Arial, Helvetica, sans-serif"
                                            Width="90px"></asp:TextBox>
                                    </td>
                                    <td>
                                        Comentario
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_p_comentario" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="ib_prohibicion" runat="server" ImageUrl="../imagenes/sistema/static/109_AllAnnotations_Default_16x16_72.png"
                                            OnClick="ImageButton2_Click" />
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <asp:GridView ID="gr_prohibicion" runat="server" AutoGenerateColumns="False" DataKeyNames="id_prohibicion"
                                CssClass="tabla_datos" EnableModelValidation="True" OnSelectedIndexChanged="gr_prohibicion_SelectedIndexChanged">
                                <Columns>
                                    <asp:BoundField DataField="fila" HeaderText="Fila">
                                        <ItemStyle CssClass="td_derecha" />
                                        <HeaderStyle CssClass="td_cabecera" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="id_prohibicion" HeaderText="id_prohibicion" Visible="False">
                                        <ItemStyle CssClass="td_derecha" />
                                        <HeaderStyle CssClass="td_cabecera" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="cod_tipo" HeaderText="codigo">
                                        <ItemStyle CssClass="td_derecha" />
                                        <HeaderStyle CssClass="td_cabecera" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="tipo" HeaderText="Tipo">
                                        <ItemStyle CssClass="td_derecha" />
                                        <HeaderStyle CssClass="td_cabecera" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="fojas" HeaderText="Fojas">
                                        <ItemStyle CssClass="td_derecha" />
                                        <HeaderStyle CssClass="td_cabecera" />
                                    </asp:BoundField>
                                     <asp:BoundField DataField="letra" HeaderText="Letra">
                                        <ItemStyle CssClass="td_derecha" />
                                        <HeaderStyle CssClass="td_cabecera" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="numero" HeaderText="Numero">
                                        <ItemStyle CssClass="td_derecha" />
                                        <HeaderStyle CssClass="td_cabecera" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ano" HeaderText="Año">
                                        <ItemStyle CssClass="td_derecha" />
                                        <HeaderStyle CssClass="td_cabecera" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="a_favor" HeaderText="A favor de">
                                        <ItemStyle CssClass="td_derecha" />
                                        <HeaderStyle CssClass="td_cabecera" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="comuna" HeaderText="Conservador">
                                        <ItemStyle CssClass="td_derecha" />
                                        <HeaderStyle CssClass="td_cabecera" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="comentario" HeaderText="Comentario">
                                        <ItemStyle CssClass="td_derecha" />
                                        <HeaderStyle CssClass="td_cabecera" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Acreedor">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="lnk_acreedor" runat="server" data-title-id="title-acreedor" data-fancybox-type="iframe"
                                                CssClass="fancybox fancybox.iframe" ImageUrl="~/imagenes/sistema/static/personero.gif"
                                                NavigateUrl='<%# Bind("url_acreedor") %>' /></ItemTemplate>
                                        <ItemStyle CssClass="td_derecha_mediana_2" />
                                        <HeaderStyle CssClass="td_cabecera_mediana_2" />
                                    </asp:TemplateField>
                                    <asp:CommandField SelectText="Quitar" ShowSelectButton="True" />
                                </Columns>
                                <HeaderStyle CssClass="tr_cabecera" />
                                <RowStyle CssClass="tr_fila" />
                                <AlternatingRowStyle CssClass="tr_fila_alt" />
                            </asp:GridView>
                        </asp:Panel>
                    
</ContentTemplate>
                























































</ajaxToolkit:TabPanel>
                <ajaxToolkit:TabPanel ID="tab_Credito" runat="server" HeaderText="DATOS DE CREDITO (*)">
                    <ContentTemplate>
                        <table class="table">
                            <tr>
                                <td>
                                    <b>DATOS DE CREDITO</b>
                                </td>
                            </tr>
                        </table>
                        <asp:Panel ID="panel_credito" runat="server">
                            <table class="table">
                                <tr>
                                    <td>Fecha de Memo</td>
                                    <td>
                                        <asp:DropDownList ID="dlFechaMemo" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Tipo Crédito (*)
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="dl_tipo_credito" runat="server" Font-Names="Arial" Font-Size="X-Small"
                                            Height="16px" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small"
                                            TabIndex="17" >
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        Sub Producto
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="dlSubProductoCredito" runat="server" AutoPostBack="True"
                                            onselectedindexchanged="dlSubProductoCredito_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Precio Propiedad(UF)
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_precio" runat="server" onKeyPress="return soloNumeros(event)" MaxLength="9" Style="font-size: x-small;" Width="76px" onFocus="if (this.value=='0') this.value='';" onBlur="if (this.value.trim()=='')this.value='0';" ></asp:TextBox>
                                    </td>
                                    <td>
                                        Tasación</td>
                                    <td>
                                        <asp:TextBox ID="txt_tasacion" runat="server" onKeyPress="return soloNumeros(event)" onFocus="if (this.value=='0') this.value='';" onBlur="if (this.value.trim()=='')this.value='0';" 
                                            Font-Size="X-Small" Width="76px"></asp:TextBox>
                                        &nbsp;Uf.</td>
                                </tr>
                                <tr>
                                    <td>
                                        Monto Crédito(UF)</td>
                                    <td>
                                        <asp:TextBox ID="txt_monto_credito" runat="server" onKeyPress="return soloNumeros(event)"  onFocus="if (this.value=='0') this.value='';" onBlur="if (this.value.trim()=='')this.value='0';"
                                            MaxLength="6" Style="font-size: x-small;
                                            font-family: Arial, Helvetica, sans-serif" Width="76px"></asp:TextBox>
                                    </td>
                                    <td>
                                        Nº Crédito
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtNumeroCredito0" runat="server" Style="font-size: x-small;" 
                                            Width="76px"></asp:TextBox>
&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        Tasa
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtTasa" runat="server" Style="font-size: x-small;" 
                                            onFocus="if (this.value=='0') this.value='';" onBlur="if (this.value.trim()=='')this.value='0';"
                                            Width="76px" ontextchanged="txtTasa_TextChanged"></asp:TextBox>
                                        %</td>
                                    <td>
                                        
                                        Pié</td>
                                    <td>
                                        
                                        <asp:TextBox ID="txtPie" runat="server" Style="font-size: x-small;" onFocus="if (this.value=='0') this.value='';" onBlur="if (this.value.trim()=='')this.value='0';"
                                            Width="76px"></asp:TextBox>
                                        <asp:DropDownList ID="dlMonedaPie" runat="server" Width="60px">
                                        </asp:DropDownList>
                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Plazo en Meses
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="dlPlazoMeses" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        Meses de Gracia
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="dlMesesGracia" runat="server" AutoPostBack="True" 
                                            onselectedindexchanged="dlMesesGracia_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        VCTO. 1ºCuota
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="dlVencimientoPriemraCuota" runat="server" Width="150px" Enabled="False"> 
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        Tipo Hipoteca
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="dlTipoHipoteca" runat="server"> 
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Meses de Carencia
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="dlMescarencia1" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        y
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="dlMescarencia2" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Codeudores c/seguro
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="ckCodeudorSeguro" runat="server" AutoPostBack="True" 
                                            oncheckedchanged="ckCodeudorSeguro_CheckedChanged" />
                                    </td>
                                    <td runat="server" id="trPorcsegurocodeudordescripcion" Visible="False">
                                        Porc.
                                    </td>
                                    <td runat="server" id="trPorcsegurocodeudor" Visible="False" >
                                        <asp:DropDownList ID="dlCodeudorSeguroPorcentaje" runat="server">
                                        </asp:DropDownList>%
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Seguro invalidéz
                                    </td>
                                     <td>
                                        <asp:CheckBox ID="ckSeguroInvalidez" runat="server" />
                                    </td>
                                     <td>
                                        Seguro desempleo
                                    </td>
                                     <td>
                                        <asp:CheckBox ID="ckSeguroDesempleo" runat="server" />
                                    </td>
                                    
                                </tr>
                            </table>
                            <br />
                            
                            
                            <asp:Panel ID="panel_subsidio" Visible="False" runat="server">
                                 <table class="table">
                                <tr>
                                    <td>
                                        <strong>SUBSIDIO</strong>
                                    </td>
                                </tr>
                            </table>
                               <table class="table">
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblIdSubsidio" runat="server" Text="0" Visible="False"></asp:Label>
                                            Ahorro Previo
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSubsidioAhorroPrevio" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                           Nº Cuenta ahorro
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSubsidioNumeroCuentaAhorro" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                           Banco
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="dlSubsidioBanco" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Monto
                                        </td>
                                        <td>
                                           <asp:TextBox ID="txtSubsidioMonto" runat="server"></asp:TextBox>
                                        </td>
                                         <td>
                                            Nº serie certificado
                                        </td>
                                        <td>
                                           <asp:TextBox ID="txtSubsidioNumSerie" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            Título
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="dlSubsidioTitulo" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            Beneficiario
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="dlSubsidioBeneficiario" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <br/>
                            <asp:Panel id="PanelTasaMixta" runat="server">
                            <table class="table">
                                <tr>
                                    <td>
                                        <strong>FORMA DE PAGO</strong>
                                    </td>
                                </tr>
                            </table>
                            <table class="table">
                                <tr>
                                    <td>
                                        <asp:Label ID="lblIdFormaPago" runat="server" Text="0" Visible="False"></asp:Label>
                                        Desde el día en que rija esta obligación y 
                                        hasta el mes&nbsp; 
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="dlFinTasafija" runat="server" AutoPostBack="True" 
                                            onselectedindexchanged="dlFinTasafija_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        inclusive, la tasa será del</td>
                                    <td>
                                        <asp:TextBox ID="txt_tasa" runat="server" MaxLength="10" Style="font-size: x-small; 
                                            font-family: Arial, Helvetica, sans-serif" Width="60px" onKeyPress="return soloNumeros(event)"  onFocus="if (this.value=='0') this.value='';" onBlur="if (this.value.trim()=='')this.value='0';" >0</asp:TextBox>
                                        &nbsp;% anual</td>
                                    <td>
                                        Valor dividendo
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtValorDividendo" runat="server" MaxLength="10" Style="font-size: x-small;
                                            font-family: Arial, Helvetica, sans-serif" Width="60px" onKeyPress="return soloNumeros(event)" onFocus="if (this.value=='0') this.value='';" onBlur="if (this.value.trim()=='')this.value='0';" >0</asp:TextBox>
                                    </td>
                                    </tr>
                                    <tr>
                                    <td>
                                        A partir del día primero del mes</td>
                                    <td>
                                        <asp:DropDownList ID="dlInicioTasaMixta" runat="server" Enabled="False" 
                                            Width="150px">
                                        </asp:DropDownList>
                                        
                                    </td>
                                    <td>
                                        la tasa será de</td>
                                    <td>
                                        <asp:TextBox ID="txtTasaMixta" runat="server" Width="60px"  onKeyPress="return soloNumeros(event)" onFocus="if (this.value=='0') this.value='';" onBlur="if (this.value.trim()=='')this.value='0';" >0</asp:TextBox>
                                        &nbsp;%anual</td>
                                     <td>
                                         Valor dividendo
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtValorDividendoTasaMixta" runat="server" MaxLength="10" Style="font-size: x-small;
                                            font-family: Arial, Helvetica, sans-serif" Width="60px" onKeyPress="return soloNumeros(event)" onFocus="if (this.value=='0') this.value='';" onBlur="if (this.value.trim()=='')this.value='0';" >0</asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                            <table class="table">
                            <tr>
                                <td>
                                    Los Primeros dividendos serán de
                                </td>
                                <td>
                                     <asp:TextBox ID="txtPrimerosDividendos" runat="server" Width="60px" onKeyPress="return soloNumeros(event)"  onFocus="if (this.value=='0') this.value='';" onBlur="if (this.value.trim()=='')this.value='0';" >0</asp:TextBox> 
                                </td>
                                <td>
                                    El Último dividendo será de
                                </td>
                                <td>
                                     <asp:TextBox ID="txtUltimoDividendo" runat="server" Width="60px" onKeyPress="return soloNumeros(event)"  onFocus="if (this.value=='0') this.value='';" onBlur="if (this.value.trim()=='')this.value='0';" >0</asp:TextBox> 
                                </td>
                            </tr>
                            </table>
                            </asp:Panel>
 <br/>
                        </asp:Panel>
                    
                    
</ContentTemplate>
                























































</ajaxToolkit:TabPanel>
                <ajaxToolkit:TabPanel ID="tab_final" runat="server" HeaderText="INSCRIPCION CBR">
                    <HeaderTemplate>
                        INSCRIPCION CBR
                    
</HeaderTemplate>
                    























































<ContentTemplate>
                        <table class="table">
                            <tr>
                                <td>
                                    <b>DATOS FINALES</b>
                                </td>
                            </tr>
                        </table>
                        <asp:Panel ID="panel_dato_final" runat="server">
                            <table class="table">
                                <tr id="Tr1" runat="server">
                                    <td id="Td1" runat="server">
                                        Nº Caratula
                                    </td>
                                    <td id="Td2" runat="server">
                                        <asp:TextBox ID="txt_f_caratula" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <table class="table" id="tblFinalFojas" runat="server">
                                <tr runat="server">
                                    <td runat="server">
                                        Final fojas
                                    </td>
                                    <td runat="server">
                                        <asp:TextBox ID="txt_f_fojas" runat="server"  onKeyPress="return soloNumeros(event)"></asp:TextBox>
                                    </td>
                                     <td  runat="server">
                                        Letra
                                    </td>
                                    <td  runat="server">
                                        <asp:TextBox ID="txt_f_letra" runat="server" ></asp:TextBox>
                                    </td>
                                    <td runat="server">
                                        Final Numero
                                    </td>
                                    <td runat="server">
                                        <asp:TextBox ID="txt_f_numero" runat="server"  onKeyPress="return soloNumeros(event)"></asp:TextBox>
                                    </td>
                                    <td runat="server">
                                        Final Año
                                    </td>
                                    <td runat="server">
                                        <asp:TextBox ID="txt_f_año" runat="server" AutoPostBack="True"  onKeyPress="return soloNumeros(event)"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr runat="server">
                                    <td runat="server">
                                        <asp:Label ID="lbl_deudor" runat="server" Text="Observaciones"></asp:Label>
                                    </td>
                                    <td colspan="4" runat="server">
                                        <asp:TextBox ID="txt_observacionFinalFoja" runat="server" MaxLength="1000" Style="font-size: x-small;
                                            font-family: Arial, Helvetica, sans-serif" onFocus="if (this.value=='Escribe una observación...') this.value='';"
                                            onBlur="if (this.value.trim()=='')this.value='Escribe una observación...';" Width="100%">Escribe una observación...</asp:TextBox>
                                    </td>
                                    <td runat="server">
                                        <asp:Button ID="btnAgregarFinalFoja" runat="server" CssClass="button_verde" Text="+ Agregar"
                                            OnClick="btnAgregarFinalFoja_Click" />
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <agp:Fojas ID="FojasFinal" runat="server" />
                            <br />
                            <table class="table">
                                <tr>
                                    <td>
                                        <strong>HIPOTECAS GRAVAMENES Y PROHIBICIONES</strong>
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <table class="table">
                                <tr>
                                    <td>
                                        Tipo
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="dl_tipo_prohibicionCBR" runat="server" CssClass="control" Font-Names="Arial"
                                            Font-Size="X-Small" Height="16px" TabIndex="4" Width="152px">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        Fojas
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_p_fojasCBR" runat="server" MaxLength="6" Style="font-size: x-small;
                                            font-family: Arial, Helvetica, sans-serif" Width="65px" onKeyPress="return soloNumeros(event)"></asp:TextBox>
                                    </td>
                                    <td>
                                        Letra
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_p_fojasLetraCBR" runat="server" Height="19px" Style="font-family: Arial, Helvetica, sans-serif;
                                            font-size: x-small" TabIndex="7" Width="73px"></asp:TextBox>
                                    </td>
                                    <td>
                                        Numero
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_p_numeroCBR" runat="server" Height="19px" Style="font-family: Arial, Helvetica, sans-serif;
                                            font-size: x-small" TabIndex="7" Width="73px" onKeyPress="return soloNumeros(event)"></asp:TextBox>
                                    </td>
                                    <td>
                                        Año
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_p_anoCBR" runat="server" MaxLength="10" Style="font-size: x-small;
                                            font-family: Arial, Helvetica, sans-serif" Width="65px" onKeyPress="return soloNumeros(event)" OnTextChanged="txt_p_anoCBR_TextChanged"></asp:TextBox>
                                    </td>
                                    <td>
                                        A favor de
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_p_a_favor_deCBR" runat="server" Style="font-size: x-small; font-family: Arial, Helvetica, sans-serif"
                                            Width="90px"></asp:TextBox>
                                    </td>
                                    <td>
                                        Comentario
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_p_comentarioCBR" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="ib_prohibicionCBR" runat="server" ImageUrl="../imagenes/sistema/static/109_AllAnnotations_Default_16x16_72.png"
                                            OnClick="ib_prohibicionCBR_Click" />
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <asp:GridView ID="gr_prohibicionCBR" runat="server" AutoGenerateColumns="False" DataKeyNames="id_prohibicion"
                                CssClass="tabla_datos" EnableModelValidation="True" OnSelectedIndexChanged="gr_prohibicionCBR_SelectedIndexChanged">
                                <Columns>
                                    <asp:BoundField DataField="fila" HeaderText="Fila">
                                        <ItemStyle CssClass="td_derecha" />
                                        <HeaderStyle CssClass="td_cabecera" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="id_prohibicion" HeaderText="id_prohibicion" Visible="False">
                                        <ItemStyle CssClass="td_derecha" />
                                        <HeaderStyle CssClass="td_cabecera" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="cod_tipo" HeaderText="codigo">
                                        <ItemStyle CssClass="td_derecha" />
                                        <HeaderStyle CssClass="td_cabecera" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="tipo" HeaderText="Tipo">
                                        <ItemStyle CssClass="td_derecha" />
                                        <HeaderStyle CssClass="td_cabecera" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="fojas" HeaderText="Fojas">
                                        <ItemStyle CssClass="td_derecha" />
                                        <HeaderStyle CssClass="td_cabecera" />
                                    </asp:BoundField>
                                   <asp:BoundField DataField="letra" HeaderText="Letra">
                                        <ItemStyle CssClass="td_derecha" />
                                        <HeaderStyle CssClass="td_cabecera" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="numero" HeaderText="Numero">
                                        <ItemStyle CssClass="td_derecha" />
                                        <HeaderStyle CssClass="td_cabecera" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ano" HeaderText="Año">
                                        <ItemStyle CssClass="td_derecha" />
                                        <HeaderStyle CssClass="td_cabecera" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="a_favor" HeaderText="A favor de">
                                        <ItemStyle CssClass="td_derecha" />
                                        <HeaderStyle CssClass="td_cabecera" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="comuna" HeaderText="Conservador">
                                        <ItemStyle CssClass="td_derecha" />
                                        <HeaderStyle CssClass="td_cabecera" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="comentario" HeaderText="Comentario">
                                        <ItemStyle CssClass="td_derecha" />
                                        <HeaderStyle CssClass="td_cabecera" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Acreedor">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="lnk_acreedor" runat="server" data-title-id="title-acreedor" data-fancybox-type="iframe"
                                                CssClass="fancybox fancybox.iframe" ImageUrl="~/imagenes/sistema/static/personero.gif"
                                                NavigateUrl='<%# Bind("url_acreedor") %>' /></ItemTemplate>
                                        <ItemStyle CssClass="td_derecha_mediana_2" />
                                        <HeaderStyle CssClass="td_cabecera_mediana_2" />
                                    </asp:TemplateField>
                                    <asp:CommandField SelectText="Quitar" ShowSelectButton="True" />
                                </Columns>
                                <HeaderStyle CssClass="tr_cabecera" />
                                <RowStyle CssClass="tr_fila" />
                                <AlternatingRowStyle CssClass="tr_fila_alt" />
                            </asp:GridView>
                        </asp:Panel>
                    
</ContentTemplate>
                























































</ajaxToolkit:TabPanel>
                <ajaxToolkit:TabPanel ID="tab_tasador" runat="server" HeaderText="TASADOR" Visible="false">
                    <ContentTemplate>
                        <asp:Panel ID="panel_tasador" runat="server">
                            <table class="table">
                                <tr>
                                    <td>
                                        Valor Comercial(UF)
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_valor_comercial" runat="server"  onKeyPress="return soloNumeros(event)" ></asp:TextBox>
                                    </td>
                                    <td>
                                        Metros Edificados
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_metros_edificados" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        Permiso Edificacion
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_permiso_edificacion" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Valor Liquidez (UF)
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_valor_liquidez" runat="server" onKeyPress="return soloNumeros(event)"></asp:TextBox>
                                    </td>
                                    <td>
                                        Metros Terreno
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_metros_terreno" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        Estado General Obra
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_estado_obra" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Valor Seguro (UF)
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_valor_seguro" runat="server" onKeyPress="return soloNumeros(event)" ></asp:TextBox>
                                    </td>
                                    <td>
                                        Superficie a Valorar
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_superficie_valorar" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        Urbanizacion
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_urbanizacion" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Leyes Acogidas
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txt_leyes_acogidas" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    
</ContentTemplate>

    


















</ajaxToolkit:TabPanel>        
                <ajaxToolkit:TabPanel ID="tab_documentos" runat="server" HeaderText="DOCUMENTOS"
                    Visible="True">
                    <ContentTemplate>
                      
           
    <br/>
            
            <asp:GridView ID="gr_documentos" runat="server" AutoGenerateColumns="False" 
						CssClass="tabla_datos" 
						DataKeyNames="id_documento_operacion,id_solicitud,id_documento,url" 
						GridLines="None" OnRowCommand="gr_documentos_RowCommand"
						EnableModelValidation="True" 
						>
                <Columns>
                <asp:ButtonField AccessibleHeaderText="nombre" 
                                                CommandName="View" 
                                                DataTextField="nombre" 
												HeaderText="Documento">
                                                <ItemStyle CssClass="td_derecha_grande"  />
					                            <HeaderStyle CssClass="td_cabecera_grande" /> 
                </asp:ButtonField>

                <asp:BoundField AccessibleHeaderText="extension" DataField="extension" HeaderText="Extensión">
                <ItemStyle CssClass="td_derecha"  />
				<HeaderStyle CssClass="td_cabecera" /> 
                </asp:BoundField>

                <asp:BoundField AccessibleHeaderText="peso" DataField="peso" HeaderText="Tamaño">
                <ItemStyle CssClass="td_derecha"  />
				<HeaderStyle CssClass="td_cabecera" /> 
                </asp:BoundField>

                <asp:BoundField AccessibleHeaderText="observaciones" DataField="observaciones" HeaderText="Observaciones">
                <ItemStyle CssClass="td_derecha_grande"  />
				<HeaderStyle CssClass="td_cabecera_grande" />
                </asp:BoundField>

                <asp:BoundField AccessibleHeaderText="Usuario" DataField="usuario" HeaderText="Usuario">
                <ItemStyle CssClass="td_derecha_grande"  />
				<HeaderStyle CssClass="td_cabecera_grande" />
                </asp:BoundField>

                <asp:TemplateField AccessibleHeaderText="eliminar" HeaderText="Eliminar">
                <ItemTemplate>
	            <asp:CheckBox ID="chk_eliminar" runat="server" Checked="false" />	
	            </ItemTemplate>
                            <ItemStyle CssClass="td_derecha"  />
				            <HeaderStyle CssClass="td_cabecera" />
                </asp:TemplateField>
                </Columns>

                <HeaderStyle CssClass="tr_cabecera" />
				<RowStyle CssClass="tr_fila" />
				<AlternatingRowStyle CssClass="tr_fila_alt" />
            </asp:GridView>
            <br/>
             <table class="table">
                <tr>
                    <td>
                        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" 
                            CssClass="button_rojo" Visible="False" onclick="btnEliminar_Click" />
                        <cc1:ConfirmButtonExtender ID="Button1_ConfirmButtonExtender" runat="server" 
                            TargetControlID="btnEliminar" 
                            ConfirmText="¿Está seguro de Eliminar los documentos seleccionados?" 
                            Enabled="True" />
                    </td>
                    <td>
                        <asp:ImageButton ID="ibRefrescar" runat="server" 
                            ImageUrl="../imagenes/sistema/static/panel_control/lupa.png" Height="32px" 
                            onclick="ibRefrescar_Click1" Width="32px" />
                    </td>
                </tr>
            </table>
            <hr/>
            <table class="table">
                    <tr>
                        <td>
                        Subir Documentos
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="dlTitulo" runat="server">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="dlTitulo" 
                            ErrorMessage="Seleccione un título" InitialValue="0" Display="Dynamic" ValidationGroup="subir"/>
                        </td>
                        <td>
                             <asp:FileUpload ID="fu_archivo" runat="server" CssClass="button" />
                        </td>
                        <td>
                            Comentario
                        </td>
                        <td>
                            <asp:TextBox ID="txtComentario" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="btnSubir" runat="server" Text="Subir" CssClass="button" ValidationGroup="subir" ToolTip="Sube el documento seleccionado"
                                onclick="btnSubir_Click" />
                            <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender4" runat="server" 
                                TargetControlID="btnSubir" ConfirmText="¿Está seguro de Subir un documento?" 
                                Enabled="True" />
                        </td>
                    </tr>
              
            </table>

            <div class="centrado">
			    <iframe id="i_documento" frameborder="1" height="400px" width="95%" runat="server" scrolling="auto"></iframe>
		    </div>
    
                    
</ContentTemplate>
                
</ajaxToolkit:TabPanel>

 <ajaxToolkit:TabPanel ID="tab_insertos" runat="server" HeaderText="INSERTOS"
                    Visible="True">
                    <ContentTemplate>
                      
           
    <br/>
            
            <asp:GridView ID="gr_insertos" runat="server" AutoGenerateColumns="False" 
						CssClass="tabla_datos" 
						DataKeyNames="id_inserto_hipoteca,id_inserto" 
						GridLines="None" OnRowCommand="gr_insertos_RowCommand"
						EnableModelValidation="True" 
						>
                <Columns>
                <asp:ButtonField AccessibleHeaderText="nombre" 
                                                CommandName="View" 
                                                DataTextField="nombre" 
												HeaderText="Inserto">
                                                <ItemStyle CssClass="td_derecha_grande"  />
					                            <HeaderStyle CssClass="td_cabecera_grande" /> 
                </asp:ButtonField>

                <asp:BoundField AccessibleHeaderText="fecha" DataField="fecha" HeaderText="Fecha">
                <ItemStyle CssClass="td_derecha"  />
				<HeaderStyle CssClass="td_cabecera" /> 
                </asp:BoundField>


                <asp:BoundField AccessibleHeaderText="Usuario" DataField="usuario" HeaderText="Usuario">
                <ItemStyle CssClass="td_derecha_grande"  />
				<HeaderStyle CssClass="td_cabecera_grande" />
                </asp:BoundField>

                 <asp:TemplateField HeaderText="Editar">
							    <ItemTemplate>
                                    <asp:ImageButton ID="ibEliminar" 
                                                        runat="server"
                                                        Height="32px" Width="32px"
                                                        ImageUrl="../imagenes/sistema/static/edit.png" 
                                                        CommandName="editar"  CommandArgument='<%#((GridViewRow)Container).RowIndex %>'
                                                        />
                                     
							    </ItemTemplate>
							    <ItemStyle CssClass="td_derecha_mediana_2" />
								<HeaderStyle CssClass="td_cabecera_mediana_2" />
		  </asp:TemplateField>
                </Columns>

                <HeaderStyle CssClass="tr_cabecera" />
				<RowStyle CssClass="tr_fila" />
				<AlternatingRowStyle CssClass="tr_fila_alt" />
            </asp:GridView>
            <br/>
            <hr/>
            <table class="table">
                    <tr>
                        <td>
                        Subir Insertos<asp:Label ID="lblIdInserto" runat="server" Text="0" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="dlInsertoTitulos" runat="server">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="dlInsertoTitulos" 
                            ErrorMessage="Seleccione un título" InitialValue="0" Display="Dynamic" ValidationGroup="subirinserto"/>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                             <asp:Button ID="btnInsertoSubir" runat="server" Text="Guardar" 
                                CssClass="button" ValidationGroup="subirinserto" ToolTip="Sube el inserto" 
                                onclick="btnInsertoSubir_Click"/>
                            <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender3" runat="server" TargetControlID="btnInsertoSubir" ConfirmText="¿Está seguro de Subir un inserto?" Enabled="True" />
                                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                 <asp:Button ID="btnInsertoEliminar" runat="server" Text="Eliminar" 
                                CssClass="button_rojo"  ToolTip="Elimina el inserto" 
                                onclick="btnInsertoEliminar_Click"/>
                            <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender5" runat="server" 
                                TargetControlID="btnInsertoEliminar" ConfirmText="¿Está seguro de Eliminar un inserto?" 
                                Enabled="True" />
                        </td>
                       
                       </tr>
                       <tr>
                        <td>
                            <asp:TextBox ID="txtInsertoTexto" TextMode="MultiLine" Width="800px" Height="600px" 
                                runat="server"></asp:TextBox>
                        </td>
                        </tr>
                      
              
            </table>

            <div class="centrado">
			    <br/>
                 <br/>
                  <br/>
		    </div>
    
                    
</ContentTemplate>




















































</ajaxToolkit:TabPanel>
            </ajaxToolkit:TabContainer>
           
        </ContentTemplate>
    </asp:UpdatePanel>
       <br/>   <br/>
    <div class="divControles">
        <center>Controles   <br/><br/>
          
        <asp:ImageButton ID="ImageButton1" runat="server" 
            ImageUrl="../imagenes/sistema/static/hipotecario/save.png" 
            ToolTip="Guardar todo"
            onclick="ImageButton1_Click" />
              
                <ajaxToolkit:ConfirmButtonExtender ID="bt_guardar_ConfirmButtonExtender" runat="server"
                    TargetControlID="ImageButton1" ConfirmText="¿Está seguro de guardar los cambios?">
                </ajaxToolkit:ConfirmButtonExtender> 
            <%--  <a href="#" id="generarDocumentos">
                    <asp:Image ID="Image3" runat="server" ImageUrl="../imagenes/sistema/static/word-small.jpg" />
                </a>
               
                
              </center>
               <div id="panel-oculto" style="display:none;">
         <asp:DropDownList runat="server" ID="dlDocumentosParaCrear"/>--%>
         <a onclick="divLogin()" ><img src="../imagenes/sistema/static/hipotecario/documentos.png" /> </a>
       </center>
          
   
               
    </div>
    
</asp:Content>
