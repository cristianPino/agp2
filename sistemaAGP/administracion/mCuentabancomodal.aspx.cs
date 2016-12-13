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
    public partial class mCuentabancomodal : System.Web.UI.Page
    {
        private string codigo_banco;


        protected void Page_Load(object sender, EventArgs e)
        {
            

            codigo_banco = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["codigo_banco"].ToString());

            

            

            if (!IsPostBack)
            {

                grillacuentas();
            }

        }





        protected void grillacuentas()
        {

            List<CuentaBanco> lcuenta = new CuentabancoBC().getcuentabancobybanco(codigo_banco);

            this.gr_dato.DataSource = lcuenta;
            this.gr_dato.DataBind();
        }



        public void Button1_Click(object sender, EventArgs e)
        {

            if (valida_ingreso()) 
            {
                add_cuenta();
            }


        }

        private void add_cuenta()
        {

            string add = new CuentabancoBC().add_cuenta_banco(0, codigo_banco, this.txt_cuenta.Text.Trim());

            FuncionGlobal.alerta("CUENTA CORRIENTE INGRESADA CON EXITO", this.Page);
            limpiar();
            grillacuentas();
            return;

        }



        private void limpiar()
        {

            this.txt_cuenta.Text = "";

        }

        private Boolean valida_ingreso()
        {

            if (this.txt_cuenta.Text == "")
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
