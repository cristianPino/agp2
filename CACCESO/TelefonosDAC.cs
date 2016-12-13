using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;

namespace CACCESO
{
	public class TelefonosDAC : CACCESO.BaseDAC
	{
		public string add_telefonos(string tipo_telefono, int rut, int numero, int id_telefono)
		{
			using (SqlConnection sqlConn = new SqlConnection(this.strConn))
			{
				sqlConn.Open();
				try
				{
					SqlCommand Cmd = new SqlCommand("sp_add_telefonos", sqlConn);
					Cmd.CommandType = CommandType.StoredProcedure;
					Cmd.Parameters.AddWithValue("@tipo_telefono", tipo_telefono);
					Cmd.Parameters.AddWithValue("@rut", rut);
					Cmd.Parameters.AddWithValue("@numero", numero);
					Cmd.Parameters.AddWithValue("@id_telefono", id_telefono);
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

		public string act_checkTelefonos(int id_telefono, string check)
		{
			using (SqlConnection sqlConn = new SqlConnection(this.strConn))
			{
				sqlConn.Open();
				try
				{					
					SqlCommand Cmd = new SqlCommand("sp_act_checkTelefonos", sqlConn);
					Cmd.CommandType = CommandType.StoredProcedure;
					Cmd.Parameters.AddWithValue("@id_telefono", id_telefono);
					Cmd.Parameters.AddWithValue("@check", check);
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

		public Telefonos getTelefonoPorDefecto(int rut)
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_telefono_por_defecto";
					cmd.Parameters.AddWithValue("@rut", rut);
					SqlDataReader reader = cmd.ExecuteReader();
					Telefonos mtelefonos = new Telefonos();
                    if (reader.Read())
                    {
                        mtelefonos.Id_telefono = Convert.ToInt32(reader["id_telefono"].ToString());
                        mtelefonos.Rut = Convert.ToInt32(reader["rut"].ToString());
                        mtelefonos.Tipo_telefono = reader["tipo_telefono"].ToString();
                        mtelefonos.Numero = Convert.ToInt32(reader["numero"].ToString());
                        mtelefonos.Check = reader["prioridad"].ToString();
                    }
                    else
                    { mtelefonos = null; }


					return mtelefonos;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<Telefonos> gettelefono(int rut)
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_telefonos";
					cmd.Parameters.AddWithValue("@rut", rut);
					SqlDataReader reader = cmd.ExecuteReader();
					List<Telefonos> ltelefonos = new List<Telefonos>();
					while (reader.Read())
					{
						Telefonos mtelefonos = new Telefonos();
						mtelefonos.Id_telefono = Convert.ToInt32(reader["id_telefono"].ToString());
						mtelefonos.Rut = Convert.ToInt32(reader["rut"].ToString());
						mtelefonos.Tipo_telefono = reader["tipo_telefono"].ToString();
						mtelefonos.Numero = Convert.ToInt32(reader["numero"].ToString());
						mtelefonos.Check = reader["prioridad"].ToString();
						ltelefonos.Add(mtelefonos);
						mtelefonos = null;
					}
					return ltelefonos;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}