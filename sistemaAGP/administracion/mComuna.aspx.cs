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
    public partial class mComuna : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FuncionGlobal.combopais(this.dl_pais);
            }

        }

        protected void dl_pais_SelectedIndexChanged(object sender, EventArgs e)
        {
            FuncionGlobal.comboregion(this.dl_region, this.dl_pais.SelectedValue);
        }

        protected void dl_region_SelectedIndexChanged(object sender, EventArgs e)
        {
            FuncionGlobal.combociudad(this.dl_ciudad, Convert.ToInt16(this.dl_region.SelectedValue));
        }

        protected void grillacomuna()
        {

            List<Comuna> lComuna = new ComunaBC().getComunabyciudad(Convert.ToInt16(this.dl_ciudad.SelectedValue));

            this.gr_dato.DataSource = lComuna;
            this.gr_dato.DataBind();
        }



        public void Button1_Click(object sender, EventArgs e)
        {

            if (valida_ingreso())
            {
                add_comuna();
            }


        }

        private void add_comuna()
        {

            string add = new ComunaBC().add_comuna(Convert.ToInt16(this.dl_ciudad.SelectedValue), this.txt_nombre.Text);

            FuncionGlobal.alerta("COMUNA INGRESADA CON EXITO", this.Page);

            limpiar();
            grillacomuna();
            return;

        }



        private void limpiar()
        {

            this.txt_nombre.Text = "";

        }

        private Boolean valida_ingreso()
        {

            if (this.txt_nombre.Text == "")
            {

                FuncionGlobal.alerta("INGRESE LOS DATOS CORRESPONDIENTES", Page);
                return false;
            }
            return true;

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //limpiar();

            

        }

        protected void dl_ciudad_SelectedIndexChanged(object sender, EventArgs e)
        {
            grillacomuna();
        }



    }
}
