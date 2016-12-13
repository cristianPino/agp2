using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
    public class FormaPago
    {
        private Int32 id_forma_pago;

        public Int32 Id_forma_pago
        {
            get { return id_forma_pago; }
            set { id_forma_pago = value; }
        }
        private Int32 id_cliente;

        public Int32 Id_cliente
        {
            get { return id_cliente; }
            set { id_cliente = value; }
        }
        private string descripcion;

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

    }
}
