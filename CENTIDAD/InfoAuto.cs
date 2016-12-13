using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD {
	public class InfoAuto {
	    public int CodigoEstado { set; get; }
	    public bool HabilitadoTransferencia { set; get; }
        public bool ConMuntas { set; get; }
	    public string UrlInforme { set; get; }
        public string EstadoFamilia { set; get; }
	    public string EncargoRobo { set; get; }
	    public string LimitacionDominio { set; get; }
	    public string RevisionTecnica { set; get; }
	    public string MontoMulta { set; get; }
        public string EjecutivoActual { set; get; }
        public string CorreoComprador { set; get; }
        public string IdSolicitudEncriptado { set; get; }
        public string PatenteEncriptado { set; get; }
        public int IdEstadoFamilia { get; set; }
        public string TipoOperacion { get; set; }
        public string DescripcionTipoOperacion { get; set; }
        public string Sucursal { get; set; }
	    public int TiempoTranscurrido { get; set; }
	    private Int32 estado_vehiculo;
        public string Usuario { get; set; }
        public int OrdenCompra { get; set; }
        public int IdCliente { get; set; }

        public int ChartMes { get; set; }
        public string ChartMesDescripcion { get; set; }
        public int ChartMesConteo { get; set; }

	    public Int32 Estado_vehiculo
        {
            get { return estado_vehiculo; }
            set { estado_vehiculo = value; }
        }
        public int IdSolicitudAsociado { get; set; }

        private int id_solicitud;

		public int Id_solicitud {
			get { return id_solicitud; }
			set { id_solicitud = value; }
		}

		private string marca;

        public string Marca
        {
			get { return marca; }
			set { marca = value; }
		}

        private string tipo_vehiculo;

        public string Tipo_vehiculo
        {
			get { return tipo_vehiculo; }
			set { tipo_vehiculo = value; }
		}
		
		private string patente = "";

		public string Patente {
			get { return patente; }
			set { patente = value; }
		}
		
		private string dv = "";

		public string Dv {
			get { return dv; }
			set { dv = value; }
		}

		private string modelo = "";

		public string Modelo {
			get { return modelo; }
			set { modelo = value; }
		}

		private string chassis = "";

		public string Chassis {
			get { return chassis; }
			set { chassis = value; }
		}

		private string motor = "";

		public string Motor {
			get { return motor; }
			set { motor = value; }
		}

		private string vin = "";

		public string Vin {
			get { return vin; }
			set { vin = value; }
		}

	

		private int ano = 0;

		public int Ano {
			get { return ano; }
			set { ano = value; }
		}



		private string color = "";

		public string Color {
			get { return color; }
			set { color = value; }
		}
		
		private string combustible = "BEN";

		public string Combustible {
			get { return combustible; }
			set { combustible = value; }
		}

        private string propietario_nombre;

        public string Propietario_nombre
        {
            get { return propietario_nombre; }
            set { propietario_nombre = value; }
        }
        private string propietario_rut;

        public string Propietario_rut
        {
            get { return propietario_rut; }
            set { propietario_rut = value; }
        }
        private string fechaAdquisicion;

        public string FechaAdquisicion
        {
            get { return fechaAdquisicion; }
            set { fechaAdquisicion = value; }
        }
        private string repertorio;

        public string Repertorio
        {
            get { return repertorio; }
            set { repertorio = value; }
        }
        private string aseguradora;

        public string Aseguradora
        {
            get { return aseguradora; }
            set { aseguradora = value; }
        }
        private string numPoliza;

        public string NumPoliza
        {
            get { return numPoliza; }
            set { numPoliza = value; }
        }
        private string fechaVencimientoPoliza;

        public string FechaVencimientoPoliza
        {
            get { return fechaVencimientoPoliza; }
            set { fechaVencimientoPoliza = value; }
        }

        private bool existe;

        public bool Existe
        {
            get { return existe; }
            set { existe = value; }
        }
     

	}
}