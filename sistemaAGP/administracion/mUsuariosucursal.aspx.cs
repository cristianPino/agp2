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
using System.Collections.Generic;
using CENTIDAD;
using CNEGOCIO;


namespace sistemaAGP
{
	public partial class mUsuariosucursal : System.Web.UI.Page
	{
		private string cuenta_usuario;

		protected void Page_Load(object sender, EventArgs e)
		{
			string cuenta_usu;
			cuenta_usu = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_usuario"].ToString());
			cuenta_usuario = cuenta_usu;
			if (!IsPostBack)
			{
				FuncionGlobal.comboclientesbyusuario(cuenta_usuario, this.dl_cliente);
				Usuario musuario = new UsuarioBC().GetUsuario(cuenta_usuario);
				this.lbl_usuario.Text = musuario.Nombre;
			}
		}

		protected void Check_Clicked(Object sender, EventArgs e)
		{
			FuncionGlobal.marca_check(gr_dato);
		}

		protected void gr_dato_SelectedIndexChanged(object sender, EventArgs e) { }

		protected void Button1_Click(object sender, EventArgs e)
		{
			add_usuario_sucursal();
			//FuncionGlobal.alerta("SUCURSALES ACTUALIZADAS CON EXITO", Page);
			UpdatePanel pnl = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
			FuncionGlobal.alerta_updatepanel("SUCURSALES ACTUALIZADAS CON EXITO", this.Page, pnl);
			getsucursales();
		}

		protected void dl_modulo_SelectedIndexChanged(object sender, EventArgs e)
		{
			getsucursales();
		}

		private void getsucursales()
		{
			List<SucursalCliente> lsucursal = new SucursalclienteBC().getUsuarioSucursal(Convert.ToInt16(this.dl_modulo.SelectedValue), cuenta_usuario);
			this.gr_dato.DataSource = lsucursal;
			this.gr_dato.DataBind();
		}

		private void add_usuario_sucursal()
		{
			GridViewRow row;
			for (int i = 0; i < gr_dato.Rows.Count; i++)
			{
				row = gr_dato.Rows[i];
				CheckBox chk = (CheckBox)gr_dato.Rows[i].FindControl("chk");
                CheckBox chk2 = (CheckBox)gr_dato.Rows[i].FindControl("chk2");
				CheckBox chksup2 = (CheckBox)gr_dato.Rows[i].FindControl("chksup2");
				Int16 id_sucursal = Convert.ToInt16(this.gr_dato.Rows[i].Cells[0].Text);
				if (chk.Checked == true)
				{

					int add = new UsuarioBC().add_usuario_sucursal(cuenta_usuario, id_sucursal,chk2.Checked,chksup2.Checked);
				}
				else
				{
                    int del = new UsuarioBC().del_usuario_sucursal(cuenta_usuario, id_sucursal, chk2.Checked,chksup2.Checked);
				}
			}
		}

		protected void dl_cliente_SelectedIndexChanged(object sender, EventArgs e)
		{
			FuncionGlobal.combomodulobyusuario(this.dl_modulo, cuenta_usuario, Convert.ToInt16(this.dl_cliente.SelectedValue));
		}
	}
}