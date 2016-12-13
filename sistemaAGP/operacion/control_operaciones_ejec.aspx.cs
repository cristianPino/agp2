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


namespace sistemaAGP {
	public partial class control_operaciones_ejec : System.Web.UI.Page {
		protected void Page_Load(object sender, EventArgs e) {
			if (!IsPostBack) {
				this.txt_desde.Text = DateTime.Today.ToShortDateString();
				this.txt_hasta.Text = DateTime.Today.ToShortDateString();
				FuncionGlobal.comboclientesbyusuario((string)(Session["usrname"]), this.dl_cliente);
				FuncionGlobal.combotipooperacion(this.dl_producto);
				//carga el combo con los tipos de nómina
				getnomina(dpl_nomina);
			}
		}

		

		protected void Click_Gasto(Object sender, EventArgs e) {
			busca_operacion();
		}

		protected void dl_cliente_SelectedIndexChanged(object sender, EventArgs e) {
			FuncionGlobal.combomodulo(dl_modulo, Convert.ToInt16(this.dl_cliente.SelectedValue));
			FuncionGlobal.combosucursalbycliente(this.dl_sucursal, Convert.ToInt16(this.dl_cliente.SelectedValue));
		}
        protected void Check_Clicked(Object sender, EventArgs e)
        {
            FuncionGlobal.marca_check(gr_dato);
          
        }

		protected void ib_buscar_Click(object sender, ImageClickEventArgs e) {
			busca_operacion();
			if (this.dl_cliente.SelectedValue != "0" && this.dl_producto.SelectedValue != "0") {
				this.chk_nomina.Visible = true;
			} else {
				this.chk_nomina.Visible = false;
			}
		}

