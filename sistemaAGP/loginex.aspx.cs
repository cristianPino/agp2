using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using CENTIDAD;
using CNEGOCIO;


namespace sistemaAGP {
	public partial class _Defaultex : System.Web.UI.Page {

        

		protected void Page_Load(object sender, EventArgs e)
		{
            //if (Server.MachineName.ToUpper() == "AGPHOSTING")
            //{
            //    //if (Request.Url.GetLeftPart(UriPartial.Scheme).IndexOf("https") == -1)
            //    //{
            //    //    Response.Redirect(Request.Url.AbsoluteUri.Replace("http", "https"));
            //    //}
            //}


			string usuario = Request.QueryString["usuario"].ToString();
			string password = Request.QueryString["password"].ToString();
			Boolean existe = new UsuarioBC().ValidarUsuario(usuario, password);
			if (existe == true)
			{

				Usuario musuario = new UsuarioBC().GetUsuario(usuario);
                Session.Add("usrname", usuario);
				Session.Add("nivel_usuario", musuario.Nivel);
				Response.Redirect("home.aspx");
			}
			else
			{
				
				Response.Redirect("http://www.agpsa.cl");

			}

            //string userAgent = Request.UserAgent.ToLower();
            //if (userAgent.Contains("iphone") || userAgent.Contains("android") || userAgent.Contains("ppc") || userAgent.Contains("windows ce") || userAgent.Contains("blackberry") || userAgent.Contains("opera mini") || userAgent.Contains("mobile") || userAgent.Contains("palm") || userAgent.Contains("portable"))
            //    Response.Redirect("~/mobile/app.html");
		}

		protected void Button1_Click(object sender, EventArgs e)
		{
			
		}
	}
}