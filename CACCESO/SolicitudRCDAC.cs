using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using CENTIDAD;

namespace CACCESO
{
	public class SolicitudRCDAC : BaseDAC
	{

		public string add_SolicitudRC(SolicitudRC solicitud)
		{
			using (SqlConnection cnn = new SqlConnection(this.strConn))
			{
				cnn.Open();
				try
				{
					SqlCommand cmd = new SqlCommand("sp_add_solicitudrc_operacion", cnn);
					cmd.CommandType = CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue("@id_solicitud", solicitud.Id_solicitud);
					cmd.Parameters.AddWithValue("@cod_solicrc", solicitud.Tipo_solicitud.CodSolicRC);
					cmd.Parameters.AddWithValue("@codigo_oficina_rc", solicitud.Oficina_rc.Codigo_oficina_rc);
					cmd.Parameters.AddWithValue("@nro_solicitud", solicitud.Nro_solicitud);
					cmd.Parameters.AddWithValue("@anio_solicitud", solicitud.Anio_solicitud);
					cmd.Parameters.AddWithValue("@estado_solicitud", solicitud.Estado_solicitud);
					cmd.Parameters.AddWithValue("@obs_solicitud", solicitud.Obs_solicitud);
					cmd.Parameters.AddWithValue("@fecha_solicitud", solicitud.Fecha_solicitud);
					cmd.ExecuteNonQuery();
					cnn.Close();
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}
			return "";
		}

		public List<SolicitudRC> get_SolicitudRC_Operacion(int id_solicitud)
		{
			using (SqlConnection cnn = new SqlConnection(this.strConn))
			{
				cnn.Open();
				try
				{
					SqlCommand cmd = new SqlCommand("sp_r_solicitudrc_operacion", cnn);
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
					SqlDataReader dr = cmd.ExecuteReader();
					List<SolicitudRC> lSolic = new List<SolicitudRC>();
					while (dr.Read())
					{
						SolicitudRC mSolic = new SolicitudRC();
						mSolic.Id_solicitud_rc = Convert.ToInt32(dr["id_solicitud_rc"]);
						mSolic.Id_solicitud = Convert.ToInt32(dr["id_solicitud"]);
						mSolic.Tipo_solicitud = new TipoSolicitudRCDAC().getTipoSolicitudRC(Convert.ToInt32(dr["cod_solicrc"]));
						mSolic.Oficina_rc = new OficinaRCDAC().get_OficinaRC(Convert.ToInt32(dr["codigo_oficina_rc"]));
						mSolic.Nro_solicitud = Convert.ToInt32(dr["nro_solicitud"]);
						mSolic.Anio_solicitud = Convert.ToInt32(dr["anio_solicitud"]);
						mSolic.Estado_solicitud = dr["estado_solicitud"].ToString();
						mSolic.Obs_solicitud = dr["obs_solicitud"].ToString();
						mSolic.Fecha_solicitud = Convert.ToDateTime(dr["fecha_solicitud"]);
						lSolic.Add(mSolic);
					}
					cnn.Close();
					return lSolic;
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}
		}

		public SolicitudRC get_SolicitudRC_Operacion_by_Id_solicitud_rc(int id_solicitud_rc)
		{
			using (SqlConnection cnn = new SqlConnection(this.strConn))
			{
				cnn.Open();
				try
				{
					SqlCommand cmd = new SqlCommand("sp_r_solicitudrc_operacion_by_id_solicitud_rc", cnn);
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@id_solicitud_rc", id_solicitud_rc);
					SqlDataReader dr = cmd.ExecuteReader();
					SolicitudRC mSolic = new SolicitudRC();
					if (dr.Read())
					{
						mSolic.Id_solicitud_rc = Convert.ToInt32(dr["id_solicitud_rc"]);
						mSolic.Id_solicitud = Convert.ToInt32(dr["id_solicitud"]);
						mSolic.Tipo_solicitud = new TipoSolicitudRCDAC().getTipoSolicitudRC(Convert.ToInt32(dr["cod_solicrc"]));
						mSolic.Oficina_rc = new OficinaRCDAC().get_OficinaRC(Convert.ToInt32(dr["codigo_oficina_rc"]));
						mSolic.Nro_solicitud = Convert.ToInt32(dr["nro_solicitud"]);
						mSolic.Anio_solicitud = Convert.ToInt32(dr["anio_solicitud"]);
						mSolic.Estado_solicitud = dr["estado_solicitud"].ToString();
						mSolic.Obs_solicitud = dr["obs_solicitud"].ToString();
						mSolic.Fecha_solicitud = Convert.ToDateTime(dr["fecha_solicitud"]);
					}
					cnn.Close();
					return mSolic;
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}
		}
	}
}