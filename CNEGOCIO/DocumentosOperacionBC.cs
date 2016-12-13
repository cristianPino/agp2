using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;

namespace CNEGOCIO
{
	public class DocumentosOperacionBC
	{

		public string add_documentos(Int32 id_solicitud, Int32 id_documento, string url, string extension, Int64 peso, string observaciones,string cuenta_usuario)
		{
            return new DocumentosOperacionDAC().add_documentos(id_solicitud, id_documento, url, extension, peso, observaciones, cuenta_usuario);
		}

		public string del_documentos(Int32 id_documento_operacion,string cuentaUsuario)
		{
			return new DocumentosOperacionDAC().del_documentos(id_documento_operacion, cuentaUsuario);
		}

		public List<DocumentosOperacion> getDocumentos(Int32 id_solicitud, Int32 id_documento)
		{
			return new DocumentosOperacionDAC().getDocumentos(id_solicitud, id_documento);
		}

		public List<DocumentosOperacion> getDocumentosAsociados(Int32 id_solicitud)
		{
			return new DocumentosOperacionDAC().getDocumentosAsociados(id_solicitud);
		}
        public List<DocumentosOperacion> GetDocumentosTipoGastos(int idSolicitud)
        {
            return new DocumentosOperacionDAC().GetDocumentosTipoGastos(idSolicitud);
        }
	}
}