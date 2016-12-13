using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CNEGOCIO;
using CENTIDAD;

namespace sistemaAGP
{
	public partial class gastooperacionperu : System.Web.UI.Page
	{
		private string id_solicitud;

		protected void Page_Load(object sender, EventArgs e)
		{
			id_solicitud = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_solicitud"].ToString());
			this.lbl_operacion.Text = id_solicitud;
			if (!IsPostBack)
			{
				getGasto();
			}
		}

		protected void Total_general()
		{
			double subtotal = FuncionGlobal.suma_textogrilla_double(gr_dato, "txt_valor_gasto");
			double igv = subtotal * 0.18;
			double total = subtotal + igv;
			this.lbl_subtotal.Text = string.Format("{0:C2}", subtotal);
			this.lbl_igv.Text = string.Format("{0:C2}", igv);
			this.lbl_total.Text = string.Format("{0:C2}", total);
			this.lbl_cargo_empresa.Text = string.Format("{0:C2}", FuncionGlobal.suma_textogrilla_double(gr_dato, "txt_cargo_empresa"));
			this.lbl_cargo_cliente.Text = string.Format("{0:C2}", FuncionGlobal.suma_textogrilla_double(gr_dato, "txt_cargo_cliente"));
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

		protected void txt_cantidad_Leave(object sender, EventArgs e)
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
			DataColumn colll = new DataColumn("bloqueo");
			col.DataType = System.Type.GetType("System.Boolean");
			coll.DataType = System.Type.GetType("System.Boolean");
			colll.DataType = System.Type.GetType("System.Boolean");

			dt.Columns.Add(col);
			dt.Columns.Add(coll);
			dt.Columns.Add(colll);

			List<GastoOperacionPeru> lgasto = new GastoOperacionPeruBC().GetGastoOperacion(Convert.ToInt32(id_solicitud));

			if (lgasto.Count > 0)
			{
				this.bt_guardar.Visible = true;
			}

			foreach (GastoOperacionPeru mgasto in lgasto)
			{
				DataRow dr = dt.NewRow();
				dr["checkgc"] = mgasto.Tipogasto.Check;
				dr["id_tipogasto"] = mgasto.Tipogasto.Id_tipogasto;
				dr["descripcion"] = mgasto.Tipogasto.Descripcion;
				dr["valor"] = string.Format("{0:N2}", mgasto.Monto);
				dr["check"] = mgasto.Check;
				dr["cargo_cliente"] = string.Format("{0:N2}", mgasto.Cargo_cliente);
				dr["cargo_empresa"] = string.Format("{0:N2}", mgasto.Cargo_empresa);
				dr["bloqueo"] = mgasto.Bloqueo;
				dt.Rows.Add(dr);
			}
			this.gr_dato.DataSource = dt;
			this.gr_dato.DataBind();
			Total_general();
		}

		protected void bt_guardar_Click(object sender, EventArgs e)
		{
			UpdatePanel up = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
			if ((Convert.ToDouble(this.lbl_cargo_cliente.Text.Replace("S/.", "")) + Convert.ToDouble(this.lbl_cargo_empresa.Text.Replace("S/.", ""))) != Convert.ToDouble(this.lbl_subtotal.Text.Replace("S/.", "")))
			{
				FuncionGlobal.alerta_updatepanel("Existe diferencia entre los montos", Page, up);
			}
			else
			{
				add_gastos();
				FuncionGlobal.alerta_updatepanel("Gastos ingresados con éxito", Page, up);
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
					double montogasto = Convert.ToDouble(txt.Text.ToString());
					double cargo_cliente = Convert.ToDouble(txt_ccliente.Text.ToString());
					double cargo_empresa = Convert.ToDouble(txt_cempresa.Text.ToString());
					string add = new GastoOperacionPeruBC().AddGastoOperacion(Convert.ToInt32(id_solicitud), Convert.ToInt16(id_tipogasto), montogasto, (string)(Session["usrname"]), cargo_cliente, cargo_empresa, chkgc);

				}
				else
				{
                    string add = new GastooperacionBC().del_gastooperacion(Convert.ToInt32(id_solicitud), Convert.ToInt16(id_tipogasto), chkgc, (string)(Session["usrname"]));
				}
			}
		}

		protected void bt_cerrar_Click(object sender, EventArgs e)
		{
			ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "cerrar", "self.close();", true);
		}

		protected void bt_comprobante_Click(object sender, EventArgs e) { }

		protected void gr_dato_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				try
				{
					if (Convert.ToBoolean(this.gr_dato.DataKeys[e.Row.RowIndex].Values["bloqueo"]))
					{
						((TextBox)e.Row.FindControl("txt_valor_gasto")).Enabled = false;
						((TextBox)e.Row.FindControl("txt_cargo_cliente")).Enabled = false;
						((TextBox)e.Row.FindControl("txt_cargo_empresa")).Enabled = false;
					}
				}
				catch
				{
				}
			}
		}
	}
}