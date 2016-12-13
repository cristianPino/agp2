<%@ Page Title="Administracion de Participantes" Language="C#" MasterPageFile="~/Adm.Master" AutoEventWireup="true" CodeBehind="mAcreedor.aspx.cs" Inherits="sistemaAGP.mAcreedor" %>

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
				maxWidth: 405,
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
	<style type="text/css">
        .style3
        {
            width: 138px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<agp:DatosPersona ID="DatosParticipante" runat="server" Titulo="DATOS DEL PARTICIPANTE" HabilitarCompraPara="false" HabilitarParticipante="true" />
	<table>
	<tr>
		<td class="style3" style="text-align: left">
			<asp:Button ID="Button1" runat="server" Style="font-family: Arial, Helvetica, sans-serif;
				font-size: x-small" Text="Guardar" OnClick="Button1_Click" />
		</td>
	</tr>
	</table>

	<table>
		<tr>
			<td>
				<asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Names="Arial" Font-Size="X-Small" ForeColor="#333333" GridLines="None" Width="500px" EnableModelValidation="True">
					<RowStyle BackColor="#EFF3FB" />
					<Columns>
						<asp:BoundField AccessibleHeaderText="Rut Acreedor" DataField="rut_acreedor" HeaderText="Rut Acreedor">
							<ControlStyle Height="0px" Width="0px" />
						</asp:BoundField>
						<asp:BoundField AccessibleHeaderText="nombre" DataField="nombre" HeaderText="Nombre" />
						<asp:BoundField AccessibleHeaderText="Estado Civil" DataField="estado_civil" FooterText="Estado Civil" HeaderText="Estado Civil" />
						<asp:BoundField AccessibleHeaderText="Sexo" DataField="sexo" FooterText="Sexo" HeaderText="Sexo" />
						<asp:BoundField AccessibleHeaderText="Profesion" DataField="profesion" FooterText="Profesion" HeaderText="Profesion" />
					
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
		</table>
</asp:Content>