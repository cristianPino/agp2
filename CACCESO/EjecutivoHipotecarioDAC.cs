using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using CENTIDAD;

namespace CACCESO
{
    public class EjecutivoHipotecarioDAC  : BaseDAC
    {
        public List<EjecutivoHipotecario> GetEjecutivoHipotecaBySucursal(int idSucursal)
        { 
            try
            {
                using (var sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();

                    var cmd = new SqlCommand(strConn, sqlConn)
                        {
                            CommandType = System.Data.CommandType.StoredProcedure,
                            CommandText = "sp_get_hipoteca_opeacion_ejecutivoBySucursal"
                        };

                    cmd.Parameters.AddWithValue("@id_sucursal", idSucursal);

                    var reader = cmd.ExecuteReader();
                    var lista = new List<EjecutivoHipotecario>();

                    while (reader.Read())
                    {  
                        var e = new EjecutivoHipotecario 
                        {
                            IdEjecutivo = Convert.ToInt32(reader["id_ejecutivo"]),
                            IdCliente = Convert.ToInt32(reader["id_cliente"]),
                            IdSucursal = Convert.ToInt32(reader["id_sucursal"]),
                            Nombre = reader["Nombre"].ToString(),
                            Apepat = reader["Apepat"].ToString(),
                            Apemat = reader["Apemat"].ToString(),
                            Cliente = new ClienteDAC().Getcliente(Convert.ToInt16(reader["id_cliente"])),
                            Sucursal = new SucursalclienteDAC().getSucursal(Convert.ToInt16(reader["id_sucursal"]))
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

      
    }
}