		private void busca_operacion() {
			double rut;
			Int32 factura;
			Int32 noperacion;
			Int32 estado_actual;
			Int16 dl_modulo;
			Int16 dl_sucursal;

			if (this.txt_rut.Text.Trim() == "") { rut = 0; } else { rut = Convert.ToDouble(this.txt_rut.Text); }

			if (this.txt_operacion.Text.Trim() == "") { noperacion = 0; } else { noperacion = Convert.ToInt32(this.txt_operacion.Text); }

			if (this.txt_factura.Text.Trim() == "") { factura = 0; } else { factura = Convert.ToInt32(this.txt_factura.Text); }
			
			if (this.dpl_estado.SelectedValue == "") { estado_actual = 0; } else { estado_actual = Convert.ToInt32(this.dpl_estado.SelectedValue); }

			if (this.dl_modulo.SelectedValue == "") { dl_modulo = 0; } else { dl_modulo = Convert.ToInt16(this.dl_modulo.SelectedValue); }

			if (this.dl_sucursal.SelectedValue == "") { dl_sucursal = 0; } else { dl_sucursal = Convert.ToInt16(this.dl_sucursal.SelectedValue); }

			List<Operacion> loperacion = new OperacionBC().getOperaciones(this.dl_producto.SelectedValue,
																   dl_modulo,
																   dl_sucursal,
																   Convert.ToInt16(this.dl_cliente.SelectedValue), noperacion, rut,
																   factura, this.txt_cliente.Text.Trim(),
																   this.txt_patente.Text.Trim(),
																   string.Format("{0:yyyyMMdd}", Convert.ToDateTime(this.txt_desde.Text.Trim())),
																   string.Format("{0:yyyyMMdd}", Convert.ToDateTime(this.txt_hasta.Text.Trim())),
																   estado_actual, (string)(Session["usrname"]), 0, "TODO",0,"","",0);

			DataTable dt = new DataTable();
			dt.Columns.Add(new DataColumn("id_solicitud"));
			dt.Columns.Add(new DataColumn("cliente"));
			dt.Columns.Add(new DataColumn("nombre_cliente"));
			dt.Columns.Add(new DataColumn("tipo_operacion"));
			dt.Columns.Add(new DataColumn("operacion"));
			dt.Columns.Add(new DataColumn("numero_factura"));
			dt.Columns.Add(new DataColumn("patente"));
			dt.Columns.Add(new DataColumn("numero_cliente"));
			dt.Columns.Add(new DataColumn("rut_persona"));
			dt.Columns.Add(new DataColumn("nombre_persona"));
			dt.Columns.Add(new DataColumn("total_gasto"));
			dt.Columns.Add(new DataColumn("total_egreso"));
			dt.Columns.Add(new DataColumn("total_ingreso"));
			dt.Columns.Add(new DataColumn("total_devolucion"));
			dt.Columns.Add(new DataColumn("saldo"));
			dt.Columns.Add(new DataColumn("ultimo_estado"));

		
			foreach (Operacion moperacion in loperacion) {
				DataRow dr = dt.NewRow();
				dr["id_solicitud"] = moperacion.Id_solicitud;
				dr["cliente"] = moperacion.Cliente.Id_cliente;
				dr["nombre_cliente"] = moperacion.Cliente.Persona.Nombre;

                if (moperacion.Numero_factura != 0)
				dr["numero_factura"] = moperacion.Numero_factura;
                else
                    dr["numero_factura"] = "";
				dr["patente"] = moperacion.Patente;
				dr["numero_cliente"] = moperacion.Numero_cliente;
				if (moperacion.Adquiriente != null) {
					dr["rut_persona"] = moperacion.Adquiriente.Rut;
					dr["nombre_persona"] = moperacion.Adquiriente.Nombre + " " + moperacion.Adquiriente.Apellido_paterno + " " + moperacion.Adquiriente.Apellido_materno;
				} else {
					dr["rut_persona"] = "0";
					dr["nombre_persona"] = "Sin Adquiriente";
				}
				dr["tipo_operacion"] = moperacion.Tipo_operacion.Codigo.Trim();
				dr["operacion"] = moperacion.Tipo_operacion.Operacion.ToString();
				dr["total_gasto"] = moperacion.Total_gasto;
				dr["total_egreso"] = moperacion.Total_egreso;
				dr["total_ingreso"] = moperacion.Total_ingreso;
				dr["total_devolucion"] = moperacion.Total_devolucion;
				dr["saldo"] = (moperacion.Total_ingreso - moperacion.Total_egreso);
				dr["ultimo_estado"] = moperacion.Estado;
				dt.Rows.Add(dr);
			}

			this.gr_dato.DataSource = dt;
			this.gr_dato.DataBind();

			Carga_Link();

			getnomina(this.dl_nomina);
		}

