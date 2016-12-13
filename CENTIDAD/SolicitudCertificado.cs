using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
	public class SolicitudCertificado
	{
		private Operacion operacion;

		public Operacion Operacion
		{
			get { return operacion; }
			set { operacion = value; }
		}

		private SucursalCliente sucursal;

		public SucursalCliente Sucursal
		{
			get { return sucursal; }
			set { sucursal = value; }
		}

		private string patente;

		public string Patente
		{
			get { return patente; }
			set { patente = value; }
		}
	}
}