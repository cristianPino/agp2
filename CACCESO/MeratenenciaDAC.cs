using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;

namespace CACCESO
{
    public class MeratenenciaDAC : CACCESO.BaseDAC
    {

        public string add_meratenencia(Meratenencia meratenencia)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                try
                {
                    SqlCommand Cmd = new SqlCommand("sp_add_meratenencia", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_solicitud", meratenencia.Id_solicitud);
                    oParam = Cmd.Parameters.AddWithValue("@titulo_mera", meratenencia.Titulo_mera);
                    oParam = Cmd.Parameters.AddWithValue("@calidad_mero", meratenencia.Calidad_mero);
                    oParam = Cmd.Parameters.AddWithValue("@tipo_doc", meratenencia.Tipo_doc);
                    oParam = Cmd.Parameters.AddWithValue("@naturaleza_doc", meratenencia.Naturaleza_doc);
                    oParam = Cmd.Parameters.AddWithValue("@n_doc", meratenencia.N_doc);
                    oParam = Cmd.Parameters.AddWithValue("@lugar_doc", meratenencia.Lugar_doc);
                    oParam = Cmd.Parameters.AddWithValue("@fecha_doc", meratenencia.Fecha_doc);
                    oParam = Cmd.Parameters.AddWithValue("@autorizacion", meratenencia.Autorizacion);
                    oParam = Cmd.Parameters.AddWithValue("@anno_causa", meratenencia.Anno_causa);
                    oParam = Cmd.Parameters.AddWithValue("@tribunal", meratenencia.Tribunal);
                    oParam = Cmd.Parameters.AddWithValue("@rut_comprador", meratenencia.Rut_comprador);
                    oParam = Cmd.Parameters.AddWithValue("@rut_vendedor", meratenencia.Rut_vendedor);
                    oParam = Cmd.Parameters.AddWithValue("@n_bien", meratenencia.N_bien);
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

        public Meratenencia getmeratenencia(Int32 id_solicitud)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_meratenencia";
                    cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
                    SqlDataReader reader = cmd.ExecuteReader();
                    Meratenencia mmera = new Meratenencia();
                    if (reader.Read())
                    {
                        mmera.Anno_causa = Convert.ToInt32(reader["anno_causa"]);
                        mmera.Autorizacion = reader["autorizacion"].ToString();
                        mmera.Calidad_mero = reader["calidad_mero"].ToString();
                        mmera.Fecha_doc =Convert.ToDateTime(reader["fecha_doc"].ToString());
                        mmera.Id_solicitud =Convert.ToInt32(reader["id_solicitud"].ToString());
                        mmera.Lugar_doc = reader["lugar_doc"].ToString();
                        mmera.N_doc = reader["n_doc"].ToString();
                        mmera.Naturaleza_doc = reader["naturaleza_doc"].ToString();
                        mmera.Tipo_doc = reader["tipo_doc"].ToString();
                        mmera.Titulo_mera = reader["titulo_mera"].ToString();
                        mmera.Tribunal = reader["tribunal"].ToString();
                        mmera.N_bien = reader["n_bien"].ToString();
                    }
                    return mmera;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
