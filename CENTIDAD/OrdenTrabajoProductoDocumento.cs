using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
    public class OrdenTrabajoProductoDocumento
    {
        public string CodigoProdicto { get; set; }
        public int IdDocumento { get; set; }
        public TipoOperacion TipoOperacion { get; set; }
        public Documentos Documento { get; set; }
        public bool Existe { get; set; }
    }
}
