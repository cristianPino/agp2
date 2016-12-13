<%@ Page Title="" Language="C#" MasterPageFile="~/AGP.Master" AutoEventWireup="true"
	CodeBehind="CargaTAG.aspx.cs" Inherits="sistemaAGP.preinscripcion.CargaTAG" %>

<%@ Register TagPrefix="ajaxToolkit" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=3.5.40412.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMenu" runat="server">

    <style type="text/css">
        
        .caja
        {
            width: 995px;
            margin: auto;
            height: 294px;
            background: #2FAACE;
            box-shadow: 10px 10px 3px #D8D8D8;
            transition: height .4s;
            color: #fff;
            font-size: xx-small;
            text-align: center;
            vertical-align:middle;
            border: solid 1px #fff;
            position: relative;
			top: 0px;
			left: 0px;
		}
        .caja table
        {
            margin: 0 auto;
            text-align: left;
        }
        
         .cajaVertical
        {
            width: 40%;
            margin: auto;
            height: 120px;
            background: #2FAACE;
            box-shadow: 10px 10px 3px #D8D8D8;
            transition: background .4s;
            text-align: center;
            color: #fff;
            font-size: xx-small;
            vertical-align:sub;
            border: solid 1px #fff;
           
        }
        .cajaVertical table
        {
            margin: 0 auto;
            text-align: left;
        }
        .style5
		{
			color: #000000;
		}
        </style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoCentral" runat="server">


    <br/>
    <div id="caja" class="caja" align="center">
  <br/>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table>
				<tr>
					<td style="border-style: none; border-color: inherit; border-width: 0; text-align: left;
						width: 968px; height: 277px;" align="left" valign="top">
						<asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="X-Small"
							Text="Administracion de Carga de TAG"></asp:Label>
						<br />
						<table style="width: 38%; font-family: Arial, Helvetica, sans-serif; font-size: x-small"
							bgcolor="#E5E5E5">
							<tr>
								<td style="width: 56px; text-align: right;">
									<span class="style5">Codigo TAG</span> </td>
									<td style="width: 200px; text-align: left">
										<asp:TextBox ID="txt_codigo" runat="server" Font-Names="Arial" Font-Size="X-Small"
											MaxLength="50" AutoPostBack="true" ontextchanged="txt_codigo_TextChanged" Width="200px"></asp:TextBox>
									</td>
									<td>
										<asp:Label ID="lbl_stock" runat="server" Text="Label" 
											style="color: #000000; font-weight: 700; font-size: small;"></asp:Label>
									
									</td>
								
							</tr>
						</table>
						<br />
						<asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" CellPadding="4"
							Font-Names="Verdana" Font-Size="X-Small" ForeColor="#333333" GridLines="None" Height="118px" 
							Width="254px">
							<RowStyle BackColor="#EFF3FB" />
							<Columns>
								<asp:TemplateField AccessibleHeaderText="Codigo" HeaderText="Codigo">
									<EditItemTemplate>
										<asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("id_tag") %>'></asp:TextBox>
									</EditItemTemplate>
									<ItemTemplate>
										<asp:Label ID="Label1" runat="server" Text='<%# Bind("id_tag") %>'></asp:Label>
									</ItemTemplate>
								</asp:TemplateField>
								<asp:BoundField AccessibleHeaderText="Codigo_TAG" DataField="codigo" HeaderText="Codigo_TAG" />
							</Columns>
							<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
							<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
							<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
							<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
							<EditRowStyle BackColor="#2461BF" />
							<AlternatingRowStyle BackColor="White" />
						</asp:GridView>
					</td>
				</tr>
                </table>
                   </ContentTemplate>
                    </asp:UpdatePanel>
                  </div>   
                
       
   
    <br />
    <br />

    


    <br/>



</asp:Content>
