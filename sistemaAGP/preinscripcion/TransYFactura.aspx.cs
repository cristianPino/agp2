using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CENTIDAD;
using CNEGOCIO;

namespace sistemaAGP.preinscripcion
{
    public partial class TransYFactura : System.Web.UI.Page
    {
        public int IdOrdenTrabajo = 0;
		protected void Page_Load(object sender, EventArgs e)
		{
            this.agp_adquirente.OnActivarCompraPara += new wucPersonaEventHandler(agpAdquiriente_OnActivarCompraPara);
            this.agp_adquirente.OnClickDireccion += new wucBotonEventHandler(agpAdquiriente_OnClickDireccion);
            this.agp_adquirente.OnClickTelefono += new wucBotonEventHandler(agpAdquiriente_OnClickTelefono);
            this.agp_adquirente.OnClickCorreo += new wucBotonEventHandler(agpAdquiriente_OnClickCorreo);
            this.agpCompraPara.OnClickDireccion += new wucBotonEventHandler(agpCompraPara_OnClickDireccion);
            this.agpCompraPara.OnClickTelefono += new wucBotonEventHandler(agpCompraPara_OnClickTelefono);
            this.agpCompraPara.OnClickCorreo += new wucBotonEventHandler(agpCompraPara_OnClickCorreo);
            IdOrdenTrabajo = Convert.ToInt32(FuncionGlobal.FuctionDesEncriptar(Request.QueryString["idOrdenTrabajo"]));
            var tipoOper = Request.QueryString["tipo_operacion"].ToString();

            if(tipoOper.Trim() == "STMH")
            {
                tdnumOper.Visible = true;
                tdTexOper.Visible = true;
            }

		    if (!IsPostBack)
			{
				ViewState["id_solicitud"] = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_solicitud"].ToString());
				ViewState["id_cliente"] = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_cliente"].ToString());
				ViewState["tipo_operacion"] = Request.QueryString["tipo_operacion"].ToString();

                var cli = ViewState["id_cliente"].ToString();

                if (cli == "15")
                {
                    txtNumOperacion.AutoPostBack = true;
                    lblInstruccionPago.Visible = true;
                    dlInstruccionPago.Visible = true;
                    lblNormaEuro.Visible = true;
                    ckNormaEuro.Visible = true;
                    FuncionGlobal.comboparametro(dlInstruccionPago, "INPAG"); //INSTRUCCION DE PAGO LEASING
                }

                this.Cambiar_Titulo();
				FuncionGlobal.comboclientesbyusuario((string)(Session["usrname"]), this.dl_cliente);
				this.dl_cliente.SelectedValue = ViewState["id_cliente"].ToString();
				this.dl_cliente.Enabled = false;
				FuncionGlobal.combosucursalbyclienteandUsuario(this.dl_sucursal, Convert.ToInt16(this.dl_cliente.SelectedValue), (string)(Session["usrname"]));

                FuncionGlobal.comboparametro(this.dl_forma_pago, "FOPA");
                FuncionGlobal.comboparametro(this.dl_cargo_venta, "CAVE");
                FuncionGlobal.combobanco(this.dl_financiera, Convert.ToInt32(ViewState["id_cliente"].ToString()));
				if (this.dl_sucursal.Items.Count == 2)
				{
					this.dl_sucursal.SelectedIndex = 1;
				}

				this.Busca_Operacion();
                hdIdOrdenTrabajo.Value = "0";
                if (IdOrdenTrabajo == 0) return;
                hdIdOrdenTrabajo.Value = IdOrdenTrabajo.ToString(CultureInfo.InvariantCulture);
                var otra = new OrdenTrabajoBC().GetOrdenTrabajo(IdOrdenTrabajo);
                BuscaOrdenTrabajo(otra);
                agp_vehiculo.OrdenTrabajo = otra;
                agp_adquirente.Mostrar_Form(Convert.ToInt32(otra.RutAdquiriente));
               
                if (otra.TieneCompraPara)
                {
                    this.agp_adquirente.setCompraPara(true);
                    this.agpCompraPara.Visible = true;
                    this.agpCompraPara.Mostrar_Form(otra.CompraParaRut);
                    this.agp_adquirente.HabilitarCompraPara = otra.TieneCompraPara;
                    
                }

			    
            }
		}

