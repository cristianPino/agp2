using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
    public class Comuna
    {

        private int id_comuna;
        private Ciudad ciudad;
        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public Ciudad Ciudad
        {
            get { return ciudad; }
            set { ciudad = value; }
        }

        public int Id_Comuna
        {
            get { return id_comuna; }
            set { id_comuna = value; }
        }

    }
}
