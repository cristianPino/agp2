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
using System.Collections.Generic;

namespace sistemaAGP
{
	public partial class mUsuario : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

			if (!IsPostBack)
			{
				FuncionGlobal.comboparametro(this.dl_nivel, "NIVEL");
				FuncionGlobal.combocliente(this.dl_cliente);
				FuncionGlobal.combocliente(this.dl_Fcliente);
				FuncionGlobal.comboperfil(this.dl_perfil);
			}
		}

		protected void Button1_Click(object sender, EventArgs e) { add_usuario(); }		

		protected void btnAceptar_Click(object sender, EventArgs e) { }

		private void add_usuario()
		{
			int add = new UsuarioBC().add_usuario(this.txt_cuenta.Text, this.txt_nombre.Text, this.txt_clave.Text, this.txt_telefono.Text, Convert.ToInt16(this.txt_anexo.Text), this.txt_correo.Text, this.dl_nivel.SelectedValue, Convert.ToInt16(this.txt_intentos.Text), Convert.ToInt16(this.dl_cliente.SelectedValue), this.dl_perfil.SelectedValue, this.chk_permite_eliminar.Checked, this.usuanav.Text,this.chk_permite_pagar.Checked);
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

		protected void Button2_Click(object sender, EventArgs e) { limpiar(); }		

		protected void txt_cuenta_Leave(object sender, EventArgs e) { getusuario(); }

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
				this.chk_permite_eliminar.Checked = usr.Permite_eliminar;
                this.chk_permite_pagar.Checked = usr.Permite_pagar;
				this.usuanav.Text = usr.Usuanav;

				this.dl_nivel.SelectedValue = usr.Nivel;

				this.dl_cliente.SelectedValue = Convert.ToString(usr.Cliente.Id_cliente);

				this.dl_perfil.SelectedValue = usr.Perfil.Codigoperfil;

				this.ib_modulo.Attributes.Add("onclick", "javascript:window.showModalDialog('mModulousuario.aspx?id=" + usr.Cliente.Id_cliente + "&id_usuario=" + FuncionGlobal.FuctionEncriptar(usr.UserName) + "','_blank','height=350,width=300, top=150,left=150,status=no,toolbar=no,menubar=no,l ocation=no,scrollbars=no,resizable=no,copyhistory= false')");

                //this.ib_operacion.Attributes.Add("onclick", "javascript:window.showModalDialog('mOperacionUsuario.aspx?id=" + usr.Cliente.Id_cliente + "&id_usuario=" + FuncionGlobal.FuctionEncriptar(usr.UserName) + "','_blank','height=350,width=300, top=150,left=150,status=no,toolbar=no,menubar=no,l ocation=no,scrollbars=no,resizable=no,copyhistory= false')");
                this.ib_operacion.NavigateUrl = "../administracion/mOperacionUsuario.aspx?id=" + usr.Cliente.Id_cliente + "&id_usuario=" + FuncionGlobal.FuctionEncriptar(usr.UserName) ;
                //this.ib_sucursal.Attributes.Add("onclick", "javascript:window.showModalDialog('mUsuariosucursal.aspx?id=" + usr.Cliente.Id_cliente + "&id_usuario=" + FuncionGlobal.FuctionEncriptar(usr.UserName) + "','_blank','height=350,width=300, top=150,left=150,status=no,toolbar=no,menubar=no,l ocation=no,scrollbars=no,resizable=no,copyhistory= false')");
                this.ib_sucursal.NavigateUrl = "../administracion/mUsuariosucursal.aspx?id=" + usr.Cliente.Id_cliente + "&id_usuario=" + FuncionGlobal.FuctionEncriptar(usr.UserName);

				this.ib_perfil.Attributes.Add("onclick", "javascript:window.showModalDialog('mUsuarioopcionmenu.aspx?cuenta_usuario=" + FuncionGlobal.FuctionEncriptar(this.txt_cuenta.Text) + "','_blank','height=400,width=300, top=150,left=150,status=no,toolbar=no,menubar=no,l ocation=no,scrollbars=yes,resizable=no,copyhistory= false')");

                //this.ib_clientes.Attributes.Add("onclick", "javascript:window.showModalDialog('mUsuariocliente.aspx?cuenta_usuario=" + FuncionGlobal.FuctionEncriptar(this.txt_cuenta.Text) + "','_blank','height=400,width=300, top=150,left=150,status=no,toolbar=no,menubar=no,l ocation=no,scrollbars=yes,resizable=no,copyhistory= false')");
                this.ib_clientes.NavigateUrl = "../administracion/mUsuariocliente.aspx?cuenta_usuario=" + FuncionGlobal.FuctionEncriptar(this.txt_cuenta.Text);
                this.hl_usuarioEstado.NavigateUrl = "../administracion/mUsuarioEstado.aspx?cuenta_usuario=" + FuncionGlobal.FuctionEncriptar(this.txt_cuenta.Text);

                this.ib_cuenta_cte.Attributes.Add("onclick", "javascript:window.showModalDialog('mCta_Cte.aspx?cuenta_usuario=" + FuncionGlobal.FuctionEncriptar(this.txt_cuenta.Text) + "','_blank','height=400,width=300, top=150,left=150,status=no,toolbar=no,menubar=no,l ocation=no,scrollbars=yes,resizable=no,copyhistory= false')");

                this.ib_movimiento.Attributes.Add("onclick", "javascript:window.showModalDialog('mMovimiento_Cta.aspx?cuenta_usuario=" + FuncionGlobal.FuctionEncriptar(this.txt_cuenta.Text) + "','_blank','height=400,width=300, top=150,left=150,status=no,toolbar=no,menubar=no,l ocation=no,scrollbars=yes,resizable=no,copyhistory= false')");
				
				this.ib_financieraus.Attributes.Add("onclick", "javascript:window.showModalDialog('mFinancieraus.aspx?cuenta_usuario=" + FuncionGlobal.FuctionEncriptar(this.txt_cuenta.Text) + "','_blank','height=400,width=300, top=150,left=150,status=no,toolbar=no,menubar=no,l ocation=no,scrollbars=yes,resizable=no,copyhistory= false')");

				this.id_usuariofamiliacliente.Attributes.Add("onclick", "javascript:window.showModalDialog('mFamiliaCliente.aspx?id_cliente=" + FuncionGlobal.FuctionEncriptar(this.dl_cliente.SelectedValue) +  "&id_usuario=" + FuncionGlobal.FuctionEncriptar(usr.UserName) + "','_blank','height=400,width=300, top=150,left=150,status=no,toolbar=no,menubar=no,l ocation=no,scrollbars=yes,resizable=no,copyhistory= false')");

				this.ib_modulo.Visible = true;
				this.ib_sucursal.Visible = true;
				this.ib_perfil.Visible = true;
				this.ib_clientes.Visible = true;
				this.ib_operacion.Visible = true;
                this.ib_movimiento.Visible = true;
				this.ib_financieraus.Visible = true;
                this.ib_cuenta_cte.Visible = true;
				this.id_usuariofamiliacliente.Visible = true;
			    hl_usuarioEstado.Visible = true;

			}
		}

		private void limpiar()
		{
			this.ib_modulo.Visible = false;
			this.ib_sucursal.Visible = false;
			this.ib_perfil.Visible = false;
			this.ib_clientes.Visible = false;
			this.ib_operacion.Visible = false;
            this.ib_movimiento.Visible = false;
            this.ib_cuenta_cte.Visible = false;
            this.id_usuariofamiliacliente.Visible = false;
            this.ib_financieraus.Visible = false;

			this.txt_cuenta.Enabled = true;
			this.txt_cuenta.Text = "";
			this.txt_nombre.Text = "";
			this.txt_intentos.Text = "";
			this.txt_telefono.Text = "";
			this.txt_correo.Text = "";
			this.txt_clave.Text = "";
			this.txt_anexo.Text = "";
			this.usuanav.Text = "";
			this.dl_nivel.SelectedValue = "0";
			this.dl_cliente.SelectedValue = "0";
			this.dl_perfil.SelectedValue = "0";
			this.txt_cuenta.Focus();
            this.chk_permite_pagar.Checked = false;
            this.chk_permite_eliminar.Checked = false;
		}

		protected void getusuariocliente()
		{
			DataTable dt = new DataTable();
			dt.Columns.Add(new DataColumn("cuenta"));
			dt.Columns.Add(new DataColumn("nombre"));
			dt.Columns.Add(new DataColumn("nivel"));
			dt.Columns.Add(new DataColumn("perfil"));
			List<Usuario> lusuario = new UsuarioBC().GetUsuariobycliente(Convert.ToInt32(this.dl_Fcliente.SelectedValue));
			foreach (Usuario mUsuario in lusuario)
			{
				DataRow dr = dt.NewRow();
				dr["cuenta"] = mUsuario.UserName;
				dr["nombre"] = mUsuario.Nombre;
				dr["nivel"] = mUsuario.Nivel;
				dr["perfil"] = mUsuario.Perfil.Descripcion;
				dt.Rows.Add(dr);
			}
			this.gr_dato.DataSource = dt;
			this.gr_dato.DataBind();
		}

		protected void ib_modulo_Click(object sender, ImageClickEventArgs e) { }

		protected void ib_operacion_Click(object sender, ImageClickEventArgs e) { }

		protected void gr_dato_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.txt_cuenta.Text = ((GridView)sender).SelectedRow.Cells[0].Text;
			getusuario();
		}

		protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e) { getusuariocliente(); }		

		protected void dl_cliente_SelectedIndexChanged(object sender, EventArgs e) { }

        protected void ib_cuenta_cte_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void ib_movimiento_Click(object sender, ImageClickEventArgs e)
        {

        }

		protected void ib_financieraus_Click(object sender, ImageClickEventArgs e)
		{

		}

        protected void chk_permite_pagar_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void chk_permite_eliminar_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void ib_perfil_Click(object sender, ImageClickEventArgs e)
        {

        }

	}
}