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
	public partial class mGastosComunes : System.Web.UI.Page
	{

		Int16 id_fam;



		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{


				string id_fam_encrip;

				id_fam_encrip = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id"].ToString());

				id_fam = Convert.ToInt16(id_fam_encrip);

				
				
				this.getAllGastosComunes();
			}
		}

		protected void dl_familia_SelectedIndexChanged(object sender, EventArgs e)
		{
			
		}

		protected void getAllGastosComunes()
		{
			DataTable dt = new DataTable();

			dt.Columns.Add(new DataColumn("id_gasto"));
			dt.Columns.Add(new DataColumn("descripcion"));
			dt.Columns.Add(new DataColumn("valor"));
			dt.Columns.Add(new DataColumn("pdecta"));
			dt.Columns.Add(new DataColumn("proveedor"));
			dt.Columns.Add(new DataColumn("ctafac"));
			DataColumn col = new DataColumn("cargo_contable");
			col.DataType = System.Type.GetType("System.Boolean");
			DataColumn col1 = new DataColumn("Transferencia");
			

			col1.DataType = System.Type.GetType("System.Boolean");
			DataColumn col2 = new DataColumn("bloqueada");
			col2.DataType = System.Type.GetType("System.Boolean");
			DataColumn col3 = new DataColumn("Factura");
			col3.DataType = System.Type.GetType("System.Boolean");
			DataColumn col4 = new DataColumn("opcional");
			col4.DataType = System.Type.GetType("System.Boolean");
			dt.Columns.Add(col);
			dt.Columns.Add(col1);
			dt.Columns.Add(col2);
			dt.Columns.Add(col3);
			dt.Columns.Add(col4);
			

			List<GastosComunes> lgastos = new GastosComunesBC().getallGastosComunes(id_fam);
			foreach (GastosComunes mgastos in lgastos)
			{
				DataRow dr = dt.NewRow();


				dr["id_gasto"] = mgastos.Id_tipogasto;
				dr["descripcion"] = mgastos.Descripcion;
				dr["valor"] = mgastos.Valor;
				dr["cargo_contable"] = Convert.ToBoolean(mgastos.Cargo_contable);


				dr["bloqueada"] = Convert.ToBoolean(mgastos.Bloqueo);
				dr["opcional"] = Convert.ToBoolean(mgastos.Opcional);
				dr["Factura"] = Convert.ToBoolean(mgastos.Factura);

				dr["Transferencia"] = Convert.ToBoolean(mgastos.Transferencia);

                if (mgastos.Plandecuenta != null)
                {
                    dr["pdecta"] = mgastos.Plandecuenta.Cuenta.Trim();
                }
                else
                {
                    dr["pdecta"] = "";
                }

				if (mgastos.Cuenta_facturacion != null)
				{
					dr["ctafac"] = mgastos.Cuenta_facturacion.Trim();
				}
				else
				{
					dr["ctafac"] = "";
				}


                dr["proveedor"] = mgastos.Proveedor;
				
				
				dt.Rows.Add(dr);


			}


			this.gr_dato.DataSource = dt;
			this.gr_dato.DataBind();


		}

		protected void gr_dato_RowEditing(object sender, GridViewEditEventArgs e)
		{
			
		}

		protected void gr_dato_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
		{
			
		}

		protected void gr_dato_RowUpdating(object sender, GridViewUpdateEventArgs e)
		{
			
		}

		protected void btn_guardar_Click(object sender, EventArgs e)
		{
			
		}

		protected void btn_nuevo_Click(object sender, ImageClickEventArgs e)
		{
			

			
		}

		protected void gr_dato_SelectedIndexChanged(object sender, EventArgs e)
		{


		}

		protected void presionado(object sender, EventArgs e)
		{
			GridViewRow row;

			string id_fam_encrip;

			id_fam_encrip = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id"].ToString());

			id_fam = Convert.ToInt16(id_fam_encrip);


			string add_MU = "";

			for (int i = 0; i < gr_dato.Rows.Count; i++)
			{

				row = gr_dato.Rows[i];
				string id_estado = gr_dato.Rows[i].Cells[0].Text;
				//string Descripcion = gr_dato.Rows[i].Cells[1].Text;
				TextBox descripcion = (TextBox)gr_dato.Rows[i].FindControl("descripcion");
				string valor = gr_dato.Rows[i].Cells[2].Text;
				CheckBox chk_cargocont = (CheckBox)gr_dato.Rows[i].FindControl("cargo_contable");
				CheckBox chk_transferencia = (CheckBox)gr_dato.Rows[i].FindControl("transferencia");
				//CheckBox chk_ctafac = (CheckBox)gr_dato.Rows[i].FindControl("ctafac");
				CheckBox chk_bloqueo = (CheckBox)gr_dato.Rows[i].FindControl("bloqueada");
				CheckBox chk_factura = (CheckBox)gr_dato.Rows[i].FindControl("Factura");
				CheckBox chk_opcional = (CheckBox)gr_dato.Rows[i].FindControl("opcional");
				TextBox plandecta = (TextBox)gr_dato.Rows[i].FindControl("pdecta");
				TextBox cctafac = (TextBox)gr_dato.Rows[i].FindControl("ctafac");
				TextBox proveedor = (TextBox)gr_dato.Rows[i].FindControl("proveedor");
				
				Int16 estado = Convert.ToInt16(id_estado);
				string ccargocont = chk_cargocont.Checked.ToString();
				string ctransferencia = chk_transferencia.Checked.ToString();
				string cbloqueo = chk_bloqueo.Checked.ToString();
				string cfactura = chk_factura.Checked.ToString();
				string copcional = chk_opcional.Checked.ToString();


				string descr = descripcion.Text.ToString();
				string pland = plandecta.Text.ToString();
				string provee = proveedor.Text.ToString();
				string ctafac = cctafac.Text.ToString();

				add_MU = new GastosComunesBC().add_GastosComunes(Convert.ToInt16(id_estado), Convert.ToInt32(valor), descr, ccargocont, ctransferencia, cbloqueo, id_fam, pland, provee, cfactura, copcional, ctafac);


			}

		}

		protected void grabar(object sender, EventArgs e)
		{
			string id_fam_encrip;

			id_fam_encrip = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id"].ToString());

			id_fam = Convert.ToInt16(id_fam_encrip);

			string add_MU = "";


			string descripcion = this.TextBox1.Text;
			string plandecuenta = this.TextBox2.Text;
			string proveedor = this.TextBox4.Text;
			string cvalor = this.TextBox3.Text;
			string ctafac = this.TextBox4.Text;
			string ccontable = this.chk_aviso.Checked.ToString();
			string ctransf = this.CheckBox1.Checked.ToString();
			string cbloqueada = this.CheckBox3.Checked.ToString();
			string factura = this.CheckBox2.Checked.ToString();
			string opcional = this.CheckBox4.Checked.ToString();
			

			add_MU = new GastosComunesBC().add_GastosComunes(0, Convert.ToInt32(cvalor), descripcion, ccontable, ctransf, cbloqueada, id_fam, plandecuenta, proveedor, factura,opcional,ctafac);


			getAllGastosComunes();
		}
	}
}