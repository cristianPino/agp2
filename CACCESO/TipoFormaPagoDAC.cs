using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using CENTIDAD;

namespace CACCESO
{
	public class TipoFormaPagoDAC : BaseDAC
	{
		public TipoFormaPago GetTipoFormaPago(int id_formapago)
		{
			try
			{
				using (SqlConnection cnn = new SqlConnection(this.strConn))
				{
					TipoFormaPago fp = new TipoFormaPago();
					cnn.Open();
					SqlCommand cmd = new SqlCommand("sp_r_get_tipo_formapago", cnn);
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@id_formapago", id_formapago);
					SqlDataReader dr = cmd.ExecuteReader();
					if (dr.Read())
					{
						fp.Id_FormaPago = Convert.ToInt32(dr["id_formapago"]);
						fp.Descripcion = dr["descripcion"].ToString();
						fp.Codigo = dr["codigo"].ToString();
					}
					dr.Close();
					cnn.Close();
					return fp;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<TipoFormaPago> GetTipoFormaPagoTodos()
		{
			try
			{
				using (SqlConnection cnn = new SqlConnection(this.strConn))
				{
					List<TipoFormaPago> lfp = new List<TipoFormaPago>();
					cnn.Open();
					SqlCommand cmd = new SqlCommand("sp_r_get_tipo_formapago", cnn);
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@id_formapago", 0);
					SqlDataReader dr = cmd.ExecuteReader();
					while (dr.Read())
					{
						TipoFormaPago fp = new TipoFormaPago();
						fp.Id_FormaPago = Convert.ToInt32(dr["id_formapago"]);
						fp.Descripcion = dr["descripcion"].ToString();
						fp.Codigo = dr["codigo"].ToString();
						lfp.Add(fp);
					}
					dr.Close();
					cnn.Close();
					return lfp;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}