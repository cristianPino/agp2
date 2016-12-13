using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CENTIDAD;
using CNEGOCIO;


namespace sistemaAGP.preinscripcion
{
    public partial class InfoAutoProcesos : System.Web.UI.Page
    {
        protected int IdSolicitud;
        protected void Page_Load(object sender, EventArgs e)
        {
            IdSolicitud = Convert.ToInt32(FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_solicitud"]));
            if(IsPostBack)return;
            GetProcesos();
        }

        public void GetProcesos()
        {
            var lista = new InfoAutoProcesoBC().Get_contenidoInformeDV(IdSolicitud);
            var dt = new DataTable();
            dt.Columns.Add(new DataColumn("descripcion"));
            dt.Columns.Add(new DataColumn("fechaInicio"));
            dt.Columns.Add(new DataColumn("fechaTermino"));
            dt.Columns.Add(new DataColumn("estado"));

            foreach (var a in lista)
            {   
                var dr = dt.NewRow();
                dr["descripcion"] = a.DescripcionPaso;
                dr["fechaInicio"] = a.FechaInicio.Contains("01/01/1900 0:00:00") ? "" : a.FechaInicio; 
                dr["fechaTermino"] = a.FechaTermino.Contains("01/01/1900 0:00:00")?"":a.FechaTermino;
                dr["estado"] = a.Estado?"OK":"PENDIENTE";
              
                dt.Rows.Add(dr);
            }

            gr_dato.DataSource = dt;
            gr_dato.DataBind();
        }

        protected void ib_buscar_Click(object sender, ImageClickEventArgs e)
        {
            GetProcesos();
        }
    }
}