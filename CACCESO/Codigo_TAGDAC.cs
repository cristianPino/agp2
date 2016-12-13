using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;

namespace CACCESO
{
    public class Codigo_TAGDAC : CACCESO.BaseDAC
    {
        public string add_Codigo_TAG(string codigo_tag)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                try
                {
                    SqlCommand Cmd = new SqlCommand("sp_add_Codigo_TAG", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@Codigo_TAG", codigo_tag);
                    Cmd.ExecuteNonQuery();
                    sqlConn.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return "";
        }

        public string add_Control_TAG(string patente, Int32 id_solicitud,string tipo,string cuenta_usuario)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                try
                {
                    SqlCommand Cmd = new SqlCommand("sp_add_Control_TAG", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
                    oParam = Cmd.Parameters.AddWithValue("@patente", patente);
                    oParam = Cmd.Parameters.AddWithValue("@tipo", tipo);
                    oParam = Cmd.Parameters.AddWithValue("@cuenta_usuario", cuenta_usuario);
                    Cmd.ExecuteNonQuery();
                    sqlConn.Close();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            return "OK";
        }


        public List<Codigo_TAG> GetCodigosActivos(Int32 id_solicitud)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_Codigo_TAGActivos";
                    cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<Codigo_TAG> lCodigo = new List<Codigo_TAG>();
                    while (reader.Read())
                    {
                        Codigo_TAG mCodigo = new Codigo_TAG();
                        mCodigo.Id_tag = Convert.ToInt32(reader["id_tag"]);
                        mCodigo.Codigo = reader["codigo_TAG"].ToString();
                        mCodigo.Activo = Convert.ToBoolean(reader["activo"]);

                        lCodigo.Add(mCodigo);
                    }
                    return lCodigo;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<Codigo_TAG> GetCodigos()
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_Codigo_TAG";
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<Codigo_TAG> lCodigo = new List<Codigo_TAG>();
                    while (reader.Read())
                    {
                        Codigo_TAG mCodigo = new Codigo_TAG();
                        mCodigo.Id_tag = Convert.ToInt32(reader["id_tag"]);
                        mCodigo.Codigo = reader["codigo_TAG"].ToString();
                        mCodigo.Activo = Convert.ToBoolean(reader["activo"]);

                        lCodigo.Add(mCodigo);
                    }
                    return lCodigo;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
