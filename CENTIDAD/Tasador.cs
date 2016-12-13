using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
    public class Tasador
    {
        private Usuario usu_tasador;

        public Usuario Usu_tasador
        {
            get { return usu_tasador; }
            set { usu_tasador = value; }
        }
        private Int32 id_cliente;

        public Int32 Id_cliente
        {
            get { return id_cliente; }
            set { id_cliente = value; }
        }

        private bool check;

        public bool Check
        {
            get { return check; }
            set { check = value; }
        }
    }
}
