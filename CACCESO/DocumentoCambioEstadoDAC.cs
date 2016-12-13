using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using CENTIDAD;
using System.Data;
namespace CACCESO
{
    public class DocumentoCambioEstadoDAC : BaseDAC
    {
        public List<DocumentoCambioEstado> GetAllDocumentosCambioEstado(int idFamilia, int idCliente)
        {
            try
            {
                using (var sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    var cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_get_documentoCambioEstado";
                    cmd.Parameters.AddWithValue("@id_cliente", idCliente);
                    cmd.Parameters.AddWithValue("@id_familia", idFamilia);
                    var reader = cmd.ExecuteReader();
                    var lista = new List<DocumentoCambioEstado>();
                    while (reader.Read())
                    {
                        var d = new DocumentoCambioEstado();
                        d.IdDocumento = Convert.ToInt32(reader["id_documento"]);
                        d.IdCliente = Convert.ToInt32(reader["id_cliente"]);
                        d.SiguienteCodigoEstado = Convert.ToInt32(reader["siguiente_codigo_estado"]);
                        d.IdFamilia = Convert.ToInt32(reader["id_familia"]);
                        d.NombreDocumento = reader["nombre"].ToString();
                        lista.Add(d);

                    }   
                    return lista;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddDocumentosCambioEstado(DocumentoCambioEstado doc)
        {
            try
            {
                using (var sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    var cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_add_documento_cambioEstado";
                    cmd.Parameters.AddWithValue("@id_documento", doc.IdDocumento);
                    cmd.Parameters.AddWithValue("@codigiSiguienteEstado", doc.SiguienteCodigoEstado);
                    cmd.Parameters.AddWithValue("@id_familia", doc.IdFamilia);
                    cmd.Parameters.AddWithValue("@id_cliente", doc.IdCliente);
                    cmd.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void DelDocumentosCambioEstado(DocumentoCambioEstado doc)
        {
            try
            {
                using (var sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    var cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_del_documento_cambioEstado";
                    cmd.Parameters.AddWithValue("@id_documento", doc.IdDocumento); 
                    cmd.Parameters.AddWithValue("@id_familia", doc.IdFamilia);
                    cmd.Parameters.AddWithValue("@id_cliente", doc.IdCliente);
                    cmd.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int GotoDocumentosCambioEstado(int idSolicitud,int idDocumento, string cuentausuario)
        {    
            var resp=0;
            try
            {
                using (var sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    var cmd = new SqlCommand(strConn, sqlConn)
                        {
                            CommandType = CommandType.StoredProcedure,
                            CommandText = "sp_goto_documento_cambio_estado"
                        };
                    cmd.Parameters.AddWithValue("@id_documento", idDocumento);
                    cmd.Parameters.AddWithValue("@cuenta_usuario", cuentausuario);
                    cmd.Parameters.AddWithValue("@id_solicitud",idSolicitud);
                    var reader = cmd.ExecuteReader();
                    if(reader.Read())
                    {
                        resp = Convert.ToInt32(reader["respuesta"]);
                    }
                    return resp;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
