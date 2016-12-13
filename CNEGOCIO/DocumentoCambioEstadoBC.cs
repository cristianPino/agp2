using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CACCESO;
using CENTIDAD;

namespace CNEGOCIO
{
    public class DocumentoCambioEstadoBC
    {
        public List<DocumentoCambioEstado> GetAllDocumentosCambioEstado(int idFamilia, int idCliente)
        {
            return new DocumentoCambioEstadoDAC().GetAllDocumentosCambioEstado(idFamilia, idCliente);
        }
        public void AddDocumentosCambioEstado(DocumentoCambioEstado doc)
        {
            new DocumentoCambioEstadoDAC().AddDocumentosCambioEstado(doc);
        }
        public void DelDocumentosCambioEstado(DocumentoCambioEstado doc)
        {
            new DocumentoCambioEstadoDAC().DelDocumentosCambioEstado(doc);
        }
        public int GotoDocumentosCambioEstado(int idSolicitud, int idDocumento, string cuentausuario)
        {
            return new DocumentoCambioEstadoDAC().GotoDocumentosCambioEstado(idSolicitud, idDocumento, cuentausuario);
        }
    }


}
