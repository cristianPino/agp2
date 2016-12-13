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
	public partial class Gastomovimientocuenta : System.Web.UI.Page
	{
		private string id_solicitud;
		private string tipo_movimiento;

		protected void Page_Load(object sender, EventArgs e)
		{
			id_solicitud = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_solicitud"].ToString());
			tipo_movimiento = Request.QueryString["tipo"].ToString();
			this.lbl_operacion.Text = id_solicitud;
			this.lbl_tipo.Text = tipo_movimiento;
			if (!IsPostBack)
			{
				FuncionGlobal.combobanco(dl_financiera,1);
				FuncionGlobal.comboparametro(this.dl_tipo_operacion, "FMO");

                this.dl_financiera.SelectedValue = "SANT";
                FuncionGlobal.combocuenta(this.dl_financiera.SelectedValue, this.dl_cuenta);
                this.dl_cuenta.SelectedValue = "13";
				getGasto();
			}
		}

		protected void Total_general()
		{
			this.lbl_total.Text = Convert.ToString(FuncionGlobal.suma_textogrilla(gr_dato, "txt_valor_gasto"));
		}

		protected void txt_valor_gasto_Leave(object sender, EventArgs e)
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
		
		public void getGasto()
		{
			DataTable dt = new DataTable();

			dt.Columns.Add(new DataColumn("id_tipogasto"));
			dt.Columns.Add(new DataColumn("descripcion"));
			dt.Columns.Add(new DataColumn("valor"));

			DataColumn coll = new DataColumn("checkgc");
			DataColumn col = new DataColumn("check");
			col.DataType = System.Type.GetType("System.Boolean");
			coll.DataType = System.Type.GetType("System.Boolean");

			dt.Columns.Add(col);
			dt.Columns.Add(coll);

			List<GastoOperacion> lgasto = new GastooperacionBC().Getgastooperacionmov(Convert.ToInt32(id_solicitud), tipo_movimiento);
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

				dt.Rows.Add(dr);
			}

			this.gr_dato.DataSource = dt;
			this.gr_dato.DataBind();

			Total_general();
			getMovimiento();
		}

		public void getMovimiento()
		{
			DataTable dt = new DataTable();

			dt.Columns.Add(new DataColumn("id_movimiento_cuenta"));
			dt.Columns.Add(new DataColumn("descripcion"));
			dt.Columns.Add(new DataColumn("monto"));
			dt.Columns.Add(new DataColumn("banco"));
			dt.Columns.Add(new DataColumn("cuenta"));
			dt.Columns.Add(new DataColumn("tipo_operacion"));
			dt.Columns.Add(new DataColumn("numero_documento"));
			dt.Columns.Add(new DataColumn("fecha_movimiento"));
			dt.Columns.Add(new DataColumn("documento_especial"));
			dt.Columns.Add(new DataColumn("usuario"));

			DataColumn col = new DataColumn("check");
			DataColumn coll = new DataColumn("chkgc");
			col.DataType = System.Type.GetType("System.Boolean");
			dt.Columns.Add(col);
			coll.DataType = System.Type.GetType("System.Boolean");
			dt.Columns.Add(coll);
			
			List<MovimientoCuenta> lcuenta = new MovimientocuentaBC().getMovimientocuenta(Convert.ToInt32(id_solicitud), tipo_movimiento);

			if (lcuenta.Count > 0)
				this.bt_Eliminar.Visible = true;
			else
				this.bt_Eliminar.Visible = false;

			foreach (MovimientoCuenta mcuenta in lcuenta)
			{
				DataRow dr = dt.NewRow();
				dr["id_movimiento_cuenta"] = mcuenta.Id_movimiento_cuenta;
				dr["descripcion"] = mcuenta.Tipo_gasto.Descripcion;
				dr["monto"] = mcuenta.Monto;
				dr["banco"] = mcuenta.Cuenta_banco.Banco.Nombre;
				dr["cuenta"] = mcuenta.Cuenta_banco.Numero_cuenta;
				dr["tipo_operacion"] = mcuenta.Tipo_operacion;
				dr["numero_documento"] = mcuenta.Numero_documento;
				dr["fecha_movimiento"] = mcuenta.Fecha_movimiento;
				dr["documento_especial"] = mcuenta.Documento_especial;
				dr["usuario"] = mcuenta.Usuario.Nombre;
				dr["chkgc"] = mcuenta.Tipo_gasto.Check;
				dr["check"] = false;
				dt.Rows.Add(dr);
			}
			this.gr_movimiento.DataSource = dt;
			this.gr_movimiento.DataBind();
		}
		
		protected void bt_guardar_Click(object sender, EventArgs e)
		{
              EstadoOperacion mesta = new EstadooperacionBC().getEstadobyorden(Convert.ToInt32(id_solicitud), 88);
              if (mesta.Permite_estado == true)
              {


                  if (this.txt_especial.Text != "")
                  {
                      add_gastos();
                      FuncionGlobal.alerta("MOVIMIENTO INGRESADO CON EXITO", Page);
                      getGasto();
                  }
                  else
                  {
                      FuncionGlobal.alerta("Es requerido el Documento Especial para realizar el Pago Masivo", this.Page);
                      return;
                  }
              }
              else
              {
                  FuncionGlobal.alerta("No se puede realizar Pago por no estar entregado a Cobranza", this.Page);
              }
		
			
		}

		protected void bt_eliminar_Click(object sender, EventArgs e)
		{
            

			del_movimiento();
			FuncionGlobal.alerta("MOVIMIENTO ACTUALIZADO CON EXITO", Page);
			getGasto();
		}

		private void add_gastos()
		{
			GridViewRow row;
			for (int i = 0; i < gr_dato.Rows.Count; i++)
			{
				row = gr_dato.Rows[i];
				CheckBox chk = (CheckBox)gr_dato.Rows[i].FindControl("chk");
				string id_tipogasto = this.gr_dato.Rows[i].Cells[1].Text;
				if (chk.Checked == true)
				{
					TextBox txt = (TextBox)gr_dato.Rows[i].FindControl("txt_valor_gasto");
					Int32 montogasto = Convert.ToInt32(txt.Text.ToString());
					string chkgc = ((CheckBox)gr_dato.Rows[i].FindControl("chkgc")).Checked.ToString();
					string add = new MovimientocuentaBC().add_movimiento_cuenta(Convert.ToInt32(id_solicitud), Convert.ToInt16(this.dl_cuenta.SelectedValue), Convert.ToInt16(id_tipogasto), (string)(Session["usrname"]), this.txt_numero_documento.Text, tipo_movimiento, this.dl_tipo_operacion.SelectedValue, this.txt_especial.Text, montogasto, chkgc);
				}
			}
		}
		
		private void del_movimiento()
		{
			GridViewRow row;
			for (int i = 0; i < gr_movimiento.Rows.Count; i++)
			{
				row = gr_movimiento.Rows[i];
				CheckBox chk = (CheckBox)gr_movimiento.Rows[i].FindControl("chk");
				string id_movimiento = this.gr_movimiento.Rows[i].Cells[1].Text;
				string chkgc = ((CheckBox)gr_movimiento.Rows[i].FindControl("chkgc")).Checked.ToString();
				string add;
				if (chk.Checked == true)
					add = new MovimientocuentaBC().del_movimiento_cuenta(Convert.ToInt32(id_movimiento), chkgc);
			}
		}

		protected void dl_financiera_SelectedIndexChanged(object sender, EventArgs e)
		{
			FuncionGlobal.combocuenta(this.dl_financiera.SelectedValue, this.dl_cuenta);
            this.dl_cuenta.SelectedValue = "13";
		}

        protected void gr_dato_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
	}
}
