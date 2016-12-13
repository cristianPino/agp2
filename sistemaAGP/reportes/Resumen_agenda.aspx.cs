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
    public partial class Resumen_agenda : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

      

            if (!IsPostBack)
            {
                //FuncionGlobal.combousuariosbyPerfil(this.dl_tecnico, "ADM");
                FuncionGlobal.combohoras(this.dl_hora);
                this.txt_desde.Text = DateTime.Today.ToShortDateString();
                this.txt_hasta.Text = DateTime.Today.ToShortDateString();

            }

        }

        protected void dl_tecnico_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void dl_hora_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void txt_desde_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txt_hasta_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ib_desde_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void ib_hasta_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void ib_resumen_Click(object sender, ImageClickEventArgs e)
        {

            //ReportDocument rpt = new ReportDocument();

            //rpt.Load(Server.MapPath("INF_AGENDA.rpt"));


            //rpt.SetParameterValue(0, this.txt_desde.Text);
            //rpt.SetParameterValue(1, this.txt_hasta.Text);
            //rpt.SetParameterValue(2, this.dl_tecnico.SelectedValue);
            //rpt.SetParameterValue(3, this.dl_hora.SelectedValue);
         

            //Session.Add("documento", rpt);
            //Session.Add("nombre_rpt", "INF_AGENDA.rpt");
            this.ib_resumen.Attributes.Add("onclick", "javascript:window.open('../reportes/view_report_agenda.aspx?DESDE=" + this.txt_desde.Text + "&HASTA=" + this.txt_hasta.Text + "&TECNICO=" + this.dl_tecnico.SelectedValue+ "&HORA=" + dl_hora.SelectedValue+ "','_blank','height=355,width=500, top=150,left=150,status=no,toolbar=no,menubar=no,l ocation=no,scrollbars=yes,resizable=yes,copyhistory= false')");

            //string cadena = "";
            //cadena += "?nombre_rpt=" + "INF_AGENDA.rpt";
            //cadena += "&DESDE=" + this.txt_desde.Text;
            //cadena += "&HASTA=" + this.txt_hasta.Text;
            //cadena += "&TECNICO=" + this.dl_tecnico.SelectedValue;
            //cadena += "&HORA=" + this.dl_hora.SelectedValue;

            //Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "MyScript", "<script type=\"text/javascript\">window.open('view_report_agenda.aspx" + cadena + "'); </script>");

        }


    }
}

