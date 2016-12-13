using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;

namespace CACCESO
{
    public class Analisis_AlzaDAC : CACCESO.BaseDAC
    {

        public string add_analis_alza(string cod_financiera, int monto, string fecha_carta, string fecha_termino, Int32 id_solicitud,string fecha_otorgamiento)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                try
                {
                    SqlCommand Cmd = new SqlCommand("sp_add_analisis_alza", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@cod_financiera", cod_financiera);
                    Cmd.Parameters.AddWithValue("@monto", monto);
                    Cmd.Parameters.AddWithValue("@fecha_carta", fecha_carta);
                    Cmd.Parameters.AddWithValue("@fecha_termino", fecha_termino);
                    Cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
                    Cmd.Parameters.AddWithValue("@fecha_otorgamiento", fecha_otorgamiento);
                    Cmd.ExecuteNonQuery();
                    sqlConn.Close();
                    return "0";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
        }

        public Analisis_Alza getAnalis_alza(Int32 id_solicitud)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_analisis_alza";
                    cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
                    SqlDataReader reader = cmd.ExecuteReader();
                    Analisis_Alza manalisis = new Analisis_Alza();
                    while (reader.Read())
                    {
                        manalisis.Monto= Convert.ToInt32(reader["monto"].ToString());
                        manalisis.Fecha_carta = reader["fecha_carta"].ToString();
                        manalisis.Fecha_termino = reader["fecha_termino"].ToString();
                        manalisis.Cod_financiera = reader["cod_financiera"].ToString();
                        manalisis.Fecha_otorgamiento = reader["fecha_otorgamiento"].ToString();
                    }
                    return manalisis;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
