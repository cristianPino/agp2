using System;
using System.Web;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;
using CENTIDAD;

namespace CACCESO
{
    public class MatrizExcelDAC
    {

        public string GetReportePreticket(string usuario, DataTable dt)
        {
            return new GenExcell().ReportePreticket(usuario, dt);
        }

        public string getnominamatrizgasto(Int16 id_nomina, Int32 folio_nomina, Int32 id_familia, string titulo)
        {
            string add = new GenExcell().INTgetnominamatrizgasto(id_nomina, folio_nomina, id_familia, titulo);
                return add;

        }

        public string getMatrizRetiroCarpeta(string desde,string hasta, string usuario)
        {
            string add = new GenExcell().INTgetmatrizRetiroCarpeta(desde,hasta, usuario);
            return add;

        }
        public string getReporteCobranzaa(string usuario, string tipo)
        {
            string add = new GenExcell().getmatrizReporteControlCobranza(usuario, tipo);
            return add;

        }
        public string GetReporteCertificados(string usuario, DataTable dt)
        {
            return new GenExcell().ReporteCErtificados(usuario, dt);
        }

        public string GetReporteHipotecario(string usuario, DataTable dt)
        {
            return new GenExcell().ReporteHipotecario(usuario, dt);  
        }


        public string getMatrizinforme(string desde, string hasta, string usuario, string sp_informe, string tipo_operacion, int id_modulo, int id_sucursal, int id_cliente, int id_solicitud,
                                        int rut_adquiriente, int numero_factura, string numero_cliente, string patente, int ultimo_estado, int folio, int id_nomina, int id_ciudad,
                                        int id_familia,string titulo)
        {
            string add = new GenExcell().INTgetmatrizinforme(desde, hasta, usuario, sp_informe, tipo_operacion, id_modulo, id_sucursal, id_cliente, id_solicitud, rut_adquiriente, numero_factura, numero_cliente, patente,
                                                ultimo_estado, folio, id_nomina, id_ciudad, id_familia, titulo);
            return add;


        }

        public string getMatrizinforme_Excel(string usuario, string desde, string hasta,  string sp_informe,int id_familia, string titulo)
        {
            string add = new GenExcell().INTgetmatrizinforme_Excel(usuario,desde, hasta,  sp_informe, id_familia, titulo);
            return add;


        }

        internal class GenExcell : CACCESO.BaseDAC
        {
            StreamWriter w;

            public string INTgetnominamatrizgasto(Int16 id_nomina, Int32 folio_nomina, Int32 id_familia, string titulo)

            {

                
                 string strPath = System.Configuration.ConfigurationManager.AppSettings["EXPORT_EXCEL"];


                 string ruta = strPath + id_nomina.ToString().Trim() + "_" +    folio_nomina.ToString().Trim() + ".xls";
                 string archivo =  id_nomina.ToString().Trim() + "_" + folio_nomina.ToString().Trim() + ".xls";

                FileStream fs = new FileStream(ruta, FileMode.Create,
                                     FileAccess.ReadWrite);

                w = new StreamWriter(fs);

                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_composicion_gasto_operacion";
                    cmd.Parameters.AddWithValue("@id_familia", id_familia);
                    cmd.Parameters.AddWithValue("@folio", folio_nomina);
                    cmd.Parameters.AddWithValue("@id_nomina", id_nomina);
                    SqlDataReader reader = cmd.ExecuteReader();


                    EscribeCabecera(reader, titulo);
                    EscribeLinea(reader);
                    EscribePiePagina();


                    w.Close();

                    sqlConn.Close();
                }

                return archivo;
            
            }

