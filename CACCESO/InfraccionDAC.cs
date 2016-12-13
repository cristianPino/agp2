using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using CENTIDAD;

namespace CACCESO
{
	public class InfraccionDAC : CACCESO.BaseDAC
	{

		public string add_Infraccion(Int32 id_solicitud, string patente, Int32 rut, string sucursal_origen)
		{

			using (SqlConnection sqlConn = new SqlConnection(this.strConn))
			{
				sqlConn.Open();

				try
				{


					SqlCommand Cmd = new SqlCommand("sp_w_infraccion", sqlConn);
					Cmd.CommandType = CommandType.StoredProcedure;
					SqlParameter oParam = Cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
					oParam = Cmd.Parameters.AddWithValue("@patente", patente);
					oParam = Cmd.Parameters.AddWithValue("@rut", rut);
					oParam = Cmd.Parameters.AddWithValue("@sucursal_origen", sucursal_origen);


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

		public Infraccion GetInfraccionbyIdSolicitud(Int32 id_solicitud)
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_infraccionbyIdSolicitud";
					cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
					SqlDataReader reader = cmd.ExecuteReader();
					Infraccion mInfraccion = new Infraccion();

					if (reader.Read())
					{
						mInfraccion.Operacion = new OperacionDAC().getOperacion(Convert.ToInt32(reader["id_solicitud"]));
						mInfraccion.Rut = Convert.ToInt32(reader["rut"]);
						mInfraccion.Patente = reader["patente"].ToString();
						mInfraccion.Secursal_origen = reader["sucursal_origen"].ToString();
					}
					else
					{ mInfraccion = null; }
					return mInfraccion;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public Infraccion Getinfraccionbypatente(Int32 id_cliente, string patente, string tipo_operacion)
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_infraccionbypatente";
					cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
					cmd.Parameters.AddWithValue("@patente", patente);
					cmd.Parameters.AddWithValue("@tipo_operacion", tipo_operacion);
					SqlDataReader reader = cmd.ExecuteReader();

					Infraccion minfraccion = new Infraccion();

					if (reader.Read())
					{
						minfraccion.Operacion = new OperacionDAC().getOperacion(Convert.ToInt32(reader["id_solicitud"]));
						minfraccion.Rut = Convert.ToInt32(reader["rut"]);
						minfraccion.Patente = reader["patente"].ToString();
						minfraccion.Secursal_origen = reader["sucursal_origen"].ToString();

					}
					else
					{ minfraccion = null; }
					return minfraccion;
				}

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}