using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using CENTIDAD;

namespace CACCESO
{
	public class TipoMonedaDAC : BaseDAC
	{
		public TipoMoneda GetTipoMoneda(string cod_moneda)
		{
			using (SqlConnection cnn = new SqlConnection(this.strConn))
			{
				try
				{
					cnn.Open();
					SqlCommand cmd = new SqlCommand("sp_r_get_tipomoneda", cnn);
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@cod_moneda", cod_moneda);
					SqlDataReader dr = cmd.ExecuteReader();
					TipoMoneda mon = new TipoMoneda();
					if (dr.Read())
					{
						mon.Cod_moneda = dr["cod_moneda"].ToString();
						mon.Nombre = dr["nombre"].ToString();
						mon.Simbolo = dr["simbolo"].ToString();
					}
					cnn.Close();
					return mon;
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}
		}

		public List<TipoMoneda> GetTipoMonedaTodas()
		{
			using (SqlConnection cnn = new SqlConnection(this.strConn))
			{
				try
				{
					cnn.Open();
					SqlCommand cmd = new SqlCommand("sp_r_get_tipomoneda", cnn);
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@cod_moneda", "TODAS");
					SqlDataReader dr = cmd.ExecuteReader();
					List<TipoMoneda> lmon = new List<TipoMoneda>();
					while (dr.Read())
					{
						TipoMoneda mon = new TipoMoneda();
						mon.Cod_moneda = dr["cod_moneda"].ToString();
						mon.Nombre = dr["nombre"].ToString();
						mon.Simbolo = dr["simbolo"].ToString();
						lmon.Add(mon);
					}
					cnn.Close();
					return lmon;
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}
		}
	}
}