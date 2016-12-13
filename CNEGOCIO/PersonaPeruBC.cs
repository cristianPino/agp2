using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;

namespace CNEGOCIO
{
	public class PersonaPeruBC
	{
		public string AddPersona(string nro_documento_identidad, string tipo_documento_identidad, string nombres, string apellido_paterno, string apellido_materno, string estado_civil, string inscripcion_registral, string domicilio, Int16 id_comuna)
		{
			PersonaPeru persona = new PersonaPeru();
			persona.NroDocumentoIdentidad = nro_documento_identidad;
			persona.TipoDocumentoIdentidad = tipo_documento_identidad;
			persona.Nombres = nombres;
			persona.ApellidoPaterno = apellido_paterno;
			persona.ApellidoMaterno = apellido_materno;
			persona.EstadoCivil = estado_civil;
			persona.InscripcionRegistral = inscripcion_registral;
			persona.Domicilio = domicilio;
			persona.Comuna = new ComunaDAC().getComuna(Convert.ToInt16(id_comuna));
			return new PersonaPeruDAC().AddPersona(persona);
		}

		public PersonaPeru GetPersona(string nroDocumentoIdentidad, string tipoDocumentoIdentidad)
		{
			return new PersonaPeruDAC().GetPersona(nroDocumentoIdentidad, tipoDocumentoIdentidad);
		}
	}
}