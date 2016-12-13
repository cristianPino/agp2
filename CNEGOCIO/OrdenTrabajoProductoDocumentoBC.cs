using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;

namespace CNEGOCIO
{
    public class OrdenTrabajoProductoDocumentoBC
    {
        public List<OrdenTrabajoProductoDocumento> GetAllProductos()
        {
            return new OrdenTrabajoProductoDocumentoDAC().GetAllProductos();
        }
        public List<OrdenTrabajoProductoDocumento> GetAllDocumentoByProducto(string codigoProducto)
        {
            return new OrdenTrabajoProductoDocumentoDAC().GetAllDocumentoByProducto(codigoProducto);
        }

        public bool ExisteProducto(int idOrdenTrabajo, string idProducto)
        {
            return new OrdenTrabajoProductoDocumentoDAC().ExisteProducto(idOrdenTrabajo, idProducto);
        }

        public bool ExisteDocumento(int idOrdenTrabajo, int idDocumnento)
        {
            return new OrdenTrabajoProductoDocumentoDAC().ExisteDocumento(idOrdenTrabajo, idDocumnento);
        }


    }
}
