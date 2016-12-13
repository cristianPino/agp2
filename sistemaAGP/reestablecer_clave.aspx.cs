using System;
using System.Web.UI;
using CNEGOCIO;

namespace sistemaAGP
{
    public partial class reestablecer_clave : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            try
            {
                var musuario = new UsuarioBC().GetUsuario(Convert.ToString(Session["usrname"]));
                int result = DateTime.Compare(musuario.Fechacaducacion, DateTime.Now);
                if (result > 0)
                {
                    Response.Redirect("login.aspx");
                    return;
                }
            }
            catch (Exception ex)
            {
                FuncionGlobal.alerta("Se produjo un error: " + ex.Message, Page);
                Response.Redirect("login.aspx");
            }

            try
            {
                lblMensaje.Text =
                 string.Format(
                     "Estimad@ {0}: La contraseña asociada a su cuenta a caducado. Por favor ingrese una nueva.",
                     new UsuarioBC().GetUsuario(Convert.ToString(Session["usrname"])).Nombre.ToUpper().Trim());
            }
            catch (Exception ex)
            {
                FuncionGlobal.alerta("Se produjo un error: " + ex.Message, Page);
                Response.Redirect("login.aspx");
            }

        }

        public bool ValidarContraseniaNueva(string contrasena)
        {
            return contrasena == new UsuarioBC().GetUsuario(Convert.ToString(Session["usrname"])).Contraseña.Trim();
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtContrasena.Text.Trim() == string.Empty || txtContrasenaConfirm.Text.Trim() == string.Empty)
            {
                FuncionGlobal.alerta("Ingrese una nueva contraseña", Page);
                return;
            }

            if (txtContrasena.Text.Trim() != txtContrasenaConfirm.Text.Trim())
            {
                FuncionGlobal.alerta("Las contraseñas son distintas", Page);
                return;
            }
            if (ValidarContraseniaNueva(txtContrasena.Text.Trim()))
            {
                FuncionGlobal.alerta("Ingrese una contraseña distinta a la anterior", Page);
                return;
            }

            try
            {
                new UsuarioBC().ReestablecerContrasenia(Convert.ToString(Session["usrname"]), txtContrasena.Text.Trim());
                FuncionGlobal.alerta("Contraseña cambiada correctamente", Page);
                Response.Redirect("home.aspx");
            }
            catch (Exception ex)
            {
                FuncionGlobal.alerta(ex.Message, Page);
                Response.Redirect("login.aspx");
            }

        }


    }
}