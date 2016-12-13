using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CENTIDAD;
using CNEGOCIO;

namespace sistemaAGP
{
	public partial class UploadEscritura : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				ViewState["id_cliente"] = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_cliente"].ToString());
				ViewState["id_solicitud"] = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_solicitud"].ToString());

				this.lbl_id_solicitud.Text = ViewState["id_solicitud"].ToString();

				Garantia garantia = new GarantiaBC().GetgarantiabyIdSolicitud(Convert.ToInt32(ViewState["id_solicitud"].ToString()));
				if (garantia != null)
				{
					this.lbl_dedudor.Text = (garantia.Adquiriente.Nombre + " " + garantia.Adquiriente.Apellido_paterno + " " + garantia.Adquiriente.Apellido_materno).Trim().ToUpper();
					this.lbl_rut_constituyente_titulo.Text = (garantia.Adquiriente.Rut > 50000000) ? "RUT" : "RUN";
				}
			}
		}		

		protected void btn_subir_Click(object sender, EventArgs e)
		{
			if (this.fu_archivo.PostedFile != null && this.fu_archivo.PostedFile.ContentLength > 0)
			{
				//ScriptManager.RegisterStartupScript(this, this.GetType(), "Start", "UploadStarted();", true);
				string url = "";
				string fileName = ViewState["id_solicitud"].ToString() + ".doc";
				switch (ViewState["id_cliente"].ToString().Trim())
				{
					case "1": //AGP S.A.
						url = "generadas/agp/" + fileName;
						break;
					case "4": //AUTOMOTORES GILDEMEISTER S.A.
						url = "generadas/ag/" + fileName;
						break;
					case "6": //AUTOMOTRIZ PORTILLO S.A.
						url = "generadas/portillo/" + fileName;
						break;
					case "10": //AMICAR
						url = "generadas/amicar/" + fileName;
						break;
					case "14": //BICE CREDIAUTO
						url = "generadas/bice/" + fileName;
						break;
					case "15": //BANCO ESTADO
						url = "generadas/bestado/" + fileName;
						break;
					case "16": //SANTANDER CONSUMER
						url = "generadas/santander/" + fileName;
						break;
					case "19": //SCOTIABANK
						url = "generadas/scotiabank/" + fileName;
						break;
					case "35": //AUTOMOTORA PORTEZUELO S.A.
						url = "generadas/portezuelo/" + fileName;
						break;
					case "44": //FACTORLINE
						url = "generadas/factorline/" + fileName;
						break;
					case "50": //TANNER
						url = "generadas/tanner/" + fileName;
						break;
					default:
						url = "generadas/" + fileName;
						break;
				}

				string savePath = Server.MapPath(url);
				try
				{
					this.fu_archivo.SaveAs(savePath);
					ScriptManager.RegisterStartupScript(this.up_file, this.up_file.GetType(), "Complete", "alert('Se completo la carga del archivo');", true);
				}
				catch (Exception ex)
				{
					ScriptManager.RegisterStartupScript(this.up_file, this.up_file.GetType(), "Error", "alert('Se produjo un error al subir el archivo:\n" + ex.Message + "');", true);
				}
			}
		}
	}
}