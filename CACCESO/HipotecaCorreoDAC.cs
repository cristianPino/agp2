using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using CENTIDAD;

namespace CACCESO
{
    public class HipotecaCorreoDAC     :BaseDAC
    {
        public List<HipotecaCorreo> GetHipotecaCorreos (int idCliente, int idFamilia)
        {
            try
            {
                using (var sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    var cmd = new SqlCommand(strConn, sqlConn)
                        {CommandType = System.Data.CommandType.StoredProcedure, CommandText = "sp_get_Hipoteca_correo"};
                    cmd.Parameters.AddWithValue("@id_cliente", idCliente);
                    cmd.Parameters.AddWithValue("@id_familia", idFamilia);
                    SqlDataReader reader = cmd.ExecuteReader();
                    var lista = new List<HipotecaCorreo>();
                    while (reader.Read())
                    {
                        var h = new HipotecaCorreo();
                        h.IdCodigoEstado = Convert.ToInt32(reader["codigo_estado"]);
                        h.CorreoEjecutivoHipotecario = Convert.ToBoolean(reader["correo_ejecutivo_hipotecario"]);
                        h.CorreoVendedorHipotecario = Convert.ToBoolean(reader["correo_vendedor_hipotecario"]);
                        h.CorreoCompradorHipotecario = Convert.ToBoolean(reader["correo_comprador_hipotecario"]);
                        h.CorreoUsuariosOperacion = Convert.ToBoolean(reader["correo_usuarios_operacion"]);
                        h.CorreoListaCorreo = Convert.ToBoolean(reader["correo_lista_correo"]);
                        h.Lista = reader["lista"].ToString();
                        h.IdFormatoCorreo = Convert.ToInt32(reader["id_formato_correo"]);
                        h.DescripcionEstado = reader["descripcion"].ToString();
                        lista.Add(h);

                    }
                    return lista;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void UptCorreos(HipotecaCorreo hipoteca)
        {
            try
            {
                using (var sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    var cmd = new SqlCommand(strConn, sqlConn) { CommandType = System.Data.CommandType.StoredProcedure, CommandText = "up_hipotecaCorreo" };
                    cmd.Parameters.AddWithValue("@id_cliente", hipoteca.IdCliente);
                    cmd.Parameters.AddWithValue("@id_estado", hipoteca.IdCodigoEstado);
                    cmd.Parameters.AddWithValue("@correoEjecutivo", hipoteca.CorreoEjecutivoHipotecario);
                    cmd.Parameters.AddWithValue("@correoVendedor", hipoteca.CorreoVendedorHipotecario);
                    cmd.Parameters.AddWithValue("@correoComprador", hipoteca.CorreoCompradorHipotecario);
                    cmd.Parameters.AddWithValue("@correoUsuarios", hipoteca.CorreoUsuariosOperacion);
                    cmd.Parameters.AddWithValue("@correoLista", hipoteca.CorreoListaCorreo);
                    cmd.Parameters.AddWithValue("@id_formato_correo", hipoteca.IdFormatoCorreo);
                    cmd.Parameters.AddWithValue("@lista", hipoteca.Lista);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DelCorreos(HipotecaCorreo hipoteca)
        {
            try
            {
                using (var sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    var cmd = new SqlCommand(strConn, sqlConn) { CommandType = System.Data.CommandType.StoredProcedure, CommandText = "sp_del_hipoteca_correo" };
                    cmd.Parameters.AddWithValue("@id_cliente", hipoteca.IdCliente);
                    cmd.Parameters.AddWithValue("@id_estado", hipoteca.IdCodigoEstado);    

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
