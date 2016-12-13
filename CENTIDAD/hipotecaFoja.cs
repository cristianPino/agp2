using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
    public class hipotecaFoja 
    {
        public int IdFoja { get; set; }
        public int IdSolicitud { get; set; }
        public string CodigoTipo { get; set; }
        public Parametro TipoFoja { get; set; }
        public string InscripcionFoja { get; set; }
        public string InscripcionFojaLetra { get; set; }
        public string InscripcionNumero { get; set; }
        public string InscripcionAnio { get; set; }
        public string Observacion { get; set; }

    }
}
