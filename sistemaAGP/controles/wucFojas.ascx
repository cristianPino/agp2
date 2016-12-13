<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wucFojas.ascx.cs" Inherits="sistemaAGP.controles.wucFojas" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
 <asp:UpdatePanel runat="server" ID="updateGrilla" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:Label ID="lblTipo" runat="server" Text="" Visible="False"></asp:Label>
    <asp:GridView runat="server" 
                ID="grFojas"
                CssClass="tabla_datos"
                AutoGenerateColumns="False" 
                EnableModelValidation="True"
                DataKeyNames="idFoja,idSolicitud,tipo" 
                onrowediting="grFojas_RowEditing" 
                onrowcancelingedit="grFojas_RowCancelingEdit" 
                onrowupdating="grFojas_RowUpdating"
                OnRowCommand="grFojas_RowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="Id">
							    <ItemTemplate>
								    <asp:HyperLink ID="id"   AccessibleHeaderText="id" runat="server" Text='<%# Bind("idFoja") %>' />
							    </ItemTemplate>
							           <ItemStyle CssClass="td_derecha_mediana_2" />
									<HeaderStyle CssClass="td_cabecera_mediana_2" />
					</asp:TemplateField>
                     <asp:TemplateField HeaderText="Tipo">
							    <ItemTemplate>
								    <asp:HyperLink ID="descripcionTipo"   AccessibleHeaderText="descripcionTipo" runat="server" Text='<%# Bind("descripcionTipo") %>' />
							    </ItemTemplate>
							           <ItemStyle CssClass="td_derecha_mediana_2" />
									<HeaderStyle CssClass="td_cabecera_mediana_2" />
					</asp:TemplateField>
                   
                     <asp:BoundField DataField="inscripcionFoja"
                                    HeaderText="Inscripcion Foja"
                                    AccessibleHeaderText="inscripcionFoja"
                                     >
                                  <ItemStyle CssClass="td_derecha"  />
								  <HeaderStyle CssClass="td_cabecera" />
                      </asp:BoundField>
                      <asp:BoundField DataField="fojaLetra"
                                    HeaderText="Letra"
                                    AccessibleHeaderText="inscripcionFoja">
                                  <ItemStyle CssClass="td_derecha"  />
								  <HeaderStyle CssClass="td_cabecera" />
                    </asp:BoundField>
                     <asp:BoundField DataField="inscripcionNumero"
                                    HeaderText="Inscripción Número"
                                    AccessibleHeaderText="inscripcionNumero"
                                     >
                                  <ItemStyle CssClass="td_derecha"  />
								  <HeaderStyle CssClass="td_cabecera" />
                    </asp:BoundField>
                     <asp:BoundField DataField="inscripcionAnio"
                                    HeaderText="Inscripcion Año"
                                    AccessibleHeaderText="InscripcionAnio"
                                     >
                                  <ItemStyle CssClass="td_derecha"  />
								  <HeaderStyle CssClass="td_cabecera" />
                    </asp:BoundField>
                      <asp:BoundField DataField="observaciones"
                                    HeaderText="Observaciones"
                                    AccessibleHeaderText="observaciones"
                                     >
                                  <ItemStyle CssClass="td_derecha_grande"  />
								  <HeaderStyle CssClass="td_cabecera_grande" />
                    </asp:BoundField>
                                  
                    <asp:ButtonField ButtonType="Image" 
                                    CommandName="Edit" 
                                    HeaderText="Editar"
                                    AccessibleHeaderText="editar" 
                                    ImageUrl="~/imagenes/sistema/static/edit.png"
                                    ShowHeader="True" >
                                  <ItemStyle CssClass="td_derecha"  />
								  <HeaderStyle CssClass="td_cabecera" />
                    </asp:ButtonField>
                    
                    <asp:ButtonField ButtonType="Image" CommandName="Cancel" HeaderText="Cancelar " 
                        ImageUrl="~/imagenes/sistema/static/109_AllAnnotations_Error_16x16_72.png" 
                        ShowHeader="True" Text="cancelar" />
                    <asp:ButtonField ButtonType="Image" CommandName="Update" 
                        HeaderText="Actualizar" 
                        ImageUrl="~/imagenes/sistema/static/109_AllAnnotations_Default_16x16_72.png" 
                        ShowHeader="True" Text="Actualizar" />
                     <asp:TemplateField HeaderText="Eliminar">
							    <ItemTemplate>
                                    <asp:ImageButton ID="ibEliminar" 
                                                        runat="server"
                                                        Height="32px" Width="32px"
                                                        ImageUrl="../imagenes/sistema/static/Rechazar.jpg" 
                                                        CommandName="Eliminar"  CommandArgument='<%#((GridViewRow)Container).RowIndex %>'
                                                        />
                                     <ajaxToolkit:ConfirmButtonExtender  ID="ConfirmButtonExtender1" 
                           runat ="server" 
                           TargetControlID="ibEliminar"
                           
                           ConfirmText="¿Esta seguro de eliminar esta foja?"/>
							    </ItemTemplate>
							    <ItemStyle CssClass="td_derecha_mediana_2" />
								<HeaderStyle CssClass="td_cabecera_mediana_2" />
		  </asp:TemplateField>
                  
                </Columns>  
                        <HeaderStyle CssClass="tr_cabecera" />
						<RowStyle CssClass="tr_fila" />
						<AlternatingRowStyle CssClass="tr_fila_alt" />      
    </asp:GridView>
    </ContentTemplate>
    </asp:UpdatePanel>
