using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CENTIDAD;
using CNEGOCIO;

namespace sistemaAGP.controles
{
    public partial class wucServiciosAgp : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack)return;
            LoadGrProducto();
            LoadGrDocumnetos();
        }

        public void LoadGrProducto()
        {
            var dt = new DataTable();
            dt.Columns.Add(new DataColumn("idProd"));
            dt.Columns.Add(new DataColumn("productos"));

            //var loadProc = new CheckActividadOrdenTrabajoBC().get_productos_primera_ot();

            //foreach (var prod in loadProc)
            //{
            //    var dr = dt.NewRow();
            //    dr["idProd"] = prod.Codigo;
            //    dr["productos"] = prod.Operacion;
            //    dt.Rows.Add(dr);
            //}
            GrProducto.DataSource = dt;
            GrProducto.DataBind();
        }

        public void LoadGrDocumnetos()
        {
            var dt = new DataTable();
            dt.Columns.Add(new DataColumn("idProd"));
            dt.Columns.Add(new DataColumn("documentos"));

          //  var loadDoc = new CheckActividadOrdenTrabajoBC().get_documentos_ot();

            //foreach (var doc in loadDoc)
            //{
            //    var dr = dt.NewRow();
            //    dr["idProd"] = doc.IdDocumento;
            //    dr["documentos"] = doc.Nombre;
            //    dt.Rows.Add(dr);
            //}
            GrDocumentos.DataSource = dt;
            GrDocumentos.DataBind();
        }


        protected void upGrillaHipoteca_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(udp, GetType(), "cabeceragrid", "grilla_cabecera();", true);
        }

        public void AddServicios(int idOt)
        {

            GridViewRow row;

            for (int i = 0; i < GrProducto.Rows.Count; i++)
            {

                row = GrProducto.Rows[i];
                CheckBox chk = (CheckBox)GrProducto.Rows[i].FindControl("CheckProd");

                string idProd = GrProducto.Rows[i].Cells[0].Text;

                if (chk.Checked)
                {
                  new OrdenTrabajoBC().AddServicio(idOt,idProd);  

                }
                

            }
        }

        public void AddDocumentos(int idOt)
        {
            GridViewRow row;

            for (int i = 0; i < GrDocumentos.Rows.Count; i++)
            {

                row = GrDocumentos.Rows[i];
                CheckBox chk = (CheckBox)GrDocumentos.Rows[i].FindControl("CheckDoc");

                var idDoc = Convert.ToInt32(GrDocumentos.Rows[i].Cells[0].Text);

                if (chk.Checked)
                {
                 new OrdenTrabajoBC().AddDocumento(idOt,idDoc); 

                }


            }
        }

    }
}