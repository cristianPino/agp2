using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
    public class Acreedor
    {
        private Persona p_acreedor;

        public Persona P_acreedor
        {
            get { return p_acreedor; }
            set { p_acreedor = value; }
        }
        private Int32 id_prohibicion;

        public Int32 Id_prohibicion
        {
            get { return id_prohibicion; }
            set { id_prohibicion = value; }
        }
        private Int32 id_acreedor;

        public Int32 Id_acreedor
        {
            get { return id_acreedor; }
            set { id_acreedor = value; }
        }

    }
}
