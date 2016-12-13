<%@ Page Title="" Language="C#" MasterPageFile="~/AGP.Master" AutoEventWireup="true" CodeBehind="importar_excel.aspx.cs" Inherits="sistemaAGP.importar.importar_excel" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoMenu" runat="server">
	<style type="text/css">
        .style5
        {
            font-family: Arial, Helvetica, sans-serif;
        }
        .style6
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: small;
            color: #FFFFFF;
        }
        .style7
        {
            height: 4px;
            margin-left: 40px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoCentral" runat="server">
	<div>
		<asp:Label ID="Label2" runat="server" Text="Carga de Archivo Amicar" Font-Bold="True"></asp:Label>
</div>

<div>
	<asp:Label ID="Label1" runat="server" Text="Seleccione Archivo Excel" Font-Bold="True" ></asp:Label>
<asp:FileUpload ID="fileuploadExcel" runat="server" />&nbsp;&nbsp;
<asp:Button ID="btnImport" runat="server" Text="Cargar Planilla" 
        OnClick="btnImport_Click" />
<br />
<asp:Label ID="lblMessage" runat="server" Font-Bold="True" ForeColor="#009933"></asp:Label>&nbsp;<asp:Button 
        ID="btn_carga" runat="server" Text="Cargar Creditos a Sistema" 
        OnClick="btn_carga_Click" Visible="False" />
    <br />
<asp:GridView ID="grvExcelData" runat="server" CellPadding="4" 
        EnableModelValidation="True" ForeColor="#333333" GridLines="None" 
        Font-Size="Small">
    <AlternatingRowStyle BackColor="White" />
    <EditRowStyle BackColor="#7C6F57" />
    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
<HeaderStyle BackColor="#1C5E55" Font-Bold="true" ForeColor="White" />
    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
    <RowStyle BackColor="#E3EAEB" />
    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
</asp:GridView>
</div>

</asp:Content>