            public void EscribeLinea(SqlDataReader reader)
            {
                DataTable schema = reader.GetSchemaTable();
                StringBuilder html;
                
                while (reader.Read())
                {
                    
                     html = new StringBuilder();
                    
                    // strlinea = strlinea + "<td>" + reader[myField[myProperty].ToString()].ToString() + "</td>";

                    //strlinea ="<tr>";
                    html.Append("<tr>");
                   
                    for (int col = 0; col < reader.FieldCount; col++)
                    {
                        // Console.Write(reader.GetName(col).ToString());         // Gets the column name

                        //strlinea = strlinea + "<td>" + reader[reader.GetName(col).ToString()].ToString() + "</td>";

                        html.Append("<td>" + reader[reader.GetName(col).ToString()].ToString() + "</td>");
                       
                       
                    }

                    html.Append("</tr>");

                    

                    w.Write(html.ToString());
                    html = null;
                    
                }
              
            }

        
            public void EscribePiePagina()
            {
                StringBuilder html = new StringBuilder();
                html.Append("  </table>");
                html.Append("</p>");
                html.Append(" </body>");
                html.Append("</html>");
                w.Write(html.ToString());
            }

        


            public void EscribeCabecera(SqlDataReader reader, string titulo)
            {  
                DataTable schema = reader.GetSchemaTable();

                StringBuilder html = new StringBuilder();
                html.Append("<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.0 Transitional//EN\">");
                html.Append("<html>");
                html.Append("  <head>");
                html.Append("<title>www.devjoker.com</title>");
                html.Append("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" />");
                html.Append("  </head>");
                html.Append("<body>");
                html.Append("<p>");

                
                

                html.Append("<table>");
                html.Append("<tr><td colspan='10'>" + titulo +   "</td></tr>");
                html.Append("<tr style=\"font-weight:bold;font-size: 12px;color: white;\">");


                // html.Append("<td bgcolor=\"Darkcyan\">" + myField[myProperty].ToString() + "</td>");

                for (int col = 0; col < reader.FieldCount; col++)
                {
                   // Console.Write(reader.GetName(col).ToString());         // Gets the column name

                   html.Append("<td bgcolor=\"Darkcyan\">" + reader.GetName(col).ToString() + "</td>");
                }

                html.Append("</tr>");

                w.Write(html.ToString());
            }

           

            public string getmatrizReporteControlCobranza(string usuario, string tipo)
            {


                string strPath = System.Configuration.ConfigurationManager.AppSettings["EXPORT_EXCEL"];


                string ruta = strPath + usuario.Trim() + DateTime.Now.Day.ToString() + '-' + DateTime.Now.Month.ToString() + '-' + DateTime.Now.Year.ToString() + ".xls";
                string archivo = usuario.Trim() + DateTime.Now.Day.ToString() + '-' + DateTime.Now.Month.ToString() + '-' + DateTime.Now.Year.ToString() + ".xls";

                FileStream fs = new FileStream(ruta, FileMode.Create,
                                     FileAccess.ReadWrite);

                w = new StreamWriter(fs);


                string proc = "";

                switch (tipo)
                {
                    case "1": proc = "TBL_REPORTE_PROCESO_COBRANZA_CANTIDAD"; break;
                    case "2": proc = "TBL_REPORTE_PROCESO_COBRANZA_MONTO"; break;
                    case "3": proc = "TBL_REPORTE_PROCESO_COBRANZA_REEMBOLSO"; break;
                    case "4": proc = "TBL_REPORTE_PROCESO_COBRANZA_FACTURA"; break;
                }

                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);

                    cmd.CommandTimeout = 10000;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_get_procesos_all";
                    cmd.Parameters.AddWithValue("@nombre_tabla", proc + usuario.Trim());

                    SqlDataReader reader = cmd.ExecuteReader();


                    EscribeCabecera(reader, "REPORTE PROCESOS COBRANZA");
                    EscribeLinea(reader);
                    EscribePiePagina();

                    w.Close();
                    sqlConn.Close();

                }

                //string ruta2 = "C:\\EXPORT_EXCEL\\" + usuario.Trim() + DateTime.Now.Day.ToString() + '-' + DateTime.Now.Month.ToString() + '-' + DateTime.Now.Year.ToString() + ".xlsx";
                //string archivo2 = usuario.Trim() + DateTime.Now.Day.ToString() + '-' + DateTime.Now.Month.ToString() + '-' + DateTime.Now.Year.ToString() + ".xlsx";

