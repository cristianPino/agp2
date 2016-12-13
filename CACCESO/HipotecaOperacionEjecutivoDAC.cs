using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using CENTIDAD;

namespace CACCESO
{
    public class HipotecaOperacionEjecutivoDAC :BaseDAC
    {
        public List<HipotecaOperacionEjecutivo> Get_hipoteca_operacion_ejecutivobyOperacion(int idSolicitud)
        {

            try
            {
                using (var sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();

                    var cmd = new SqlCommand(strConn, sqlConn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure,
                        CommandText = "sp_get_hipoteca_operacion_ejecutivobyOperacion"
                    };

                    cmd.Parameters.AddWithValue("@id_solicitud", idSolicitud);

                    var reader = cmd.ExecuteReader();
                    var lista = new List<HipotecaOperacionEjecutivo>();

                    while (reader.Read())
                    {
                        var e = new HipotecaOperacionEjecutivo
                        {
                            IdHipotecaOperacionEjecutivo = Convert.ToInt32(reader["id_hipoteca_operacion_ejecutivo"]),
                            IdEjecutivo = Convert.ToInt32(reader["id_ejecutivo"]),
                            IdCliente = Convert.ToInt32(reader["id_cliente"]),
                            IdSucursal = Convert.ToInt32(reader["id_sucursal"]),
                            Nombre = reader["Nombre"].ToString(),
                            Apepat = reader["Apepat"].ToString(),
                            Apemat = reader["Apemat"].ToString(),
                            Cliente = new ClienteDAC().Getcliente(Convert.ToInt16(reader["id_cliente"])),
                            Sucursal = new SucursalclienteDAC().getSucursal(Convert.ToInt16(reader["id_sucursal"])) ,
                            Mail = reader["mail"].ToString() 
                            
                        };
                        lista.Add(e);
                    }
                    sqlConn.Close();
                    return lista;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DelEjecutivoHipoteca(HipotecaOperacionEjecutivo hip)
        {
            try
            {
                using (var sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();

                    var cmd = new SqlCommand(strConn, sqlConn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure,
                        CommandText = "sp_del_hipoteca_opeacion_ejecutivo"
                    };

                    cmd.Parameters.AddWithValue("@id_hipoteca_operacion_ejecutivo", hip.IdHipotecaOperacionEjecutivo);
                    cmd.ExecuteNonQuery();
                    sqlConn.Close();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string AddEjecutivoHipoteca(HipotecaOperacionEjecutivo hip)
        {
            try
            {
                using (var sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();

                    var cmd = new SqlCommand(strConn, sqlConn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure,
                        CommandText = "sp_add_hipoteca_opeacion_ejecutivo"
                    };

                    cmd.Parameters.AddWithValue("@id_ejecutivo", hip.IdEjecutivo);
                    cmd.Parameters.AddWithValue("@id_solicitud", hip.IdSolicitud);
                    var reader = cmd.ExecuteReader();
                    var respuesta="";
                    if(reader.Read())
                    {
                        respuesta = reader["respuesta"].ToString();
                    }
                    sqlConn.Close();
                    return respuesta;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
