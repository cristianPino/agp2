using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;

namespace CACCESO
{
    public class GastosInfraccionDAC : CACCESO.BaseDAC
    {

        public List<GastosInfraccion> GetGastosInfraccionbysolicitud(Int32 id_solicitud)
        {

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_infraccion";
                    cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<GastosInfraccion> linfraccion = new List<GastosInfraccion>();
                    while (reader.Read())
                    {
                        GastosInfraccion mInfraccion = new GastosInfraccion();

                        
                        mInfraccion.Descripcion = reader["descripcion"].ToString();
                        mInfraccion.Codigo = reader["codigo"].ToString();
                        mInfraccion.Observacion = reader["observacion"].ToString();
                        mInfraccion.Monto = Convert.ToInt32(reader["monto"].ToString());
                        mInfraccion.Fecha = reader["fecha"].ToString();
                        

                        linfraccion.Add(mInfraccion);
                        mInfraccion = null;

                    }
                    return linfraccion;


                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string add_gastosInfraccion(Int32 id_solicitud, string codigo, string observacion, Int32 monto,string fecha)
        {

            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();

                try
                {


                    SqlCommand Cmd = new SqlCommand("sp_w_gastosInfraccion", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
                    oParam = Cmd.Parameters.AddWithValue("@codigo", codigo);
                    oParam = Cmd.Parameters.AddWithValue("@observacion", observacion);
                    oParam = Cmd.Parameters.AddWithValue("@monto", monto);
                    oParam = Cmd.Parameters.AddWithValue("@fecha", fecha);


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
