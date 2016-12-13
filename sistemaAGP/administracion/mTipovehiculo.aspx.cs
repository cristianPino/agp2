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
using CENTIDAD;
using CNEGOCIO;
using System.Collections.Generic;


namespace sistemaAGP
{
    public partial class mTipovehiculo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Tipovehiculo> lTipovehiculo = new TipovehiculoBC().getallTipovehiculo();

            this.gr_dato.DataSource = lTipovehiculo;
            this.gr_dato.DataBind();

        }



        public void Button1_Click(object sender, EventArgs e)
        {

            if (valida_ingreso())
            {

                add_Tipovehiculo();

                List<Tipovehiculo> lTipovehiculo = new TipovehiculoBC().getallTipovehiculo();

                this.gr_dato.DataSource = lTipovehiculo;
                this.gr_dato.DataBind();

                limpiar();


            }

        }

        private void add_Tipovehiculo()
        {



            string add = new TipovehiculoBC().add_Tipovehiculo(this.txt_codigo.Text, this.txt_nombre.Text);

            FuncionGlobal.alerta("TIPO DE VEHICULO INGRESADO CON EXITO", this.Page);
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


    }
}
