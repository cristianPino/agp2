using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using CENTIDAD;

namespace CACCESO
{
	public class OficinaRCDAC : BaseDAC
	{
		public string add_OficinaRC(OficinaRC oficina)
		{
			using (SqlConnection sqlConn = new SqlConnection(this.strConn))
			{
				sqlConn.Open();
				try
				{
					SqlCommand Cmd = new SqlCommand("sp_add_oficina_rc", sqlConn);
					Cmd.CommandType = CommandType.StoredProcedure;
					SqlParameter oParam = Cmd.Parameters.AddWithValue("@codigo_oficina_rc", oficina.Codigo_oficina_rc);
					oParam = Cmd.Parameters.AddWithValue("@descripcion_oficina_rc", oficina.Descripcion_oficina_rc);
					oParam = Cmd.Parameters.AddWithValue("@id_region", oficina.Region_oficina_rc.Id_region);
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

		public OficinaRC get_OficinaRC(int codigo_oficina_rc)
		{
			using (SqlConnection sqlConn = new SqlConnection(this.strConn))
			{
				sqlConn.Open();
				try
				{
					SqlCommand Cmd = new SqlCommand("sp_r_oficina_rc", sqlConn);
					Cmd.CommandType = CommandType.StoredProcedure;
					SqlParameter oParam = Cmd.Parameters.AddWithValue("@codigo_oficina_rc", codigo_oficina_rc);
					SqlDataReader dr = Cmd.ExecuteReader();
					OficinaRC mOficina = new OficinaRC();
					if (dr.Read())
					{
						mOficina.Codigo_oficina_rc = Convert.ToInt32(dr["codigo_oficina_rc"]);
						mOficina.Descripcion_oficina_rc = dr["descripcion_oficina_rc"].ToString();
						mOficina.Region_oficina_rc = new RegionDAC().getregion(Convert.ToInt16(dr["id_region"]));
					}
					sqlConn.Close();
					return mOficina;
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}
		}

		public List<OficinaRC> get_OficinasRC(int id_region)
		{
			using (SqlConnection sqlConn = new SqlConnection(this.strConn))
			{
				sqlConn.Open();
				try
				{
					SqlCommand Cmd = new SqlCommand("sp_r_lista_oficina_rc", sqlConn);
					Cmd.CommandType = CommandType.StoredProcedure;
					SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_region", id_region);
					SqlDataReader dr = Cmd.ExecuteReader();
					List<OficinaRC> lOficina = new List<OficinaRC>();
					while (dr.Read())
					{
						OficinaRC mOficina = new OficinaRC();
						mOficina.Codigo_oficina_rc = Convert.ToInt32(dr["codigo_oficina_rc"]);
						mOficina.Descripcion_oficina_rc = dr["descripcion_oficina_rc"].ToString();
						mOficina.Region_oficina_rc = new RegionDAC().getregion(Convert.ToInt16(dr["id_region"]));
						lOficina.Add(mOficina);
					}
					sqlConn.Close();
					return lOficina;
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}
		}
	}
}