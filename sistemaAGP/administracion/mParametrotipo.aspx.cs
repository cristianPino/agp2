﻿using System;
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
using CENTIDAD;
using CNEGOCIO;
using System.Collections.Generic;


namespace sistemaAGP
{
    public partial class mParametrotipo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
         
            List<Parametrotipo> lParametrotipo = new ParametrotipoBC().getallparametrotipo("TODO");

            this.gr_dato.DataSource = lParametrotipo;
            this.gr_dato.DataBind();

        }



        public void Button1_Click(object sender, EventArgs e)
        {

            if (valida_ingreso())
            {

                add_parametrotipo();

                List<Parametrotipo> lParametrotipo = new ParametrotipoBC().getallparametrotipo("TODO");

                this.gr_dato.DataSource = lParametrotipo;
                this.gr_dato.DataBind();

                limpiar();


            }

        }

        private void add_parametrotipo()
        {



            string add = new ParametrotipoBC().add_parametrotipo(this.txt_codigo.Text, this.txt_nombre.Text);

            FuncionGlobal.alerta("TIPO DE PARAMETRO INGRESADO CON EXITO", this.Page);
            limpiar();
            return;

        }


        private void limpiar()
        {
            this.txt_codigo.Text = "";
            this.txt_nombre.Text = "";

        }

        private Boolean valida_ingreso()
        {

            if (this.txt_codigo.Text == "" | this.txt_nombre.Text == "")
            {

                FuncionGlobal.alerta("INGRESE LOS DATOS CORRESPONDIENTES", Page);
                return false;
            }
            return true;

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        protected void gr_dato_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


    }
}

