<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucGrabar.ascx.cs" Inherits="sistemaAGP.wucGrabar" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<script type="text/javascript">
    function desactivarBoton()
    {
       
        var boton = $('#<%=btnAceptar.ClientID %>');
        boton.style.display = "none";
       
    }
</script>


<style type="text/css">
	.style1 {
		width: 58px;
	}
	
	      .style6
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: x-small;
            color: #FF3300;
        }
          .style7
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: x-small;
            font-weight: bold;
              color:Red;
			width: 51px;
		}
        
              .modal_div2 {
                border-radius: 20px;
                -ms-border-radius: 10px;
                -moz-border-radius: 10px;
                -webkit-border-radius: 10px;
                -khtml-border-radius: 10px;
                 background-color:Aqua;
                border: 1px solid  #343536;
                
                                  position: absolute;
                height: 233px;
                width: 215px;
                top: 1%;
                left: 19%;
                

              

}
.modal_div2-texto {
                height:210px;
                width: 510px;
                   position:absolute;
                top:500px;
                left:60px
                margin-top: -50px;
                margin-left: -140px;
                color:  #fff;
}
.modal_div2-texto table {
                height: 100%;
                width: 100%;
}
.modal_div2-texto td {
                padding: 3px 6px 3px 6px;
                margin: 5px;
                vertical-align: middle;
                text-align: center;
}

        
        
        .modal_div {
                border-radius: 20px;
                -ms-border-radius: 10px;
                -moz-border-radius: 10px;
                -webkit-border-radius: 10px;
                -khtml-border-radius: 10px;
                 background-color: #669999;
                border: 1px solid  #343536;
                
				opacity:0.9;
                
                                  position: absolute;
                height: 445px;
                width: 350px;
                top: 10%;
                left: 31%;
                

              

}
.modal_div-texto {
                height:44px;
                width: 330px;
                position:absolute;
                top: 400px;
                left:150px;
                margin-left: -140px;
                color:  #fff;
}
.modal_div-texto table {
                height: 100%;
                width: 100%;
}
.modal_div-texto td {
                padding: 3px 6px 3px 6px;
                margin: 5px;
                vertical-align: middle;
                text-align: center;
}

        
    	.style8 {
			width: 110px;
		}

        
    	.style9 {
			font-family: Arial, Helvetica, sans-serif;
			font-size: x-small;
			font-weight: bold;
			color: Red;
			width: 115px;
		}

        
    		
</style>



<table style="background-color: #669999; width: 100%">
	<tr>
		<td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: auto; color: #ffffff;">
			<strong><asp:Label ID="lbl_titulo" runat="server" Text="" /></strong>
		</td>
	</tr>
</table>

