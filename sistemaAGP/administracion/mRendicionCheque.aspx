<%@ Page Language="C#" MasterPageFile="~/Adm.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="mRendicionCheque.aspx.cs" Inherits="sistemaAGP.mRendicionCheque" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
	<style type="text/css">

        .style1
        {
            width: 68%;
            height: 3px;
        }
        .style4
        {
            font-size: small;
            font-weight: 700;
            font-family: Arial, Helvetica, sans-serif;
            color: #FFFFFF;
            background-color: #006666;
        }
        .style10
        {
            font-size: x-small;
            font-weight: bold;
            font-family: Arial, Helvetica, sans-serif;
            width: 561px;
            height: 13px;
        }
        .style11
        {
            font-size: x-small;
            font-weight: bold;
            font-family: Arial, Helvetica, sans-serif;
            width: 561px;
            height: 10px;
        }
        .style12
        {
            font-size: small;
            font-family: Arial, Helvetica, sans-serif;
        }
        .style15
        {
			font-size: small;
			width: 304px;
		}
        .style16 {
			width: 152px;
		}
        .style17 {
			height: 62px;
		}
        </style>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<link rel="stylesheet" href="/Style/reset.css" />
	<link rel="stylesheet" href="/Style/text.css" />
	<link rel="stylesheet" href="/Style/960.css" />
	<link rel="stylesheet" href="/Style/site.css" />
	<script type='text/javascript' src='../jquery-1.7.2.min.js'></script>
	<script type='text/javascript' src='../jquery.mousewheel-3.0.6.pack.js'></script>
	<script type='text/javascript' src='../jquery.fancybox.js?v=2.0.6'></script>
	<link rel="Stylesheet" type="text/css" href="../jquery.fancybox.css?v=2.0.6" media="screen" />
	
	<script type="text/javascript">
	    $(document).ready(function () {
	        $('.fancybox').fancybox({
	            maxWidth: 800,
	            maxHeight: 600,
	            fitToView: true,
	            titleshow: true,
				titleposition:'inside',
	            width: 800,
	            height: 600,
				

	            autoSize: false,
	            openEffect: 'elastic',
	            openSpeed: 150,
	            closeEffect: 'elastic',
	            closeSpeed: 150,
	            closeClick: false,
	            closeBtn: true,
	           
	            
	            scrolling: 'auto',
	            padding: 5,
	            beforeShow: function () {
	                var el, id = $(this.element).data('title-id');
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
	                    	'background-color': 'Gray',
							
	                    }
	                }
	            }
	        });
	    });
	</script>

	<table>
		<tr>
			<td class="style4">
				Rendicion Movimiento Banco</td>
		</tr>
	</table>

	<ajaxToolkit:TabContainer ID="tab_datos" runat="server" Width="100%" 
                    ActiveTabIndex="0" ScrollBars="Auto">
					<ajaxToolkit:TabPanel ID="tab_negocio" runat="server" HeaderText="RENDICION" Width="100%">
						<ContentTemplate>
