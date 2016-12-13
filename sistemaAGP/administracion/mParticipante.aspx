<%@ Page Title="Administracion de Participantes" Language="C#" MasterPageFile="~/Adm.Master" AutoEventWireup="true" CodeBehind="mParticipante.aspx.cs" Inherits="sistemaAGP.mParticipante" %>

<%@ Register Src="~/controles/wucPersonaTransferencia.ascx" TagName="DatosPersona" TagPrefix="agp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<script type="text/javascript" src="../jquery-1.7.2.min.js"></script>
	<script type="text/javascript" src="../jquery.mousewheel-3.0.6.pack.js"></script>
	<script type="text/javascript" src="../jquery.fancybox.js?v=2.0.6"></script>
	<link rel="Stylesheet" type="text/css" href="../jquery.fancybox.css?v=2.0.6" media="screen" />
	<script type="text/javascript">
		$(document).ready(function () {
			$('.fancybox').fancybox({
				maxWidth: 500,
				maxHeight: 300,
				minWidth: 500,
				minHeight: 300,
				fitToView: false,
				width: 500,
				height: 300,
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
	<style type="text/css">
        .style1
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: x-small;
            font-weight: bold;
        }
        .style3
        {
            width: 138px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<agp:DatosPersona ID="DatosParticipante" runat="server" Titulo="DATOS DEL PARTICIPANTE" HabilitarCompraPara="false" />
	<table>
		<tr>
			<td>
				<span class="style1">Tipo Participe</span>
			</td>
			<td>
				<asp:DropDownList ID="dl_tipo" runat="server" AutoPostBack="False" Font-Names="Arial" Font-Size="X-Small" Height="16px" OnSelectedIndexChanged="dl_pais_SelectedIndexChanged" Width="138px" TabIndex="35" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small">
				</asp:DropDownList>
			</td>
			<td>
				<asp:CheckBox ID="chk_firma" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; font-weight: 700" Text="Firma Contrato" OnCheckedChanged="chk_firma_CheckedChanged" />
			</td>
			<td style="width: 73px; font-family: Arial, Helvetica, sans-serif; font-size: x-small;" class="style30">
				<strong>Fecha Personeria </strong>
			</td>
			<td>
				<asp:TextBox ID="txt_fecha" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" Height="19px" Width="73px" TabIndex="7" OnTextChanged="txt_fecha_TextChanged"></asp:TextBox>
				<cc1:CalendarExtender runat="server" TargetControlID="txt_fecha" CssClass="calendario" Format="dd/MM/yyyy" PopupButtonID="ib_calendario" ID="CalendarExtender2" />
			</td>
			<td>
				<asp:ImageButton ID="ib_calendario" runat="server" ImageUrl="../imagenes/sistema/gif/calendario.gif" OnClick="ib_calendario_Click" />
			</td>
		</tr>
	</table>
	<table>
		<tr>
			<td class="style1">
				Ciudad Notario
			</td>
			<td class="style9">
				<asp:TextBox ID="txt_ciudad_n" runat="server" CssClass="style2" Width="134px" OnTextChanged="txt_ciudad_n_TextChanged"></asp:TextBox>
			</td>
			<td class="style1">
				Notario Publico
			</td>
			<td class="style9">
				<asp:TextBox ID="txt_notario" runat="server" CssClass="style2" Width="134px" OnTextChanged="txt_notario_TextChanged"></asp:TextBox>
			</td>
			<td class="style3" style="text-align: right">
				<asp:Button ID="Button1" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" Text="Guardar" OnClick="Button1_Click" />
			</td>
		</tr>
	</table>
	<table>
		<tr>
			<td>
				<asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Names="Arial" Font-Size="X-Small" ForeColor="#333333" GridLines="None" Width="500px" EnableModelValidation="True">
					<RowStyle BackColor="#EFF3FB" />
					<Columns>
						<asp:BoundField AccessibleHeaderText="rut_participe" DataField="rut_participe" HeaderText="Rut Participe">
							<ControlStyle Height="0px" Width="0px" />
						</asp:BoundField>
						<asp:BoundField AccessibleHeaderText="nombre" DataField="nombre" HeaderText="Nombre" />
						<asp:BoundField AccessibleHeaderText="Tipo" DataField="tipo" HeaderText="Tipo" />
						<asp:TemplateField AccessibleHeaderText="Firma" FooterText="Firma" HeaderText="Firma">
							<ItemTemplate>
								<asp:CheckBox ID="chk" runat="server" EnableViewState="true" Checked='<%# Bind("check")  %>' />
							</ItemTemplate>
						</asp:TemplateField>
						<asp:BoundField AccessibleHeaderText="Ciudad Notario" DataField="ciudad_notario" FooterText="Ciudad Notario" HeaderText="Ciudad Notario" />
						<asp:BoundField AccessibleHeaderText="Notario Publico" DataField="notario_publico" FooterText="Notario Publico" HeaderText="Notario Publico" />
						<asp:BoundField AccessibleHeaderText="fecha_personeria" DataField="fecha_participante" FooterText="fecha_personeria" HeaderText="fecha_personeria" />
						<asp:TemplateField AccessibleHeaderText="Sucursales" HeaderText="Sucursales">
							<ItemTemplate>
								<asp:ImageButton ID="ib_sucursal" runat="server" ImageUrl="../imagenes/sistema/static/registro.jpg" OnClick="Click_sucursales" Text="sucursales" />
							</ItemTemplate>
							<ControlStyle Height="35px" Width="35px" />
						</asp:TemplateField>
					</Columns>
					<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
					<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
					<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
					<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
					<EditRowStyle BackColor="#2461BF" />
					<AlternatingRowStyle BackColor="White" />
				</asp:GridView>
				<br />
			</td>
		</tr>
		<tr>
			<td>
				<asp:Button ID="btn_editar" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" Text="Editar" OnClick="Editar_Click" />
			</td>
		</tr>
	</table>
</asp:Content>