                //Application apli = new Application() ;
                //Workbook wb ;
                //Worksheet ws ;
                //wb = apli.Workbooks.Add();

                //using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                //{
                //    sqlConn.Open();
                //    SqlCommand cmd = new SqlCommand(strConn, sqlConn);

                //    cmd.CommandTimeout = 10000;
                //    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //    cmd.CommandText = "sp_get_procesos_all";
                //    cmd.Parameters.AddWithValue("@nombre_tabla", "TBL_REPORTE_PROCESO_COBRANZA_CANTIDAD" + usuario.Trim());

                //    SqlDataReader reader = cmd.ExecuteReader();

                //     ws =  (Worksheet)wb.Worksheets.get_Item(1);

                //     int columnCount = reader.FieldCount;

                //     for (int n = 0; n < columnCount; n++)
                //     {
                //         //Console.Write(myReader.GetName(n) + "\t");
                //         //createHeaders(ws, 1, n + 1, reader.GetName(n));

                //         ws.Cells[1, n + 1] = reader.GetName(n);
                //     }

                //     int rowCounter = 2;
                //     while (reader.Read())
                //     {
                //         for (int n = 0; n < columnCount; n++)
                //         {
                //             //Console.WriteLine();
                //             //Console.Write(myReader[myReader.GetName(n)].ToString() + "\t");
                //             //addData(ws, rowCounter, n + 1, reader[reader.GetName(n)].ToString());

                //             ws.Cells[rowCounter, n + 1] = reader[reader.GetName(n)].ToString();
                //         }
                //         rowCounter++;
                //     }


                //    sqlConn.Close();
                //}

                //using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                //{
                //    sqlConn.Open();
                //    SqlCommand cmd = new SqlCommand(strConn, sqlConn);

                //    cmd.CommandTimeout = 10000;
                //    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //    cmd.CommandText = "sp_get_procesos_all";
                //    cmd.Parameters.AddWithValue("@nombre_tabla", "TBL_REPORTE_PROCESO_COBRANZA_MONTO" + usuario.Trim());


                //    SqlDataReader reader = cmd.ExecuteReader();

                //    ws = (Worksheet)wb.Worksheets.get_Item(2);

                //    int columnCount = reader.FieldCount;

                //    for (int n = 0; n < columnCount; n++)
                //    {
                //        //Console.Write(myReader.GetName(n) + "\t");
                //        //createHeaders(ws, 1, n + 1, reader.GetName(n));
                //        ws.Cells[1, n + 1] = reader.GetName(n);
                //    }

                //    int rowCounter = 2;
                //    while (reader.Read())
                //    {
                //        for (int n = 0; n < columnCount; n++)
                //        {
                //            //Console.WriteLine();
                //            //Console.Write(myReader[myReader.GetName(n)].ToString() + "\t");
                //            //addData(ws, rowCounter, n + 1, reader[reader.GetName(n)].ToString());
                //            ws.Cells[rowCounter, n + 1] = reader[reader.GetName(n)].ToString();
                //        }
                //        rowCounter++;
                //    }



                //    sqlConn.Close();
                //}
                //using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                //{
                //    sqlConn.Open();
                //    SqlCommand cmd = new SqlCommand(strConn, sqlConn);

                //    cmd.CommandTimeout = 10000;
                //    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //    cmd.CommandText = "sp_get_procesos_all";
                //    cmd.Parameters.AddWithValue("@nombre_tabla", "TBL_REPORTE_PROCESO_COBRANZA_REEMBOLSO" + usuario.Trim());

                //    SqlDataReader reader = cmd.ExecuteReader();

                //    ws = (Worksheet)wb.Worksheets.get_Item(3);

                //    int columnCount = reader.FieldCount;

