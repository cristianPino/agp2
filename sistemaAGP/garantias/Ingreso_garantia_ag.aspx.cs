using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using CENTIDAD;
using CNEGOCIO;
using sistemaAGP.integracionAG;
//using sistemaAGP.IntegracionIndumotora;

namespace sistemaAGP
{
	public partial class Ingreso_garantia_ag : System.Web.UI.Page
    {
        public static int IdOrdenTrabajo = 0;
		protected void Page_Load(object sender, EventArgs e)
		{
            IdOrdenTrabajo = Convert.ToInt32(FuncionGlobal.FuctionDesEncriptar(Request.QueryString["idOrdenTrabajo"]));
			if (!IsPostBack)
			{
				ViewState["id_solicitud"] = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_solicitud"].ToString());
				ViewState["id_cliente"] = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_cliente"].ToString());
				ViewState["tipo_operacion"] = Request.QueryString["tipo_operacion"].ToString();
				ViewState["separadorMiles"] = CultureInfo.CurrentUICulture.NumberFormat.NumberGroupSeparator;

                //if ((this.dl_forma_pago_factura.SelectedValue == "2") || (this.dl_forma_pago_factura.SelectedValue == "3"))
                //{
                //    this.RegistrarCalcularMontoFinanciar();

                //}
                this.RegistrarCalcularMontoFinanciar();


				this.Cambiar_Titulo();

				FuncionGlobal.comboclientesbyusuario((string)(Session["usrname"]), this.dl_cliente);
				this.dl_cliente.SelectedValue = ViewState["id_cliente"].ToString();
				FuncionGlobal.combosucursalbyclienteandUsuario(this.dl_sucursal, Convert.ToInt16(this.dl_cliente.SelectedValue), (string)(Session["usrname"]));

				if (this.dl_sucursal.Items.Count == 2)
				{
					this.dl_sucursal.SelectedIndex = 1;
				}

				FuncionGlobal.comboparametro(this.dl_tipo_doc_fundante, "DOCFUN");
				this.dl_tipo_doc_fundante.SelectedValue = "FACT";
				this.dl_tipo_doc_fundante.Enabled = false;
				this.Cambio_Documento_Fundante();
				this.pnl_tipo_doc_fundante.Visible = false;

				FuncionGlobal.comboparametro(this.dl_forma_pago_factura, "FOPA");

				FuncionGlobal.comboparametro(this.dl_estado_rnp, "EDORNP");
				FuncionGlobal.comboparametro(this.dl_estado_prenda, "EDOGARA");

				FuncionGlobal.combobanco(this.dl_banco,Convert.ToInt32(ViewState["id_cliente"]));

				this.BuscarClienteVendedor();
				
				this.ace_solicitante.ContextKey = this.dl_cliente.SelectedValue;

				this.tab_garantia.Visible = false;
				this.rfv_notaria_protocolizacion.Enabled = false;
				this.rfv_ciudad_notaria_protocolizacion.Enabled = false;

				this.txt_notaria_protocolizacion.Text = "MARÍA GLORIA ACHARAN TOLEDO";
				this.txt_ciudad_notaria_protocolizacion.Text = "SANTIAGO";

				this.Busca_Operacion();
			}
		}

		protected void dl_tipo_doc_fundante_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.Cambio_Documento_Fundante();
		}

		protected void txt_factura_TextChanged(object sender, EventArgs e)
		{
			if (this.txt_factura.Text != "")
			{
                
				int valor = Convert.ToInt32(this.txt_factura.Text.Replace(ViewState["separadorMiles"].ToString(), ""));
				this.txt_factura.Text = valor.ToString("N0");

                if (this.dl_tipo_doc_fundante.SelectedValue == "FACT") this.Busca_Operacion_Por_Factura();
			}
		}

		//protected void txt_monto_factura_TextChanged(object sender, EventArgs e)
		//{
		//    if (this.txt_monto_factura.Text != "")
		//    {
		//        int valor = Convert.ToInt32(this.txt_monto_factura.Text.Replace(ViewState["separadorMiles"].ToString(), ""));
		//        this.txt_monto_factura.Text = valor.ToString("N0");
		//    }
		//    this.Calcular_Monto_Financiar();
		//}

