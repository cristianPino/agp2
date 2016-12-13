using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
	public class OficinaRC
	{
		private int codigo_oficina_rc;

		public int Codigo_oficina_rc
		{
			get { return codigo_oficina_rc; }
			set { codigo_oficina_rc = value; }
		}

		private string descripcion_oficina_rc;

		public string Descripcion_oficina_rc
		{
			get { return descripcion_oficina_rc; }
			set { descripcion_oficina_rc = value; }
		}

		private Region region_oficina_rc;

		public Region Region_oficina_rc
		{
			get { return region_oficina_rc; }
			set { region_oficina_rc = value; }
		}
	}
}