        public void BuscaOrdenTrabajo(CENTIDAD.OrdenTrabajo otra)
        {
            dl_sucursal.SelectedValue = otra.IdSucursal.ToString(CultureInfo.InvariantCulture);
            txt_factura.Text = otra.NumeroFactura.Trim();
            txt_neto.Text = otra.FacturaNeto.Trim();
            txt_fecha_factura.Text = Convert.ToDateTime(otra.FechaFactura.Trim()).ToShortDateString();
            dl_forma_pago.SelectedValue = otra.CodigoFormaPago.Trim();
            dl_financiera.SelectedValue = otra.CodigoFinanciera.Trim();
            dl_cargo_venta.SelectedValue = otra.QuienPaga.Trim();

            var usuario = Convert.ToString(Session["usrname"]).Trim();

            if (usuario != "153636613" && usuario != "17483833k" && usuario != "141548085"
                && usuario != "130055087" && usuario != "116333627")
            {
                dl_forma_pago.SelectedValue = otra.ConCreditoAmicar ? "2" : "0";
                dl_forma_pago.Enabled = !otra.ConCreditoAmicar;
            }

        }


        protected void agpAdquiriente_OnActivarCompraPara(object sender, wucPersonaEventArgs e)
        {
            this.agpCompraPara.Visible = e.Activar;
        }

        protected void agpAdquiriente_OnClickDireccion(object sender, wucBotonEventArgs e)
        {
            //UpdatePanel pnl = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
            ScriptManager.RegisterClientScriptBlock(this.up_adquiriente, this.up_adquiriente.GetType(), "AdqDir", e.Url, false);
        }

        protected void agpAdquiriente_OnClickTelefono(object sender, wucBotonEventArgs e)
        {
            //UpdatePanel pnl = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
            ScriptManager.RegisterClientScriptBlock(this.up_adquiriente, this.up_adquiriente.GetType(), "AdqTel", e.Url, false);
        }

        protected void agpAdquiriente_OnClickCorreo(object sender, wucBotonEventArgs e)
        {
            //UpdatePanel pnl = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
            ScriptManager.RegisterClientScriptBlock(this.up_adquiriente, this.up_adquiriente.GetType(), "AdqCor", e.Url, false);
        }

        protected void agpCompraPara_OnClickDireccion(object sender, wucBotonEventArgs e)
        {
            //UpdatePanel pnl = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
            ScriptManager.RegisterClientScriptBlock(this.up_adquiriente, this.up_adquiriente.GetType(), "ParaDir", e.Url, false);
        }

        protected void agpCompraPara_OnClickTelefono(object sender, wucBotonEventArgs e)
        {
            //UpdatePanel pnl = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
            ScriptManager.RegisterClientScriptBlock(this.up_adquiriente, this.up_adquiriente.GetType(), "ParaTel", e.Url, false);
        }

        protected void agpCompraPara_OnClickCorreo(object sender, wucBotonEventArgs e)
        {
            //UpdatePanel pnl = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
            ScriptManager.RegisterClientScriptBlock(this.up_adquiriente, this.up_adquiriente.GetType(), "ParaCorr", e.Url, false);
        }

		protected void bt_guardar_Click(object sender, EventArgs e)
		{
			this.Add_Operacion();
		}
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Add_Operacion();
        }
        protected void cmdLink_Click2(object sender, EventArgs e)
        {
            this.Add_Operacion();
        }

