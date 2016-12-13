using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using CENTIDAD;

namespace CACCESO
{
    public class UsuarioEstadoDAC :BaseDAC
    {
        public List<UsuarioEstado>get_all(string cuentaUsuario, int idFamilia)
        {
            using (var sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                try
                {
                    var Cmd = new SqlCommand("sp_get_all_usuario_estado", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@cuenta_usuario", cuentaUsuario);
                    Cmd.Parameters.AddWithValue("@id_familia", idFamilia);

                    var reader = Cmd.ExecuteReader();
                    var lista = new List<UsuarioEstado>();
                    while(reader.Read())
                    {
                        var es = new UsuarioEstado();
                        es.NombreEstado = reader["descripcion"].ToString();
                        es.Pertenece = Convert.ToBoolean(reader["existe"]);
                        es.CodigoEstado = Convert.ToInt32(reader["codigo_estado"]);
                        es.SoloLectura = Convert.ToByte(reader["solo_lectura"]);
                        lista.Add(es);
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

        public void Upt(string cuentaUsuario, int codigoEstado, byte soloLectura)
        {
            using (var sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                try
                {
                    var Cmd = new SqlCommand("sp_up_usuario_estado", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@cuenta_usuario", cuentaUsuario);
                    Cmd.Parameters.AddWithValue("@codigo_estado", codigoEstado);
                    Cmd.Parameters.AddWithValue("@soloLectura", soloLectura);
                    Cmd.ExecuteNonQuery();
                   
                    sqlConn.Close();
                   }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void Del(string cuentaUsuario, int codigoEstado)
        {
            using (var sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                try
                {
                    var Cmd = new SqlCommand("sp_del_usuario_estado", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@cuenta_usuario", cuentaUsuario);
                    Cmd.Parameters.AddWithValue("@codigo_estado", codigoEstado);
                    Cmd.ExecuteNonQuery();

                    sqlConn.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
