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
    public partial class ingresoTR : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {

                this.lbl_numero.Text = "0";
                this.pnl_comprador.Visible = false;
                this.pnl_compra_para.Visible = false;


                FuncionGlobal.comboclientesbyusuario((string)(Session["usrname"]),this.dl_cliente);
                FuncionGlobal.combopais(this.dl_pais);
                FuncionGlobal.combopais(this.dl_pais_para);
                FuncionGlobal.combopais(this.dl_pais_compra);
            }

        }




        private void add()
        {


            double rut_compra_para;
            double rut_comprador;

            rut_compra_para = 0;
            rut_comprador = 0;

            //gravar dato vendedor en perona

            string persona = new PersonaBC().add_persona(Convert.ToDouble(this.txt_rut.Text),
                                                                this.txt_dv.Text,
                                                                Convert.ToInt16(this.dl_comuna.SelectedValue),
                                                                   "",
                                                                   this.txt_nombre.Text,
                                                                   this.txt_paterno.Text,
                                                                   this.txt_materno.Text,
                                                                   "0",
                                                                   "0",
                                                                   "",
                                                                   "",
                                                                   "0",
                                                                   this.txt_telefono.Text,
                                                                   "",
                                                                   "",
                                                                   this.txt_direccion.Text,
                                                                   this.txt_numero.Text,
                                                                   this.txt_depto.Text,
                                                                   "0","");


            if (this.rb_consignacion.Checked == false)
            {

                rut_comprador = Convert.ToDouble(this.txt_rut_compra.Text);
                //graba dato comprador en persona
                string personacom = new PersonaBC().add_persona(Convert.ToDouble(this.txt_rut_compra.Text),
                                                             this.txt_dv.Text,
                                                             Convert.ToInt16(this.dl_comuna_compra.SelectedValue),
                                                                "",
                                                                this.txt_nombre_compra.Text,
                                                                this.txt_apellidop_compra.Text,
                                                                this.txt_apellidom_compra.Text,
                                                                "0",
                                                                "0",
                                                                "",
                                                                "",
                                                                "0",
                                                                this.txt_telefono_compra.Text,
                                                                "",
                                                                "",
                                                                this.txt_direccion_compra.Text,
                                                                this.txt_numero_compra.Text,
                                                                this.txt_depto_compra.Text,
                                                                "0","");


                if (this.chk_compra_para.Checked == true)
                {

                    rut_compra_para = Convert.ToDouble(this.txt_rut_para.Text);

                    //grabo dato compra para en persona
                    string personacpara = new PersonaBC().add_persona(Convert.ToDouble(this.txt_rut_para.Text),
                                                               this.txt_dv.Text,
                                                               Convert.ToInt16(this.dl_comuna_para.SelectedValue),
                                                                  "",
                                                                  this.txt_nombre_para.Text,
                                                                  this.txt_paterno_para.Text,
                                                                  this.txt_materno_para.Text,
                                                                  "0",
                                                                  "0",
                                                                  "",
                                                                  "",
                                                                  "0",
                                                                  this.txt_telefono_para.Text,
                                                                  "",
                                                                  "",
                                                                  this.txt_direccion_para.Text,
                                                                  this.txt_numero_para.Text,
                                                                  this.txt_depto_para.Text,
                                                                  "0","");


                }

            }


            Int32 add = new OperacionBC().add_operacion(Convert.ToInt32(this.lbl_numero.Text), Convert.ToInt16(this.dl_cliente.SelectedValue), "TR", (string)(Session["usrname"]), 0, "", 0,0);

            if (add != 0)
            {

                string add_TR = new TransferenciaBC().add_Transferencia(add, 
                                                                        Convert.ToDouble(this.txt_rut.Text),
                                                                   
                                                                        rut_comprador,
                                                                        rut_compra_para,
                                                                        1,"","");


            }



            this.lbl_operacion.Visible = true;
            this.lbl_numero.Visible = true;
            this.lbl_operacion.Text = "Operación de Transferencia Numero:";
            this.lbl_numero.Text = Convert.ToString(add);
            FuncionGlobal.alerta("CONTRATO DE TRANSFERENCIA, INGRESADO CON EXITO", Page);
        }




        protected void chk_compra_para_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chk_compra_para.Checked)
            {
                this.pnl_compra_para.Visible = true;
            }
            else
            {
                this.pnl_compra_para.Visible = false;
            }
        }


        protected void txt_rut_Leave(object sender, EventArgs e)
        {

            this.txt_dv.Text = FuncionGlobal.digitoVerificador(this.txt_rut.Text);

            busca_persona(Convert.ToDouble(this.txt_rut.Text));

            this.ib_adquiriente.Attributes.Add("OnClick", "javascript:window.showModalDialog('../administracion/mPersonaModal.aspx?id_persona=" + this.txt_rut.Text + "','#1','dialogHeight: 350px; dialogWidth: 900px;dialogTop: 190px; dialogLeft: 220px; edge: Raised; center: Yes;help: No; resizable: No; status: No;');");
            this.ib_par_vendedor.Attributes.Add("onclick", "javascript:window.showModalDialog('../administracion/mParticipante.aspx?rut=" + this.txt_rut.Text + "&nombre=" + this.txt_nombre.Text + " " + this.txt_paterno.Text + "','','status:false;dialogWidth:900px;dialogHeight:500px')");



            this.ib_adquiriente.Visible = true;
            this.ib_par_vendedor.Visible = true;
            this.txt_nombre.Focus();

        }


        private void busca_persona(double rut)
        {

            Persona mpersona = new PersonaBC().getpersonabyrut(rut);

            if (mpersona != null)
            {
                this.ib_adquiriente.Visible = true;
                this.ib_par_vendedor.Visible = true;
                this.ib_adquiriente.Attributes.Add("OnClick", "javascript:window.showModalDialog('../administracion/mPersonaModal.aspx?id_persona=" + mpersona.Rut.ToString() + "','#1','dialogHeight: 350px; dialogWidth: 900px;dialogTop: 190px; dialogLeft: 220px; edge: Raised; center: Yes;help: No; resizable: No; status: No;');");
                this.ib_par_vendedor.Attributes.Add("onclick", "javascript:window.showModalDialog('../administracion/mParticipante.aspx?rut=" + mpersona.Rut.ToString() + "&nombre=" + mpersona.Nombre.ToString() + " " + mpersona.Apellido_paterno.ToString() + "','','status:false;dialogWidth:900px;dialogHeight:500px')");

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

        protected void txt_rut_para_Leave(object sender, EventArgs e)
        {

            this.txt_dv.Text = FuncionGlobal.digitoVerificador(this.txt_rut.Text);

            busca_persona_para(Convert.ToDouble(this.txt_rut_para.Text));

            this.ib_compra_para.Attributes.Add("OnClick", "javascript:window.showModalDialog('../administracion/mPersonaModal.aspx?id_persona=" + this.txt_rut_para.Text + "','#1','dialogHeight: 350px; dialogWidth: 900px;dialogTop: 190px; dialogLeft: 220px; edge: Raised; center: Yes;help: No; resizable: No; status: No;');");

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

            this.ib_compra_para.Attributes.Add("OnClick", "javascript:window.showModalDialog('../administracion/mPersonaModal.aspx?id_persona=" + mpersona.Rut.ToString() + "','#1','dialogHeight: 350px; dialogWidth: 900px;dialogTop: 190px; dialogLeft: 220px; edge: Raised; center: Yes;help: No; resizable: No; status: No;');");
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

        private void limpia_comprador()
        {

            limpia_para();
            this.chk_compra_para.Checked = false;
            this.pnl_compra_para.Visible = false;
            

            this.txt_rut_compra.Enabled = true;
            this.txt_rut_compra.Text = "";
            this.txt_dv_compra.Text = "";
            this.txt_nombre_compra.Text = "";
            this.txt_apellidop_compra.Text = "";
            this.txt_apellidom_compra.Text = "";
            this.txt_direccion_compra.Text = "";
            this.txt_numero_compra.Text = "";
            this.txt_depto_compra.Text = "";
            this.txt_telefono_compra.Text = "";

            FuncionGlobal.combopais(this.dl_pais_compra);
            this.dl_region_compra.Items.Clear();
            this.dl_ciudad_compra.Items.Clear();
            this.dl_comuna_compra.Items.Clear();
            this.ib_adquiriente.Visible = false;
            this.txt_rut_compra.Focus();


        }

        private void limpia_vende()
        {
            this.txt_rut.Enabled = true;
            this.txt_rut.Text = "";
            this.txt_dv.Text = "";
            this.txt_nombre.Text = "";
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

        private  void limpia_para()
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

        protected void dl_pais_SelectedIndexChanged(object sender, EventArgs e)
        {
            FuncionGlobal.comboregion(this.dl_region, this.dl_pais.SelectedValue);
        }

        protected void dl_pais_para_SelectedIndexChanged(object sender, EventArgs e)
        {
                FuncionGlobal.comboregion(this.dl_region_para, this.dl_pais_para.SelectedValue);
        }

        protected void dl_region_SelectedIndexChanged(object sender, EventArgs e)
        {
            FuncionGlobal.combociudad(this.dl_ciudad, Convert.ToInt16(this.dl_region.SelectedValue));
        }

        protected void dl_region_compra_SelectedIndexChanged(object sender, EventArgs e)
        {
            FuncionGlobal.combociudad(this.dl_ciudad_compra, Convert.ToInt16(this.dl_region_compra.SelectedValue));
        }

        protected void dl_comuna_SelectedIndexChanged(object sender, EventArgs e)
        {
            FuncionGlobal.combocomuna(this.dl_comuna, Convert.ToInt16(this.dl_ciudad.SelectedValue));
        }

        protected void dl_ciudad_SelectedIndexChanged(object sender, EventArgs e)
        {
            FuncionGlobal.combocomuna(this.dl_comuna, Convert.ToInt16(this.dl_ciudad.SelectedValue));
            this.ib_comuna.Attributes.Add("OnClick", "javascript:window.showModalDialog('../administracion/mComunamodal.aspx?id_ciudad=" + this.dl_ciudad.SelectedValue.Trim() + "','#1','dialogHeight: 400px; dialogWidth: 350px;dialogTop: 190px; dialogLeft: 220px; edge: Raised; center: Yes;help: No; resizable: No; status: No;');");
            ib_comuna.Visible = true;
        }

        protected void dl_ciudad_compra_SelectedIndexChanged(object sender, EventArgs e)
        {
            FuncionGlobal.combocomuna(this.dl_comuna_compra, Convert.ToInt16(this.dl_ciudad_compra.SelectedValue));
            this.ib_comuna.Attributes.Add("OnClick", "javascript:window.showModalDialog('../administracion/mComunamodal.aspx?id_ciudad=" + this.dl_ciudad.SelectedValue.Trim() + "','#1','dialogHeight: 400px; dialogWidth: 350px;dialogTop: 190px; dialogLeft: 220px; edge: Raised; center: Yes;help: No; resizable: No; status: No;');");
            ib_comuna.Visible = true;
        }

        protected void dl_region_para_SelectedIndexChanged(object sender, EventArgs e)
        {
            FuncionGlobal.combociudad(this.dl_ciudad_para, Convert.ToInt16(this.dl_region_para.SelectedValue));
        }

        protected void dl_comuna_para_SelectedIndexChanged(object sender, EventArgs e)
        {
            FuncionGlobal.combocomuna(this.dl_comuna_para, Convert.ToInt16(this.dl_ciudad_para.SelectedValue));
        }

        protected void dl_ciudad_para_SelectedIndexChanged(object sender, EventArgs e)
        {
            FuncionGlobal.combocomuna(this.dl_comuna_para, Convert.ToInt16(this.dl_ciudad_para.SelectedValue));
            this.ib_comuna.Attributes.Add("OnClick", "javascript:window.showModalDialog('../administracion/mComunamodal.aspx?id_ciudad=" + this.dl_ciudad.SelectedValue.Trim() + "','#1','dialogHeight: 400px; dialogWidth: 350px;dialogTop: 190px; dialogLeft: 220px; edge: Raised; center: Yes;help: No; resizable: No; status: No;');");
            ib_comuna.Visible = true;
        }

        protected void ib_comuna_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void ib_adquiriente_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void ib_comuna_para_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void ib_compra_para_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void txt_direccion_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txt_direccion_compra_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txt_direccion_para_TextChanged(object sender, EventArgs e)
        {

        }


        protected void btn_guardar_Click(object sender, EventArgs e)
        {
          
        }

        protected void dl_pais_compra_SelectedIndexChanged(object sender, EventArgs e)
        {
            FuncionGlobal.comboregion(this.dl_region_compra, this.dl_pais_compra.SelectedValue);
        }

        protected void depto_compra_TextChanged(object sender, EventArgs e)
        {

        }

        protected void telefono_compra_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txt_rut_compra_Leave(object sender, EventArgs e)
        {

            this.txt_dv_compra.Text = FuncionGlobal.digitoVerificador(this.txt_rut_compra.Text);

            busca_comprador(Convert.ToDouble(this.txt_rut_compra.Text));

            this.ib_comprador.Attributes.Add("OnClick", "javascript:window.showModalDialog('../administracion/mPersonaModal.aspx?id_persona=" + this.txt_rut_compra.Text + "','#1','dialogHeight: 350px; dialogWidth: 900px;dialogTop: 190px; dialogLeft: 220px; edge: Raised; center: Yes;help: No; resizable: No; status: No;');");

            this.ib_comprador.Visible = true;
            this.txt_nombre_compra.Focus();

        }


        private void busca_comprador(double rut)
        {

            Persona mpersona = new PersonaBC().getpersonabyrut(rut);

            if (mpersona != null)
            {
                this.ib_comprador.Visible = true;
                this.ib_par_comprador.Visible = true;

                this.ib_comprador.Attributes.Add("OnClick", "javascript:window.showModalDialog('../administracion/mPersonaModal.aspx?id_persona=" + mpersona.Rut.ToString() + "','#1','dialogHeight: 350px; dialogWidth: 900px;dialogTop: 190px; dialogLeft: 220px; edge: Raised; center: Yes;help: No; resizable: No; status: No;');");
                this.ib_par_comprador.Attributes.Add("onclick", "javascript:window.showModalDialog('../administracion/mParticipante.aspx?rut=" + mpersona.Rut.ToString() + "&nombre=" + mpersona.Nombre.ToString() + " " + mpersona.Apellido_paterno.ToString() + "','','status:false;dialogWidth:900px;dialogHeight:500px')");


                this.txt_rut_compra.Enabled = false;
                this.txt_dv_compra.Enabled = false;

                this.txt_nombre_compra.Text = mpersona.Nombre;
                this.txt_apellidop_compra.Text = mpersona.Apellido_paterno;
                this.txt_apellidom_compra.Text = mpersona.Apellido_materno;
                this.txt_dv_compra.Text = mpersona.Dv;
                this.txt_direccion_compra.Text = mpersona.Direccion;
                this.txt_numero_compra.Text = mpersona.Numero;
                this.txt_depto_compra.Text = mpersona.Depto;
                this.txt_telefono_compra.Text = mpersona.Telefono;


                this.dl_pais_compra.SelectedValue = mpersona.Comuna.Ciudad.Region.Pais.Codigo;
                FuncionGlobal.comboregion(this.dl_region_compra, mpersona.Comuna.Ciudad.Region.Pais.Codigo);
                this.dl_region_compra.SelectedValue = Convert.ToString(mpersona.Comuna.Ciudad.Region.Id_region);

                FuncionGlobal.combociudad(this.dl_ciudad_compra, Convert.ToInt16(mpersona.Comuna.Ciudad.Region.Id_region));
                this.dl_ciudad_compra.SelectedValue = Convert.ToString(mpersona.Comuna.Ciudad.Id_Ciudad);
                FuncionGlobal.combocomuna(this.dl_comuna_compra, Convert.ToInt16(mpersona.Comuna.Ciudad.Id_Ciudad));
                this.dl_comuna_compra.SelectedValue = Convert.ToString(mpersona.Comuna.Id_Comuna);
            }
            else
            {
                this.txt_dv_compra.Focus();

            }
        }



        protected void rb_consignacion_CheckedChanged1(object sender, EventArgs e)
        {
            this.pnl_compra_para.Visible = false;
            this.pnl_comprador.Visible = false;
        }

        
        protected void rb_consignacion_CheckedChanged2(object sender, EventArgs e)
        {
            limpia_comprador();
            this.pnl_comprador.Visible = false;
            this.pnl_compra_para.Visible = false;
            this.chk_compra_para.Checked = false;
        }

        protected void rb_automotora_CheckedChanged(object sender, EventArgs e)
        {
            limpia_comprador();
            this.pnl_comprador.Visible = true;

            if (this.dl_cliente.SelectedValue == "0")
            { return; }
            
            Cliente mcliente = new ClienteBC().getcliente(Convert.ToInt16(this.dl_cliente.SelectedValue));

            this.txt_rut_compra.Text = mcliente.Persona.Rut.ToString();
            busca_comprador(mcliente.Persona.Rut);
        }

        protected void rb_tercero_CheckedChanged1(object sender, EventArgs e)
        {
            limpia_comprador();
            this.pnl_comprador.Visible = true;
        }

        protected void bt_salir_OnClick(object sender, EventArgs e)
        {
            
        }

        protected void ib_busca_sii_Click(object sender, ImageClickEventArgs e)
        {
            if (this.txt_sii.Text.Trim() != "")
            {
                busca_sii();

              

            }
        }

        private void busca_sii()

        {
            List<TasacionSII> ltasa = new TasacionSIIBC().GetTasacionbydatos(this.txt_sii.Text.Trim(), "", "", 0);


            this.gr_dato.DataSource = ltasa;
            this.gr_dato.DataBind();
            this.ModalPopupExtender.Show();
        
        }
        protected void gr_dato_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gr_dato.SelectedRow;

            Int32 valor;
            valor =  Convert.ToInt32(row.Cells[8].Text);

            this.txt_tasacion.Text =  valor.ToString();
            this.lbl_codigo.Text = this.txt_sii.Text.Trim();
        }

        protected void dl_cliente_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (this.dl_cliente.SelectedValue == "0")
            { return; }

            if (this.rb_automotora.Checked == true)

            {
                limpia_comprador();
                Cliente mcliente = new ClienteBC().getcliente(Convert.ToInt16(this.dl_cliente.SelectedValue));
                this.txt_rut_compra.Text = mcliente.Persona.Rut.ToString();
                busca_comprador(mcliente.Persona.Rut);
            
            }
        }

        protected void ib_limpia_vende_Click(object sender, ImageClickEventArgs e)
        {
            limpia_vende();
        }

        protected void ib_limpia_compra_Click(object sender, ImageClickEventArgs e)
        {
            limpia_comprador();
        }

        protected void ib_limpia_para_Click(object sender, ImageClickEventArgs e)
        {
            limpia_para();
        }

        protected void bt_guardar_Click(object sender, EventArgs e)
        {
            add();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            this.lbl_numero.Text = "0";
            this.lbl_operacion.Text = "";
            Page.Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);

        }
            
    }

}

