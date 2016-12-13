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

namespace sistemaAGP
{
    public partial class mInforme : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                List<Informe> lInforme = new InformeBC().getInforme();

                this.gr_dato.DataSource = lInforme;
                this.gr_dato.DataBind();
            }

        }
       

        protected void Button1_Click(object sender, EventArgs e)
        {

            if (valida_ingreso())
            {

                add_informe();

                List<Informe> lInforme = new InformeBC().getInforme();

                this.gr_dato.DataSource = lInforme;
                this.gr_dato.DataBind();

                limpiar();


            }
        }
        private void add_informe()
        {



            string add = new InformeBC().add_informe(this.txt_nombre.Text,this.txt_descripcion.Text);

            FuncionGlobal.alerta("INFORME INGRESADA CON EXITO", this.Page);
            limpiar();
            return;

        }


        private void limpiar()
        {
            this.txt_descripcion.Text = "";
            this.txt_nombre.Text = "";
           

        }

        private Boolean valida_ingreso()
        {

            if (this.txt_nombre.Text == "" | this.txt_descripcion.Text == "" )
            {

                FuncionGlobal.alerta("INGRESE LOS DATOS CORRESPONDIENTES", Page);
                return false;
            }
            return true;

        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }

        protected void gr_dato_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void txt_descripcion_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}
