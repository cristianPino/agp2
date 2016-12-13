using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CENTIDAD;
using CNEGOCIO;

namespace sistemaAGP.digitalizacion
{
    public partial class GestoriaDocumental : System.Web.UI.Page
    {
        public int IdSolicitud = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            IdSolicitud = Convert.ToInt32(FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_solicitud"]));
            hdIdSolicitud.Value = IdSolicitud.ToString(CultureInfo.InvariantCulture);
            if (IsPostBack) return;
            GetDocs(IdSolicitud);
        }

        private void GetDocs(Int32 idSolicitud)
        {
            i_documento.Attributes["src"] = "";

            var dt = new DataTable();
            dt.Columns.Add(new DataColumn("id_documento_operacion"));
            dt.Columns.Add(new DataColumn("id_solicitud"));
            dt.Columns.Add(new DataColumn("id_documento"));
            dt.Columns.Add(new DataColumn("nombre"));
            dt.Columns.Add(new DataColumn("url"));
            dt.Columns.Add(new DataColumn("extension"));
            dt.Columns.Add(new DataColumn("peso"));
            dt.Columns.Add(new DataColumn("observaciones"));
            dt.Columns.Add(new DataColumn("usuario"));

            var lista = new DocumentosOperacionBC().GetDocumentosTipoGastos(idSolicitud);
            btnSubir.Visible = lista.Count > 0;
            foreach (var doc in lista)
            {
                var dr = dt.NewRow();
                dr["id_documento_operacion"] = doc.Id_documento_operacion;
                dr["id_solicitud"] = doc.Id_solicitud;
                dr["id_documento"] = doc.Id_documento;
                dr["nombre"] = doc.Nombre;
                dr["url"] = doc.Url;
                dr["extension"] = doc.Extension;
                dr["peso"] = doc.Id_documento_operacion == 0 ? "" : (doc.Peso / 1024).ToString() + "Kb.";
                dr["observaciones"] = doc.Observaciones;
                dr["usuario"] = doc.Id_documento_operacion == 0 ? "" : doc.Usuario.Nombre;
                dt.Rows.Add(dr);
            }
            gr_documentos.DataSource = dt;
            gr_documentos.DataBind();
        }




        protected void btnSubir_Click(object sender, EventArgs e)
        {
            try
            {
                var subidos = subir_archivos();
                GetDocs(Convert.ToInt32(hdIdSolicitud.Value));
                FuncionGlobal.alerta_updatepanel("Se subieron correctamente " + subidos + " Archivos.", Page, upd);
            }
            catch (Exception ex)
            {
                FuncionGlobal.alerta_updatepanel(ex.Message, Page, upd);
            }

        }


        public string CambiarMes(string mes)
        {
            var nuevomes = mes;
            if (Convert.ToInt32(mes) < 10)
            {
                nuevomes = nuevomes.Substring(1, nuevomes.Length - 1);
                return nuevomes;
            }
            return nuevomes;
        }