		protected void Carga_Link() {
			int i;
			GridViewRow row;
			HyperLink but;
			ImageButton ibuton;
			Button buton;
			string nombre;

			for (i = 0; i < gr_dato.Rows.Count; i++) {
				row = gr_dato.Rows[i];
				if (row.RowType == DataControlRowType.DataRow) {
					string tipo = gr_dato.DataKeys[i].Values[0].ToString();
					int cont = gr_dato.DataKeys.Count;
					Int16 id_cliente = Convert.ToInt16(gr_dato.DataKeys[i].Values[1].ToString());
					nombre = (string)row.Cells[4].Text;
					but = (HyperLink)row.Cells[0].Controls[0];
					TipoOperacion op = new TipooperacionBC().getTipooperacion(tipo);
					but.Attributes.Add("onclick", "javascript:window.showModalDialog('" + op.Url_operacion + FuncionGlobal.FuctionEncriptar(but.Text.Trim()) + "&id_cliente=" + FuncionGlobal.FuctionEncriptar(id_cliente.ToString()) + "','_blank','dialogheight=450px;dialogWidth=730px, top=0,left=0,status=no,toolbar=no,menubar=no,location=no,scrollbars=no,resizable=yes,copyhistory= false')");
					
					ibuton = (ImageButton)row.FindControl("ib_estado");
					ibuton.Attributes.Add("onclick", "javascript:window.showModalDialog('mOperacion_estado.aspx?tipo=" + FuncionGlobal.FuctionEncriptar(tipo) + "&id_cliente=" + FuncionGlobal.FuctionEncriptar(id_cliente.ToString()) + "&id_solicitud=" + FuncionGlobal.FuctionEncriptar(but.Text.Trim()) + "&nombre_estado=" + nombre + "','','status:false;dialogWidth:500px;dialogHeight:260px')");
					
					ibuton = (ImageButton)row.FindControl("ib_gasto");
					ibuton.Attributes.Add("onclick", "javascript:window.showModalDialog('gastooperacion.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(but.Text.Trim()) + "','','status:false;dialogWidth:500px;dialogHeight:400px')");

                    //ibuton = (ImageButton)row.FindControl("ib_egreso");
                    //ibuton.Attributes.Add("onclick", "javascript:window.showModalDialog('gastomovimientocuenta.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(but.Text.Trim()) + "&tipo=E" + "','','status:false;dialogWidth:700px;dialogHeight:400px')");

                    //ibuton = (ImageButton)row.FindControl("ib_ingreso");
                    //ibuton.Attributes.Add("onclick", "javascript:window.showModalDialog('gastomovimientocuenta.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(but.Text.Trim()) + "&tipo=I" + "','','status:false;dialogWidth:700px;dialogHeight:400px')");

                    //ibuton = (ImageButton)row.FindControl("ib_devolucion");
                    //ibuton.Attributes.Add("onclick", "javascript:window.showModalDialog('gastomovimientocuenta.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(but.Text.Trim()) + "&tipo=D" + "','','status:false;dialogWidth:700px;dialogHeight:400px')");

					ibuton = (ImageButton)row.FindControl("ib_nomina");
					ibuton.Attributes.Add("onclick", "javascript:window.showModalDialog('nominabyoperacion.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(but.Text.Trim()) + "','','status:false;dialogWidth:700px;dialogHeight:400px')");

					ibuton = (ImageButton)row.FindControl("ib_cargar");
					ibuton.Attributes.Add("onclick", "javascript:window.showModalDialog('../digitalizacion/subir_documentos.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(but.Text.Trim()) + "&tipo=" + tipo + "','','status:false;dialogWidth:700px;dialogHeight:400px')");

					ibuton = (ImageButton)row.FindControl("ib_cdigital");
					ibuton.Attributes.Add("onclick", "javascript:window.open('../digitalizacion/ver_documentos.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(but.Text.Trim()) + "&origen=pc','_blank','height=600,width=800,location=0,menubar=0,titlebar=1,toolbar=0,resizable=1,scrollbars=1')");

					ibuton = (ImageButton)row.FindControl("ib_comGastos");
					ibuton.Attributes.Add("onclick", "javascript:window.open('../reportes/view_comprobante_cobro.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(but.Text.Trim()) + "','_blank','height=355,width=500, top=150,left=150,status=no,toolbar=no,menubar=no,l ocation=no,scrollbars=no,resizable=yes,copyhistory= false')");

					buton = (Button)row.FindControl("bt_eliminar");
					buton.Attributes.Add("onclick", "return confirmarEliminar();");
				}
			}
		}

		protected void dl_producto_SelectedIndexChanged(object sender, EventArgs e) { }

		protected void Check_Clicked_Grilla(Object sender, EventArgs e) {
		
		}

		
		protected void gr_dato_SelectedIndexChanged(object sender, EventArgs e) { }


		protected void dl_modulo_SelectedIndexChanged(object sender, EventArgs e) { }


		protected void dl_estado_SelectedIndexChanged(object sender, EventArgs e) {	}

		private void getestado(string tipo, DropDownList combo) {
			EstadoTipoOperacion mEstadotipooperacion = new EstadoTipoOperacion();

			mEstadotipooperacion.Codigo = "0";
			mEstadotipooperacion.Descripcion = "Seleccionar";

			List<EstadoTipoOperacion> lEstadotipooperacion = new EstadotipooperacionBC().getEstadoByTipooperacion(tipo);

			lEstadotipooperacion.Add(mEstadotipooperacion);

			combo.DataSource = lEstadotipooperacion;
			combo.DataValueField = "codigo_estado";
			combo.DataTextField = "descripcion";
			combo.DataBind();
			combo.SelectedValue = "0";

			return;
		}

		protected void txt_obs_TextChanged(object sender, EventArgs e) { }

		protected void Button1_Click(object sender, EventArgs e) {
			GridViewRow row;
			HyperLink but;

			for (int i = 0; i < gr_dato.Rows.Count; i++) {
				row = gr_dato.Rows[i];
				CheckBox chk = (CheckBox)gr_dato.Rows[i].FindControl("chk");

				but = (HyperLink)row.Cells[0].Controls[0];
				string id_solicitud = but.Text.Trim();

				if (chk.Checked == true) {
					string add = new EstadooperacionBC().add_Estadooperacion(Convert.ToInt32(id_solicitud), Convert.ToInt32(this.dl_estado.SelectedValue), this.txt_obs.Text, (string)(Session["usrname"]));
				}
			}

			FuncionGlobal.alerta_updatepanel("ESTADO DE TRABAJO ACTUALIZADO CON EXITO", this.Page, this.UpdatePanel3);
			this.chk_workflow.Checked = false;
			busca_operacion();
		}

		protected void dl_producto_SelectedIndexChanged1(object sender, EventArgs e) {
			if (this.dl_producto.SelectedValue != "0") {
				this.chk_workflow.Visible = true;
				getestado(this.dl_producto.SelectedValue, this.dl_estado);
			} else {
				this.chk_workflow.Visible = false;
			}
			
			if (this.dl_producto.SelectedValue != "0") {
				this.lbl_flujo.Visible = true;
				this.dpl_estado.Visible = true;
				getestado(this.dl_producto.SelectedValue, this.dpl_estado);
			} else {
				this.lbl_flujo.Visible = false;
				this.dpl_estado.Visible = false;
			}
		}

		protected void Button2_Click(object sender, EventArgs e) {
			ExportToSpreadsheet();
		}

		private void ExportToSpreadsheet() {
			double rut;
			Int32 factura;
			Int32 noperacion;
			Int32 estado_actual;

			if (this.txt_rut.Text.Trim() == "") { rut = 0; } else { rut = Convert.ToDouble(this.txt_rut.Text); }

			if (this.txt_operacion.Text.Trim() == "") { noperacion = 0; } else { noperacion = Convert.ToInt32(this.txt_operacion.Text); }

			if (this.txt_factura.Text.Trim() == "") { factura = 0; } else { factura = Convert.ToInt32(this.txt_factura.Text); }

			if (this.dpl_estado.SelectedValue == "") { estado_actual = 0; } else { estado_actual = Convert.ToInt32(this.dpl_estado.SelectedValue); }

			List<Operacion> loperacion = new OperacionBC().getOperaciones(this.dl_producto.SelectedValue,
															   0,
															   0,
																Convert.ToInt16(this.dl_cliente.SelectedValue), noperacion, rut
																, factura, this.txt_cliente.Text.Trim(),
																this.txt_patente.Text.Trim(),
																string.Format("{0:yyyyMMdd}", Convert.ToDateTime(this.txt_desde.Text.Trim())),
																string.Format("{0:yyyyMMdd}", Convert.ToDateTime(this.txt_hasta.Text.Trim())),
																estado_actual, (string)(Session["usrname"]),0,"TODO",0,"","",0);

			DataTable dt = new DataTable();
			dt.Columns.Add(new DataColumn("id_solicitud"));
			dt.Columns.Add(new DataColumn("cliente"));
			dt.Columns.Add(new DataColumn("tipo_operacion"));
			dt.Columns.Add(new DataColumn("operacion"));
			dt.Columns.Add(new DataColumn("numero_factura"));
			dt.Columns.Add(new DataColumn("patente"));
			dt.Columns.Add(new DataColumn("numero_cliente"));
			dt.Columns.Add(new DataColumn("rut_persona"));
			dt.Columns.Add(new DataColumn("nombre_persona"));
			dt.Columns.Add(new DataColumn("total_gasto"));
			dt.Columns.Add(new DataColumn("total_egreso"));
			dt.Columns.Add(new DataColumn("total_ingreso"));
			dt.Columns.Add(new DataColumn("saldo"));
			dt.Columns.Add(new DataColumn("ultimo_estado"));

			
			foreach (Operacion moperacion in loperacion) {
				DataRow dr = dt.NewRow();

				dr["id_solicitud"] = moperacion.Id_solicitud;
				dr["cliente"] = moperacion.Cliente.Id_cliente;
				dr["numero_factura"] = moperacion.Numero_factura;
				dr["patente"] = moperacion.Patente;
				dr["numero_cliente"] = moperacion.Numero_cliente;

				if (moperacion.Adquiriente != null) {
					dr["rut_persona"] = moperacion.Adquiriente.Rut;
					dr["nombre_persona"] = moperacion.Adquiriente.Nombre + " " + moperacion.Adquiriente.Apellido_paterno + " " + moperacion.Adquiriente.Apellido_materno;
				} else {
					dr["rut_persona"] = "0";
					dr["nombre_persona"] = "Sin Adquiriente";
				}

				dr["tipo_operacion"] = moperacion.Tipo_operacion.Codigo.Trim();
				dr["operacion"] = moperacion.Tipo_operacion.Operacion.ToString();
				dr["total_gasto"] = moperacion.Total_gasto;
				dr["total_egreso"] = moperacion.Total_egreso;
				dr["total_ingreso"] = moperacion.Total_ingreso;
				dr["saldo"] = (moperacion.Total_ingreso - moperacion.Total_egreso);
				dr["ultimo_estado"] = moperacion.Estado;
				dt.Rows.Add(dr);
			}

			HttpContext context = HttpContext.Current;

			context.Response.Clear();

			foreach (DataColumn column in dt.Columns) {
				context.Response.Write(column.ColumnName + ";");
			}

			context.Response.Write(Environment.NewLine);
			foreach (DataRow row in dt.Rows) {
				for (int i = 0; i < dt.Columns.Count; i++) {
					context.Response.Write(row[i].ToString().Replace(";", string.Empty) + ";");
				}
				context.Response.Write(Environment.NewLine);
			}
			context.Response.ContentType = "text/csv";
			context.Response.AppendHeader("Content-Disposition", "attachment; filename=" + "informe" + ".csv");
			context.Response.End();
		}

		protected void CheckBox1_CheckedChanged(object sender, EventArgs e) {
			if (chk_workflow.Checked == true) {				
				this.chk_nomina.Checked = false;
				this.Panel3.Visible = false;
				if (this.Panel2.Visible == true) { this.Panel2.Visible = false; } else { this.Panel2.Visible = true; }
			} else { this.Panel2.Visible = false; }
		}

		

		protected void dl_nomina_SelectedIndexChanged(object sender, EventArgs e) { }

		private void getnomina(DropDownList combo) {
			TipoNomina mTiponomina = new TipoNomina();

			mTiponomina.Id_nomina = 0;
			mTiponomina.Descripcion = "Seleccionar";

			List<TipoNomina> lTiponomina = new TipoNominaBC().getTiponomina();

			lTiponomina.Add(mTiponomina);

			combo.DataSource = lTiponomina;
			combo.DataValueField = "id_nomina";
			combo.DataTextField = "descripcion";
			combo.DataBind();
			combo.SelectedValue = "0";

			return;
		}

		protected void chk_nomina_CheckedChanged(object sender, EventArgs e) {
			if (chk_nomina.Checked == true) {
				this.chk_workflow.Checked = false;
				this.Panel2.Visible = false;
				if (this.Panel3.Visible == true) { this.Panel2.Visible = false; } else { this.Panel3.Visible = true; }
			} else { this.Panel3.Visible = false; }
		}

		protected void Button3_Click(object sender, EventArgs e) {
			if (Convert.ToInt32(this.dl_nomina.SelectedValue) > 0) {
				GridViewRow row;
				HyperLink but;

				Int32 folio = traerfolio(Convert.ToInt32(this.dl_nomina.SelectedValue));

				for (int i = 0; i < gr_dato.Rows.Count; i++) {
					row = gr_dato.Rows[i];
					CheckBox chk = (CheckBox)gr_dato.Rows[i].FindControl("chk");

					but = (HyperLink)row.Cells[0].Controls[0];
					string id_solicitud = but.Text.Trim();

					if (chk.Checked == true) {
						string add = new TipoNominaBC().add_tiponominaByOperacion(Convert.ToInt32(id_solicitud), Convert.ToInt32(this.dl_nomina.SelectedValue), folio, Session["usrname"].ToString());
					}
				}

				string upd = new TipoNominaBC().upd_FolioNomina(Convert.ToInt32(this.dl_nomina.SelectedValue));

				FuncionGlobal.alerta_updatepanel(string.Format("NOMINA Nº{0} GUARDADA CON EXITO", folio), this.Page, this.UpdatePanel4);

				this.chk_nomina.Checked = false;
				busca_operacion();
			} else {
				FuncionGlobal.alerta_updatepanel("Debe selecionar un tipo de nomina", this.Page, this.UpdatePanel4);
			}

			return;
		}

		public Int32 traerfolio(Int32 id_nomina) {
			TipoNomina lTiponomina = new TipoNominaBC().getTiponominaBytipo(id_nomina);
			Int32 folio = Convert.ToInt32(lTiponomina.Folio);
			return folio;
		}

		protected void btn_nomina_pdf_Click(object sender, ImageClickEventArgs e) {
			ver_reporte_nomina();
		}

		protected void ver_reporte_nomina() {
			Int32 id_nomina;
			Int32 folio;

			id_nomina = Convert.ToInt32(this.dpl_nomina.SelectedValue);
			if (!Int32.TryParse(this.txt_nomina.Text, out folio)) { folio = 0; }

			if (id_nomina != 0 && folio != 0) {
				string reporte;
				reporte = "infNomina.rpt";

				ReportDocument rpt = new ReportDocument();

				rpt.Load(Server.MapPath("../reportes/" + reporte));

				rpt.SetParameterValue(0, null);
				rpt.SetParameterValue(1, null);
				rpt.SetParameterValue(2, null);
				rpt.SetParameterValue(3, null);
				rpt.SetParameterValue(4, null);
				rpt.SetParameterValue(5, null);
				rpt.SetParameterValue(6, null);
				rpt.SetParameterValue(7, null);
				rpt.SetParameterValue(8, null);
				rpt.SetParameterValue(9, null);
				rpt.SetParameterValue(10, null);
				rpt.SetParameterValue(11, null);
				rpt.SetParameterValue(12, (string)(Session["usrname"]));
				rpt.SetParameterValue(13, folio);
				rpt.SetParameterValue(14, id_nomina);

				Session.Add("documento", rpt);
				Session.Add("nombre_rpt", reporte);
				//Page.RegisterClientScriptBlock("ViewNomina", "<script type='text/javascript'>window.open('../reportes/view_report_agp.aspx','_blank','height=355,width=500, top=150,left=150,status=no,toolbar=no,menubar=no,l ocation=no,scrollbars=no,resizable=yes,copyhistory= false')</script>");
				ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ViewNomina", "window.open('../reportes/view_report_agp.aspx','_blank','height=355,width=500, top=150,left=150,status=no,toolbar=no,menubar=no,l ocation=no,scrollbars=no,resizable=yes,copyhistory= false');", true);
			}
		}

		protected void txt_nomina_TextChanged(object sender, EventArgs e) { }

		protected void gr_dato_RowCommand(object sender, GridViewCommandEventArgs e) {
			if (e.CommandName == "eliminar") {
				string del = new OperacionBC().del_operacion(Convert.ToInt32(e.CommandArgument.ToString()),(string)(Session["usrname"]));
				busca_operacion();
			}
		}






	}
}