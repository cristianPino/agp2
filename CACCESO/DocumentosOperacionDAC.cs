using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;

namespace CACCESO
{
    public class DocumentosOperacionDAC : CACCESO.BaseDAC
    {
        public string add_documentos(Int32 id_solicitud, Int32 id_documento, string url, string extension, Int64 peso, string observaciones, string cuenta_usuario)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_add_documentos_operacion", sqlConn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@id_solicitud", id_solicitud));
                    cmd.Parameters.Add(new SqlParameter("@id_documento", id_documento));
                    cmd.Parameters.Add(new SqlParameter("@url", url));
                    cmd.Parameters.Add(new SqlParameter("@extension", extension));
                    cmd.Parameters.Add(new SqlParameter("@peso", peso));
                    cmd.Parameters.Add(new SqlParameter("@observaciones", observaciones));
                    cmd.Parameters.Add(new SqlParameter("@cuenta_usuario", cuenta_usuario));
                    cmd.ExecuteNonQuery();
                    sqlConn.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return "";
        }

        public string del_documentos(Int32 id_documento_operacion, string cuentaUsuario)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_del_documentos_operacion", sqlConn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@id_documento_operacion", id_documento_operacion));
                    cmd.Parameters.Add(new SqlParameter("@cuenta_usuario", cuentaUsuario));
                    cmd.ExecuteNonQuery();
                    sqlConn.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return "";
        }

        public List<DocumentosOperacion> getDocumentos(Int32 id_solicitud, Int32 id_documento)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();

                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_documentosbyoperacion";
                    cmd.Parameters.Add(new SqlParameter("@id_solicitud", id_solicitud));
                    cmd.Parameters.Add(new SqlParameter("@id_documento", id_documento));

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<DocumentosOperacion> lDocumentos = new List<DocumentosOperacion>();

                    while (reader.Read())
                    {
                        DocumentosOperacion mDocumentos = new DocumentosOperacion();
                        mDocumentos.Id_documento_operacion = Convert.ToInt32(reader["id_documento_operacion"]);
                        mDocumentos.Id_solicitud = Convert.ToInt32(reader["id_solicitud"]);
                        mDocumentos.Id_documento = Convert.ToInt32(reader["id_documento"]);
                        mDocumentos.Nombre = reader["nombre"].ToString();
                        mDocumentos.Url = reader["url"].ToString();
                        mDocumentos.Extension = reader["extension"].ToString();
                        mDocumentos.Peso = Convert.ToInt32(reader["peso"]);
                        mDocumentos.Publico = Convert.ToBoolean(reader["publico"]);
                        mDocumentos.Observaciones = reader["observaciones"].ToString();
                        mDocumentos.CuentaUsuario = reader["cuenta_usuario"].ToString();
                        mDocumentos.Fecha = reader["fecha_hora_upload"].ToString();
                        mDocumentos.Usuario = new Usuario { UserName = reader["cuenta_usuario"].ToString(), Nombre = reader["usuario_nombre"].ToString() };


                        lDocumentos.Add(mDocumentos);
                        mDocumentos = null;
                    }
                    return lDocumentos;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<DocumentosOperacion> getDocumentosAsociados(Int32 id_solicitud)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();

                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_documentosbyoperacion_asoc";
                    cmd.Parameters.Add(new SqlParameter("@id_solicitud", id_solicitud));

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<DocumentosOperacion> lDocumentos = new List<DocumentosOperacion>();

                    while (reader.Read())
                    {
                        DocumentosOperacion mDocumentos = new DocumentosOperacion();
                        mDocumentos.Id_documento_operacion = Convert.ToInt32(reader["id_documento_operacion"]);
                        mDocumentos.Id_solicitud = Convert.ToInt32(reader["id_solicitud"]);
                        mDocumentos.Id_documento = Convert.ToInt32(reader["id_documento"]);
                        mDocumentos.Nombre = reader["nombre"].ToString();
                        mDocumentos.Url = reader["url"].ToString();
                        mDocumentos.Extension = reader["extension"].ToString();
                        mDocumentos.Peso = Convert.ToInt32(reader["peso"]);
                        mDocumentos.Publico = Convert.ToBoolean(reader["publico"]);
                        mDocumentos.Observaciones = reader["observaciones"].ToString();

                        lDocumentos.Add(mDocumentos);
                        mDocumentos = null;
                    }
                    return lDocumentos;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<DocumentosOperacion> GetDocumentosTipoGastos(int idSolicitud)
        {
            using (var sqlConn = new SqlConnection(strConn))
            {
                sqlConn.Open();

                var cmd = new SqlCommand(strConn, sqlConn) { CommandType = CommandType.StoredProcedure, CommandText = "sp_r_documentos_tipo_gasto" };
                cmd.Parameters.Add(new SqlParameter("@id_solicitud", idSolicitud));

                var reader = cmd.ExecuteReader();

                var lDocumentos = new List<DocumentosOperacion>();

                while (reader.Read())
                {
                    var mDocumentos = new DocumentosOperacion();
                    mDocumentos.Id_documento_operacion = Convert.ToInt32(reader["id_documento_operacion"]);
                    mDocumentos.Id_solicitud = Convert.ToInt32(reader["id_solicitud"]);
                    mDocumentos.Id_documento = Convert.ToInt32(reader["id_documento"]);
                    mDocumentos.Nombre = reader["nombre"].ToString();
                    mDocumentos.Url = reader["url"].ToString();
                    mDocumentos.Extension = reader["extension"].ToString();
                    mDocumentos.Peso = Convert.ToInt32(reader["peso"]);
                    mDocumentos.Publico = Convert.ToBoolean(reader["publico"]);
                    mDocumentos.Observaciones = reader["observaciones"].ToString();
                    mDocumentos.CuentaUsuario = reader["cuenta_usuario"].ToString();
                    if (mDocumentos.Id_documento_operacion != 0)
                    {
                        mDocumentos.Usuario = new UsuarioDAC().GetusuariobyUsername(mDocumentos.CuentaUsuario);
                    }
                    lDocumentos.Add(mDocumentos);
                }
                sqlConn.Close();
                return lDocumentos;
            }
        }
    }
}