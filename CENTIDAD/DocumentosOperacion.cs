using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD {
	public class DocumentosOperacion {
		private Int32 id_documento_operacion;
		private Int32 id_solicitud;
		private Int32 id_documento;
		private string nombre;
		private string url;
		private string extension;
		private Int64 peso;
		private Boolean publico;
		private string observaciones;
		
		public Int32 Id_documento_operacion {
			get { return id_documento_operacion; }
			set { id_documento_operacion = value; }
		}

		public Int32 Id_solicitud {
			get { return id_solicitud; }
			set { id_solicitud = value; }
		}

		public Int32 Id_documento {
			get { return id_documento; }
			set { id_documento = value; }
		}

		public string Nombre {
			get { return nombre; }
			set { nombre = value; }
		}

		public string Url {
			get { return url; }
			set { url = value; }
		}

		public string Extension {
			get { return extension; }
			set { extension = value; }
		}

		public Int64 Peso {
			get { return peso; }
			set { peso = value; }
		}

		public Boolean Publico {
			get { return publico; }
			set { publico = value; }
		}

		public string Observaciones
		{
			get { return observaciones; }
			set { observaciones = value; }
		}

        public string CuentaUsuario { get; set; }
        public string Fecha { get; set; }
        public Usuario Usuario { get; set; } 
	}
}
