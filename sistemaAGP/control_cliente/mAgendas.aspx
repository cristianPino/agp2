<%@ Page Title="Agendas" Language="C#" MasterPageFile="~/Adm.Master" AutoEventWireup="true" CodeBehind="mAgendas.aspx.cs" Inherits="sistemaAGP.mAgendas" EnableSessionState="True" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
	<style type="text/css">
        .style31
        {
            width: 1115px;
            height: 16px;
        }
        </style>
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <table  bgcolor="#cccccc" style="width: 100%; height: 13px;">
        <tr>
            <td style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; width: 1115px; color: #000000;">
                <b>AGENDAR FIRMA</b></td>
        </tr>
    </table>
	<table bgcolor="#669999" style="width: 100%; height: 14px;">
		<tr>
			<td align="center" style="font-family: Arial, Helvetica, sans-serif; font-size: x-small; color: #FFFFFF;"
				class="style31">
				<b>AGENDA</b>
			</td>
		</tr>
	</table>
    <asp:Table ID="TBL_Agenda" runat="server" Width="100%" Visible="false">
        <asp:TableRow>
        <asp:TableCell>
            <table width="100%">
		        <tr>
			        <td align="center">
                <asp:Label ID="Label11" runat="server" Text="Encargado"></asp:Label>&nbsp;
				<asp:Dropdownlist runat="server" id="dl_Usuarios" onselectedindexchanged="dl_Usuarios_SelectedIndexChanged"
					autopostback="true">
 				</asp:dropdownlist>
                &nbsp;&nbsp;
                <asp:Label ID="Label12" runat="server" Text="Tipo Agendamineto"></asp:Label>
                &nbsp;
				<asp:Dropdownlist runat="server" id="cbo_tipoagenda">
					<asp:Listitem text="Firma de crédito" value="FR" />
					<asp:Listitem text="Verificación de domicilio" value="VD" />
                    <asp:Listitem text="Firma de crédito Y Verificación de domicilio" value="FRVD" />

				</asp:DropdownList>
			</td>
		        </tr>
		        <tr>		
			        <td valign="top" align="center">
                <asp:Calendar ID="cld_FechaFirma" runat="server" 
                    onselectionchanged="cld_FechaFirma_SelectionChanged" BackColor="White" 
                    BorderColor="Black" BorderStyle="Solid" CellSpacing="1" Font-Names="Verdana" 
                    Font-Size="9pt" ForeColor="Black" Height="308px" NextPrevFormat="ShortMonth" 
                    ToolTip="Seleccione un Dia" Width="472px">
                    <DayHeaderStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" 
                        Height="8pt" />
                    <DayStyle BackColor="#CCCCCC" />
                    <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="White" />
                    <OtherMonthDayStyle ForeColor="#999999" />
                    <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                    <TitleStyle BackColor="#333399" BorderStyle="Solid" Font-Bold="True" 
                        Font-Size="12pt" ForeColor="White" Height="12pt" />
                    <TodayDayStyle BackColor="#999999" ForeColor="White" />
                    <WeekendDayStyle BackColor="White" BorderColor="Blue" />
                </asp:Calendar>
                <asp:Label ID="lblfechaseleccionada" runat="server" Text="" Visible="false"></asp:Label>
                <asp:Label ID="Label1" runat="server" Text="REASIGNANDO OPERACION :" Visible="false"></asp:Label>
                &nbsp;&nbsp;&nbsp;<asp:Label ID="lblnroOpe" runat="server" Text="0" Visible="false"></asp:Label>
			</td>		
		        </tr>
                <tr>
                    <td valign="top" align="center">
                        <asp:gridview id="grdResultado" runat="server" allowpaging="True" autogeneratecolumns="False" onrowdatabound="grdResultado_RowDataBound" onrowcreated="grdResultado_RowCreated"
					        onrowcommand="grdResultado_RowCommand" width="850px" allowsorting="True" enablemodelvalidation="True" autopostback="true">
                            <EmptyDataTemplate>
                                <table>
                                    <tr align="center">
                                        <td class="ms-input">
                                            No existen registros.
                                        </td>
                                    </tr>
                                </table>
                            </EmptyDataTemplate>
                            <Columns>      
                                <asp:BoundField DataField="Hora_firma" HeaderText="Hora"/>
                                <asp:TemplateField HeaderText=".">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btn_Tomada" runat="server" CommandName="Tomada" ImageUrl="~/imagenes/sistema/static/persona.png" Width="25px" />
                                        <asp:ImageButton ID="btn_Disponible" runat="server" CommandName="Disponible" ImageUrl="~/imagenes/sistema/static/ok.png" Width="25px"  />
                                    </ItemTemplate>
                                </asp:TemplateField>
					            <asp:BoundField DataField="id_solicitud" HeaderText="Solicitud" />
                                <asp:BoundField DataField="Estado" HeaderText="Estado" />
                                <asp:BoundField DataField="Cliente" HeaderText="Cliente" />
                                <asp:BoundField DataField="Direccion" HeaderText="Direccion" />
                                <asp:BoundField DataField="comuna" HeaderText="Comuna" />
                                <asp:BoundField DataField="Telefono" HeaderText="Telefono" />
                                <asp:BoundField DataField="celular" HeaderText="Celular" />
                                <asp:BoundField DataField="N_intentos" HeaderText="Intento" />
                                <asp:TemplateField HeaderText="Reasignar" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                         <asp:ImageButton ID="btnReasignar" runat="server" CommandName="Reasignar" ImageUrl="~/imagenes/sistema/static/Reciclar.Gif" Width="25px"/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Rechazo" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnRechazo"  runat="server"  CommandName="Rechazo"   ImageUrl="~/imagenes/sistema/static/Rechazar.jpg" Width="25px"/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                        </Columns>
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Font-Names="Verdana" Font-Size="8pt" />
                            <EditRowStyle BackColor="#999999" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" Font-Names="Times New Roman"
                                Font-Size="9pt" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" Font-Size="8pt"
                                Font-Names="Verdana,sans-serif" />
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" Font-Names="Verdana" Font-Size="8pt" />
                        </asp:GridView>                    
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
            </table>
        </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

