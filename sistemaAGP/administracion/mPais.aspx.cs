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
    public partial class mPais : System.Web.UI.Page 
     
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Pais> lPais= new PaisBC().getallpais("TODO");

            this.gr_dato.DataSource = lPais;
            this.gr_dato.DataBind(); 

        }

       

        public void Button1_Click(object sender, EventArgs e)
        {

            if (valida_ingreso())

            {

                add_pais();

                List<Pais> lPais = new PaisBC().getallpais("TODO");

                this.gr_dato.DataSource = lPais;
                this.gr_dato.DataBind();

                limpiar();


            }
            
        }

        private void add_pais()
        {



            string add = new PaisBC().add_pais(this.txt_codigo.Text, this.txt_nombre.Text);

            FuncionGlobal.alerta("PAIS INGRESADO CON EXITO",this.Page);
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
                
                if (this.txt_codigo.Text == "" | this.txt_nombre.Text == "" )
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
