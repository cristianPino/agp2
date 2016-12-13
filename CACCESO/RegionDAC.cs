using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;


namespace CACCESO
{
	public class RegionDAC : CACCESO.BaseDAC
	{

		public string add_region(Region region)
		{
			using (SqlConnection sqlConn = new SqlConnection(this.strConn))
			{
				sqlConn.Open();
				try
				{
					SqlCommand Cmd = new SqlCommand("sp_add_region", sqlConn);
					Cmd.CommandType = CommandType.StoredProcedure;
					SqlParameter oParam = Cmd.Parameters.AddWithValue("@codigo", region.Pais.Codigo);
					oParam = Cmd.Parameters.AddWithValue("@nombre", region.Nombre);
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

		public List<Region> getregionbypais(string codigo)
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_regionbypais";
					cmd.Parameters.AddWithValue("@codigo", codigo);
					SqlDataReader reader = cmd.ExecuteReader();
					List<Region> lRegion = new List<Region>();
					while (reader.Read())
					{
						Region mRegion = new Region();
						mRegion.Id_region = Convert.ToInt16(reader["id_region"]);
						mRegion.Nombre = reader["nombre"].ToString();
						mRegion.Pais = new PaisDAC().getpais(reader["codigo"].ToString());
						mRegion.Capital = reader["capital"].ToString();
						lRegion.Add(mRegion);
						mRegion = null;
					}
					return lRegion;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public Region getregion(Int16 id_region)
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_regiones";
					cmd.Parameters.AddWithValue("@id_region", id_region);
					SqlDataReader reader = cmd.ExecuteReader();
					Region mRegion = new Region();
					if (reader.Read())
					{
						mRegion.Id_region = Convert.ToInt16(reader["id_region"]);
						mRegion.Nombre = reader["nombre"].ToString();
						mRegion.Pais = new PaisDAC().getpais(reader["codigo"].ToString());
						mRegion.Capital = reader["capital"].ToString();
					}
					return mRegion;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}