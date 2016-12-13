using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using CENTIDAD;

namespace CACCESO
{
    public class InfoAutoProcesoDAC :BaseDAC
    {
        public List<InfoAutoProceso> Get_contenidoInformeDV(int idSolicitud)
        {
            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();
                try
                {
                    var cmd = new SqlCommand("sp_get_contenidoInformeDV", sqlConn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@id_solicitud", idSolicitud));
                    var reader = cmd.ExecuteReader();
                    var lista = new List<InfoAutoProceso>();
                    while (reader.Read())
                    {
                        var m = new InfoAutoProceso();
                        m.Estado = Convert.ToBoolean(reader["estado"]);
                        m.FechaInicio = reader["fecha_inicio"].ToString();
                        m.FechaTermino = reader["fecha_termino"].ToString() ?? "";
                        m.DescripcionPaso = reader["descripcion"].ToString() ?? "";
                        m.IdPaso = Convert.ToInt32(reader["id_dicom_vehiculo_pasos"]);
                        lista.Add(m);
                    }

                    sqlConn.Close();
                    return lista;

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
