﻿<%@ Page Language="C#" MasterPageFile="~/Adm.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="mBancoCliente.aspx.cs" Inherits="sistemaAGP.mBancoCliente" %>
<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
	<style type="text/css">

        .style1
        {
            width: 50%;
            height: 3px;
        }
        .style4
        {
            font-size: x-small;
            font-weight: bold;
            font-family: Arial, Helvetica, sans-serif;
        }
        .style5 {
			font-size: x-small;
			font-weight: bold;
			font-family: Arial, Helvetica, sans-serif;
			width: 561px;
			height: 47px;
		}
        </style>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<script type="text/javascript" src="../jquery-1.7.2.min.js"></script>
	<script type="text/javascript" src="../jquery.mousewheel-3.0.6.pack.js"></script>
	<script type="text/javascript" src="../jquery.fancybox.js?v=2.0.6"></script>
	<link rel="Stylesheet" type="text/css" href="../jquery.fancybox.css?v=2.0.6" media="screen" />
	<script type="text/javascript">
		$(document).ready(function () {
			$('.fancybox').fancybox({
				maxWidth: 200,
				maxHeight: 150,
				fitToView: true,
				width: 150,
				height: 150,
				autoSize: true,
				openEffect: 'elastic',
				openSpeed: 150,
				closeEffect: 'elastic',
				closeSpeed: 150,
				closeClick: false,
				
				closeBtn: false,
				scrolling: 'auto',
				padding: 5,
				beforeShow: function () {
					var el, id = $(this.element).data('title-id');

					$.fancybox.close();
					if (id) {
						el = $('#' + id);
						if (el.length)
							this.title = el.html();
					}
				},
				helpers: {
					overlay: {
						opacity: 0.5,
						css: {
							'background-color': 'Gray'
						}
					}
				}
			});
		});
	</script>

	<table>
		<tr>
			<td class="style4">
				BANCO CLIENTE</td>
		</tr>
	</table>
	<table class="style1">
		
		</table>
		<table>
			<tr>
				<td class="style4">
					
				</td>
				<td class="style4">
					&nbsp;
				</td>
				<td class="style4">
				</td>
				<td class="style4">
					&nbsp;
				</td>
			</tr>
		</table>
		<table>
		<tr>
			<td class="style2">
			<asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Names="Arial" Font-Size="X-Small" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="gr_dato_SelectedIndexChanged" Style="margin-right: 0px" Width="216px" DataKeyNames="codigo_banco">
			
					<RowStyle BackColor="#EFF3FB" />
					<Columns>
						
						<asp:BoundField AccessibleHeaderText="codigo_banco" DataField="codigo_banco" HeaderText="Codigo Banco" />
						<asp:BoundField AccessibleHeaderText="nombre" DataField="nombre" HeaderText="Nombre" />
						
						
						<asp:TemplateField>
							<HeaderTemplate>
						
							</HeaderTemplate>
							<ItemTemplate>
								<asp:CheckBox ID="check" MaxLength="2" Height="16px" runat="server" Width="20px" Checked='<%# Bind("check") %>' AutoCompleteType="Disabled" Font-Size="7pt"></asp:CheckBox>
							</ItemTemplate>
						</asp:TemplateField>
					</Columns>
					<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
					<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
					<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
					<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
					<EditRowStyle BackColor="#2461BF" />
					<AlternatingRowStyle BackColor="White" />
				</asp:GridView>
				<asp:Button ID="Button1" runat="server" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small" Text="Grabar" OnClick="Button1_Click" Visible="true" />
				<br />
			</td>
			
	</table>
</asp:Content>
