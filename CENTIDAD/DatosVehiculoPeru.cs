using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
	public class DatosVehiculoPeru
	{
		private double idDatoVehiculoPeru;

		public double IdDatoVehiculoPeru
		{
			get { return idDatoVehiculoPeru; }
			set { idDatoVehiculoPeru = value; }
		}

		private int idSolicitud;

		public int IdSolicitud
		{
			get { return idSolicitud; }
			set { idSolicitud = value; }
		}

		private string numeroPlaca;

		public string NumeroPlaca
		{
			get { return numeroPlaca; }
			set { numeroPlaca = value; }
		}

		private string numeroVin;

		public string NumeroVin
		{
			get { return numeroVin; }
			set { numeroVin = value; }
		}

		private string numeroSerieVin;

		public string NumeroSerieVin
		{
			get { return numeroSerieVin; }
			set { numeroSerieVin = value; }
		}

		private Marcavehiculo marca;

		public Marcavehiculo Marca
		{
			get { return marca; }
			set { marca = value; }
		}

		private string modelo;

		public string Modelo
		{
			get { return modelo; }
			set { modelo = value; }
		}

		private string version;

		public string Version
		{
			get { return version; }
			set { version = value; }
		}

		private string aModelo;

		public string AModelo
		{
			get { return aModelo; }
			set { aModelo = value; }
		}

		private string aFabricacion;

		public string AFabricacion
		{
			get { return aFabricacion; }
			set { aFabricacion = value; }
		}

		private string claseCarroceria;

		public string ClaseCarroceria
		{
			get { return claseCarroceria; }
			set { claseCarroceria = value; }
		}

		private TipoClasificacionVehicular tipo_clasificacion;

		public TipoClasificacionVehicular Tipo_clasificacion
		{
			get { return tipo_clasificacion; }
			set { tipo_clasificacion = value; }
		}

		//private string carroceria;

		//public string Carroceria
		//{
		//    get { return carroceria; }
		//    set { carroceria = value; }
		//}

		private TipoCarroceria tipo_carroceria;

		public TipoCarroceria Tipo_carroceria
		{
			get { return tipo_carroceria; }
			set { tipo_carroceria = value; }
		}

		private string color;

		public string Color
		{
			get { return color; }
			set { color = value; }
		}

		private string numeroMotor;

		public string NumeroMotor
		{
			get { return numeroMotor; }
			set { numeroMotor = value; }
		}

		private string potenciaMotor;

		public string PotenciaMotor
		{
			get { return potenciaMotor; }
			set { potenciaMotor = value; }
		}

		private string combustible;

		public string Combustible
		{
			get { return combustible; }
			set { combustible = value; }
		}

		private string cilindrada;

		public string Cilindrada
		{
			get { return cilindrada; }
			set { cilindrada = value; }
		}

		private string cilindros;

		public string Cilindros
		{
			get { return cilindros; }
			set { cilindros = value; }
		}

		private string longitud;

		public string Longitud
		{
			get { return longitud; }
			set { longitud = value; }
		}

		private string numeroPasajeros;

		public string NumeroPasajeros
		{
			get { return numeroPasajeros; }
			set { numeroPasajeros = value; }
		}

		private string pesoNeto;

		public string PesoNeto
		{
			get { return pesoNeto; }
			set { pesoNeto = value; }
		}

		private string cargaUtil;

		public string CargaUtil
		{
			get { return cargaUtil; }
			set { cargaUtil = value; }
		}

		private string pesoBruto;

		public string PesoBruto
		{
			get { return pesoBruto; }
			set { pesoBruto = value; }
		}

		private string numeroAsientos;

		public string NumeroAsientos
		{
			get { return numeroAsientos; }
			set { numeroAsientos = value; }
		}

		private string numeroEjes;

		public string NumeroEjes
		{
			get { return numeroEjes; }
			set { numeroEjes = value; }
		}

		private string ancho;

		public string Ancho
		{
			get { return ancho; }
			set { ancho = value; }
		}

		private string numeroPuertas;

		public string NumeroPuertas
		{
			get { return numeroPuertas; }
			set { numeroPuertas = value; }
		}

		private string alto;

		public string Alto
		{
			get { return alto; }
			set { alto = value; }
		}

		private string numeroRuedas;

		public string NumeroRuedas
		{
			get { return numeroRuedas; }
			set { numeroRuedas = value; }
		}

		private string formulaRodante;

		public string FormulaRodante
		{
			get { return formulaRodante; }
			set { formulaRodante = value; }
		}

		private int cod_tipo_carroceria;

		public int Cod_tipo_carroceria
		{
			get { return cod_tipo_carroceria; }
			set { cod_tipo_carroceria = value; }
		}
	}
}