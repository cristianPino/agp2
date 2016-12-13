<%@ Page Title="" Language="C#" MasterPageFile="~/modal2.Master" AutoEventWireup="true" CodeBehind="Documentos.aspx.cs" Inherits="sistemaAGP.OrdenTrabajo.modal.Documentos" %>
<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=3.5.40412.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>
<%@ Register TagPrefix="AjaxControlToolkit" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=3.5.40412.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <asp:UpdatePanel runat="server" id="UpdatePanel1" >
<ContentTemplate>
   <div class="divTituloModal">
        <img src="../../imagenes/sistema/static/panel_control/carpeta.png" /> 
        <asp:Label ID="Label1" runat="server" Text="Carpeta digital"></asp:Label>
    </div>
    <div style="clear: both">
					<asp:GridView ID="gr_documentos" 
                                runat="server" 
                                CssClass="tabla_mensaje" 
                                AutoGenerateColumns="False"  
                                CellPadding="4" Font-Size="X-Small" 
                                DataKeyNames="idChecklistOrdenPedido,idOrdenTrabajo, id_checklist,url" 
                                GridLines="None"  
                                OnRowCommand="gr_documentos_RowCommand"  
                                EnableModelValidation="True">						
						        <Columns>
							            

                                       

							            <asp:ButtonField DataTextField="nombre" 
                                                    HeaderText="Archivo" 
                                                    CommandName="View">
                                             <ItemStyle CssClass="td_derecha_grande"  />
								             <HeaderStyle CssClass="td_cabecera_grande" />
						                </asp:ButtonField> 

							           

                                        <asp:BoundField AccessibleHeaderText="fecha" 
                                                    DataField="fecha" 
                                                    HeaderText="Fecha">
							                 <ItemStyle CssClass="td_derecha"  />
								             <HeaderStyle CssClass="td_cabecera" />
						                </asp:BoundField> 

                                         <asp:BoundField AccessibleHeaderText="usuario" 
                                                    DataField="usuario" 
                                                    HeaderText="Usuario">
							                 <ItemStyle CssClass="td_derecha"  />
								             <HeaderStyle CssClass="td_cabecera" />
						                </asp:BoundField> 

							            <asp:BoundField AccessibleHeaderText="observaciones" 
                                                    DataField="observaciones" 
                                                    HeaderText="Observaciones">
							                 <ItemStyle CssClass="td_derecha_mediana"  />
								             <HeaderStyle CssClass="td_cabecera_mediana" />
						                </asp:BoundField> 

							            <asp:TemplateField AccessibleHeaderText="eliminar">
								            <ItemTemplate>
									                 <asp:CheckBox ID="chk_eliminar" 
                                                                runat="server" 
                                                                Checked="false" />
								            </ItemTemplate>
							                <ItemStyle CssClass="td_derecha_chica"  />
								            <HeaderStyle CssClass="td_cabecera_chica" />						   	
							            </asp:TemplateField>
						        </Columns>
                                <HeaderStyle CssClass="tr_cabecera" />
						        <RowStyle CssClass="tr_fila" />
						        <AlternatingRowStyle CssClass="tr_fila_alt" />	
					        </asp:GridView>
                            </div>
                    <br />

                    <asp:Panel ID="divBoton" 
                                runat="server" 
                                CssClass="centrado">

						            <asp:Button ID="bt_eliminar" 
                                                runat="server" 
                                                CssClass="button" 
                                                Text="Eliminar los documentos seleccionados" 
                                                onclick="bt_eliminar_Click" />
						            <AjaxControlToolkit:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="bt_eliminar"
                                                                                          ConfirmText="¿Está seguro de Eliminar los archivos seleccionados?"/>

					 </asp:Panel>
                    <br />

                    <asp:Panel ID="Panel_subir" 
                                Width="100%" 
                                runat="server">
                                <table class="table" 
                                        style="width:100%" >
                                       
                                        <tr>
                                           
                                            <td colspan="2" > 
                                                        <asp:DropDownList ID="dl_lista_titulos" 
                                                                    Width="100%" 
                                                                    runat="server" CssClass="ddl"/>
                                            </td>
                                        </tr>
                                        <tr>
                                           
                                            <td colspan="2">
                                                        <asp:TextBox ID="txt_comentarios" 
                                                        placeholder="Comentarios" class="inputs"
                                                                    Width="100%" 
                                                                    runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                           
                                            <td> 
                                                        <asp:FileUpload ID="fu_archivo"  
                                                                    runat="server" 
                                                                    CssClass="button" />
                                            </td>
                                            <td>
                                                        <asp:Button ID="btn_subir" 
                                                                    runat="server" 
                                                                    CssClass="button" 
                                                                    Text="Subir" 
                                                                    onclick="btn_subir_Click" />
                                                                
                                                <AjaxControlToolkit:ConfirmButtonExtender ID="ConfirmButtonExtender8" runat="server" TargetControlID="btn_subir"
                                                                                          ConfirmText="¿Está seguro de Subir este archivo?"/>
                                            </td>
                                        </tr>
                                    </table>

                   
                    </asp:Panel>
					
				
			
		<div class="centrado">
			&nbsp;
		</div>
		<div class="centrado">
			<iframe id="i_documento" 
                    frameborder="1" 
                    height="400px" 
                    width="95%" 
                    runat="server" 
                    scrolling="auto"></iframe>
		</div>
       
         </ContentTemplate>
                 <Triggers>
                <asp:PostBackTrigger ControlID="btn_subir" />
            </Triggers>
       </asp:UpdatePanel>
    <asp:HiddenField ID="hdId" runat="server" />
    
           <div class="divInfo" style="clear: both" id="divInfo" runat="server">
        <center>
            <table>
                <tr>
                    <td>
                        <asp:ImageButton ID="ibSalir" runat="server" ImageUrl="~/imagenes/sistema/static/hipotecario/salir.png"
                            OnClick="ibSalir_Click" />
                    </td>
                </tr>
            </table>
        </center>
    </div>
</asp:Content>
