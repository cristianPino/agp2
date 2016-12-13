using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
	public class PersonaPeru
	{
		private string nroDocumentoIdentidad;

		public string NroDocumentoIdentidad
		{
			get { return nroDocumentoIdentidad; }
			set { nroDocumentoIdentidad = value; }
		}

		private string tipoDocumentoIdentidad;

		public string TipoDocumentoIdentidad
		{
			get { return tipoDocumentoIdentidad; }
			set { tipoDocumentoIdentidad = value; }
		}

		private string nombres;

		public string Nombres
		{
			get { return nombres; }
			set { nombres = value; }
		}

		private string apellidoPaterno;

		public string ApellidoPaterno
		{
			get { return apellidoPaterno; }
			set { apellidoPaterno = value; }
		}

		private string apellidoMaterno;

		public string ApellidoMaterno
		{
			get { return apellidoMaterno; }
			set { apellidoMaterno = value; }
		}

		private string estadoCivil;

		public string EstadoCivil
		{
			get { return estadoCivil; }
			set { estadoCivil = value; }
		}

		private string inscripcionRegistral;

		public string InscripcionRegistral
		{
			get { return inscripcionRegistral; }
			set { inscripcionRegistral = value; }
		}

		private string domicilio;

		public string Domicilio
		{
			get { return domicilio; }
			set { domicilio = value; }
		}

		private Comuna comuna;

		public Comuna Comuna
		{
			get { return comuna; }
			set { comuna = value; }
		}
	}
}