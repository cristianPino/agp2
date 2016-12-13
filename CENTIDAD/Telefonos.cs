using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
    public class Telefonos
    {

        private Int32 id_telefono;

        public Int32 Id_telefono
        {
            get { return id_telefono; }
            set { id_telefono = value; }
        }
        private Int32 rut;

        public Int32 Rut
        {
            get { return rut; }
            set { rut = value; }
        }
        private string tipo_telefono;

        public string Tipo_telefono
        {
            get { return tipo_telefono; }
            set { tipo_telefono = value; }
        }
        private Int32 numero;

        public Int32 Numero
        {
            get { return numero; }
            set { numero = value; }
        }
        private string check;

        public string Check
        {
            get { return check; }
            set { check = value; }
        }

    }
}
