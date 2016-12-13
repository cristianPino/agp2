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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Web;



namespace sistemaAGP.administracion
{



	public partial class mReglaEstadofamilia : System.Web.UI.Page
	{


		
		Int16 id_familia;
		Int16 id_estado;
		
		protected void Page_Load(object sender, EventArgs e)
		{

			
			string id_estado_str;
			id_estado_str = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["codigo_estado"].ToString());
			id_estado = Convert.ToInt16(id_estado_str);

			string id_familia_str;
			id_familia_str = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_familia"].ToString());
			id_familia = Convert.ToInt16(id_familia_str);

            string nombre_familia = (Request.QueryString["nombre_familia"].ToString());

			if (!IsPostBack)
			{

                this.lbl_familia.Text = nombre_familia.Trim();
                this.lbl_estado.Text = new EstadotipooperacionBC().getestadobycodigoestado(id_estado).Descripcion.Trim();       
                
                getestado();
			}


		}

		private void getestado()
		{

			List<AlertaestadoFamilia> lEstadotipooperacion = new AlertaestadoFamiliaBC().getRegla_EstadoFamilia(id_familia, id_estado);


			DataTable dt = new DataTable();
			dt.Columns.Add("id_alerta");
			dt.Columns.Add("codigo");
			dt.Columns.Add("descripcion");
			DataColumn col = new DataColumn("chekalert");
			col.DataType = System.Type.GetType("System.Boolean");
			//dt.Columns.Add(new DataColumn("chk2"));
			dt.Columns.Add(col);

			foreach (AlertaestadoFamilia estadotipo in lEstadotipooperacion)
			{
				DataRow dr = dt.NewRow();


				dr["id_alerta"] = estadotipo.Estado_alerta;
				dr["codigo"] = estadotipo.Estado_alerta.Codigo_estado;
				dr["descripcion"] = estadotipo.Descripcion;
				dr["chekalert"] = estadotipo.Cheked;
				dt.Rows.Add(dr);

			}


			this.gr_dato.DataSource = dt;
			this.gr_dato.DataBind();

		}

		protected void gr_dato_SelectedIndexChanged(object sender, EventArgs e)
		{


		}

		protected void Button1_Click(object sender, EventArgs e)
		{


			add_usuario_tipo_operacion();




		}




		private void add_usuario_tipo_operacion()
		{

			GridViewRow row;

			for (int i = 0; i < gr_dato.Rows.Count; i++)
			{

				row = gr_dato.Rows[i];
				CheckBox chk = (CheckBox)gr_dato.Rows[i].FindControl("chk2");

				string codigo = gr_dato.DataKeys[i].Values[0].ToString();
			//	string regla = gr_dato.DataKeys[i].Values[1].ToString();

				string codigo2 = this.gr_dato.Rows[i].Cells[0].Text;

				if (chk.Checked == true)
				{

					string add = new AlertaestadoFamiliaBC().add_regla_estado_familia(Convert.ToInt16(id_estado), Convert.ToInt16(codigo));

				}
				else
				{
					string add = new AlertaestadoFamiliaBC().del_regla_estado_familia(Convert.ToInt16(id_estado), Convert.ToInt16(codigo));
				}

			}


		}

	}
}