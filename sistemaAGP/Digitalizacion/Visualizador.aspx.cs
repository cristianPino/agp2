using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CENTIDAD;
using CNEGOCIO;

namespace sistemaAGP.digitalizacion
{
    public partial class Visualizador : System.Web.UI.Page
    {
        public int IdSolicitud;
        public string IdIncidencia;
        public int IdSolicitudOrigen;
        public string TipoOperacion;
        public string Usuario;
        public bool ExisteIncidencia = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            IdSolicitud = Convert.ToInt32(FuncionGlobal.FuctionDesEncriptar(Request.QueryString["id_solicitud"]));

            IdIncidencia = Request.QueryString["id_incidencia"];
            //no se pueden subir ni eliminar documentos de la incidencia fuera cuando esta ya es operación
            wucDocumento.VerPanelAcciones = false;

            if (IdIncidencia != null)
            {
                //lleno la incidencia
                wucDocumento.Inicio(Convert.ToInt32(IdIncidencia));
                ExisteIncidencia = true;
            }

            if(Session["usrname"] == null) { FuncionGlobal.alerta_updatepanel("Ha perdido la sesión",this.Page,updateP); return;}

            Usuario = (Session["usrname"]).ToString().Trim();
            var usuario = new UsuarioBC().GetUsuario(Usuario);

            //Busco si por numero de operación encuentro una incidencia
            var dtNuevaSolicitud = new IncidenciaBC().GetIncidenciaFromNuevaSolicitud(IdSolicitud);
            if (dtNuevaSolicitud.Rows.Count > 0)
            {
                gr_documentos_origen.DataSource = GetDocs(Convert.ToInt32(dtNuevaSolicitud.Rows[0]["id_solicitud"]), usuario);
                gr_documentos_origen.DataBind();

                //si no recibio idIncidencia como parametro pero si exite desde la busqueda por operacion
                if (IdIncidencia == null)
                {
                    wucDocumento.Inicio(Convert.ToInt32(dtNuevaSolicitud.Rows[0]["id_incidencia"]));
                }
                ExisteIncidencia = true;
            }

            if (!ExisteIncidencia)
            {
                tab_opciones.Tabs[1].Visible = false;
                tab_opciones.Tabs[2].Visible = false;
            }

            //lleno la grilla de la operacion
            TipoOperacion = Request.QueryString["tipo"];
            if (IsPostBack) return;

            InicializarComponentes(usuario);
            GetTitulosDoc();


            gr_documentos.DataSource = GetDocs(IdSolicitud, usuario);
            gr_documentos.DataBind();


        }

        private void InicializarComponentes(Usuario usuario)
        {
            imgSubir.ImageUrl = Constantes.IMAGEN_SUBIR_DOCUMENTO_ACTIVO;
            imgEliminar.ImageUrl = usuario.Permite_eliminar
                ? Constantes.IMAGEN_ELIMINAR_DOCUMENTO_ACTIVO_AZUL
                : Constantes.IMAGEN_ELIMINAR_DOCUMENTO_DESACTIVO;

            imgEliminar.Enabled = usuario.Permite_eliminar;

        }

        private void GetDocIncidencia()
        {

        }




        private DataTable GetDocs(Int32 idSolicitud, Usuario usuario)
        {
            this.i_documento.Attributes["src"] = "";

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
            dt.Columns.Add(new DataColumn("fecha"));

            var lista = new DocumentosOperacionBC().getDocumentos(idSolicitud, 0);

           
            foreach (var doc in lista)
            {
                var dr = dt.NewRow();
                dr["id_documento_operacion"] = doc.Id_documento_operacion;
                dr["id_solicitud"] = doc.Id_solicitud;
                dr["id_documento"] = doc.Id_documento;
                dr["nombre"] = doc.Nombre.ToUpper();
                dr["url"] = doc.Url;
                dr["extension"] = doc.Extension;
                dr["fecha"] = doc.Fecha;
                dr["peso"] = (doc.Peso / 1024).ToString() + "Kb.";
                dr["observaciones"] = doc.Observaciones;
                dr["usuario"] = doc.CuentaUsuario == "" ? "SIN INFORMACIÓN" : doc.Usuario.Nombre.ToUpper();
                dt.Rows.Add(dr);
            }
            return dt;

        }

        public void GetTitulosDoc()
        {
            var dt = new DataTable();
            dt.Columns.Add("id_documento");
            dt.Columns.Add("nombre");
            var dr = dt.NewRow();
            dr["id_documento"] = 0;
            dr["nombre"] = "Seleccione un título";
            dt.Rows.Add(dr);

            //Actividad por prod_cliente
            var lista = new DocumentosBC().getDocumentosByProductos(TipoOperacion, 0);
            foreach (var d in lista)
            {
                dr = dt.NewRow();
                dr["id_documento"] = d.Id_documento;
                dr["nombre"] = d.Nombre;
                dt.Rows.Add(dr);
            }
            dlTitulo.DataSource = dt;
            dlTitulo.DataTextField = "nombre";
            dlTitulo.DataValueField = "id_documento";
            dlTitulo.SelectedValue = "0";
            dlTitulo.DataBind();
        }

