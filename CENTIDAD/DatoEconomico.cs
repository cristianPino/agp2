using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
    public class DatoEconomico
    {

        private string codigo;
        private double valor;

        public double Valor
        {
            get { return valor; }
            set { valor = value; }
        }

        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        

    }
}
