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
    public partial class analisis_vehiculos : System.Web.UI.Page
    {
        //private string patente;
        private string id_solicitud;

        protected void Page_Load(object sender, EventArgs e)
        {

            //patente = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["patente"].ToString());
            id_solicitud = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_solicitud"].ToString());

            if (!IsPostBack)
            {
                getvehiculos();

            }

        }

        public void getvehiculos()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("id_solicitud"));
            dt.Columns.Add(new DataColumn("patente"));
            dt.Columns.Add(new DataColumn("kilometraje"));
            dt.Columns.Add(new DataColumn("tasacion"));
            dt.Columns.Add(new DataColumn("precio"));

            List<DatosVehiculo> ldatos = new DatosvehiculoBC().getDatosvehiculo(Convert.ToInt32(id_solicitud));

            foreach (DatosVehiculo mdatos in ldatos)
            {
                DataRow dr = dt.NewRow();
                dr["id_solicitud"] = mdatos.Id_solicitud;
                dr["patente"] = mdatos.Patente;
                dr["kilometraje"] =FuncionGlobal.NumeroConFormato(mdatos.Kilometraje.ToString());
                dr["tasacion"] =FuncionGlobal.NumeroConFormato(mdatos.Tasacion.ToString());
                dr["precio"] =FuncionGlobal.NumeroConFormato(mdatos.Precio.ToString());
                dt.Rows.Add(dr);
            }

            this.gr_dato.DataSource = dt;
            this.gr_dato.DataBind();

            Carga_Link();
        }

        protected void Carga_Link()
        {
            int i;
            GridViewRow row;
            ImageButton ibuton;

            for (i = 0; i < gr_dato.Rows.Count; i++)
            {
                row = gr_dato.Rows[i];
                if (row.RowType == DataControlRowType.DataRow)
                {

                    string patente = (string)row.Cells[1].Text;
                    string id_solicitud = (string)row.Cells[0].Text;

                    ibuton = (ImageButton)row.FindControl("ib_analisis");
                    ibuton.Attributes.Add("onclick", "javascript:window.showModalDialog('analisis_patente.aspx?id_solicitud=" + FuncionGlobal.FuctionEncriptar(id_solicitud) + "&patente=" + FuncionGlobal.FuctionEncriptar(patente) + "','','status:false;dialogWidth:500px;dialogHeight:260px')");
                }
            }
        }
        protected void Click_analisis(Object sender, EventArgs e)
        {
          
        }
        protected void gr_dato_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }
    }
}
