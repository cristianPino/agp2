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
    public partial class mHomologacion : System.Web.UI.Page
    {
        string codigo_distribuidor;
        string nombre;


        protected void Page_Load(object sender, EventArgs e)
        {
            codigo_distribuidor = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["codigo_distribuidor"].ToString());
            nombre = Request.QueryString["nombre"].ToString();
           

            this.lbl_poliza.Text = nombre;

            if (!IsPostBack)
            {
                gethomologacionpoliza();
            }
        }

        protected void gethomologacionpoliza()
        {
            DataTable dt = new DataTable();


            dt.Columns.Add(new DataColumn("codigo"));
            dt.Columns.Add(new DataColumn("nombre"));
            dt.Columns.Add(new DataColumn("codigoTipVehDist"));
           
            List<HomologacionPoliza> lhomologacionpoliza= new HomologacionPolizaBC().gethomologacionpoliza(codigo_distribuidor);


            foreach (HomologacionPoliza mhomologacionpoliza in lhomologacionpoliza)
            {
                DataRow dr = dt.NewRow();

                dr["codigo"] = mhomologacionpoliza.Codigo;
                dr["nombre"] = mhomologacionpoliza.Tipovehiculo.Nombre;
                dr["codigoTipVehDist"] = mhomologacionpoliza.CodigoTipVehDist;
                

                dt.Rows.Add(dr);

            }

            this.gr_dato.DataSource = dt;
            this.gr_dato.DataBind();
        }



        private void add_homologacionpoliza()
        {

            GridViewRow row;
            string add;
            for (int i = 0; i < gr_dato.Rows.Count; i++)
            {
                row = gr_dato.Rows[i];
                TextBox txt = (TextBox)gr_dato.Rows[i].FindControl("txt_codigoTipVehDist");
                string codigo = this.gr_dato.Rows[i].Cells[0].Text;


                add = new HomologacionPolizaBC().add_homologacionpoliza(codigo_distribuidor, codigo,Convert.ToInt32(txt.Text.ToString()));



            }
        }
        protected void bt_cerrar_Click(object sender, EventArgs e)
        {

            Response.Write("<script>self.close();</script>");


        }
        protected void bt_guardar_Click(object sender, EventArgs e)
        {
            add_homologacionpoliza();
            FuncionGlobal.alerta("VALORES INGRESADO CON EXITO", Page);
            gethomologacionpoliza();
        }

        protected void gr_dato_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void txt_codigoTipVehDist_Leave(object sender, EventArgs e)
        {

        }
        protected void gr_dato_RowEditing(object sender, GridViewEditEventArgs e)
        {

            gr_dato.EditIndex = e.NewEditIndex;

        }

     
    }
}
