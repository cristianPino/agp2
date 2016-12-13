using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using CENTIDAD;

namespace CACCESO
{
    public class HipotecaInsertoDAC        :BaseDAC
    {
        public HipotecaInserto GetInserto(int idInsertoTitulo, int idSolicitud)
        {
            try
            {
                using (var sqlConn = new SqlConnection(strConn))
                {
                    sqlConn.Open();
                    var cmd = new SqlCommand(strConn, sqlConn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure,
                        CommandText = "sp_get_hipoteca_inserto"
                    };
                    cmd.Parameters.AddWithValue("@id_inserto_titulo", idInsertoTitulo);
                    cmd.Parameters.AddWithValue("@id_solicitud", idSolicitud);
                    var reader = cmd.ExecuteReader();
                    var inserto = new HipotecaInserto();
                    if (reader.Read())
                    {
                        inserto.IdInsertoTitulo = Convert.ToInt32(reader["id_inserto"]);
                        inserto.IdInserto = Convert.ToInt32(reader["id_inserto_hipoteca"]);
                        inserto.Texto = reader["texto"].ToString();
                        inserto.Usuario = new UsuarioDAC().GetusuariobyUsername(reader["usuario"].ToString());
                        inserto.Fecha = Convert.ToDateTime(reader["fecha"]);
                        inserto.InsertoTitulo =  new HipotecaInsertoTituloDAC().GetInsertoTitulo(inserto.IdInsertoTitulo);
                    }
                    sqlConn.Close();
                    return inserto;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void DelInserto(int idInsertoHipoteca)
        {
            try
            {
                using (var sqlConn = new SqlConnection(strConn))
                {
                    sqlConn.Open();
                    var cmd = new SqlCommand(strConn, sqlConn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure,
                        CommandText = "sp_del_hipoteca_inserto"
                    };
                    cmd.Parameters.AddWithValue("@id_inserto_hipoteca", idInsertoHipoteca);
                 
                    cmd.ExecuteNonQuery();
                    sqlConn.Close();
                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddInserto(HipotecaInserto inserto)
        {
            try
            {
                using (var sqlConn = new SqlConnection(strConn))
                {
                    sqlConn.Open();
                    var cmd = new SqlCommand(strConn, sqlConn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure,
                        CommandText = "sp_add_hipoteca_inserto"
                    };
                    cmd.Parameters.AddWithValue("@id_inserto_hipoteca", inserto.IdInserto);
                    cmd.Parameters.AddWithValue("@id_solicitud", inserto.IdSolicitud);
                    cmd.Parameters.AddWithValue("@id_inserto", inserto.IdInsertoTitulo);
                    cmd.Parameters.AddWithValue("@texto", inserto.Texto);
                    cmd.Parameters.AddWithValue("@cuenta_usuario", inserto.CuentaUsuario);

                    cmd.ExecuteNonQuery();
                    sqlConn.Close();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HipotecaInserto> GetAllInserto(int idSolicitud)
        {
            try
            {
                using (var sqlConn = new SqlConnection(strConn))
                {
                    sqlConn.Open();
                    var cmd = new SqlCommand(strConn, sqlConn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure,
                        CommandText = "sp_get_all_hipoteca_inserto"
                    };
                    cmd.Parameters.AddWithValue("@id_solicitud", idSolicitud);
                    var reader = cmd.ExecuteReader();
                    var lista = new List<HipotecaInserto>();
                    while (reader.Read())
                    {
                        var inserto = new HipotecaInserto
                            {
                                IdInsertoTitulo = Convert.ToInt32(reader["id_inserto"]),
                                IdInserto = Convert.ToInt32(reader["id_inserto_hipoteca"]),
                                Texto = reader["texto"].ToString(),
                                Usuario = new UsuarioDAC().GetusuariobyUsername(reader["usuario"].ToString()),
                                Fecha = Convert.ToDateTime(reader["fecha"])
                            };
                        inserto.InsertoTitulo = new HipotecaInsertoTituloDAC().GetInsertoTitulo(inserto.IdInsertoTitulo);
                        lista.Add(inserto);
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