        public string CambiarDia(string dia)
        {
            var nuevodia = dia;
            if (Convert.ToInt32(dia) < 10)
            {
                nuevodia = nuevodia.Substring(1, nuevodia.Length - 1);
                return nuevodia;
            }
            return nuevodia;
        }
        protected int subir_archivos()
        {
            var correctos = 0;
            for (var idx = 0; idx < gr_documentos.Rows.Count; idx++)
            {
                var row = gr_documentos.Rows[idx];
                if (row.RowType != DataControlRowType.DataRow) continue;
                var fuDocumento = (FileUpload)row.FindControl("fu_archivo");
                if (fuDocumento.PostedFile == null || fuDocumento.PostedFile.ContentLength <= 0) continue;
                var idSolicitud = Convert.ToInt32(hdIdSolicitud.Value);
                var idDocumento = Convert.ToInt32(gr_documentos.DataKeys[idx].Values[2].ToString().Trim());

                //divido la fecha en año mes dia.
                var x = DateTime.Now.ToString("yyyyMMddHHmmss");
                var anio = x.Substring(0, 4);
                var mes = x.Substring(4, 2);
                var dia = x.Substring(6, 2);

                //obtengo todos los nombres de los meses del año en español.
                String[] meses = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames;

                //valido que el formato de los dias y meses sean equivalentes a los nombres de las carpetas de destino.
                var numeroMes = CambiarMes(mes);
                var carpetaMes = numeroMes + "." + meses[Convert.ToInt32(mes) - 1];
                var nuevoDia = CambiarDia(dia);

                //armo los strings con las rutas dependiendo de la consulta.
                string destino = "";

                destino = "/" + anio + "/" + carpetaMes + "/" + nuevoDia;

                var pre = new OperacionBC().getoperacion(idSolicitud);
                var sPath = String.Format("{0}/{1}/{2}", "docs", pre.Cliente.Id_cliente.ToString().Trim(),
                                          pre.Tipo_operacion.Codigo.ToString().Trim());
                if (!Directory.Exists(@sPath))
                    sPath = String.Format("{0}/{1}", "docs", pre.Tipo_operacion.Codigo.ToString().Trim());
                if (!Directory.Exists(@sPath)) sPath = "docs";
                var observaciones = ((TextBox)row.FindControl("txt_observaciones")).Text.Trim();

                var fiDocumento = new FileInfo(fuDocumento.FileName);
                if (fiDocumento.Extension.ToLower() != ".png" && fiDocumento.Extension.ToLower() != ".jpg" &&
                    fiDocumento.Extension.ToLower() != ".gif" && fiDocumento.Extension.ToLower() != ".pdf" &&
                    fiDocumento.Extension.ToLower() != ".doc" && fiDocumento.Extension.ToLower() != ".docx" &&
                    fiDocumento.Extension.ToLower() != ".xls" && fiDocumento.Extension.ToLower() != ".xlsx" &&
                    fiDocumento.Extension.ToLower() != ".tiff") continue;
                if (fuDocumento.PostedFile.ContentLength > 6194304) continue;
                var sDoc = idSolicitud.ToString() + "_" + idDocumento.ToString() + "_" +
                           DateTime.Now.ToString("yyyyMMdd_HHmmss") + fiDocumento.Extension;
                var sSave = Server.MapPath(@sPath) + destino + "\\" + sDoc;

                fuDocumento.PostedFile.SaveAs(sSave);
                sSave = sPath + destino + "/" + sDoc;
                var doc = new DocumentosOperacionBC();
                doc.add_documentos(idSolicitud, idDocumento, sSave, fiDocumento.Extension,
                                   fuDocumento.PostedFile.ContentLength, observaciones,
                                   Session["usrname"].ToString());
                correctos++;
            }
            return correctos;
        }

        protected void gr_documentos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName != "View") return;
            var idx = Convert.ToInt32(e.CommandArgument);
            var url = gr_documentos.DataKeys[idx].Values[3].ToString(); ;
            i_documento.Attributes["src"] = url;
        }

        protected void gr_documentos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow) return;
            var idDocumentoOperacion = Convert.ToInt32(gr_documentos.DataKeys[e.Row.RowIndex].Values[1].ToString().Trim());
            var subeArchivo = (FileUpload)e.Row.FindControl("fu_archivo");
            var checkEliminar = (CheckBox)e.Row.FindControl("chk_eliminar");
            var textComentario = (TextBox)e.Row.FindControl("txt_observaciones");
            if (idDocumentoOperacion != 0)
            {
                subeArchivo.Visible = false;
                e.Row.BackColor = System.Drawing.Color.DimGray;
                e.Row.ForeColor = System.Drawing.Color.LightSkyBlue;
                textComentario.ReadOnly = true;
            }
            else
            {
                checkEliminar.Checked = false;
                checkEliminar.Visible = false;
            }
        }
    }
}