using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;

namespace CACCESO
{
    public class StockVentasDAC : CACCESO.BaseDAC
    {
       public string add_stockventas(Int32 id_solicitud, Int32 id_solicitud_venta,string estado_venta,Int32 id_dato_vehiculo, bool habilitada)
       {
           using (SqlConnection sqlConn = new SqlConnection(this.strConn))
           {
               sqlConn.Open();
               try
               {
                   SqlCommand Cmd = new SqlCommand("sp_add_stockventa", sqlConn);
                   Cmd.CommandType = CommandType.StoredProcedure;
                   SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
                   oParam = Cmd.Parameters.AddWithValue("@id_solicitud_venta", id_solicitud_venta);
                   oParam = Cmd.Parameters.AddWithValue("@estado_venta", estado_venta);
                   oParam = Cmd.Parameters.AddWithValue("@id_dato_vehiculo", id_dato_vehiculo);
				   oParam = Cmd.Parameters.AddWithValue("@habilitada", habilitada);
                   Cmd.ExecuteNonQuery();
                   sqlConn.Close();
               }
               catch (Exception ex)
               {
                   throw ex;
               }
           }
           return "";
       }

       public string del_stockventas(Int32 id_dato_vehiculo)
       {
           using (SqlConnection sqlConn = new SqlConnection(this.strConn))
           {
               sqlConn.Open();
               try
               {
                   SqlCommand Cmd = new SqlCommand("sp_del_stockventa", sqlConn);
                   Cmd.CommandType = CommandType.StoredProcedure;
                   SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_dato_vehiculo", id_dato_vehiculo);
              
                   Cmd.ExecuteNonQuery();
                   sqlConn.Close();
               }
               catch (Exception ex)
               {
                   throw ex;
               }
           }
           return "";
       }


       public string act_stockventas(Int32 id_solicitud)
       {
           using (SqlConnection sqlConn = new SqlConnection(this.strConn))
           {
               sqlConn.Open();
               try
               {
                   SqlCommand Cmd = new SqlCommand("sp_del_stock", sqlConn);
                   Cmd.CommandType = CommandType.StoredProcedure;
                   SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_solicitud_old", id_solicitud);

                   Cmd.ExecuteNonQuery();
                   sqlConn.Close();
               }
               catch (Exception ex)
               {
                   throw ex;
               }
           }
           return "";
       }

       public string act_stockventasImpuesto(Int32 id_solicitud,Int32 Impuesto)
       {
           using (SqlConnection sqlConn = new SqlConnection(this.strConn))
           {
               sqlConn.Open();
               try
               {
                   SqlCommand Cmd = new SqlCommand("sp_stock_imp", sqlConn);
                   Cmd.CommandType = CommandType.StoredProcedure;
                   SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
                   oParam = Cmd.Parameters.AddWithValue("@Impuesto", Impuesto);

                   Cmd.ExecuteNonQuery();
                   sqlConn.Close();
               }
               catch (Exception ex)
               {
                   throw ex;
               }
           }
           return "";
       }


       public string act_compra(Int32 id_solicitud)
       {
           using (SqlConnection sqlConn = new SqlConnection(this.strConn))
           {
               sqlConn.Open();
               try
               {
                   SqlCommand Cmd = new SqlCommand("sp_W_act_compra", sqlConn);
                   Cmd.CommandType = CommandType.StoredProcedure;
                   SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);

                   Cmd.ExecuteNonQuery();
                   sqlConn.Close();
               }
               catch (Exception ex)
               {
                   throw ex;
               }
           }
           return "";
       }

    }
}