                //    for (int n = 0; n < columnCount; n++)
                //    {
                //        //Console.Write(myReader.GetName(n) + "\t");
                //        //createHeaders(ws, 1, n + 1, reader.GetName(n));
                //        ws.Cells[1, n + 1] = reader.GetName(n);
                //    }

                //    int rowCounter = 2;
                //    while (reader.Read())
                //    {
                //        for (int n = 0; n < columnCount; n++)
                //        {
                //            //Console.WriteLine();
                //            //Console.Write(myReader[myReader.GetName(n)].ToString() + "\t");
                //            //addData(ws, rowCounter, n + 1, reader[reader.GetName(n)].ToString());
                //            ws.Cells[rowCounter, n + 1] = reader[reader.GetName(n)].ToString();
                //        }
                //        rowCounter++;
                //    }


                //    sqlConn.Close();
                //}

                //wb.Worksheets.Add();
                //using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                //{
                //    sqlConn.Open();
                //    SqlCommand cmd = new SqlCommand(strConn, sqlConn);

                //    cmd.CommandTimeout = 10000;
                //    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //    cmd.CommandText = "sp_get_procesos_all";
                //    cmd.Parameters.AddWithValue("@nombre_tabla", "TBL_REPORTE_PROCESO_COBRANZA_FACTURA" + usuario.Trim());

                //    SqlDataReader reader = cmd.ExecuteReader();


                //    ws = (Worksheet)wb.Worksheets.get_Item(4);

                //    int columnCount = reader.FieldCount;

                //    for (int n = 0; n < columnCount; n++)
                //    {
                //        //Console.Write(myReader.GetName(n) + "\t");
                //        //createHeaders(ws, 1, n + 1, reader.GetName(n));
                //        ws.Cells[1, n + 1] = reader.GetName(n);
                //    }

                //    int rowCounter = 2;
                //    while (reader.Read())
                //    {
                //        for (int n = 0; n < columnCount; n++)
                //        {
                //            //Console.WriteLine();
                //            //Console.Write(myReader[myReader.GetName(n)].ToString() + "\t");
                //            //addData(ws, rowCounter, n + 1, reader[reader.GetName(n)].ToString());
                //            ws.Cells[rowCounter, n + 1] = reader[reader.GetName(n)].ToString();
                //        }
                //        rowCounter++;
                //    }

                //    sqlConn.Close();
                //}
                //wb.SaveAs(ruta2, XlFileFormat.xlWorkbookDefault);

                //wb.Close(true);
                //apli.Quit();


                return archivo;

            }



            public string INTgetmatrizRetiroCarpeta(string desde, string hasta, string usuario)
            {


                string strPath = System.Configuration.ConfigurationManager.AppSettings["EXPORT_EXCEL"];


                string ruta = strPath + usuario.Trim() +  DateTime.Now.Day.ToString()+'-'+DateTime.Now.Month.ToString()+'-'+ DateTime.Now.Year.ToString() + ".xls";
                string archivo = usuario.Trim() +  DateTime.Now.Day.ToString() + '-' + DateTime.Now.Month.ToString() + '-' + DateTime.Now.Year.ToString() + ".xls";
                
                FileStream fs = new FileStream(ruta, FileMode.Create,
                                     FileAccess.ReadWrite);

                w = new StreamWriter(fs);
               
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);

                    cmd.CommandTimeout = 10000;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_composicion_retiro_carpeta";
                    cmd.Parameters.AddWithValue("@desde", desde);
                    cmd.Parameters.AddWithValue("@hasta", hasta);

                    SqlDataReader reader = cmd.ExecuteReader();
                    EscribeCabecera(reader,"REPORTE RETIRO DE CARPETAS");
                    EscribeLinea(reader); 
                    EscribePiePagina();

