using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
    public class Hipoteca_FormaPago
    {

        public int IdSolicitud { get; set; }
        public Int32 IdFormaPago { get; set; }

        public Int32 CuotainicioTasaMixta { get; set; }   
        public Int32 CuotaFinalTasaFija  { get; set; }    
        public string TasaFija  { get; set; }
        public string TasaMixta { get; set; }   
        public string ValorDividendoTasaFija { get; set; }
        public string ValorDividendoTasaMixta { get; set; }
        public string ValorPrimerosDividendos { get; set; }
        public string ValorUltimoDividendo { get; set; }


    }
}
