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
	public partial class Alzamiento_18112 : System.Web.UI.Page
    {
        public enum Cliente
        {
            Scotiabank = 19,
            Bice = 14,
            Bk = 58
        }
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

                if (IdOrdenTrabajo != 0)
                {
                    var otra = new OrdenTrabajoBC().GetOrdenTrabajo(IdOrdenTrabajo);

                    if (otra.IdCliente == (int) Cliente.Bk || otra.IdCliente == (int) Cliente.Bice)
                    {
                        this.txt_nro_credito.Text = otra.NumeroOrden.Trim();
                    }

                    agp_vehiculo.OrdenTrabajo = otra;
                    agp_consignatario.Mostrar_Form(Convert.ToInt32(otra.RutAdquiriente));
                    dl_sucursal.SelectedValue = otra.IdSucursal.ToString().Trim();
                }
                else
                {
                    this.Busca_Operacion();
                }                
			}
		}

      

		protected void Add_Operacion()
		{
			if (!this.Validar_Form()) return;

			UpdatePanel up = (UpdatePanel)this.Parent;
			if (!this.agp_consignatario.Guardar_Form())
			{
				ScriptManager.RegisterStartupScript(up, up.GetType(), "alert_adquirente", string.Format("alert('{0}');", this.agp_consignatario.MensajeError), true);
				return;
			}

			Int32 id_solicitud = Convert.ToInt32(ViewState["id_solicitud"]);
			double Adquiriente = this.agp_consignatario.Rut;
			short cliente = Convert.ToInt16(ViewState["id_cliente"]);
			double compra_para = 0;
			string creada = "";
			double compra_repre = 0;
			double repertorio = 0;
			double n_factura = 0;
			string fecha_factura = "";
			short id_sucursal = Convert.ToInt16(this.dl_sucursal.SelectedValue);
			double emisor = 0;
			double monto = 0;
			double n_cuotas = 0;
			string fecha_primera = "";
			string fecha_ultima = "";
			string cta_corriente = "";
			string banco = "";
			string titular = "";
			string notario = "";
			string ciudad = "";
			string fecha_contrato = "";
			double n_cheques = 0;
			double neto_factura = 0;
			string tipo_pago_factura = "0";
			double factura_intereses = 0;
			string fecha_factura_intereses = "";
			double monto_factura_intereses = 0;
			string fecha_protocolizacion = "";
			string n_protocolizacion = "0";
			string n_RepertorioNotaria = (this.txt_repertorio_notaria.Text.Replace(ViewState["separadorMiles"].ToString(), ""));
			string n_RepertorioRNP = "0";
			string fecha_repertorio = this.txt_fecha_repertorio_notaria.Text;
			string oficina_Registro = "";
			string ing_alza_PN_registro = "";
			string ing_alza_PH_registro = "";
			string n_solicitud_PN_registro = "";
			string n_solicitud_PH_registro = "";
			string nombreEstado = "";
			string fechaUltimoEstado = "";
			double valor_vehiculo = 0;
			double monto_pie = 0;
			double factura_gastos = 0;
			string fecha_factura_gastos = "";
			double monto_factura_gastos = 0;
			double nro_credito = Convert.ToInt32(FuncionGlobal.NumeroSinFormato(this.txt_nro_credito.Text));
			string doc_fundante = "0";
			string solicitante = this.txt_solicitante.Text.ToUpper().Trim();
			string notaria_protocolizacion = "";
			string ciudad_notaria_protocolizacion = "";
			string fecha_repertorio_rnp = "";
			string estado_solicitud_rnp = "0";
			string estado_prenda = "0";
			string observaciones = "";
			string nro_declaracion = "";
            string fecha_pagare = "";
            int valor_cuotas = 0;
            string tasa = "0";
            int dia = 0;
            int capital_pagare = 0;

            int add = new OperacionBC().add_operacion(id_solicitud, cliente, ViewState["tipo_operacion"].ToString(), (string)(Session["usrname"]), 0, "", Convert.ToInt32(this.dl_sucursal.SelectedValue),0);

			ViewState["id_solicitud"] = add.ToString();

			if (add != 0)
			{
				string output = new GarantiaBC().add_Garantia(add, Adquiriente, cliente, compra_para, creada, compra_repre, repertorio, n_factura, fecha_factura, id_sucursal,
																emisor, monto, n_cuotas, fecha_primera, fecha_ultima, cta_corriente, banco, titular, notario, ciudad, fecha_contrato, n_cheques,
																neto_factura, tipo_pago_factura, factura_intereses, fecha_factura_intereses, monto_factura_intereses, fecha_protocolizacion, n_protocolizacion, n_RepertorioNotaria,
																n_RepertorioRNP, fecha_repertorio, oficina_Registro, ing_alza_PN_registro, ing_alza_PH_registro, n_solicitud_PN_registro, n_solicitud_PH_registro, nombreEstado,
																fechaUltimoEstado, valor_vehiculo, monto_pie, factura_gastos, fecha_factura_gastos, monto_factura_gastos, nro_credito, doc_fundante, solicitante,
                                                                notaria_protocolizacion, ciudad_notaria_protocolizacion, fecha_repertorio_rnp, estado_solicitud_rnp, estado_prenda, observaciones, false, nro_declaracion, fecha_pagare,
                                                                valor_cuotas, capital_pagare, tasa, dia);
				//Si hay un error guardando la operación
				if (output != "")
				{
					ScriptManager.RegisterStartupScript(up, up.GetType(), "alert_add_garantia", string.Format("alert('{0}');", output), true);
					return;
				}

                //PARA ORDEN DE TRABAJO
                if (IdOrdenTrabajo!=0)
                {
                    FuncionGlobal.UpdateTipoOperacionOrdenTrabajo(ViewState["tipo_operacion"].ToString(), IdOrdenTrabajo, add);
                }

				string add_or = new EstadooperacionBC().add_estado_orden(Convert.ToInt32(add), 1, ViewState["tipo_operacion"].ToString(), "", (string)(Session["usrname"]));//INGRESO OPERACIÓN
				
				if (!this.agp_vehiculo.Guardar_Form(add))
				{
					ScriptManager.RegisterStartupScript(up, up.GetType(), "alert_add_garantia", string.Format("alert('{0}');", this.agp_vehiculo.MensajeError), true);
					return;
				}

				this.lbl_operacion.Visible = true;
				this.lbl_numero.Visible = true;

				this.lbl_numero.Text = add.ToString("N0");

				this.Busca_Operacion();
			}
		}

		protected bool Validar_Form()
		{
			return true;
		}

		protected void Busca_Operacion()
		{
			Garantia garantia = new GarantiaBC().GetgarantiabyIdSolicitud(Convert.ToInt32(ViewState["id_solicitud"]));

			if (ViewState["id_cliente"].ToString() == "4")
			{
				this.lbl_solicitante.Visible = true;
				this.txt_solicitante.Visible = true;
				this.rfv_solicitante.Enabled = true;
			}
			else
			{
				this.lbl_solicitante.Visible = false;
				this.txt_solicitante.Visible = false;
				this.rfv_solicitante.Enabled = false;
			}

			if (garantia != null)
			{
				this.lbl_operacion.Visible = true;
				this.lbl_numero.Visible = true;
				this.lbl_numero.Text = garantia.Operacion.Id_solicitud.ToString("N0");

				this.txt_solicitante.Text = garantia.Solicitante;

				this.dl_sucursal.SelectedValue = garantia.Sucursal_origen.Id_sucursal.ToString();

				DateTime fecha;

				this.agp_vehiculo.Mostrar_Form(garantia.Operacion.Id_solicitud);
				this.agp_consignatario.Mostrar_Form(garantia.Adquiriente.Rut);

				this.txt_repertorio_notaria.Text = garantia.N_RepertorioNotaria;
				if (DateTime.TryParse(garantia.Fecha_repertorio, out fecha))
					this.txt_fecha_repertorio_notaria.Text = fecha.ToShortDateString();
				else
					this.txt_fecha_repertorio_notaria.Text = "";
			}

           

        }

		protected void Cambiar_Titulo()
		{
			this.lbl_titulo.Text = new TipooperacionBC().getTipooperacion(ViewState["tipo_operacion"].ToString()).Operacion;
		}

		protected void bt_guardar_Click(object sender, EventArgs e)
		{
			this.Add_Operacion();
		}

		protected void bt_limpiar_Click(object sender, EventArgs e)
		{
			Page.Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);
		}
	}
}