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
	public partial class view_report_hipoteca : System.Web.UI.Page
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
			LoadReporte();
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

			this.documento.SetParameterValue("@tipo_operacion", Request.QueryString["tipo_operacion"]);
			this.documento.SetParameterValue("@id_modulo", Convert.ToInt32(Request.QueryString["id_modulo"]));
			this.documento.SetParameterValue("@id_sucursal", Convert.ToInt32(Request.QueryString["id_sucursal"]));
			this.documento.SetParameterValue("@id_cliente", Convert.ToInt32(Request.QueryString["id_cliente"]));
			this.documento.SetParameterValue("@id_solicitud", Convert.ToInt32(Request.QueryString["id_solicitud"]));
			this.documento.SetParameterValue("@rut_deudor", Convert.ToInt32(Request.QueryString["rut_deudor"]));
			this.documento.SetParameterValue("@numero_cliente", Request.QueryString["numero_cliente"]);
			this.documento.SetParameterValue("@rol", Request.QueryString["rol"]);
			this.documento.SetParameterValue("@desde", Request.QueryString["desde"]);
			this.documento.SetParameterValue("@hasta", Request.QueryString["hasta"]);
			this.documento.SetParameterValue("@ultimo_estado", Convert.ToInt32(Request.QueryString["ultimo_estado"]));
			this.documento.SetParameterValue("@id_familia", Convert.ToInt32(Request.QueryString["id_familia"]));
            this.documento.SetParameterValue("@semaforo", Convert.ToInt32(Request.QueryString["semaforo"]));

			this.CrystalReportViewer1.ReportSource = this.documento;
		}
	}
}