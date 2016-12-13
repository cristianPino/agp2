using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CACCESO;
using CENTIDAD;


namespace CNEGOCIO
{
	public class TelefonoBC
	{
		public List<Telefonos> gettelefonos(int rut)
		{
			List<Telefonos> ltelefonos = new TelefonosDAC().gettelefono(rut);
			return ltelefonos;
		}

		public string add_telefonos(int rut, string tipo_telefono, int numero, int id_telefono)
		{
			string add = new TelefonosDAC().add_telefonos(tipo_telefono, rut, numero, id_telefono);
			return add;
		}

		public string act_checkTelefonos(int id_telefono, string check)
		{
			string add = new TelefonosDAC().act_checkTelefonos(id_telefono, check);
			return add;
		}

		public Telefonos getTelefonoPorDefecto(int rut)
		{
			return new TelefonosDAC().getTelefonoPorDefecto(rut);
		}
	}
}