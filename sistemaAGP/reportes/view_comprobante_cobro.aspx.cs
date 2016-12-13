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
	public partial class view_comprobante_cobro : System.Web.UI.Page {

		private string id_solicitud;
        private string id_familia;
		private ReportDocument documento = new ReportDocument();

		protected override void OnUnload(EventArgs e)
		{
			base.OnUnload(e);
			this.documento.Dispose();
			this.documento.Close();
		}

		public void Page_Load(object sender, EventArgs e) {
			id_solicitud = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_solicitud"].ToString());
            id_familia = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_familia"].ToString());
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

		public void LoadReporte()
		{
           

                string server = System.Configuration.ConfigurationManager.AppSettings["servidor_crystal"];
                string base_crystal = System.Configuration.ConfigurationManager.AppSettings["base_crystal"];
                string usuario_crystal = System.Configuration.ConfigurationManager.AppSettings["usuario_crystal"];
                string pasword_crystal = System.Configuration.ConfigurationManager.AppSettings["pasword_crystal"];

                string nombre = "InfComprobanteGasto.rpt";

                //ComprobanteCobroFamilia comprobante = new ComprobanteCobroFamiliaBC().getComprobante(Convert.ToInt32(this.id_familia));
                TipoOperacion comprobante = new TipooperacionBC().getcomprobantebyoperacion(Convert.ToInt32(id_solicitud));
                if (comprobante != null)
                    nombre = comprobante.Comprobante_rpt;

                //switch (this.id_familia)
                //{
                //    //case "1":
                //    //    nombre = "InfComprobanteGasto.rpt";
                //    //    break;
                //    case "2":
                //        nombre = "InfComprobanteGastoMulta.rpt";
                //        break;
                //    case "4":
                //        nombre = "InfComprobanteGasto.rpt";
                //        break;
                //    case "3":
                //        nombre = "InfComprobanteGastoTR.rpt";
                //        break;
                //    case "7":
                //        nombre = "InfComprobanteGastoINMA.rpt";
                //        break;
                //}

                this.documento.Load(Server.MapPath(nombre));

                this.documento.DataSourceConnections[0].SetConnection(server, base_crystal, false);
                this.documento.DataSourceConnections[0].SetLogon(usuario_crystal, pasword_crystal);

                this.documento.SetParameterValue(0, this.id_solicitud);

                if (id_familia.Trim() !="24")
                {
                this.documento.OpenSubreport("DATOVEHICULO");
                this.documento.SetParameterValue(1, this.id_solicitud);
                this.documento.OpenSubreport("DETALLE_GASTOS");
                this.documento.SetParameterValue(2, this.id_solicitud);
                }

                this.CrystalReportViewer1.HasToggleGroupTreeButton = false;
                this.CrystalReportViewer1.HasToggleParameterPanelButton = false;
                CrystalReportViewer1.HasCrystalLogo = false;
                CrystalReportViewer1.HasDrillUpButton = false;
                CrystalReportViewer1.HasExportButton = true;
                CrystalReportViewer1.HasGotoPageButton = false;
                CrystalReportViewer1.HasPageNavigationButtons = false;
                CrystalReportViewer1.HasRefreshButton = false;
                CrystalReportViewer1.HasSearchButton = false;
                CrystalReportViewer1.HasToggleGroupTreeButton = false;
                CrystalReportViewer1.HasZoomFactorList = false;
                CrystalReportViewer1.BestFitPage = false;
                this.CrystalReportViewer1.ReportSource = this.documento;
                //CrystalReportViewer1.DataBind();
          
		}
	}
}