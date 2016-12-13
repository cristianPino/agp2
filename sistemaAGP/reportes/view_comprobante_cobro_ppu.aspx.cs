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
	public partial class view_comprobante_cobro_ppu : System.Web.UI.Page {

		private ReportDocument documento = new ReportDocument();

		protected override void OnUnload(EventArgs e)
		{
			base.OnUnload(e);
			this.documento.Dispose();
			this.documento.Close();
		}

		public void Page_Load(object sender, EventArgs e) {
			if (!IsPostBack)
			{
				ViewState["id_solicitud"] = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_solicitud"].ToString());
				ViewState["id_familia"] = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_familia"].ToString());
			}
			LoadReporte();
		}

		public void LoadReporte()
		{
			string server = System.Configuration.ConfigurationManager.AppSettings["servidor_crystal"];
			string base_crystal = System.Configuration.ConfigurationManager.AppSettings["base_crystal"];
			string usuario_crystal = System.Configuration.ConfigurationManager.AppSettings["usuario_crystal"];
			string pasword_crystal = System.Configuration.ConfigurationManager.AppSettings["pasword_crystal"];

            //string nombre = "InfComprobanteGastoPPU.rpt";

            TipoOperacion mtipo = new TipooperacionBC().getcomprobantebyoperacion(Convert.ToInt32(ViewState["id_solicitud"]));


            this.documento.Load(Server.MapPath(mtipo.Comprobante_rpt));

			this.documento.DataSourceConnections[0].SetConnection(server, base_crystal, false);
			this.documento.DataSourceConnections[0].SetLogon(usuario_crystal, pasword_crystal);

			this.documento.SetParameterValue(0, ViewState["id_solicitud"]);
			this.documento.OpenSubreport("DETALLE_GASTOS");
			this.documento.SetParameterValue(1, ViewState["id_solicitud"]);

			this.CrystalReportViewer1.ReportSource = this.documento;
		}
	}
}