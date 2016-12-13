using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
    public class ContratoCliente
    {
        private Int32 id_cliente;

        public Int32 Id_cliente
        {
            get { return id_cliente; }
            set { id_cliente = value; }
        }
        private Int32 id_contrato;

        public Int32 Id_contrato
        {
            get { return id_contrato; }
            set { id_contrato = value; }
        }

        private Boolean check;

        public Boolean Check
        {
            get { return check; }
            set { check = value; }
        }

        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
    }
}
