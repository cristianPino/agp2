using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
    public class Marcavehiculo
    {
        private int id_marca;
        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public int Id_marca
        {
            get { return id_marca; }
            set { id_marca = value; }
        }


    }
}
