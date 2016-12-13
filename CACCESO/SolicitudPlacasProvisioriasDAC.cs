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
	public class SolicitudPlacasProvisioriasDAC : BaseDAC
	{
		public string add_solicitud_placas_provisorias(SolicitudPlacasProvisorias solicitud)
		{
			using (SqlConnection cnn = new SqlConnection(this.strConn))
			{
				try
				{
					cnn.Open();
					SqlCommand cmd = new SqlCommand("sp_add_solicitud_patente_provisoria", cnn);
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@id_solicitud", solicitud.Operacion.Id_solicitud);
					cmd.Parameters.AddWithValue("@id_sucursal", solicitud.Sucursal.Id_sucursal);
					cmd.Parameters.AddWithValue("@patente", solicitud.Patente);
					cmd.Parameters.AddWithValue("@rut", solicitud.Adquirente.Rut);
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

		public SolicitudPlacasProvisorias get_solicitud_placas_provisorias(int id_solicitud)
		{
			using (SqlConnection cnn = new SqlConnection(this.strConn))
			{
				try
				{
					cnn.Open();
					SqlCommand cmd = new SqlCommand("sp_r_solicitud_patente_provisoria", cnn);
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
					SqlDataReader dr = cmd.ExecuteReader();
					SolicitudPlacasProvisorias solicitud = null;
					if (dr.Read())
					{
						solicitud = new SolicitudPlacasProvisorias();
						solicitud.Operacion = new OperacionDAC().getOperacion(Convert.ToInt32(dr["id_solicitud"]));
						solicitud.Sucursal = new SucursalclienteDAC().getSucursal(Convert.ToInt16(dr["id_sucursal"]));
						solicitud.Patente = dr["patente"].ToString();
						solicitud.Adquirente = new PersonaDAC().getpersonabyrut(Convert.ToDouble(dr["rut"]));
					}
					cnn.Close();
					return solicitud;
				}
				catch
				{
					return null;
				}
			}
		}

		public SolicitudPlacasProvisorias get_solicitud_placas_provisorias(string patente)
		{
			using (SqlConnection cnn = new SqlConnection(this.strConn))
			{
				try
				{
					cnn.Open();
					SqlCommand cmd = new SqlCommand("sp_r_solicitud_patente_provisoria_por_patente", cnn);
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@patente", patente);
					SqlDataReader dr = cmd.ExecuteReader();
					SolicitudPlacasProvisorias solicitud = null;
					if (dr.Read())
					{
						solicitud = new SolicitudPlacasProvisorias();
						solicitud.Operacion = new OperacionDAC().getOperacion(Convert.ToInt32(dr["id_solicitud"]));
						solicitud.Sucursal = new SucursalclienteDAC().getSucursal(Convert.ToInt16(dr["id_sucursal"]));
						solicitud.Patente = dr["patente"].ToString();
						solicitud.Adquirente = new PersonaDAC().getpersonabyrut(Convert.ToDouble(dr["rut"]));
					}
					cnn.Close();
					return solicitud;
				}
				catch
				{
					return null;
				}
			}
		}
	}
}
