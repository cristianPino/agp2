using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;

namespace CACCESO
{
    public class CreditBcaDAC : CACCESO.BaseDAC
    {
        public string add_agendaBCA(Int32 operacion, Int32 NRef, Int32 rut_persona, Int32 n_interno)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                try
                {
                    SqlCommand Cmd = new SqlCommand("sp_add_agendaBCA", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_solicitud", operacion);
                    oParam = Cmd.Parameters.AddWithValue("@rut_persona", rut_persona);
                    oParam = Cmd.Parameters.AddWithValue("@n_interno", n_interno);
                    oParam = Cmd.Parameters.AddWithValue("@Referencia", NRef);
                    
                    Cmd.ExecuteNonQuery();
                    sqlConn.Close();
                }
                catch (Exception)
                {
                    
                }
            }
            return "";
        }

        //public string del_agenda(Int32 id_solicitud)
        //{
        //    using (SqlConnection sqlConn = new SqlConnection(this.strConn))
        //    {
        //        sqlConn.Open();
        //        try
        //        {
        //            SqlCommand Cmd = new SqlCommand("sp_del_agenda", sqlConn);
        //            Cmd.CommandType = CommandType.StoredProcedure;
        //            SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
        //            Cmd.ExecuteNonQuery();
        //            sqlConn.Close();
        //        }
        //        catch (Exception ex)
        //        {
        //            throw ex;
        //        }
        //    }
        //    return "";
        //}

        public CreditBca getAgendaBCA(Int32 n_interno, Int32 rut_persona, string fecha_desde, string fecha_hasta )
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_agendaBCA";
                    SqlParameter oParam = cmd.Parameters.AddWithValue("@n_interno", n_interno);
                    oParam = cmd.Parameters.AddWithValue("@Rut", rut_persona);
                    oParam = cmd.Parameters.AddWithValue("@desde", fecha_desde);
                    oParam = cmd.Parameters.AddWithValue("@hasta", fecha_hasta);
                    SqlDataReader reader = cmd.ExecuteReader();
                    CreditBca mAgendaBCA = new CreditBca();
                    if (reader.Read())
                    {
                        mAgendaBCA.id_Interno = Convert.ToInt32(reader["id_solicitud"]);
                        mAgendaBCA.Id_Referencia = Convert.ToInt32(reader["NroReferencia"]);
                        mAgendaBCA.Id_CreditoBCA = Convert.ToInt32(reader["NcreditoBCA"]);
                        mAgendaBCA.RutCliente = new PersonaDAC().getpersonabyrut(Convert.ToDouble(reader["rut_persona"].ToString()));
                        mAgendaBCA.Oper = new EstadotipooperacionDAC().GETULTIMOESTADO(Convert.ToInt32(reader["id_solicitud"]));
                    }
                    return mAgendaBCA;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CreditBca> getListAgendasBCA(Int32 n_interno, Int32 rut_persona, string fecha_desde, string fecha_hasta)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_CreditoBCA";
                    SqlParameter oParam = cmd.Parameters.AddWithValue("@n_interno", n_interno);
                    oParam = cmd.Parameters.AddWithValue("@Rut", rut_persona);
                    oParam = cmd.Parameters.AddWithValue("@desde", fecha_desde);
                    oParam = cmd.Parameters.AddWithValue("@hasta", fecha_hasta);
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<CreditBca> lagenda = new List<CreditBca>();
                    while (reader.Read())
                    {
                        CreditBca magenda = new CreditBca();
                        magenda.id_Interno = Convert.ToInt32(reader["id_solicitud"]);
                        magenda.Id_Referencia = Convert.ToInt32(reader["NroReferencia"]);
                        magenda.Id_CreditoBCA = Convert.ToInt32(reader["NcreditoBCA"]);
                        magenda.RutCliente = new PersonaDAC().getpersonabyrut(Convert.ToDouble(reader["rut_persona"].ToString()));
                        magenda.Oper = new EstadotipooperacionDAC().GETULTIMOESTADO(Convert.ToInt32(reader["id_solicitud"]));
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
