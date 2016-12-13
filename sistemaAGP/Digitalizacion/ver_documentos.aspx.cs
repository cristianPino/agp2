using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CNEGOCIO;
using CENTIDAD;

namespace sistemaAGP.digitalizacion {
	public partial class ver_documentos : System.Web.UI.Page {

		Int32 id_solicitud;
		public string origen;

		protected void Page_Load(object sender, EventArgs e) {
			origen = Request.QueryString["origen"];
			if (origen != "pc") {
				this.divBoton.Visible = false;
                //this.gr_documentos.Columns[3].Visible = false;
               
			}

			id_solicitud = Convert.ToInt32(FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_solicitud"]));
			if (!IsPostBack) {

                TipoOperacion tipo = new TipooperacionBC().getcomprobantebyoperacion(id_solicitud);
                Usuario usu = new UsuarioBC().GetUsuario((string)(Session["usrname"]));

                if (usu.Cliente.Id_cliente == 1 && tipo.Codigo.ToUpper() == "DTAG" || usu.Cliente.Id_cliente == 1 && tipo.Codigo.ToUpper() == "CTAG")
                {
                    this.tabAsociados.Visible = true;
                    this.gr_asociados.Visible = true;
                }

				carga_documentos(id_solicitud);
			}
		}

		private void carga_documentos(Int32 id_solicitud) {
			this.i_documento.Attributes["src"] = "";

			DataTable dt = new DataTable();
			dt.Columns.Add(new DataColumn("id_documento_operacion"));
			dt.Columns.Add(new DataColumn("id_solicitud"));
			dt.Columns.Add(new DataColumn("id_documento"));
			dt.Columns.Add(new DataColumn("nombre"));
			dt.Columns.Add(new DataColumn("url"));
			dt.Columns.Add(new DataColumn("extension"));
			dt.Columns.Add(new DataColumn("peso"));
			dt.Columns.Add(new DataColumn("observaciones"));

			foreach (DocumentosOperacion doc in new DocumentosOperacionBC().getDocumentos(id_solicitud, 0))
			{
				DataRow dr = dt.NewRow();
				if (origen == "eo" && !doc.Publico) continue;
				dr["id_documento_operacion"] = doc.Id_documento_operacion;
				dr["id_solicitud"] = doc.Id_solicitud;
				dr["id_documento"] = doc.Id_documento;
				dr["nombre"] = doc.Nombre;
				dr["url"] = doc.Url;
				dr["extension"] = doc.Extension;
				dr["peso"] = (doc.Peso / 1024).ToString() + "Kb.";
				dr["observaciones"] = doc.Observaciones;
				dt.Rows.Add(dr);
			}
			this.gr_documentos.DataSource = dt;
			this.gr_documentos.DataBind();

			DataTable asoc = new DataTable();
			asoc.Columns.Add(new DataColumn("id_documento_operacion"));
			asoc.Columns.Add(new DataColumn("id_solicitud"));
			asoc.Columns.Add(new DataColumn("id_documento"));
			asoc.Columns.Add(new DataColumn("nombre"));
			asoc.Columns.Add(new DataColumn("url"));
			asoc.Columns.Add(new DataColumn("extension"));
			asoc.Columns.Add(new DataColumn("peso"));
			asoc.Columns.Add(new DataColumn("observaciones"));

			foreach (DocumentosOperacion doc in new DocumentosOperacionBC().getDocumentosAsociados(id_solicitud))
			{
				DataRow dr = asoc.NewRow();
				if (origen == "eo" && !doc.Publico) continue;
				dr["id_documento_operacion"] = doc.Id_documento_operacion;
				dr["id_solicitud"] = doc.Id_solicitud;
				dr["id_documento"] = doc.Id_documento;
				dr["nombre"] = doc.Nombre;
				dr["url"] = doc.Url;
				dr["extension"] = doc.Extension;
				dr["peso"] = (doc.Peso / 1024).ToString() + "Kb.";
				dr["observaciones"] = doc.Observaciones;
				asoc.Rows.Add(dr);
			}
			this.gr_asociados.DataSource = asoc;
			this.gr_asociados.DataBind();
		}

		protected void bt_eliminar_Click(object sender, EventArgs e) {
             EstadoOperacion mesta = new EstadooperacionBC().getEstadobyorden(Convert.ToInt32(id_solicitud), 88);

             Usuario usu = new UsuarioBC().GetUsuario((string)(Session["usrname"]));
             if (usu.Cliente.Id_cliente == 1)
             {

                 if (mesta.Permite_estado == false)
                 {
                     eliminar_documentos();
                 }
                 else
                 {
                     FuncionGlobal.alerta_updatepanel("NO SE PUEDE ELIMINAR DOCUMENTOS SI ESTA EN COBRANZA", this.Page, this.up_datos);
                 }
             }
             else
             {
                 FuncionGlobal.alerta_updatepanel("NO POSE LOS PERMISOS NECESARIOS PARA ELIMINAR DOCUMENTOS", this.Page, this.up_datos);
             }
		}

		private void eliminar_documentos() {
            string usuario = Convert.ToString(Session["usrname"]);
            for (Int32 idx = 0; idx < gr_documentos.Rows.Count; idx++) {
				GridViewRow row = gr_documentos.Rows[idx];
				if (row.RowType == DataControlRowType.DataRow) {
					Int32 id_documento_operacion = Convert.ToInt32(gr_documentos.DataKeys[idx].Values[0].ToString());
					CheckBox chk_del = (CheckBox)row.FindControl("chk_eliminar2");
					if (chk_del.Checked) {
						try {
							string del = new DocumentosOperacionBC().del_documentos(id_documento_operacion, usuario);

							string url = Server.MapPath(gr_documentos.DataKeys[idx].Values[3].ToString());
							System.IO.FileInfo fi_doc = new System.IO.FileInfo(url);
							if (fi_doc.Exists) {
								fi_doc.Delete();
							}
						} catch (Exception ex) {
							throw ex;
						}
					}
				}
			}
			carga_documentos(id_solicitud);
		}

		protected void gr_documentos_RowCommand(object sender, GridViewCommandEventArgs e) {
			if (e.CommandName == "View") {
				Int32 idx = Convert.ToInt32(e.CommandArgument);
				string url = this.gr_documentos.DataKeys[idx].Values[3].ToString(); ;
				this.i_documento.Attributes["src"] = url;
			}
		}

		protected void gr_asociados_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			if (e.CommandName == "View")
			{
				Int32 idx = Convert.ToInt32(e.CommandArgument);
				string url = this.gr_asociados.DataKeys[idx].Values[3].ToString(); ;
				this.i_documento.Attributes["src"] = url;
			}
		}

		protected void tabDocs_ActiveTabChanged(object sender, EventArgs e)
		{
			this.i_documento.Attributes["src"] = "";
		}

        protected void gr_documentos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       
	}
}