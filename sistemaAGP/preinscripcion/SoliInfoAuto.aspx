<%@ Page Language="C#"
    MasterPageFile="~/Adm.Master"
    AutoEventWireup="true"
    CodeBehind="SoliInfoAuto.aspx.cs"
    Inherits="sistemaAGP.SoliInfoAuto" Title="Solicitud InfoAuto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="ajaxToolkit" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=3.5.40412.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .caja {
            width: 100%;
            margin: auto;
            height: 100px;
            background: #2FAACE;
            box-shadow: 10px 10px 3px #D8D8D8;
            transition: height .4s;
            color: #fff;
            font-size: xx-small;
            text-align: center;
            vertical-align: middle;
            border: solid 1px #fff;
            position: relative;
        }

            .caja table {
                margin: 0 auto;
                text-align: left;
            }

        .cajaVertical {
            width: 30%;
            margin: auto;
            height: 280px;
            background: #2FAACE;
            box-shadow: 10px 10px 3px #D8D8D8;
            transition: background .4s;
            text-align: center;
            color: #fff;
            font-size: xx-small;
            vertical-align: middle;
            border: solid 1px #fff;
        }

            .cajaVertical table {
                margin: 0 auto;
                text-align: left;
            }
    </style>
    <script type="text/javascript">

        function ocultarVarios() {

            document.getElementById('<%=txtPatenteSol.ClientID%>').disabled = false;
            document.getElementById('<%=txtOperacion.ClientID%>').disabled = false;                 
           
            document.getElementById("divTxtUnaPatente").style.backgroundColor = '#2FAACE';
            document.getElementById("divTextboxVarios").style.backgroundColor = '#23819c';

            var cliente = document.getElementById('<%=hdIdCliente.ClientID%>').value;

            if (cliente == "1")
            {
                document.getElementById('<%=chkAsociar.ClientID%>').disabled = false;
                document.getElementById('<%=chkAsociarVarias.ClientID%>').disabled = true;
                document.getElementById('<%=txtVariasPatentes.ClientID%>').disabled = true;
                document.getElementById('<%=txtVariasOperaciones.ClientID%>').disabled = true;
            }

        }

        function mostrarVarios() {

            document.getElementById('<%=txtPatenteSol.ClientID%>').disabled = true;            
            document.getElementById('<%=txtVariasPatentes.ClientID%>').disabled = false;
            
            document.getElementById("divTxtUnaPatente").style.backgroundColor = '#23819c';
            document.getElementById("divTextboxVarios").style.backgroundColor = '#2FAACE';

            var cliente = document.getElementById('<%=hdIdCliente.ClientID%>').value;
            if (cliente == "1")
            {
                document.getElementById('<%=txtOperacion.ClientID%>').disabled = true;
                document.getElementById('<%=chkAsociar.ClientID%>').disabled = true;
                document.getElementById('<%=chkAsociarVarias.ClientID%>').disabled = false;
                document.getElementById('<%=txtVariasOperaciones.ClientID%>').disabled = false;
            }
          
        }

        function mostrarUsuariosAGPAsociaciones()
        {
            var cliente = document.getElementById('<%=hdIdCliente.ClientID%>').value;
            if (cliente != "1")
            {               
                document.getElementById('<%=chkAsociarVarias.ClientID%>').disabled = true;
                document.getElementById('<%=txtOperacion.ClientID%>').disabled = true;
                document.getElementById('<%=chkAsociar.ClientID%>').disabled = true;
                document.getElementById('<%=txtVariasOperaciones.ClientID%>').disabled = true;
            }
        }

        function soloNumeros(e)
        {
            var key = window.Event ? e.which : e.keyCode
            return (key >= 48 && key <= 57)
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="div_titulo">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/imagenes/sistema/static/infoAuto/InfoAutoIcono2.png"
            Height="30px" Width="30px" />
        <asp:Label ID="Label2" runat="server" Text="Solicitud de Documentos" Style="font-size: 18pt; font-weight: bold;"></asp:Label>
    </div>
    <br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always" OnLoad="UpdatePanel1_Load">
        <ContentTemplate>
            <div id="caja" class="caja" align="center">
                <br />

                <table>
                    <tr>
                        <td>Indiquenos su empresa
                        </td>
                        <td>
                            <asp:DropDownList ID="dlCliente" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dlCliente_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>Indiquenos la sucursal
                        </td>
                        <td>
                            <asp:DropDownList ID="dlSucursal" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>Seleccione la Familia
                        </td>
                        <td>
                            <asp:DropDownList ID="dlFamilia" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dlFamilia_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td>¿Cuál es el Producto que necesita?
                        </td>
                        <td>
                            <asp:DropDownList ID="dlTipoDoc" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dlTipoDoc_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </div>
            <br />
            <div class="caja" style="height: 40px">
                <br />
                <table>
                    <tr>
                        <td>¿Cuántas patentes desea consultar?
                        </td>
                        <td>
                            <input type="radio" id="rdbuna" name="validacion" checked="True" onchange="ocultarVarios()"
                                runat="server" />
                        </td>
                        <td>Una Patente
                        </td>
                        <td>
                            <input type="radio" id="rdbVarias" name="validacion" onchange="mostrarVarios()" runat="server" />
                        </td>
                        <td>Varias Patentes
                        </td>
                    </tr>
                </table>
            </div>
            <br />

            <div id="divTxtUnaPatente"  class="cajaVertical" style="float: left;" align="center">
                <br />
                INGRESE AQUÍ LA PATENTE
        <br />
                <table>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtPatenteSol" runat="server" Width="100px" MaxLength="6" Font-Size="large"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Formato: LLNNNN; LLLLNN
                        </td>
                    </tr>
                    <tr>
                        <td>/------------------------------------/
                        </td>
                    </tr>
                    <tr>
                        <td> <asp:CheckBox ID="chkAsociar" Checked="false" runat="server" AutoPostBack="true" OnCheckedChanged="chkAsociar_CheckedChanged" Text="ASOCIAR A OPERACION" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtOperacion" runat="server" Enabled="false" Width="100px" MaxLength="6" Font-Size="large" onKeyPress="return soloNumeros(event)"></asp:TextBox>
                           
                        </td>
                    </tr>


                </table>

            </div>

            <div id="divTextboxVarios" class="cajaVertical"  style="float: left; background-color: #23819c" align="center">
                <br />
                INGRESO MASIVO
            <br />
                <center>
                <table>
                    <tr>
                        <td>
                            PATENTES
                        </td>
                        <td>
                            <asp:CheckBox ID="chkAsociarVarias" Checked="false" runat="server" AutoPostBack="true" Text="ASOCIAR A "/>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtVariasPatentes" runat="server" TextMode="MultiLine" Width="100px" Enabled="False"
                                Height="180px"></asp:TextBox>
                        </td>
                        <td>
                                <asp:TextBox ID="txtVariasOperaciones" runat="server" TextMode="MultiLine" Width="100px" Enabled="False"
                                Height="180px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="2">Formato: LLNNNN; LLLLNN
                        </td>
                        
                    </tr>
                </table>
                    </center>
            </div>

            <div class="cajaVertical" style="float: right; vertical-align: middle;" align="center">
                <br />
                PRESIONE AQUÍ PARA SOLICITAR
            <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <table>
                    <tr>
                        <td>
                            <asp:ImageButton ID="ibPedir" ValidationGroup="ibCreaBorradorEscritura" runat="server"
                                ImageUrl="../imagenes/sistema/static/hipotecario/crear_nuevo_doc.png" ToolTip="Crear documento"
                                OnClick="ibPedir_Click" />

                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td>
                            <ajaxToolkit:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="ibPedir"
                                ConfirmText="¿Está seguro de Solicitar el documento?" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="dlTipoDoc"
                                Display="Dynamic" ErrorMessage="Seleccione opción de documento." InitialValue="0"
                                ValidationGroup="ibCreaBorradorEscritura" Font-Bold="True" ForeColor="White" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="dlCliente"
                                Display="Dynamic" ErrorMessage="Seleccione opción de cliente." InitialValue="0"
                                ValidationGroup="ibCreaBorradorEscritura" ForeColor="White" Font-Bold="True" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="dlSucursal"
                                Display="Dynamic" ErrorMessage="Seleccione opción de Sucursal." InitialValue="0"
                                ValidationGroup="ibCreaBorradorEscritura" ForeColor="White" Font-Bold="True" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPatenteSol"
                                Display="Dynamic" ErrorMessage="Indiquenos una patente" InitialValue="0" ValidationGroup="ibCreaBorradorEscritura"
                                ForeColor="White" Font-Bold="True" />
                        </td>
                    </tr>
                </table>

            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="dlFamilia" EventName="SelectedIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:HiddenField ID="hdIdCliente" runat="server" />
</asp:Content>
