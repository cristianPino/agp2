using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using CENTIDAD;
using CNEGOCIO;

namespace sistemaAGP
{
	public partial class mUsuariodatos : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				this.txt_cuenta.Text = (string)(Session["usrname"]);
				FuncionGlobal.comboparametro(this.dl_nivel, "NIVEL");
				FuncionGlobal.combocliente(this.dl_cliente);
				FuncionGlobal.comboperfil(this.dl_perfil);
				this.txt_correo.Enabled = false;
				this.txt_intentos.Enabled = false;
				this.dl_cliente.Enabled = false;
				this.dl_nivel.Enabled = false;
				this.dl_perfil.Enabled = false;
				getusuario();
			}
		}

		protected void Button1_Click(object sender, EventArgs e) { add_usuario(); }		

		protected void btnAceptar_Click(object sender, EventArgs e) { }

		private void add_usuario()
		{
            Usuario usr = new UsuarioBC().GetUsuario(this.txt_cuenta.Text);
			int add = new UsuarioBC().add_usuario(this.txt_cuenta.Text, this.txt_nombre.Text, this.txt_clave.Text, this.txt_telefono.Text, Convert.ToInt16(this.txt_anexo.Text), this.txt_correo.Text, this.dl_nivel.SelectedValue, Convert.ToInt16(this.txt_intentos.Text), Convert.ToInt16(this.dl_cliente.SelectedValue), this.dl_perfil.SelectedValue, this.chk_permite_eliminar.Checked,this.usuanav.Text,usr.Permite_pagar);
			if (add != 0)
			{
				FuncionGlobal.alerta("USUARIO INGRESADO CON EXITO", Page);
				return;
			}
			else
			{
				FuncionGlobal.alerta("ERROR AL INGRESAR USUARIO", Page);
				return;
			}
		}

		protected void txt_cuenta_Leave(object sender, EventArgs e) { }

		private void getusuario()
		{
			Usuario usr = new UsuarioBC().GetUsuario(this.txt_cuenta.Text);
			if (usr.Nombre != null)
			{
				this.txt_cuenta.Enabled = false;
				this.txt_nombre.Text = usr.Nombre;
				this.txt_intentos.Text = Convert.ToString(usr.Itentos);
				this.txt_telefono.Text = usr.Telefono;
				this.txt_correo.Text = usr.Correo;
				this.txt_clave.Text = usr.Contraseña;
				this.txt_anexo.Text = Convert.ToString(usr.Anexo);
				this.dl_nivel.SelectedValue = usr.Nivel;
				this.dl_cliente.SelectedValue = Convert.ToString(usr.Cliente.Id_cliente);
				this.dl_perfil.SelectedValue = usr.Perfil.Codigoperfil;
				this.chk_permite_eliminar.Checked = usr.Permite_eliminar;
			}
		}
	}
}