<table>

	<table class="style1">
		<tr>
				<td class="style10">
					Banco
					<asp:Label ID="banco" runat="server" Font-Names="Arial" Font-Size="X-Small" Font-Bold="True" ForeColor="Black"></asp:Label>
				</td>
			
		
			<td class="style10">
				Cuenta :
				<asp:Label ID="cuenta1" runat="server" Font-Names="Arial" Font-Size="X-Small" Font-Bold="True" ForeColor="Black"></asp:Label>
			</td>
		
		
			<td class="style10">
				Numero Documento:
				<asp:Label ID="numdoc" runat="server" Font-Names="Arial" Font-Size="X-Small" Font-Bold="True" ForeColor="Black"></asp:Label>
			</td>
			
		</tr>
		<tr>
			<td class="style11">
				Monto Estimado:
				<asp:Label ID="montoini" runat="server" Font-Names="Arial" Font-Size="X-Small" Font-Bold="True" ForeColor="Black"></asp:Label>
			</td>
			
			
		</tr>
		
		</table>
	



			<asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" Font-Names="Arial" Font-Size="X-Small" ForeColor="#333333" 
        GridLines="None" OnSelectedIndexChanged="gr_dato_SelectedIndexChanged" 
        Style="margin-right: 0px; font-size: x-small;" Width="216px" 
        DataKeyNames="id_nomina,folio,tipo_nomina,monto,familia, id_gasto">
			
					<RowStyle BackColor="#EFF3FB" />
					<Columns>
						
						<asp:BoundField AccessibleHeaderText="Folio" DataField="folio" HeaderText="Folio Nomina" />
						<asp:BoundField AccessibleHeaderText="tipo_nomina" DataField="tipo_nomina" HeaderText="Tipo" />
						<asp:BoundField AccessibleHeaderText="Familia" DataField="nombre_familia" HeaderText="Familia" />
						<asp:BoundField AccessibleHeaderText="monto" DataField="monto" HeaderText="Monto Nomina" />
						
						
						
					</Columns>
					<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
					<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
					<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
					<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
					<EditRowStyle BackColor="#2461BF" />
					<AlternatingRowStyle BackColor="White" />
				</asp:GridView>
				
	
	<table>

	<tr>
		
		<td class="style15">
			 <span class="style12">TOTAL  A RENDIR  </span>  

             <asp:Label ID="total" 
                 runat="server" Font-Names="Arial" Font-Size="Small" Font-Bold="True" 
                 ForeColor="Black" CssClass="style12"></asp:Label>
             </td>
             </tr>
             <tr>
             <td class="style15">
			     <span class="style12">Observacion</span><asp:TextBox ID="txt_observacion" 
                     runat="server" Width="506px" CssClass="style12"></asp:TextBox>
             </td>
		
	</tr>
		</table>
		<table>
    <tr>
    	
			<td> 
             <asp:ImageButton ID="ImageButton1" runat="server" 
                 ImageUrl="~/imagenes/sistema/static/dinero.png" 
                 onclick="ImageButton1_Click" CssClass="style12" Width="35px" />
			 
             </td>

             </tr>
             <tr>

             <td class="style16">
                 <asp:Label ID="lbl_error" runat="server" ForeColor="Red" CssClass="style12"></asp:Label>
             </td>
		
	</tr>

	</table>
	
	</table>
	
			
						</ContentTemplate>
					</ajaxToolkit:TabPanel>

					<ajaxToolkit:TabPanel ID="tab_RENDICION" runat="server" HeaderText="Eliminar Nomina Rendicion" Width="100%">
						<ContentTemplate>
							
	



			<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" Font-Names="Arial" Font-Size="X-Small" ForeColor="#333333" 
        GridLines="None" OnSelectedIndexChanged="gr_dato_SelectedIndexChanged" 
        Style="margin-right: 0px; font-size: x-small;" Width="216px" 
        DataKeyNames="id_nomina,folio,tipo_nomina,monto,familia,id_gasto" EnableModelValidation="True">
			
					<RowStyle BackColor="#EFF3FB" />
					<Columns>
						
						<asp:BoundField AccessibleHeaderText="Folio" DataField="folio" HeaderText="Folio Nomina" />
						<asp:BoundField AccessibleHeaderText="tipo_nomina" DataField="tipo_nomina" HeaderText="Tipo" />
						<asp:BoundField AccessibleHeaderText="Familia" DataField="nombre_familia" HeaderText="Familia" />
						<asp:BoundField AccessibleHeaderText="monto" DataField="monto" HeaderText="Monto Nomina" />
						<asp:TemplateField>
						
						<ItemTemplate>
							<asp:CheckBox ID="chk2" runat="server" EnableViewState="true" Checked='<%# Bind("chk2") %>' />
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
				
	
	<table>

	<tr>
		
		<td class="style15">
			 <span class="style12">TOTAL  A RENDIR  </span>  

             <asp:Label ID="Label5" 
                 runat="server" Font-Names="Arial" Font-Size="Small" Font-Bold="True" 
                 ForeColor="Black" CssClass="style12"></asp:Label>
             </td>
             </tr>
             <tr>
             <td class="style15">
			     &nbsp;</td>
		
	</tr>
		</table>
		<table>
    <tr>
    	<td class="style16">
		
			   
			   <asp:Button ID="Button1" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="21px" OnClick="Button_Click" TabIndex="16" Text="Eliminar  " />
        
      </td>
			<td> 
                &nbsp;</td>

             </tr>
             <tr>

             <td class="style16">
                 <asp:Label ID="Label6" runat="server" ForeColor="Red" CssClass="style12"></asp:Label>
             </td>
		
	</tr>

	</table>
	
	</table>






							</table>


								</ContentTemplate>
					</ajaxToolkit:TabPanel>
					

					<ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="Agregar Nomina Rendicion" Width="100%">
						<ContentTemplate>
							 <table bgcolor="Gray" style="width: 100%">
				<tr>
					<td style="text-align:left; background-color: #006666;" 
                        class="style4">
						
					    <strong>AGREGAR NOMINAS RENDICION</strong></td>
				</tr>
				</table>
    			<table style="background-color: #507cd1; font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #ffffff;">
					<tr>
						<td>
							Familia AGP
						</td>
						<td>
							<asp:DropDownList ID="dl_familia" runat="server" AutoPostBack="True" Width="200px" Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;" OnSelectedIndexChanged="dl_familia_SelectedIndexChanged">
							</asp:DropDownList>
						</td>
						<td>
							Tipo Nómina
						</td>
						<td>
							<asp:DropDownList ID="dl_tiponomina" runat="server" Width="200px" 
								Style="font-family: Arial, Helvetica, sans-serif; font-size: x-small;" 
								onselectedindexchanged="dl_tiponomina_SelectedIndexChanged" AutoPostBack="True">
							</asp:DropDownList>
						</td>
						
						
					
					
					
                    	<td>
						Folio</td>
						<td>
							<asp:TextBox ID="txt_folio" runat="server" Height="16px" Width="92px"
								 Enabled="TRUE" ontextchanged="txt_folio_TextChanged1"></asp:TextBox>
						</td>
						
					   

                    </tr>
                    
                    <tr>
						<td class="style16">
							<asp:Button ID="Button2" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="21px" OnClick="Button_Click1" TabIndex="16" Text="Agregar  " />
						</td>
					</tr>
					
					
				</table>
				
			</asp:Panel>
			
		</ContentTemplate>
		
	
	
         
							
					</ajaxToolkit:TabPanel>

					</ajaxToolkit:TabContainer>
	
</asp:Content>
