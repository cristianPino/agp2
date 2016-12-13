<%@ Page Title="" Language="C#" MasterPageFile="~/Adm.Master" AutoEventWireup="true" CodeBehind="mConservadorComuna.aspx.cs" Inherits="sistemaAGP.administracion.mConservadorComuna" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:UpdatePanel runat="server" ID="updateGrilla" UpdateMode="Conditional">
    <ContentTemplate>
    <asp:GridView runat="server" 
                ID="gr_dato"
                CssClass="tabla_datos"
                AutoGenerateColumns="False" 
                EnableModelValidation="True"
                DataKeyNames="idComuna">
                <Columns>
                    <asp:TemplateField HeaderText="Id Comuna">
							    <ItemTemplate>
								    <asp:HyperLink ID="id"   AccessibleHeaderText="id" runat="server" Text='<%# Bind("idComuna") %>' />
							    </ItemTemplate>
							           <ItemStyle CssClass="td_derecha_mediana_2" />
									<HeaderStyle CssClass="td_cabecera_mediana_2" />
					</asp:TemplateField>

                    <asp:BoundField DataField="region"
                                    HeaderText="Región"
                                    AccessibleHeaderText="region"
                                     >
                                  <ItemStyle CssClass="td_derecha_grande"  />
								  <HeaderStyle CssClass="td_cabecera_grande" />
                    </asp:BoundField>
                     <asp:BoundField DataField="ciudad"
                                    HeaderText="ciudad"
                                    AccessibleHeaderText="ciudad"
                                     >
                                  <ItemStyle CssClass="td_derecha_grande"  />
								  <HeaderStyle CssClass="td_cabecera_grande" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Comuna">
							    <ItemTemplate>
								    <asp:HyperLink ID="comuna"   AccessibleHeaderText="comuna" runat="server" Text='<%# Bind("comuna") %>' />
							    </ItemTemplate>
							       <ItemStyle CssClass="td_derecha_grande"  />
								  <HeaderStyle CssClass="td_cabecera_grande" />
					</asp:TemplateField>
                                  
                     <asp:TemplateField HeaderText="Pertenece">
                                <HeaderTemplate>
                                <asp:CheckBox runat="server" ID="checkall" AutoPostBack="True"  OnCheckedChanged="Check_Clicked" />
                                </HeaderTemplate>
							    <ItemTemplate>
                                    <asp:CheckBox ID="chk" runat="server" Checked='<%# Bind("check") %>' />
							    </ItemTemplate>
							       <ItemStyle CssClass="td_derecha_grande"  />
								  <HeaderStyle CssClass="td_cabecera_grande" />
					</asp:TemplateField>
                   
                </Columns>  
                        <HeaderStyle CssClass="tr_cabecera" />
						<RowStyle CssClass="tr_fila" />
						<AlternatingRowStyle CssClass="tr_fila_alt" />      
    </asp:GridView>
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar Cambios" 
            CssClass="button" onclick="btnGuardar_Click" />
            <ajaxToolkit:ConfirmButtonExtender ID="Button1_ConfirmButtonExtender" runat="server" TargetControlID="btnGuardar"
                        ConfirmText="¿Esta seguro de guardar los cambios?" >
    </ajaxToolkit:ConfirmButtonExtender>
      
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
