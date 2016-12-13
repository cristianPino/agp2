using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD {
	public class OperacionXML {

		private double id_solicitud;

		public double Id_solicitud
		{
			get { return id_solicitud; }
			set { id_solicitud = value; }
		}

		private DatosVehiculo vehiculo;

		public DatosVehiculo Vehiculo {
			get { return vehiculo; }
			set { vehiculo = value; }
		}

		private Int64 numFactura;

		public Int64 NumFactura {
			get { return numFactura; }
			set { numFactura = value; }
		}

		private DateTime fechaFactura;

		public DateTime FechaFactura {
			get { return fechaFactura; }
			set { fechaFactura = value; }
		}

		private Int64 netoFactura;

		public Int64 NetoFactura {
			get { return netoFactura; }
			set { netoFactura = value; }
		}

		private Persona adquirente;

		public Persona Adquirente {
			get { return adquirente; }
			set { adquirente = value; }
		}
	}
}