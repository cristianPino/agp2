using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

 namespace CENTIDAD
{
    public class Contratos
    {
        private Int32 id_contrato;

        public Int32 Id_contrato
        {
            get { return id_contrato; }
            set { id_contrato = value; }
        }
        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        private string descripcion;

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
    }
}