		protected void Cambio_Documento_Fundante()
		{
			switch (this.dl_tipo_doc_fundante.SelectedValue)
			{
				case "FACT":
					this.lbl_datos_negocio.Text = "DATOS FACTURA";
					this.pnl_datos_negocio.Visible = true;
					this.pnl_emisor.Visible = true;

					this.lbl_factura.Text = "Nro. Factura";
					this.rfv_factura.ErrorMessage = this.lbl_factura.Text;
					this.rfv_factura.Enabled = true;

					this.lbl_fecha_factura.Text = "Fecha Factura";
					this.rfv_fecha_factura.ErrorMessage = this.lbl_fecha_factura.Text;
					this.rfv_fecha_factura.EnableClientScript = true;

					this.lbl_monto_factura.Text = "Total Factura";
					this.rfv_monto_factura.ErrorMessage = this.lbl_monto_factura.Text;
					this.rfv_monto_factura.Enabled = true;

					this.lbl_notaria_factura.Text = "";
					this.rfv_notaria_factura.ErrorMessage = this.lbl_notaria_factura.Text;
					this.rfv_notaria_factura.Enabled = false;

					this.lbl_ciudad_notaria_factura.Text = "";
					this.rfv_ciudad_notaria_factura.ErrorMessage = this.lbl_ciudad_notaria_factura.Text;
					this.rfv_ciudad_notaria_factura.Enabled = false;

					break;
				case "CONT":
					this.lbl_datos_negocio.Text = "DATOS CONTRATO";
					this.pnl_datos_negocio.Visible = true;
					this.pnl_emisor.Visible = false;

					this.lbl_factura.Text = "";
					this.rfv_factura.ErrorMessage = this.lbl_factura.Text;
					this.rfv_factura.Enabled = false;

					this.lbl_fecha_factura.Text = "Fecha Contrato";
					this.rfv_fecha_factura.ErrorMessage = this.lbl_fecha_factura.Text;
					this.rfv_fecha_factura.EnableClientScript = true;

					this.lbl_monto_factura.Text = "Valor Vehículo";
					this.rfv_monto_factura.ErrorMessage = this.lbl_monto_factura.Text;
					this.rfv_monto_factura.Enabled = true;

					this.lbl_notaria_factura.Text = "Notaría";
					this.rfv_notaria_factura.ErrorMessage = this.lbl_notaria_factura.Text;
					this.rfv_notaria_factura.Enabled = true;

					this.lbl_ciudad_notaria_factura.Text = "Ciudad Notaría";
					this.rfv_ciudad_notaria_factura.ErrorMessage = this.lbl_ciudad_notaria_factura.Text;
					this.rfv_ciudad_notaria_factura.Enabled = true;

					break;
				case "DECL":
					this.lbl_datos_negocio.Text = "DATOS DECLARACIÓN CONCENSUAL";
					this.pnl_datos_negocio.Visible = true;
					this.pnl_emisor.Visible = false;

					this.lbl_factura.Text = "Nro. Declaración";
					this.rfv_factura.ErrorMessage = this.lbl_factura.Text;
					this.rfv_factura.Enabled = true;

					this.lbl_fecha_factura.Text = "Fecha Declaración";
					this.rfv_fecha_factura.ErrorMessage = this.lbl_fecha_factura.Text;
					this.rfv_fecha_factura.EnableClientScript = true;

					this.lbl_monto_factura.Text = "Valor Vehículo";
					this.rfv_monto_factura.ErrorMessage = this.lbl_monto_factura.Text;
					this.rfv_monto_factura.Enabled = true;

					this.lbl_notaria_factura.Text = "";
					this.rfv_notaria_factura.ErrorMessage = this.lbl_notaria_factura.Text;
					this.rfv_notaria_factura.Enabled = false;

					this.lbl_ciudad_notaria_factura.Text = "";
					this.rfv_ciudad_notaria_factura.ErrorMessage = this.lbl_ciudad_notaria_factura.Text;
					this.rfv_ciudad_notaria_factura.Enabled = false;

					break;
				case "SIN":
					this.lbl_datos_negocio.Text = "DATOS NEGOCIO SIN RESPALDO";
					this.pnl_datos_negocio.Visible = true;
					this.pnl_emisor.Visible = false;

					this.lbl_factura.Text = "";
					this.rfv_factura.ErrorMessage = this.lbl_factura.Text;
					this.rfv_factura.Enabled = false;

					this.lbl_fecha_factura.Text = "";
					this.rfv_fecha_factura.ErrorMessage = this.lbl_fecha_factura.Text;
					this.rfv_fecha_factura.EnableClientScript = false;

					this.lbl_monto_factura.Text = "Valor Vehículo";
					this.rfv_monto_factura.ErrorMessage = this.lbl_monto_factura.Text;
					this.rfv_monto_factura.Enabled = true;

					this.lbl_notaria_factura.Text = "";
					this.rfv_notaria_factura.ErrorMessage = this.lbl_notaria_factura.Text;
					this.rfv_notaria_factura.Enabled = false;

					this.lbl_ciudad_notaria_factura.Text = "";
					this.rfv_ciudad_notaria_factura.ErrorMessage = this.lbl_ciudad_notaria_factura.Text;
					this.rfv_ciudad_notaria_factura.Enabled = false;

					break;
				default:
					this.lbl_datos_negocio.Text = "";
					this.pnl_datos_negocio.Visible = false;
					this.pnl_emisor.Visible = false;

					this.lbl_factura.Text = "";
					this.rfv_factura.ErrorMessage = this.lbl_factura.Text;
					this.rfv_factura.Enabled = false;

					this.lbl_fecha_factura.Text = "";
					this.rfv_fecha_factura.ErrorMessage = this.lbl_fecha_factura.Text;
					this.rfv_fecha_factura.EnableClientScript = false;

					this.lbl_monto_factura.Text = "";
					this.rfv_monto_factura.ErrorMessage = this.lbl_monto_factura.Text;
					this.rfv_monto_factura.Enabled = false;

					this.lbl_notaria_factura.Text = "";
					this.rfv_notaria_factura.ErrorMessage = this.lbl_notaria_factura.Text;
					this.rfv_notaria_factura.Enabled = false;

					this.lbl_ciudad_notaria_factura.Text = "";
					this.rfv_ciudad_notaria_factura.ErrorMessage = this.lbl_ciudad_notaria_factura.Text;
					this.rfv_ciudad_notaria_factura.Enabled = false;

					break;
			}
		}

		protected void bt_guardar_Click(object sender, EventArgs e)
		{
			this.Add_Operacion();
		}

