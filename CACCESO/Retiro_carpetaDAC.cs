using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;

namespace CACCESO
{
	public class Retiro_carpetaDAC : CACCESO.BaseDAC
	{



        public string add_retiro_carpeta(string rut_adquiriente, int num_credito, string ejecutivo, int id_solicitud, string financiera,
                        string concesionario, string prohibicion,string ot,string patente,string fecha_adjudicacion)
		{
			using (SqlConnection sqlConn = new SqlConnection(this.strConn))
			{
				sqlConn.Open();
				try
				{
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_add_retiro_carpeta";
					cmd.Parameters.AddWithValue("@rut_adquiriente", rut_adquiriente);
					cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
					cmd.Parameters.AddWithValue("@num_credito", num_credito);
					cmd.Parameters.AddWithValue("@ejecutivo", ejecutivo);
                    cmd.Parameters.AddWithValue("@financiera", financiera);
                    cmd.Parameters.AddWithValue("@concesionario", concesionario);
                    cmd.Parameters.AddWithValue("@prohibicion", prohibicion);
                    cmd.Parameters.AddWithValue("@ot", ot);
                    cmd.Parameters.AddWithValue("@patente", patente);
                    cmd.Parameters.AddWithValue("@fecha_adjudicacion", fecha_adjudicacion);
                    cmd.ExecuteNonQuery();
					sqlConn.Close();
				}
				catch (Exception ex)
				{
					throw ex;
				}
			return "";
			}
		}



        public Retiro_Carpeta getRetiroCarpeta(Int32 id_solicitud)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_getRetiroCarpeta";
                    cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
                    SqlDataReader reader = cmd.ExecuteReader();
                    Retiro_Carpeta mretiro = new Retiro_Carpeta();
                    if (reader.Read())
                    {
                        mretiro.Id_solicitud = Convert.ToInt32(reader["id_solicitud"].ToString());
                        mretiro.Num_credito = Convert.ToInt32(reader["num_credito"].ToString());
                        mretiro.Rut_adquiriente = Convert.ToInt32(reader["rut_adquiriente"].ToString());
                        mretiro.Ejecutivo = reader["ejecutivo"].ToString();
                        mretiro.Financiera = reader["financiera"].ToString();
                        mretiro.Concesionario = reader["concesionario"].ToString();
                        mretiro.Prohibicion = reader["prohibicion"].ToString();
                        mretiro.Codigo_ot = reader["codigo_ot"].ToString();
                        mretiro.Patente = reader["patente"].ToString();
                        mretiro.Fecha_adjudicacion = reader["fecha_adjudicacion"].ToString();
                    }
                    return mretiro;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Retiro_Carpeta getRetiroCarpetabycredito(Int32 credito)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(this.strConn))
                {
                    sqlConn.Open();
                    SqlCommand cmd = new SqlCommand(strConn, sqlConn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "sp_r_getRetiroCarpetabyCredito";
                    cmd.Parameters.AddWithValue("@credito", credito);
                    SqlDataReader reader = cmd.ExecuteReader();
                    Retiro_Carpeta mretiro = new Retiro_Carpeta();
                    if (reader.Read())
                    {
                        mretiro.Id_solicitud = Convert.ToInt32(reader["id_solicitud"].ToString());
                        mretiro.Num_credito = Convert.ToInt32(reader["num_credito"].ToString());
                        mretiro.Rut_adquiriente = Convert.ToInt32(reader["rut_adquiriente"].ToString());
                        mretiro.Ejecutivo = reader["ejecutivo"].ToString();
                        mretiro.Financiera = reader["financiera"].ToString();
                        mretiro.Concesionario = reader["concesionario"].ToString();
                        mretiro.Prohibicion = reader["prohibicion"].ToString();
                        mretiro.Codigo_ot = reader["codigo_ot"].ToString();
                        mretiro.Patente = reader["patente"].ToString();
                        mretiro.Fecha_adjudicacion = reader["fecha_adjudicacion"].ToString();
                    }
                    return mretiro;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



	}
}