<table style="width: 100%">
			<tr>
			 <%--<td >
					<asp:Button ID="bt_guardar" runat="server" Font-Names="Arial" Font-Size="X-Small" Text="Caratula" TabIndex="54" Visible="true" OnClick="bt_guardar_Click" />
				</td>--%>
		   <td >
		  
				 <asp:Button ID="btnSaveClick" runat="server" Font-Names="Arial" Font-Size="X-Small" Text="Guardar" TabIndex="54" onclick="cmdLink_Click"  />
				 </td>
				 <td>
				 <asp:Button ID="bt_limpiar" runat="server" Font-Names="Arial" Font-Size="X-Small" 
						 Text="Limpiar" TabIndex="54" onclick="bt_limpiar_Click"  />
				
			</td>
			
			<td align=right>	
			
					<%--<asp:Label ID="lbl_error" runat="server"></asp:Label>--%>
					<%--<asp:ImageButton ID="ib_poliza" runat="server" ImageUrl="~/imagenes/sistema/static/poliza.jpg" Height="22px" Width="23px" Visible="false" OnClick="ib_poliza_Click" />
					<asp:ImageButton ID="ib_gasto" runat="server" ImageUrl="~/imagenes/sistema/static/dinero.png" Height="22px" Width="23px" OnClick="ib_gasto_Click" Visible="true" />
					<asp:ImageButton ID="ib_comgasto" runat="server" ImageUrl="~/imagenes/sistema/impresoras/impresora.gif" Height="22px" Width="23px" Visible="false" />--%>
				   <asp:Label ID="cargo_vta" runat="server" Font-Names="Arial" Font-Size="Small" ForeColor="#FF3300"
					Visible="false"></asp:Label>
					<asp:Label ID="lbl_operacion"  runat="server" Font-Names="Arial" 
						Font-Size="Small" ForeColor="#FF3300" Visible="true" style="font-weight: 700"></asp:Label>
					<asp:Label ID="lbl_numero" runat="server" Font-Names="Arial" Font-Size="Small" 
						ForeColor="#FF3300" Visible="true" style="font-weight: 700"></asp:Label>
					
				
					<asp:Label ID="lbl_error" Visible="false" runat="server"></asp:Label>
					<asp:ImageButton ID="ib_poliza" runat="server" ImageUrl="~/imagenes/sistema/static/poliza.jpg"
						Height="22px" Width="23px" Visible="false" OnClick="ib_poliza_Click" />
					<asp:ImageButton ID="ib_gasto" runat="server" ImageUrl="~/imagenes/sistema/static/dinero.png"
						Height="22px" Width="23px" OnClick="ib_gasto_Click" Visible="false" />
					<asp:ImageButton ID="ib_comgasto" runat="server" ImageUrl="~/imagenes/sistema/impresoras/impresora.gif"
						Height="22px" Width="24px" Visible="false" onclick="ib_comgasto_Click" />
				<asp:imagebutton id="ib_comgastoingreso" runat="server" imageurl="~/imagenes/sistema/static/panel_control/wflow.png"
					height="22px" width="23px" visible="false" onclick="ib_comgastoingreso_Click" />
				</td>

		  </tr>
		</table>	

		<asp:Panel ID="pnlSeleccionarDatos" runat="server" Style="border-width: 1px; border-style: solid; background-color: #FFFFFF; position: inherit; width: 300px; height: 80px" Height="64px" Width="296px">
		<center style="background-color: #0066CC">
			<asp:Label ID="Label4" ForeColor="Blue" Font-Names="Arial, Helvetica, sans-serif" runat="server" Text="¿Esta seguro de ingresar esta operación?" Font-Size="Small" Style="color: #FFFFFF; font-weight: 700" />
		</center>
		<table style="width: 292px; height: 60px">
			<tr>
				<td align="center" style="background-color: #FFFFFF">
					<asp:button id="btnAceptar" runat="server" font-names="Arial" font-size="X-Small" OnClientClick="desactivarBoton()"
						text="Aceptar" onclick="cmdLink_Click"/>
				</td>
				<td align="center" style="background-color: #FFFFFF">
					<asp:Button ID="btnCancelar" runat="server" Font-Names="Arial" Font-Size="X-Small" Text="Cancelar"  />
				</td>
			</tr>
		</table>
	</asp:Panel>
	<asp:Panel ID="pnl_ingreso_riesgo" runat="server" CssClass="modal_div"  updatemode="Conditional" Visible="false">
		
	
		<asp:GridView ID="gr_dato" runat="server" AutoGenerateColumns="False" CellPadding="4"  CssClass="modal_div2" DataKeyNames="Codigo, Gasto" Font-Names="Arial" Font-Size="X-Small" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="gr_dato_SelectedIndexChanged">
			<RowStyle BackColor="#EFF3FB" />
			<Columns>
				<asp:BoundField AccessibleHeaderText="Codigo" DataField="Codigo" HeaderText="" />
				<asp:BoundField AccessibleHeaderText="Gasto" DataField="Gasto" HeaderText="Gasto" />
				<asp:TemplateField>
					<HeaderTemplate>
					</HeaderTemplate>
					<ItemTemplate>
						<asp:CheckBox ID="chk" runat="server" AutoPostBack="true" Checked='<%# Bind("chk") %>' EnableViewState="true" OnCheckedChanged="Check_Grilla_Clicked" Enabled="false" />
					</ItemTemplate>
				</asp:TemplateField>
				<%--<asp:BoundField AccessibleHeaderText="monto" DataField="monto" HeaderText="Monto" />--%>
				<asp:TemplateField HeaderText="Valor">
					<itemtemplate>
						<asp:TextBox ID="monto" runat="server" AutoCompleteType="Disabled" AutoPostBack="true" Font-Size="7pt" Height="16px" MaxLength="10" OnTextChanged="txt_valor_gasto_Leave" ReadOnly="true" Text='<%# Bind("monto") %>' Width="50px"></asp:TextBox>
						<%--<cc1:FilteredTextBoxExtender ID="txt_valor_gasto_FilteredTextBoxExtender" runat="server" TargetControlID="monto" FilterType="Custom, Numbers" ValidChars="">
					</cc1:FilteredTextBoxExtender>--%>
					</itemtemplate>
				</asp:TemplateField>

				<asp:TemplateField accessibleHeaderText="G.C." HeaderText="G.C.">
				
					<ItemTemplate>
						<asp:CheckBox ID="chkgc" runat="server" AutoPostBack="true" Checked='<%# Bind("chkgc") %>' Enabled="false"
							EnableViewState="true" OnCheckedChanged="Check_Grilla_Clicked" />
					</ItemTemplate>
				</asp:TemplateField>
			</Columns>
			<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
			<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
			<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
			<HeaderStyle BackColor="Blue" Font-Bold="True" ForeColor="White" />
			<EditRowStyle BackColor="#2461BF" />
			<AlternatingRowStyle BackColor="White" />
		</asp:GridView>
        <br/>

        				<table class="modal_div-texto">
					<tr>
						<td class="style9">
							TOTAL SELECCIONADO
						</td>
						<td class="style8">
							<b>
							<asp:Label ID="lbl_total" runat="server" CssClass="style6"></asp:Label>
							
							
							</b>
						</td>
						<td class="style7">
							<asp:Button ID="Buttonguardar" runat="server" Font-Names="Arial" Font-Size="X-Small" Height="25px" OnClick="bt_guardar2_Click" Text="Guardar" Width="59px" />
						</td>
					
                    </tr>
				</table>

	</asp:Panel>
	<cc1:modalpopupextender ID="mpeSeleccion" runat="server" 
		TargetControlID="btnSaveClick" PopupControlID="pnlSeleccionarDatos" 
		CancelControlID="btnCancelar" DropShadow="True"
		BackgroundCssClass="FondoAplicacion" />

			