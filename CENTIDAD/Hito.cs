using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
    public class Hito
    {
        private Int32 id_hito;

        public Int32 Id_hito
        {
            get { return id_hito; }
            set { id_hito = value; }
        }
        private Int32 id_estado;

        public Int32 Id_estado
        {
            get { return id_estado; }
            set { id_estado = value; }
        }
        private string observacion;

        public string Observacion
        {
            get { return observacion; }
            set { observacion = value; }
        }
        private string fecha;

        public string Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
        private Int32 tipo;

        public Int32 Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        private string semaforo;

        public string Semaforo
        {
            get { return semaforo; }
            set { semaforo = value; }
        }

    }
}
