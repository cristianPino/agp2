using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
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


namespace sistemaAGP
{
	public partial class control_operaciones_prueba : System.Web.UI.Page
	{
        private Int32 semaforo = 0;

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				this.txt_desde.Text = DateTime.Today.ToShortDateString();
				this.txt_hasta.Text = DateTime.Today.ToShortDateString();
				this.cal_desde.FirstDayOfWeek = FirstDayOfWeek.Monday;
				this.cal_hasta.FirstDayOfWeek = FirstDayOfWeek.Monday;
				FuncionGlobal.comboclientesbyusuario((string)(Session["usrname"]), this.dl_cliente);
				FuncionGlobal.combomodulobyusuario(this.dl_modulo, (string)(Session["usrname"]), Convert.ToInt16(this.dl_cliente.SelectedValue));
				FuncionGlobal.combosucursalbyclienteandUsuario(this.dl_sucursal, Convert.ToInt16(this.dl_cliente.SelectedValue), (string)(Session["usrname"]));
				FuncionGlobal.combofamiliabyusuario((string)(Session["usrname"]), this.dl_familia);
				FuncionGlobal.comboProductobyfamilia(this.dl_producto, Convert.ToInt16(this.dl_familia.SelectedValue));

				FuncionGlobal.comboparametro(this.dl_saldo, "TISO");

				FuncionGlobal.combobanco(this.dl_financiera,1);
				FuncionGlobal.comboparametro(this.dl_tipo_operacion, "FMO");

