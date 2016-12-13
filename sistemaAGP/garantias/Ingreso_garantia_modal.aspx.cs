using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using CENTIDAD;
using CNEGOCIO;
using sistemaAGP.integracionAG;


namespace sistemaAGP
{
	public partial class Ingreso_garantia_modal : System.Web.UI.Page
	{

		private string id_solicitud;
		private string id_cliente;
		public  static string tipo_operacion=string.Empty;
        public static int IdOrdenTrabajo = 0;

		protected void Page_Load(object sender, EventArgs e)
        {
            IdOrdenTrabajo = Convert.ToInt32(FuncionGlobal.FuctionDesEncriptar(Request.QueryString["idOrdenTrabajo"]));
			this.agpAdquirente.OnActivarCompraPara += new wucPersonaEventHandler(agpAdquiriente_OnActivarCompraPara);
            this.agpAdquirente.OnClickDireccion += new wucBotonEventHandler(agpAdquiriente_OnClickDireccion);
            this.agpAdquirente.OnClickTelefono += new wucBotonEventHandler(agpAdquiriente_OnClickTelefono);
            this.agpAdquirente.OnClickCorreo += new wucBotonEventHandler(agpAdquiriente_OnClickCorreo);
            this.agpAdquirente.OnClickParticipante += new wucBotonEventHandler(agpAdquiriente_OnClickParticipante);


            this.agpCompraPara.OnClickDireccion += new wucBotonEventHandler(agpCompraPara_OnClickDireccion);
            this.agpCompraPara.OnClickTelefono += new wucBotonEventHandler(agpCompraPara_OnClickTelefono);
            this.agpCompraPara.OnClickCorreo += new wucBotonEventHandler(agpCompraPara_OnClickCorreo);

			id_solicitud = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_solicitud"].ToString());
			id_cliente = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_cliente"].ToString());
			tipo_operacion = Request.QueryString["tipo_operacion"].ToString();

			if (!IsPostBack)
			{
				this.lbl_operacion.Visible = false;
				this.lbl_numero.Visible = false;
				this.lbl_numero.Text = "0";
				this.lbl_operacion.Text = "";
				
				FuncionGlobal.comboclientesbyusuario((string)(Session["usrname"]), this.dl_cliente);
				this.dl_cliente.SelectedValue = id_cliente;
				FuncionGlobal.combosucursalbyclienteandUsuario(this.dl_sucursal, Convert.ToInt16(this.dl_cliente.SelectedValue), (string)(Session["usrname"]));

				FuncionGlobal.comboparametro(this.dl_forma_pago, "FOPA");
				FuncionGlobal.combobanco(this.dl_financiera,Convert.ToInt32(id_cliente));
				
				CambiarTitulo();

				buscar_cliente_vendedor();

				busca_operacion();
                //estadoPanel();
                busca_datos_estado();
			}
		}

		protected void CambiarTitulo()
		{
			this.lblTitulo.Text = new TipooperacionBC().getTipooperacion(tipo_operacion).Operacion;
		}

        protected void agpAdquiriente_OnClickParticipante(object sender, wucBotonEventArgs e)
        {
            UpdatePanel pnl = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
            ScriptManager.RegisterClientScriptBlock(pnl, pnl.GetType(), "AdqDir", e.Url, false);
        }

        protected void agpAdquiriente_OnClickDireccion(object sender, wucBotonEventArgs e)
        {
            UpdatePanel pnl = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
            ScriptManager.RegisterClientScriptBlock(pnl, pnl.GetType(), "AdqDir", e.Url, false);
        }

        protected void agpAdquiriente_OnClickTelefono(object sender, wucBotonEventArgs e)
        {
            UpdatePanel pnl = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
            ScriptManager.RegisterClientScriptBlock(pnl, pnl.GetType(), "AdqTel", e.Url, false);
        }

        protected void agpAdquiriente_OnClickCorreo(object sender, wucBotonEventArgs e)
        {
            UpdatePanel pnl = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
            ScriptManager.RegisterClientScriptBlock(pnl, pnl.GetType(), "AdqCor", e.Url, false);
        }

        protected void agpCompraPara_OnClickDireccion(object sender, wucBotonEventArgs e)
        {
            UpdatePanel pnl = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
            ScriptManager.RegisterClientScriptBlock(pnl, pnl.GetType(), "ParaDir", e.Url, false);
        }

        protected void agpCompraPara_OnClickTelefono(object sender, wucBotonEventArgs e)
        {
            UpdatePanel pnl = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
            ScriptManager.RegisterClientScriptBlock(pnl, pnl.GetType(), "ParaTel", e.Url, false);
        }

        protected void agpCompraPara_OnClickCorreo(object sender, wucBotonEventArgs e)
        {
            UpdatePanel pnl = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
            ScriptManager.RegisterClientScriptBlock(pnl, pnl.GetType(), "ParaCorr", e.Url, false);
        }


		protected void bt_guardar_Click(object sender, EventArgs e) { }

		protected void bt_limpiar_Click(object sender, EventArgs e)
		{
			this.lbl_numero.Text = "0";
			this.lbl_operacion.Text = "";
			Page.Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);
		}

		protected void btnAceptar_Click(object sender, EventArgs e)
		{
			if (valida_ingreso() == true)
			{
				add_operacion();
			

			}
		}

		protected void btnCancelar_Click(object sender, EventArgs e) { }

