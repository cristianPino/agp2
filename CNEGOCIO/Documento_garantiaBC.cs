using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CACCESO;
using CENTIDAD;


namespace CNEGOCIO
{
    public class Documento_garantiaBC
    {

        public Documento_garantia getdocumento_garantia(Int32 id_solicitud)
        {
            return new Documento_garantiaDAC().getdocumentos_garantia(id_solicitud);
        }
        public string add_documento_garantia(Int32 id_solicitud, string cuenta_usuario, Int32 cod_matriz, DateTime fecha_doc,bool documento)
        {
            string add = new Documento_garantiaDAC().add_documento_garantia(cuenta_usuario,id_solicitud,cod_matriz,documento,fecha_doc);
            return add;
        }
		public string add_escritura_pendiente(int id_solicitud, string origen, string destino)
		{
			return new Documento_garantiaDAC().add_escritura_pendiente(id_solicitud, origen, destino);
		}
    }
}
