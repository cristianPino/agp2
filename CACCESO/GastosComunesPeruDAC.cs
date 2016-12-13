using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using CENTIDAD;

namespace CACCESO
{
	public class GastosComunesPeruDAC : BaseDAC
	{
		public List<GastosComunesPeru> getallGastosComunes()
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_GastosComunesPeru";
					SqlDataReader reader = cmd.ExecuteReader();
					List<GastosComunesPeru> lGastosComunesPeru = new List<GastosComunesPeru>();
					while (reader.Read())					{
						GastosComunesPeru mGastosComunesPeru = new GastosComunesPeru();
						mGastosComunesPeru.Id_tipogasto = Convert.ToInt32(reader["id_tipogasto"].ToString());
						mGastosComunesPeru.Descripcion = reader["descripcion"].ToString();
						mGastosComunesPeru.Valor = Convert.ToInt32(reader["valor"].ToString());
						mGastosComunesPeru.Cargo_contable = Convert.ToBoolean(reader["cargo_contable"].ToString());
						mGastosComunesPeru.Transferencia = Convert.ToBoolean(reader["transferencia"].ToString());
						lGastosComunesPeru.Add(mGastosComunesPeru);
						mGastosComunesPeru = null;
					}
					return lGastosComunesPeru;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public string add_GastoasComunes(Int32 id_tipogasto, int valor, string descripcion, string cargo_contable, string transferencia)
		{
			using (SqlConnection sqlConn = new SqlConnection(this.strConn))
			{
				sqlConn.Open();
				try
				{
					SqlCommand Cmd = new SqlCommand("sp_add_GastosComunesPeru", sqlConn);
					Cmd.CommandType = CommandType.StoredProcedure;
					SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_tipogasto", id_tipogasto);
					oParam = Cmd.Parameters.AddWithValue("@valor", valor);
					oParam = Cmd.Parameters.AddWithValue("@descripcion", descripcion);
					oParam = Cmd.Parameters.AddWithValue("@cargo_contable", cargo_contable);
					oParam = Cmd.Parameters.AddWithValue("@transferencia", transferencia);
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

		public GastosComunesPeru getGastosComunes(Int32 id_tipogasto)
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_GastosComunesPeruDes";
					cmd.Parameters.AddWithValue("@id_tipogasto", id_tipogasto);
					SqlDataReader reader = cmd.ExecuteReader();
					GastosComunesPeru mGastosComunesPeru = new GastosComunesPeru();
					if (reader.Read())
					{
						mGastosComunesPeru.Id_tipogasto = Convert.ToInt32(reader["id_tipogasto"].ToString());
						mGastosComunesPeru.Descripcion = reader["descripcion"].ToString();
						mGastosComunesPeru.Valor = Convert.ToInt32(reader["valor"].ToString());
						mGastosComunesPeru.Cargo_contable = Convert.ToBoolean(reader["cargo_contable"].ToString());
					}
					return mGastosComunesPeru;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}