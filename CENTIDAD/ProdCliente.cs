using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
    public class ProdCliente
    {
        private Int32 id_producto_cliente;

        public Int32 Id_producto_cliente
        {
            get { return id_producto_cliente; }
            set { id_producto_cliente = value; }
        }
        private Int32 id_cliente;

        public Int32 Id_cliente
        {
            get { return id_cliente; }
            set { id_cliente = value; }
        }
        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

    }
}
