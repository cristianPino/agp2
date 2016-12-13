using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CACCESO;
using CENTIDAD;

namespace CNEGOCIO
{
    public class DocumentoEstadoBC
    {

        public List<DocumentoEstado> DocumentosbyEstado(Int32 codigo_estado)
        {
            return new DocumentoEstadoDAC().DocumentosbyEstado(codigo_estado);
        }

        public string add_Documento_Estado(Int32 codigo_estado, Int32 id_documento)
        {
            return new DocumentoEstadoDAC().add_Documento_Estado(codigo_estado, id_documento);
        }

        public string del_documento_estado(Int32 codigo_estado, Int32 id_documento)
        {
            return new DocumentoEstadoDAC().del_documento_estado(codigo_estado,id_documento);
        }

    }
}
