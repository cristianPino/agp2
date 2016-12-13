using System;
using System.Collections;
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
using System.Collections.Generic;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Web;


namespace sistemaAGP
{
    public partial class mPersonaModal : System.Web.UI.Page
    {

        private Int32 id_persona;
        private string id_pers;

        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                id_pers = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_persona"].ToString());
                
                this.txt_rut.Text = id_pers;

                id_persona = Convert.ToInt32(id_pers);



                ib_ficha.Attributes.Add("onclick", "javascript:window.open('../reportes/reporte_prueba.aspx','_blank','height=355,width=500, top=150,left=150,status=no,toolbar=no,menubar=no,l ocation=no,scrollbars=no,resizable=yes,copyhistory= false')");


                this.ib_ficha.Visible = false;
                this.ib_personeria.Visible = false;

                FuncionGlobal.comboparametro(this.dl_estado_civil, "ESCIVIL");
                FuncionGlobal.comboparametro(this.dl_sexo, "SEXO");
                FuncionGlobal.comboparametro(this.dl_tipo_persona, "TIPOPER");
                FuncionGlobal.comboparametro(this.dl_tipo_empleador, "TIPOEMPL");
                FuncionGlobal.combopais(this.dl_pais);
                this.txt_rut.Focus();
                this.busca_persona(Convert.ToDouble(id_persona));

            }


        }

        private void busca_persona(double rut)
        {

            Persona mpersona = new PersonaBC().getpersonabyrut(rut);

            if (mpersona != null)
            {


                this.ib_personeria.Visible = true;
                this.ib_ficha.Visible = true;
                //carga_rpt();

                this.txt_rut.Enabled = false;
                this.txt_dv.Enabled = false;

                

                this.txt_nombre.Text = mpersona.Nombre;
                this.txt_paterno.Text = mpersona.Apellido_paterno;
                this.txt_materno.Text = mpersona.Apellido_materno;
                this.txt_dv.Text = mpersona.Dv;
                this.txt_serie.Text = mpersona.Serie;
                this.txt_nacionalidad.Text = mpersona.Nacionalidad;
                this.txt_profesion.Text = mpersona.Profesion;
                this.txt_telefono.Text = mpersona.Telefono;
                this.txt_celular.Text = mpersona.Celular;
                this.txt_correo.Text = mpersona.Correo;
                this.txt_direccion.Text = mpersona.Direccion;
                this.txt_numero.Text = mpersona.Numero;
                this.txt_depto.Text = mpersona.Depto;

                this.dl_tipo_persona.SelectedValue = mpersona.Tipo_persona;
                this.dl_tipo_empleador.SelectedValue = mpersona.Tipo_empleador;
                this.dl_sexo.SelectedValue = mpersona.Sexo;
                this.dl_estado_civil.SelectedValue = mpersona.Estado_civil;

                this.dl_pais.SelectedValue = mpersona.Comuna.Ciudad.Region.Pais.Codigo;
                FuncionGlobal.comboregion(this.dl_region, mpersona.Comuna.Ciudad.Region.Pais.Codigo);
                this.dl_region.SelectedValue = Convert.ToString(mpersona.Comuna.Ciudad.Region.Id_region);

                FuncionGlobal.combociudad(this.dl_ciudad, Convert.ToInt16(mpersona.Comuna.Ciudad.Region.Id_region));
                this.dl_ciudad.SelectedValue = Convert.ToString(mpersona.Comuna.Ciudad.Id_Ciudad);
                FuncionGlobal.combocomuna(this.dl_comuna, Convert.ToInt16(mpersona.Comuna.Ciudad.Id_Ciudad));
                this.dl_comuna.SelectedValue = Convert.ToString(mpersona.Comuna.Id_Comuna);
                this.ib_comuna.Attributes.Add("OnClick", "javascript:window.showModalDialog('../administracion/mComunamodal.aspx?id_ciudad=" + FuncionGlobal.FuctionEncriptar(this.dl_ciudad.SelectedValue.Trim()) + "','#1','dialogHeight: 400px; dialogWidth: 350px;dialogTop: 190px; dialogLeft: 220px; edge: Raised; center: Yes;help: No; resizable: No; status: No;');");
                ib_comuna.Visible = true;

            }
            else
            {
                this.txt_dv.Enabled = true;
                this.txt_dv.Focus();

                return;

            }

        }




        private void add_persona()
        {
            string persona = new PersonaBC().add_persona(Convert.ToDouble(this.txt_rut.Text),
                                                            this.txt_dv.Text,
                                                            Convert.ToInt16(this.dl_comuna.SelectedValue),
                                                               this.txt_serie.Text,
                                                               this.txt_nombre.Text,
                                                               this.txt_paterno.Text,
                                                               this.txt_materno.Text,
                                                               this.dl_sexo.SelectedValue,
                                                               this.dl_tipo_persona.SelectedValue,
                                                               this.txt_nacionalidad.Text,
                                                               this.txt_profesion.Text,
                                                               this.dl_estado_civil.SelectedValue,
                                                               this.txt_telefono.Text,
                                                               this.txt_celular.Text,
                                                               this.txt_correo.Text,
                                                               this.txt_direccion.Text,
                                                               this.txt_numero.Text,
                                                               this.txt_depto.Text,
                                                               this.dl_tipo_empleador.SelectedValue,
                                                               "0");


        }

        private void limpiar()
        {
            this.txt_rut.Enabled = true;
            this.txt_dv.Enabled = true;

            this.txt_nombre.Text = "";
            this.txt_paterno.Text = "";
            this.txt_materno.Text = "";
            this.txt_dv.Text = "";
            this.txt_serie.Text = "";
            this.txt_nacionalidad.Text = "";
            this.txt_profesion.Text = "";
            this.txt_telefono.Text = "";
            this.txt_celular.Text = "";
            this.txt_correo.Text = "";
            this.txt_direccion.Text = "";
            this.txt_numero.Text = "";
            this.txt_depto.Text = "";

            this.txt_rut_rep1.Text = "";
            this.txt_rut_rep2.Text = "";
            this.txt_dv_rep1.Text = "";
            this.txt_dv_rep2.Text = "";
            this.txt_nombre_rep1.Text = "";
            this.txt_nombre_rep2.Text = "";
            this.txt_fecha.Text = "";
            this.txt_notaria.Text = "";
            this.txt_ciudad.Text = "";



        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (valida_ingreso())
            {
                add_persona();
                Response.Write("<script>window.close();</script>");
                FuncionGlobal.alerta("PERSONA INGRESADA CON EXITO", this.Page);
                this.ib_personeria.Visible = true;
                this.ib_ficha.Visible = true;
                //carga_rpt();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);

     }

        private void getrepresentante(double rut)
        {

         }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {

        }


        protected void txt_serie_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txt_rut_Leave(object sender, EventArgs e)
        {

            this.txt_dv.Text = FuncionGlobal.digitoVerificador(this.txt_rut.Text);

            busca_persona(Convert.ToDouble(this.txt_rut.Text));

            this.txt_serie.Focus();

        }

        protected void ib_comuna_Click(object sender, ImageClickEventArgs e)
        {
            FuncionGlobal.combocomuna(this.dl_comuna, Convert.ToInt16(this.dl_ciudad.SelectedValue));
        }

        protected void dl_ciudad_SelectedIndexChanged(object sender, EventArgs e)
        {
            FuncionGlobal.combocomuna(this.dl_comuna, Convert.ToInt16(this.dl_ciudad.SelectedValue));
            this.ib_comuna.Attributes.Add("OnClick", "javascript:window.showModalDialog('../administracion/mComunamodal.aspx?id_ciudad=" + FuncionGlobal.FuctionEncriptar(this.dl_ciudad.SelectedValue.Trim()) + "','#1','dialogHeight: 400px; dialogWidth: 350px;dialogTop: 190px; dialogLeft: 220px; edge: Raised; center: Yes;help: No; resizable: No; status: No;');");
            ib_comuna.Visible = true;
        }

        protected void dl_pais_SelectedIndexChanged(object sender, EventArgs e)
        {
            FuncionGlobal.comboregion(this.dl_region, this.dl_pais.SelectedValue);
        }

        protected void dl_region_SelectedIndexChanged(object sender, EventArgs e)
        {
            FuncionGlobal.combociudad(this.dl_ciudad, Convert.ToInt16(this.dl_region.SelectedValue));
        }

        private Boolean valida_ingreso()
        {
            if (this.txt_rut.Text == "" | this.txt_nombre.Text == "" | this.txt_direccion.Text == ""
            | this.txt_nacionalidad.Text == "" | this.txt_profesion.Text == "" | this.txt_telefono.Text == ""
            | this.txt_direccion.Text == "" | this.txt_numero.Text == "" | this.txt_telefono.Text == ""
                | this.dl_comuna.SelectedValue == "0")
            {

                FuncionGlobal.alerta("INGRESE LOS DATOS CORRESPONDIENTES", Page);
                return false;
            }

            return true;

        }


		//private void carga_rpt()
		//{

		//    ReportDocument rpt = new ReportDocument();
		//    rpt.Load(Server.MapPath("../reportes/mpersona.rpt"));

		//    rpt.SetParameterValue(0, this.txt_rut.Text);
            
		//    Session.Add("documento", rpt);
		//    Session.Add("nombre_rpt", "mPersona.rpt");


		//}

        protected void ib_personeria_Click(object sender, ImageClickEventArgs e)
        {

        }


    }
}
