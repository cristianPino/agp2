using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD {
	public class Documentos {
		private Int32 id_documento;
		private string nombre;
		private Boolean check;
		private Boolean publico;

		public Int32 Id_documento {
			get { return id_documento; }
			set { id_documento = value; }
		}

		public string Nombre {
			get { return nombre; }
			set { nombre = value; }
		}

		public Boolean Check {
			get { return check; }
			set { check = value; }
		}

		public Boolean Publico {
			get { return publico; }
			set { publico = value; }
		}
	}
}