		protected void bt_limpiar_Click(object sender, EventArgs e)
		{
			Page.Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);
		}

	

		protected void Add_Operacion()
		{
            double para = 0;
            double adq = 0;
            //if (!this.agp_adquirente.Guardar_Form())
            //{
            //    ScriptManager.RegisterStartupScript(this.up_operacion, this.up_operacion.GetType(), "alert_adquirente", string.Format("alert('{0}');", this.agp_adquirente.MensajeError), true);
            //    return;
            //}

            if (this.dl_cliente.SelectedValue == "15" && this.txtNumOperacion.Text == "")
		    {
                FuncionGlobal.alerta_updatepanel("Falta ingresar número de operación cliente", this.Page, up_operacion);
                return;
		    }
            if (this.txt_fecha_factura.Text == "")
            {
                FuncionGlobal.alerta_updatepanel("Falta ingresar la fecha de Facturacion", this.Page, up_operacion);
                return;
            }
            if (this.txt_factura.Text == "")
            {
                FuncionGlobal.alerta_updatepanel("Falta ingresar la Factura", this.Page, up_operacion);
                return;
            }

            if (this.agp_adquirente.Guardar_Form())
            {
                if (this.agp_adquirente.InfoPersona != null)
                {
                    adq = this.agp_adquirente.InfoPersona.Rut;
                }
                else
                {
                    adq = this.agp_adquirente.getRut();
                }
            }
            if (this.agpCompraPara.Visible)
            {
                if (this.agpCompraPara.Guardar_Form())
                {
                    if (this.agpCompraPara.InfoPersona != null)
                    {
                        para = this.agpCompraPara.InfoPersona.Rut;
                    }
                    else
                    {
                        para = this.agpCompraPara.getRut();
                    }
                }
            }
            var tipoOper = Request.QueryString["tipo_operacion"].ToString();

		    var numOperacion = "0";

            if(tipoOper.Trim() == "STMH")
            {
                numOperacion = this.txtNumOperacion.Text;
            }

		    int add = new OperacionBC().add_operacion(Convert.ToInt32(ViewState["id_solicitud"]),
		                                              Convert.ToInt16(ViewState["id_cliente"]),
		                                              ViewState["tipo_operacion"].ToString(), (string) (Session["usrname"]),0,
                                                      numOperacion, Convert.ToInt32(this.dl_sucursal.SelectedValue), 0);
            this.agpDatosGrabar.Id_solicitud = add;
            this.agpDatosGrabar.Carga_vent = Convert.ToInt32(this.dl_cargo_venta.SelectedValue.Trim());
            if (hdIdOrdenTrabajo.Value.Trim() != "0") { FuncionGlobal.UpdateTipoOperacionOrdenTrabajo(ViewState["tipo_operacion"].ToString(), Convert.ToInt32(hdIdOrdenTrabajo.Value), add); }

            if (!this.agp_vehiculo.Guardar_Form(add))
            {
                ScriptManager.RegisterStartupScript(this.up_operacion, this.up_operacion.GetType(), "alert_vehiculo", string.Format("alert('{0}');", this.agp_vehiculo.MensajeError), true);
                return;
            }
            Int32 factura = 0;
            if (this.txt_factura.Text != "")
            {
                factura =Convert.ToInt32(this.txt_factura.Text);
            }

			ViewState["id_solicitud"] = add.ToString();

			if (add != 0)
			{
                string output = new PreinscripcionBC().add_preinscripcion(add, Convert.ToDouble(factura), "", "", "", "", this.dl_cargo_venta.SelectedValue.ToString(),this.txt_fecha_factura.Text,
                                                                    Convert.ToDouble(adq), this.dl_financiera.SelectedValue, "SP", Convert.ToDouble(para),this.dl_forma_pago.SelectedValue , Convert.ToDouble(this.txt_neto.Text), "",
                                                                    0, Convert.ToInt16(this.dl_sucursal.SelectedValue), Convert.ToInt16(this.dl_sucursal.SelectedValue),
                                                                    Convert.ToDouble(0),Convert.ToDouble(0),"","0");
				//Si hay un error guardando la operación
				if (output != "")
				{
					ScriptManager.RegisterStartupScript(this.up_operacion, this.up_operacion.GetType(), "alert_add_PermySeg", string.Format("alert('{0}');", output), true);
					return;
				}

				string add_or = new EstadooperacionBC().add_estado_orden(Convert.ToInt32(add), 1, ViewState["tipo_operacion"].ToString(), "", (string)(Session["usrname"]));

			
			}

            if (ViewState["id_cliente"].ToString() == "15")
            {
                var patente_op_tipo = ViewState["tipo_operacion"];
                new BienesNumeroClienteBC().act_datos_bien(Convert.ToInt32(txtNumOperacion.Text),//numeroOperacion   int, 
                                                           Convert.ToInt32(txt_factura.Text),           //factura     numeric(18),   
                                                           Convert.ToInt32(dl_bien.SelectedValue),      //id_bien     numeric(18),
                                                           Convert.ToInt32(add),                        //id_solicitud    numeric(18),
                                                           patente_op_tipo.ToString(),                             //patente     varchar(6), 
                                                           Convert.ToDateTime(txt_fecha_factura.Text),  //fecha_emision_factura  DATETIME,
                                                           Convert.ToInt32(dlInstruccionPago.Text),     //instruccion_de_pago  int,
                                                           Convert.ToInt32(!string.IsNullOrEmpty((ckNormaEuro.Text)) ? 1 : 0)//normaEuro int = 0,  
                                                           );
            }

        }

		protected void Busca_Operacion()
		{
			Preinscripcion solicitud = new PreinscripcionBC().GetpreinscripcionbyIdSolicitud(Convert.ToInt32(ViewState["id_solicitud"].ToString()));
			if (solicitud != null)
			{
				this.Carga_Operacion(solicitud.Operacion.Id_solicitud);
			}
            
		}

		protected void Busca_Operacion_Por_Patente()
		{
			DatosVehiculo solicitud = new DatosvehiculoBC().getDatovehiculobypatente(this.agp_vehiculo.Vehiculo.Patente);
			if (solicitud != null)
			{
				this.Carga_Operacion(solicitud.Id_solicitud);
			}
		}

		protected void Cambiar_Titulo()
		{
			this.lbl_titulo.Text = new TipooperacionBC().getTipooperacion(ViewState["tipo_operacion"].ToString()).Operacion;
		}

		protected void Carga_Operacion(Int32 solicitud)
		{
            Preinscripcion minscripcion = new PreinscripcionBC().GetpreinscripcionbyIdSolicitud(solicitud);
            DatosVehiculo mvehiculo = new DatosvehiculoBC().getDatovehiculo(solicitud);
			this.dl_sucursal.SelectedValue = minscripcion.Sucursal_origen.Id_sucursal.ToString();
            this.txt_factura.Text = minscripcion.N_factura.ToString();

		
            this.txt_neto.Text = minscripcion.Neto_factura.ToString();
		
            this.dl_financiera.SelectedValue = minscripcion.Bancofinanciera.Codigo.Trim();
            this.dl_forma_pago.SelectedValue = minscripcion.Tipo_pago_factura.Trim();
            this.dl_cargo_venta.SelectedValue = minscripcion.Cargo_venta;
            //this.agp_vehiculo.Vehiculo.Patente = mvehiculo.Patente;
            this.agp_vehiculo.Mostrar_Form(solicitud);
            this.txt_fecha_factura.Text = minscripcion.Fechafactura.ToString();
            //this.agp_adquirente.Mostrar_Form(minscripcion.Adquiriente.Rut);
			this.agp_adquirente.Mostrar_Form(minscripcion.Adquiriente.Rut);
            if (minscripcion.Compra_para != null)
            {
                this.agp_adquirente.setCompraPara(true);
                this.agpCompraPara.Visible = true;
                this.agpCompraPara.Mostrar_Form(minscripcion.Compra_para.Rut);
            }
            agpDatosGrabar.Id_solicitud = Convert.ToInt32(solicitud);
            this.agpDatosGrabar.mostrar_operacion(solicitud.ToString());

          

		}

        protected void txt_factura_TextChanged(object sender, EventArgs e)
        {
            Preinscripcion add = new PreinscripcionBC().Getpreinscripcionbyfactura(Convert.ToInt16(this.dl_cliente.SelectedValue), Convert.ToDouble(this.txt_factura.Text.Trim()));

            if (add!= null)
            {
                this.Carga_Operacion_factura(add.Operacion.Id_solicitud);
            }
        }

        protected void txt_neto_TextChanged(object sender, EventArgs e)
        {
            
        }
        protected void Carga_Operacion_factura(Int32 solicitud)
        {
            Preinscripcion minscripcion = new PreinscripcionBC().GetpreinscripcionbyIdSolicitud(solicitud);
            DatosVehiculo mvehiculo = new DatosvehiculoBC().getDatovehiculo(solicitud);
            this.dl_sucursal.SelectedValue = minscripcion.Sucursal_origen.Id_sucursal.ToString();
            this.txt_factura.Text = minscripcion.N_factura.ToString();

            this.agp_vehiculo.Mostrar_Form(solicitud);

            //this.agp_adquirente.Rut = minscripcion.Adquiriente.Rut;
            this.agp_adquirente.Mostrar_Form(minscripcion.Adquiriente.Rut);

        }
        protected void ib_comgasto_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void ib_gasto_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void ib_poliza_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void dl_forma_pago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.dl_forma_pago.SelectedValue == "1")
            {
                this.dl_financiera.SelectedValue = "CON";
            }
        }

        protected void dl_financiera_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void dl_cliente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void dl_cargo_venta_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void txtNumOperacion_TextChanged(object sender, EventArgs e)
        {
            if (txtNumOperacion.Text != "0" && txtNumOperacion.Text != "")
            {
                dl_bien.Visible = true;
                lbl_bien.Visible = true;
                FuncionGlobal.BienesByNumeroCliente(dl_bien, txtNumOperacion.Text, ViewState["tipo_operacion"].ToString());
            }
        }
	}
}