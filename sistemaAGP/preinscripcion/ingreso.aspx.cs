using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CENTIDAD;
using CNEGOCIO;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Web;

namespace sistemaAGP
{
    public partial class ingreso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (this.lbl_numero.Text != "")
            {
                //carga_rpt(Convert.ToInt32(this.lbl_numero.Text));
            }
            
            this.bt_caratula.Attributes.Add("onclick", "javascript:window.open('../reportes/reporte_prueba.aspx','_blank','height=355,width=500, top=150,left=150,status=no,toolbar=no,menubar=no,l ocation=no,scrollbars=no,resizable=yes,copyhistory= false')");

            if (!IsPostBack)
            {

                this.lbl_operacion.Visible = false;
                this.lbl_numero.Visible = false;

                this.lbl_numero.Text = "0";

                this.lbl_operacion.Text = "";
                this.ib_adquiriente.Visible = false;
                this.ib_compra_para.Visible = false;

                FuncionGlobal.combocliente(this.dl_cliente);
                FuncionGlobal.combotipovehiculo(this.dl_tipo_vehiculo);
                FuncionGlobal.combomarcavehiculo(this.dl_marca_vehiculo);
                FuncionGlobal.comboparametro(this.dl_combustible, "COMB");

                FuncionGlobal.comboparametro(this.dl_notaria, "NOT");
                FuncionGlobal.comboparametro(this.dl_forma_pago, "FOPA");
                FuncionGlobal.comboparametro(this.dl_tag, "TAG");
                FuncionGlobal.comboparametro(this.dl_cargo_venta, "CAVE");
                FuncionGlobal.comboparametro(this.dl_tipo_tramite, "TITR");

                FuncionGlobal.combobanco(this.dl_financiera,1);
                FuncionGlobal.combopoliza(this.dl_distribuidor_poliza);

                FuncionGlobal.combopais(this.dl_pais);
                FuncionGlobal.combopais(this.dl_pais_para);
                this.txt_factura.Focus();
                

            }
        
        }

        protected void dl_tipo_vehiculo_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void dl_marca_vehiculo_SelectedIndexChanged(object sender, EventArgs e)
        {
            FuncionGlobal.combomodelovehiculo(this.dl_modelo_vehiculo, Convert.ToInt16(this.dl_marca_vehiculo.SelectedValue),
                                                            this.dl_tipo_vehiculo.SelectedValue);
        }

        protected void dl_cliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            FuncionGlobal.combosucursalbycliente(this.dl_sucursal_origen, Convert.ToInt16(this.dl_cliente.SelectedValue));
            FuncionGlobal.combosucursalbycliente(this.dl_sucursal_destino, Convert.ToInt16(this.dl_cliente.SelectedValue));
        }

        protected void dl_pais_SelectedIndexChanged(object sender, EventArgs e)
        {
            FuncionGlobal.comboregion(this.dl_region, this.dl_pais.SelectedValue);
        }

        protected void dl_pais_para_SelectedIndexChanged(object sender, EventArgs e)
        {
            FuncionGlobal.comboregion(this.dl_region_para, this.dl_pais.SelectedValue);
        }


        protected void dl_region_SelectedIndexChanged(object sender, EventArgs e)
        {
            FuncionGlobal.combociudad(this.dl_ciudad, Convert.ToInt16(this.dl_region.SelectedValue));
        }

        protected void dl_region_para_SelectedIndexChanged(object sender, EventArgs e)
        {
            FuncionGlobal.combociudad(this.dl_ciudad_para, Convert.ToInt16(this.dl_region.SelectedValue));
        }


        protected void dl_ciudad_SelectedIndexChanged(object sender, EventArgs e)
        {
            FuncionGlobal.combocomuna(this.dl_comuna, Convert.ToInt16(this.dl_ciudad.SelectedValue));
            this.ib_comuna.Attributes.Add("OnClick", "javascript:window.showModalDialog('../administracion/mComunamodal.aspx?id_ciudad=" + this.dl_ciudad.SelectedValue.Trim() + "','#1','dialogHeight: 400px; dialogWidth: 350px;dialogTop: 190px; dialogLeft: 220px; edge: Raised; center: Yes;help: No; resizable: No; status: No;');");
            ib_comuna.Visible = true;
        }

        protected void dl_ciudad_para_SelectedIndexChanged(object sender, EventArgs e)
        {
            FuncionGlobal.combocomuna(this.dl_comuna_para, Convert.ToInt16(this.dl_ciudad_para.SelectedValue));
            this.ib_comuna_para.Attributes.Add("OnClick", "javascript:window.showModalDialog('../administracion/mComunamodal.aspx?id_ciudad=" + this.dl_ciudad_para.SelectedValue.Trim() + "','#1','dialogHeight: 400px; dialogWidth: 350px;dialogTop: 190px; dialogLeft: 220px; edge: Raised; center: Yes;help: No; resizable: No; status: No;');");
            ib_comuna_para.Visible = true;
        }

        protected void dl_comuna_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void txt_factura_Leave(object sender, EventArgs e)
        {


            if (this.dl_cliente.SelectedValue != "0" && this.txt_factura.Text.Trim() != "")
            {
                busca_operacion();
            }
        
        }

		//private void carga_rpt(Int32 id_solicitud)
		//{

		//    ReportDocument rpt = new ReportDocument();
		//    rpt.Load(Server.MapPath("../reportes/InfCaratulaPI.rpt"));

		//    rpt.SetParameterValue(0, id_solicitud);


		//    rpt.OpenSubreport("DATOVEHICULO");
		//    rpt.SetParameterValue(1, id_solicitud);

		//    rpt.OpenSubreport("DETALLE_GASTOS");
		//    rpt.SetParameterValue(2, id_solicitud);


		//    Session.Add("documento", rpt);
		//    Session.Add("nombre_rpt", "InfCaratulaPI.rpt");


		//}



        private void busca_operacion()

        {

            Preinscripcion mpreinscripcion = new PreinscripcionBC().Getpreinscripcionbyfactura(Convert.ToInt16(this.dl_cliente.SelectedValue),
                Convert.ToDouble(this.txt_factura.Text));



            if (mpreinscripcion != null)
            {

                this.bt_caratula.Visible = true;
                //carga_rpt(mpreinscripcion.Operacion.Id_solicitud);

                this.lbl_operacion.Visible = true;
                this.lbl_numero.Visible = true;
                this.lbl_operacion.Text = "Operación de Primera Inscripción Numero:";
                this.lbl_numero.Text = Convert.ToString(mpreinscripcion.Operacion.Id_solicitud);

                //**datos vehiculo

				//if (mpreinscripcion.Pre_dato_vehiculo != null)
				//{

				//    this.dl_tipo_vehiculo.SelectedValue = mpreinscripcion.Pre_dato_vehiculo.Modelo.Tipovehiculo.Codigo;
				//    this.dl_marca_vehiculo.SelectedValue = Convert.ToString(mpreinscripcion.Pre_dato_vehiculo.Modelo.Marcavehiculo.Id_marca);

				//    FuncionGlobal.combomodelovehiculo(this.dl_modelo_vehiculo, Convert.ToInt16(this.dl_marca_vehiculo.SelectedValue),
				//                                        this.dl_tipo_vehiculo.SelectedValue);

				//    this.dl_modelo_vehiculo.SelectedValue = mpreinscripcion.Pre_dato_vehiculo.Modelo.Id_Modelo.ToString();
                        

				//    this.txt_ano_vehiculo.Text = mpreinscripcion.Pre_dato_vehiculo.Ano.ToString();
				//    this.txt_cilindrada.Text = mpreinscripcion.Pre_dato_vehiculo.Cilindraje;
				//    this.txt_puertas.Text = mpreinscripcion.Pre_dato_vehiculo.N_puerta.ToString();
				//    this.txt_asientos.Text = mpreinscripcion.Pre_dato_vehiculo.N_asiento.ToString();
				//    this.txt_peso_bruto.Text = mpreinscripcion.Pre_dato_vehiculo.Pesobruto.ToString();
				//    this.txt_peso_carga.Text = mpreinscripcion.Pre_dato_vehiculo.Carga.ToString();
				//    this.dl_combustible.SelectedValue = mpreinscripcion.Pre_dato_vehiculo.Combustible.Trim();
				//    this.txt_color.Text = mpreinscripcion.Pre_dato_vehiculo.Color;
				//    this.txt_motor.Text = mpreinscripcion.Pre_dato_vehiculo.Motor;
				//    this.txt_chasis.Text = mpreinscripcion.Pre_dato_vehiculo.Chassis;
				//    this.txt_patente.Text = mpreinscripcion.Pre_dato_vehiculo.Patente.Trim();
				//    this.txt_dv_patente.Text = mpreinscripcion.Pre_dato_vehiculo.Dv.Trim();

				//}

                //**datos negocio
                
                this.txt_neto.Text = mpreinscripcion.Neto_factura.ToString();
                this.txt_fecha_factura.Text = string.Format("{0:dd/MM/yyyy}", mpreinscripcion.Fechafactura);
                this.dl_sucursal_origen.SelectedValue = mpreinscripcion.Sucursal_origen.Id_sucursal.ToString();
                this.dl_sucursal_destino.SelectedValue = mpreinscripcion.Sucursal_destino.Id_sucursal.ToString();
                this.dl_forma_pago.SelectedValue = mpreinscripcion.Tipo_pago_factura.Trim();
                this.dl_financiera.SelectedValue = mpreinscripcion.Bancofinanciera.Codigo.Trim();
                this.txt_poliza.Text = mpreinscripcion.N_poliza;
                this.dl_distribuidor_poliza.SelectedValue = mpreinscripcion.Distribuidor_poliza.Codigo.Trim();
                this.dl_cargo_venta.SelectedValue = mpreinscripcion.Cargo_venta.Trim();
                this.dl_tipo_tramite.SelectedValue = mpreinscripcion.Tipo_tramite.Trim();
                this.dl_notaria.SelectedValue = mpreinscripcion.Legalizar.Trim();
                this.txt_terminacion.Text = mpreinscripcion.Terminacion_especial;
                this.dl_tag.SelectedValue = mpreinscripcion.Tag.Trim();
            
                //**adquiriente

                if (mpreinscripcion.Adquiriente != null)
                {
                    busca_persona(mpreinscripcion.Adquiriente.Rut);
                    this.txt_rut.Text = mpreinscripcion.Adquiriente.Rut.ToString();
                }
                if (mpreinscripcion.Compra_para != null)
                {  busca_persona_para(mpreinscripcion.Compra_para.Rut);
                    this.txt_rut_para.Text = mpreinscripcion.Compra_para.Rut.ToString();
                    this.chk_compra_para.Checked = true;
                    this.Panel1.Visible = true;
                }


                mpreinscripcion = null;
            }


        }
        
        protected void txt_rut_Leave(object sender, EventArgs e)
        {

            this.txt_dv.Text = FuncionGlobal.digitoVerificador(this.txt_rut.Text);

            busca_persona(Convert.ToDouble(this.txt_rut.Text));

            this.ib_adquiriente.Attributes.Add("OnClick", "javascript:window.showModalDialog('../administracion/mPersonaModal.aspx?id_persona="  + FuncionGlobal.FuctionEncriptar(this.txt_rut.Text) + "','#1','dialogHeight: 350px; dialogWidth: 900px;dialogTop: 190px; dialogLeft: 220px; edge: Raised; center: Yes;help: No; resizable: No; status: No;');");

        

            
            this.ib_adquiriente.Visible = true;
            this.txt_nombre.Focus();

        }

        protected void txt_rut_para_Leave(object sender, EventArgs e)
        {

            this.txt_dv.Text = FuncionGlobal.digitoVerificador(this.txt_rut.Text);

            busca_persona_para(Convert.ToDouble(this.txt_rut_para.Text));

            this.ib_compra_para.Attributes.Add("OnClick", "javascript:window.showModalDialog('../administracion/mPersonaModal.aspx?id_persona=" + FuncionGlobal.FuctionEncriptar(this.txt_rut_para.Text) + "','#1','dialogHeight: 350px; dialogWidth: 900px;dialogTop: 190px; dialogLeft: 220px; edge: Raised; center: Yes;help: No; resizable: No; status: No;');");

            this.ib_compra_para.Visible = true;
            
            this.txt_nombre.Focus();

        }

        private void busca_persona_para(double rut)
        {

            Persona mpersona = new PersonaBC().getpersonabyrut(rut);

            if (mpersona.Rut == Convert.ToDouble(0))
            {
                this.txt_dv_para.Focus();
                return;

            }

            this.ib_compra_para.Attributes.Add("OnClick", "javascript:window.showModalDialog('../administracion/mPersonaModal.aspx?id_persona=" + FuncionGlobal.FuctionEncriptar(mpersona.Rut.ToString()) + "','#1','dialogHeight: 350px; dialogWidth: 900px;dialogTop: 190px; dialogLeft: 220px; edge: Raised; center: Yes;help: No; resizable: No; status: No;');");
            this.ib_compra_para.Visible = true;
            
            this.txt_rut_para.Enabled = false;
            this.txt_dv_para.Enabled = false;

            this.txt_nombre_para.Text = mpersona.Nombre;
            this.txt_paterno_para.Text = mpersona.Apellido_paterno;
            this.txt_materno_para.Text = mpersona.Apellido_materno;
            this.txt_dv_para.Text = mpersona.Dv;
            this.txt_direccion_para.Text = mpersona.Direccion;
            this.txt_numero_para.Text = mpersona.Numero;
            this.txt_depto_para.Text = mpersona.Depto;
            this.txt_telefono_para.Text = mpersona.Telefono;


            this.dl_pais_para.SelectedValue = mpersona.Comuna.Ciudad.Region.Pais.Codigo;
            FuncionGlobal.comboregion(this.dl_region_para, mpersona.Comuna.Ciudad.Region.Pais.Codigo);
            this.dl_region_para.SelectedValue = Convert.ToString(mpersona.Comuna.Ciudad.Region.Id_region);

            FuncionGlobal.combociudad(this.dl_ciudad_para, Convert.ToInt16(mpersona.Comuna.Ciudad.Region.Id_region));
            this.dl_ciudad_para.SelectedValue = Convert.ToString(mpersona.Comuna.Ciudad.Id_Ciudad);
            FuncionGlobal.combocomuna(this.dl_comuna_para, Convert.ToInt16(mpersona.Comuna.Ciudad.Id_Ciudad));
            this.dl_comuna_para.SelectedValue = Convert.ToString(mpersona.Comuna.Id_Comuna);

        }

        private void busca_persona(double rut)
        {

            Persona mpersona = new PersonaBC().getpersonabyrut(rut);

            if (mpersona != null)
            {
                this.ib_adquiriente.Visible = true;
                this.ib_adquiriente.Attributes.Add("OnClick", "javascript:window.showModalDialog('../administracion/mPersonaModal.aspx?id_persona=" + FuncionGlobal.FuctionEncriptar(mpersona.Rut.ToString()) + "','#1','dialogHeight: 350px; dialogWidth: 900px;dialogTop: 190px; dialogLeft: 220px; edge: Raised; center: Yes;help: No; resizable: No; status: No;');");

                this.txt_rut.Enabled = false;
                this.txt_dv.Enabled = false;

                this.txt_nombre.Text = mpersona.Nombre;
                this.txt_paterno.Text = mpersona.Apellido_paterno;
                this.txt_materno.Text = mpersona.Apellido_materno;
                this.txt_dv.Text = mpersona.Dv;
                this.txt_direccion.Text = mpersona.Direccion;
                this.txt_numero.Text = mpersona.Numero;
                this.txt_depto.Text = mpersona.Depto;
                this.txt_telefono.Text = mpersona.Telefono;


                this.dl_pais.SelectedValue = mpersona.Comuna.Ciudad.Region.Pais.Codigo;
                FuncionGlobal.comboregion(this.dl_region, mpersona.Comuna.Ciudad.Region.Pais.Codigo);
                this.dl_region.SelectedValue = Convert.ToString(mpersona.Comuna.Ciudad.Region.Id_region);

                FuncionGlobal.combociudad(this.dl_ciudad, Convert.ToInt16(mpersona.Comuna.Ciudad.Region.Id_region));
                this.dl_ciudad.SelectedValue = Convert.ToString(mpersona.Comuna.Ciudad.Id_Ciudad);
                FuncionGlobal.combocomuna(this.dl_comuna, Convert.ToInt16(mpersona.Comuna.Ciudad.Id_Ciudad));
                this.dl_comuna.SelectedValue = Convert.ToString(mpersona.Comuna.Id_Comuna);
            }
            else
            {
                this.txt_dv.Focus();
                

            }



        }

        protected void bt_limpia_persona_Click(object sender, EventArgs e)
        {
            this.txt_rut.Enabled = true;
            this.txt_rut.Text = "";
            this.txt_dv.Text = "";
            this.txt_nombre.Text="";
            this.txt_paterno.Text = "";
            this.txt_materno.Text = "";
            this.txt_direccion.Text = "";
            this.txt_numero.Text = "";
            this.txt_depto.Text = "";
            this.txt_telefono.Text = "";

            FuncionGlobal.combopais(this.dl_pais);
            this.dl_region.Items.Clear();
            this.dl_ciudad.Items.Clear();
            this.dl_comuna.Items.Clear();
            this.ib_adquiriente.Visible = false;
            this.txt_rut.Focus();
        

        }

        protected void bt_limpia_para_Click(object sender, EventArgs e)
        {
            this.txt_rut_para.Enabled = true;
            this.txt_rut_para.Text = "";
            this.txt_dv_para.Text = "";
            this.txt_nombre_para.Text = "";
            this.txt_paterno_para.Text = "";
            this.txt_materno_para.Text = "";
            this.txt_direccion_para.Text = "";
            this.txt_numero_para.Text = "";
            this.txt_depto_para.Text = "";
            this.txt_telefono_para.Text = "";

           FuncionGlobal.combopais(this.dl_pais_para);
            this.dl_region_para.Items.Clear();
            this.dl_ciudad_para.Items.Clear();
            this.dl_comuna_para.Items.Clear();
            
            this.ib_compra_para.Visible = false;

            this.txt_rut_para.Focus();


        }

        protected void ib_adquiriente_Click(object sender, ImageClickEventArgs e)
        {
            this.busca_persona(Convert.ToDouble(this.txt_rut.Text));

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            add_operacion();
        }

        private void add_operacion()
        {

            Int32 add = new OperacionBC().add_operacion(Convert.ToInt32(this.lbl_numero.Text), Convert.ToInt16(this.dl_cliente.SelectedValue), "PI", (string)(Session["usrname"]), 0, "", Convert.ToInt32(this.dl_sucursal_origen.SelectedValue),0);
            if (add != 0)
            {

				string add_PI = new PreinscripcionBC().add_preinscripcion(add,
																Convert.ToDouble(this.txt_factura.Text),
																this.txt_poliza.Text.Trim(),
																this.dl_tag.SelectedValue,
																this.dl_notaria.SelectedValue,
																this.dl_tipo_tramite.SelectedValue,
																this.dl_cargo_venta.SelectedValue,
																this.txt_fecha_factura.Text,
																Convert.ToDouble(this.txt_rut.Text),
																this.dl_financiera.SelectedValue,
																this.dl_distribuidor_poliza.SelectedValue,
																Convert.ToDouble(this.txt_rut_para.Text),
																this.dl_forma_pago.SelectedValue,
																Convert.ToDouble(this.txt_neto.Text),
																this.txt_terminacion.Text,
																19,
																Convert.ToInt16(this.dl_sucursal_origen.SelectedValue),
																Convert.ToInt16(this.dl_sucursal_destino.SelectedValue),
																0,0,"","");
                if (add_PI == "")

                { 
                
                        string add_PDV = new PredatovehiculoBC().add_Predatovehiculo(add,
                                                                    Convert.ToInt16(this.dl_modelo_vehiculo.SelectedValue),
                                                                    this.txt_chasis.Text.Trim(),
                                                                    Convert.ToInt16(this.txt_ano_vehiculo.Text),
                                                                    this.txt_motor.Text.Trim(),
                                                                    this.txt_cilindrada.Text.Trim(),
                                                                    this.txt_patente.Text.Trim(),
                                                                    this.txt_color.Text.Trim(),
                                                                    Convert.ToDouble(this.txt_peso_carga.Text),
                                                                    Convert.ToDouble(this.txt_peso_bruto.Text),
                                                                    this.dl_combustible.SelectedValue,
                                                                    Convert.ToInt16(this.txt_puertas.Text),
                                                                    Convert.ToInt16(this.txt_asientos.Text),
                                                                    this.txt_dv_patente.Text.Trim());



                   

                
                
                }


            }



            this.lbl_operacion.Visible = true;
            this.lbl_numero.Visible = true;
            this.lbl_operacion.Text = "Operación de Primera Inscripción Numero:";
            this.lbl_numero.Text = Convert.ToString(add);

            this.bt_caratula.Visible = true;
            //carga_rpt(add);


        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            this.lbl_numero.Text = "0";
            this.lbl_operacion.Text = "";
            Page.Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);
        }

        protected void ib_comuna_Click(object sender, ImageClickEventArgs e)
        {
            FuncionGlobal.combocomuna(this.dl_comuna, Convert.ToInt16(this.dl_ciudad.SelectedValue));
        }

        protected void ib_comuna_para_Click(object sender, ImageClickEventArgs e)
        {
            FuncionGlobal.combocomuna(this.dl_comuna_para, Convert.ToInt16(this.dl_ciudad_para.SelectedValue));
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

        }

        protected void chk_compra_para_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chk_compra_para.Checked)
            {
                this.Panel1.Visible = true;
            }
            else
            {
                this.Panel1.Visible = false;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        protected void bt_guardar_Click(object sender, EventArgs e)
        {

        }

        protected void bt_caratula_Click(object sender, EventArgs e)
        {

        }
      

      


    }
}
