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
    public partial class mRegion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                FuncionGlobal.combopais(this.dl_pais);
            }
         

        }

        public void Button1_Click(object sender, EventArgs e)
        {

            if (valida_ingreso())
            {
                add_region();
            }


        }

        protected void dl_pais_SelectedIndexChanged(object sender, EventArgs e)
        {
           grillaregion();
        }

        protected void grillaregion()
        {

            List<Region> lRegion = new RegionBC().getregionbypais(this.dl_pais.SelectedValue);

            this.gr_dato.DataSource = lRegion;
            this.gr_dato.DataBind();
        }
        
        
        private void add_region()
        {

            string add = new RegionBC().add_region(this.dl_pais.SelectedValue, this.txt_nombre.Text);
            
            FuncionGlobal.alerta("REGION INGRESADA CON EXITO", this.Page);
            
            limpiar();
            grillaregion();
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
            limpiar();
        }

       


    }
}