		protected bool valida_ingreso()
		{
			UpdatePanel up = (UpdatePanel)this.Master.FindControl("UpdatePanel1");

			if (this.dl_sucursal.SelectedValue == "0" || this.dl_sucursal.SelectedValue == "")
			{
				FuncionGlobal.alerta_updatepanel("Debe ingresar la sucursal", Page, up);
				this.dl_sucursal.Focus();
				return false;
			}
			if (this.dl_forma_pago.SelectedValue == "0" || this.dl_forma_pago.SelectedValue == "")
			{
				FuncionGlobal.alerta_updatepanel("Debe ingresar la forma de pago", Page, up);
				this.dl_forma_pago.Focus();
				return false;
			}
			if (this.txt_total.Text.Trim() == "" || Convert.ToDouble(this.txt_total.Text) == 0)
			{
				FuncionGlobal.alerta_updatepanel("Debe ingresar el monto a financiar", this.Page, up);
				this.txt_total.Focus();
				return false;
			}

			if (this.txt_factura.Text.Trim() == "") this.txt_factura.Text = "0";
			if (this.txt_neto.Text.Trim() == "") this.txt_neto.Text = "0";
			if (this.txt_pie.Text.Trim() == "") this.txt_pie.Text = "0";
			if (this.txt_cheques.Text.Trim() == "") this.txt_cheques.Text = "0";
			if (this.txt_Repertorio.Text.Trim() == "") this.txt_Repertorio.Text = "0";
			if (this.txtFacturaIntereses.Text.Trim() == "") this.txtFacturaIntereses.Text = "0";
			if (this.txtMontoFacturaIntereses.Text.Trim() == "") this.txtMontoFacturaIntereses.Text = "0";
			if (this.txtMontoFinanciar.Text.Trim() == "") this.txtMontoFinanciar.Text = "0";
			if (this.txtFacturaGastos.Text.Trim() == "") this.txtFacturaGastos.Text = "0";
			if (this.txtMontoFacturaGastos.Text.Trim() == "") this.txtMontoFacturaGastos.Text = "0";
			if (this.txt_numProtocolizacion.Text.Trim() == "") this.txt_numProtocolizacion.Text = "0";
			if (this.txt_numRepertorioNotaria.Text.Trim() == "") this.txt_numRepertorioNotaria.Text = "0";
			if (this.txt_numRepertorioRNP.Text.Trim() == "") this.txt_numRepertorioRNP.Text = "0";
			if (this.txt_ingAlzaPN.Text.Trim() == "") this.txt_ingAlzaPN.Text = "0";
			if (this.txt_ingAlzaPH.Text.Trim() == "") this.txt_ingAlzaPH.Text = "0";
			if (this.txt_solRegistroPN.Text.Trim() == "") this.txt_solRegistroPN.Text = "0";
			if (this.txt_solRegistroPH.Text.Trim() == "") this.txt_solRegistroPH.Text = "0";

			Calcular_Monto_Financiar();

			if (this.dl_forma_pago.SelectedValue == "3")
			{
				int pie = 0;
				int total = 0;
				int cheques = 0;
				int intereses = 0;

				if (!int.TryParse(this.txt_total.Text, out total)) total = 0;
				if (!int.TryParse(this.txt_pie.Text, out pie)) pie = 0;
				if (!int.TryParse(this.txtMontoFacturaIntereses.Text, out intereses)) intereses = 0;
				if (!int.TryParse(((TextBox)this.gr_cheques.FooterRow.FindControl("txt_total_monto_cheque")).Text, out cheques)) cheques = 0;

				if (cheques != total - pie + intereses)
				{
					FuncionGlobal.alerta_updatepanel("El monto de los cheques no coincide con el saldo correspondiente", Page, up);
					((TextBox)this.gr_cheques.FooterRow.FindControl("txt_total_monto_cheque")).Focus();
					return false;
				}
			}
			return true;
		}

