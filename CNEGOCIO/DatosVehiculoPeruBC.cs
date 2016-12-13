using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;

namespace CNEGOCIO
{
	public class DatosVehiculoPeruBC
	{
		public string AddVehiculo(double id_dato_vehiculo_peru, int id_solicitud, int id_marca_vehiculo, string numero_vin, string numero_serie_vin, string modelo, string version, string a_modelo, string a_fabricacion, string clase_carroceria, string carroceria, string color, string numero_motor, string potencia_motor, string combustible, string cilindros, string cilindrada, string longitud, string numero_pasajeros, string peso_neto, string carga_util, string peso_bruto, string numero_asientos, string numero_ejes, string ancho, string numero_puertas, string alto, string numero_ruedas, string formula_rodante, int id_clasificacion, string numero_placa)
		{
			DatosVehiculoPeru veh = new DatosVehiculoPeru();
			veh.IdDatoVehiculoPeru = id_dato_vehiculo_peru;
			veh.IdSolicitud = id_solicitud;
			veh.Marca = new MarcavehiculoDAC().getMarcavehiculo(id_marca_vehiculo);
			veh.NumeroVin = numero_vin;
			veh.NumeroSerieVin = numero_serie_vin;
			veh.Modelo = modelo;
			veh.Version = version;
			veh.AModelo = a_modelo;
			veh.AFabricacion = a_fabricacion;
			veh.ClaseCarroceria = clase_carroceria;
			//veh.Carroceria = carroceria;
			veh.Tipo_carroceria = new TipoCarroceriaBC().GetTipoCarroceria(Convert.ToInt32(carroceria));
			veh.Tipo_clasificacion = new TipoClasificacionVehicularDAC().GetTipoClasificacionVehicular(id_clasificacion);
			veh.Color = color;
			veh.NumeroMotor = numero_motor;
			veh.PotenciaMotor = potencia_motor;
			veh.Combustible = combustible;
			veh.Cilindros = cilindros;
			veh.Cilindrada = cilindrada;
			veh.Longitud = longitud;
			veh.NumeroPasajeros = numero_pasajeros;
			veh.PesoNeto = peso_neto;
			veh.CargaUtil = carga_util;
			veh.PesoBruto = peso_bruto;
			veh.NumeroAsientos = numero_asientos;
			veh.NumeroEjes = numero_ejes;
			veh.Ancho = ancho;
			veh.NumeroPuertas = numero_puertas;
			veh.Alto = alto;
			veh.NumeroRuedas = numero_ruedas;
			veh.FormulaRodante = formula_rodante;
			veh.NumeroPlaca = numero_placa;
			return new DatosVehiculoPeruDAC().AddVehiculo(veh);
		}

		public DatosVehiculoPeru GetVehiculoByIdSolicitud(double id_solicitud)
		{
			return new DatosVehiculoPeruDAC().GetVehiculoByIdSolicitud(id_solicitud);
		}
	}
}