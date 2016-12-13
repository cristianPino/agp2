using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using CENTIDAD;

namespace CACCESO
{
    public class HipotecarioFirmaDAC : BaseDAC
    {
        public List<HipotecarioFirma> GetHipotecarioFirma(int idSolicitud)
        {
            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();
                var cmd = new SqlCommand(strConn, sqlConn) { CommandType = CommandType.StoredProcedure, CommandText = "sp_get_hipotecario_firma" };

                cmd.Parameters.AddWithValue("@id_solicitud", idSolicitud);

                cmd.CommandTimeout = 0;

                var reader = cmd.ExecuteReader();
                var lista = new List<HipotecarioFirma>();
                while (reader.Read())
                {
                    var hip = new HipotecarioFirma
                        {
                            IdHipotecarioFirma = Convert.ToInt32(reader["id_hipotecario_firma"]),
                            Titulo = reader["titulo"].ToString(),
                            FechaFirma = Convert.ToDateTime(reader["fecha_firma"]),
                            Existe = Convert.ToBoolean(reader["check"]),
                            Comentario = reader["comentario"].ToString(),
                            IdFirma = Convert.ToInt32(reader["id_firma"]),
                            UsuarioFirma = new UsuarioDAC().GetusuariobyUsername(reader["cuenta_usuario"].ToString())
                        };
                    lista.Add(hip);
                }

                sqlConn.Close();
                return lista;
            }
        }

        public void AddHipotecarioFirma(HipotecarioFirma h)
        {
            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();
                var cmd = new SqlCommand(strConn, sqlConn) { CommandType = CommandType.StoredProcedure, CommandText = "sp_add_hipotecarioFirma" };

                cmd.Parameters.AddWithValue("@idFirma", h.IdFirma);
                cmd.Parameters.AddWithValue("@idSolicitud", h.IdSolicitud);
                cmd.Parameters.AddWithValue("@cuentaUsuario", h.UsuarioFirma.UserName);
                cmd.Parameters.AddWithValue("@comentario", h.Comentario);
                cmd.ExecuteNonQuery();   
                sqlConn.Close();
             
            }
        }

    }
}
