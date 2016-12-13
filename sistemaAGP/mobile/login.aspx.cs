using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CENTIDAD;
using CNEGOCIO;

namespace sistemaAGP.mobile
{
	public partial class login : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				string user = Request.Form["user"] ?? "";
				string pswd = Request.Form["pswd"] ?? "";

				if (new UsuarioBC().ValidarUsuario(user.Trim(), pswd.Trim()))
				{
					Usuario musuario = new UsuarioBC().GetUsuario(user);
					Session.Add("usrname", user);
					Session.Add("nivel_usuario", musuario.Nivel);
					Response.Redirect("home.aspx", true);
				}
				else
				{
					Response.Redirect("app.html", true);
				}
			}
		}
	}
}