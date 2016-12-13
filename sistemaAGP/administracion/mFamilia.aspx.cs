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

namespace sistemaAGP
{
	public partial class mFamilia : System.Web.UI.Page
	{



		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				
				getfamilia();
			}
		}

		private void getfamilia()
		{
			DataTable dt = new DataTable();
			dt.Columns.Add(new DataColumn("id_familia"));
			dt.Columns.Add(new DataColumn("Descripcion"));
			dt.Columns.Add(new DataColumn("url_Estado"));
			dt.Columns.Add(new DataColumn("url_Gasto"));
			dt.Columns.Add(new DataColumn("url_Nomina"));
			dt.Columns.Add(new DataColumn("url_Operacion"));
			dt.Columns.Add(new DataColumn("url_operaciongastos"));
			

			List<Familia_Producto> lfamilia = new Familia_productoBC().getallFamilia_producto();
			foreach (Familia_Producto mfamilia in lfamilia)
			{
				DataRow dr = dt.NewRow();

				dr["id_familia"] = mfamilia.Id_familia;
				dr["Descripcion"] = mfamilia.Descripcion;
				dr["url_Estado"] = "mestado.aspx?id=" + FuncionGlobal.FuctionEncriptar(mfamilia.Id_familia.ToString().Trim()) + "&nombre_familia=" + (mfamilia.Descripcion.Trim()) ;
				dr["url_Gasto"] = "../operacion/mGastosComunes.aspx?id=" + FuncionGlobal.FuctionEncriptar(mfamilia.Id_familia.ToString().Trim());
				dr["url_Nomina"] = "mTiponomina.aspx?id=" + FuncionGlobal.FuctionEncriptar(mfamilia.Id_familia.ToString().Trim());
				dr["url_Operacion"] = "mproducto.aspx?id=" + FuncionGlobal.FuctionEncriptar(mfamilia.Id_familia.ToString().Trim());
				dr["url_operaciongastos"] = "mproductoTipogasto.aspx?id=" + FuncionGlobal.FuctionEncriptar(mfamilia.Id_familia.ToString().Trim());
				
				dt.Rows.Add(dr);
			}

			this.gr_dato.DataSource = dt;
			this.gr_dato.DataBind();
		}

		protected void txt_rut_Leave(object sender, EventArgs e)
		{
			
		}

		private void busca_persona(double rut)
		{
			Persona mpersona = new PersonaBC().getpersonabyrut(rut);
			if (mpersona.Rut == Convert.ToDouble(0))
			{
				FuncionGlobal.alerta("RUT NO EXISTE COMO PERSONA EN EL SISTEMA", this.Page);
				return;
			}
			
		}

		private void add_familia()
		{
			
		}

		protected void Button1_Click(object sender, EventArgs e)
		{
			add_familia();
		}

		protected void Button2_Click(object sender, EventArgs e) { }

		protected void txt_rut_TextChanged(object sender, EventArgs e) { }

		protected void gr_dato_SelectedIndexChanged(object sender, EventArgs e) { }

		protected void gr_dato_SelectedIndexChanged1(object sender, EventArgs e)
		{

		}
	}
}


