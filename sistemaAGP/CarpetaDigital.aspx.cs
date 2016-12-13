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
	public partial class CarpetaDigital : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				ViewState["id_solicitud"] = FuncionGlobal.DescifrarSQL(Request.QueryString["id_solicitud"] ?? "0100000068D348071CD1805E07BC58A432EA44D0F96484D33EF2234F");
				ViewState["id_documento"] = FuncionGlobal.DescifrarSQL(Request.QueryString["id_documento"] ?? "0100000068D348071CD1805E07BC58A432EA44D0F96484D33EF2234F");
				ViewState["url_fondo"] = "imagenes/clientes/fondos/agp.png";

				this.lbl_titulo.Text = "Carpeta Digital - Operación nº " + ViewState["id_solicitud"];

				this.Carga_Fondo();
				this.Carga_Documentos();
			}
		}

		protected void Carga_Fondo()
		{
			Operacion op = new OperacionBC().getoperacion(Convert.ToInt32(ViewState["id_solicitud"]));
			if (op.Cliente != null)
				if (op.Cliente.Fondo_Pantalla != "") ViewState["url_fondo"] = op.Cliente.Fondo_Pantalla;
			op = null;
		}

		protected void Carga_Documentos()
		{
			this.gr_documentos.DataSource = from doc in new DocumentosOperacionBC().getDocumentos(Convert.ToInt32(ViewState["id_solicitud"]), Convert.ToInt32(ViewState["id_documento"]))
											orderby doc.Id_documento_operacion ascending
											select new
											{
												id_documento_operacion = doc.Id_documento_operacion,
												id_solicitud = doc.Id_solicitud,
												id_documento = doc.Id_documento,
												nombre = doc.Nombre.Trim(),
												url = string.Format("https://docs.google.com/gview?url={0}&embedded=true", HttpUtility.UrlEncode(Request.Url.Scheme + "://" + Request.Url.Authority + "/digitalizacion/" + doc.Url.Trim())),
												extension = doc.Extension.Trim().ToLower(),
												peso = (doc.Peso / 1024).ToString("N0") + "Kb.",
												observaciones = doc.Observaciones
											};
			this.gr_documentos.DataBind();
		}

      


      
	}
}