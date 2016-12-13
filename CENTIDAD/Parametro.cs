using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
    public class Parametro
    {

        protected string codigoparametro;
        protected string valoralfanumerico;
        protected double valornumerico;
        protected int orden;

        public  string Codigoparametro
        {
            get { return codigoparametro; }
            set { codigoparametro = value; }
        }
        

        public string Valoralfanumerico
        {
            get { return valoralfanumerico; }
            set { valoralfanumerico = value; }
        }
        

        public  double Valornumerico
        {
            get { return valornumerico; }
            set { valornumerico = value; }
        }
        

        public  int Orden
        {
            get { return orden; }
            set { orden = value; }
        }


    
    }
}
