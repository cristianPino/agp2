using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;
namespace CACCESO
{
    public class AgendaDAC : CACCESO.BaseDAC
    {
        public string add_agenda(Int32 operacion, DateTime fecha_firma, string hora_firma, Int32 rut_persona, string cuenta_usuario, string ejecutivo, string tipoagenda, string useragp)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                try
                {
                    SqlCommand Cmd = new SqlCommand("sp_add_agenda", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_solicitud", operacion);
                    oParam = Cmd.Parameters.AddWithValue("@fecha_firma", fecha_firma);
                    oParam = Cmd.Parameters.AddWithValue("@hora_firma", hora_firma);
                    oParam = Cmd.Parameters.AddWithValue("@rut_persona", rut_persona);
                    oParam = Cmd.Parameters.AddWithValue("@cuenta_usuario", cuenta_usuario);
                    oParam = Cmd.Parameters.AddWithValue("@ejecutivo", ejecutivo);
                    oParam = Cmd.Parameters.AddWithValue("@TipoAgenda", tipoagenda);
                    oParam = Cmd.Parameters.AddWithValue("@useragp", useragp);
                    
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

        public string del_agenda(Int32 id_solicitud)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                try
                {
                    SqlCommand Cmd = new SqlCommand("sp_del_agenda", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
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

        public Agenda getAgenda(Int32 id_solicitud)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_agenda";
                    cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
                    SqlDataReader reader = cmd.ExecuteReader();
                    Agenda mAgenda = new Agenda();
                    if (reader.Read())
                    {
                        mAgenda.Id_solicitud = Convert.ToInt32((reader["id_solicitud"]));
                        mAgenda.Hora_firma = reader["hora_firma"].ToString();
                        mAgenda.Fecha_firma = Convert.ToDateTime(reader["fecha_firma"]);
                        mAgenda.N_intentos = Convert.ToInt32(reader["n_intentos"]);
                        mAgenda.Rut_persona = Convert.ToInt32(reader["rut_persona"]);
                        mAgenda.Ejecutivo = reader["ejecutivo"].ToString();
                        mAgenda.Tipoagenda = reader["TipoAgenda"].ToString();
                    }
                    return mAgenda;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Agenda> getAgendas(string usuario, string fecha)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "SP_R_GetAgendafromUser";
                    SqlParameter oParam = cmd.Parameters.AddWithValue("@user", usuario);
                    oParam = cmd.Parameters.AddWithValue("@fecha", fecha);
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<Agenda> lagenda = new List<Agenda>();
                    while (reader.Read())
                    {
                        Agenda magenda = new Agenda();
                        magenda.Id_solicitud = Convert.ToInt32(reader["id_solicitud"]);
                        magenda.Hora_firma = reader["hora"].ToString();
                        magenda.Estado = reader["estado"].ToString();
                        magenda.Cliente = reader["cliente"].ToString();
                        magenda.Direccion = reader["direccion"].ToString();
                        magenda.comuna = reader["Comuna"].ToString();
                        magenda.Telefono = reader["telefono"].ToString();
                        magenda.Celular = reader["celular"].ToString();
                        magenda.N_intentos = Convert.ToInt32(reader["intentos"]);
                        lagenda.Add(magenda);
                    }
                    return lagenda;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Agenda> getHoras()
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_gethoras";
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<Agenda> lagenda = new List<Agenda>();
                    while (reader.Read())
                    {
                        Agenda magenda = new Agenda();
                        magenda.Hora_firma = reader["horas"].ToString();

                        lagenda.Add(magenda);
                    }
                    return lagenda;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
