using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
    public class Participante
    {
        private string fecha_participante;

        public string Fecha_participante
        {
            get { return fecha_participante; }
            set { fecha_participante = value; }
        }
        private string ciudad_notario;

        public string Ciudad_notario
        {
            get { return ciudad_notario; }
            set { ciudad_notario = value; }
        }
        private string notario_publico;

        public string Notario_publico
        {
            get { return notario_publico; }
            set { notario_publico = value; }
        }
        private Persona persona;

        public Persona Persona
        {
            get { return persona; }
            set { persona = value; }
        }
        private Persona participe;

        public Persona Participe
        {
            get { return participe; }
            set { participe = value; }
        }
        private string tipo;

        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }
        private Boolean firma;

        public Boolean Firma
        {
            get { return firma; }
            set { firma = value; }
        }


    }
}
