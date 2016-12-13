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
	public partial class view_nomina : System.Web.UI.Page
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



		public void LoadReporte()
		{
			string server = System.Configuration.ConfigurationManager.AppSettings["servidor_crystal"];
			string base_crystal = System.Configuration.ConfigurationManager.AppSettings["base_crystal"];
			string usuario_crystal = System.Configuration.ConfigurationManager.AppSettings["usuario_crystal"];
			string pasword_crystal = System.Configuration.ConfigurationManager.AppSettings["pasword_crystal"];

			this.documento = new ReportDocument();
            int id_nomina = Convert.ToInt32(Request.QueryString["id_nomina"]);

			//if (id_nomina == 1 || id_nomina == 2 || id_nomina == 3)
			//{
			//    this.documento.Load(Server.MapPath("../reportes/infOperacionesbynomina_PI.rpt"));
			//}
			//else
			//{
			//    switch(id_nomina)
			//    {
			//        case 4:
			//            this.documento.Load(Server.MapPath("../reportes/InfSolicitud_repertorio.rpt")); 
			//            break;
			//        case 5:
			//            this.documento.Load(Server.MapPath("../reportes/infNominaFacturacion.rpt"));
			//            break;
			//        case 6:
			//            this.documento.Load(Server.MapPath("../reportes/infDespachoPrendasCons.rpt"));
			//            break;
			//        case 7:
			//            this.documento.Load(Server.MapPath("../reportes/infNominaCheque.rpt"));
			//            break;
			//        case 8:
			//            this.documento.Load(Server.MapPath("../reportes/infNominaIngresoRNP.rpt"));
			//            break;
			//        case 10:
			//            this.documento.Load(Server.MapPath("../reportes/infDespachoEscriFirRepre.rpt"));
			//            break;
			//        case 11:
			//            this.documento.Load(Server.MapPath("../reportes/infInforGestionIndPrenda.rpt"));
			//            break;
			//        case 13:
			//            this.documento.Load(Server.MapPath("../reportes/InfNomina_factura_peru.rpt"));
			//            break;
			//        case 12:
			//            this.documento.Load(Server.MapPath("../reportes/InfCuadro_Seguiminto_peru.rpt"));
			//            break;
			//        case 15:
			//            this.documento.Load(Server.MapPath("../reportes/InfScotiabank.rpt"));
			//            break;
			//        case 17:
			//            this.documento.Load(Server.MapPath("../reportes/InfForm28Scotiabank.rpt"));
			//            break;
			//    }
			//}

			TipoNomina nomina = new TipoNominaBC().getTiponominaBytipo(id_nomina);
			if (nomina != null)
			{
				if (nomina.Reporte != "")
				{
					this.documento.Load(Server.MapPath(string.Format("../reportes/{0}", nomina.Reporte)));

					this.documento.DataSourceConnections[0].SetConnection(server, base_crystal, false);
					this.documento.DataSourceConnections[0].SetLogon(usuario_crystal, pasword_crystal);

					this.documento.SetParameterValue("@id_familia", Convert.ToInt32(Request.QueryString["id_familia"]));
					this.documento.SetParameterValue("@folio", Convert.ToInt32(Request.QueryString["folio"]));
					this.documento.SetParameterValue("@id_nomina", Convert.ToInt32(Request.QueryString["id_nomina"]));

					this.CrystalReportViewer1.ReportSource = this.documento;
				}
			}
		}
	}
}