		protected void bt_limpiar_Click(object sender, EventArgs e)
		{
			Page.Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);
		}

		protected void agp_adquirente_CambioCompraPara(object sender, CambioCompraParaEventArgs e)
		{
			this.agp_compra_para.Visible = e.Activar;
		}

		protected void Add_Operacion()
		{
			if (!this.Validar_Form()) return;

			UpdatePanel up = this.up_negocio;
			if (!this.agp_adquirente.Guardar_Form())
			{
				ScriptManager.RegisterStartupScript(up, up.GetType(), "alert_adquirente", string.Format("alert('{0}');", this.agp_adquirente.MensajeError), true);
				return;
			}
			if (this.agp_compra_para.Visible)
			{
				if (!this.agp_compra_para.Guardar_Form())
				{
					ScriptManager.RegisterStartupScript(up, up.GetType(), "alert_compra_para", string.Format("alert('{0}');", this.agp_compra_para.MensajeError), true);
					return;
				}
			}
			if (this.dl_tipo_doc_fundante.SelectedValue.Trim() == "FACT")
			{
				if (!this.agp_emisor.Guardar_Form())
				{
					ScriptManager.RegisterStartupScript(up, up.GetType(), "alert_emisor", string.Format("alert('{0}');", this.agp_compra_para.MensajeError), true);
					return;
				}
			}

			//Int32 id_solicitud = Convert.ToInt32(ViewState["id_solicitud"]);
			double Adquiriente = this.agp_adquirente.Rut;
			short cliente = Convert.ToInt16(ViewState["id_cliente"]);
			double compra_para = this.agp_compra_para.Rut;
			string creada = "";
			double compra_repre = 0;
			double repertorio = 0;
			double n_factura = Convert.ToDouble(this.txt_factura.Text.Replace(ViewState["separadorMiles"].ToString(), ""));
			string fecha_factura = this.txt_fecha_factura.Text;
			short id_sucursal = Convert.ToInt16(this.dl_sucursal.SelectedValue);
			double emisor = this.agp_emisor.Rut;
			double monto = Convert.ToDouble(this.txt_monto_factura.Text.Replace(ViewState["separadorMiles"].ToString(), ""));
			double n_cuotas = Convert.ToDouble(this.txt_cheques.Text);
			string fecha_primera = this.txt_primera.Text;
			string fecha_ultima = this.txt_ultima.Text;
			string cta_corriente = this.txt_nro_cuenta.Text.Trim();
			string banco = this.dl_banco.SelectedValue.Trim();
			string titular = this.txt_titular_cuenta.Text.Trim().ToUpper();
			string notario = this.txt_notaria_factura.Text;
			string ciudad = this.txt_ciudad_notaria_factura.Text;
			string fecha_contrato = this.txt_fecha_factura.Text;
			double n_cheques = Convert.ToDouble(this.txt_cheques.Text);
			double neto_factura = Convert.ToDouble(this.txt_monto_factura.Text.Replace(ViewState["separadorMiles"].ToString(), ""));
			string tipo_pago_factura = this.dl_forma_pago_factura.SelectedValue;
			double factura_intereses = Convert.ToDouble(this.txt_factura_intereses.Text);
			string fecha_factura_intereses = this.txt_fecha_factura_intereses.Text;
			double monto_factura_intereses = Convert.ToDouble(this.txt_monto_factura_intereses.Text);
			string fecha_protocolizacion = this.txt_fecha_protocolizacion.Text;
            string n_protocolizacion = (this.txt_nro_protocolizacion.Text.Replace(ViewState["separadorMiles"].ToString(), ""));
            string n_RepertorioNotaria = (this.txt_repertorio_protocolizacion.Text.Replace(ViewState["separadorMiles"].ToString(), ""));
            string n_RepertorioRNP = (this.txt_repertorio_rnp.Text.Replace(ViewState["separadorMiles"].ToString(), ""));
			string fecha_repertorio = this.txt_fecha_repertorio_protocolizacion.Text;
			string oficina_Registro = "";
			string ing_alza_PN_registro = "";
			string ing_alza_PH_registro = "";
			string n_solicitud_PN_registro = "";
			string n_solicitud_PH_registro = "";
			string nombreEstado = "";
			string fechaUltimoEstado = "";
			double valor_vehiculo = Convert.ToDouble(this.txt_monto_factura.Text.Replace(ViewState["separadorMiles"].ToString(), ""));
			double monto_pie = Convert.ToDouble(this.txt_pie.Text);
			double factura_gastos = Convert.ToDouble(this.txt_factura_gastos.Text.Replace(ViewState["separadorMiles"].ToString(), ""));
			string fecha_factura_gastos = this.txt_fecha_factura_gastos.Text;
			double monto_factura_gastos = Convert.ToDouble(this.txt_monto_factura_gastos.Text);
			double nro_credito = Convert.ToDouble(this.txt_nro_credito.Text.Trim() != "" ? this.txt_nro_credito.Text.Replace(ViewState["separadorMiles"].ToString(), "") : "0");
			string doc_fundante = this.dl_tipo_doc_fundante.SelectedValue;
			string solicitante = this.txt_solicitante.Text.ToUpper().Trim();
			string notaria_protocolizacion = this.txt_notaria_protocolizacion.Text.Trim();
			string ciudad_notaria_protocolizacion = this.txt_ciudad_notaria_protocolizacion.Text.Trim();
			string fecha_repertorio_rnp = this.txt_fecha_repertorio_rnp.Text;
			string estado_solicitud_rnp = this.dl_estado_rnp.SelectedValue;
			string estado_prenda = this.dl_estado_prenda.SelectedValue;
            string observaciones = "";
			string nro_declaracion = "";
            string fecha_pagare = "";
            int valor_cuotas = 0;
            string tasa = "0";
            int dia = 0;
            int capital_pagare = 0;

            int add = new OperacionBC().add_operacion(Convert.ToInt32(ViewState["id_solicitud"]), cliente, ViewState["tipo_operacion"].ToString(), (string)(Session["usrname"]), 0, nro_credito.ToString().Trim(), Convert.ToInt32(this.dl_sucursal.SelectedValue),0);

			ViewState["id_solicitud"] = add;
			this.lbl_operacion.Visible = true;
			this.lbl_numero.Visible = true;
			this.lbl_numero.Text = add.ToString("N0");

			if (add != 0)
			{
				string output = new GarantiaBC().add_Garantia(add, Adquiriente, cliente, compra_para, creada, compra_repre, repertorio, n_factura, fecha_factura, id_sucursal,
																emisor, monto, n_cuotas, fecha_primera, fecha_ultima, cta_corriente, banco, titular, notario, ciudad, fecha_contrato, n_cheques,
																neto_factura, tipo_pago_factura, factura_intereses, fecha_factura_intereses, monto_factura_intereses, fecha_protocolizacion, n_protocolizacion, n_RepertorioNotaria,
																n_RepertorioRNP, fecha_repertorio, oficina_Registro, ing_alza_PN_registro, ing_alza_PH_registro, n_solicitud_PN_registro, n_solicitud_PH_registro, nombreEstado,
																fechaUltimoEstado, valor_vehiculo, monto_pie, factura_gastos, fecha_factura_gastos, monto_factura_gastos, nro_credito, doc_fundante, solicitante,
                                                                notaria_protocolizacion, ciudad_notaria_protocolizacion, fecha_repertorio_rnp, estado_solicitud_rnp, estado_prenda, observaciones, this.chk_cav.Checked, nro_declaracion, fecha_pagare,
                                                                valor_cuotas, capital_pagare, tasa, dia);
				//Si hay un error guardando la operación
				if (output != "")
				{
					ScriptManager.RegisterStartupScript(up, up.GetType(), "alert_add_garantia", string.Format("alert('{0}');", output), true);
					return;
				}


                //PARA ORDEN DE TRABAJO
                if (IdOrdenTrabajo != 0)
                {
                    FuncionGlobal.UpdateTipoOperacionOrdenTrabajo(ViewState["tipo_operacion"].ToString(), IdOrdenTrabajo, add);
                }
				
                string add_or = "";
				//Si el usuario que crea la operación es de AGP, agrega el estado INGRESO AGP a la operación, marcándola como ingresada
				if (new UsuarioBC().GetUsuario((string)(Session["usrname"])).Cliente.Id_cliente == 1)
				{
					//add_or = new EstadooperacionBC().add_estado_orden(Convert.ToInt32(add), 0, ViewState["tipo_operacion"].ToString(), "Ingresada en AGP", (string)(Session["usrname"]));
					add_or = new EstadooperacionBC().add_estado_orden(Convert.ToInt32(add), 1, ViewState["tipo_operacion"].ToString(), "Ingresada en AGP", (string)(Session["usrname"]));
				}
				//Si el usuario que crea la operación es externo a AGP, el estado inicial de la operación es PREINGRESO
				else
				{
					add_or = new EstadooperacionBC().add_estado_orden(Convert.ToInt32(add), 0, ViewState["tipo_operacion"].ToString(), "Ingresada en sucursal del cliente", (string)(Session["usrname"]));
				}

				if (!this.agp_vehiculo.Guardar_Form(add))
				{
					ScriptManager.RegisterStartupScript(up, up.GetType(), "alert_add_vehiculo", string.Format("alert('{0}');", this.agp_vehiculo.MensajeError), true);
					return;
				}

				ChequesFormaPagoBC cheques = new ChequesFormaPagoBC();
				cheques.del_cheques_operacion(add);
				for (int i = 0; i < this.gr_cheques.Rows.Count; i++)
				{
					int id_cheque;
					string codigo_banco = "";
					string nro_cuenta = "";
					int nro_cheque;
					DateTime fecha_cheque;
					int monto_cheque;

					if (!int.TryParse(this.gr_cheques.Rows[i].Cells[0].Text.Replace(ViewState["separadorMiles"].ToString(), ""), out id_cheque)) id_cheque = i + 1;
					if (!int.TryParse(((TextBox)this.gr_cheques.Rows[i].FindControl("txt_nro_cheque")).Text, out nro_cheque)) nro_cheque = 0;
					if (!DateTime.TryParse(((TextBox)this.gr_cheques.Rows[i].FindControl("txt_fecha_cheque")).Text, out fecha_cheque)) fecha_cheque = DateTime.Now;
					if (!int.TryParse(((TextBox)this.gr_cheques.Rows[i].FindControl("txt_monto_cheque")).Text.Replace(ViewState["separadorMiles"].ToString(), ""), out monto_cheque)) monto_cheque = 0;
					
					cheques.add_cheques_operacion(id_cheque, add, nro_cheque, fecha_cheque, monto_cheque, codigo_banco, nro_cuenta);
				}
				cheques = null;
			}

			this.Busca_Operacion();
		}

		protected bool Validar_Form()
		{
			if (this.txt_factura.Text.Trim() == "") this.txt_factura.Text = "0";

			if (this.txt_pie.Text.Trim() == "") this.txt_pie.Text = "0";
			if (this.txt_cheques.Text.Trim() == "") this.txt_cheques.Text = "0";
			if (this.txt_factura_intereses.Text.Trim() == "") this.txt_factura_intereses.Text = "0";
			if (this.txt_monto_factura_intereses.Text.Trim() == "") this.txt_monto_factura_intereses.Text = "0";
			if (this.txt_monto_financiar.Text.Trim() == "") this.txt_monto_financiar.Text = "0";
			if (this.txt_factura_gastos.Text.Trim() == "") this.txt_factura_gastos.Text = "0";
			if (this.txt_monto_factura_gastos.Text.Trim() == "") this.txt_monto_factura_gastos.Text = "0";

			this.Calcular_Monto_Financiar();

			if (this.dl_forma_pago_factura.SelectedValue == "3")
			{
				int pie = 0;
				int total = 0;
				int cheques = 0;
				int intereses = 0;

                if (!int.TryParse(FuncionGlobal.NumeroConFormato(this.txt_monto_factura.Text), out total)) total = 0;
                if (!int.TryParse(FuncionGlobal.NumeroConFormato(this.txt_pie.Text), out pie)) pie = 0;

                if (!int.TryParse(FuncionGlobal.NumeroConFormato(this.txt_monto_factura_intereses.Text), out intereses)) intereses = 0;
				if (!int.TryParse(((TextBox)this.gr_cheques.FooterRow.FindControl("txt_total_monto_cheque")).Text, out cheques)) cheques = 0;

				if (cheques != total - pie + intereses)
				{
					ScriptManager.RegisterStartupScript(this.up_operacion, this.up_operacion.GetType(), "ErrorPersona", "alert('El monto de los cheques no coincide con el saldo correspondiente');", true);
					((TextBox)this.gr_cheques.FooterRow.FindControl("txt_total_monto_cheque")).Focus();
					return false;
				}
			}

			return true;
		}

		protected void Busca_Operacion()
		{
			Garantia mgarantia = new GarantiaBC().GetgarantiabyIdSolicitud(Convert.ToInt32(ViewState["id_solicitud"]));
			if (mgarantia != null)
			{
				this.Carga_Operacion(mgarantia);
			}
		}

		protected void Busca_Operacion_Por_Factura()
		{
			if (this.txt_factura.Text.Trim() == "") return;
			Int16 id_cliente = Convert.ToInt16(this.dl_cliente.SelectedValue);
			double rut_emisor = this.agp_emisor.Rut;
			double nro_factura = Convert.ToDouble(this.txt_factura.Text);
			Garantia mgarantia = new GarantiaBC().Getgarantiabyfactura(id_cliente, rut_emisor, nro_factura);
			if (mgarantia != null)
			{
				this.Carga_Operacion(mgarantia);
			}
			else
			{
				Cliente cliente_emisor = new ClienteBC().getClientePorRut(rut_emisor);
				if (cliente_emisor != null)
				{
					switch (cliente_emisor.Id_webservice)
					{
						case 1:
							this.GetDatosFacturaWS_AG();
							break;
						case 3:
                            //this.GetDatosFacturaWS_Indumotora();
							break;
						default:
							break;
					}
				}
			}
		}

		protected void Carga_Operacion(Garantia garantia)
		{
			this.lbl_operacion.Visible = true;
			this.lbl_numero.Visible = true;
			this.lbl_numero.Text = garantia.Operacion.Id_solicitud.ToString("N0");

			this.tab_garantia.Visible = true;
			this.rfv_notaria_protocolizacion.Enabled = true;
			this.rfv_ciudad_notaria_protocolizacion.Enabled = true;

			this.dl_sucursal.SelectedValue = garantia.Sucursal_origen.Id_sucursal.ToString();

			this.txt_solicitante.Text = garantia.Solicitante;

			this.dl_tipo_doc_fundante.SelectedValue = garantia.Doc_fundante.Trim();
			this.Cambio_Documento_Fundante();
			this.pnl_tipo_doc_fundante.Visible = true;

			switch (this.dl_tipo_doc_fundante.SelectedValue)
			{
				case "FACT":
					if (garantia.Emisor != null) this.agp_emisor.Mostrar_Form(garantia.Emisor.Rut);
					this.txt_factura.Text = garantia.N_factura.ToString("N0");
					this.txt_fecha_factura.Text = Convert.ToDateTime(garantia.Fechafactura).ToShortDateString();
					this.txt_monto_factura.Text = garantia.Monto.ToString("N0");
					break;
				case "CONT":
					this.txt_fecha_factura.Text = Convert.ToDateTime(garantia.Fechafactura).ToShortDateString();
					this.txt_monto_factura.Text = garantia.Monto.ToString("N0");
					this.txt_notaria_factura.Text = garantia.Notario;
					this.txt_ciudad_notaria_factura.Text = garantia.Ciudad_notario;
					break;
				case "DECL":
					this.txt_factura.Text = garantia.N_factura.ToString("N0");
					this.txt_fecha_factura.Text = Convert.ToDateTime(garantia.Fechafactura).ToShortDateString();
					this.txt_monto_factura.Text = garantia.Monto.ToString("N0");
					break;
				case "SIN":
					this.txt_monto_factura.Text = garantia.Monto.ToString("N0");
					break;
				default:
					break;
			}

			this.dl_forma_pago_factura.SelectedValue = garantia.Tipo_pago_factura.Trim();
			this.txt_nro_credito.Text = garantia.Nro_credito.ToString("N0");
			if (this.dl_forma_pago_factura.SelectedValue == "2")
			{
				this.rfv_nro_credito.Enabled = true;
				this.lbl_cheques.Text = "Nº Cuotas";
				this.txt_cheques.Text = garantia.N_cheques.ToString();
				this.lbl_primera.Text = "Fecha Primera Cuota";
				this.txt_primera.Text = Convert.ToDateTime(garantia.Fecha_primera).ToShortDateString();
				this.lbl_ultima.Text = "Fecha Última Cuota";
				this.txt_ultima.Text = Convert.ToDateTime(garantia.Fecha_ultima).ToShortDateString();
				this.pnl_cheques.Visible = true;
				this.pnl_grilla_cheques.Visible = false;
			}
			else if (this.dl_forma_pago_factura.SelectedValue == "3")
			{
				this.rfv_nro_credito.Enabled = false;
				this.lbl_cheques.Text = "Nº Cheques";
				this.txt_cheques.Text = garantia.N_cheques.ToString();
				this.lbl_primera.Text = "Fecha Primer Cheque";
				this.txt_primera.Text = Convert.ToDateTime(garantia.Fecha_primera).ToShortDateString();
				this.lbl_ultima.Text = "Fecha Último Cheque";
				this.txt_ultima.Text = Convert.ToDateTime(garantia.Fecha_ultima).ToShortDateString();
				this.pnl_grilla_cheques.Visible = true;
				this.pnl_cheques.Visible = true;

				FuncionGlobal.BuscarValueCombo(this.dl_banco, garantia.Bancofinanciera);
				this.txt_nro_cuenta.Text = garantia.Cta_corriente;
				this.txt_titular_cuenta.Text = garantia.Titular;

				if (!this.Mostrar_Cheques(garantia.Operacion.Id_solicitud))
				{
					this.Crear_Cheques(Convert.ToInt32(garantia.N_cheques), Convert.ToDateTime(garantia.Fecha_primera));
				}
			}
			else
			{
				this.rfv_nro_credito.Enabled = false;
				this.lbl_cheques.Text = "";
				this.txt_cheques.Text = "";
				this.lbl_primera.Text = "";
				this.txt_primera.Text = "";
				this.lbl_ultima.Text = "";
				this.txt_ultima.Text = "";
				this.pnl_cheques.Visible = false;
				this.pnl_grilla_cheques.Visible = false;
			}

			DateTime fecha;

			this.txt_pie.Text = garantia.Monto_pie.ToString("N0");

			this.txt_factura_gastos.Text = garantia.Factura_gastos.ToString("N0");
			if (DateTime.TryParse(garantia.Fecha_factura_gastos, out fecha))
				this.txt_fecha_factura_gastos.Text = fecha.ToShortDateString();
			else
				this.txt_fecha_factura_gastos.Text = "";
			this.txt_monto_factura_gastos.Text = garantia.Monto_factura_gastos.ToString("N0");

			this.txt_factura_intereses.Text = garantia.Factura_intereses.ToString("N0");
			if (DateTime.TryParse(garantia.Fecha_factura_intereses, out fecha))
				this.txt_fecha_factura_intereses.Text = fecha.ToShortDateString();
			else
				this.txt_fecha_factura_intereses.Text = "";
			this.txt_monto_factura_intereses.Text = garantia.Monto_factura_intereses.ToString("N0");

			this.txt_monto_financiar.Text = garantia.Valor_vehiculo.ToString("N0");

			//this.Calcular_Monto_Financiar();

			this.agp_vehiculo.Mostrar_Form(garantia.Operacion.Id_solicitud);
			this.agp_adquirente.Mostrar_Form(garantia.Adquiriente.Rut);
			if (garantia.Compra_para != null)
			{
				if (garantia.Compra_para.Rut != 0)
				{
					this.agp_compra_para.Visible = true;
					this.agp_compra_para.Mostrar_Form(garantia.Compra_para.Rut);
					this.agp_adquirente.CompraPara = true;
				}
			}

			if(garantia.Notaria_protocolizacion.Trim()=="")
				this.txt_notaria_protocolizacion.Text = "MARÍA GLORIA ACHARAN TOLEDO";
			else
				this.txt_notaria_protocolizacion.Text = garantia.Notaria_protocolizacion.ToUpper().Trim();

			if (garantia.Ciudad_notaria_protocolizacion.Trim() == "")
				this.txt_ciudad_notaria_protocolizacion.Text = "SANTIAGO";
			else
				this.txt_ciudad_notaria_protocolizacion.Text = garantia.Ciudad_notaria_protocolizacion.ToUpper().Trim();

			this.txt_nro_protocolizacion.Text = garantia.N_protocolizacion;
			if (DateTime.TryParse(garantia.Fecha_protocolizacion, out fecha))
				this.txt_fecha_protocolizacion.Text = fecha.ToShortDateString();
			else
				this.txt_fecha_protocolizacion.Text = "";
			this.txt_repertorio_protocolizacion.Text = garantia.N_RepertorioNotaria;

			if (DateTime.TryParse(garantia.Fecha_repertorio, out fecha))
				this.txt_fecha_repertorio_protocolizacion.Text = fecha.ToShortDateString();
			else
				this.txt_fecha_repertorio_protocolizacion.Text = "";

			this.txt_repertorio_rnp.Text = garantia.N_RepertorioRNP;
			if (DateTime.TryParse(garantia.Fecha_repertorio_rnp, out fecha))
				this.txt_fecha_repertorio_rnp.Text = fecha.ToShortDateString();
			else
				this.txt_fecha_repertorio_rnp.Text = "";

			FuncionGlobal.BuscarTextoCombo(this.dl_estado_rnp, garantia.Estado_solicitud_rnp.Trim());
			FuncionGlobal.BuscarTextoCombo(this.dl_estado_prenda, garantia.Estado_prenda.Trim());

			this.chk_cav.Checked = garantia.Cav_comprado;
		}

		protected void Cambiar_Titulo()
		{
			this.lbl_titulo.Text = new TipooperacionBC().getTipooperacion(ViewState["tipo_operacion"].ToString()).Operacion;
		}

		protected void BuscarClienteVendedor()
		{
			Cliente c = new ClienteBC().getcliente(Convert.ToInt16(this.dl_cliente.SelectedValue));
			this.agp_emisor.Rut = c.Persona.Rut;
		}

		protected void dl_forma_pago_factura_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.txt_nro_credito.Text = "0";
			if (this.dl_forma_pago_factura.SelectedValue == "2")
			{
				this.rfv_nro_credito.Enabled = true;
				this.rfv_nro_credito2.Enabled = true;
				this.lbl_cheques.Text = "Nº Cuotas";
				this.txt_cheques.Text = "";
				this.lbl_primera.Text = "Fecha Primera Cuota";
				this.txt_primera.Text = "";
				this.lbl_ultima.Text = "Fecha Última Cuota";
				this.txt_ultima.Text = "";
				this.pnl_cheques.Visible = true;
				this.pnl_grilla_cheques.Visible = false;
			}
			else if (this.dl_forma_pago_factura.SelectedValue == "3")
			{
				this.rfv_nro_credito.Enabled = false;
				this.rfv_nro_credito2.Enabled = false;
				this.lbl_cheques.Text = "Nº Cheques";
				this.txt_cheques.Text = "";
				this.lbl_primera.Text = "Fecha Primer Cheque";
				this.txt_primera.Text = "";
				this.lbl_ultima.Text = "Fecha Último Cheque";
				this.txt_ultima.Text = "";
				this.pnl_cheques.Visible = true;
				this.pnl_grilla_cheques.Visible = true;
			}
			else
			{
				this.rfv_nro_credito.Enabled = false;
				this.rfv_nro_credito2.Enabled = false;
				this.rfv_nro_credito.Enabled = false;
				this.lbl_cheques.Text = "";
				this.txt_cheques.Text = "";
				this.lbl_primera.Text = "";
				this.txt_primera.Text = "";
				this.lbl_ultima.Text = "";
				this.txt_ultima.Text = "";
				this.pnl_cheques.Visible = false;
				this.pnl_grilla_cheques.Visible = false;
			}
		}

		protected void txt_cheques_TextChanged(object sender, EventArgs e)
		{
			if (this.txt_primera.Text != "" && this.txt_cheques.Text != "")
				this.txt_ultima.Text = string.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(this.txt_primera.Text).AddMonths(Convert.ToInt32(this.txt_cheques.Text) - 1));

			if (this.dl_forma_pago_factura.SelectedValue == "3" && this.txt_cheques.Text.Trim() != "")
				this.Crear_Cheques(Convert.ToInt32(this.txt_cheques.Text));
		}

		protected void txt_primera_TextChanged(object sender, EventArgs e)
		{
			if (this.txt_primera.Text != "" && this.txt_cheques.Text != "")
				this.txt_ultima.Text = string.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(this.txt_primera.Text).AddMonths(Convert.ToInt32(this.txt_cheques.Text) - 1));

			if (this.dl_forma_pago_factura.SelectedValue == "3" && this.txt_cheques.Text.Trim() != "" && this.txt_primera.Text != "")
				this.Crear_Cheques(Convert.ToInt32(this.txt_cheques.Text), Convert.ToDateTime(this.txt_primera.Text));
		}

		protected void txt_factura_intereses_TextChanged(object sender, EventArgs e)
		{
			if (this.txt_factura_intereses.Text != "")
			{
				int valor = Convert.ToInt32(this.txt_factura_intereses.Text.Replace(ViewState["separadorMiles"].ToString(), ""));
				this.txt_factura_intereses.Text = valor.ToString("N0");
			}
		}

		//protected void txt_monto_factura_intereses_TextChanged(object sender, EventArgs e)
		//{
		//    if (this.txt_monto_factura_intereses.Text != "")
		//    {
		//        int valor = Convert.ToInt32(this.txt_monto_factura_intereses.Text.Replace(ViewState["separadorMiles"].ToString(), ""));
		//        this.txt_monto_factura_intereses.Text = valor.ToString("N0");
		//    }
		//    this.Calcular_Monto_Financiar();
		//}

		protected void txt_factura_gastos_TextChanged(object sender, EventArgs e)
		{
			if (this.txt_factura_gastos.Text != "")
			{
				int valor = Convert.ToInt32(this.txt_factura_gastos.Text.Replace(ViewState["separadorMiles"].ToString(), ""));
				this.txt_factura_gastos.Text = valor.ToString("N0");
			}
		}

		protected void txt_monto_factura_gastos_TextChanged(object sender, EventArgs e)
		{
			if (this.txt_monto_factura_gastos.Text != "")
			{
				int valor = Convert.ToInt32(this.txt_monto_factura_gastos.Text.Replace(ViewState["separadorMiles"].ToString(), ""));
				this.txt_monto_factura_gastos.Text = valor.ToString("N0");
			}
		}

		protected void gr_cheques_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				((ImageButton)e.Row.FindControl("btn_nro_cheque")).CommandArgument = e.Row.RowIndex.ToString();
				((ImageButton)e.Row.FindControl("btn_monto_cheque")).CommandArgument = e.Row.RowIndex.ToString();
				((ImageButton)e.Row.FindControl("btn_fecha_cheque")).CommandArgument = e.Row.RowIndex.ToString();
			}
		}

		protected void btn_nro_cheque_Click(object sender, ImageClickEventArgs e)
		{
			ImageButton btn = (ImageButton)sender;
			int index;
			int valor;
			index = Convert.ToInt32(btn.CommandArgument);
			if (int.TryParse(((TextBox)this.gr_cheques.Rows[index].FindControl("txt_nro_cheque")).Text, out valor))
			{
				valor++;
				for (int i = index + 1; i < this.gr_cheques.Rows.Count; i++, valor++)
					((TextBox)this.gr_cheques.Rows[i].FindControl("txt_nro_cheque")).Text = valor.ToString();
			}
		}

		protected void btn_fecha_cheque_Click(object sender, ImageClickEventArgs e)
		{
			ImageButton btn = (ImageButton)sender;
			int index;
			DateTime valor;
			index = Convert.ToInt32(btn.CommandArgument);
			if (DateTime.TryParse(((TextBox)this.gr_cheques.Rows[index].FindControl("txt_fecha_cheque")).Text, out valor))
			{
				for (int i = index + 1; i < this.gr_cheques.Rows.Count; i++, valor = valor.AddMonths(1))
					((TextBox)this.gr_cheques.Rows[i].FindControl("txt_fecha_cheque")).Text = valor.ToShortDateString();
			}
		}

		protected void btn_monto_cheque_Click(object sender, ImageClickEventArgs e)
		{
			ImageButton btn = (ImageButton)sender;
			int index;
			int valor;
			int suma = 0;
			index = Convert.ToInt32(btn.CommandArgument);
			if (int.TryParse(((TextBox)this.gr_cheques.Rows[index].FindControl("txt_monto_cheque")).Text.Replace(ViewState["separadorMiles"].ToString(), ""), out valor))
			{
				suma += valor;
				for (int i = index + 1; i < this.gr_cheques.Rows.Count; i++)
				{
					((TextBox)this.gr_cheques.Rows[i].FindControl("txt_monto_cheque")).Text = valor.ToString("N0");
					suma += valor;
				}
			}
			((TextBox)this.gr_cheques.FooterRow.FindControl("txt_total_monto_cheque")).Text = suma.ToString("N0");
		}

		protected void txt_monto_cheque_TextChanged(object sender, EventArgs e)
		{
			TextBox txt_monto = (TextBox)sender;
			TextBox txt_total = ((TextBox)this.gr_cheques.FooterRow.FindControl("txt_total_monto_cheque"));
			HiddenField hdn_monto = ((HiddenField)this.gr_cheques.Rows[((GridViewRow)txt_monto.Parent.Parent).RowIndex].FindControl("hdn_monto_cheque"));
			if (txt_monto.Text != "")
			{
				int valor = Convert.ToInt32(txt_monto.Text.Replace(ViewState["separadorMiles"].ToString(), ""));
				int old = hdn_monto.Value == "" ? 0 : Convert.ToInt32(hdn_monto.Value.Replace(ViewState["separadorMiles"].ToString(), ""));
				int total = Convert.ToInt32(txt_total.Text.Replace(ViewState["separadorMiles"].ToString(), ""));
				total = total - old + valor;

				txt_monto.Text = valor.ToString("N0");
				hdn_monto.Value = valor.ToString("N0");
				txt_total.Text = total.ToString("N0");
			}
		}

		public bool Mostrar_Cheques(int id_solicitud)
		{
			List<ChequesFormaPago> lcheques = new ChequesFormaPagoBC().get_cheques_operacion(id_solicitud);
			if (lcheques.Count > 0)
			{
				int suma = 0;
				DataTable dt = new DataTable();
				dt.Columns.Add("id_cheque");
				dt.Columns.Add("nro_cheque");
				dt.Columns.Add("fecha_cheque");
				dt.Columns.Add("monto_cheque");
				foreach (ChequesFormaPago cheque in lcheques)
				{
					DataRow dr = dt.NewRow();
					dr["id_cheque"] = cheque.Id_cheque;
					dr["nro_cheque"] = cheque.Nro_cheque.ToString();
					dr["fecha_cheque"] = cheque.Fecha_cheque.ToShortDateString();
					dr["monto_cheque"] = cheque.Monto_cheque.ToString("N0");
					dt.Rows.Add(dr);
					suma += cheque.Monto_cheque;
				}
				this.gr_cheques.DataSource = dt;
				this.gr_cheques.DataBind();
				if (this.gr_cheques.Rows.Count > 0)
				{
					((TextBox)this.gr_cheques.FooterRow.FindControl("txt_total_monto_cheque")).Text = suma.ToString("N0");
				}
				return true;
			}
			else
			{
				return false;
			}
		}

		public void Crear_Cheques(int nro_cheques)
		{
			DataTable dt = new DataTable();
			dt.Columns.Add("id_cheque");
			dt.Columns.Add("nro_cheque");
			dt.Columns.Add("fecha_cheque");
			dt.Columns.Add("monto_cheque");
			for (int i = 1; i <= nro_cheques; i++)
			{
				DataRow dr = dt.NewRow();
				dr["id_cheque"] = i;
				dr["nro_cheque"] = "";
				dr["fecha_cheque"] = "";
				dr["monto_cheque"] = 0;
				dt.Rows.Add(dr);
			}
			this.gr_cheques.DataSource = dt;
			this.gr_cheques.DataBind();
			if (this.gr_cheques.Rows.Count > 0)
			{
				((TextBox)this.gr_cheques.FooterRow.FindControl("txt_total_monto_cheque")).Text = "0";
			}
		}

		public void Crear_Cheques(int nro_cheques, DateTime fecha_inicio)
		{
			if (this.gr_cheques.Rows.Count > 0)
			{
				for (int i = 0; i < this.gr_cheques.Rows.Count; i++)
					((TextBox)this.gr_cheques.Rows[i].FindControl("txt_fecha_cheque")).Text = fecha_inicio.AddMonths(i).ToShortDateString();
			}
			else
			{
				DataTable dt = new DataTable();
				dt.Columns.Add("id_cheque");
				dt.Columns.Add("nro_cheque");
				dt.Columns.Add("fecha_cheque");
				dt.Columns.Add("monto_cheque");
				for (int i = 1; i <= nro_cheques; i++)
				{
					DataRow dr = dt.NewRow();
					dr["id_cheque"] = i;
					dr["nro_cheque"] = "";
					dr["fecha_cheque"] = fecha_inicio.AddMonths(i - 1).ToShortDateString();
					dr["monto_cheque"] = 0;
					dt.Rows.Add(dr);
				}
				this.gr_cheques.DataSource = dt;
				this.gr_cheques.DataBind();
			}
			if (this.gr_cheques.Rows.Count > 0)
			{
				((TextBox)this.gr_cheques.FooterRow.FindControl("txt_total_monto_cheque")).Text = "0";
			}
		}

		protected void Calcular_Monto_Financiar()
		{
			if (this.txt_monto_factura_intereses.Text.Trim() == "") this.txt_monto_factura_intereses.Text = "0";
			if (this.txt_pie.Text.Trim() == "") this.txt_pie.Text = "0";
			if (this.txt_monto_factura.Text.Trim() == "") this.txt_monto_factura.Text = "0";

			int vehiculo = Convert.ToInt32(this.txt_monto_factura.Text.Replace(ViewState["separadorMiles"].ToString(), ""));
			int intereses = Convert.ToInt32(this.txt_monto_factura_intereses.Text.Replace(ViewState["separadorMiles"].ToString(), ""));
			int pie = Convert.ToInt32(this.txt_pie.Text.Replace(ViewState["separadorMiles"].ToString(), ""));

			this.txt_monto_financiar.Text = (vehiculo + intereses - pie).ToString("N0");
		}

		protected void GetDatosFacturaWS_AG()
		{
			if (this.txt_factura.Text.Trim() == "") return;
			System.Net.ServicePointManager.Expect100Continue = false;
			WSIntegracionAGPSoapClient ws = new WSIntegracionAGPSoapClient();
			try
			{
                XElement xDoc;

                try
                {
                     xDoc = XElement.Parse(ws.GetFacturaPorNumero(ConfigurationManager.AppSettings["wsag_user"], ConfigurationManager.AppSettings["wsag_pass"], Convert.ToInt64(this.txt_factura.Text.Replace(ViewState["separadorMiles"].ToString(), ""))));

                }

                catch
                {
                    return;
                }


                    var query = (from f in xDoc.Descendants("factura")
							 select new
							 {
								 datosFactura = new
								 {
									 numeroFactura = (f.Element("datosFactura") != null) ? f.Element("datosFactura").Element("numeroFactura").Value : "",
									 tipoCliente = (f.Element("datosFactura") != null) ? f.Element("datosFactura").Element("tipoCliente").Value : "",
									 codigoSucursal = (f.Element("datosFactura") != null) ? f.Element("datosFactura").Element("codigoSucursal").Value : "",
									 descripSucursal = (f.Element("datosFactura") != null) ? f.Element("datosFactura").Element("descripSucursal").Value : "",
									 fechaFactura = (f.Element("datosFactura") != null) ? f.Element("datosFactura").Element("fechaFactura").Value : "",
									 netoFactura = (f.Element("datosFactura") != null) ? f.Element("datosFactura").Element("netoFactura").Value : "",
									 financiera = (f.Element("datosFactura") != null) ? f.Element("datosFactura").Element("financiera").Value : ""
								 },
								 datosAdquirente = new
								 {
									 rut = (f.Element("datosAdquiriente") != null) ? f.Element("datosAdquiriente").Element("rut").Value : "",
									 dv = (f.Element("datosAdquiriente") != null) ? f.Element("datosAdquiriente").Element("dv").Value : "",
									 nombre = (f.Element("datosAdquiriente") != null) ? f.Element("datosAdquiriente").Element("nombre").Value : "",
									 paterno = (f.Element("datosAdquiriente") != null) ? f.Element("datosAdquiriente").Element("paterno").Value : "",
									 materno = (f.Element("datosAdquiriente") != null) ? f.Element("datosAdquiriente").Element("materno").Value : "",
									 direccion = (f.Element("datosAdquiriente") != null) ? f.Element("datosAdquiriente").Element("direccion").Value : "",
									 numero = (f.Element("datosAdquiriente") != null) ? f.Element("datosAdquiriente").Element("numero").Value : "",
									 depto = (f.Element("datosAdquiriente") != null) ? f.Element("datosAdquiriente").Element("depto").Value : "",
									 region = (f.Element("datosAdquiriente") != null) ? f.Element("datosAdquiriente").Element("region").Value : "",
									 ciudad = (f.Element("datosAdquiriente") != null) ? f.Element("datosAdquiriente").Element("ciudad").Value : "",
									 comuna = (f.Element("datosAdquiriente") != null) ? f.Element("datosAdquiriente").Element("comuna").Value : "",
									 fono = (f.Element("datosAdquiriente") != null) ? f.Element("datosAdquiriente").Element("fono").Value : ""
								 },
								 datosVehiculo = new
								 {
									 tipoVehiculo = (f.Element("datosVehiculo") != null) ? f.Element("datosVehiculo").Element("tipoVehiculo").Value : "",
									 marca = (f.Element("datosVehiculo") != null) ? f.Element("datosVehiculo").Element("marca").Value : "",
									 codigoModelo = (f.Element("datosVehiculo") != null) ? f.Element("datosVehiculo").Element("codigoModelo").Value : "",
									 descripModelo = (f.Element("datosVehiculo") != null) ? f.Element("datosVehiculo").Element("descripModelo").Value : "",
									 vin = (f.Element("datosVehiculo") != null) ? f.Element("datosVehiculo").Element("vin").Value : "",
									 chasis = (f.Element("datosVehiculo") != null) ? f.Element("datosVehiculo").Element("vin").Value : "",
									 anio = (f.Element("datosVehiculo") != null) ? f.Element("datosVehiculo").Element("anio").Value : "",
									 motor = (f.Element("datosVehiculo") != null) ? f.Element("datosVehiculo").Element("motor").Value : "",
									 cilindraje = (f.Element("datosVehiculo") != null) ? f.Element("datosVehiculo").Element("cilindraje").Value : "",
									 color = (f.Element("datosVehiculo") != null) ? f.Element("datosVehiculo").Element("color").Value : "",
									 carga = (f.Element("datosVehiculo") != null) ? f.Element("datosVehiculo").Element("carga").Value : "",
									 pesoBruto = (f.Element("datosVehiculo") != null) ? f.Element("datosVehiculo").Element("pesoBruto").Value : "",
									 combustible = (f.Element("datosVehiculo") != null) ? f.Element("datosVehiculo").Element("combustible").Value : "",
									 numeroPuertas = (f.Element("datosVehiculo") != null) ? f.Element("datosVehiculo").Element("numeroPuertas").Value : "",
									 numeroAsientos = (f.Element("datosVehiculo") != null) ? f.Element("datosVehiculo").Element("numeroAsientos").Value : ""
								 }
							 }).FirstOrDefault();
				if (query != null)
				{
					double num;
					// Carga datos de la factura
					string[] aux = query.datosFactura.fechaFactura.Trim().Substring(0, query.datosFactura.fechaFactura.Trim().IndexOf(" ")).Split('/');
					this.txt_fecha_factura.Text = string.Format("{0:dd/MM/yyyy}", DateTime.Parse(aux[2] + "-" + aux[0] + "-" + aux[1]));
					if (double.TryParse(query.datosFactura.netoFactura.Replace(".", ","), out num))
					{
                        this.txt_monto_factura.Text = (Convert.ToInt64(num)*1.19).ToString("N0");
					}

					// Carga datos del vehículo
					this.agp_vehiculo.TipoVehiculo = query.datosVehiculo.tipoVehiculo.Trim();
					this.agp_vehiculo.Marca = query.datosVehiculo.marca.Trim();
					this.agp_vehiculo.Modelo = query.datosVehiculo.descripModelo.Trim();
					this.agp_vehiculo.Anio = query.datosVehiculo.anio.Trim();
					this.agp_vehiculo.Cilindrada = query.datosVehiculo.cilindraje.Trim();
					this.agp_vehiculo.Puertas = query.datosVehiculo.numeroPuertas.Trim();
					this.agp_vehiculo.Asientos = query.datosVehiculo.numeroAsientos.Trim();
					this.agp_vehiculo.PesoBruto = query.datosVehiculo.pesoBruto.Trim();
					this.agp_vehiculo.PesoCarga = query.datosVehiculo.carga.Trim();
					this.agp_vehiculo.Combustible = query.datosVehiculo.combustible.Trim();
					this.agp_vehiculo.Color = query.datosVehiculo.color.Trim();
					this.agp_vehiculo.Motor = query.datosVehiculo.motor.Trim();
					this.agp_vehiculo.Chasis = query.datosVehiculo.chasis.Trim();
					this.agp_vehiculo.Serie = "";
					//this.agp_vehiculo.setVin(query.datosVehiculo.vin.Trim());

					// Carga datos del negocio
					FuncionGlobal.BuscarValueCombo(this.dl_sucursal, new SucursalclienteBC().getSucursalParidadAG(query.datosFactura.codigoSucursal.Trim()).Id_sucursal.ToString());

					// Carga datos del adquirente
					if (new PersonaBC().getpersonabyrut(Convert.ToDouble(query.datosAdquirente.rut)) == null)
					{
						this.agp_adquirente.Rut = Convert.ToDouble(query.datosAdquirente.rut);
						this.agp_adquirente.DV = query.datosAdquirente.dv.ToUpper().Trim();
						this.agp_adquirente.Nombre = query.datosAdquirente.nombre.ToUpper().Trim();
						this.agp_adquirente.Paterno = query.datosAdquirente.paterno.ToUpper().Trim();
						this.agp_adquirente.Materno = query.datosAdquirente.materno.ToUpper().Trim();
					}
					else
					{
						this.agp_adquirente.Mostrar_Form(Convert.ToDouble(query.datosAdquirente.rut));
					}
				}
			}
			finally
			{
				ws.Close();
			}
		}

        //protected void GetDatosFacturaWS_Indumotora()
        //{
        //    if (this.txt_factura.Text.Trim() == "") return;
        //    System.Net.ServicePointManager.Expect100Continue = false;
        //    WService_agp_autoproSoapClient ws = new WService_agp_autoproSoapClient();
        //    try
        //    {
        //        ws.Open();
        //        Respuesta resp = ws.Integra_Agp(this.agp_emisor.Rut.ToString().Trim() + this.agp_emisor.DV.Trim().ToUpper(), this.txt_factura.Text.Trim().Replace(ViewState["separadorMiles"].ToString(), ""));
        //        XElement doc = resp.DatosRespuesta;
        //        if (doc != null)
        //        {
        //            string texto = doc.ToString();
        //        }
        //        else
        //        {
        //            FuncionGlobal.alerta_updatepanel(resp.Descripcion, this, this.up_negocio);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        FuncionGlobal.alerta_updatepanel(ex.Message, this, this.up_negocio);
        //    }
        //    finally
        //    {
        //        ws.Close();
        //    }
        //}

        protected void RegistrarCalcularMontoFinanciar()
        {

            string funcion = "";
            funcion += "function calcularMontoFinanciar() {\n";
            funcion += "\tvar vehiculo = document.getElementById('" + this.txt_monto_factura.ClientID + "').value.replace(/\\./g, '');\n";
            funcion += "\tvar intereses = document.getElementById('" + this.txt_monto_factura_intereses.ClientID + "').value.replace(/\\./g, '');\n";

            funcion += "\tif(document.getElementById('" + this.txt_pie.ClientID + "') != undefined ){\tvar pie = document.getElementById('" + this.txt_pie.ClientID + "').value.replace(/\\./g, ''); \n }\n";
            funcion += "\telse{  var pie = 0; }\n";

            funcion += "\tvar monto = ((!isNaN(vehiculo)) ? parseInt(vehiculo) : 0) + ((!isNaN(intereses)) ? parseInt(intereses) : 0) - ((!isNaN(pie)) ? parseInt(pie) : 0);\n";
            funcion += "\tmonto = monto.toString().split('').reverse().join('').replace(/(?=\\d*\\.?)(\\d{3})/g, '$1.');\n";
            funcion += "\tmonto = monto.split('').reverse().join('').replace(/^[\\.]/, '');\n";
            funcion += "\tdocument.getElementById('" + this.txt_monto_financiar.ClientID + "').value = monto;\n";
            funcion += "}";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Montofinanciar", funcion, true);
        }

        protected void txt_monto_factura_TextChanged1(object sender, EventArgs e)
        {

        }

        
    }
}