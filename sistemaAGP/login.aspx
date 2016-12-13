<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="sistemaAGP._Default" Theme="Tema1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
	<title>AGP S.A. ASESORIAS Y GESTION DE PROCESOS.</title>
	<style type="text/css">
        .tablalogin {
        	width:400px;
        	height:220px;
        	background-image: url(imagenes/log2mor.png);
        }
        .style2 {
            height: 21px;
        }
        .style3 {
            height: 21px;
            width: 86px;
            color: #333333;
            font-size: medium;
        }
        .style5 {
            width: 86px;
        }
        .style6 {
            height: 18px;
            width: 86px;
            color: #333333;
            font-size: medium;
        }
        .style7 {
            height: 18px;
        }
    </style>
</head>
<body>
	<form id="form1" runat="server">
	<center>
		<table>
			<tr>
				<td>
					&nbsp;
					<table class="tablalogin">
						<tr>
							<td valign="bottom" align="center">
								<table style="width: 277px; height: 66px">
									<tr>
										<td align="center" class="style3">
											usuario
										</td>
										<td align="left" class="style2">
											<asp:TextBox ID="txt_username" runat="server" BackColor="#0099CC" MaxLength="20" ForeColor="White" Font-Names="Verdana" Font-Size="X-Small" Height="18px" Width="150px"></asp:TextBox>
										</td>
									</tr>
									<tr>
										<td class="style6" align="center">
											password
										</td>
										<td class="style7" align="left">
											<asp:TextBox ID="txt_pass" runat="server" BackColor="#0099CC" MaxLength="20" TextMode="Password" ForeColor="White" Font-Names="Verdana" Font-Size="X-Small" Height="18px" Width="150px"></asp:TextBox>
										</td>
									</tr>
								</table>
							</td>
						</tr>
						<tr>
							<td>
								<strong>
									<asp:Label ID="lbl_error" runat="server" Font-Size="Smaller"></asp:Label></strong>
							</td>
						</tr>
						<tr>
							<td><center>
								<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Entrar" Font-Size="XX-Small" />
							</center>
							</td>
						</tr>
					</table>
				</td>
			</tr>
		</table>
		<br />
	</center>
	</form>
</body>
</html>