<asp:Table ID="TBL_Operacion" runat="server" Width="100%" Visible="false">
        <asp:TableRow>
            <asp:TableCell>
	
	<table width="100%">
		<tr>	
			<td class="style32">
				<asp:label id="lbl_numero" runat="server" text="Nº Operación: "></asp:label>
			</td>	
			<td >
                <asp:Label ID="lbl_operacion" runat="server" Text="lbl_operacion"></asp:Label>
			</td>		
		</tr>
		<tr>
			<td class="style32">
				<asp:label id="lbl_fecha" runat="server" text="lbl_fecha"></asp:label>
                &nbsp;&nbsp;&nbsp;
                <asp:Label ID="lbl_hora" runat="server" Text=""></asp:Label>
			</td>
            <td>
                <asp:Label ID="Label20" runat="server" Text="Ejecutivo Comercial"></asp:Label>
                &nbsp;&nbsp;
                <asp:DropDownList ID="cbo_EjeCom" runat="server" ToolTip="Ejecutivo Comercial Asociado al Credito" style="font-size:9px; font-family:Tahoma;">
                </asp:DropDownList>
            </td>
		</tr>
		<tr>
			<td class="style32">
				<asp:label id="lbl_intentos" runat="server" text="lbl_intentos" visible="false"></asp:label>
			</td>
		</tr>
		
        </table>

   <table width="100%" class="tabla-normal" style=" background-color:Silver; ">
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Rut"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txt_rut" runat="server" style="font-size:9px; font-family:Tahoma;" ontextchanged="txt_rut_TextChanged" onKeyPress="return solonumeros(event)" AutoPostBack="true" MaxLength="8"></asp:TextBox> - 
                <asp:TextBox ID="txt_dv" runat="server" Enabled="False" Width="20px" style="font-size:9px; font-family:Tahoma;"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Nombre"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtNombre" runat="server" 
                    style="font-size:9px; font-family:Tahoma;" Width="300px"></asp:TextBox>
            </td>

        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Apellido Paterno"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtApellidoP" runat="server" 
                    style="font-size:9px; font-family:Tahoma;" Width="303px"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="Label5" runat="server" Text="Apellido Materno"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtApellidoM" runat="server" 
                    style="font-size:9px; font-family:Tahoma;" Width="301px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label6" runat="server" Text="Direccion"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtdireccion" runat="server" 
                    style="font-size:9px; font-family:Tahoma;" Width="350px"></asp:TextBox>  
            </td>
            <td>
                <asp:Label ID="Label19" runat="server" Text="Número"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txt_numeriDir" runat="server" style="font-size:9px; font-family:Tahoma;" onKeyPress="return solonumeros(event)"></asp:TextBox>
            </td>
        </tr>
        <tr>
         <td>
                <asp:Label ID="Label17" runat="server" Text="Comuna"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="cboComuna" runat="server" 
                    style="font-size:9px; font-family:Tahoma;" Height="16px" Width="299px">
                </asp:DropDownList>
            </td>
            <td>
                <asp:Label ID="Label13" runat="server" Text="tipo Dirección"></asp:Label>
            </td>
            <td>
                <asp:RadioButtonList ID="rdbtipodir" runat="server">
                <asp:ListItem Text="Particular" Value="DCAS">  </asp:ListItem>
                <asp:ListItem Text="Comercial" Value="DOFI"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label14" runat="server" Text="Telefono"></asp:Label>
            </td>
            <td>
                <%--<asp:Label ID="Label18" runat="server" Text="Codigo Area"></asp:Label>
                &nbsp;&nbsp;
                <asp:DropDownList ID="cbo_codigoarea" runat="server" style="font-size:9px; font-family:Tahoma;">
                    <asp:ListItem Text="Seleccionar" Value="0"></asp:ListItem>
                    <asp:ListItem Text="I Región" Value="57"></asp:ListItem>
                    <asp:ListItem Text="II Región" Value="55"></asp:ListItem>
                    <asp:ListItem Text="III Región-Prov de Huasco" Value="51"></asp:ListItem>
                    <asp:ListItem Text="III Región-Prov de Chañaral y Copiapó" Value="52"></asp:ListItem>
                    <asp:ListItem Text="IV Región-Prov de Elqui" Value="51"></asp:ListItem>
                    <asp:ListItem Text="IV Región-Prov de Choapa y Limarí" Value="53"></asp:ListItem>
                    <asp:ListItem Text="V Región-Prov de Valparaíso" Value="32"></asp:ListItem>
                    <asp:ListItem Text="V Región-Provincias de Petorca y Quillota" Value="33"></asp:ListItem>
                    <asp:ListItem Text="V Región-Prov de Los Andes y San Felipe" Value="34"></asp:ListItem>
                    <asp:ListItem Text="V Región-Prov de San Antonio " Value="35"></asp:ListItem>
                    <asp:ListItem Text="V Región-Prov de Isla de Pascua" Value="39"></asp:ListItem>
                    <asp:ListItem Text="Región Metropolitana" Value="02"></asp:ListItem>
                    <asp:ListItem Text="VI Región" Value="72"></asp:ListItem>
                    <asp:ListItem Text="VII Región-Prov de Talca" Value="71"></asp:ListItem>
                    <asp:ListItem Text="VII Región-Prov de Curicó" Value="75"></asp:ListItem>
                    <asp:ListItem Text="VII Región-Prov de Cauquenes y Linares" Value="73"></asp:ListItem>
                    <asp:ListItem Text="VIII Región-Prov de Arauco y Concepción" Value="41"></asp:ListItem>
                    <asp:ListItem Text="VIII Región-Prov de Ñuble" Value="42"></asp:ListItem>
                    <asp:ListItem Text="VIII Región-Prov de Biobío" Value="43"></asp:ListItem>
                    <asp:ListItem Text="IX Región" Value="45"></asp:ListItem>
                    <asp:ListItem Text="X Región-Prov de Osorno" Value="64"></asp:ListItem>
                    <asp:ListItem Text="X Región-Prov de Chiloé, Llanquihue y Palena" Value="65"></asp:ListItem>
                    <asp:ListItem Text="XI Región" Value="67"></asp:ListItem>
                    <asp:ListItem Text="XII Región-" Value="61"></asp:ListItem>
                    <asp:ListItem Text="XIV Región" Value="63"></asp:ListItem>
                    <asp:ListItem Text="XV Región" Value="58"></asp:ListItem>
                </asp:DropDownList>
                &nbsp;--%>
                <asp:TextBox ID="txt_telefono" runat="server" MaxLength="7" style="font-size:9px; font-family:Tahoma;" onKeyPress="return solonumeros(event)"></asp:TextBox>
                <asp:Label ID="Label16" runat="server" Text="Ejemplo 1234567" ForeColor="blue" style="font-size:10px; font-family:Tahoma;"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label7" runat="server" Text="Celular"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txt_celular" runat="server" MaxLength="8" style="font-size:9px; font-family:Tahoma;" onKeyPress="return solonumeros(event)"></asp:TextBox>
                <asp:Label ID="Label15" runat="server" Text="Ejemplo 91234567" ForeColor="blue" style="font-size:10px; font-family:Tahoma;"></asp:Label>
            </td>
        </tr>
        <tr>
           
        </tr>
    </table>

   <table width="50%">
    <tr>
        <td>
            <asp:Label ID="Label18" runat="server" Text="nro Credito Interno"></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txt_cantidadCredito" runat="server" Width="60" font-names="Arial" font-size="X-Small" onKeyPress="return solonumeros(event)"></asp:TextBox>
        </td>
        <td>
            <asp:Button ID="btnAgregarcredito" runat="server" Text="Agregar" onclick="btnAgregarcredito_Click"/>        
        </td>
		
    </tr>
    <tr>
        <td colspan="2">
              <asp:gridview id="grdAddCreditos" runat="server" allowpaging="True" autogeneratecolumns="False" allowsorting="True" enablemodelvalidation="True"	>
                <EmptyDataTemplate>
                    <table>
                        <tr align="center">
                            <td class="ms-input">
                                No existen registros.
                            </td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <Columns>      
                    <asp:BoundField DataField="Id_interno" HeaderText="Nro Credito Crediautos" />
                </Columns>
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Font-Names="Verdana" Font-Size="8pt" />
                <EditRowStyle BackColor="#999999" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" Font-Names="Times New Roman"
                    Font-Size="9pt" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" Font-Size="8pt"
                    Font-Names="Verdana,sans-serif" />
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" Font-Names="Verdana" Font-Size="8pt" />
            </asp:GridView>
        </td>   
    </tr>
   </table>

   <table>
        <tr>
		    <td class="style32">
			    &nbsp;</td>
			<td>
					&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label9" runat="server" Text="Creditos Firmados, Asociados a Operación" Visible="false"></asp:Label>   
            </td>
        </tr>
        <tr>
            <td>
                <asp:gridview id="grdCrditos" runat="server" allowpaging="True" autogeneratecolumns="False"
					 width="850px" allowsorting="True" enablemodelvalidation="True"	autopostback="true" onrowdatabound="grdCrditos_RowDataBound">
                <EmptyDataTemplate>
                    <table>
                        <tr align="center">
                            <td class="ms-input">
                                No existen registros.
                            </td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <Columns>      
                    <asp:BoundField DataField="Id_solicitud" HeaderText="Nro Agenda" />
                    <asp:BoundField DataField="Id_interno" HeaderText="Nro Credito Crediautos" />
                    <asp:BoundField DataField="Id_credito" HeaderText="Nro Interno AGP" />
                    <asp:TemplateField HeaderText="Carpeta Digital">
                       <ItemTemplate>
                        <asp:ImageButton ID="ib_cdigital" runat="server" ImageUrl="../imagenes/sistema/static/carpetas.gif" Width="20px" Height="20px" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Font-Names="Verdana" Font-Size="8pt" />
                <EditRowStyle BackColor="#999999" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" Font-Names="Times New Roman"
                    Font-Size="9pt" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" Font-Size="8pt"
                    Font-Names="Verdana,sans-serif" />
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" Font-Names="Verdana" Font-Size="8pt" />
            </asp:GridView>
            </td>
            <td></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label10" runat="server" Text="Observación:"></asp:Label>
                &nbsp;
                <asp:TextBox ID="txt_obs" runat="server" TextMode="MultiLine" Wrap="true" Height="126px" Width="606px"></asp:TextBox> 
            </td>
        </tr>
    </table>
       
   <table  bgcolor="cccccc" style="width: 100%" >
                <tr>
                     <td style="text-align: center; width: 38px;">
                        <asp:Button ID="bt_guardar" runat="server" Font-Names="Arial" Font-Size="X-Small" 
                            Text="Guardar" TabIndex="53" onclick="bt_guardar_Click" Enabled="false" />
                    </td>
					<td colspan="4">
						<asp:Label ID="lblerror2" runat="server" Text="" ForeColor="Red"> </asp:Label>
					</td>
					<td style="text-align: center; width: 38px;">
                    <asp:Button ID="btnRechCred" runat="server" Text="Rechazar"  onclick="btnRechCred_Click" Visible="false" font-names="Arial" font-size="X-Small"/>
						<asp:Button id="bt_finalizar" runat="server" font-names="Arial" font-size="X-Small"
							text="Finalizar" tabindex="53" onclick="bt_finalizar_Click" visible="false" />
					</td>
					<td>
						<%--<asp:label id="lbl_fin" runat="server" text="lbl_finalizar"  forecolor="Red"></asp:label>--%>
						<asp:label id="label_fin" runat="server" text="OPERACION FINALIZADA" visible="false" forecolor="Red"></asp:label>
					</td>
                    <td>

                        <asp:Button ID="bt_Volver" runat="server" Text="Volver a Agenda" onclick="bt_Volver_Click" Visible="false" font-names="Arial" font-size="X-Small"/> 
                    </td>     
                    <td style="text-align: right">
						&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:Label ID="Label8" runat="server" Text="" ForeColor="Red" Font-Size="11px"></asp:Label>
                    </td>
                </tr>
            </table>
                    </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <br/>
    <asp:Label ID="lbl_Oper_ID" runat="server" Text="" Visible="false"></asp:Label>
    &nbsp;&nbsp;&nbsp;
    <asp:Label ID="lbl_Oper_Hora" runat="server" Text="" Visible="false"></asp:Label>
    &nbsp;&nbsp;&nbsp;
    <asp:Label ID="lbl_Oper_Tipo" runat="server" Text="" Visible="false"></asp:Label>
    &nbsp;&nbsp;&nbsp;
    <asp:Label ID="lbl_Oper_IDCli" runat="server" Text="" Visible="false"></asp:Label>
    &nbsp;&nbsp;&nbsp;
    <asp:Label ID="lbl_Oper_Fecha" runat="server" Text="" Visible="false"></asp:Label>
    
</asp:Content>

