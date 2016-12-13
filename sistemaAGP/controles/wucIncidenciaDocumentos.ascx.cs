using System;
using System.Web.UI.WebControls;
using CNEGOCIO;
using System.Globalization;
using System.IO;
using System.Data;

namespace sistemaAGP.controles
{
    public partial class wucIncidenciaDocumentos : System.Web.UI.UserControl
    {
        static int IdIncidencia;
        public bool VerPanelAcciones { get; set; }
        static bool PuedeModificar { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            pnelAcciones.Visible = VerPanelAcciones;           
        }

        public void Inicio(int idIncidencia, bool puedeModificar=false)
        {
            //a pesar de que el panel tenga una visibilidad por defecto, 
            //si puedeModificar es distinto pisa al defecto (de no especificar valor por defecto es false)
            pnelAcciones.Visible = puedeModificar;

            gr_documentos.DataSource = new IncidenciaBC().GetDocumentosIncidencia(idIncidencia);
            gr_documentos.DataBind();
        }
        protected void btnSubirIncidencia_Click(object sender, EventArgs e)
        {
            if (txtTítulo.Text.Trim() == string.Empty || txtComentario.Text.Trim() == string.Empty)
            {
                //MENSAJE ERROR
                FuncionGlobal.alerta_updatepanel("Ingrese un título y un comentario", Page, upd_Incidencia);
               // FuncionGlobal.alerta("Ingrese un título y un comentario", Page);
            }
            else
            {
                try
                {
                    subir_archivos();
                    Inicio(IdIncidencia);
                }
                catch (Exception ex)
                {
                    //MENSAJE ERROR
                    FuncionGlobal.alerta_updatepanel("Error: " + ex.Message , Page, upd_Incidencia);
                    FuncionGlobal.alerta("Error: " + ex.Message, Page);
                }
               
            }
            
        }


        protected void gr_documentos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "View")
            {
                Int32 idx = Convert.ToInt32(e.CommandArgument);
                string url = this.gr_documentos.DataKeys[idx]["url"].ToString(); ;
                this.i_documento.Attributes["src"] = url;
            }
        }

        protected void subir_archivos()
        {
            //divido la fecha en año mes dia.
            string x = DateTime.Now.ToString("yyyyMMddHHmmss");
            string anio = x.Substring(0, 4);
            string mes = x.Substring(4, 2);
            string dia = x.Substring(6, 2);

            //obtengo todos los nombres de los meses del año en español.
            String[] meses = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames;

            //valido que el formato de los dias y meses sean equivalentes a los nombres de las carpetas de destino.
            string numeroMes = CambiarMes(mes);
            string carpetaMes = numeroMes + "." + meses[Convert.ToInt32(mes) - 1];
            string nuevoDia = CambiarDia(dia);

            //armo los strings con las rutas dependiendo de la consulta.
            var destino = "";

            destino = "/" + anio + "/" + carpetaMes + "/" + nuevoDia;

            var sPath = String.Format("{0}/{1}", "docs", IdIncidencia);
            if (!Directory.Exists(@sPath)) sPath = String.Format("{0}/{1}", "docs", IdIncidencia);
            if (!Directory.Exists(@sPath)) sPath = "docs";

            var observaciones = txtComentario.Text.Trim();

            var fuDocumento = fu_archivo;
            if (fuDocumento.PostedFile == null || fuDocumento.PostedFile.ContentLength <= 0) return;
            var fiDocumento = new FileInfo(fuDocumento.FileName);
            if (fiDocumento.Extension.ToLower() != ".png" && fiDocumento.Extension.ToLower() != ".jpg" &&
                fiDocumento.Extension.ToLower() != ".gif" && fiDocumento.Extension.ToLower() != ".pdf" &&
                fiDocumento.Extension.ToLower() != ".doc" && fiDocumento.Extension.ToLower() != ".docx" &&
                fiDocumento.Extension.ToLower() != ".xls" && fiDocumento.Extension.ToLower() != ".xlsx" &&
                fiDocumento.Extension.ToLower() != ".tiff") return;
            if (fuDocumento.PostedFile.ContentLength > 6194304) return;
            var sDoc = IdIncidencia + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + fiDocumento.Extension;
            var sSave = Server.MapPath(@sPath) + destino + "\\" + sDoc;

            fuDocumento.PostedFile.SaveAs(sSave);
            sSave = sPath + destino + "/" + sDoc;
            var doc = new DocumentosOperacionBC();
            DataTable dt = new IncidenciaBC().GetIncidenciaById(IdIncidencia);
            var incidenciaEstado = Convert.ToInt32(dt.Rows[0]["id_incidencia_estado"]);
            new IncidenciaBC().AddDocumentoIncidencia(IdIncidencia, txtTítulo.Text.Trim(), incidenciaEstado, sSave, Convert.ToString(Session["usrname"]), txtComentario.Text.Trim());
            
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
    }
}