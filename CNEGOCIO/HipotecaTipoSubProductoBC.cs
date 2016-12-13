using System;
using System.Collections.Generic;  
using CENTIDAD;
using CACCESO;
namespace CNEGOCIO
{
    public class HipotecaTipoSubProductoBC
    {
        public List<HipotecaTipoSubProducto> GetAll(HipotecaTipoSubProducto h)
        {
            try
            {
                return new HipotecaTipoSubProductoDAC().GetAll(h);
            }
            catch(Exception exception)
            {
                throw;
            }
            
        }
    }
}
