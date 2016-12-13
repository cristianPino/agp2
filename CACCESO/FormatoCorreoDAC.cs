using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using CENTIDAD;

namespace CACCESO
{
    public class FormatoCorreoDAC : BaseDAC
    {
        public List<FormatoCorreo> GetFortmatoCorreos()
        {
            try
            {
                using (var sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    var cmd = new SqlCommand(strConn, sqlConn) { CommandType = System.Data.CommandType.StoredProcedure, CommandText = "sp_get_formato_correos" };
                    SqlDataReader reader = cmd.ExecuteReader();
                    var lista = new List<FormatoCorreo>();
                    while (reader.Read())
                    {
                        var f = new FormatoCorreo();
                        f.IdFormatoCorreo = Convert.ToInt32(reader["id_formato_correo"]);
                        f.Descripción = reader["descripcion"].ToString();
                        f.ProcedimientoAlmacenado = reader["procedimiento_almacenado"].ToString();
                        lista.Add(f);

                    }
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
