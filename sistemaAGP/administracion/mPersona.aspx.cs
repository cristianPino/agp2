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
    public partial class mPersona : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {

                this.ib_ficha.Attributes.Add("onclick", "javascript:window.open('../reportes/view_report_agp.aspx','_blank','height=355,width=500, top=150,left=150,status=no,toolbar=no,menubar=no,l ocation=no,scrollbars=no,resizable=yes,copyhistory= false')");
                this.ib_ficha.Visible=false;
                this.ib_personeria.Visible = false;

                FuncionGlobal.comboparametro(this.dl_estado_civil, "ESCIVIL");
                FuncionGlobal.comboparametro(this.dl_sexo, "SEXO");

                this.txt_rut.Focus();

            }
            

        }

        private void busca_persona(double rut)
        {

            Persona mpersona = new PersonaBC().getpersonabyrut(rut);

            if  ( mpersona== null)
            {
                this.txt_dv.Focus();

                return;

            }

            this.ib_direccion.Visible = true;
            this.ib_personeria.Visible = true;
            
            this.ib_ficha.Visible = true;
            this.txt_rut.Enabled = false;
            this.txt_dv.Enabled = false;


            this.txt_nombre.Text = mpersona.Nombre;
            this.txt_paterno.Text = mpersona.Apellido_paterno;
            this.txt_materno.Text = mpersona.Apellido_materno;
            this.txt_dv.Text = mpersona.Dv;
            this.txt_nacionalidad.Text = mpersona.Nacionalidad;
            this.txt_profesion.Text = mpersona.Profesion;
            this.dl_sexo.SelectedValue = mpersona.Sexo;
            this.dl_estado_civil.SelectedValue = mpersona.Estado_civil;
            this.txt_giro.Text = mpersona.Giro;
            this.ib_personeria.Attributes.Add("onclick", "javascript:window.showModalDialog('mParticipante.aspx?rut=" + FuncionGlobal.FuctionEncriptar(this.txt_rut.Text) + "&nombre=" + this.txt_nombre.Text + " " + this.txt_paterno.Text + "','','status:false;dialogWidth:900px;dialogHeight:500px')");


        }


        private void add_persona()
        {
            string persona = new PersonaBC().add_persona(Convert.ToDouble(this.txt_rut.Text),
                                                            this.txt_dv.Text,
                                                            Convert.ToInt16(0),
                                                               "",
                                                               this.txt_nombre.Text,
                                                               this.txt_paterno.Text,
                                                               this.txt_materno.Text,
                                                               this.dl_sexo.SelectedValue,
                                                               "0",
                                                               this.txt_nacionalidad.Text,
                                                               this.txt_profesion.Text,
                                                               this.dl_estado_civil.SelectedValue,
                                                               "0",
                                                               "0",
                                                               "",
                                                               "",
                                                               "",
                                                               "",
                                                               "0",
                                                               this.txt_giro.Text);
                                  
        
        }

        private void limpiar()
        {
            this.txt_rut.Enabled = true;
            this.txt_dv.Enabled = true;

            this.txt_nombre.Text = "";
            this.txt_paterno.Text = "";
            this.txt_materno.Text = "";
            this.txt_dv.Text = "";
         
            this.txt_nacionalidad.Text = "";
            this.txt_profesion.Text = "";
           

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (valida_ingreso())
            {
                add_persona();
                FuncionGlobal.alerta("PERSONA INGRESADA CON EXITO", this.Page);
                this.ib_personeria.Visible = true;
                this.ib_ficha.Visible=true;
                //carga_rpt();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            this.ib_direccion.Visible = false;
            Page.Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);
            
            
        }


        protected void txt_rut_Leave(object sender, EventArgs e)
        {

            this.txt_dv.Text = FuncionGlobal.digitoVerificador(this.txt_rut.Text);

            busca_persona( Convert.ToDouble(this.txt_rut.Text));

           

        }

      
        private Boolean valida_ingreso()
        {

            

            if (this.txt_rut.Text == "" | this.txt_nombre.Text == "" 
            | this.txt_nacionalidad.Text == "" | this.txt_profesion.Text == "" )
            {

                FuncionGlobal.alerta("INGRESE LOS DATOS CORRESPONDIENTES", Page);
                return false;
            }

            return true;

        }

       
	
        protected void ib_ficha_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void txt_giro_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ib_direccion_Click(object sender, ImageClickEventArgs e)
        {
          
            this.lnk_popup.Attributes["href"] = "../administracion/mDireccion.aspx?rut=" + FuncionGlobal.FuctionEncriptar(this.txt_rut.Text.Trim());
            this.lnk_popup.Attributes["title"] = "Direcciones";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "showDirecciones", "jQuery(document).ready(function() {$(\"#" + this.lnk_popup.ClientID.Trim() + "\").trigger('click');});", true);
            
        }

        protected void txt_serie_TextChanged(object sender, EventArgs e)
        {

        }
    
    
    }
}
