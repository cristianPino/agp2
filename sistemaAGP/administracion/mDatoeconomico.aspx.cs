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
    public partial class mDatoeconomico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<DatoEconomico> lDatoeconomico = new DatoeconomicoBC().GetDatoeconomico();

            this.gr_dato.DataSource = lDatoeconomico;
            this.gr_dato.DataBind();

        }



        public void Button1_Click(object sender, EventArgs e)
        {

            if (valida_ingreso())
            {

                add_dato();

                List<DatoEconomico> lDatoeconomico = new DatoeconomicoBC().GetDatoeconomico();

                this.gr_dato.DataSource = lDatoeconomico;
                this.gr_dato.DataBind();

                limpiar();


            }

        }

        private void add_dato()
        {

            string add = new DatoeconomicoBC().add_Datoeconomico(this.txt_codigo.Text, Convert.ToDouble(this.txt_valor.Text));

            FuncionGlobal.alerta("DATO ECONOMICO INGRESADO CON EXITO", this.Page);
            limpiar();
            return;

        }


        private void limpiar()
        {
            this.txt_codigo.Text = "";
            this.txt_valor.Text = "";
            this.txt_codigo.Enabled = true;
        }

        private Boolean valida_ingreso()
        {

            if (this.txt_codigo.Text == "" | this.txt_valor.Text == "")
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
            this.txt_codigo.Text = ((GridView)sender).SelectedRow.Cells[1].Text;
            this.txt_valor.Text = ((GridView)sender).SelectedRow.Cells[2].Text;
            this.txt_codigo.Enabled = false;
        }


    }
}
