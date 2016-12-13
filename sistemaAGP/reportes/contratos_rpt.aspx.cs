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
    public partial class contratos_rpt : System.Web.UI.Page
    {
     
        private string id_solicitud;

        protected void Page_Load(object sender, EventArgs e)
        {

           
            id_solicitud = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_solicitud"].ToString());

            if (!IsPostBack)
            {
                carga_contratos();
            }

        }

        public void carga_contratos()
        {
             List<Contratos> lInforme = new ContratosBC().getcontratosbycliente(Convert.ToInt32(id_solicitud));
             UpdatePanel up = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
             if (lInforme.Count == 0)
             {
                 FuncionGlobal.alerta_updatepanel("NO HAY CONTRATOS ASOCIADOS AL CLIENTE", Page, up);
             }
             else
             {

                 DataTable dt = new DataTable();
                 dt.Columns.Add(new DataColumn("id_contrato"));
                 dt.Columns.Add(new DataColumn("descripcion"));
                 dt.Columns.Add(new DataColumn("nombre"));

                 foreach (Contratos inf in lInforme)
                 {
                     DataRow dr = dt.NewRow();
                     dr["id_contrato"] = inf.Id_contrato;
                     dr["descripcion"] = inf.Descripcion;
                     dr["nombre"] = inf.Nombre;


                     dt.Rows.Add(dr);
                 }
                 this.gr_dato.DataSource = lInforme;
                 this.gr_dato.DataBind();
             }
        }
       
        protected void gr_dato_SelectedIndexChanged1(object sender, EventArgs e)
        {
            //string id;
            //string reporte;
            //int fila;
          
           
            //fila = ((GridView)sender).SelectedRow.RowIndex;
            //id = ((GridView)sender).DataKeys[fila].Values[0].ToString();
            //reporte = ((GridView)sender).DataKeys[fila].Values[1].ToString();

            //string cadena = "";
            //cadena += "?nombre_rpt=" + reporte;
            //cadena += "&id_solicitud="+id_solicitud;
            //cadena += "&id=" + id;

            //Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "MyScript", "<script type=\"text/javascript\">window.open('view_Contratos_agp.aspx" + cadena + "'); </script>");            

            //UpdatePanel up = (UpdatePanel)this.Master.FindControl("UpdatePanel1");

            //if (up != null)
            //    ScriptManager.RegisterClientScriptBlock(up, up.GetType(), "MyScript", "<script type=\"text/javascript\">window.open('view_Contratos_agp.aspx" + cadena + "'); </script>", false);
            //else
            //    ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "MyScript", "<script type=\"text/javascript\">window.open('view_Contratos_agp.aspx" + cadena + "'); </script>", false);

        }
        protected void gr_dato_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "View")
            {
                Int32 idx = Convert.ToInt32(e.CommandArgument);
                string url = gr_dato.DataKeys[idx].Values[1].ToString();
                string id = gr_dato.DataKeys[idx].Values[0].ToString();

                string cadena = "";
                cadena += "?nombre_rpt=" + url;
                cadena += "&id_solicitud="+id_solicitud;
                cadena += "&id=" + id;
                i_documento.Attributes["src"] = "view_Contratos_agp.aspx" + cadena;
                    
            }
        }
       
    }
}
