using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
    public class ModuloCliente
    {
        private Int16 id_modulo;
        private string nombre;
        private Cliente cliente;
        private Boolean check;

        public Boolean Check
        {
            get { return check; }
            set { check = value; }
        }

        public Int16 Id_modulo
        {
            get { return id_modulo; }
            set { id_modulo = value; }
        }
        

        public Cliente Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }
        

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }



    }
}
