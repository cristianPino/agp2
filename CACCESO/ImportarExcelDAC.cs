using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Data.SqlClient;
using System.Data.Common;


namespace CACCESO
{
    public class ImportarExcelDAC : CACCESO.BaseDAC
    {

        public string importa_excel(string ruta)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                try
                {
                    SqlCommand Cmd = new SqlCommand("delete from TBL_PASO_RETIRO_AMICAR", sqlConn);
                    Cmd.CommandType = CommandType.Text;
                    Cmd.ExecuteNonQuery();
                    sqlConn.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            //Connection String to Excel Workbook

            try
            {

                string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + ruta + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";

                string query = "SELECT [reporte_agp] as f1 ,[f3],[f4],[f5],[f6],[f7],[f8],[f9],[f10],[f11],[f12],[f14],[f15],[f16] FROM [Cartola AGP$] where [reporte_agp] >1 ";
                //string query = "SELECT [reporte_agp] as f1 ,[f3],[f4],[f5],[f6],[f7],[f8],[f9],[f10],[f11],[f12],[f14],[f15],[f16] FROM [Reporte_AGP.rdl$] where [reporte_agp] >1 ";
                OleDbConnection conn = new OleDbConnection(connString);
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                OleDbCommand cmd = new OleDbCommand(query, conn);
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);

                DbDataReader dr = cmd.ExecuteReader();

                strConn = System.Configuration.ConfigurationManager.ConnectionStrings["CONECCION"].ConnectionString;

                SqlBulkCopy bulkInsert = new SqlBulkCopy(strConn);
                bulkInsert.DestinationTableName = "TBL_PASO_RETIRO_AMICAR";
                bulkInsert.WriteToServer(dr);



                da.Dispose();
                conn.Close();
                conn.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }


           


            return "";
        }


        public DataTable carga_operaciones_amicar()
        {
            DataTable dt = new DataTable();

            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
               
                try
                {
                    SqlCommand Cmd = new SqlCommand("SP_W_CARGA_RETIRO_AMICAR_PASO", sqlConn);
                    Cmd.CommandTimeout = 100000;
                    Cmd.CommandType = CommandType.StoredProcedure;
                    

                    SqlDataReader reader = Cmd.ExecuteReader();

                    

                    dt.Load(reader);


                    sqlConn.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return dt;
        
        }


        

    }
}