				this.Crear_DataTable();
			}
		}


        protected void rb_verdechangen(object sender, EventArgs e)
        {
            this.rb_amarillo.Checked = false;
            this.rb_rojo.Checked = false;
            this.rb_blanco.Checked = false;

        }

        protected void rb_amarrillochangen(object sender, EventArgs e)
        {
            this.rb_verde.Checked = false;
            this.rb_rojo.Checked = false;
            this.rb_blanco.Checked = false;

        }

        protected void rb_rojochangen(object sender, EventArgs e)
        {
            this.rb_verde.Checked = false;
            this.rb_amarillo.Checked = false;
            this.rb_blanco.Checked = false;

        }
        protected void rb_blancochangen(object sender, EventArgs e)
        {
            this.rb_verde.Checked = false;
            this.rb_amarillo.Checked = false;
            this.rb_rojo.Checked = false;
        }


		protected void dl_cliente_SelectedIndexChanged(object sender, EventArgs e)
		{
			FuncionGlobal.combomodulobyusuario(this.dl_modulo, (string)(Session["usrname"]), Convert.ToInt16(this.dl_cliente.SelectedValue));
			FuncionGlobal.combosucursalbyclienteandUsuario(this.dl_sucursal, Convert.ToInt16(this.dl_cliente.SelectedValue), (string)(Session["usrname"]));
			if (Convert.ToInt16(this.dl_cliente.SelectedValue) == 0)
			{
				FuncionGlobal.combofamiliabyusuario((string)(Session["usrname"]), this.dl_familia);
				FuncionGlobal.comboProductobyfamilia(this.dl_producto, Convert.ToInt16(this.dl_familia.SelectedValue));
			}
			else
			{
				FuncionGlobal.combofamilia_by_cliente_usuario(Convert.ToInt16(this.dl_cliente.SelectedValue), (string)(Session["usrname"]), this.dl_familia);
				FuncionGlobal.comboProductobyfamilia(this.dl_producto, Convert.ToInt16(this.dl_familia.SelectedValue));
			}

            //this.Limpiar_DataTable();

			this.pnl_acciones.Style.Add("display", "none");
		}

        //protected void Limpiar_DataTable()
        //{
        //    ViewState["dt"] = null;
        //    this.gr_dato.DataSource = null;
        //    this.gr_dato.DataBind();
        //}

		protected void dl_familia_SelectedIndexChanged(object sender, EventArgs e)
		{
			FuncionGlobal.comboProductobyfamilia(this.dl_producto, Convert.ToInt16(this.dl_familia.SelectedValue));

            FuncionGlobal.comboProductobyfamilia(this.dl_producto_cambio, Convert.ToInt16(this.dl_familia.SelectedValue));

			FuncionGlobal.combonominabyfamilia(this.dpl_nomina, Convert.ToInt32(this.dl_familia.SelectedValue));
			FuncionGlobal.combonominabyfamilia(this.dl_nomina, Convert.ToInt32(this.dl_familia.SelectedValue));
			if (this.dl_familia.SelectedValue == "0")
			{
				this.pnl_nomina.Style.Add("display", "none");
				this.pnl_flujo.Style.Add("display", "none");
			}
			else
			{
				this.pnl_nomina.Style.Add("display", "inline");
				this.pnl_flujo.Style.Add("display", "inline");
			}

			FuncionGlobal.comboEstadoByFamilia(this.dpl_estado, Convert.ToInt32(this.dl_familia.SelectedValue));
			FuncionGlobal.comboEstadoByFamilia(this.dl_estado, Convert.ToInt32(this.dl_familia.SelectedValue));

            //this.Limpiar_DataTable();

			this.pnl_acciones.Style.Add("display", "none");
		}

		protected void dl_modulo_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (Convert.ToInt16(this.dl_modulo.SelectedValue) == 0)
				FuncionGlobal.combosucursalbyclienteandUsuario(this.dl_sucursal, Convert.ToInt16(this.dl_cliente.SelectedValue), (string)(Session["usrname"]));
			else
				FuncionGlobal.combosucursalbymodulo(this.dl_sucursal, Convert.ToInt16(this.dl_modulo.SelectedValue));
		}

		protected void dl_producto_SelectedIndexChanged(object sender, EventArgs e)
		{
            //this.Limpiar_DataTable();

			this.pnl_acciones.Style.Add("display", "none");
		}

		protected void ib_buscar_Click(object sender, ImageClickEventArgs e)
		{
            this.lbl_count.Text = "0";
            this.lbl_count.Visible = false;
			this.Busca_Operacion();
		}

		protected void ib_pago_operacion_Click(object sender, ImageClickEventArgs e)
		{
            //double suma = (from r in this.gr_dato.Rows.OfType<GridViewRow>()
            //               where ((CheckBox)r.FindControl("chk")).Checked == true && r.RowType == DataControlRowType.DataRow
            //               select Convert.ToDouble(this.gr_dato.DataKeys[r.RowIndex].Values[5])).Sum();
            //if (suma == 0)
            //{
            //    FuncionGlobal.alerta_updatepanel("No hay operaciones seleccionadas o el saldo a pagar es cero", this.Page, this.up_movimiento);
            //    return;
            //}
            //FuncionGlobal.BuscarValueCombo(this.dl_financiera, "0");
            //FuncionGlobal.combocuenta(this.dl_financiera.SelectedValue, this.dl_cuenta);
            //FuncionGlobal.BuscarValueCombo(this.dl_tipo_operacion, "0");
            //this.txt_fecha_pago.Text = "";
            //this.txt_especial.Text = "";
            //this.lbl_total_gastos.Text = string.Format("{0:N0}", suma);
            //this.mpe_movimiento.Show();
		}

		protected void ib_cargar_gastos_Click(object sender, ImageClickEventArgs e)
		{
			if (this.Filas_Selecionadas())
				this.Add_Gasto_Completo();
		}

		protected void ib_work_Click(object sender, ImageClickEventArgs e)
		{
			if (this.Filas_Selecionadas())
			{
				FuncionGlobal.BuscarValueCombo(this.dl_estado, "0");
				this.txt_obs.Text = "";
				this.mpe_work.Show();
			}
		}

		protected void ib_nomina_Click(object sender, ImageClickEventArgs e)
		{
			if (this.Filas_Selecionadas())
			{
				FuncionGlobal.BuscarValueCombo(this.dl_nomina, "0");
				this.mpe_nominas.Show();
			}
		}


        protected void ib_modifica_producto_Click(object sender, ImageClickEventArgs e)
        {
            if (this.Filas_Selecionadas())
            {
                this.mpe_modifica.Show();  
            }
        }

		protected void dl_financiera_SelectedIndexChanged(object sender, EventArgs e)
		{
			FuncionGlobal.combocuenta(this.dl_financiera.SelectedValue, this.dl_cuenta);
		}

		protected void bt_graba_movimiento_Click(object sender, EventArgs e)
		{
            if (this.txt_especial.Text != "")
            {
                this.Add_Pago_Completo();
            }
            else
            {
                FuncionGlobal.alerta_updatepanel("Es requerido el Documento Especial para realizar el Pago Masivo", this.Page, this.up_movimiento);
            }
		}

		protected void bt_guardar_nomina_Click(object sender, EventArgs e)
		{
			this.Generar_Nomina();
		}

		protected void bt_guardar_work_Click(object sender, EventArgs e)
		{
			this.Guardar_Wflow();
		}

		protected void btn_nomina_pdf_Click(object sender, ImageClickEventArgs e)
		{
			this.Ver_Reporte_Nomina();
		}

		protected void Busca_Operacion()
		{
			double rut = 0;
            double rut_para = 0;
			Int32 factura = 0;
			Int32 noperacion = 0;
			Int32 estado_actual = 0;
			Int16 dl_modulo = 0;
			Int16 dl_sucursal = 0;
			Int16 dl_saldo = 0;
            Int32 contador = 0;
			string desde = string.Format("{0:yyyyMMdd}", Convert.ToDateTime(this.txt_desde.Text.Trim()));
			string hasta = string.Format("{0:yyyyMMdd}", Convert.ToDateTime(this.txt_hasta.Text.Trim()));
			string patente = this.txt_patente.Text.Trim();

			if (this.txt_rut.Text.Trim() != "") rut = Convert.ToDouble(this.txt_rut.Text);
            if (this.txt_rut_para.Text.Trim() != "") rut_para = Convert.ToDouble(this.txt_rut_para.Text);
			if (this.txt_operacion.Text.Trim() != "") noperacion = Convert.ToInt32(this.txt_operacion.Text);
			if (this.txt_factura.Text.Trim() != "") factura = Convert.ToInt32(this.txt_factura.Text);
			if (this.dpl_estado.SelectedValue != "") estado_actual = Convert.ToInt32(this.dpl_estado.SelectedValue);
			if (this.dl_modulo.SelectedValue != "") dl_modulo = Convert.ToInt16(this.dl_modulo.SelectedValue);
			if (this.dl_sucursal.SelectedValue != "") dl_sucursal = Convert.ToInt16(this.dl_sucursal.SelectedValue);
			if (this.dl_saldo.SelectedValue != "0") dl_saldo = Convert.ToInt16(this.dl_saldo.SelectedValue);

			if ( (noperacion == 0 && patente.Trim()== "")  &&  this.chk_agrupar.Checked == true) return;
            

			//this.txt_operacion.Text = "";
			this.txt_operacion.Focus();

			if (noperacion != 0 || factura != 0 || patente != "")
			{
				desde = string.Format("{0:yyyyMMdd}", DateTime.MinValue);
				hasta = string.Format("{0:yyyyMMdd}", DateTime.MaxValue);
			}
		/*	
            if (noperacion == 0 && this.chk_agrupar.Checked == false)
			{
				ViewState["dt"] = null;
				this.Crear_DataTable();
			}
            */

            if (this.rb_blanco.Checked == true)
            {
                semaforo = 0;
            }
            if (this.rb_verde.Checked == true)
            {
                semaforo = 1;
            }
            if (this.rb_amarillo.Checked == true)
            {
                semaforo = 2;
            }
            if (this.rb_rojo.Checked == true)
            {
                semaforo = 3;
            }


            if (this.chk_agrupar.Checked == false)
            {
                ViewState["dt"] = null;
            }
			if (ViewState["dt"] == null) this.Crear_DataTable();

			
            
            DataTable dt = (DataTable)ViewState["dt"];

			int id_nomina = 0;
			int folio = 0;

			List<Operacion> loperacion = new List<Operacion>();

			if (int.TryParse(this.dpl_nomina.SelectedValue, out id_nomina) && int.TryParse(this.txt_nomina.Text, out folio))
				loperacion = new OperacionBC().getOperacionesbynomina(id_nomina, folio, Session["usrname"].ToString());
			else
				loperacion = new OperacionBC().getOperaciones(this.dl_producto.SelectedValue, dl_modulo, dl_sucursal, Convert.ToInt16(this.dl_cliente.SelectedValue), noperacion, rut, factura, this.txt_cliente.Text.Trim(), patente.Trim(),
                    desde, hasta, estado_actual, (string)(Session["usrname"]), Convert.ToInt32(this.dl_familia.SelectedValue), this.chk_proceso.Checked.ToString().ToUpper(),semaforo,this.txt_chassis.Text,this.txt_motor.Text,rut_para);

			if (dl_saldo == 1) //Pendiente de pago
			{
				var query = from o in loperacion
							where (o.Total_ingreso - o.Total_gasto != 0) && ((o.Total_ingreso > 0) || (o.Total_gasto > 0))
							select o;
				loperacion = query.ToList<Operacion>();
			}
			else if (dl_saldo == 2) //Sin saldo pendiente
			{
				var query = from o in loperacion
							where (o.Total_ingreso - o.Total_gasto == 0) && ((o.Total_ingreso > 0) || (o.Total_gasto > 0))
							select o;
				loperacion = query.ToList<Operacion>();
			}

			if (loperacion.Count != 0)
				this.pnl_acciones.Style.Add("display", "block");
			else
				this.pnl_acciones.Style.Add("display", "none");
            

			foreach (Operacion moperacion in loperacion)
			{
                wucPanelControl control = new wucPanelControl();
                control.ID = "control" + contador.ToString();
                control.Busca_Operacion(moperacion.Id_solicitud);
                Page.Controls.Add(control);
                contador++;

                

			}

                this.lbl_count.Visible = true;
                this.lbl_count.Text = "Total Operaciones: " +  dt.Rows.Count.ToString(); 
          

		}

		protected bool Filas_Selecionadas()
        {
            bool resultado = true;
            //double cantidad = (from r in this.gr_dato.Rows.OfType<GridViewRow>()
            //                   where ((CheckBox)r.FindControl("chk")).Checked == true && r.RowType == DataControlRowType.DataRow
            //                   select r.RowIndex).Count();
            //if (cantidad == 0)
            //{
            //    FuncionGlobal.alerta_updatepanel("No hay operaciones seleccionadas para realizar la acción solicitada", this.Page, this.up_movimiento);
            //    resultado = false;
            //}
            return resultado;
		}

		private void Add_Pago_Completo()
		{
            //bool permite = new UsuarioBC().GetUsuario((string)(Session["usrname"])).Permite_pagar;

            //if (permite == true)
            //{
            //    var query = from r in this.gr_dato.Rows.OfType<GridViewRow>()
            //                where ((CheckBox)r.FindControl("chk")).Checked == true && r.RowType == DataControlRowType.DataRow && Convert.ToDouble(Convert.ToDouble(this.gr_dato.DataKeys[r.RowIndex].Values[5])) > 0
            //                select r.RowIndex;
            //    string add;
            //    foreach (int i in query)
            //        add = new MovimientocuentaBC().add_movimiento_cuentaPagoCompleto(Convert.ToInt32(this.gr_dato.DataKeys[i].Values[3].ToString()), Convert.ToInt16(this.dl_cuenta.SelectedValue), (string)(Session["usrname"]), this.txt_fecha_pago.Text.Trim(), this.dl_tipo_operacion.SelectedValue, this.txt_especial.Text);

            //    FuncionGlobal.alerta_updatepanel("Movimiento contable ingresado con exito", this.Page, this.up_movimiento);
            //    this.Busca_Operacion();
            //}
            //else
            //{
            //    FuncionGlobal.alerta_updatepanel("Su usuario no tiene los pemisos para Pagar Operaciones", this.Page, this.up_movimiento);
            //}
		}

		private void Add_Gasto_Completo()
		{
            //var query = from r in this.gr_dato.Rows.OfType<GridViewRow>()
            //            where ((CheckBox)r.FindControl("chk")).Checked == true && r.RowType == DataControlRowType.DataRow && Convert.ToDouble(Convert.ToDouble(this.gr_dato.DataKeys[r.RowIndex].Values[5])) == 0
            //            select r.RowIndex;
            //string add;
            //foreach (int i in query)
            //    foreach (GastoOperacion gasto in new GastooperacionBC().Getgastooperacion(Convert.ToInt32(this.gr_dato.DataKeys[i].Values[3].ToString())))
            //        add = new GastooperacionBC().add_gastooperacion(Convert.ToInt32(this.gr_dato.DataKeys[i].Values[3].ToString()), gasto.Tipogasto.Id_tipogasto, gasto.Monto, (string)(Session["usrname"]), gasto.Cargo_cliente, gasto.Cargo_empresa, gasto.Tipogasto.Check.ToString());

            //FuncionGlobal.alerta_updatepanel("Gastos ingresados con exito", this.Page, this.up_movimiento);
            //this.Busca_Operacion();
		}

		private void Generar_Nomina()
		{
            //var query = from r in this.gr_dato.Rows.OfType<GridViewRow>()
            //            where ((CheckBox)r.FindControl("chk")).Checked == true && r.RowType == DataControlRowType.DataRow
            //            select r.RowIndex;
            //string add;
			
            //TipoNomina lTiponomina = new TipoNominaBC().getTiponominaBytipo(Convert.ToInt32(this.dl_nomina.SelectedValue));
            //int folio = Convert.ToInt32(lTiponomina.Folio);
            //int orden_new = lTiponomina.Orden_new;

            //foreach (int i in query)
            //{
            //    add = new TipoNominaBC().add_tiponominaByOperacion(Convert.ToInt32(this.gr_dato.DataKeys[i].Values[3].ToString()), Convert.ToInt32(this.dl_nomina.SelectedValue), folio, Session["usrname"].ToString());

            ////    if (orden_new != 0)
            ////        add = new EstadooperacionBC().add_estado_orden(Convert.ToInt32(this.gr_dato.DataKeys[i].Values[3].ToString()), orden_new, this.gr_dato.DataKeys[i].Values[0].ToString(), "", Session["usrname"].ToString());
            //}

            //add = new TipoNominaBC().upd_FolioNomina(Convert.ToInt32(this.dl_nomina.SelectedValue));

            //FuncionGlobal.alerta_updatepanel(string.Format("Nómina {0} con folio {1} generada con éxito", lTiponomina.Descripcion, folio), this.Page, this.up_movimiento);
            //this.Busca_Operacion();
		}

		private void Guardar_Wflow()
		{
            //var query = from r in this.gr_dato.Rows.OfType<GridViewRow>()
            //            where ((CheckBox)r.FindControl("chk")).Checked == true && r.RowType == DataControlRowType.DataRow
            //            select r.RowIndex;
            //string add;
            //foreach(int i in query)
            //    add = new EstadooperacionBC().add_Estadooperacion(Convert.ToInt32(this.gr_dato.DataKeys[i].Values[3].ToString()), Convert.ToInt32(this.dl_estado.SelectedValue), this.txt_obs.Text.Trim().ToUpper(), (string)(Session["usrname"]));

            //FuncionGlobal.alerta_updatepanel("Estado workflow cambiado con éxito", this.Page, this.up_movimiento);
            //this.Busca_Operacion();
		}

		protected void Ver_Reporte_Nomina()
		{
			int id_nomina = Convert.ToInt32(this.dpl_nomina.SelectedValue);
			int folio;
			
			if (!int.TryParse(this.txt_nomina.Text, out folio)) { folio = 0; }

			if (id_nomina != 0 && folio != 0)
			{
				string cadena = string.Format("../reportes/view_nomina.aspx?id_familia={0}&folio={1}&id_nomina={2}", this.dl_familia.SelectedValue, folio, id_nomina);
				ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "ViewNomina", "window.open('" + cadena + "');", true);
			}
		}

		protected void gr_dato_RowDeleting(object sender, GridViewDeleteEventArgs e)
		{
            //if (new UsuarioBC().GetUsuario(Session["usrname"].ToString()).Permite_eliminar)
            //{
            //    int id_solicitud = Convert.ToInt32(this.gr_dato.DataKeys[e.RowIndex].Values[3].ToString());
            //    this.Borrar_Operacion(id_solicitud);
            //}
            //else
            //{
            //    e.Cancel = true;
            //    FuncionGlobal.alerta_updatepanel("Ud. no tiene los permisos suficientes para eliminar esta operación", this.Page, this.up_grilla);
            //}
		}

		protected void Borrar_Operacion(int id_solicitud)
		{
            //string del = new OperacionBC().del_operacion(id_solicitud);
            //FuncionGlobal.alerta_updatepanel(string.Format("Operacion nro. {0} eliminada correctamente", id_solicitud), this.Page, this.up_grilla);
            //this.Busca_Operacion();
		}

		protected void checkall_CheckedChanged(object sender, EventArgs e)
		{
            //FuncionGlobal.marca_check(this.gr_dato);
		}

		protected void gr_dato_RowDataBound(object sender, GridViewRowEventArgs e)
		{
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    string nombre;

            //    string tipo = this.gr_dato.DataKeys[e.Row.RowIndex].Values[0].ToString();
            //    string patente = this.gr_dato.DataKeys[e.Row.RowIndex].Values[2].ToString();
            //    int cont = this.gr_dato.DataKeys.Count;
            //    Int16 id_cliente = Convert.ToInt16(gr_dato.DataKeys[e.Row.RowIndex].Values[1].ToString());
            //    string id_estado = gr_dato.DataKeys[e.Row.RowIndex].Values[8].ToString();
            //    nombre = (string)e.Row.Cells[4].Text;
            //    TipoOperacion op = new TipooperacionBC().getTipooperacion(tipo);

            //    HyperLink but = (HyperLink)e.Row.Cells[0].Controls[0];
            //    but.Attributes.Add("onclick", "javascript:window.showModalDialog('" + op.Url_operacion + FuncionGlobal.FuctionEncriptar(but.Text.Trim()) + "&id_cliente=" + FuncionGlobal.FuctionEncriptar(id_cliente.ToString()) + "&patente=" + patente + "&ventatipo=','_blank','" + op.Tamano + "')");

            //    HyperLink but1 = (HyperLink)e.Row.Cells[16].Controls[0];
            //    but1.Attributes.Add("onclick", "javascript:window.showModalDialog('../operacion/SubEstados.aspx?id_solicitud=" + but.Text.Trim() + "&id_estado=" + id_estado +"','_blank','" + op.Tamano + "')");

            //    but = (HyperLink)e.Row.FindControl("lnk_gasto");
            //    if (Convert.ToInt32(gr_dato.DataKeys[e.Row.RowIndex].Values[4].ToString()) == 0 && Convert.ToInt32(gr_dato.DataKeys[e.Row.RowIndex].Values[5]) > 0 && Convert.ToInt32(gr_dato.DataKeys[e.Row.RowIndex].Values[6]) > 0)
            //    {
            //        but.Enabled = false;
            //        but.ImageUrl = "~/imagenes/sistema/static/panel_control/gastos_disable.png";
            //    }
            //    else
            //    {
            //        but.Enabled = true;
            //        but.ImageUrl = "~/imagenes/sistema/static/panel_control/gastos.png";
            //    }

            //    but = (HyperLink)e.Row.FindControl("lnk_ingreso");
            //    bool permite = new UsuarioBC().GetUsuario((string)(Session["usrname"])).Permite_pagar;
            //    if (permite == false)
            //    {
            //        but.Enabled = false;
            //        but.ImageUrl = "~/imagenes/sistema/static/panel_control/ingresos_disable.png";
            //    }
            //    else
            //    {
            //        but.Enabled = true;
            //        but.ImageUrl = "~/imagenes/sistema/static/panel_control/ingresos.png";
            //    }

            //}
		}

		protected void Crear_DataTable()
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
            dt.Columns.Add(new DataColumn("id_estado"));
            dt.Columns.Add(new DataColumn("contador"));
            dt.Columns.Add(new DataColumn("semaforo"));
			dt.Columns.Add(new DataColumn("factura_emitida"));
			dt.Columns.Add(new DataColumn("sucursal"));
			dt.Columns.Add(new DataColumn("url_nominas"));
			dt.Columns.Add(new DataColumn("url_cargar"));
			dt.Columns.Add(new DataColumn("url_digital"));
			dt.Columns.Add(new DataColumn("url_estado"));
			dt.Columns.Add(new DataColumn("url_poliza"));
			dt.Columns.Add(new DataColumn("url_solicrc"));
			dt.Columns.Add(new DataColumn("url_comgastos"));
			dt.Columns.Add(new DataColumn("url_gastos"));
			dt.Columns.Add(new DataColumn("url_ingreso"));
            dt.Columns.Add(new DataColumn("url_contratos"));
			dt.Columns.Add(new DataColumn("repertorio_solicitado"));
			dt.Columns.Add(new DataColumn("n_repertorio"));
            dt.Columns.Add(new DataColumn("url_comingreso"));
			ViewState["dt"] = dt;
		}

		protected void txt_operacion_TextChanged(object sender, EventArgs e)
		{
			this.Busca_Operacion();
		}

		protected void ib_repertorio_Click(object sender, ImageClickEventArgs e)
		{
			if (this.Filas_Selecionadas())
				this.Generar_Archivo_Solicitud_Repertorio();
			else
				FuncionGlobal.alerta_updatepanel("Debe seleccionar al menos una operación", this, this.up_movimiento);
		}

		protected void Generar_Archivo_Solicitud_Repertorio()
		{
            //int id_repertorio = new RepertorioBC().add_repertorio(Session["usrname"].ToString());
            //if (id_repertorio != 0)
            //{
            //    var query = from r in this.gr_dato.Rows.OfType<GridViewRow>()
            //                where ((CheckBox)r.FindControl("chk")).Checked == true && r.RowType == DataControlRowType.DataRow
            //                select new
            //                {
            //                    id_solicitud = Convert.ToInt32(this.gr_dato.DataKeys[r.RowIndex].Values[3].ToString()),
            //                    tipo_operacion = this.gr_dato.DataKeys[r.RowIndex].Values[0].ToString()
            //                };
            //    foreach (var q in query)
            //    {
            //        string add = new RepertorioBC().add_repertorio_operacion(id_repertorio, q.id_solicitud);
            //        if (Convert.ToDouble(this.dl_familia.SelectedValue) == 3)
            //        {
            //            add = new EstadooperacionBC().add_estado_orden(q.id_solicitud, 68, q.tipo_operacion, "AUTOMÁTICO SYSTEM", (string)Session["usrname"]);
            //        }
            //    }
            //    using (StreamWriter sw = new StreamWriter(string.Format("{0}\\{1:yyyyMMdd_HHmmss}.csv", Server.MapPath(ResolveClientUrl("~/operacion/solicitud_repertorio/")), DateTime.Now, false)))
            //    {
            //        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["CONECCION"].ConnectionString))
            //        {
            //            cnn.Open();
            //            using (SqlCommand cmd = new SqlCommand("sp_r_get_datos_solicitud_repertorio", cnn))
            //            {
            //                cmd.CommandType = CommandType.StoredProcedure;
            //                cmd.Parameters.AddWithValue("@id_repertorio", id_repertorio);
            //                SqlDataReader dr = cmd.ExecuteReader();

            //                string linea = "";

            //                for (int col = 0; col < dr.FieldCount; col++)
            //                    linea += string.Format("{0};", dr.GetName(col));
            //                sw.WriteLine(linea);

            //                while (dr.Read())
            //                {
            //                    linea = "";
            //                    for (int col = 0; col < dr.FieldCount; col++)
            //                        linea += string.Format("{0};", dr[col]);
            //                    sw.WriteLine(linea);
            //                }
            //                dr.Close();
            //            }
            //            cnn.Close();
            //        }
            //        sw.Close();
            //    }
            //    FuncionGlobal.alerta_updatepanel("Solicitudes de repertorio generadas con éxito", this.Page, this.up_movimiento);
            //}
            //else
            //{
            //    FuncionGlobal.alerta_updatepanel("Solicitudes de repertorio no generadas", this.Page, this.up_movimiento);
            //}
		}

        protected void gr_dato_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void bt_guardar_modifica_Click(object sender, EventArgs e)
        {
            this.actualiza_producto();
		
        }
        private void actualiza_producto()
        {
            //var query = from r in this.gr_dato.Rows.OfType<GridViewRow>()
            //            where ((CheckBox)r.FindControl("chk")).Checked == true && r.RowType == DataControlRowType.DataRow
            //            select r.RowIndex;
            //Int32 add;
			
			

            //foreach (int i in query)
            //{
            //    add = new OperacionBC().actualiza_producto ( (Convert.ToInt32(this.gr_dato.DataKeys[i].Values[3].ToString())),
            //                                            this.dl_producto_cambio.SelectedValue,
            //                                            Session["usrname"].ToString());
 

          
            //}

			

            //FuncionGlobal.alerta_updatepanel("DATOS ACTUALIZADOS", this.Page, this.up_movimiento);
            //this.Busca_Operacion();
		}

        protected void ib_exportar_Click(object sender, ImageClickEventArgs e)
        {

            string desde = string.Format("{0:yyyyMMdd}", Convert.ToDateTime(this.txt_desde.Text.Trim()));
            string hasta = string.Format("{0:yyyyMMdd}", Convert.ToDateTime(this.txt_hasta.Text.Trim()));
		
         
            string add = "";

            if (this.dl_familia.SelectedValue != "19")
            {

                if (this.dpl_nomina.SelectedValue == "0" || this.txt_nomina.Text.Trim() == "")
                { return; }

                string titulo = "";

                titulo = "NOMINA AREA: " + this.dl_familia.SelectedItem.Text.Trim() + " - TIPO :  " +
                                    this.dpl_nomina.SelectedItem.Text.Trim() + "  NUMERO:  " + this.txt_nomina.Text.Trim();


                 add = new MatrizExcelBC().getnominamatrizgasto(Convert.ToInt16(this.dpl_nomina.SelectedValue),
                                                                        Convert.ToInt32(this.txt_nomina.Text),
                                                                        Convert.ToInt16(this.dl_familia.SelectedValue), titulo);


                FuncionGlobal.alerta_updatepanel("Nomina con detalle de gastos, generada con exito", this.Page, this.up_movimiento);

            }

            else
            {

                 add = new MatrizExcelBC().getMatrizRetiroCarpeta(desde,hasta,Session["usrname"].ToString());
  
            }

            string strAlerta = "window.open('http://sistema.agpsa.cl/Reportes_Excel/" + add.ToString().Trim()  + "');";
            //ScriptManager.RegisterStartupScript(up, pPagina.GetType(), "", strAlerta, true);
            ScriptManager.RegisterStartupScript(this.up_movimiento, this.up_movimiento.GetType(), "", strAlerta, true);


            return;
        }

        protected void txt_chassis_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txt_motor_TextChanged(object sender, EventArgs e)
        {
             
        }

        protected void txt_rut_para_TextChanged(object sender, EventArgs e)
        {

        }



	}
}