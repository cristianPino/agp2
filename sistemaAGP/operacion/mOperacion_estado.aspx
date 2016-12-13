<%@ Page Title="Analisis estado" Language="C#" MasterPageFile="~/Adm.Master" AutoEventWireup="true" CodeBehind="mOperacion_estado.aspx.cs" Inherits="sistemaAGP.mOperacion_estado" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<style type="text/css">
        .style1
        {
            width: 41px;
        }
        .style2
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: x-small;
            margin-left: 0px;
        }
        .style3
        {
            width: 132px;
        }
        .style4
        {
            width: 131px;
            text-align: right;
        }
        .style5
        {
            text-align: left;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<table border="0" style="width: 493px; height: 347px">
		<tr>
			<td style="border-style: none; border-color: inherit; border-width: 0; text-align: left; width: 968px; height: 277px;" align="left" valign="top">
				<asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="X-Small" Text="Administracion de WorkFlow"></asp:Label>
				<br />
				<table style="width: 14%; font-family: Arial, Helvetica, sans-serif; font-size: x-small" bgcolor="#E5E5E5">
				</table>
				<br />
				<table style="width: 92%; font-family: Arial, Helvetica, sans-serif; font-size: x-small" bgcolor="#E5E5E5">
					<tr>
						<td class="style1">
							Tipo Operacion
						</td>
						<td class="style2">
							<asp:Label ID="lbl_tipo" runat="server" Text="Label" Font-Names="Arial" Font-Size="X-Small"></asp:Label>
						</td>
						<td class="style4">
							<asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="X-Small" Text="Nº solicitud"></asp:Label>
						</td>
						<td>
							<asp:Label ID="lbl_solicitud" runat="server" Text="Label" Font-Names="Arial" Font-Size="X-Small" Style="font-weight: 700"></asp:Label>
						</td>
					</tr>
				<tr>
					<td colspan="4" style="background-color: #add8e6">
						<asp:Label ID="Label2" Text="LOS ESTADOS QUE TIENEN FONDO DE ESTE COLOR ESTAN ELIMINADOS" runat="server" ></asp:Label>

					</td>
				</tr>
				</table>
				<table style="width: 92%; font-family: Arial, Helvetica, sans-serif; font-size: x-small" bgcolor="#E5E5E5">
					<tr>
						<td style="width: 56px;" class="style5">
							Flujo de trabajo
						</td>
							<td style="text-align: left" class="style3">
								<asp:DropDownList ID="dl_estado" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="18px" OnSelectedIndexChanged="dl_estado_SelectedIndexChanged" Width="240px">
								</asp:DropDownList>
							</td>
					</tr>
					<tr>
						<td style="width: 15px; text-align: right">
							Obs.
						</td>
						<td style="text-align: left;" class="style3">
							<asp:TextBox ID="txt_obs" runat="server" Font-Names="Arial" Font-Size="X-Small" MaxLength="1000" Width="367px" TabIndex="3" Height="16px" OnTextChanged="txt_obs_TextChanged"></asp:TextBox>
						</td>
					</tr>
				</table>
				<asp:Button ID="Button1" runat="server" Font-Names="Arial" Font-Size="X-Small" Text="Guardar" OnClick="Button1_Click" TabIndex="16" />
				<cc1:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server" TargetControlID="Button1" ConfirmText="¿Esta seguro del estado seleccionado?" />
				<asp:Button ID="Button2" runat="server" Font-Names="Arial" Font-Size="X-Small" OnClick="Button2_Click" Text="cancelar" />


				<asp:gridview id="gr_dato" runat="server" autogeneratecolumns="False" cellpadding="4"
					font-names="Arial" font-size="X-Small" forecolor="#333333" gridlines="None" width="445px"
					datakeynames="id_estado,activo" onselectedindexchanged="gr_dato_SelectedIndexChanged"
					onrowdatabound="gr_dato_RowDataBound">

			<RowStyle BackColor="#EFF3FB" />
			<Columns>
				
				<asp:HyperLinkField DataTextField="estado" HeaderText="Estado">
						<ItemStyle ForeColor="#00CC00" />
					</asp:HyperLinkField>
				<asp:BoundField DataField="cuenta_usuario" HeaderText="cuenta usuario" Visible="False" />
				<asp:BoundField DataField="nombre_usuario" HeaderText="Usuario" />
				<asp:BoundField DataField="fecha" HeaderText="Fecha Hora" />
				<asp:BoundField DataField="observacion" HeaderText="Observación" />
				<asp:BoundField DataField="contador" HeaderText="Contador" />
				<asp:ImageField AccessibleHeaderText="Semaforo" DataImageUrlField="semaforo" HeaderText="Semaforo">
				</asp:ImageField>
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