        protected void gr_documentos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName != "View") return;
            var idx = Convert.ToInt32(e.CommandArgument);
            var url = gr_documentos.DataKeys[idx].Values[3].ToString();

            lblDocumentoNombre.Text = gr_documentos.DataKeys[idx]["nombre"].ToString().Trim();
            lblDocumentoComentario.Text = gr_documentos.DataKeys[idx]["observaciones"].ToString().Trim();
            lblDocumentoUsuario.Text = gr_documentos.DataKeys[idx]["usuario"].ToString().Trim();

            i_documento.Attributes["src"] = url;
        }

        protected void btnSubir_Click(object sender, EventArgs e)
        {
            subir_archivos();
        }

        protected void subir_archivos()
        {
            var subida = false;
            var idDocumento = Convert.ToInt32(dlTitulo.SelectedValue);

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

            var pre = new OperacionBC().getoperacion(IdSolicitud);
            var sPath = String.Format("{0}/{1}/{2}", "docs", pre.Cliente.Id_cliente.ToString().Trim(), pre.Tipo_operacion.Codigo.Trim());
            if (!Directory.Exists(@sPath)) sPath = String.Format("{0}/{1}", "docs", pre.Tipo_operacion.Codigo.Trim());
            if (!Directory.Exists(@sPath)) sPath = "docs";

            var observaciones = txtObservacion.Value.Trim();

            var fuDocumento = fu_archivo;
            if (fuDocumento.PostedFile == null || fuDocumento.PostedFile.ContentLength <= 0) return;
            var fiDocumento = new FileInfo(fuDocumento.FileName);
            if (fiDocumento.Extension.ToLower() != ".png" && fiDocumento.Extension.ToLower() != ".jpg" &&
                fiDocumento.Extension.ToLower() != ".gif" && fiDocumento.Extension.ToLower() != ".pdf" &&
                fiDocumento.Extension.ToLower() != ".doc" && fiDocumento.Extension.ToLower() != ".docx" &&
                fiDocumento.Extension.ToLower() != ".xls" && fiDocumento.Extension.ToLower() != ".xlsx" &&
                fiDocumento.Extension.ToLower() != ".tiff") return;
            if (fuDocumento.PostedFile.ContentLength > 6194304) return;
            var sDoc = IdSolicitud + "_" + idDocumento + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + fiDocumento.Extension;
            var sSave = Server.MapPath(@sPath) + destino + "\\" + sDoc;
            try
            {
                fuDocumento.PostedFile.SaveAs(sSave);
                sSave = sPath + destino + "/" + sDoc;
                var doc = new DocumentosOperacionBC();
                doc.add_documentos(IdSolicitud, idDocumento, sSave, fiDocumento.Extension, fuDocumento.PostedFile.ContentLength, observaciones, Usuario);
                var cambiaEstado = new DocumentoCambioEstadoBC().GotoDocumentosCambioEstado(IdSolicitud, idDocumento,
                                                                                            Usuario);
                if (cambiaEstado == 1)
                {
                    Mensaje("Archivo subido con éxito. Esta acción cambió de estado la operación.");
                }
                subida = true;

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this.updateP, this.updateP.GetType(), "ShowError", string.Format("<script type=\"text/javascript\">alert('Error al subir el archivo {0}\n\n{1}');</script>", fuDocumento.FileName, ex.Message), false);
            }
            Mensaje(subida ? "Archivo subido con éxito" : "No se pudo subir el archivo seleccionado");
            var usuario = new UsuarioBC().GetUsuario(Usuario);
            GetDocs(IdSolicitud, usuario);
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

        private void eliminar_documentos()
        {
            string usuario = Convert.ToString(Session["usrname"]);

            if (string.IsNullOrEmpty(usuario))
            {
                Mensaje("Se ha perdido la conexión. Vuelva a entrar al sistema");
                return;
            }


            var eliminados = 0;
            for (var idx = 0; idx < gr_documentos.Rows.Count; idx++)
            {
                var row = gr_documentos.Rows[idx];
                if (row.RowType != DataControlRowType.DataRow) continue;
                var idDocumentoOperacion = Convert.ToInt32(gr_documentos.DataKeys[idx].Values[0].ToString());
                var chkDel = (CheckBox)row.FindControl("chk_eliminar");
                if (!chkDel.Checked) continue;
                try
                {

                    new DocumentosOperacionBC().del_documentos(idDocumentoOperacion, usuario);
                    eliminados += 1;
                    var url = Server.MapPath(gr_documentos.DataKeys[idx].Values[3].ToString());
                    var fiDoc = new FileInfo(url);
                    if (fiDoc.Exists)
                    {
                        fiDoc.Delete();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            Mensaje("Se han eliminado " + eliminados + " documentos.");
           
            GetDocs(IdSolicitud, new UsuarioBC().GetUsuario(Usuario));
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

        public void Mensaje(string mensaje)
        {
            FuncionGlobal.alerta_updatepanel(mensaje, Page, updateP);
        }
        

        protected void imgEliminar_Click(object sender, ImageClickEventArgs e)
        {
            eliminar_documentos();
        }

        protected void imgSubir_Click(object sender, ImageClickEventArgs e)
        {
            mpe_subir.Show();
        }
    }
}