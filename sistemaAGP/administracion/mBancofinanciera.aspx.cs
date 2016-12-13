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
    public partial class mBancofinanciera : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<BancoFinanciera> lBancofinanciera = new BancofinancieraBC().getallbancofinanciera("TODO",1);

            this.gr_dato.DataSource = lBancofinanciera;
            this.gr_dato.DataBind();

        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            int i;
            GridViewRow row;
            ImageButton but;
            for (i = 0; i < gr_dato.Rows.Count; i++)
            {
                row = gr_dato.Rows[i];
                if (row.RowType == DataControlRowType.DataRow)
                {
                    but = (ImageButton)row.FindControl("ib_cuenta");
                    but.Attributes.Add("onclick", "javascript:window.showModalDialog('mCuentabancomodal.aspx?codigo_banco=" + FuncionGlobal.FuctionEncriptar(row.Cells[0].Text) + "','_blank','DialogHeight:355px,DialogWidth:500px, top:150,left:150,status=no,toolbar=no,menubar=no,l ocation=no,scrollbars=no,resizable=no,copyhistory= false')");




                }
            }
        }

        public void Button1_Click(object sender, EventArgs e)
        {

            if (valida_ingreso())
            {

                add_bancofinanciera();

                List<BancoFinanciera> lBancofinanciera = new BancofinancieraBC().getallbancofinanciera("TODO",1);

                this.gr_dato.DataSource = lBancofinanciera;
                this.gr_dato.DataBind();

                limpiar();


            }

        }

        private void add_bancofinanciera()
        {



            string add = new BancofinancieraBC().add_bancofinanciera(this.txt_codigo.Text, this.txt_nombre.Text);

            FuncionGlobal.alerta("BANCO FINACIERO INGRESADO CON EXITO", this.Page);
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


