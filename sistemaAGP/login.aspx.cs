using System;
using System.Web.UI;
using CENTIDAD;
using CNEGOCIO;

namespace sistemaAGP
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Server.MachineName.ToUpper() != "AGPHOSTING") return;

            if (Request.Url.GetLeftPart(UriPartial.Scheme).IndexOf("https", StringComparison.Ordinal) == -1)
            {
                Response.Redirect(Request.Url.AbsoluteUri.Replace("http", "https"));
            }
            //string userAgent = Request.UserAgent.ToLower();
            //if (userAgent.Contains("iphone") || userAgent.Contains("android") || userAgent.Contains("ppc") || userAgent.Contains("windows ce") || userAgent.Contains("blackberry") || userAgent.Contains("opera mini") || userAgent.Contains("mobile") || userAgent.Contains("palm") || userAgent.Contains("portable"))
            //    Response.Redirect("~/mobile/app.html");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Boolean existe = new UsuarioBC().ValidarUsuario(txt_username.Text, txt_pass.Text.Trim());

            if (existe)
            {
                Usuario musuario = new UsuarioBC().GetUsuario(txt_username.Text);
                int result = DateTime.Compare(musuario.Fechacaducacion, DateTime.Now);

                Session.Add("usrname", txt_username.Text);
                Session.Add("nivel_usuario", musuario.Nivel);

                Response.Redirect(result <= 0 ? "reestablecer_clave.aspx" : "Inicio.aspx?D=" + FuncionGlobal.FuctionEncriptar("INICIO"));
            }
            else
            {
                lbl_error.Text = "Usuario no existe";
            }
        }
    }
}