		protected void add_operacion()
		{
			double rut = 0;
			double rut_para = 0;
			double rut_emisor = 0;

            if (this.dl_sucursal.SelectedValue == "0")
            {
                UpdatePanel up = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
                FuncionGlobal.alerta_updatepanel("Ingrese sucursal", Page, up);
                return;
            }

			if (this.agpAdquirente.Guardar_Form())
			{
				if (this.agpAdquirente.InfoPersona != null)
				{
					rut = this.agpAdquirente.InfoPersona.Rut;
				}
			}
			if (this.agpCompraPara.Visible)
			{
				if (this.agpCompraPara.Guardar_Form())
				{
					if (this.agpCompraPara.InfoPersona != null)
					{
						rut_para = this.agpCompraPara.InfoPersona.Rut;
					}
				}
			}
			if (this.agpEmisor.Guardar_Form())
			{
				if (this.agpEmisor.InfoPersona != null)
				{
					rut_emisor = this.agpEmisor.InfoPersona.Rut;
				}
			}

            Int32 add = new OperacionBC().add_operacion(Convert.ToInt32(this.lbl_numero.Text), Convert.ToInt16(this.dl_cliente.SelectedValue), tipo_operacion, (string)(Session["usrname"]), 0, "", Convert.ToInt32(this.dl_sucursal.SelectedValue),0);
            if (txt_Repertorio.Text == "") { this.txt_Repertorio.Text = "0"; }
            if (txt_cheques.Text == "") { this.txt_cheques.Text = "0"; }

			if (add != 0)
			{

                //PARA ORDEN DE TRABAJO
                if (IdOrdenTrabajo != 0)
                {
                    FuncionGlobal.UpdateTipoOperacionOrdenTrabajo(tipo_operacion, IdOrdenTrabajo, add);
                }


                string fecha_pagare = "";
                int valor_cuotas = 0;
                string tasa = "0";
                int dia = 0;
                int capital_pagare = 0;

				string add_GA = new GarantiaBC().add_Garantia(add, rut, Convert.ToInt16(this.dl_cliente.SelectedValue), rut_para, "", 0, Convert.ToDouble(this.txt_Repertorio.Text), Convert.ToDouble(this.txt_factura.Text), this.txt_fecha_factura.Text, Convert.ToInt16(this.dl_sucursal.SelectedValue), rut_emisor, Convert.ToDouble(this.txtMontoFinanciar.Text), Convert.ToDouble(this.txt_cheques.Text), this.txt_primera.Text, this.txt_ultima.Text, this.txt_cta_corriente.Text, this.dl_financiera.SelectedValue, this.txt_titular.Text, this.txt_notario.Text, this.txt_Ciudad.Text, this.txt_fecha_contrato.Text, Convert.ToDouble(this.txt_cheques.Text), Convert.ToDouble(this.txt_neto.Text), this.dl_forma_pago.SelectedValue, Convert.ToDouble(this.txtFacturaIntereses.Text), this.txtFechaFacturaIntereses.Text, Convert.ToDouble(this.txtMontoFacturaIntereses.Text),
                    this.txt_fecProtocolizacion.Text, this.txt_numProtocolizacion.Text, this.txt_numRepertorioNotaria.Text, this.txt_numRepertorioRNP.Text, this.txt_fechaRepertorio.Text, this.txt_oficinaRegistro.Text, this.txt_ingAlzaPN.Text, this.txt_ingAlzaPH.Text, this.txt_solRegistroPN.Text, this.txt_solRegistroPH.Text, this.lbl_nombreEstado.Text, this.lbl_fechaUltimoEstado.Text, Convert.ToDouble(this.txt_total.Text), Convert.ToDouble(this.txt_pie.Text), Convert.ToDouble(this.txtFacturaGastos.Text), this.txtFechaFacturaGastos.Text, Convert.ToDouble(this.txtMontoFacturaGastos.Text), 0, "", "", "", "", "", "0", "0", "", false, "", fecha_pagare,
                                                                valor_cuotas, capital_pagare, tasa, dia);
				if (add_GA == "")
				{
					string add_or = new EstadooperacionBC().add_estado_orden(Convert.ToInt32(add), 1, tipo_operacion, "", (string)(Session["usrname"]));

					string addVeh = this.agpVehiculo.Guardar_Form(add);

					if (addVeh != "")
					{
						UpdatePanel up = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
						FuncionGlobal.alerta_updatepanel(addVeh, Page, up);
					}

					ChequesFormaPagoBC cheques = new ChequesFormaPagoBC();

					cheques.del_cheques_operacion(add);

					for (int i = 0; i < this.gr_cheques.Rows.Count; i++)
					{
						int id_cheque = Convert.ToInt32(this.gr_cheques.Rows[i].Cells[0].Text);
						int nro_cheque = Convert.ToInt32(((TextBox)this.gr_cheques.Rows[i].FindControl("txt_nro_cheque")).Text);
						DateTime fecha_cheque = Convert.ToDateTime(((TextBox)this.gr_cheques.Rows[i].FindControl("txt_fecha_cheque")).Text);
						int monto_cheque = Convert.ToInt32(((TextBox)this.gr_cheques.Rows[i].FindControl("txt_monto_cheque")).Text);
						cheques.add_cheques_operacion(id_cheque, add, nro_cheque, fecha_cheque, monto_cheque, "", "");
					}

					cheques = null;
				}
				this.lbl_operacion.Visible = true;
				this.lbl_numero.Visible = true;

				this.lbl_operacion.Text = "Número de Operación:";
				this.lbl_numero.Text = Convert.ToString(add);
/*****************/
                /***** Datos Factura ****/
                if (this.txt_factura.Text.Trim() == "") { this.txt_factura.Text = "0"; }
                if (this.txt_neto.Text.Trim() == "") { this.txt_neto.Text = "0"; }
                if (this.txt_fecha_factura.Text == "") { this.txt_fecha_factura.Text = null; }
                /***** Datos del Credito ****/
                if (this.txt_pie.Text==""){this.txt_pie.Text="0";}
                if (this.txt_cheques.Text == "") { this.txt_cheques.Text = "0"; }
                if (this.txtFacturaIntereses.Text == "") { this.txtFacturaIntereses.Text = "0"; }
          /**/  if (this.txtFechaFacturaIntereses.Text == "") { this.txtFechaFacturaIntereses.Text = null; }
                if (this.txtMontoFacturaIntereses.Text == "") { this.txtMontoFacturaIntereses.Text = "0"; }
                if (this.txtMontoFinanciar.Text == "") { this.txtMontoFinanciar.Text = "0"; }
                if (this.txtFacturaGastos.Text == "") { this.txtFacturaGastos.Text = "0"; }
                if (this.txtFechaFacturaGastos.Text == "") { this.txtFechaFacturaGastos.Text = null; }
                if (this.txtMontoFacturaGastos.Text == "") { this.txtMontoFacturaGastos.Text = null; }
                
                /****** Estados ****/
                if (this.txt_fecProtocolizacion.Text == "") { this.txt_fecProtocolizacion.Text = null; }
                if (this.txt_numProtocolizacion.Text == "") { this.txt_numProtocolizacion.Text = "0"; }
                if (this.txt_numRepertorioNotaria.Text == "") { this.txt_numRepertorioNotaria.Text = "0"; }
                if (this.txt_numRepertorioRNP.Text == "") { this.txt_numRepertorioRNP.Text = "0"; }
                if (this.txt_fecha_contrato.Text == "") { this.txt_fecha_contrato.Text = null; }
                if (this.txt_fechaRepertorio.Text == "") { this.txt_fechaRepertorio.Text = null; }
                if (this.txt_oficinaRegistro.Text == "") { this.txt_oficinaRegistro.Text = "0"; }

                if (this.txt_observaciones.Text == "") { this.txt_oficinaRegistro.Text = "0"; }
                

/*****************/



			}
		}

		

		
		protected void busca_operacion()
		{
			Garantia mgarantia = new GarantiaBC().GetgarantiabyIdSolicitud(Convert.ToInt32(id_solicitud));
			if (mgarantia != null)
			{
				this.lbl_operacion.Visible = true;
				this.lbl_numero.Visible = true;
				this.lbl_operacion.Text = "Operación de Solicitud de Garantia Numero:";
				this.lbl_numero.Text = Convert.ToString(mgarantia.Operacion.Id_solicitud);

				this.dl_cliente.SelectedValue = mgarantia.Operacion.Cliente.Id_cliente.ToString();
				FuncionGlobal.combosucursalbyclienteandUsuario(this.dl_sucursal, Convert.ToInt16(this.dl_cliente.SelectedValue), (string)(Session["usrname"]));
				this.dl_sucursal.SelectedValue = mgarantia.Sucursal_origen.Id_sucursal.ToString();

				//** datos emisor
				if (mgarantia.Emisor != null)
				{
					this.agpEmisor.Mostrar_Form(mgarantia.Emisor.Rut);
				}

				//** datos factura
				this.txt_factura.Text = mgarantia.N_factura.ToString();
				this.txt_neto.Text = mgarantia.Neto.ToString();
				this.txt_fecha_factura.Text = string.Format("{0:dd/MM/yyyy}", mgarantia.Fechafactura);

				//** datos vehiculo
				this.agpVehiculo.Mostrar_Form(mgarantia.Operacion.Id_solicitud);

				//** datos crédito
				this.dl_forma_pago.SelectedValue = mgarantia.Tipo_pago_factura.Trim();
				this.txt_cheques.Text = mgarantia.N_cheques.ToString();
                this.dl_financiera.SelectedValue = mgarantia.Bancofinanciera.Trim();
				this.txt_cta_corriente.Text = mgarantia.Cta_corriente;
				this.txt_titular.Text = mgarantia.Titular;
				//this.txt_cuotas.Text = mgarantia.N_cuotas.ToString();

				DateTime aux;
				if (DateTime.TryParse(mgarantia.Fecha_primera, out aux))
					this.txt_primera.Text = string.Format("{0:dd/MM/yyyy}", aux);
				else
					this.txt_primera.Text = "";

				if (DateTime.TryParse(mgarantia.Fecha_primera, out aux))
					this.txt_ultima.Text = string.Format("{0:dd/MM/yyyy}", aux);
				else
					this.txt_ultima.Text = "";

				this.txt_Repertorio.Text = mgarantia.Repertorio.ToString();
				this.txt_notario.Text = mgarantia.Notario;
				this.txt_Ciudad.Text = mgarantia.Ciudad_notario;
				this.txt_fecha_contrato.Text = string.Format("{0:dd/MM/yyyy}", mgarantia.Fecha_contrato);
				this.txtFacturaIntereses.Text = mgarantia.Factura_intereses.ToString();
				this.txtFechaFacturaIntereses.Text = mgarantia.Fecha_factura_intereses;
				this.txtMontoFacturaIntereses.Text = mgarantia.Monto_factura_intereses.ToString();
				this.txtMontoFinanciar.Text = mgarantia.Monto.ToString();
				this.txt_total.Text = mgarantia.Valor_vehiculo.ToString();
				this.txt_pie.Text = mgarantia.Monto_pie.ToString();

				this.txt_numRepertorioNotaria.Text = mgarantia.N_RepertorioNotaria;
				this.txt_fechaRepertorio.Text = string.Format("{0:dd/MM/yyyy}", mgarantia.Fecha_repertorio);
				this.txt_ingAlzaPN.Text = mgarantia.Ing_alza_PN_registro;
				this.txt_solRegistroPN.Text = mgarantia.N_solicitud_PN_registro;
				this.txt_oficinaRegistro.Text = mgarantia.Oficina_Registro;
				this.txt_ingAlzaPH.Text = mgarantia.Ing_alza_PH_registro;
				this.txt_solRegistroPH.Text = mgarantia.N_solicitud_PH_registro;
				this.txt_numRepertorioRNP.Text = mgarantia.N_RepertorioRNP;
				this.txt_fecProtocolizacion.Text = string.Format("{0:dd/MM/yyyy}", mgarantia.Fecha_protocolizacion);
				this.txt_numProtocolizacion.Text = mgarantia.N_protocolizacion;

				this.txtFacturaGastos.Text = mgarantia.Factura_gastos.ToString();
				if (mgarantia.Fecha_factura_gastos != "")
					this.txtFechaFacturaGastos.Text = string.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(mgarantia.Fecha_factura_gastos));
				else
					this.txtFechaFacturaGastos.Text = "";
				this.txtMontoFacturaGastos.Text = mgarantia.Monto_factura_gastos.ToString();

                EstadoOperacion eo = new EstadooperacionBC().getUltimoEstadoByIdoperacion(mgarantia.Operacion.Id_solicitud);

                this.lbl_nombreEstado.Text = eo.Estado_operacion.Descripcion;
                this.lbl_fechaUltimoEstado.Text = string.Format("{0:dd/MM/yyyy}", eo.Fecha_hora);

				//** adquiriente
				if (mgarantia.Adquiriente != null)
				{
					this.agpAdquirente.Mostrar_Form(mgarantia.Adquiriente.Rut);
				}
				if (mgarantia.Compra_para != null)
				{
					this.agpAdquirente.setCompraPara(true);
					this.agpCompraPara.Visible = true;
					this.agpCompraPara.Mostrar_Form(mgarantia.Compra_para.Rut);
				}

				//** cheques
				if (this.dl_forma_pago.SelectedValue == "3")
				{
					this.pnlInfoCheques.Visible = true;

					DataTable dt = new DataTable();
					dt.Columns.Add("nro_cuota");
					dt.Columns.Add("nro_cheque");
					dt.Columns.Add("fecha_cheque");
					dt.Columns.Add("monto_cheque");
					foreach(ChequesFormaPago cheque in new ChequesFormaPagoBC().get_cheques_operacion(mgarantia.Operacion.Id_solicitud))
					{
						DataRow dr = dt.NewRow();
						dr["nro_cuota"] = cheque.Id_cheque;
						dr["nro_cheque"] = cheque.Nro_cheque;
						dr["fecha_cheque"] = cheque.Fecha_cheque.ToShortDateString();
						dr["monto_cheque"] = cheque.Monto_cheque;
						dt.Rows.Add(dr);
					}
					this.gr_cheques.DataSource = dt;
					this.gr_cheques.DataBind();
					suma_grilla();
				}
			}
		}

		protected void txt_factura_TextChanged(object sender, EventArgs e)
		{
			if (!busca_operacion_por_factura())
			{
				double rut_emisor = this.agpEmisor.getRut();
				Cliente cliente_emisor = new ClienteBC().getClientePorRut(rut_emisor);
				if (cliente_emisor != null)
				{
					switch(cliente_emisor.Id_webservice){
						case 1:
							getDatosFacturaWS();
							break;
						default:
							break;
					}
				}
			}
		}


	

		protected void gr_dato_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private bool busca_operacion_por_factura()
		{
			if (this.txt_factura.Text.Trim() == "") return false;
			Int16 id_cliente = Convert.ToInt16(this.dl_cliente.SelectedValue);
			double rut_emisor = this.agpEmisor.getRut();
			double nro_factura = Convert.ToDouble(this.txt_factura.Text);
			Garantia mgarantia = new GarantiaBC().Getgarantiabyfactura(id_cliente, rut_emisor, nro_factura);
			if (mgarantia != null)
			{
				this.lbl_operacion.Visible = true;
				this.lbl_numero.Visible = true;
				this.lbl_operacion.Text = "Operación de Solicitud de Garantia Numero:";
				this.lbl_numero.Text = Convert.ToString(mgarantia.Operacion.Id_solicitud);

				this.dl_cliente.SelectedValue = mgarantia.Operacion.Cliente.Id_cliente.ToString();
				FuncionGlobal.combosucursalbyclienteandUsuario(this.dl_sucursal, Convert.ToInt16(this.dl_cliente.SelectedValue), (string)(Session["usrname"]));
				this.dl_sucursal.SelectedValue = mgarantia.Sucursal_origen.Id_sucursal.ToString();

				//** datos emisor
				if (mgarantia.Emisor != null)
				{
					this.agpEmisor.Mostrar_Form(mgarantia.Emisor.Rut);
				}

				//** datos factura
				this.txt_factura.Text = mgarantia.N_factura.ToString();
				this.txt_neto.Text = mgarantia.Neto.ToString();
				this.txt_fecha_factura.Text = string.Format("{0:dd/MM/yyyy}", mgarantia.Fechafactura);

				//** datos vehiculo
				this.agpVehiculo.Mostrar_Form(mgarantia.Operacion.Id_solicitud);

				//** datos crédito
				this.dl_forma_pago.SelectedValue = mgarantia.Tipo_pago_factura.Trim();
				this.txt_cheques.Text = mgarantia.N_cheques.ToString();
				this.dl_financiera.SelectedValue = mgarantia.Bancofinanciera.Trim();
				this.txt_cta_corriente.Text = mgarantia.Cta_corriente;
				this.txt_titular.Text = mgarantia.Titular;
				//this.txt_cuotas.Text = mgarantia.N_cuotas.ToString();

				DateTime aux;
				if (DateTime.TryParse(mgarantia.Fecha_primera, out aux))
					this.txt_primera.Text = string.Format("{0:dd/MM/yyyy}", aux);
				else
					this.txt_primera.Text = "";

				if (DateTime.TryParse(mgarantia.Fecha_primera, out aux))
					this.txt_ultima.Text = string.Format("{0:dd/MM/yyyy}", aux);
				else
					this.txt_ultima.Text = "";

				this.txt_Repertorio.Text = mgarantia.Repertorio.ToString();
				this.txt_notario.Text = mgarantia.Notario;
				this.txt_Ciudad.Text = mgarantia.Ciudad_notario;
				this.txt_fecha_contrato.Text = string.Format("{0:dd/MM/yyyy}", mgarantia.Fecha_contrato);
				this.txtFacturaIntereses.Text = mgarantia.Factura_intereses.ToString();
				this.txtFechaFacturaIntereses.Text = mgarantia.Fecha_factura_intereses;
				this.txtMontoFacturaIntereses.Text = mgarantia.Monto_factura_intereses.ToString();
				this.txtMontoFinanciar.Text = mgarantia.Monto.ToString();
				this.txt_total.Text = mgarantia.Valor_vehiculo.ToString();
				this.txt_pie.Text = mgarantia.Monto_pie.ToString();

                this.txt_numRepertorioNotaria.Text = mgarantia.N_RepertorioNotaria;
                this.txt_fechaRepertorio.Text = string.Format("{0:dd/MM/yyyy}", mgarantia.Fecha_repertorio); 
                this.txt_ingAlzaPN.Text = mgarantia.Ing_alza_PN_registro;
                this.txt_solRegistroPN.Text = mgarantia.N_solicitud_PN_registro;
                this.txt_oficinaRegistro.Text = mgarantia.Oficina_Registro;
                this.txt_ingAlzaPH.Text = mgarantia.Ing_alza_PH_registro;
                this.txt_solRegistroPH.Text = mgarantia.N_solicitud_PH_registro;
                this.txt_numRepertorioRNP.Text = mgarantia.N_RepertorioRNP;
                this.txt_fecProtocolizacion.Text = string.Format("{0:dd/MM/yyyy}", mgarantia.Fecha_protocolizacion);
                this.txt_numProtocolizacion.Text = mgarantia.N_protocolizacion;

				this.txtFacturaGastos.Text = mgarantia.Factura_gastos.ToString();
				if (mgarantia.Fecha_factura_gastos != "")
					this.txtFechaFacturaGastos.Text = string.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(mgarantia.Fecha_factura_gastos));
				else
					this.txtFechaFacturaGastos.Text = "";
				this.txtMontoFacturaGastos.Text = mgarantia.Monto_factura_gastos.ToString();

				EstadoOperacion eo = new EstadooperacionBC().getUltimoEstadoByIdoperacion(mgarantia.Operacion.Id_solicitud);

				this.lbl_nombreEstado.Text = eo.Estado_operacion.Descripcion;
				this.lbl_fechaUltimoEstado.Text = string.Format("{0:dd/MM/yyyy}", eo.Fecha_hora);

				//** adquiriente
				if (mgarantia.Adquiriente != null)
				{
					this.agpAdquirente.Mostrar_Form(mgarantia.Adquiriente.Rut);
				}
				if (mgarantia.Compra_para != null)
				{
					this.agpAdquirente.setCompraPara(true);
					this.agpCompraPara.Visible = true;
					this.agpCompraPara.Mostrar_Form(mgarantia.Compra_para.Rut);
				}

				//** cheques
				if (this.dl_forma_pago.SelectedValue == "3")
				{
					this.pnlInfoCheques.Visible = true;

					DataTable dt = new DataTable();
					dt.Columns.Add("nro_cuota");
					dt.Columns.Add("nro_cheque");
					dt.Columns.Add("fecha_cheque");
					dt.Columns.Add("monto_cheque");
					foreach (ChequesFormaPago cheque in new ChequesFormaPagoBC().get_cheques_operacion(mgarantia.Operacion.Id_solicitud))
					{
						DataRow dr = dt.NewRow();
						dr["nro_cuota"] = cheque.Id_cheque;
						dr["nro_cheque"] = cheque.Nro_cheque;
						dr["fecha_cheque"] = cheque.Fecha_cheque.ToShortDateString();
						dr["monto_cheque"] = cheque.Monto_cheque;
						dt.Rows.Add(dr);
					}
					this.gr_cheques.DataSource = dt;
					this.gr_cheques.DataBind();
					suma_grilla();
				}
				return true;
			}
			return false;
		}

		protected void getDatosFacturaWS()
		{
			if (this.txt_factura.Text.Trim() == "") return;
			System.Net.ServicePointManager.Expect100Continue = false;
			WSIntegracionAGPSoapClient ws = new WSIntegracionAGPSoapClient();
			try
			{
				XElement xDoc = XElement.Parse(ws.GetFacturaPorNumero(ConfigurationManager.AppSettings["wsag_user"], ConfigurationManager.AppSettings["wsag_pass"], Convert.ToInt64(this.txt_factura.Text)));
				var query = from f in xDoc.Descendants("factura")
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
							};
				foreach (var q in query)
				{
					double num;
					// Carga datos de la factura
					string[] aux = q.datosFactura.fechaFactura.Trim().Substring(0, q.datosFactura.fechaFactura.Trim().IndexOf(" ")).Split('/');
					this.txt_fecha_factura.Text = string.Format("{0:dd/MM/yyyy}", DateTime.Parse(aux[2] + "-" + aux[0] + "-" + aux[1]));
					if (double.TryParse(q.datosFactura.netoFactura.Replace(".", ","), out num))
					{
						this.txt_neto.Text = Convert.ToInt64(num).ToString();
						this.txt_total.Text = Convert.ToInt64(num * 1.19).ToString();
					}

					// Carga datos del vehículo
					this.agpVehiculo.setTipoVehiculo(q.datosVehiculo.tipoVehiculo.Trim());
					this.agpVehiculo.setMarca(q.datosVehiculo.marca.Trim());
					this.agpVehiculo.setModelo(q.datosVehiculo.descripModelo.Trim());
					this.agpVehiculo.setAnio(q.datosVehiculo.anio.Trim());
					this.agpVehiculo.setCilindrada(q.datosVehiculo.cilindraje.Trim());
					this.agpVehiculo.setPuertas(q.datosVehiculo.numeroPuertas.Trim());
					this.agpVehiculo.setAsientos(q.datosVehiculo.numeroAsientos.Trim());
					this.agpVehiculo.setPesoBruto(q.datosVehiculo.pesoBruto.Trim());
					this.agpVehiculo.setPesoCarga(q.datosVehiculo.carga.Trim());
					this.agpVehiculo.setCombustible(q.datosVehiculo.combustible.Trim());
					this.agpVehiculo.setColor(q.datosVehiculo.color.Trim());
					this.agpVehiculo.setMotor(q.datosVehiculo.motor.Trim());
					this.agpVehiculo.setChasis(q.datosVehiculo.chasis.Trim());
					this.agpVehiculo.setVin(q.datosVehiculo.vin.Trim());

					// Carga datos del negocio
					FuncionGlobal.BuscarValueCombo(this.dl_sucursal, new SucursalclienteBC().getSucursalParidadAG(q.datosFactura.codigoSucursal.Trim()).Id_sucursal.ToString());

					// Carga datos del adquirente
					if (new PersonaBC().getpersonabyrut(Convert.ToDouble(q.datosAdquirente.rut)) == null)
					{
						this.agpAdquirente.setRut(q.datosAdquirente.rut.Trim());
						this.agpAdquirente.setDV(q.datosAdquirente.dv.Trim());
						this.agpAdquirente.setNombre(q.datosAdquirente.nombre.Trim());
						this.agpAdquirente.setPaterno(q.datosAdquirente.paterno.Trim());
						this.agpAdquirente.setMaterno(q.datosAdquirente.materno.Trim());}
					else
					{
						this.agpAdquirente.Mostrar_Form(Convert.ToDouble(q.datosAdquirente.rut));
					}
					break;
				}
			}
			finally
			{
				ws.Close();
			}
		}

		protected void txt_primera_TextChanged(object sender, EventArgs e)
		{
			if (this.txt_primera.Text != "" && this.txt_cheques.Text != "")
			{
				this.txt_ultima.Text = string.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(this.txt_primera.Text).AddMonths(Convert.ToInt32(this.txt_cheques.Text) - 1));
			}
  /********************************/
            
			if (this.dl_forma_pago.SelectedValue == "3")
			{
				if (this.txt_cheques.Text.Trim() != "")
				{
					DateTime fecha = Convert.ToDateTime(this.txt_primera.Text);
					for (int i = 0; i < this.gr_cheques.Rows.Count; i++)
					{
						((TextBox)this.gr_cheques.Rows[i].FindControl("txt_fecha_cheque")).Text = fecha.ToShortDateString();
						fecha = fecha.AddMonths(1);
					}
				}
			}
		}

		protected void agpAdquiriente_OnActivarCompraPara(object sender, wucPersonaEventArgs e)
		{
			this.agpCompraPara.Visible = e.Activar;
		}

		protected void dl_cliente_SelectedIndexChanged(object sender, EventArgs e)
		{
			buscar_cliente_vendedor();
		}

		protected void buscar_cliente_vendedor()
		{
			Cliente c = new ClienteBC().getcliente(Convert.ToInt16(this.dl_cliente.SelectedValue));
			this.agpEmisor.Mostrar_Form(c.Persona.Rut);
		}

		protected void txt_neto_TextChanged(object sender, EventArgs e)
		{
			if (this.txt_neto.Text.Trim() != "")
			{
				int neto = 0;
				if (int.TryParse(this.txt_neto.Text, out neto))
				{
					this.txt_total.Text = Convert.ToInt32(neto * 1.19).ToString();
				}
			}            
		}

		protected void txt_cheques_TextChanged(object sender, EventArgs e)
		{
			if (this.txt_primera.Text != "" && this.txt_cheques.Text != "")
			{
				this.txt_ultima.Text = string.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(this.txt_primera.Text).AddMonths(Convert.ToInt32(this.txt_cheques.Text) - 1));
			}
			if (this.dl_forma_pago.SelectedValue == "3")
			{
				int cheques = 0;
				this.pnlInfoCheques.Visible = true;
				if (this.txt_cheques.Text.Trim() != "")
				{
					if (int.TryParse(this.txt_cheques.Text, out cheques))
					{

						DataTable dt = new DataTable();
						dt.Columns.Add("nro_cuota");
						dt.Columns.Add("nro_cheque");
						dt.Columns.Add("fecha_cheque");
						dt.Columns.Add("monto_cheque");
						for (int i = 0; i < cheques; i++)
						{
							DataRow dr = dt.NewRow();
							dr["nro_cuota"] = i + 1;
							dr["nro_cheque"] = "";
							if (this.txt_primera.Text != "")
								dr["fecha_cheque"] = string.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(this.txt_primera.Text).AddMonths(i));
							else
								dr["fecha_cheque"] = "";
							dr["monto_cheque"] = "";
							dt.Rows.Add(dr);
						}
						this.gr_cheques.DataSource = dt;
						this.gr_cheques.DataBind();
						suma_grilla();
					}
				}
			}
		}

		protected void gr_cheques_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			int index;
			int valor;
			DateTime fecha;
			switch (e.CommandName)
			{
				case "FillDownNro":
					index = Convert.ToInt32(e.CommandArgument);
					if (int.TryParse(((TextBox)this.gr_cheques.Rows[index].FindControl("txt_nro_cheque")).Text, out valor))
					{
						for (int i = index + 1; i < this.gr_cheques.Rows.Count; i++)
						{
							valor++;
							((TextBox)this.gr_cheques.Rows[i].FindControl("txt_nro_cheque")).Text = valor.ToString();
						}
					}
					break;
				case "FillDownMonto":
					index = Convert.ToInt32(e.CommandArgument);
					if (int.TryParse(((TextBox)this.gr_cheques.Rows[index].FindControl("txt_monto_cheque")).Text, out valor))
					{
						for (int i = index + 1; i < this.gr_cheques.Rows.Count; i++)
						{
							((TextBox)this.gr_cheques.Rows[i].FindControl("txt_monto_cheque")).Text = valor.ToString();
						}
					}
					break;
				case "FillDownFecha":
					index = Convert.ToInt32(e.CommandArgument);
					if (DateTime.TryParse(((TextBox)this.gr_cheques.Rows[index].FindControl("txt_fecha_cheque")).Text, out fecha))
					{
						for (int i = index + 1; i < this.gr_cheques.Rows.Count; i++)
						{
							fecha = fecha.AddMonths(1);
							((TextBox)this.gr_cheques.Rows[i].FindControl("txt_fecha_cheque")).Text = fecha.ToShortDateString();
						}
					}
					break;
			}
			suma_grilla();
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

		protected void txt_monto_cheque_TextChanged(object sender, EventArgs e)
		{
			suma_grilla();
		}

		protected void dl_forma_pago_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.dl_forma_pago.SelectedValue == "3")
			{
				this.pnlInfoCheques.Visible = true;
			}
			else
			{
				this.pnlInfoCheques.Visible = false;
			}
		}

		protected void suma_grilla()
		{
			int suma = 0;
			for (int idx = 0; idx < this.gr_cheques.Rows.Count; idx++)
			{
				int valor = 0;
				if (int.TryParse(((TextBox)this.gr_cheques.Rows[idx].FindControl("txt_monto_cheque")).Text, out valor))
					suma += valor;
				else
					suma += 0;
			}
			((TextBox)this.gr_cheques.FooterRow.FindControl("txt_total_monto_cheque")).Text = suma.ToString();
		}

        protected void txt_protocolizacion_TextChanged(object sender, EventArgs e)
        {

        }

        //protected void estadoPanel()
        //{
        //    if (id_solicitud != "0" && id_solicitud != "2")
        //    {
        //        Estadotipooperacion mestado = new EstadotipooperacionBC().getultimoestado(Convert.ToInt32(id_solicitud));
        //        switch (tipo_operacion)
        //        {       //PRENDA
        //            case "ga": if (mestado.Orden == 60)
        //                {
        //                    this.txt_fecProtocolizacion.Visible = true;
        //                    this.lbl_fecProtocolizacion.Visible = true;
        //                    this.txt_numProtocolizacion.Visible = true;
        //                    this.lbl_numProtocolizacion.Visible = true;
        //                    this.txt_numRepertorioNotaria.Visible = true;
        //                    this.lbl_numRepertorioNotaria.Visible = true;
        //                }
        //                if (mestado.Orden >= 70)
        //                {
        //                    this.txt_numRepertorioRNP.Visible = true;
        //                    this.lbl_numRepertorioRNP.Visible = true;
        //                }
        //                        break;
        //                //ALZAMIENTO 4702
        //            case "alzan": if (mestado.Orden == 40)
        //                        {
        //                            this.lbl_numRepertorioNotaria.Visible = true;
        //                            this.txt_numRepertorioNotaria.Visible = true;
        //                            this.lbl_fechaRepertorio.Visible = true;
        //                            this.txt_fechaRepertorio.Visible = true;
        //                            this.img_fecRepertorio.Visible = true;
        //                        }

        //                        if (mestado.Orden >= 50)
        //                        {
        //                            this.lbl_ofRegistro.Visible = true;
        //                            this.txt_oficinaRegistro.Visible = true;
        //                            this.lbl_ingAlzaPNreg.Visible = true;
        //                            this.txt_ingAlzaPN.Visible = true;
        //                            this.lbl_ingAlzaPHreg.Visible = true;
        //                            this.txt_ingAlzaPH.Visible = true;
        //                            this.lbl_numSolPNreg.Visible = true;
        //                            this.txt_solRegistroPN.Visible = true;
        //                            this.lbl_numSolPHreg.Visible = true;
        //                            this.txt_solRegistroPH.Visible = true;
        //                        }
        //                           break;
        //                //ALZAMIENTO 20190
        //            case "alzga": if (mestado.Orden >= 40)
        //                           {
        //                               this.lbl_fechaRepertorio.Visible = true;
        //                               this.txt_fechaRepertorio.Visible = true;
        //                               this.lbl_numRepertorioNotaria.Visible = true;
        //                               this.txt_numRepertorioNotaria.Visible = true;
        //                               this.img_fecRepertorio.Visible = true;
        //                           }      
        //                            if(mestado.Orden>=60)
        //                            {
        //                                this.lbl_ofRegistro.Visible = true;
        //                                this.txt_oficinaRegistro.Visible = true;
        //                                this.txt_ingAlzaPH.Visible = true;
        //                                this.lbl_ingAlzaPHreg.Visible = true;
        //                                this.lbl_numSolPHreg.Visible = true;
        //                                this.txt_solRegistroPH.Visible = true;
        //                            }
        //                            if (mestado.Orden >= 80)
        //                            {
        //                                this.lbl_numRepertorioRNP.Visible = true;
        //                                this.txt_numRepertorioRNP.Visible = true;
        //                            }

        //                            break;
        //            /*
        //        default:    this.txt_numProtocolizacion.Visible = false;
        //                    this.txt_numRepertorioNotaria.Visible = true;
        //                    this.txt_fecProtocolizacion.Visible = false;
        //                    this.txt_numRepertorioRNP.Visible = false;
        //                    this.txt_fechaRepertorio.Visible = false;
        //                    this.CalendarExtender2.Enabled = false;
        //                    this.txt_oficinaRegistro.Visible = false;
        //                    this.txt_ingAlzaPN.Visible = false;
        //                    this.txt_ingAlzaPH.Visible = false;
        //                    this.txt_solRegistroPN.Visible = false;
        //                    this.txt_solRegistroPH.Visible = false;
        //                    this.lbl_fecProtocolizacion.Visible = false;
        //                    this.txt_fecProtocolizacion.Visible = false;             
        //                    this.lbl_ingAlzaPNreg.Visible = false;
        //                    this.txt_ingAlzaPN.Visible = false;
        //                    this.lbl_numSolPNreg.Visible = true;
        //                    this.txt_solRegistroPN.Visible = true;
        //                    break;
        //        */
        //        }
        //    }
            

        //}

        protected void busca_datos_estado()
        {
            Garantia mgarantia = new GarantiaBC().GetgarantiabyIdSolicitud(Convert.ToInt32(id_solicitud));
            if (mgarantia != null)
            {
                if (id_solicitud != "0" && id_solicitud != "2")
                {
                    EstadoTipoOperacion mestado = new EstadotipooperacionBC().getultimoestado(Convert.ToInt32(id_solicitud));
                    switch (tipo_operacion)
                    {       //PRENDA
                        case "ga": if (mestado.Orden >= 60)
                            {
                                this.txt_fecProtocolizacion.Visible = true;
                                this.lbl_fecProtocolizacion.Visible = true;
                                this.txt_numProtocolizacion.Visible = true;
                                this.lbl_numProtocolizacion.Visible = true;
                                this.txt_numRepertorioNotaria.Visible = true;
                                this.lbl_numRepertorioNotaria.Visible = true;
                                this.txt_fecProtocolizacion.Text = string.Format("{0:dd/MM/yyyy}", mgarantia.Fecha_protocolizacion); 
                                this.txt_numProtocolizacion.Text = mgarantia.N_protocolizacion;
                                this.txt_numRepertorioNotaria.Text = mgarantia.N_RepertorioNotaria;
                                this.lbl_fechaUltimoEstado.Visible = true;
                                this.lbl_nombreEstado.Visible = true;
                                this.lbl_fecUltimoEstado.Visible = true;
                                this.lbl_nomEstadoAnt.Visible = true;
                                this.lbl_notario.Visible = true;
                                this.txt_notario.Visible = true;
                                this.lbl_ciudadNotario.Visible = true;
                                this.txt_Ciudad.Visible = true;
                                this.lbl_fechaContrato.Visible = true;
                                this.txt_fecha_contrato.Visible = true;
                                this.ib_contrato.Visible = true;
                            }


                            if (mestado.Orden >= 70)
                            {
                                this.txt_numRepertorioRNP.Visible = true;
                                this.lbl_numRepertorioRNP.Visible = true;
                                this.txt_numRepertorioRNP.Text = mgarantia.N_RepertorioRNP;
                            }
                            break;
                        //ALZAMIENTO 4702
                        case "alzan": if (mestado.Orden >= 40)
                            {
                                this.lbl_numRepertorioNotaria.Visible = true;
                                this.txt_numRepertorioNotaria.Visible = true;
                                this.lbl_fechaRepertorio.Visible = true;
                                this.txt_fechaRepertorio.Visible = true;
                                this.img_fecRepertorio.Visible = true;
                                this.txt_numRepertorioNotaria.Text = mgarantia.N_RepertorioNotaria;
                                this.txt_fechaRepertorio.Text = string.Format("{0:dd/MM/yyyy}", mgarantia.Fecha_repertorio);
                                this.lbl_fechaUltimoEstado.Visible = true;
                                this.lbl_nombreEstado.Visible = true;
                                this.lbl_fecUltimoEstado.Visible = true;
                                this.lbl_nomEstadoAnt.Visible = true;
                                this.lbl_notario.Visible = true;
                                this.txt_notario.Visible = true;
                                this.lbl_ciudadNotario.Visible = true;
                                this.txt_Ciudad.Visible=true;
                                this.lbl_fechaContrato.Visible = true;
                                this.txt_fecha_contrato.Visible = true;
                                this.ib_contrato.Visible = true;

                            }

                            if (mestado.Orden >= 50)
                            {
                                this.lbl_ofRegistro.Visible = true;
                                this.txt_oficinaRegistro.Visible = true;
                                this.lbl_ingAlzaPNreg.Visible = true;
                                this.txt_ingAlzaPN.Visible = true;
                                this.lbl_ingAlzaPHreg.Visible = true;
                                this.txt_ingAlzaPH.Visible = true;
                                this.lbl_numSolPNreg.Visible = true;
                                this.txt_solRegistroPN.Visible = true;
                                this.lbl_numSolPHreg.Visible = true;
                                this.txt_solRegistroPH.Visible = true;
                                this.txt_oficinaRegistro.Text = mgarantia.Oficina_Registro;
                                this.txt_ingAlzaPN.Text = mgarantia.Ing_alza_PN_registro;
                                this.txt_ingAlzaPH.Text = mgarantia.Ing_alza_PH_registro;
                                this.txt_solRegistroPN.Text = mgarantia.N_solicitud_PN_registro;
                                this.txt_solRegistroPH.Text = mgarantia.N_solicitud_PH_registro;
                                
                            }
                            break;
                        //ALZAMIENTO 20190
                        case "alzga": if (mestado.Orden >= 40)
                            {
                                this.lbl_fechaRepertorio.Visible = true;
                                this.txt_fechaRepertorio.Visible = true;
                                this.lbl_numRepertorioNotaria.Visible = true;
                                this.txt_numRepertorioNotaria.Visible = true;
                                this.img_fecRepertorio.Visible = true;
                                this.txt_numRepertorioNotaria.Text = mgarantia.N_RepertorioNotaria;
                                this.txt_fechaRepertorio.Text = string.Format("{0:dd/MM/yyyy}", mgarantia.Fecha_repertorio);
                                this.lbl_fechaUltimoEstado.Visible = true;
                                this.lbl_nombreEstado.Visible = true;
                                this.lbl_fecUltimoEstado.Visible = true;
                                this.lbl_nomEstadoAnt.Visible = true;
                                this.lbl_notario.Visible = true;
                                this.txt_notario.Visible = true;
                                this.lbl_ciudadNotario.Visible = true;
                                this.txt_Ciudad.Visible = true;
                                this.lbl_fechaContrato.Visible = true;
                                this.txt_fecha_contrato.Visible = true;
                                this.ib_contrato.Visible = true;
                                
                            }
                            if (mestado.Orden >= 60)
                            {
                                this.lbl_ofRegistro.Visible = true;
                                this.txt_oficinaRegistro.Visible = true;
                                this.txt_ingAlzaPH.Visible = true;
                                this.lbl_ingAlzaPHreg.Visible = true;
                                this.lbl_numSolPHreg.Visible = true;
                                this.txt_solRegistroPH.Visible = true;
                                this.txt_oficinaRegistro.Text = mgarantia.Oficina_Registro;
                                this.txt_ingAlzaPH.Text = mgarantia.Ing_alza_PH_registro;
                                this.txt_solRegistroPH.Text = mgarantia.N_solicitud_PH_registro;
                                
                            }
                            if (mestado.Orden >= 80)
                            {
                                this.lbl_numRepertorioRNP.Visible = true;
                                this.txt_numRepertorioRNP.Visible = true;
                                this.txt_numRepertorioRNP.Text = mgarantia.N_RepertorioRNP;
                                
                            }

                            break;
                        /*
                    default:    this.txt_numProtocolizacion.Visible = false;
                                this.txt_numRepertorioNotaria.Visible = true;
                                this.txt_fecProtocolizacion.Visible = false;
                                this.txt_numRepertorioRNP.Visible = false;
                                this.txt_fechaRepertorio.Visible = false;
                                this.CalendarExtender2.Enabled = false;
                                this.txt_oficinaRegistro.Visible = false;
                                this.txt_ingAlzaPN.Visible = false;
                                this.txt_ingAlzaPH.Visible = false;
                                this.txt_solRegistroPN.Visible = false;
                                this.txt_solRegistroPH.Visible = false;
 
                                
                                break;
                    */
                    }
                }
            }

        }

        protected void img_fecRepertorio_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void dl_financiera_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

		protected void Calcular_Monto_Financiar()
		{
			if (this.txtMontoFacturaIntereses.Text.Trim() == "") this.txtMontoFacturaIntereses.Text = "0";
			if (this.txt_pie.Text.Trim() == "") this.txt_pie.Text = "0";
			if (this.txt_total.Text.Trim() == "") this.txt_total.Text = "0";

			int vehiculo = Convert.ToInt32(this.txt_total.Text);
			int intereses = Convert.ToInt32(this.txtMontoFacturaIntereses.Text);
			int pie = Convert.ToInt32(this.txt_pie.Text);

			this.txtMontoFinanciar.Text = (vehiculo + intereses - pie).ToString();			
		}

		protected void txt_pie_TextChanged(object sender, EventArgs e)
		{
			Calcular_Monto_Financiar();
		}

		protected void txt_total_TextChanged(object sender, EventArgs e)
		{
			Calcular_Monto_Financiar();
		}

		protected void txtMontoFacturaIntereses_TextChanged(object sender, EventArgs e)
		{
			Calcular_Monto_Financiar();
		}

	}
}