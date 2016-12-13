using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;
namespace CACCESO
{
    public class Leasing_transferenciaDAC : CACCESO.BaseDAC
    {
        public Leasing_transferencia GetLeasingById(Int32 id_solicitud)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_LeasingbyIdSolicitud";
                    cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
                    SqlDataReader reader = cmd.ExecuteReader();
                    
                    Leasing_transferencia mLeasing = new Leasing_transferencia();
                    
                    if (reader.Read())
                    {
                      
                        mLeasing.Fecha_contrato = Convert.ToDateTime(reader["fecha_contrato"]);
                        mLeasing.N_contrato = Convert.ToInt32(reader["n_contrato"].ToString());
                        mLeasing.Patente = reader["patente"].ToString();
                        mLeasing.Valor_cesion = Convert.ToInt32(reader["valor_cesion"].ToString());
                        mLeasing.Valor_opcion = Convert.ToInt32(reader["valor_opcion"].ToString());
                        mLeasing.N_vehiculos = Convert.ToInt32(reader["cantidad"].ToString());
                    } 
                   else
                   {
                        mLeasing = null;  
                    }
                        
                    
                    return mLeasing;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Leasing_transferencia> GetLeasingByIdSolicitud(Int32 id_solicitud)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_LeasingbyIdSolicitud";
                    cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<Leasing_transferencia> lLeasing = new List<Leasing_transferencia>();
                    while (reader.Read())
                    {
                        Leasing_transferencia mLeasing = new Leasing_transferencia();
                        mLeasing.Fecha_contrato = Convert.ToDateTime(reader["fecha_contrato"]);
                        mLeasing.N_contrato = Convert.ToInt32(reader["n_contrato"].ToString());
                        mLeasing.Patente = reader["patente"].ToString();
                        mLeasing.Valor_cesion = Convert.ToInt32(reader["valor_cesion"].ToString());
                        mLeasing.Valor_opcion = Convert.ToInt32(reader["valor_opcion"].ToString());
                        mLeasing.N_vehiculos = Convert.ToInt32(reader["cantidad"].ToString());
                        lLeasing.Add(mLeasing);
                        mLeasing = null;
                    }
                    return lLeasing;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string add_leasing(Int32 id_solicitud, string patente, DateTime fecha_contrato, Int32 n_contrato, Int32 valor_cesion, Int32 valor_opcion,Int32 n_vehiculos)
        {




            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();

                try
                {

                    SqlCommand Cmd = new SqlCommand("sp_w_leasing", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
                    oParam = Cmd.Parameters.AddWithValue("@patente", patente);
                    oParam = Cmd.Parameters.AddWithValue("@fecha_contrato", fecha_contrato);
                    oParam = Cmd.Parameters.AddWithValue("@n_contrato", n_contrato);
                    oParam = Cmd.Parameters.AddWithValue("@valor_cesion", valor_cesion);
                    oParam = Cmd.Parameters.AddWithValue("@valor_opcion", valor_opcion);
                    oParam = Cmd.Parameters.AddWithValue("@cantidad", n_vehiculos);

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

        public Leasing_transferencia getLeasing(string patente)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_LeasingbyPatente";
                    cmd.Parameters.AddWithValue("@patente", patente);
                    SqlDataReader reader = cmd.ExecuteReader();
                    Leasing_transferencia mLeasing = new Leasing_transferencia();
                    while (reader.Read())
                    {
                        mLeasing.Fecha_contrato = Convert.ToDateTime(reader["fecha_contrato"]);
                        mLeasing.N_contrato = Convert.ToInt32(reader["n_contrato"].ToString());
                        mLeasing.Patente = reader["patente"].ToString();
                        mLeasing.Valor_cesion = Convert.ToInt32(reader["valor_cesion"].ToString());
                        mLeasing.Valor_opcion = Convert.ToInt32(reader["valor_opcion"].ToString());
                        mLeasing.N_vehiculos = Convert.ToInt32(reader["cantidad"].ToString());
                    }
                    return mLeasing;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
