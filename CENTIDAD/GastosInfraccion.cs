using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
    public class GastosInfraccion
    {
        private Operacion operacion;

        public Operacion Operacion
        {
            get { return operacion; }
            set { operacion = value; }
        }
        private string observacion;

        public string Observacion
        {
            get { return observacion; }
            set { observacion = value; }
        }
        private Int32 monto;

        public Int32 Monto
        {
            get { return monto; }
            set { monto = value; }
        }

        private string codigo;

        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        private string descripcion;

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        private string fecha;

        public string Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
    }
}
