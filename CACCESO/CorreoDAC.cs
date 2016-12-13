using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;

namespace CACCESO
{
	public class CorreoDAC : CACCESO.BaseDAC
	{
		public string add_correo(string correo, int rut, int id_correo)
		{
			using (SqlConnection sqlConn = new SqlConnection(this.strConn))
			{
				sqlConn.Open();
				try
				{
					SqlCommand Cmd = new SqlCommand("sp_add_correo", sqlConn);
					Cmd.CommandType = CommandType.StoredProcedure;
					Cmd.Parameters.AddWithValue("@correo", correo);
					Cmd.Parameters.AddWithValue("@rut", rut);
					Cmd.Parameters.AddWithValue("@id_correo", id_correo);
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

		public string act_check(int id_correo, string check)
		{
			using (SqlConnection sqlConn = new SqlConnection(this.strConn))
			{
				sqlConn.Open();
				try
				{
					SqlCommand Cmd = new SqlCommand("sp_act_checkCorreo", sqlConn);
					Cmd.CommandType = CommandType.StoredProcedure;
					SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_correo", id_correo);
					oParam = Cmd.Parameters.AddWithValue("@check", check);
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

		public Correo getCorreoPorDefecto(int rut)
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_correo_por_defecto";
					cmd.Parameters.AddWithValue("@rut", rut);
					SqlDataReader reader = cmd.ExecuteReader();
					Correo mcorreo = new Correo();
                    if (reader.Read())
                    {
                        mcorreo.Id_correo = Convert.ToInt32(reader["id_correo"].ToString());
                        mcorreo.Rut = Convert.ToInt32(reader["rut"].ToString());
                        mcorreo.Correo1 = reader["correo"].ToString();
                        mcorreo.Check = reader["prioridad"].ToString();
                    }
                    else

                    { mcorreo = null; }
					return mcorreo;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<Correo> getcorreo(int rut)
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_correo";
					cmd.Parameters.AddWithValue("@rut", rut);
					SqlDataReader reader = cmd.ExecuteReader();
					List<Correo> lcorreo = new List<Correo>();
					while (reader.Read())
					{
						Correo mcorreo = new Correo();
						mcorreo.Id_correo = Convert.ToInt32(reader["id_correo"].ToString());
						mcorreo.Rut = Convert.ToInt32(reader["rut"].ToString());
						mcorreo.Correo1 = reader["correo"].ToString();
						mcorreo.Check = reader["prioridad"].ToString();
						lcorreo.Add(mcorreo);
						mcorreo = null;
					}
					return lcorreo;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}