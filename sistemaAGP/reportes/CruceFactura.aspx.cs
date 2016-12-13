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
using System.Data.OleDb;
using System.IO;
using CNEGOCIO;
using CENTIDAD;
using System.Collections.Generic;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Web;

namespace sistemaAGP
{
    public partial class CruceFactura : System.Web.UI.Page
	{

      

        


        protected void carga_excel(string sp_informe,string titulo)
        {
            string desde = string.Format("{0:yyyyMMdd}",DateTime.Now);
            string hasta = string.Format("{0:yyyyMMdd}",DateTime.Now);
           
         
            int id_familia = 0;
         
       
            string add = "";
            add = new MatrizExcelBC().getmatrizinforme_Excel((string)(Session["usrname"]), desde, hasta, sp_informe,id_familia,titulo);

            string strAlerta = "window.open('http://sistema.agpsa.cl/Reportes_Excel/" + add.ToString().Trim() + "');";
            //ScriptManager.RegisterStartupScript(Page,Page.GetType(), "", strAlerta, true);
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "", strAlerta, true);


            return;
        }
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				
			}
		}

	

		protected void gr_dato_SelectedIndexChanged(object sender, EventArgs e)
		{
            

		}

        private string carga_archivo()
        {
            string sSave = "";

            if (this.fileuploadExcel.PostedFile != null && this.fileuploadExcel.PostedFile.ContentLength > 0)
            {
                FileInfo fi_documento = new FileInfo(fileuploadExcel.FileName);
                if (fi_documento != null)
                {
                    if (fi_documento.Extension.ToLower() == ".xls")
                    {

                        if (fileuploadExcel.PostedFile.ContentLength <= 6194304)
                        {
                            string sDoc = "Cruce_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + fi_documento.Extension;
                            sSave = "c:\\Archivo_Cruce\\" + sDoc;
                            try
                            {
                                this.fileuploadExcel.PostedFile.SaveAs(sSave);
                                //sSave = "docs/" + sDoc;
                                //sSave = sPath + "/" + sDoc;

                            }
                            catch (Exception ex)
                            {
                                Response.Write(ex.Message);
                                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "ShowError", string.Format("<script language=javascript>alert('Error al subir el archivo {0}\n\n{1}');</script>", fi_documento.FullName, ex.Message));

                            }
                        }
                    }
                    else
                    {
                        this.lbl_cantidad.Text = "El formato del Excel solo puede ser .xls";
                    }
                }
            }

            return sSave;

        }

        protected void btnImport_Click(object sender, EventArgs e)
        {
            //eliminar

            importa_excel(carga_archivo());
        }

        private void importa_excel(string ruta)
        {
            this.gr_dato.DataSourceID = null;
            this.gr_dato.DataSource = null;
            this.gr_dato.DataBind();
            ViewState["dt_operacion"] = null;
          
        

          
                    //Connection String to Excel Workbook
                    string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + ruta + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";


                    string query = "SELECT [factura],[id_cliente]  FROM [Hoja1$] ";
                    OleDbConnection conn = new OleDbConnection(connString);
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                    OleDbCommand cmd = new OleDbCommand(query, conn);
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    this.lbl_cantidad.Visible = true;
                    this.lbl_cantidad.Text = "Numero de Filas en Archivo : " + ds.Tables[0].Rows.Count.ToString();

                    da.Dispose();
                    conn.Close();
                    conn.Dispose();

                    DataTable dt = ds.Tables[0];

                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["factura"] != null && dr["factura"].ToString().Trim() != "")
                        {
                            Buscar_Operaciones(Convert.ToInt32(dr["factura"]),Convert.ToInt32(dr["id_cliente"]));
                            //this.txt_folio.Text = "";
                        }
                    }


                }


        protected void Buscar_Operaciones(int factura, int id_cliente)
        {
            DataTable dt = new DataTable();

            dt = (DataTable)ViewState["dt_operacion"];

            if (dt == null)
            {
                crear_data_table();
                dt = (DataTable)ViewState["dt_operacion"];
            }

            Operacion moperacion = new OperacionBC().getCruceFactura(factura, id_cliente, 0);

            if (moperacion != null)
            {
               
                DataRow dr = dt.NewRow();



                dr["monto_gasto"] = moperacion.Total_gasto.ToString();
                dr["id_solicitud"] = moperacion.Id_solicitud;
                dr["id_cliente"] = moperacion.Cliente.Id_cliente;
                dr["nombre_cliente"] = moperacion.Cliente.Persona.Nombre;
                dr["tipo_operacion"] = moperacion.Tipo_operacion.Codigo;
                dr["operacion"] = moperacion.Tipo_operacion.Operacion;
                dr["numero_factura"] = moperacion.Numero_factura;
                dr["ingresada"] = "SI";

                DatosVehiculo mdato = new DatosvehiculoBC().getDatovehiculo(moperacion.Id_solicitud);
                if (mdato == null)
                {
                    dr["patente"] = "";
                }
                else
                {
                    dr["patente"] = mdato.Patente;
                }

                if (moperacion.Adquiriente != null)
                {
                    dr["rut_persona"] = moperacion.Adquiriente.Rut.ToString("N0") + "-" + moperacion.Adquiriente.Dv;
                    dr["nombre_persona"] = string.Format("{0} {1} {2}", moperacion.Adquiriente.Nombre, moperacion.Adquiriente.Apellido_paterno, moperacion.Adquiriente.Apellido_materno).Trim();
                }
                else
                {
                    dr["rut_persona"] = "0-0";
                    dr["nombre_persona"] = "Sin Adquiriente";

                }

                dr["ultimo_estado"] = moperacion.Estado;

                dt.Rows.Add(dr);

            }

            ViewState["dt_operacion"] = dt;
            this.gr_dato.DataSource = dt;
            this.gr_dato.DataBind();
         

        }


        protected void crear_data_table()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("id_solicitud", System.Type.GetType("System.Int32")));
            dt.Columns.Add(new DataColumn("id_cliente", System.Type.GetType("System.Int32")));
            dt.Columns.Add(new DataColumn("nombre_cliente", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("tipo_operacion", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("operacion", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("numero_factura", System.Type.GetType("System.Int32")));
            dt.Columns.Add(new DataColumn("ingresada", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("patente", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("rut_persona", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("nombre_persona", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("semaforo"));
            dt.Columns.Add(new DataColumn("ultimo_estado", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("monto_gasto"));
           

            ViewState["dt_operacion"] = dt;

        }

            
      
	}
}