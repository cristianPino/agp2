using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CENTIDAD;
using CNEGOCIO;

namespace sistemaAGP
{
	public partial class Ingreso_garantia_amicar : System.Web.UI.Page
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

				this.Cambiar_Titulo();

				FuncionGlobal.comboclientesbyusuario((string)(Session["usrname"]), this.dl_cliente);
				this.dl_cliente.SelectedValue = ViewState["id_cliente"].ToString();
				FuncionGlobal.combosucursalbyclienteandUsuario(this.dl_sucursal, Convert.ToInt16(this.dl_cliente.SelectedValue), (string)(Session["usrname"]));

				if (this.dl_sucursal.Items.Count == 2)
				{
					this.dl_sucursal.SelectedIndex = 1;
				}

				FuncionGlobal.comboparametro(this.dl_tipo_doc_fundante, "DOCFUN");
				this.dl_tipo_doc_fundante.SelectedValue = "SIN";
				this.dl_tipo_doc_fundante.Enabled = true;
				this.Cambio_Documento_Fundante();
				this.pnl_tipo_doc_fundante.Visible = true;

				FuncionGlobal.comboparametro(this.dl_forma_pago_factura, "FOPA");
				this.dl_forma_pago_factura.SelectedValue = "2";
				this.dl_forma_pago_factura.Enabled = false;

				FuncionGlobal.comboparametro(this.dl_estado_rnp, "EDORNP");
				FuncionGlobal.comboparametro(this.dl_estado_prenda, "EDOGARA");

				this.tab_garantia.Visible = false;
				this.rfv_notaria_protocolizacion.Enabled = false;
				this.rfv_ciudad_notaria_protocolizacion.Enabled = false;

				this.txt_notaria_protocolizacion.Text = "MARÍA GLORIA ACHARAN TOLEDO";
				this.txt_ciudad_notaria_protocolizacion.Text = "SANTIAGO";

				this.Busca_Operacion();

                if (Convert.ToInt32(ViewState["id_solicitud"].ToString()) == 0)
                {
                    this.tab_vehiculo.Visible = false;

                }
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
			}
		}

		protected void txt_monto_factura_TextChanged(object sender, EventArgs e)
		{
			if (this.txt_monto_factura.Text != "")
			{
				int valor = Convert.ToInt32(this.txt_monto_factura.Text.Replace(ViewState["separadorMiles"].ToString(), ""));
				this.txt_monto_factura.Text = valor.ToString("N0");
			}
		}

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

			Int32 id_solicitud = Convert.ToInt32(ViewState["id_solicitud"]);
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
			double n_cuotas = 0;
			string fecha_primera = "";
			string fecha_ultima = this.txt_ultima.Text;
			string cta_corriente = "";
			string banco = "";
			string titular = "";
			string notario = this.txt_notaria_factura.Text;
			string ciudad = this.txt_ciudad_notaria_factura.Text;
			string fecha_contrato = this.txt_fecha_factura.Text;
			double n_cheques = 0;
			double neto_factura = Convert.ToDouble(this.txt_monto_factura.Text.Replace(ViewState["separadorMiles"].ToString(), ""));
			string tipo_pago_factura = this.dl_forma_pago_factura.SelectedValue;
			double factura_intereses = 0;
			string fecha_factura_intereses = "";
			double monto_factura_intereses = 0;
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
			double monto_pie = 0;
			double factura_gastos = 0;
			string fecha_factura_gastos = "";
			double monto_factura_gastos = 0;
			double nro_credito = Convert.ToDouble(this.txt_nro_credito.Text.Replace(ViewState["separadorMiles"].ToString(), ""));
			string doc_fundante = this.dl_tipo_doc_fundante.SelectedValue;
			string solicitante = "";
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

            int add = new OperacionBC().add_operacion(id_solicitud, cliente, ViewState["tipo_operacion"].ToString(), (string)(Session["usrname"]), 0, nro_credito.ToString().Trim(), Convert.ToInt32(this.dl_sucursal.SelectedValue),0);

			ViewState["id_solicitud"] = add.ToString();
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

				string add_or = new EstadooperacionBC().add_estado_orden(Convert.ToInt32(add), 1, ViewState["tipo_operacion"].ToString(), "", (string)(Session["usrname"]));




                if (this.tab_vehiculo.Visible == true)
                {
                    if (!this.agp_vehiculo.Guardar_Form(add))
                    {
                        ScriptManager.RegisterStartupScript(up, up.GetType(), "alert_add_vehiculo", string.Format("alert('{0}');", this.agp_vehiculo.MensajeError), true);
                        return;
                    }
                }
				this.Busca_Operacion();
			}
		}

		protected bool Validar_Form()
		{
			if (this.txt_factura.Text.Trim() == "") this.txt_factura.Text = "0";
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
			this.dl_forma_pago_factura.Enabled = false;
			this.txt_nro_credito.Text = garantia.Nro_credito.ToString("N0");

			DateTime fecha;

			if (DateTime.TryParse(garantia.Fecha_ultima, out fecha))
				this.txt_ultima.Text = fecha.ToShortDateString();
			else
				this.txt_ultima.Text = "";

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

			this.txt_notaria_protocolizacion.Text = garantia.Notaria_protocolizacion;
			this.txt_ciudad_notaria_protocolizacion.Text = garantia.Ciudad_notaria_protocolizacion;
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
	}
}