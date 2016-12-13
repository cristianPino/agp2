using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using CENTIDAD;

namespace CACCESO
{
	public class TipoClasificacionVehicularDAC : BaseDAC
	{
		public TipoClasificacionVehicular GetTipoClasificacionVehicular(int id_categoria)
		{
			try
			{
				using (SqlConnection cnn = new SqlConnection(this.strConn))
				{
					cnn.Open();
					SqlCommand cmd = new SqlCommand("sp_r_get_tipoclasificacionvehicular", cnn);
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@id_categoria", id_categoria);
					SqlDataReader dr = cmd.ExecuteReader();
					TipoClasificacionVehicular cls = new TipoClasificacionVehicular();
					if (dr.Read())
					{
						cls.Id_categoria = Convert.ToInt32(dr["id_categoria"]);
						cls.Descripcion = dr["descripcion"].ToString();
						cls.Anexo = Convert.ToBoolean(dr["anexo"]);
					}
					dr.Close();
					cnn.Close();
					return cls;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<TipoClasificacionVehicular> GetTipoClasificacionVehicularTodas()
		{
			try
			{
				using (SqlConnection cnn = new SqlConnection(this.strConn))
				{
					cnn.Open();
					SqlCommand cmd = new SqlCommand("sp_r_get_tipoclasificacionvehicular", cnn);
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@id_categoria", 0);
					SqlDataReader dr = cmd.ExecuteReader();
					List<TipoClasificacionVehicular> lcls = new List<TipoClasificacionVehicular>();
					while (dr.Read())
					{
						TipoClasificacionVehicular cls = new TipoClasificacionVehicular();
						cls.Id_categoria = Convert.ToInt32(dr["id_categoria"]);
						cls.Descripcion = dr["descripcion"].ToString();
						cls.Anexo = Convert.ToBoolean(dr["anexo"]);
						lcls.Add(cls);
					}
					dr.Close();
					cnn.Close();
					return lcls;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}