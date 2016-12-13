using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD {
	public class TipoSolicitudRCProducto {

		private int id_solicrc_toper;

		public int ID {
			get { return id_solicrc_toper; }
			set { id_solicrc_toper = value; }
		}

		private int cod_solicrc;

		public int CodSolicRC {
			get { return cod_solicrc; }
			set { cod_solicrc = value; }
		}

		private string codigo;

		public string Codigo {
			get { return codigo; }
			set { codigo = value; }
		}

		private string desc_solicrc;

		public string DescSolicRC {
			get { return desc_solicrc; }
			set { desc_solicrc = value; }
		}

		private bool check;

		public bool Check {
			get { return check; }
			set { check = value; }
		}
	}
}