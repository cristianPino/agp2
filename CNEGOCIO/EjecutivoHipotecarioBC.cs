using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CENTIDAD;
using CACCESO;

namespace CNEGOCIO
{
    public class EjecutivoHipotecarioBC
    {
        public List<EjecutivoHipotecario> GetEjecutivoHipotecaBySucursal(int idSucursal)
        {
            return new EjecutivoHipotecarioDAC().GetEjecutivoHipotecaBySucursal(idSucursal);
        }
    }
}