                    w.Close();
                    sqlConn.Close();
                }

                return archivo;

            }

            public string INTgetmatrizinforme(string desde, string hasta, string usuario, string sp_informe, string tipo_operacion, int id_modulo, int id_sucursal, int id_cliente, int id_solicitud,
                                      int rut_adquiriente, int numero_factura, string numero_cliente, string patente, int ultimo_estado, int folio, int id_nomina, int id_ciudad,
                                      int id_familia, string titulo)
            {
                string strPath = System.Configuration.ConfigurationManager.AppSettings["EXPORT_EXCEL"];
                string ruta = strPath + usuario.Trim() + DateTime.Now.Day.ToString() + '-' + DateTime.Now.Month.ToString() + '-' + DateTime.Now.Year.ToString() + ".xls";
                string archivo = usuario.Trim() + DateTime.Now.Day.ToString() + '-' + DateTime.Now.Month.ToString() + '-' + DateTime.Now.Year.ToString() + ".xls";

                FileStream fs = new FileStream(ruta, FileMode.Create,
                                     FileAccess.ReadWrite);
                w = new StreamWriter(fs);
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandTimeout = 10000;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = sp_informe;
                    cmd.Parameters.AddWithValue("@tipo_operacion", tipo_operacion);
                    cmd.Parameters.AddWithValue("@id_modulo", id_modulo);
                    cmd.Parameters.AddWithValue("@id_sucursal", id_sucursal);
                    cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
                    cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
                    cmd.Parameters.AddWithValue("@rut_adquiriente", rut_adquiriente);
                    cmd.Parameters.AddWithValue("@numero_factura", numero_factura);
                    cmd.Parameters.AddWithValue("@numero_cliente", numero_cliente);
                    cmd.Parameters.AddWithValue("@patente", patente);
                    cmd.Parameters.AddWithValue("@desde", desde);
                    cmd.Parameters.AddWithValue("@hasta", hasta);
                    cmd.Parameters.AddWithValue("@ultimo_estado", ultimo_estado);
                    cmd.Parameters.AddWithValue("@cuenta_usuario", usuario);
                    cmd.Parameters.AddWithValue("@folio", folio);
                    cmd.Parameters.AddWithValue("@id_nomina", id_nomina);
                    cmd.Parameters.AddWithValue("@id_ciudad", id_ciudad);
                    cmd.Parameters.AddWithValue("@id_familia", id_familia);


                    SqlDataReader reader = cmd.ExecuteReader();
                    EscribeCabecera(reader, titulo);
                    EscribeLinea(reader);
                    EscribePiePagina();

                    w.Close();
                    sqlConn.Close();
                }

                return archivo;

            }



            public string INTgetmatrizinforme_Excel(string usuario, string desde, string hasta, string sp_informe, int id_familia, string titulo)
            {
                string strPath = System.Configuration.ConfigurationManager.AppSettings["EXPORT_EXCEL"];
                string tiempo = DateTime.Now.ToShortTimeString();
                string ruta = strPath + usuario.Trim() + DateTime.Now.Day.ToString() + '-' + DateTime.Now.Month.ToString() + '-' + DateTime.Now.Year.ToString() +  ".xls";
                string archivo = usuario.Trim() + DateTime.Now.Day.ToString() + '-' + DateTime.Now.Month.ToString() + '-' + DateTime.Now.Year.ToString() +  ".xls";

                FileStream fs = new FileStream(ruta, FileMode.Create,
                                     FileAccess.ReadWrite);
                w = new StreamWriter(fs);
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandTimeout = 10000;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = sp_informe;
                    cmd.Parameters.AddWithValue("@desde", desde);
                    cmd.Parameters.AddWithValue("@hasta", hasta);
                    cmd.Parameters.AddWithValue("@id_familia", id_familia);


                    SqlDataReader reader = cmd.ExecuteReader();
                    EscribeCabecera(reader, titulo);
                    EscribeLinea(reader);
                    EscribePiePagina();

                    w.Close();
                    sqlConn.Close();
                }

                return archivo;

            }



            #region Para sistema hipotecario

            public string ReporteHipotecario(string usuario, DataTable dt)
            {
                string strPath = ConfigurationManager.AppSettings["EXPORT_EXCEL"];

                string ruta = strPath + usuario.Trim() + DateTime.Now.Day.ToString() + '-' + DateTime.Now.Month.ToString() + '-' + DateTime.Now.Year.ToString() + ".xls";
                string archivo = usuario.Trim() + DateTime.Now.Day.ToString() + '-' + DateTime.Now.Month.ToString() + '-' + DateTime.Now.Year.ToString() + ".xls";

                var fs = new FileStream(ruta, FileMode.Create,
                                     FileAccess.ReadWrite);

                w = new StreamWriter(fs);    

                EscribeCabeceraHipotecario();
                EscribeLineaHipotecario(dt);
                EscribePiePagina();
                w.Close();
                fs.Close();

                return archivo;

            }

            public void EscribeCabeceraHipotecario()
            {
                var html = new StringBuilder();
                html.Append("<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.0 Transitional//EN\">");
                html.Append("<html>");
                html.Append("  <head>");
                html.Append("<title>www.devjoker.com</title>");
                html.Append("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" />");
                html.Append("  </head>");
                html.Append("<body>");
                html.Append("<p>");
                html.Append("<table>");
                html.Append("<tr><td colspan='10'>Operaciones hipotecarias</td></tr>");
                html.Append("<tr style=\"font-weight:bold;font-size: 12px;color: white;\">");

                html.Append("<td bgcolor=\"Darkcyan\">Id solicitud</td>");
                html.Append("<td bgcolor=\"Darkcyan\">Tipo operación</td>");
                html.Append("<td bgcolor=\"Darkcyan\">Cliente</td>");
                html.Append("<td bgcolor=\"Darkcyan\">Sucursal</td>");
                html.Append("<td bgcolor=\"Darkcyan\">Numero bco</td>");
                html.Append("<td bgcolor=\"Darkcyan\">Comprador</td>");
                html.Append("<td bgcolor=\"Darkcyan\">Rut</td>");
                html.Append("<td bgcolor=\"Darkcyan\">Actividad</td>");
                html.Append("<td bgcolor=\"Darkcyan\">Fecha inicio actividad</td>");
                html.Append("<td bgcolor=\"Darkcyan\">Horas laborales</td>");
                html.Append("<td bgcolor=\"Darkcyan\">Sla</td>");
                html.Append("<td bgcolor=\"Darkcyan\">Estado</td>");   

                html.Append("</tr>");

                w.Write(html.ToString());
            }

            public void EscribeLineaHipotecario(DataTable dt)
            {
                for (var i = 0; i < dt.Rows.Count;i++ )
                {
                    var dr = dt.Rows[i];
                    var html = new StringBuilder();
                    html.Append("<tr>");

                    html.Append("<td>" + dr["idSolicitud"].ToString() + "</td>");
                    html.Append("<td>" + dr["tipoOperacion"].ToString() + "</td>");
                    html.Append("<td>" + dr["cliente"].ToString() + "</td>");
                    html.Append("<td>" + dr["sucursal"].ToString() + "</td>");
                    html.Append("<td>" + dr["numeroBanco"].ToString() + "</td>");
                    html.Append("<td>" + dr["comprador"].ToString() + "</td>");
                    html.Append("<td>" + dr["rutComprador"].ToString() + "</td>");
                    html.Append("<td>" + dr["nombreActividad"].ToString() + "</td>");
                    html.Append("<td>" + dr["fechaInicio"].ToString() + "</td>");
                    html.Append("<td>" + dr["horasActividad"].ToString() + "</td>");
                    html.Append("<td>" + dr["sla"].ToString() + "</td>");
                    html.Append("<td><img src='" + dr["semaforo"].ToString() + "'/></td>");   
                    html.Append("</tr>"); 

                    w.Write(html.ToString());
                }     
            }

            #endregion

            #region Para preticket

            public string ReportePreticket(string usuario, DataTable dt)
            {
                string strPath = ConfigurationManager.AppSettings["EXPORT_EXCEL"];

                string ruta = strPath + usuario.Trim() + DateTime.Now.Day.ToString() + '-' + DateTime.Now.Month.ToString() + '-' + DateTime.Now.Year.ToString() + ".xls";
                string archivo = usuario.Trim() + DateTime.Now.Day.ToString() + '-' + DateTime.Now.Month.ToString() + '-' + DateTime.Now.Year.ToString() + ".xls";

                var fs = new FileStream(ruta, FileMode.Create,
                                     FileAccess.ReadWrite);

                w = new StreamWriter(fs);

                EscribeCabeceraPreticket();
                EscribeLineaPreticket(dt);
                EscribePiePagina();
                w.Close();
                fs.Close();

                return archivo;

            }

            public void EscribeCabeceraPreticket()
            {
                var html = new StringBuilder();
                html.Append("<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.0 Transitional//EN\">");
                html.Append("<html>");
                html.Append("  <head>");
                html.Append("<title>www.devjoker.com</title>");
                html.Append("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" />");
                html.Append("  </head>");
                html.Append("<body>");
                html.Append("<p>");
                html.Append("<table>");
                html.Append("<tr><td colspan='10'>AGP SA: Preticket</td></tr>");
                html.Append("<tr style=\"font-weight:bold;font-size: 12px;color: white;\">");

                html.Append("<td bgcolor=\"DarkSlateBlue\">Id</td>");
                html.Append("<td bgcolor=\"DarkSlateBlue\">Factura</td>");
                html.Append("<td bgcolor=\"DarkSlateBlue\">Cliente</td>");
                html.Append("<td bgcolor=\"DarkSlateBlue\">Sucursal</td>");
                html.Append("<td bgcolor=\"DarkSlateBlue\">Ejecutivo Ingreso</td>");
                html.Append("<td bgcolor=\"DarkSlateBlue\">Fecha de Ingreso</td>");
                html.Append("<td bgcolor=\"DarkSlateBlue\">Actividad</td>");
                html.Append("<td bgcolor=\"DarkSlateBlue\">Usuario Actual</td>");
                html.Append("<td bgcolor=\"DarkSlateBlue\">Fecha inicio actividad</td>");
                html.Append("<td bgcolor=\"DarkSlateBlue\">Horas laborales</td>");
                html.Append("<td bgcolor=\"DarkSlateBlue\">Sla</td>");
                html.Append("<td bgcolor=\"DarkSlateBlue\">Id Solicitud</td>");
                html.Append("<td bgcolor=\"DarkSlateBlue\">Estado AGP</td>");
                html.Append("</tr>");

                w.Write(html.ToString());
            }

            public void EscribeLineaPreticket(DataTable dt)
            {
                for (var i = 0; i < dt.Rows.Count; i++)
                {
                    var dr = dt.Rows[i];
                    var html = new StringBuilder();
                    html.Append("<tr>");

                    html.Append("<td>" + dr["idOrden"].ToString() + "</td>");
                    html.Append("<td>" + dr["numeroFactura"].ToString() + "</td>");
                    html.Append("<td>" + dr["cliente"].ToString() + "</td>");
                    html.Append("<td>" + dr["sucursal"].ToString() + "</td>");
                    html.Append("<td>" + dr["ejecutivoIngreso"].ToString() + "</td>");
                    html.Append("<td>" + dr["fechaIngreso"].ToString() + "</td>");
                    html.Append("<td>" + dr["nombreActividad"].ToString() + "</td>");
                    html.Append("<td>" + dr["usuarioActual"].ToString() + "</td>");
                    html.Append("<td>" + dr["fechaInicio"].ToString() + "</td>");
                    html.Append("<td>" + dr["horasActividad"].ToString() + "</td>");
                    html.Append("<td>" + dr["sla"].ToString() + "</td>");
                    html.Append("<td>" + dr["id_solicitud"].ToString() + "</td>");
                    html.Append("<td>" + dr["estado_agp"].ToString() + "</td>");
                    html.Append("</tr>");

                    w.Write(html.ToString());
                }
            }

            #endregion

            #region Para sistema CERTIFICADOS

            public string ReporteCErtificados(string usuario, DataTable dt)
            {
                string strPath = ConfigurationManager.AppSettings["EXPORT_EXCEL"];

                string ruta = strPath + usuario.Trim() + DateTime.Now.Day.ToString() + '-' + DateTime.Now.Month.ToString() + '-' + DateTime.Now.Year.ToString() + ".xls";
                string archivo = usuario.Trim() + DateTime.Now.Day.ToString() + '-' + DateTime.Now.Month.ToString() + '-' + DateTime.Now.Year.ToString() + ".xls";

                var fs = new FileStream(ruta, FileMode.Create,
                                     FileAccess.ReadWrite);

                w = new StreamWriter(fs);

                EscribeCabeceraCertificados();
                EscribeLineaCertificados(dt);
                EscribePiePagina();
                w.Close();
                fs.Close();

                return archivo;

            }

            public void EscribeCabeceraCertificados()
            {
                var html = new StringBuilder();
                html.Append("<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.0 Transitional//EN\">");
                html.Append("<html>");
                html.Append("  <head>");
                html.Append("<title>Informe AGP</title>");
                html.Append("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" />");
                html.Append("  </head>");
                html.Append("<body>");
                html.Append("<p>");
                html.Append("<table>");
                html.Append("<tr><td colspan='10'>Operaciones Certificados AGP</td></tr>");
                html.Append("<tr style=\"font-weight:bold;font-size: 12px;color: white;\">");

                html.Append("<td bgcolor=\"SlateBlue\">Patente</td>");
                html.Append("<td bgcolor=\"SlateBlue\">Fecha</td>");
                html.Append("<td bgcolor=\"SlateBlue\">Producto</td>");
                html.Append("<td bgcolor=\"SlateBlue\">Sucursal</td>");
                html.Append("<td bgcolor=\"SlateBlue\">Usuario</td>");
                html.Append("<td bgcolor=\"SlateBlue\">Marca</td>");
                html.Append("<td bgcolor=\"SlateBlue\">Propietario</td>");
                html.Append("<td bgcolor=\"SlateBlue\">Encargo por Robo</td>");
                html.Append("<td bgcolor=\"SlateBlue\">Limitacion al dominio</td>");
                html.Append("<td bgcolor=\"SlateBlue\">Monto estimado multas</td>");
                html.Append("<td bgcolor=\"SlateBlue\">Estado</td>");

                html.Append("</tr>");

                w.Write(html.ToString());
            }

            public void EscribeLineaCertificados(DataTable dt)
            {
                for (var i = 0; i < dt.Rows.Count; i++)
                {
                    var dr = dt.Rows[i];
                    var html = new StringBuilder();
                    html.Append("<tr>");

                    html.Append("<td>" + dr["patente"].ToString() + "</td>");
                    html.Append("<td>" + dr["fecha"].ToString() + "</td>");
                    html.Append("<td>" + dr["producto"].ToString() + "</td>");
                    html.Append("<td>" + dr["sucursal"].ToString() + "</td>");
                    html.Append("<td>" + dr["usuario"].ToString() + "</td>");
                    html.Append("<td>" + dr["marca"].ToString() + "</td>");
                    html.Append("<td>" + dr["propietario"].ToString() + "</td>");
                    html.Append("<td>" + dr["encargo_robo"].ToString() + "</td>");
                    html.Append("<td>" + dr["limitacion_dominio"].ToString() + "</td>");
                    html.Append("<td>" + dr["monto_multas"].ToString() + "</td>");
                    html.Append("<td>" + dr["estado"].ToString() + "</td>");
                    html.Append("</tr>");

                    w.Write(html.ToString());
                }
            }

            #endregion

        }

        



    }
}
