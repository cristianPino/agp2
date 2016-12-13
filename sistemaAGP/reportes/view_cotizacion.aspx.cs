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
	public partial class view_cotizacion : System.Web.UI.Page
    {

        private string cuenta_usuario;
        private string Vendedor;
        private string Adquiriente;
		private string fechafac;
		//private string hasta;
		private string id_marca;
        private string prod;
        private string monto;
        private string Id_cliente;
        private string Tramitacion;
        private DateTime fecha;
		private ReportDocument documento = new ReportDocument();


		protected override void OnUnload(EventArgs e)
		{
			base.OnUnload(e);
			this.documento.Dispose();
			this.documento.Close();
		}

		public void Page_Load(object sender, EventArgs e) {
			fechafac = Request.QueryString["fecha"].ToString();
			//hasta = Request.QueryString["hasta"].ToString();
			id_marca = Request.QueryString["id_marca"].ToString();
			monto = Request.QueryString["monto"].ToString();
            cuenta_usuario = Request.QueryString["cuenta_usuario"].ToString();
            Vendedor = Request.QueryString["Vendedor"].ToString();
            Tramitacion = Request.QueryString["Fechatramite"].ToString();
            Id_cliente = Request.QueryString["id_cliente"].ToString();
            Adquiriente = Request.QueryString["Adquiriente"].ToString();
            prod = Request.QueryString["prod"].ToString();
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

			this.documento.Load(Server.MapPath("InfCotizacion.rpt"));

			this.documento.DataSourceConnections[0].SetConnection(server, base_crystal, false);
			this.documento.DataSourceConnections[0].SetLogon(usuario_crystal, pasword_crystal);

            this.documento.SetParameterValue(4, this.Vendedor);
            this.documento.SetParameterValue(7, this.Adquiriente);
            this.documento.SetParameterValue(8, this.prod);
			this.documento.SetParameterValue(1,  Convert.ToDateTime(this.fechafac).ToString("yyyyMMdd")   );
           // this.documento.SetParameterValue(1,  Convert.ToDateTime(this.hasta).ToString("yyyyMMdd")) ;
			this.documento.SetParameterValue(0, this.id_marca);
			this.documento.SetParameterValue(2, this.monto);
            this.documento.SetParameterValue(3, this.cuenta_usuario);
            this.documento.SetParameterValue(5, this.Tramitacion);
            this.documento.SetParameterValue(6, this.Id_cliente);
          //  this.documento.SetParameterValue(4, this.Vendedor);
			this.CrystalReportViewer1.ReportSource = this.documento;
		}
	}
}