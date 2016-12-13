using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
    public class Proceso_cierre
    {
        private Int32 id_cliente;

        public Int32 Id_cliente
        {
          get { return id_cliente; }
          set { id_cliente = value; }
        }

        public Int32 total_gasto { get; set; }
        public Int32 tramite { get; set; }
        public Int32 cant_oper { get; set; }
        public Int32 id_solicitud { get; set; }
        public string operacion { get; set; }
        public string familia { get; set; }
        public string codigo_operacion { get; set; }
        public string factura { get; set; }
        public string sucursal { get; set; }
        public string cliente { get; set; }
        public string patente { get; set; }

    }
}
