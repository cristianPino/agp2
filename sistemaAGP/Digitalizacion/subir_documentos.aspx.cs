using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CNEGOCIO;
using CENTIDAD;
using System.Globalization;

namespace sistemaAGP {
	public partial class subir_documentos : System.Web.UI.Page {

		Int32 id_solicitud;
        Int32 id_documento;
		string tipo;
        string usuario;

		protected void Page_Load(object sender, EventArgs e) {
			id_solicitud = Convert.ToInt32(FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_solicitud"]));
			tipo = Request.QueryString["tipo"];

            if (Request.QueryString["id_documento"] != null)
            {
                id_documento = Convert.ToInt32(FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_documento"]));
            }
            else
            {
                id_documento = 0;
            }
            if (Request.QueryString["cuenta_usuario"] != null)
            {
               usuario = FuncionGlobal.FuctionDesEncriptar(Request.QueryString["cuenta_usuario"]).Trim();
            }
            else
            {
                usuario = (string)(Session["usrname"]).ToString().Trim();
            }
			if (!IsPostBack) {
				carga_documentos(id_solicitud, tipo,id_documento);
			}
		}

		private void carga_documentos(Int32 id_solicitud, string tipo, Int32 id_documento) {
			List<Documentos> lDocs = new DocumentosBC().getDocumentosByProductos(tipo, id_documento);

			if (lDocs.Count > 0) {
				divGrilla.Visible = true;
				divMensaje.Visible = false;
				DataTable dt = new DataTable();
				dt.Columns.Add(new DataColumn("id_solicitud"));
				dt.Columns.Add(new DataColumn("codigo"));
				dt.Columns.Add(new DataColumn("id_documento"));
				dt.Columns.Add(new DataColumn("nombre"));
                dt.Columns.Add(new DataColumn("url_escanner"));


				foreach (Documentos doc in lDocs) {
					DataRow dr = dt.NewRow();
					dr["id_solicitud"] = id_solicitud;
					dr["codigo"] = tipo;
					dr["id_documento"] = doc.Id_documento;
					dr["nombre"] = doc.Nombre;
                    dr["url_escanner"] = "Prueba.aspx?id_solicitud=" + id_solicitud.ToString().Trim() + "&tipo=" + doc.Id_documento.ToString().Trim()  ;

					dt.Rows.Add(dr);
				}

				this.gr_documentos.DataSource = dt;
				this.gr_documentos.DataBind();
			} else {
				divGrilla.Visible = false;
				divMensaje.Visible = true;
			}
		}

		protected void bt_subir_Click(object sender, EventArgs e) {
			subir_archivos();
		}
        public string CambiarMes(string mes)
        {
            string nuevomes = mes;
            if (Convert.ToInt32(mes) < 10)
            {
                nuevomes = nuevomes.Substring(1, nuevomes.Length - 1);
                return nuevomes;
            }
            return nuevomes;
        }

        public string CambiarDia(string dia)
        {
            string nuevodia = dia;
            if (Convert.ToInt32(dia) < 10)
            {
                nuevodia = nuevodia.Substring(1, nuevodia.Length - 1);
                return nuevodia;
            }
            return nuevodia;
        }

		protected void subir_archivos() {
			for (Int32 idx = 0; idx < gr_documentos.Rows.Count; idx++) {
				GridViewRow row = gr_documentos.Rows[idx];
				if (row.RowType == DataControlRowType.DataRow) {
					Int32 id_solicitud = Convert.ToInt32(gr_documentos.DataKeys[idx].Values[0].ToString().Trim());
					string codigo = gr_documentos.DataKeys[idx].Values[1].ToString();
					Int32 id_documento = Convert.ToInt32(gr_documentos.DataKeys[idx].Values[2].ToString().Trim());

                    //divido la fecha en año mes dia.
                    string x = DateTime.Now.ToString("yyyyMMddHHmmss");
                    string anio = x.Substring(0, 4);
                    string mes = x.Substring(4, 2);
                    string dia = x.Substring(6, 2);

                    //obtengo todos los nombres de los meses del año en español.
                    String[] Meses = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames;

                    //valido que el formato de los dias y meses sean equivalentes a los nombres de las carpetas de destino.
                    string numero_mes = CambiarMes(mes);
                    string CarpetaMes = numero_mes + "." + Meses[Convert.ToInt32(mes) - 1].ToString();
                    string nuevo_dia = CambiarDia(dia);

                    //armo los strings con las rutas dependiendo de la consulta.
                    string destino = "";
                
                        destino = "/" + anio + "/" + CarpetaMes + "/" + nuevo_dia ;
                  


					Operacion pre = new OperacionBC().getoperacion(id_solicitud);
					string sPath = String.Format("{0}/{1}/{2}", "docs", pre.Cliente.Id_cliente.ToString().Trim(), pre.Tipo_operacion.Codigo.ToString().Trim());
					if (!System.IO.Directory.Exists(@sPath)) sPath = String.Format("{0}/{1}", "docs", pre.Tipo_operacion.Codigo.ToString().Trim());
					if (!System.IO.Directory.Exists(@sPath)) sPath = "docs";
					pre = null;

					string observaciones = ((TextBox)row.FindControl("txt_observaciones")).Text.Trim();

					FileUpload fu_documento = (FileUpload)row.FindControl("fu_archivo");
					if (fu_documento.PostedFile != null && fu_documento.PostedFile.ContentLength > 0) {
						FileInfo fi_documento = new FileInfo(fu_documento.FileName);
						if (fi_documento != null) {
							if (fi_documento.Extension.ToLower() == ".png" || fi_documento.Extension.ToLower() == ".jpg" ||
								fi_documento.Extension.ToLower() == ".gif" || fi_documento.Extension.ToLower() == ".pdf" ||
								fi_documento.Extension.ToLower() == ".doc" || fi_documento.Extension.ToLower() == ".docx" ||
								fi_documento.Extension.ToLower() == ".xls" || fi_documento.Extension.ToLower() == ".xlsx" ||
								fi_documento.Extension.ToLower() == ".tiff") {
								if (fu_documento.PostedFile.ContentLength <= 6194304) {
									string sDoc = id_solicitud.ToString() + "_" + id_documento.ToString() + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + fi_documento.Extension;
									string sSave = Server.MapPath(@sPath)+destino + "\\" + sDoc;
									//string sSave = Server.MapPath(@"docs") + "\\" + sDoc;
									try {
										fu_documento.PostedFile.SaveAs(sSave);
										//sSave = "docs/" + sDoc;
										sSave = sPath +destino+ "/" + sDoc;
										DocumentosOperacionBC doc = new DocumentosOperacionBC();
										doc.add_documentos(id_solicitud, id_documento, sSave, fi_documento.Extension, fu_documento.PostedFile.ContentLength, observaciones,usuario);
									} catch (Exception ex) {
										//Response.Write(ex.Message);
										//Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "ShowError", string.Format("<script language=javascript>alert('Error al subir el archivo {0}\n\n{1}');</script>", fu_documento.FileName, ex.Message));
										ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "ShowError", string.Format("<script type=\"text/javascript\">alert('Error al subir el archivo {0}\n\n{1}');</script>", fu_documento.FileName, ex.Message), false);
									}
								}
							}
						}
					}
				}
			}
			//Page.RegisterClientScriptBlock("ShowAlert", "<script language=javascript>alert('Archivos subidos con éxito');</script>");
			ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "ShowAlert", "<script type=\"text/javascript\">alert('Archivos subidos con éxito');</script>", false);
		}
	}
}