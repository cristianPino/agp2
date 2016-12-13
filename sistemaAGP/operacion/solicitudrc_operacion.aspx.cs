using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CENTIDAD;
using CNEGOCIO;

namespace sistemaAGP
{
	public partial class solicitudrc_operacion : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				this.lblOperacion.Text = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_solicitud"].ToString());
				FuncionGlobal.comboregion(this.ddlRegion, "CH");
				FuncionGlobal.comboOficinaRC(this.ddlOficina, Convert.ToInt32(this.ddlRegion.SelectedValue));
				FuncionGlobal.comboTipoSolicitudRC(this.ddlTipoSolicitud, Request.QueryString["tipo"].ToString());
				this.txtFechaSolicitud.Text = DateTime.Now.ToShortDateString();
				limpiar();
				getSolicitudes();
			}
		}

		protected void getSolicitudes()
		{
			DataTable dt = new DataTable();
			dt.Columns.Add("fecha");
			dt.Columns.Add("tipo");
			dt.Columns.Add("oficina");
			dt.Columns.Add("numero");
			dt.Columns.Add("anio");
			dt.Columns.Add("estado");
			dt.Columns.Add("obs");
			List<SolicitudRC> lsolic = new SolicitudRCBC().get_SolicitudRC_Operacion(Convert.ToInt32(this.lblOperacion.Text));
			foreach (SolicitudRC msolic in lsolic)
			{
				DataRow dr = dt.NewRow();
				dr["fecha"] = msolic.Fecha_solicitud.ToShortDateString();
				dr["tipo"] = "";
				dr["oficina"] = msolic.Oficina_rc.Descripcion_oficina_rc;
				dr["numero"] = msolic.Nro_solicitud;
				dr["anio"] = msolic.Anio_solicitud.ToString();
				dr["estado"] = msolic.Estado_solicitud;
				dr["obs"] = msolic.Obs_solicitud;
				dt.Rows.Add(dr);
			}
			this.grdSolicitudes.DataSource = dt;
			this.grdSolicitudes.DataBind();
		}

		protected void limpiar()
		{
			this.ddlTipoSolicitud.SelectedValue = "0";
			this.ddlRegion.SelectedValue = "0";
			FuncionGlobal.comboOficinaRC(this.ddlOficina, Convert.ToInt32(this.ddlRegion.SelectedValue));
			this.txtNroSolicitud.Text = "";
			this.txtFechaSolicitud.Text = DateTime.Now.ToShortDateString();
			this.txtPatente.Text = "";

			DatosVehiculo veh = new DatosvehiculoBC().getDatovehiculo(Convert.ToInt32(this.lblOperacion.Text));
			this.txtPatente.Text = veh.Patente.Trim().ToUpper();
			this.txtPatente.Enabled = false;
			veh = null;
		}

		protected void btnGuardar_Click(object sender, EventArgs e)
		{
			DateTime fecha = Convert.ToDateTime(this.txtFechaSolicitud.Text);
			string add = new SolicitudRCBC().add_SolicitudRC(0, Convert.ToInt32(this.lblOperacion.Text), Convert.ToInt32(this.ddlTipoSolicitud.SelectedValue), Convert.ToInt32(this.ddlOficina.SelectedValue), Convert.ToInt32(this.txtNroSolicitud.Text), fecha.Year, "INGRESADA", "", fecha);
			UpdatePanel up = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
			FuncionGlobal.alerta_updatepanel("Solicitud guardada con exito", Page, up);
			getSolicitudes();
		}

		protected void ddlRegion_SelectedIndexChanged(object sender, EventArgs e)
		{
			FuncionGlobal.comboOficinaRC(this.ddlOficina, Convert.ToInt32(this.ddlRegion.SelectedValue));
		}

		protected void btnLimpiar_Click(object sender, EventArgs e)
		{
			limpiar();
		}

		protected void txtCodigoBarra_TextChanged(object sender, EventArgs e)
		{
			if (this.txtCodigoBarra.Text.Trim().Length >= 12)
			{
				FuncionGlobal.BuscarValueCombo(this.ddlOficina, Convert.ToInt32(this.txtCodigoBarra.Text.Substring(2, 3)).ToString());
				this.txtNroSolicitud.Text = this.txtCodigoBarra.Text.Substring(5, 6);
			}
		}
	}
}