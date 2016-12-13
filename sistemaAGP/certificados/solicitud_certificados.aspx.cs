using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CENTIDAD;
using CNEGOCIO;

namespace sistemaAGP.certificados
{
	public partial class solicitud_certificados : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				ViewState["id_solicitud"] = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_solicitud"].ToString());
				ViewState["id_cliente"] = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_cliente"].ToString());
				ViewState["tipo_operacion"] = Request.QueryString["tipo_operacion"].ToString();

				this.Cambiar_Titulo();

				FuncionGlobal.comboclientesbyusuario((string)(Session["usrname"]), this.dl_cliente);
				this.dl_cliente.SelectedValue = ViewState["id_cliente"].ToString();
				this.dl_cliente.Enabled = false;
				FuncionGlobal.combosucursalbyclienteandUsuario(this.dl_sucursal, Convert.ToInt16(this.dl_cliente.SelectedValue), (string)(Session["usrname"]));

				if (this.dl_sucursal.Items.Count == 2)
				{
					this.dl_sucursal.SelectedIndex = 1;
				}

				this.Busca_Operacion();
			}
		}

		protected void bt_guardar_Click(object sender, EventArgs e)
		{
			this.Add_Operacion();
		}

		protected void bt_limpiar_Click(object sender, EventArgs e)
		{
			Page.Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);
		}

		protected void txt_patente_TextChanged(object sender, EventArgs e)
		{
			if (this.txt_patente.Text.Trim() != "")
			{
				if (FuncionGlobal.formatoPatente(this.txt_patente.Text))
					this.txt_dv.Text = FuncionGlobal.digitoVerificadorPatente(this.txt_patente.Text);
				else
					this.txt_dv.Text = "";
			}
		}

		protected void Add_Operacion()
		{
            int add = new OperacionBC().add_operacion(Convert.ToInt32(ViewState["id_solicitud"]), Convert.ToInt16(ViewState["id_cliente"]), ViewState["tipo_operacion"].ToString(), (string)(Session["usrname"]), 0, "", Convert.ToInt32(this.dl_sucursal.SelectedValue),0);

			ViewState["id_solicitud"] = add.ToString();

			if (add != 0)
			{
				string output = new SolicitudCertificadoBC().add_solicitud_certificado(add, Convert.ToInt16(this.dl_sucursal.SelectedValue), this.txt_patente.Text.Trim().ToUpper());
				//Si hay un error guardando la operación
				if (output != "")
				{
					ScriptManager.RegisterStartupScript(this.up_operacion, this.up_operacion.GetType(), "alert_add_garantia", string.Format("alert('{0}');", output), true);
					return;
				}

				string add_or = new EstadooperacionBC().add_estado_orden(Convert.ToInt32(add), 1, ViewState["tipo_operacion"].ToString(), "", (string)(Session["usrname"]));

				this.lbl_operacion.Visible = true;
				this.lbl_numero.Visible = true;

				this.lbl_numero.Text = add.ToString("N0");
			}
		}

		protected void Busca_Operacion()
		{
			SolicitudCertificado solicitud = new SolicitudCertificadoBC().get_solicitud_certificado(Convert.ToInt32(ViewState["id_solicitud"].ToString()));
			if (solicitud != null)
			{
				this.dl_sucursal.SelectedValue = solicitud.Sucursal.Id_sucursal.ToString();
				this.txt_patente.Text = solicitud.Patente.ToUpper().Trim();
				this.txt_patente.Enabled = false;
				this.txt_dv.Text = FuncionGlobal.digitoVerificadorPatente(this.txt_patente.Text);

				this.lbl_operacion.Visible = true;
				this.lbl_numero.Visible = true;

				this.lbl_numero.Text = solicitud.Operacion.Id_solicitud.ToString("N0");
			}
		}

		protected void Cambiar_Titulo()
		{
			this.lbl_titulo.Text = new TipooperacionBC().getTipooperacion(ViewState["tipo_operacion"].ToString()).Operacion;
		}
	}
}