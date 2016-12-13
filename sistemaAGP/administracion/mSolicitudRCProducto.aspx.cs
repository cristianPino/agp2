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
	public partial class mSolicitudRCProducto : System.Web.UI.Page {
		private string codigo;

		protected void Page_Load(object sender, EventArgs e) {
			codigo = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["codigo"].ToString());
			if (!IsPostBack) {
				cargar_tipos_solicitudes();
			}
		}

		protected void Check_Clicked(Object sender, EventArgs e) {
			FuncionGlobal.marca_check(gr_dato);
		}

		protected void cargar_tipos_solicitudes() {
			List<TipoSolicitudRCProducto> lSolic = new TipoSolicitudRCBC().getTipoSolicitudRC_by_TipoOperacion(codigo);
			this.gr_dato.DataSource = lSolic;
			this.gr_dato.DataBind();
		}

		public void add_tipo_solicitud_producto() {
		    for (int i = 0; i < gr_dato.Rows.Count; i++) {
				Int32 id = Convert.ToInt32(gr_dato.Rows[i].Cells[0].Text);
				CheckBox chk = (CheckBox)gr_dato.Rows[i].FindControl("chk");
				if (chk.Checked == true) {
					if (Convert.ToInt32(gr_dato.DataKeys[i].Values[0]) == 0) {
						string add = new TipoSolicitudRCProductoBC().addTipoSolicitudRC_TipoOperacion(codigo, id);
					}
				} else {
					if (Convert.ToInt32(gr_dato.DataKeys[i].Values[0]) != 0) {
						string add = new TipoSolicitudRCProductoBC().delTipoSolicitudRC_TipoOperacion(Convert.ToInt32(gr_dato.DataKeys[i].Values[0]));
					}
				}
			}
			cargar_tipos_solicitudes();
		}

		protected void btnGuardar_Click(object sender, EventArgs e) {
			add_tipo_solicitud_producto();
		}
	}
}