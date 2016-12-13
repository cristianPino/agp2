using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sistemaAGP.control_cliente
{
    public partial class ReporteAgendaCrediautos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FuncionGlobal.combousuariobyperfil(this.cbo_EjeCom, "ECCA");
            FuncionGlobal.combousuariobyperfil(this.cbo_EjeOpe, "CGYS");

        }

        protected void img_buscar_Click(object sender, ImageClickEventArgs e)
        {
			string ope = "0";
			string rut_cli = "0";
			UpdatePanel up = (UpdatePanel)this.Master.FindControl("UpdatePanel1");

			if (this.txt_nroOpe.Text != "") { ope = this.txt_nroOpe.Text; }
			if (this.txt_rutCli.Text != "") { rut_cli = this.txt_rutCli.Text; }

			if (this.txt_desde.Text == "") { txt_desde.Text = DateTime.Today.ToString(); }
			if (this.txt_hasta.Text == "") { txt_hasta.Text = DateTime.Today.ToString(); }


            string cadena = "";
            cadena += "?nombre_rpt=Agenda_AGP_CA.rpt" ;
            cadena += "&interno=" + ope;
            cadena += "&ejecutivo_operacion=" + this.cbo_EjeOpe.SelectedValue;
            cadena += "&ejecutivo_comercial=" + this.cbo_EjeCom.SelectedValue;
            cadena += "&desde=" + Convert.ToDateTime(this.txt_desde.Text).ToString("yyyyMMdd");
			cadena += "&hasta=" + Convert.ToDateTime(this.txt_hasta.Text).ToString("yyyyMMdd");
            cadena += "&rut_cli=" + rut_cli;
            cadena += "&tip=1" ;


            ScriptManager.RegisterStartupScript(this, this.GetType(), "MyScript", "window.open('../reportes/view_agenda.aspx" + cadena + "');", true);
        }
    }
}