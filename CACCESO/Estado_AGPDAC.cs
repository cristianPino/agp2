using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;


namespace CACCESO
{
	public class Estado_AGPDAC : CACCESO.BaseDAC
	{
		public Estado_AGP get_estado_agp(int id_solicitud)
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					Estado_AGP estado = null;
					sqlConn.Open();
					SqlCommand Cmd = new SqlCommand("sp_r_estado_agp", sqlConn);
					Cmd.CommandType = CommandType.StoredProcedure;
					Cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
					SqlDataReader dr = Cmd.ExecuteReader();
					if (dr.Read())
					{
						estado = new Estado_AGP()
						{
							Id_solicitud = Convert.ToInt32(dr["id_solicitud"]),
							Factura = Convert.ToInt32(dr["factura"]),
							Fecha_factura = Convert.ToDateTime(dr["fecha_factura"]),
							Fecha_pago = Convert.ToDateTime(dr["fecha_pago"]),
							Pago = dr["pago"].ToString(),
							Proceso_agp = dr["proceso_agp"].ToString(),
							Repertorio_solicitado = Convert.ToBoolean(dr["repertorio_solicitado"])
						};
					}
					sqlConn.Close();
					return estado;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public string act_estado_AGP(Int32 id_solicitud, string proceso_AGP)
		{
			using (SqlConnection sqlConn = new SqlConnection(this.strConn))
			{
				sqlConn.Open();
				try
				{
					SqlCommand Cmd = new SqlCommand("sp_w_estado_agp", sqlConn);
					Cmd.CommandType = CommandType.StoredProcedure;
					Cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
					Cmd.Parameters.AddWithValue("@proceso_AGP", proceso_AGP);
					Cmd.ExecuteNonQuery();
					sqlConn.Close();
					return "";
				}
				catch (Exception ex)
				{
					return ex.Message;
				}
			}
		}

		public string act_repertorio_solicitado(int id_solicitud)
		{
			using (SqlConnection sqlConn = new SqlConnection(this.strConn))
			{
				sqlConn.Open();
				try
				{
					SqlCommand Cmd = new SqlCommand("sp_w_estado_agp_repertorio_solicitado", sqlConn);
					Cmd.CommandType = CommandType.StoredProcedure;
					Cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
					Cmd.ExecuteNonQuery();
					sqlConn.Close();
					return "";
				}
				catch (Exception ex)
				{
					return ex.Message;
				}
			}
		}
	}
}