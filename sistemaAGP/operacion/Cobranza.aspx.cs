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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Web;


namespace sistemaAGP
{
    public partial class Cobranza : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { 
                FuncionGlobal.combofamilia_producto(this.dl_familia);
                crear_datatable();
                FuncionGlobal.combocliente(this.ddlCliente);
            }
        }

        protected void crear_datatable()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add(new DataColumn("n_factura"));;
            dt.Columns.Add(new DataColumn("cliente"));
            dt.Columns.Add(new DataColumn("fecha_factura"));
            dt.Columns.Add(new DataColumn("total_general"));
            dt.Columns.Add(new DataColumn("total_factura"));
            dt.Columns.Add(new DataColumn("saldo_pendiente"));
            dt.Columns.Add(new DataColumn("familia"));


            if (Session["dt"] == null)
                Session.Add("dt", dt);
            else
                Session["dt"] = dt;
        }

        protected void ib_buscar_Click(object sender, ImageClickEventArgs e)
        {
            busca_operacion();

        }

        //busca_operacion_facturacion
        private void busca_operacion()
        {
            if (this.dl_familia.SelectedValue == "0")
            {
                return;
            }
            if (this.ddlCliente.SelectedValue == "0")
            {
                return;
            }

            Int32 factura_agp = 0;
            Int32 id_familia = 0;


            if (this.txt_factura_agp.Text.Trim() != "") factura_agp = Convert.ToInt32(this.txt_factura_agp.Text);
            if (this.dl_familia.SelectedValue != "0") id_familia = Convert.ToInt32(this.dl_familia.SelectedValue);


            DataTable dt = new DataTable();

            dt.Columns.Add(new DataColumn("n_factura")); ;
            dt.Columns.Add(new DataColumn("cliente"));
            dt.Columns.Add(new DataColumn("fecha_factura"));
            dt.Columns.Add(new DataColumn("total_general"));
            dt.Columns.Add(new DataColumn("total_factura"));
            dt.Columns.Add(new DataColumn("saldo_pendiente"));
            dt.Columns.Add(new DataColumn("familia"));
            dt.Columns.Add(new DataColumn("url_rebajar"));


            List<Factura> lfactura = new FacturaBC().getcobranza(Convert.ToInt32(this.ddlCliente.SelectedValue), factura_agp);
            foreach (Factura mfactura in lfactura)
            {

                DataRow dr = dt.NewRow();

                dr["n_factura"] = mfactura.N_factura_agp;
                dr["cliente"] = new ClienteBC().getcliente(Convert.ToInt16(mfactura.Cliente.Id_cliente)).Persona.Nombre;
                dr["fecha_factura"] = mfactura.Fecha_factura_agp;
                dr["total_general"] = mfactura.Total_gasto;
                dr["total_factura"] = mfactura.Total_neto;
                dr["saldo_pendiente"] = mfactura.Saldo_pendiente;
                dr["familia"] = this.dl_familia.Text;
                dr["url_rebajar"] = "Cobranza.aspx?n_factura=" + FuncionGlobal.FuctionEncriptar(mfactura.N_factura_agp.ToString().Trim());
                dt.Rows.Add(dr);
              
            }
           
            this.gr_dato.DataSource = dt;
            this.gr_dato.DataBind();

        }
        protected void gr_dato_SelectedIndexChanged(object sender, EventArgs e) { }

        protected void txt_factura_agp_TextChanged(object sender, EventArgs e)
        { 
        }
        protected void ddlCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        protected void dl_familia_SelectedIndexChanged(object sender, EventArgs e)
        {   
        }
        protected void gr_dato_RowDataBound(object sender, GridViewRowEventArgs e)
        {
        }
    }
}