using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using CENTIDAD;

namespace CACCESO
{
	public class DatosVehiculoPeruDAC : BaseDAC
	{
		public string AddVehiculo(DatosVehiculoPeru veh)
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand("sp_add_datosvehiculoperu", sqlConn);
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@id_dato_vehiculo_peru", veh.IdDatoVehiculoPeru);
					cmd.Parameters.AddWithValue("@id_solicitud", veh.IdSolicitud);
					cmd.Parameters.AddWithValue("@id_marca_vehiculo", veh.Marca.Id_marca);
					cmd.Parameters.AddWithValue("@numero_vin", veh.NumeroVin);
					cmd.Parameters.AddWithValue("@numero_serie_vin", veh.NumeroSerieVin);
					cmd.Parameters.AddWithValue("@modelo", veh.Modelo);
					cmd.Parameters.AddWithValue("@version", veh.Version);
					cmd.Parameters.AddWithValue("@a_modelo", veh.AModelo);
					cmd.Parameters.AddWithValue("@a_fabricacion", veh.AFabricacion);
					cmd.Parameters.AddWithValue("@clase_carroceria", veh.ClaseCarroceria);
					cmd.Parameters.AddWithValue("@carroceria", veh.Tipo_carroceria.Cod_tipo_carroceria);
					cmd.Parameters.AddWithValue("@color", veh.Color);
					cmd.Parameters.AddWithValue("@numero_motor", veh.NumeroMotor);
					cmd.Parameters.AddWithValue("@potencia_motor", veh.PotenciaMotor);
					cmd.Parameters.AddWithValue("@combustible", veh.Combustible);
					cmd.Parameters.AddWithValue("@cilindros", veh.Cilindros);
					cmd.Parameters.AddWithValue("@cilindrada", veh.Cilindrada);
					cmd.Parameters.AddWithValue("@longitud", veh.Longitud);
					cmd.Parameters.AddWithValue("@numero_pasajeros", veh.NumeroPasajeros);
					cmd.Parameters.AddWithValue("@peso_neto", veh.PesoNeto);
					cmd.Parameters.AddWithValue("@carga_util", veh.CargaUtil);
					cmd.Parameters.AddWithValue("@peso_bruto", veh.PesoBruto);
					cmd.Parameters.AddWithValue("@numero_asientos", veh.NumeroAsientos);
					cmd.Parameters.AddWithValue("@numero_ejes", veh.NumeroEjes);
					cmd.Parameters.AddWithValue("@ancho", veh.Ancho);
					cmd.Parameters.AddWithValue("@numero_puertas", veh.NumeroPuertas);
					cmd.Parameters.AddWithValue("@alto", veh.Alto);
					cmd.Parameters.AddWithValue("@numero_ruedas", veh.NumeroRuedas);
					cmd.Parameters.AddWithValue("@formula_rodante", veh.FormulaRodante);
					cmd.Parameters.AddWithValue("@id_categoria", veh.Tipo_clasificacion.Id_categoria);
					cmd.Parameters.AddWithValue("@numero_placa", veh.NumeroPlaca);
					cmd.Parameters.AddWithValue("@cod_tipo_carroceria", veh.Tipo_carroceria.Cod_tipo_carroceria);
					cmd.ExecuteNonQuery();
					sqlConn.Close();
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return "";
		}

		public DatosVehiculoPeru GetVehiculoByIdSolicitud(double id_solicitud)
		{
			try
			{
				using (SqlConnection sqlConn = new SqlConnection(this.strConn))
				{
					sqlConn.Open();
					SqlCommand cmd = new SqlCommand("sp_r_datosvehiculoperu_by_id_solicitud", sqlConn);
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Parameters.AddWithValue("@id_solicitud", id_solicitud);
					SqlDataReader dr = cmd.ExecuteReader();
					DatosVehiculoPeru veh = new DatosVehiculoPeru();
					if (dr.Read())
					{
						veh.IdDatoVehiculoPeru = Convert.ToDouble(dr["id_dato_vehiculo_peru"]);
						veh.IdSolicitud = Convert.ToInt32(dr["id_solicitud"]);
						veh.Marca = new MarcavehiculoDAC().getMarcavehiculo(Convert.ToInt32(dr["id_marca_vehiculo"]));
						veh.NumeroVin = dr["numero_vin"].ToString();
						veh.NumeroSerieVin = dr["numero_serie_vin"].ToString();
						veh.Modelo = dr["modelo"].ToString();
						veh.Version = dr["version"].ToString();
						veh.AModelo = dr["a_modelo"].ToString();
						veh.AFabricacion = dr["a_fabricacion"].ToString();
						veh.ClaseCarroceria = dr["clase_carroceria"].ToString();
						veh.Tipo_carroceria = new TipoCarroceriaDAC().GetTipoCarroceria(Convert.ToInt32(dr["cod_tipo_carroceria"]));
						veh.Tipo_clasificacion = new TipoClasificacionVehicularDAC().GetTipoClasificacionVehicular(Convert.ToInt32(dr["id_categoria"]));
						veh.Color = dr["color"].ToString();
						veh.NumeroMotor = dr["numero_motor"].ToString();
						veh.PotenciaMotor = dr["potencia_motor"].ToString();
						veh.Combustible = dr["combustible"].ToString();
						veh.Cilindros = dr["cilindros"].ToString();
						veh.Cilindrada = dr["cilindrada"].ToString();
						veh.Longitud = dr["longitud"].ToString();
						veh.NumeroPasajeros = dr["numero_pasajeros"].ToString();
						veh.PesoNeto = dr["peso_neto"].ToString();
						veh.CargaUtil = dr["carga_util"].ToString();
						veh.PesoBruto = dr["peso_bruto"].ToString();
						veh.NumeroAsientos = dr["numero_asientos"].ToString();
						veh.NumeroEjes = dr["numero_ejes"].ToString();
						veh.Ancho = dr["ancho"].ToString();
						veh.NumeroPuertas = dr["numero_puertas"].ToString();
						veh.Alto = dr["alto"].ToString();
						veh.NumeroRuedas = dr["numero_ruedas"].ToString();
						veh.FormulaRodante = dr["formula_rodante"].ToString();
						veh.NumeroPlaca = dr["numero_placa"].ToString();
					}
					dr.Close();
					sqlConn.Close();
					return veh;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}