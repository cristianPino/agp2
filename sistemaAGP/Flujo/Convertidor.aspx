<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Convertidor.aspx.cs" Inherits="sistemaAGP.Flujo.Convertidor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table>


	<tr>
	
	<td>
	
		<asp:Label ID="lbl_longitud" runat="server" Text="Longitud"></asp:Label>
	
	</td>
	<td>
	
		<asp:TextBox ID="txt_Longitud" runat="server" 
			ontextchanged="txt_Longitud_TextChanged"></asp:TextBox>
	
	</td>
	<td>
		<asp:Button ID="btn_derecha" runat="server" Text="-->" 
			onclick="btn_derecha_Click" />
	</td>
		<td>
			<asp:Label ID="lbl_x" runat="server" Text="X"></asp:Label>
		</td>
		<td>
			<asp:TextBox ID="txt_x" runat="server" ontextchanged="txt_x_TextChanged"></asp:TextBox>
		</td>
	</tr>
	<tr>
		<td>
			<asp:Label ID="lbl_latitud" runat="server" Text="Latitud"></asp:Label>
		</td>
		<td>
			<asp:TextBox ID="txt_latitud" runat="server" 
				ontextchanged="txt_latitud_TextChanged"></asp:TextBox>
		</td>
		<td>
			<asp:Button ID="izquierda" runat="server" Text="<--" 
				onclick="izquierda_Click" />
		</td>
		<td>
			<asp:Label ID="lbl_y" runat="server" Text="Y"></asp:Label>
		</td>
		<td>
			<asp:TextBox ID="txt_y" runat="server" ontextchanged="txt_y_TextChanged"></asp:TextBox>
		</td>
	</tr>
	<tr>
	<td></td>
	<td></td>
	<td></td>
	<td>
		<asp:Label ID="lbl_zona" runat="server" Text="Zona"></asp:Label>
	</td>
		<td>
			<asp:TextBox ID="txt_zona" runat="server" OnTextChanged="txt_zona_TextChanged"></asp:TextBox>
		</td>
	</tr>
	<tr>
		<td>
		</td>
		<td>
		</td>
		<td>
		</td>
		<td>
			<asp:Label ID="lbl_hemisferio" runat="server" Text="Hemisferio"></asp:Label>
		</td>
		<td>
			<asp:RadioButton ID="rdb_emisferio_n" runat="server" Text="N" Checked="" 
				GroupName="emisferio" AutoPostBack="True" />
			<asp:RadioButton ID="rdb_emisferio_s" runat="server" Text="S" GroupName="emisferio" 
				AutoPostBack="True" />
		</td>
	</tr>
	<tr>
	<td colspan="4">
		<asp:Label ID="lbl_error" runat="server" ForeColor="Red"></asp:Label>
	</td>
	</tr>
	
	</table>
    </div>
    </form>
</body>
</html>
