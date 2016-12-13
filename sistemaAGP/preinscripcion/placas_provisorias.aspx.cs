using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CENTIDAD;
using CNEGOCIO;

namespace sistemaAGP.preinscripcion
{
	public partial class placas_provisorias : System.Web.UI.Page
    {
        public int IdOrdenTrabajo = 0;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				ViewState["id_solicitud"] = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_solicitud"].ToString());
				ViewState["id_cliente"] = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_cliente"].ToString());
				ViewState["tipo_operacion"] = Request.QueryString["tipo_operacion"].ToString();
                IdOrdenTrabajo = Convert.ToInt32(FuncionGlobal.FuctionDesEncriptar(Request.QueryString["idOrdenTrabajo"]));
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
                hdIdOrdenTrabajo.Value = "0";
                if (IdOrdenTrabajo == 0) return;
                hdIdOrdenTrabajo.Value = IdOrdenTrabajo.ToString(CultureInfo.InvariantCulture);
                var otra = new OrdenTrabajoBC().GetOrdenTrabajo(IdOrdenTrabajo);
                BuscaOrdenTrabajo(otra);
                agp_adquirente.Mostrar_Form(Convert.ToInt32(otra.RutAdquiriente));
			}
		}

		protected void bt_guardar_Click(object sender, EventArgs e)
		{
			this.Add_Operacion();
		}

        public void BuscaOrdenTrabajo(CENTIDAD.OrdenTrabajo otra)
        {  
            dl_sucursal.SelectedValue = otra.IdSucursal.ToString(CultureInfo.InvariantCulture);
          
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
				{
					this.txt_dv.Text = FuncionGlobal.digitoVerificadorPatente(this.txt_patente.Text);
					this.Busca_Operacion_Por_Patente();
				}
				else{
					this.txt_dv.Text = "";
				}
			}
		}

		protected void Add_Operacion()
		{
			if (!this.agp_adquirente.Guardar_Form())
			{
				ScriptManager.RegisterStartupScript(this.up_operacion, this.up_operacion.GetType(), "alert_adquirente", string.Format("alert('{0}');", this.agp_adquirente.MensajeError), true);
				return;
			}

            int add = new OperacionBC().add_operacion(Convert.ToInt32(ViewState["id_solicitud"]), Convert.ToInt16(ViewState["id_cliente"]), ViewState["tipo_operacion"].ToString(), (string)(Session["usrname"]), 0, "", Convert.ToInt32(this.dl_sucursal.SelectedValue),0);

			ViewState["id_solicitud"] = add.ToString();

			if (add != 0)
			{
				string output = new SolicitudPlacasProvisoriasBC().add_solicitud_placas_provisorias(add, Convert.ToInt16(this.dl_sucursal.SelectedValue), this.txt_patente.Text.Trim().ToUpper(), this.agp_adquirente.Rut);
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
                if (hdIdOrdenTrabajo.Value.Trim() != "0") { FuncionGlobal.UpdateTipoOperacionOrdenTrabajo(ViewState["tipo_operacion"].ToString(), Convert.ToInt32(hdIdOrdenTrabajo.Value), add); }
			}
		}

		protected void Busca_Operacion()
		{
			SolicitudPlacasProvisorias solicitud = new SolicitudPlacasProvisoriasBC().get_solicitud_placas_provisorias(Convert.ToInt32(ViewState["id_solicitud"].ToString()));
			if (solicitud != null)
			{
				this.Carga_Operacion(solicitud);
			}
		}

		protected void Busca_Operacion_Por_Patente()
		{
			SolicitudPlacasProvisorias solicitud = new SolicitudPlacasProvisoriasBC().get_solicitud_placas_provisorias(this.txt_patente.Text);
			if (solicitud != null)
			{
				this.Carga_Operacion(solicitud);
			}
		}

		protected void Cambiar_Titulo()
		{
			this.lbl_titulo.Text = new TipooperacionBC().getTipooperacion(ViewState["tipo_operacion"].ToString()).Operacion;
		}

		protected void Carga_Operacion(SolicitudPlacasProvisorias solicitud)
		{
			this.dl_sucursal.SelectedValue = solicitud.Sucursal.Id_sucursal.ToString();
			this.txt_patente.Text = solicitud.Patente.ToUpper().Trim();
			this.txt_patente.Enabled = false;
			this.txt_dv.Text = FuncionGlobal.digitoVerificadorPatente(this.txt_patente.Text);

			this.lbl_operacion.Visible = true;
			this.lbl_numero.Visible = true;

			this.lbl_numero.Text = solicitud.Operacion.Id_solicitud.ToString("N0");

			this.agp_adquirente.Rut = solicitud.Adquirente.Rut;
			this.agp_adquirente.Mostrar_Form(solicitud.Adquirente.Rut);
		}
	}
}