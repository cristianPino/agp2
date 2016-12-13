using System;
using System.Collections.Generic;
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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Web;

namespace sistemaAGP
{
    public partial class ProductosVarios : System.Web.UI.Page
    {
        private Int32 id_solicitud;
        private Int16 id_cliente;
        private string tipo_operacion;

        protected void Page_Load(object sender, EventArgs e)
        {

            this.Datosvendedor.OnClickDireccion += new wucBotonEventHandler(Datosvendedor_OnClickDireccion);
            this.Datosvendedor.OnClickTelefono += new wucBotonEventHandler(Datosvendedor_OnClickTelefono);
            this.Datosvendedor.OnClickCorreo += new wucBotonEventHandler(Datosvendedor_OnClickCorreo);
            this.Datosvendedor.OnClickParticipante += new wucBotonEventHandler(Datosvendedor_OnClickParticipante);


            id_solicitud = Convert.ToInt32(FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_solicitud"].ToString()));
            id_cliente = Convert.ToInt16(FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_cliente"].ToString()));
            tipo_operacion = Request.QueryString["tipo_operacion"].ToString();

            if(!IsPostBack)
            {
                cambiar_titulo();
                FuncionGlobal.comboclientesbyusuario((string)(Session["usrname"]), this.dl_cliente);
                this.dl_cliente.SelectedValue = id_cliente.ToString();
                FuncionGlobal.combosucursalbyclienteandUsuario(this.dl_sucursal_origen, Convert.ToInt16(this.dl_cliente.SelectedValue), (string)(Session["usrname"]));

                FuncionGlobal.combotipovehiculo(this.dl_tipo_vehiculo);
				FuncionGlobal.combomarcavehiculo(this.dl_marca);


                if (tipo_operacion.Trim() == "ctag" || tipo_operacion.Trim() == "dtag")
                {
                    this.Label1.Text = "Codigo TAG";
                    this.txt_interno.Visible = false;
                    this.dl_Codigo_TAG.Visible = true;
                    FuncionGlobal.comboCodigo_TAGactivos(this.dl_Codigo_TAG, id_solicitud);
                }

                if (id_solicitud != 0)
                {
                    busca_operacion();
                }


            }

        }
        protected void cambiar_titulo()
        {
            TipoOperacion p = new TipooperacionBC().getTipooperacion(this.tipo_operacion);
            this.Title = p.Operacion;
            this.lbl_titulo.Text = p.Operacion;
            p = null;
        }

     
        protected void Datosvendedor_OnClickParticipante(object sender, wucBotonEventArgs e)
        {
            UpdatePanel pnl = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
            ScriptManager.RegisterClientScriptBlock(pnl, pnl.GetType(), "AdqDir", e.Url, false);
        }
        protected void Datosvendedor_OnClickDireccion(object sender, wucBotonEventArgs e)
        {
            UpdatePanel pnl = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
            ScriptManager.RegisterClientScriptBlock(pnl, pnl.GetType(), "AdqDir", e.Url, false);
        }

        protected void Datosvendedor_OnClickTelefono(object sender, wucBotonEventArgs e)
        {
            UpdatePanel pnl = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
            ScriptManager.RegisterClientScriptBlock(pnl, pnl.GetType(), "AdqTel", e.Url, false);
        }

        protected void Datosvendedor_OnClickCorreo(object sender, wucBotonEventArgs e)
        {
            UpdatePanel pnl = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
            ScriptManager.RegisterClientScriptBlock(pnl, pnl.GetType(), "AdqCor", e.Url, false);
        }

        protected void busca_operacion()
        {

            Operacion moperacion = new OperacionBC().getoperacion(Convert.ToInt32(id_solicitud));

           
            this.lbl_operacion.Text = "Operación Numero:";
            this.lbl_numero.Text = Convert.ToString(moperacion.Id_solicitud);
            this.txt_observacion.Text = moperacion.Observacion;
            txt_factura.Text = moperacion.Numero_factura.ToString();
            if (moperacion.Numero_cliente == null)
            {
                this.txt_interno.Text = "";
            }
            else
            {
                if (tipo_operacion.Trim() == "ctag" || tipo_operacion.Trim() == "dtag")
                {
                    this.dl_Codigo_TAG.SelectedValue = moperacion.Numero_cliente.ToString();
                    this.dl_sucursal_origen.SelectedValue = moperacion.Sucursal.Id_sucursal.ToString();
                    this.lbl_operacion.Visible = true;
                    this.lbl_numero.Visible = true;
                }
                else
                {
                    this.txt_interno.Text = moperacion.Numero_cliente.ToString();
                    this.dl_sucursal_origen.SelectedValue = moperacion.Sucursal.Id_sucursal.ToString();
                    this.lbl_operacion.Visible = true;
                    this.lbl_numero.Visible = true;
                }
            }

            DatosVehiculo mdatosvehiculo = new DatosvehiculoBC().getDatovehiculo(id_solicitud);

            if (mdatosvehiculo.Id_solicitud != 0)
            {
                this.txt_patente.Text = mdatosvehiculo.Patente.Trim();
                this.txt_dv_patente.Text = FuncionGlobal.digitoVerificadorPatente(mdatosvehiculo.Patente.Trim());
                this.txt_kilometraje.Text = mdatosvehiculo.Kilometraje.ToString();
                this.dl_marca.SelectedValue = mdatosvehiculo.Marca.Id_marca.ToString();
                this.dl_tipo_vehiculo.SelectedValue = mdatosvehiculo.Tipo_vehiculo.Codigo;
                this.txt_motor.Text = mdatosvehiculo.Motor;
                this.txt_ano.Text = mdatosvehiculo.Ano.ToString();
            }

            ParticipeOperacion mvende = new ParticipeOperacionBC().getparticipebytipo(Convert.ToInt32(id_solicitud), "COMPR");
            if (mvende.Participe != null)
            {
                this.Datosvendedor.Mostrar_Form(mvende.Participe.Rut);
            }
        }

   
        protected void txt_interno_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txt_patente_TextChanged(object sender, EventArgs e)
        {
            if (this.txt_patente.Text.Trim() != "")
            {
                if (FuncionGlobal.formatoPatente(this.txt_patente.Text))
                {
                    this.txt_dv_patente.Text = FuncionGlobal.digitoVerificadorPatente(this.txt_patente.Text);


                }
                else
                {
                    UpdatePanel pnl = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
                    ScriptManager.RegisterClientScriptBlock(pnl, pnl.GetType(), "validacion_ppu", "alert('La patente no cumple con el formato requerido (LLNNNN|LLLLNN). Si la patente es de una moto, coloque un cero (0) entre las letras y los números.');", true);
                    this.txt_patente.Text = "";
                    this.txt_dv_patente.Text = "";
                    this.txt_patente.Focus();
                }
            }
        }


        protected bool Busca_Patente(string patente)
        {
            DatosVehiculo veh = new DatosvehiculoBC().getDatovehiculobypatente(patente);
            //veh = new DatosvehiculoBC().getDatovehiculobypatente(patente);
            if (veh != null)
            {
                this.txt_patente.Text = veh.Patente;
                if (veh.Tipo_vehiculo != null)
                    this.dl_tipo_vehiculo.SelectedValue = veh.Tipo_vehiculo.Codigo;
                if (veh.Marca != null)
                    this.dl_marca.SelectedValue = Convert.ToString(veh.Marca.Id_marca);
                if (veh.Tipo_vehiculo != null)
                    this.dl_tipo_vehiculo.SelectedValue = veh.Tipo_vehiculo.Codigo;
                this.txt_ano.Text = veh.Ano.ToString();
                this.txt_motor.Text = veh.Motor;
                this.txt_kilometraje.Text = veh.Kilometraje.ToString();
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void bt_guardar_Click(object sender, EventArgs e)
        {

            if (valida_ingreso() == true)
            {
                add_operacion();
            }

           
        }

        protected void add_operacion()
        {

            string rutvend = "0";
            int     operacion = 0;

            if (this.Datosvendedor.Guardar_Form())
            {
                if (this.Datosvendedor.InfoPersona != null)
                {
                    rutvend = this.Datosvendedor.InfoPersona.Rut.ToString();
                }
            }
            if (this.lbl_numero.Text != "")
            {
                operacion = Convert.ToInt32(this.lbl_numero.Text);
            }

            string interno = "";

            if (tipo_operacion.Trim() == "ctag" || tipo_operacion.Trim() == "dtag")
            {
                interno = this.dl_Codigo_TAG.SelectedValue;
            }
            else
            {
                interno = this.txt_interno.Text.Trim();
            }

            int fac = 0;

            if (txt_factura.Text.Trim() != "")
            {
                fac = Convert.ToInt32(txt_factura.Text.Trim());
            }


            Int32 add = new OperacionBC().add_operacion(operacion, Convert.ToInt16(this.dl_cliente.SelectedValue),
                                                        tipo_operacion, (string)(Session["usrname"]), 0,interno,
                                                        Convert.ToInt32(this.dl_sucursal_origen.SelectedValue), fac, this.txt_observacion.Text);

            string addparven = new ParticipeOperacionBC().add_participe(Convert.ToInt32(add), Convert.ToInt32(this.Datosvendedor.InfoPersona.Rut), "COMPR");

            DatosVehiculo mdato2 = new DatosVehiculo();
            Int32 id_dato_vehiculo = 0;

            mdato2 = new DatosvehiculoBC().getDatovehiculo( operacion);

            Marcavehiculo marca = new Marcavehiculo();
            Tipovehiculo tipvehi = new Tipovehiculo();
            string mar = this.dl_marca.SelectedValue;
            string tip = this.dl_tipo_vehiculo.SelectedValue;
            string anno = "0";
            string kilometraje = "0";

            if (this.txt_ano.Text != "")
            {
                anno = this.txt_ano.Text;
            }
            if (this.txt_kilometraje.Text != "")
            {
                kilometraje = this.txt_kilometraje.Text;
            }
            if (mar != "0")
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
            


            if (mdato2 != null)
            {
                if (mdato2.Id_solicitud == add)
                {
                    id_dato_vehiculo = mdato2.Id_dato_vehiculo;
                }

                string datovehi = new DatosvehiculoBC().add_Datosvehiculo(add,
                                                                        marca,
                                                                        tipvehi,
                                                                        txt_patente.Text,
                                                                        FuncionGlobal.digitoVerificadorPatente(txt_patente.Text),
                                                                        mdato2.Modelo, mdato2.Chassis, this.txt_motor.Text, mdato2.Vin, mdato2.Serie, Convert.ToInt32(anno), "", mdato2.Color, 0, 0, "", 0, 0,
                                                                        Convert.ToInt32(FuncionGlobal.NumeroSinFormato(kilometraje)), Convert.ToInt32(0),
                                                                        "", Convert.ToInt32(0),
                                                                        id_dato_vehiculo, DateTime.Now, "", "false", "", 0, "false",mdato2.Transmision,mdato2.Equipamiento, "0");

            }
            else
            {
                string datovehi = new DatosvehiculoBC().add_Datosvehiculo(add,
                                                                            marca,
                                                                           tipvehi,
                                                                            this.txt_patente.Text,
                                                                            FuncionGlobal.digitoVerificadorPatente(txt_patente.Text),
                                                                            "", "", this.txt_motor.Text, "", "", Convert.ToInt32(anno), "", "", 0, 0, "", 0, 0,
                                                                            Convert.ToInt32(FuncionGlobal.NumeroSinFormato(kilometraje)),
                                                                            Convert.ToInt32(0),
                                                                            "", Convert.ToInt32(0), id_dato_vehiculo, DateTime.Now,
                                                                            "", "false", "", 0, "0","0","0", "0");

            }

            string add_or = new EstadooperacionBC().add_estado_orden(Convert.ToInt32(add), 1, tipo_operacion, "", (string)(Session["usrname"]));


            this.lbl_operacion.Visible = true;
            this.lbl_numero.Visible = true;
            this.lbl_operacion.Text = "Operación Numero:";
            this.lbl_numero.Text = Convert.ToString(add);
            FuncionGlobal.alerta(this.lbl_titulo.Text + ", INGRESADO CON EXITO", Page); 
        }

        protected Boolean valida_ingreso()
        {
            UpdatePanel up = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
            if (this.dl_sucursal_origen.SelectedValue == "0")
            {
                FuncionGlobal.alerta_updatepanel("Ingrese la Sucursal de Origen", Page, up);
                this.dl_sucursal_origen.Focus();
                return false;
            }

            if (this.dl_cliente.SelectedValue == "15" && tipo_operacion.Trim() !="dtag" && tipo_operacion.Trim() != "ctag")
            {

                if (this.txt_factura.Text.Trim() == "")
                {
                    FuncionGlobal.alerta_updatepanel("Debe ingresar la Factura", Page, up);
                    return false;
                }
                if (this.txt_factura.Text.Trim() == "0")
                {
                    FuncionGlobal.alerta_updatepanel("Debe ingresar la Factura", Page, up);
                    return false;
                }


                if (this.txt_interno.Text.Trim() == "")
                {
                    FuncionGlobal.alerta_updatepanel("Debe ingresar el Nº cliente", Page, up);
                    return false;
                }
                if (this.txt_interno.Text.Trim() == "0")
                {
                    FuncionGlobal.alerta_updatepanel("Debe ingresar el Nº cliente", Page, up);
                    return false;
                }

            }

            return true;

        }


        protected void dl_cliente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void txt_kilometraje_TextChanged(object sender, EventArgs e)
        {

        }

        protected void dl_tipo_vehiculo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void dl_marca_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void txt_ano_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txt_motor_TextChanged(object sender, EventArgs e)
        {

        }

        //protected void Button1_Click1(object sender, EventArgs e)
        //{
        //    this.txt_ano.Text = "";
        //    this.txt_dv_patente.Text = "";
        //    this.txt_kilometraje.Text = "";
        //    this.txt_patente.Text = "";
        //}

    }
}