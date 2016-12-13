using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
    public class Codigo_TAG
    {
        private Int32 id_tag;

        public Int32 Id_tag
        {
            get { return id_tag; }
            set { id_tag = value; }
        }
        private string codigo;

        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        private bool activo;

        public bool Activo
        {
            get { return activo; }
            set { activo = value; }
        }
    }
}
