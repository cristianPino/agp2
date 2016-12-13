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
using CNEGOCIO;
using CENTIDAD;
using System.Collections.Generic;

namespace sistemaAGP
{
	public partial class mWorkflow : System.Web.UI.Page
	{
		private string id_solicitud;

		protected void Page_Load(object sender, EventArgs e)
		{
			id_solicitud = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_solicitud"].ToString());
			if (!IsPostBack)
			{
				getestadowork();
			}
		}

		protected void getestadowork()
		{
			List<EstadoOperacion> lEstadooperacion = new EstadooperacionBC().getEstadoByoperacion(Convert.ToInt32(id_solicitud), (string)(Session["usrname"]));
			DataTable dt = new DataTable();
			dt.Columns.Add(new DataColumn("estado"));
			dt.Columns.Add(new DataColumn("fecha"));
			dt.Columns.Add(new DataColumn("cuenta_usuario"));
			dt.Columns.Add(new DataColumn("nombre_usuario"));
			dt.Columns.Add(new DataColumn("observacion"));
            dt.Columns.Add(new DataColumn("contador"));
            dt.Columns.Add(new DataColumn("semaforo"));

			foreach (EstadoOperacion mestadooperacion in lEstadooperacion)
			{
				DataRow dr = dt.NewRow();
				dr["estado"] = mestadooperacion.Estado_operacion.Descripcion;
				dr["fecha"] = mestadooperacion.Fecha_hora;
				dr["cuenta_usuario"] = mestadooperacion.Usuario.UserName;
				dr["nombre_usuario"] = mestadooperacion.Usuario.Nombre;
				dr["observacion"] = mestadooperacion.Observacion;
                dr["semaforo"] = mestadooperacion.Semaforo.Trim();
                dr["contador"] = mestadooperacion.Contador.ToString().Trim() ;

				dt.Rows.Add(dr);
			}
			this.gr_dato.DataSource = dt;
			this.gr_dato.DataBind();
		}

        protected void gr_dato_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
	}
}