using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;

namespace CNEGOCIO
{
	public class DatosvehiculoBC
	{
		public List<DatosVehiculo> getDatosvehiculo(int id_solicitud)
		{
			List<DatosVehiculo> lDatosvehiculo = new DatosvehiculoDAC().getDatosvehiculo(id_solicitud);
			return lDatosvehiculo;
		}

		public DatosVehiculo getDatovehiculo(int id_solicitud)
		{
			return new DatosvehiculoDAC().getDatoVehiculo(id_solicitud);
		}
		
		public string add_Datosvehiculo(Int32 id_solicitud, Marcavehiculo marca, Tipovehiculo tipo_vehiculo, string patente,
                                        string dv, string modelo, string chassis, string motor, string vin, string serie, 
                                        int ano, string cilindraje, string color, int carga, int pesobruto, string combustible,
                                        int npuerta, int nasiento, Int32 kilometraje ,Int32 tasacion, string codigo_SII,
                                        Int32 precio,Int32 id_dato_vehiculo,DateTime fecha_contrato,string forma_pago,string prenda,
                                        string estado_vehiculo, Int32 rut_prenda, string financiamiento_amicar,string transmision, 
                                        string equipamiento, string codigo_banco ="0")
		{
			string add = new DatosvehiculoDAC().add_Datosvehiculo(id_solicitud, marca, tipo_vehiculo, patente, dv, modelo, chassis,
                                                                motor, vin, serie, ano, cilindraje, color, carga, pesobruto, 
                                                                combustible, npuerta, nasiento,kilometraje,precio,tasacion,codigo_SII,
                                                                id_dato_vehiculo, forma_pago, fecha_contrato, prenda, estado_vehiculo,
                                                                rut_prenda, financiamiento_amicar,transmision,equipamiento);
			return add;
		}

		public List<string> getListaModelosVehiculos(string modelo)
		{
			return new DatosvehiculoDAC().getListaModelosVehiculos(modelo);
		}

		public List<string> getListaColoresVehiculos(string color)
		{
			return new DatosvehiculoDAC().getListaColoresVehiculos(color);
		}

        public string del_Datosvehiculo(int id_solicitud)
        {
            string add = new DatosvehiculoDAC().del_vehiculos(id_solicitud);
            return add;
        }
        public string del_Datosvehiculo_id(int id_Dato_vehiculo)
        {
            string add = new DatosvehiculoDAC().del_vehiculos_id(id_Dato_vehiculo);
            return add;
        }

        public DatosVehiculo getDatovehiculobypatente(string patente)
        {
            return new DatosvehiculoDAC().getDatoVehiculobypatente(patente);
        }
		public DatosVehiculo getDatovehiculobyPatente_id_solicitud(string patente,Int32 id_solicitud)
		{
			return new DatosvehiculoDAC().getDatovehiculobyPatente_id_solicitud(patente, id_solicitud);
		}
	}
}