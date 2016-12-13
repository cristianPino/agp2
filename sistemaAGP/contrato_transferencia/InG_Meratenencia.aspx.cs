using System;
using System.Globalization;
using System.Web;
using System.Web.UI;
using CENTIDAD;
using CNEGOCIO;
using CrystalDecisions.ReportAppServer.Controllers;

namespace sistemaAGP
{
    public partial class InG_Meratenencia : Page
    {
        private Int32 id_solicitud;
        private Int16 id_cliente;
        private string tipo_operacion;
        public static int IdOrdenTrabajo;
        protected void Page_Load(object sender, EventArgs e)
        {

            Datosvendedor.OnClickDireccion += Datosvendedor_OnClickDireccion;
            Datosvendedor.OnClickTelefono += Datosvendedor_OnClickTelefono;
            Datosvendedor.OnClickCorreo += Datosvendedor_OnClickCorreo;
            Datosvendedor.OnClickParticipante += Datosvendedor_OnClickParticipante;

            Datoscomprador.OnClickDireccion += Datoscomprador_OnClickDireccion;
            Datoscomprador.OnClickTelefono += Datoscomprador_OnClickTelefono;
            Datoscomprador.OnClickCorreo += Datoscomprador_OnClickCorreo;
            Datoscomprador.OnClickParticipante += Datoscomprador_OnClickParticipante;

            id_solicitud = Convert.ToInt32(FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_solicitud"]));
            id_cliente = Convert.ToInt16(FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_cliente"]));
            tipo_operacion = Request.QueryString["tipo_operacion"];

            IdOrdenTrabajo = Request.QueryString["idOrdenTrabajo"] == null
              ? 0
              : Convert.ToInt32(FuncionGlobal.FuctionDesEncriptar(Request.QueryString["idOrdenTrabajo"]));

            if (!IsPostBack)
            {
                if (id_cliente == 15)
                {
                    txt_interno.AutoPostBack = true;
                }


                lbl_operacion.Visible = false;
                lbl_numero.Visible = false;

                lbl_numero.Text = "0";

                lbl_operacion.Text = "";

                cambiar_titulo();
                FuncionGlobal.comboclientesbyusuario((string)(Session["usrname"]), dl_cliente);
                dl_cliente.SelectedValue = id_cliente.ToString();
                FuncionGlobal.combosucursalbyclienteandUsuario(dl_sucursal_origen, Convert.ToInt16(dl_cliente.SelectedValue), (string)(Session["usrname"]));

                FuncionGlobal.combotipovehiculo(dl_tipo_vehiculo);
				FuncionGlobal.combomarcavehiculo(dl_marca);

                FuncionGlobal.comboparametro(dl_calidad_mero, "CAME");
                FuncionGlobal.comboparametro(dl_naturaleza_doc, "TIPME");
                FuncionGlobal.comboparametro(dl_tipo_doc, "TIDOC");
                FuncionGlobal.comboparametro(dl_titulo_mera, "TIPME");

                if (id_solicitud != 0)
                {
                    busca_operacion();
                }

                dl_calidad_mero.SelectedIndex = 1;
                dl_naturaleza_doc.SelectedIndex =1;
                dl_tipo_doc.SelectedIndex = 2;
                dl_titulo_mera.SelectedIndex = 1;

                if (IdOrdenTrabajo == 0) return;
                var otra = new OrdenTrabajoBC().GetOrdenTrabajo(IdOrdenTrabajo);
                BuscaOrdenTrabajo(otra);

                if (id_cliente == 15)
                {
                    txt_interno.AutoPostBack = true;
                }

            }

        }

        public void BuscaOrdenTrabajo(CENTIDAD.OrdenTrabajo otra)
        {
            lbl_operacion.Visible = true;
            lbl_numero.Visible = true;
            lbl_operacion.Text = "Operación de Meratenencia Numero:";
            lbl_numero.Text = "0";
           
            txt_interno.Text = otra.NumeroOrden;
            dl_sucursal_origen.SelectedValue = otra.IdSucursal.ToString(CultureInfo.InvariantCulture);

            txt_patente.Text  = otra.Patente.Trim();
            txt_dv_patente.Text = FuncionGlobal.digitoVerificadorPatente(otra.Patente.Trim());
            txt_kilometraje.Text = "0";
            dl_marca.SelectedValue = "0";
            dl_tipo_vehiculo.SelectedValue = "0";
            txt_modelo.Text = otra.VehiculoModelo.Trim();
            txtNumFactura.Text = otra.NumeroFactura;

            var rutVendedor = new ClienteBC().getcliente(Convert.ToInt16(otra.Cliente.Id_cliente)).Persona.Rut;
            Datoscomprador.Mostrar_Form(Convert.ToInt32(otra.RutAdquiriente.Substring(0, otra.RutAdquiriente.Length - 1)));
            Datosvendedor.Mostrar_Form(rutVendedor);

        }

        protected void cambiar_titulo()
        {
            TipoOperacion p = new TipooperacionBC().getTipooperacion(tipo_operacion);
            Title = p.Operacion;
            lbl_titulo.Text = p.Operacion;
            p = null;
        }

        protected void Datoscomprador_OnClickParticipante(object sender, wucBotonEventArgs e)
        {
            UpdatePanel pnl = (UpdatePanel)Master.FindControl("UpdatePanel1");
            ScriptManager.RegisterClientScriptBlock(pnl, pnl.GetType(), "AdqDir", e.Url, false);
        }

     
        protected void Datosvendedor_OnClickParticipante(object sender, wucBotonEventArgs e)
        {
            UpdatePanel pnl = (UpdatePanel)Master.FindControl("UpdatePanel1");
            ScriptManager.RegisterClientScriptBlock(pnl, pnl.GetType(), "AdqDir", e.Url, false);
        }
        protected void Datosvendedor_OnClickDireccion(object sender, wucBotonEventArgs e)
        {
            UpdatePanel pnl = (UpdatePanel)Master.FindControl("UpdatePanel1");
            ScriptManager.RegisterClientScriptBlock(pnl, pnl.GetType(), "AdqDir", e.Url, false);
        }

        protected void Datosvendedor_OnClickTelefono(object sender, wucBotonEventArgs e)
        {
            UpdatePanel pnl = (UpdatePanel)Master.FindControl("UpdatePanel1");
            ScriptManager.RegisterClientScriptBlock(pnl, pnl.GetType(), "AdqTel", e.Url, false);
        }

        protected void Datosvendedor_OnClickCorreo(object sender, wucBotonEventArgs e)
        {
            UpdatePanel pnl = (UpdatePanel)Master.FindControl("UpdatePanel1");
            ScriptManager.RegisterClientScriptBlock(pnl, pnl.GetType(), "AdqCor", e.Url, false);
        }

        protected void Datoscomprador_OnClickDireccion(object sender, wucBotonEventArgs e)
        {
            UpdatePanel pnl = (UpdatePanel)Master.FindControl("UpdatePanel1");
            ScriptManager.RegisterClientScriptBlock(pnl, pnl.GetType(), "AdqDir", e.Url, false);
        }

        protected void Datoscomprador_OnClickTelefono(object sender, wucBotonEventArgs e)
        {
            UpdatePanel pnl = (UpdatePanel)Master.FindControl("UpdatePanel1");
            ScriptManager.RegisterClientScriptBlock(pnl, pnl.GetType(), "AdqTel", e.Url, false);
        }

        protected void Datoscomprador_OnClickCorreo(object sender, wucBotonEventArgs e)
        {
            UpdatePanel pnl = (UpdatePanel)Master.FindControl("UpdatePanel1");
            ScriptManager.RegisterClientScriptBlock(pnl, pnl.GetType(), "AdqCor", e.Url, false);
        }


        protected void busca_operacion()
        {
            Operacion moperacion = new OperacionBC().getoperacion(Convert.ToInt32(id_solicitud));

            lbl_operacion.Visible = true;
            lbl_numero.Visible = true;
            lbl_operacion.Text = "Operación de Meratenencia Numero:";
            lbl_numero.Text = Convert.ToString(moperacion.Id_solicitud);
            txt_interno.Text = moperacion.Numero_cliente;
            dl_sucursal_origen.SelectedValue = moperacion.Sucursal.Id_sucursal.ToString();
            txtNumFactura.Text = moperacion.Numero_factura.ToString();
            

            DatosVehiculo mdatosvehiculo = new DatosvehiculoBC().getDatovehiculo(id_solicitud);

            txt_patente.Text = mdatosvehiculo.Patente.Trim();
            txt_dv_patente.Text = FuncionGlobal.digitoVerificadorPatente(mdatosvehiculo.Patente.Trim());
            txt_kilometraje.Text = mdatosvehiculo.Kilometraje.ToString();
            dl_marca.SelectedValue = mdatosvehiculo.Marca.Id_marca.ToString();
            dl_tipo_vehiculo.SelectedValue = mdatosvehiculo.Tipo_vehiculo.Codigo;
            txt_modelo.Text = mdatosvehiculo.Modelo;
            

            ParticipeOperacion mcompra = new ParticipeOperacionBC().getparticipebytipo(Convert.ToInt32(id_solicitud), "COMPR");
            ParticipeOperacion mvende = new ParticipeOperacionBC().getparticipebytipo(Convert.ToInt32(id_solicitud), "VENDE");

            Datosvendedor.Mostrar_Form(mvende.Participe.Rut);
            Datoscomprador.Mostrar_Form(mcompra.Participe.Rut);

            Meratenencia mera = new MeratenenciaBC().getmeratenencia(id_solicitud);

            txt_bien.Text = mera.N_bien;
            txt_autorizacion_doc.Text = mera.Autorizacion;
            txt_anno_causa.Text = mera.Anno_causa.ToString();
            txt_fecha_documento.Text = mera.Fecha_doc.ToString();
            txt_lugar_doc.Text = mera.Lugar_doc;
            txt_n_doc.Text = mera.N_doc;
            txt_tribunal.Text = mera.Tribunal;
            dl_calidad_mero.SelectedValue = mera.Calidad_mero;
            dl_naturaleza_doc.SelectedValue = mera.Naturaleza_doc;
            dl_tipo_doc.SelectedValue = mera.Tipo_doc;
            dl_titulo_mera.SelectedValue = mera.Titulo_mera;


           
        }

   
        protected void txt_interno_TextChanged(object sender, EventArgs e)
        {
            if (txt_interno.Text != "0" && txt_interno.Text != "")
            {
                dl_bien.Visible = true;
                lbl_bien.Visible = true;
                FuncionGlobal.BienesByNumeroCliente(dl_bien, txt_interno.Text, tipo_operacion.ToString());
            }
        }

        protected void txt_patente_TextChanged(object sender, EventArgs e)
        {
            if (txt_patente.Text.Trim() != "")
            {
                if (FuncionGlobal.formatoPatente(txt_patente.Text))
                {
                    txt_dv_patente.Text = FuncionGlobal.digitoVerificadorPatente(txt_patente.Text);


                }
                else
                {
                    UpdatePanel pnl = (UpdatePanel)Master.FindControl("UpdatePanel1");
                    ScriptManager.RegisterClientScriptBlock(pnl, pnl.GetType(), "validacion_ppu", "alert('La patente no cumple con el formato requerido (LLNNNN|LLLLNN). Si la patente es de una moto, coloque un cero (0) entre las letras y los números.');", true);
                    txt_patente.Text = "";
                    txt_dv_patente.Text = "";
                    txt_patente.Focus();
                }
            }
        }


        protected bool Busca_Patente(string patente)
        {
            DatosVehiculo veh = new DatosvehiculoBC().getDatovehiculobypatente(patente);
            //veh = new DatosvehiculoBC().getDatovehiculobypatente(patente);
            if (veh != null)
            {
                txt_patente.Text = veh.Patente;
                if (veh.Tipo_vehiculo != null)
                    dl_tipo_vehiculo.SelectedValue = veh.Tipo_vehiculo.Codigo;
                if (veh.Marca != null)
                    dl_marca.SelectedValue = Convert.ToString(veh.Marca.Id_marca);
                if (veh.Tipo_vehiculo != null)
                    dl_tipo_vehiculo.SelectedValue = veh.Tipo_vehiculo.Codigo;
                
                txt_modelo.Text = veh.Modelo;
                txt_kilometraje.Text = veh.Kilometraje.ToString();
                return true;
            }
            return false;
        }

        protected void bt_guardar_Click(object sender, EventArgs e)
        {
            UpdatePanel up = (UpdatePanel)Master.FindControl("UpdatePanel1");

            string rutcomp = "0";
            string rutvend = "0";


            //if(txtNumFactura.Text == "")
            //{
            //    tdMensaje.Visible = true;
            //    lblMensaje.Text = "Favor agregar número de factura.";
            //    return;
            //}

            //DateTime result;

            //bool validafecha = DateTime.TryParse(txt_fecha_documento.Text, out result.ToShortDateString("DD/MM/YYYY"));

            if (txt_patente.Text == "" || txt_patente.Text == "0")
            {
                FuncionGlobal.alerta_updatepanel("Debe ingresar la Fecha de Documento correcta", Page, up);
                return;
            }



            if (txt_patente.Text == "" || txt_patente.Text == "0")
            {

                FuncionGlobal.alerta_updatepanel("Debe ingresar la Patente", Page, up);
                return;
            }


            if (txt_fecha_documento.Text == "" || txt_fecha_documento.Text == "0")
            {

                FuncionGlobal.alerta_updatepanel("Debe ingresar la Fecha de Documento", Page, up);
                return;
            }

            if (id_cliente == 15)
            {
                if (txt_interno.Text == "")
                {
                    //Response.Write("<script language=javascript>alert('Debe ingresar el número de operación banco');</script>");
                    //return;
                    FuncionGlobal.alerta_updatepanel("Debe ingresar el número de operación banco", Page, up);
                    return;
                }

                if (Convert.ToInt32(txt_interno.Text) <= 0)
                {
                    FuncionGlobal.alerta_updatepanel("El número de operación banco no corresponde", Page, up);
                    return;
                    //Response.Write("<script language=javascript>alert('El número de operación banco no corresponde');</script>");
                    //return;
                }

                if (txtNumFactura.Text == "")
                {
                    FuncionGlobal.alerta_updatepanel("Debe ingresar el número de factura", Page, up);
                    return;
                    //Response.Write("<script language=javascript>alert('Debe ingresar el número de factura');</script>");
                    //return;
                }

                var validaNumOperacionBanco = new OperacionBC().validaNumOperacionBanco(Convert.ToInt32(txt_interno.Text), Convert.ToInt32(txtNumFactura.Text));
                if (validaNumOperacionBanco.Numero_cliente != txt_interno.Text)
                {
                    FuncionGlobal.alerta_updatepanel("Por favor revise número de operacion o factura.", Page, up);
                    return;
                    //Response.Write("<script language=javascript>alert('Por favor revise número de operacion o factura.');</script>");
                    //return;
                }
            }

            if (Datoscomprador.Guardar_Form())
            {
                if (Datoscomprador.InfoPersona != null)
                {
                    rutcomp = Datoscomprador.InfoPersona.Rut.ToString();
                }
            }


            if (Datosvendedor.Guardar_Form())
            {
                if (Datosvendedor.InfoPersona != null)
                {
                    rutvend = Datosvendedor.InfoPersona.Rut.ToString();
                }
            }

            Int32 add = new OperacionBC().add_operacion(Convert.ToInt32(lbl_numero.Text),
                                                        Convert.ToInt16(dl_cliente.SelectedValue), tipo_operacion,
                                                        (string) (Session["usrname"]), 0, (txt_interno.Text.Trim()),
                                                        Convert.ToInt32(dl_sucursal_origen.SelectedValue), Convert.ToInt32(txtNumFactura.Text));

            //PARA ORDEN DE TRABAJO
            if (IdOrdenTrabajo != 0)
            {
                FuncionGlobal.UpdateTipoOperacionOrdenTrabajo(tipo_operacion, IdOrdenTrabajo, add);
            }

            

            string addparcom = new ParticipeOperacionBC().add_participe(add, Convert.ToInt32(Datoscomprador.InfoPersona.Rut), "COMPR");
            string addparven = new ParticipeOperacionBC().add_participe(add, Convert.ToInt32(Datosvendedor.InfoPersona.Rut), "VENDE");
            Meratenencia mera = new Meratenencia();
            mera.Anno_causa = Convert.ToInt32(txt_anno_causa.Text);
            mera.Autorizacion = txt_autorizacion_doc.Text;
            mera.Calidad_mero = dl_calidad_mero.SelectedValue;
            mera.Fecha_doc = Convert.ToDateTime(txt_fecha_documento.Text);
            mera.Id_solicitud = Convert.ToInt32(add);
            mera.Lugar_doc = txt_lugar_doc.Text;
            mera.N_doc = txt_n_doc.Text;
            mera.Naturaleza_doc = dl_naturaleza_doc.SelectedValue;
            mera.Rut_comprador = Convert.ToInt32(Datoscomprador.InfoPersona.Rut);
            mera.Rut_vendedor = Convert.ToInt32(Datosvendedor.InfoPersona.Rut);
            mera.Tipo_doc = dl_tipo_doc.SelectedValue;
            mera.Titulo_mera = dl_titulo_mera.SelectedValue;
            mera.Tribunal = txt_tribunal.Text;
            mera.N_bien = dl_bien.SelectedValue;
            string addmera = new MeratenenciaBC().add_meratenencia(mera);

            DatosVehiculo mdato2 = new DatosvehiculoBC().getDatovehiculobyPatente_id_solicitud(txt_patente.Text,add);

            Marcavehiculo marca = new Marcavehiculo();
            Tipovehiculo tipvehi = new Tipovehiculo();
            string mar = dl_marca.SelectedValue;
            string tip = dl_tipo_vehiculo.SelectedValue;

            if(mar!="0")
            {
                marca = new MarcavehiculoBC().getmarcavehiculo(Convert.ToInt16(mar));
            }
            else
            {
                  marca = new MarcavehiculoBC().getmarcavehiculo(69);
            }
            if (tip != "0")
            {
                 tipvehi = new TipovehiculoBC().getTipoVehiculo(tip);
            }
            else
            {
                 tipvehi = new TipovehiculoBC().getTipoVehiculo("PDF");
            }
            //Int32 id_dato_vehiculo = 0;


            if (mdato2 != null)
            {
                string datovehi = new DatosvehiculoBC().add_Datosvehiculo(add,
                                                                        mdato2.Marca,
                                                                        mdato2.Tipo_vehiculo,
                                                                        txt_patente.Text,
                                                                        FuncionGlobal.digitoVerificadorPatente(txt_patente.Text),
                                                                        mdato2.Modelo, mdato2.Chassis, "", mdato2.Vin, mdato2.Serie, Convert.ToInt32(0), "", mdato2.Color, 0, 0, "", 0, 0,
                                                                        Convert.ToInt32(0),Convert.ToInt32(0),
                                                                        "", Convert.ToInt32(0),
                                                                        Convert.ToInt32(mdato2.Id_dato_vehiculo), DateTime.Now, "", "false", "", 0, "false",
                                                                        mdato2.Transmision,mdato2.Equipamiento,"0");

            }
            else
            {
                string datovehi = new DatosvehiculoBC().add_Datosvehiculo(add,
                                                                            marca,
                                                                           tipvehi,
                                                                            txt_patente.Text,
                                                                            FuncionGlobal.digitoVerificadorPatente(txt_patente.Text),
                                                                            txt_modelo.Text, "","", "", "", Convert.ToInt32(0), "", "", 0, 0, "", 0, 0,
                                                                            Convert.ToInt32(0),
                                                                            Convert.ToInt32(0),
                                                                            "", Convert.ToInt32(0), 0, DateTime.Now,
                                                                            "", "false", "", 0, "0","0","0","0");

            }

            string add_or = new EstadooperacionBC().add_estado_orden(Convert.ToInt32(add), 1, tipo_operacion, "", (string)(Session["usrname"]));


            lbl_operacion.Visible = true;
            lbl_numero.Visible = true;
            lbl_operacion.Text = "Operación de Meratenencia Numero:";
            lbl_numero.Text = Convert.ToString(add);

            int bien;

            if (dl_bien.SelectedValue == "0" || dl_bien.SelectedValue == null || dl_bien.SelectedValue == "")
            {
                bien = Convert.ToInt32(txt_bien.Text);
            }
            else
            {
                bien = Convert.ToInt32(dl_bien.SelectedValue);
            }

                if (id_cliente == 15)
            {
                new BienesNumeroClienteBC().add_integracion_leasing(add, bien,
                                                                    Convert.ToInt32(txt_interno.Text), tipo_operacion);
            }

            FuncionGlobal.alerta(lbl_titulo.Text+", INGRESADO CON EXITO", Page);
        }

        protected void dl_cliente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void txt_kilometraje_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txt_ano_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txt_motor_TextChanged(object sender, EventArgs e)
        {

        }

        protected void dl_marca_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void dl_tipo_vehiculo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void txt_n_doc_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txt_lugar_doc_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txt_autorizacion_doc_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txt_fecha_documento_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txt_tribunal_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txt_anno_causa_TextChanged(object sender, EventArgs e)
        {

        }

        protected void dl_titulo_mera_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void dl_calidad_mero_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void dl_tipo_doc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void dl_naturaleza_doc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void txt_bien_TextChanged(object sender, EventArgs e)
        {

        }

        protected void bt_limpiar_Click(object sender, EventArgs e)
        {

            lbl_numero.Text = "0";
            lbl_operacion.Text = "";
            Page.Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);

        }

        protected void txt_modelo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}