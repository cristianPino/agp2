<%@ Page Title="" Language="C#" MasterPageFile="~/Adm.Master" AutoEventWireup="true" CodeBehind="solicitudrc_operacion.aspx.cs" Inherits="sistemaAGP.solicitudrc_operacion" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<style type="text/css">
		.style4 {
			width: 127px;
			background-color: #FFFFFF;
		}
		.style5 {
			width: 58px;
			text-align: center;
			background-color: #FFFFFF;
		}
		.style6 {
			font-family: Arial, Helvetica, sans-serif;
			font-size: x-small;
			color: #FF3300;
		}
		.style7 {
			font-family: Arial, Helvetica, sans-serif;
			font-size: x-small;
			font-weight: bold;
		}
		.style8
		{
			font-family: Arial, Helvetica, sans-serif;
			font-size: x-small;
		}
		.style9
		{
			font-family: Arial, Helvetica, sans-serif;
			font-size: x-small;
			color: #ffffff;
			background-color: #0099ff;
		}
    </style>
	<script type="text/javascript">
		function validateYear(oSrc, args) {
			var now = new Date();
			args.IsValid = (1900 <= parseInt(args.Value) && parseInt(args.Value) <= now.getFullYear());
		}
	</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div>
		<table style="width: 81%; font-family: Arial, Helvetica, sans-serif; font-size: x-small" bgcolor="#E5E5E5">
		</table>
		<table style="width: 28%; font-family: Arial, Helvetica, sans-serif; font-size: x-small" bgcolor="#E5E5E5">
			<tr>
				<td class="style4">
					Nº Operacion
				</td>
				<td class="style5">
					<asp:Label ID="lblOperacion" runat="server" Text="Label" Style="color: #FF3300"></asp:Label>
				</td>
			</tr>
		</table>
	</div>
	<asp:UpdatePanel ID="UpdatePanelDatos" runat="server">
		<ContentTemplate>
			<table class="style7">
				<tr>
					<td>
						Código de Barras
					</td>
					<td colspan="3">
						<asp:TextBox ID="txtCodigoBarra" runat="server" Text="" MaxLength="15" Width="100px" CssClass="style9" AutoPostBack="true" ontextchanged="txtCodigoBarra_TextChanged" TabIndex="1"></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td>
						Patente
					</td>
					<td>
						<asp:TextBox ID="txtPatente" runat="server" Text="" MaxLength="6" Width="80px" CssClass="style8"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Patente" Text="*" ControlToValidate="txtPatente" InitialValue=""></asp:RequiredFieldValidator>
					</td>
					<td>
						Tipo de Solicitud
					</td>
					<td>
						<asp:DropDownList ID="ddlTipoSolicitud" runat="server" CssClass="style8" Width="200px">
						</asp:DropDownList>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Tipo de Solicitud" Text="*" ControlToValidate="ddlTipoSolicitud" InitialValue="0"></asp:RequiredFieldValidator>
					</td>
				</tr>
				<tr>
					<td>
						Región Oficina
					</td>
					<td>
						<asp:DropDownList ID="ddlRegion" runat="server" CssClass="style8" Width="200px" onselectedindexchanged="ddlRegion_SelectedIndexChanged" AutoPostBack="true">
						</asp:DropDownList>
					</td>
					<td>
						Oficina
					</td>
					<td>
						<asp:DropDownList ID="ddlOficina" runat="server" CssClass="style8" Width="200px">
						</asp:DropDownList>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Oficina" Text="*" ControlToValidate="ddlOficina" InitialValue="0"></asp:RequiredFieldValidator>
					</td>
				</tr>
				<tr>
					<td>
						Nro. Solicitud
					</td>
					<td>
						<asp:TextBox ID="txtNroSolicitud" runat="server" Text="" CssClass="style8" MaxLength="10" Width="100px"></asp:TextBox>
						<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Número Solicitud" Text="*" ControlToValidate="txtNroSolicitud" InitialValue=""></asp:RequiredFieldValidator>
						<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Numbers" TargetControlID="txtNroSolicitud">
						</cc1:FilteredTextBoxExtender>
					</td>
					<td>
						Fecha Solicitud
					</td>
					<td>
						<asp:TextBox ID="txtFechaSolicitud" runat="server" CssClass="style8" MaxLength="10" Width="80px"></asp:TextBox>
						<asp:ImageButton ID="btnFechaSolicitud" runat="server" ImageUrl="../imagenes/sistema/gif/calendario.gif" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" />
						<cc1:CalendarExtender ID="calFechaSolicitud" runat="server" TargetControlID="txtFechaSolicitud" CssClass="calendario" Format="dd/MM/yyyy" PopupButtonID="btnFechaSolicitud" />
						<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Fecha Solicitud" Text="*" ControlToValidate="txtFechaSolicitud" InitialValue=""></asp:RequiredFieldValidator>
					</td>
				</tr>
				<tr>
					<td colspan="2" style="text-align: center;">
						<asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="style8" onclick="btnGuardar_Click" />
					</td>
					<td colspan="2" style="text-align: center;">
						<asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" CssClass="style8" onclick="btnLimpiar_Click" CausesValidation="false" />
					</td>
				</tr>
			</table>
			<cc1:ConfirmButtonExtender ID="btnGuardar_ConfirmButtonExtender" runat="server" TargetControlID="btnGuardar" ConfirmText="¿Esta seguro de ingresar una nueva solicitud?">
			</cc1:ConfirmButtonExtender>
			<asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="true" ShowSummary="false" DisplayMode="BulletList" HeaderText="Debe ingresar los siguientes datos antes de continuar:" />
		</ContentTemplate>
	</asp:UpdatePanel>
	<asp:UpdatePanel ID="UpdatePanelGrilla" runat="server">
		<ContentTemplate>
			<asp:GridView ID="grdSolicitudes" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Names="Arial" Font-Size="X-Small" ForeColor="#333333" GridLines="None">
				<Columns>
					<asp:BoundField AccessibleHeaderText="fecha" HeaderText="Fecha" DataField="fecha" />
					<asp:BoundField AccessibleHeaderText="tipo" HeaderText="Tipo" DataField="tipo" />
					<asp:BoundField AccessibleHeaderText="oficina" HeaderText="Oficina" DataField="oficina" />
					<asp:BoundField AccessibleHeaderText="numero" HeaderText="Número" DataField="numero" />
					<asp:BoundField AccessibleHeaderText="estado" HeaderText="Estado" DataField="estado" />
					<asp:BoundField AccessibleHeaderText="obs" HeaderText="Observaciones" DataField="obs" />
				</Columns>
				<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
				<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
				<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
				<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
				<EditRowStyle BackColor="#2461BF" />
				<AlternatingRowStyle BackColor="#CCCCCC" />
			</asp:GridView>
		</ContentTemplate>
	</asp:UpdatePanel>
</asp:Content>