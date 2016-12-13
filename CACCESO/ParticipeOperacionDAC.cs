using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;
namespace CACCESO
{
    public class ParticipeOperacionDAC : CACCESO.BaseDAC
    {

        public string add_OperacionParticipe(Int32 id_solicitud, int rut, string tipo)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                try
                {
                    SqlCommand Cmd = new SqlCommand("sp_add_OperacionParticipe", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
                    Cmd.Parameters.AddWithValue("@rut", rut);
                    Cmd.Parameters.AddWithValue("@tipo", tipo);
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


        public List<ParticipeOperacion> getparticipe(Int32 id_solicitud)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_participe";
                    cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<ParticipeOperacion> lparticpe = new List<ParticipeOperacion>();
                    while (reader.Read())
                    {
                        ParticipeOperacion mparticipe = new ParticipeOperacion();
                        mparticipe.Participe =new PersonaDAC().getpersonabyrut(Convert.ToDouble(reader["rut"].ToString()));
                        mparticipe.Tipo = reader["tipo"].ToString();
                        lparticpe.Add(mparticipe);
                        mparticipe = null;
                    }
                    return lparticpe;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public ParticipeOperacion getparticipebytipo(Int32 id_solicitud,string tipo)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_participebytipo";
                    cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
                    cmd.Parameters.AddWithValue("@tipo", tipo);
                    SqlDataReader reader = cmd.ExecuteReader();
                    ParticipeOperacion mcorreo = new ParticipeOperacion();
                    while (reader.Read())
                    {
                        mcorreo.Participe =new PersonaDAC().getpersonabyrut(Convert.ToDouble(reader["rut"].ToString()));
                        mcorreo.Tipo = reader["tipo"].ToString();
                       
                    }
                    return mcorreo;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delparticipebytipo(int idsolicitud, string tipo, int rut)
        {
            try
            {
                using (var sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    var cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_del_participebytipo";
                    cmd.Parameters.AddWithValue("@id_solicitud", idsolicitud);
                    cmd.Parameters.AddWithValue("@rut", rut);
                    cmd.Parameters.AddWithValue("@tipo", tipo);
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

