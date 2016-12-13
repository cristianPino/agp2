using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CACCESO;
using CENTIDAD;

namespace CNEGOCIO
{
    public class HipotecaClausulaBC
    {
        public List<HipotecaClausula> GetAll(Int32 idCliente, int idTipoCredito)
        {
            return new HipotecaClausulaDAC().GetAll(idCliente, idTipoCredito);
        }
        public string DelClausula(Int32 idCalusula, int tipoCredito)
        {
            return new HipotecaClausulaDAC().DelClausula(idCalusula, tipoCredito);
        }
        public string AddClausula(Int32 idCalusula, int tipoCredito)
        {
            return new HipotecaClausulaDAC().AddClausula(idCalusula, tipoCredito);
        }

    }
}
