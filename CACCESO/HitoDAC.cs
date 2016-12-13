using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;

namespace CACCESO
{
    public class HitoDAC : CACCESO.BaseDAC
    {
        public string add_hito(Int32 id_estado, string observacion, string fecha,Int32 tipo)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                try
                {
                    SqlCommand Cmd = new SqlCommand("sp_add_hito", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@id_estado", id_estado);
                    Cmd.Parameters.AddWithValue("@observacion", observacion);
                    Cmd.Parameters.AddWithValue("@fecha", fecha);
                    Cmd.Parameters.AddWithValue("@tipo", tipo);
                    Cmd.ExecuteNonQuery();
                    sqlConn.Close();
                    return "";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
        }

        public List<Hito> getHitos(Int32 id_estado)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_hitos";
                    cmd.Parameters.AddWithValue("@id_estado", id_estado);
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<Hito> lhito = new List<Hito>();
                    while (reader.Read())
                    {
                        Hito mhito = new Hito();
                        mhito.Id_estado = Convert.ToInt32(reader["id_estado"].ToString());
                        mhito.Id_hito = Convert.ToInt32(reader["id_hito"].ToString());
                        mhito.Tipo = Convert.ToInt32(reader["tipo"].ToString());
                        mhito.Semaforo = reader["semaforo"].ToString();
                        mhito.Observacion = reader["observacion"].ToString();
                        mhito.Fecha = reader["fecha"].ToString();
                        lhito.Add(mhito);
                        mhito = null;
                    }
                    return lhito;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
