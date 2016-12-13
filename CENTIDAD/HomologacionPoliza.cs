using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
    public class HomologacionPoliza
    {
        private Tipovehiculo tipovehiculo;

        public Tipovehiculo Tipovehiculo
        {
            get { return tipovehiculo; }
            set { tipovehiculo = value; }
        }
        private string codigo;

        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        private Int32 codigoTipVehDist;

        public Int32 CodigoTipVehDist
        {
            get { return codigoTipVehDist; }
            set { codigoTipVehDist = value; }
        }

    }
}
