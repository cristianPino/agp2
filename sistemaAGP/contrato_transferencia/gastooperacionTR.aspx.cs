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
    public partial class gastooperacionTR : System.Web.UI.Page
	{
		private string id_solicitud;

		protected void Page_Load(object sender, EventArgs e)
		{
			//this.bt_comprobante.Attributes.Add("onclick", "javascript:window.open('../reportes/view_report_agp.aspx','_blank','height=355,width=500, top=150,left=150,status=no,toolbar=no,menubar=no,l ocation=no,scrollbars=no,resizable=yes,copyhistory= false')");
			//Session.Add("impresion", "S");
			id_solicitud = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_solicitud"].ToString());
			this.lbl_operacion.Text = id_solicitud;
			if (!IsPostBack)
			{
				getGasto();
			}
		}

		protected void Total_general()
		{
			this.lbl_total.Text = Convert.ToString(FuncionGlobal.suma_textogrilla(gr_dato, "txt_valor_gasto"));
			this.lbl_cargo_empresa.Text = Convert.ToString(FuncionGlobal.suma_textogrilla(gr_dato, "txt_cargo_empresa"));
			this.lbl_cargo_cliente.Text = Convert.ToString(FuncionGlobal.suma_textogrilla(gr_dato, "txt_cargo_cliente"));
		}

		protected void txt_valor_gasto_Leave(object sender, EventArgs e)
		{
			Total_general();
		}

		protected void txt_cargo_empresa_Leave(object sender, EventArgs e)
		{
			Total_general();
		}

		protected void txt_cargo_cliente_Leave(object sender, EventArgs e)
		{
			Total_general();
		}

		protected void Check_Clicked(Object sender, EventArgs e)
		{
			FuncionGlobal.marca_check(gr_dato);
			Total_general();
		}

		protected void Check_Grilla_Clicked(Object sender, EventArgs e)
		{
			Total_general();
		}

		protected void gr_dato_SelectedIndexChanged(object sender, EventArgs e) { }

		protected void gr_dato_RowEditing(object sender, GridViewEditEventArgs e)
		{
			gr_dato.EditIndex = e.NewEditIndex;
		}

		public void getGasto()
		{
			DataTable dt = new DataTable();
			dt.Columns.Add(new DataColumn("id_tipogasto"));
			dt.Columns.Add(new DataColumn("descripcion"));
			dt.Columns.Add(new DataColumn("valor"));
			dt.Columns.Add(new DataColumn("cargo_cliente"));
			dt.Columns.Add(new DataColumn("cargo_empresa"));
			DataColumn col = new DataColumn("check");
			DataColumn coll = new DataColumn("checkgc");
			col.DataType = System.Type.GetType("System.Boolean");
			coll.DataType = System.Type.GetType("System.Boolean");

			dt.Columns.Add(col);
			dt.Columns.Add(coll);

			List<GastoOperacion> lgasto = new GastooperacionBC().Getgastooperaciontr(Convert.ToInt32(id_solicitud));

			if (lgasto.Count > 0)
			{
				this.bt_guardar.Visible = true;
			}

			foreach (GastoOperacion mgasto in lgasto)
			{
				DataRow dr = dt.NewRow();

				dr["checkgc"] = mgasto.Tipogasto.Check;
				dr["id_tipogasto"] = mgasto.Tipogasto.Id_tipogasto;
				dr["descripcion"] = mgasto.Tipogasto.Descripcion;
				dr["valor"] = mgasto.Monto;
				dr["check"] = mgasto.Check;
				dr["cargo_cliente"] = mgasto.Cargo_cliente;
				dr["cargo_empresa"] = mgasto.Cargo_empresa;
				dt.Rows.Add(dr);
			}
			this.gr_dato.DataSource = dt;
			this.gr_dato.DataBind();
			Total_general();
		}

		protected void bt_guardar_Click(object sender, EventArgs e)
		{
			if ((Convert.ToInt32(this.lbl_cargo_cliente.Text) + Convert.ToInt32(this.lbl_cargo_empresa.Text)) != Convert.ToInt32(this.lbl_total.Text))
			{
				FuncionGlobal.alerta("EXISTEN DIFERENCIAS ENTRE LOS MONTOS", Page);
			}
			else
			{
				add_gastos();
				FuncionGlobal.alerta("GASTOS ACTUALIZADOS CON EXITO", Page);
			}
		}

		private void add_gastos()
		{
			GridViewRow row;
			for (int i = 0; i < gr_dato.Rows.Count; i++)
			{
				row = gr_dato.Rows[i];
				CheckBox chk = (CheckBox)gr_dato.Rows[i].FindControl("chk");
				string id_tipogasto = this.gr_dato.Rows[i].Cells[1].Text;
				string chkgc = ((CheckBox)gr_dato.Rows[i].FindControl("chkgc")).Checked.ToString();

				if (chk.Checked == true)
				{
					TextBox txt = (TextBox)gr_dato.Rows[i].FindControl("txt_valor_gasto");
					TextBox txt_ccliente = (TextBox)gr_dato.Rows[i].FindControl("txt_cargo_cliente");
					TextBox txt_cempresa = (TextBox)gr_dato.Rows[i].FindControl("txt_cargo_empresa");
					Int32 montogasto = Convert.ToInt32(txt.Text.ToString());
					Int32 cargo_cliente = Convert.ToInt32(txt_ccliente.Text.ToString());
					Int32 cargo_empresa = Convert.ToInt32(txt_cempresa.Text.ToString());
					string add = new GastooperacionBC().add_gastooperacion(Convert.ToInt32(id_solicitud), Convert.ToInt16(id_tipogasto), montogasto, (string)(Session["usrname"]), cargo_cliente, cargo_empresa, chkgc);

				}
				else
				{
                    string add = new GastooperacionBC().del_gastooperacion(Convert.ToInt32(id_solicitud), Convert.ToInt16(id_tipogasto), chkgc, (string)(Session["usrname"]));
				}
			}
		}

		protected void bt_cerrar_Click(object sender, EventArgs e)
		{
			Response.Write("<script>self.close();</script>");
		}

		protected void bt_comprobante_Click(object sender, EventArgs e) { }
	}
}