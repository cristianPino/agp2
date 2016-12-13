using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;

namespace CACCESO 
{
    public class DocumentoEstadoDAC : CACCESO.BaseDAC
    {

        public string add_Documento_Estado(Int32 codigo_estado, Int32 id_documento)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                try
                {
                    SqlCommand Cmd = new SqlCommand("sp_add_Documento_Estado ", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@codigo_estado", codigo_estado);
                    Cmd.Parameters.AddWithValue("@id_documento", id_documento);
                    Cmd.ExecuteNonQuery();
                    sqlConn.Close();
                    return "";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
        }


        public string del_documento_estado(Int32 codigo_estado, Int32 id_documento)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                try
                {
                    SqlCommand Cmd = new SqlCommand("sp_del_documento_estado  ", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@codigo_estado", codigo_estado);
                    Cmd.Parameters.AddWithValue("@id_documento", id_documento);
                    Cmd.ExecuteNonQuery();
                    sqlConn.Close();
                    return "";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
        }


        public List<DocumentoEstado> DocumentosbyEstado(Int32 codigo_estado)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_DocumentosbyEstado ";
                    cmd.Parameters.AddWithValue("@codigo_estado", codigo_estado);
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<DocumentoEstado> ldocumento = new List<DocumentoEstado>();
                    while (reader.Read())
                    {
                        DocumentoEstado mdocumento = new DocumentoEstado();
                        mdocumento.Id_documento = Convert.ToInt32(reader["id_documento"].ToString());
                        mdocumento.Chk_doc = Convert.ToBoolean(reader["chk_doc"].ToString());

                        ldocumento.Add(mdocumento);
                        mdocumento = null;
                    }
                    return ldocumento;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
