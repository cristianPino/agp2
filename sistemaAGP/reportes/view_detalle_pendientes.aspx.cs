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
    public partial class view_detalle_pendientes : System.Web.UI.Page
    {

	
		private ReportDocument documento = new ReportDocument();
        private string cuenta_usuario;
        private string id_sucursal;
   
		protected override void OnUnload(EventArgs e)
		{
			base.OnUnload(e);
			this.documento.Dispose();
			this.documento.Close();
		}

		public void Page_Load(object sender, EventArgs e) {
			

            cuenta_usuario = Request.QueryString["cuenta_usuario"];
            id_sucursal = Request.QueryString["id_sucursal"];
           

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
            string nombre = "";
          
					nombre = "infPendiente.rpt";
               

			this.documento.Load(Server.MapPath(nombre));

			this.documento.DataSourceConnections[0].SetConnection(server, base_crystal, false);
			this.documento.DataSourceConnections[0].SetLogon(usuario_crystal, pasword_crystal);

            //this.documento.SetParameterValue(0, this.id_solicitud);
            //this.documento.OpenSubreport("DATOVEHICULO");
            //this.documento.SetParameterValue(1, this.id_solicitud);
            //this.documento.OpenSubreport("DETALLE_GASTOS");
            //this.documento.SetParameterValue(2, this.id_solicitud);

       

            this.documento.SetParameterValue("@tipo_operacion", "0");
            this.documento.SetParameterValue("@id_modulo", 0);
            this.documento.SetParameterValue("@id_sucursal", id_sucursal);
            this.documento.SetParameterValue("@id_cliente",0);
            this.documento.SetParameterValue("@id_solicitud", 0);
            this.documento.SetParameterValue("@rut_adquiriente", 0);
            this.documento.SetParameterValue("@numero_factura", 0);
            this.documento.SetParameterValue("@numero_cliente", "0");
            this.documento.SetParameterValue("@patente", "");
            this.documento.SetParameterValue("@desde", "20110101");
             this.documento.SetParameterValue("@hasta", string.Format("{0:yyyyMMdd}", DateTime.Now));
            this.documento.SetParameterValue("@ultimo_estado", 0);
            this.documento.SetParameterValue("@cuenta_usuario",cuenta_usuario);
            this.documento.SetParameterValue("@folio", 0);
            this.documento.SetParameterValue("@id_nomina", 0);
            this.documento.SetParameterValue("@id_ciudad", 0);
            this.documento.SetParameterValue("@id_familia", 0);

			this.CrystalReportViewer1.ReportSource = this.documento;
		}
	}
}