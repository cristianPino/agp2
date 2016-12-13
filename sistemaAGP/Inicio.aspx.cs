using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using CENTIDAD;
using CNEGOCIO;
using System.Data;

namespace sistemaAGP
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            Resumen("",divResumenesOperacion);

        }

        public void Resumen(string grupo, HtmlGenericControl div)
        {
            DataTable dt = new IncidenciaBC().GetResumen(Convert.ToString(Session["usrname"]));
            div.Visible = dt.Rows.Count > 0;
            foreach (DataRow dr in dt.Rows)
            {
                UserControl uc = (UserControl)Page.LoadControl(dr["url_resumen_incidencia"].ToString());
                div.Controls.Add(uc);
            }
        }
    }
}