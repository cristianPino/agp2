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


namespace sistemaAGP.reportes {
	public partial class view_cheques_rendicion : System.Web.UI.Page
    {

        private string cuenta_usuario;
		private string desde;
		private string hasta;
		private string tip_mov;
		private string estado;
        private DateTime fecha;
		private ReportDocument documento = new ReportDocument();


		protected override void OnUnload(EventArgs e)
		{
			base.OnUnload(e);
			this.documento.Dispose();
			this.documento.Close();
		}

		public void Page_Load(object sender, EventArgs e) {
			desde = Request.QueryString["desde"].ToString();
			hasta = Request.QueryString["hasta"].ToString();
			tip_mov = Request.QueryString["tip_mov"].ToString();
			estado = Request.QueryString["estado"].ToString();
			//ReportDocument rpt = new ReportDocument();
			//rpt.Load(Server.MapPath("InfComprobanteGasto.rpt"));
			//rpt.SetParameterValue(0, id_solicitud);
			//rpt.OpenSubreport("DATOVEHICULO");
			//rpt.SetParameterValue(1, id_solicitud);
			//rpt.OpenSubreport("DETALLE_GASTOS");
			//rpt.SetParameterValue(2, id_solicitud);
			//LoadReport(rpt, "InfComprobanteGasto.rpt", "N");
			//rpt.Dispose();
			//rpt.Close();
			LoadReporte();
		}

		public void LoadReport(ReportDocument crReportDocument, string nombre_reporte, string impresion) {
			string server = System.Configuration.ConfigurationManager.AppSettings["servidor_crystal"];
			string base_crystal = System.Configuration.ConfigurationManager.AppSettings["base_crystal"];
			string usuario_crystal = System.Configuration.ConfigurationManager.AppSettings["usuario_crystal"];
			string pasword_crystal = System.Configuration.ConfigurationManager.AppSettings["pasword_crystal"];
			crReportDocument.DataSourceConnections[0].SetConnection(server, base_crystal, false);
			crReportDocument.DataSourceConnections[0].SetLogon(usuario_crystal, pasword_crystal);
			if (impresion == "S") {
				crReportDocument.Load(HttpContext.Current.Server.MapPath(nombre_reporte));
				crReportDocument.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "");
			} else {
				crReportDocument.Load(HttpContext.Current.Server.MapPath(nombre_reporte));
				crReportDocument.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "");
			}
			Session["impresion"] = "";
			crReportDocument.Dispose();
			crReportDocument.Close();
		}

		protected void Button1_Click(object sender, EventArgs e) { }

		public void LoadReporte()
		{
			string server = System.Configuration.ConfigurationManager.AppSettings["servidor_crystal"];
			string base_crystal = System.Configuration.ConfigurationManager.AppSettings["base_crystal"];
			string usuario_crystal = System.Configuration.ConfigurationManager.AppSettings["usuario_crystal"];
			string pasword_crystal = System.Configuration.ConfigurationManager.AppSettings["pasword_crystal"];

			//this.documento = new ReportDocument();

			this.documento.Load(Server.MapPath("infChequeBanco.rpt"));

			this.documento.DataSourceConnections[0].SetConnection(server, base_crystal, false);
			this.documento.DataSourceConnections[0].SetLogon(usuario_crystal, pasword_crystal);

			this.documento.SetParameterValue(0,  Convert.ToDateTime(this.desde).ToString("yyyyMMdd")   );
            this.documento.SetParameterValue(1,  Convert.ToDateTime(this.hasta).ToString("yyyyMMdd")) ;
			this.documento.SetParameterValue(2, this.tip_mov);
			this.documento.SetParameterValue(3, this.estado);
		
			this.CrystalReportViewer1.ReportSource = this.documento;
		}
	}
}