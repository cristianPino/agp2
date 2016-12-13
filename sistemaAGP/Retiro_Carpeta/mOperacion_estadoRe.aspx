<%@ Page Title="Analisis estado" Language="C#" MasterPageFile="~/Adm.Master" AutoEventWireup="true" CodeBehind="mOperacion_estadoRe.aspx.cs" Inherits="sistemaAGP.mOperacion_estadoRe" %>

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
				</table>
				<table style="width: 92%; font-family: Arial, Helvetica, sans-serif; font-size: x-small" bgcolor="#E5E5E5">
					<tr>
						<td style="width: 56px;" class="style5">
							Flujo de trabajo
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
				&nbsp;<asp:Button ID="Button2" runat="server" Font-Names="Arial" Font-Size="X-Small" OnClick="Button2_Click" Text="cancelar" />
				<asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Names="Arial" Font-Size="X-Small" ForeColor="#333333" GridLines="None" Width="445px" OnSelectedIndexChanged="gr_dato_SelectedIndexChanged" EnableModelValidation="True" OnPageIndexChanging="gr_dato_PageIndexChanging" OnRowCancelingEdit="gr_dato_RowCancelingEdit" OnRowDeleting="gr_dato_RowDeleting" OnRowEditing="gr_dato_RowEditing" OnRowUpdating="gr_dato_RowUpdating" DataKeyNames="id_estado">
			<RowStyle BackColor="#EFF3FB" />
			<Columns>
				<asp:BoundField DataField="id_estado" HeaderText="id_estado" ReadOnly="true" Visible="false" />
				<asp:BoundField DataField="estado" HeaderText="Estado" ReadOnly="true" />
				<asp:BoundField DataField="cuenta_usuario" HeaderText="cuenta usuario" Visible="False" ReadOnly="true" />
				<asp:BoundField DataField="nombre_usuario" HeaderText="Usuario" ReadOnly="true" />
				<%--<asp:BoundField DataField="fecha" HeaderText="Fecha Hora" />--%>
				<asp:TemplateField ItemStyle-Width="150px" HeaderText="fecha">
					<ItemTemplate>
						<asp:Label ID="fecha" CssClass="style4" runat="server" Text='<%# Eval("fecha")%>'></asp:Label></ItemTemplate>
					<EditItemTemplate>
						<asp:TextBox ID="fecha" runat="server" Text='<%# Eval("fecha")%>'> </asp:TextBox>
					</EditItemTemplate>
					<FooterTemplate>
						<asp:TextBox ID="fecha" runat="server"> </asp:TextBox>
					</FooterTemplate>

<ItemStyle Width="150px"></ItemStyle>
				</asp:TemplateField>
				
				<asp:TemplateField ItemStyle-Width="150px" HeaderText="observacion">
					<ItemTemplate>
						<asp:Label ID="observacion" CssClass="style4" runat="server" Text='<%# Eval("observacion")%>'></asp:Label></ItemTemplate>
							<edititemtemplate>
						<asp:TextBox ID="observacion" runat="server"
							  Text='<%# Eval("observacion")%>'> </asp:TextBox>
						 </edititemtemplate> 
					<FooterTemplate>
				<asp:TextBox ID="observacion" runat="server"> </asp:TextBox>
				</FooterTemplate>

<ItemStyle Width="150px"></ItemStyle>
				</asp:TemplateField>




				<%--<asp:BoundField DataField="observacion" HeaderText="Observación" />--%>
				<asp:BoundField DataField="contador" HeaderText="Contador" ReadOnly="true" />
				<asp:ImageField AccessibleHeaderText="Semaforo" DataImageUrlField="semaforo" HeaderText="Semaforo" ReadOnly="true">
				</asp:ImageField>
				<asp:CommandField ShowEditButton="True" ShowCancelButton="False" ShowDeleteButton="True" />
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
