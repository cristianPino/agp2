using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;
namespace CACCESO
{
    public class Movimiento_Cta_CteDAC : CACCESO.BaseDAC
    {
        public string add_mvimiento_cta(Int32 id_cta_cte, Int32 monto, DateTime fecha_hora, string tipo_movimiento, string usuario_movimiento)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                try
                {
                    SqlCommand Cmd = new SqlCommand("sp_add_movimiento_cta", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@usuario_movimiento", usuario_movimiento);
                    oParam = Cmd.Parameters.AddWithValue("@monto", monto);
                    oParam = Cmd.Parameters.AddWithValue("@id_cta_cte", id_cta_cte);
                    oParam = Cmd.Parameters.AddWithValue("@fecha_hora", fecha_hora);
                    oParam = Cmd.Parameters.AddWithValue("@tipo_movimiento", tipo_movimiento);
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

        public List<Movimiento_Cta_Cte> getCta_Cte(string cuenta_usuario)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_movimiento_cta_cte";
                    cmd.Parameters.AddWithValue("@cuenta_usuario", cuenta_usuario);
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<Movimiento_Cta_Cte> lmovimiento_cta_cte = new List<Movimiento_Cta_Cte>();
                    while (reader.Read())
                    {
                        Movimiento_Cta_Cte mmovimiento_cta_cte = new Movimiento_Cta_Cte();
                        mmovimiento_cta_cte.Fecha_hora =Convert.ToDateTime(reader["fecha"].ToString());
                        mmovimiento_cta_cte.Abono = Convert.ToInt32(reader["abono"].ToString());
                        mmovimiento_cta_cte.Carga = Convert.ToInt32(reader["cargo"].ToString());
                        lmovimiento_cta_cte.Add(mmovimiento_cta_cte);
                        mmovimiento_cta_cte = null;
                    }
                    return lmovimiento_cta_cte;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
