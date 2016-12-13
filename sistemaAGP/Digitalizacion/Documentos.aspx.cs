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

namespace sistemaAGP.OrdenTrabajo.modal
{
    public partial class Documentos : System.Web.UI.Page
    {
        public int IdOrdenTrabajo; 
        protected void Page_Load(object sender, EventArgs e)
        {
          if(IsPostBack)return;
            IdOrdenTrabajo = Convert.ToInt32(FuncionGlobal.FuctionDesEncriptar(Request.QueryString["idOrdenTrabajo"]));
            hdId.Value = IdOrdenTrabajo.ToString();
            FuncionGlobal.ComboChecklist(dl_lista_titulos,1);
            carga_documentos(IdOrdenTrabajo);
        }
        private void carga_documentos(int idOt)
        {
            this.i_documento.Attributes["src"] = "";

            DataTable dt = new DataTable();
           
            dt.Columns.Add(new DataColumn("idChecklistOrdenPedido"));
            dt.Columns.Add(new DataColumn("idOrdenTrabajo"));
            dt.Columns.Add(new DataColumn("nombre"));
            dt.Columns.Add(new DataColumn("url"));
            dt.Columns.Add(new DataColumn("fecha"));
            dt.Columns.Add(new DataColumn("usuario"));
            dt.Columns.Add(new DataColumn("observaciones"));
            dt.Columns.Add(new DataColumn("id_checklist"));

            var lista = new ChecklistOrdenTrabajoBC().GetCecklistOrdenTrabajo(idOt);

            foreach ( var n in lista )//1 valor para los check tipo documentos
            {
                DataRow dr = dt.NewRow();

                dr["id_checklist"] = n.IdChecklist;
                dr["idChecklistOrdenPedido"] = n.IdChecklistOrdenTrabajo;
                dr["idOrdenTrabajo"] = n.IdOrdenTrabajo;
                dr["nombre"] = n.DescripcionChecklist;
                dr["url"] = n.Url;
                dr["fecha"] = n.Fecha;
                dr["observaciones"] = n.Observacion;
                dr["usuario"] = new UsuarioBC().GetUsuario(n.CuentaUsuario).Nombre.ToUpper();
                dt.Rows.Add(dr);
            }
            bt_eliminar.Visible = lista.Count > 0;
            this.gr_documentos.DataSource = dt;
            this.gr_documentos.DataBind();
            ScriptManager.RegisterStartupScript(this.UpdatePanel1, GetType(), "cabeceragrid", " grilla_cabecera();", true);

        }

       

        protected void gr_documentos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "View")
            {
                Int32 idx = Convert.ToInt32(e.CommandArgument);
                string url = this.gr_documentos.DataKeys[idx].Values[3].ToString(); ;
                this.i_documento.Attributes["src"] = url;
            }
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

     


