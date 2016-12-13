using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CNEGOCIO;
using CENTIDAD;
using System.Data;

namespace sistemaAGP.administracion {
	public partial class mEstadosRC : System.Web.UI.Page {
		protected void Page_Load(object sender, EventArgs e) {
			if (!IsPostBack) {
				limpiar();
				cargarTipoSolicitudRC();
			}
		}

		protected void cargarTipoSolicitudRC() {
			DataTable dt = new DataTable();
			dt.Columns.Add("codigo");
			dt.Columns.Add("descripcion");
			dt.Columns.Add("correos");
			List<TipoSolicitudRC> lSolic = new TipoSolicitudRCBC().getTipoSolicitudRC();
			foreach (TipoSolicitudRC mSolic in lSolic) {
				DataRow dr = dt.NewRow();
				dr["codigo"] = mSolic.CodSolicRC;
				dr["descripcion"] = mSolic.DescSolicRC;
				dr["correos"] = mSolic.ListaCorreos;
				dt.Rows.Add(dr);
			}
			gr_dato.DataSource = dt;
			gr_dato.DataBind();
		}

		protected void btnGuardar_Click(object sender, EventArgs e) {
			guardar();
		}

		protected void btnLimpiar_Click(object sender, EventArgs e) {
			limpiar();
		}

		protected void gr_dato_SelectedIndexChanged(object sender, EventArgs e) { }

		protected void gr_dato_RowCommand(object sender, GridViewCommandEventArgs e) {
			if (e.CommandName == "Select") {
				GridViewRow row = gr_dato.Rows[Convert.ToInt32(e.CommandArgument)];
				this.lblCodigo.Text = row.Cells[0].Text;
				this.txtDescripcion.Text = Server.HtmlDecode(row.Cells[1].Text);
				this.txtCorreos.Text = Server.HtmlDecode(row.Cells[2].Text);
			}
		}

		protected void limpiar() {
			this.lblCodigo.Text = "0";
			this.txtDescripcion.Text = "";
			this.txtCorreos.Text = "";
		}

		protected void guardar() {
			if (txtDescripcion.Text.Trim() == "") { FuncionGlobal.alerta("Debe ingresar el texto para la solicitud", this.Page); return; }
			string s = new TipoSolicitudRCBC().addTipoSolicitudRC(Convert.ToInt32(this.lblCodigo.Text), this.txtDescripcion.Text.Trim(), this.txtCorreos.Text.Trim());
			FuncionGlobal.alerta("DATOS GUARDADOS SATISFACTORIAMENTE", this.Page);
			limpiar();
			cargarTipoSolicitudRC();
		}
	}
}