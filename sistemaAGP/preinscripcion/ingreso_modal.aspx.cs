using System;     
using System.Configuration; 
using System.Globalization;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Xml;
using System.Xml.Linq;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using System.Text;
using CENTIDAD;
using CNEGOCIO;
using iTextSharp.text.pdf;
using sistemaAGP.integracionAG;
using sistemaAGP.IntegracionIndumotora;
using sistemaAGP.IntegracionMarubeni;

namespace sistemaAGP
{
    public partial class ingreso_modal : System.Web.UI.Page
    {

        private string id_solicitud = "0";
        private string id_cliente;
        private string tipo_operacion;
        public int IdOrdenTrabajo= 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            agpAdquirente.OnActivarCompraPara += new wucPersonaEventHandler(agpAdquiriente_OnActivarCompraPara);
            agpAdquirente.OnClickDireccion += new wucBotonEventHandler(agpAdquiriente_OnClickDireccion);
            agpAdquirente.OnClickTelefono += new wucBotonEventHandler(agpAdquiriente_OnClickTelefono);
            agpAdquirente.OnClickCorreo += new wucBotonEventHandler(agpAdquiriente_OnClickCorreo);
            agpCompraPara.OnClickDireccion += new wucBotonEventHandler(agpCompraPara_OnClickDireccion);
            agpCompraPara.OnClickTelefono += new wucBotonEventHandler(agpCompraPara_OnClickTelefono);
            agpCompraPara.OnClickCorreo += new wucBotonEventHandler(agpCompraPara_OnClickCorreo);

            IdOrdenTrabajo= Convert.ToInt32(FuncionGlobal.FuctionDesEncriptar(Request.QueryString["idOrdenTrabajo"]));


            id_solicitud = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_solicitud"]);
            id_cliente = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_cliente"]);
            tipo_operacion = Request.QueryString["tipo_operacion"].ToUpper(); 
             

            if (IsPostBack) return;

            if (id_cliente == "15")
            {
                lblInstruccionPago.Visible = true;
                dlInstruccionPago.Visible = true;
                lblNormaEuro.Visible = true;
                ckNormaEuro.Visible = true;
                FuncionGlobal.comboparametro(dlInstruccionPago, "INPAG"); //INSTRUCCION DE PAGO LEASING
            }

            if (id_cliente == "15")
            {
                txt_numero_emisor.AutoPostBack = true;
            }

            cambiar_titulo();
            FuncionGlobal.comboparametro(dlImpuestoVerde, "IMPV");
            FuncionGlobal.comboclientesbyusuario((string)(Session["usrname"]), this.dl_cliente);
            dl_cliente.SelectedValue = id_cliente;
            FuncionGlobal.combosucursalbyclienteandUsuario(dl_sucursal_origen, Convert.ToInt16(this.dl_cliente.SelectedValue), (string)(Session["usrname"]));
            FuncionGlobal.combosucursalbyclienteandUsuario(dl_sucursal_destino, Convert.ToInt16(this.dl_cliente.SelectedValue), (string)(Session["usrname"]));


            buscar_cliente_vendedor(); 
            FuncionGlobal.comboparametro(dl_forma_pago, "FOPA"); 
            FuncionGlobal.comboparametro(dl_cargo_venta, "CAVE");
            
            FuncionGlobal.combobanco(dl_financiera, Convert.ToInt32(id_cliente));

            if (tipo_operacion.Trim().ToUpper() == "REN")
            {
                agpVendedor.Visible = false;
                pnl_datos_factura.Visible = false;
                txt_factura.Text = "0";
                txt_fecha_factura.Text = "";
                txt_neto.Text = "0";
                lbl_forma_pago.Visible = false;
                dl_forma_pago.SelectedValue = "1";
                dl_forma_pago.Visible = false;
                lbl_financiera.Visible = false;
                dl_financiera.SelectedValue = "CON";
                dl_financiera.Visible = false;
                lbl_terminacion.Visible = false;
                txt_terminacion.Text = "NO";
                txt_terminacion.Visible = false;
                lbl_nota_venta.Visible = false;
                txt_nota_venta.Text = "0";
                txt_nota_venta.Visible = false; 
                dl_sucursal_origen.Focus();
            }
            else
            {
                txt_factura.Focus();
            }

            busca_operacion();
            hdIdOrdenTrabajo.Value = "0";
            if (IdOrdenTrabajo == 0) return;
            hdIdOrdenTrabajo.Value = IdOrdenTrabajo.ToString(CultureInfo.InvariantCulture);
            var otra = new OrdenTrabajoBC().GetOrdenTrabajo(IdOrdenTrabajo);
            BuscaOrdenTrabajo(otra);
            agpVehiculo.OrdenTrabajo = otra;
            agpAdquirente.Mostrar_Form(Convert.ToInt32(otra.RutAdquiriente.Substring(0,otra.RutAdquiriente.Length-1)));

            if(otra.TieneCompraPara)
            {
                this.agpAdquirente.setCompraPara(true);
                this.agpCompraPara.Visible = true;
                this.agpCompraPara.Mostrar_Form(otra.CompraParaRut);
                this.agpAdquirente.HabilitarCompraPara = otra.TieneCompraPara;
            }
            
        }

        protected void cambiar_titulo()
        {
            TipoOperacion p = new TipooperacionBC().getTipooperacion(this.tipo_operacion);
            this.Title = p.Operacion;
            this.lbl_titulo.Text = p.Operacion;
            p = null;
        }

        protected void agpAdquiriente_OnActivarCompraPara(object sender, wucPersonaEventArgs e)
        {
            this.agpCompraPara.Visible = e.Activar;
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

      
        protected void dl_cliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            FuncionGlobal.combosucursalbyclienteandUsuario(this.dl_sucursal_origen, Convert.ToInt16(this.dl_cliente.SelectedValue), (string)(Session["usrname"]));
            FuncionGlobal.combosucursalbyclienteandUsuario(this.dl_sucursal_destino, Convert.ToInt16(this.dl_cliente.SelectedValue), (string)(Session["usrname"])); 

            buscar_cliente_vendedor();
        }

     

        protected void dl_comuna_SelectedIndexChanged(object sender, EventArgs e) { }

        protected void txt_factura_Leave(object sender, EventArgs e)
        { 
            double rut_emisor = agpVendedor.getRut();
          
            var cli = new ClienteBC().getClientePorRut(rut_emisor);
            if (cli == null) return;
            switch (cli.Id_webservice)
            {
                case 1:
                    getDatosFacturaWS();

                    break;
                case 3:
                    getDatosFacturaWSIndumotora();
                    break;
                case 4:
                    getDatosFacturaWSMarubeni();
                    break;
                case 5:
                    getDatosFacturaWSDitec();
                    break;
            }
        }