        protected void subir_archivos()
        {
            Int32 idOrdenTrabajo = Convert.ToInt32(hdId.Value);
           
            Int32 idDocumento = Convert.ToInt32(dl_lista_titulos.SelectedValue);

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

            destino = "/" + anio + "/" + CarpetaMes + "/" + nuevo_dia;

            string sPath = String.Format("{0}/{1}/{2}", "docs", IdOrdenTrabajo.ToString().Trim(),dl_lista_titulos.SelectedValue.Trim());
            if (!System.IO.Directory.Exists(@sPath)) sPath = String.Format("{0}/{1}", "docs", dl_lista_titulos.SelectedValue.Trim());
            if (!System.IO.Directory.Exists(@sPath)) sPath = "docs";

            
            //string sPath = String.Format("{0}/{1}/{2}", "docs", IdOrdenTrabajo,IdOrdenTrabajo);
            //if (!System.IO.Directory.Exists(@sPath)) sPath = String.Format("{0}/{1}", "docs",idOrdenTrabajo);
            //if (!System.IO.Directory.Exists(@sPath)) sPath = "docs";  
            FileUpload fu_documento = fu_archivo;
            if (fu_documento.PostedFile != null && fu_documento.PostedFile.ContentLength > 0)
            {
                FileInfo fi_documento = new FileInfo(fu_documento.FileName);
                if (fi_documento != null)
                {
                    if (fi_documento.Extension.ToLower() == ".png" || fi_documento.Extension.ToLower() == ".jpg" ||
                        fi_documento.Extension.ToLower() == ".gif" || fi_documento.Extension.ToLower() == ".pdf" ||
                        fi_documento.Extension.ToLower() == ".doc" || fi_documento.Extension.ToLower() == ".docx" ||
                        fi_documento.Extension.ToLower() == ".xls" || fi_documento.Extension.ToLower() == ".xlsx" ||
                        fi_documento.Extension.ToLower() == ".tiff")
                    {
                        if (fu_documento.PostedFile.ContentLength <= 10195407)
                        {
                            string sDoc = idOrdenTrabajo.ToString() + "_" + idDocumento.ToString() + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + fi_documento.Extension;
                            string sSave = Server.MapPath(@sPath) + destino + "\\" + sDoc;
                            //string sSave = Server.MapPath(@"docs") + "\\" + sDoc;
                            try
                            {
                               
                                fu_documento.PostedFile.SaveAs(sSave);
                                //sSave = "docs/" + sDoc;
                                sSave = sPath + destino + "/" + sDoc;
                                new ChecklistOrdenTrabajoBC().AddChecklistOrdenTrabajo(new ChecklistOrdenTrabajo
                                {
                                    IdChecklist = Convert.ToInt16(dl_lista_titulos.SelectedValue),
                                    CuentaUsuario = Session["usrname"].ToString().Trim(),
                                    Url = sSave,
                                    Observacion = txt_comentarios.Text.Trim(),
                                    IdOrdenTrabajo = Convert.ToInt32(hdId.Value)
                                });

                               
                                ;
                            }
                            catch (Exception ex)
                            {
                                FuncionGlobal.alerta_updatepanel(ex.Message,Page,UpdatePanel1);
                                return;
                            }
                        }
                    }
                }
               
            }
            //Page.RegisterClientScriptBlock("ShowAlert", "<script language=javascript>alert('Archivos subidos con éxito');</script>");
            ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "ShowAlert", "<script type=\"text/javascript\">alert('Archivos subidos con éxito');</script>", false);
        }

        protected void btn_subir_Click(object sender, EventArgs e)
        {
            int id_titulo = Convert.ToInt32(this.dl_lista_titulos.SelectedValue); 

            if (id_titulo == 0 )
            {
                FuncionGlobal.alerta_updatepanel("ERROR: Seleccione un Título de documento", this.Page, this.UpdatePanel1);
                return;
            }
            try
            {
                subir_archivos();
                carga_documentos(Convert.ToInt32(hdId.Value)); 
            }
            catch (Exception ex)
            {
                FuncionGlobal.alerta_updatepanel(ex.Message, this.Page, this.UpdatePanel1); 
            }
           
            FuncionGlobal.alerta_updatepanel("Se subió el archivo correctamente", this.Page, this.UpdatePanel1);
        }



        private void eliminar_documentos()
        {
            for (Int32 idx = 0; idx < gr_documentos.Rows.Count; idx++)
            {
                GridViewRow row = gr_documentos.Rows[idx];
                if (row.RowType == DataControlRowType.DataRow)
                {
                   
                    CheckBox chk_del = (CheckBox)row.FindControl("chk_eliminar");
                    if (chk_del.Checked)
                    {
                        
                            Int32 idChecklistOrdenPedido = Convert.ToInt32(gr_documentos.DataKeys[idx].Values[0].ToString());
                            new ChecklistOrdenTrabajoBC().DelCecklistOrdenTrabajo(idChecklistOrdenPedido); 
                     }
                }
            }

        }

        protected void bt_eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                eliminar_documentos();
                carga_documentos(Convert.ToInt32(hdId.Value));
            }
            catch(Exception ex)
            {
                FuncionGlobal.alerta_updatepanel(ex.Message, this.Page, this.UpdatePanel1);
            }

            FuncionGlobal.alerta_updatepanel("Se eliminó correctamente la selección de archivos", this.Page, this.UpdatePanel1);
        }

        protected void ibSalir_Click(object sender, ImageClickEventArgs e)
        {
            string script = "parent.$.fancybox.close();";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "closewindow", script, true);
        }

        public void limpiar()
        {

            this.txt_comentarios.Text = "";
            this.dl_lista_titulos.SelectedValue = "0";

        }
    }
}