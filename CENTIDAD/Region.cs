using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
	public class Region
	{
		private int id_region;

		public int Id_region
		{
			get { return id_region; }
			set { id_region = value; }
		}

		private string nombre;

		public string Nombre
		{
			get { return nombre; }
			set { nombre = value; }
		}

		private Pais pais;

		public Pais Pais
		{
			get { return pais; }
			set { pais = value; }
		}

		private string capital;

		public string Capital
		{
			get { return capital; }
			set { capital = value; }
		}
	}
}