        private bool busca_operacion_por_factura()
        {
            bool resp = false;
            if (this.txt_factura.Text.Trim() == "") return resp;
            Int16 id_cliente = Convert.ToInt16(this.dl_cliente.SelectedValue);
            double rut_emisor = this.agpVendedor.getRut();
            double nro_factura = Convert.ToDouble(this.txt_factura.Text);
            //Preinscripcion mpreinscripcion = new PreinscripcionBC().Getpreinscripcionbyfactura(id_cliente, nro_factura);
            //Preinscripcion mpreinscripcion = new PreinscripcionBC().GetpreinscripcionbyfacturayTipo(id_cliente, nro_factura, this.tipo_operacion);
            Preinscripcion mpreinscripcion = new PreinscripcionBC().GetpreinscripcionbyfacturayTipo(id_cliente, rut_emisor, nro_factura, this.tipo_operacion);
            if (mpreinscripcion != null)
            {
                resp = true;
                //this.lbl_operacion.Visible = true;
                //this.lbl_numero.Visible = true;
                //this.ib_gasto.Visible = true;
                //this.ib_poliza.Visible = true;
                //this.ib_comgasto.Visible = true;
                ////this.lbl_operacion.Text = "Operación de Primera Inscripción Numero:";
                //this.lbl_operacion.Text = "Número de Operación:";
                //this.lbl_numero.Text = Convert.ToString(mpreinscripcion.Operacion.Id_solicitud);
                //this.ib_gasto.Attributes.Add("OnClick", "javascript:window.showModalDialog('../operacion/gastooperacion.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(lbl_numero.Text.Trim()) + "','#1','dialogHeight: 350px; dialogWidth: 900px;dialogTop: 190px; dialogLeft: 220px; edge: Raised; center: Yes;help: No; resizable: No; status: No;');");
                //this.ib_poliza.Attributes.Add("OnClick", "javascript:window.showModalDialog('../administracion/mPoliza.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(lbl_numero.Text.Trim()) + "&id_cliente=" + FuncionGlobal.FuctionEncriptar(id_cliente.ToString()) + "','','status:false;dialogWidth:700px;dialogHeight:400px')");
                //this.ib_comgasto.Attributes.Add("OnClick", "javascript:window.open('../reportes/view_comprobante_cobro.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(lbl_numero.Text.Trim()) + "','_blank','height=355,width=500, top=150,left=150,status=no,toolbar=no,menubar=no,l ocation=no,scrollbars=no,resizable=yes,copyhistory= false')");


                this.dl_cliente.SelectedValue = mpreinscripcion.Operacion.Cliente.Id_cliente.ToString();
                FuncionGlobal.combosucursalbyclienteandUsuario(this.dl_sucursal_origen, Convert.ToInt16(this.dl_cliente.SelectedValue), (string)(Session["usrname"]));
                FuncionGlobal.combosucursalbyclienteandUsuario(this.dl_sucursal_destino, Convert.ToInt16(this.dl_cliente.SelectedValue), (string)(Session["usrname"]));
                this.txt_factura.Text = mpreinscripcion.N_factura.ToString();

                //**datos vendedor
                this.agpVendedor.Mostrar_Form(mpreinscripcion.Rut_vendedor);

                //**datos vehiculo
                this.agpVehiculo.Mostrar_Form(mpreinscripcion.Operacion.Id_solicitud);
             
                //this.txt_patente.Text = this.agpVehiculo.Vehiculo.Patente.Trim();
                //if (mpreinscripcion.Dato_vehiculo != null) {
                //    this.dl_tipo_vehiculo.SelectedValue = mpreinscripcion.Dato_vehiculo.Tipo_vehiculo.Codigo;
                //    this.dl_marca_vehiculo.SelectedValue = Convert.ToString(mpreinscripcion.Dato_vehiculo.Marca.Id_marca);
                //    this.txt_modelo_vehiculo.Text = mpreinscripcion.Dato_vehiculo.Modelo;
                //    this.txt_ano_vehiculo.Text = mpreinscripcion.Dato_vehiculo.Ano.ToString();
                //    this.txt_cilindrada.Text = mpreinscripcion.Dato_vehiculo.Cilindraje;
                //    this.txt_puertas.Text = mpreinscripcion.Dato_vehiculo.Npuerta.ToString();
                //    this.txt_asientos.Text = mpreinscripcion.Dato_vehiculo.Nasiento.ToString();
                //    this.txt_peso_bruto.Text = mpreinscripcion.Dato_vehiculo.Pesobruto.ToString();
                //    this.txt_peso_carga.Text = mpreinscripcion.Dato_vehiculo.Carga.ToString();
                //    this.dl_combustible.SelectedValue = mpreinscripcion.Dato_vehiculo.Combustible.Trim();
                //    this.txt_color.Text = mpreinscripcion.Dato_vehiculo.Color;
                //    this.txt_motor.Text = mpreinscripcion.Dato_vehiculo.Motor;
                //    this.txt_chasis.Text = mpreinscripcion.Dato_vehiculo.Chassis;
                //    this.txt_patente.Text = mpreinscripcion.Dato_vehiculo.Patente.Trim();
                //}

                //**datos negocio
                this.txt_neto.Text = mpreinscripcion.Neto_factura.ToString();
                this.txt_fecha_factura.Text = string.Format("{0:dd/MM/yyyy}", mpreinscripcion.Fechafactura);
                this.dl_sucursal_origen.SelectedValue = mpreinscripcion.Sucursal_origen.Id_sucursal.ToString();
                this.dl_sucursal_destino.SelectedValue = mpreinscripcion.Sucursal_destino.Id_sucursal.ToString();
                this.dl_forma_pago.SelectedValue = mpreinscripcion.Tipo_pago_factura.Trim();
                this.dl_financiera.SelectedValue = mpreinscripcion.Bancofinanciera.Codigo.Trim();
                //this.txt_poliza.Text = mpreinscripcion.N_poliza;
                //this.dl_distribuidor_poliza.SelectedValue = mpreinscripcion.Distribuidor_poliza.Codigo.Trim();
                this.dl_cargo_venta.SelectedValue = mpreinscripcion.Cargo_venta.Trim();
                //this.dl_tipo_tramite.SelectedValue = mpreinscripcion.Tipo_tramite.Trim();
                //this.dl_notaria.SelectedValue = mpreinscripcion.Legalizar.Trim();
                this.txt_terminacion.Text = mpreinscripcion.Terminacion_especial;
                //this.dl_tag.SelectedValue = mpreinscripcion.Tag.Trim();
                this.txt_nota_venta.Text = mpreinscripcion.Nota_venta.ToString();

                //**adquiriente
                if (mpreinscripcion.Adquiriente != null)
                { 
                    agpAdquirente.Mostrar_Form(mpreinscripcion.Adquiriente.Rut);
                }
                if (mpreinscripcion.Compra_para != null)
                {
                    agpAdquirente.setCompraPara(true);
                    agpCompraPara.Visible = true;
                    agpCompraPara.Mostrar_Form(mpreinscripcion.Compra_para.Rut);
                    
                }
              
            }
            return resp;
        }

        public void BuscaOrdenTrabajo(CENTIDAD.OrdenTrabajo otra)  {
           
            txt_factura.Text = otra.NumeroFactura.Trim();
            txt_fecha_factura.Text = Convert.ToDateTime(otra.FechaFactura.Trim()).ToShortDateString();
            txt_neto.Text = otra.FacturaNeto.Trim();
            dl_sucursal_origen.SelectedValue = otra.IdSucursal.ToString(CultureInfo.InvariantCulture);
            dl_forma_pago.SelectedValue = otra.CodigoFormaPago.Trim();

            var usuario = Convert.ToString(Session["usrname"]).Trim();

            if (usuario != "153636613" && usuario != "17483833k" && usuario != "141548085"
                && usuario != "130055087" && usuario != "116333627")
            {
                dl_forma_pago.SelectedValue = otra.ConCreditoAmicar ? "2" : "0";
                dl_forma_pago.Enabled = !otra.ConCreditoAmicar;
            }

            dl_cargo_venta.SelectedValue = otra.QuienPaga.Trim();
            txt_terminacion.Text = otra.TmEspecial.Trim();
            txt_nota_venta.Text = otra.NumeroOrden.Trim();
            txt_cit.Text = otra.VehiculoCit.Trim();
            dlImpuestoVerde.SelectedValue = otra.ImpuestoVerde;


        }

        private void busca_operacion()
        {
            var mpreinscripcion = new PreinscripcionBC().GetpreinscripcionbyIdSolicitud(Convert.ToInt32(id_solicitud));
            if (mpreinscripcion == null) return;
            
            txt_numero_emisor.Text = mpreinscripcion.Operacion.Numero_cliente.Trim();
            txt_cit.Text = mpreinscripcion.Cit;
            agpDatosGrabar.Id_solicitud = Convert.ToInt32(id_solicitud);
            agpDatosGrabar.mostrar_operacion(id_solicitud);
            // trae dato  impuesto verde: Si/No 
            dlImpuestoVerde.SelectedValue = mpreinscripcion.TieneImpuestoVerde.Trim();
            var usrname = Convert.ToString(Session["usrname"]).Trim();
            if (this.dlImpuestoVerde.SelectedValue.Trim() != "0" && (usrname != "116333627" || usrname != "153636613" || usrname != "15678754k" || usrname != "141548085"))
            {
                dlImpuestoVerde.Enabled = false;
            }
            dl_cliente.SelectedValue = mpreinscripcion.Operacion.Cliente.Id_cliente.ToString();
            FuncionGlobal.combosucursalbyclienteandUsuario(dl_sucursal_origen, Convert.ToInt16(dl_cliente.SelectedValue), (string)(Session["usrname"]));
            FuncionGlobal.combosucursalbyclienteandUsuario(dl_sucursal_destino, Convert.ToInt16(dl_cliente.SelectedValue), (string)(Session["usrname"]));
            txt_factura.Text = mpreinscripcion.N_factura != 0 ? mpreinscripcion.N_factura.ToString() : "";
            //**datos vehiculo
            //agpVehiculo.Id_solicitud = mpreinscripcion.Operacion.Id_solicitud;
            this.agpVehiculo.Mostrar_Form(mpreinscripcion.Operacion.Id_solicitud);
              

            //**datos vendedor
            this.agpVendedor.Mostrar_Form(mpreinscripcion.Rut_vendedor);

            //**datos negocio
            this.txt_neto.Text = mpreinscripcion.Neto_factura.ToString();
            if (mpreinscripcion.Fechafactura != Convert.ToDateTime("01/01/1001"))
                this.txt_fecha_factura.Text = string.Format("{0:dd/MM/yyyy}", mpreinscripcion.Fechafactura);
            else
                this.txt_fecha_factura.Text = "";
            this.dl_sucursal_origen.SelectedValue = mpreinscripcion.Sucursal_origen.Id_sucursal.ToString();
            this.dl_sucursal_destino.SelectedValue = mpreinscripcion.Sucursal_destino.Id_sucursal.ToString();
            this.dl_forma_pago.SelectedValue = mpreinscripcion.Tipo_pago_factura.Trim();
            this.dl_financiera.SelectedValue = mpreinscripcion.Bancofinanciera.Codigo.Trim();
            //this.txt_poliza.Text = mpreinscripcion.N_poliza;
            //this.dl_distribuidor_poliza.SelectedValue = mpreinscripcion.Distribuidor_poliza.Codigo.Trim();
            this.dl_cargo_venta.SelectedValue = mpreinscripcion.Cargo_venta.Trim();
            //this.dl_tipo_tramite.SelectedValue = mpreinscripcion.Tipo_tramite.Trim();
            //this.dl_notaria.SelectedValue = mpreinscripcion.Legalizar.Trim();
            this.txt_terminacion.Text = mpreinscripcion.Terminacion_especial;
            //this.dl_tag.SelectedValue = mpreinscripcion.Tag.Trim();
            this.txt_nota_venta.Text = mpreinscripcion.Nota_venta.ToString();

            //**adquiriente
            if (mpreinscripcion.Adquiriente != null)
            {
                this.agpAdquirente.Mostrar_Form(mpreinscripcion.Adquiriente.Rut);
            }
            if (mpreinscripcion.Compra_para != null)
            {
                this.agpAdquirente.setCompraPara(true);
                this.agpCompraPara.Visible = true;
                this.agpCompraPara.Mostrar_Form(mpreinscripcion.Compra_para.Rut);
            }
        }

