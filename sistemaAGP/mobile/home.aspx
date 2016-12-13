<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="sistemaAGP.mobile.home" %>

<!DOCTYPE html>
<html>
<head>
	<meta charset="utf-8" />
	<meta name="viewport" content="width=device-width, initial-scale=1" />
	<title></title>
	<link rel="stylesheet" href="https://ajax.aspnetcdn.com/ajax/jquery.mobile/1.1.0/jquery.mobile-1.1.0.min.css" />
	<link rel="stylesheet" href="my.css" />
	<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>
	<script src="https://ajax.aspnetcdn.com/ajax/jquery.mobile/1.1.0/jquery.mobile-1.1.0.min.js"></script>
	<script src="my.js"></script>
</head>
<body>
	<form id="frm_home" runat="server">
	<div data-role="page" id="page1">
		<div data-theme="b" data-role="header">
			<h3>
				Sistema AGP
			</h3>
		</div>
		<div data-role="content" style="padding: 15px">
			<h4>
				Bienvenido, <asp:Label ID="lbl_usuario" runat="server"></asp:Label>
			</h4>
			<div>
				<a href="logout.aspx" data-transition="fade">Cerrar sesión </a>
			</div>
			<div data-role="fieldcontain">
				<label for="selectmenu1">
					Seleccione una opción:
				</label>
				<asp:DropDownList ID="ddl_menu" runat="server" Name="ddl_menu" data-mini="true">
				</asp:DropDownList>
				<%--<select name="selectmenu1" id="selectmenu1" data-mini="true">
					<option value="option1">Menú 1 </option>
					<option value="value">Menú 2 </option>
					<option value="value">Menú 3 </option>
				</select>--%>
			</div>
		</div>
	</div>
	</form>
</body>
</html>