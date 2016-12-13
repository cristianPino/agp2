using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;

namespace CACCESO
{
	public class ComunaDAC : CACCESO.BaseDAC
	{
		public Comuna getComuna(Int16 id_comuna)
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_comuna";
					cmd.Parameters.AddWithValue("@id_comuna", id_comuna);
					SqlDataReader reader = cmd.ExecuteReader();
					Comuna mComuna = new Comuna();
					if (reader.Read())
					{
						mComuna.Id_Comuna = Convert.ToInt16(reader["id_Comuna"]);
						mComuna.Nombre = reader["nombre"].ToString();
						mComuna.Ciudad = new CiudadDAC().getciudad(Convert.ToInt16(reader["id_ciudad"]));
					}
					return mComuna;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<Comuna> getComunabyciudad(Int16 id_ciudad)
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_comunabyciudad";
					cmd.Parameters.AddWithValue("@id_ciudad", id_ciudad);
					SqlDataReader reader = cmd.ExecuteReader();
					List<Comuna> lComuna = new List<Comuna>();
					while (reader.Read())
					{
						Comuna mComuna = new Comuna();
						mComuna.Id_Comuna = Convert.ToInt16(reader["id_Comuna"]);
						mComuna.Nombre = reader["nombre"].ToString();
						mComuna.Ciudad = new CiudadDAC().getciudad(Convert.ToInt16(reader["id_ciudad"]));
						lComuna.Add(mComuna);
						mComuna = null;
					}
					return lComuna;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public string add_Comuna(Comuna Comuna)
		{
			using (SqlConnection sqlConn = new SqlConnection(this.strConn))
			{
				sqlConn.Open();
				try
				{
					SqlCommand Cmd = new SqlCommand("sp_add_Comuna", sqlConn);
					Cmd.CommandType = CommandType.StoredProcedure;
					SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_ciudad", Comuna.Ciudad.Id_Ciudad);
					oParam = Cmd.Parameters.AddWithValue("@nombre", Comuna.Nombre);
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

		public List<Comuna> getComunabyregion(Int16 id_region)
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_comunabyregion";
					cmd.Parameters.AddWithValue("@id_region", id_region);
					SqlDataReader reader = cmd.ExecuteReader();
					List<Comuna> lComuna = new List<Comuna>();
					while (reader.Read())
					{
						Comuna mComuna = new Comuna();
						mComuna.Id_Comuna = Convert.ToInt16(reader["id_Comuna"]);
						mComuna.Nombre = reader["nombre"].ToString();
						mComuna.Ciudad = new CiudadDAC().getciudad(Convert.ToInt16(reader["id_ciudad"]));
						lComuna.Add(mComuna);
						mComuna = null;
					}
					return lComuna;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}