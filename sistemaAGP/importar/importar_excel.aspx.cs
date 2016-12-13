using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.IO;
using CNEGOCIO; 

namespace sistemaAGP.importar
{
    public partial class importar_excel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private string carga_archivo()
        {
            string  sSave="";

            if (this.fileuploadExcel.PostedFile != null && this.fileuploadExcel.PostedFile.ContentLength > 0)
            {
                FileInfo fi_documento = new FileInfo(fileuploadExcel.FileName);
                if (fi_documento != null)
                {
                    if (fi_documento.Extension.ToLower() == ".png" || fi_documento.Extension.ToLower() == ".jpg" ||
                        fi_documento.Extension.ToLower() == ".gif" || fi_documento.Extension.ToLower() == ".pdf" ||
                        fi_documento.Extension.ToLower() == ".doc" || fi_documento.Extension.ToLower() == ".docx" ||
                        fi_documento.Extension.ToLower() == ".xls" || fi_documento.Extension.ToLower() == ".xlsx" ||
                        fi_documento.Extension.ToLower() == ".tiff")
                    {

                        if (fileuploadExcel.PostedFile.ContentLength <= 6194304)
                        {
                            string sDoc = "Amicar_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + fi_documento.Extension;
                             sSave = "c:\\Archivo_Amicar\\" + sDoc;
                            try
                            {
                                this.fileuploadExcel.PostedFile.SaveAs(sSave);
                                //sSave = "docs/" + sDoc;
                                //sSave = sPath + "/" + sDoc;

                            }
                            catch (Exception ex)
                            {
                                //Response.Write(ex.Message);
                                //Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "ShowError", string.Format("<script language=javascript>alert('Error al subir el archivo {0}\n\n{1}');</script>", fu_documento.FileName, ex.Message));

                            }
                        }
                    }
                }
            }

            return sSave;

        }

        protected void btnImport_Click(object sender, EventArgs e)
        {
            this.btn_carga.Visible = false; 
            importa_excel(carga_archivo());
        }


        private void importa_excel(string ruta)
        {

            
            //Connection String to Excel Workbook
            string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + ruta + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";

            string query = "SELECT [reporte_agp] as f1 ,[f3],[f4],[f5],[f6],[f7],[f8],[f9],[f10], [f11],[f12],[f14],[f15],[f16], 1 as estado, " + DateTime.Now.ToString("yyyymmdd") + " as fecha FROM [Cartola AGP$] where [reporte_agp] >1 ";
            //string query = "SELECT [reporte_agp] as f1 ,[f3],[f4],[f5],[f6],[f7],[f8],[f9],[f10], [f11],[f12],[f14],[f15],[f16], 1 as estado, " + DateTime.Now.ToString("yyyymmdd") + " as fecha FROM [Reporte_AGP.rdl$] where [reporte_agp] >1 ";
            OleDbConnection conn = new OleDbConnection(connString);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            OleDbCommand cmd = new OleDbCommand(query, conn);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            lblMessage.Text = "Numero de Filas en Archivo : "  + ds.Tables[0].Rows.Count.ToString();

            if (ds.Tables[0].Rows.Count > 0)
            {
                this.btn_carga.Visible = true; 
            }


            
            da.Dispose();
            conn.Close();
            conn.Dispose();


            string imp = new ImportalExcelBC().importa_excel(ruta);   


        }

        protected void btn_carga_Click(object sender, EventArgs e)
        {

            DataTable imp = new ImportalExcelBC().carga_operaciones_amicar();

            this.grvExcelData.DataSource = imp;
            this.grvExcelData.DataBind();

            FuncionGlobal.alerta("Operaciones de Creditos Adjudicados ingresados con Exito", Page);


        }





    }
}