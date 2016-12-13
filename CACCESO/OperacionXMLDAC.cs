using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using CENTIDAD;

namespace CACCESO {
	public class OperacionXMLDAC : CACCESO.BaseDAC {

		public OperacionXML getOperacionXML(int rut, string patente)
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_operacionesxml";
					cmd.Parameters.AddWithValue("@rut", rut);
					cmd.Parameters.AddWithValue("@patente", patente);
					SqlDataReader reader = cmd.ExecuteReader();
					OperacionXML mOperacion = new OperacionXML();
					while (reader.Read())
					{
						mOperacion.Id_solicitud = Convert.ToDouble(reader["id_solicitud"]);
						mOperacion.Vehiculo = new DatosvehiculoDAC().getDatoVehiculo(Convert.ToInt32(reader["id_solicitud"]));
						mOperacion.NumFactura = Convert.ToInt64(reader["n_factura"]);
						mOperacion.FechaFactura = Convert.ToDateTime(reader["fecha_factura"]);
						mOperacion.NetoFactura = Convert.ToInt64(reader["neto_factura"]);
						mOperacion.Adquirente = new PersonaDAC().getpersonabyrut(Convert.ToDouble(reader["rut"]));
					}
					return mOperacion;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public OperacionXML getOperacionXML_Por_Patente(string patente) {
			try {
				using (SqlConnection sqlConn = new SqlConnection(this.strConn)) {
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_operacionesxml_por_patente";
					cmd.Parameters.AddWithValue("@patente", patente);
					SqlDataReader reader = cmd.ExecuteReader();
					OperacionXML mOperacion = new OperacionXML();
					while (reader.Read()) {
						mOperacion.Id_solicitud = Convert.ToDouble(reader["id_solicitud"]);
						mOperacion.Vehiculo = new DatosvehiculoDAC().getDatoVehiculo(Convert.ToInt32(reader["id_solicitud"]));
						mOperacion.NumFactura = Convert.ToInt64(reader["n_factura"]);
						mOperacion.FechaFactura = Convert.ToDateTime(reader["fecha_factura"]);
						mOperacion.NetoFactura = Convert.ToInt64(reader["neto_factura"]);
						mOperacion.Adquirente = new PersonaDAC().getpersonabyrut(Convert.ToDouble(reader["rut"]));
					}
					return mOperacion;
				}
			} catch (Exception ex) {
				throw ex;
			}
		}

		public OperacionXML getOperacionXML_Por_motor(string motor)
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand(strConn, sqlConn);
					cmd.CommandType = System.Data.CommandType.StoredProcedure;
					cmd.CommandText = "sp_r_operacionesxml_por_motor";
					cmd.Parameters.AddWithValue("@motor", motor);
					SqlDataReader reader = cmd.ExecuteReader();
					OperacionXML mOperacion = new OperacionXML();
					while (reader.Read())
					{
						mOperacion.Id_solicitud = Convert.ToDouble(reader["id_solicitud"]);
						mOperacion.Vehiculo = new DatosvehiculoDAC().getDatoVehiculo(Convert.ToInt32(reader["id_solicitud"]));
						mOperacion.NumFactura = Convert.ToInt64(reader["n_factura"]);
						mOperacion.FechaFactura = Convert.ToDateTime(reader["fecha_factura"]);
						mOperacion.NetoFactura = Convert.ToInt64(reader["neto_factura"]);
						mOperacion.Adquirente = new PersonaDAC().getpersonabyrut(Convert.ToDouble(reader["rut"]));
					}
					return mOperacion;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

        public string act_valor_patente(string patente, Int32 monto)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                try
                {
                    SqlCommand Cmd = new SqlCommand("act_valor_patente", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@patente", patente);
                    oParam = Cmd.Parameters.AddWithValue("@monto", monto);
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

        public string act_valor_motor(string motor, Int32 monto)
        {
            using (SqlConnection sqlConn = new SqlConnection(this.strConn))
            {
                sqlConn.Open();
                try
                {
                    SqlCommand Cmd = new SqlCommand("act_valor_motor", sqlConn);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter oParam = Cmd.Parameters.AddWithValue("@motor", motor);
                    oParam = Cmd.Parameters.AddWithValue("@monto", monto);
                    //oParam = Cmd.Parameters.AddWithValue("@datos", "");
                    //oParam.Direction = ParameterDirection.Output;
                    SqlDataReader reader = Cmd.ExecuteReader();
                    string nTheNewId="";
                    while (reader.Read())
                    {
                         nTheNewId = reader["datos"].ToString();
                    }
                    sqlConn.Close();
                    return nTheNewId;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
           
        }



	}
}