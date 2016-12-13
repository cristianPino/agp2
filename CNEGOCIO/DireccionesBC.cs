using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CACCESO;
using CENTIDAD;

namespace CNEGOCIO
{
	public class DireccionesBC
	{
		public List<Direcciones> getdirecciones(int rut)
		{
			List<Direcciones> ldireccion = new DireccionesDAC().getdirecciones(rut);
			return ldireccion;
		}

		public string add_direcciones(int rut, string direccion, string tipo_direccion, string numero, int comuna, string complemento, int id_direccion)
		{
			string add = new DireccionesDAC().add_direcciones(tipo_direccion, rut, numero, direccion, comuna, complemento, id_direccion);
			return add;
		}

		public string act_checkDireccion(int id_direccion, string check)
		{
			string add = new DireccionesDAC().act_checkDireccion(id_direccion, check);
			return add;
		}

		public Direcciones getDireccionPorDefecto(int rut)
		{
			return new DireccionesDAC().getDireccionPorDefecto(rut);
		}
	}
}