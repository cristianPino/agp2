using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using CENTIDAD;

namespace CACCESO
{
	public class TipoGastoPeruDAC : BaseDAC
	{
		public TipoGastoPeru getTipoGastoPeru(Int16 id_tipogasto)
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_TipoGasto_Peru";
					cmd.Parameters.AddWithValue("@id_tipogasto", id_tipogasto);
					SqlDataReader reader = cmd.ExecuteReader();
					TipoGastoPeru mTipogasto = new TipoGastoPeru();
					if (reader.Read())
					{
						mTipogasto.Cliente = new ClienteDAC().Getcliente(Convert.ToInt16(reader["id_cliente"].ToString()));
						mTipogasto.Id_tipogasto = Convert.ToInt16(reader["id_tipogasto"].ToString());
						mTipogasto.Descripcion = reader["descripcion"].ToString();
						mTipogasto.Valor = Convert.ToDouble(reader["valor"].ToString());
						mTipogasto.Tipooperacion = new TipooperacionDAC().getTipooperacion(reader["tipo_operacion"].ToString());
						mTipogasto.Cargo_contable = Convert.ToBoolean(reader["cargo_contable"].ToString());
					}
					return mTipogasto;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}