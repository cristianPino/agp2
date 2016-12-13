using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
    public class ParticipeOperacion
    {
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

    }
}
