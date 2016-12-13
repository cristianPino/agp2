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


namespace sistemaAGP.reportes
{


    public partial class view_report_agenda : System.Web.UI.Page
    {

        //private ReportDocument documento;
        //private string id_solicitud;
        //private string patente;



        public void Page_Load(object sender, EventArgs e)
        {

          string  hora = Request.QueryString["HORA"].ToString();
          string desde = Convert.ToDateTime(Request.QueryString["DESDE"].ToString()).ToString("yyyyMMdd");
          string hasta = Convert.ToDateTime(Request.QueryString["HASTA"].ToString()).ToString("yyyyMMdd");
          string tecnico = Request.QueryString["TECNICO"].ToString();


            ReportDocument rpt = new ReportDocument();
            rpt.Load(Server.MapPath("INF_AGENDA.rpt"));

            rpt.SetParameterValue(0, desde);
            rpt.SetParameterValue(1, hasta);
            rpt.SetParameterValue(2, tecnico);
            rpt.SetParameterValue(3, hora);

            LoadReport(rpt, "INF_AGENDA.rpt", "N");



        }

        public void LoadReport(ReportDocument crReportDocument,
                                            string nombre_reporte,
                                            string impresion)
        {


            string server = System.Configuration.ConfigurationManager.AppSettings["servidor_crystal"];
            string base_crystal = System.Configuration.ConfigurationManager.AppSettings["base_crystal"];
            string usuario_crystal = System.Configuration.ConfigurationManager.AppSettings["usuario_crystal"];
            string pasword_crystal = System.Configuration.ConfigurationManager.AppSettings["pasword_crystal"];





            crReportDocument.DataSourceConnections[0].SetConnection(server, base_crystal, false);
            crReportDocument.DataSourceConnections[0].SetLogon(usuario_crystal, pasword_crystal);

            if (impresion == "S")
            {

                crReportDocument.Load(HttpContext.Current.Server.MapPath(nombre_reporte));
                crReportDocument.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "");

            }
            else
            {
                crReportDocument.Load(HttpContext.Current.Server.MapPath(nombre_reporte));
                crReportDocument.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "");
            }

            Session["impresion"] = "";

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}
