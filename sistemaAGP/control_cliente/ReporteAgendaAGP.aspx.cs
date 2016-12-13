using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sistemaAGP.control_cliente
{
    public partial class ReporteAgendaAGP : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void img_buscar_Click(object sender, ImageClickEventArgs e)
        {
			UpdatePanel up = (UpdatePanel)this.Master.FindControl("UpdatePanel1");
			if (this.txt_desde.Text == "") { txt_desde.Text = DateTime.Today.ToString(); }
			if (this.txt_hasta.Text == "") { txt_hasta.Text = DateTime.Today.ToString(); }


            string cadena = "";
            cadena += "?nombre_rpt=Agenda_AGP.rpt";
			cadena += "&desde=" + Convert.ToDateTime(this.txt_desde.Text).ToString("yyyyMMdd");
			cadena += "&hasta=" + Convert.ToDateTime(this.txt_hasta.Text).ToString("yyyyMMdd");
            cadena += "&tip=2";



			ScriptManager.RegisterStartupScript(this, this.GetType(), "MyScript", "window.open('../reportes/view_agenda.aspx" + cadena + "');", true);
        }
    }
}