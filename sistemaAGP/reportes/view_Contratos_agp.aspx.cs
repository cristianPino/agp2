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
	public partial class view_Contratos_agp : System.Web.UI.Page
	{
		//private ReportDocument documento;// = new ReportDocument();
		private ReportDocument documento = new ReportDocument();
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

			//this.documento = new ReportDocument();

			this.documento.Load(HttpContext.Current.Server.MapPath(Request.QueryString["nombre_rpt"]));
			//this.documento.Load(Server.MapPath(Request.QueryString["nombre_rpt"]));

			this.documento.DataSourceConnections[0].SetConnection(server, base_crystal, false);
			this.documento.DataSourceConnections[0].SetLogon(usuario_crystal, pasword_crystal);


			//this.documento.Load(Server.MapPath(Request.QueryString["nombre_rpt"]));
            string id = "1";
			
			id = Request.QueryString["id"].ToString();
			if (id == "1" || id == "17" || id == "30" || id == "34")
            {            
				this.documento.SetParameterValue(0, Convert.ToInt32(Request.QueryString["id_solicitud"]));
				this.documento.OpenSubreport("comprador");
				this.documento.SetParameterValue(1, Convert.ToInt32(Request.QueryString["id_solicitud"]));
				this.documento.SetParameterValue(2, "comprador");
				this.documento.SetParameterValue(3, Convert.ToInt32(Request.QueryString["id"]));

				this.documento.OpenSubreport("Repre_comprador");
				this.documento.SetParameterValue(4, Convert.ToInt32(Request.QueryString["id_solicitud"]));
				this.documento.SetParameterValue(5, "comprador");
				this.documento.SetParameterValue(6, Convert.ToInt32(Request.QueryString["id"]));


				this.documento.OpenSubreport("Repre_vendedor");
				this.documento.SetParameterValue(7, Convert.ToInt32(Request.QueryString["id_solicitud"]));
				this.documento.SetParameterValue(8, "vendedor");
				this.documento.SetParameterValue(9, Convert.ToInt32(Request.QueryString["id"]));

				this.documento.OpenSubreport("vendedor");
				this.documento.SetParameterValue(10, Convert.ToInt32(Request.QueryString["id_solicitud"]));
				this.documento.SetParameterValue(11, "vendedor");
				this.documento.SetParameterValue(12, Convert.ToInt32(Request.QueryString["id"]));
            }
			else if (id == "14" || id =="5" )
			{
				this.documento.SetParameterValue(0, Convert.ToInt32(Request.QueryString["id_solicitud"]));
				this.documento.OpenSubreport("cheques");
				this.documento.SetParameterValue(1, Convert.ToInt32(Request.QueryString["id_solicitud"]));
				this.documento.OpenSubreport("comprador");
				this.documento.SetParameterValue(2, Convert.ToInt32(Request.QueryString["id_solicitud"]));
				this.documento.SetParameterValue(3, "comprador");
				this.documento.SetParameterValue(4, Convert.ToInt32(Request.QueryString["id"]));

				this.documento.OpenSubreport("Repre_comprador");
				this.documento.SetParameterValue(5, Convert.ToInt32(Request.QueryString["id_solicitud"]));
				this.documento.SetParameterValue(6, "comprador");
				this.documento.SetParameterValue(7, Convert.ToInt32(Request.QueryString["id"]));


				this.documento.OpenSubreport("Repre_vendedor");
				this.documento.SetParameterValue(8, Convert.ToInt32(Request.QueryString["id_solicitud"]));
				this.documento.SetParameterValue(9, "vendedor");
				this.documento.SetParameterValue(10, Convert.ToInt32(Request.QueryString["id"]));

				this.documento.OpenSubreport("vendedor");
				this.documento.SetParameterValue(11, Convert.ToInt32(Request.QueryString["id_solicitud"]));
				this.documento.SetParameterValue(12, "vendedor");
				this.documento.SetParameterValue(13, Convert.ToInt32(Request.QueryString["id"]));
			}
			// contratos y cesiones leasing
			else if (id == "10" || id == "11" || id == "12" || id == "13" || id == "15")
			{
				
				this.documento.SetParameterValue(0, Convert.ToInt32(Request.QueryString["id_solicitud"]));
				this.documento.OpenSubreport("comprador");
				this.documento.SetParameterValue(1, Convert.ToInt32(Request.QueryString["id_solicitud"]));
				this.documento.SetParameterValue(2, "comprador");
				this.documento.SetParameterValue(3, Convert.ToInt32(Request.QueryString["id"]));

				this.documento.OpenSubreport("Repre_comprador");
				this.documento.SetParameterValue(4, Convert.ToInt32(Request.QueryString["id_solicitud"]));
				this.documento.SetParameterValue(5, "comprador");
				this.documento.SetParameterValue(6, Convert.ToInt32(Request.QueryString["id"]));


				this.documento.OpenSubreport("Repre_vendedor");
				this.documento.SetParameterValue(7, Convert.ToInt32(Request.QueryString["id_solicitud"]));
				this.documento.SetParameterValue(8, "vendedor");
				this.documento.SetParameterValue(9, Convert.ToInt32(Request.QueryString["id"]));

				this.documento.OpenSubreport("vendedor");
				this.documento.SetParameterValue(10, Convert.ToInt32(Request.QueryString["id_solicitud"]));
				this.documento.SetParameterValue(11, "vendedor");
				this.documento.SetParameterValue(12, Convert.ToInt32(Request.QueryString["id"]));

			}
			else if (id == "4" || id == "19")
			{
				this.documento.SetParameterValue(0, Convert.ToInt32(Request.QueryString["id_solicitud"]));
				this.documento.OpenSubreport("comprador");
				this.documento.SetParameterValue(1, Convert.ToInt32(Request.QueryString["id_solicitud"]));
				this.documento.SetParameterValue(2, "comprador");
				this.documento.SetParameterValue(3, Convert.ToInt32(Request.QueryString["id"]));

				this.documento.OpenSubreport("Repre_comprador");
				this.documento.SetParameterValue(4, Convert.ToInt32(Request.QueryString["id_solicitud"]));
				this.documento.SetParameterValue(5, "comprador");
				this.documento.SetParameterValue(6, Convert.ToInt32(Request.QueryString["id"]));
			}
			else if (id == "9")
			{
				this.documento.SetParameterValue(0, Convert.ToInt32(Request.QueryString["id_solicitud"]));
				this.documento.OpenSubreport("detalle_gasto_TR");
				this.documento.SetParameterValue(1, Convert.ToInt32(Request.QueryString["id_solicitud"]));
			}
            else if(id=="27"||id=="28")
            {
                this.documento.SetParameterValue(0, Convert.ToInt32(Request.QueryString["id_solicitud"]));
                this.documento.OpenSubreport("vendedor");
                this.documento.SetParameterValue(1, Convert.ToInt32(Request.QueryString["id_solicitud"]));
                this.documento.SetParameterValue(2, "vendedor");
                this.documento.SetParameterValue(3, Convert.ToInt32(Request.QueryString["id"]));

				this.documento.OpenSubreport("comprador");
				this.documento.SetParameterValue(4, Convert.ToInt32(Request.QueryString["id_solicitud"]));
				this.documento.SetParameterValue(5, "comprador");
				this.documento.SetParameterValue(6, Convert.ToInt32(Request.QueryString["id"]));

                //this.documento.OpenSubreport("Repre_vendedor");
                //this.documento.SetParameterValue(7, Convert.ToInt32(Request.QueryString["id_solicitud"]));
                //this.documento.SetParameterValue(8, "vendedor");
                //this.documento.SetParameterValue(9, Convert.ToInt32(Request.QueryString["id"]));

                //this.documento.OpenSubreport("Repre_comprador");
                //this.documento.SetParameterValue(10, Convert.ToInt32(Request.QueryString["id_solicitud"]));
                //this.documento.SetParameterValue(11, "comprador");
                //this.documento.SetParameterValue(12, Convert.ToInt32(Request.QueryString["id"]));

            }
            else if (id == "26" )
            {
                this.documento.SetParameterValue(0, Convert.ToInt32(Request.QueryString["id_solicitud"]));
                this.documento.OpenSubreport("vendedor");
                this.documento.SetParameterValue(1, Convert.ToInt32(Request.QueryString["id_solicitud"]));
                this.documento.SetParameterValue(2, "vendedor");
                this.documento.SetParameterValue(3, Convert.ToInt32(Request.QueryString["id"]));

                this.documento.OpenSubreport("comprador");
                this.documento.SetParameterValue(4, Convert.ToInt32(Request.QueryString["id_solicitud"]));
                this.documento.SetParameterValue(5, "comprador");
                this.documento.SetParameterValue(6, Convert.ToInt32(Request.QueryString["id"]));

                this.documento.OpenSubreport("Repre_comprador");
                this.documento.SetParameterValue(7, Convert.ToInt32(Request.QueryString["id_solicitud"]));
                this.documento.SetParameterValue(8, "comprador");
                this.documento.SetParameterValue(9, Convert.ToInt32(Request.QueryString["id"]));

                //this.documento.OpenSubreport("Repre_comprador");
                //this.documento.SetParameterValue(10, Convert.ToInt32(Request.QueryString["id_solicitud"]));
                //this.documento.SetParameterValue(11, "comprador");
                //this.documento.SetParameterValue(12, Convert.ToInt32(Request.QueryString["id"]));

            }
            else if (id == "24")
            {
                this.documento.SetParameterValue(0, Convert.ToInt32(Request.QueryString["id_solicitud"]));
                this.documento.OpenSubreport("vendedor");
                this.documento.SetParameterValue(1, Convert.ToInt32(Request.QueryString["id_solicitud"]));
                this.documento.SetParameterValue(2, "vendedor");
                this.documento.SetParameterValue(3, Convert.ToInt32(Request.QueryString["id"]));

            }
            else if (id == "25")
            {
                this.documento.SetParameterValue(0, Convert.ToInt32(Request.QueryString["id_solicitud"]));
                this.documento.OpenSubreport("comprador");
                this.documento.SetParameterValue(1, Convert.ToInt32(Request.QueryString["id_solicitud"]));
                this.documento.SetParameterValue(2, "comprador");
                this.documento.SetParameterValue(3, Convert.ToInt32(Request.QueryString["id"]));
                this.documento.OpenSubreport("Cheques");
                this.documento.SetParameterValue(4, Convert.ToInt32(Request.QueryString["id_solicitud"]));

            }
            else if (id == "35")
            {
               
               this.documento.SetParameterValue(0, Convert.ToInt32(Request.QueryString["id_solicitud"]));
                this.documento.OpenSubreport("Personeria_comprador");
                this.documento.SetParameterValue(1, Convert.ToInt32(Request.QueryString["id_solicitud"]));
                this.documento.SetParameterValue(2, "comprador");
                this.documento.SetParameterValue(3, Convert.ToInt32(Request.QueryString["id"]));

                this.documento.OpenSubreport("comprador");
                this.documento.SetParameterValue(4, Convert.ToInt32(Request.QueryString["id_solicitud"]));
                this.documento.SetParameterValue(5, "comprador");
                this.documento.SetParameterValue(6, Convert.ToInt32(Request.QueryString["id"]));


                this.documento.OpenSubreport("vendedor");
                this.documento.SetParameterValue(7, Convert.ToInt32(Request.QueryString["id_solicitud"]));
                this.documento.SetParameterValue(8, "vendedor");
                this.documento.SetParameterValue(9, Convert.ToInt32(Request.QueryString["id"]));
                

            }
            else if (id == "37" )
            {
                this.documento.SetParameterValue(0, Convert.ToInt32(Request.QueryString["id_solicitud"]));
                this.documento.OpenSubreport("Comprador");
                this.documento.SetParameterValue(1, Convert.ToInt32(Request.QueryString["id_solicitud"]));
               
            }
            else if (id == "36")
            {
                this.documento.SetParameterValue(0, Convert.ToInt32(Request.QueryString["id_solicitud"]));
                this.documento.OpenSubreport("Comprador");
                this.documento.SetParameterValue(1, Convert.ToInt32(Request.QueryString["id_solicitud"]));
                this.documento.OpenSubreport("repre_comprador");
                this.documento.SetParameterValue(2, Convert.ToInt32(Request.QueryString["id_solicitud"]));

            }
            if (id == "38" )
            {
                this.documento.SetParameterValue(0, Convert.ToInt32(Request.QueryString["id_solicitud"]));
                this.documento.OpenSubreport("comprador");
                this.documento.SetParameterValue(1, Convert.ToInt32(Request.QueryString["id_solicitud"]));
                this.documento.SetParameterValue(2, "comprador");
                this.documento.SetParameterValue(3, Convert.ToInt32(Request.QueryString["id"]));

                this.documento.OpenSubreport("Repre_comprador");
                this.documento.SetParameterValue(4, Convert.ToInt32(Request.QueryString["id_solicitud"]));
                this.documento.SetParameterValue(5, "comprador");
                this.documento.SetParameterValue(6, Convert.ToInt32(Request.QueryString["id"]));


                this.documento.OpenSubreport("Repre_vendedor");
                this.documento.SetParameterValue(7, Convert.ToInt32(Request.QueryString["id_solicitud"]));
                this.documento.SetParameterValue(8, "vendedor");
                this.documento.SetParameterValue(9, Convert.ToInt32(Request.QueryString["id"]));

                this.documento.OpenSubreport("vendedor");
                this.documento.SetParameterValue(10, Convert.ToInt32(Request.QueryString["id_solicitud"]));
                this.documento.SetParameterValue(11, "vendedor");
                this.documento.SetParameterValue(12, Convert.ToInt32(Request.QueryString["id"]));
            }
            else
			{
				this.documento.SetParameterValue(0, Convert.ToInt32(Request.QueryString["id_solicitud"]));
			}

            CrystalReportViewer1.HasToggleGroupTreeButton = false;
            CrystalReportViewer1.HasToggleParameterPanelButton = false;
            CrystalReportViewer1.HasCrystalLogo = false;
            //CrystalReportViewer1.HasDrillUpButton = false;
            //CrystalReportViewer1.HasExportButton = false;
            //CrystalReportViewer1.HasGotoPageButton = false;
            //CrystalReportViewer1.HasPageNavigationButtons = false;
            CrystalReportViewer1.HasRefreshButton = false;
            CrystalReportViewer1.HasSearchButton = false;
            CrystalReportViewer1.HasToggleGroupTreeButton = false;
            CrystalReportViewer1.HasZoomFactorList = false;
            //CrystalReportViewer1.BestFitPage = false;

            this.CrystalReportViewer1.ReportSource = this.documento;
		}
	}
}