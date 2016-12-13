using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using CENTIDAD;

namespace CACCESO
{
	public class ChequesFormaPagoDAC : BaseDAC
	{
		public string add_cheques_operacion(ChequesFormaPago cheque)
		{
			try
			{
				using (SqlConnection cnn = new SqlConnection(this.strConn))
				{
					cnn.Open();
					SqlCommand cmd = new SqlCommand("sp_add_cheques_operacion", cnn);
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@id_cheque", cheque.Id_cheque);
					cmd.Parameters.AddWithValue("@id_solicitud", cheque.Id_solicitud);
					cmd.Parameters.AddWithValue("@nro_cheque", cheque.Nro_cheque);
					cmd.Parameters.AddWithValue("@fecha_cheque", cheque.Fecha_cheque);
					cmd.Parameters.AddWithValue("@monto_cheque", cheque.Monto_cheque);
					
					if (cheque.Codigo_banco == "") cmd.Parameters.AddWithValue("@codigo_banco", DBNull.Value);
					else cmd.Parameters.AddWithValue("@codigo_banco", cheque.Codigo_banco);

					if (cheque.Nro_cuenta == "") cmd.Parameters.AddWithValue("@nro_cuenta", DBNull.Value);
					else cmd.Parameters.AddWithValue("@nro_cuenta", cheque.Nro_cuenta);

					cmd.ExecuteNonQuery();
					cnn.Close();
					return "";
				}
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}

		public string del_cheques_operacion(int id_solicitud)
		{
			try
			{
				using (SqlConnection cnn = new SqlConnection(this.strConn))
				{
					cnn.Open();
					SqlCommand cmd = new SqlCommand("sp_del_cheques_operacion", cnn);
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
					cmd.ExecuteNonQuery();
					cnn.Close();
					return "";
				}
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}

		public List<ChequesFormaPago> get_cheques_operacion(int id_solicitud)
		{
			try
			{
				using (SqlConnection cnn = new SqlConnection(this.strConn))
				{
					cnn.Open();
					SqlCommand cmd = new SqlCommand("sp_r_cheques_operacion", cnn);
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
					SqlDataReader dr = cmd.ExecuteReader();
					List<ChequesFormaPago> lch = new List<ChequesFormaPago>();
					while (dr.Read())
					{
						ChequesFormaPago ch = new ChequesFormaPago();
						ch.Id_cheque = Convert.ToInt32(dr["id_cheque"]);
						ch.Id_solicitud = Convert.ToInt32(dr["id_solicitud"]);
						ch.Nro_cheque = Convert.ToInt32(dr["nro_cheque"]);
						ch.Fecha_cheque = Convert.ToDateTime(dr["fecha_cheque"]);
						ch.Monto_cheque = Convert.ToInt32(dr["monto_cheque"]);
						ch.Codigo_banco = dr["codigo_banco"].ToString();
						ch.Nro_cuenta = dr["nro_cuenta"].ToString();
						lch.Add(ch);
					}
					dr.Close();
					cnn.Close();
					return lch;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
