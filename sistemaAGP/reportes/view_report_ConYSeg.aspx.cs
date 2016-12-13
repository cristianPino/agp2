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
using System.IO;
using CNEGOCIO;
using CENTIDAD;
using System.Collections.Generic;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Web;


namespace sistemaAGP.reportes
{
	public partial class view_report_ConYSeg : System.Web.UI.Page
	{
		private ReportDocument documento;// = new ReportDocument();
		//private string nombre_rpt;
		//private string impresion;

		protected override void OnUnload(EventArgs e)
		{
			base.OnUnload(e);
			this.documento.Dispose();
			this.documento.Close();
		}

		public void Page_Load(object sender, EventArgs e)
		{
			//if (Session["impresion"] == null)
			//    impresion = "N";
			//else
			//    impresion = Session["impresion"].ToString();
			//nombre_rpt = Session["nombre_rpt"].ToString();
			//documento = (ReportDocument)Session["documento"];
			//LoadReport(documento, nombre_rpt, impresion);
			//documento.Dispose();
			//documento.Close();
			LoadReporte();
		}

		public void LoadReport(ReportDocument crReportDocument, string nombre_reporte, string impresion)
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
			crReportDocument.Dispose();
			crReportDocument.Close();
			//this.CrystalReportViewer1.ReportSource = crReportDocument;
		}

		public void LoadReporte()
		{
			string server = System.Configuration.ConfigurationManager.AppSettings["servidor_crystal"];
			string base_crystal = System.Configuration.ConfigurationManager.AppSettings["base_crystal"];
			string usuario_crystal = System.Configuration.ConfigurationManager.AppSettings["usuario_crystal"];
			string pasword_crystal = System.Configuration.ConfigurationManager.AppSettings["pasword_crystal"];

			this.documento = new ReportDocument();
			
			this.documento.Load(Server.MapPath(Request.QueryString["nombre_rpt"]));

			this.documento.DataSourceConnections[0].SetConnection(server, base_crystal, false);
			this.documento.DataSourceConnections[0].SetLogon(usuario_crystal, pasword_crystal);

			//this.documento.Load(Server.MapPath(Request.QueryString["nombre_rpt"]));

			this.documento.SetParameterValue(0, Request.QueryString["tipo_operacion"]);
			this.documento.SetParameterValue(1, Convert.ToInt32(Request.QueryString["id_cliente"]));
			this.documento.SetParameterValue(2, Convert.ToInt32(Request.QueryString["id_solicitud"]));
			this.documento.SetParameterValue(3, Convert.ToInt32(Request.QueryString["rut_adquiriente"]));
			this.documento.SetParameterValue(4, Request.QueryString["numero_cliente"]);
			this.documento.SetParameterValue(5, Request.QueryString["patente"]);
			this.documento.SetParameterValue(6, Request.QueryString["desde"]);
			this.documento.SetParameterValue(7, Request.QueryString["hasta"]);



			this.CrystalReportViewer1.ReportSource = this.documento;
			//switch (Request.QueryString["formato"])
			//{
			//    case "html":
			//        this.CrystalReportViewer1.ReportSource = this.documento;
			//        break;
			//    case "pdf":
			//        this.documento.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "");
			//        break;
			//    case "xls":
			//        this.documento.ExportToHttpResponse(ExportFormatType.Excel, Response, false, "");
			//        break;
			//}
		}
	}
}