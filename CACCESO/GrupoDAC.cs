using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;

namespace CACCESO
{
    public class GrupoDAC : CACCESO.BaseDAC
    {
        public Grupo getGrupo(Int32 id_grupo)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_get_grupo_familia";
                    cmd.Parameters.AddWithValue("@id_grupo", id_grupo);
                    SqlDataReader reader = cmd.ExecuteReader();
                    Grupo mGrupo = new Grupo();
                    if (reader.Read())
                    {
                        mGrupo.Id_grupo = Convert.ToInt32(reader["id_grupo"].ToString());
                        mGrupo.Descripcion = reader["descripcion"].ToString();
                    }
                    return mGrupo;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Grupo> getallGrupo()
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_getallgrupofamilia";
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<Grupo> lGrupo = new List<Grupo>();
                    while (reader.Read())
                    {
                        Grupo mGrupo = new Grupo();
                        mGrupo.Id_grupo = Convert.ToInt32(reader["id_grupo"].ToString());
                        mGrupo.Descripcion = reader["descripcion"].ToString();

                        lGrupo.Add(mGrupo);
                        mGrupo = null;
                    }
                    return lGrupo;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
            
        public string addgrupo(Int32 id_grupo, string descripcion)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_add_grupo_familia", sqlConn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_grupo", id_grupo);
                    cmd.Parameters.AddWithValue("@descripcion", descripcion);
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

       

        public string addEstadogrupo(Int32 id_grupo,Int32 codigo_estado)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_add_estado_grupo", sqlConn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_grupo", id_grupo);
                    cmd.Parameters.AddWithValue("@codigo_estado", codigo_estado);
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

        public string deleteEstadogrupo(Int32 codigo_estado)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_w_delete_grupo_estado", sqlConn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@codigo_estado", codigo_estado);
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

        public Grupo getEstadobycodigo(Int32 codigo_estado)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_get_estadogrupobycodigo";
                    cmd.Parameters.AddWithValue("@codigo_estado", codigo_estado);
                    SqlDataReader reader = cmd.ExecuteReader();
                    Grupo mGrupoFamilia = new Grupo();
                    if (reader.Read())
                    {
                        mGrupoFamilia.Id_grupo = Convert.ToInt32(reader["id_grupo"].ToString());
                        mGrupoFamilia.Codigo_estado = Convert.ToInt32(reader["codigo_estado"].ToString());
                    }
                    return mGrupoFamilia;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
