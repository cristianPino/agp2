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
    public partial class mDistribuidorpoliza : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<DistribuidorPoliza> lDistribuidorpoliza = new DistribuidorpolizaBC().getalldistribuidorpoliza("TODO");

                this.gr_dato.DataSource = lDistribuidorpoliza;
                this.gr_dato.DataBind();
                
            }
            Carga_Link();
        }



        public void Button1_Click(object sender, EventArgs e)
        {

            if (valida_ingreso())
            {

                add_distribuidorpoliza();

                List<DistribuidorPoliza> lDistribuidorpoliza = new DistribuidorpolizaBC().getalldistribuidorpoliza("TODO");

                this.gr_dato.DataSource = lDistribuidorpoliza;
                this.gr_dato.DataBind();

                limpiar();


            }

        }

        private void add_distribuidorpoliza()
        {



            string add = new DistribuidorpolizaBC().add_distribuidorpoliza(this.txt_codigo.Text, this.txt_nombre.Text);

            FuncionGlobal.alerta("DISTRIBUIDOR POLIZA INGRESADO CON EXITO", this.Page);
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

        protected void Carga_Link()
        {
            int i;
            GridViewRow row;
            ImageButton ibuton;
            string codigo_distribuidor;
            string nombredis;

            for (i = 0; i < gr_dato.Rows.Count; i++)
            {
                row = gr_dato.Rows[i];
                if (row.RowType == DataControlRowType.DataRow)
                {
                    
                    codigo_distribuidor = (string)row.Cells[0].Text;
                    nombredis = (string)row.Cells[1].Text;

                    ibuton = (ImageButton)row.FindControl("ib_valor");
                    ibuton.Attributes.Add("onclick", "javascript:window.showModalDialog('mValorSeguro.aspx?codigo_distribuidor=" + FuncionGlobal.FuctionEncriptar(codigo_distribuidor) + "&nombre=" + nombredis + "','','status:false;dialogWidth:500px;dialogHeight:260px')");

                    ibuton = (ImageButton)row.FindControl("ib_Homologacion");
                    ibuton.Attributes.Add("onclick", "javascript:window.showModalDialog('mHomologacion.aspx?codigo_distribuidor=" + FuncionGlobal.FuctionEncriptar(codigo_distribuidor) + "&nombre=" + nombredis + "','','status:false;dialogWidth:500px;dialogHeight:260px')");

                    }
            }
        }

    }
}

