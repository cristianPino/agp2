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
    public partial class mComunamodal : System.Web.UI.Page
    {
        private string id_ciudad;


        protected void Page_Load(object sender, EventArgs e)
        {


            id_ciudad = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_ciudad"].ToString());

            
            if (!IsPostBack)
            {
                
                grillacomuna();
            }

        }

        

        

        protected void grillacomuna()
        {

            List<Comuna> lComuna = new ComunaBC().getComunabyciudad(Convert.ToInt16( id_ciudad));

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

            string add = new ComunaBC().add_comuna(Convert.ToInt16(id_ciudad),this.txt_comuna.Text);

            FuncionGlobal.alerta("COMUNA INGRESADA CON EXITO", this.Page);
            Response.Write("<script>window.close();</script>");
            limpiar();
            grillacomuna();
            return;

        }



        private void limpiar()
        {

            this.txt_comuna.Text = "";

        }

        private Boolean valida_ingreso()
        {

            if (this.txt_comuna.Text == "")
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
