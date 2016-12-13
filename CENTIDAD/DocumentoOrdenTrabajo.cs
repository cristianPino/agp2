using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CENTIDAD
{
    public  class DocumentoOrdenTrabajo
    {
        public int IdDocumentoOrdenTrabajo { get; set; }
        public Documentos Documento { get; set; }
        public OrdenTrabajo OrdenTrabajo { get; set; }
    }
}
