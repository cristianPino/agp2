using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
    public class DocumentoCambioEstado
    {
        public int IdDocumentoCambioEstado { get; set; }
        public int IdCliente { get; set; }
        public int IdDocumento { get; set; }
        public int SiguienteCodigoEstado { get; set; }
        public int IdFamilia { get; set; }
        public string NombreDocumento { get; set; }
    }
}
