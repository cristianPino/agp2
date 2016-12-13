using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;

namespace CNEGOCIO
{
	public class ParticipanteBC
	{
		public string add_participe(double rut_persona, double rut_participe, string tipo_participe, Boolean firma, string ciudad_notario, string notario_publico, DateTime fecha_participante)
		{
			return new ParticipanteDAC().add_Participante(rut_persona, rut_participe, tipo_participe, firma, ciudad_notario, notario_publico, fecha_participante);
		}

        public string del_participe(double rut_persona)
        {
            return new ParticipanteDAC().del_participantes(rut_persona);
        }

		public List<Participante> Getparticipante(double rut_persona)
		{
			return new ParticipanteDAC().GetParticipante(rut_persona);
		}
	}
}