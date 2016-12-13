using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using CENTIDAD;

namespace CACCESO
{
	public class SolicitudCertificadoDAC : BaseDAC
	{
		public string add_solicitud_certificado(SolicitudCertificado solicitud)
		{
			using (SqlConnection cnn = new SqlConnection(this.strConn))
			{
				try
				{
					cnn.Open();
					SqlCommand cmd = new SqlCommand("add_solicitud_certificado", cnn);
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@id_solicitud", solicitud.Operacion.Id_solicitud);
					cmd.Parameters.AddWithValue("@id_sucursal", solicitud.Sucursal.Id_sucursal);
					cmd.Parameters.AddWithValue("@patente", solicitud.Patente);
					cmd.ExecuteNonQuery();
					cnn.Close();
					return "";
				}
				catch (Exception ex)
				{
					return ex.Message;
				}
			}
		}

		public SolicitudCertificado get_solicitud_certificado(int id_solicitud)
		{
			using (SqlConnection cnn = new SqlConnection(this.strConn))
			{
				try
				{
					cnn.Open();
					SqlCommand cmd = new SqlCommand("r_solicitud_certificado", cnn);
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
					SqlDataReader dr = cmd.ExecuteReader();
					SolicitudCertificado certificado = null;
					if (dr.Read())
					{
						certificado = new SolicitudCertificado();
						certificado.Operacion = new OperacionDAC().getOperacion(Convert.ToInt32(dr["id_solicitud"]));
						certificado.Sucursal = new SucursalclienteDAC().getSucursal(Convert.ToInt16(dr["id_sucursal"]));
						certificado.Patente = dr["patente"].ToString();
					}
					cnn.Close();
					return certificado;
				}
				catch
				{
					return null;
				}
			}
		}
	}
}