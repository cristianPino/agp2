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
	public partial class control_operaciones_peru : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				this.txt_desde.Text = DateTime.Today.ToShortDateString();
				this.txt_hasta.Text = DateTime.Today.ToShortDateString();
				this.Panel1.Visible = false;

				FuncionGlobal.combofamilia_producto(this.dl_familia);
				FuncionGlobal.comboclientesbyusuario((string)(Session["usrname"]), this.dl_cliente);
				FuncionGlobal.combotipooperacion(this.dl_producto);
				FuncionGlobal.combobanco(dl_financiera,1);
				FuncionGlobal.comboparametro(this.dl_tipo_operacion, "FMO");
				FuncionGlobal.comboparametro(this.dl_saldo, "TISO");
				//carga el combo con los tipos de nómina
				getnomina(dpl_nomina);
				crear_datatable();
			}
		}

		protected void crear_datatable()
		{
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
			dt.Columns.Add(new DataColumn("factura_emitida"));
			if (Session["dt"] == null)
				Session.Add("dt", dt);
			else
				Session["dt"] = dt;
		}

		protected void dl_financiera_SelectedIndexChanged(object sender, EventArgs e)
		{
			FuncionGlobal.combocuenta(this.dl_financiera.SelectedValue, this.dl_cuenta);
		}

		private void combotipogasto()
		{
			if (this.dl_cliente.SelectedValue == "0") { return; }
			if (this.dl_producto.SelectedValue == "0") { return; }
			GastosComunes mGastosComunes = new GastosComunes();
			mGastosComunes.Id_tipogasto = 0;
			mGastosComunes.Descripcion = "Seleccionar";
			List<GastosComunes> lGastosComunes = new GastosComunesBC().getallGastosComunes(Convert.ToInt32(this.dl_familia.SelectedValue));
			lGastosComunes.Add(mGastosComunes);

		}

		protected void Check_Clicked(Object sender, EventArgs e)
		{
			FuncionGlobal.marca_check(gr_dato);
			if (this.Panel1.Visible == false) { return; }
			//valida_movimiento();
			//total_movimiento();
			this.total_pago();
		}

		protected void dl_cliente_SelectedIndexChanged(object sender, EventArgs e)
		{
			FuncionGlobal.combomodulo(dl_modulo, Convert.ToInt16(this.dl_cliente.SelectedValue));
			FuncionGlobal.combosucursalbycliente(this.dl_sucursal, Convert.ToInt16(this.dl_cliente.SelectedValue));
		}

		protected void ib_buscar_Click(object sender, ImageClickEventArgs e)
		{
			busca_operacion();

		}

		private void busca_operacion()
		{
			if (this.dl_familia.SelectedValue == "0")
			{
				return;
			}

			string rut = "";
			string factura = "";
			Int32 noperacion = 0;
			Int32 estado_actual = 0;
			Int16 dl_modulo = 0;
			Int16 dl_sucursal = 0;
			Int16 dl_saldo = 0;
			string desde = string.Format("{0:yyyyMMdd}", Convert.ToDateTime(this.txt_desde.Text.Trim()));
			string hasta = string.Format("{0:yyyyMMdd}", Convert.ToDateTime(this.txt_hasta.Text.Trim()));
			string patente = this.txt_patente.Text.Trim();

			if (this.txt_rut.Text.Trim() != "") rut = this.txt_rut.Text;
			if (this.txt_operacion.Text.Trim() != "") noperacion = Convert.ToInt32(this.txt_operacion.Text);
			if (this.txt_factura.Text.Trim() != "") factura = this.txt_factura.Text;
			if (this.dpl_estado.SelectedValue != "") estado_actual = Convert.ToInt32(this.dpl_estado.SelectedValue);
			if (this.dl_modulo.SelectedValue != "") dl_modulo = Convert.ToInt16(this.dl_modulo.SelectedValue);
			if (this.dl_sucursal.SelectedValue != "") dl_sucursal = Convert.ToInt16(this.dl_sucursal.SelectedValue);
			if (this.dl_saldo.SelectedValue != "0") dl_saldo = Convert.ToInt16(this.dl_saldo.SelectedValue);

			if (noperacion == 0 && this.chk_agrupar.Checked == true)
			{ return; }


			this.txt_operacion.Text = "";
			this.txt_operacion.Focus();

			if (noperacion != 0 || factura != "" || patente != "")
			{
				desde = string.Format("{0:yyyyMMdd}", DateTime.MinValue);
				hasta = string.Format("{0:yyyyMMdd}", DateTime.MaxValue);
			}
			if (noperacion == 0 && this.chk_agrupar.Checked == false)
			{
				Session["dt"] = null;
				crear_datatable();
			}

			DataTable dt = (DataTable)Session["dt"];

			List<OperacionPeru> loperacion = new OperacionBC().getOperacionesPeru(this.dl_producto.SelectedValue, dl_modulo, dl_sucursal, Convert.ToInt16(this.dl_cliente.SelectedValue), noperacion, rut, factura, this.txt_cliente.Text.Trim(), patente, desde, hasta, estado_actual, (string)(Session["usrname"]), Convert.ToInt32(this.dl_familia.SelectedValue));
			//List<Operacion> loperacion = new OperacionBC().getOperaciones(this.dl_producto.SelectedValue, dl_modulo, dl_sucursal, Convert.ToInt16(this.dl_cliente.SelectedValue), noperacion, rut, factura, this.txt_cliente.Text.Trim(), patente, desde, hasta, estado_actual, (string)(Session["usrname"]), Convert.ToInt32(this.dl_familia.SelectedValue));
			if (dl_saldo == 1) //Pendiente de pago
			{
				var query = from o in loperacion
							where (o.Total_ingreso - o.Total_gasto != 0) && ((o.Total_ingreso > 0) || (o.Total_gasto > 0))
							select o;
				loperacion = query.ToList<OperacionPeru>();
			}
			else if (dl_saldo == 2) //Sin saldo pendiente
			{
				var query = from o in loperacion
							where (o.Total_ingreso - o.Total_gasto == 0) && ((o.Total_ingreso > 0) || (o.Total_gasto > 0))
							select o;
				loperacion = query.ToList<OperacionPeru>();
			}

			if (loperacion.Count != 0) { this.Panel1.Visible = false; } else { this.Panel1.Visible = false; }

			foreach (OperacionPeru moperacion in loperacion)
			{
				DataRow dr = dt.NewRow();
				dr["id_solicitud"] = moperacion.Id_solicitud;
				dr["cliente"] = moperacion.Cliente.Id_cliente;
				dr["nombre_cliente"] = moperacion.Cliente.Persona.Nombre;
				dr["numero_factura"] = moperacion.Numero_factura;
				dr["patente"] = moperacion.Patente;
				dr["numero_cliente"] = moperacion.Numero_cliente;
				if (moperacion.Adquiriente != null)
				{
					dr["rut_persona"] = moperacion.Adquiriente.TipoDocumentoIdentidad + " Nº " + moperacion.Adquiriente.NroDocumentoIdentidad;
					dr["nombre_persona"] = moperacion.Adquiriente.Nombres + " " + moperacion.Adquiriente.ApellidoPaterno + " " + moperacion.Adquiriente.ApellidoMaterno;
				}
				else
				{
					dr["rut_persona"] = "";
					dr["nombre_persona"] = "Sin Adquiriente";
				}
				dr["tipo_operacion"] = moperacion.Tipo_operacion.Codigo.Trim();
				dr["operacion"] = moperacion.Tipo_operacion.Operacion.ToString();
				dr["total_gasto"] = string.Format("{0:C2}", moperacion.Total_gasto * 1.18);
				dr["total_egreso"] = string.Format("{0:C2}", moperacion.Total_egreso);
				dr["total_ingreso"] = string.Format("{0:C2}", moperacion.Total_ingreso * 1.18);
				dr["total_devolucion"] = string.Format("{0:C2}", moperacion.Total_devolucion);
				dr["saldo"] = string.Format("{0:C2}", (moperacion.Total_ingreso * 1.18 - moperacion.Total_gasto * 1.18));
				dr["ultimo_estado"] = moperacion.Estado;
				dr["factura_emitida"] = moperacion.Factura_emitida;

				dt.Rows.Add(dr);
			}

			this.gr_dato.DataSource = dt;
			this.gr_dato.DataBind();

			getnomina(this.dl_nomina);
		}

		protected void total_pago()
		{
			double suma = 0;
			var query = from r in this.gr_dato.Rows.OfType<GridViewRow>()
						where ((CheckBox)r.FindControl("chk")).Checked == true && r.RowType == DataControlRowType.DataRow
						select Convert.ToDouble(r.Cells[19].Text.ToUpper().Replace("S/.","").Trim());
			foreach (double d in query)
			{
				suma += d;
			}
			this.lbl_total_gastos.Text = string.Format("{0:N2}", suma);
		}

		protected void Check_Clicked_Grilla(Object sender, EventArgs e)
		{
			total_pago();
		}

		protected void gr_dato_SelectedIndexChanged(object sender, EventArgs e) { }

		protected void bt_graba_movimiento_Click(object sender, EventArgs e)
		{
			this.add_pago_completo();
		}

		protected void dl_modulo_SelectedIndexChanged(object sender, EventArgs e) { }


		protected void dl_estado_SelectedIndexChanged(object sender, EventArgs e) { }

		private void getestado(string tipo, DropDownList combo)
		{
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

		protected void Button1_Click(object sender, EventArgs e)
		{
			GridViewRow row;
			HyperLink but;

			for (int i = 0; i < gr_dato.Rows.Count; i++)
			{
				row = gr_dato.Rows[i];
				CheckBox chk = (CheckBox)gr_dato.Rows[i].FindControl("chk");

				but = (HyperLink)row.Cells[0].Controls[0];
				string id_solicitud = but.Text.Trim();

				if (chk.Checked == true)
				{
					string add = new EstadooperacionBC().add_Estadooperacion(Convert.ToInt32(id_solicitud), Convert.ToInt32(this.dl_estado.SelectedValue), this.txt_obs.Text, (string)(Session["usrname"]));
				}
			}

			FuncionGlobal.alerta_updatepanel("ESTADO DE TRABAJO ACTUALIZADO CON EXITO", this.Page, this.UpdatePanel3);
			this.Panel2.Visible = false;
			busca_operacion();
		}

		protected void dl_producto_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.dl_producto.SelectedValue != "0")
			{
				getestado(this.dl_producto.SelectedValue, this.dl_estado);
			}

			if (this.dl_producto.SelectedValue != "0")
			{
				this.lbl_flujo.Visible = true;
				this.dpl_estado.Visible = true;
				getestado(this.dl_producto.SelectedValue, this.dpl_estado);
			}
			else
			{
				this.lbl_flujo.Visible = false;
				this.dpl_estado.Visible = false;
			}
		}

		protected void Button2_Click(object sender, EventArgs e)
		{
			ExportToSpreadsheet();
		}

		private void ExportToSpreadsheet()
		{
			double rut;
			Int32 factura;
			Int32 noperacion;
			Int32 estado_actual;

			if (this.txt_rut.Text.Trim() == "") { rut = 0; } else { rut = Convert.ToDouble(this.txt_rut.Text); }

			if (this.txt_operacion.Text.Trim() == "") { noperacion = 0; } else { noperacion = Convert.ToInt32(this.txt_operacion.Text); }

			if (this.txt_factura.Text.Trim() == "") { factura = 0; } else { factura = Convert.ToInt32(this.txt_factura.Text); }

			if (this.dpl_estado.SelectedValue == "") { estado_actual = 0; } else { estado_actual = Convert.ToInt32(this.dpl_estado.SelectedValue); }

			List<Operacion> loperacion = new OperacionBC().getOperaciones(this.dl_producto.SelectedValue, 0, 0, Convert.ToInt16(this.dl_cliente.SelectedValue), noperacion, rut, factura, this.txt_cliente.Text.Trim(), this.txt_patente.Text.Trim(), string.Format("{0:yyyyMMdd}", Convert.ToDateTime(this.txt_desde.Text.Trim())), string.Format("{0:yyyyMMdd}", Convert.ToDateTime(this.txt_hasta.Text.Trim())), estado_actual, (string)(Session["usrname"]), 0, "TODO",0,"","",0);
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

			if (loperacion.Count != 0) { this.Panel1.Visible = false; } else { this.Panel1.Visible = false; }

			foreach (Operacion moperacion in loperacion)
			{
				DataRow dr = dt.NewRow();

				dr["id_solicitud"] = moperacion.Id_solicitud;
				dr["cliente"] = moperacion.Cliente.Id_cliente;
				dr["numero_factura"] = moperacion.Numero_factura;
				dr["patente"] = moperacion.Patente;
				dr["numero_cliente"] = moperacion.Numero_cliente;

				if (moperacion.Adquiriente != null)
				{
					dr["rut_persona"] = moperacion.Adquiriente.Rut;
					dr["nombre_persona"] = moperacion.Adquiriente.Nombre + " " + moperacion.Adquiriente.Apellido_paterno + " " + moperacion.Adquiriente.Apellido_materno;
				}
				else
				{
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

			foreach (DataColumn column in dt.Columns)
			{
				context.Response.Write(column.ColumnName + ";");
			}

			context.Response.Write(Environment.NewLine);
			foreach (DataRow row in dt.Rows)
			{
				for (int i = 0; i < dt.Columns.Count; i++)
				{
					context.Response.Write(row[i].ToString().Replace(";", string.Empty) + ";");
				}
				context.Response.Write(Environment.NewLine);
			}
			context.Response.ContentType = "text/csv";
			context.Response.AppendHeader("Content-Disposition", "attachment; filename=" + "informe" + ".csv");
			context.Response.End();
		}



		protected void dl_nomina_SelectedIndexChanged(object sender, EventArgs e) { }

		private void getnomina(DropDownList combo)
		{
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


		protected void Button3_Click(object sender, EventArgs e)
		{
			if (Convert.ToInt32(this.dl_nomina.SelectedValue) > 0)
			{
				GridViewRow row;
				HyperLink but;

				Int32 folio = traerfolio(Convert.ToInt32(this.dl_nomina.SelectedValue));

				for (int i = 0; i < gr_dato.Rows.Count; i++)
				{
					row = gr_dato.Rows[i];
					CheckBox chk = (CheckBox)gr_dato.Rows[i].FindControl("chk");

					but = (HyperLink)row.Cells[0].Controls[0];
					string id_solicitud = but.Text.Trim();

					if (chk.Checked == true)
					{
						string add = new TipoNominaBC().add_tiponominaByOperacion(Convert.ToInt32(id_solicitud), Convert.ToInt32(this.dl_nomina.SelectedValue), folio, Session["usrname"].ToString());
					}
				}

				string upd = new TipoNominaBC().upd_FolioNomina(Convert.ToInt32(this.dl_nomina.SelectedValue));

				FuncionGlobal.alerta_updatepanel(string.Format("NOMINA Nº{0} GUARDADA CON EXITO", folio), this.Page, this.UpdatePanel4);

				this.Panel3.Visible = false;
				busca_operacion();
			}
			else
			{
				FuncionGlobal.alerta_updatepanel("Debe selecionar un tipo de nomina", this.Page, this.UpdatePanel4);
			}

			return;
		}

		public Int32 traerfolio(Int32 id_nomina)
		{
			TipoNomina lTiponomina = new TipoNominaBC().getTiponominaBytipo(id_nomina);
			Int32 folio = Convert.ToInt32(lTiponomina.Folio);
			return folio;
		}

		protected void btn_nomina_pdf_Click(object sender, ImageClickEventArgs e)
		{
			ver_reporte_nomina();
		}

		protected void ver_reporte_nomina()
		{
			Int32 id_nomina;
			Int32 folio;



			if (this.dl_familia.SelectedValue == "0")
			{


				return;

			}


			id_nomina = Convert.ToInt32(this.dpl_nomina.SelectedValue);
			if (!Int32.TryParse(this.txt_nomina.Text, out folio)) { folio = 0; }

			if (id_nomina != 0 && folio != 0)
			{

				string cadena = "/reportes/view_nomina.aspx";
				cadena += "?id_familia=" + this.dl_familia.SelectedValue.ToString();
				cadena += "&folio=" + folio.ToString();
				cadena += "&id_nomina=" + id_nomina.ToString();
				ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "ViewNomina", "<script type=\"text/javascript\">window.open('" + cadena + "'); </script>", false);
			}
		}

		protected void txt_nomina_TextChanged(object sender, EventArgs e) { }

		protected void gr_dato_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			if (e.CommandName == "eliminar")
			{
				if (new UsuarioBC().GetUsuario(Session["usrname"].ToString()).Permite_eliminar)
				{
					del_operacion(Convert.ToInt32(e.CommandArgument.ToString()));
				}
				else
				{
					this.txtUsuario.Text = "";
					this.txtPassword.Text = "";
					this.lblOpEliminar.Text = e.CommandArgument.ToString();
					this.ModalPopupExtenderEliminar.Show();
				}
			}
		}

		protected void bt_pago_completo_Click(object sender, EventArgs e) { }

		private void add_pago_completo()
		{
			GridViewRow row;
			HyperLink but;
			if (this.lbl_total_gastos.Text == "0")
			{
				FuncionGlobal.alerta_updatepanel("IMPOSIBLE REALIZAR PAGO, SUMA DE GASTOS SELECCIONADOS ESTA EN CERO", this.Page, this.panel_movimiento);
				return;
			}

			if (this.dl_financiera.SelectedValue.ToString() == "0" || this.dl_cuenta.SelectedValue.ToString() == "0" || this.dl_tipo_operacion.SelectedValue.ToString() == "0" || this.txt_fecha_pago.Text.Trim() == "" || this.txt_especial.Text == "")
			{
				FuncionGlobal.alerta_updatepanel("INGREASE LOS DATOS CORRESPONDIENTES PARA GENERAR MOVIMIENTO CONTABLE", this.Page, this.panel_movimiento);
				return;
			}

			for (int i = 0; i < gr_dato.Rows.Count; i++)
			{
				row = gr_dato.Rows[i];
				CheckBox chk = (CheckBox)gr_dato.Rows[i].FindControl("chk");
				but = (HyperLink)row.Cells[0].Controls[0];
				string id_solicitud = but.Text.Trim();
				if (chk.Checked == true)
				{
					string add = new MovimientoCuentaPeruBC().add_movimiento_cuentaPagoCompleto(Convert.ToInt32(id_solicitud), Convert.ToInt16(this.dl_cuenta.SelectedValue), (string)(Session["usrname"]), this.txt_fecha_pago.Text.Trim(), this.dl_tipo_operacion.SelectedValue, this.txt_especial.Text);
				}
			}

			FuncionGlobal.alerta_updatepanel("MOVIMIENTO CONTABLE INGRESADO CON EXITO", this.Page, this.panel_movimiento);
			this.Panel1.Visible = false;
			this.busca_operacion();
		}

		protected void chk_movimiento_CheckedChanged1(object sender, EventArgs e) { }

		protected void ib_pago_operacion_Click(object sender, ImageClickEventArgs e)
		{
			if (this.Panel1.Visible == true)
			{
				this.Panel1.Visible = false;

			}
			else
			{
				this.Panel2.Visible = false;
				this.Panel3.Visible = false;
				this.Panel1.Visible = true;

				this.total_pago();
			}
		}

		protected void ib_work_Click(object sender, ImageClickEventArgs e)
		{
			if (this.Panel2.Visible == true)
			{
				this.Panel2.Visible = false;

			}
			else
			{
				this.Panel1.Visible = false;
				this.Panel3.Visible = false;
				this.Panel2.Visible = true;
			}
		}

		protected void ib_nomina_Click(object sender, ImageClickEventArgs e)
		{
			if (this.Panel3.Visible == true)
			{
				this.Panel3.Visible = false;

			}
			else
			{
				this.Panel1.Visible = false;
				this.Panel2.Visible = false;
				this.Panel3.Visible = true;
			}
		}

		protected void btnAceptarEliminar_Click(object sender, EventArgs e)
		{
			if (new UsuarioBC().ValidarUsuario(this.txtUsuario.Text, this.txtPassword.Text))
			{
				Usuario user = new UsuarioBC().GetUsuario(this.txtUsuario.Text);
				if (user.Permite_eliminar)
					del_operacion(Convert.ToInt32(this.lblOpEliminar.Text));
				else
					FuncionGlobal.alerta_updatepanel("La cuenta ingresada no posee privilegios para eliminar operaciones", Page, this.UpdatePanel2);
			}
			else
			{
				FuncionGlobal.alerta_updatepanel("La cuenta y clave ingresadas no coinciden", Page, this.UpdatePanel2);
			}
		}

		protected void del_operacion(int id_solicitud)
		{
			string del = new OperacionBC().del_operacion(id_solicitud,(string)(Session["username"]));
			FuncionGlobal.alerta_updatepanel(string.Format("Operacion nro. {0} eliminada correctamente", id_solicitud), Page, this.UpdatePanel2);
			busca_operacion();
		}

		protected void gr_dato_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				HyperLink but;
				ImageButton ibuton;
				Button buton;
				string nombre;

				string tipo = gr_dato.DataKeys[e.Row.RowIndex].Values[0].ToString();
				int cont = gr_dato.DataKeys.Count;
				Int16 id_cliente = Convert.ToInt16(gr_dato.DataKeys[e.Row.RowIndex].Values[1].ToString());
				nombre = (string)e.Row.Cells[4].Text;
				but = (HyperLink)e.Row.Cells[0].Controls[0];
				TipoOperacion op = new TipooperacionBC().getTipooperacion(tipo);
				but.Attributes.Add("onclick", "javascript:window.showModalDialog('" + op.Url_operacion + FuncionGlobal.FuctionEncriptar(but.Text.Trim()) + "&id_cliente=" + FuncionGlobal.FuctionEncriptar(id_cliente.ToString()) + "','_blank','dialogheight=600px;dialogWidth=850px, top=0,left=0,status=no,toolbar=no,menubar=no,location=no,scrollbars=no,resizable=yes,copyhistory= false')");

				ibuton = (ImageButton)e.Row.FindControl("ib_estado");
				ibuton.Attributes.Add("onclick", "javascript:window.showModalDialog('mOperacion_estado.aspx?tipo=" + FuncionGlobal.FuctionEncriptar(tipo) + "&id_cliente=" + FuncionGlobal.FuctionEncriptar(id_cliente.ToString()) + "&id_solicitud=" + FuncionGlobal.FuctionEncriptar(but.Text.Trim()) + "&nombre_estado=" + nombre + "','','status:false;dialogWidth:500px;dialogHeight:260px')");

				ibuton = (ImageButton)e.Row.FindControl("ib_gasto");
				ibuton.Attributes.Add("onclick", "javascript:window.showModalDialog('gastooperacionperu.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(but.Text.Trim()) + "','','status:false;dialogWidth:500px;dialogHeight:400px')");

				ibuton = (ImageButton)e.Row.FindControl("ib_ingreso");
				ibuton.Attributes.Add("onclick", "javascript:window.showModalDialog('gastomovimientocuentaperu.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(but.Text.Trim()) + "&tipo=I" + "','','status:false;dialogWidth:700px;dialogHeight:400px')");

				ibuton = (ImageButton)e.Row.FindControl("ib_nomina");
				ibuton.Attributes.Add("onclick", "javascript:window.showModalDialog('nominabyoperacion.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(but.Text.Trim()) + "','','status:false;dialogWidth:700px;dialogHeight:400px')");

				ibuton = (ImageButton)e.Row.FindControl("ib_cargar");
				ibuton.Attributes.Add("onclick", "javascript:window.showModalDialog('../digitalizacion/subir_documentos.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(but.Text.Trim()) + "&tipo=" + tipo + "','','status:false;dialogWidth:700px;dialogHeight:400px')");

				ibuton = (ImageButton)e.Row.FindControl("ib_cdigital");
				ibuton.Attributes.Add("onclick", "javascript:window.open('../digitalizacion/ver_documentos.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(but.Text.Trim()) + "&origen=pc','_blank','height=600,width=800,location=0,menubar=0,titlebar=1,toolbar=0,resizable=1,scrollbars=1')");

				ibuton = (ImageButton)e.Row.FindControl("ib_comGastos");
				ibuton.Attributes.Add("onclick", "javascript:window.open('../reportes/view_comprobante_cobro.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(but.Text.Trim()) + "&id_familia=" + FuncionGlobal.FuctionEncriptar(this.dl_familia.SelectedValue) + "','_blank','height=355,width=500, top=150,left=150,status=no,toolbar=no,menubar=no,l ocation=no,scrollbars=yes,resizable=yes,copyhistory= false')");

				buton = (Button)e.Row.FindControl("bt_eliminar");
				buton.Attributes.Add("onclick", "return confirmarEliminar();");
			}
		}

		protected void txt_operacion_TextChanged(object sender, EventArgs e)
		{
			busca_operacion();
		}
	}
}