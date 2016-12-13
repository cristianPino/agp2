using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
    public class Infraccion
    {
        private Operacion operacion;

        public Operacion Operacion
        {
            get { return operacion; }
            set { operacion = value; }
        }
        private string patente;

        public string Patente
        {
            get { return patente; }
            set { patente = value; }
        }
        private Int32 rut;

        public Int32 Rut
        {
            get { return rut; }
            set { rut = value; }
        }
        private string tipo_infraccion;

        public string Tipo_infraccion
        {
            get { return tipo_infraccion; }
            set { tipo_infraccion = value; }
        }
      
        private DateTime fecha;

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        private string secursal_origen;

        public string Secursal_origen
        {
            get { return secursal_origen; }
            set { secursal_origen = value; }
        }
      
    }
}
