using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using CENTIDAD;

namespace CACCESO
{
	public class TipoCarroceriaDAC : BaseDAC
	{

		public TipoCarroceria GetTipoCarroceria(int cod_tipo_carroceria)
		{
			using (SqlConnection cnn = new SqlConnection(this.strConn))
			{
				try
				{
					cnn.Open();
					SqlCommand cmd = new SqlCommand("sp_r_get_tipo_carroceria", cnn);
					cmd.CommandType = CommandType.StoredProcedure;
					SqlParameter param = new SqlParameter("@cod_tipo_carroceria", cod_tipo_carroceria);
					cmd.Parameters.Add(param);
					SqlDataReader dr = cmd.ExecuteReader();
					TipoCarroceria car = new TipoCarroceria();
					if (dr.Read())
					{
						car.Cod_tipo_carroceria = Convert.ToInt32(dr["cod_tipo_carroceria"]);
						car.Descripcion = dr["descripcion"].ToString();
					}
					dr.Close();
					cnn.Close();
					return car;
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}
		}

		public List<TipoCarroceria> GetTipoCarroceriaTodos()
		{
			using (SqlConnection cnn = new SqlConnection(this.strConn))
			{
				try
				{
					cnn.Open();
					SqlCommand cmd = new SqlCommand("sp_r_get_tipo_carroceria", cnn);
					cmd.CommandType = CommandType.StoredProcedure;
					SqlParameter param = new SqlParameter("@cod_tipo_carroceria", "0");
					cmd.Parameters.Add(param);
					SqlDataReader dr = cmd.ExecuteReader();
					List<TipoCarroceria> lcar = new List<TipoCarroceria>();
					while (dr.Read())
					{
						TipoCarroceria car = new TipoCarroceria();
						car.Cod_tipo_carroceria = Convert.ToInt32(dr["cod_tipo_carroceria"]);
						car.Descripcion = dr["descripcion"].ToString();
						lcar.Add(car);
					}
					dr.Close();
					cnn.Close();
					return lcar;
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}
		}
	}
}