        protected void txt_rut_Leave(object sender, EventArgs e) { }

        protected void txt_rut_para_Leave(object sender, EventArgs e) { }

        private void busca_persona_para(Double rut) { }

        private void busca_persona(double rut) { }

        protected void bt_limpia_persona_Click(object sender, EventArgs e) { }

        protected void bt_limpia_para_Click(object sender, EventArgs e) { }

        protected void ib_adquiriente_Click(object sender, ImageClickEventArgs e) { }


        protected void cmdLink_Click1(object sender, EventArgs e)
        {
            agpDatosGrabar.ID = "0";
            agpDatosGrabar.Id_solicitud = 0;
            this.id_solicitud = "0";
            Page.Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);

        }
        protected void cmdLink_Click(object sender, EventArgs e)
        {
            agpDatosGrabar.ID = "0";
            agpDatosGrabar.Id_solicitud = 0;
            this.id_solicitud = "0";
            Page.Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);

        }

        protected void cmdLink_Click2(object sender, EventArgs e)
        {
            if (valida_ingreso() == true)
            {
                add_operacion();
                //pnl_ingreso_riesgo.Visible = true;
            }

            //this.ModalPopupExtender1.Show();
        }


        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if (valida_ingreso() == true)
            {
                add_operacion();

                //pnl_ingreso_riesgo.Visible = true;
            }

            //this.ModalPopupExtender1.Show();
        }

        private void add_operacion()
        {
            double rut = 0;
            double rut_para = 0;
            double rut_vendedor = 0;

            var tipOperacion = Request.QueryString["tipo_operacion"].ToString();

            if (id_cliente == "15")
            {
                if (txt_numero_emisor.Text == "")
                {
                    Response.Write("<script language=javascript>alert('Debe ingresar el número de operación banco');</script>");
                    return;
                }

                if (txt_factura.Text == "")
                {
                    Response.Write("<script language=javascript>alert('Debe ingresar el número de factura');</script>");
                    return;
                }

                var validaNumOperacionBanco = new OperacionBC().validaNumOperacionBanco(Convert.ToInt32(txt_numero_emisor.Text), Convert.ToInt32(txt_factura.Text));
                if (validaNumOperacionBanco.Numero_cliente != txt_numero_emisor.Text)
                {
                    Response.Write("<script language=javascript>alert('Por favor revise número de operacion o factura.');</script>");
                    return;
                }
                
            }

            if (this.agpVendedor.Guardar_Form())
            {
                if (this.agpVendedor.InfoPersona != null)
                {
                    rut_vendedor = this.agpVendedor.InfoPersona.Rut;
                }
                else
                {
                    rut_vendedor = this.agpVendedor.getRut();
                }
            }
            if (this.agpAdquirente.Guardar_Form())
            {
                if (this.agpAdquirente.InfoPersona != null)
                {
                    rut = this.agpAdquirente.InfoPersona.Rut;
                }
                else
                {
                    rut = this.agpAdquirente.getRut();
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
                    else
                    {
                        rut_para = this.agpCompraPara.getRut();
                    }
                }
            }

            Int32 add = new OperacionBC().add_operacion(Convert.ToInt32(id_solicitud),
                                                        Convert.ToInt16(this.dl_cliente.SelectedValue), this.tipo_operacion,
                                                        (string)(Session["usrname"]), 0, (this.txt_numero_emisor.Text.Trim() != "") ? txt_numero_emisor.Text.Trim() : "0",
                                                        Convert.ToInt32(this.dl_sucursal_origen.SelectedValue),
                                                        (this.txt_factura.Text != "")
                                                            ? Convert.ToInt32(this.txt_factura.Text)
                                                            : 0);

            this.agpDatosGrabar.Id_solicitud = add;
            this.agpDatosGrabar.Carga_vent = Convert.ToInt32(this.dl_cargo_venta.SelectedValue.Trim());
            if (add != 0)
            {
                //string tipo_tramite = dl_tipo_tramite.SelectedValue.ToString();
                //if (tipo_tramite == "0")
                //{
                //    tipo_tramite = "NIN";
                //}
                string add_PI = new PreinscripcionBC().add_preinscripcion(add,
                                                                (this.txt_factura.Text != "") ? Convert.ToDouble(this.txt_factura.Text) : 0,
                                                                "",
                                                                "",//this.dl_tag.SelectedValue,
                                                                "",
                                                                "",
                                                                this.dl_cargo_venta.SelectedValue,
                                                                this.txt_fecha_factura.Text,
                                                                rut,
                                                                this.dl_financiera.SelectedValue,
                                                                "SP",
                                                                rut_para,
                                                                this.dl_forma_pago.SelectedValue,
                                                                Convert.ToDouble(this.txt_neto.Text),
                                                                this.txt_terminacion.Text,
                                                                19,
                                                                Convert.ToInt16(this.dl_sucursal_origen.SelectedValue),
                                                                Convert.ToInt16(this.dl_sucursal_destino.SelectedValue),
                                                                Convert.ToDouble(this.txt_nota_venta.Text),
                                                                rut_vendedor, this.txt_cit.Text, dlImpuestoVerde.SelectedValue);



                if (add_PI == "")
                {
                    string add_or = new EstadooperacionBC().add_estado_orden(Convert.ToInt32(add), 1, "PI", "", (string)(Session["usrname"]));

                  
                }


                if (add_PI == "")
                {
                    string add_or = new EstadooperacionBC().add_estado_patente(Convert.ToInt32(add), this.agpVehiculo.GetPatente().Trim(), (string)(Session["usrname"]));
                }
                //aqui


                //hasta aqui

                if (add_PI == "")
                {
                    string addVeh = this.agpVehiculo.Guardar_Form(add);
                    if (addVeh != "")
                    {
                        UpdatePanel up = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
                        FuncionGlobal.alerta_updatepanel(addVeh, Page, up);
                    }
                }

                if (hdIdOrdenTrabajo.Value.Trim() != "0") { FuncionGlobal.UpdateTipoOperacionOrdenTrabajo(tipo_operacion, Convert.ToInt32(hdIdOrdenTrabajo.Value), add); }


                if (this.tipo_operacion.Trim() == "PITAG" || this.tipo_operacion.Trim() == "IPTAG" || tipo_operacion.Trim() == "IPSTG" || tipo_operacion.Trim() == "PSTAG" || tipo_operacion.Trim() == "PRTAG")
                {
                    string patente = "";
                    if (this.agpVehiculo.Getpatente().ToString() != null && this.agpVehiculo.Getpatente().ToString() != "")
                    {
                        patente = this.agpVehiculo.Getpatente().ToString();
                    }
                    string tag = new Codigo_TAGBC().add_Control_TAG(patente, Convert.ToInt32(add), "1", (string)(Session["usrname"]));
                }

                if (dl_cliente.SelectedValue == "84" || dl_cliente.SelectedValue == "58" || dl_cliente.SelectedValue == "14")
                {
                    if (dl_forma_pago.SelectedValue.Trim() == "2")
                    {
                        new OperacionBC().crear_garantia_prohibicion(add);
                    }
                }

                if (id_cliente == "15")
                {
                    var patente = "";
                    new BienesNumeroClienteBC().act_datos_bien(Convert.ToInt32(txt_numero_emisor.Text),//numeroOperacion   int, 
                                                               Convert.ToInt32(txt_factura.Text),           //factura     numeric(18),   
                                                               Convert.ToInt32(dl_bien.SelectedValue),      //id_bien     numeric(18),
                                                               Convert.ToInt32(add),                         //id_solicitud    numeric(18),
                                                               patente,                                     //patente     varchar(6) , 
                                                               Convert.ToDateTime(txt_fecha_factura.Text),  //fecha_emision_factura  DATETIME,
                                                               Convert.ToInt32(dlInstruccionPago.Text),     //instruccion_de_pago  int,
                                                               Convert.ToInt32(!string.IsNullOrEmpty((ckNormaEuro.Text))?1:0)//normaEuro     int = 0,  
                                                               );
                }
            }

            //this.lbl_operacion.Visible = true;
            //this.lbl_numero.Visible = true;

            //this.lbl_operacion.Text = "Operación de Primera Inscripción Numero:";
            //this.lbl_operacion.Text = "Número de Operación:";
            //this.lbl_numero.Text = Convert.ToString(add);


            //this.ib_gasto.Visible = true;
            //this.ib_gasto.Attributes.Add("OnClick", "javascript:window.showModalDialog('../operacion/gastooperacion.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(lbl_numero.Text.Trim()) + "','#1','dialogHeight: 350px; dialogWidth: 900px;dialogTop: 190px; dialogLeft: 220px; edge: Raised; center: Yes;help: No; resizable: No; status: No;');");

            //this.ib_poliza.Visible = true;
            //this.ib_poliza.Attributes.Add("OnClick", "javascript:window.showModalDialog('../administracion/mPoliza.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(lbl_numero.Text.Trim()) + "&id_cliente=" + FuncionGlobal.FuctionEncriptar(this.id_cliente.ToString()) + "','','status:false;dialogWidth:700px;dialogHeight:400px')");

            //this.ib_comgasto.Visible = true;
            //this.ib_comgasto.Attributes.Add("OnClick", "javascript:window.open('../reportes/view_comprobante_cobro.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(lbl_numero.Text.Trim()) + "&id_familia=" + FuncionGlobal.FuctionEncriptar(mfamilia.Id_familia.ToString()) + "','_blank','height=355,width=500, top=150,left=150,status=no,toolbar=no,menubar=no,l ocation=no,scrollbars=no,resizable=yes,copyhistory= false')");


            //this.btn_imprime_ingreso.Attributes.Add("OnClick", "javascript:window.open('../reportes/view_comprobante_ingreso.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(lbl_numero.Text.Trim()) + "&id_familia=" + FuncionGlobal.FuctionEncriptar(mfamilia.Id_familia.ToString()) + "','_blank','height=355,width=500, top=150,left=150,status=no,toolbar=no,menubar=no,l ocation=no,scrollbars=no,resizable=yes,copyhistory= false')"); 

            //getgastos();
        }

        //protected void bt_limpiar_Click(object sender, EventArgs e)
        //{
        //    this.lbl_numero.Text = "0";
        //    this.lbl_operacion.Text = "";
        //    Page.Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);
        //}

        private Boolean valida_ingreso()
        {
            string strchassis;

            UpdatePanel up = (UpdatePanel)this.Master.FindControl("UpdatePanel1");


            if (id_solicitud == "0")
            {
                strchassis = this.agpVehiculo.GetChassis().Trim();

                if ((string)(Session["usrname"]).ToString().Trim() != "153636613" && (string)(Session["usrname"]).ToString().Trim() != "116333627")
                {
                    string existe = new PreinscripcionBC().ValidaOperacionExistente(Convert.ToInt32(this.dl_cliente.SelectedValue),
                                                                Convert.ToInt32(txt_factura.Text),
                                                                this.tipo_operacion, strchassis);


                    if (existe.Trim() != "")
                    {
                        FuncionGlobal.alerta_updatepanel(existe.Trim(), Page, up);
                        return false;
                    }
                }
            }

            if (id_cliente == "15")
            {
                if (txt_numero_emisor.Text == "")
                {
                    //Response.Write("<script language=javascript>alert('Debe ingresar el número de operación banco');</script>");
                    FuncionGlobal.alerta_updatepanel("Debe ingresar el número de operación banco", Page, up);
                    return false;
                }

                if (Convert.ToInt32(txt_numero_emisor.Text) <= 0)
                {
                    //Response.Write("<script language=javascript>alert('Debe ingresar el número de operación banco');</script>");
                    FuncionGlobal.alerta_updatepanel("El número de operación banco no corresponde", Page, up);
                    return false;
                }

                if (txt_factura.Text == "")
                {
                    //Response.Write("<script language=javascript>alert('Debe ingresar el número de factura');</script>");
                    FuncionGlobal.alerta_updatepanel("Debe ingresar el número de factura", Page, up);
                    return false;
                }

                var validaNumOperacionBanco = new OperacionBC().validaNumOperacionBanco(Convert.ToInt32(txt_numero_emisor.Text), Convert.ToInt32(txt_factura.Text));
                if (validaNumOperacionBanco.Numero_cliente != txt_numero_emisor.Text)
                {
                    //Response.Write("<script language=javascript>alert('Por favor revise número de operacion o factura.');</script>");
                    FuncionGlobal.alerta_updatepanel("Por favor revise número de operacion o factura.", Page, up);
                    return false;
                }

                if (dl_bien.SelectedValue == "0")
                {
                    //Response.Write("<script language=javascript>alert('Debe ingresar el número de factura');</script>");
                    FuncionGlobal.alerta_updatepanel("Debe seleccionar un tipo de Bien", Page, up);
                    return false;
                }

                if (dlInstruccionPago.SelectedValue == "0")
                {
                    FuncionGlobal.alerta_updatepanel("Por favor indique forma de pago.", Page, up);
                    return false;
                }
            }

            //if (this.dl_tag.SelectedValue == "0")
            //{
            //    FuncionGlobal.alerta_updatepanel("Ingrese la opcion del TAG", Page, up);
            //    this.dl_tag.Focus();
            //    return false;
            //}
            if (this.dl_cargo_venta.Text.Trim() == "")
            {
                FuncionGlobal.alerta_updatepanel("Ingrese el cargo de venta", Page, up);
                this.dl_cargo_venta.Focus();
                return false;
            }
           
            if(this.dlImpuestoVerde.SelectedValue.Trim()=="0")
            {
                FuncionGlobal.alerta_updatepanel("Ingrese si tiene impuesto verde", Page, up);
                this.dlImpuestoVerde.Focus();
                return false;
            }

            if (this.txt_neto.Text.Trim() == "")
            {
                FuncionGlobal.alerta_updatepanel("Ingrese el valor neto de la factura", Page, up);
                this.txt_neto.Focus();
                return false;
            }
            if (this.id_cliente.Trim() == "15" && this.txt_numero_emisor.Text.Trim() == "")
            {
                FuncionGlobal.alerta_updatepanel("Ingrese el Numero Interno del CLiente", Page, up);
                this.txt_numero_emisor.Focus();
                return false;
            }
            if (this.dl_sucursal_origen.SelectedValue == "0")
            {
                FuncionGlobal.alerta_updatepanel("Ingrese la sucursal de origen", Page, up);
                this.dl_sucursal_origen.Focus();
                return false;
            }
            if (this.dl_sucursal_destino.SelectedValue == "0")
            {
                FuncionGlobal.alerta_updatepanel("Ingrese la sucursal de destino", Page, up);
                this.dl_sucursal_destino.Focus();
                return false;
            }


            if (!this.agpVehiculo.Validar_Form())
            {
                FuncionGlobal.alerta_updatepanel("Los datos de vehículo están incompletos o no corresponden", Page, up);
                return false;
            }

            if (this.dl_forma_pago.SelectedValue == "0")
            {
                FuncionGlobal.alerta_updatepanel("Ingrese la forma de pago", Page, up);
                this.dl_forma_pago.Focus();
                return false;
            }
            else if (this.dl_forma_pago.SelectedValue == "2" && (this.dl_financiera.SelectedValue == "CON" || this.dl_financiera.SelectedValue == "0"))
            {
                FuncionGlobal.alerta_updatepanel("Ingrese la financiera", Page, up);
                this.dl_financiera.Focus();
                return false;
            }
            if (this.txt_nota_venta.Text.Trim() == "") this.txt_nota_venta.Text = "0";
            return true;
        }

        protected void ib_comuna_Click(object sender, ImageClickEventArgs e) { }

        protected void ib_comuna_para_Click(object sender, ImageClickEventArgs e) { }

        protected void bt_guardar_Click(object sender, EventArgs e)
        {



        }

        protected void bt_caratula_Click(object sender, EventArgs e) { }

        protected void btnCancelar_Click(object sender, EventArgs e) { }

        protected void ib_gasto_Click(object sender, ImageClickEventArgs e) { }

        protected void dl_tipo_tramite_SelectedIndexChanged(object sender, EventArgs e) { }

        protected void dl_forma_pago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.dl_forma_pago.SelectedValue == "1")
            {
                this.dl_financiera.SelectedValue = "CON";
            }
        }

        protected void getDatosFacturaWS()
        {
            if (this.txt_factura.Text.Trim() == "") return;
            try
            {
                System.Net.ServicePointManager.Expect100Continue = false;
                WSIntegracionAGPSoapClient ws = new WSIntegracionAGPSoapClient();
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
                                    numeroAsientos = (f.Element("datosVehiculo") != null) ? f.Element("datosVehiculo").Element("numeroAsientos").Value : "",
                                    CIT = (f.Element("datosVehiculo") != null) ? f.Element("datosVehiculo").Element("CIT").Value : ""
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
                    }

                    this.txt_cit.Text = q.datosVehiculo.vin.Trim().ToString();

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
                    FuncionGlobal.BuscarValueCombo(this.dl_sucursal_origen, new SucursalclienteBC().getSucursalParidadAG(q.datosFactura.codigoSucursal.Trim()).Id_sucursal.ToString());
                    FuncionGlobal.BuscarValueCombo(this.dl_sucursal_destino, new SucursalclienteBC().getSucursalParidadAG(q.datosFactura.codigoSucursal.Trim()).Id_sucursal.ToString());

                    // Carga datos del adquirente
                    if (new PersonaBC().getpersonabyrut(Convert.ToDouble(q.datosAdquirente.rut)) == null)
                    {
                        this.agpAdquirente.setRut(q.datosAdquirente.rut.Trim());
                        this.agpAdquirente.setDV(q.datosAdquirente.dv.Trim());
                        this.agpAdquirente.setNombre(q.datosAdquirente.nombre.Trim());
                        this.agpAdquirente.setPaterno(q.datosAdquirente.paterno.Trim());
                        this.agpAdquirente.setMaterno(q.datosAdquirente.materno.Trim());
                    }
                    else
                    {
                        this.agpAdquirente.Mostrar_Form(Convert.ToDouble(q.datosAdquirente.rut));
                    }
                    break;
                }
            }
            catch (Exception ex)
            {
                UpdatePanel up = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
                FuncionGlobal.alerta_updatepanel(ex.Message, Page, up);
            }
        }

        //protected void ib_poliza_Click(object sender, ImageClickEventArgs e) { }

        protected void buscar_cliente_vendedor()
        {
            Cliente c = new ClienteBC().getcliente(Convert.ToInt16(this.dl_cliente.SelectedValue));
            this.agpVendedor.Mostrar_Form(c.Persona.Rut);
        }

        //protected void ib_comgasto_Click(object sender, ImageClickEventArgs e)
        //{

        //}


        protected void getDatosFacturaWSIndumotora()
        {
            if (this.txt_factura.Text.Trim() == "") return;
            try
            {

                Respuesta c = new Respuesta();


                WService_agp_autoproSoapClient x = new WService_agp_autoproSoapClient();

                c = x.Integra_Agp("795674209", this.txt_factura.Text.Trim());




                var query = from f in c.Mae_Adquiriente.Descendants("Datos")
                            select new
                            {


                                rut = (f.Element("RutCliente") != null) ? f.Element("RutCliente").Value : "",
                                dv = (f.Element("TxtDijitoCliente") != null) ? f.Element("TxtDijitoCliente").Value : "",
                                razon_social = (f.Element("TxtSufijoCliente") != null) ? f.Element("TxtSufijoCliente").Value : "",
                                nombre = (f.Element("NombreCliente") != null) ? f.Element("NombreCliente").Value : "",
                                paterno = (f.Element("ApellidoPaterno") != null) ? f.Element("ApellidoPaterno").Value : "",
                                materno = (f.Element("ApellidoMaterno") != null) ? f.Element("ApellidoMaterno").Value : "",
                                direccion = (f.Element("Direccion") != null) ? f.Element("Direccion").Value : "",
                                numero = (f.Element("Numero") != null) ? f.Element("Numero").Value : "",
                                depto = (f.Element("Departamento") != null) ? f.Element("Departamento").Value : "",
                                region = (f.Element("Region") != null) ? f.Element("Region").Value : "",
                                ciudad = (f.Element("Ciudad") != null) ? f.Element("Ciudad").Value : "",
                                comuna = (f.Element("Comuna") != null) ? f.Element("Comuna").Value : "",
                                fono = (f.Element("Telefono") != null) ? f.Element("Telefono").Value : ""

                            };
                foreach (var q in query)
                {
                    // Carga datos del adquirente
                    if (new PersonaBC().getpersonabyrut(Convert.ToDouble(q.rut)) == null)
                    {
                        this.agpAdquirente.setRut(q.rut.Trim());
                        this.agpAdquirente.setDV(q.dv.Trim());
                        this.agpAdquirente.setNombre(q.nombre.Trim());
                        this.agpAdquirente.setPaterno(q.paterno.Trim());
                        this.agpAdquirente.setMaterno(q.materno.Trim());
                    }
                    else
                    {
                        this.agpAdquirente.Mostrar_Form(Convert.ToDouble(q.rut));
                    }
                    break;
                }




                var queryVE = from f in c.Mae_DatosVehiculos.Descendants("Datos")
                              select new
                              {


                                  tipoVehiculo = (f.Element("Tipo_Vehiculo") != null) ? f.Element("Tipo_Vehiculo").Value : "",
                                  marca = (f.Element("Marca") != null) ? f.Element("Marca").Value : "",
                                  descripModelo = (f.Element("Descrp_Modelo") != null) ? f.Element("Descrp_Modelo").Value : "",
                                  anio = (f.Element("Año_Comercial") != null) ? f.Element("Año_Comercial").Value : "",
                                  cilindraje = (f.Element("Cilindrada") != null) ? f.Element("Cilindrada").Value : "",
                                  numeroPuertas = (f.Element("Puertas") != null) ? f.Element("Puertas").Value : "",
                                  numeroAsientos = (f.Element("Asientos") != null) ? f.Element("Asientos").Value : "",
                                  pesoBruto = (f.Element("Peso_Bruto") != null) ? f.Element("Peso_Bruto").Value : "",
                                  carga = (f.Element("Carga") != null) ? f.Element("Carga").Value : "",
                                  combustible = (f.Element("Combustible") != null) ? f.Element("Combustible").Value : "",
                                  color = (f.Element("Color") != null) ? f.Element("Color").Value : "",
                                  motor = (f.Element("Motor") != null) ? f.Element("Motor").Value : "",
                                  chasis = (f.Element("Chasis") != null) ? f.Element("Chasis").Value : "",
                                  vin = (f.Element("Vin") != null) ? f.Element("Vin").Value : ""


                              };
                foreach (var q in queryVE)
                {
                    // Carga datos del vehículo
                    this.agpVehiculo.setTipoVehiculo(q.tipoVehiculo.Trim());
                    this.agpVehiculo.setMarca(q.marca.Trim());
                    this.agpVehiculo.setModelo(q.descripModelo.Trim());
                    this.agpVehiculo.setAnio(q.anio.Trim());
                    this.agpVehiculo.setCilindrada(q.cilindraje.Trim());
                    this.agpVehiculo.setPuertas(q.numeroPuertas.Trim());
                    this.agpVehiculo.setAsientos(q.numeroAsientos.Trim());
                    this.agpVehiculo.setPesoBruto(q.pesoBruto.Trim());
                    this.agpVehiculo.setPesoCarga(q.carga.Trim());
                    this.agpVehiculo.setCombustible(q.combustible.Trim());
                    this.agpVehiculo.setColor(q.color.Trim());
                    this.agpVehiculo.setMotor(q.motor.Trim());
                    this.agpVehiculo.setChasis(q.chasis.Trim());
                    this.agpVehiculo.setVin(q.vin.Trim());
                }



                var queryFA = from f in c.Mae_Facturas.Descendants("Datos")
                              select new
                              {



                                  Numero_Factura = (f.Element("Numero_Factura") != null) ? f.Element("Numero_Factura").Value : "",
                                  Tipo_Cliente = (f.Element("Tipo_Cliente") != null) ? f.Element("Tipo_Cliente").Value : "",
                                  Descrip_Sucursal = (f.Element("Descrip_Sucursal") != null) ? f.Element("Descrip_Sucursal").Value : "",
                                  Codigo_Sucursal = (f.Element("Codigo_Sucursal") != null) ? f.Element("Codigo_Sucursal").Value : "",
                                  Descrip_FormaPago = (f.Element("Descrip_FormaPago") != null) ? f.Element("Descrip_FormaPago").Value : "",
                                  Fecha_Factura = (f.Element("Fecha_Factura") != null) ? f.Element("Fecha_Factura").Value : "",
                                  Neto = (f.Element("Total_Neto") != null) ? f.Element("Total_Neto").Value : "",
                                  Codigo_FormaPago = (f.Element("Codigo_FormaPago") != null) ? f.Element("Codigo_FormaPago").Value : ""


                              };
                foreach (var q in queryFA)
                {
                    double num;
                    // Carga datos de la factura
                    //string[] aux = q.datosFactura.Fecha_Factura.Trim().Substring(0, q.datosFactura.Fecha_Factura.Trim().IndexOf(" ")).Split('/');
                    //this.txt_fecha_factura.Text = string.Format("{0:dd/MM/yyyy}", DateTime.Parse(aux[2] + "-" + aux[0] + "-" + aux[1]));
                    this.txt_fecha_factura.Text = Convert.ToDateTime(q.Fecha_Factura).ToString("dd/MM/yyyy");
                    if (double.TryParse(q.Neto.Replace(".", ","), out num))
                    {
                        this.txt_neto.Text = Convert.ToInt64(num).ToString();
                    }


                    FuncionGlobal.BuscarValueCombo(this.dl_sucursal_origen, new SucursalclienteBC().getSucursalParidad(q.Codigo_Sucursal.Trim(), Convert.ToInt32(id_cliente)).Id_sucursal.ToString());
                    FuncionGlobal.BuscarValueCombo(this.dl_sucursal_destino, new SucursalclienteBC().getSucursalParidad(q.Codigo_Sucursal.Trim(), Convert.ToInt32(id_cliente)).Id_sucursal.ToString());

                    string forma_pago = q.Codigo_FormaPago.Trim();

                    if (forma_pago == "02")
                    {
                        this.dl_forma_pago.SelectedValue = "2";
                    }

                }
            }
            catch (Exception ex)
            {
                //this.lbl_error.Text = ex.Message.Trim();
                //UpdatePanel up = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
                //FuncionGlobal.alerta_updatepanel(ex.Message, Page, up);
            }
        }

        protected void getDatosFacturaWSDitec()
        {

            string pag;
            WebClient client = new WebClient();
            Stream d;
            StreamReader r;
            string line;

            d = client.OpenRead("http://api2.ditecautomoviles.cl/webservice/?query=AGP_Mae_FacturasAGPView&vars=" + this.txt_factura.Text.Trim());

            pag = client.ToString();

            r = new StreamReader(d);
            line = r.ReadLine();

            d.Close();

            string[] fac = line.Split(new char[] { ',' });
            int countx = fac.Length;
            string[] xfac = new string[countx];


            for (int i = 0; i < countx; i++)
            {


                if (i == 13)
                {
                    int o = fac[i].Replace("\"", "").Length;
                    int u = o - 14;
                    xfac[i] = fac[i].Replace("\"", "").Substring(14, u);
                }
                else
                {
                    string[] factura = fac[i].Replace("\"", "").Split(new char[] { ':' });
                    xfac[i] = factura[1].ToString().Trim();
                }
            }





            d = client.OpenRead("http://api2.ditecautomoviles.cl/webservice/?query=AGP_Mae_DatosVehiculosAGPView&vars=" + xfac[5].ToString().Trim());

            pag = client.ToString();

            r = new StreamReader(d);
            line = r.ReadLine();

            d.Close();

            string[] veh = line.Split(new char[] { ',' });
            int countxv = veh.Length;
            string[] xveh = new string[countxv];



            for (int i = 0; i < countxv; i++)
            {
                string[] vehiculo = veh[i].Replace("\"", "").Split(new char[] { ':' });
                xveh[i] = vehiculo[1].ToString().Trim();
            }






            d = client.OpenRead("http://api2.ditecautomoviles.cl/webservice/?query=AGP_Mae_AdquirienteAGPView&vars=" + xfac[4].ToString().Trim());

            pag = client.ToString();

            r = new StreamReader(d);
            line = r.ReadLine();

            d.Close();

            string[] adq = line.Split(new char[] { ',' });
            int countxad = adq.Length;
            string[] xadq = new string[countxad];



            for (int i = 0; i < countxad; i++)
            {
                string[] adquiriente = adq[i].Replace("\"", "").Split(new char[] { ':' });

                if (adquiriente.Length == 1)
                {
                    xadq[i] = adquiriente[0].ToString().Trim();
                }
                else
                {
                    xadq[i] = adquiriente[1].ToString().Trim();
                }

            }


            //d = client.OpenRead("http://api2.ditecautomoviles.cl/webservice/?query=AGP_Mae_FormasPago");

            //pag = client.ToString();

            //r = new StreamReader(d);
            //line = r.ReadLine();

            //d.Close();

            //string[] fmp = line.Split(new char[] { ',' });
            //int countxfm = adq.Length;
            //string[] xfmp = new string[countxad];



            //for (int i = 0; i < countxfm; i++)
            //{
            //    string[] forma_pago = fmp[i].Replace("\"", "").Split(new char[] { ':' });

            //    if (forma_pago.Length == 1)
            //    {
            //        xfmp[i] = forma_pago[0].ToString().Trim();
            //    }
            //    else
            //    {
            //        xfmp[i] = forma_pago[1].ToString().Trim();
            //    }

            //}



            //d = client.OpenRead("http://api2.ditecautomoviles.cl/webservice/?query=AGP_Mae_SucursalesVenta");

            //pag = client.ToString();

            //r = new StreamReader(d);
            //line = r.ReadLine();

            //d.Close();

            //string[] fsuc = line.Split(new char[] { ',' });
            //int countxsuc = adq.Length;
            //string[] xsuc = new string[countxad];



            //for (int i = 0; i < countxsuc; i++)
            //{
            //    string[] sucursal = fsuc[i].Replace("\"", "").Split(new char[] { ':' });

            //    if (sucursal.Length == 1)
            //    {
            //        xsuc[i] = sucursal[0].ToString().Trim();
            //    }
            //    else
            //    {
            //        xsuc[i] = sucursal[1].ToString().Trim();
            //    }

            //}

            FuncionGlobal.BuscarValueCombo(this.dl_sucursal_origen, new SucursalclienteBC().getSucursalParidad(xfac[9].ToString().Trim(), Convert.ToInt32(id_cliente)).Id_sucursal.ToString());
            FuncionGlobal.BuscarValueCombo(this.dl_sucursal_destino, new SucursalclienteBC().getSucursalParidad(xfac[9].ToString().Trim(), Convert.ToInt32(id_cliente)).Id_sucursal.ToString());


            if (xfac[9].ToString().Trim() == "2")
            {
                dl_sucursal_origen.SelectedValue = "749";
                dl_sucursal_destino.SelectedValue = "749";
            }


            //switch (xfac[11].ToString().Trim())
            //{
            //    case "-1":

            //        dl_forma_pago.SelectedValue = "1";
            //        break;
            //    case "16,14,15":

            //        dl_forma_pago.SelectedValue = "2";
            //        break;
            //    case "11,17":

            //        dl_forma_pago.SelectedValue = "3";
            //        break;
            //    case "5":

            //        dl_forma_pago.SelectedValue = "4";
            //        break;
            //    case "8":

            //        dl_forma_pago.SelectedValue = "5";
            //        break;
            //}


            double num;

            string fecha = xfac[13].ToString().Trim().Replace("\\", "");

            txt_cit.Text = xveh[19].ToString().Trim().Replace("}", "").Replace("]", "");

            this.txt_fecha_factura.Text = string.Format("{0:dd/MM/yyyy}", fecha);
            if (double.TryParse(xfac[14].ToString().Trim().Replace(".", ","), out num))
            {
                this.txt_neto.Text = Convert.ToInt64(num).ToString();
            }

            if (xfac[19].ToString().Trim().Replace("}","").Replace("]","") == "S")
            {
                dl_forma_pago.SelectedValue = "2";
                dl_financiera.SelectedValue = "FOR";
            }
           


            //this.txt_cit.Text = xveh[14].ToString().Trim();

            // Carga datos del vehículo
            this.agpVehiculo.setPatente(xfac[15].ToString().Trim());
            this.agpVehiculo.setTipoVehiculo(xveh[4].ToString().Trim());
            this.agpVehiculo.setMarca(xveh[5].ToString().Trim());
            this.agpVehiculo.setModelo(xveh[7].ToString().Trim());
            this.agpVehiculo.setAnio(xveh[10].ToString().Trim());
            this.agpVehiculo.setCilindrada(xveh[12].ToString().Trim());
            this.agpVehiculo.setPuertas(xveh[17].ToString().Trim());
            this.agpVehiculo.setAsientos(xveh[18].ToString().Trim());
            this.agpVehiculo.setPesoBruto(xveh[15].ToString().Trim());
            this.agpVehiculo.setPesoCarga(xveh[14].ToString().Trim());
            this.agpVehiculo.setCombustible(xveh[16].ToString().Trim());
            this.agpVehiculo.setColor(xveh[13].ToString().Trim());
            this.agpVehiculo.setMotor(xveh[11].ToString().Trim());
            this.agpVehiculo.setChasis(xveh[9].ToString().Trim());
            this.agpVehiculo.setVin(xveh[8].ToString().Trim());
            


            // Carga datos del negocio
            //FuncionGlobal.BuscarValueCombo(this.dl_sucursal_origen, new SucursalclienteBC().getSucursalParidadAG(q.datosFactura.codigoSucursal.Trim()).Id_sucursal.ToString());
            //FuncionGlobal.BuscarValueCombo(this.dl_sucursal_destino, new SucursalclienteBC().getSucursalParidadAG(q.datosFactura.codigoSucursal.Trim()).Id_sucursal.ToString());

            // Carga datos del adquirente
            if (new PersonaBC().getpersonabyrut(Convert.ToDouble(xadq[0].ToString().Trim())) == null)
            {
                this.agpAdquirente.setRut(xadq[0].ToString().Trim());
                this.agpAdquirente.setDV(xadq[1].ToString().Trim());
                this.agpAdquirente.setNombre(xadq[4].ToString().Trim());
                this.agpAdquirente.setPaterno(xadq[5].ToString().Trim());
                this.agpAdquirente.setMaterno(xadq[6].ToString().Trim());
            }
            else
            {
                this.agpAdquirente.Mostrar_Form(Convert.ToDouble(xadq[0].ToString().Trim()));
            }


        }

        protected void getDatosFacturaWSMarubeni()
        {
            if (this.txt_factura.Text.Trim() == "") return;
            try
            {

                Service1SoapClient ad = new Service1SoapClient();
                Service1SoapClient ve = new Service1SoapClient();
                Service1SoapClient com = new Service1SoapClient();
                Service1SoapClient fac = new Service1SoapClient();
                XElement adquiriente = XElement.Parse(ad.Auto_Mae_AdquirienteAGPView(765108306, "130829473_X", "virago33", this.txt_factura.Text.Trim()).GetXml());


                var query = from f in adquiriente.Descendants("Auto_Mae_AdquirienteAGPView")
                            select new
                            {

                                datosAdquirente = new
                                {

                                    rut = (f.Element("RutCliente") != null) ? f.Element("RutCliente").Value : "",
                                    dv = (f.Element("TxtDijitoCliente") != null) ? f.Element("TxtDijitoCliente").Value : "",
                                    razon_social = (f.Element("Razon_Social") != null) ? f.Element("Razon_Social").Value : "",
                                    nombre = (f.Element("NombreCliente") != null) ? f.Element("NombreCliente").Value : "",
                                    paterno = (f.Element("ApellidoPaterno") != null) ? f.Element("ApellidoPaterno").Value : "",
                                    materno = (f.Element("ApellidoMaterno") != null) ? f.Element("ApellidoMaterno").Value : "",
                                    direccion = (f.Element("Direccion") != null) ? f.Element("Direccion").Value : "",
                                    numero = (f.Element("Numero") != null) ? f.Element("Numero").Value : "",
                                    depto = (f.Element("Departamento") != null) ? f.Element("Departamento").Value : "",
                                    region = (f.Element("Region") != null) ? f.Element("Region").Value : "",
                                    ciudad = (f.Element("Ciudad") != null) ? f.Element("Ciudad").Value : "",
                                    comuna = (f.Element("Comuna") != null) ? f.Element("Comuna").Value : "",
                                    fono = (f.Element("Telefono") != null) ? f.Element("Telefono").Value : ""
                                }
                            };
                foreach (var q in query)
                {
                    // Carga datos del adquirente
                    if (new PersonaBC().getpersonabyrut(Convert.ToDouble(q.datosAdquirente.rut)) == null)
                    {
                        this.agpAdquirente.setRut(q.datosAdquirente.rut.Trim());
                        this.agpAdquirente.setDV(q.datosAdquirente.dv.Trim());
                        this.agpAdquirente.setNombre(q.datosAdquirente.nombre.Trim());
                        this.agpAdquirente.setPaterno(q.datosAdquirente.paterno.Trim());
                        this.agpAdquirente.setMaterno(q.datosAdquirente.materno.Trim());
                    }
                    else
                    {
                        this.agpAdquirente.Mostrar_Form(Convert.ToDouble(q.datosAdquirente.rut));
                    }
                    break;
                }


                XElement vehiculo = XElement.Parse(ve.Auto_Mae_DatosVehiculosAGPView(765108306, "130829473_X", "virago33", this.txt_factura.Text.Trim()).GetXml());

                var queryVE = from f in vehiculo.Descendants("Auto_Mae_DatosVehiculosAGPView")
                              select new
                              {

                                  datosvehiculo = new
                                  {

                                      tipoVehiculo = (f.Element("Tipo_Vehiculo") != null) ? f.Element("Tipo_Vehiculo").Value : "",
                                      marca = (f.Element("Marca") != null) ? f.Element("Marca").Value : "",
                                      descripModelo = (f.Element("Descrp_Modelo") != null) ? f.Element("Descrp_Modelo").Value : "",
                                      anio = (f.Element("Año_Comercial") != null) ? f.Element("Año_Comercial").Value : "",
                                      cilindraje = (f.Element("Cilindrada") != null) ? f.Element("Cilindrada").Value : "",
                                      numeroPuertas = (f.Element("Puertas") != null) ? f.Element("Puertas").Value : "",
                                      numeroAsientos = (f.Element("Asientos") != null) ? f.Element("Asientos").Value : "",
                                      pesoBruto = (f.Element("Peso_Bruto") != null) ? f.Element("Peso_Bruto").Value : "",
                                      carga = (f.Element("Carga") != null) ? f.Element("Carga").Value : "",
                                      combustible = (f.Element("Combustible") != null) ? f.Element("Combustible").Value : "",
                                      color = (f.Element("Color") != null) ? f.Element("Color").Value : "",
                                      motor = (f.Element("Motor") != null) ? f.Element("Motor").Value : "",
                                      chasis = (f.Element("Chasis") != null) ? f.Element("Chasis").Value : "",
                                      vin = (f.Element("Vin") != null) ? f.Element("Vin").Value : ""
                                  }
                              };
                foreach (var q in queryVE)
                {
                    // Carga datos del vehículo
                    this.agpVehiculo.setTipoVehiculo(q.datosvehiculo.tipoVehiculo.Trim());
                    this.agpVehiculo.setMarca(q.datosvehiculo.marca.Trim());
                    this.agpVehiculo.setModelo(q.datosvehiculo.descripModelo.Trim());
                    this.agpVehiculo.setAnio(q.datosvehiculo.anio.Trim());
                    this.agpVehiculo.setCilindrada(q.datosvehiculo.cilindraje.Trim());
                    this.agpVehiculo.setPuertas(q.datosvehiculo.numeroPuertas.Trim());
                    this.agpVehiculo.setAsientos(q.datosvehiculo.numeroAsientos.Trim());
                    this.agpVehiculo.setPesoBruto(q.datosvehiculo.pesoBruto.Trim());
                    this.agpVehiculo.setPesoCarga(q.datosvehiculo.carga.Trim());
                    this.agpVehiculo.setCombustible(q.datosvehiculo.combustible.Trim());
                    this.agpVehiculo.setColor(q.datosvehiculo.color.Trim());
                    this.agpVehiculo.setMotor(q.datosvehiculo.motor.Trim());
                    this.agpVehiculo.setChasis(q.datosvehiculo.chasis.Trim());
                    this.agpVehiculo.setVin(q.datosvehiculo.vin.Trim());
                }

                XElement factura = XElement.Parse(fac.Auto_Mae_FacturasAGPView(765108306, "130829473_X", "virago33", this.txt_factura.Text.Trim()).GetXml());

                var queryFA = from f in factura.Descendants("Auto_Mae_FacturasAGPView")
                              select new
                              {

                                  datosFactura = new
                                  {

                                      Numero_Factura = (f.Element("Numero_Factura") != null) ? f.Element("Numero_Factura").Value : "",
                                      Tipo_Cliente = (f.Element("Tipo_Cliente") != null) ? f.Element("Tipo_Cliente").Value : "",
                                      Descrip_Sucursal = (f.Element("Descrip_Sucursal") != null) ? f.Element("Descrip_Sucursal").Value : "",
                                      Codigo_Sucursal = (f.Element("Codigo_Sucursal") != null) ? f.Element("Codigo_Sucursal").Value : "",
                                      Descrip_FormaPago = (f.Element("Descrip_FormaPago") != null) ? f.Element("Descrip_FormaPago").Value : "",
                                      Fecha_Factura = (f.Element("Fecha_Factura") != null) ? f.Element("Fecha_Factura").Value : "",
                                      Neto = (f.Element("Neto") != null) ? f.Element("Neto").Value : "",
                                      Codigo_FormaPago = (f.Element("Codigo_FormaPago") != null) ? f.Element("Codigo_FormaPago").Value : ""

                                  }
                              };
                foreach (var q in queryFA)
                {
                    double num;
                    // Carga datos de la factura
                    //string[] aux = q.datosFactura.Fecha_Factura.Trim().Substring(0, q.datosFactura.Fecha_Factura.Trim().IndexOf(" ")).Split('/');
                    //this.txt_fecha_factura.Text = string.Format("{0:dd/MM/yyyy}", DateTime.Parse(aux[2] + "-" + aux[0] + "-" + aux[1]));
                    this.txt_fecha_factura.Text = Convert.ToDateTime(q.datosFactura.Fecha_Factura).ToString("dd/MM/yyyy");
                    if (double.TryParse(q.datosFactura.Neto.Replace(".", ","), out num))
                    {
                        this.txt_neto.Text = Convert.ToInt64(num).ToString();
                    }


                    FuncionGlobal.BuscarValueCombo(this.dl_sucursal_origen, new SucursalclienteBC().getSucursalParidad(q.datosFactura.Codigo_Sucursal.Trim(), Convert.ToInt32(id_cliente)).Id_sucursal.ToString());
                    FuncionGlobal.BuscarValueCombo(this.dl_sucursal_destino, new SucursalclienteBC().getSucursalParidad(q.datosFactura.Codigo_Sucursal.Trim(), Convert.ToInt32(id_cliente)).Id_sucursal.ToString());

                    string forma_pago = q.datosFactura.Codigo_FormaPago.Trim();

                    if (forma_pago == "02")
                    {
                        this.dl_forma_pago.SelectedValue = "2";
                    }

                }

                //XElement compra_para = XElement.Parse(com.Auto_Mae_CompraParaAGPView(765108306, "130829473_X", "virago33", this.txt_factura.Text.Trim()).GetXml());



            }
            catch (Exception ex)
            {

                //this.lbl_error.Text = ex.Message.Trim();  
                //UpdatePanel up = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
                //FuncionGlobal.alerta_updatepanel(ex.Message, Page, up);
            }
        }

        protected void dl_financiera_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void txt_fecha_factura_TextChanged(object sender, EventArgs e)
        {

            ViewState["fecha_factura"] = Convert.ToDateTime(this.txt_fecha_factura.Text);
            if (this.txt_neto.Text != "")
            {
                ViewState["monto_factura"] = Convert.ToInt32(this.txt_neto.Text);
            }
        }

        protected void txt_neto_TextChanged(object sender, EventArgs e)
        {
            if (this.txt_fecha_factura.Text != "")
            {
                ViewState["fecha_factura"] = Convert.ToDateTime(this.txt_fecha_factura.Text);
            }
            ViewState["monto_factura"] = Convert.ToInt32(this.txt_neto.Text);
        }


        protected void txt_numero_emisor_OnTextChanged(object sender, EventArgs e)
        {
            if (txt_numero_emisor.Text != "0" && txt_numero_emisor.Text != "")
            {
                dl_bien.Visible = true;
                lbl_bien.Visible = true;
                FuncionGlobal.BienesByNumeroCliente(dl_bien, txt_numero_emisor.Text, tipo_operacion);
            }
        }

        #region

        //protected void getgastos()
        //{
        //    //ClienteTag lClientetag = new ClienteTagBC().getclientetag(Convert.ToInt16(dl_cliente.SelectedValue.ToString()), 1);

        //    DataTable dt = new DataTable();
        //    dt.Columns.Add(new DataColumn("Gasto"));
        //    dt.Columns.Add(new DataColumn("Codigo"));
        //    DataColumn colhabilitado = new DataColumn("chk");
        //    colhabilitado.DataType = System.Type.GetType("System.Boolean");
        //    dt.Columns.Add(colhabilitado);
        //    //dt.Columns.Add(new DataColumn("check"));
        //    dt.Columns.Add(new DataColumn("monto"));
        //    DataColumn chkgchabilitado = new DataColumn("chkgc");
        //    chkgchabilitado.DataType = System.Type.GetType("System.Boolean");
        //    dt.Columns.Add(chkgchabilitado);



        //    List<GastoOperacion> lgasto = new GastooperacionBC().Getgastooperacion(Convert.ToInt32(this.lbl_numero.Text));
        //    foreach (GastoOperacion mcliente in lgasto)
        //    {


        //        DataRow dr = dt.NewRow();



        //        dr["Gasto"] =  mcliente.Tipogasto.Descripcion;
        //        dr["chk"] = mcliente.Opcional;


        //        dr["monto"] = mcliente.Monto;
        //        dr["Codigo"] = mcliente.Tipogasto.Id_tipogasto;
        //        dr["chkgc"] = mcliente.Tipogasto.Check;

        //        if (Convert.ToBoolean(mcliente.Opcional) == false)
        //        {


        //            colhabilitado.ReadOnly = true;

        //        };

        //        dt.Rows.Add(dr);



        //        this.gr_dato.DataSource = dt;
        //        this.gr_dato.DataBind();
        //        Total_general();

        //    }
        //}

        //protected void txt_valor_gasto_Leave(object sender, EventArgs e)
        //{
        //    Total_general();
        //    //this.ModalPopupExtender1.Show();

        //}
        //protected void gr_dato_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //}

        //protected void Total_general()
        //{
        //    this.lbl_total.Text = Convert.ToString(FuncionGlobal.suma_textogrilla(gr_dato, "monto"));

        //    //this.lbl_cargo_empresa.Text = Convert.ToString(FuncionGlobal.suma_textogrilla(gr_dato, "txt_cargo_empresa"));
        //    //this.lbl_cargo_cliente.Text = Convert.ToString(FuncionGlobal.suma_textogrilla(gr_dato, "txt_cargo_cliente"));
        //}

        //protected void Check_Grilla_Clicked(Object sender, EventArgs e)
        //{
        //    Total_general();
        //    //this.ModalPopupExtender.Show();
        //}

        //protected void bt_guardar2_Click(object sender, EventArgs e)
        //{
        //    if (this.lbl_numero.Text != "")
        //    {

        //        //string add_or = new  ClienteTagBC().addclientetagoperacion(Convert.ToInt32(add),52);
        //        GridViewRow row;

        //        for (int i = 0; i < gr_dato.Rows.Count; i++)
        //        {

        //            row = gr_dato.Rows[i];
        //            CheckBox chk = (CheckBox)gr_dato.Rows[i].FindControl("chk");
        //            CheckBox chkgc = (CheckBox)gr_dato.Rows[i].FindControl("chkgc");
        //            //string montogasto = this.gr_dato.Rows[i].Cells[3].Text;
        //            TextBox montogasto = (TextBox)gr_dato.Rows[i].FindControl("monto");
        //            string codigo1 = this.gr_dato.Rows[i].Cells[0].Text;
        //            string codigo2 = this.gr_dato.Rows[i].Cells[1].Text;
        //            string codigo3 = this.gr_dato.Rows[i].Cells[2].Text;
        //            string codigo4 = this.gr_dato.Rows[i].Cells[3].Text;

        //            int cargo = Convert.ToInt16(this.dl_cargo_venta.SelectedValue);
        //            //	int id_cliente = id_cliente;

        //            if (chk.Checked == true)
        //            {
        //                if (cargo == 1)
        //                {
        //                    //string add_or = new ClienteTagBC().addclientetagoperacion(Convert.ToInt32(add), 52,Convert.ToInt32( montogasto));
        //                    string add_or = new GastooperacionBC().add_gastooperacion(Convert.ToInt32(this.lbl_numero.Text), Convert.ToInt16(codigo1), Convert.ToInt32(montogasto.Text), (string)(Session["usrname"]), 0, Convert.ToInt32(montogasto.Text), chkgc.Checked.ToString());
        //                }

        //                if (cargo == 2)
        //                {
        //                    //string add_or = new ClienteTagBC().addclientetagoperacion(Convert.ToInt32(add), 52,Convert.ToInt32( montogasto));
        //                    string add_or = new GastooperacionBC().add_gastooperacion(Convert.ToInt32(this.lbl_numero.Text), Convert.ToInt16(codigo1), Convert.ToInt32(montogasto.Text), (string)(Session["usrname"]), Convert.ToInt32(montogasto.Text), 0, chkgc.Checked.ToString());
        //                }
        //            }

        //            else
        //            {
        //                //string add_or = new ClienteTagBC().delclientetagoperacion(Convert.ToInt32(add), 52);
        //                string add_or = new GastooperacionBC().del_gastooperacion(Convert.ToInt32(this.lbl_numero.Text), Convert.ToInt16(codigo1), chkgc.Checked.ToString());
        //            }
        //        }
        //        Familia_Producto mfamilia1 = new Familia_productoBC().getfamiliabycodigo(tipo_operacion);
        //        //string addcom_or = new GastooperacionBC().add_gastooperacioncomunes(Convert.ToInt32(add), (string)(Session["usrname"]),tipo_operacion,Convert.ToInt16(id_cliente),Convert.ToInt16(mfamilia1.Id_familia.ToString()),Convert.ToInt16(this.dl_cargo_venta.SelectedValue));
        //    }
        //    //pnl_ingreso_riesgo.Visible = false;
        //}

        #endregion

    }
}
