using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD {
	public class TipoSolicitudRC {
		private Int32 cod_solicrc;

		public Int32 CodSolicRC {
			get { return cod_solicrc; }
			set { cod_solicrc = value; }
		}

		private string desc_solicrc;

		public string DescSolicRC {
			get { return desc_solicrc; }
			set { desc_solicrc = value; }
		}

		private string lista_correos;

		public string ListaCorreos
		{
			get { return lista_correos; }
			set { lista_correos = value; }
		}
	}
}